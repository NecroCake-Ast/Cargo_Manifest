using Npgsql;
using System;
using System.Collections.Generic;

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
            cmd.CommandText = "INSERT INTO \"Airport\" (\"EN_Name\", \"RU_Name\") "
                            + "VALUES ('" + airport.En_Name + "', '" + airport.Ru_Name + "')";
            cmd.ExecuteNonQuery();
            DB.Close();
        }

        /// <summary>
        /// Получение списка аэропортов
        /// </summary>
        /// <returns>Список аэропортов</returns>
        public List<Stored_Airport> GetAllAirports()
        {
            List<Stored_Airport> airports = new List<Stored_Airport>();
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "SELECT \"ID\", \"EN_Name\", \"RU_Name\" FROM \"Airport\" ORDER BY \"ID\"";
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Stored_Airport addAirport = new Stored_Airport();
                addAirport.ID = reader.GetInt32(0);
                addAirport.En_Name = reader.GetString(1);
                addAirport.Ru_Name = reader.GetString(2);
                airports.Add(addAirport);
            }
            DB.Close();
            return airports;
        }

        public int GetAirportByName(string name)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "SELECT \"ID\" FROM \"Airport\" WHERE \"RU_Name\" = '" + name
                + "' OR \"EN_Name\" = '" + name + "'";
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return reader.GetInt32(0);
            DB.Close();
            throw new Exception("Перевозчика с заданным ID не существует");
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
            DB.Close();
        }

        /// <summary>
        /// Обновление данных о аэропортах
        /// </summary>
        /// <param name="airport">Новые данные</param>
        public void Update(Stored_Airport airport)
        {
            if (airport.Ru_Name != "" || airport.En_Name != "")
            {
                NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
                DB.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = DB;
                cmd.CommandText = "UPDATE \"Airport\" SET";
                if (airport.En_Name != "")
                {
                    cmd.CommandText += " \"EN_Name\" = '" + airport.En_Name + "'";
                    if (airport.Ru_Name != "")
                        cmd.CommandText += ",";
                }
                if (airport.Ru_Name != "")
                    cmd.CommandText += " \"RU_Name\" = '" + airport.Ru_Name + "'";
                cmd.CommandText += " WHERE \"ID\" = " + airport.ID;
                DB.Close();
                cmd.ExecuteNonQuery();
            }
        }
    }
}