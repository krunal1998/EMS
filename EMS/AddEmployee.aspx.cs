using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static SUPERVISOR[] supervisors;
        public static JOBTITLE[] jobtitles;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            loadjobtitle();
            loadsupervisors();
        }

        private void loadsupervisors()
        {
            SupervisorValue.Items.Clear();

            ListItem select = new ListItem("Select supervisor", "0");
            SupervisorValue.Items.Add(select);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Supervisor");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<SUPERVISOR[]>();
                    readTask.Wait();

                    supervisors = readTask.Result;

                    foreach (var sup in supervisors)
                    {
                        ListItem li = new ListItem();

                        li.Text = getemployeename(sup.EmployeeId);
                        li.Value = sup.SupervisorId.ToString();
                        SupervisorValue.Items.Add(li);

                    }
                }
            }       
    }

        private string getemployeename(string employeeId)
        {
            EMPLOYEE e = null;
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
                  

                }
               
                //HTTP GET
                var responseTask1 = client.GetAsync("PersonalDetails/" + e.PersonalDetailId);
                responseTask1.Wait();

                var result1 = responseTask1.Result;
                if (result1.IsSuccessStatusCode)
                {

                    var readTask1 = result1.Content.ReadAsAsync<PERSONALDETAILS>();
                    readTask1.Wait();

                    var pd = readTask1.Result;
                    return pd.FirstName + " " + pd.MiddleName + " " + pd.LastName;

                }
                else return null;
            }
        }

        public void loadjobtitle()
        {
            JobTitleValue.Items.Clear();
            
            ListItem select = new ListItem("Select job title", "0");
            JobTitleValue.Items.Add(select);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("JobTitle");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<JOBTITLE[]>();
                    readTask.Wait();

                    jobtitles = readTask.Result;

                    foreach (var jobtitle in jobtitles)
                    {
                        ListItem li = new ListItem(jobtitle.JobTitleName, jobtitle.JobTitleName);
                        li.Text = jobtitle.JobTitleName;
                        li.Value = jobtitle.JobTitleId.ToString();
                        JobTitleValue.Items.Add(li);
                    
                    }
                }
            }

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            PERSONALDETAILS pd = new PERSONALDETAILS();
            EMPLOYEE emp = new EMPLOYEE();

            pd.FirstName = FirstName.Text;
            pd.MiddleName = MiddleName.Text;
            pd.LastName = LastName.Text;
            pd.DateOfBirth = Convert.ToDateTime(DOBValue.Text);
            emp.JobtitleId = Convert.ToInt32(JobTitleValue.SelectedValue);
            emp.SupervisorId = Convert.ToInt32(SupervisorValue.SelectedValue);
        }

        /*
PERSONALDETAILS pd;
LOGINDETAILS ld;
EMPLOYEE e;
ALLOCATEDALLOWANCES aa;
ALLOWANCES a;
JOBTITLE jt;
protected void Page_Load(object sender, EventArgs e)
{
   a=getallowances
}

protected void Save_Click(object sender, EventArgs e)
{
   c.feedbackDescription = FeedbackValue.Text;
   c.ComplainStatus = StatusValue.SelectedValue;
   var client = new HttpClient();
   client.BaseAddress = new Uri(Global.URIstring);

   var putTask = client.PutAsJsonAsync<COMPLAINS>("complains/" + c.ComplainId, c);
   putTask.Wait();

   var result = putTask.Result;
   if (result.IsSuccessStatusCode)
   {
       Response.Write("Save successfull!");
   }
   FeedbackValue.Enabled = false;
   StatusValue.Enabled = false;
}*/
    }
}