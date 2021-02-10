using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Summary description for PGDBWaybillManager
/// </summary>
namespace Practic_3_curs.Models
{
    public class PGDBWaybillManager : IWaybillManager
    {
        string Connect_Setting;  //!< Данные для подключения к БД
        public PGDBWaybillManager(string connect_setting)
        {
            Connect_Setting = connect_setting;
        }

        /// <summary>
        /// Добавление новой накладной
        /// </summary>
        /// <param name="cargotype">Данные новой накладной</param>
        public void Add(CWaybill waybill)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "INSERT INTO \"Waybill\" (\"Number\", \"Code\", \"Manifest\") "
                            + "VALUES ('" + waybill.Num + "', '" + waybill.Code + "', '" + waybill.Manifest + ")";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Получение списка накладных
        /// </summary>
        /// <returns>Список накладных</returns>
        public List<CWaybill> GetAllWaybill()
        {
            List<CWaybill> waybills = new List<CWaybill>();
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "SELECT \"Number\", \"Code\", \"Manifest\" FROM \"Waybill\" ORDER BY \"Code\"";
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CWaybill addWaybill = new CWaybill();
                addWaybill.Num = reader.GetInt32(0);
                addWaybill.Code = reader.GetInt32(1);
                addWaybill.Manifest = reader.GetInt32(2);
                waybills.Add(addWaybill);
            }
            return waybills;
        }

        /// <summary>
        /// Удаление информации о накладных
        /// </summary>
        /// <param name="code">Код удаляемой накладной</param>
        public void Remove(int code)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "DELETE FROM \"Waybill\" WHERE \"Code\" = '" + code + "'";
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Обновление данных о накладных
        /// </summary>
        /// <param name="waybill">Новые данные</param>
        public void Update(CWaybill waybill)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "UPDATE \"Waybill\" SET \"Code\" = '" + waybill.Code
                + "', \"Manifest\" = '" + waybill.Manifest + "' WHERE \"Number\" = '" + waybill.Num + "'";
            cmd.ExecuteNonQuery();
        }
    }
}
