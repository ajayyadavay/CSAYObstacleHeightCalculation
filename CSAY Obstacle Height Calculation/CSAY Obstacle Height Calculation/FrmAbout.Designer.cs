namespace CSAY_Obstacle_Height_Calculation
{
    partial class FrmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtInstructionToUse = new System.Windows.Forms.TextBox();
            this.BtnExit = new System.Windows.Forms.Button();
            this.TxtAbout = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtInstructionToUse);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 301);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instruction to Use";
            // 
            // TxtInstructionToUse
            // 
            this.TxtInstructionToUse.Location = new System.Drawing.Point(6, 33);
            this.TxtInstructionToUse.Multiline = true;
            this.TxtInstructionToUse.Name = "TxtInstructionToUse";
            this.TxtInstructionToUse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtInstructionToUse.Size = new System.Drawing.Size(544, 250);
            this.TxtInstructionToUse.TabIndex = 0;
            this.TxtInstructionToUse.Text = resources.GetString("TxtInstructionToUse.Text");
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnExit.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnExit.FlatAppearance.BorderSize = 0;
            this.BtnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.White;
            this.BtnExit.Location = new System.Drawing.Point(618, 282);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(327, 42);
            this.BtnExit.TabIndex = 21;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // TxtAbout
            // 
            this.TxtAbout.BackColor = System.Drawing.Color.Thistle;
            this.TxtAbout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAbout.Location = new System.Drawing.Point(618, 170);
            this.TxtAbout.Multiline = true;
            this.TxtAbout.Name = "TxtAbout";
            this.TxtAbout.Size = new System.Drawing.Size(327, 84);
            this.TxtAbout.TabIndex = 22;
            this.TxtAbout.Text = "Obstacle Height Calculation Ver 2023.1\r\nCreated by Ajay Yadav\r\nGithub: github.com" +
    "/ajayyadavay\r\nE-mail: civil.ajayyadav@gmail.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(615, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 112);
            this.label1.TabIndex = 23;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(977, 344);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtAbout);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAbout";
            this.Text = "About";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtInstructionToUse;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.TextBox TxtAbout;
        private System.Windows.Forms.Label label1;
    }
}