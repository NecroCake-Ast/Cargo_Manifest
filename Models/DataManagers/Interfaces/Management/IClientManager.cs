using System.Collections.Generic;

namespace Practic_3_curs.Models
{
    /// <summary>
    /// Интерфейс классов, обрабатывающих данные о клиентах
    /// </summary>
    public interface IClientManager
    {
        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        /// <returns>Список клиентов</returns>
        List<Stored_Client> GetAllClients();

        /// <summary>
        /// Добавление нового клиента
        /// </summary>
        /// <param name="client">Данные нового клиента</param>
        void Add(Stored_Client client);

        /// <summary>
        /// Обновление данных о клиентах
        /// </summary>
        /// <param name="client">Новые данные</param>
        void Update(Stored_Client client);

        /// <summary>
        /// Удаление информации о клиентах
        /// </summary>
        /// <param name="id">Код удаляемого клиента</param>
        void Remove(int id);
    }
}
