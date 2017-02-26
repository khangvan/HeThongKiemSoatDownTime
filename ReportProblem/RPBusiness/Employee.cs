using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportProblem.Data;

namespace ReportProblem.Business
{
    class Employee
    {
        private String opCode;
        private String opName;
        private String email;
        private String pwd;
        private String dept;

        //get set
        public void setOpCode(String code)
        {
            opCode = code;
        }
        public String getOpCode()
        {
            return opCode;
        }
        public void setName(String name)
        {
            opName = name;
        }
        public String getOpName()
        {
            return opName;
        }
        public void setEmail(String m)
        {
            email = m;
        }
        public String getEmail()
        {
            return email;
        }
        public void setDept(String d)
        {
            dept = d;
        }
        public String getDept()
        {
            return dept;
        }
        public void setPwd(String p)
        {
            pwd = p;
        }
        public String getPwd()
        {
            return pwd;
        }

        public bool ValidateLogin()
        {
            bool login = false;

            // hash password
            
            HashPass h = new HashPass(this.pwd);
            DBaction db = new DBaction();
            
            login = db.VerifyUser(this.opCode,h.getHash());
            db.Close();
            return login;
        }
        public bool changePass(String newPass)
        {
            this.pwd = newPass;
            bool result = false;
            DBaction db = new DBaction();
            result =(db.ChangePassword(this.opCode,newPass) >0)?true:false;
            db.Close();
            return result;
        }
        public void Load()
        {
            DBaction db = new DBaction();
            Employee e = db.getUserInfo(this.opCode);
            this.setPwd(e.getPwd());
            this.setName(e.getOpName());
            this.setEmail(e.getEmail());
            this.setDept(e.getDept());
            db.Close();
        }
        public bool isExisted()
        {
            bool result = false;
            DBaction db= new DBaction ();
            result = db.existed(this.opCode);
            db.Close();
            return result;
        }
        public bool Add()
        {
            bool result = false;
            DBaction db = new DBaction();
            if (this.isExisted()) result =false;
            else result=(db.AddUser(this.opCode,this.opName,this.pwd,this.email,this.dept)>0)?true:false;
            db.Close();
            return result;
        }
        public bool changeEmail()
        {
            
            bool result = false;
            DBaction db = new DBaction();
            result = (db.ChangeEmail(this.opCode,this.email) > 0) ? true : false;
            db.Close();
            return result;
        }
        public bool changeDept()
        {

            bool result = false;
            DBaction db = new DBaction();
            result = (db.ChangeDept(this.opCode, this.dept) > 0) ? true : false;
            db.Close();
            return result;
        }
        public String GetNameFromMail(List<string> m)
        {

            string n = "";
            
            foreach (string i in m)
            {
                DBaction db = new DBaction();
                n += db.GetNameFromMail(i).Trim();
                n += ",";
                db.Close();
            }
           
            return n;
        }

    }
}
