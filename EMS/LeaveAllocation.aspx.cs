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
            if (!IsPostBack)
                gvbind();

        }
        protected void gvbind()
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvbind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lblID = (Label)row.FindControl("lblID");
            //TextBox txtname=(TextBox)gr.cell[].control[];  
            TextBox textName = (TextBox)row.Cells[0].Controls[0];
            TextBox textadd = (TextBox)row.Cells[1].Controls[0];
            TextBox textc = (TextBox)row.Cells[2].Controls[0];
            //TextBox textadd = (TextBox)row.FindControl("txtadd");  
            //TextBox textc = (TextBox)row.FindControl("txtc");  
            GridView1.EditIndex = -1;
            // conn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);  
            //SqlCommand cmd = new SqlCommand("update detail set name='" + textName.Text + "',address='" + textadd.Text + "',country='" + textc.Text + "'where id='" + userid + "'", conn);
            //cmd.ExecuteNonQuery();
            //conn.Close();
            gvbind();
            //GridView1.DataBind();  
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gvbind();
        }
    }
}