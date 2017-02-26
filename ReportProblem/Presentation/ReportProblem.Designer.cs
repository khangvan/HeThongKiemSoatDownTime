namespace ReportProblem
{
    partial class ReportProblem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportProblem));
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblProblem = new System.Windows.Forms.Label();
            this.cbbCategory = new System.Windows.Forms.ComboBox();
            this.cbbProblem = new System.Windows.Forms.ComboBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.rtbDes = new System.Windows.Forms.RichTextBox();
            this.lblCc = new System.Windows.Forms.Label();
            this.rtbTo = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbCc = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FunctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportProblemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LineSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProblemSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPO = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblLine = new System.Windows.Forms.Label();
            this.cbbLine = new System.Windows.Forms.ComboBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbEquipment = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRecord = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(9, 39);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(93, 18);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Nhóm sự cố";
            // 
            // lblProblem
            // 
            this.lblProblem.AutoSize = true;
            this.lblProblem.Location = new System.Drawing.Point(307, 42);
            this.lblProblem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProblem.Name = "lblProblem";
            this.lblProblem.Size = new System.Drawing.Size(51, 18);
            this.lblProblem.TabIndex = 2;
            this.lblProblem.Text = "Sự cố";
            this.lblProblem.Click += new System.EventHandler(this.lblProblem_Click);
            // 
            // cbbCategory
            // 
            this.cbbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCategory.FormattingEnabled = true;
            this.cbbCategory.Location = new System.Drawing.Point(133, 36);
            this.cbbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cbbCategory.Name = "cbbCategory";
            this.cbbCategory.Size = new System.Drawing.Size(164, 26);
            this.cbbCategory.TabIndex = 3;
            this.cbbCategory.SelectedIndexChanged += new System.EventHandler(this.cbbCategory_SelectedIndexChanged);
            this.cbbCategory.SelectionChangeCommitted += new System.EventHandler(this.cbbCategory_SelectionChangeCommitted);
            this.cbbCategory.DropDownClosed += new System.EventHandler(this.cbbCategory_DropDownClosed);
            // 
            // cbbProblem
            // 
            this.cbbProblem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProblem.FormattingEnabled = true;
            this.cbbProblem.Location = new System.Drawing.Point(463, 31);
            this.cbbProblem.Margin = new System.Windows.Forms.Padding(4);
            this.cbbProblem.Name = "cbbProblem";
            this.cbbProblem.Size = new System.Drawing.Size(611, 26);
            this.cbbProblem.TabIndex = 4;
            this.cbbProblem.SelectedIndexChanged += new System.EventHandler(this.cbbProblem_SelectedIndexChanged);
            this.cbbProblem.SelectionChangeCommitted += new System.EventHandler(this.cbbProblem_SelectionChangeCommitted);
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(293, 34);
            this.lblTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(51, 25);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "Đến";
            // 
            // rtbDes
            // 
            this.rtbDes.Location = new System.Drawing.Point(133, 143);
            this.rtbDes.Margin = new System.Windows.Forms.Padding(4);
            this.rtbDes.Name = "rtbDes";
            this.rtbDes.Size = new System.Drawing.Size(941, 34);
            this.rtbDes.TabIndex = 8;
            this.rtbDes.Text = "";
            // 
            // lblCc
            // 
            this.lblCc.AutoSize = true;
            this.lblCc.Location = new System.Drawing.Point(572, 31);
            this.lblCc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCc.Name = "lblCc";
            this.lblCc.Size = new System.Drawing.Size(30, 19);
            this.lblCc.TabIndex = 7;
            this.lblCc.Text = "Cc";
            // 
            // rtbTo
            // 
            this.rtbTo.Location = new System.Drawing.Point(341, 31);
            this.rtbTo.Margin = new System.Windows.Forms.Padding(4);
            this.rtbTo.Name = "rtbTo";
            this.rtbTo.Size = new System.Drawing.Size(223, 28);
            this.rtbTo.TabIndex = 1;
            this.rtbTo.Text = "";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(14, 146);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(94, 18);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Mô tả Sự cố";
            // 
            // rtbCc
            // 
            this.rtbCc.Location = new System.Drawing.Point(610, 26);
            this.rtbCc.Margin = new System.Windows.Forms.Padding(4);
            this.rtbCc.Name = "rtbCc";
            this.rtbCc.Size = new System.Drawing.Size(214, 33);
            this.rtbCc.TabIndex = 2;
            this.rtbCc.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(10, 345);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(187, 42);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Ghi nhận và Gửi BCSC";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Visible = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FunctionToolStripMenuItem,
            this.SettingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1114, 25);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FunctionToolStripMenuItem
            // 
            this.FunctionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReportProblemToolStripMenuItem,
            this.StatisticsToolStripMenuItem,
            this.CloseToolStripMenuItem});
            this.FunctionToolStripMenuItem.Name = "FunctionToolStripMenuItem";
            this.FunctionToolStripMenuItem.Size = new System.Drawing.Size(77, 19);
            this.FunctionToolStripMenuItem.Text = "Chức năng";
            // 
            // ReportProblemToolStripMenuItem
            // 
            this.ReportProblemToolStripMenuItem.Name = "ReportProblemToolStripMenuItem";
            this.ReportProblemToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ReportProblemToolStripMenuItem.Text = "Báo cáo sự cố";
            this.ReportProblemToolStripMenuItem.Click += new System.EventHandler(this.ReportProblemToolStripMenuItem_Click);
            // 
            // StatisticsToolStripMenuItem
            // 
            this.StatisticsToolStripMenuItem.Name = "StatisticsToolStripMenuItem";
            this.StatisticsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.StatisticsToolStripMenuItem.Text = "Xem thống kê";
            this.StatisticsToolStripMenuItem.Click += new System.EventHandler(this.StatisticsToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CloseToolStripMenuItem.Text = "Đóng";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // SettingToolStripMenuItem
            // 
            this.SettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LineSettingToolStripMenuItem,
            this.ProblemSetupToolStripMenuItem,
            this.AccountToolStripMenuItem});
            this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            this.SettingToolStripMenuItem.Size = new System.Drawing.Size(67, 19);
            this.SettingToolStripMenuItem.Text = "Cấu hình";
            // 
            // LineSettingToolStripMenuItem
            // 
            this.LineSettingToolStripMenuItem.Name = "LineSettingToolStripMenuItem";
            this.LineSettingToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.LineSettingToolStripMenuItem.Text = "Cấu hình";
            this.LineSettingToolStripMenuItem.Click += new System.EventHandler(this.SettingToolStripMenuItem_Click);
            // 
            // ProblemSetupToolStripMenuItem
            // 
            this.ProblemSetupToolStripMenuItem.Name = "ProblemSetupToolStripMenuItem";
            this.ProblemSetupToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.ProblemSetupToolStripMenuItem.Text = "Cài đặt sự cố";
            this.ProblemSetupToolStripMenuItem.Click += new System.EventHandler(this.ProblemSetupToolStripMenuItem_Click);
            // 
            // AccountToolStripMenuItem
            // 
            this.AccountToolStripMenuItem.Name = "AccountToolStripMenuItem";
            this.AccountToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.AccountToolStripMenuItem.Text = "Thông tin tài khoản";
            this.AccountToolStripMenuItem.Click += new System.EventHandler(this.AccountToolStripMenuItem_Click);
            // 
            // lblPO
            // 
            this.lblPO.AutoSize = true;
            this.lblPO.Location = new System.Drawing.Point(9, 76);
            this.lblPO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(127, 18);
            this.lblPO.TabIndex = 13;
            this.lblPO.Text = "Production Order";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(14, 110);
            this.lblModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(51, 18);
            this.lblModel.TabIndex = 14;
            this.lblModel.Text = "Model";
            this.lblModel.Click += new System.EventHandler(this.lblModel_Click);
            // 
            // txtPO
            // 
            this.txtPO.Location = new System.Drawing.Point(133, 73);
            this.txtPO.Margin = new System.Windows.Forms.Padding(4);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(164, 26);
            this.txtPO.TabIndex = 5;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(133, 106);
            this.txtModel.Margin = new System.Windows.Forms.Padding(4);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(164, 26);
            this.txtModel.TabIndex = 6;
            this.txtModel.TextChanged += new System.EventHandler(this.txtModel_TextChanged);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(11, 31);
            this.lblLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(42, 19);
            this.lblLine.TabIndex = 17;
            this.lblLine.Text = "Line";
            // 
            // cbbLine
            // 
            this.cbbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLine.FormattingEnabled = true;
            this.cbbLine.Location = new System.Drawing.Point(57, 28);
            this.cbbLine.Margin = new System.Windows.Forms.Padding(4);
            this.cbbLine.Name = "cbbLine";
            this.cbbLine.Size = new System.Drawing.Size(223, 27);
            this.cbbLine.TabIndex = 0;
            this.cbbLine.SelectedIndexChanged += new System.EventHandler(this.cbbLine_SelectedIndexChanged);
            this.cbbLine.DropDownClosed += new System.EventHandler(this.cbbLine_DropDownClosed);
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(463, 106);
            this.txtMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(611, 26);
            this.txtMaterial.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "Material";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(711, 345);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(189, 60);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Xóa, nhập lại thông tin";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.cbbLine);
            this.groupBox1.Controls.Add(this.lblLine);
            this.groupBox1.Controls.Add(this.rtbCc);
            this.groupBox1.Controls.Add(this.rtbTo);
            this.groupBox1.Controls.Add(this.lblCc);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1102, 86);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ghi nhận DownTime";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox2.Controls.Add(this.cbbEquipment);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtMaterial);
            this.groupBox2.Controls.Add(this.txtModel);
            this.groupBox2.Controls.Add(this.txtPO);
            this.groupBox2.Controls.Add(this.lblModel);
            this.groupBox2.Controls.Add(this.lblPO);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblDescription);
            this.groupBox2.Controls.Add(this.rtbDes);
            this.groupBox2.Controls.Add(this.cbbProblem);
            this.groupBox2.Controls.Add(this.cbbCategory);
            this.groupBox2.Controls.Add(this.lblProblem);
            this.groupBox2.Controls.Add(this.lblCategory);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1102, 219);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin sự cố";
            // 
            // cbbEquipment
            // 
            this.cbbEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEquipment.FormattingEnabled = true;
            this.cbbEquipment.Location = new System.Drawing.Point(463, 68);
            this.cbbEquipment.Margin = new System.Windows.Forms.Padding(4);
            this.cbbEquipment.Name = "cbbEquipment";
            this.cbbEquipment.Size = new System.Drawing.Size(611, 26);
            this.cbbEquipment.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tên thiết bị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(316, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(494, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Chú ý: Vui lòng chọn nhóm sự cố và tên sự cố (chọn tên thiết bị nếu có)";
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(908, 345);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(193, 60);
            this.btnRecord.TabIndex = 25;
            this.btnRecord.Text = "Ghi DownTime && Email tự động gửi";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 357);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(265, 18);
            this.linkLabel1.TabIndex = 26;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Xem hướng dẫn sử dụng- Click Here";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 181);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(412, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ghi tiếng Việt, không dấu, không cách khoảng, xuống dòng";
            // 
            // ReportProblem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 418);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportProblem";
            this.Text = "Ghi nhận thời gian dừng line";
            this.Load += new System.EventHandler(this.ReportProblem_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblProblem;
        private System.Windows.Forms.ComboBox cbbCategory;
        private System.Windows.Forms.ComboBox cbbProblem;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.RichTextBox rtbDes;
        private System.Windows.Forms.Label lblCc;
        private System.Windows.Forms.RichTextBox rtbTo;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbCc;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FunctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportProblemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LineSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProblemSetupToolStripMenuItem;
        private System.Windows.Forms.Label lblPO;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtPO;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.ToolStripMenuItem AccountToolStripMenuItem;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.ComboBox cbbLine;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbEquipment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
    }
}

