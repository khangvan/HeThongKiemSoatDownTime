using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ReportProblem.Business;
using System.Data;



namespace ReportProblem.Data
{
    class DBaction
    {
        SqlConnection cnn;

        /*  Connection  */
        public DBaction()
        {
            String connetionString = "Data Source=10.84.10.67\\SIPLACE_2008R2EX;Initial Catalog=PTR;User ID=reports;Password=reports";
            this.cnn = new SqlConnection(connetionString);
            cnn.Open();
          
        }
        public void Close()
        {
            this.cnn.Close();
        }


        /*  UserAccount Info  */
        public int ChangeEmail(String opCode, String email)
        {
            
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "UPDATE [PTR].[dbo].[ADC_Opcode] SET [Email] = @email WHERE [OpCode] = @opCode";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@opCode", opCode);
            return cmd.ExecuteNonQuery();
            
        }
        public int ChangeDept(String opCode, String dept)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "UPDATE [PTR].[dbo].[ADC_Opcode] SET [Dept] = @d WHERE [OpCode] = @opCode";
            cmd.Parameters.AddWithValue("@d", dept);
            cmd.Parameters.AddWithValue("@opCode", opCode);
            return cmd.ExecuteNonQuery();

        }
        public int ChangePassword(String opCode, String pass)
        {
            HashPass h = new HashPass(pass);
            String pwd = h.getHash();
                
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "UPDATE [PTR].[dbo].[ADC_Opcode] SET [Password] = @pwd WHERE [OpCode] = @opCode";
            cmd.Parameters.AddWithValue("@pwd", pwd);
            cmd.Parameters.AddWithValue("@opCode", opCode);
           return cmd.ExecuteNonQuery();

        }
        public bool VerifyUser(String opCode, String pass)
        {
            bool verify = false;
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT Password FROM [PTR].[dbo].[ADC_Opcode] WHERE [OpCode] = @op";
           cmd.Parameters.AddWithValue("@op", opCode);
            SqlDataReader myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
               
                if(myreader.GetValue(0).ToString().Equals(pass))
                verify = true;   
            
            }
            
           
            return verify;
        }
        public string GetNameFromMail(String m)
        {
           
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT [OpName] FROM [PTR].[dbo].[ADC_Opcode] WHERE [Email] LIKE '%"+m+"%'";
            
            SqlDataReader myreader = cmd.ExecuteReader();
            string name = "";
            while (myreader.Read())
            {

                name += myreader.GetValue(0).ToString();

            }


            return name;
        }
        public bool existed(String opCode)
        {
            bool verify = false;
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT OpCode FROM [PTR].[dbo].[ADC_Opcode] WHERE [OpCode] = @op";
            cmd.Parameters.AddWithValue("@op", opCode);
            SqlDataReader myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {

 
                    verify = true;

            }


            return verify;
        }
        public Employee getUserInfo(String opcode)
        {

          Employee e= new Employee();
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT OpCode, OpName, Email, Password,Dept FROM [PTR].[dbo].[ADC_Opcode] WHERE [OpCode]=@op ";
            cmd.Parameters.AddWithValue("@op",opcode);

            SqlDataReader myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                e.setOpCode(myreader.GetValue(0).ToString());
                e.setName(myreader.GetValue(1).ToString());
                e.setEmail(myreader.GetValue(2).ToString());
                e.setPwd(myreader.GetValue(3).ToString());
                e.setDept(myreader.GetValue(4).ToString());

            }
            return e;
        }
        public int AddUser(String opcode,String OpName, String pwd,String email,String dept)
        {
            HashPass h = new HashPass(pwd);
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "INSERT INTO [PTR].[dbo].[ADC_Opcode](OpCode, Password, Email, OpName, Dept) VALUES(@op,@p,@m,@n,@d)";
            cmd.Parameters.AddWithValue("@op", opcode);
            cmd.Parameters.AddWithValue("@p", h.getHash());
            cmd.Parameters.AddWithValue("@m", email);
            cmd.Parameters.AddWithValue("@n", OpName);
            cmd.Parameters.AddWithValue("@d", dept);
           return  cmd.ExecuteNonQuery();

        }


        /*  Failure Info  */
        public void AddFailGroup(String failGroup)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "INSERT INTO  [PTR].[dbo].[FailGroup](GroupName) VALUES(@group)";
            cmd.Parameters.AddWithValue("@group", failGroup);
          
            cmd.ExecuteNonQuery();

        }
        public void UpdateFailGroup(int id, String groupName)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "UPDATE [PTR].[dbo].[FailGroup] SET [GroupName] = @g WHERE [Id] = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@g", groupName);
            cmd.ExecuteNonQuery();

        }
         public void RemoveFailGroup(int id)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM [PTR].[dbo].[FailGroup]  WHERE [Id] = @id";
            cmd.Parameters.AddWithValue("@id", id);
           
            cmd.ExecuteNonQuery();

        }
        
         public DataTable getFailRecord(String from, String to,String line,int stt)
         {
           
             String plus="";
             if (stt > 0) plus = " AND [Status] = " + stt;
             //record dang va chua xu ly
             if (stt == 4) plus = " AND [Status] <3 ";
           //  if (failGroup > 0) plus += " AND [FailGroup] =" + failGroup;
               SqlCommand cmd;
             cmd = cnn.CreateCommand();
             if (line.Length > 0)
             {
                 cmd.CommandText = "SELECT RecordId as MaSuCo,Line,FailGroup as Nhom, Fail as SuCo,OpName as NguoiBaoCao, Description as Mota,TimeStop as ThoiGianDung, TimeResume as ThoiGianChayLai,Status as TrangThai, [PTR].[dbo].[EquipmentList].[Name] as TenThietBi, PO,Model,Material as Part,Duration as TGDung,Repairer as NguoiSuaChua,Comment as GiaiPhap  FROM [PTR].[dbo].[FailRecord],[PTR].[dbo].[Failure],[PTR].[dbo].[ADC_Opcode],[PTR].[dbo].[EquipmentList] WHERE [TimeStop] >= '" + from + "' AND [TimeStop] <= '" + to + "' AND [Failure] = [PTR].[dbo].[Failure].[Id] AND [Line] =@line AND [reporter] = [OpCode] and [PTR].[dbo].[EquipmentList].[Id] = [PTR].[dbo].[FailRecord].[Equipment] " + plus;
                 cmd.Parameters.AddWithValue("@line", line);
             }
             else
                 cmd.CommandText = "SELECT RecordId as MaSuCo,Line,FailGroup as Nhom,Fail as SuCo,OpName as NguoiBaoCao, Description as Mota,TimeStop as ThoiGianDung, TimeResume as ThoiGianChayLai,Status as TrangThai,[PTR].[dbo].[EquipmentList].[Name] as TenThietBi, PO,Model,Material as Part,Duration as TGDung,Repairer as NguoiSuaChua,Comment as GiaiPhap FROM [PTR].[dbo].[FailRecord],[PTR].[dbo].[Failure],[PTR].[dbo].[ADC_Opcode],[PTR].[dbo].[EquipmentList] WHERE [TimeStop] >= '" + from + "' AND [TimeStop] <= '" + to + "' AND [Failure] = [PTR].[dbo].[Failure].[Id]  AND [reporter] = [OpCode] and [PTR].[dbo].[EquipmentList].[Id] = [PTR].[dbo].[FailRecord].[Equipment]" + plus;
            
             
             DataTable data = new DataTable();
             data.Load(cmd.ExecuteReader());
             cmd.Dispose();
             return data;
         }
         public void RemoveFailRecord(int id)
         {

             SqlCommand cmd;
             cmd = cnn.CreateCommand();
             cmd.CommandText = "DELETE FROM [PTR].[dbo].[FailRecord]  WHERE [RecordId] = @id";
             cmd.Parameters.AddWithValue("@id", id);

             cmd.ExecuteNonQuery();

         }
         public int GetDate(int id)
         {
             int r = 0;
             SqlCommand cmd;
             cmd = cnn.CreateCommand();
             cmd.CommandText = "SELECT [TimeStop] FROM [PTR].[dbo].[FailRecord] WHERE [RecordId]=@id ";
             cmd.Parameters.AddWithValue("@id", id);

             SqlDataReader myreader = cmd.ExecuteReader();
             while (myreader.Read())
             {
                 r = Convert.ToInt32(myreader.GetValue(0).ToString());
                 break;

             }
             return r;

         }
         public List<Item> getSumFail(String from, String to,String line)
         {

             SqlCommand cmd;
             cmd = cnn.CreateCommand();
             if (line.Length > 0)
             {
                 cmd.CommandText = "SELECT DISTINCT Fail, [PTR].[dbo].[FailRecord].[Failure] FROM [PTR].[dbo].[FailRecord] JOIN [PTR].[dbo].[Failure] ON [PTR].[dbo].[FailRecord].[Failure] = [PTR].[dbo].[Failure].[Id] WHERE [TimeStop] >= '" + from + "' AND [TimeStop] <= '" + to + "' AND [Line] = @line";
                 cmd.Parameters.AddWithValue("@line",line);
             }
             else
             cmd.CommandText = "SELECT DISTINCT Fail, [PTR].[dbo].[FailRecord].[Failure] FROM [PTR].[dbo].[FailRecord] JOIN [PTR].[dbo].[Failure] ON [PTR].[dbo].[FailRecord].[Failure] = [PTR].[dbo].[Failure].[Id] WHERE [TimeStop] >= '" + from + "' AND [TimeStop] <= '" + to + "'";

             SqlDataReader r = cmd.ExecuteReader();

             List<Item> l = new List<Item>();
             while (r.Read())
             {
                 Item i = new Item(r.GetValue(0).ToString(),Convert.ToInt32(r.GetValue(1)));
                 l.Add(i);
                
             }
             return l;
         }

         public int getSumByFailAndStatus(String from, String to,int fail, int stt,String line)
         {

             SqlCommand cmd;
             cmd = cnn.CreateCommand();
             if (line.Length > 0)
             {
                 cmd.CommandText = "SELECT COUNT(*) FROM [PTR].[dbo].[FailRecord] WHERE [TimeStop] >= '" + from + "' AND [TimeStop] <= '" + to + "' AND [Status] = " + stt + " AND [Failure] = " + fail+" AND [Line] = @line";

                 cmd.Parameters.AddWithValue("@line", line);
             }
             else

             cmd.CommandText = "SELECT COUNT(*) FROM [PTR].[dbo].[FailRecord] WHERE [TimeStop] >= '" + from + "' AND [TimeStop] <= '" + to + "' AND [Status] = " + stt+" AND [Failure] = "+fail;

             SqlDataReader r = cmd.ExecuteReader();

             int count = 0;
             while (r.Read())
             {
                count = Convert.ToInt32(r.GetValue(0));

             }
             return count;
         }
        // return list of FailgroupId, assign name of failgroup to n
         public List<String> getAllFailGroup(List<string> n)
         {

             List<String> l = new List<string>();
             SqlCommand cmd;
             cmd = cnn.CreateCommand();
             cmd.CommandText = "SELECT Id, GroupName FROM [PTR].[dbo].[FailGroup] ";


             SqlDataReader myreader = cmd.ExecuteReader();
             while (myreader.Read())
             {
                 l.Add(myreader.GetValue(0).ToString());
                 n.Add(myreader.GetValue(1).ToString());

             }
             return l;
         }
         public String getFailGroupNameById(int id)
         {

            
             SqlCommand cmd;
             cmd = cnn.CreateCommand();
             cmd.CommandText = "SELECT  GroupName FROM [PTR].[dbo].[FailGroup] where Id= "+id;


             SqlDataReader myreader = cmd.ExecuteReader();
             String result = "";
             while (myreader.Read())
             {
                result = myreader.GetValue(0).ToString();
                

             }
             return result;
         }
         public String GetFailGroup(String failName)
         {
             SqlCommand cmd;
             cmd = cnn.CreateCommand();
             cmd.CommandText = "SELECT  GroupName FROM [PTR].[dbo].[FailGroup],[PTR].[dbo].[Failure] WHERE [FailGroup] = [PTR].[dbo].[FailGroup].Id AND [PTR].[dbo].[Failure].Fail = '"+failName+"'";

             String result = "";
             SqlDataReader myreader = cmd.ExecuteReader();
             while (myreader.Read())
             {
                 result =myreader.GetValue(0).ToString();
                

             }
             return result;
         }
        public void AddFailure(String fail,int group)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "INSERT INTO [PTR].[dbo].[Failure](Fail, FailGroup) VALUES(@fail,@group)";
            cmd.Parameters.AddWithValue("@group", group);
            cmd.Parameters.AddWithValue("@fail", fail);
            cmd.ExecuteNonQuery();

        }
        public void AddEquipment(String equip)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "INSERT INTO [PTR].[dbo].[EquipmentList]( [Name]) VALUES(@equip)";
            cmd.Parameters.AddWithValue("@equip", equip);
          
            cmd.ExecuteNonQuery();

        }

        public void RemoveEquipment(int id)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM [PTR].[dbo].[EquipmentList] WHERE [Id]= "+id;
          

            cmd.ExecuteNonQuery();

        }
        public List<Item> GetEquipList()
        {
            List<Item> l = new List<Item>();
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT  Id,Name FROM [PTR].[dbo].[EquipmentList]";

           
            SqlDataReader myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                l.Add(new Item(myreader.GetValue(1).ToString(), myreader.GetInt32(0)));
               


            }
            return l;
        }

        public DataTable GetEquipDataTable()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT  Id,Name FROM [PTR].[dbo].[EquipmentList]";


            dt.Load(cmd.ExecuteReader());
            
            return dt;
        }
        public void UpdateFailure(int id, String failure)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "UPDATE [PTR].[dbo].[Failure] SET [Fail] = @f WHERE [Id] = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@f", failure);
            cmd.ExecuteNonQuery();

        }
        public void UpdateFailure(String oldName, String failure)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "UPDATE [PTR].[dbo].[Failure] SET [Fail] = @f WHERE [Fail] = @old";
            cmd.Parameters.AddWithValue("@old", oldName);
            cmd.Parameters.AddWithValue("@f", failure);
            cmd.ExecuteNonQuery();

        }
        public void RemoveFailure(int id)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM [PTR].[dbo].[Failure]  WHERE [Id] = @id";
            cmd.Parameters.AddWithValue("@id",id);

            cmd.ExecuteNonQuery();

        }


        public int AddFailRecord(int fail, String reporter,String description,String PO, String model,String material,String line,int equip)
        {
        
            try
            {
                //kcheck
                //SP_Processing.MySqlConn msqlcon = new SP_Processing.MySqlConn("vnmsrv601_PTR");
                // msqlcon.ExecSProc("[InsertFailRecord]", fail,reporter, description,PO,model,material,line,equip);
                 return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

            

            //try
            //{


                

            //    SqlCommand cmd;
            //    cmd = cnn.CreateCommand();
            //    cmd.CommandText = "INSERT INTO [PTR].[dbo].[FailRecord](Failure, Reporter, Description, PO, Model, Material, TimeStop, Status, Line, Duration,Equipment) VALUES(@f, @r, @d , @p, @m, @ma, @n, 1,@l,0.0,@equip)";
            //    cmd.Parameters.AddWithValue("@f", fail);
            //    cmd.Parameters.AddWithValue("@r", reporter);
            //    cmd.Parameters.AddWithValue("@D", description);
            //    cmd.Parameters.AddWithValue("@p", PO);
            //    cmd.Parameters.AddWithValue("@m", model);
            //    cmd.Parameters.AddWithValue("@ma", material);
            //    cmd.Parameters.AddWithValue("@n", now);
            //    cmd.Parameters.AddWithValue("@l", line);
            //    cmd.Parameters.AddWithValue("@equip", equip);
            //    return cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{

            //    return -1;
            //}

        }
        // return list of FailgroupId, assign name of failgroup to n
        public List<String> getFail(List<string> n, int group)
        {

            List<String> l = new List<string>();
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT Id, Fail FROM [PTR].[dbo].[Failure] WHERE [FailGroup] =@g";
            cmd.Parameters.AddWithValue("@g",group);

            SqlDataReader myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                l.Add(myreader.GetValue(0).ToString());
                n.Add(myreader.GetValue(1).ToString());

            }
            return l;
        }
        public double getSumDuration(String line,String from,String to)
        {

            
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            if (line.Length > 0)
            {
                cmd.CommandText = "SELECT SUM([Duration]) FROM [PTR].[dbo].[FailRecord] WHERE Line = @l AND [TimeStop] >= '" + from + "' AND [TimeStop] <= '" + to+"'" ;
                cmd.Parameters.AddWithValue("@l", line);
                
            }
            else
                cmd.CommandText = "SELECT SUM([Duration]) FROM [PTR].[dbo].[FailRecord] WHERE [TimeStop] >= '" + from + "' AND [TimeStop] <= '" + to + "'";
           

            SqlDataReader myreader = cmd.ExecuteReader();
            double sum = 0.0;
            while (myreader.Read())
            {
                if (!myreader.IsDBNull(0))
                sum = Convert.ToDouble(myreader.GetValue(0));
              
            }
            return sum;
        }
        public double getSumDurationByFailAndStatus(String line, String from, String to,int fail,int stt)
        {


            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            if (line.Length > 0)
            {
                cmd.CommandText = "SELECT SUM([Duration]) FROM [PTR].[dbo].[FailRecord] WHERE Line = @l AND [TimeStop] >= '" + from + "' AND [TimeStop] <= '" + to + "' AND [Failure] = "+fail+ " AND [Status] = "+stt ;
                cmd.Parameters.AddWithValue("@l", line);

            }
            else
                cmd.CommandText = "SELECT SUM([Duration]) FROM [PTR].[dbo].[FailRecord] WHERE [TimeStop] >= '" + from + "' AND [TimeStop] <= '" + to + "' AND [Failure] = " + fail+" AND [Status] = "+stt ;


            SqlDataReader myreader = cmd.ExecuteReader();
            double sum = 0.0;
            while (myreader.Read())
            {
                if (!myreader.IsDBNull(0))
                    sum = Convert.ToDouble(myreader.GetValue(0));

            }
            return sum;
        }
        public int getCountFailByStatus(String line, String from, String to,int stt)
        {
            String StringLine="";
            List<String> lines = line.Split(',').ToList();
            foreach (String i in lines) StringLine += "'" + i + "',";
            StringLine = StringLine.Substring(0, StringLine.Length - 1);
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            if (line.Length > 0)
            {
             
                cmd.CommandText = "SELECT COUNT(*) FROM [PTR].[dbo].[FailRecord] WHERE Line IN ( @l ) AND [TimeStop] >= '" + from + "' AND [TimeStop] <= '" + to + "' AND [Status] = "+stt;
                cmd.Parameters.AddWithValue("@l", StringLine);
            
            }
            else
                cmd.CommandText = "SELECT COUNT(*) FROM [PTR].[dbo].[FailRecord] WHERE [TimeStop] >= '" + from + "' AND [TimeStop] <= '" + to + "' AND [Status] = " + stt;


            SqlDataReader myreader = cmd.ExecuteReader();
            int sum = 0;
            while (myreader.Read())
            {
                if (!myreader.IsDBNull(0))
                    sum = myreader.GetInt32(0);

            }
            return sum;
        }
        public int getCountFailByStatus(String line, int stt)
        {

            String StringLine = "";
            List<String> lines = line.Split(',').ToList();
            foreach (String i in lines) StringLine += "'" + i + "',";
            StringLine = StringLine.Substring(0, StringLine.Length - 1);
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            if (line.Length > 0)
            {
                cmd.CommandText = "SELECT COUNT(*) FROM [PTR].[dbo].[FailRecord] WHERE Line  IN ( @l ) AND [Status] = " + stt;
                cmd.Parameters.AddWithValue("@l", StringLine);

            }
            else
                cmd.CommandText = "SELECT COUNT(*) FROM [PTR].[dbo].[FailRecord] WHERE [Status] = " + stt;


            SqlDataReader myreader = cmd.ExecuteReader();
            int sum = 0;
            while (myreader.Read())
            {
                if (!myreader.IsDBNull(0))
                    sum = myreader.GetInt32(0);

            }
            return sum;
        }
        public DataTable getFailAndGroup()
        {

            DataTable d = new DataTable();
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT GroupName as Nhom, Fail as SuCo, [PTR].[dbo].[Failure].Id as Id FROM [PTR].[dbo].[Failure], [PTR].[dbo].[FailGroup] WHERE [PTR].[dbo].[FailGroup].Id = [PTR].[dbo].[Failure].FailGroup order by GroupName";
            d.Load(cmd.ExecuteReader());
          
            return d;
        }
        public int getStatus(int id)
        {

        
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT [Status] FROM [PTR].[dbo].[FailRecord] WHERE RecordId = '"+id+"'";

            SqlDataReader reader = cmd.ExecuteReader();
            int d = 1;
            while (reader.Read())
            {
                d = reader.GetInt32(0);
            }

            return d;
        }
        public void UpdateStatus(int id, int status,String repairer,String  comment)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            if (status == 3)
            {
                cmd.CommandText = "UPDATE [PTR].[dbo].[FailRecord] SET [status] = @stt,[TimeResume]=@now, [Repairer]=@repairer,[Comment]=@comment WHERE [RecordId] = @id";
                cmd.Parameters.AddWithValue("@now", ServerTime.current());
                 cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@stt",status);
                cmd.Parameters.AddWithValue("@repairer", repairer);
                cmd.Parameters.AddWithValue("@comment", comment);
                cmd.ExecuteNonQuery();
                cmd = cnn.CreateCommand();
                cmd.CommandText = "UPDATE [PTR].[dbo].[FailRecord] SET [Duration] = DATEDIFF(MINUTE,[TimeStop],[TimeResume]) WHERE [RecordId] = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            else{
                cmd.CommandText = "UPDATE [PTR].[dbo].[FailRecord] SET [status] = @stt, [Repairer]=@repairer WHERE [RecordId] = @id";
          
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@stt",status);
            cmd.Parameters.AddWithValue("@repairer", repairer);
            cmd.ExecuteNonQuery();
            }

        }
        public void UpdateFailureForFailRecord(int oldFailId, int newFailId)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
           
                cmd.CommandText = "UPDATE [PTR].[dbo].[FailRecord] SET [Failure] = @f WHERE [Failure] = @old";

                cmd.Parameters.AddWithValue("@old", oldFailId);
                cmd.Parameters.AddWithValue("@f", newFailId);
             
                cmd.ExecuteNonQuery();
            

        }
        public int GetLastRecordId()
        {
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT MAX(RecordId) FROM [PTR].[dbo].[FailRecord]";
          

            SqlDataReader myreader = cmd.ExecuteReader();
            int r = 0;
            while (myreader.Read())
            {
                
                r = Convert.ToInt32(myreader.GetValue(0));
               
            }
            return r;
        }
        public void UpdateTimeResume()
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            DateTime now = ServerTime.current();
                cmd.CommandText = "UPDATE [PTR].[dbo].[FailRecord] SET [TimeResume] = @n WHERE [status] <> 3";

                cmd.Parameters.AddWithValue("@n",now);
            cmd.ExecuteNonQuery();


            cmd = cnn.CreateCommand();
            cmd.CommandText = "UPDATE [PTR].[dbo].[FailRecord] SET [Duration] = DATEDIFF(MINUTE,[TimeStop],[TimeResume])";
            cmd.ExecuteNonQuery();
              
        }

        /*  Line Info  */
        public void AddLine(String LineId,String LineName)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "INSERT INTO  [PTR].[dbo].[tblLineName](LineID, LineName) VALUES(@id, @name)";
            cmd.Parameters.AddWithValue("@id", LineId);
            cmd.Parameters.AddWithValue("@name", LineName);
            cmd.ExecuteNonQuery();

        }
        public int UpdateMailList(String LineId, String mailToMachine, String mailCcMachine, String mailToMaterial, String mailCcMaterial, String mailToMan, String mailCcMan, String mailToMethod, String mailCcMethod, String upperLevelMail)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "UPDATE [PTR].[dbo].[tblLineName] SET [MailToMaterial] = @mailToMaterial, [MailCCMaterial] = @mailCcMaterial,[MailToMan] =@mailToMan, [MailCCMan]= @mailCcMan, [MailToMachine]= @mailToMachine, [MailCCMachine] = @mailCcMachine, [MailToMethod]=@mailToMethod,[MailCCMethod]=@mailCcMethod, [UpperLevelMail] =@up WHERE [LineID] = @id";
            cmd.Parameters.AddWithValue("@id", LineId);
            cmd.Parameters.AddWithValue("@mailToMaterial", mailToMaterial);
            cmd.Parameters.AddWithValue("@mailCcMaterial", mailCcMaterial);

            cmd.Parameters.AddWithValue("@mailToMan", mailToMan);
            cmd.Parameters.AddWithValue("@mailCcMan", mailCcMan);

            cmd.Parameters.AddWithValue("@mailToMachine", mailToMachine);
            cmd.Parameters.AddWithValue("@mailCcMachine", mailCcMachine);

            cmd.Parameters.AddWithValue("@mailToMethod", mailToMethod);
            cmd.Parameters.AddWithValue("@mailCcMethod", mailCcMethod);


            cmd.Parameters.AddWithValue("@up", upperLevelMail);
          return  cmd.ExecuteNonQuery();

        }
        public void UpdateLineName(String id, String line)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "UPDATE [PTR].[dbo].[tblLineName] SET [LineName] = @line WHERE [LineID] = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@line", line);
            cmd.ExecuteNonQuery();

        }
        public void RemoveLine(String id)
        {

            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "DELETE FROM [PTR].[dbo].[tblLineName]  WHERE [LineID] = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

        }
        public String[] getMail(String lineCode)
        {
            String[] mail = new String[9];
            
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT MailToMachine,MailCCMachine, MailToMaterial,MailCCMaterial,MailToMan,MailCCMan, MailToMethod,MailCCMethod, UpperLevelMail FROM [PTR].[dbo].[tblLineName] WHERE [LineID] = @li";
            cmd.Parameters.AddWithValue("@li", lineCode);
           
            SqlDataReader myreader = cmd.ExecuteReader();
             while (myreader.Read())
             {
                 mail[0] = myreader.GetValue(0).ToString();
                 mail[1] = myreader.GetValue(2).ToString();
                 mail[2] = myreader.GetValue(4).ToString();
                 mail[3] = myreader.GetValue(6).ToString();
                 mail[4] = myreader.GetValue(1).ToString();
                 mail[5] = myreader.GetValue(3).ToString();
                 mail[6] = myreader.GetValue(5).ToString();
                 mail[7] = myreader.GetValue(7).ToString();
                 mail[8] = myreader.GetValue(8).ToString();
                 break;
             }
             return mail;
        }
        public String getMailCC(String lineCode)
        {
            String mail = "";
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT MailCC FROM [PTR].[dbo].[tblLineName] WHERE [LineID] = @li";
            cmd.Parameters.AddWithValue("@li", lineCode);

            SqlDataReader myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                mail = myreader.GetValue(0).ToString();
                break;
            }
            return mail;
        }
        public String getUpperLevelMail(String lineCode)
        {
            String mail = "";
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT UpperLevelMail FROM [PTR].[dbo].[tblLineName] WHERE [LineID] = @li";
            cmd.Parameters.AddWithValue("@li", lineCode);

            SqlDataReader myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                mail = myreader.GetValue(0).ToString();
                break;
            }
            return mail;
        }
        public List<String> getAllLineCode()
        {

            List<String> l = new List<string>();
            SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = "SELECT LineID FROM [PTR].[dbo].[tblLineName] ";
         

            SqlDataReader myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                l.Add(myreader.GetValue(0).ToString());
               
            }
            return l;
        }
        public DateTime getCurrentTime()
        {
            DateTime d = new DateTime();
             SqlCommand cmd;
            cmd = cnn.CreateCommand();
            cmd.CommandText = " select getdate() ";
         

            SqlDataReader myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                d = myreader.GetDateTime(0);
               
            }
            return d;
        }
        //public Line getLineInfo(String id)
        //{

        //    Line l = new Line();
        //    SqlCommand cmd;
        //    cmd = cnn.CreateCommand();
        //    cmd.CommandText = "SELECT MailTo,MailCC,UpperLevelMail FROM [PTR].[dbo].[tblLineName] WHERE [LineID]=@id ";
        //    cmd.Parameters.AddWithValue("@id", id);
        //    Console.WriteLine(id);
        //    SqlDataReader myreader = cmd.ExecuteReader();
        //    while (myreader.Read())
        //    {
        //        l.setMailTo(myreader.GetValue(0).ToString());
        //        l.setMailCC(myreader.GetValue(1).ToString());
        //        l.setUpperLevelMail(myreader.GetValue(2).ToString());
             

        //    }
        //    return l;
        //}
    }
}
