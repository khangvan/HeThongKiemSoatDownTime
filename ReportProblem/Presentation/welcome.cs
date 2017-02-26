using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using ReportProblem.Data;
using ReportProblem.Business;
namespace ReportProblem
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
         
        }

        // delegate to send info to another form
        public delegate void delCode(String text);
   
    


        private void btnLogin_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.setOpCode(txtOpCode.Text);
            emp.setPwd(txtPass.Text);
           // MessageBox.Show(emp.ValidateLogin().ToString());
            // login successful
            Cursor.Current = Cursors.WaitCursor;

            if (emp.ValidateLogin())
            {
                this.Hide();
                Statistics statis = new Statistics();
                delCode code = new delCode(statis.delOpCode);
                code(txtOpCode.Text);


                statis.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai thông tin");
                txtPass.Clear();
            }
            
           
          
        }
        
       
        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.Enter))
            btnLogin.PerformClick();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddNew n = new AddNew();
            this.Hide();
            n.MdiParent = this.ParentForm;
            n.ShowDialog();
            this.Close();
        }

        private void txtOpCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals( Keys.Enter)) txtPass.Focus();
        }

        private void welcome_Load(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
