namespace Practic_3_curs.Models
{
    /// <summary>
    /// Рейс
    /// </summary>
    public class CFlight
    {
        public string CarrierCode { get; set; }   //!< Код перевозчика
        public string Number      { get; set; }   //!< Номер рейса

        public string FullName { get => CarrierCode + Number; } //!< Код перевозчика + номер рейса

        public CFlight(string code, string number)
        {
            CarrierCode = code.TrimEnd();
            Number = number.TrimEnd();
        }
    }
}
