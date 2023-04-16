namespace CSAY_Obstacle_Height_Calculation
{
    partial class FrmObstacleHeightCalculation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObstacleHeightCalculation));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabLoadAllRecord = new System.Windows.Forms.TabPage();
            this.BtnExportRecordToExcel = new System.Windows.Forms.Button();
            this.LblRecordNo = new System.Windows.Forms.Label();
            this.LblLoad = new System.Windows.Forms.Label();
            this.BtnLoadAllRecord = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.TabRWYEq = new System.Windows.Forms.TabPage();
            this.TxtRWYClassify = new System.Windows.Forms.TextBox();
            this.BtnZoomToFit2 = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gMapControl2 = new GMap.NET.WindowsForms.GMapControl();
            this.BtnLoadRWYCoord = new System.Windows.Forms.Button();
            this.ComboBoxRWY = new System.Windows.Forms.ComboBox();
            this.TxtAirportCode = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ColLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSlope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIntercept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportLineParameterToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLatitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLongitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEasting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNorthing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportRWYCOORDToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label19 = new System.Windows.Forms.Label();
            this.TabObstacleHeightCalculation = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.ChkBoxOuterHorizontal = new System.Windows.Forms.CheckBox();
            this.ChkBoxInnerTrans = new System.Windows.Forms.CheckBox();
            this.ChkBoxInnerApproach = new System.Windows.Forms.CheckBox();
            this.BtnDeselectAll = new System.Windows.Forms.Button();
            this.BtnSelectAll = new System.Windows.Forms.Button();
            this.ChkBoxBalkedlanding = new System.Windows.Forms.CheckBox();
            this.ChkBoxTransition = new System.Windows.Forms.CheckBox();
            this.ChkBoxTakeoffclimb = new System.Windows.Forms.CheckBox();
            this.ChkBoxApproach = new System.Windows.Forms.CheckBox();
            this.ChkBoxConical = new System.Windows.Forms.CheckBox();
            this.ChkBoxHorizontal = new System.Windows.Forms.CheckBox();
            this.BtnZoomToFit = new System.Windows.Forms.Button();
            this.ChkBoxAutoFitMap = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.TxtPlotCase = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.BtnExportToKML = new System.Windows.Forms.Button();
            this.TxtArealDistance = new System.Windows.Forms.TextBox();
            this.BtnSaveMap = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtLong2 = new System.Windows.Forms.TextBox();
            this.TxtLat2 = new System.Windows.Forms.TextBox();
            this.BtnCreateMap = new System.Windows.Forms.Button();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.TxtElev_Permitted = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.TxtElev_Obstacle = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TxtHeightAbovePlinth = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.TxtRL_Plinth = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ComboBoxLocalLevel = new System.Windows.Forms.ComboBox();
            this.TxtTole = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtWardNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtLocalLevel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtPlotNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ComboBoxObstacleType = new System.Windows.Forms.ComboBox();
            this.ComboBoxFY = new System.Windows.Forms.ComboBox();
            this.TxtObstacleType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtFY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComboBoxDesignation = new System.Windows.Forms.ComboBox();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.TxtDesignation = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtMiddleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtLong1 = new System.Windows.Forms.TextBox();
            this.TxtLat1 = new System.Windows.Forms.TextBox();
            this.TabLetter = new System.Windows.Forms.TabPage();
            this.BtnCreateNepaliTippani = new System.Windows.Forms.Button();
            this.TxtNepaliLocalLevel = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.TxtNepaliWardNo = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.TxtNepaliElevation = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.TxtNepaliPlotNo = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.BtnCreateNepaliLetter = new System.Windows.Forms.Button();
            this.TxtPrevLetterRefNepali = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.TxtPrevLetterNepaliDate = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.TxtLetterNepaliDate = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.BtnPreviewLetter = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.TxtTitleOfReport = new System.Windows.Forms.TextBox();
            this.lable36 = new System.Windows.Forms.Label();
            this.TxtOtherInfo = new System.Windows.Forms.TextBox();
            this.TxtPreviousLetterDate = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.TxtPrevLetterRef = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.TxtLetterSignedby = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.TxtLetterCC = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtLetterSubject = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.TxtLetterTo = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.TxtLetterDate = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.TabLetterPreview = new System.Windows.Forms.TabPage();
            this.BtnToWord = new System.Windows.Forms.Button();
            this.RichTxtLetters = new System.Windows.Forms.RichTextBox();
            this.TxtDocumentRequired = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.TabCalculationDetail = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.TxtCM = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.TxtElev_allow = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TxtSurfaceHeightaboveRWY = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtSurfaceName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TxtRL_RWY = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.ColCalcSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCalcSurfaceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCalcSurfaceHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCalcRL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCalculation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtCalculationDetail = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.TabRWYClassify = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.TabMenu = new System.Windows.Forms.TabPage();
            this.BtnOpenFolder = new System.Windows.Forms.Button();
            this.BtnAutoProcess = new System.Windows.Forms.Button();
            this.BtnDisplay = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.RadModify_del_display = new System.Windows.Forms.RadioButton();
            this.RadAdd = new System.Windows.Forms.RadioButton();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnModify = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnCalculate = new System.Windows.Forms.Button();
            this.BtnExportToPDF = new System.Windows.Forms.Button();
            this.TabFilter = new System.Windows.Forms.TabPage();
            this.RichTxtFilter = new System.Windows.Forms.RichTextBox();
            this.BtnGreaterThan = new System.Windows.Forms.Button();
            this.BtnLessThan = new System.Windows.Forms.Button();
            this.BtnEqualTo = new System.Windows.Forms.Button();
            this.BtnFilter = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnOR = new System.Windows.Forms.Button();
            this.BtnAnd = new System.Windows.Forms.Button();
            this.ComboBoxDistinctVal1 = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.ComboBoxFilterBy1 = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.TxtLog = new System.Windows.Forms.TextBox();
            this.TxtRecentFolderLocation = new System.Windows.Forms.TextBox();
            this.PanelBack = new System.Windows.Forms.Panel();
            this.PanelFore = new System.Windows.Forms.Panel();
            this.LblProgress = new System.Windows.Forms.Label();
            this.ColSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSurface = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDimension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.TabLoadAllRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.TabRWYEq.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.TabObstacleHeightCalculation.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.TabGeneral.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.TabLetter.SuspendLayout();
            this.TabLetterPreview.SuspendLayout();
            this.TabCalculationDetail.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.TabRWYClassify.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.TabMenu.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.TabFilter.SuspendLayout();
            this.PanelBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.TabLoadAllRecord);
            this.tabControl1.Controls.Add(this.TabRWYEq);
            this.tabControl1.Controls.Add(this.TabObstacleHeightCalculation);
            this.tabControl1.Controls.Add(this.TabGeneral);
            this.tabControl1.Controls.Add(this.TabLetter);
            this.tabControl1.Controls.Add(this.TabLetterPreview);
            this.tabControl1.Controls.Add(this.TabCalculationDetail);
            this.tabControl1.Controls.Add(this.TabRWYClassify);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1346, 470);
            this.tabControl1.TabIndex = 0;
            // 
            // TabLoadAllRecord
            // 
            this.TabLoadAllRecord.Controls.Add(this.BtnExportRecordToExcel);
            this.TabLoadAllRecord.Controls.Add(this.LblRecordNo);
            this.TabLoadAllRecord.Controls.Add(this.LblLoad);
            this.TabLoadAllRecord.Controls.Add(this.BtnLoadAllRecord);
            this.TabLoadAllRecord.Controls.Add(this.dataGridView3);
            this.TabLoadAllRecord.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabLoadAllRecord.Location = new System.Drawing.Point(4, 25);
            this.TabLoadAllRecord.Name = "TabLoadAllRecord";
            this.TabLoadAllRecord.Padding = new System.Windows.Forms.Padding(3);
            this.TabLoadAllRecord.Size = new System.Drawing.Size(1338, 441);
            this.TabLoadAllRecord.TabIndex = 0;
            this.TabLoadAllRecord.Text = "Load All Record";
            this.TabLoadAllRecord.UseVisualStyleBackColor = true;
            // 
            // BtnExportRecordToExcel
            // 
            this.BtnExportRecordToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.BtnExportRecordToExcel.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnExportRecordToExcel.FlatAppearance.BorderSize = 0;
            this.BtnExportRecordToExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(117)))), ((int)(((byte)(64)))));
            this.BtnExportRecordToExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(191)))), ((int)(((byte)(111)))));
            this.BtnExportRecordToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportRecordToExcel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportRecordToExcel.ForeColor = System.Drawing.Color.White;
            this.BtnExportRecordToExcel.Location = new System.Drawing.Point(237, 388);
            this.BtnExportRecordToExcel.Name = "BtnExportRecordToExcel";
            this.BtnExportRecordToExcel.Size = new System.Drawing.Size(212, 42);
            this.BtnExportRecordToExcel.TabIndex = 28;
            this.BtnExportRecordToExcel.Text = "Export Record To Excel";
            this.BtnExportRecordToExcel.UseVisualStyleBackColor = false;
            this.BtnExportRecordToExcel.Click += new System.EventHandler(this.BtnExportRecordToExcel_Click);
            // 
            // LblRecordNo
            // 
            this.LblRecordNo.AutoSize = true;
            this.LblRecordNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblRecordNo.Location = new System.Drawing.Point(455, 399);
            this.LblRecordNo.Name = "LblRecordNo";
            this.LblRecordNo.Size = new System.Drawing.Size(196, 20);
            this.LblRecordNo.TabIndex = 27;
            this.LblRecordNo.Text = "Total no. of Record loaded:";
            // 
            // LblLoad
            // 
            this.LblLoad.AutoSize = true;
            this.LblLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblLoad.Location = new System.Drawing.Point(776, 399);
            this.LblLoad.Name = "LblLoad";
            this.LblLoad.Size = new System.Drawing.Size(37, 20);
            this.LblLoad.TabIndex = 26;
            this.LblLoad.Text = "Log:";
            // 
            // BtnLoadAllRecord
            // 
            this.BtnLoadAllRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.BtnLoadAllRecord.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnLoadAllRecord.FlatAppearance.BorderSize = 0;
            this.BtnLoadAllRecord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(117)))), ((int)(((byte)(64)))));
            this.BtnLoadAllRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(191)))), ((int)(((byte)(111)))));
            this.BtnLoadAllRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLoadAllRecord.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLoadAllRecord.ForeColor = System.Drawing.Color.White;
            this.BtnLoadAllRecord.Location = new System.Drawing.Point(19, 388);
            this.BtnLoadAllRecord.Name = "BtnLoadAllRecord";
            this.BtnLoadAllRecord.Size = new System.Drawing.Size(212, 42);
            this.BtnLoadAllRecord.TabIndex = 25;
            this.BtnLoadAllRecord.Text = "Load All Record";
            this.BtnLoadAllRecord.UseVisualStyleBackColor = false;
            this.BtnLoadAllRecord.Click += new System.EventHandler(this.BtnLoadAllRecord_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(19, 15);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(1306, 362);
            this.dataGridView3.TabIndex = 0;
            // 
            // TabRWYEq
            // 
            this.TabRWYEq.Controls.Add(this.TxtRWYClassify);
            this.TabRWYEq.Controls.Add(this.BtnZoomToFit2);
            this.TabRWYEq.Controls.Add(this.label27);
            this.TabRWYEq.Controls.Add(this.label26);
            this.TabRWYEq.Controls.Add(this.groupBox4);
            this.TabRWYEq.Controls.Add(this.BtnLoadRWYCoord);
            this.TabRWYEq.Controls.Add(this.ComboBoxRWY);
            this.TabRWYEq.Controls.Add(this.TxtAirportCode);
            this.TabRWYEq.Controls.Add(this.dataGridView2);
            this.TabRWYEq.Controls.Add(this.groupBox6);
            this.TabRWYEq.Controls.Add(this.label19);
            this.TabRWYEq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabRWYEq.Location = new System.Drawing.Point(4, 25);
            this.TabRWYEq.Name = "TabRWYEq";
            this.TabRWYEq.Padding = new System.Windows.Forms.Padding(3);
            this.TabRWYEq.Size = new System.Drawing.Size(1338, 441);
            this.TabRWYEq.TabIndex = 3;
            this.TabRWYEq.Text = "RWY COORD and Eq";
            this.TabRWYEq.UseVisualStyleBackColor = true;
            // 
            // TxtRWYClassify
            // 
            this.TxtRWYClassify.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRWYClassify.Location = new System.Drawing.Point(585, 287);
            this.TxtRWYClassify.Name = "TxtRWYClassify";
            this.TxtRWYClassify.Size = new System.Drawing.Size(302, 28);
            this.TxtRWYClassify.TabIndex = 16;
            // 
            // BtnZoomToFit2
            // 
            this.BtnZoomToFit2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnZoomToFit2.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnZoomToFit2.FlatAppearance.BorderSize = 0;
            this.BtnZoomToFit2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnZoomToFit2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnZoomToFit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnZoomToFit2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnZoomToFit2.ForeColor = System.Drawing.Color.White;
            this.BtnZoomToFit2.Location = new System.Drawing.Point(757, 321);
            this.BtnZoomToFit2.Name = "BtnZoomToFit2";
            this.BtnZoomToFit2.Size = new System.Drawing.Size(129, 42);
            this.BtnZoomToFit2.TabIndex = 15;
            this.BtnZoomToFit2.Text = "Zoom to Fit";
            this.BtnZoomToFit2.UseVisualStyleBackColor = false;
            this.BtnZoomToFit2.Click += new System.EventHandler(this.BtnZoomToFit2_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Red;
            this.label27.Location = new System.Drawing.Point(585, 385);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(204, 18);
            this.label27.TabIndex = 14;
            this.label27.Text = "RUNWAY CLASSIFICATION: ";
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.MediumBlue;
            this.label26.Location = new System.Drawing.Point(582, 412);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(569, 31);
            this.label26.TabIndex = 13;
            this.label26.Text = "PRECISION APPROACH  CATEGORY II OR III, CODE NO. 4E";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gMapControl2);
            this.groupBox4.Location = new System.Drawing.Point(902, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(423, 393);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Runway Map";
            // 
            // gMapControl2
            // 
            this.gMapControl2.Bearing = 0F;
            this.gMapControl2.CanDragMap = true;
            this.gMapControl2.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl2.GrayScaleMode = false;
            this.gMapControl2.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl2.LevelsKeepInMemory = 5;
            this.gMapControl2.Location = new System.Drawing.Point(6, 21);
            this.gMapControl2.MarkersEnabled = true;
            this.gMapControl2.MaxZoom = 25;
            this.gMapControl2.MinZoom = 2;
            this.gMapControl2.MouseWheelZoomEnabled = true;
            this.gMapControl2.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl2.Name = "gMapControl2";
            this.gMapControl2.NegativeMode = false;
            this.gMapControl2.PolygonsEnabled = true;
            this.gMapControl2.RetryLoadTile = 0;
            this.gMapControl2.RoutesEnabled = true;
            this.gMapControl2.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl2.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl2.ShowTileGridLines = false;
            this.gMapControl2.Size = new System.Drawing.Size(411, 366);
            this.gMapControl2.TabIndex = 11;
            this.gMapControl2.Zoom = 0D;
            // 
            // BtnLoadRWYCoord
            // 
            this.BtnLoadRWYCoord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnLoadRWYCoord.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnLoadRWYCoord.FlatAppearance.BorderSize = 0;
            this.BtnLoadRWYCoord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnLoadRWYCoord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnLoadRWYCoord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLoadRWYCoord.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLoadRWYCoord.ForeColor = System.Drawing.Color.White;
            this.BtnLoadRWYCoord.Location = new System.Drawing.Point(585, 321);
            this.BtnLoadRWYCoord.Name = "BtnLoadRWYCoord";
            this.BtnLoadRWYCoord.Size = new System.Drawing.Size(151, 42);
            this.BtnLoadRWYCoord.TabIndex = 11;
            this.BtnLoadRWYCoord.Text = "1. Load RWY Coord";
            this.BtnLoadRWYCoord.UseVisualStyleBackColor = false;
            this.BtnLoadRWYCoord.Click += new System.EventHandler(this.BtnLoadRWYCoord_Click);
            // 
            // ComboBoxRWY
            // 
            this.ComboBoxRWY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxRWY.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxRWY.FormattingEnabled = true;
            this.ComboBoxRWY.Location = new System.Drawing.Point(585, 253);
            this.ComboBoxRWY.Name = "ComboBoxRWY";
            this.ComboBoxRWY.Size = new System.Drawing.Size(151, 28);
            this.ComboBoxRWY.TabIndex = 10;
            this.ComboBoxRWY.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRWY_SelectedIndexChanged);
            // 
            // TxtAirportCode
            // 
            this.TxtAirportCode.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAirportCode.Location = new System.Drawing.Point(745, 253);
            this.TxtAirportCode.Name = "TxtAirportCode";
            this.TxtAirportCode.Size = new System.Drawing.Size(142, 28);
            this.TxtAirportCode.TabIndex = 9;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColLine,
            this.ColSlope,
            this.ColIntercept,
            this.ColDistance});
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridView2.Location = new System.Drawing.Point(22, 247);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(557, 175);
            this.dataGridView2.TabIndex = 10;
            // 
            // ColLine
            // 
            this.ColLine.HeaderText = "Line";
            this.ColLine.Name = "ColLine";
            this.ColLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColLine.Width = 50;
            // 
            // ColSlope
            // 
            this.ColSlope.HeaderText = "Slope";
            this.ColSlope.Name = "ColSlope";
            this.ColSlope.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSlope.Width = 150;
            // 
            // ColIntercept
            // 
            this.ColIntercept.HeaderText = "Intercept in m";
            this.ColIntercept.Name = "ColIntercept";
            this.ColIntercept.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColIntercept.Width = 150;
            // 
            // ColDistance
            // 
            this.ColDistance.HeaderText = "Distance in m";
            this.ColDistance.Name = "ColDistance";
            this.ColDistance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDistance.Width = 150;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportLineParameterToExcelToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(235, 26);
            // 
            // exportLineParameterToExcelToolStripMenuItem
            // 
            this.exportLineParameterToExcelToolStripMenuItem.Name = "exportLineParameterToExcelToolStripMenuItem";
            this.exportLineParameterToExcelToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.exportLineParameterToExcelToolStripMenuItem.Text = "Export Line parameter to Excel";
            this.exportLineParameterToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportLineParameterToExcelToolStripMenuItem_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridView1);
            this.groupBox6.Location = new System.Drawing.Point(22, 17);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(874, 212);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Runway Coordinates";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPoint,
            this.ColDescription,
            this.ColLatitude,
            this.ColLongitude,
            this.ColEasting,
            this.ColNorthing});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(6, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(858, 167);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColPoint
            // 
            this.ColPoint.HeaderText = "Point";
            this.ColPoint.Name = "ColPoint";
            this.ColPoint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPoint.Width = 50;
            // 
            // ColDescription
            // 
            this.ColDescription.HeaderText = "Description";
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDescription.Width = 145;
            // 
            // ColLatitude
            // 
            this.ColLatitude.HeaderText = "Latitude (N in DD)";
            this.ColLatitude.Name = "ColLatitude";
            this.ColLatitude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColLatitude.Width = 150;
            // 
            // ColLongitude
            // 
            this.ColLongitude.HeaderText = "Longitude (E in DD)";
            this.ColLongitude.Name = "ColLongitude";
            this.ColLongitude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColLongitude.Width = 150;
            // 
            // ColEasting
            // 
            this.ColEasting.HeaderText = "Easting (X in m)";
            this.ColEasting.Name = "ColEasting";
            this.ColEasting.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEasting.Width = 150;
            // 
            // ColNorthing
            // 
            this.ColNorthing.HeaderText = "Northing (Y in m)";
            this.ColNorthing.Name = "ColNorthing";
            this.ColNorthing.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColNorthing.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportRWYCOORDToExcelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(226, 26);
            // 
            // exportRWYCOORDToExcelToolStripMenuItem
            // 
            this.exportRWYCOORDToExcelToolStripMenuItem.Name = "exportRWYCOORDToExcelToolStripMenuItem";
            this.exportRWYCOORDToExcelToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.exportRWYCOORDToExcelToolStripMenuItem.Text = "Export RWY COORD To Excel";
            this.exportRWYCOORDToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportRWYCOORDToExcelToolStripMenuItem_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(622, 234);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 16);
            this.label19.TabIndex = 8;
            this.label19.Text = "Choose RWY";
            // 
            // TabObstacleHeightCalculation
            // 
            this.TabObstacleHeightCalculation.Controls.Add(this.groupBox11);
            this.TabObstacleHeightCalculation.Controls.Add(this.BtnZoomToFit);
            this.TabObstacleHeightCalculation.Controls.Add(this.ChkBoxAutoFitMap);
            this.TabObstacleHeightCalculation.Controls.Add(this.label25);
            this.TabObstacleHeightCalculation.Controls.Add(this.TxtPlotCase);
            this.TabObstacleHeightCalculation.Controls.Add(this.label24);
            this.TabObstacleHeightCalculation.Controls.Add(this.BtnExportToKML);
            this.TabObstacleHeightCalculation.Controls.Add(this.TxtArealDistance);
            this.TabObstacleHeightCalculation.Controls.Add(this.BtnSaveMap);
            this.TabObstacleHeightCalculation.Controls.Add(this.groupBox5);
            this.TabObstacleHeightCalculation.Controls.Add(this.BtnCreateMap);
            this.TabObstacleHeightCalculation.Controls.Add(this.gMapControl1);
            this.TabObstacleHeightCalculation.Controls.Add(this.splitter1);
            this.TabObstacleHeightCalculation.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabObstacleHeightCalculation.Location = new System.Drawing.Point(4, 25);
            this.TabObstacleHeightCalculation.Name = "TabObstacleHeightCalculation";
            this.TabObstacleHeightCalculation.Size = new System.Drawing.Size(1338, 441);
            this.TabObstacleHeightCalculation.TabIndex = 2;
            this.TabObstacleHeightCalculation.Text = "RWY to Obstacle Distance Calculation";
            this.TabObstacleHeightCalculation.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.ChkBoxOuterHorizontal);
            this.groupBox11.Controls.Add(this.ChkBoxInnerTrans);
            this.groupBox11.Controls.Add(this.ChkBoxInnerApproach);
            this.groupBox11.Controls.Add(this.BtnDeselectAll);
            this.groupBox11.Controls.Add(this.BtnSelectAll);
            this.groupBox11.Controls.Add(this.ChkBoxBalkedlanding);
            this.groupBox11.Controls.Add(this.ChkBoxTransition);
            this.groupBox11.Controls.Add(this.ChkBoxTakeoffclimb);
            this.groupBox11.Controls.Add(this.ChkBoxApproach);
            this.groupBox11.Controls.Add(this.ChkBoxConical);
            this.groupBox11.Controls.Add(this.ChkBoxHorizontal);
            this.groupBox11.Location = new System.Drawing.Point(975, 107);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(346, 186);
            this.groupBox11.TabIndex = 20;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Surfaces";
            // 
            // ChkBoxOuterHorizontal
            // 
            this.ChkBoxOuterHorizontal.AutoSize = true;
            this.ChkBoxOuterHorizontal.Checked = true;
            this.ChkBoxOuterHorizontal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBoxOuterHorizontal.ForeColor = System.Drawing.Color.DeepPink;
            this.ChkBoxOuterHorizontal.Location = new System.Drawing.Point(150, 49);
            this.ChkBoxOuterHorizontal.Name = "ChkBoxOuterHorizontal";
            this.ChkBoxOuterHorizontal.Size = new System.Drawing.Size(188, 24);
            this.ChkBoxOuterHorizontal.TabIndex = 25;
            this.ChkBoxOuterHorizontal.Text = "OUTER HORIZONTAL";
            this.ChkBoxOuterHorizontal.UseVisualStyleBackColor = true;
            this.ChkBoxOuterHorizontal.CheckedChanged += new System.EventHandler(this.ChkBoxOuterHorizontal_CheckedChanged);
            // 
            // ChkBoxInnerTrans
            // 
            this.ChkBoxInnerTrans.AutoSize = true;
            this.ChkBoxInnerTrans.Checked = true;
            this.ChkBoxInnerTrans.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBoxInnerTrans.ForeColor = System.Drawing.Color.DarkRed;
            this.ChkBoxInnerTrans.Location = new System.Drawing.Point(150, 95);
            this.ChkBoxInnerTrans.Name = "ChkBoxInnerTrans";
            this.ChkBoxInnerTrans.Size = new System.Drawing.Size(184, 24);
            this.ChkBoxInnerTrans.TabIndex = 24;
            this.ChkBoxInnerTrans.Text = "INNER TRANSITION";
            this.ChkBoxInnerTrans.UseVisualStyleBackColor = true;
            this.ChkBoxInnerTrans.CheckedChanged += new System.EventHandler(this.ChkBoxInnerTrans_CheckedChanged);
            // 
            // ChkBoxInnerApproach
            // 
            this.ChkBoxInnerApproach.AutoSize = true;
            this.ChkBoxInnerApproach.Checked = true;
            this.ChkBoxInnerApproach.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBoxInnerApproach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ChkBoxInnerApproach.Location = new System.Drawing.Point(150, 71);
            this.ChkBoxInnerApproach.Name = "ChkBoxInnerApproach";
            this.ChkBoxInnerApproach.Size = new System.Drawing.Size(162, 24);
            this.ChkBoxInnerApproach.TabIndex = 23;
            this.ChkBoxInnerApproach.Text = "INNER APPROACH";
            this.ChkBoxInnerApproach.UseVisualStyleBackColor = true;
            this.ChkBoxInnerApproach.CheckedChanged += new System.EventHandler(this.ChkBoxInnerApproach_CheckedChanged);
            // 
            // BtnDeselectAll
            // 
            this.BtnDeselectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnDeselectAll.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnDeselectAll.FlatAppearance.BorderSize = 0;
            this.BtnDeselectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnDeselectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnDeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeselectAll.ForeColor = System.Drawing.Color.White;
            this.BtnDeselectAll.Location = new System.Drawing.Point(261, 124);
            this.BtnDeselectAll.Name = "BtnDeselectAll";
            this.BtnDeselectAll.Size = new System.Drawing.Size(79, 48);
            this.BtnDeselectAll.TabIndex = 22;
            this.BtnDeselectAll.Text = "Deselect all";
            this.BtnDeselectAll.UseVisualStyleBackColor = false;
            this.BtnDeselectAll.Click += new System.EventHandler(this.BtnDeselectAll_Click);
            // 
            // BtnSelectAll
            // 
            this.BtnSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.BtnSelectAll.Enabled = false;
            this.BtnSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnSelectAll.FlatAppearance.BorderSize = 0;
            this.BtnSelectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(117)))), ((int)(((byte)(64)))));
            this.BtnSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(191)))), ((int)(((byte)(111)))));
            this.BtnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectAll.ForeColor = System.Drawing.Color.White;
            this.BtnSelectAll.Location = new System.Drawing.Point(181, 124);
            this.BtnSelectAll.Name = "BtnSelectAll";
            this.BtnSelectAll.Size = new System.Drawing.Size(74, 48);
            this.BtnSelectAll.TabIndex = 21;
            this.BtnSelectAll.Text = "Select all";
            this.BtnSelectAll.UseVisualStyleBackColor = false;
            this.BtnSelectAll.Click += new System.EventHandler(this.BtnSelectAll_Click);
            // 
            // ChkBoxBalkedlanding
            // 
            this.ChkBoxBalkedlanding.AutoSize = true;
            this.ChkBoxBalkedlanding.Checked = true;
            this.ChkBoxBalkedlanding.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBoxBalkedlanding.ForeColor = System.Drawing.Color.DarkOrange;
            this.ChkBoxBalkedlanding.Location = new System.Drawing.Point(14, 148);
            this.ChkBoxBalkedlanding.Name = "ChkBoxBalkedlanding";
            this.ChkBoxBalkedlanding.Size = new System.Drawing.Size(161, 24);
            this.ChkBoxBalkedlanding.TabIndex = 5;
            this.ChkBoxBalkedlanding.Text = "BALKED LANDING";
            this.ChkBoxBalkedlanding.UseVisualStyleBackColor = true;
            this.ChkBoxBalkedlanding.CheckedChanged += new System.EventHandler(this.ChkBoxBalkedlanding_CheckedChanged);
            // 
            // ChkBoxTransition
            // 
            this.ChkBoxTransition.AutoSize = true;
            this.ChkBoxTransition.Checked = true;
            this.ChkBoxTransition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBoxTransition.ForeColor = System.Drawing.Color.Blue;
            this.ChkBoxTransition.Location = new System.Drawing.Point(14, 101);
            this.ChkBoxTransition.Name = "ChkBoxTransition";
            this.ChkBoxTransition.Size = new System.Drawing.Size(130, 24);
            this.ChkBoxTransition.TabIndex = 4;
            this.ChkBoxTransition.Text = "TRANSITION";
            this.ChkBoxTransition.UseVisualStyleBackColor = true;
            this.ChkBoxTransition.CheckedChanged += new System.EventHandler(this.ChkBoxTransition_CheckedChanged);
            // 
            // ChkBoxTakeoffclimb
            // 
            this.ChkBoxTakeoffclimb.AutoSize = true;
            this.ChkBoxTakeoffclimb.Checked = true;
            this.ChkBoxTakeoffclimb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBoxTakeoffclimb.ForeColor = System.Drawing.Color.DarkCyan;
            this.ChkBoxTakeoffclimb.Location = new System.Drawing.Point(14, 124);
            this.ChkBoxTakeoffclimb.Name = "ChkBoxTakeoffclimb";
            this.ChkBoxTakeoffclimb.Size = new System.Drawing.Size(152, 24);
            this.ChkBoxTakeoffclimb.TabIndex = 3;
            this.ChkBoxTakeoffclimb.Text = "TAKE OFF CLIMB";
            this.ChkBoxTakeoffclimb.UseVisualStyleBackColor = true;
            this.ChkBoxTakeoffclimb.CheckedChanged += new System.EventHandler(this.ChkBoxTakeoffclimb_CheckedChanged);
            // 
            // ChkBoxApproach
            // 
            this.ChkBoxApproach.AutoSize = true;
            this.ChkBoxApproach.Checked = true;
            this.ChkBoxApproach.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBoxApproach.ForeColor = System.Drawing.Color.Red;
            this.ChkBoxApproach.Location = new System.Drawing.Point(14, 77);
            this.ChkBoxApproach.Name = "ChkBoxApproach";
            this.ChkBoxApproach.Size = new System.Drawing.Size(108, 24);
            this.ChkBoxApproach.TabIndex = 2;
            this.ChkBoxApproach.Text = "APPROACH";
            this.ChkBoxApproach.UseVisualStyleBackColor = true;
            this.ChkBoxApproach.CheckedChanged += new System.EventHandler(this.ChkBoxApproach_CheckedChanged);
            // 
            // ChkBoxConical
            // 
            this.ChkBoxConical.AutoSize = true;
            this.ChkBoxConical.Checked = true;
            this.ChkBoxConical.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBoxConical.ForeColor = System.Drawing.Color.DimGray;
            this.ChkBoxConical.Location = new System.Drawing.Point(14, 52);
            this.ChkBoxConical.Name = "ChkBoxConical";
            this.ChkBoxConical.Size = new System.Drawing.Size(97, 24);
            this.ChkBoxConical.TabIndex = 1;
            this.ChkBoxConical.Text = "CONICAL";
            this.ChkBoxConical.UseVisualStyleBackColor = true;
            this.ChkBoxConical.CheckedChanged += new System.EventHandler(this.ChkBoxConical_CheckedChanged);
            // 
            // ChkBoxHorizontal
            // 
            this.ChkBoxHorizontal.AutoSize = true;
            this.ChkBoxHorizontal.Checked = true;
            this.ChkBoxHorizontal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBoxHorizontal.ForeColor = System.Drawing.Color.DarkMagenta;
            this.ChkBoxHorizontal.Location = new System.Drawing.Point(14, 27);
            this.ChkBoxHorizontal.Name = "ChkBoxHorizontal";
            this.ChkBoxHorizontal.Size = new System.Drawing.Size(187, 24);
            this.ChkBoxHorizontal.TabIndex = 0;
            this.ChkBoxHorizontal.Text = "INNER HORIZONTAL";
            this.ChkBoxHorizontal.UseVisualStyleBackColor = true;
            this.ChkBoxHorizontal.CheckedChanged += new System.EventHandler(this.ChkBoxHorizontal_CheckedChanged);
            // 
            // BtnZoomToFit
            // 
            this.BtnZoomToFit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnZoomToFit.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnZoomToFit.FlatAppearance.BorderSize = 0;
            this.BtnZoomToFit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnZoomToFit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnZoomToFit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnZoomToFit.ForeColor = System.Drawing.Color.White;
            this.BtnZoomToFit.Location = new System.Drawing.Point(975, 388);
            this.BtnZoomToFit.Name = "BtnZoomToFit";
            this.BtnZoomToFit.Size = new System.Drawing.Size(116, 42);
            this.BtnZoomToFit.TabIndex = 19;
            this.BtnZoomToFit.Text = "Zoom to Point";
            this.BtnZoomToFit.UseVisualStyleBackColor = false;
            this.BtnZoomToFit.Click += new System.EventHandler(this.BtnZoomToFit_Click);
            // 
            // ChkBoxAutoFitMap
            // 
            this.ChkBoxAutoFitMap.Checked = true;
            this.ChkBoxAutoFitMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBoxAutoFitMap.Location = new System.Drawing.Point(1131, 333);
            this.ChkBoxAutoFitMap.Name = "ChkBoxAutoFitMap";
            this.ChkBoxAutoFitMap.Size = new System.Drawing.Size(125, 49);
            this.ChkBoxAutoFitMap.TabIndex = 18;
            this.ChkBoxAutoFitMap.Text = "Auto Fit Map While Saving";
            this.ChkBoxAutoFitMap.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.DarkViolet;
            this.label25.Location = new System.Drawing.Point(1254, 331);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 20);
            this.label25.TabIndex = 17;
            this.label25.Text = "Plot Case";
            // 
            // TxtPlotCase
            // 
            this.TxtPlotCase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPlotCase.Location = new System.Drawing.Point(1258, 354);
            this.TxtPlotCase.Name = "TxtPlotCase";
            this.TxtPlotCase.Size = new System.Drawing.Size(63, 26);
            this.TxtPlotCase.TabIndex = 16;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.DarkViolet;
            this.label24.Location = new System.Drawing.Point(971, 307);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(137, 20);
            this.label24.TabIndex = 11;
            this.label24.Text = "Areal distance (m)";
            // 
            // BtnExportToKML
            // 
            this.BtnExportToKML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnExportToKML.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnExportToKML.FlatAppearance.BorderSize = 0;
            this.BtnExportToKML.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnExportToKML.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnExportToKML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportToKML.ForeColor = System.Drawing.Color.White;
            this.BtnExportToKML.Location = new System.Drawing.Point(1209, 388);
            this.BtnExportToKML.Name = "BtnExportToKML";
            this.BtnExportToKML.Size = new System.Drawing.Size(120, 42);
            this.BtnExportToKML.TabIndex = 15;
            this.BtnExportToKML.Text = "Export to KML";
            this.BtnExportToKML.UseVisualStyleBackColor = false;
            this.BtnExportToKML.Click += new System.EventHandler(this.BtnExportToKML_Click);
            // 
            // TxtArealDistance
            // 
            this.TxtArealDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtArealDistance.Location = new System.Drawing.Point(1131, 299);
            this.TxtArealDistance.Name = "TxtArealDistance";
            this.TxtArealDistance.Size = new System.Drawing.Size(190, 26);
            this.TxtArealDistance.TabIndex = 10;
            // 
            // BtnSaveMap
            // 
            this.BtnSaveMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnSaveMap.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnSaveMap.FlatAppearance.BorderSize = 0;
            this.BtnSaveMap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnSaveMap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnSaveMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveMap.ForeColor = System.Drawing.Color.White;
            this.BtnSaveMap.Location = new System.Drawing.Point(1097, 388);
            this.BtnSaveMap.Name = "BtnSaveMap";
            this.BtnSaveMap.Size = new System.Drawing.Size(104, 42);
            this.BtnSaveMap.TabIndex = 14;
            this.BtnSaveMap.Text = "3. Save Map";
            this.BtnSaveMap.UseVisualStyleBackColor = false;
            this.BtnSaveMap.Click += new System.EventHandler(this.BtnSaveMap_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.TxtLong2);
            this.groupBox5.Controls.Add(this.TxtLat2);
            this.groupBox5.Location = new System.Drawing.Point(975, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(346, 87);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Nearest Coordinate of Plot";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(191, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "Longitude, E (DD)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Latitude, N (DD)";
            // 
            // TxtLong2
            // 
            this.TxtLong2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLong2.Location = new System.Drawing.Point(195, 48);
            this.TxtLong2.Name = "TxtLong2";
            this.TxtLong2.Size = new System.Drawing.Size(131, 26);
            this.TxtLong2.TabIndex = 7;
            this.TxtLong2.Text = "83.42268056";
            // 
            // TxtLat2
            // 
            this.TxtLat2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLat2.Location = new System.Drawing.Point(14, 48);
            this.TxtLat2.Name = "TxtLat2";
            this.TxtLat2.Size = new System.Drawing.Size(136, 26);
            this.TxtLat2.TabIndex = 7;
            this.TxtLat2.Text = "27.50574722";
            // 
            // BtnCreateMap
            // 
            this.BtnCreateMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnCreateMap.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnCreateMap.FlatAppearance.BorderSize = 0;
            this.BtnCreateMap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnCreateMap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnCreateMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCreateMap.ForeColor = System.Drawing.Color.White;
            this.BtnCreateMap.Location = new System.Drawing.Point(975, 340);
            this.BtnCreateMap.Name = "BtnCreateMap";
            this.BtnCreateMap.Size = new System.Drawing.Size(150, 42);
            this.BtnCreateMap.TabIndex = 12;
            this.BtnCreateMap.Text = "2. Plot Map";
            this.BtnCreateMap.UseVisualStyleBackColor = false;
            this.BtnCreateMap.Click += new System.EventHandler(this.BtnCreateMap_Click);
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(3, 3);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 25;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(954, 438);
            this.gMapControl1.TabIndex = 1;
            this.gMapControl1.Zoom = 2D;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(957, 441);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.groupBox9);
            this.TabGeneral.Controls.Add(this.groupBox3);
            this.TabGeneral.Controls.Add(this.groupBox2);
            this.TabGeneral.Controls.Add(this.groupBox1);
            this.TabGeneral.Controls.Add(this.groupBox7);
            this.TabGeneral.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabGeneral.Location = new System.Drawing.Point(4, 25);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneral.Size = new System.Drawing.Size(1338, 441);
            this.TabGeneral.TabIndex = 1;
            this.TabGeneral.Text = "General";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.TxtElev_Permitted);
            this.groupBox9.Controls.Add(this.label22);
            this.groupBox9.Controls.Add(this.TxtElev_Obstacle);
            this.groupBox9.Controls.Add(this.label20);
            this.groupBox9.Controls.Add(this.TxtHeightAbovePlinth);
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Controls.Add(this.TxtRL_Plinth);
            this.groupBox9.Controls.Add(this.label23);
            this.groupBox9.Location = new System.Drawing.Point(15, 261);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1303, 71);
            this.groupBox9.TabIndex = 12;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Elevation of Proposed Obstacle";
            // 
            // TxtElev_Permitted
            // 
            this.TxtElev_Permitted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtElev_Permitted.Location = new System.Drawing.Point(1169, 31);
            this.TxtElev_Permitted.Name = "TxtElev_Permitted";
            this.TxtElev_Permitted.Size = new System.Drawing.Size(118, 26);
            this.TxtElev_Permitted.TabIndex = 9;
            this.TxtElev_Permitted.TextChanged += new System.EventHandler(this.TxtElev_Permitted_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.DarkViolet;
            this.label22.Location = new System.Drawing.Point(870, 34);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(285, 20);
            this.label22.TabIndex = 8;
            this.label22.Text = "Permitted elevation of obstacle (AMSL)";
            // 
            // TxtElev_Obstacle
            // 
            this.TxtElev_Obstacle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtElev_Obstacle.Location = new System.Drawing.Point(745, 31);
            this.TxtElev_Obstacle.Name = "TxtElev_Obstacle";
            this.TxtElev_Obstacle.Size = new System.Drawing.Size(119, 26);
            this.TxtElev_Obstacle.TabIndex = 7;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.DarkViolet;
            this.label20.Location = new System.Drawing.Point(528, 34);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(213, 20);
            this.label20.TabIndex = 6;
            this.label20.Text = "Elevation of obstacle (AMSL)";
            // 
            // TxtHeightAbovePlinth
            // 
            this.TxtHeightAbovePlinth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHeightAbovePlinth.Location = new System.Drawing.Point(436, 31);
            this.TxtHeightAbovePlinth.Name = "TxtHeightAbovePlinth";
            this.TxtHeightAbovePlinth.Size = new System.Drawing.Size(85, 26);
            this.TxtHeightAbovePlinth.TabIndex = 5;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(287, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(143, 20);
            this.label21.TabIndex = 4;
            this.label21.Text = "Height above plinth";
            // 
            // TxtRL_Plinth
            // 
            this.TxtRL_Plinth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRL_Plinth.Location = new System.Drawing.Point(158, 31);
            this.TxtRL_Plinth.Name = "TxtRL_Plinth";
            this.TxtRL_Plinth.Size = new System.Drawing.Size(99, 26);
            this.TxtRL_Plinth.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(7, 34);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(147, 20);
            this.label23.TabIndex = 0;
            this.label23.Text = "RL of Plinth (AMSL)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ComboBoxLocalLevel);
            this.groupBox3.Controls.Add(this.TxtTole);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.TxtWardNo);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.TxtLocalLevel);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(15, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1303, 71);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Address";
            // 
            // ComboBoxLocalLevel
            // 
            this.ComboBoxLocalLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxLocalLevel.FormattingEnabled = true;
            this.ComboBoxLocalLevel.Location = new System.Drawing.Point(119, 25);
            this.ComboBoxLocalLevel.Name = "ComboBoxLocalLevel";
            this.ComboBoxLocalLevel.Size = new System.Drawing.Size(293, 28);
            this.ComboBoxLocalLevel.TabIndex = 10;
            this.ComboBoxLocalLevel.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLocalLevel_SelectedIndexChanged);
            // 
            // TxtTole
            // 
            this.TxtTole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTole.Location = new System.Drawing.Point(1018, 25);
            this.TxtTole.Name = "TxtTole";
            this.TxtTole.Size = new System.Drawing.Size(269, 26);
            this.TxtTole.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(951, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Tole";
            // 
            // TxtWardNo
            // 
            this.TxtWardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWardNo.Location = new System.Drawing.Point(836, 25);
            this.TxtWardNo.Name = "TxtWardNo";
            this.TxtWardNo.Size = new System.Drawing.Size(96, 26);
            this.TxtWardNo.TabIndex = 3;
            this.TxtWardNo.TextChanged += new System.EventHandler(this.TxtWardNo_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(741, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Ward no.";
            // 
            // TxtLocalLevel
            // 
            this.TxtLocalLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLocalLevel.Location = new System.Drawing.Point(424, 25);
            this.TxtLocalLevel.Name = "TxtLocalLevel";
            this.TxtLocalLevel.Size = new System.Drawing.Size(311, 26);
            this.TxtLocalLevel.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.OrangeRed;
            this.label10.Location = new System.Drawing.Point(7, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Local Level (*)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtPlotNo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.ComboBoxObstacleType);
            this.groupBox2.Controls.Add(this.ComboBoxFY);
            this.groupBox2.Controls.Add(this.TxtObstacleType);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TxtFY);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TxtID);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(15, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1303, 71);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General";
            // 
            // TxtPlotNo
            // 
            this.TxtPlotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPlotNo.Location = new System.Drawing.Point(1072, 23);
            this.TxtPlotNo.Name = "TxtPlotNo";
            this.TxtPlotNo.Size = new System.Drawing.Size(215, 26);
            this.TxtPlotNo.TabIndex = 9;
            this.TxtPlotNo.TextChanged += new System.EventHandler(this.TxtPlotNo_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(983, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Plot no. (*)";
            // 
            // ComboBoxObstacleType
            // 
            this.ComboBoxObstacleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxObstacleType.FormattingEnabled = true;
            this.ComboBoxObstacleType.Location = new System.Drawing.Point(610, 23);
            this.ComboBoxObstacleType.Name = "ComboBoxObstacleType";
            this.ComboBoxObstacleType.Size = new System.Drawing.Size(173, 28);
            this.ComboBoxObstacleType.TabIndex = 7;
            this.ComboBoxObstacleType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxMonth_SelectedIndexChanged);
            // 
            // ComboBoxFY
            // 
            this.ComboBoxFY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFY.FormattingEnabled = true;
            this.ComboBoxFY.Location = new System.Drawing.Point(250, 23);
            this.ComboBoxFY.Name = "ComboBoxFY";
            this.ComboBoxFY.Size = new System.Drawing.Size(121, 28);
            this.ComboBoxFY.TabIndex = 6;
            this.ComboBoxFY.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFY_SelectedIndexChanged);
            // 
            // TxtObstacleType
            // 
            this.TxtObstacleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObstacleType.Location = new System.Drawing.Point(793, 23);
            this.TxtObstacleType.Name = "TxtObstacleType";
            this.TxtObstacleType.Size = new System.Drawing.Size(184, 26);
            this.TxtObstacleType.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(494, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Obstacle Type";
            // 
            // TxtFY
            // 
            this.TxtFY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFY.Location = new System.Drawing.Point(380, 23);
            this.TxtFY.Name = "TxtFY";
            this.TxtFY.Size = new System.Drawing.Size(108, 26);
            this.TxtFY.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(134, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Fiscal Year (*)";
            // 
            // TxtID
            // 
            this.TxtID.Enabled = false;
            this.TxtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtID.Location = new System.Drawing.Point(41, 25);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(87, 26);
            this.TxtID.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComboBoxDesignation);
            this.groupBox1.Controls.Add(this.TxtLastName);
            this.groupBox1.Controls.Add(this.TxtDesignation);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtMiddleName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtFirstName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1303, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // ComboBoxDesignation
            // 
            this.ComboBoxDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDesignation.FormattingEnabled = true;
            this.ComboBoxDesignation.Location = new System.Drawing.Point(103, 25);
            this.ComboBoxDesignation.Name = "ComboBoxDesignation";
            this.ComboBoxDesignation.Size = new System.Drawing.Size(103, 28);
            this.ComboBoxDesignation.TabIndex = 12;
            this.ComboBoxDesignation.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDesignation_SelectedIndexChanged);
            // 
            // TxtLastName
            // 
            this.TxtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLastName.Location = new System.Drawing.Point(1116, 25);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(171, 26);
            this.TxtLastName.TabIndex = 5;
            // 
            // TxtDesignation
            // 
            this.TxtDesignation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDesignation.Location = new System.Drawing.Point(212, 25);
            this.TxtDesignation.Name = "TxtDesignation";
            this.TxtDesignation.Size = new System.Drawing.Size(108, 26);
            this.TxtDesignation.TabIndex = 11;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(7, 28);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(90, 20);
            this.label40.TabIndex = 10;
            this.label40.Text = "Deisgnation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1028, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Name";
            // 
            // TxtMiddleName
            // 
            this.TxtMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMiddleName.Location = new System.Drawing.Point(804, 25);
            this.TxtMiddleName.Name = "TxtMiddleName";
            this.TxtMiddleName.Size = new System.Drawing.Size(204, 26);
            this.TxtMiddleName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(699, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Middle Name";
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFirstName.Location = new System.Drawing.Point(463, 25);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(230, 26);
            this.TxtFirstName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(344, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name (*)";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.TxtLong1);
            this.groupBox7.Controls.Add(this.TxtLat1);
            this.groupBox7.ForeColor = System.Drawing.Color.DarkViolet;
            this.groupBox7.Location = new System.Drawing.Point(15, 338);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1303, 87);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Coordinate of RWY";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(656, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 20);
            this.label13.TabIndex = 9;
            this.label13.Text = "Longitude, E (DD)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 20);
            this.label14.TabIndex = 8;
            this.label14.Text = "Latitude, N (DD)";
            // 
            // TxtLong1
            // 
            this.TxtLong1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLong1.Location = new System.Drawing.Point(800, 32);
            this.TxtLong1.Name = "TxtLong1";
            this.TxtLong1.Size = new System.Drawing.Size(493, 26);
            this.TxtLong1.TabIndex = 7;
            // 
            // TxtLat1
            // 
            this.TxtLat1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLat1.Location = new System.Drawing.Point(158, 32);
            this.TxtLat1.Name = "TxtLat1";
            this.TxtLat1.Size = new System.Drawing.Size(446, 26);
            this.TxtLat1.TabIndex = 7;
            // 
            // TabLetter
            // 
            this.TabLetter.Controls.Add(this.BtnCreateNepaliTippani);
            this.TabLetter.Controls.Add(this.TxtNepaliLocalLevel);
            this.TabLetter.Controls.Add(this.label48);
            this.TabLetter.Controls.Add(this.TxtNepaliWardNo);
            this.TabLetter.Controls.Add(this.label47);
            this.TabLetter.Controls.Add(this.TxtNepaliElevation);
            this.TabLetter.Controls.Add(this.label46);
            this.TabLetter.Controls.Add(this.TxtNepaliPlotNo);
            this.TabLetter.Controls.Add(this.label43);
            this.TabLetter.Controls.Add(this.BtnCreateNepaliLetter);
            this.TabLetter.Controls.Add(this.TxtPrevLetterRefNepali);
            this.TabLetter.Controls.Add(this.label42);
            this.TabLetter.Controls.Add(this.TxtPrevLetterNepaliDate);
            this.TabLetter.Controls.Add(this.label41);
            this.TabLetter.Controls.Add(this.label45);
            this.TabLetter.Controls.Add(this.TxtLetterNepaliDate);
            this.TabLetter.Controls.Add(this.label44);
            this.TabLetter.Controls.Add(this.BtnPreviewLetter);
            this.TabLetter.Controls.Add(this.label36);
            this.TabLetter.Controls.Add(this.TxtTitleOfReport);
            this.TabLetter.Controls.Add(this.lable36);
            this.TabLetter.Controls.Add(this.TxtOtherInfo);
            this.TabLetter.Controls.Add(this.TxtPreviousLetterDate);
            this.TabLetter.Controls.Add(this.label34);
            this.TabLetter.Controls.Add(this.TxtPrevLetterRef);
            this.TabLetter.Controls.Add(this.label33);
            this.TabLetter.Controls.Add(this.TxtLetterSignedby);
            this.TabLetter.Controls.Add(this.label32);
            this.TabLetter.Controls.Add(this.TxtLetterCC);
            this.TabLetter.Controls.Add(this.label31);
            this.TabLetter.Controls.Add(this.TxtLetterSubject);
            this.TabLetter.Controls.Add(this.label30);
            this.TabLetter.Controls.Add(this.TxtLetterTo);
            this.TabLetter.Controls.Add(this.label29);
            this.TabLetter.Controls.Add(this.TxtLetterDate);
            this.TabLetter.Controls.Add(this.label28);
            this.TabLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabLetter.Location = new System.Drawing.Point(4, 25);
            this.TabLetter.Name = "TabLetter";
            this.TabLetter.Size = new System.Drawing.Size(1338, 441);
            this.TabLetter.TabIndex = 4;
            this.TabLetter.Text = "Letter and others";
            this.TabLetter.UseVisualStyleBackColor = true;
            // 
            // BtnCreateNepaliTippani
            // 
            this.BtnCreateNepaliTippani.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnCreateNepaliTippani.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnCreateNepaliTippani.FlatAppearance.BorderSize = 0;
            this.BtnCreateNepaliTippani.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnCreateNepaliTippani.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnCreateNepaliTippani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCreateNepaliTippani.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreateNepaliTippani.ForeColor = System.Drawing.Color.White;
            this.BtnCreateNepaliTippani.Location = new System.Drawing.Point(1044, 350);
            this.BtnCreateNepaliTippani.Name = "BtnCreateNepaliTippani";
            this.BtnCreateNepaliTippani.Size = new System.Drawing.Size(222, 54);
            this.BtnCreateNepaliTippani.TabIndex = 52;
            this.BtnCreateNepaliTippani.Text = "Create Nepali tippani";
            this.BtnCreateNepaliTippani.UseVisualStyleBackColor = false;
            this.BtnCreateNepaliTippani.Click += new System.EventHandler(this.BtnCreateNepaliTippani_Click);
            // 
            // TxtNepaliLocalLevel
            // 
            this.TxtNepaliLocalLevel.Font = new System.Drawing.Font("Kalimati", 12F);
            this.TxtNepaliLocalLevel.Location = new System.Drawing.Point(1046, 298);
            this.TxtNepaliLocalLevel.Name = "TxtNepaliLocalLevel";
            this.TxtNepaliLocalLevel.Size = new System.Drawing.Size(275, 34);
            this.TxtNepaliLocalLevel.TabIndex = 51;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Kalimati", 12F);
            this.label48.Location = new System.Drawing.Point(898, 301);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(98, 27);
            this.label48.TabIndex = 50;
            this.label48.Text = "स्थानीय तहः-";
            // 
            // TxtNepaliWardNo
            // 
            this.TxtNepaliWardNo.Font = new System.Drawing.Font("Kalimati", 12F);
            this.TxtNepaliWardNo.Location = new System.Drawing.Point(1046, 255);
            this.TxtNepaliWardNo.Name = "TxtNepaliWardNo";
            this.TxtNepaliWardNo.Size = new System.Drawing.Size(275, 34);
            this.TxtNepaliWardNo.TabIndex = 49;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Kalimati", 12F);
            this.label47.Location = new System.Drawing.Point(898, 258);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(66, 27);
            this.label47.TabIndex = 48;
            this.label47.Text = "वडा नं.-";
            // 
            // TxtNepaliElevation
            // 
            this.TxtNepaliElevation.Font = new System.Drawing.Font("Kalimati", 12F);
            this.TxtNepaliElevation.Location = new System.Drawing.Point(1046, 211);
            this.TxtNepaliElevation.Name = "TxtNepaliElevation";
            this.TxtNepaliElevation.Size = new System.Drawing.Size(275, 34);
            this.TxtNepaliElevation.TabIndex = 47;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Kalimati", 12F);
            this.label46.Location = new System.Drawing.Point(898, 217);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(59, 27);
            this.label46.TabIndex = 46;
            this.label46.Text = "उचाईः-";
            // 
            // TxtNepaliPlotNo
            // 
            this.TxtNepaliPlotNo.Font = new System.Drawing.Font("Kalimati", 12F);
            this.TxtNepaliPlotNo.Location = new System.Drawing.Point(1046, 171);
            this.TxtNepaliPlotNo.Name = "TxtNepaliPlotNo";
            this.TxtNepaliPlotNo.Size = new System.Drawing.Size(275, 34);
            this.TxtNepaliPlotNo.TabIndex = 45;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Kalimati", 12F);
            this.label43.Location = new System.Drawing.Point(898, 174);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(75, 27);
            this.label43.TabIndex = 44;
            this.label43.Text = "कित्ता नं.-";
            // 
            // BtnCreateNepaliLetter
            // 
            this.BtnCreateNepaliLetter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnCreateNepaliLetter.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnCreateNepaliLetter.FlatAppearance.BorderSize = 0;
            this.BtnCreateNepaliLetter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnCreateNepaliLetter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnCreateNepaliLetter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCreateNepaliLetter.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreateNepaliLetter.ForeColor = System.Drawing.Color.White;
            this.BtnCreateNepaliLetter.Location = new System.Drawing.Point(826, 350);
            this.BtnCreateNepaliLetter.Name = "BtnCreateNepaliLetter";
            this.BtnCreateNepaliLetter.Size = new System.Drawing.Size(212, 54);
            this.BtnCreateNepaliLetter.TabIndex = 43;
            this.BtnCreateNepaliLetter.Text = "Create Nepali Letter";
            this.BtnCreateNepaliLetter.UseVisualStyleBackColor = false;
            this.BtnCreateNepaliLetter.Click += new System.EventHandler(this.BtnCreateNepaliLetter_Click);
            // 
            // TxtPrevLetterRefNepali
            // 
            this.TxtPrevLetterRefNepali.Font = new System.Drawing.Font("Kalimati", 12F);
            this.TxtPrevLetterRefNepali.Location = new System.Drawing.Point(1046, 131);
            this.TxtPrevLetterRefNepali.Name = "TxtPrevLetterRefNepali";
            this.TxtPrevLetterRefNepali.Size = new System.Drawing.Size(275, 34);
            this.TxtPrevLetterRefNepali.TabIndex = 42;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Kalimati", 12F);
            this.label42.Location = new System.Drawing.Point(898, 134);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(150, 27);
            this.label42.TabIndex = 41;
            this.label42.Text = "प्राप्त निवेदनको च.नं.-";
            // 
            // TxtPrevLetterNepaliDate
            // 
            this.TxtPrevLetterNepaliDate.Font = new System.Drawing.Font("Kalimati", 12F);
            this.TxtPrevLetterNepaliDate.Location = new System.Drawing.Point(1046, 89);
            this.TxtPrevLetterNepaliDate.Name = "TxtPrevLetterNepaliDate";
            this.TxtPrevLetterNepaliDate.Size = new System.Drawing.Size(275, 34);
            this.TxtPrevLetterNepaliDate.TabIndex = 40;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Kalimati", 12F);
            this.label41.Location = new System.Drawing.Point(896, 92);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(153, 27);
            this.label41.TabIndex = 39;
            this.label41.Text = "प्राप्त निवेदनको मितिः-";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.SeaGreen;
            this.label45.Location = new System.Drawing.Point(992, 16);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(265, 20);
            this.label45.TabIndex = 38;
            this.label45.Text = "Fill Following text in Devanagiri script";
            // 
            // TxtLetterNepaliDate
            // 
            this.TxtLetterNepaliDate.Font = new System.Drawing.Font("Kalimati", 12F);
            this.TxtLetterNepaliDate.Location = new System.Drawing.Point(1046, 48);
            this.TxtLetterNepaliDate.Name = "TxtLetterNepaliDate";
            this.TxtLetterNepaliDate.Size = new System.Drawing.Size(275, 34);
            this.TxtLetterNepaliDate.TabIndex = 37;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Kalimati", 12F);
            this.label44.Location = new System.Drawing.Point(898, 51);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(122, 27);
            this.label44.TabIndex = 36;
            this.label44.Text = "निवेदनको मितिः-";
            // 
            // BtnPreviewLetter
            // 
            this.BtnPreviewLetter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnPreviewLetter.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnPreviewLetter.FlatAppearance.BorderSize = 0;
            this.BtnPreviewLetter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnPreviewLetter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnPreviewLetter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPreviewLetter.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPreviewLetter.ForeColor = System.Drawing.Color.White;
            this.BtnPreviewLetter.Location = new System.Drawing.Point(606, 350);
            this.BtnPreviewLetter.Name = "BtnPreviewLetter";
            this.BtnPreviewLetter.Size = new System.Drawing.Size(212, 54);
            this.BtnPreviewLetter.TabIndex = 27;
            this.BtnPreviewLetter.Text = "Preview English Letter";
            this.BtnPreviewLetter.UseVisualStyleBackColor = false;
            this.BtnPreviewLetter.Click += new System.EventHandler(this.BtnPreviewLetter_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label36.Location = new System.Drawing.Point(452, 226);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(101, 18);
            this.label36.TabIndex = 25;
            this.label36.Text = "Title of Report";
            // 
            // TxtTitleOfReport
            // 
            this.TxtTitleOfReport.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtTitleOfReport.Location = new System.Drawing.Point(455, 247);
            this.TxtTitleOfReport.Multiline = true;
            this.TxtTitleOfReport.Name = "TxtTitleOfReport";
            this.TxtTitleOfReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtTitleOfReport.Size = new System.Drawing.Size(432, 85);
            this.TxtTitleOfReport.TabIndex = 24;
            this.TxtTitleOfReport.Text = "Gautam Buddha International Airport Civil Aviation Office\r\nSiddharthanagar Munici" +
    "pality-4, Rupandehi\r\nCivil Engineering Division\r\nObstacle Height Calculation She" +
    "et";
            // 
            // lable36
            // 
            this.lable36.AutoSize = true;
            this.lable36.Location = new System.Drawing.Point(452, 30);
            this.lable36.Name = "lable36";
            this.lable36.Size = new System.Drawing.Size(101, 18);
            this.lable36.TabIndex = 23;
            this.lable36.Text = "Any Other info";
            // 
            // TxtOtherInfo
            // 
            this.TxtOtherInfo.Location = new System.Drawing.Point(455, 57);
            this.TxtOtherInfo.Multiline = true;
            this.TxtOtherInfo.Name = "TxtOtherInfo";
            this.TxtOtherInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtOtherInfo.Size = new System.Drawing.Size(432, 146);
            this.TxtOtherInfo.TabIndex = 22;
            // 
            // TxtPreviousLetterDate
            // 
            this.TxtPreviousLetterDate.Location = new System.Drawing.Point(195, 187);
            this.TxtPreviousLetterDate.Name = "TxtPreviousLetterDate";
            this.TxtPreviousLetterDate.Size = new System.Drawing.Size(224, 24);
            this.TxtPreviousLetterDate.TabIndex = 19;
            this.TxtPreviousLetterDate.TextChanged += new System.EventHandler(this.TxtPreviousLetterDate_TextChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(16, 190);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(152, 18);
            this.label34.TabIndex = 18;
            this.label34.Text = "Date of previous letter";
            // 
            // TxtPrevLetterRef
            // 
            this.TxtPrevLetterRef.Location = new System.Drawing.Point(195, 227);
            this.TxtPrevLetterRef.Name = "TxtPrevLetterRef";
            this.TxtPrevLetterRef.Size = new System.Drawing.Size(224, 24);
            this.TxtPrevLetterRef.TabIndex = 17;
            this.TxtPrevLetterRef.TextChanged += new System.EventHandler(this.TxtPrevLetterRef_TextChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(16, 230);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(173, 18);
            this.label33.TabIndex = 16;
            this.label33.Text = "Ref. no. of previous letter";
            // 
            // TxtLetterSignedby
            // 
            this.TxtLetterSignedby.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtLetterSignedby.Location = new System.Drawing.Point(86, 263);
            this.TxtLetterSignedby.Multiline = true;
            this.TxtLetterSignedby.Name = "TxtLetterSignedby";
            this.TxtLetterSignedby.Size = new System.Drawing.Size(333, 69);
            this.TxtLetterSignedby.TabIndex = 15;
            this.TxtLetterSignedby.Text = ".....................................\r\nEr. \r\nCheif, CED";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label32.Location = new System.Drawing.Point(8, 263);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(72, 18);
            this.label32.TabIndex = 14;
            this.label32.Text = "Signed by";
            // 
            // TxtLetterCC
            // 
            this.TxtLetterCC.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtLetterCC.Location = new System.Drawing.Point(86, 347);
            this.TxtLetterCC.Multiline = true;
            this.TxtLetterCC.Name = "TxtLetterCC";
            this.TxtLetterCC.Size = new System.Drawing.Size(333, 71);
            this.TxtLetterCC.TabIndex = 13;
            this.TxtLetterCC.Text = "1. GM, GBIACAO";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label31.Location = new System.Drawing.Point(35, 350);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(34, 18);
            this.label31.TabIndex = 12;
            this.label31.Text = "CC:";
            // 
            // TxtLetterSubject
            // 
            this.TxtLetterSubject.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtLetterSubject.Location = new System.Drawing.Point(86, 146);
            this.TxtLetterSubject.Name = "TxtLetterSubject";
            this.TxtLetterSubject.Size = new System.Drawing.Size(333, 24);
            this.TxtLetterSubject.TabIndex = 11;
            this.TxtLetterSubject.Text = "Regarding consent for building construction";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label30.Location = new System.Drawing.Point(8, 149);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(61, 18);
            this.label30.TabIndex = 10;
            this.label30.Text = "Subject:";
            // 
            // TxtLetterTo
            // 
            this.TxtLetterTo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtLetterTo.Location = new System.Drawing.Point(86, 54);
            this.TxtLetterTo.Multiline = true;
            this.TxtLetterTo.Name = "TxtLetterTo";
            this.TxtLetterTo.Size = new System.Drawing.Size(333, 86);
            this.TxtLetterTo.TabIndex = 9;
            this.TxtLetterTo.Text = "...............................Municipality\r\nRupandehi, Lumbini Province\r\nNepal";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label29.Location = new System.Drawing.Point(22, 54);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(26, 18);
            this.label29.TabIndex = 8;
            this.label29.Text = "To";
            // 
            // TxtLetterDate
            // 
            this.TxtLetterDate.Location = new System.Drawing.Point(86, 24);
            this.TxtLetterDate.Name = "TxtLetterDate";
            this.TxtLetterDate.Size = new System.Drawing.Size(333, 24);
            this.TxtLetterDate.TabIndex = 7;
            this.TxtLetterDate.TextChanged += new System.EventHandler(this.TxtLetterDate_TextChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(16, 27);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 18);
            this.label28.TabIndex = 6;
            this.label28.Text = "Date:-";
            // 
            // TabLetterPreview
            // 
            this.TabLetterPreview.Controls.Add(this.BtnToWord);
            this.TabLetterPreview.Controls.Add(this.RichTxtLetters);
            this.TabLetterPreview.Controls.Add(this.TxtDocumentRequired);
            this.TabLetterPreview.Controls.Add(this.label35);
            this.TabLetterPreview.Location = new System.Drawing.Point(4, 25);
            this.TabLetterPreview.Name = "TabLetterPreview";
            this.TabLetterPreview.Padding = new System.Windows.Forms.Padding(3);
            this.TabLetterPreview.Size = new System.Drawing.Size(1338, 441);
            this.TabLetterPreview.TabIndex = 5;
            this.TabLetterPreview.Text = "English Letter Preview";
            this.TabLetterPreview.UseVisualStyleBackColor = true;
            // 
            // BtnToWord
            // 
            this.BtnToWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnToWord.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnToWord.FlatAppearance.BorderSize = 0;
            this.BtnToWord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnToWord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnToWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnToWord.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnToWord.ForeColor = System.Drawing.Color.White;
            this.BtnToWord.Location = new System.Drawing.Point(788, 319);
            this.BtnToWord.Name = "BtnToWord";
            this.BtnToWord.Size = new System.Drawing.Size(537, 42);
            this.BtnToWord.TabIndex = 22;
            this.BtnToWord.Text = "English letter To word File";
            this.BtnToWord.UseVisualStyleBackColor = false;
            this.BtnToWord.Click += new System.EventHandler(this.BtnToWord_Click);
            // 
            // RichTxtLetters
            // 
            this.RichTxtLetters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTxtLetters.Location = new System.Drawing.Point(6, 6);
            this.RichTxtLetters.Name = "RichTxtLetters";
            this.RichTxtLetters.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.RichTxtLetters.Size = new System.Drawing.Size(756, 405);
            this.RichTxtLetters.TabIndex = 0;
            this.RichTxtLetters.Text = "";
            // 
            // TxtDocumentRequired
            // 
            this.TxtDocumentRequired.BackColor = System.Drawing.Color.Thistle;
            this.TxtDocumentRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDocumentRequired.Location = new System.Drawing.Point(788, 84);
            this.TxtDocumentRequired.Multiline = true;
            this.TxtDocumentRequired.Name = "TxtDocumentRequired";
            this.TxtDocumentRequired.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtDocumentRequired.Size = new System.Drawing.Size(537, 217);
            this.TxtDocumentRequired.TabIndex = 21;
            this.TxtDocumentRequired.Text = resources.GetString("TxtDocumentRequired.Text");
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.SeaGreen;
            this.label35.Location = new System.Drawing.Point(975, 52);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(153, 20);
            this.label35.TabIndex = 20;
            this.label35.Text = "Documents required";
            // 
            // TabCalculationDetail
            // 
            this.TabCalculationDetail.Controls.Add(this.groupBox8);
            this.TabCalculationDetail.Controls.Add(this.label49);
            this.TabCalculationDetail.Controls.Add(this.dataGridView4);
            this.TabCalculationDetail.Controls.Add(this.TxtCalculationDetail);
            this.TabCalculationDetail.Controls.Add(this.label37);
            this.TabCalculationDetail.Location = new System.Drawing.Point(4, 25);
            this.TabCalculationDetail.Name = "TabCalculationDetail";
            this.TabCalculationDetail.Padding = new System.Windows.Forms.Padding(3);
            this.TabCalculationDetail.Size = new System.Drawing.Size(1338, 441);
            this.TabCalculationDetail.TabIndex = 6;
            this.TabCalculationDetail.Text = "Calculation Detail";
            this.TabCalculationDetail.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.TxtCM);
            this.groupBox8.Controls.Add(this.label50);
            this.groupBox8.Controls.Add(this.TxtElev_allow);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Controls.Add(this.TxtSurfaceHeightaboveRWY);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.TxtSurfaceName);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.TxtRL_RWY);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(19, 309);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1303, 113);
            this.groupBox8.TabIndex = 11;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Allowable Elevation";
            // 
            // TxtCM
            // 
            this.TxtCM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCM.Location = new System.Drawing.Point(1160, 68);
            this.TxtCM.Name = "TxtCM";
            this.TxtCM.Size = new System.Drawing.Size(99, 26);
            this.TxtCM.TabIndex = 9;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.DarkViolet;
            this.label50.Location = new System.Drawing.Point(951, 71);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(203, 20);
            this.label50.TabIndex = 8;
            this.label50.Text = "Central Reference Meridian";
            // 
            // TxtElev_allow
            // 
            this.TxtElev_allow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtElev_allow.Location = new System.Drawing.Point(1021, 34);
            this.TxtElev_allow.Name = "TxtElev_allow";
            this.TxtElev_allow.Size = new System.Drawing.Size(240, 26);
            this.TxtElev_allow.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.DarkViolet;
            this.label18.Location = new System.Drawing.Point(798, 37);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(198, 20);
            this.label18.TabIndex = 6;
            this.label18.Text = "Elevation allowable (AMSL)";
            // 
            // TxtSurfaceHeightaboveRWY
            // 
            this.TxtSurfaceHeightaboveRWY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSurfaceHeightaboveRWY.Location = new System.Drawing.Point(605, 34);
            this.TxtSurfaceHeightaboveRWY.Name = "TxtSurfaceHeightaboveRWY";
            this.TxtSurfaceHeightaboveRWY.Size = new System.Drawing.Size(175, 26);
            this.TxtSurfaceHeightaboveRWY.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.DarkViolet;
            this.label15.Location = new System.Drawing.Point(391, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(195, 20);
            this.label15.TabIndex = 4;
            this.label15.Text = "Surface height above RWY";
            // 
            // TxtSurfaceName
            // 
            this.TxtSurfaceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSurfaceName.Location = new System.Drawing.Point(158, 65);
            this.TxtSurfaceName.Name = "TxtSurfaceName";
            this.TxtSurfaceName.Size = new System.Drawing.Size(787, 26);
            this.TxtSurfaceName.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.DarkViolet;
            this.label16.Location = new System.Drawing.Point(73, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 20);
            this.label16.TabIndex = 2;
            this.label16.Text = "Surface";
            // 
            // TxtRL_RWY
            // 
            this.TxtRL_RWY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRL_RWY.Location = new System.Drawing.Point(158, 31);
            this.TxtRL_RWY.Name = "TxtRL_RWY";
            this.TxtRL_RWY.Size = new System.Drawing.Size(229, 26);
            this.TxtRL_RWY.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.DarkViolet;
            this.label17.Location = new System.Drawing.Point(7, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(142, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "RL of RWY (AMSL)";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Teal;
            this.label49.Location = new System.Drawing.Point(17, 17);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(465, 20);
            this.label49.TabIndex = 28;
            this.label49.Text = "Calculation detail of all the surfaces under which the obstalce lies";
            // 
            // dataGridView4
            // 
            this.dataGridView4.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCalcSN,
            this.ColCalcSurfaceName,
            this.ColCalcSurfaceHeight,
            this.ColCalcRL,
            this.ColCalculation});
            this.dataGridView4.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridView4.Location = new System.Drawing.Point(19, 40);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(1289, 198);
            this.dataGridView4.TabIndex = 23;
            // 
            // ColCalcSN
            // 
            this.ColCalcSN.HeaderText = "SN";
            this.ColCalcSN.Name = "ColCalcSN";
            this.ColCalcSN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCalcSN.Width = 50;
            // 
            // ColCalcSurfaceName
            // 
            this.ColCalcSurfaceName.HeaderText = "Surface Name";
            this.ColCalcSurfaceName.Name = "ColCalcSurfaceName";
            this.ColCalcSurfaceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCalcSurfaceName.Width = 300;
            // 
            // ColCalcSurfaceHeight
            // 
            this.ColCalcSurfaceHeight.HeaderText = "Surface Height";
            this.ColCalcSurfaceHeight.Name = "ColCalcSurfaceHeight";
            this.ColCalcSurfaceHeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCalcSurfaceHeight.Width = 150;
            // 
            // ColCalcRL
            // 
            this.ColCalcRL.HeaderText = "RL of Surface";
            this.ColCalcRL.Name = "ColCalcRL";
            this.ColCalcRL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCalcRL.Width = 225;
            // 
            // ColCalculation
            // 
            this.ColCalculation.HeaderText = "Calculation";
            this.ColCalculation.Name = "ColCalculation";
            this.ColCalculation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCalculation.Width = 500;
            // 
            // TxtCalculationDetail
            // 
            this.TxtCalculationDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCalculationDetail.Location = new System.Drawing.Point(262, 244);
            this.TxtCalculationDetail.Multiline = true;
            this.TxtCalculationDetail.Name = "TxtCalculationDetail";
            this.TxtCalculationDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtCalculationDetail.Size = new System.Drawing.Size(1046, 39);
            this.TxtCalculationDetail.TabIndex = 26;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.Teal;
            this.label37.Location = new System.Drawing.Point(29, 263);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(227, 20);
            this.label37.TabIndex = 27;
            this.label37.Text = "Final Surface Calculation detail";
            // 
            // TabRWYClassify
            // 
            this.TabRWYClassify.Controls.Add(this.groupBox12);
            this.TabRWYClassify.Location = new System.Drawing.Point(4, 25);
            this.TabRWYClassify.Name = "TabRWYClassify";
            this.TabRWYClassify.Size = new System.Drawing.Size(1338, 441);
            this.TabRWYClassify.TabIndex = 7;
            this.TabRWYClassify.Text = "RWY Classification";
            this.TabRWYClassify.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.dataGridView5);
            this.groupBox12.Location = new System.Drawing.Point(19, 15);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(689, 403);
            this.groupBox12.TabIndex = 10;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Runway Coordinates";
            // 
            // dataGridView5
            // 
            this.dataGridView5.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSN,
            this.ColSurface,
            this.ColDimension});
            this.dataGridView5.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView5.Location = new System.Drawing.Point(6, 27);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(662, 356);
            this.dataGridView5.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.TabMenu);
            this.tabControl2.Controls.Add(this.TabFilter);
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(12, 532);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1346, 169);
            this.tabControl2.TabIndex = 1;
            // 
            // TabMenu
            // 
            this.TabMenu.Controls.Add(this.BtnOpenFolder);
            this.TabMenu.Controls.Add(this.BtnAutoProcess);
            this.TabMenu.Controls.Add(this.BtnDisplay);
            this.TabMenu.Controls.Add(this.groupBox10);
            this.TabMenu.Controls.Add(this.BtnExit);
            this.TabMenu.Controls.Add(this.BtnAbout);
            this.TabMenu.Controls.Add(this.BtnDelete);
            this.TabMenu.Controls.Add(this.BtnModify);
            this.TabMenu.Controls.Add(this.BtnAdd);
            this.TabMenu.Controls.Add(this.BtnCalculate);
            this.TabMenu.Controls.Add(this.BtnExportToPDF);
            this.TabMenu.Location = new System.Drawing.Point(4, 25);
            this.TabMenu.Name = "TabMenu";
            this.TabMenu.Padding = new System.Windows.Forms.Padding(3);
            this.TabMenu.Size = new System.Drawing.Size(1338, 140);
            this.TabMenu.TabIndex = 0;
            this.TabMenu.Text = "Menu";
            this.TabMenu.UseVisualStyleBackColor = true;
            // 
            // BtnOpenFolder
            // 
            this.BtnOpenFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnOpenFolder.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnOpenFolder.FlatAppearance.BorderSize = 0;
            this.BtnOpenFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnOpenFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOpenFolder.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpenFolder.ForeColor = System.Drawing.Color.White;
            this.BtnOpenFolder.Location = new System.Drawing.Point(893, 78);
            this.BtnOpenFolder.Name = "BtnOpenFolder";
            this.BtnOpenFolder.Size = new System.Drawing.Size(210, 42);
            this.BtnOpenFolder.TabIndex = 26;
            this.BtnOpenFolder.Text = "Open Recent Folder";
            this.BtnOpenFolder.UseVisualStyleBackColor = false;
            this.BtnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
            // 
            // BtnAutoProcess
            // 
            this.BtnAutoProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnAutoProcess.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnAutoProcess.FlatAppearance.BorderSize = 0;
            this.BtnAutoProcess.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnAutoProcess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnAutoProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAutoProcess.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAutoProcess.ForeColor = System.Drawing.Color.White;
            this.BtnAutoProcess.Location = new System.Drawing.Point(893, 29);
            this.BtnAutoProcess.Name = "BtnAutoProcess";
            this.BtnAutoProcess.Size = new System.Drawing.Size(210, 42);
            this.BtnAutoProcess.TabIndex = 25;
            this.BtnAutoProcess.Text = "Auto Process";
            this.BtnAutoProcess.UseVisualStyleBackColor = false;
            this.BtnAutoProcess.Click += new System.EventHandler(this.BtnAutoProcess_Click);
            // 
            // BtnDisplay
            // 
            this.BtnDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnDisplay.Enabled = false;
            this.BtnDisplay.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnDisplay.FlatAppearance.BorderSize = 0;
            this.BtnDisplay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnDisplay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDisplay.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDisplay.ForeColor = System.Drawing.Color.White;
            this.BtnDisplay.Location = new System.Drawing.Point(237, 78);
            this.BtnDisplay.Name = "BtnDisplay";
            this.BtnDisplay.Size = new System.Drawing.Size(212, 42);
            this.BtnDisplay.TabIndex = 24;
            this.BtnDisplay.Text = "Display";
            this.BtnDisplay.UseVisualStyleBackColor = false;
            this.BtnDisplay.Click += new System.EventHandler(this.BtnDisplay_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.RadModify_del_display);
            this.groupBox10.Controls.Add(this.RadAdd);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.ForeColor = System.Drawing.Color.ForestGreen;
            this.groupBox10.Location = new System.Drawing.Point(1140, 17);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(185, 103);
            this.groupBox10.TabIndex = 23;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Choose Action";
            // 
            // RadModify_del_display
            // 
            this.RadModify_del_display.AutoSize = true;
            this.RadModify_del_display.ForeColor = System.Drawing.Color.Black;
            this.RadModify_del_display.Location = new System.Drawing.Point(2, 60);
            this.RadModify_del_display.Name = "RadModify_del_display";
            this.RadModify_del_display.Size = new System.Drawing.Size(187, 24);
            this.RadModify_del_display.TabIndex = 1;
            this.RadModify_del_display.Text = "Modify, Display, Delete";
            this.RadModify_del_display.UseVisualStyleBackColor = true;
            this.RadModify_del_display.CheckedChanged += new System.EventHandler(this.RadModify_del_display_CheckedChanged);
            // 
            // RadAdd
            // 
            this.RadAdd.AutoSize = true;
            this.RadAdd.Checked = true;
            this.RadAdd.ForeColor = System.Drawing.Color.Black;
            this.RadAdd.Location = new System.Drawing.Point(5, 30);
            this.RadAdd.Name = "RadAdd";
            this.RadAdd.Size = new System.Drawing.Size(56, 24);
            this.RadAdd.TabIndex = 0;
            this.RadAdd.TabStop = true;
            this.RadAdd.Text = "Add";
            this.RadAdd.UseVisualStyleBackColor = true;
            this.RadAdd.CheckedChanged += new System.EventHandler(this.RadAdd_CheckedChanged);
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
            this.BtnExit.Location = new System.Drawing.Point(675, 78);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(212, 42);
            this.BtnExit.TabIndex = 22;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnAbout.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnAbout.FlatAppearance.BorderSize = 0;
            this.BtnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAbout.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAbout.ForeColor = System.Drawing.Color.White;
            this.BtnAbout.Location = new System.Drawing.Point(675, 29);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(212, 42);
            this.BtnAbout.TabIndex = 21;
            this.BtnAbout.Text = "About";
            this.BtnAbout.UseVisualStyleBackColor = false;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnDelete.FlatAppearance.BorderSize = 0;
            this.BtnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(237, 29);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(212, 42);
            this.BtnDelete.TabIndex = 20;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnModify.Enabled = false;
            this.BtnModify.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnModify.FlatAppearance.BorderSize = 0;
            this.BtnModify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnModify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModify.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModify.ForeColor = System.Drawing.Color.White;
            this.BtnModify.Location = new System.Drawing.Point(19, 77);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(212, 42);
            this.BtnModify.TabIndex = 19;
            this.BtnModify.Text = "Modify";
            this.BtnModify.UseVisualStyleBackColor = false;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(19, 29);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(212, 42);
            this.BtnAdd.TabIndex = 18;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnCalculate
            // 
            this.BtnCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnCalculate.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnCalculate.FlatAppearance.BorderSize = 0;
            this.BtnCalculate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnCalculate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCalculate.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCalculate.ForeColor = System.Drawing.Color.White;
            this.BtnCalculate.Location = new System.Drawing.Point(455, 29);
            this.BtnCalculate.Name = "BtnCalculate";
            this.BtnCalculate.Size = new System.Drawing.Size(212, 42);
            this.BtnCalculate.TabIndex = 17;
            this.BtnCalculate.Text = "5. Calculate";
            this.BtnCalculate.UseVisualStyleBackColor = false;
            this.BtnCalculate.Click += new System.EventHandler(this.BtnCalculate_Click);
            // 
            // BtnExportToPDF
            // 
            this.BtnExportToPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnExportToPDF.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnExportToPDF.FlatAppearance.BorderSize = 0;
            this.BtnExportToPDF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnExportToPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnExportToPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportToPDF.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportToPDF.ForeColor = System.Drawing.Color.White;
            this.BtnExportToPDF.Location = new System.Drawing.Point(455, 78);
            this.BtnExportToPDF.Name = "BtnExportToPDF";
            this.BtnExportToPDF.Size = new System.Drawing.Size(212, 42);
            this.BtnExportToPDF.TabIndex = 16;
            this.BtnExportToPDF.Text = "6. Export to PDF";
            this.BtnExportToPDF.UseVisualStyleBackColor = false;
            this.BtnExportToPDF.Click += new System.EventHandler(this.BtnExportToPDF_Click);
            // 
            // TabFilter
            // 
            this.TabFilter.Controls.Add(this.RichTxtFilter);
            this.TabFilter.Controls.Add(this.BtnGreaterThan);
            this.TabFilter.Controls.Add(this.BtnLessThan);
            this.TabFilter.Controls.Add(this.BtnEqualTo);
            this.TabFilter.Controls.Add(this.BtnFilter);
            this.TabFilter.Controls.Add(this.BtnClear);
            this.TabFilter.Controls.Add(this.BtnOR);
            this.TabFilter.Controls.Add(this.BtnAnd);
            this.TabFilter.Controls.Add(this.ComboBoxDistinctVal1);
            this.TabFilter.Controls.Add(this.label39);
            this.TabFilter.Controls.Add(this.ComboBoxFilterBy1);
            this.TabFilter.Controls.Add(this.label38);
            this.TabFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabFilter.Location = new System.Drawing.Point(4, 25);
            this.TabFilter.Name = "TabFilter";
            this.TabFilter.Padding = new System.Windows.Forms.Padding(3);
            this.TabFilter.Size = new System.Drawing.Size(1338, 140);
            this.TabFilter.TabIndex = 1;
            this.TabFilter.Text = "Filter";
            this.TabFilter.UseVisualStyleBackColor = true;
            // 
            // RichTxtFilter
            // 
            this.RichTxtFilter.Location = new System.Drawing.Point(15, 75);
            this.RichTxtFilter.Name = "RichTxtFilter";
            this.RichTxtFilter.Size = new System.Drawing.Size(1300, 39);
            this.RichTxtFilter.TabIndex = 23;
            this.RichTxtFilter.Text = "";
            // 
            // BtnGreaterThan
            // 
            this.BtnGreaterThan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnGreaterThan.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnGreaterThan.FlatAppearance.BorderSize = 0;
            this.BtnGreaterThan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnGreaterThan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnGreaterThan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGreaterThan.ForeColor = System.Drawing.Color.White;
            this.BtnGreaterThan.Location = new System.Drawing.Point(483, 16);
            this.BtnGreaterThan.Name = "BtnGreaterThan";
            this.BtnGreaterThan.Size = new System.Drawing.Size(51, 42);
            this.BtnGreaterThan.TabIndex = 22;
            this.BtnGreaterThan.Text = ">";
            this.BtnGreaterThan.UseVisualStyleBackColor = false;
            this.BtnGreaterThan.Click += new System.EventHandler(this.BtnGreaterThan_Click);
            // 
            // BtnLessThan
            // 
            this.BtnLessThan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnLessThan.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnLessThan.FlatAppearance.BorderSize = 0;
            this.BtnLessThan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnLessThan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnLessThan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLessThan.ForeColor = System.Drawing.Color.White;
            this.BtnLessThan.Location = new System.Drawing.Point(411, 16);
            this.BtnLessThan.Name = "BtnLessThan";
            this.BtnLessThan.Size = new System.Drawing.Size(51, 42);
            this.BtnLessThan.TabIndex = 21;
            this.BtnLessThan.Text = "<";
            this.BtnLessThan.UseVisualStyleBackColor = false;
            this.BtnLessThan.Click += new System.EventHandler(this.BtnLessThan_Click);
            // 
            // BtnEqualTo
            // 
            this.BtnEqualTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(19)))), ((int)(((byte)(71)))));
            this.BtnEqualTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnEqualTo.FlatAppearance.BorderSize = 0;
            this.BtnEqualTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(10)))), ((int)(((byte)(57)))));
            this.BtnEqualTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(39)))), ((int)(((byte)(96)))));
            this.BtnEqualTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEqualTo.ForeColor = System.Drawing.Color.White;
            this.BtnEqualTo.Location = new System.Drawing.Point(337, 16);
            this.BtnEqualTo.Name = "BtnEqualTo";
            this.BtnEqualTo.Size = new System.Drawing.Size(54, 42);
            this.BtnEqualTo.TabIndex = 20;
            this.BtnEqualTo.Text = "=";
            this.BtnEqualTo.UseVisualStyleBackColor = false;
            this.BtnEqualTo.Click += new System.EventHandler(this.BtnEqualTo_Click);
            // 
            // BtnFilter
            // 
            this.BtnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnFilter.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnFilter.FlatAppearance.BorderSize = 0;
            this.BtnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFilter.ForeColor = System.Drawing.Color.White;
            this.BtnFilter.Location = new System.Drawing.Point(1217, 15);
            this.BtnFilter.Name = "BtnFilter";
            this.BtnFilter.Size = new System.Drawing.Size(100, 42);
            this.BtnFilter.TabIndex = 19;
            this.BtnFilter.Text = "FILTER";
            this.BtnFilter.UseVisualStyleBackColor = false;
            this.BtnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(134)))), ((int)(((byte)(230)))));
            this.BtnClear.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnClear.FlatAppearance.BorderSize = 0;
            this.BtnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
            this.BtnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(164)))), ((int)(((byte)(242)))));
            this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClear.ForeColor = System.Drawing.Color.White;
            this.BtnClear.Location = new System.Drawing.Point(1110, 15);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(100, 42);
            this.BtnClear.TabIndex = 18;
            this.BtnClear.Text = "CLEAR";
            this.BtnClear.UseVisualStyleBackColor = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnOR
            // 
            this.BtnOR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.BtnOR.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnOR.FlatAppearance.BorderSize = 0;
            this.BtnOR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(117)))), ((int)(((byte)(64)))));
            this.BtnOR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(191)))), ((int)(((byte)(111)))));
            this.BtnOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOR.ForeColor = System.Drawing.Color.White;
            this.BtnOR.Location = new System.Drawing.Point(1004, 15);
            this.BtnOR.Name = "BtnOR";
            this.BtnOR.Size = new System.Drawing.Size(100, 42);
            this.BtnOR.TabIndex = 17;
            this.BtnOR.Text = "OR";
            this.BtnOR.UseVisualStyleBackColor = false;
            this.BtnOR.Click += new System.EventHandler(this.BtnOR_Click);
            // 
            // BtnAnd
            // 
            this.BtnAnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.BtnAnd.FlatAppearance.BorderColor = System.Drawing.Color.DarkViolet;
            this.BtnAnd.FlatAppearance.BorderSize = 0;
            this.BtnAnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(117)))), ((int)(((byte)(64)))));
            this.BtnAnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(191)))), ((int)(((byte)(111)))));
            this.BtnAnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAnd.ForeColor = System.Drawing.Color.White;
            this.BtnAnd.Location = new System.Drawing.Point(898, 15);
            this.BtnAnd.Name = "BtnAnd";
            this.BtnAnd.Size = new System.Drawing.Size(100, 42);
            this.BtnAnd.TabIndex = 16;
            this.BtnAnd.Text = "AND";
            this.BtnAnd.UseVisualStyleBackColor = false;
            this.BtnAnd.Click += new System.EventHandler(this.BtnAnd_Click);
            // 
            // ComboBoxDistinctVal1
            // 
            this.ComboBoxDistinctVal1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDistinctVal1.FormattingEnabled = true;
            this.ComboBoxDistinctVal1.Location = new System.Drawing.Point(558, 33);
            this.ComboBoxDistinctVal1.Name = "ComboBoxDistinctVal1";
            this.ComboBoxDistinctVal1.Size = new System.Drawing.Size(308, 26);
            this.ComboBoxDistinctVal1.TabIndex = 15;
            this.ComboBoxDistinctVal1.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDistinctVal1_SelectedIndexChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(558, 13);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(105, 18);
            this.label39.TabIndex = 14;
            this.label39.Text = "Distinct Values";
            // 
            // ComboBoxFilterBy1
            // 
            this.ComboBoxFilterBy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFilterBy1.FormattingEnabled = true;
            this.ComboBoxFilterBy1.Location = new System.Drawing.Point(15, 34);
            this.ComboBoxFilterBy1.Name = "ComboBoxFilterBy1";
            this.ComboBoxFilterBy1.Size = new System.Drawing.Size(308, 26);
            this.ComboBoxFilterBy1.TabIndex = 13;
            this.ComboBoxFilterBy1.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFilterBy1_SelectedIndexChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(23, 11);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(169, 18);
            this.label38.TabIndex = 11;
            this.label38.Text = "Filter by (Column Name)";
            // 
            // TxtLog
            // 
            this.TxtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLog.ForeColor = System.Drawing.Color.Blue;
            this.TxtLog.Location = new System.Drawing.Point(116, 497);
            this.TxtLog.Multiline = true;
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtLog.Size = new System.Drawing.Size(450, 45);
            this.TxtLog.TabIndex = 2;
            // 
            // TxtRecentFolderLocation
            // 
            this.TxtRecentFolderLocation.BackColor = System.Drawing.Color.MistyRose;
            this.TxtRecentFolderLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRecentFolderLocation.Location = new System.Drawing.Point(818, 497);
            this.TxtRecentFolderLocation.Multiline = true;
            this.TxtRecentFolderLocation.Name = "TxtRecentFolderLocation";
            this.TxtRecentFolderLocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtRecentFolderLocation.Size = new System.Drawing.Size(539, 45);
            this.TxtRecentFolderLocation.TabIndex = 11;
            // 
            // PanelBack
            // 
            this.PanelBack.Controls.Add(this.PanelFore);
            this.PanelBack.Location = new System.Drawing.Point(572, 497);
            this.PanelBack.Name = "PanelBack";
            this.PanelBack.Size = new System.Drawing.Size(180, 45);
            this.PanelBack.TabIndex = 12;
            // 
            // PanelFore
            // 
            this.PanelFore.Location = new System.Drawing.Point(0, 0);
            this.PanelFore.Name = "PanelFore";
            this.PanelFore.Size = new System.Drawing.Size(0, 45);
            this.PanelFore.TabIndex = 0;
            this.PanelFore.SizeChanged += new System.EventHandler(this.PanelFore_SizeChanged);
            // 
            // LblProgress
            // 
            this.LblProgress.AutoSize = true;
            this.LblProgress.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProgress.Location = new System.Drawing.Point(758, 511);
            this.LblProgress.Name = "LblProgress";
            this.LblProgress.Size = new System.Drawing.Size(34, 18);
            this.LblProgress.TabIndex = 1;
            this.LblProgress.Text = "0%";
            // 
            // ColSN
            // 
            this.ColSN.HeaderText = "SN";
            this.ColSN.Name = "ColSN";
            // 
            // ColSurface
            // 
            this.ColSurface.HeaderText = "Surface";
            this.ColSurface.Name = "ColSurface";
            this.ColSurface.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSurface.Width = 300;
            // 
            // ColDimension
            // 
            this.ColDimension.HeaderText = "Dimension";
            this.ColDimension.Name = "ColDimension";
            this.ColDimension.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDimension.Width = 200;
            // 
            // FrmObstacleHeightCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.LblProgress);
            this.Controls.Add(this.PanelBack);
            this.Controls.Add(this.TxtRecentFolderLocation);
            this.Controls.Add(this.TxtLog);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmObstacleHeightCalculation";
            this.Text = "CSAY Obstacle Height Calculation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabLoadAllRecord.ResumeLayout(false);
            this.TabLoadAllRecord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.TabRWYEq.ResumeLayout(false);
            this.TabRWYEq.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.TabObstacleHeightCalculation.ResumeLayout(false);
            this.TabObstacleHeightCalculation.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.TabGeneral.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.TabLetter.ResumeLayout(false);
            this.TabLetter.PerformLayout();
            this.TabLetterPreview.ResumeLayout(false);
            this.TabLetterPreview.PerformLayout();
            this.TabCalculationDetail.ResumeLayout(false);
            this.TabCalculationDetail.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.TabRWYClassify.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.TabMenu.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.TabFilter.ResumeLayout(false);
            this.TabFilter.PerformLayout();
            this.PanelBack.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabLoadAllRecord;
        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.TabPage TabObstacleHeightCalculation;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage TabMenu;
        private System.Windows.Forms.TabPage TabFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtMiddleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox ComboBoxObstacleType;
        private System.Windows.Forms.ComboBox ComboBoxFY;
        private System.Windows.Forms.TextBox TxtObstacleType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtFY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtPlotNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtTole;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtWardNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtLocalLevel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox ComboBoxRWY;
        private System.Windows.Forms.TextBox TxtAirportCode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button BtnLoadRWYCoord;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button BtnCreateMap;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtLong1;
        private System.Windows.Forms.TextBox TxtLat1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtLong2;
        private System.Windows.Forms.TextBox TxtLat2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLatitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLongitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEasting;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNorthing;
        private System.Windows.Forms.Button BtnExportToKML;
        private System.Windows.Forms.Button BtnSaveMap;
        private System.Windows.Forms.TextBox TxtLog;
        private System.Windows.Forms.TabPage TabRWYEq;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSlope;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIntercept;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDistance;
        private GMap.NET.WindowsForms.GMapControl gMapControl2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox ComboBoxLocalLevel;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox TxtElev_allow;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TxtSurfaceHeightaboveRWY;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TxtSurfaceName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TxtRL_RWY;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button BtnExportToPDF;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox TxtElev_Permitted;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox TxtElev_Obstacle;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TxtHeightAbovePlinth;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox TxtRL_Plinth;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button BtnCalculate;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox TxtArealDistance;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox TxtPlotCase;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TabPage TabLetter;
        private System.Windows.Forms.TextBox TxtLetterSignedby;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox TxtLetterCC;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox TxtLetterSubject;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox TxtLetterTo;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox TxtLetterDate;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox TxtPreviousLetterDate;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox TxtPrevLetterRef;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox TxtDocumentRequired;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button BtnDisplay;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RadioButton RadModify_del_display;
        private System.Windows.Forms.RadioButton RadAdd;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnAbout;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnModify;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label lable36;
        private System.Windows.Forms.TextBox TxtOtherInfo;
        private System.Windows.Forms.Label LblLoad;
        private System.Windows.Forms.Button BtnLoadAllRecord;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label LblRecordNo;
        private System.Windows.Forms.Button BtnAutoProcess;
        private System.Windows.Forms.Button BtnOpenFolder;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox TxtTitleOfReport;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox TxtCalculationDetail;
        private System.Windows.Forms.Button BtnFilter;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnOR;
        private System.Windows.Forms.Button BtnAnd;
        private System.Windows.Forms.ComboBox ComboBoxDistinctVal1;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox ComboBoxFilterBy1;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button BtnGreaterThan;
        private System.Windows.Forms.Button BtnLessThan;
        private System.Windows.Forms.Button BtnEqualTo;
        private System.Windows.Forms.RichTextBox RichTxtFilter;
        private System.Windows.Forms.Button BtnExportRecordToExcel;
        private System.Windows.Forms.CheckBox ChkBoxAutoFitMap;
        private System.Windows.Forms.ComboBox ComboBoxDesignation;
        private System.Windows.Forms.TextBox TxtDesignation;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox TxtRecentFolderLocation;
        private System.Windows.Forms.TabPage TabLetterPreview;
        private System.Windows.Forms.RichTextBox RichTxtLetters;
        private System.Windows.Forms.Button BtnPreviewLetter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportRWYCOORDToExcelToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem exportLineParameterToExcelToolStripMenuItem;
        private System.Windows.Forms.Button BtnToWord;
        private System.Windows.Forms.TextBox TxtPrevLetterRefNepali;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox TxtPrevLetterNepaliDate;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox TxtLetterNepaliDate;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Button BtnCreateNepaliLetter;
        private System.Windows.Forms.TextBox TxtNepaliPlotNo;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox TxtNepaliElevation;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox TxtNepaliWardNo;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox TxtNepaliLocalLevel;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Button BtnCreateNepaliTippani;
        private System.Windows.Forms.Panel PanelBack;
        private System.Windows.Forms.Panel PanelFore;
        private System.Windows.Forms.Label LblProgress;
        private System.Windows.Forms.TabPage TabCalculationDetail;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCalcSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCalcSurfaceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCalcSurfaceHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCalcRL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCalculation;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Button BtnZoomToFit;
        private System.Windows.Forms.Button BtnZoomToFit2;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.CheckBox ChkBoxBalkedlanding;
        private System.Windows.Forms.CheckBox ChkBoxTransition;
        private System.Windows.Forms.CheckBox ChkBoxTakeoffclimb;
        private System.Windows.Forms.CheckBox ChkBoxApproach;
        private System.Windows.Forms.CheckBox ChkBoxConical;
        private System.Windows.Forms.CheckBox ChkBoxHorizontal;
        private System.Windows.Forms.Button BtnDeselectAll;
        private System.Windows.Forms.Button BtnSelectAll;
        private System.Windows.Forms.TextBox TxtCM;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.CheckBox ChkBoxInnerTrans;
        private System.Windows.Forms.CheckBox ChkBoxInnerApproach;
        private System.Windows.Forms.CheckBox ChkBoxOuterHorizontal;
        private System.Windows.Forms.TabPage TabRWYClassify;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.TextBox TxtRWYClassify;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSurface;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDimension;
    }
}

