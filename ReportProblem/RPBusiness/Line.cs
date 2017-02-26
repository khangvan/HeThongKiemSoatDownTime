using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportProblem.Data;
namespace ReportProblem.Business
{
    class Line
    {
        private String lineId;
        private String lineName;
        private String[] mailTo = new String[4];
        private String[] mailCC = new String[4];

        private String upperLevelMail;

        // get set attribute
        public void setLineId(String l)
        {
            lineId = l;
        }
        public String getLineId()
        {
            return this.lineId;
        }

        public void setLineName(String line)
        {
            lineName = line;

        }
        public String getLineName()
        {
            return this.lineName;
        }

        public void setMailTo(String[] m)
        {
            mailTo = m;
        }
        public String getMailTo(int group)
        {
           
            return this.mailTo[group];
        }


        public void setMailCC(String[] m)
        {
            mailCC = m;
        }
        public String getMailCC(int group)
        {
           
            return this.mailCC[group];
        }

        public void setUpperLevelMail(String m)
        {
            upperLevelMail = m;
        }
        public String getUpperLevelMail()
        {
            
            return this.upperLevelMail;
        }

      

        //action
        public void AddLine()
        {
            DBaction db = new DBaction();
            db.AddLine(this.lineId, this.lineName);
            db.Close();
        }
        public bool UpdateMailList()
        {
            bool result = false;
            DBaction db = new DBaction();

            //group mail
            //0: machine
            //1:  material
            //2:  man
            //3: method
            int r = db.UpdateMailList(this.lineId, this.mailTo[0], this.mailCC[0], this.mailTo[1], this.mailCC[1], this.mailTo[2], this.mailCC[2], this.mailTo[3], this.mailCC[3], this.upperLevelMail);
            result=(r>0)?true:false;
            db.Close();
            return result;
        }
        public void UpdateLineName()
        {
            DBaction db = new DBaction();
            db.UpdateLineName(this.lineId, this.lineName);

            db.Close();
        }
        public void Remove()
        {
            DBaction db = new DBaction();
            db.RemoveLine(this.lineId);

            db.Close();
        }
        public List<String> getAllLine()
        {
            List<String> l = new List<string>();
            DBaction db = new DBaction();
           l = db.getAllLineCode();
            db.Close();
            return l;
        }
        public void Load()
        {
            DBaction db = new DBaction();
            String[] mail = new String[9];
              mail =  db.getMail(this.lineId);
            for(int i=0;i<4;i++){
                this.mailTo[i] = mail[i];
            }
            for (int i = 4; i < 8; i++)
            {
                this.mailCC[i-4] = mail[i];
            }
            
            this.upperLevelMail = mail[8];
            db.Close();
        }
    }
}
