
namespace Kuldorendszer
{
    partial class Osztaly
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
            this.txtBOsztaly = new System.Windows.Forms.TextBox();
            this.txtBOsztalyKod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 33);
            this.button1.TabIndex = 54;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnMegse
            // 
            this.btnMegse.Location = new System.Drawing.Point(234, 139);
            this.btnMegse.Name = "btnMegse";
            this.btnMegse.Size = new System.Drawing.Size(84, 33);
            this.btnMegse.TabIndex = 55;
            this.btnMegse.Text = "Mégsem";
            this.btnMegse.UseVisualStyleBackColor = true;
            this.btnMegse.Click += new System.EventHandler(this.btnMegse_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(11, 139);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 33);
            this.btnOk.TabIndex = 53;
            this.btnOk.Text = "Felvitel";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtBOsztaly
            // 
            this.txtBOsztaly.Location = new System.Drawing.Point(151, 81);
            this.txtBOsztaly.Name = "txtBOsztaly";
            this.txtBOsztaly.Size = new System.Drawing.Size(122, 20);
            this.txtBOsztaly.TabIndex = 50;
            // 
            // txtBOsztalyKod
            // 
            this.txtBOsztalyKod.Location = new System.Drawing.Point(151, 31);
            this.txtBOsztalyKod.Name = "txtBOsztalyKod";
            this.txtBOsztalyKod.Size = new System.Drawing.Size(122, 20);
            this.txtBOsztalyKod.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Osztály :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Osztály kód:";
            // 
            // Osztaly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 190);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMegse);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtBOsztaly);
            this.Controls.Add(this.txtBOsztalyKod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Osztaly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Osztály";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMegse;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtBOsztaly;
        private System.Windows.Forms.TextBox txtBOsztalyKod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}