using System;
using System.Windows.Forms;

namespace Practic_3_curs.Views
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void onManifestsShow(object sender, EventArgs e)
        {
            ((MainContainer)MdiParent).Manifests_Show();
        }

        private void onWaybillsShow(object sender, EventArgs e)
        {
            ((MainContainer)MdiParent).Waybills_Show();
        }

        private void onClientsShow(object sender, EventArgs e)
        {
            ((MainContainer)MdiParent).Clients_Show();
        }

        private void onCarriersShow(object sender, EventArgs e)
        {
            ((MainContainer)MdiParent).Carriers_Show();
        }

        private void onAirportsShow(object sender, EventArgs e)
        {
            ((MainContainer)MdiParent).Airports_Show();
        }

        private void onCargoTypesShow(object sender, EventArgs e)
        {
            ((MainContainer)MdiParent).CargoTypes_Show();
        }

        private void onEFFMGen(object sender, EventArgs e)
        {
            ((MainContainer)MdiParent).EFFM_Show();
        }
    }
}
