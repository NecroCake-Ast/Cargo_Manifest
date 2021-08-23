using System.Collections.Generic;

namespace Practic_3_curs.Models
{
    /// <summary>
    /// Интерфейс классов, обрабатывающих данные о аэропортах
    /// </summary>
    public interface IAirportManager
    {
        /// <summary>
        /// Получение списка аэропортов
        /// </summary>
        /// <returns>Список аэропортов</returns>
        List<Stored_Airport> GetAllAirports();

        int GetAirportByName(string name);

        /// <summary>
        /// Добавление нового аэропорта
        /// </summary>
        /// <param name="airport">Данные нового аэропорта</param>
        void Add(Stored_Airport airport);

        /// <summary>
        /// Обновление данных о аэропорте
        /// </summary>
        /// <param name="carrier">Новые данные</param>
        void Update(Stored_Airport airport);

        /// <summary>
        /// Удаление информации о аэропорте
        /// </summary>
        /// <param name="id">Код удаляемого аэропорта</param>
        void Remove(int id);
    }
}
