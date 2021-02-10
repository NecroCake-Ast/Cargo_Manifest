using System.Collections.Generic;

namespace Practic_3_curs.Models
{
    /// <summary>
    /// Интерфейс классов, обрабатывающих данные о перевозчиках
    /// </summary>
    public interface ICarrierManager
    {
        /// <summary>
        /// Получение списка перевозчиков
        /// </summary>
        /// <returns>Список перевозчиков</returns>
        List<CCarrier> GetAllCarriers();

        /// <summary>
        /// Добавление нового перевозчика
        /// </summary>
        /// <param name="carrier">Данные нового перевозчика</param>
        void Add(CCarrier carrier);

        /// <summary>
        /// Обновление данных о перевозчике
        /// </summary>
        /// <param name="carrier">Новые данные</param>
        void Update(CCarrier carrier);

        /// <summary>
        /// Удаление информации о перевозчике
        /// </summary>
        /// <param name="code">Код удаляемого перевозчика</param>
        void Remove(string code);
    }
}
