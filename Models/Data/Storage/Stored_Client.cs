namespace Practic_3_curs.Models
{
    /// <summary>
    /// Информация о клиенте, записанном в хранилище данных
    /// </summary>
    public class Stored_Client
    {
        public int    ID    { get; set; }   //!< ID
        public string Name  { get; set; }   //!< Наиемнование
        public string Phone { get; set; }   //!< Номер телефона
    }
}
