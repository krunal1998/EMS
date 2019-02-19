using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EMS
{
    public partial class LeaveReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Table t = new Table();
            TableHeaderRow thr = new TableHeaderRow();

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
            thc4.Text = "Total Leaves";
            TableHeaderCell thc5 = new TableHeaderCell();
            thc5.Width = 200;
            thc5.BorderWidth = 1;
            thc5.Text = "Taken Leaves";
            TableHeaderCell thc6 = new TableHeaderCell();
            thc6.Width = 200;
            thc6.BorderWidth = 1;
            thc6.Text = "Leave Balance";
            TableHeaderCell thc7 = new TableHeaderCell();
            thr.Cells.Add(thc2); thr.Cells.Add(thc3); thr.Cells.Add(thc4); thr.Cells.Add(thc5); thr.Cells.Add(thc6);
            t.Rows.Add(thr);

            PlaceHolder1.Controls.Add(t);


            var table = new DataTable();

            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Education", typeof(long));

            table.Columns.Add("Lbl");
            var row = table.NewRow();
            row["State"] = "Gujarat";
            row["Education"] = 791;

            table.Rows.Add(row);
            row = table.NewRow();
            row["State"] = "Delhi";
            row["Education"] = 978;
            table.Rows.Add(row);

            row = table.NewRow();
            row["State"] = "Panjab";
            row["Education"] = 1650;
            table.Rows.Add(row);

            row = table.NewRow();
            row["State"] = "UP";
            row["Education"] = 1500;
            table.Rows.Add(row);
            Chart1.Series[0].Enabled = true;
            Chart1.DataSource = table;
            Chart1.DataBind();
            Chart2.DataSource = table;
            Chart2.DataBind();

        }

        [System.Web.Script.Services.ScriptMethod()]

        [System.Web.Services.WebMethod]

        public static List<string> GetListofEmployeeName(string prefixText)

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