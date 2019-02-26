using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("LoginDetails/" + Username.Text.ToLower());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<LOGINDETAILS>();
                    readTask.Wait();

                    var logindetails = readTask.Result;


                    if (Password.Text.Equals(logindetails.Password) && logindetails != null)
                    {
                        if (issupervisor(logindetails.EmployeeId))
                            Response.Redirect("SupervisorDashboard.aspx");
                        else
                        {
                            ErrorMessage.Visible = true;
                            ErrorMessage.Text = "You are not a supervisor. Please contact HR if this seems to be an error.";
                        }
                    }
                    else
                    {
                        ErrorMessage.Visible = true;
                        ErrorMessage.Text = "Invalid Password";
                    }

                }
                else
                {
                    ErrorMessage.Visible = true;
                    ErrorMessage.Text = "Username not found. Please try again";
                }
            }
        }

        private bool issupervisor(string employeeId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("supervisor");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<SUPERVISOR[]>();
                    readTask.Wait();

                    var supervisors = readTask.Result;

                    foreach (SUPERVISOR s in supervisors) {
                        if (s.EmployeeId.Equals(employeeId))
                            return true;
                    }

                }
                return false;
            }
        }
    }
}