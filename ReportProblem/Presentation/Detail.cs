using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportProblem.Presentation
{
    public partial class Detail : Form
    {
        public Detail(int recordId,String fail,String line,String stop,String resume,String duration,int stt,String reporter,String equip,String PO,String model,String part,String repairer,String description,String comment)
        {
            InitializeComponent();
            textBox1.Text +=" "+ recordId.ToString();
            textBox2.Text += " " + fail;
            textBox3.Text += " " + reporter;
            textBox4.Text += " " + resume;
            textBox5.Text += " " + stop;
            textBox6.Text += " " + repairer;
            textBox7.Text = " " + description;
            textBox8.Text += " " + line;
            textBox9.Text += " " + duration + " phút";
            switch (stt)
            {
                case 1: textBox10.Text += " Chưa xử lý"; break;
                case 2: textBox10.Text += " Đang xử lý"; break;
                case 3: textBox10.Text += " Đã xử lý"; break;
                default: break;
            }
            textBox17.Text += " " + equip;
            textBox11.Text += " " + PO;
            textBox12.Text += " " + model;
            textBox13.Text += " " + part;
            textBox14.Text = " " + comment;

        }
    }
}
