using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportProblem.Presentation;
using ReportProblem.Business;

namespace ReportProblem.Presentation
{
    public partial class ChangeFailNameOfRecord : Form
    {
        private int oldId;
        private String oldFailName;
        public bool result = false;
        public ChangeFailNameOfRecord(int Id,String FailName)
        {
            InitializeComponent();
            oldId=Id;
            oldFailName = FailName;
            this.btnDelete.Text += " " + oldFailName;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            MasterPass master = new MasterPass();
            master.ShowDialog();
            if (master.Result())
            {
                // update failure for fail record
                try
                {
                    BLFailRecord failRecord = new BLFailRecord();
                    failRecord.UpdateFailureForFailrecord(oldId, Convert.ToInt32(numNewId.Value));
                }
                catch (Exception)
                {

                    MessageBox.Show("Lỗi chuyển tên sự cố ");
                }


                try
                {
                    //delete failure
                    Failure fail = new Failure();
                    fail.Remove(oldId);
                    MessageBox.Show("Đã xóa !");
                    result = true;
                    this.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Lỗi xóa fail Record");
                }
            }
         
        }
        public bool Result()
        {
            return result;
        }
    }
}
