using Practic_3_curs.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Practic_3_curs.Views
{
    public partial class Waybills_Form : Form
    {
        List<Stored_Waybill> Waybills;
        public Waybills_Form()
        {
            InitializeComponent();
            Waybills = new List<Stored_Waybill>();
        }

        void WaybillsShow()
        {
            Waybills_Field.Text = "";
            foreach (Stored_Waybill waybill in Waybills)
                Waybills_Field.Text += "Накладная № " + waybill.Waybill_Code + "-"
                    + waybill.Waybill_Number + ".\r\nДекларация № "
                    + waybill.Manifest_ID + "\r\n\t"
                    + "Тип груза: " + waybill.Type + "\r\n\t"
                    + "Количество занимаемых мест: " + waybill.Place_Count + "\r\n\t"
                    + "Вес: " + waybill.Weight + "кг. Объём: " + waybill.Volume + "м³." + "\r\n\r\n\t"
                    + "Отправитель: " + waybill.Sender + "\r\n\t"
                    + "Получатель:  " + waybill.Recipient + "\r\n-----------------------------------------------------\r\n";
        }

        Stored_Waybill CreateWaybillFromForm()
        {
            Stored_Waybill createdWaybill = new Stored_Waybill();
            // Тип груза
            createdWaybill.Type = CargoType_Inp.Text;
            // Вес
            try   { createdWaybill.Weight = double.Parse(Weight_Inp.Text.Replace('.', ',')); }
            catch { createdWaybill.Weight = 0; }
            // Объём груза
            try   { createdWaybill.Volume = double.Parse(Volume_Inp.Text.Replace('.', ',')); }
            catch { createdWaybill.Volume = 0; }
            // Количество занимаемых мест
            try   { createdWaybill.Place_Count = int.Parse(Place_Inp.Text); }
            catch { createdWaybill.Place_Count = 0; }
            // Отправитель
            createdWaybill.Sender = Sender_Inp.Text;
            // Получатель
            createdWaybill.Recipient = Recipient_Inp.Text;
            // Код накладной
            try   { createdWaybill.Waybill_Code = int.Parse(WaybillCode_Inp.Text); }
            catch { createdWaybill.Waybill_Code = 555; }
            // Номер накладной
            try   { createdWaybill.Waybill_Number = int.Parse(WaybillNumber_Inp.Text); }
            catch { createdWaybill.Waybill_Number = -1; }
            // Номер декларации
            try   { createdWaybill.Manifest_ID = int.Parse(ManifestID_Inp.Text); }
            catch { createdWaybill.Manifest_ID = -1; }

            return createdWaybill;
        }

        public void LoadWaybills()
        {
            try
            {
                Sender_Inp.Items.Clear();
                Recipient_Inp.Items.Clear();
                CargoType_Inp.Items.Clear();
                List<Stored_Client> clients = Program.ClientManager.GetAllClients();
                foreach (Stored_Client client in clients)
                {
                    string client_name = client.Name.TrimEnd();
                    Sender_Inp.Items.Add(client_name);
                    Recipient_Inp.Items.Add(client_name);
                }
                List<Stored_CargoType> types = Program.CargoTypeManager.GetAllCargoTypes();
                foreach (Stored_CargoType type in types)
                    CargoType_Inp.Items.Add(type.Ru_Name.TrimEnd());
                Waybills = Program.WaybillManager.GetAllWaybills();
                WaybillsShow();
            }
            catch (Exception except)
            {
                Program.Log("Waybills.LoadWaybills " + except.Message);
            }
        }

        private void onMenuShow(object sender, EventArgs e)
        {
            Waybills.Clear();
            Waybills_Field.Text = "";
            ((MainContainer)MdiParent).Menu_Show();
        }

        private void onAddClick(object sender, EventArgs e)
        {
            try
            {
                Stored_Waybill newWaybill = CreateWaybillFromForm();
                Program.WaybillManager.Add(newWaybill, Program.CargoTypeManager, Program.ClientManager);
                LoadWaybills();
            }
            catch (Exception except)
            {
                Program.Log("Waybills.onAddClick " + except.Message);
            }
        }

        private void onUpdateClick(object sender, EventArgs e)
        {
            try
            {
                Stored_Waybill UpdatedWaybill = CreateWaybillFromForm();
                Program.WaybillManager.Update(UpdatedWaybill, Program.CargoTypeManager, Program.ClientManager);
                LoadWaybills();
            }
            catch (Exception except)
            {
                Program.Log("Waybills.onUpdateClick " + except.Message);
            }
        }

        private void onRemoveClick(object sender, EventArgs e)
        {
            try
            {
                Program.WaybillManager.Remove(int.Parse(WaybillNumber_Inp.Text));
                LoadWaybills();
            }
            catch (Exception except)
            {
                Program.Log("Waybills.onRemoveClick " + except.Message);
            }
        }
    }
}
