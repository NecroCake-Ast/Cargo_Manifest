
namespace Practic_3_curs.Views
{
    partial class EFFM_Form
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
            this.Enter_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Send = new System.Windows.Forms.Button();
            this.AddressTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EnterDate = new System.Windows.Forms.DateTimePicker();
            this.EnterFlight = new System.Windows.Forms.ComboBox();
            this.CM = new System.Windows.Forms.TextBox();
            this.Menu_btn = new System.Windows.Forms.Button();
            this.genDoc_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Enter_btn
            // 
            this.Enter_btn.Location = new System.Drawing.Point(13, 152);
            this.Enter_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Enter_btn.Name = "Enter_btn";
            this.Enter_btn.Size = new System.Drawing.Size(163, 28);
            this.Enter_btn.TabIndex = 3;
            this.Enter_btn.Text = "Вывести E-FFM";
            this.Enter_btn.UseVisualStyleBackColor = true;
            this.Enter_btn.Click += new System.EventHandler(this.Enter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Дата";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Рейс";
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(683, 96);
            this.Send.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(110, 28);
            this.Send.TabIndex = 6;
            this.Send.Text = "Отправить почту";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // AddressTo
            // 
            this.AddressTo.Location = new System.Drawing.Point(587, 67);
            this.AddressTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddressTo.Name = "AddressTo";
            this.AddressTo.Size = new System.Drawing.Size(206, 23);
            this.AddressTo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(473, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Получатель:";
            // 
            // EnterDate
            // 
            this.EnterDate.Location = new System.Drawing.Point(76, 64);
            this.EnterDate.Name = "EnterDate";
            this.EnterDate.Size = new System.Drawing.Size(155, 23);
            this.EnterDate.TabIndex = 1;
            this.EnterDate.ValueChanged += new System.EventHandler(this.onDateSelect);
            // 
            // EnterFlight
            // 
            this.EnterFlight.FormattingEnabled = true;
            this.EnterFlight.Location = new System.Drawing.Point(76, 110);
            this.EnterFlight.Name = "EnterFlight";
            this.EnterFlight.Size = new System.Drawing.Size(155, 23);
            this.EnterFlight.TabIndex = 2;
            // 
            // CM
            // 
            this.CM.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CM.Location = new System.Drawing.Point(13, 234);
            this.CM.Multiline = true;
            this.CM.Name = "CM";
            this.CM.ReadOnly = true;
            this.CM.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CM.Size = new System.Drawing.Size(780, 273);
            this.CM.TabIndex = 6;
            this.CM.TabStop = false;
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
            // genDoc_btn
            // 
            this.genDoc_btn.Location = new System.Drawing.Point(13, 186);
            this.genDoc_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.genDoc_btn.Name = "genDoc_btn";
            this.genDoc_btn.Size = new System.Drawing.Size(163, 31);
            this.genDoc_btn.TabIndex = 5;
            this.genDoc_btn.Text = "Сформировать документ";
            this.genDoc_btn.UseVisualStyleBackColor = true;
            this.genDoc_btn.Click += new System.EventHandler(this.CreateDoc_Click);
            // 
            // EFFM_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 519);
            this.Controls.Add(this.genDoc_btn);
            this.Controls.Add(this.Menu_btn);
            this.Controls.Add(this.CM);
            this.Controls.Add(this.EnterFlight);
            this.Controls.Add(this.EnterDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddressTo);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Enter_btn);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "EFFM_Form";
            this.Text = "E-FFM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Enter_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox AddressTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker EnterDate;
        private System.Windows.Forms.ComboBox EnterFlight;
        private System.Windows.Forms.TextBox CM;
        private System.Windows.Forms.Button Menu_btn;
        private System.Windows.Forms.Button genDoc_btn;
    }
}