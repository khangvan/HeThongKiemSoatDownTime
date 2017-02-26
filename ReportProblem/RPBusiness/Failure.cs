using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportProblem.Data;
using System.Data;
namespace ReportProblem.Business
    
{
    class Failure
    {
        private int Id;
        private String Name;
        private int groupId;

        public void setId(int id)
        {
            Id = id;
        }
        public int getId()
        {
            return this.Id;
        }

        public void setName(String name)
        {
            Name = name;
        }
        public String getName()
        {
            return this.Name;
        }
        public void setGroupId(int g)
        {
            groupId = g;
        }
        public int getGroupId()
        {
            return this.groupId;
        }

        public void Add()
        {

            DBaction db = new DBaction();
            db.AddFailure(this.Name, this.groupId);
            db.Close();
        }
        public void Rename()
        {

            DBaction db = new DBaction();
            db.UpdateFailure(this.Id, this.Name);
            db.Close();
        }
        public void Rename(String oldName)
        {

            DBaction db = new DBaction();
            db.UpdateFailure(oldName, this.Name);
            db.Close();
        }
        public void Remove(int id)
        {

            DBaction db = new DBaction();
            db.RemoveFailure(id);
            db.Close();
        }
        public List<Item> getFail(int group)
        {
            List<String> l = new List<String>();
            List<String> name = new List<String>();
            DBaction db = new DBaction();
            l = db.getFail(name,group);
            db.Close();
            List<Item> g = new List<Item>();
            for (int i = 0; i < l.Count; i++)
            {

                Item item = new Item(name[i],l[i]);
                
                g.Add(item);
            }
            return g;
        }
        public DataTable GetFailAndGroup()
        {
            DBaction db = new DBaction();
            DataTable result = db.getFailAndGroup();
            db.Close();
            return result;
        }
        public List<Item> getEquipmentList()
        {
            List<Item> l = new List<Item>();
          
            DBaction db = new DBaction();
            l = db.GetEquipList();
            db.Close();
            return l;

        }
        public DataTable getEquipmentDataTable()
        {
           

            DBaction db = new DBaction();
            DataTable dt = db.GetEquipDataTable();
            db.Close();
            return dt;

        }
        public void AddEquip(String name)
        {

            DBaction db = new DBaction();
            db.AddEquipment(name);
            db.Close();
        }
        public void RemoveEquip(int id)
        {

            DBaction db = new DBaction();
            db.RemoveEquipment(id);
            db.Close();
        }
    }
}
