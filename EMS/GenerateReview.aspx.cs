using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;

namespace EMS
{
    public partial class GenerateReview : System.Web.UI.Page
    {
        static List<PERSONALDETAILS> pdlist;
        static List<EMPLOYEE> elist;
        static JOBTITLE jt;
        static bool parametersfetched = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pdlist = getallpersonaldetails();
                elist = getEmployees();
                Page.DataBind();
            }
        }


        protected void NameTextBox_TextChanged(object sender, EventArgs e) {

        }



        private List<PERFORMANCEPARAMETER> getparameters(int jobTitleId)
        {
            List<PERFORMANCEPARAMETER> plist = new List<PERFORMANCEPARAMETER>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Parameters/");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<PERFORMANCEPARAMETER[]>();
                    readTask.Wait();

                    var parameters = readTask.Result;

                    foreach (var p in parameters)
                    {

                        if (jobTitleId == p.JobTitleId)
                        {
                            plist.Add(p);
                        }
                    }

                }
                return plist;
            }
        }



        private JOBTITLE getJobTitle(int jobtitleId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);
            //HTTP GET
            var responseTask = client.GetAsync("jobtitle/"+jobtitleId);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<JOBTITLE>();
                readTask.Wait();

                var jt = readTask.Result;

                return jt;

            }
            return null;
        }


        private List<EMPLOYEE> getEmployees()
        {
            List<EMPLOYEE> list = new List<EMPLOYEE>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);
            //HTTP GET
            var responseTask = client.GetAsync("employees/");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<EMPLOYEE[]>();
                readTask.Wait();

                var employees = readTask.Result;

                foreach (EMPLOYEE e in employees)
                {
                    list.Add(e);
                }
            }

            return list;
        }

        private List<PERSONALDETAILS> getallpersonaldetails()
        {
            List<PERSONALDETAILS> list = new List<PERSONALDETAILS>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);
            //HTTP GET
            var responseTask = client.GetAsync("PersonalDetails/");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<PERSONALDETAILS[]>();
                readTask.Wait();

                var employees = readTask.Result;

                foreach (PERSONALDETAILS e in employees)
                {
                    list.Add(e);
                }
            }

            return list;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetEmployeesList(string prefixText)
        {
            List<string> namelist = new List<string>();
            foreach (PERSONALDETAILS p in pdlist) {
                namelist.Add(p.FirstName + " " + p.LastName );
            }           

            List<string> temp = new List<string>();
            foreach (string v in namelist)
            {
                if (v.ToLower().Contains(prefixText.ToLower()))
                    temp.Add(v);
            }
            return temp;
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if (parametersfetched == false)
            {
                employeeError.Visible = true;
            }
            else {
                employeeError.Visible = false;
                //post to generatereview table
                GENERATEREVIEW g = new GENERATEREVIEW();
                g.DueDate =Convert.ToDateTime (DueDateTextBox.Text);
                g.StartDate = Convert.ToDateTime(FromDateTextBox.Text);
                g.EndDate = Convert.ToDateTime(ToDateTextBox.Text);
                PERSONALDETAILS pd = pdlist.FirstOrDefault(p => (p.FirstName + " " + p.LastName) == NameTextBox.Text);
                g.EmployeeId = elist.FirstOrDefault(em => em.PersonalDetailId == pd.PersonalDetailId).EmployeeId;
                g.Status = "Generated";

                var client = new HttpClient();
                client.BaseAddress = new Uri(Global.URIstring);
                var postTask = client.PostAsJsonAsync<GENERATEREVIEW>("generatedreviews/", g);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Response.Write("Successfuly genertated review!");
                    Response.Redirect("PendingReviews.aspx");
                }
            }

        }

        protected void fetchparametersButton_Click(object sender, EventArgs e)
        {
            PERSONALDETAILS pd = pdlist.FirstOrDefault(p => (p.FirstName + " " + p.LastName) == NameTextBox.Text);
            EMPLOYEE emp = elist.FirstOrDefault(em => em.PersonalDetailId == pd.PersonalDetailId);
            jt = getJobTitle(emp.JobtitleId.Value);

            List<PERFORMANCEPARAMETER> pplist = getparameters(jt.JobTitleId);
            int i = 1;
            foreach (PERFORMANCEPARAMETER p in pplist)
            {
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                Label parlabel = new Label();
                parlabel.Text = i + ". " + p.ParameterName + " (" + p.MinRating + "-" + p.MaxRating + ")";
                tc.Controls.Add(parlabel);
                tr.Cells.Add(tc);
                SelectedParametersTable.Rows.Add(tr);
                i++;
            }
            if (pplist.Count == 0)
            {
                JobTitleLabel.Text = "No parameters set for " + jt.JobTitleName;
                manageparameters.Text = "Add parameters...";

            }
            else
            {
                JobTitleLabel.Text = "Selected Parameters for: " + jt.JobTitleName;
                parametersfetched = true;
            }
            manageparameters.Visible = true;

        }

        protected void manageparameters_Click(object sender, EventArgs e)
        {
            Session["JTID"] = jt.JobTitleId;
            Response.Redirect("ManageIndividualParameters.aspx");

        }
    }
}