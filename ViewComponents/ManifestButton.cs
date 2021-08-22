using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practic_3_curs.ViewComponents
{
    public class ManifestButton : Button
    {
        private Label _Header;
        private Label _Time;
        private Label _Details;

        public ManifestButton(Control parent, string flight, string time, string details)
        {
            Parent = parent;
            Width = parent.Width - 100;
            Height = 150;

            _Header = new Label() {
                Parent = this,
                Location = new Point(10, 10),
                Font = new Font(FontFamily.GenericMonospace, 18, FontStyle.Regular),
                Text = flight,
                Width = 100, Height = 20
            };
            _Header.Width = _Header.Parent.Width - 20;
            _Header.Height = 20;
            _Header.Click += (sender, args) => InvokeOnClick(this, args);

            _Time = new Label()
            {
                Parent = this,
                Location = new Point(10, 40),
                Font = new Font(FontFamily.GenericMonospace, 14, FontStyle.Italic),
                Text = time,
            };
            _Time.Width = _Time.Parent.Width - 20;
            _Time.Height = 20;
            _Time.Click += (sender, args) => InvokeOnClick(this, args);
        }

        public void ClearData()
        {
            _Header.Dispose();
            _Time.Dispose();
        }
    }
}
