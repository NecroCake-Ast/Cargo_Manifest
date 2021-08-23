namespace Practic_3_curs.Models
{
    /// <summary>
    /// Информация о грузе, записанном в хранилище данных 
    /// </summary>
    public class Stored_Waybill
    {
        public int     ID             { get; set; }   //!< ID
        public int     Place_Count    { get; set; }   //!< Количество занимаемых мест
        public double  Weight         { get; set; }   //!< Вес
        public double  Volume         { get; set; }   //!< Объём
        public string  Type           { get; set; }   //!< ID типа груза
        public string  Sender         { get; set; }   //!< ID отправителя
        public string  Recipient      { get; set; }   //!< ID получателя
        public int     Waybill_Code   { get; set; }   //!< Код накладной
        public int     Waybill_Number { get; set; }   //!< Номер накладной
        public int     Manifest_ID    { get; set; }   //!< ID декларации
    }
}
