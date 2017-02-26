using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportProblem.Business;

namespace ReportProblem.Presentation
{
    public partial class MasterPass : Form
    {
        private bool result = false;
        public MasterPass()
        {
            InitializeComponent();
        }

        private void pwdMasterPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (pwdMasterPass.Text.Equals(Info.masterPass))
                {
                    result = true;
                    this.Close();
                }
                else MessageBox.Show("Mật khẩu không đúng, bạn không có quyền");

            }
        }
        public bool Result()
        {
            return result;
        }
    }
}
