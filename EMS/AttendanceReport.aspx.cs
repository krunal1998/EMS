using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Http;

namespace EMS
{
    public partial class AttendanceReport : System.Web.UI.Page
    {
        public static PERSONALDETAILS[] pdlist;
        public static EMPLOYEE[] employees;
        public static ATTENDANCE[] attendances;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadpersonaldetails();
                loademployee();
            }

        }

        //load personal details of employees
        public void loadpersonaldetails()
        {
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

                pdlist = readTask.Result;

            }
        }

        //load employee data
        public void loademployee()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);
            //HTTP GET
            var responseTask = client.GetAsync("Employees/");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<EMPLOYEE[]>();
                readTask.Wait();

                employees = readTask.Result;

            }
        }

        //get personal id from employee name
        public int getpersonalid(string name)
        {
            int pid = 0;
            string ename = "";
            foreach (var p in pdlist)
            {
                ename = p.FirstName + " " + p.LastName;
                if (ename.Equals(name))
                {
                    pid = p.PersonalDetailId;
                    break;
                }
            }
            return pid;
        }


        //get employee id from personal detail id
        public string getemployeeid(int pid)
        {
            string eid = "";
            foreach (var employee in employees)
            {
                if (pid == employee.PersonalDetailId)
                {
                    eid = employee.EmployeeId;
                    break;
                }
            }
            return eid;
        }



        protected void EmployeeViewButton_Click(object sender, EventArgs e)
        {
            int pid = getpersonalid(EnameTextBox.Text);
            string empid = getemployeeid(pid);

            //load attendance record
            loadattendance(EmpFromDate.Text, EmpToDate.Text);

            DataTable dt = new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("PunchInTime");
            dt.Columns.Add("PunchOutTime");
            dt.Columns.Add("Status");

            int fullday = 0;
            int halfday = 0;
            int absent = 0;

            foreach (var attendance in attendances)
            {
                if(attendance.EmployeeId.Equals(empid))
                {
                    DataRow row = dt.NewRow();
                    row["Date"] = attendance.PunchInDate.ToShortDateString();
                    row["PunchInTime"] = attendance.PunchInTime;
                    row["PunchOutTime"] = attendance.PunchOutTime;
                    if(attendance.WorkingHours==8.0)
                    {
                        fullday++;
                        row["Status"] = "Present(Full Day)";
                    }
                    else if(attendance.WorkingHours == 4.0)
                    {
                        halfday++;
                        row["Status"] = "Present(Half Day)";
                    }
                    else if(attendance.WorkingHours == 0.0)
                    {
                        absent++;
                        row["Status"] = "Absent";
                    }

                    dt.Rows.Add(row);
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            //bind data with chart
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Status");
            dt1.Columns.Add("Days");

            List<string> status = new List<string>();
            status.Add("Present(Full Day)"); status.Add("Present(Half Day)"); status.Add("Absent");
            List<int> days = new List<int>();
            days.Add(fullday); days.Add(halfday); days.Add(absent);
            for (int i = 0; i < 3; i++)
            {
                DataRow row = dt1.NewRow();
                row["Status"] = status[i];
                row["Days"] = days[i];
                dt1.Rows.Add(row);
            }
            Chart2.DataSource = dt1;
            Chart2.DataBind();

            PrintButton.Visible = true;
        }


        //load all leave data
        public void loadattendance(string fromdate, string todate)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Attendance?date1=" + fromdate + "&date2=" + todate);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<ATTENDANCE[]>();
                    readTask.Wait();

                    attendances = readTask.Result;

                }
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
        //return all employee name list
        public static List<string> GetEmployeeName()
        {
            List<string> namelist = new List<string>();
            foreach (PERSONALDETAILS p in pdlist)
            {
                namelist.Add(p.FirstName + " " + p.LastName);
            }
            return namelist;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            List<string> list = GetEmployeeName();
            if (!list.Contains(EnameTextBox.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

    }
}