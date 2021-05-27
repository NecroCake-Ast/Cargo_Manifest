using System.Windows.Forms;

namespace Practic_3_curs.Views
{
    public partial class MainContainer : Form
    {
        Form           Active_Form;
        MenuForm       Menu;
        EFFM_Form      EFFM;
        Manifests_Form  Manifests_Edit;
        Waybills_Form  Waybills_Edit;
        Carriers_Form  Carriers_Edit;
        Airports_Form  Airports_Edit;
        Clients_Form   Clients_Edit;
        CargoType_Form CargoTypes_Edit;
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

            Airports_Edit = new Airports_Form();
            Airports_Edit.MdiParent = this;
            Airports_Edit.WindowState = FormWindowState.Maximized;

            Clients_Edit = new Clients_Form();
            Clients_Edit.MdiParent = this;
            Clients_Edit.WindowState = FormWindowState.Maximized;

            Waybills_Edit = new Waybills_Form();
            Waybills_Edit.MdiParent = this;
            Waybills_Edit.WindowState = FormWindowState.Maximized;

            CargoTypes_Edit = new CargoType_Form();
            CargoTypes_Edit.MdiParent = this;
            CargoTypes_Edit.WindowState = FormWindowState.Maximized;

            Manifests_Edit = new Manifests_Form();
            Manifests_Edit.MdiParent = this;
            Manifests_Edit.WindowState = FormWindowState.Maximized;

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

        public void Manifests_Show()
        {
            Manifests_Edit.LoadManifests();
            ShowForm(Manifests_Edit);
        }

        public void Waybills_Show()
        {
            Waybills_Edit.LoadWaybills();
            ShowForm(Waybills_Edit);
        }

        public void Carriers_Show()
        {
            Carriers_Edit.LoadCarriers();   
            ShowForm(Carriers_Edit);
        }

        public void Airports_Show()
        {
            Airports_Edit.LoadAirports();
            ShowForm(Airports_Edit);
        }

        public void Clients_Show()
        {
            Clients_Edit.LoadClients();
            ShowForm(Clients_Edit);
        }

        public void CargoTypes_Show()
        {
            CargoTypes_Edit.LoadCargoTypes();
            ShowForm(CargoTypes_Edit);
        }
    }
}
