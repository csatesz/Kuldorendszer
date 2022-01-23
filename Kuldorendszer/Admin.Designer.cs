
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
            this.components = new System.ComponentModel.Container();
            this.btnFelhKarb = new System.Windows.Forms.Button();
            this.btnMerkKarb = new System.Windows.Forms.Button();
            this.lBAdmin = new System.Windows.Forms.ListBox();
            this.btnJvKarb = new System.Windows.Forms.Button();
            this.btnCsapKarb = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.kuldesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kuldesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kuldesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kuldesBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFelhKarb
            // 
            this.btnFelhKarb.FlatAppearance.BorderSize = 0;
            this.btnFelhKarb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnFelhKarb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFelhKarb.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnFelhKarb.Location = new System.Drawing.Point(24, 36);
            this.btnFelhKarb.Name = "btnFelhKarb";
            this.btnFelhKarb.Size = new System.Drawing.Size(100, 47);
            this.btnFelhKarb.TabIndex = 48;
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
            this.btnMerkKarb.Location = new System.Drawing.Point(24, 131);
            this.btnMerkKarb.Name = "btnMerkKarb";
            this.btnMerkKarb.Size = new System.Drawing.Size(100, 47);
            this.btnMerkKarb.TabIndex = 49;
            this.btnMerkKarb.Text = "Mérkőzések karbantartása";
            this.btnMerkKarb.UseVisualStyleBackColor = true;
            this.btnMerkKarb.Click += new System.EventHandler(this.btnMerkKarb_Click);
            // 
            // lBAdmin
            // 
            this.lBAdmin.FormattingEnabled = true;
            this.lBAdmin.Location = new System.Drawing.Point(399, 16);
            this.lBAdmin.Name = "lBAdmin";
            this.lBAdmin.Size = new System.Drawing.Size(389, 420);
            this.lBAdmin.TabIndex = 50;
            // 
            // btnJvKarb
            // 
            this.btnJvKarb.FlatAppearance.BorderSize = 0;
            this.btnJvKarb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnJvKarb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJvKarb.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnJvKarb.Location = new System.Drawing.Point(24, 234);
            this.btnJvKarb.Name = "btnJvKarb";
            this.btnJvKarb.Size = new System.Drawing.Size(100, 47);
            this.btnJvKarb.TabIndex = 51;
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
            this.btnCsapKarb.Location = new System.Drawing.Point(24, 342);
            this.btnCsapKarb.Name = "btnCsapKarb";
            this.btnCsapKarb.Size = new System.Drawing.Size(100, 47);
            this.btnCsapKarb.TabIndex = 52;
            this.btnCsapKarb.Text = "Csapatok karbantartása";
            this.btnCsapKarb.UseVisualStyleBackColor = true;
            this.btnCsapKarb.Click += new System.EventHandler(this.btnCsapKarb_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(244, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 47);
            this.button1.TabIndex = 53;
            this.button1.Text = "Töröl";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(244, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 47);
            this.button2.TabIndex = 54;
            this.button2.Text = "Új adat";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(244, 92);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 47);
            this.button3.TabIndex = 55;
            this.button3.Text = "Módosít";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnMerkKarb);
            this.panel1.Controls.Add(this.btnFelhKarb);
            this.panel1.Controls.Add(this.btnJvKarb);
            this.panel1.Controls.Add(this.btnCsapKarb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 450);
            this.panel1.TabIndex = 56;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(235, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(498, 121);
            this.dataGridView1.TabIndex = 57;
            // 
            // kuldesBindingSource
            // 
            this.kuldesBindingSource.DataSource = typeof(Kuldorendszer.Kuldes);
            // 
            // kuldesBindingSource1
            // 
            this.kuldesBindingSource1.DataSource = typeof(Kuldorendszer.Kuldes);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lBAdmin);
            this.Name = "Admin";
            this.Text = "Admin";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kuldesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kuldesBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFelhKarb;
        private System.Windows.Forms.Button btnMerkKarb;
        private System.Windows.Forms.ListBox lBAdmin;
        private System.Windows.Forms.Button btnJvKarb;
        private System.Windows.Forms.Button btnCsapKarb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource kuldesBindingSource;
        private System.Windows.Forms.BindingSource kuldesBindingSource1;
    }
}