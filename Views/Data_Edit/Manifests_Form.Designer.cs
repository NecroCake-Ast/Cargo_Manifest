
namespace Practic_3_curs.Views
{
    partial class Manifests_Form
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
            this.Manifests_Field = new System.Windows.Forms.TextBox();
            this.Remove_btn = new System.Windows.Forms.Button();
            this.Update_btn = new System.Windows.Forms.Button();
            this.Add_btn = new System.Windows.Forms.Button();
            this.Menu_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ID_Inp = new System.Windows.Forms.TextBox();
            this.From_Inp = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Flight_Inp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Carrier_Inp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Date_Inp = new System.Windows.Forms.DateTimePicker();
            this.Aircraft_Inp = new System.Windows.Forms.TextBox();
            this.To_Inp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Time_Inp = new System.Windows.Forms.DateTimePicker();
            this.isDateUpdate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Manifests_Field
            // 
            this.Manifests_Field.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Manifests_Field.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Manifests_Field.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Manifests_Field.Location = new System.Drawing.Point(13, 245);
            this.Manifests_Field.MaxLength = 100000;
            this.Manifests_Field.Multiline = true;
            this.Manifests_Field.Name = "Manifests_Field";
            this.Manifests_Field.ReadOnly = true;
            this.Manifests_Field.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Manifests_Field.Size = new System.Drawing.Size(548, 248);
            this.Manifests_Field.TabIndex = 14;
            this.Manifests_Field.TabStop = false;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 15);
            this.label4.TabIndex = 40;
            this.label4.Text = "ID";
            // 
            // ID_Inp
            // 
            this.ID_Inp.Location = new System.Drawing.Point(13, 83);
            this.ID_Inp.MaxLength = 16;
            this.ID_Inp.Name = "ID_Inp";
            this.ID_Inp.Size = new System.Drawing.Size(107, 23);
            this.ID_Inp.TabIndex = 5;
            // 
            // From_Inp
            // 
            this.From_Inp.FormattingEnabled = true;
            this.From_Inp.Location = new System.Drawing.Point(13, 207);
            this.From_Inp.Name = "From_Inp";
            this.From_Inp.Size = new System.Drawing.Size(107, 23);
            this.From_Inp.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 45;
            this.label5.Text = "Рейс";
            // 
            // Flight_Inp
            // 
            this.Flight_Inp.Location = new System.Drawing.Point(140, 144);
            this.Flight_Inp.MaxLength = 16;
            this.Flight_Inp.Name = "Flight_Inp";
            this.Flight_Inp.Size = new System.Drawing.Size(107, 23);
            this.Flight_Inp.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 57;
            this.label1.Text = "Перевозчик";
            // 
            // Carrier_Inp
            // 
            this.Carrier_Inp.FormattingEnabled = true;
            this.Carrier_Inp.Location = new System.Drawing.Point(13, 144);
            this.Carrier_Inp.Name = "Carrier_Inp";
            this.Carrier_Inp.Size = new System.Drawing.Size(107, 23);
            this.Carrier_Inp.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 60;
            this.label2.Text = "Дата и время";
            // 
            // Date_Inp
            // 
            this.Date_Inp.Location = new System.Drawing.Point(394, 141);
            this.Date_Inp.Name = "Date_Inp";
            this.Date_Inp.Size = new System.Drawing.Size(145, 23);
            this.Date_Inp.TabIndex = 61;
            // 
            // Aircraft_Inp
            // 
            this.Aircraft_Inp.Location = new System.Drawing.Point(267, 144);
            this.Aircraft_Inp.MaxLength = 16;
            this.Aircraft_Inp.Name = "Aircraft_Inp";
            this.Aircraft_Inp.Size = new System.Drawing.Size(107, 23);
            this.Aircraft_Inp.TabIndex = 62;
            // 
            // To_Inp
            // 
            this.To_Inp.FormattingEnabled = true;
            this.To_Inp.Location = new System.Drawing.Point(140, 207);
            this.To_Inp.Name = "To_Inp";
            this.To_Inp.Size = new System.Drawing.Size(107, 23);
            this.To_Inp.TabIndex = 63;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 64;
            this.label3.Text = "Борт";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 15);
            this.label6.TabIndex = 66;
            this.label6.Text = "Аэропорт вылета";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(140, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 15);
            this.label7.TabIndex = 65;
            this.label7.Text = "Аэропорт прибытия";
            // 
            // Time_Inp
            // 
            this.Time_Inp.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.Time_Inp.Location = new System.Drawing.Point(545, 141);
            this.Time_Inp.Name = "Time_Inp";
            this.Time_Inp.ShowUpDown = true;
            this.Time_Inp.Size = new System.Drawing.Size(81, 23);
            this.Time_Inp.TabIndex = 67;
            // 
            // isDateUpdate
            // 
            this.isDateUpdate.AutoSize = true;
            this.isDateUpdate.Location = new System.Drawing.Point(394, 170);
            this.isDateUpdate.Name = "isDateUpdate";
            this.isDateUpdate.Size = new System.Drawing.Size(153, 19);
            this.isDateUpdate.TabIndex = 68;
            this.isDateUpdate.Text = "Обновить дату и время";
            this.isDateUpdate.UseVisualStyleBackColor = true;
            // 
            // Manifests_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.isDateUpdate);
            this.Controls.Add(this.Time_Inp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.To_Inp);
            this.Controls.Add(this.Aircraft_Inp);
            this.Controls.Add(this.Date_Inp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Carrier_Inp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Flight_Inp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.From_Inp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ID_Inp);
            this.Controls.Add(this.Manifests_Field);
            this.Controls.Add(this.Remove_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Menu_btn);
            this.Name = "Manifests_Form";
            this.Text = "Декларации";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Remove_btn;
        private System.Windows.Forms.Button Update_btn;
        private System.Windows.Forms.Button Add_btn;
        private System.Windows.Forms.Button Menu_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ID_Inp;
        private System.Windows.Forms.ComboBox From_Inp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Flight_Inp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Carrier_Inp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker Date_Inp;
        private System.Windows.Forms.TextBox Aircraft_Inp;
        private System.Windows.Forms.ComboBox To_Inp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Manifests_Field;
        private System.Windows.Forms.DateTimePicker Time_Inp;
        private System.Windows.Forms.CheckBox isDateUpdate;
    }
}