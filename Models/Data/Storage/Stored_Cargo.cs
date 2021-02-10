namespace Practic_3_curs.Models
{
    /// <summary>
    /// Информация о грузе, записанном в хранилище данных 
    /// </summary>
    public class Stored_Cargo
    {
        public int     ID          { get; set; }   //!< ID
        public int     Place_Count { get; set; }   //!< Количество занимаемых мест
        public double  Weight      { get; set; }   //!< Вес
        public double  Volume      { get; set; }   //!< Объём
        public int     Type        { get; set; }   //!< ID типа груза
        public int     Sender      { get; set; }   //!< ID отправителя
        public int     Recipient   { get; set; }   //!< ID получателя
        public int     Waybill     { get; set; }   //!< Номер накладной
    }
}
