using Practic_3_curs.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Practic_3_curs.Views
{
    public partial class Clients_Form : Form
    {
        List<Stored_Client> Clients;
        public Clients_Form()
        {
            InitializeComponent();
            Clients = new List<Stored_Client>();
        }

        void ClientsShow()
        {
            Carriers_Field.Text = "";
            foreach (Stored_Client client in Clients)
                Carriers_Field.Text += client.ID.ToString().PadRight(9) + "\"" + client.Name + "\". Телефон: " + client.Phone + "\r\n";
        }

        public void LoadClients()
        {
            try
            {
                Clients = Program.ClientManager.GetAllClients();
                ClientsShow();
            }
            catch { }
        }

        private void onMenuShow(object sender, EventArgs e)
        {
            Clients.Clear();
            Carriers_Field.Text = "";
            ((MainContainer)MdiParent).Menu_Show();
        }

        private void onAddClick(object sender, EventArgs e)
        {
            try
            {
                Stored_Client client = new Stored_Client();
                client.ID = int.Parse(ID_Inp.Text);
                client.Name = Name_Inp.Text;
                client.Phone = Phone_Inp.Text;
                Program.ClientManager.Add(client);
                LoadClients();
            }
            catch { }
        }

        private void onUpdateClick(object sender, EventArgs e)
        {
            try
            {
                Stored_Client client = new Stored_Client();
                client.ID = int.Parse(ID_Inp.Text);
                client.Name = Name_Inp.Text;
                client.Phone = Phone_Inp.Text;
                Program.ClientManager.Update(client);
                LoadClients();
            }
            catch { }
        }

        private void onRemoveClick(object sender, EventArgs e)
        {
            try
            {
                Program.ClientManager.Remove(int.Parse(ID_Inp.Text));
                LoadClients();
            }
            catch { }
        }
    }
}
