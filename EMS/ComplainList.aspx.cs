using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class ComplainList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<COMPLAINS> clist = getAllComplains();
            List<COMPLAINTYPES> ctlist = getAllComplainTypes();

            foreach (COMPLAINS c in clist)
            {
                String ctype = ctlist.FirstOrDefault(ct => ct.ComplaintypeId == c.ComplainTypeId).ComplainType; 
                TableRow row = new TableRow();
                row.ID = c.ComplainId.ToString();


                TableCell complaintype = new TableCell();
                Label ctlabel = new Label();
                ctlabel.Text = ctype;
                complaintype.Controls.Add(ctlabel);
                row.Cells.Add(complaintype);


                String ename = getEmployeeName(c.EmployeeId);
                TableCell employee = new TableCell();
                Label employeelabel = new Label();
                employeelabel.Text = ename;
                employee.Controls.Add(employeelabel);
                row.Cells.Add(employee);

                TableCell cdescription = new TableCell();
                Label cdescriptionlabel = new Label();
                cdescriptionlabel.Text = c.ComplainDescription;
                cdescription.Controls.Add(cdescriptionlabel);
                row.Cells.Add(cdescription);


                TableCell cstatus = new TableCell();
                Label cstatuslabel = new Label();
                cstatuslabel.Text = c.ComplainStatus;
                cstatus.Controls.Add(cstatuslabel);
                row.Cells.Add(cstatus);


                TableCell cfeedback = new TableCell();
                Label cfeedbacklabel = new Label();
                cfeedbacklabel.Text = c.feedbackDescription;
                employee.Controls.Add(cfeedbacklabel);
                row.Cells.Add(cfeedback);



                TableCell c1 = new TableCell();
                Button view = new Button();
                view.Text = "view";
                view.Command += new CommandEventHandler(viewbutton_click);
                view.CommandArgument = c.ComplainId.ToString();
                c1.Controls.Add(view);
                row.Cells.Add(c1);
                Table2.Rows.Add(row);

            }
        }
        void viewbutton_click(object sender, CommandEventArgs e)
        {
            Session["CID"] = e.CommandArgument;

            Response.Redirect("Complain.aspx");


        }

        private List<COMPLAINTYPES> getAllComplainTypes()
        {
            List<COMPLAINTYPES> list = new List<COMPLAINTYPES>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("ComplainType");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<COMPLAINTYPES[]>();
                    readTask.Wait();

                    var complaintypes = readTask.Result;

                    foreach (var ct in complaintypes)
                    {
                        list.Add(ct);
                    }
                }
            }
            return list;
        }

        private List<COMPLAINS> getAllComplains()
        {
            List<COMPLAINS> list = new List<COMPLAINS>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Complains");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<COMPLAINS[]>();
                    readTask.Wait();

                    var complains = readTask.Result;

                    foreach (var c in complains)
                    {
                            list.Add(c);
                    }
                }
            }
            return list;
        }

        private string getEmployeeName(string employeeId)
        {
            EMPLOYEE e = getEmployee(employeeId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("PersonalDetails/" + e.PersonalDetailId.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<PERSONALDETAILS>();
                    readTask.Wait();

                    PERSONALDETAILS pd = readTask.Result;
                    return pd.FirstName + " " + pd.LastName;
                }
                else return "";
            }
        }


        private EMPLOYEE getEmployee(string employeeId)
        {
            EMPLOYEE e;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Employees/" + employeeId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<EMPLOYEE>();
                    readTask.Wait();

                    e = readTask.Result;
                    return e;

                }
                else return null;
            }
        }

        protected void Filter_Click(object sender, EventArgs e)
        {

        }
        /*   protected void gvbind()
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
      ComplainList.DataSource = dt;
      ComplainList.DataBind();
  }
  protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
  {
      ComplainList.EditIndex = e.NewEditIndex;
      gvbind();
  }
  protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
  {
      int userid = Convert.ToInt32(ComplainList.DataKeys[e.RowIndex].Value.ToString());
      GridViewRow row = (GridViewRow)ComplainList.Rows[e.RowIndex];
      Label lblID = (Label)row.FindControl("lblID");
      //TextBox txtname=(TextBox)gr.cell[].control[];  
      TextBox textName = (TextBox)row.Cells[0].Controls[0];
      TextBox textadd = (TextBox)row.Cells[1].Controls[0];
      TextBox textc = (TextBox)row.Cells[2].Controls[0];
      //TextBox textadd = (TextBox)row.FindControl("txtadd");  
      //TextBox textc = (TextBox)row.FindControl("txtc");  
      ComplainList.EditIndex = -1;
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
      ComplainList.EditIndex = -1;
      gvbind();
  }

  protected void Filter_Click(object sender, EventArgs e)
  {
      gvbind();
  }
  */
    }
}