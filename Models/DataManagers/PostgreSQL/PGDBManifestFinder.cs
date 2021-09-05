using Npgsql;
using System;
using System.Collections.Generic;

namespace Practic_3_curs.Models
{
	/// <summary>
	/// Класс, выполняющий поиск информации о манифесте 
	/// в базе данных PostgreSQL
	/// </summary>
	public class PGDBManifestFinder : IManifestFinder
	{
		string Connect_Setting;  //!< Данные для подключения к БД
		public PGDBManifestFinder(string connect_setting)
		{
			Connect_Setting = connect_setting;
		}

		/// <summary>
		/// Возвращает код селекта манифеста из базы данных
		/// </summary>
		/// <param name="date">Дата рейса</param>
		/// <param name="flight">Номер рейса</param>
		/// <returns>Код селекта манифеста</returns>
		/// TODO: Возможно это стоит перетащить в базу, как функцию. Надо уточнять
		string Manifest_Select_Code(DateTime date, string carrier, string flight)
		{
			return (
					"SELECT \"Manifest\".\"ID\", \"Carrier\".\"Code\","
	              + "       \"Carrier\".\"Name\", \"Carrier\".\"Mail\","
	              + "       \"Manifest\".\"Flight\", \"Manifest\".\"Aircraft\","
	              + "       \"From_Airport\".\"EN_Name\", \"To_Airport\".\"EN_Name\","
	              + "       \"Manifest\".\"Date\" "
                  + "FROM \"Manifest\", \"Carrier\","
	              + "     \"Airport\" AS \"From_Airport\","
	              + "     \"Airport\" AS \"To_Airport\" "
                  + "WHERE \"Manifest\".\"Carrier\" = \"Carrier\".\"Code\" "
                  + "  AND \"Manifest\".\"From\" = \"From_Airport\".\"ID\" "
                  + "  AND \"Manifest\".\"To\" = \"To_Airport\".\"ID\" "
				  + "  AND EXTRACT(DAY FROM \"Manifest\".\"Date\") = " + date.Day
				  + "  AND EXTRACT(MONTH FROM \"Manifest\".\"Date\") = " + date.Month
				  + "  AND EXTRACT(YEAR FROM \"Manifest\".\"Date\") = " + date.Year
				  + "  AND \"Manifest\".\"Flight\" = '" + flight + "' "
				  + "  AND \"Manifest\".\"Carrier\" = '" + carrier + "' "
			);
		}

		/// <summary>
		/// Поиск основной информации о манифесте
		/// (Поиск грузов не ведётся)
		/// </summary>
		/// <param name="date">Дата рейса</param>
		/// <param name="carrier">Код перевозчика</param>
		/// <param name="flight">Номер рейса</param>
		/// <returns>Манифест (без указания грузов)</returns>
		public CManifest LoadManifest(DateTime date, string carrier, string flight)
		{
			CManifest manifest = new CManifest();
			NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
			DB.Open();
			NpgsqlCommand cmd = new NpgsqlCommand();
			cmd.Connection = DB;
			cmd.CommandText = Manifest_Select_Code(date, carrier, flight);
			NpgsqlDataReader dataReader = cmd.ExecuteReader();
			if (dataReader.Read())
			{
				manifest.ID = dataReader.GetInt32(0);
				manifest.Carrier.Code = dataReader.GetString(1);
				manifest.Carrier.Name = dataReader.GetString(2);
				manifest.Carrier.Mail = dataReader.GetString(3);
				manifest.Flight = dataReader.GetString(4).TrimEnd();
				manifest.Aircraft = dataReader.GetString(5).TrimEnd();
				manifest.From = dataReader.GetString(6);
				manifest.To = dataReader.GetString(7);
				manifest.Date = dataReader.GetDateTime(8);
			}
			DB.Close();
			return manifest;
		}

		/// <summary>
		/// Возвращает код селекта грузов манифеста из базы данных
		/// </summary>
		/// <param name="manifest_id">ID манифеста</param>
		/// <returns>Код селекта грузов манифеста</returns>
		/// TODO: Возможно это стоит перетащить в базу, как функцию. Надо уточнять
		string Cargos_Select_Code(int manifest_id)
		{
			return (
			   "SELECT \"Waybill\".\"Code\", \"Waybill\".\"Number\","
			 + "       \"Cargo\".\"Place_Count\", \"Cargo\".\"Weight\","
			 + "       \"Cargo\".\"Volume\", \"Cargo_Type\".\"EN_Name\","
			 + "       \"Sender\".\"Name\", \"Recipient\".\"Name\" "
			 + "FROM \"Cargo\", \"Cargo_Type\", \"Client\" AS \"Sender\","
			 + "     \"Client\" AS \"Recipient\", \"Waybill\" "
			 + "WHERE \"Waybill\".\"Manifest\" = " + manifest_id
			 + "  AND \"Cargo\".\"Waybill\" = \"Waybill\".\"Number\""
			 + "  AND \"Sender\".\"ID\" = \"Cargo\".\"Sender\""
			 + "  AND \"Recipient\".\"ID\" = \"Cargo\".\"Recipient\""
			 + "  AND \"Cargo_Type\".\"ID\" = \"Cargo\".\"Type\""
			);
		}

