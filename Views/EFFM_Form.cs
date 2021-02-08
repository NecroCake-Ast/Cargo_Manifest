using Practic_3_curs.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using NPOI.XWPF.UserModel;
using System.IO;
using NPOI.OpenXmlFormats.Wordprocessing;

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
            MailAddress fromAddress = new MailAddress("**********@mail.ru",
                Manifest.Carrier.Code.TrimEnd() + "-" + Manifest.To.TrimEnd());
            // Куда отправляется
            MailAddress toAddress = new MailAddress(To_Address);
            MailMessage m = new MailMessage(fromAddress, toAddress);
            // Тема письма
            m.Subject = "E-FFM. Рейс" + Manifest.Carrier.Code.TrimEnd() + Manifest.Flight + ". " + Manifest.Date;
            // Текст письма
            m.Body = "";
            foreach (var res in Lines)
                m.Body += res + "\n";
            // Адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // Логин и пароль
            smtp.Credentials = new NetworkCredential(fromAddress.Address, "********");
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
                    + "M" + curCargo.Volume + "/" + curCargo.Type.TrimEnd().ToUpper());
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
        /// TODO:
        ///      Много кода. Мб отдельный класс сделать для этого? (Necrocake, 03.02.2021)
        private void CreateDoc_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(EnterDate.Text);
            CFlight flight = FindFlight(EnterFlight.Text);
            if (flight != null)
            {
                CM.Font = new Font(CM.Font, CM.Font.Style | FontStyle.Regular);
                CManifest test = Program.ManifestFinder.FindManifest(date, flight.CarrierCode, flight.Number);

                //Create document
                XWPFDocument doc = new XWPFDocument();

                //Create info about manifest
                XWPFParagraph FIRSTLINE = doc.CreateParagraph();
                XWPFRun first = FIRSTLINE.CreateRun();
                first.SetText("OPERATOR");

                XWPFParagraph SECONDLINE = doc.CreateParagraph();
                XWPFRun second = SECONDLINE.CreateRun();
                second.SetText("AIRCRAFT " + test.Aircraft + "            FLIGHT " + test.Flight + "            DATE " + test.Date);

                XWPFParagraph THIRDLINE = doc.CreateParagraph();
                XWPFRun third = THIRDLINE.CreateRun();
                third.SetText("FROM " + test.From + "                TO " + test.To + "                          docdocdocdocdocdoc");

                //create table
                XWPFTable table = doc.CreateTable();

                //create first row
                XWPFTableRow tableRowOne = table.GetRow(0);
                tableRowOne.GetCell(0).SetText("AIR WAYBILL NUMBER");
                tableRowOne.AddNewTableCell().SetText("NR OF PACK");
                tableRowOne.AddNewTableCell().SetText("NATURE OF GODS");
                tableRowOne.AddNewTableCell().SetText("CROSS WEIGHT");
                tableRowOne.AddNewTableCell().SetText("ORIGIN DEST");
                tableRowOne.AddNewTableCell().SetText("FOR OFFICIAL USE ONLY");
                tableRowOne.AddNewTableCell().SetText("REMARK");
                //create second row
                XWPFTableRow tableRowTwo = table.CreateRow();
                for (int i = 0; i < test.Cargos.Count; i++)
                {
                    XWPFParagraph newPar = tableRowTwo.GetCell(0).AddParagraph();
                    XWPFRun parRun = newPar.CreateRun();
                    parRun.SetText(test.Cargos[i].Waybill.Code.ToString()
                        + "-" + test.Cargos[i].Waybill.Num.ToString());
                }
                XWPFParagraph CellLastPar = tableRowTwo.GetCell(0).AddParagraph();
                XWPFRun CellLastRun = CellLastPar.CreateRun();
                CellLastRun.SetText("ULD TOTAL");
                int SumPlace = 0;
                for (int i = 0; i < test.Cargos.Count; i++)
                {
                    XWPFParagraph newPar = tableRowTwo.GetCell(1).AddParagraph();
                    XWPFRun parRun = newPar.CreateRun();
                    parRun.SetText(test.Cargos[i].PlaceCnt.ToString());
                    SumPlace += test.Cargos[i].PlaceCnt;
                }
                CellLastPar = tableRowTwo.GetCell(1).AddParagraph();
                CellLastRun = CellLastPar.CreateRun();
                CellLastRun.SetText(SumPlace.ToString());
                CellLastPar = tableRowTwo.GetCell(2).GetParagraphArray(0);
                CellLastRun = CellLastPar.CreateRun();
                CellLastRun.SetText("BULK");
                for (int i = 0; i < test.Cargos.Count; i++)
                {
                    XWPFParagraph newPar = tableRowTwo.GetCell(2).AddParagraph();
                    XWPFRun parRun = newPar.CreateRun();
                    parRun.SetText(test.Cargos[i].Type.TrimEnd());
                }
                double SumWeight = 0;
                for (int i = 0; i < test.Cargos.Count; i++)
                {
                    XWPFParagraph newPar = tableRowTwo.GetCell(3).AddParagraph();
                    XWPFRun parRun = newPar.CreateRun();
                    parRun.SetText(test.Cargos[i].Weight + "KG");
                    SumWeight += test.Cargos[i].Weight;
                }
                CellLastPar = tableRowTwo.GetCell(3).AddParagraph();
                CellLastRun = CellLastPar.CreateRun();
                CellLastRun.SetText(SumWeight + "KG");
                for (int i = 0; i < test.Cargos.Count; i++)
                {
                    XWPFParagraph newPar = tableRowTwo.GetCell(4).AddParagraph();
                    XWPFRun parRun = newPar.CreateRun();
                    parRun.SetText(test.From.TrimEnd() + "-" + test.To.TrimEnd());
                }

                //create third row
                XWPFTableRow tableRowThree = table.CreateRow();
                tableRowThree.GetCell(0).SetText("                  ");
                tableRowThree.GetCell(1).SetText("                  ");
                tableRowThree.GetCell(2).SetText("                  ");

                XWPFParagraph PAGE = doc.CreateParagraph();
                XWPFRun Page = PAGE.CreateRun();
                Page.FontFamily = "Monospaced";
                Page.SetText("PAGE PAGE: " + SumPlace + " " + SumWeight);
                XWPFParagraph FLIGHT = doc.CreateParagraph();
                XWPFRun Flight = FLIGHT.CreateRun();
                Flight.FontFamily = "Monospaced";
                Flight.SetText("FLIGHT PAGE: " + SumPlace + " " + SumWeight);

                doc.Document.body.sectPr = new CT_SectPr();
                CT_SectPr secPr = doc.Document.body.sectPr;

                //Create header and set its text
                CT_Hdr header = new CT_Hdr();
                header.AddNewP().AddNewR().AddNewT().Value = "CARGO MANIFEST";
                //Create footer and set its text
                CT_Ftr footer = new CT_Ftr();
                string Footer = "___________________________________________________________________________\n"
                    + "Средства пакетирования загружены на борт..."
                    + "Старший на рейсе ВМТС-грузчик ____________________(подпись) __________ (ФИО)_________(дата)\n";
                footer.AddNewP().AddNewR().AddNewT().Value = Footer;
                //Create the relation of header
                XWPFRelation relation1 = XWPFRelation.HEADER;
                XWPFHeader myHeader = (XWPFHeader)doc.CreateRelationship(relation1, XWPFFactory.GetInstance(), doc.HeaderList.Count + 1);
                //Create the relation of footer
                XWPFRelation relation2 = XWPFRelation.FOOTER;
                XWPFFooter myFooter = (XWPFFooter)doc.CreateRelationship(relation2, XWPFFactory.GetInstance(), doc.FooterList.Count + 1);
                //Set the header
                myHeader.SetHeaderFooter(header);
                CT_HdrFtrRef myHeaderRef = secPr.AddNewHeaderReference();
                myHeaderRef.type = ST_HdrFtr.@default;
                myHeaderRef.id = myHeader.GetPackageRelationship().Id;
                //Set the footer
                myFooter.SetHeaderFooter(footer);
                CT_HdrFtrRef myFooterRef = secPr.AddNewFooterReference();
                myFooterRef.type = ST_HdrFtr.@default;
                myFooterRef.id = myFooter.GetPackageRelationship().Id;
                //Save the file
                using (FileStream stream = File.Create(date.Day + "." + date.Month + "." + date.Year + "-" + flight.FullName + ".docx"))
                {
                    doc.Write(stream);
                }
                MessageBox.Show(
                date.Day + "." + date.Month + "." + date.Year + "-" + flight.FullName + ".docx успешно сформирован",
                "Message",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                MessageBox.Show(
                   "Не удалось создать файл" + date.Day + "." + date.Month + "." + date.Year + "-" + flight.FullName + ".docx",
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
                EnterFlight.Items.Add(curFlight.FullName);
        }

        private void onMenuShow(object sender, EventArgs e)
        {
            ((MainContainer)MdiParent).Menu_Show();
        }
    }
}
