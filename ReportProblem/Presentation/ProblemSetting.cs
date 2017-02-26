using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportProblem.Business;
using ReportProblem.Presentation;
namespace ReportProblem
{
    public partial class ProblemSetting : Form
    {
        private FailGroup group = new FailGroup();
        private Failure fail = new Failure();
        private int failId = -1;
        private String failName = "";
        public ProblemSetting()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoSize = false;

            LoadData();
            List<Item> list = group.getAllFailGroup();
            foreach (Item i in list) cbbCategory.Items.Add(i);
            cbbCategory.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MasterPass master = new MasterPass();
            master.ShowDialog();
            if (master.Result())
            {

                fail.setGroupId(Convert.ToInt32(((Item)cbbCategory.SelectedItem).Value));
                fail.setName(txtFailName.Text);
                fail.Add();
                LoadData();
            }
        }

        private void gvProblemSetup_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = gvProblemSetup.Rows[e.RowIndex];
            //fail.setName(row.Cells[0].Value.ToString());
            //fail.Rename(gvProblemSetup.Tag.ToString());
            //LoadData();
        }
        public void LoadData()
        {
            gvProblemSetup.DataSource = fail.GetFailAndGroup();
            
        }

        private void gvProblemSetup_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //old value
            gvProblemSetup.Tag = gvProblemSetup.CurrentCell.Value.ToString();

        }

        private void gvProblemSetup_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

            int failIdIndex = 2;
            int failNameIndex = 1;
                if (gvProblemSetup.SelectedRows.Count > 0)
                {

                    failId = Convert.ToInt32(gvProblemSetup.SelectedRows[0].Cells[failIdIndex].Value.ToString());
                    failName = gvProblemSetup.SelectedRows[0].Cells[failNameIndex].Value.ToString();

                }
            
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ChangeFailNameOfRecord change = new ChangeFailNameOfRecord(failId, failName);
            change.ShowDialog();
            if (change.Result())
                LoadData();
        }

       
       
    }
}