		/// <summary>
		/// Добавление в манифест информации о грузах
		/// </summary>
		/// <param name="manifest">Дополняемый манифест</param>
		void LoadCargos(CManifest manifest)
		{
			NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
			DB.Open();
			NpgsqlCommand cmd = new NpgsqlCommand();
			cmd.Connection = DB;
			cmd.CommandText = Cargos_Select_Code(manifest.ID);
			NpgsqlDataReader dataReader = cmd.ExecuteReader();
			while (dataReader.Read())
			{
				CCargo cargo = new CCargo();
				cargo.Waybill.Code = dataReader.GetInt32(0);
				cargo.Waybill.Num = dataReader.GetInt64(1);
				cargo.PlaceCnt = dataReader.GetInt32(2);
				cargo.Weight = dataReader.GetDouble(3);
				cargo.Volume = dataReader.GetDouble(4);
				cargo.Type = dataReader.GetString(5);
				cargo.Sender = dataReader.GetString(6);
				cargo.Recipient = dataReader.GetString(7);
				manifest.Cargos.Add(cargo);
			}
			DB.Close();
		}

		/// <summary>
		/// Устанавливает версию манифеста
		/// </summary>
		/// <param name="manifest">Дополняемый манифест</param>
		void LoadVersion(CManifest manifest)
		{
			NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
			DB.Open();
			NpgsqlCommand cmd = new NpgsqlCommand();
			cmd.Connection = DB;
			cmd.CommandText = "SELECT COUNT(*) FROM \"Update\" WHERE \"Manifest\"=" + manifest.ID;
			NpgsqlDataReader dataReader = cmd.ExecuteReader();
			if (dataReader.Read())
				manifest.Version = dataReader.GetInt32(0) + 1;
			else
				manifest.Version = 1;
			DB.Close();
		}

		/// <summary>
		/// Поиск манифеста в базе данных по дате и номеру рейса
		/// </summary>
		/// <param name="date">Дата рейса</param>
		/// <param name="carrier">Код перевозчика</param>
		/// <param name="flight">Номер рейса</param>
		/// <returns>Найденный манифест</returns>
		public CManifest FindManifest(DateTime date, string carrier, string flight)
		{
			CManifest manifest = LoadManifest(date, carrier, flight);
			LoadCargos(manifest);
			LoadVersion(manifest);
			return manifest;
		}

		/// <summary>
		/// Возвращает код селекта грузов манифеста из базы данных
		/// </summary>
		/// <param name="manifest_id">ID манифеста</param>
		/// <returns>Код селекта грузов манифеста</returns>
		/// TODO: Возможно это стоит перетащить в базу, как функцию. Надо уточнять
		string Flights_Select_Code(DateTime date)
		{
			return (
			   "SELECT \"Carrier\", \"Flight\""
             + "FROM \"Manifest\""
             + "WHERE EXTRACT(YEAR FROM \"Date\") = " + date.Year
             + "  AND EXTRACT(MONTH FROM \"Date\") = " + date.Month
             + "  AND EXTRACT(DAY FROM \"Date\") = " + date.Day
			);
		}


		/// <summary>
		/// Поиск всех рейсов за заданный день
		/// </summary>
		/// <param name="date">Дата, по которой идёт поиск</param>
		/// <returns>Список рейсов</returns>
		public List<CFlight> FindFlights(DateTime date)
        {
			List<CFlight> flights = new List<CFlight>();
			NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
			DB.Open();
			NpgsqlCommand cmd = new NpgsqlCommand();
			cmd.Connection = DB;
			cmd.CommandText = Flights_Select_Code(date);
			NpgsqlDataReader dataReader = cmd.ExecuteReader();
			while (dataReader.Read())
				flights.Add(new CFlight(dataReader.GetString(0), dataReader.GetString(1)));
			DB.Close();
			return flights;
        }

        public bool Ping()
        {
			try
			{
				NpgsqlConnection DB = new NpgsqlConnection(Connect_Setting);
				DB.Open();
				NpgsqlCommand cmd = new NpgsqlCommand();
				cmd.Connection = DB;
				cmd.CommandText = "SELECT COUNT(*)";
				cmd.ExecuteNonQuery();
				DB.Close();
				return true;
			} catch { }
			return false;
		}
    }
}
