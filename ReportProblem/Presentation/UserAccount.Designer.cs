namespace ReportProblem
{
    partial class UserAccount
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
            this.lblEmpId = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.lblEmpIdValue = new System.Windows.Forms.Label();
            this.lblEmpNameValue = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.pwdPass = new System.Windows.Forms.TextBox();
            this.pwdConfirm = new System.Windows.Forms.TextBox();
            this.btnUpdatePass = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pwdOldPass = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEmpId
            // 
            this.lblEmpId.AutoSize = true;
            this.lblEmpId.Location = new System.Drawing.Point(50, 38);
            this.lblEmpId.Name = "lblEmpId";
            this.lblEmpId.Size = new System.Drawing.Size(72, 13);
            this.lblEmpId.TabIndex = 0;
            this.lblEmpId.Text = "Mã nhân viên";
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Location = new System.Drawing.Point(50, 70);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(76, 13);
            this.lblEmpName.TabIndex = 2;
            this.lblEmpName.Text = "Tên nhân viên";
            // 
            // lblEmpIdValue
            // 
            this.lblEmpIdValue.AutoSize = true;
            this.lblEmpIdValue.Location = new System.Drawing.Point(161, 38);
            this.lblEmpIdValue.Name = "lblEmpIdValue";
            this.lblEmpIdValue.Size = new System.Drawing.Size(55, 13);
            this.lblEmpIdValue.TabIndex = 1;
            this.lblEmpIdValue.Text = "20140001";
            // 
            // lblEmpNameValue
            // 
            this.lblEmpNameValue.AutoSize = true;
            this.lblEmpNameValue.Location = new System.Drawing.Point(161, 70);
            this.lblEmpNameValue.Name = "lblEmpNameValue";
            this.lblEmpNameValue.Size = new System.Drawing.Size(76, 13);
            this.lblEmpNameValue.TabIndex = 3;
            this.lblEmpNameValue.Text = "Nguyen Van A";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(50, 139);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(50, 220);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(71, 13);
            this.lblPass.TabIndex = 6;
            this.lblPass.Text = "Mật khẩu mới";
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(50, 258);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(53, 13);
            this.lblConfirm.TabIndex = 7;
            this.lblConfirm.Text = "Xác nhận";
            // 
            // pwdPass
            // 
            this.pwdPass.Location = new System.Drawing.Point(164, 213);
            this.pwdPass.Name = "pwdPass";
            this.pwdPass.Size = new System.Drawing.Size(198, 20);
            this.pwdPass.TabIndex = 3;
            this.pwdPass.UseSystemPasswordChar = true;
            // 
            // pwdConfirm
            // 
            this.pwdConfirm.Location = new System.Drawing.Point(164, 251);
            this.pwdConfirm.Name = "pwdConfirm";
            this.pwdConfirm.Size = new System.Drawing.Size(198, 20);
            this.pwdConfirm.TabIndex = 4;
            this.pwdConfirm.UseSystemPasswordChar = true;
            this.pwdConfirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pwdConfirm_KeyDown);
            // 
            // btnUpdatePass
            // 
            this.btnUpdatePass.Location = new System.Drawing.Point(164, 285);
            this.btnUpdatePass.Name = "btnUpdatePass";
            this.btnUpdatePass.Size = new System.Drawing.Size(78, 28);
            this.btnUpdatePass.TabIndex = 5;
            this.btnUpdatePass.Text = "Lưu thay đổi";
            this.btnUpdatePass.UseVisualStyleBackColor = true;
            this.btnUpdatePass.Click += new System.EventHandler(this.btnUpdatePass_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mật khẩu cũ";
            // 
            // pwdOldPass
            // 
            this.pwdOldPass.Location = new System.Drawing.Point(164, 172);
            this.pwdOldPass.Name = "pwdOldPass";
            this.pwdOldPass.Size = new System.Drawing.Size(198, 20);
            this.pwdOldPass.TabIndex = 2;
            this.pwdOldPass.UseSystemPasswordChar = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(164, 132);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(198, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Phòng ban";
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(164, 96);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(198, 20);
            this.txtDept.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(284, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 325);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.pwdOldPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdatePass);
            this.Controls.Add(this.pwdConfirm);
            this.Controls.Add(this.pwdPass);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblEmpNameValue);
            this.Controls.Add(this.lblEmpName);
            this.Controls.Add(this.lblEmpIdValue);
            this.Controls.Add(this.lblEmpId);
            this.Name = "UserAccount";
            this.Text = "UserAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmpId;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Label lblEmpIdValue;
        private System.Windows.Forms.Label lblEmpNameValue;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox pwdPass;
        private System.Windows.Forms.TextBox pwdConfirm;
        private System.Windows.Forms.Button btnUpdatePass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pwdOldPass;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Button btnCancel;
    }
}