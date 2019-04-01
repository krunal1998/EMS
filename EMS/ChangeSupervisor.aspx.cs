using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class Supervisor : System.Web.UI.Page
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


        //Employee Name Validator 
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            List<string> list = GetEmployeeName();
            if (!list.Contains(EmployeeNameValue.Text))
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
        public static List<string> GetListofEmployeeName(string prefixText)
        {
            //get all employee name 
            List<string> namelist = GetEmployeeName();

            List<string> temp = new List<string>();
            //generate employee name list based on prefix
            foreach (string v in namelist)
            {
                if (v.ToLower().Contains(prefixText.ToLower()))
                    temp.Add(v);
            }
            return temp;
        }

        private static List<string> GetEmployeeName()
        {
            List<string> namelist = new List<string>();
            foreach (PERSONALDETAILS p in pdlist)
            {
                namelist.Add(p.FirstName + " " + p.MiddleName + " " + p.LastName);
            }
            return namelist;
        }

        //New SupervisorName Validator
        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            List<string> list = GetSupervisorName();
            if (!list.Contains(SupervisorNameValue.Text))
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
        public static List<string> GetListofSupervisorName(string prefixText)
        {
            //get all employee name 
            List<string> namelist = GetSupervisorName();

            List<string> temp = new List<string>();
            //generate employee name list based on prefix
            foreach (string v in namelist)
            {
                if (v.ToLower().Contains(prefixText.ToLower()))
                    temp.Add(v);
            }
            return temp;
        }

        private static List<string> GetSupervisorName()
        {
            List<string> namelist = new List<string>();
            foreach (SUPERVISOR s in suplist)
            {
                String name = getName(s.EmployeeId);
                namelist.Add(name);
            }
            return namelist;
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
      
        protected void Change_Click(object sender, EventArgs e)
        {
            string empname = EmployeeNameValue.Text;
            PERSONALDETAILS pd = pdlist.Find(p => (p.FirstName + " " + p.MiddleName + " " + p.LastName).Equals(empname));
            EMPLOYEE emp = elist.Find(em => em.PersonalDetailId == pd.PersonalDetailId);
            string eid = emp.EmployeeId;
           

            string supname = SupervisorNameValue.Text;
            PERSONALDETAILS pd1 = pdlist.Find(p => (p.FirstName + " " + p.MiddleName + " " + p.LastName).Equals(supname));
            EMPLOYEE supemp = elist.Find(em => em.PersonalDetailId == pd1.PersonalDetailId);

            SUPERVISOR sup1 = suplist.Find(s => s.EmployeeId == supemp.EmployeeId);
            emp.SupervisorId = sup1.SupervisorId;

            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);

            var putTask = client.PutAsJsonAsync<EMPLOYEE>("employees/" + emp.EmployeeId, emp);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                Response.Write("Change successfull!");
            }
        }
    }
}