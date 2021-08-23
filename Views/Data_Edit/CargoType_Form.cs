using Practic_3_curs.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Practic_3_curs.Views
{
    public partial class CargoType_Form : Form
    {
        List<Stored_CargoType> CargoTypes;
        public CargoType_Form()
        {
            InitializeComponent();
            CargoTypes = new List<Stored_CargoType>();
        }

        void CargoTypesShow()
        {
            CargoTypes_Field.Text = "";
            foreach (Stored_CargoType cargoType in CargoTypes)
                CargoTypes_Field.Text += cargoType.ID + "\u00A0-\u00A0" + cargoType.Ru_Name.TrimEnd()
                    + "\u00A0(En:\u00A0" + cargoType.En_Name.TrimEnd() + ")\r\n";
        }

        public void LoadCargoTypes()
        {
            try
            {
                CargoTypes = Program.CargoTypeManager.GetAllCargoTypes();
                CargoTypesShow();
            }
            catch (Exception except)
            {
                Program.Log("CargoTypes.LoadCargoTypes " + except.Message);
            }
        }

        private void onMenuShow(object sender, EventArgs e)
        {
            CargoTypes.Clear();
            CargoTypes_Field.Text = "";
            ((MainContainer)MdiParent).Menu_Show();
        }

        private void onAddClick(object sender, EventArgs e)
        {
            try
            {
                Stored_CargoType cargoType = new Stored_CargoType();
                cargoType.Ru_Name = RU_Name_Inp.Text;
                cargoType.En_Name = EN_Name_Inp.Text;
                Program.CargoTypeManager.Add(cargoType);
                LoadCargoTypes();
            }
            catch (Exception except)
            {
                Program.Log("CargoTypes.onAddClick " + except.Message);
            }
        }

        private void onUpdateClick(object sender, EventArgs e)
        {
            try
            {
                Stored_CargoType cargoType = new Stored_CargoType();
                cargoType.ID = int.Parse(ID_Inp.Text);
                cargoType.Ru_Name = RU_Name_Inp.Text;
                cargoType.En_Name = EN_Name_Inp.Text;
                Program.CargoTypeManager.Update(cargoType);
                LoadCargoTypes();
            }
            catch (Exception except)
            {
                Program.Log("CargoTypes.onUpdateClick " + except.Message);
            }
        }

        private void onRemoveClick(object sender, EventArgs e)
        {
            try
            {
                Program.CargoTypeManager.Remove(int.Parse(ID_Inp.Text));
                LoadCargoTypes();
            }
            catch (Exception except)
            {
                Program.Log("CargoTypes.onRemoveClick " + except.Message);
            }
        }
    }
}
