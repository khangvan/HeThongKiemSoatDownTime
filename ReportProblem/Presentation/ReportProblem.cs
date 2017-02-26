using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using ReportProblem.Business;
using System.Diagnostics;
namespace ReportProblem
{
    public partial class ReportProblem : Form
    {
        private Employee employee = new Employee();
        private Line line = new Line();
        private FailGroup failGroup = new FailGroup();
        private Failure fail = new Failure();



        private bool isSendMail;
        private static int wait = 1;
        private static int processing = 2;
        private static int finished = 3;


        public ReportProblem(String empId,int lineIndex)
        {
            InitializeComponent();
         
            this.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
           // this.MinimizeBox = false;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoSize = false;

            isSendMail = true;
            employee.setOpCode(empId);
            employee.Load();



            #region equipment
            List<Item> equip = new List<Item>();
            equip = fail.getEquipmentList();

            cbbEquipment.Items.Add(new Item("N/A", -1));
            foreach (Item i in equip)
            {
                cbbEquipment.Items.Add(i);
            }
            // default value is Fail group Material
            cbbEquipment.SelectedIndex = 0; 
            #endregion


           


            #region get fail and group
            List<Item> g = new List<Item>();
            g = failGroup.getAllFailGroup();

            cbbCategory.Items.Add(new Item("Chọn Nhóm sự cố",-1));
            foreach (Item i in g)
            {
                cbbCategory.Items.Add(i);
            }
            // default value is Fail group Material
            cbbCategory.SelectedIndex = 0;

            List<Item> f = new List<Item>();

            if (Convert.ToInt32(((Item)cbbCategory.SelectedItem).Value.ToString()) >= 0)
            {
                f = fail.getFail(Convert.ToInt32(((Item)cbbCategory.SelectedItem).Value.ToString()));
                foreach (Item i in f)
                {
                    cbbProblem.Items.Add(i);
                }
                // default value is the first
                cbbProblem.SelectedIndex = 0;
            }
            else
            {
                cbbProblem.Items.Add(new Item("Chọn Tên sự cố", -1));
                cbbProblem.SelectedIndex = 0;
            }
            #endregion

            #region set line
            List<String> allLine = line.getAllLine();
            foreach (String linecode in allLine)
            {
                cbbLine.Items.Add(linecode);

            }

            cbbLine.SelectedIndex = lineIndex;
            try
            {
                line.setLineId(cbbLine.SelectedItem.ToString());
                line.Load();
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi khi nhận dạng Line");
            }
      
            #endregion
        }
       
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void ReportProblemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }


