using System.Collections.Generic;

namespace Practic_3_curs.Models
{
    public interface IWaybillManager
    {
        /// <summary>
        /// Добавление новой накладной
        /// </summary>
        /// <param name="cargotype">Данные новой накладной</param>
        void Add(Stored_Waybill waybill, ICargoTypeManager typeManager, IClientManager clientManager);

        /// <summary>
        /// Получение списка накладных
        /// </summary>
        /// <returns>Список накладных</returns>
        List<Stored_Waybill> GetAllWaybills();

        /// <summary>
        /// Удаление информации о накладных
        /// </summary>
        /// <param name="code">Код удаляемой накладной</param>
        void Remove(int code);

        /// <summary>
        /// Обновление данных о накладных
        /// </summary>
        /// <param name="waybill">Новые данные</param>
        void Update(Stored_Waybill waybill, ICargoTypeManager typeManager, IClientManager clientManager);
    }
}