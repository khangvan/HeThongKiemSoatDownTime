using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportProblem.Business
{
    class Item
    {

        public string Text;
        public object Value;

        public  Item(string t,object v)
        {
            Text = t;
            Value = v;
        }
        public override string ToString()
        {
            return Text;
        }

    }
}
