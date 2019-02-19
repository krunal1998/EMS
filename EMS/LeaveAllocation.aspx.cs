using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EMS
{
    public partial class LeaveAllocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("JobTitle");
            DataColumn dc2 = new DataColumn("LeaveType");
            DataColumn dc3 = new DataColumn("numberofLeaves");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            DataRow dr = dt.NewRow();
            dr[0] = "Software Designer";
            dr[1] = "FMLA";
            dr[2] = "4";
            dt.Rows.Add(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        
    }
}