using Practic_3_curs.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Practic_3_curs.Views
{
    public partial class EFFM_Form : Form
    {
        List<CFlight> Flights;    //!< Все рейсы за установленную дату

        public EFFM_Form()
        {
            Flights = new List<CFlight>();
            InitializeComponent();
        }

        /// <summary>
        /// Отправка манифеста по электронной почте
        /// </summary>
        /// <param name="Lines">Строки письма</param>
        /// <param name="Manifest">Отправляемый манифест</param>
        /// <param name="To_Address">Получатель</param>
        public void SendMessage(List<string> Lines, CManifest Manifest, string To_Address)
        {
            // Откуда отправляется
            MailAddress fromAddress = new MailAddress(Program.MailData.Login,
                Manifest.Carrier.Code.TrimEnd() + "-" + Manifest.To.TrimEnd());
            // Куда отправляется
            MailAddress toAddress = new MailAddress(To_Address);
            MailMessage m = new MailMessage(fromAddress, toAddress);
            // Тема письма
            m.Subject = "E-FFM. Рейс " + Manifest.Carrier.Code.TrimEnd() + Manifest.Flight + ". " + Manifest.Date;
            // Текст письма
            m.Body = "";
            foreach (var res in Lines)
                m.Body += res + "\n";
            // Адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient(Program.MailData.Host, Program.MailData.Port);
            // Логин и пароль
            smtp.Credentials = new NetworkCredential(fromAddress.Address, Program.MailData.Password);
            smtp.Timeout = 10000;
            smtp.EnableSsl = true;
             smtp.Send(m);
        }

        /// <summary>
        /// Формирование E-FFM по переданному манифесту
        /// </summary>
        /// <param name="manifest">Манифест</param>
        /// <returns>Строки E-FFM</returns>
        List<string> Cargo_Manifest(CManifest manifest)
        {
            List<string> CargoManifest = new List<string>();
            CargoManifest.Add("FFM/" + manifest.Version);
            CargoManifest.Add("1/" + manifest.Carrier.Code.Trim()
                + manifest.Flight + "/" + manifest.GetDate() + "/"
                + manifest.From.Trim() + "/" + manifest.Aircraft);
            CargoManifest.Add(manifest.To);
            foreach (CCargo curCargo in manifest.Cargos)
                CargoManifest.Add(curCargo.Waybill.Code + "-" + curCargo.Waybill.Num + ""
                    + manifest.From + "" + manifest.To + "/T"
                    + curCargo.PlaceCnt + "K" + curCargo.Weight
                    + "MC" + curCargo.Volume + "/" + curCargo.Type.TrimEnd().ToUpper());
            CargoManifest.Add("LAST");
            return CargoManifest;
        }

        /// <summary>
        /// Поиск информации о рейсе по его полному названию
        /// </summary>
        /// <param name="fullName">Полное название рейса (например SU1172)</param>
        /// <returns>
        /// Рейс с переданным названием
        /// null в случае, если рейса не существует
        /// </returns>
        CFlight FindFlight(string fullName)
        {
            for (int i = 0; i < Flights.Count; i++)
                if (Flights[i].FullName == fullName)
                    return Flights[i];
            return null;
        }

        /// <summary>
        /// Нажатие на кнопку формирования E-FFM
        /// </summary>
        public void Enter_Click(object sender, EventArgs e)
        {
            CM.Text = "";
            DateTime date = DateTime.Parse(EnterDate.Text);
            CFlight flight = FindFlight(EnterFlight.Text);
            if (flight != null)
            {
                CM.Font = new Font(CM.Font, CM.Font.Style | FontStyle.Regular);
                CManifest test = Program.ManifestFinder.FindManifest(date, flight.CarrierCode, flight.Number);
                List<string> result = Cargo_Manifest(test);
                foreach (var res in result)
                    CM.Text += res + "\r\n";
            }
        }

        /// <summary>
        /// Нажатие на кнопку отправки E-FFM по почте
        /// </summary>
        public void Send_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(EnterDate.Text);
            CFlight flight = FindFlight(EnterFlight.Text);
            if (flight != null)
            {
                string To = AddressTo.Text;
                CManifest test = Program.ManifestFinder.FindManifest(date, flight.CarrierCode, flight.Number);
                List<string> result = new List<string>();
                result = Cargo_Manifest(test);
                SendMessage(result, test, To);
            }
        }

        /// <summary>
        /// Нажатие на кнопку формирования документа .docx
        /// </summary>
        private void CreateDoc_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(EnterDate.Text);
            CFlight flight = FindFlight(EnterFlight.Text);
            if (flight != null)
            {
                CM.Font = new Font(CM.Font, CM.Font.Style | FontStyle.Regular);
                CManifest manifest = Program.ManifestFinder.FindManifest(date, flight.CarrierCode, flight.Number);

                CDocumentGenerator generator = new CDocumentGenerator();
                if (generator.GenDoc(manifest, flight, date))
                    MessageBox.Show(
                        date.Day + "." + date.Month + "." + date.Year + "-" + flight.FullName + ".docx успешно сформирован",
                        "Message",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                else
                    MessageBox.Show(
                        "Не удалось создать файл " + date.Day + "." + date.Month + "." + date.Year + "-" + flight.FullName + ".docx"
                        + "\nВозможно файл с таким названием используется другой программой",
                        "Message",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                MessageBox.Show(
                   "Не удалось сформировать Cargo Manifest. Проверьте правильность указанных данных",
                   "Message",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        /// <summary>
        /// Событие изменения даты
        /// 
        /// Применяется для изменения списка рейсов
        /// </summary>
        private void onDateSelect(object sender, EventArgs e)
        {
            CM.Text = "";
            DateTime date = DateTime.Parse(EnterDate.Text);
            Flights = Program.ManifestFinder.FindFlights(date);
            EnterFlight.SelectedItem = null;
            EnterFlight.Items.Clear();
            foreach (var curFlight in Flights)
                EnterFlight.Items.Add(curFlight.FullName.TrimEnd());
        }

        private void onMenuShow(object sender, EventArgs e)
        {
            ((MainContainer)MdiParent).Menu_Show();
        }
    }
}
