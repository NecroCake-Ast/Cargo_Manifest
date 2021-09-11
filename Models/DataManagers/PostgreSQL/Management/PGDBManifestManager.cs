using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Summary description for PGDBManifestManager
/// </summary>
namespace Practic_3_curs.Models
{
    public class PGDBManifestManager : IManifestManager
    {
        string Connect_Setting;  //!< Данные для подключения к БД
        public PGDBManifestManager(string connect_setting)
        {
            Connect_Setting = connect_setting;
        }

        /// <summary>
        /// Добавление нового манифеста
        /// </summary>
        /// <param name="manifest">Данные нового манифеста</param>
        public void Add(Stored_Manifest manifest, IAirportManager airportManager, ICarrierManager carrierManager)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "INSERT INTO \"Manifest\" (\"Carrier\", \"Flight\", \"Aircraft\", \"From\", \"To\", \"Date\") "
                            + "VALUES ('" + manifest.Carrier + "', '" + manifest.Flight + "', '"
                            + manifest.Aircraft + "', '" + airportManager.GetAirportByName(manifest.From) + "', '"
                            + airportManager.GetAirportByName(manifest.To) + "', '" + manifest.Date + "')";
            cmd.ExecuteNonQuery();
            DB.Close();
        }

        /// <summary>
		/// Возвращает код селекта деклараций из базы данных
		/// </summary>
		/// <returns>Код селекта деклараций</returns>
		string Manifest_Select_Code()
        {
            return (
                    "SELECT \"Manifest\".\"ID\", \"Manifest\".\"Carrier\", "
                  + "       \"Manifest\".\"Flight\", \"Manifest\".\"Aircraft\", "
                  + "       \"From\".\"EN_Name\", \"To\".\"EN_Name\", "
                  + "       \"Manifest\".\"Date\" "
                  + "FROM \"Manifest\", "
                  + "     \"Airport\" AS \"From\", \"Airport\" AS \"To\" "
                  + "WHERE \"From\".\"ID\" = \"Manifest\".\"From\" "
                  + "  AND \"To\".\"ID\" = \"Manifest\".\"To\" "
                  + "ORDER BY \"Manifest\".\"Date\" DESC "
            );
        }

        /// <summary>
        /// Получение списка манифеста
        /// </summary>
        /// <returns>Список манифестов</returns>
        public List<Stored_Manifest> GetAllManifest()
        {
            List<Stored_Manifest> manifests = new List<Stored_Manifest>();
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = Manifest_Select_Code();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Stored_Manifest addManifest = new Stored_Manifest();
                addManifest.ID = reader.GetInt32(0);
                addManifest.Carrier = reader.GetString(1).TrimEnd();
                addManifest.Flight = reader.GetString(2).TrimEnd();
                addManifest.Aircraft = reader.GetString(3).TrimEnd();
                addManifest.From = reader.GetString(4).TrimEnd();
                addManifest.To = reader.GetString(5).TrimEnd();
                addManifest.Date = reader.GetDateTime(6);
                manifests.Add(addManifest);
            }
            DB.Close();
            return manifests;
        }

        /// <summary>
        /// Удаление информации о манифесте
        /// </summary>
        /// <param name="id">Код удаляемого манифеста</param>
        public void Remove(int id)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "DELETE FROM \"Manifest\" WHERE \"ID\" = '" + id + "'";
            cmd.ExecuteNonQuery();
            DB.Close();
        }

        private string GenUpdateCommand(Stored_Manifest manifest, IAirportManager airportManager, ICarrierManager carrierManager)
        {
            string cmdText = "";
            // Тип груза
            if (manifest.Carrier != "")
                try
                {
                    cmdText += ", \"Carrier\" = '" + manifest.Carrier + "'";
                }
                catch { }
            // Вес груза
            if (manifest.Flight != "")
                cmdText += ", \"Flight\" = '" + manifest.Flight + "'";
            // Объём груза
            if (manifest.Aircraft != "")
                cmdText += ", \"Aircraft\" = '" + manifest.Aircraft + "'";
            // Отправитель
            if (manifest.From != "")
                try
                {
                    cmdText += ", \"From\" = '" + airportManager.GetAirportByName(manifest.From) + "'";
                }
                catch { }
            // Получатель
            if (manifest.To != "")
                try
                {
                    cmdText += ", \"To\" = '" + airportManager.GetAirportByName(manifest.To) + "'";
                }
                catch { }
            // Объём груза
            if (manifest.Date != null)
                cmdText += ", \"Date\" = '" + manifest.Date + "'";

            cmdText = "UPDATE \"Manifest\" SET " + cmdText.Substring(1) + " WHERE \"ID\" = '" + manifest.ID + "'";
            return cmdText;
        }


        /// <summary>
        /// Обновление данных о манифесте
        /// </summary>
        /// <param name="manifest">Новые данные</param>
        public void Update(Stored_Manifest manifest, IAirportManager airportManager, ICarrierManager carrierManager)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = GenUpdateCommand(manifest, airportManager, carrierManager);
            cmd.ExecuteNonQuery();
            DB.Close();
        }
    }
}