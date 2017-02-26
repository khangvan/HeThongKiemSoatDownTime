using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportProblem.Presentation
{
    public partial class OTDPDReport : Form
    {
        public OTDPDReport()
        {
            InitializeComponent();


        }

        private void pRODOTDBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
 //      SaveMethod();
            SaveMethodAddNew();

        }

        private void SaveMethodAddNew()
        {
            foreach (Control tb in groupBox1.Controls)
            {
                if (tb is TextBox)
                {
                    if (tb.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin!");
                        tb.Focus();
                        return;
                    }
                    else
                    {

                    }
                    //here is where you access all the textboxs.
                }
                if (tb is ComboBox)
                {
                    if (tb.Text == "Please choose one below...")
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin!");
                        tb.Focus();
                        return;
                    }
                }


            }

            this.Validate();
            this.pRODOTDBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pTRDataSet);

             
           
        }

        private void SaveMethod()
        {
            //foreach (Control tb in groupBox1.Controls)
            //{
            //    if (tb is TextBox)
            //    {
            //        if (tb.Text == "")
            //        {
            //            MessageBox.Show("Vui lòng nhập đủ thông tin!");
            //            tb.Focus();
            //            return;
            //        }
            //        else
            //        {

            //        }
            //        //here is where you access all the textboxs.
            //    }
            //    if (tb is ComboBox)
            //    {
            //        if (tb.Text == "Please choose one below...")
            //        {
            //            MessageBox.Show("Vui lòng nhập đủ thông tin!");
            //            tb.Focus();
            //            return;
            //        }
            //    }


            //}

            this.Validate();
            this.pRODOTDBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pTRDataSet);

            //bindingNavigatorAddNewItem.PerformClick();

        }

        private void OTDPDReport_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'pTRDataSet.PRODOTD' table. You can move, or remove it, as needed.
            this.pRODOTDTableAdapter.Fill(this.pTRDataSet.PRODOTD);


            //#region Lấy Line Name
            //PTRDataSet.getLineNameDataTable dt1 = new PTRDataSet.getLineNameDataTable();
            //PTRDataSetTableAdapters.getLineNameOnlyTableAdapter da = new PTRDataSetTableAdapters.getLineNameOnlyTableAdapter();
            //dt1= da.GetDataLineName();
            
           
           

            //    foreach (DataRow dr in dt1.Rows)
            //    {

            //        lineComboBox.Items.Add(dr["LineID"].ToString().Trim());
            //    }
               
            //    lineComboBox.SelectedIndex = 0;
            
      

            ////do add new
            //    bindingNavigatorAddNewItem.PerformClick();

        }

        private void descriptionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    //add save
            //    SaveMethodAddNew();
            //    //then new perform
            //   // 
            //}
       }

       
    }
}
