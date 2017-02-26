using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportProblem.Business;
namespace ReportProblem
{
    public partial class PeopleRelativeSetup : Form
    {
        private Line line = new Line();
        public PeopleRelativeSetup()
        {

            InitializeComponent();
            List<String> allLine = line.getAllLine();
            foreach (String linecode in allLine)
            {
                cbbLine.Items.Add(linecode);

            }
            this.rtbUpperLevelMail.Hide();
            this.lblUpperLevelMail.Hide();
            // default value is the first
            cbbLine.SelectedItem = allLine[0];
          

            line.setLineId(cbbLine.SelectedItem.ToString());
       
            line.Load();
            rtbToMachine.Text = line.getMailTo(0);
            rtbCcMachine.Text = line.getMailCC(0);
            rtbToMaterial.Text = line.getMailTo(1);
            rtbCcMaterial.Text = line.getMailCC(1);
            rtbToMan.Text = line.getMailTo(2);
            rtbCcMan.Text = line.getMailCC(2);
            rtbToMethod.Text = line.getMailTo(3);
            rtbCcMethod.Text = line.getMailCC(3);
            rtbUpperLevelMail.Text = line.getUpperLevelMail();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //reset mail list

            String[] mailto = new String[4];
              mailto[0] =  rtbToMachine.Text;
              mailto[1] = rtbToMaterial.Text;
              mailto[2] = rtbToMan.Text;
              mailto[3] = rtbToMethod.Text;
            line.setMailTo(mailto);


            String[] mailcc = new String[4];
            mailcc[0] = rtbCcMachine.Text;
            mailcc[1] = rtbCcMaterial.Text;
            mailcc[2] = rtbCcMan.Text;
            mailcc[3] = rtbCcMethod.Text;
            line.setMailCC(mailcc);


            //filter mail to
            String mailUpper = rtbUpperLevelMail.Text;
            line.setUpperLevelMail(mailUpper);
           
            if (line.UpdateMailList())
            {

                MessageBox.Show("Thay đổi thành công.");
                
                 
                
            }
            else MessageBox.Show("Xảy ra lỗi");
        }

        public string FilterEmail(string src, string findfrom = "<", string findto = ">")
        {
            int start = src.IndexOf(findfrom);
            int to = src.IndexOf(findto, start + findfrom.Length);
            if (start < 0 || to < 0) return "";
            string s = src.Substring(
                           start + findfrom.Length,
                           to - start - findfrom.Length);
            return s;
        }

        private void cbbLine_DropDownClosed(object sender, EventArgs e)
        {
            line.setLineId(cbbLine.SelectedItem.ToString());

            line.Load();
            rtbToMachine.Text = line.getMailTo(0);
            rtbCcMachine.Text = line.getMailCC(0);
            rtbToMaterial.Text = line.getMailTo(1);
            rtbCcMaterial.Text = line.getMailCC(1);
            rtbToMan.Text = line.getMailTo(2);
            rtbCcMan.Text = line.getMailCC(2);
            rtbToMethod.Text = line.getMailTo(3);
            rtbCcMethod.Text = line.getMailCC(3);
            rtbUpperLevelMail.Text = line.getUpperLevelMail();
        }

        private void rtbTo_Enter(object sender, EventArgs e)
        {
            rtbToMachine.Text += rtbUpperLevelMail.Text;
        }

        private void rtbUpperLevelMail_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
