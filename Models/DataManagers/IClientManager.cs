using System;
using System.Collections.Generic;
using System.Text;

namespace Practic_3_curs.Models.DataManagers
{
    /// <summary>
    /// Интерфейс классов, обрабатывающих данные о клиентах
    /// </summary>
    interface IClientManager
    {
        /// <summary>
        /// Получение списка перевозчиков
        /// </summary>
        /// <returns>Список перевозчиков</returns>
        List<CCarrier> GetAllClientss();

        /// <summary>
        /// Добавление нового перевозчика
        /// </summary>
        /// <param name="client">Данные нового грузоотправителя(получателя)</param>
        void Add(CClient client);

        /// <summary>
        /// Обновление данных о перевозчике
        /// </summary>
        /// <param name="client">Новые данные</param>
        void Update(CClient client);

        /// <summary>
        /// Удаление информации о перевозчике
        /// </summary>
        /// <param name="id">Код удаляемого перевозчика</param>
        void Remove(int id);
    }
}
