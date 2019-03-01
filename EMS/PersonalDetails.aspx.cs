using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class PersonalDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EMPLOYEE emp;
                String eid = Session["EID"].ToString();
                emp = getselectedemployee(eid);
                PERSONALDETAILS pd = getpersonaldetails(emp.PersonalDetailId);

                String fname = pd.FirstName;
                FirstName.Text = fname;

                String mname = pd.MiddleName;
                MiddleName.Text = mname;

                String lname = pd.LastName;
                LastName.Text = lname;

                String empid = emp.EmployeeId;
                IDValue.Text = empid;

                DateTime dob = pd.DateOfBirth.Value;
                DOBValue.Text = dob.ToString("dd-MM-yyyy");

                String gen = pd.Gender;
                GenValue.Text = gen;

                String nat = pd.Nationality;
                NationalityValue.Text = nat;

                String ms = pd.MartialStatus;
                MaritalSatusValue.Text = ms;
                
            }
        }

        private PERSONALDETAILS getpersonaldetails(int? personalDetailId)
        {
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("PersonalDetails/" + personalDetailId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<PERSONALDETAILS>();
                    readTask.Wait();

                    PERSONALDETAILS pd = readTask.Result;
                    return pd;
                }
                return null;
            }
        }

        private EMPLOYEE getselectedemployee(String eid)
        {
            EMPLOYEE e;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Employees/" + eid);
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
    }
}