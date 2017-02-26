namespace ReportProblem
{
    partial class Statistics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics));
            this.gvProblem = new System.Windows.Forms.DataGridView();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportProblemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportOTDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cấuHìnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetupEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProblemSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EquipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbbLine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbStatus = new System.Windows.Forms.ComboBox();
            this.cbbChartType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNotiWait = new System.Windows.Forms.Label();
            this.lblWaitValue = new System.Windows.Forms.Label();
            this.lblProcessingValue = new System.Windows.Forms.Label();
            this.lblFinishedValue = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblSumProblem = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkFinished = new System.Windows.Forms.CheckBox();
            this.chkProcessing = new System.Windows.Forms.CheckBox();
            this.chkWait = new System.Windows.Forms.CheckBox();
            this.gbSwitchUser = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pwdPass = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnFinished = new System.Windows.Forms.Button();
            this.btnProcessing = new System.Windows.Forms.Button();
            this.cbSendMail = new System.Windows.Forms.CheckBox();
            this.btnSwitchUser = new System.Windows.Forms.Button();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvProblem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbSwitchUser.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvProblem
            // 
            this.gvProblem.AllowUserToAddRows = false;
            this.gvProblem.AllowUserToDeleteRows = false;
            this.gvProblem.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvProblem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvProblem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvProblem.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvProblem.GridColor = System.Drawing.SystemColors.Control;
            this.gvProblem.Location = new System.Drawing.Point(12, 129);
            this.gvProblem.Name = "gvProblem";
            this.gvProblem.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvProblem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvProblem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProblem.Size = new System.Drawing.Size(1222, 397);
            this.gvProblem.TabIndex = 0;
            this.gvProblem.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvProblem_CellContentDoubleClick);
            this.gvProblem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvProblem_CellFormatting);
            this.gvProblem.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gvProblem_RowStateChanged);
            this.gvProblem.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gvProblem_UserDeletingRow);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(183, 18);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(46, 13);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "Từ ngày";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(183, 50);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(53, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "Đến ngày";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(243, 15);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(183, 20);
            this.dtpFrom.TabIndex = 0;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(243, 46);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(183, 20);
            this.dtpTo.TabIndex = 1;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // Chart1
            // 
            legend1.Name = "Legend1";
            this.Chart1.Legends.Add(legend1);
            this.Chart1.Location = new System.Drawing.Point(10, 559);
            this.Chart1.Name = "Chart1";
            this.Chart1.Size = new System.Drawing.Size(1224, 171);
            this.Chart1.TabIndex = 9;
            this.Chart1.Text = "Chart1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngToolStripMenuItem,
            this.cấuHìnhToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1246, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatisticsToolStripMenuItem,
            this.ReportProblemToolStripMenuItem,
            this.reportOTDToolStripMenuItem,
            this.ExportExcelToolStripMenuItem,
            this.CloseToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // StatisticsToolStripMenuItem
            // 
            this.StatisticsToolStripMenuItem.Name = "StatisticsToolStripMenuItem";
            this.StatisticsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.StatisticsToolStripMenuItem.Text = "Xem thống kê";
            this.StatisticsToolStripMenuItem.Click += new System.EventHandler(this.StatisticsToolStripMenuItem_Click);
            // 
            // ReportProblemToolStripMenuItem
            // 
            this.ReportProblemToolStripMenuItem.Name = "ReportProblemToolStripMenuItem";
            this.ReportProblemToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ReportProblemToolStripMenuItem.Text = "Báo cáo sự cố";
            this.ReportProblemToolStripMenuItem.Click += new System.EventHandler(this.ReportProblemToolStripMenuItem_Click);
            // 
            // reportOTDToolStripMenuItem
            // 
            this.reportOTDToolStripMenuItem.Name = "reportOTDToolStripMenuItem";
            this.reportOTDToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.reportOTDToolStripMenuItem.Text = "ReportOTD";
            this.reportOTDToolStripMenuItem.Click += new System.EventHandler(this.reportOTDToolStripMenuItem_Click);
            // 
            // ExportExcelToolStripMenuItem
            // 
            this.ExportExcelToolStripMenuItem.Name = "ExportExcelToolStripMenuItem";
            this.ExportExcelToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ExportExcelToolStripMenuItem.Text = "Xuất Excel";
            this.ExportExcelToolStripMenuItem.Click += new System.EventHandler(this.ExportExcelToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CloseToolStripMenuItem.Text = "Đóng";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click_1);
            // 
            // cấuHìnhToolStripMenuItem
            // 
            this.cấuHìnhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetupEmailToolStripMenuItem,
            this.ProblemSetupToolStripMenuItem,
            this.AccountToolStripMenuItem,
            this.AddLineToolStripMenuItem,
            this.EquipToolStripMenuItem});
            this.cấuHìnhToolStripMenuItem.Name = "cấuHìnhToolStripMenuItem";
            this.cấuHìnhToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.cấuHìnhToolStripMenuItem.Text = "Cấu hình";
            // 
            // SetupEmailToolStripMenuItem
            // 
            this.SetupEmailToolStripMenuItem.Name = "SetupEmailToolStripMenuItem";
            this.SetupEmailToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.SetupEmailToolStripMenuItem.Text = "Cài đặt danh sách email";
            this.SetupEmailToolStripMenuItem.Click += new System.EventHandler(this.SetupEmailToolStripMenuItem_Click);
            // 
            // ProblemSetupToolStripMenuItem
            // 
            this.ProblemSetupToolStripMenuItem.Name = "ProblemSetupToolStripMenuItem";
            this.ProblemSetupToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.ProblemSetupToolStripMenuItem.Text = "Cài đặt sự cố";
            this.ProblemSetupToolStripMenuItem.Click += new System.EventHandler(this.ProblemSetupToolStripMenuItem_Click);
            // 
            // AccountToolStripMenuItem
            // 
            this.AccountToolStripMenuItem.Name = "AccountToolStripMenuItem";
            this.AccountToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.AccountToolStripMenuItem.Text = "Thông tin tài khoản";
            this.AccountToolStripMenuItem.Click += new System.EventHandler(this.AccountToolStripMenuItem_Click);
            // 
            // AddLineToolStripMenuItem
            // 
            this.AddLineToolStripMenuItem.Name = "AddLineToolStripMenuItem";
            this.AddLineToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.AddLineToolStripMenuItem.Text = "Cấu hình  Line";
            this.AddLineToolStripMenuItem.Click += new System.EventHandler(this.AddLineToolStripMenuItem_Click);
            // 
            // EquipToolStripMenuItem
            // 
            this.EquipToolStripMenuItem.Name = "EquipToolStripMenuItem";
            this.EquipToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.EquipToolStripMenuItem.Text = "Danh sách thiết bị";
            this.EquipToolStripMenuItem.Click += new System.EventHandler(this.EquipToolStripMenuItem_Click);
            // 
            // cbbLine
            // 
            this.cbbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLine.FormattingEnabled = true;
            this.cbbLine.Location = new System.Drawing.Point(84, 15);
            this.cbbLine.Name = "cbbLine";
            this.cbbLine.Size = new System.Drawing.Size(92, 21);
            this.cbbLine.TabIndex = 14;
            this.cbbLine.DropDownClosed += new System.EventHandler(this.cbbLine_DropDownClosed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Line";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbLine);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.lblFrom);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 96);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tùy chọn";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::ReportProblem.Properties.Resources.Excel_icon;
            this.btnExport.Location = new System.Drawing.Point(6, 71);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(65, 21);
            this.btnExport.TabIndex = 18;
            this.btnExport.Text = "Export";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Trạng thái";
            // 
            // cbbStatus
            // 
            this.cbbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Location = new System.Drawing.Point(84, 41);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(92, 21);
            this.cbbStatus.TabIndex = 16;
            this.cbbStatus.DropDownClosed += new System.EventHandler(this.cbbStatus_DropDownClosed);
            // 
            // cbbChartType
            // 
            this.cbbChartType.FormattingEnabled = true;
            this.cbbChartType.Location = new System.Drawing.Point(96, 532);
            this.cbbChartType.Name = "cbbChartType";
            this.cbbChartType.Size = new System.Drawing.Size(92, 21);
            this.cbbChartType.TabIndex = 19;
            this.cbbChartType.DropDownClosed += new System.EventHandler(this.cbbChartType_DropDownClosed);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 535);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Thống kê theo";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblNotiWait);
            this.groupBox3.Controls.Add(this.lblWaitValue);
            this.groupBox3.Controls.Add(this.lblProcessingValue);
            this.groupBox3.Controls.Add(this.lblFinishedValue);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.lblSumProblem);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.lblTime);
            this.groupBox3.Location = new System.Drawing.Point(738, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 96);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin chung";
            // 
            // lblNotiWait
            // 
            this.lblNotiWait.AutoSize = true;
            this.lblNotiWait.ForeColor = System.Drawing.Color.Red;
            this.lblNotiWait.Location = new System.Drawing.Point(340, 15);
            this.lblNotiWait.Name = "lblNotiWait";
            this.lblNotiWait.Size = new System.Drawing.Size(0, 13);
            this.lblNotiWait.TabIndex = 30;
            // 
            // lblWaitValue
            // 
            this.lblWaitValue.AutoSize = true;
            this.lblWaitValue.Location = new System.Drawing.Point(239, 15);
            this.lblWaitValue.Name = "lblWaitValue";
            this.lblWaitValue.Size = new System.Drawing.Size(56, 13);
            this.lblWaitValue.TabIndex = 29;
            this.lblWaitValue.Text = "Chưa xử lý";
            // 
            // lblProcessingValue
            // 
            this.lblProcessingValue.AutoSize = true;
            this.lblProcessingValue.Location = new System.Drawing.Point(239, 40);
            this.lblProcessingValue.Name = "lblProcessingValue";
            this.lblProcessingValue.Size = new System.Drawing.Size(57, 13);
            this.lblProcessingValue.TabIndex = 28;
            this.lblProcessingValue.Text = "Đang xử lý";
            // 
            // lblFinishedValue
            // 
            this.lblFinishedValue.AutoSize = true;
            this.lblFinishedValue.Location = new System.Drawing.Point(239, 70);
            this.lblFinishedValue.Name = "lblFinishedValue";
            this.lblFinishedValue.Size = new System.Drawing.Size(45, 13);
            this.lblFinishedValue.TabIndex = 27;
            this.lblFinishedValue.Text = "Đã xử lý";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Thời gian dừng";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(167, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Chưa xử lý";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(167, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Đang xử lý";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(173, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Đã xử lý";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Số sự cố";
            // 
            // lblSumProblem
            // 
            this.lblSumProblem.AutoSize = true;
            this.lblSumProblem.Location = new System.Drawing.Point(106, 40);
            this.lblSumProblem.Name = "lblSumProblem";
            this.lblSumProblem.Size = new System.Drawing.Size(49, 13);
            this.lblSumProblem.TabIndex = 21;
            this.lblSumProblem.Text = "Số sự cố";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Cập nhật thời gian";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(101, 18);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 13);
            this.lblTime.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkFinished);
            this.groupBox4.Controls.Add(this.chkProcessing);
            this.groupBox4.Controls.Add(this.chkWait);
            this.groupBox4.Location = new System.Drawing.Point(1048, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(186, 96);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Đèn tín hiệu";
            // 
            // chkFinished
            // 
            this.chkFinished.AutoSize = true;
            this.chkFinished.ForeColor = System.Drawing.Color.Green;
            this.chkFinished.Location = new System.Drawing.Point(18, 74);
            this.chkFinished.Name = "chkFinished";
            this.chkFinished.Size = new System.Drawing.Size(64, 17);
            this.chkFinished.TabIndex = 2;
            this.chkFinished.Text = "Đã xử lý";
            this.chkFinished.UseVisualStyleBackColor = true;
            // 
            // chkProcessing
            // 
            this.chkProcessing.AutoSize = true;
            this.chkProcessing.ForeColor = System.Drawing.Color.Goldenrod;
            this.chkProcessing.Location = new System.Drawing.Point(18, 54);
            this.chkProcessing.Name = "chkProcessing";
            this.chkProcessing.Size = new System.Drawing.Size(76, 17);
            this.chkProcessing.TabIndex = 1;
            this.chkProcessing.Text = "Đang xử lý";
            this.chkProcessing.UseVisualStyleBackColor = true;
            // 
            // chkWait
            // 
            this.chkWait.AutoSize = true;
            this.chkWait.ForeColor = System.Drawing.Color.Red;
            this.chkWait.Location = new System.Drawing.Point(18, 36);
            this.chkWait.Name = "chkWait";
            this.chkWait.Size = new System.Drawing.Size(75, 17);
            this.chkWait.TabIndex = 0;
            this.chkWait.Text = "Chưa xử lý";
            this.chkWait.UseVisualStyleBackColor = true;
            // 
            // gbSwitchUser
            // 
            this.gbSwitchUser.Controls.Add(this.label4);
            this.gbSwitchUser.Controls.Add(this.label3);
            this.gbSwitchUser.Controls.Add(this.pwdPass);
            this.gbSwitchUser.Controls.Add(this.txtCode);
            this.gbSwitchUser.Location = new System.Drawing.Point(454, 32);
            this.gbSwitchUser.Name = "gbSwitchUser";
            this.gbSwitchUser.Size = new System.Drawing.Size(278, 91);
            this.gbSwitchUser.TabIndex = 23;
            this.gbSwitchUser.TabStop = false;
            this.gbSwitchUser.Text = "Đổi user";
            this.gbSwitchUser.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mật khẩu";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã nhân viên";
            this.label3.Visible = false;
            // 
            // pwdPass
            // 
            this.pwdPass.Location = new System.Drawing.Point(102, 44);
            this.pwdPass.Name = "pwdPass";
            this.pwdPass.Size = new System.Drawing.Size(143, 20);
            this.pwdPass.TabIndex = 1;
            this.pwdPass.UseSystemPasswordChar = true;
            this.pwdPass.Visible = false;
            this.pwdPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pwdPass_KeyDown);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(102, 13);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(143, 20);
            this.txtCode.TabIndex = 0;
            this.txtCode.Visible = false;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.OrangeRed;
            this.btnNew.Location = new System.Drawing.Point(3, 21);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(85, 38);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "Tạo mới sự cố (Chưa xử lý)";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnFinished
            // 
            this.btnFinished.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnFinished.Location = new System.Drawing.Point(185, 21);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(85, 38);
            this.btnFinished.TabIndex = 11;
            this.btnFinished.Text = "Đóng sự cố (Đã xử lý)";
            this.btnFinished.UseVisualStyleBackColor = false;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // btnProcessing
            // 
            this.btnProcessing.BackColor = System.Drawing.Color.Yellow;
            this.btnProcessing.Location = new System.Drawing.Point(94, 21);
            this.btnProcessing.Name = "btnProcessing";
            this.btnProcessing.Size = new System.Drawing.Size(85, 38);
            this.btnProcessing.TabIndex = 10;
            this.btnProcessing.Text = "Đang xử lý";
            this.btnProcessing.UseVisualStyleBackColor = false;
            this.btnProcessing.Click += new System.EventHandler(this.btnProcessing_Click);
            // 
            // cbSendMail
            // 
            this.cbSendMail.AutoSize = true;
            this.cbSendMail.Location = new System.Drawing.Point(6, 67);
            this.cbSendMail.Name = "cbSendMail";
            this.cbSendMail.Size = new System.Drawing.Size(63, 17);
            this.cbSendMail.TabIndex = 14;
            this.cbSendMail.Text = "Gửi mail";
            this.cbSendMail.UseVisualStyleBackColor = true;
            // 
            // btnSwitchUser
            // 
            this.btnSwitchUser.Location = new System.Drawing.Point(185, 65);
            this.btnSwitchUser.Name = "btnSwitchUser";
            this.btnSwitchUser.Size = new System.Drawing.Size(85, 29);
            this.btnSwitchUser.TabIndex = 15;
            this.btnSwitchUser.Text = "Đổi user";
            this.btnSwitchUser.UseVisualStyleBackColor = true;
            this.btnSwitchUser.Click += new System.EventHandler(this.btnSwitchUser_Click);
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.btnRemove);
            this.gbControl.Controls.Add(this.btnSwitchUser);
            this.gbControl.Controls.Add(this.cbSendMail);
            this.gbControl.Controls.Add(this.btnProcessing);
            this.gbControl.Controls.Add(this.btnFinished);
            this.gbControl.Controls.Add(this.btnNew);
            this.gbControl.Location = new System.Drawing.Point(454, 27);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(278, 96);
            this.gbControl.TabIndex = 17;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Điều khiển";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(94, 66);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(85, 29);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "Xóa sự cố";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1246, 742);
            this.Controls.Add(this.gbSwitchUser);
            this.Controls.Add(this.cbbChartType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Chart1);
            this.Controls.Add(this.gvProblem);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Statistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê thời gian dừng line | DownTime Record";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Statistics_FormClosed);
            this.Load += new System.EventHandler(this.Statistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvProblem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbSwitchUser.ResumeLayout(false);
            this.gbSwitchUser.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.gbControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvProblem;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportProblemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cấuHìnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetupEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProblemSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AccountToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbbLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbChartType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem AddLineToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblWaitValue;
        private System.Windows.Forms.Label lblProcessingValue;
        private System.Windows.Forms.Label lblFinishedValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblSumProblem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblNotiWait;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkFinished;
        private System.Windows.Forms.CheckBox chkProcessing;
        private System.Windows.Forms.CheckBox chkWait;
        private System.Windows.Forms.GroupBox gbSwitchUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pwdPass;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnFinished;
        private System.Windows.Forms.Button btnProcessing;
        private System.Windows.Forms.CheckBox cbSendMail;
        private System.Windows.Forms.Button btnSwitchUser;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ToolStripMenuItem EquipToolStripMenuItem;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ToolStripMenuItem ExportExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportOTDToolStripMenuItem;

    }
}