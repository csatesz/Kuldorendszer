
namespace Kuldorendszer
{
    partial class Admin
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
            this.btnFelhKarb = new System.Windows.Forms.Button();
            this.btnMerkKarb = new System.Windows.Forms.Button();
            this.lBAdmin = new System.Windows.Forms.ListBox();
            this.btnJvKarb = new System.Windows.Forms.Button();
            this.btnCsapKarb = new System.Windows.Forms.Button();
            this.btnTorol = new System.Windows.Forms.Button();
            this.btnUj = new System.Windows.Forms.Button();
            this.btnModosit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnElerhetKarb = new System.Windows.Forms.Button();
            this.btnOsztKarb = new System.Windows.Forms.Button();
            this.btnTelepKarb = new System.Windows.Forms.Button();
            this.dGridAdmin = new System.Windows.Forms.DataGridView();
            this.textBKeres = new System.Windows.Forms.TextBox();
            this.btnKeres = new System.Windows.Forms.Button();
            this.lblKeresMezo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFelhKarb
            // 
            this.btnFelhKarb.FlatAppearance.BorderSize = 0;
            this.btnFelhKarb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnFelhKarb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFelhKarb.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnFelhKarb.Location = new System.Drawing.Point(24, 16);
            this.btnFelhKarb.Name = "btnFelhKarb";
            this.btnFelhKarb.Size = new System.Drawing.Size(100, 47);
            this.btnFelhKarb.TabIndex = 1;
            this.btnFelhKarb.Text = "Felhasználók karbantartása";
            this.btnFelhKarb.UseVisualStyleBackColor = true;
            this.btnFelhKarb.Click += new System.EventHandler(this.btnFelhKarb_Click);
            // 
            // btnMerkKarb
            // 
            this.btnMerkKarb.FlatAppearance.BorderSize = 0;
            this.btnMerkKarb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnMerkKarb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMerkKarb.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnMerkKarb.Location = new System.Drawing.Point(24, 78);
            this.btnMerkKarb.Name = "btnMerkKarb";
            this.btnMerkKarb.Size = new System.Drawing.Size(100, 47);
            this.btnMerkKarb.TabIndex = 2;
            this.btnMerkKarb.Text = "Mérkőzések karbantartása";
            this.btnMerkKarb.UseVisualStyleBackColor = true;
            this.btnMerkKarb.Click += new System.EventHandler(this.btnMerkKarb_Click);
            // 
            // lBAdmin
            // 
            this.lBAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lBAdmin.FormattingEnabled = true;
            this.lBAdmin.Location = new System.Drawing.Point(399, 16);
            this.lBAdmin.Name = "lBAdmin";
            this.lBAdmin.Size = new System.Drawing.Size(407, 199);
            this.lBAdmin.TabIndex = 13;
            // 
            // btnJvKarb
            // 
            this.btnJvKarb.FlatAppearance.BorderSize = 0;
            this.btnJvKarb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnJvKarb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJvKarb.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnJvKarb.Location = new System.Drawing.Point(24, 142);
            this.btnJvKarb.Name = "btnJvKarb";
            this.btnJvKarb.Size = new System.Drawing.Size(100, 47);
            this.btnJvKarb.TabIndex = 3;
            this.btnJvKarb.Text = "Játékvezetők karbantartása";
            this.btnJvKarb.UseVisualStyleBackColor = true;
            this.btnJvKarb.Click += new System.EventHandler(this.btnJvKarb_Click);
            // 
            // btnCsapKarb
            // 
            this.btnCsapKarb.FlatAppearance.BorderSize = 0;
            this.btnCsapKarb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnCsapKarb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCsapKarb.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCsapKarb.Location = new System.Drawing.Point(24, 207);
            this.btnCsapKarb.Name = "btnCsapKarb";
            this.btnCsapKarb.Size = new System.Drawing.Size(100, 47);
            this.btnCsapKarb.TabIndex = 4;
            this.btnCsapKarb.Text = "Csapatok karbantartása";
            this.btnCsapKarb.UseVisualStyleBackColor = true;
            this.btnCsapKarb.Click += new System.EventHandler(this.btnCsapKarb_Click);
            // 
            // btnTorol
            // 
            this.btnTorol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTorol.Enabled = false;
            this.btnTorol.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnTorol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTorol.Location = new System.Drawing.Point(244, 168);
            this.btnTorol.Name = "btnTorol";
            this.btnTorol.Size = new System.Drawing.Size(100, 47);
            this.btnTorol.TabIndex = 10;
            this.btnTorol.Text = "Töröl";
            this.btnTorol.UseVisualStyleBackColor = true;
            this.btnTorol.Click += new System.EventHandler(this.btnTorol_Click);
            this.btnTorol.MouseLeave += new System.EventHandler(this.btnTorol_MouseLeave);
            this.btnTorol.MouseHover += new System.EventHandler(this.btnTorol_MouseHover);
            // 
            // btnUj
            // 
            this.btnUj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUj.Enabled = false;
            this.btnUj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnUj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUj.Location = new System.Drawing.Point(244, 16);
            this.btnUj.Name = "btnUj";
            this.btnUj.Size = new System.Drawing.Size(100, 47);
            this.btnUj.TabIndex = 8;
            this.btnUj.Text = "Új adat";
            this.btnUj.UseVisualStyleBackColor = true;
            this.btnUj.Click += new System.EventHandler(this.btnUj_Click);
            this.btnUj.MouseLeave += new System.EventHandler(this.btnUj_MouseLeave);
            this.btnUj.MouseHover += new System.EventHandler(this.btnUj_MouseHover);
            // 
            // btnModosit
            // 
            this.btnModosit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModosit.Enabled = false;
            this.btnModosit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnModosit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModosit.Location = new System.Drawing.Point(244, 94);
            this.btnModosit.Name = "btnModosit";
            this.btnModosit.Size = new System.Drawing.Size(100, 47);
            this.btnModosit.TabIndex = 9;
            this.btnModosit.Text = "Módosít";
            this.btnModosit.UseVisualStyleBackColor = true;
            this.btnModosit.Click += new System.EventHandler(this.btnModosit_Click);
            this.btnModosit.MouseLeave += new System.EventHandler(this.btnModosit_MouseLeave);
            this.btnModosit.MouseHover += new System.EventHandler(this.btnModosit_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnElerhetKarb);
            this.panel1.Controls.Add(this.btnOsztKarb);
            this.panel1.Controls.Add(this.btnTelepKarb);
            this.panel1.Controls.Add(this.btnMerkKarb);
            this.panel1.Controls.Add(this.btnFelhKarb);
            this.panel1.Controls.Add(this.btnJvKarb);
            this.panel1.Controls.Add(this.btnCsapKarb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 479);
            this.panel1.TabIndex = 56;
            // 
            // btnElerhetKarb
            // 
            this.btnElerhetKarb.FlatAppearance.BorderSize = 0;
            this.btnElerhetKarb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnElerhetKarb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElerhetKarb.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnElerhetKarb.Location = new System.Drawing.Point(24, 420);
            this.btnElerhetKarb.Name = "btnElerhetKarb";
            this.btnElerhetKarb.Size = new System.Drawing.Size(100, 47);
            this.btnElerhetKarb.TabIndex = 7;
            this.btnElerhetKarb.Text = "Elérhetőségek karbantartása";
            this.btnElerhetKarb.UseVisualStyleBackColor = true;
            this.btnElerhetKarb.Click += new System.EventHandler(this.btnElerhetKarb_Click);
            // 
            // btnOsztKarb
            // 
            this.btnOsztKarb.FlatAppearance.BorderSize = 0;
            this.btnOsztKarb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnOsztKarb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOsztKarb.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnOsztKarb.Location = new System.Drawing.Point(24, 347);
            this.btnOsztKarb.Name = "btnOsztKarb";
            this.btnOsztKarb.Size = new System.Drawing.Size(100, 47);
            this.btnOsztKarb.TabIndex = 6;
            this.btnOsztKarb.Text = "Osztályok karbantartása";
            this.btnOsztKarb.UseVisualStyleBackColor = true;
            this.btnOsztKarb.Click += new System.EventHandler(this.btnOsztKarb_Click);
            // 
            // btnTelepKarb
            // 
            this.btnTelepKarb.FlatAppearance.BorderSize = 0;
            this.btnTelepKarb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnTelepKarb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTelepKarb.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnTelepKarb.Location = new System.Drawing.Point(24, 277);
            this.btnTelepKarb.Name = "btnTelepKarb";
            this.btnTelepKarb.Size = new System.Drawing.Size(100, 47);
            this.btnTelepKarb.TabIndex = 5;
            this.btnTelepKarb.Text = "Települések karbantartása";
            this.btnTelepKarb.UseVisualStyleBackColor = true;
            this.btnTelepKarb.Click += new System.EventHandler(this.btnTelepKarb_Click);
            // 
            // dGridAdmin
            // 
            this.dGridAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGridAdmin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGridAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridAdmin.Location = new System.Drawing.Point(223, 277);
            this.dGridAdmin.Name = "dGridAdmin";
            this.dGridAdmin.ReadOnly = true;
            this.dGridAdmin.Size = new System.Drawing.Size(583, 190);
            this.dGridAdmin.TabIndex = 14;
            this.dGridAdmin.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridAdmin_CellClick);
            this.dGridAdmin.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridAdmin_CellEndEdit);
            this.dGridAdmin.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridAdmin_CellLeave);
            // 
            // textBKeres
            // 
            this.textBKeres.Location = new System.Drawing.Point(399, 234);
            this.textBKeres.Name = "textBKeres";
            this.textBKeres.Size = new System.Drawing.Size(407, 20);
            this.textBKeres.TabIndex = 12;
            this.textBKeres.TextChanged += new System.EventHandler(this.textBKeres_TextChanged);
            // 
            // btnKeres
            // 
            this.btnKeres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKeres.Enabled = false;
            this.btnKeres.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnKeres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeres.Location = new System.Drawing.Point(244, 232);
            this.btnKeres.Name = "btnKeres";
            this.btnKeres.Size = new System.Drawing.Size(100, 23);
            this.btnKeres.TabIndex = 11;
            this.btnKeres.Text = "Keres";
            this.btnKeres.UseVisualStyleBackColor = true;
            this.btnKeres.Click += new System.EventHandler(this.btnKeres_Click);
            this.btnKeres.MouseLeave += new System.EventHandler(this.btnKeres_MouseLeave);
            this.btnKeres.MouseHover += new System.EventHandler(this.btnKeres_MouseHover);
            // 
            // lblKeresMezo
            // 
            this.lblKeresMezo.AutoSize = true;
            this.lblKeresMezo.Location = new System.Drawing.Point(241, 261);
            this.lblKeresMezo.Name = "lblKeresMezo";
            this.lblKeresMezo.Size = new System.Drawing.Size(99, 13);
            this.lblKeresMezo.TabIndex = 53;
            this.lblKeresMezo.Text = "Keresési feltétel(ek)";
            this.lblKeresMezo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(819, 479);
            this.Controls.Add(this.lblKeresMezo);
            this.Controls.Add(this.btnKeres);
            this.Controls.Add(this.textBKeres);
            this.Controls.Add(this.dGridAdmin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnModosit);
            this.Controls.Add(this.btnUj);
            this.Controls.Add(this.btnTorol);
            this.Controls.Add(this.lBAdmin);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimumSize = new System.Drawing.Size(835, 515);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridAdmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFelhKarb;
        private System.Windows.Forms.Button btnMerkKarb;
        private System.Windows.Forms.ListBox lBAdmin;
        private System.Windows.Forms.Button btnJvKarb;
        private System.Windows.Forms.Button btnCsapKarb;
        private System.Windows.Forms.Button btnTorol;
        private System.Windows.Forms.Button btnUj;
        private System.Windows.Forms.Button btnModosit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dGridAdmin;
        private System.Windows.Forms.TextBox textBKeres;
        private System.Windows.Forms.Button btnKeres;
        private System.Windows.Forms.Label lblKeresMezo;
        private System.Windows.Forms.Button btnOsztKarb;
        private System.Windows.Forms.Button btnTelepKarb;
        private System.Windows.Forms.Button btnElerhetKarb;
    }
}