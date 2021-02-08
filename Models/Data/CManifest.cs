using System;
using System.Collections.Generic;

namespace Practic_3_curs.Models
{
    /// <summary>
    /// Информация о грузоперевозке
    /// </summary>
    public class CManifest
    {
        public int          ID        { get; set; }  //!< ID
        public int          Version   { get; set; }  //!< Версия
        public CCarrier     Carrier   { get; set; }  //!< Перевозчик
        public int          Flight    { get; set; }  //!< Номер рейса
        public int          Aircraft  { get; set; }  //!< Бортовой номер
        public string       From      { get; set; }  //!< Аэропорт вылета
        public string       To        { get; set; }  //!< Аэропорт назначения
        public DateTime     Date      { get; set; }  //!< Дата и время вылета
        public List<CCargo> Cargos    { get; set; }  //!< Доставляемые грузы

        public CManifest()
        {
            Carrier = new CCarrier();
            Cargos = new List<CCargo>();
        }

        /// <summary>
        /// Возвращает строковое представление даты и времени 
        /// вылета в формате DD.MMM.YYYY hh:mm
        /// </summary>
        /// <returns>Строковое представление даты</returns>
        public string GetDate()
        {
            string res = "" + Date.Day;
            if (res.Length < 2)
                res = "0" + res;
            switch (Date.Month)
            {
                case 1:
                    res += "JAN";
                    break;
                case 2:
                    res += "FEB";
                    break;
                case 3:
                    res += "MAR";
                    break;
                case 4:
                    res += "APR";
                    break;
                case 5:
                    res += "MAY";
                    break;
                case 6:
                    res += "JUN";
                    break;
                case 7:
                    res += "JUL";
                    break;
                case 8:
                    res += "AUG";
                    break;
                case 9:
                    res += "SEP";
                    break;
                case 10:
                    res += "OCT";
                    break;
                case 11:
                    res += "NOV";
                    break;
                case 12:
                    res += "DEC";
                    break;
            }
            string H = "" + Date.Hour;
            if (H.Length < 2)
                H = "0" + H;
            string M = "" + Date.Minute;
            if (M.Length < 2)
                M = "0" + M;
            res += M + H;
            return res;
        }
    }
}
