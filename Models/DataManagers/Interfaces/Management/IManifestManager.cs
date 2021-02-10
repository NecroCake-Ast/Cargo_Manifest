using System.Collections.Generic;

namespace Practic_3_curs.Models
{
    /// <summary>
    /// Интерфейс классов, обрабатывающих данные о манифестах
    /// </summary>
    public interface IManifestManager
    {
        /// <summary>
        /// Получение списка манифеста
        /// </summary>
        /// <returns>Список манифеста</returns>
        List<Stored_Manifest> GetAllManifest();

        /// <summary>
        /// Добавление нового манифеста
        /// </summary>
        /// <param name="manifest">Данные нового манифеста</param>
        void Add(Stored_Manifest manifest);

        /// <summary>
        /// Обновление данных о манифесте
        /// </summary>
        /// <param name="manifest">Новые данные</param>
        void Update(Stored_Manifest manifest);

        /// <summary>
        /// Удаление информации о манифесте
        /// </summary>
        /// <param name="id">Код удаляемого манифеста</param>
        void Remove(int id);
    }
}
