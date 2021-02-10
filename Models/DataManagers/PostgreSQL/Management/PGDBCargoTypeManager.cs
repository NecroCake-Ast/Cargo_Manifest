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
        }

        /// <summary>
        /// Получение списка товаров
        /// </summary>
        /// <returns>Список товаров</returns>
        public List<Stored_CargoType> GetAllCargoType()
        {
            List<Stored_CargoType> cargotypes = new List<Stored_CargoType>();
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "SELECT \"EN_Name\", \"RU_Name\" FROM \"Cargo_Type\" ORDER BY \"ID\"";
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Stored_CargoType addType = new Stored_CargoType();
                addType.En_Name = reader.GetString(0);
                addType.Ru_Name = reader.GetString(1);
                cargotypes.Add(addType);
            }
            return cargotypes;
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
            cmd.CommandText = "DELETE FROM \"Cargo_Type\" WHERE \"ID\" = '" + id + "'";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Обновление данных о товарах
        /// </summary>
        /// <param name="cargotype">Новые данные</param>
        public void Update(Stored_CargoType cargotype)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "UPDATE \"Cargo_Type\" SET \"En_Mane\" = '" + cargotype.En_Name
                + "', \"RU_Name\" = '" + cargotype.Ru_Name + "' WHERE \"EN_Name\" = '" + cargotype.En_Name + "'";
            cmd.ExecuteNonQuery();
        }
    }
}
