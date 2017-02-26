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
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Deployment.Application;
namespace ReportProblem
{
    public partial class Statistics : Form
    {
        private DataTable data = new DataTable();
        private BLFailRecord f = new BLFailRecord();
        private Employee employee = new Employee();
        private FailGroup category = new FailGroup();

        #region index in grid view
        int recordIdIndex = 0;
        int lineIdIndex = 1;
        int groupFailIndex = 2;
        int failNameIndex = 3;
        int reporterIndex = 4;
        int descriptionIndex = 5;
        int stopTimeIndex = 6;
        int resumeTimeIndex = 7;
        int statusIndex = 8;
        int equipmentIndex = 9;
        int POIndex = 10;
        int modelIndex = 11;
        int partIndex = 12;
        int durationIndex = 13;
        int repairerIndex = 14;
        int commentIndex = 15;

        #endregion



        private static int cstwait = 1;
        private static int cstprocessing = 2;
        private static int cstfinished = 3;
        System.IO.Ports.SerialPort serialPort1 = new System.IO.Ports.SerialPort();

        private int rowTemp ;
        private int RecordIdtemp;//temp variable
        private String LineIdTemp;
        private String failNameTemp;
        private Line line = new Line();
        private string LocalLineId = "";
        private string comPort = "COM2";
        private int BaudRate = 9600;

        public void delOpCode(String text) { employee.setOpCode(text); employee.Load(); }
      
        public Statistics()
        {
            
            try
            {

               

                InitializeComponent();
                // this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                // Set the MinimizeBox to false to remove the minimize box.
                // this.MinimizeBox = false;
                // Set the start position of the form to the center of the screen.
                this.StartPosition = FormStartPosition.CenterScreen;
                this.AutoSize = false;

                #region Khởi tạo setup đèn tín hiệu
                // set line name local
                try
                {
                    String path = "C:\\ADC\\HeThongKiemSoatSuCo\\Line.txt";
                    StreamReader streamReader = new StreamReader(path);
                    LocalLineId = streamReader.ReadToEnd();
                    streamReader.Close();
              

                    path = "C:\\ADC\\HeThongKiemSoatSuCo\\COM.txt";
                    streamReader = new StreamReader(path);
                    String temp = streamReader.ReadToEnd();
                    if (temp.Length > 0)
                    {
                        comPort = temp.Split(';')[0];
                        BaudRate = Convert.ToInt32(temp.Split(';')[1]);

                    }
                    streamReader.Close();


                }
                catch (Exception ex)
                {

                    if (!Directory.Exists("C:\\ADC\\HeThongKiemSoatSuCo"))  // if it doesn't exist, create
                        Directory.CreateDirectory("C:\\ADC\\HeThongKiemSoatSuCo");
                    if (!File.Exists("C:\\ADC\\HeThongKiemSoatSuCo\\Line.txt"))
                        System.IO.File.Create("C:\\ADC\\HeThongKiemSoatSuCo\\Line.txt").Close();
                    if (!File.Exists("C:\\ADC\\HeThongKiemSoatSuCo\\COM.txt"))
                        System.IO.File.Create("C:\\ADC\\HeThongKiemSoatSuCo\\COM.txt").Close();
                }

                groupBox4.Text = "Đèn tín hiệu Line " +LocalLineId;

                try
                {
                    serialPort1.PortName = this.comPort; // chuyen com2
                    serialPort1.BaudRate = this.BaudRate;
                    if (!serialPort1.IsOpen) serialPort1.Open();
                }
                catch (Exception ee)
                {

                    if (LocalLineId.Length > 0)
                        MessageBox.Show(this.comPort + " is not available" + ee.Message);
                }
                #endregion

                // den tin hieu
                checkLight();


                #region Khởi tạo combobox line
                List<String> allLine = line.getAllLine();

                foreach (String linecode in allLine)
                {

                  int i= cbbLine.Items.Add(new Item(linecode.Trim(),linecode.Trim()));
                 

                }
                cbbLine.Items.Add(new Item( "All","All"));
                cbbLine.SelectedIndex = cbbLine.Items.Count -1;
                #endregion

                #region Khởi tạo combobox status
                cbbStatus.Items.Add(new Item("Chưa và đang xử lý", 4));
                cbbStatus.Items.Add(new Item("Tất cả", 0));
                cbbStatus.Items.Add(new Item("Chưa xử lý", 1));
                cbbStatus.Items.Add(new Item("Đang xử lý", 2));
                cbbStatus.Items.Add(new Item("Đã xử lý", 3));
                
                cbbStatus.SelectedIndex = 0;
                #endregion

                cbbChartType.Items.Add(new Item("Số lượng sự cố", 0));
                cbbChartType.Items.Add(new Item("Thời gian dừng", 1));
                cbbChartType.SelectedIndex = 0;

                cbSendMail.Checked = true;

                ////deafault yesterday to today
                dtpFrom.Value = DateTime.Today.AddDays(-1);
                dtpTo.Value = DateTime.Today;


                //Timer to refresh data
                InitializeTimer();
                LoadData();

            }
            catch (Exception loi)
            {

                MessageBox.Show(loi.Message);
            }


        }

