using Practic_3_curs.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Practic_3_curs.Views
{
    public partial class Carriers_Form : Form
    {
        List<CCarrier> Carriers;
        public Carriers_Form()
        {
            InitializeComponent();
            Carriers = new List<CCarrier>();
        }

        void CarriersShow()
        {
            Carriers_Field.Text = "";
            foreach (CCarrier carrier in Carriers)
                Carriers_Field.Text += carrier.Code + " - \"" + carrier.Name.TrimEnd() + "\", Mail: " + carrier.Mail.TrimEnd() + "\r\n";
        }

        public void LoadCarriers()
        {
            try
            {
                Carriers = Program.CarriersManager.GetAllCarriers();
                CarriersShow();
            }
            catch { }
        }

        private void onMenuShow(object sender, EventArgs e)
        {
            Carriers.Clear();
            Carriers_Field.Text = "";
            ((MainContainer)MdiParent).Menu_Show();
        }

        private void onAddClick(object sender, EventArgs e)
        {
            try
            {
                CCarrier carrier = new CCarrier();
                carrier.Code = Code_Inp.Text;
                carrier.Name = Name_Inp.Text;
                carrier.Mail = Mail_Inp.Text;
                Program.CarriersManager.Add(carrier);
                LoadCarriers();
            }
            catch { }
        }

        private void onUpdateClick(object sender, EventArgs e)
        {
            try
            {
                CCarrier carrier = new CCarrier();
                carrier.Code = Code_Inp.Text;
                carrier.Name = Name_Inp.Text;
                carrier.Mail = Mail_Inp.Text;
                Program.CarriersManager.Update(carrier);
                LoadCarriers();
            }
            catch { }
        }

        private void onRemoveClick(object sender, EventArgs e)
        {
            try
            {
                Program.CarriersManager.Remove(Code_Inp.Text);
                LoadCarriers();
            }
            catch { }
        }
    }
}
