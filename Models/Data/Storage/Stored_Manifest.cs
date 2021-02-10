using System;

namespace Practic_3_curs.Models
{

    /// <summary>
    /// Информация о декларации, записанной в хранилище данных 
    /// </summary>
    public class Stored_Manifest
    {
        public int      ID       { get; set; }   //!< ID декларации
        public int      Carrier  { get; set; }   //!< Код перевозчика
        public long     Flight   { get; set; }   //!< Рейс
        public long     Aircraft { get; set; }   //!< Бортовой номер
        public int      From     { get; set; }   //!< ID аэропорта вылета
        public int      To       { get; set; }   //!< ID аэропорта прибытия
        public DateTime Date     { get; set; }   //!< Дата и время вылета
    }
}