        private void InitializeTimer()
        {
            // Call this procedure when the application starts.
            // Set to 1 second.
            Timer Timer1 = new Timer();
            // 30 min refresh
            Timer1.Interval = 1000*60*10;
            Timer1.Tick += new EventHandler(Timer1_Tick);

            // Enable timer.
            Timer1.Enabled = true;

        }


        private void Timer1_Tick(object Sender, EventArgs e)
        {
            LoadData();
        }
      

      

        private void LoadData()
        {
            try
            {
              
                String lineString = "";
                if (!((Item)cbbLine.SelectedItem).Text.Equals("All")) lineString = ((Item)cbbLine.SelectedItem).Text;
                data = f.GetFailRecordList(dtpFrom.Value.ToString(), dtpTo.Value.AddDays(1).ToString(), lineString ,Convert.ToInt32(((Item)cbbStatus.SelectedItem).Value));
                gvProblem.DataSource = data;


                this.gvProblem.Columns["MaSuCo"].Frozen = true;
                List<Item> kindOfFail = new List<Item>();
                kindOfFail = f.getSumfail(dtpFrom.Value.ToString(), dtpTo.Value.AddDays(1).ToString(), lineString);
                // overview info
                lblSumProblem.Text = data.Rows.Count.ToString();
                lblWaitValue.Text = f.GetCountFailByStatus(lineString, dtpFrom.Value.ToString(), dtpTo.Value.AddDays(1).ToString(), cstwait).ToString();
                lblProcessingValue.Text = f.GetCountFailByStatus(lineString, dtpFrom.Value.ToString(), dtpTo.Value.AddDays(1).ToString(), cstprocessing).ToString();
                lblFinishedValue.Text = f.GetCountFailByStatus(lineString, dtpFrom.Value.ToString(), dtpTo.Value.AddDays(1).ToString(), cstfinished).ToString();

                // chart : number of problem
                if (Convert.ToInt32(((Item)cbbChartType.SelectedItem).Value) == 0)
                {


                    // chart
                    Chart1.ChartAreas.Clear();
                    Chart1.Series.Clear();

                    Chart1.ChartAreas.Add("Area");
                    //Chart1.ChartAreas["Area"].AxisY.Interval = 1;
                    Chart1.ChartAreas["Area"].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    Chart1.ChartAreas["Area"].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    DataPoint p;

                    //da xu ly
                    Chart1.Series.Add("a");
                    Chart1.Series["a"].LegendText = "Đã xử lý";
                    Chart1.Series["a"].ChartType = SeriesChartType.StackedColumn;
                    Chart1.Series["a"].Color = Color.Green;


                    List<Item> finished = new List<Item>();
                    finished = f.getSumByFailAndStatus(dtpFrom.Value.ToString(), dtpTo.Value.AddDays(1).ToString(), kindOfFail, 3, lineString);

                    foreach (Item i in finished)
                    {
                        p = Chart1.Series["a"].Points.Add(Convert.ToInt32(i.Value)); p.Color = Color.Green;
                        i.Text = i.Text.Replace(" ", "\n");
                        p.Label = i.Text;
                        

                    }


                    //dang xu ly
                    Chart1.Series.Add("b");
                    Chart1.Series["b"].LegendText = "Đang xử lý";
                    Chart1.Series["b"].ChartType = SeriesChartType.StackedColumn;
                    Chart1.Series["b"].Color = Color.Yellow;
                    List<Item> processing = new List<Item>();
                    processing = f.getSumByFailAndStatus(dtpFrom.Value.ToString(), dtpTo.Value.AddDays(1).ToString(), kindOfFail, 2, lineString);
                    foreach (Item i in processing)
                    {
                        p = Chart1.Series["b"].Points.Add(Convert.ToInt32(i.Value)); p.Color = Color.Yellow;
                      
                       

                    }


                    //chua xu ly
                    Chart1.Series.Add("c");
                    Chart1.Series["c"].LegendText = "Chưa xử lý";
                    Chart1.Series["c"].ChartType = SeriesChartType.StackedColumn;
                    Chart1.Series["c"].Color = Color.Red;
                    List<Item> wait = new List<Item>();

                    wait = f.getSumByFailAndStatus(dtpFrom.Value.ToString(), dtpTo.Value.AddDays(1).ToString(), kindOfFail, 1, lineString);
                    foreach (Item i in wait)
                    {
                        p = Chart1.Series["c"].Points.Add(Convert.ToInt32(i.Value)); p.Color = Color.Red; 
                        
                    }
                    Chart1.DataBind();
                }
                //chart: timestop
                else
                {
                    Chart1.ChartAreas.Clear();
                    Chart1.Series.Clear();

                    Chart1.ChartAreas.Add("Area");
                    // interval: 10 min
                    // Chart1.ChartAreas["Area"].AxisY.Interval = 10;
                    Chart1.ChartAreas["Area"].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    Chart1.ChartAreas["Area"].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    // da xu ly
                    Chart1.Series.Add("a");
                    Chart1.Series["a"].Color = Color.Green;
                    Chart1.Series["a"].LegendText = "Đã xử lý";
                    Chart1.Series["a"].ChartType = SeriesChartType.StackedColumn;



                    List<Item> timeStop = new List<Item>();
                    timeStop = f.getSumDurationByFailAndStatus(dtpFrom.Value.ToString(), dtpTo.Value.AddDays(1).ToString(), kindOfFail, lineString, cstfinished);
                    foreach (Item i in timeStop)
                    {
                        DataPoint p;
                        p = Chart1.Series["a"].Points.Add(Convert.ToInt32(i.Value)); p.Color = Color.Green; 
                        i.Text = i.Text.Replace(" ", "\n");
                        p.Label = i.Text;
                    }


                    // dang xu ly
                    Chart1.Series.Add("b");
                    Chart1.Series["b"].Color = Color.Yellow;
                    Chart1.Series["b"].LegendText = "Đang xử lý";
                    Chart1.Series["b"].ChartType = SeriesChartType.StackedColumn;



                    timeStop = new List<Item>();
                    timeStop = f.getSumDurationByFailAndStatus(dtpFrom.Value.ToString(), dtpTo.Value.AddDays(1).ToString(), kindOfFail, lineString, cstprocessing);
                    foreach (Item i in timeStop)
                    {
                        DataPoint p;
                        p = Chart1.Series["b"].Points.Add(Convert.ToInt32(i.Value)); p.Color = Color.Yellow; 


                    }

                    // chua xu ly
                    Chart1.Series.Add("c");
                    Chart1.Series["c"].Color = Color.Red;
                    Chart1.Series["c"].LegendText = "Chưa xử lý";
                    Chart1.Series["c"].ChartType = SeriesChartType.StackedColumn;



                    timeStop = new List<Item>();
                    timeStop = f.getSumDurationByFailAndStatus(dtpFrom.Value.ToString(), dtpTo.Value.AddDays(1).ToString(), kindOfFail, lineString, cstwait);
                    foreach (Item i in timeStop)
                    {
                        DataPoint p;
                        p = Chart1.Series["c"].Points.Add(Convert.ToInt32(i.Value)); p.Color = Color.Red; 

                    }
                    Chart1.DataBind();

                }



                if (((Item)cbbLine.SelectedItem).Text.Equals("All"))
                    lblTime.Text = f.GetSumDuration("", dtpFrom.Value.ToString(), dtpTo.Value.AddDays(1).ToString()).ToString() + " phút";
                else lblTime.Text = f.GetSumDuration(((Item)cbbLine.SelectedItem).Text, dtpFrom.Value.ToString(), dtpTo.Value.AddDays(1).ToString()).ToString() + " phút";
                //if(lbl)
             
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
                
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void gvProblem_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
           
                
       DialogResult dialogResult = MessageBox.Show("Chắc chắn xóa ?", "Xac nhan", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                

               // MessageBox.Show(e.Row.Cells[0].Value.ToString());
                f.Remove(Convert.ToInt32(e.Row.Cells[recordIdIndex].Value.ToString()));
                MessageBox.Show("Đã xóa");
                LoadData();
            }
       
        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {

            int temp = rowTemp;
            if (f.QuickGetStatus(RecordIdtemp) < cstfinished)
            {
                f.setStatus(cstprocessing);
                f.setId(RecordIdtemp);
               f.UpdateStatus(employee.getOpName(), "");
              
                if (cbSendMail.Checked)
                {
                    Line li = new Line();
                    li.setLineId(LineIdTemp);
                    li.Load();
                    String failName = failNameTemp;
                    String failGroup = f.getFailGroup(failName);
                    

                    //  MessageBox.Show(RecordIdtemp.ToString());
                    //send mail
                    //send mail
                    //  mail = new Email(RecordIdtemp,employee.getOpName(), li.getMailTo(), li.getMailCC(), failGroup, li.getLineId(), failName, "", status, li.getUpperLevelMail().Split(';').ToList());
                    Email mail = new Email(employee.getOpName(), li.getMailTo(Convert.ToInt32(gvProblem.Rows[temp].Cells[groupFailIndex].Value.ToString())), li.getMailCC(Convert.ToInt32(gvProblem.Rows[temp].Cells[groupFailIndex].Value.ToString())), failGroup, li.getLineId(), failName, "", cstprocessing, li.getUpperLevelMail().Split(';').ToList(), Convert.ToInt32(gvProblem.Rows[temp].Cells[recordIdIndex].Value.ToString()), "", "", "","");
                    mail.Send();
                }
                checkLight();
                LoadData();
                gvProblem.ClearSelection();
                gvProblem.Rows[temp].Selected = true;

            }
            else
            {
                MessageBox.Show("Sự cố đã được xử lý");
                LoadData();
            }
            
           // gvProblem.Rows[rowTemp].Cells[0].Selected = true;
          
           
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            if (f.QuickGetStatus(RecordIdtemp) < cstfinished)
            {
                try
                {
                    int temp = rowTemp;
                    Line li = new Line();
                    li.setLineId(LineIdTemp);
                    li.Load();
                    String failName = failNameTemp;
                    String failGroup = f.getFailGroup(failName);
                    bool isSendMail = false;
                   
                    if (cbSendMail.Checked)
                    {

                        isSendMail = true;
                    }
                    //string des= gvProblem.Rows[temp].Cells[po].Value;
                    SolutionComment comment = new SolutionComment(isSendMail, employee.getOpName(), li.getMailTo(Convert.ToInt32(gvProblem.Rows[temp].Cells[groupFailIndex].Value)), li.getMailCC(Convert.ToInt32(gvProblem.Rows[temp].Cells[groupFailIndex].Value)), failGroup, li.getLineId(), failName, "des", cstprocessing, li.getUpperLevelMail().Split(';').ToList(), RecordIdtemp, "PO", "Model", "Marterial");

                    comment.ShowDialog();
                    LoadData();
                    checkLight();
                    //gvProblem.ClearSelection();
                    //gvProblem.Rows[temp].Selected = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Sự cố đã được xử lý");
                LoadData();
            }
        }


        private void gvProblem_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            
            if (gvProblem.SelectedRows.Count > 0)
            {
                RecordIdtemp = Convert.ToInt32(gvProblem.SelectedRows[0].Cells[recordIdIndex].Value.ToString());
                LineIdTemp = gvProblem.SelectedRows[0].Cells[lineIdIndex].Value.ToString();
                failNameTemp = gvProblem.SelectedRows[0].Cells[failNameIndex].Value.ToString();
                rowTemp= gvProblem.SelectedRows[0].Index;
            }
            
         
        }

        private void gvProblem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gvProblem.Columns[e.ColumnIndex].Name == "Nhom" &&
                e.RowIndex >= 0 &&
                gvProblem["Nhom", e.RowIndex].Value is int)
            {
                int id = (int)gvProblem["Nhom", e.RowIndex].Value;
                
                e.Value = category.getFailGroupNameById(id);
            }

            if (gvProblem.Columns[e.ColumnIndex].Name == "TrangThai" &&
                e.RowIndex >= 0 &&
                gvProblem["TrangThai", e.RowIndex].Value is int)
            {
                switch ((int)gvProblem["TrangThai", e.RowIndex].Value)
                {
                    case 1:
                        e.Value = "Chưa xử lý";
                        gvProblem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        e.FormattingApplied = true;
                        
                          
                        break;
                    case 2:
                        e.Value = "Đang xử lý";
                        gvProblem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        e.FormattingApplied = true;
                        break;
                    case 3:
                        e.Value = "Đã xử lý";
                        gvProblem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                        e.FormattingApplied = true;
                        break;
                }
            }
            
        }

     
        private void CloseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void ReportProblemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNew.PerformClick();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (cbbLine.SelectedItem.ToString().Equals("All"))
                MessageBox.Show("Vui lòng chọn line trước");
            else
            {
                ReportProblem r = new ReportProblem(employee.getOpCode(), cbbLine.SelectedIndex);
                r.MdiParent = this.ParentForm;
                r.ShowDialog();
                LoadData();
            }
            checkLight();
           
        }

