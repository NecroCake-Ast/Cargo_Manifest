using Npgsql;
using System;
using System.Collections.Generic;

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
		/// Возвращает код селекта данных о грузах из базы данных
		/// </summary>
		/// <returns>Код селекта данных о грузах</returns>
		string Cargo_Select_Code()
        {
            return (
                    "SELECT \"Waybill\".\"Code\", \"Waybill\".\"Number\", \"Waybill\".\"Manifest\", "
	             + "        \"Cargo\".\"ID\", \"Cargo\".\"Place_Count\", \"Cargo\".\"Weight\", "
	             + "        \"Cargo\".\"Volume\", \"Sender_Name\".\"Name\", "
	             + "        \"Recipient_Name\".\"Name\", \"Cargo_Type\".\"RU_Name\" "
                 + "FROM \"Waybill\", \"Cargo\", \"Client\" AS \"Sender_Name\", "
                 + "     \"Client\" AS \"Recipient_Name\", \"Cargo_Type\" "
                 + "WHERE \"Cargo\".\"Waybill\" = \"Waybill\".\"Number\" "
                 + "  AND \"Sender_Name\".\"ID\" = \"Cargo\".\"Sender\" "
                 + "  AND \"Recipient_Name\".\"ID\" = \"Cargo\".\"Recipient\" "
                 + "  AND \"Cargo_Type\".\"ID\" = \"Cargo\".\"Type\" "
                 + "ORDER BY \"Waybill\".\"Number\" DESC"
            );
        }

        /// <summary>
        /// Добавление кода накладной, номера накладной и номера декларации
        /// </summary>
        /// <param name="waybill">Данные накладной</param>
        void AddWaybill(Stored_Waybill waybill)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "INSERT INTO \"Waybill\" (\"Number\", \"Code\", \"Manifest\") "
                            + "VALUES ('" + waybill.Waybill_Number + "', '" + waybill.Waybill_Code + "', '"
                            + waybill.Manifest_ID + "')";
            cmd.ExecuteNonQuery();
            DB.Close();
        }

        /// <summary>
        /// Добавление информации о грузе
        /// </summary>
        /// <param name="waybill">Данные накладной</param>
        void AddCagro(Stored_Waybill waybill, int type, int sender, int recipient)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "INSERT INTO \"Cargo\" (\"Place_Count\", \"Weight\", \"Volume\", "
                            + "       \"Type\", \"Sender\", \"Recipient\", \"Waybill\") VALUES ('"
                            + waybill.Place_Count + "', '"
                            + waybill.Weight.ToString().Replace(',', '.') + "', '"
                            + waybill.Volume.ToString().Replace(',', '.') + "', '"
                            + type + "', '"
                            + sender + "', '"
                            + recipient + "', '"
                            + waybill.Waybill_Number + "')";
            cmd.ExecuteNonQuery();
            DB.Close();
        }

        /// <summary>
        /// Добавление новой накладной
        /// </summary>
        /// <param name="waybill">Данные новой накладной</param>
        public void Add(Stored_Waybill waybill, ICargoTypeManager typeManager, IClientManager clientManager)
        {
            if (waybill.Manifest_ID != -1 && waybill.Waybill_Number != -1)
            {
                int type = typeManager.GetTypeByName(waybill.Type);
                int sender_ID = clientManager.GetClientByName(waybill.Sender);
                int recipient_ID = clientManager.GetClientByName(waybill.Recipient);

                AddWaybill(waybill);
                try
                {
                    AddCagro(waybill, type, sender_ID, recipient_ID);
                }
                catch
                {
                    Remove(waybill.Waybill_Number);
                }
            }
        }

        /// <summary>
        /// Получение списка накладных
        /// </summary>
        /// <returns>Список накладных</returns>
        public List<Stored_Waybill> GetAllWaybills()
        {
            List<Stored_Waybill> waybills = new List<Stored_Waybill>();
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = Cargo_Select_Code();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Stored_Waybill addWaybill = new Stored_Waybill();
                addWaybill.Waybill_Code = reader.GetInt32(0);
                addWaybill.Waybill_Number = reader.GetInt32(1);
                addWaybill.Manifest_ID = reader.GetInt32(2);
                addWaybill.ID = reader.GetInt32(3);
                addWaybill.Place_Count = reader.GetInt32(4);
                addWaybill.Weight = reader.GetDouble(5);
                addWaybill.Volume = reader.GetDouble(6);
                addWaybill.Sender = reader.GetString(7).TrimEnd();
                addWaybill.Recipient = reader.GetString(8).TrimEnd();
                addWaybill.Type = reader.GetString(9).TrimEnd();
                waybills.Add(addWaybill);
            }
            DB.Close();
            return waybills;
        }

        /// <summary>
        /// Удаление информации о накладных
        /// </summary>
        /// <param name="number">Код удаляемой накладной</param>
        public void Remove(int number)
        {
            NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
            DB.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = DB;
            cmd.CommandText = "DELETE FROM \"Cargo\" WHERE \"Waybill\" = " + number;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DELETE FROM \"Waybill\" WHERE \"Number\" = " + number;
            cmd.ExecuteNonQuery();
            DB.Close();
        }

        private string GenUpdateCommand(Stored_Waybill waybill, ICargoTypeManager typeManager, IClientManager clientManager)
        {
            string cmdText = "";
            // Тип груза
            if (waybill.Type != "")
                try
                {
                    cmdText += ", \"Type\" = " + typeManager.GetTypeByName(waybill.Type);
                } catch { }
            // Вес груза
            if (waybill.Weight != 0)
                cmdText += ", \"Weight\" = " + waybill.Weight;
            // Объём груза
            if (waybill.Volume != 0)
                cmdText += ", \"Volume\" = " + waybill.Volume;
            // Количество занимаемых мест
            if (waybill.Place_Count != 0)
                cmdText += ", \"Place_Count\" = " + waybill.Place_Count;
            // Отправитель
            if (waybill.Sender != "")
                try
                {
                    cmdText += ", \"Sender\" = " + clientManager.GetClientByName(waybill.Sender);
                }
                catch { }
            // Получатель
            if (waybill.Recipient != "")
                try
                {
                    cmdText += ", \"Recipient\" = " + clientManager.GetClientByName(waybill.Recipient);
                }
                catch { }
            cmdText = "UPDATE \"Cargo\" SET " + cmdText.Substring(1)
                + " WHERE \"Waybill\" = '" + waybill.Waybill_Number + "'";
            return cmdText;
        }

        public void UpdateCargo(Stored_Waybill waybill, ICargoTypeManager typeManager, IClientManager clientManager)
        {
            if (waybill.Type != "" || waybill.Weight != 0 || waybill.Volume != 0
                || waybill.Place_Count != 0 || waybill.Sender != "" || waybill.Recipient != "")
            {
                NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
                DB.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = DB;
                cmd.CommandText = GenUpdateCommand(waybill, typeManager, clientManager);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateWaybill(Stored_Waybill waybill)
        {
            if (waybill.Manifest_ID >= 0)
            {
                NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
                DB.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = DB;
                cmd.CommandText = "UPDATE \"Waybill\" SET \"Manifest\" = '" + waybill.Manifest_ID + "' "
                                + "WHERE \"Number = \"" + waybill.Waybill_Number;
                cmd.ExecuteNonQuery();
                DB.Close();
            }
        }

        /// <summary>
        /// Обновление данных о накладных
        /// </summary>
        /// <param name="waybill">Новые данные</param>
        public void Update(Stored_Waybill waybill, ICargoTypeManager typeManager, IClientManager clientManager)
        {
            UpdateCargo(waybill, typeManager, clientManager);
            UpdateWaybill(waybill);
        }
    }
}
