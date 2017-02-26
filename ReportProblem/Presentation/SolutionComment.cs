using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportProblem.Business;
//using ReportProblem.Presentation;

namespace ReportProblem.Presentation
{
    public partial class SolutionComment : Form
    {
        private Label label1;
        private RichTextBox rtbComment;
        private Button btnOk;
        private string repairer;
        private BLFailRecord f = new BLFailRecord();
        private Email mail = new Email();
        private bool sendMail;
        public SolutionComment(bool isSendMail,String reporter,String to,String cc,String failGroup,String line,String failName,String description,int stt,List<String> mailOfProductEngineer,int RecordId)
        {
            InitializeComponent();
            repairer = reporter;
            sendMail = isSendMail;
             mail = new Email(reporter, to, cc, failGroup, line, failName, description, 3, mailOfProductEngineer, RecordId,"", "", "", "");
           
           f.setId(RecordId);
          
        }

        public SolutionComment(bool isSendMail, String reporter, String to, String cc, String failGroup, String line, String failName, String description, int stt, List<String> mailOfProductEngineer, int RecordId, string PO, string Model, string Material)
        {
            InitializeComponent();
            repairer = reporter;
            sendMail = isSendMail;
            mail = new Email(reporter, to, cc, failGroup, line, failName, description, 3, mailOfProductEngineer, RecordId,"", PO, Model, Material);

            f.setId(RecordId);

        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.rtbComment = new System.Windows.Forms.RichTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mô tả cách sửa chữa";
            // 
            // rtbComment
            // 
            this.rtbComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbComment.Location = new System.Drawing.Point(12, 23);
            this.rtbComment.Name = "rtbComment";
            this.rtbComment.Size = new System.Drawing.Size(350, 169);
            this.rtbComment.TabIndex = 1;
            this.rtbComment.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(292, 198);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 21);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // SolutionComment
            // 
            this.ClientSize = new System.Drawing.Size(402, 232);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rtbComment);
            this.Controls.Add(this.label1);
            this.Name = "SolutionComment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhap cach xu ly van de";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            mail.comment = rtbComment.Text;
            //if (sendMail) mail.Send();
            f.setStatus(3);
            f.UpdateStatus(repairer, rtbComment.Text);
           
            this.Close();
        }

        
    }
}
