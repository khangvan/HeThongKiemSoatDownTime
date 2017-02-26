using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportProblem.Data;
namespace ReportProblem.Business
{
    class FailGroup
    {
        private int Id;
        private String GroupName;

        public void setId(int id)
        {
            Id  = id;
        }
        public int getId()
        {
            return this.Id;
        }

        public void setName(String g)
        {
            GroupName = g;
        }
        public String getName()
        {
            return this.GroupName;
        }
        //action
        public void AddGroup()
        {
         
            DBaction db = new DBaction();
            db.AddFailGroup(this.GroupName);            
            db.Close();
        
        }
        public void Rename()
        {
            DBaction db = new DBaction();
            
            db.UpdateFailGroup(this.Id, this.GroupName);
            db.Close();
        }
        public void Remove()
        {
            DBaction db = new DBaction();

            db.RemoveFailGroup(this.Id);
            db.Close();
        }
        public List<Item> getAllFailGroup()
        {
            List<String> l = new List<string>();
            List<String> groupName = new List<string>();
            DBaction db = new DBaction();
            l = db.getAllFailGroup(groupName);
            db.Close();
            List<Item> g = new List<Item>();
            for (int i = 0; i < l.Count; i++)
            {

                Item item = new Item(groupName[i],l[i]);
                
                g.Add(item);
            }
            return g;
        }
        public String getFailGroupNameById(int id)
        {
            DBaction db = new DBaction();
            String r = db.getFailGroupNameById(id);
            db.Close();
            return r;
        }
    }
}
