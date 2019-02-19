using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class ComplainList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvbind()
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("ComplainType");
            DataColumn dc2 = new DataColumn("ComplainantsName");
            DataColumn dc3 = new DataColumn("ComplainDescription");
            DataColumn dc4 = new DataColumn("ComplainStatus");
            DataColumn dc5 = new DataColumn("Feedback");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            DataRow dr = dt.NewRow();
            dr[0] = "Theft";
            dr[1] = "Pratik Chirag Joshi";
            dr[2] = "My Wallet was stolen from my desk when I was out on break";
            dr[3] = "Pending";
            dr[4] = "Thank You Sir!!!";
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1[0] = "Leaves Issues";
            dr1[1] = "Pratik Chirag Joshi";
            dr1[2] = "My leaves being shown in the account is having discrepancies ";
            dr1[3] = "Solved";
            dr1[4] = "I am glad the issue was solved quickly ";
            dt.Rows.Add(dr1);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            gvbind();
        }
    }
}