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
    public partial class LineSetting : Form
    {
        public LineSetting()
        {
            InitializeComponent();
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            if (pwdPass.Text.Equals(Info.masterPass))
            {
                Line l = new Line();
                l.setLineId(txtLine.Text);
                l.setLineName(txtLine.Text);
                l.AddLine();
                MessageBox.Show("Đã thêm");
            }
            else MessageBox.Show("Mật khẩu không đúng, bạn không được phép");
            txtLine.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (pwdPass.Text.Equals(Info.masterPass))
            {
            Line l = new Line();
            l.setLineId(txtLine.Text);
            l.setLineName(txtLine.Text);
            l.Remove();
            MessageBox.Show("Đã Xóa");
            }
            else MessageBox.Show("Mật khẩu không đúng, bạn không được phép");
            txtLine.Clear();
        }
    }
}
