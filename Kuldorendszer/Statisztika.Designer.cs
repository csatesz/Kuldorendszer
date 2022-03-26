
namespace Kuldorendszer
{
    partial class Statisztika
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
            this.lBStat = new System.Windows.Forms.ListBox();
            this.cBoxJv = new System.Windows.Forms.ComboBox();
            this.cBoxOsztaly = new System.Windows.Forms.ComboBox();
            this.dTPTol = new System.Windows.Forms.DateTimePicker();
            this.dTPIg = new System.Windows.Forms.DateTimePicker();
            this.lblJv = new System.Windows.Forms.Label();
            this.lblOsztaly = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.btnStat = new System.Windows.Forms.Button();
            this.btnBezar = new System.Windows.Forms.Button();
            this.chkBDate = new System.Windows.Forms.CheckBox();
            this.chkBOsztaly = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lBStat
            // 
            this.lBStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lBStat.FormattingEnabled = true;
            this.lBStat.ItemHeight = 16;
            this.lBStat.Location = new System.Drawing.Point(408, 12);
            this.lBStat.Name = "lBStat";
            this.lBStat.Size = new System.Drawing.Size(243, 372);
            this.lBStat.TabIndex = 0;
            // 
            // cBoxJv
            // 
            this.cBoxJv.FormattingEnabled = true;
            this.cBoxJv.Location = new System.Drawing.Point(190, 28);
            this.cBoxJv.Name = "cBoxJv";
            this.cBoxJv.Size = new System.Drawing.Size(168, 21);
            this.cBoxJv.Sorted = true;
            this.cBoxJv.TabIndex = 2;
            this.cBoxJv.SelectedIndexChanged += new System.EventHandler(this.cBoxJv_SelectedIndexChanged);
            // 
            // cBoxOsztaly
            // 
            this.cBoxOsztaly.Enabled = false;
            this.cBoxOsztaly.FormattingEnabled = true;
            this.cBoxOsztaly.Location = new System.Drawing.Point(190, 68);
            this.cBoxOsztaly.Name = "cBoxOsztaly";
            this.cBoxOsztaly.Size = new System.Drawing.Size(168, 21);
            this.cBoxOsztaly.Sorted = true;
            this.cBoxOsztaly.TabIndex = 3;
            this.cBoxOsztaly.SelectedIndexChanged += new System.EventHandler(this.cBoxOsztaly_SelectedIndexChanged);
            // 
            // dTPTol
            // 
            this.dTPTol.CustomFormat = "yyyy-MM-dd HH-mm";
            this.dTPTol.Enabled = false;
            this.dTPTol.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPTol.Location = new System.Drawing.Point(190, 109);
            this.dTPTol.Name = "dTPTol";
            this.dTPTol.Size = new System.Drawing.Size(168, 20);
            this.dTPTol.TabIndex = 4;
            // 
            // dTPIg
            // 
            this.dTPIg.CustomFormat = "yyyy-MM-dd HH-mm";
            this.dTPIg.Enabled = false;
            this.dTPIg.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPIg.Location = new System.Drawing.Point(190, 148);
            this.dTPIg.Name = "dTPIg";
            this.dTPIg.Size = new System.Drawing.Size(168, 20);
            this.dTPIg.TabIndex = 5;
            // 
            // lblJv
            // 
            this.lblJv.Location = new System.Drawing.Point(30, 28);
            this.lblJv.Name = "lblJv";
            this.lblJv.Size = new System.Drawing.Size(117, 20);
            this.lblJv.TabIndex = 0;
            this.lblJv.Text = "Játékvezető neve:";
            // 
            // lblOsztaly
            // 
            this.lblOsztaly.Location = new System.Drawing.Point(30, 68);
            this.lblOsztaly.Name = "lblOsztaly";
            this.lblOsztaly.Size = new System.Drawing.Size(117, 20);
            this.lblOsztaly.TabIndex = 0;
            this.lblOsztaly.Text = "Osztály megnevezés:";
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(30, 109);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(117, 20);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Mikortól:";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(30, 148);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(108, 20);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "Meddig:";
            // 
            // btnStat
            // 
            this.btnStat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStat.Location = new System.Drawing.Point(33, 310);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(95, 40);
            this.btnStat.TabIndex = 7;
            this.btnStat.Text = "Statisztika készítése";
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // btnBezar
            // 
            this.btnBezar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBezar.Location = new System.Drawing.Point(263, 310);
            this.btnBezar.Name = "btnBezar";
            this.btnBezar.Size = new System.Drawing.Size(95, 40);
            this.btnBezar.TabIndex = 8;
            this.btnBezar.Text = "Bezár";
            this.btnBezar.UseVisualStyleBackColor = true;
            this.btnBezar.Click += new System.EventHandler(this.btnBezar_Click);
            // 
            // chkBDate
            // 
            this.chkBDate.AutoSize = true;
            this.chkBDate.Location = new System.Drawing.Point(157, 132);
            this.chkBDate.Name = "chkBDate";
            this.chkBDate.Size = new System.Drawing.Size(15, 14);
            this.chkBDate.TabIndex = 9;
            this.chkBDate.UseVisualStyleBackColor = true;
            this.chkBDate.CheckedChanged += new System.EventHandler(this.chkBDate_CheckedChanged);
            // 
            // chkBOsztaly
            // 
            this.chkBOsztaly.AutoSize = true;
            this.chkBOsztaly.Location = new System.Drawing.Point(157, 72);
            this.chkBOsztaly.Name = "chkBOsztaly";
            this.chkBOsztaly.Size = new System.Drawing.Size(15, 14);
            this.chkBOsztaly.TabIndex = 11;
            this.chkBOsztaly.UseVisualStyleBackColor = true;
            this.chkBOsztaly.CheckedChanged += new System.EventHandler(this.chkBOsztaly_CheckedChanged);
            // 
            // Statisztika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(663, 401);
            this.Controls.Add(this.chkBOsztaly);
            this.Controls.Add(this.chkBDate);
            this.Controls.Add(this.btnBezar);
            this.Controls.Add(this.btnStat);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblOsztaly);
            this.Controls.Add(this.lblJv);
            this.Controls.Add(this.dTPIg);
            this.Controls.Add(this.dTPTol);
            this.Controls.Add(this.cBoxOsztaly);
            this.Controls.Add(this.cBoxJv);
            this.Controls.Add(this.lBStat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Statisztika";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statisztika";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lBStat;
        private System.Windows.Forms.ComboBox cBoxJv;
        private System.Windows.Forms.ComboBox cBoxOsztaly;
        private System.Windows.Forms.DateTimePicker dTPTol;
        private System.Windows.Forms.DateTimePicker dTPIg;
        private System.Windows.Forms.Label lblJv;
        private System.Windows.Forms.Label lblOsztaly;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnStat;
        private System.Windows.Forms.Button btnBezar;
        private System.Windows.Forms.CheckBox chkBDate;
        private System.Windows.Forms.CheckBox chkBOsztaly;
    }
}