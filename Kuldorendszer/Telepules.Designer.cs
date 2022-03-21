
namespace Kuldorendszer
{
    partial class Telepules
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
            this.txtBIrSzam = new System.Windows.Forms.TextBox();
            this.txtBTelepules = new System.Windows.Forms.TextBox();
            this.txtBTelepulesKod = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMegse = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBIrSzam
            // 
            this.txtBIrSzam.Location = new System.Drawing.Point(156, 122);
            this.txtBIrSzam.Name = "txtBIrSzam";
            this.txtBIrSzam.Size = new System.Drawing.Size(122, 20);
            this.txtBIrSzam.TabIndex = 43;
            // 
            // txtBTelepules
            // 
            this.txtBTelepules.Location = new System.Drawing.Point(156, 78);
            this.txtBTelepules.Name = "txtBTelepules";
            this.txtBTelepules.Size = new System.Drawing.Size(122, 20);
            this.txtBTelepules.TabIndex = 40;
            // 
            // txtBTelepulesKod
            // 
            this.txtBTelepulesKod.Location = new System.Drawing.Point(156, 41);
            this.txtBTelepulesKod.Name = "txtBTelepulesKod";
            this.txtBTelepulesKod.Size = new System.Drawing.Size(122, 20);
            this.txtBTelepulesKod.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Iránítószám:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Település:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Település kód:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 33);
            this.button1.TabIndex = 45;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnMegse
            // 
            this.btnMegse.Location = new System.Drawing.Point(234, 218);
            this.btnMegse.Name = "btnMegse";
            this.btnMegse.Size = new System.Drawing.Size(84, 33);
            this.btnMegse.TabIndex = 46;
            this.btnMegse.Text = "Mégsem";
            this.btnMegse.UseVisualStyleBackColor = true;
            this.btnMegse.Click += new System.EventHandler(this.btnMegse_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(11, 218);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 33);
            this.btnOk.TabIndex = 44;
            this.btnOk.Text = "Felvitel";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Telepules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(330, 278);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMegse);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtBIrSzam);
            this.Controls.Add(this.txtBTelepules);
            this.Controls.Add(this.txtBTelepulesKod);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Telepules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telepules";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBIrSzam;
        private System.Windows.Forms.TextBox txtBTelepules;
        private System.Windows.Forms.TextBox txtBTelepulesKod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMegse;
        private System.Windows.Forms.Button btnOk;
    }
}