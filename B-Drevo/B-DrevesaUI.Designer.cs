namespace BDrevesa {
    partial class BDrevesaUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tblGlavno = new System.Windows.Forms.TableLayoutPanel();
            this.tblZgoraj = new System.Windows.Forms.TableLayoutPanel();
            this.tblStopnjaDodaj = new System.Windows.Forms.TableLayoutPanel();
            this.lblStopnja = new System.Windows.Forms.Label();
            this.nudStopnja = new System.Windows.Forms.NumericUpDown();
            this.lblDodaj = new System.Windows.Forms.Label();
            this.tbDodaj = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNalozi = new System.Windows.Forms.Button();
            this.btnSpremeni = new System.Windows.Forms.Button();
            this.pbDrevo = new System.Windows.Forms.PictureBox();
            this.tblGlavno.SuspendLayout();
            this.tblZgoraj.SuspendLayout();
            this.tblStopnjaDodaj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopnja)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrevo)).BeginInit();
            this.SuspendLayout();
            // 
            // tblGlavno
            // 
            this.tblGlavno.ColumnCount = 1;
            this.tblGlavno.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblGlavno.Controls.Add(this.tblZgoraj, 0, 0);
            this.tblGlavno.Controls.Add(this.pbDrevo, 0, 1);
            this.tblGlavno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblGlavno.Location = new System.Drawing.Point(0, 0);
            this.tblGlavno.Name = "tblGlavno";
            this.tblGlavno.RowCount = 2;
            this.tblGlavno.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblGlavno.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblGlavno.Size = new System.Drawing.Size(736, 641);
            this.tblGlavno.TabIndex = 0;
            // 
            // tblZgoraj
            // 
            this.tblZgoraj.ColumnCount = 2;
            this.tblZgoraj.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblZgoraj.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblZgoraj.Controls.Add(this.tblStopnjaDodaj, 0, 0);
            this.tblZgoraj.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tblZgoraj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblZgoraj.Location = new System.Drawing.Point(3, 3);
            this.tblZgoraj.Name = "tblZgoraj";
            this.tblZgoraj.RowCount = 1;
            this.tblZgoraj.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblZgoraj.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblZgoraj.Size = new System.Drawing.Size(730, 44);
            this.tblZgoraj.TabIndex = 0;
            // 
            // tblStopnjaDodaj
            // 
            this.tblStopnjaDodaj.ColumnCount = 2;
            this.tblStopnjaDodaj.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStopnjaDodaj.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStopnjaDodaj.Controls.Add(this.lblStopnja, 0, 0);
            this.tblStopnjaDodaj.Controls.Add(this.nudStopnja, 0, 1);
            this.tblStopnjaDodaj.Controls.Add(this.lblDodaj, 1, 0);
            this.tblStopnjaDodaj.Controls.Add(this.tbDodaj, 1, 1);
            this.tblStopnjaDodaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblStopnjaDodaj.Location = new System.Drawing.Point(3, 3);
            this.tblStopnjaDodaj.Name = "tblStopnjaDodaj";
            this.tblStopnjaDodaj.RowCount = 2;
            this.tblStopnjaDodaj.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStopnjaDodaj.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStopnjaDodaj.Size = new System.Drawing.Size(359, 38);
            this.tblStopnjaDodaj.TabIndex = 1;
            // 
            // lblStopnja
            // 
            this.lblStopnja.AutoSize = true;
            this.lblStopnja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStopnja.Location = new System.Drawing.Point(0, 0);
            this.lblStopnja.Margin = new System.Windows.Forms.Padding(0);
            this.lblStopnja.Name = "lblStopnja";
            this.lblStopnja.Size = new System.Drawing.Size(179, 19);
            this.lblStopnja.TabIndex = 0;
            this.lblStopnja.Text = "Minimalna stopnja:";
            // 
            // nudStopnja
            // 
            this.nudStopnja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudStopnja.Location = new System.Drawing.Point(0, 19);
            this.nudStopnja.Margin = new System.Windows.Forms.Padding(0);
            this.nudStopnja.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudStopnja.Name = "nudStopnja";
            this.nudStopnja.Size = new System.Drawing.Size(179, 20);
            this.nudStopnja.TabIndex = 1;
            this.nudStopnja.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblDodaj
            // 
            this.lblDodaj.AutoSize = true;
            this.lblDodaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDodaj.Location = new System.Drawing.Point(179, 0);
            this.lblDodaj.Margin = new System.Windows.Forms.Padding(0);
            this.lblDodaj.Name = "lblDodaj";
            this.lblDodaj.Size = new System.Drawing.Size(180, 19);
            this.lblDodaj.TabIndex = 2;
            this.lblDodaj.Text = "Dodaj:";
            // 
            // tbDodaj
            // 
            this.tbDodaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDodaj.Location = new System.Drawing.Point(179, 19);
            this.tbDodaj.Margin = new System.Windows.Forms.Padding(0);
            this.tbDodaj.Name = "tbDodaj";
            this.tbDodaj.Size = new System.Drawing.Size(180, 20);
            this.tbDodaj.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnNalozi, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSpremeni, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(368, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(359, 38);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnNalozi
            // 
            this.btnNalozi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNalozi.Location = new System.Drawing.Point(179, 0);
            this.btnNalozi.Margin = new System.Windows.Forms.Padding(0);
            this.btnNalozi.Name = "btnNalozi";
            this.btnNalozi.Size = new System.Drawing.Size(180, 38);
            this.btnNalozi.TabIndex = 1;
            this.btnNalozi.Text = "Naloži iz datoteke";
            this.btnNalozi.UseVisualStyleBackColor = true;
            this.btnNalozi.Click += new System.EventHandler(this.BtnNaloziClick);
            // 
            // btnSpremeni
            // 
            this.btnSpremeni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSpremeni.Location = new System.Drawing.Point(0, 0);
            this.btnSpremeni.Margin = new System.Windows.Forms.Padding(0);
            this.btnSpremeni.Name = "btnSpremeni";
            this.btnSpremeni.Size = new System.Drawing.Size(179, 38);
            this.btnSpremeni.TabIndex = 0;
            this.btnSpremeni.Text = "Dodaj ali spremeni stopnjo";
            this.btnSpremeni.UseVisualStyleBackColor = true;
            this.btnSpremeni.Click += new System.EventHandler(this.BtnSpremeniClick);
            // 
            // pbDrevo
            // 
            this.pbDrevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDrevo.Location = new System.Drawing.Point(3, 53);
            this.pbDrevo.Name = "pbDrevo";
            this.pbDrevo.Size = new System.Drawing.Size(730, 585);
            this.pbDrevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDrevo.TabIndex = 1;
            this.pbDrevo.TabStop = false;
            // 
            // BDrevesaUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 641);
            this.Controls.Add(this.tblGlavno);
            this.Name = "BDrevesaUI";
            this.Text = "B-Drevesa (IA 6)";
            this.tblGlavno.ResumeLayout(false);
            this.tblZgoraj.ResumeLayout(false);
            this.tblStopnjaDodaj.ResumeLayout(false);
            this.tblStopnjaDodaj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopnja)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDrevo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblGlavno;
        private System.Windows.Forms.TableLayoutPanel tblZgoraj;
        private System.Windows.Forms.TableLayoutPanel tblStopnjaDodaj;
        private System.Windows.Forms.Label lblStopnja;
        private System.Windows.Forms.NumericUpDown nudStopnja;
        private System.Windows.Forms.Label lblDodaj;
        private System.Windows.Forms.TextBox tbDodaj;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnNalozi;
        private System.Windows.Forms.Button btnSpremeni;
        private System.Windows.Forms.PictureBox pbDrevo;
    }
}