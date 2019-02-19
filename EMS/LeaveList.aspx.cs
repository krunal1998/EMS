using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class LeaveList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                Table t = new Table();
                TableHeaderRow thr = new TableHeaderRow();
                TableHeaderCell thc1 = new TableHeaderCell();
                thc1.Width = 200;
                thc1.BorderWidth = 1;
                thc1.Text = "Date";

                TableHeaderCell thc2 = new TableHeaderCell();
                thc2.Width = 200;
                thc2.BorderWidth = 1;
                thc2.Text = "Employee Name";
                TableHeaderCell thc3 = new TableHeaderCell();
                thc3.Width = 200;
                thc3.BorderWidth = 1;
                thc3.Text = "Leave Type";
                TableHeaderCell thc4 = new TableHeaderCell();
                thc4.Width = 200;
                thc4.BorderWidth = 1;
                thc4.Text = "Leave Balance";
                TableHeaderCell thc5 = new TableHeaderCell();
                thc5.Width = 200;
                thc5.BorderWidth = 1;
                thc5.Text = "Number of Days";
                TableHeaderCell thc6 = new TableHeaderCell();
                thc6.Width = 200;
                thc6.BorderWidth = 1;
                thc6.Text = "Status";
                TableHeaderCell thc7 = new TableHeaderCell();
                thc7.Width = 200;
                thc7.BorderWidth = 1;
                thc7.Text = "Comment";
                TableHeaderCell thc8 = new TableHeaderCell();
                thc8.Width = 200;
                thc8.BorderWidth = 1;
                thc8.Text = "Action";

                thr.Cells.Add(thc1); thr.Cells.Add(thc2); thr.Cells.Add(thc3); thr.Cells.Add(thc4); thr.Cells.Add(thc5); thr.Cells.Add(thc6); thr.Cells.Add(thc7); thr.Cells.Add(thc8);
                t.Rows.Add(thr);

                PlaceHolder1.Controls.Add(t);
        }

        [System.Web.Script.Services.ScriptMethod()]

        [System.Web.Services.WebMethod]

        public static List<string> GetListofCountries(string prefixText)

        {
            List<string> list = new List<string>();
            list.Add("abc");
            list.Add("abb");
            list.Add("acb");
            list.Add("bca");
            list.Add("edfg");
            List<string> temp = new List<string>();
            foreach (string v in list)
            {
                if (v.Contains(prefixText))
                    temp.Add(v);
            }
            return temp;
        }
    }
}