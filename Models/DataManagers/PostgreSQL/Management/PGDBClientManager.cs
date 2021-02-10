using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Summary description for PGDBClientManager
/// </summary>
namespace Practic_3_curs.Models
{
    public class PGDBClientManager : IClientManager
    {
        string Connect_Setting;  //!< Данные для подключения к БД
        public PGDBClientManager(string connect_setting)
        {
            Connect_Setting = connect_setting;
        }

        /// <summary>
        /// Добавление нового клиента
        /// </summary>
        /// <param name="client">Данные нового клиента</param>
        public void Add(Stored_Client client)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "INSERT INTO \"Client\" (\"Name\", \"Phone\") "
                            + "VALUES ('" + client.Name + "', '" + client.Phone + ")";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        /// <returns>Список клиентов</returns>
        public List<Stored_Client> GetAllClients()
        {
            List<Stored_Client> clients = new List<Stored_Client>();
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "SELECT \"ID\", \"Name\", \"Phone\" FROM \"Client\" ORDER BY \"ID\"";
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Stored_Client addClient = new Stored_Client();
                addClient.ID = reader.GetInt32(0);
                addClient.Name = reader.GetString(1).TrimEnd();
                addClient.Phone = reader.GetString(2).TrimEnd();
                clients.Add(addClient);
            }
            return clients;
        }

        /// <summary>
        /// Удаление информации о клиентах
        /// </summary>
        /// <param name="id">Код удаляемого клиента</param>
        public void Remove(int id)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "DELETE FROM \"Client\" WHERE \"ID\" = '" + id + "'";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Обновление данных о клиентах
        /// </summary>
        /// <param name="client">Новые данные</param>
        public void Update(Stored_Client client)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "UPDATE \"Client\" SET \"Name\" = '" + client.Name
                + "', \"Phone\" = '" + client.Phone + "' WHERE \"ID\" = '" + client.ID + "'";
            cmd.ExecuteNonQuery();
        }
    }
}
