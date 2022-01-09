
namespace Kuldorendszer
{
    partial class Belepes
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
            this.BtnUjFelh = new System.Windows.Forms.Button();
            this.BtnBelep = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioBKuldo = new System.Windows.Forms.RadioButton();
            this.radioBAdmin = new System.Windows.Forms.RadioButton();
            this.txtBFelh = new System.Windows.Forms.TextBox();
            this.txtBJelszo = new System.Windows.Forms.TextBox();
            this.txtBEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnUjFelh
            // 
            this.BtnUjFelh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUjFelh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnUjFelh.Location = new System.Drawing.Point(361, 261);
            this.BtnUjFelh.Name = "BtnUjFelh";
            this.BtnUjFelh.Size = new System.Drawing.Size(110, 25);
            this.BtnUjFelh.TabIndex = 0;
            this.BtnUjFelh.Text = "Új felhasználó";
            this.BtnUjFelh.UseVisualStyleBackColor = true;
            this.BtnUjFelh.Click += new System.EventHandler(this.BtnUjFelh_Click);
            // 
            // BtnBelep
            // 
            this.BtnBelep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBelep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BtnBelep.Location = new System.Drawing.Point(140, 261);
            this.BtnBelep.Name = "BtnBelep";
            this.BtnBelep.Size = new System.Drawing.Size(131, 25);
            this.BtnBelep.TabIndex = 1;
            this.BtnBelep.Text = "Belép";
            this.BtnBelep.UseVisualStyleBackColor = true;
            this.BtnBelep.Click += new System.EventHandler(this.BtnBelep_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(361, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Felhasználónév";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(80, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Jelszó";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(81, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "E-mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(83, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Típus";
            // 
            // radioBKuldo
            // 
            this.radioBKuldo.AutoSize = true;
            this.radioBKuldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioBKuldo.Location = new System.Drawing.Point(143, 185);
            this.radioBKuldo.Name = "radioBKuldo";
            this.radioBKuldo.Size = new System.Drawing.Size(62, 21);
            this.radioBKuldo.TabIndex = 7;
            this.radioBKuldo.TabStop = true;
            this.radioBKuldo.Text = "Küldő";
            this.radioBKuldo.UseVisualStyleBackColor = true;
            // 
            // radioBAdmin
            // 
            this.radioBAdmin.AutoSize = true;
            this.radioBAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioBAdmin.Location = new System.Drawing.Point(143, 208);
            this.radioBAdmin.Name = "radioBAdmin";
            this.radioBAdmin.Size = new System.Drawing.Size(65, 21);
            this.radioBAdmin.TabIndex = 8;
            this.radioBAdmin.TabStop = true;
            this.radioBAdmin.Text = "Admin";
            this.radioBAdmin.UseVisualStyleBackColor = true;
            // 
            // txtBFelh
            // 
            this.txtBFelh.Location = new System.Drawing.Point(140, 40);
            this.txtBFelh.Name = "txtBFelh";
            this.txtBFelh.Size = new System.Drawing.Size(131, 20);
            this.txtBFelh.TabIndex = 9;
            // 
            // txtBJelszo
            // 
            this.txtBJelszo.Location = new System.Drawing.Point(140, 85);
            this.txtBJelszo.Name = "txtBJelszo";
            this.txtBJelszo.PasswordChar = '*';
            this.txtBJelszo.Size = new System.Drawing.Size(131, 20);
            this.txtBJelszo.TabIndex = 10;
            // 
            // txtBEmail
            // 
            this.txtBEmail.Location = new System.Drawing.Point(140, 128);
            this.txtBEmail.Multiline = true;
            this.txtBEmail.Name = "txtBEmail";
            this.txtBEmail.Size = new System.Drawing.Size(131, 20);
            this.txtBEmail.TabIndex = 11;
            // 
            // Belepes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 334);
            this.Controls.Add(this.txtBEmail);
            this.Controls.Add(this.txtBJelszo);
            this.Controls.Add(this.txtBFelh);
            this.Controls.Add(this.radioBAdmin);
            this.Controls.Add(this.radioBKuldo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.BtnBelep);
            this.Controls.Add(this.BtnUjFelh);
            this.Name = "Belepes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Belépés";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnUjFelh;
        private System.Windows.Forms.Button BtnBelep;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioBKuldo;
        private System.Windows.Forms.RadioButton radioBAdmin;
        private System.Windows.Forms.TextBox txtBFelh;
        private System.Windows.Forms.TextBox txtBJelszo;
        private System.Windows.Forms.TextBox txtBEmail;
    }
}

