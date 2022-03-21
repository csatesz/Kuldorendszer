
namespace Kuldorendszer
{
    partial class Elerhetoseg
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnMegse = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtBTelSzam = new System.Windows.Forms.TextBox();
            this.txtBEmail = new System.Windows.Forms.TextBox();
            this.txtBElerhetosegKod = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 33);
            this.button1.TabIndex = 54;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnMegse
            // 
            this.btnMegse.Location = new System.Drawing.Point(237, 205);
            this.btnMegse.Name = "btnMegse";
            this.btnMegse.Size = new System.Drawing.Size(84, 33);
            this.btnMegse.TabIndex = 55;
            this.btnMegse.Text = "Mégsem";
            this.btnMegse.UseVisualStyleBackColor = true;
            this.btnMegse.Click += new System.EventHandler(this.btnMegse_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(14, 205);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 33);
            this.btnOk.TabIndex = 53;
            this.btnOk.Text = "Felvitel";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtBTelSzam
            // 
            this.txtBTelSzam.Location = new System.Drawing.Point(159, 109);
            this.txtBTelSzam.Name = "txtBTelSzam";
            this.txtBTelSzam.Size = new System.Drawing.Size(122, 20);
            this.txtBTelSzam.TabIndex = 52;
            // 
            // txtBEmail
            // 
            this.txtBEmail.Location = new System.Drawing.Point(159, 65);
            this.txtBEmail.Name = "txtBEmail";
            this.txtBEmail.Size = new System.Drawing.Size(122, 20);
            this.txtBEmail.TabIndex = 50;
            // 
            // txtBElerhetosegKod
            // 
            this.txtBElerhetosegKod.Location = new System.Drawing.Point(159, 28);
            this.txtBElerhetosegKod.Name = "txtBElerhetosegKod";
            this.txtBElerhetosegKod.Size = new System.Drawing.Size(122, 20);
            this.txtBElerhetosegKod.TabIndex = 47;
            this.txtBElerhetosegKod.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Telefonszám:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Email-cím:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Elérhetőség kód:";
            this.label1.Visible = false;
            // 
            // Elerhetoseg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(340, 287);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMegse);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtBTelSzam);
            this.Controls.Add(this.txtBEmail);
            this.Controls.Add(this.txtBElerhetosegKod);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Elerhetoseg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elérhetőség";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMegse;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtBTelSzam;
        private System.Windows.Forms.TextBox txtBEmail;
        private System.Windows.Forms.TextBox txtBElerhetosegKod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}