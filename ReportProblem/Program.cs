using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;


using ReportProblem.Presentation;

namespace ReportProblem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Mutex _mut = null;

            try
            {
                _mut = Mutex.OpenExisting(AppDomain.CurrentDomain.FriendlyName);
                
            }
            catch
            {
                //handler to be written
                //MessageBox.Show("Instance already running");
            }

            if (_mut == null)
            {
                _mut = new Mutex(false, AppDomain.CurrentDomain.FriendlyName);
                Application.Run(new welcome());
               //Application.Run(new OTDPDReport());
            }
            else
            {
                _mut.Close();
                
                MessageBox.Show("Chuong trinh dang mo. Kiem tra duoi thanh taskbar");
               

            }       
            
            //Application.Run(new Statistics());
        }
    }
}
