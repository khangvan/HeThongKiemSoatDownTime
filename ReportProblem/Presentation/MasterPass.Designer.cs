﻿namespace ReportProblem.Presentation
{
    partial class MasterPass
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
            this.label1 = new System.Windows.Forms.Label();
            this.pwdMasterPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu master";
            // 
            // pwdMasterPass
            // 
            this.pwdMasterPass.Location = new System.Drawing.Point(40, 72);
            this.pwdMasterPass.Name = "pwdMasterPass";
            this.pwdMasterPass.Size = new System.Drawing.Size(172, 20);
            this.pwdMasterPass.TabIndex = 1;
            this.pwdMasterPass.UseSystemPasswordChar = true;
            this.pwdMasterPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pwdMasterPass_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(218, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(*) Enter sau khi nhập";
            // 
            // MasterPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 117);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pwdMasterPass);
            this.Controls.Add(this.label1);
            this.Name = "MasterPass";
            this.Text = "MasterPass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pwdMasterPass;
        private System.Windows.Forms.Label label2;
    }
}