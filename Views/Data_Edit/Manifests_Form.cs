using Practic_3_curs.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Practic_3_curs.Views
{
    public partial class Manifests_Form : Form
    {
        List<Stored_Manifest> Manifests;
        public Manifests_Form()
        {
            InitializeComponent();
            Manifests = new List<Stored_Manifest>();
        }

        void ManifestsShow()
        {
            Manifests_Field.Text = "";
            foreach (Stored_Manifest manifest in Manifests)
                Manifests_Field.Text += "Декларация " + manifest.ID
                    + "\r\nРейс: " + manifest.Carrier.ToUpper() + "-"
                    + manifest.Flight.TrimEnd() + "\r\nБорт " + manifest.Aircraft.TrimEnd()
                    + "(" + manifest.Date + ")\r\n\r\n" + "Из " + manifest.From
                    + "\r\nВ  " + manifest.To + "\r\n-----------------------------------------------------\r\n";
        }

        public void LoadManifests()
        {
            try
            {
                From_Inp.Items.Clear();
                To_Inp.Items.Clear();
                Carrier_Inp.Items.Clear();
                Manifests = Program.ManifestManager.GetAllManifest();
                List<Stored_Airport> airports = Program.AirportManager.GetAllAirports();
                foreach (var curAirport in airports)
                {
                    From_Inp.Items.Add(curAirport.En_Name.TrimEnd());
                    To_Inp.Items.Add(curAirport.En_Name.TrimEnd());
                }
                List<CCarrier> carriers = Program.CarriersManager.GetAllCarriers();
                foreach (var curCarrier in carriers)
                    Carrier_Inp.Items.Add(curCarrier.Code.TrimEnd());
                ManifestsShow();
            }
            catch (Exception except)
            {
                Program.Log("Manifests.LoadManifests " + except.Message);
            }
        }

        private void onMenuShow(object sender, EventArgs e)
        {
            Manifests.Clear();
            Manifests_Field.Text = "";
            ((MainContainer)MdiParent).Menu_Show();
        }

        Stored_Manifest CreateManifestFromForm()
        {
            Stored_Manifest createdManifest = new Stored_Manifest();
            // ID декларации
            try { createdManifest.ID = int.Parse(ID_Inp.Text); }
            catch { createdManifest.ID = -1; }

            createdManifest.Carrier = Carrier_Inp.Text;
            createdManifest.Flight = Flight_Inp.Text;
            createdManifest.Aircraft = Aircraft_Inp.Text;
            createdManifest.Date = DateTime.Parse(Date_Inp.Text + " " + Time_Inp.Text);
            createdManifest.From = From_Inp.Text;
            createdManifest.To = To_Inp.Text;

            return createdManifest;
        }

        private void onAddClick(object sender, EventArgs e)
        {
            try
            {
                Stored_Manifest manifest = CreateManifestFromForm();
                Program.ManifestManager.Add(manifest, Program.AirportManager, Program.CarriersManager);
                LoadManifests();
            }
            catch (Exception except)
            {
                Program.Log("Manifests.onAddClick " + except.Message);
            }
        }

        private void onUpdateClick(object sender, EventArgs e)
        {
            try
            {
                Stored_Manifest manifest = CreateManifestFromForm();
                if (!isDateUpdate.Checked)
                    manifest.Date = null;
                Program.ManifestManager.Update(manifest, Program.AirportManager, Program.CarriersManager);
                LoadManifests();
            }
            catch (Exception except)
            {
                Program.Log("Manifests.onUpdateClick " + except.Message);
            }
        }

        private void onRemoveClick(object sender, EventArgs e)
        {
            try
            {
                Program.ManifestManager.Remove(int.Parse(ID_Inp.Text));
                LoadManifests();
            }
            catch (Exception except)
            {
                Program.Log("Manifests.onRemoveClick " + except.Message);
            }
        }
    }
}
