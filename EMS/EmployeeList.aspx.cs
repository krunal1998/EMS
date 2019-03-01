using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Http;

namespace EMS
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if (!IsPostBack)
            //   gvbind();
            List<EMPLOYEE> elist = getAllEmployees();

            foreach (EMPLOYEE emp in elist)
            {
                TableRow row = new TableRow();
                row.ID = emp.EmployeeId.ToString();

                String ename = getEmployeeName(emp);
                TableCell employee = new TableCell();
                Label employeelabel = new Label();
                employeelabel.Text = ename;
                employee.Controls.Add(employeelabel);
                row.Cells.Add(employee);

                String post = getpost(emp.JobtitleId.Value);
                TableCell epost = new TableCell();
                Label epostlabel = new Label();
                epostlabel.Text = post;
                epost.Controls.Add(epostlabel);
                row.Cells.Add(epost);


                TableCell estatus = new TableCell();
                Label estatuslabel = new Label();
                estatuslabel.Text = emp.EmployeeStatus;
                estatus.Controls.Add(estatuslabel);
                row.Cells.Add(estatus);


                TableCell c1 = new TableCell();
                Button view = new Button();
                view.Text = "view";
                view.Command += new CommandEventHandler(viewbutton_click);
                view.CommandArgument = emp.EmployeeId.ToString();
                c1.Controls.Add(view);
                row.Cells.Add(c1);
                Table2.Rows.Add(row);

            }
        }

        private void viewbutton_click(object sender, CommandEventArgs e)
        {
            Session["EID"] = e.CommandArgument;

            Response.Redirect("PersonalDetails.aspx");
        }

        private string  getpost(int jobtitleId)
        {
            List<JOBTITLE> plist = new List<JOBTITLE>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("JobTitle/"+jobtitleId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<JOBTITLE>();
                    readTask.Wait();

                    var jt = readTask.Result;
                    return jt.JobTitleName;    
                }
                return null;
            }
                
        }

        private string getEmployeeName(EMPLOYEE e)
        {
        //    EMPLOYEE e = getEmployee(employeeId);

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
                    return pd.FirstName + " " + pd.MiddleName + " " + pd.LastName;
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

        private List<EMPLOYEE> getAllEmployees()
        {
            List<EMPLOYEE> list = new List<EMPLOYEE>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Employees");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<EMPLOYEE[]>();
                    readTask.Wait();

                    var employees = readTask.Result;

                    foreach (var employee in employees)
                    {
                        list.Add(employee);
                    }
                }
            }
            return list;
        }                                                                                                 


        /*
        protected void gvbind()
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("EmployeeName");
            DataColumn dc2 = new DataColumn("EmployeePost");
            DataColumn dc3 = new DataColumn("EmployeeStatus");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            DataRow dr = dt.NewRow();
            dr[0] = "Pratik Chirag Joshi";
            dr[1] = "Software Designer";
            dr[2] = "Enabled";
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1[0] = "Chintan Maheshbhai Shah";
            dr1[1] = "Database Administrater";
            dr1[2] = "Enabled";
            dt.Rows.Add(dr1);
            DataRow dr2 = dt.NewRow();
            dr2[0] = "Sameer Rajeshbhai Patel";
            dr2[1] = "Project Manager";
            dr2[2] = "Enabled";
            dt.Rows.Add(dr2);
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
        */
    }
}
