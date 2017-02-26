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
    public partial class UserAccount : Form
    {
        private Employee employee = new Employee();

        
        public UserAccount(String opCode)
        {
            InitializeComponent();
            employee.setOpCode(opCode);
            employee.Load();
            lblEmpIdValue.Text = employee.getOpCode();
            lblEmpNameValue.Text = employee.getOpName();
            txtEmail.Text = employee.getEmail();
            txtDept.Text = employee.getDept();
        }

        private void btnUpdatePass_Click(object sender, EventArgs e)
        {
            bool result = false;
            HashPass hash = new HashPass(pwdOldPass.Text);
            //verify current pass
            if (employee.getPwd().Equals(hash.getHash()))
            {
                //verify pass and confirm
                if (pwdPass.Text.Equals(pwdConfirm.Text))
                {
                   
                    result = employee.changePass(pwdPass.Text);
                    
                }
            }
            employee.setEmail(txtEmail.Text);
            employee.changeEmail();
            employee.setDept(txtDept.Text);
            employee.changeDept();
            if (result) MessageBox.Show("Thành công! Đóng chương trình và đăng nhập lại để thay đổi có hiệu lực");
            else MessageBox.Show("Sai mật khẩu hoặc xác nhận mật khẩu không khớp");
            
            this.Close();
        }

        private void pwdConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnUpdatePass.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
