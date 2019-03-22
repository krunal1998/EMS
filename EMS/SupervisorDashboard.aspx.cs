using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;

namespace EMS
{
    public partial class SupervisorDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(Global.URIstring);
                    //HTTP GET
                    var responseTask = client.GetAsync("Employees?id=" + Session["userid"]);
                    responseTask.Wait();

                    var result = responseTask.Result;
                EMPLOYEE emp = new EMPLOYEE(); ;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<EMPLOYEE>();
                    readTask.Wait();

                    emp = readTask.Result;
                }
                //HTTP GET
                responseTask = client.GetAsync("PersonalDetails/" + emp.PersonalDetailId );
                responseTask.Wait();

                result = responseTask.Result;
                PERSONALDETAILS emppd=new PERSONALDETAILS();
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<PERSONALDETAILS>();
                    readTask.Wait();

                    emppd = readTask.Result;
                    Label l = Master.FindControl("Label1") as Label;
                    l.Text = emppd.FirstName;
                }

            }
            else
                Response.Redirect("Login.aspx");

        }
    }
}