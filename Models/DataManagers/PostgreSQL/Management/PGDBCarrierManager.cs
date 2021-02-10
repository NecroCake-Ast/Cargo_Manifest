using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practic_3_curs.Models
{
    /// <summary>
    /// Класс, выполняющий управление данными о перевозчиках
    /// в базе данных PostgreSQL
    /// </summary>
    public class PGDBCarrierManager : ICarrierManager
    {
        string Connect_Setting;  //!< Данные для подключения к БД
        public PGDBCarrierManager(string connect_setting)
        {
            Connect_Setting = connect_setting;
        }

        /// <summary>
        /// Добавление нового перевозчика
        /// </summary>
        /// <param name="carrier">Данные нового перевозчика</param>
        public void Add(CCarrier carrier)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "INSERT INTO \"Carrier\" (\"Code\", \"Name\", \"Mail\") "
                            + "VALUES ('" + carrier.Code + "', '" + carrier.Name + "', '"
                            + carrier.Mail + "')";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Получение списка перевозчиков
        /// </summary>
        /// <returns>Список перевозчиков</returns>
        public List<CCarrier> GetAllCarriers()
        {
            List<CCarrier> carriers = new List<CCarrier>();
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "SELECT \"Code\", \"Name\", \"Mail\" FROM \"Carrier\" ORDER BY \"Code\"";
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                CCarrier addCarrier = new CCarrier();
                addCarrier.Code = reader.GetString(0);
                addCarrier.Name = reader.GetString(1);
                addCarrier.Mail = reader.GetString(2);
                carriers.Add(addCarrier);
            }
            return carriers;
        }

        /// <summary>
        /// Удаление информации о перевозчике
        /// </summary>
        /// <param name="code">Код удаляемого перевозчика</param>
        public void Remove(string code)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "DELETE FROM \"Carrier\" WHERE \"Code\" = '" + code + "'";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Обновление данных о перевозчике
        /// </summary>
        /// <param name="carrier">Новые данные</param>
        public void Update(CCarrier carrier)
        {
            if (carrier.Mail != "" || carrier.Name != "")
            {
                NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
                DB.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = DB;
                cmd.CommandText = "UPDATE \"Carrier\" SET ";
                if (carrier.Name != "")
                {
                    cmd.CommandText += "\"Name\" = '" + carrier.Name + "'";
                    if (carrier.Mail != "")
                        cmd.CommandText += ",";
                }
                if (carrier.Mail != "")
                    cmd.CommandText += " \"Mail\" = '" + carrier.Mail + "'";
                cmd.CommandText += " WHERE \"Code\" = '" + carrier.Code + "'";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
