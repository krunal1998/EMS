using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class Complain : System.Web.UI.Page
    {
        static COMPLAINS c;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                int cid = Convert.ToInt32(Session["CID"]);
                c = getselectedcomplain(cid);
                COMPLAINTYPES ct = getcomplaintype(c.ComplainTypeId);
                EMPLOYEE emp = getEmployee(c.EmployeeId);
                String ctype = ct.ComplainType;

                ComplainTypeValue.Text = ctype;

                String ename = getEmployeeName(emp);
                EmployeeNameValue.Text = ename;

                ComplainDescriptionValue.Text = c.ComplainDescription;

                StatusValue.SelectedValue = c.ComplainStatus;

                FeedbackValue.Text = c.feedbackDescription;
            }
        }

        private COMPLAINTYPES getcomplaintype(int complainTypeId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("ComplainType/" + complainTypeId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<COMPLAINTYPES>();
                    readTask.Wait();

                    COMPLAINTYPES ct = readTask.Result;
                    return ct;
                }
                else return null;
            }
        }

        private string getEmployeeName(EMPLOYEE emp)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("PersonalDetails/" + emp.PersonalDetailId.ToString());
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

        private EMPLOYEE getEmployee(object employeeId)
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

        private COMPLAINS getselectedcomplain(int cid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Complains/" + cid);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<COMPLAINS>();
                    readTask.Wait();

                    COMPLAINS c = readTask.Result;
                    return c;
                }
                else return null;
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            StatusValue.Enabled = true;
            FeedbackValue.Enabled = true;
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            c.feedbackDescription = FeedbackValue.Text;
            c.ComplainStatus = StatusValue.SelectedValue;
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);

                    var putTask = client.PutAsJsonAsync<COMPLAINS>("complains/"+c.ComplainId, c);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        Response.Write("Save successfull!");
                    }
            FeedbackValue.Enabled = false;
            StatusValue.Enabled = false;
                }
            }
        }