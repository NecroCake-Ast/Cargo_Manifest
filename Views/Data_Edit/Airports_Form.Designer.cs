
namespace Practic_3_curs.Views
{
    partial class Airports_Form
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
            this.Airports_Field = new System.Windows.Forms.TextBox();
            this.Remove_btn = new System.Windows.Forms.Button();
            this.Update_btn = new System.Windows.Forms.Button();
            this.Add_btn = new System.Windows.Forms.Button();
            this.ENName_Inp = new System.Windows.Forms.TextBox();
            this.RUName_Inp = new System.Windows.Forms.TextBox();
            this.ID_Inp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Menu_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Airports_Field
            // 
            this.Airports_Field.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Airports_Field.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Airports_Field.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Airports_Field.Location = new System.Drawing.Point(13, 197);
            this.Airports_Field.MaxLength = 100000;
            this.Airports_Field.Multiline = true;
            this.Airports_Field.Name = "Airports_Field";
            this.Airports_Field.ReadOnly = true;
            this.Airports_Field.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Airports_Field.Size = new System.Drawing.Size(548, 241);
            this.Airports_Field.TabIndex = 7;
            this.Airports_Field.TabStop = false;
            // 
            // Remove_btn
            // 
            this.Remove_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.Remove_btn.Location = new System.Drawing.Point(270, 140);
            this.Remove_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Remove_btn.Name = "Remove_btn";
            this.Remove_btn.Size = new System.Drawing.Size(107, 34);
            this.Remove_btn.TabIndex = 6;
            this.Remove_btn.Text = "Удалить";
            this.Remove_btn.UseVisualStyleBackColor = true;
            this.Remove_btn.Click += new System.EventHandler(this.onRemoveClick);
            // 
            // Update_btn
            // 
            this.Update_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.Update_btn.Location = new System.Drawing.Point(140, 140);
            this.Update_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(107, 34);
            this.Update_btn.TabIndex = 5;
            this.Update_btn.Text = "Изменить";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.onUpdateClick);
            // 
            // Add_btn
            // 
            this.Add_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.Add_btn.Location = new System.Drawing.Point(12, 140);
            this.Add_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(107, 34);
            this.Add_btn.TabIndex = 4;
            this.Add_btn.Text = "Добавить";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.onAddClick);
            // 
            // ENName_Inp
            // 
            this.ENName_Inp.Location = new System.Drawing.Point(379, 91);
            this.ENName_Inp.MaxLength = 3;
            this.ENName_Inp.Name = "ENName_Inp";
            this.ENName_Inp.Size = new System.Drawing.Size(182, 23);
            this.ENName_Inp.TabIndex = 3;
            // 
            // RUName_Inp
            // 
            this.RUName_Inp.Location = new System.Drawing.Point(157, 91);
            this.RUName_Inp.MaxLength = 3;
            this.RUName_Inp.Name = "RUName_Inp";
            this.RUName_Inp.Size = new System.Drawing.Size(182, 23);
            this.RUName_Inp.TabIndex = 2;
            // 
            // ID_Inp
            // 
            this.ID_Inp.Location = new System.Drawing.Point(12, 91);
            this.ID_Inp.MaxLength = 10;
            this.ID_Inp.Name = "ID_Inp";
            this.ID_Inp.Size = new System.Drawing.Size(108, 23);
            this.ID_Inp.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "Английское наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 15);
            this.label2.TabIndex = 35;
            this.label2.Text = "Русское наименование";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 34;
            this.label1.Text = "ID";
            // 
            // Menu_btn
            // 
            this.Menu_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.Menu_btn.Location = new System.Drawing.Point(13, 12);
            this.Menu_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Menu_btn.Name = "Menu_btn";
            this.Menu_btn.Size = new System.Drawing.Size(75, 34);
            this.Menu_btn.TabIndex = 0;
            this.Menu_btn.Text = "Меню";
            this.Menu_btn.UseVisualStyleBackColor = true;
            this.Menu_btn.Click += new System.EventHandler(this.onMenuShow);
            // 
            // Airports_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Airports_Field);
            this.Controls.Add(this.Remove_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.ENName_Inp);
            this.Controls.Add(this.RUName_Inp);
            this.Controls.Add(this.ID_Inp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Menu_btn);
            this.Name = "Airports_Form";
            this.Text = "Airports_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Airports_Field;
        private System.Windows.Forms.Button Remove_btn;
        private System.Windows.Forms.Button Update_btn;
        private System.Windows.Forms.Button Add_btn;
        private System.Windows.Forms.TextBox ENName_Inp;
        private System.Windows.Forms.TextBox RUName_Inp;
        private System.Windows.Forms.TextBox ID_Inp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Menu_btn;
    }
}