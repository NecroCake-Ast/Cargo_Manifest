using System;
using System.Collections.Generic;

namespace Practic_3_curs.Models
{
    /// <summary>
    /// Интерфейс классов, выполняющих поиск информации о манифестах
    /// </summary>
    public interface IManifestFinder
    {
        /// <summary>
		/// Поиск манифеста по дате и номеру рейса
		/// </summary>
		/// <param name="date">Дата рейса</param>
		/// <param name="carrier">Код перевозчика</param>
		/// <param name="flight">Номер рейса</param>
		/// <returns>Найденный манифест</returns>
        CManifest FindManifest(DateTime date, string carrier, int flight);

        /// <summary>
        /// Поиск всех рейсов за заданный день
        /// </summary>
        /// <param name="date">Дата, по которой идёт поиск</param>
        /// <returns>Список рейсов</returns>
        List<CFlight> FindFlights(DateTime date);
    }
}
