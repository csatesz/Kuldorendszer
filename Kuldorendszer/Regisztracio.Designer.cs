﻿
namespace Kuldorendszer
{
    partial class Regisztracio
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
            this.txtBRegEmail = new System.Windows.Forms.TextBox();
            this.txtBRegJelszo = new System.Windows.Forms.TextBox();
            this.txtBRegFelh = new System.Windows.Forms.TextBox();
            this.radioBAdmin = new System.Windows.Forms.RadioButton();
            this.radioBKuldo = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnReg = new System.Windows.Forms.Button();
            this.txtBJelszoUjra = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBRegEmail
            // 
            this.txtBRegEmail.Location = new System.Drawing.Point(175, 165);
            this.txtBRegEmail.Multiline = true;
            this.txtBRegEmail.Name = "txtBRegEmail";
            this.txtBRegEmail.Size = new System.Drawing.Size(131, 20);
            this.txtBRegEmail.TabIndex = 21;
            // 
            // txtBRegJelszo
            // 
            this.txtBRegJelszo.Location = new System.Drawing.Point(175, 82);
            this.txtBRegJelszo.Name = "txtBRegJelszo";
            this.txtBRegJelszo.PasswordChar = '*';
            this.txtBRegJelszo.Size = new System.Drawing.Size(131, 20);
            this.txtBRegJelszo.TabIndex = 20;
            // 
            // txtBRegFelh
            // 
            this.txtBRegFelh.Location = new System.Drawing.Point(175, 40);
            this.txtBRegFelh.Name = "txtBRegFelh";
            this.txtBRegFelh.Size = new System.Drawing.Size(131, 20);
            this.txtBRegFelh.TabIndex = 19;
            // 
            // radioBAdmin
            // 
            this.radioBAdmin.AutoSize = true;
            this.radioBAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioBAdmin.Location = new System.Drawing.Point(178, 241);
            this.radioBAdmin.Name = "radioBAdmin";
            this.radioBAdmin.Size = new System.Drawing.Size(65, 21);
            this.radioBAdmin.TabIndex = 18;
            this.radioBAdmin.TabStop = true;
            this.radioBAdmin.Text = "Admin";
            this.radioBAdmin.UseVisualStyleBackColor = true;
            // 
            // radioBKuldo
            // 
            this.radioBKuldo.AutoSize = true;
            this.radioBKuldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioBKuldo.Location = new System.Drawing.Point(178, 218);
            this.radioBKuldo.Name = "radioBKuldo";
            this.radioBKuldo.Size = new System.Drawing.Size(62, 21);
            this.radioBKuldo.TabIndex = 17;
            this.radioBKuldo.TabStop = true;
            this.radioBKuldo.Text = "Küldő";
            this.radioBKuldo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(118, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Típus";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(116, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "E-mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(115, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Jelszó";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(56, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Felhasználónév";
            // 
            // BtnReg
            // 
            this.BtnReg.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnReg.Location = new System.Drawing.Point(144, 287);
            this.BtnReg.Name = "BtnReg";
            this.BtnReg.Size = new System.Drawing.Size(131, 25);
            this.BtnReg.TabIndex = 12;
            this.BtnReg.Text = "Regisztráció";
            this.BtnReg.UseVisualStyleBackColor = false;
            this.BtnReg.Click += new System.EventHandler(this.BtnReg_Click);
            // 
            // txtBJelszoUjra
            // 
            this.txtBJelszoUjra.Location = new System.Drawing.Point(175, 125);
            this.txtBJelszoUjra.Name = "txtBJelszoUjra";
            this.txtBJelszoUjra.PasswordChar = '*';
            this.txtBJelszoUjra.Size = new System.Drawing.Size(131, 20);
            this.txtBJelszoUjra.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(65, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ismételt jelszó";
            // 
            // Regisztracio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(414, 334);
            this.Controls.Add(this.txtBJelszoUjra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBRegEmail);
            this.Controls.Add(this.txtBRegJelszo);
            this.Controls.Add(this.txtBRegFelh);
            this.Controls.Add(this.radioBAdmin);
            this.Controls.Add(this.radioBKuldo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnReg);
            this.Name = "Regisztracio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Regisztráció";
            this.Load += new System.EventHandler(this.Regisztracio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBRegEmail;
        private System.Windows.Forms.TextBox txtBRegJelszo;
        private System.Windows.Forms.TextBox txtBRegFelh;
        private System.Windows.Forms.RadioButton radioBAdmin;
        private System.Windows.Forms.RadioButton radioBKuldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnReg;
        private System.Windows.Forms.TextBox txtBJelszoUjra;
        private System.Windows.Forms.Label label5;
    }
}