        private void SetupEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeopleRelativeSetup config = new PeopleRelativeSetup();
            config.MdiParent = this.ParentForm;
            config.Show();
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
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f.UpdateTimteResume();
            LoadData();
           
        }

        private void cbbStatus_DropDownClosed(object sender, EventArgs e)
        {
            LoadData();
        }

        private void gvProblem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //RecordIdtemp = Convert.ToInt32(gvProblem.SelectedRows[0].Cells[0].Value.ToString());
            //LineIdTemp = gvProblem.SelectedRows[0].Cells[1].Value.ToString();
            //failNameTemp = gvProblem.SelectedRows[0].Cells[2].Value.ToString();
        }
        public string strTitle = "";
        private void Statistics_Load(object sender, EventArgs e)
        {
            Version ver;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ver = ApplicationDeployment.CurrentDeployment.CurrentVersion;//new Version(Application.ProductVersion);
            }
            else
            {
                ver = new Version(Application.ProductVersion);
            }

            

            //Version myVersion;
            strTitle=String.Format("THONG KE SU CO SAN XUAT " + LocalLineId + "  | Version: " + "{0:#}.{1:#} | USER: ", ver.Major, ver.Revision);
            this.Text = strTitle + employee.getOpName();
            cbSendMail.Checked = false;

        }

        private void cbbChartType_DropDownClosed(object sender, EventArgs e)
        {
            LoadData();
        }

        private void AddLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineSetting newline = new LineSetting();
            newline.Show();
        }

        private void Statistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        public void checkLight()
        {

            try
            {



                if (LocalLineId.Length > 0) // line có setup bảng đèn
                {



                    chkFinished.Checked = true;
                    chkFinished.Enabled = true;
                    chkProcessing.Enabled = false;
                    chkWait.Enabled = false;
                    //tắt tất cả đèn-refesh all status
                    serialPort1.RtsEnable = false;
                    serialPort1.DtrEnable = false;
                 
                    if (f.GetCountFailByStatus(LocalLineId, cstwait) > 0)
                    {
                        
                        serialPort1.RtsEnable = true;
                        chkWait.Enabled = true;
                        chkWait.Checked = true;
                        chkFinished.Checked = false;
                        chkFinished.Enabled = false;
                    }

                    if (f.GetCountFailByStatus(LocalLineId, cstprocessing) > 0)
                    {
                      
                        serialPort1.DtrEnable = true;
                        chkProcessing.Enabled = true;
                        chkProcessing.Checked = true;
                        chkFinished.Checked = false;
                        chkFinished.Enabled = false;

                    }

                }
                else
                {

                   groupBox4.Enabled = false;
                }



            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                throw;
            }
            
            
        }

        private void cbbCategory_DropDownClosed(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            
            gbControl.Hide();
            gbSwitchUser.Visible = true;
            gbSwitchUser.Show();
            label3.Show();
            label4.Show();

            txtCode.Show();
            pwdPass.Show();

            txtCode.Text = pwdPass.Text = "";

            txtCode.Focus();
            
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter)) pwdPass.Focus();
        }

        private void pwdPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                employee.setOpCode(txtCode.Text);
                employee.setPwd(pwdPass.Text);
                if (employee.ValidateLogin())
                {
                    gbSwitchUser.Hide();
                    label3.Hide();
                    label4.Hide();
                    txtCode.Hide();
                    pwdPass.Hide();
                    gbControl.Show();
                    employee.Load();
                    Text = strTitle + employee.getOpName();
                }
                else MessageBox.Show("Sai thông tin");
            }
        }

        //private void gvProblem_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        //{
           
        //    Detail detail = new Detail(Convert.ToInt32(gvProblem.Rows[e.RowIndex].Cells[0].Value.ToString()), gvProblem.Rows[e.RowIndex].Cells[2].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[1].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[5].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[6].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[11].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[7].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[3].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[8].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[9].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[10].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[12].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[4].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[13].Value.ToString());
        //    detail.ShowDialog();
        //}

        private void gvProblem_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Detail detail = new Detail(Convert.ToInt32(gvProblem.Rows[e.RowIndex].Cells[recordIdIndex].Value.ToString()), gvProblem.Rows[e.RowIndex].Cells[failNameIndex].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[lineIdIndex].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[stopTimeIndex].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[resumeTimeIndex].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[durationIndex].Value.ToString(), Convert.ToInt32(gvProblem.Rows[e.RowIndex].Cells[statusIndex].Value.ToString()), gvProblem.Rows[e.RowIndex].Cells[reporterIndex].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[equipmentIndex].Value.ToString(),gvProblem.Rows[e.RowIndex].Cells[POIndex].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[modelIndex].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[partIndex].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[repairerIndex].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[descriptionIndex].Value.ToString(), gvProblem.Rows[e.RowIndex].Cells[commentIndex].Value.ToString());
            detail.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            MasterPass masterPass = new MasterPass();
            masterPass.ShowDialog();
            if (masterPass.Result())
            {
                int temp = rowTemp;
                BLFailRecord re = new BLFailRecord();
                re.setId(Convert.ToInt32(gvProblem.Rows[temp].Cells[recordIdIndex].Value.ToString()));
                re.Remove(Convert.ToInt32(gvProblem.Rows[temp].Cells[recordIdIndex].Value.ToString()));
                MessageBox.Show("Đã xóa");
                LoadData();
            }
            
        }

        private void EquipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Equipment eq = new Equipment();
            eq.Show();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export.writeCSV(gvProblem);
        }

        private void ExportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExport.PerformClick();
        }

        private void reportOTDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new OTDPDReport();
           // frm.Show();
            CheckMdiChildren(frm);
        }

        void CheckMdiChildren(Form form)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == form.GetType())
                {
                    frm.Focus();
                    return;
                }
            }

            //form.MdiParent = this;
            form.Show();
        }


        

       

      
    }
}
