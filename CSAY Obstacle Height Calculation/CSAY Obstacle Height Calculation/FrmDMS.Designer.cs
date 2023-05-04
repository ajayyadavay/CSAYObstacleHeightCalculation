namespace CSAY_Obstacle_Height_Calculation
{
    partial class FrmDMS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMinute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSecond = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnCalculate = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.ChkSendDMS = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtLatitude = new System.Windows.Forms.TextBox();
            this.TxtLongitude = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDes,
            this.ColDegree,
            this.ColMinute,
            this.ColSecond});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(456, 156);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColDes
            // 
            this.ColDes.HeaderText = "Description";
            this.ColDes.Name = "ColDes";
            // 
            // ColDegree
            // 
            this.ColDegree.HeaderText = "Degree";
            this.ColDegree.Name = "ColDegree";
            // 
            // ColMinute
            // 
            this.ColMinute.HeaderText = "Minute";
            this.ColMinute.Name = "ColMinute";
            // 
            // ColSecond
            // 
            this.ColSecond.HeaderText = "Second";
            this.ColSecond.Name = "ColSecond";
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnExit.FlatAppearance.BorderSize = 0;
            this.BtnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.White;
            this.BtnExit.Location = new System.Drawing.Point(342, 358);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(126, 42);
            this.BtnExit.TabIndex = 17;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnCalculate
            // 
            this.BtnCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnCalculate.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnCalculate.FlatAppearance.BorderSize = 0;
            this.BtnCalculate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnCalculate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCalculate.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCalculate.ForeColor = System.Drawing.Color.White;
            this.BtnCalculate.Location = new System.Drawing.Point(175, 358);
            this.BtnCalculate.Name = "BtnCalculate";
            this.BtnCalculate.Size = new System.Drawing.Size(141, 42);
            this.BtnCalculate.TabIndex = 18;
            this.BtnCalculate.Text = "Calculate";
            this.BtnCalculate.UseVisualStyleBackColor = false;
            this.BtnCalculate.Click += new System.EventHandler(this.BtnCalculate_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnNew.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnNew.FlatAppearance.BorderSize = 0;
            this.BtnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNew.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.ForeColor = System.Drawing.Color.White;
            this.BtnNew.Location = new System.Drawing.Point(23, 358);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(127, 42);
            this.BtnNew.TabIndex = 19;
            this.BtnNew.Text = "New";
            this.BtnNew.UseVisualStyleBackColor = false;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // ChkSendDMS
            // 
            this.ChkSendDMS.AutoSize = true;
            this.ChkSendDMS.Checked = true;
            this.ChkSendDMS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkSendDMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkSendDMS.Location = new System.Drawing.Point(23, 325);
            this.ChkSendDMS.Name = "ChkSendDMS";
            this.ChkSendDMS.Size = new System.Drawing.Size(203, 24);
            this.ChkSendDMS.TabIndex = 20;
            this.ChkSendDMS.Text = "Send DMS to Main Form";
            this.ChkSendDMS.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Latitude (DD)";
            // 
            // TxtLatitude
            // 
            this.TxtLatitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLatitude.Location = new System.Drawing.Point(159, 238);
            this.TxtLatitude.Name = "TxtLatitude";
            this.TxtLatitude.Size = new System.Drawing.Size(309, 26);
            this.TxtLatitude.TabIndex = 22;
            // 
            // TxtLongitude
            // 
            this.TxtLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLongitude.Location = new System.Drawing.Point(159, 281);
            this.TxtLongitude.Name = "TxtLongitude";
            this.TxtLongitude.Size = new System.Drawing.Size(309, 26);
            this.TxtLongitude.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Longitude (DD)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(155, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 24);
            this.label3.TabIndex = 25;
            this.label3.Text = "DMS to DD converter";
            // 
            // FrmDMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(488, 419);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtLongitude);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtLatitude);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChkSendDMS);
            this.Controls.Add(this.BtnNew);
            this.Controls.Add(this.BtnCalculate);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "FrmDMS";
            this.Text = "FrmDMS";
            this.Load += new System.EventHandler(this.FrmDMS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDegree;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMinute;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSecond;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnCalculate;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.CheckBox ChkSendDMS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox TxtLatitude;
        public System.Windows.Forms.TextBox TxtLongitude;
    }
}