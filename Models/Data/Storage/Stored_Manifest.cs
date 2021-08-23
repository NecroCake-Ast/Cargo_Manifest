using System;

namespace Practic_3_curs.Models
{

    /// <summary>
    /// Информация о декларации, записанной в хранилище данных 
    /// </summary>
    public class Stored_Manifest
    {
        public int       ID       { get; set; }   //!< ID декларации
        public string    Carrier  { get; set; }   //!< Наименование перевозчика
        public string    Flight   { get; set; }   //!< Рейс
        public string    Aircraft { get; set; }   //!< Бортовой номер
        public string    From     { get; set; }   //!< Название аэропорта вылета
        public string    To       { get; set; }   //!< Название аэропорта прибытия
        public DateTime? Date     { get; set; }   //!< Дата и время вылета
    }
}
