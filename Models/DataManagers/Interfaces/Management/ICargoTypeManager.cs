using System.Collections.Generic;

namespace Practic_3_curs.Models
{
    /// <summary>
    /// Интерфейс классов, обрабатывающих данные о товарах
    /// </summary>
    public interface ICargoTypeManager
    {
        /// <summary>
        /// Получение списка товаров
        /// </summary>
        /// <returns>Список товаров</returns>
        List<Stored_CargoType> GetAllCargoTypes();

        /// <summary>
        /// Добавление нового товара
        /// </summary>
        /// <param name="cargotype">Данные нового товара</param>
        void Add(Stored_CargoType cargotype);

        /// <summary>
        /// Обновление данных о товарах
        /// </summary>
        /// <param name="cargotype">Новые данные</param>
        void Update(Stored_CargoType cargotype);

        /// <summary>
        /// Удаление информации о товарах
        /// </summary>
        /// <param name="id">Код удаляемого товара</param>
        void Remove(int id);

        /// <summary>
        /// Возвращает ID типа груза по названию
        /// </summary>
        /// <param name="Name"></param>
        /// <returns>ID типа груза</returns>
        int GetTypeByName(string Name);
    }
}
