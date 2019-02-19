using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EMS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                Table t = new Table();
                TableHeaderRow thr = new TableHeaderRow();
                TableHeaderCell thc1 = new TableHeaderCell();
                thc1.Width = 200;
                t.BorderWidth = 1;
                thc1.Text = "checkbox";
                TableHeaderCell thc2 = new TableHeaderCell();
                thc2.Text = "textbox";
                thr.Cells.Add(thc1); thr.Cells.Add(thc2);
                t.Rows.Add(thr);
                /* for (int i=0;i<3;i++)
                 {
                     TableRow tr = new TableRow();
                     TableCell tc = new TableCell();
                     CheckBox ck1 = new CheckBox();
                     ck1.Text = "abc";
                     tc.Controls.Add(ck1);
                     TableCell tc2 = new TableCell();
                     TextBox tx = new TextBox();
                     tc2.Controls.Add(tx);
                     tr.Cells.Add(tc); tr.Cells.Add(tc2);
                     t.Rows.Add(tr);
                 }*/
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

                Chart1.DataSource = table;
                Chart1.DataBind();
            
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

        protected void Button1_Click(object sender, EventArgs e)
        {
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


            
        }
    }
}