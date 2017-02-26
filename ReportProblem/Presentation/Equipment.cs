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
    public partial class Equipment : Form
    {
        private Failure fail = new Failure();
        public Equipment()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
           
            gvEquip.DataSource = fail.getEquipmentDataTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MasterPass master = new MasterPass();
                master.ShowDialog();
                if (master.Result())
                {

                    fail.AddEquip(txtEquipName.Text);
                    txtEquipName.Clear();
                    LoadData();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Can not add equip. Please again !");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                MasterPass master = new MasterPass();
                master.ShowDialog();
                if (master.Result())
                {

                    fail.RemoveEquip(Convert.ToInt32(txtId.Text));
                    txtId.Clear();
                    LoadData();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Can not remove equip. Please again !");
            }
        }

        private void txtEquipName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnAdd.PerformClick();
        }

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnRemove.PerformClick();
        }
    }
}
