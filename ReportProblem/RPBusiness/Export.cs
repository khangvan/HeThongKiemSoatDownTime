using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;


namespace ReportProblem.Business
{
    public static class Export
    {

        public static DataTable ToDataTable<T>(IQueryable items)
        {
            Type type = typeof(T);

            var props = TypeDescriptor.GetProperties(type)
                                      .Cast<PropertyDescriptor>()
                                      .Where(propertyInfo => propertyInfo.PropertyType.Namespace.Equals("System"))
                                      .Where(propertyInfo => propertyInfo.IsReadOnly == false)
                                      .ToArray();

            var table = new DataTable();

            foreach (var propertyInfo in props)
            {
                table.Columns.Add(propertyInfo.Name, Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
            }

            foreach (var item in items)
            {
                table.Rows.Add(props.Select(property => property.GetValue(item)).ToArray());
            }

            return table;

        }
        public static void writeCSV(DataGridView dt)
        {

            String fileName = "";
            // new file
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "CSV file  (*.csv*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    fileName = saveFileDialog1.FileName + ".csv";
                    myStream.Close();
                }
            }

            var lines = new List<String>();

            List<String> columnNames = new List<String>();

            foreach (DataGridViewColumn c in dt.Columns) columnNames.Add(c.Name);
            var header = string.Join(",", columnNames);
            lines.Add(header);



            List<String> l = new List<String>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String v = "";
                foreach (DataGridViewColumn c in dt.Columns)
                {
                    if (c.Name == "Nhom") v += displayValue(Convert.ToInt32(dt.Rows[i].Cells[c.Index].Value), "Nhom").Trim().Replace(",", "") + ",";
                    else if (c.Name == "TrangThai") v += displayValue(Convert.ToInt32(dt.Rows[i].Cells[c.Index].Value), "TrangThai").Trim().Replace(",", "") + ",";
                    else v += dt.Rows[i].Cells[c.Index].Value.ToString().Trim().Replace(",", "") + ",";
                }
                v = v.Substring(0,v.Length -1 );
              //  Console.WriteLine(v);
                l.Add(v);
            }
                lines.AddRange(l.AsEnumerable());
           

           

            File.WriteAllLines(fileName, lines, Encoding.GetEncoding("utf-8"));


            System.Diagnostics.Process.Start(fileName);
        }
        private static String displayValue(int v,String col)
        {
            // fail group
            if (col == "Nhom")
            {
                switch (v)
                {
                    case 0: return "Thiết bị";
                    case 1: return "Nguyên vật liệu";
                    case 2: return "Con người";
                    case 3: return "Phương pháp";
                    default: return "";
                }
            }
            else if (col == "TrangThai")
                switch (v)
                {
                   
                    case 1: return "Chưa xử lý";
                    case 2: return "Đang xử lý";
                    case 3: return "Đã xử lý";
                    default: return "";
                }
            else return "";
        }
    }
}
