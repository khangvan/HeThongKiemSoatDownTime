using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportProblem.Business
{
    class Email
    {
        public String reporter;
        public String to;
        public String cc;
        public String subject;
        public StringBuilder content = new StringBuilder();

        public string comment="";

        //constant
        private static int wait = 1;
        private static int processing = 2;
        private static int finished = 3;

        public Email(String r, String t, String c, String failGroup, String line, String fail, String des, int status, List<String> mailOfProductEngineer, int RecordId ,String equip, String po , String model , String material)
        {
           
            to = t;
            cc = c;
            reporter = r;
            subject = "[BC#"+RecordId+"_"+ failGroup +"_" +line.Trim()+"] "+fail ;

            content.Clear();
            content.Append("Dear All,");
            // get name of product engineer
            Employee em = new Employee();

           // Console.WriteLine()
           // content.Append(em.GetNameFromMail(mailOfProductEngineer));
            content.Append("%0A");
            content.Append(Environment.NewLine);
                //add date to content
           
                content.Append("Mã sự cố: "); content.Append(RecordId); content.Append("%0A");

                content.Append("Sự cố: "); content.Append(fail); content.Append("%0A");
                content.Append("Line: "); content.Append(line); content.Append("%0A");
                content.Append("Người báo cáo: "); content.Append(reporter); content.Append("%0A");
                content.Append("%0A");

            //Khang add
                content.Append("Mô tả: "); content.Append(des); content.Append("%0A");
                if (equip.Trim().Length > 0)
                {
                    content.Append("Thiết bị: "); content.Append(equip.Trim()); content.Append("%0A");
                }
                if (po.Length > 0)
                {
                    content.Append("PO: "); content.Append(po); content.Append("%0A");
                }
                if (model.Length > 0)
                {
                    content.Append("Model: "); content.Append(model); content.Append("%0A");
                }
                if (material.Length > 0)
                {
                    content.Append("Part: "); content.Append(material); content.Append("%0A");
                }
            //Khang add
                content.Append("%0A");
                switch (status)
                {
                    case 1:
                        {
                            //content.Append("Mô tả: "); content.Append(des); content.Append("%0A");
                            //if (equip.Trim().Length > 0)
                            //{
                            //    content.Append("Thiết bị: "); content.Append(equip.Trim()); content.Append("%0A");
                            //}
                            //if (po.Length > 0)
                            //{
                            //    content.Append("PO: "); content.Append(po); content.Append("%0A");
                            //}
                            //if (model.Length > 0)
                            //{
                            //    content.Append("Model: "); content.Append(model); content.Append("%0A");
                            //}
                            //if (material.Length > 0)
                            //{
                            //    content.Append("Part: "); content.Append(material); content.Append("%0A");
                            //}
                            content.Append("Gửi báo cáo khởi tạo sự cố"); 
                            content.Append("%0A");
                            break;
                        }
                    case 2:
                        {
                            content.Append("Thông báo sự cố đang được xử lý"); 
                            content.Append("%0A"); 
                            break;
                        }
                    case 3:
                        {
                            content.Append("Thông báo sự cố đã được xử lý"); 
                            content.Append("%0A");
                            break;
                        }
                    default: break;
                }
    

        }
  

     
        public Email() 
        {

        }
        public void Send()
        {
            if (comment.Length > 0)
            {

                content.Append("Giải pháp:".PadRight(14, ' ')); content.Append(comment); content.Append("%0A");
            }
            content.Append("Báo cáo lúc ".PadRight(14, ' ')); content.Append(ServerTime.current());
            //   + "%0A" + des + "%0A" + "Bao cao luc " + DateTime.Now;


            if (!getOSInfo().Equals("7"))
            {
                String a = ConvertVN(content.ToString());
                content.Clear();
                content.Append(a);
            }
            //MessageBox.Show();
            //MessageBox.Show();
            //MessageBox.Show();
            //MessageBox.Show();
            if(cc.Length >0 )
            System.Diagnostics.Process.Start("mailto:"+to+"&cc="+cc+"&subject="+subject+"&body="+content);
            else System.Diagnostics.Process.Start("mailto:" + to + "&subject=" + subject + "&body=" + content);


            // tiep tu debug
           // SendEmail(, subject, content);
            
        }
        public static void SendEmail(string _ToEmail, string _Subject, StringBuilder _EmailBody)
        {//ok

            Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem email = (Microsoft.Office.Interop.Outlook.MailItem)(oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem));
            email.Recipients.Add(_ToEmail);
            //add to CC
                email.Subject = _Subject;

                
                
            //string
                //string body = _EmailBody.ToString();
                //body = body.Replace("%0A", "\r\n");
                //body = string.Format(body);
            //string

                email.Body = _EmailBody.ToString().Replace("%0A", "\r\n");
            //email.Body = string.Format(_EmailBody.ToString());
            ((Microsoft.Office.Interop.Outlook.MailItem)email).Send();
        }

        // get OS info: win XP, win 7...
        public string getOSInfo()
        {
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else
                            operatingSystem = "7";
                        break;
                    default:
                        break;
                }
            }
            return operatingSystem;
        }
        public static string ConvertVN(string chucodau)
        {
            const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
            int index = -1;
            char[] arrChar = FindText.ToCharArray();
            while ((index = chucodau.IndexOfAny(arrChar)) != -1)
            {
                int index2 = FindText.IndexOf(chucodau[index]);
                chucodau = chucodau.Replace(chucodau[index], ReplText[index2]);
            }
            return chucodau;
        }
       
     }
        
 }

