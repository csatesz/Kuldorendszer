
namespace Kuldorendszer
{
    partial class Jatekvezeto
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
            this.cBoxOsztaly = new System.Windows.Forms.ComboBox();
            this.txtBJvNev = new System.Windows.Forms.TextBox();
            this.cBoxTelepules = new System.Windows.Forms.ComboBox();
            this.cBoxElerhetoseg = new System.Windows.Forms.ComboBox();
            this.txtBJvKod = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMegse = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtBMinosites = new System.Windows.Forms.TextBox();
            this.cBoxFeladat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cBoxOsztaly
            // 
            this.cBoxOsztaly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxOsztaly.FormattingEnabled = true;
            this.cBoxOsztaly.Location = new System.Drawing.Point(158, 222);
            this.cBoxOsztaly.Name = "cBoxOsztaly";
            this.cBoxOsztaly.Size = new System.Drawing.Size(121, 21);
            this.cBoxOsztaly.Sorted = true;
            this.cBoxOsztaly.TabIndex = 23;
            this.cBoxOsztaly.SelectedIndexChanged += new System.EventHandler(this.cBoxOsztaly_SelectedIndexChanged);
            // 
            // txtBJvNev
            // 
            this.txtBJvNev.Location = new System.Drawing.Point(158, 58);
            this.txtBJvNev.Name = "txtBJvNev";
            this.txtBJvNev.Size = new System.Drawing.Size(122, 20);
            this.txtBJvNev.TabIndex = 24;
            // 
            // cBoxTelepules
            // 
            this.cBoxTelepules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTelepules.Location = new System.Drawing.Point(158, 144);
            this.cBoxTelepules.Name = "cBoxTelepules";
            this.cBoxTelepules.Size = new System.Drawing.Size(122, 21);
            this.cBoxTelepules.Sorted = true;
            this.cBoxTelepules.TabIndex = 21;
            this.cBoxTelepules.SelectedIndexChanged += new System.EventHandler(this.cBoxTelepules_SelectedIndexChanged);
            // 
            // cBoxElerhetoseg
            // 
            this.cBoxElerhetoseg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxElerhetoseg.FormattingEnabled = true;
            this.cBoxElerhetoseg.Location = new System.Drawing.Point(158, 97);
            this.cBoxElerhetoseg.Name = "cBoxElerhetoseg";
            this.cBoxElerhetoseg.Size = new System.Drawing.Size(121, 21);
            this.cBoxElerhetoseg.Sorted = true;
            this.cBoxElerhetoseg.TabIndex = 15;
            this.cBoxElerhetoseg.SelectedIndexChanged += new System.EventHandler(this.cBoxElerhetoseg_SelectedIndexChanged);
            // 
            // txtBJvKod
            // 
            this.txtBJvKod.Location = new System.Drawing.Point(158, 21);
            this.txtBJvKod.Name = "txtBJvKod";
            this.txtBJvKod.Size = new System.Drawing.Size(122, 20);
            this.txtBJvKod.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Keret";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Feladatkör:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Minősítés";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Település:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 33);
            this.button1.TabIndex = 28;
            this.button1.Text = "Módosít";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.update_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Elérhetőség";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Játékvezető neve:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Játékvezető kód:";
            // 
            // btnMegse
            // 
            this.btnMegse.Location = new System.Drawing.Point(323, 323);
            this.btnMegse.Name = "btnMegse";
            this.btnMegse.Size = new System.Drawing.Size(84, 33);
            this.btnMegse.TabIndex = 30;
            this.btnMegse.Text = "Mégsem";
            this.btnMegse.UseVisualStyleBackColor = true;
            this.btnMegse.Click += new System.EventHandler(this.btnMegse_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(42, 323);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 33);
            this.btnOk.TabIndex = 26;
            this.btnOk.Text = "Felvitel";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtBMinosites
            // 
            this.txtBMinosites.Location = new System.Drawing.Point(158, 183);
            this.txtBMinosites.Name = "txtBMinosites";
            this.txtBMinosites.Size = new System.Drawing.Size(122, 20);
            this.txtBMinosites.TabIndex = 32;
            // 
            // cBoxFeladat
            // 
            this.cBoxFeladat.FormattingEnabled = true;
            this.cBoxFeladat.Location = new System.Drawing.Point(158, 264);
            this.cBoxFeladat.Name = "cBoxFeladat";
            this.cBoxFeladat.Size = new System.Drawing.Size(121, 21);
            this.cBoxFeladat.TabIndex = 33;
            // 
            // Jatekvezeto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(436, 377);
            this.Controls.Add(this.cBoxFeladat);
            this.Controls.Add(this.txtBMinosites);
            this.Controls.Add(this.cBoxOsztaly);
            this.Controls.Add(this.txtBJvNev);
            this.Controls.Add(this.cBoxTelepules);
            this.Controls.Add(this.cBoxElerhetoseg);
            this.Controls.Add(this.txtBJvKod);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMegse);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Jatekvezeto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jatekvezeto";
            this.Load += new System.EventHandler(this.Jatekvezeto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cBoxOsztaly;
        private System.Windows.Forms.TextBox txtBJvNev;
        private System.Windows.Forms.ComboBox cBoxTelepules;
        private System.Windows.Forms.ComboBox cBoxElerhetoseg;
        private System.Windows.Forms.TextBox txtBJvKod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMegse;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtBMinosites;
        private System.Windows.Forms.ComboBox cBoxFeladat;
    }
}