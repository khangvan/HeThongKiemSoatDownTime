using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReportProblem.Data;
using ReportProblem;

namespace ReportProblem.Business
{
     public static class ServerTime
    {
         public static DateTime current()
         {
             DateTime t = new DateTime();
             DBaction db = new DBaction();
            t= db.getCurrentTime();
             db.Close();
             return t;
         }
    }
}
