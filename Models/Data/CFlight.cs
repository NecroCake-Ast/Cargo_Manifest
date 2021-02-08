namespace Practic_3_curs.Models
{
    /// <summary>
    /// Рейс
    /// </summary>
    public class CFlight
    {
        public string CarrierCode { get; set; }   //!< Код перевозчика
        public int    Number      { get; set; }   //!< Номер рейса

        public string FullName { get => CarrierCode + Number; } //!< Код перевозчика + номер рейса

        public CFlight(string code, int number)
        {
            CarrierCode = code.Trim();
            Number = number;
        }
    }
}
