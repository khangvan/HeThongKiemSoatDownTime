using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportProblem.Data;
using System.Data;


namespace ReportProblem.Business
{
    class BLFailRecord
    {
        private int Id;
        private int failure;
        private String failureText;
        private String reporter;
        private String description;
        private String PO;
        private String model;
        private String material;
        private DateTime timeStop;
        private DateTime timeResume;
        private int status;
        private String line;
        private int equip;

        public void setId(int i)
        {
            Id = i;
        }
        public int getId()
        {
            return Id;
        }
        public void setEquip(int i)
        {
            equip= (i < 0) ? 1 : i;
//            equip = i;
        }
        public int getEquip()
        {
            return equip;
        }
        public void setFailureId(int fail)
        {
            failure = fail;
        }
        public int getFailureId()
        {
            return failure;
        }
        public void setReporterCode(String r)
        {
            reporter = r;
        }
        public String getReporterCode()
        {
            return reporter;
        }
        public void setDescription(String des)
        {
            description = des;
        }
        public String getDescription()
        {
            return description;
        }
        public void setPO(String p)
        {
            PO = p;
        }
        public String getPO()
        {
            return PO;
        }
        public void setModel(String mod)
        {
            model = mod;
        }
        public String getModel()
        {
            return model;
        }
        public void setMaterial(String mat)
        {
            material = mat;
        }
        public String getMaterial()
        {
            return material;
        }
        public void setTimeStop(DateTime stop)
        {
            timeStop = stop;
        }
        public DateTime getTimeStop()
        {
            return timeStop;
        }
        public void setTimeResume(DateTime resume)
        {
            timeResume = resume;
        }
        public DateTime getTimeResume()
        {
            return timeResume;
        }
        public void setStatus(int stt)
        {
            status = stt;
        }
        public int getStatus()
        {
            return status;
        }
        public void setLine(String l)
        {
            line = l;
        }
        public String getLine()
        {
            return line;
        }
        public void setFailText(String l)
        {
            failureText = l;
        }
        public String getFailText()
        {
            return failureText;
        }
        public bool AddFailRecord(int fail, String reporter, String description, String PO, String model, String material, String line, int equip)
        {
            try
            {
                SP_Processing.MySqlConn msqlcon = new SP_Processing.MySqlConn("vnmsrv601_PTR");
                int i = msqlcon.ExecSProc("[amevn_InsertFailRecord]", failure, reporter, description, PO, model, material, line, equip);
                
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public bool Add( )
        {
            bool result = false;

            SP_Processing.MySqlConn msqlcon = new SP_Processing.MySqlConn("vnmsrv601_PTR");
           string a=  msqlcon.ExecSProcDS("[amevn_InsertFailRecord]", failure, reporter, description, PO, model, material, line, equip).Tables[0].Rows[0][0].ToString();
            if (a=="OK")
            {
                return true;
            }
            else
            {
                
                return false;
            }

            //DBaction db = new DBaction();
            //result = AddFailRecord(this.failure, this.reporter, this.description, this.PO, this.model, this.material, this.line, this.equip);
            //db.Close();
            return result;
        }
        public void UpdateStatus(String reporter,String  comment)
        {
            DBaction db = new DBaction();
            db.UpdateStatus(this.Id, this.status,reporter,comment);
           db.Close();
        }
        public void Remove(int id)
        {
            DBaction db = new DBaction();
            db.RemoveFailRecord(id);
            db.Close();
        }
    
        public DataTable GetFailRecordList(String from, String to,String line,int stt)
        {

            DBaction db = new DBaction();
            DataTable data = db.getFailRecord(from, to, line, stt);
            db.Close();
            return data;
        }
        public String getFailGroup(String failName)
        {
            DBaction db = new DBaction();
            String g = db.GetFailGroup(failName);
            db.Close();
            return g;
        }
        public List<Item>  getSumfail(String fr,String to,String line)
        {
            DBaction db = new DBaction();
            List<Item>  kind = db.getSumFail(fr,to,line);
            db.Close();
            return kind;
        }
        public List<Item> getSumByFailAndStatus(String fr, String to, List<Item> fail, int stt,String li)
        {
            
            List<Item> l = new List<Item>();
            
            foreach (Item i in fail)
            {
                DBaction db = new DBaction();
                Item j = new Item(i.Text,db.getSumByFailAndStatus(fr, to, Convert.ToInt32(i.Value), stt,li));
               
                db.Close();
                l.Add(j);
            }
          
            return l;
        }
        public List<Item> getSumDurationByFailAndStatus(String fr, String to, List<Item> fail, String li, int stt)
        {

            List<Item> l = new List<Item>();

            foreach (Item i in fail)
            {
                DBaction db = new DBaction();
                Item j = new Item(i.Text, db.getSumDurationByFailAndStatus(li,fr, to, Convert.ToInt32(i.Value),stt));

                db.Close();
                l.Add(j);
            }

            return l;
        }
        public int GetDate()
        {
            DBaction db = new DBaction();
            int d = db.GetDate(this.Id);
            db.Close();
            return d;

         }
        public double GetSumDuration(String l,String from,String to)
        {

            DBaction db = new DBaction();
            double d = db.getSumDuration(l,from,to);
            db.Close();
            return d;

        }
        public void UpdateTimteResume()
        {
            DBaction db = new DBaction();
             db.UpdateTimeResume();
            db.Close();
          

        }
        public int GetCountFailByStatus(String l, String from, String to,int stt)
        {
           
            DBaction db = new DBaction();
            int d = db.getCountFailByStatus(l, from, to,stt);
            db.Close();
            return d;

        }
        public int GetCountFailByStatus(String l, int stt)
        {

            DBaction db = new DBaction();
            int d = db.getCountFailByStatus(l,  stt);
            db.Close();
            return d;

        }
        public int GetLastRecordId()
        {
            DBaction db = new DBaction();
            int d = db.GetLastRecordId();
            db.Close();
            return d;
        }
        public int QuickGetStatus(int id)
        {
            DBaction db = new DBaction();
            int d = db.getStatus(id);
            db.Close();
            return d;
        }
        public void UpdateFailureForFailrecord(int old,int newFail)
        {
            DBaction db = new DBaction();
            db.UpdateFailureForFailRecord(old, newFail);
            db.Close();
            
        }
    }
}
