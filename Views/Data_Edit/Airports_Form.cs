using Practic_3_curs.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Practic_3_curs.Views
{
    public partial class Airports_Form : Form
    {
        List<Stored_Airport> Airports;
        public Airports_Form()
        {
            InitializeComponent();
            Airports = new List<Stored_Airport>();
        }

        void AirportsShow()
        {
            Airports_Field.Text = "";
            foreach (Stored_Airport airport in Airports)
                Airports_Field.Text += airport.ID + "\u00A0-\u00A0" + airport.Ru_Name.TrimEnd()
                    + "\u00A0(En:\u00A0" + airport.En_Name.TrimEnd() + ")\r\n";
        }

        public void LoadAirports()
        {
            try
            {
                Airports = Program.AirportManager.GetAllAirports();
                AirportsShow();
            }
            catch (Exception except)
            {
                Program.Log("LoadAirports " + except.Message);
            }
        }

        private void onMenuShow(object sender, EventArgs e)
        {
            Airports.Clear();
            Airports_Field.Text = "";
            ((MainContainer)MdiParent).Menu_Show();
        }

        private void onAddClick(object sender, EventArgs e)
        {
            try
            {
                Stored_Airport airport = new Stored_Airport();
                airport.Ru_Name = RUName_Inp.Text;
                airport.En_Name = ENName_Inp.Text;
                Program.AirportManager.Add(airport);
                LoadAirports();
            }
            catch (Exception except)
            {
                Program.Log("Airports.onAddClick " + except.Message);
            }
        }

        private void onUpdateClick(object sender, EventArgs e)
        {
            try
            {
                Stored_Airport airport = new Stored_Airport();
                airport.ID = int.Parse(ID_Inp.Text);
                airport.Ru_Name = RUName_Inp.Text;
                airport.En_Name = ENName_Inp.Text;
                Program.AirportManager.Update(airport);
                LoadAirports();
            }
            catch (Exception except)
            {
                Program.Log("Airports.onUpdateClick " + except.Message);
            }
        }

        private void onRemoveClick(object sender, EventArgs e)
        {
            try
            {
                Program.AirportManager.Remove(int.Parse(ID_Inp.Text));
                LoadAirports();
            }
            catch (Exception except)
            {
                Program.Log("Airports.onRemoveClick " + except.Message);
            }
        }
    }
}
