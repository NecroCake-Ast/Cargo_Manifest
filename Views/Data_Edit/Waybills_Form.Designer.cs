
namespace Practic_3_curs.Views
{
    partial class Waybills_Form
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
            this.Waybills_Field = new System.Windows.Forms.TextBox();
            this.Remove_btn = new System.Windows.Forms.Button();
            this.Update_btn = new System.Windows.Forms.Button();
            this.Add_btn = new System.Windows.Forms.Button();
            this.Menu_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Weight_Inp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Volume_Inp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Place_Inp = new System.Windows.Forms.TextBox();
            this.CargoType_Inp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Recipient_Inp = new System.Windows.Forms.ComboBox();
            this.Sender_Inp = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.WaybillCode_Inp = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ManifestID_Inp = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.WaybillNumber_Inp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Waybills_Field
            // 
            this.Waybills_Field.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Waybills_Field.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Waybills_Field.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Waybills_Field.Location = new System.Drawing.Point(13, 245);
            this.Waybills_Field.MaxLength = 100000;
            this.Waybills_Field.Multiline = true;
            this.Waybills_Field.Name = "Waybills_Field";
            this.Waybills_Field.ReadOnly = true;
            this.Waybills_Field.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Waybills_Field.Size = new System.Drawing.Size(548, 248);
            this.Waybills_Field.TabIndex = 14;
            this.Waybills_Field.TabStop = false;
            // 
            // Remove_btn
            // 
            this.Remove_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.Remove_btn.Location = new System.Drawing.Point(394, 12);
            this.Remove_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Remove_btn.Name = "Remove_btn";
            this.Remove_btn.Size = new System.Drawing.Size(107, 34);
            this.Remove_btn.TabIndex = 13;
            this.Remove_btn.Text = "Удалить";
            this.Remove_btn.UseVisualStyleBackColor = true;
            this.Remove_btn.Click += new System.EventHandler(this.onRemoveClick);
            // 
            // Update_btn
            // 
            this.Update_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.Update_btn.Location = new System.Drawing.Point(267, 12);
            this.Update_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(107, 34);
            this.Update_btn.TabIndex = 12;
            this.Update_btn.Text = "Изменить";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.onUpdateClick);
            // 
            // Add_btn
            // 
            this.Add_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.Add_btn.Location = new System.Drawing.Point(140, 12);
            this.Add_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(107, 34);
            this.Add_btn.TabIndex = 11;
            this.Add_btn.Text = "Добавить";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.onAddClick);
            // 
            // Menu_btn
            // 
            this.Menu_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.Menu_btn.Location = new System.Drawing.Point(13, 12);
            this.Menu_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Menu_btn.Name = "Menu_btn";
            this.Menu_btn.Size = new System.Drawing.Size(75, 34);
            this.Menu_btn.TabIndex = 1;
            this.Menu_btn.Text = "Меню";
            this.Menu_btn.UseVisualStyleBackColor = true;
            this.Menu_btn.Click += new System.EventHandler(this.onMenuShow);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Вес груза";
            // 
            // Weight_Inp
            // 
            this.Weight_Inp.Location = new System.Drawing.Point(140, 145);
            this.Weight_Inp.MaxLength = 16;
            this.Weight_Inp.Name = "Weight_Inp";
            this.Weight_Inp.Size = new System.Drawing.Size(107, 23);
            this.Weight_Inp.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 38;
            this.label3.Text = "Объём груза";
            // 
            // Volume_Inp
            // 
            this.Volume_Inp.Location = new System.Drawing.Point(267, 145);
            this.Volume_Inp.MaxLength = 16;
            this.Volume_Inp.Name = "Volume_Inp";
            this.Volume_Inp.Size = new System.Drawing.Size(107, 23);
            this.Volume_Inp.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 40;
            this.label4.Text = "Количество мест";
            // 
            // Place_Inp
            // 
            this.Place_Inp.Location = new System.Drawing.Point(12, 145);
            this.Place_Inp.MaxLength = 16;
            this.Place_Inp.Name = "Place_Inp";
            this.Place_Inp.Size = new System.Drawing.Size(107, 23);
            this.Place_Inp.TabIndex = 5;
            // 
            // CargoType_Inp
            // 
            this.CargoType_Inp.FormattingEnabled = true;
            this.CargoType_Inp.Location = new System.Drawing.Point(13, 85);
            this.CargoType_Inp.Name = "CargoType_Inp";
            this.CargoType_Inp.Size = new System.Drawing.Size(107, 23);
            this.CargoType_Inp.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 45;
            this.label5.Text = "Тип груза";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 15);
            this.label6.TabIndex = 46;
            this.label6.Text = "Отправитель";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(267, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 47;
            this.label7.Text = "Получатель";
            // 
            // Recipient_Inp
            // 
            this.Recipient_Inp.FormattingEnabled = true;
            this.Recipient_Inp.Location = new System.Drawing.Point(267, 85);
            this.Recipient_Inp.Name = "Recipient_Inp";
            this.Recipient_Inp.Size = new System.Drawing.Size(107, 23);
            this.Recipient_Inp.TabIndex = 4;
            // 
            // Sender_Inp
            // 
            this.Sender_Inp.FormattingEnabled = true;
            this.Sender_Inp.Location = new System.Drawing.Point(140, 85);
            this.Sender_Inp.Name = "Sender_Inp";
            this.Sender_Inp.Size = new System.Drawing.Size(107, 23);
            this.Sender_Inp.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 15);
            this.label8.TabIndex = 55;
            this.label8.Text = "Код накладной";
            // 
            // WaybillCode_Inp
            // 
            this.WaybillCode_Inp.Location = new System.Drawing.Point(12, 207);
            this.WaybillCode_Inp.MaxLength = 16;
            this.WaybillCode_Inp.Name = "WaybillCode_Inp";
            this.WaybillCode_Inp.Size = new System.Drawing.Size(107, 23);
            this.WaybillCode_Inp.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 15);
            this.label9.TabIndex = 53;
            this.label9.Text = "ID декларации";
            // 
            // ManifestID_Inp
            // 
            this.ManifestID_Inp.Location = new System.Drawing.Point(267, 207);
            this.ManifestID_Inp.MaxLength = 16;
            this.ManifestID_Inp.Name = "ManifestID_Inp";
            this.ManifestID_Inp.Size = new System.Drawing.Size(107, 23);
            this.ManifestID_Inp.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(140, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 15);
            this.label10.TabIndex = 51;
            this.label10.Text = "Номер накладной";
            // 
            // WaybillNumber_Inp
            // 
            this.WaybillNumber_Inp.Location = new System.Drawing.Point(140, 207);
            this.WaybillNumber_Inp.MaxLength = 16;
            this.WaybillNumber_Inp.Name = "WaybillNumber_Inp";
            this.WaybillNumber_Inp.Size = new System.Drawing.Size(107, 23);
            this.WaybillNumber_Inp.TabIndex = 9;
            // 
            // Waybills_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.WaybillCode_Inp);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ManifestID_Inp);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.WaybillNumber_Inp);
            this.Controls.Add(this.Recipient_Inp);
            this.Controls.Add(this.Sender_Inp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CargoType_Inp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Place_Inp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Volume_Inp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Weight_Inp);
            this.Controls.Add(this.Waybills_Field);
            this.Controls.Add(this.Remove_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Menu_btn);
            this.Name = "Waybills_Form";
            this.Text = "Авианакладные";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Remove_btn;
        private System.Windows.Forms.Button Update_btn;
        private System.Windows.Forms.Button Add_btn;
        private System.Windows.Forms.Button Menu_btn;
        private System.Windows.Forms.TextBox Waybills_Field;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Weight_Inp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Volume_Inp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Place_Inp;
        private System.Windows.Forms.ComboBox CargoType_Inp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Recipient_Inp;
        private System.Windows.Forms.ComboBox Sender_Inp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox WaybillCode_Inp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ManifestID_Inp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox WaybillNumber_Inp;
    }
}