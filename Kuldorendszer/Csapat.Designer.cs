
namespace Kuldorendszer
{
    partial class Csapat
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
            this.txtBCsapatvezeto = new System.Windows.Forms.TextBox();
            this.cBoxOsztaly = new System.Windows.Forms.ComboBox();
            this.txtBCsapatNev = new System.Windows.Forms.TextBox();
            this.cBoxElerhetoseg = new System.Windows.Forms.ComboBox();
            this.txtBCsapatKod = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMegse = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBCsapatvezeto
            // 
            this.txtBCsapatvezeto.Location = new System.Drawing.Point(149, 170);
            this.txtBCsapatvezeto.Name = "txtBCsapatvezeto";
            this.txtBCsapatvezeto.Size = new System.Drawing.Size(122, 20);
            this.txtBCsapatvezeto.TabIndex = 50;
            // 
            // cBoxOsztaly
            // 
            this.cBoxOsztaly.FormattingEnabled = true;
            this.cBoxOsztaly.Location = new System.Drawing.Point(149, 224);
            this.cBoxOsztaly.Name = "cBoxOsztaly";
            this.cBoxOsztaly.Size = new System.Drawing.Size(121, 21);
            this.cBoxOsztaly.TabIndex = 41;
            // 
            // txtBCsapatNev
            // 
            this.txtBCsapatNev.Location = new System.Drawing.Point(149, 72);
            this.txtBCsapatNev.Name = "txtBCsapatNev";
            this.txtBCsapatNev.Size = new System.Drawing.Size(122, 20);
            this.txtBCsapatNev.TabIndex = 42;
            // 
            // cBoxElerhetoseg
            // 
            this.cBoxElerhetoseg.FormattingEnabled = true;
            this.cBoxElerhetoseg.Location = new System.Drawing.Point(149, 123);
            this.cBoxElerhetoseg.Name = "cBoxElerhetoseg";
            this.cBoxElerhetoseg.Size = new System.Drawing.Size(121, 21);
            this.cBoxElerhetoseg.TabIndex = 36;
            this.cBoxElerhetoseg.SelectedIndexChanged += new System.EventHandler(this.cBoxElerhetoseg_SelectedIndexChanged);
            // 
            // txtBCsapatKod
            // 
            this.txtBCsapatKod.Location = new System.Drawing.Point(149, 23);
            this.txtBCsapatKod.Name = "txtBCsapatKod";
            this.txtBCsapatKod.Size = new System.Drawing.Size(122, 20);
            this.txtBCsapatKod.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Osztály";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Csapatvezető:";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(178, 325);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(84, 33);
            this.btnImport.TabIndex = 46;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Elérhetőség";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Csapat neve:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Csapat kód:";
            // 
            // btnMegse
            // 
            this.btnMegse.Location = new System.Drawing.Point(314, 325);
            this.btnMegse.Name = "btnMegse";
            this.btnMegse.Size = new System.Drawing.Size(84, 33);
            this.btnMegse.TabIndex = 48;
            this.btnMegse.Text = "Mégsem";
            this.btnMegse.UseVisualStyleBackColor = true;
            this.btnMegse.Click += new System.EventHandler(this.btnMegse_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(33, 325);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 33);
            this.btnOk.TabIndex = 44;
            this.btnOk.Text = "Felvitel";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Csapat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 381);
            this.Controls.Add(this.txtBCsapatvezeto);
            this.Controls.Add(this.cBoxOsztaly);
            this.Controls.Add(this.txtBCsapatNev);
            this.Controls.Add(this.cBoxElerhetoseg);
            this.Controls.Add(this.txtBCsapatKod);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMegse);
            this.Controls.Add(this.btnOk);
            this.Name = "Csapat";
            this.Text = "Csapat";
            this.Load += new System.EventHandler(this.Csapat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBCsapatvezeto;
        private System.Windows.Forms.ComboBox cBoxOsztaly;
        private System.Windows.Forms.TextBox txtBCsapatNev;
        private System.Windows.Forms.ComboBox cBoxElerhetoseg;
        private System.Windows.Forms.TextBox txtBCsapatKod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMegse;
        private System.Windows.Forms.Button btnOk;
    }
}