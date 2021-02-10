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
        public void Add(Stored_Manifest manifest)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "INSERT INTO \"Manifest\" (\"Carrier\", \"Flight\", \"Aircraft\", \"From\", \"To\", \"Date\") "
                            + "VALUES ('" + manifest.Carrier + "', '" + manifest.Flight + "', '" + manifest.Aircraft + "', '" + manifest.From + "', '"
                            + manifest.To + "', '" + manifest.Date + ")";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Получение списка манифеста
        /// </summary>
        /// <returns>Список манифеста</returns>
        public List<Stored_Manifest> GetAllManifest()
        {
            List<Stored_Manifest> manifests = new List<Stored_Manifest>();
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "SELECT \"ID\", \"Carrier\", \"Flight\", \"Aircraft\", \"From\", \"To\", \"Date\" FROM \"Manifest\" ORDER BY \"Date\"";
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Stored_Manifest addManifest = new Stored_Manifest();
                addManifest.ID = reader.GetInt32(0);
                addManifest.Carrier = reader.GetInt32(1);
                addManifest.Flight = reader.GetInt64(2);
                addManifest.Aircraft = reader.GetInt64(3);
                addManifest.From = reader.GetInt32(4);
                addManifest.To = reader.GetInt32(5);
                addManifest.Date = reader.GetDateTime(6);
                manifests.Add(addManifest);
            }
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
        }

        /// <summary>
        /// Обновление данных о манифесте
        /// </summary>
        /// <param name="manifest">Новые данные</param>
        public void Update(Stored_Manifest manifest)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "UPDATE \"Manifest\" SET \"Carrier\" = '" + manifest.Carrier
                + "', \"Aircraft\" = '" + manifest.Aircraft +
                "', \"From\" = '" + manifest.From + "', \"To\" = '" + manifest.To + "', \"Date\" = '" + manifest.Date + 
                "' WHERE \"Flight\" = '" + manifest.Flight + "' AND \"Carrier\"" + manifest.Carrier;
            cmd.ExecuteNonQuery();
        }
    }
}