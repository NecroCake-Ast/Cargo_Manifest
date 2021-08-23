namespace Practic_3_curs.Models
{
    /// <summary>
    /// Информация об аэропорте, записанном в хранилище данных
    /// </summary>
    public class Stored_Airport
    {
        public int    ID      { get; set; }   //!< ID записи
        public string En_Name { get; set; }   //!< Имя на английском
        public string Ru_Name { get; set; }   //!< Имя на русском 
    }
}
