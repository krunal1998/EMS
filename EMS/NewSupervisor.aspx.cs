using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class NewSupervisor : System.Web.UI.Page
    {
        static List<PERSONALDETAILS> pdlist;
        static List<EMPLOYEE> elist;
        static List<SUPERVISOR> suplist;

        protected void Page_Load(object sender, EventArgs e)
        {
            pdlist = getallpersonaldetails();
            elist = getallemployees();
            suplist = getallsupervisor();
        }

        private List<SUPERVISOR> getallsupervisor()
        {
            List<SUPERVISOR> list = new List<SUPERVISOR>();

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

                    var supervisors = readTask.Result;

                    foreach (var supervisor in supervisors)
                    {
                        list.Add(supervisor);
                    }
                }
            }
            return list;
        }

        private List<EMPLOYEE> getallemployees()
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

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            List<string> list = GetNonSupervisorName();
            if (!list.Contains(NewSupervisorNameValue.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetListofNonSupervisorName(string prefixText)
        {
            //get all employee name 
            List<string> namelist = GetNonSupervisorName();

            List<string> temp = new List<string>();
            //generate employee name list based on prefix
            foreach (string v in namelist)
            {
                if (v.ToLower().Contains(prefixText.ToLower()))
                    temp.Add(v);
            }
            return temp;
        }

        private static List<string> GetNonSupervisorName()
        {
            List<string> namelist = new List<string>();
            foreach (EMPLOYEE emp in elist)
            {
                if (!issupervisor(emp.EmployeeId))
                {
                    PERSONALDETAILS p = pdlist.Find(pd => pd.PersonalDetailId == emp.PersonalDetailId);
                    namelist.Add(p.FirstName + " " + p.MiddleName + " " + p.LastName);
                }
            }
            return namelist;
        }
       private static bool issupervisor(string employeeId)
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

                    foreach (SUPERVISOR s in supervisors)
                    {
                        if (s.EmployeeId.Equals(employeeId))
                            return true;
                    }

                }
                return false;
            }
        }

        private static string getName(string employeeId)
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


        protected void Add_Click(object sender, EventArgs e)
        {
            string name = NewSupervisorNameValue.Text;
            PERSONALDETAILS pd = pdlist.Find(p => (p.FirstName + " " + p.MiddleName + " " + p.LastName).Equals(name));
            EMPLOYEE emp = elist.Find(em => em.PersonalDetailId == pd.PersonalDetailId);
            string eid = emp.EmployeeId;
            SUPERVISOR sup = new SUPERVISOR();
            sup.EmployeeId = eid;

            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);

            var postTask = client.PostAsJsonAsync<SUPERVISOR>("supervisor",sup);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                Response.Write("Add successfull!");
            }

        }
    }
}