        private void StatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Statistics statistics = new Statistics();
            statistics.MdiParent = this.ParentForm;
            statistics.Show();
          
         
            
        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeopleRelativeSetup config = new PeopleRelativeSetup();
            config.MdiParent = this.ParentForm;
            config.Show();
            
            
           
        }

        private void cbbProblem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void ProblemSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProblemSetting problemSetting = new ProblemSetting();
            problemSetting.MdiParent = this.ParentForm;

           
            problemSetting.Show();
        }

        private void AccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAccount userAccount = new UserAccount(employee.getOpCode());
            userAccount.MdiParent = this.ParentForm;
          

            userAccount.Show();
        }

      

        private void cbbLine_DropDownClosed(object sender, EventArgs e)
        {
            line.setLineId(cbbLine.SelectedItem.ToString());
            
            line.Load();
           
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

           
            if (Convert.ToInt32(((Item)cbbProblem.SelectedItem).Value) >= 0)
            {
                line.Load();
                BLFailRecord f = new BLFailRecord();
                f.setFailureId(Convert.ToInt32(((Item)cbbProblem.SelectedItem).Value.ToString()));
                f.setEquip(Convert.ToInt32(((Item)cbbEquipment.SelectedItem).Value));
                f.setReporterCode(employee.getOpCode());
                f.setDescription(rtbDes.Text);
                f.setLine(cbbLine.SelectedItem.ToString());
                bool validate = true;
                if (txtPO.Text.Length >= 3 && txtPO.Text.Length <= 12) f.setPO(txtPO.Text);
                else validate = false;

                Regex regex = new Regex("[0-9]");

                if (!regex.IsMatch(txtPO.Text))
                {
                    validate = false;
                }
              f.setModel(txtModel.Text);
              
                if (txtMaterial.Text.Length > 0) f.setMaterial(txtMaterial.Text);
                else f.setMaterial("");


                if (validate)
                {


                    f.Add();
                    
                    if (isSendMail)
                    {

                        Email mail = new Email();

                        String content = rtbDes.Text;

                        String model = "";
                        String po = "";
                        String material = "";
                        po += txtPO.Text;
                        model += txtModel.Text;
                        material += txtMaterial.Text;


                        mail = new Email(employee.getOpName(), rtbTo.Text, rtbCc.Text, ((Item)cbbCategory.SelectedItem).Text, line.getLineId(), ((Item)cbbProblem.SelectedItem).Text, content, wait, line.getUpperLevelMail().Split(';').ToList(), f.GetLastRecordId(),((Item)cbbEquipment.SelectedItem).Text, po, model, material);
                        // mail.serverMail = this.serverMail;
                        // mail.port = this.port;
                        mail.Send();
                    }




                    btnClear.PerformClick();
                    this.Close();

                }

                else MessageBox.Show("Thông tin PO phải từ 3-12 số;  Model phải hơn 3 ký tự", "Yeu cau nhap du thong tin");


            }
            else MessageBox.Show("Vui lòng chọn sự cố");
            
          
          
       

           
        }

        private void cbbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                #region MyRegion
                List<Item> f = new List<Item>();
                if (Convert.ToInt32(((Item)cbbCategory.SelectedItem).Value.ToString()) >= 0)
                {
                    cbbProblem.Items.Clear();
                    f = fail.getFail(Convert.ToInt32(((Item)cbbCategory.SelectedItem).Value.ToString()));
                    foreach (Item i in f)
                    {
                        cbbProblem.Items.Add(i);
                    }
                    // default value is the first
                    cbbProblem.SelectedIndex = 0;
                }
                else
                {
                    cbbProblem.Items.Add(new Item("Chọn Tên sự cố", -1));
                    cbbProblem.SelectedIndex = 0;
                }
                #endregion


                #region Visiable TB and PN
                cbbEquipment.Text = txtMaterial.Text = "";
                if (cbbCategory.SelectedIndex == 1 ) //tb
                {
                    txtMaterial.Text = "";
                    cbbEquipment.Text = "";

                    txtMaterial.Visible = false;
                    cbbEquipment.Visible = true;

                    

                }

                if (cbbCategory.SelectedIndex == 2)//material
                {
                    txtMaterial.Text = "";
                    cbbEquipment.Text = "";

                    txtMaterial.Visible = true;
                    cbbEquipment.Visible = false;
                }

                if (cbbCategory.SelectedIndex == 4)//Phuong phap
                {
                    txtMaterial.Text = "";
                    cbbEquipment.Text = "";

                    txtMaterial.Visible = true;
                    cbbEquipment.Visible = false;
                }
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

      

   

     

        private void btnClear_Click(object sender, EventArgs e)
        {
            //reset info
            txtPO.Text = "";
            txtModel.Text = "";
            txtMaterial.Text = "";
           
            rtbDes.Text = "";
        }

        private void lblProblem_Click(object sender, EventArgs e)
        {

        }

        private void lblModel_Click(object sender, EventArgs e)
        {

        }

        private void cbbProblem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbCategory_DropDownClosed(object sender, EventArgs e)
        {
            if (Convert.ToInt32(((Item)cbbCategory.SelectedItem).Value) >= 0)
            {
                line.Load();
                rtbTo.Text = line.getMailTo(Convert.ToInt32(((Item)cbbCategory.SelectedItem).Value));
                rtbCc.Text = line.getMailCC(Convert.ToInt32(((Item)cbbCategory.SelectedItem).Value));
            }
            else
            {
                cbbProblem.Items.Clear();
                cbbProblem.Items.Add(new Item("Chọn tên sự cố",-1));
                cbbProblem.SelectedIndex = 0;
                MessageBox.Show("Chọn nhóm và tên sự cố");
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            isSendMail = false;


            if (Convert.ToInt32(((Item)cbbProblem.SelectedItem).Value) >= 0)
            {
                line.Load();
                BLFailRecord f = new BLFailRecord();
                f.setFailureId(Convert.ToInt32(((Item)cbbProblem.SelectedItem).Value.ToString()));
                f.setEquip(Convert.ToInt32(((Item)cbbEquipment.SelectedItem).Value));
                f.setReporterCode(employee.getOpCode());
                f.setDescription(rtbDes.Text);
                f.setLine(cbbLine.SelectedItem.ToString());
                bool validate = true;
                if (txtPO.Text.Length >= 3 && txtPO.Text.Length <= 12) f.setPO(txtPO.Text);
                else validate = false;

                Regex regex = new Regex("[0-9]");

                if (!regex.IsMatch(txtPO.Text))
                {
                    validate = false;
                }
                f.setModel(txtModel.Text);

                if (txtMaterial.Text.Length > 0) f.setMaterial(txtMaterial.Text);
                else f.setMaterial("");


                if (validate)
                {


                    f.Add();

                    //if (isSendMail)
                    //{

                    //    Email mail = new Email();

                    //    String content = rtbDes.Text;

                    //    String model = "";
                    //    String po = "";
                    //    String material = "";
                    //    po += txtPO.Text;
                    //    model += txtModel.Text;
                    //    material += txtMaterial.Text;


                    //    mail = new Email(employee.getOpName(), rtbTo.Text, rtbCc.Text, ((Item)cbbCategory.SelectedItem).Text, line.getLineId(), ((Item)cbbProblem.SelectedItem).Text, content, wait, line.getUpperLevelMail().Split(';').ToList(), f.GetLastRecordId(), ((Item)cbbEquipment.SelectedItem).Text, po, model, material);
                    //    // mail.serverMail = this.serverMail;
                    //    // mail.port = this.port;
                    //    mail.Send();
                    //}




                    btnClear.PerformClick();
                    this.Close();

                }

                else MessageBox.Show("Thông tin PO phải từ 3-12 số;  Model phải hơn 3 ký tự", "Yeu cau nhap du thong tin");


            }
            else MessageBox.Show("Vui lòng chọn sự cố");


            return;
       

          //  btnSend.PerformClick();
        }

        private void cbbLine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ReportProblem_Load(object sender, EventArgs e)
        {
            txtMaterial.Visible = false;
            cbbEquipment.Visible = false;
            // Add a link to the LinkLabel.
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = @"\\vnmsrv601\DevelopSoftware\P24-HeThongKiemSoatSuCoADC\HuongdanSuDung2016\";
            linkLabel1.Links.Add(link);
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Send the URL to the operating system.
            Process.Start(e.Link.LinkData as string);
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

  

       
    }
}
