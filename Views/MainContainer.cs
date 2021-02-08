using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Practic_3_curs.Views
{
    public partial class MainContainer : Form
    {
        Form          Active_Form;
        MenuForm      Menu;
        EFFM_Form     EFFM;
        Form          Manifests_Edit;
        Form          Waybills_Edit;
        Carriers_Form Carriers_Edit;
        Form          Airports_Edit;
        Clients_Form   Clients_Edit;
        Form          CargoTypes_Edit;
        public MainContainer()
        {
            InitializeComponent();
            IsMdiContainer = true;

            Menu = new MenuForm();
            Menu.MdiParent = this;
            Menu.WindowState = FormWindowState.Maximized;

            EFFM = new EFFM_Form();
            EFFM.MdiParent = this;
            EFFM.WindowState = FormWindowState.Maximized;

            Carriers_Edit = new Carriers_Form();
            Carriers_Edit.MdiParent = this;
            Carriers_Edit.WindowState = FormWindowState.Maximized;

            Clients_Edit = new Clients_Form();
            Clients_Edit.MdiParent = this;
            Clients_Edit.WindowState = FormWindowState.Maximized;

            Active_Form = Menu;
            Active_Form.Show();
        }

        private void ShowForm(Form form)
        {
            Active_Form.Hide();
            Active_Form = form;
            Active_Form.Show();
        }

        public void EFFM_Show()
        {
            ShowForm(EFFM);
        }

        public void Menu_Show()
        {
            ShowForm(Menu);
        }

        public void Carriers_Show()
        {
            Carriers_Edit.LoadCarriers();   
            ShowForm(Carriers_Edit);
        }

        public void Clients_Show()
        {
            //Carriers_Edit.LoadCarriers();
            ShowForm(Clients_Edit);
        }
    }
}
