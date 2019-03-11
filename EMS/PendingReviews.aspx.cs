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
        public static List<GENERATEREVIEW> grlist ;
        public static List<EMPLOYEE> elist;
        public static List<PERSONALDETAILS> pdlist;
        private int supervisorid = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                getemployees();
                filterdata();
            }
        }
        private void getemployees()
        {
            elist = new List<EMPLOYEE>();
            pdlist = new List<PERSONALDETAILS>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Employees/");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<EMPLOYEE[]>();
                    readTask.Wait();

                    var employees = readTask.Result;
                    foreach (EMPLOYEE e in employees)
                    {
                        if (e.SupervisorId == supervisorid)
                        {
                            elist.Add(e);
                            PERSONALDETAILS pd = getpersonaldetails(e.PersonalDetailId.Value);
                            pdlist.Add(pd);
                        }
                    }

                }
            }


        }

        private PERSONALDETAILS getpersonaldetails(int personaldetailId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("personaldetails/" + personaldetailId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<PERSONALDETAILS>();
                    readTask.Wait();

                    var p = readTask.Result;
                    return p;

                }
                else return null;
            }

        }

        void assessbutton_click(object sender, CommandEventArgs e)
        {
            Session["GRID"] = e.CommandArgument;
            
            Response.Redirect("AssessReview.aspx");
            
            
        }

        private string getEmployeeName(string employeeId)
        {
            EMPLOYEE e = elist.Find(emp => emp.EmployeeId == employeeId);
            PERSONALDETAILS pd = pdlist.Find(p => p.PersonalDetailId == e.PersonalDetailId);

            return pd.FirstName + " " + pd.LastName;

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

        private void filterdata()
        {
            grlist = getAllPendingReviews();
            List<GENERATEREVIEW> filterlist = grlist;
            //date filter not selected
            if (fromdatetb.Text != "")
            {
                foreach (GENERATEREVIEW g in filterlist.ToList())
                {
                    DateTime date = Convert.ToDateTime(fromdatetb.Text);
                    if (g.DueDate <= date)
                        filterlist.Remove(g);
                }
            }
            if (todatetb.Text != "")
            {
                foreach (GENERATEREVIEW g in filterlist.ToList())
                {
                    DateTime date = Convert.ToDateTime(todatetb.Text);
                    if (g.DueDate >= date)
                        filterlist.Remove(g);
                }
            }
            if (EnameTextBox.Text != "")
            {
                PERSONALDETAILS pd = pdlist.Find(p => (p.FirstName + " " + p.LastName).Equals(EnameTextBox.Text));
                EMPLOYEE e = elist.Find(emp => emp.PersonalDetailId == pd.PersonalDetailId);

                if (pd != null)
                {
                    foreach (GENERATEREVIEW g in filterlist.ToList())
                    {
                        if (!g.EmployeeId.Equals(e.EmployeeId))
                            filterlist.Remove(g);
                    }
                }
                else
                {
                    filterlist.RemoveAll(g => true);
                }
            }
            loadtable(filterlist);

        }


        public void loadtable(List<GENERATEREVIEW> filterlist) {
            if (filterlist.Count == 0)
            {
                Table1.Visible = false;
                nopendingreviewslabel.Visible = true;
            }
            else
            {
                nopendingreviewslabel.Visible = false;
                Table1.Visible = true;
            }

            for (int i = 1; i < Table1.Rows.Count; i++)
            {
                Table1.Rows.RemoveAt(i);
            }
            foreach (GENERATEREVIEW g in filterlist)
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


        private int getEmployeeSID(string employeeID)
        {
            EMPLOYEE e = elist.Find(emp => emp.EmployeeId == employeeID);
            return e.SupervisorId.Value;
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

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetEmployeesList(string prefixText)
        {
            List<string> namelist = new List<string>();
            foreach (PERSONALDETAILS p in pdlist)
            {
                namelist.Add(p.FirstName + " " + p.LastName);
            }

            List<string> temp = new List<string>();
            foreach (string v in namelist)
            {
                if (v.ToLower().Contains(prefixText.ToLower()))
                    temp.Add(v);
            }
            return temp;
        }

        protected void searchbutton_Click(object sender, EventArgs e)
        {
            filterdata();
        }
    }


}