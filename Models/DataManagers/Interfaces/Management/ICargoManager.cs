using System.Collections.Generic;

namespace Practic_3_curs.Models
{
    /// <summary>
    /// Интерфейс классов, обрабатывающих данные о грузах
    /// </summary>
    public interface ICargoManager
    {
        /// <summary>
        /// Получение списка грузов
        /// </summary>
        /// <returns>Список грузов</returns>
        List<Stored_Waybill> GetAllCargo();

        /// <summary>
        /// Добавление нового груза
        /// </summary>
        /// <param name="cargo">Данные нового груза</param>
        void Add(Stored_Waybill cargo);

        /// <summary>
        /// Обновление данных о грузах
        /// </summary>
        /// <param name="cargo">Новые данные</param>
        void Update(Stored_Waybill cargo);

        /// <summary>
        /// Удаление информации о грузах
        /// </summary>
        /// <param name="id">Код удаляемого груза</param>
        void Remove(int id);
    }
}
