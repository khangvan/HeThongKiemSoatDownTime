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
    public partial class AddNew : Form
    {
        public AddNew()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // check match pass and confirm
            if (pwdPass.Text.Equals(pwdConfirm.Text))
            {

                Employee em = new Employee();
                em.setOpCode(txtEmpId.Text);
                em.setName(txtName.Text);
                em.setEmail(txtEmail.Text);
                em.setPwd(pwdPass.Text);
                em.setDept(txtDept.Text);
                if (em.Add())
                {
                    MessageBox.Show("Thành công. Mời đăng nhập!");
                    //change form
                    this.Hide();
                    welcome wel = new welcome();
                    this.Hide();
                    wel.ShowDialog();
                    this.Close();
                }
                else
                {

                    MessageBox.Show("Nhân viên đã có tài khoản. Liên hệ phòng ME nếu quên mật khẩu");
                    this.Hide();
                    welcome w = new welcome();
                    w.ShowDialog();
                    this.Close();
                }
            }
            else MessageBox.Show("Mật khẩu và xác nhận không giống");
        }
    }
}
