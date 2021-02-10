using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Summary description for PGDBCargoManager
/// </summary>
namespace Practic_3_curs.Models
{
    public class PGDBCargoManager : ICargoManager
    {
        string Connect_Setting;  //!< Данные для подключения к БД
        public PGDBCargoManager(string connect_setting)
        {
            Connect_Setting = connect_setting;
        }

        /// <summary>
        /// Добавление нового груза
        /// </summary>
        /// <param name="cargo">Данные нового груза</param>
        public void Add(Stored_Cargo cargo)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "INSERT INTO \"Cargo\" (\"Place_Count\", \"Weight\", \"Volume\", \"Type\", \"Sender\", \"Recipient\", \"Waybill\") "
                            + "VALUES ('" + cargo.Place_Count + "', '" + cargo.Weight + "', '" + cargo.Volume + "', '" + cargo.Type + "', '"
                            + cargo.Sender + "', '" + cargo.Recipient + "', '" + cargo.Waybill + ")";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Получение списка грузов
        /// </summary>
        /// <returns>Список грузов</returns>
        public List<Stored_Cargo> GetAllCargo()
        {
            List<Stored_Cargo> cargos = new List<Stored_Cargo>();
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "SELECT \"Place_Count\", \"Weight\", \"Volume\", \"Type\", \"Sender\", \"Recipient\", \"Waybill\" FROM \"Cargo\" ORDER BY \"ID\"";
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Stored_Cargo addCargo = new Stored_Cargo();
                addCargo.Place_Count = reader.GetInt32(0);
                addCargo.Weight = reader.GetFloat(1);
                addCargo.Volume = reader.GetFloat(2);
                addCargo.Type = reader.GetInt32(3);
                addCargo.Sender = reader.GetInt32(4);
                addCargo.Recipient = reader.GetInt32(5);
                addCargo.Waybill = reader.GetInt32(6);
                cargos.Add(addCargo);
            }
            return cargos;
        }

        /// <summary>
        /// Удаление информации о грузах
        /// </summary>
        /// <param name="id">Код удаляемого груза</param>
        public void Remove(int id)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "DELETE FROM \"Cargo\" WHERE \"ID\" = '" + id + "'";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Обновление данных о грузах
        /// </summary>
        /// <param name="cargo">Новые данные</param>
        public void Update(Stored_Cargo cargo)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "UPDATE \"Cargo\" SET \"Place_Count\" = '" + cargo.Place_Count
                + "', \"Weight\" = '" + cargo.Weight +
                "', \"Volume\" = '" + cargo.Volume + "', \"Type\" = '" + cargo.Type + "', \"Sender\" = '" + cargo.Sender + "', \"Recipient\" = '" + cargo.Recipient +
                "' WHERE \"Waybill\" = '" + cargo.Waybill + "'";
            cmd.ExecuteNonQuery();
        }
    }
}
