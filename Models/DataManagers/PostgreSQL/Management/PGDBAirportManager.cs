using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Summary description for PGDBAirportManager
/// </summary>
namespace Practic_3_curs.Models
{
    public class PGDBAirportManager : IAirportManager
    {
        string Connect_Setting;  //!< Данные для подключения к БД
        public PGDBAirportManager(string connect_setting)
        {
            Connect_Setting = connect_setting;
        }

        /// <summary>
        /// Добавление нового аэропорта
        /// </summary>
        /// <param name="airport">Данные нового аэропорта</param>
        public void Add(Stored_Airport airport)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "INSERT INTO \"Airport\" (\"En_Name\", \"Ru_Name\") "
                            + "VALUES ('" + airport.En_Name + "', '" + airport.Ru_Name + "')";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Получение списка аэропортов
        /// </summary>
        /// <returns>Список аэропортов</returns>
        public List<Stored_Airport> GetAllAirport()
        {
            List<Stored_Airport> airports = new List<Stored_Airport>();
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "SELECT \"EN_Name\", \"RU_Name\" FROM \"Airport\" ORDER BY \"ID\"";
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Stored_Airport addAirport = new Stored_Airport();
                addAirport.En_Name = reader.GetString(0);
                addAirport.Ru_Name = reader.GetString(1);
                airports.Add(addAirport);
            }
            return airports;
        }

        /// <summary>
        /// Удаление информации о аэропортах
        /// </summary>
        /// <param name="id">Код удаляемого аэропорта</param>
        public void Remove(int id)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "DELETE FROM \"Airport\" WHERE \"ID\" = '" + id + "'";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Обновление данных о аэропортах
        /// </summary>
        /// <param name="airport">Новые данные</param>
        public void Update(Stored_Airport airport)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "UPDATE \"Airport\" SET \"En_Mane\" = '" + airport.En_Name
                + "', \"RU_Name\" = '" + airport.Ru_Name + "' WHERE \"EN_Name\" = '" + airport.En_Name + "'";
            cmd.ExecuteNonQuery();
        }
    }
}