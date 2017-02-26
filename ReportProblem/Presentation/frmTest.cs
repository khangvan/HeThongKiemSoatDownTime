using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Microsoft;

namespace ReportProblem.Presentation
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            SendEmail("Khang.van@datalogic.com", "test", "testbody");
            MessageBox.Show("OK");
        }


        public static void SendEmail(string _ToEmail, string _Subject, string _EmailBody)
        {//ok
            
            Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem email = (Microsoft.Office.Interop.Outlook.MailItem)(oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem));
            email.Recipients.Add(_ToEmail);
            email.Subject = _Subject;
            email.Body = _EmailBody;
            ((Microsoft.Office.Interop.Outlook.MailItem)email).Send();
        }
       }

   
}
