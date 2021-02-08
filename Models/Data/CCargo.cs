namespace Practic_3_curs.Models
{
    /// <summary>
    /// Информация о грузе
    /// </summary>
    public class CCargo
    {
        public CWaybill Waybill      { get; set; }   //!< Накладная
        public string   Type         { get; set; }   //!< Название типа груза
        public string   Sender       { get; set; }   //!< Наименование отправителя
        public string   Recipient    { get; set; }   //!< Наименование получателя
        public int      PlaceCnt     { get; set; }   //!< Количество занимаемых мест
        public double   Weight       { get; set; }   //!< Суммарный вес
        public double   Volume       { get; set; }   //!< Объём

        public CCargo()
        {
            Waybill = new CWaybill();
        }
    }
}
