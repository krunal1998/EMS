using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EMS
{
    public partial class ViewReviews : System.Web.UI.Page
    {
        private int supervisorid = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (!IsPostBack)
            {
                List<GENERATEREVIEW> list = getAllPendingReviews();
                if (list.Count == 0)
                {
                    Table1.Visible = false;
                    nopendingreviewslabel.Visible = true;
                }
                else
                {
                    foreach (GENERATEREVIEW g in list)
                    {
                        String ename = getEmployeeName(g.EmployeeId);
                        TableRow row = new TableRow();
                        row.ID = g.GenerateReviewId.ToString();
                        TableCell employee = new TableCell();
                        Label employeelabel = new Label();
                        employeelabel.Text = ename;
                        employee.Controls.Add(employeelabel);
                        row.Cells.Add(employee);
                        TableCell sd = new TableCell();
                        Label sdlabel = new Label();
                        sdlabel.Text = g.StartDate.ToShortDateString();
                        sd.Controls.Add(sdlabel);
                        row.Cells.Add(sd);
                        TableCell ed = new TableCell();
                        Label edlabel = new Label();
                        edlabel.Text = g.EndDate.ToShortDateString();
                        ed.Controls.Add(edlabel);
                        row.Cells.Add(ed);
                        TableCell dd = new TableCell();
                        Label ddlabel = new Label();
                        ddlabel.Text = g.DueDate.ToShortDateString();
                        dd.Controls.Add(ddlabel);
                        row.Cells.Add(dd);
                        TableCell status = new TableCell();
                        Label statuslabel = new Label();
                        statuslabel.Text = g.Status;
                        status.Controls.Add(statuslabel);
                        row.Cells.Add(status);
                        TableCell c1 = new TableCell();
                        Button assess = new Button();
                        assess.Text = "Assess";
                        assess.Command += new CommandEventHandler(assessbutton_click);
                        assess.CommandArgument = g.GenerateReviewId.ToString();
                        c1.Controls.Add(assess);
                        row.Cells.Add(c1);
                        Table1.Rows.Add(row);

                    }
                }
            }
        }

        void assessbutton_click(object sender, CommandEventArgs e)
        {
            Session["GRID"] = e.CommandArgument;
            
            Response.Redirect("AssessReview.aspx");
            
            
        }

        private string getEmployeeName(string employeeId)
        {
            EMPLOYEE e = getEmployee(employeeId);
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("PersonalDetails/"+e.PersonalDetailId.ToString());
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

        protected void Search_Click(object sender, EventArgs e)
        {

        }
        public List<GENERATEREVIEW> getAllPendingReviews()
        {
            List<GENERATEREVIEW> list = new List<GENERATEREVIEW>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("GeneratedReviews");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<GENERATEREVIEW[]>();
                    readTask.Wait();

                    var GRs = readTask.Result;

                    foreach (var g in GRs)
                    {
                        int gsid =getEmployeeSID(g.EmployeeId);
                        if (supervisorid == gsid && g.Status.Equals("Generated")) {
                            list.Add(g);
                        }
                    }
                }
            }
            return list;
        }




        private int getEmployeeSID(string employeeID)
        {
            EMPLOYEE e = getEmployee(employeeID);
            return e.SupervisorId.Value;
        }




        private EMPLOYEE getEmployee(string employeeID) {
            EMPLOYEE e;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Employees/"+employeeID);
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
        /*
        [System.Web.Script.Services.ScriptMethod()]

        [System.Web.Services.WebMethod]

        public static List<string> GetEmployeesList(string prefixText)

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
        } */

    }


}