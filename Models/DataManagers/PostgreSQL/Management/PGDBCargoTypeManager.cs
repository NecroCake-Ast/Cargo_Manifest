using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Summary description for PGDBCargoTypeManager
/// </summary>
namespace Practic_3_curs.Models
{
    public class PGDBCargoTypeManager : ICargoTypeManager
    {
        string Connect_Setting;  //!< Данные для подключения к БД
        public PGDBCargoTypeManager(string connect_setting)
        {
            Connect_Setting = connect_setting;
        }

        /// <summary>
        /// Добавление нового товара
        /// </summary>
        /// <param name="cargotype">Данные нового товара</param>
        public void Add(Stored_CargoType cargotype)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "INSERT INTO \"Cargo_Type\" (\"EN_Name\", \"RU_Name\") "
                            + "VALUES ('" + cargotype.En_Name + "', '" + cargotype.Ru_Name + "')";
            cmd.ExecuteNonQuery();
            DB.Close();
        }

        /// <summary>
        /// Получение списка товаров
        /// </summary>
        /// <returns>Список товаров</returns>
        public List<Stored_CargoType> GetAllCargoTypes()
        {
            List<Stored_CargoType> cargotypes = new List<Stored_CargoType>();
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "SELECT \"ID\", \"EN_Name\", \"RU_Name\" FROM \"Cargo_Type\" ORDER BY \"ID\"";
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Stored_CargoType addType = new Stored_CargoType();
                addType.ID = reader.GetInt32(0);
                addType.En_Name = reader.GetString(1);
                addType.Ru_Name = reader.GetString(2);
                cargotypes.Add(addType);
            }
            DB.Close();
            return cargotypes;
        }

        /// <summary>
        /// Возвращает ID типа груза по названию
        /// </summary>
        /// <param name="Name"></param>
        /// <returns>ID типа груза</returns>
        public int GetTypeByName(string Name)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "SELECT \"ID\" FROM \"Cargo_Type\" WHERE \"RU_Name\" = '" + Name
                + "' OR \"EN_Name\" = '" + Name + "'";
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                DB.Close();
                return reader.GetInt32(0);
            }
            DB.Close();
            throw new Exception("Типа груза с таким названием не существует");
        }

        /// <summary>
        /// Удаление информации о товарах
        /// </summary>
        /// <param name="id">Код удаляемого товара</param>
        public void Remove(int id)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "DELETE FROM \"Cargo_Type\" WHERE \"ID\" = " + id;
            cmd.ExecuteNonQuery();
            DB.Close();
        }

        /// <summary>
        /// Обновление данных о товарах
        /// </summary>
        /// <param name="cargotype">Новые данные</param>
        public void Update(Stored_CargoType cargotype)
        {
            if (cargotype.Ru_Name != "" || cargotype.En_Name != "")
            {
                NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
                DB.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = DB;
                cmd.CommandText = "UPDATE \"Cargo_Type\" SET";
                if (cargotype.En_Name != "")
                {
                    cmd.CommandText += " \"EN_Name\" = '" + cargotype.En_Name + "'";
                    if (cargotype.Ru_Name != "")
                        cmd.CommandText += ",";
                }
                if (cargotype.Ru_Name != "")
                    cmd.CommandText += "\"RU_Name\" = '" + cargotype.Ru_Name + "'";
                cmd.CommandText += " WHERE \"ID\" = " + cargotype.ID;
                cmd.ExecuteNonQuery();
                DB.Close();
            }
        }
    }
}
