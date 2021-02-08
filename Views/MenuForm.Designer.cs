
namespace Practic_3_curs.Views
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EFFM_gen_btn = new System.Windows.Forms.Button();
            this.Manifests_btn = new System.Windows.Forms.Button();
            this.Waybills_btn = new System.Windows.Forms.Button();
            this.Clients_btn = new System.Windows.Forms.Button();
            this.Carriers_btn = new System.Windows.Forms.Button();
            this.Airports_btn = new System.Windows.Forms.Button();
            this.CargoTypes_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EFFM_gen_btn
            // 
            this.EFFM_gen_btn.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.EFFM_gen_btn.Location = new System.Drawing.Point(13, 12);
            this.EFFM_gen_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EFFM_gen_btn.Name = "EFFM_gen_btn";
            this.EFFM_gen_btn.Size = new System.Drawing.Size(241, 42);
            this.EFFM_gen_btn.TabIndex = 1;
            this.EFFM_gen_btn.Text = "Сформировать E-FFM";
            this.EFFM_gen_btn.UseVisualStyleBackColor = true;
            this.EFFM_gen_btn.Click += new System.EventHandler(this.onEFFMGen);
            // 
            // Manifests_btn
            // 
            this.Manifests_btn.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.Manifests_btn.Location = new System.Drawing.Point(365, 12);
            this.Manifests_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Manifests_btn.Name = "Manifests_btn";
            this.Manifests_btn.Size = new System.Drawing.Size(241, 42);
            this.Manifests_btn.TabIndex = 2;
            this.Manifests_btn.Text = "Манифесты";
            this.Manifests_btn.UseVisualStyleBackColor = true;
            this.Manifests_btn.Click += new System.EventHandler(this.onManifestsShow);
            // 
            // Waybills_btn
            // 
            this.Waybills_btn.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.Waybills_btn.Location = new System.Drawing.Point(365, 69);
            this.Waybills_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Waybills_btn.Name = "Waybills_btn";
            this.Waybills_btn.Size = new System.Drawing.Size(241, 42);
            this.Waybills_btn.TabIndex = 3;
            this.Waybills_btn.Text = "Накладные";
            this.Waybills_btn.UseVisualStyleBackColor = true;
            this.Waybills_btn.Click += new System.EventHandler(this.onWaybillsShow);
            // 
            // Clients_btn
            // 
            this.Clients_btn.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.Clients_btn.Location = new System.Drawing.Point(365, 128);
            this.Clients_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Clients_btn.Name = "Clients_btn";
            this.Clients_btn.Size = new System.Drawing.Size(241, 42);
            this.Clients_btn.TabIndex = 4;
            this.Clients_btn.Text = "Клиенты";
            this.Clients_btn.UseVisualStyleBackColor = true;
            this.Clients_btn.Click += new System.EventHandler(this.onClientsShow);
            // 
            // Carriers_btn
            // 
            this.Carriers_btn.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.Carriers_btn.Location = new System.Drawing.Point(365, 187);
            this.Carriers_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Carriers_btn.Name = "Carriers_btn";
            this.Carriers_btn.Size = new System.Drawing.Size(241, 42);
            this.Carriers_btn.TabIndex = 5;
            this.Carriers_btn.Text = "Перевозчики";
            this.Carriers_btn.UseVisualStyleBackColor = true;
            this.Carriers_btn.Click += new System.EventHandler(this.onCarriersShow);
            // 
            // Airports_btn
            // 
            this.Airports_btn.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.Airports_btn.Location = new System.Drawing.Point(365, 244);
            this.Airports_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Airports_btn.Name = "Airports_btn";
            this.Airports_btn.Size = new System.Drawing.Size(241, 42);
            this.Airports_btn.TabIndex = 6;
            this.Airports_btn.Text = "Аэропорты";
            this.Airports_btn.UseVisualStyleBackColor = true;
            this.Airports_btn.Click += new System.EventHandler(this.onAirportsShow);
            // 
            // CargoTypes_btn
            // 
            this.CargoTypes_btn.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.CargoTypes_btn.Location = new System.Drawing.Point(365, 302);
            this.CargoTypes_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CargoTypes_btn.Name = "CargoTypes_btn";
            this.CargoTypes_btn.Size = new System.Drawing.Size(241, 42);
            this.CargoTypes_btn.TabIndex = 7;
            this.CargoTypes_btn.Text = "Типы грузов";
            this.CargoTypes_btn.UseVisualStyleBackColor = true;
            this.CargoTypes_btn.Click += new System.EventHandler(this.onCargoTypesShow);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CargoTypes_btn);
            this.Controls.Add(this.Airports_btn);
            this.Controls.Add(this.Carriers_btn);
            this.Controls.Add(this.Clients_btn);
            this.Controls.Add(this.Waybills_btn);
            this.Controls.Add(this.Manifests_btn);
            this.Controls.Add(this.EFFM_gen_btn);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EFFM_gen_btn;
        private System.Windows.Forms.Button Manifests_btn;
        private System.Windows.Forms.Button Waybills_btn;
        private System.Windows.Forms.Button Clients_btn;
        private System.Windows.Forms.Button Carriers_btn;
        private System.Windows.Forms.Button Airports_btn;
        private System.Windows.Forms.Button CargoTypes_btn;
    }
}