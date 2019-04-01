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
    public partial class LeaveReport : System.Web.UI.Page
    {
        public static PERSONALDETAILS[] pdlist;
        public static EMPLOYEE[] employees;
        public static LEAVES[] leaves;
        public static LEAVETYPE[] leavetypes;
        public static EMPLOYEELEAVES[] employeeleaves;
        public static LEAVEALLOCATION[] allocatedleaves;
        public static JOBTITLE[] jobtitles;
        public static ATTENDANCE[] attendances;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["HRId"] != null)
            {
                if (!IsPostBack)
                {
                    loadpersonaldetails();
                    loademployee();
                    loadleavetypes();
                    loadjobtitle();
                    loadleaveallocation();
                    loademployeeleaves();
                }
            }
            else
                Response.Redirect("~/Login.aspx");
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

        //load leave types in drop down list
        public void loadleavetypes()
        {
            LeaveTypeDropDownList.Items.Clear();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("LeaveType");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<LEAVETYPE[]>();
                    readTask.Wait();

                    leavetypes = readTask.Result;
                }
                foreach (var leavetype in leavetypes)
                {
                    ListItem li = new ListItem();

                    li.Text = leavetype.LeaveTypeName;
                    li.Value = leavetype.LeaveTypeId.ToString();
                    LeaveTypeDropDownList.Items.Add(li);
                }
            }
        }

        //load job tiles in dropdownlist 
        public void loadjobtitle()
        {
            JobTitleDropDownList.Items.Clear();
            ListItem select = new ListItem("All", "0");
            JobTitleDropDownList.Items.Add(select);
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
                        JobTitleDropDownList.Items.Add(li);
                    }
                }
            }

        }

        //load all leave data
        public void loadleaves(string fromdate, string todate)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Leave?date1=" + fromdate + "&date2=" + todate);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<LEAVES[]>();
                    readTask.Wait();

                    leaves = readTask.Result;

                }
            }
        }

        //load allocated leave data
        protected void loadleaveallocation()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("LeaveAllocation");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<LEAVEALLOCATION[]>();
                    readTask.Wait();

                    allocatedleaves = readTask.Result;
                }
            }
        }

        //load consumed employee leaves
        protected void loademployeeleaves()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("EmployeeLeaves");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<EMPLOYEELEAVES[]>();
                    readTask.Wait();

                    employeeleaves = readTask.Result;
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

        
        
        //get employee name from personal details based on personal id
        public string getemployeename(int pid)
        {
            string name = "";
            foreach (var p in pdlist)
            {
                if (pid == p.PersonalDetailId)
                {
                    name = p.FirstName + " " + p.LastName;
                    break;
                }
            }
            return name;
        }

        //get personal detail id based on employee id
        public int getpdid(string empid)
        {
            int pid = 0;
            foreach (var emp in employees)
            {
                if (emp.EmployeeId.ToLower().Equals(empid.ToLower()))
                {
                    pid = emp.PersonalDetailId.Value;
                }
            }
            return pid;
        }

        //get personal id from employee name
        public int getpersonalid(string name)
        {
            int pid = 0;
            string ename = "";
            foreach(var p in pdlist)
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
            foreach(var employee in employees)
            {
                if(pid==employee.PersonalDetailId)
                {
                    eid = employee.EmployeeId;
                    break;
                }
            }
            return eid;
        }

        //get allocated leave for specific jobtitle and leave type
        public int getallocatedleave(int jobid, int leavetypeid)
        {
            int days = 0;
            foreach (var al in allocatedleaves)
            {
                if (al.JobTitleId == jobid && al.LeaveTypeId == leavetypeid)
                {
                    days = al.NumberOfLeave.Value;
                    break;
                }
            }
            return days;
        }


        //get consumed leave for specific employee and leave type
        public double getconsumedleave(string empid, int leavetypeid)
        {
            double days = 0;
            foreach (var cl in employeeleaves)
            {
                if (cl.EmployeeId.ToLower().Equals(empid.ToLower()) && cl.LeaveTypeId == leavetypeid)
                {
                    days = cl.NumberOfLeaves.Value;
                    break;
                }
            }
            return days;
        }

        //get list of employee for specific job title
        public List<EMPLOYEE> getEmployeeList(int jobtitleid)
        {
            List<EMPLOYEE> emplist = new List<EMPLOYEE>();
            foreach(var emp in employees)
            {
                if(emp.JobtitleId== jobtitleid)
                {
                    emplist.Add(emp);
                }
            }
            return emplist;
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

        protected void ReportDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ReportDropDownList.SelectedValue.Equals("0"))
            {
                MultiView1.Visible = false;
            }
            else if(ReportDropDownList.SelectedValue.Equals("Leave Type"))
            {
                MultiView1.Visible = true;
                MultiView1.ActiveViewIndex = 0;
                GridView1.Columns[0].HeaderText = "Employee";
            }
            else if (ReportDropDownList.SelectedValue.Equals("Employee"))
            {
                MultiView1.Visible = true;
                MultiView1.ActiveViewIndex = 1;
                GridView1.Columns[0].HeaderText = "Leave Type";
            }
            
        }

        protected void LeaveViewButton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("LeaveEntitlement");
            dt.Columns.Add("PendingLeave");
            dt.Columns.Add("ScheduledLeave");
            dt.Columns.Add("ConsumedLeave");
            dt.Columns.Add("LeaveBalance");

            //load latest leave record
            loadleaves(FromDateTextBox.Text, ToDateTextBox.Text);

            //if by default All job tiles option selected
            if (JobTitleDropDownList.SelectedIndex == 0)
            {
                foreach (var employee in employees)
                {
                    int pid = getpdid(employee.EmployeeId);
                    string ename = getemployeename(pid);
                    int entitlement = getallocatedleave(employee.JobtitleId.Value, Convert.ToInt32(LeaveTypeDropDownList.SelectedValue));
                    int consumedleave = (int)getconsumedleave(employee.EmployeeId, Convert.ToInt32(LeaveTypeDropDownList.SelectedValue));
                    int pendingdays = 0;
                    int scheduleddays = 0;
                    int consumeddays = 0;
                    foreach (var leave in leaves)
                    {
                        if (leave.LeavetypeId == Convert.ToInt32(LeaveTypeDropDownList.SelectedValue) && leave.EmployeeId.Equals(employee.EmployeeId))
                        {
                            if (leave.LeaveStatus.Equals("Pending"))
                                pendingdays = pendingdays + (int)leave.NumberOfDays;
                            if (leave.LeaveStatus.Equals("Approved"))
                                scheduleddays = scheduleddays + (int)leave.NumberOfDays;
                            if (leave.LeaveStatus.Equals("Consumed"))
                                consumeddays = consumeddays + (int)leave.NumberOfDays;
                        }
                    }

                    DataRow row = dt.NewRow();
                    row["Name"] = ename;
                    row["LeaveEntitlement"] = entitlement;
                    row["PendingLeave"] = pendingdays;
                    row["ScheduledLeave"] = scheduleddays;
                    row["ConsumedLeave"] = consumeddays;
                    row["LeaveBalance"] = entitlement - consumedleave; ;
                    dt.Rows.Add(row);
                }
               
            }

            else
            {
                List<EMPLOYEE> emplist = getEmployeeList(Convert.ToInt32(JobTitleDropDownList.SelectedValue));
                foreach (var employee in emplist)
                {
                    int pid = getpdid(employee.EmployeeId);
                    string ename = getemployeename(pid);
                    int entitlement = getallocatedleave(employee.JobtitleId.Value, Convert.ToInt32(LeaveTypeDropDownList.SelectedValue));
                    int appliedleave = (int)getconsumedleave(employee.EmployeeId, Convert.ToInt32(LeaveTypeDropDownList.SelectedValue));
                    int pendingdays = 0;
                    int scheduleddays = 0;
                    int consumeddays = 0;
                    foreach (var leave in leaves)
                    {
                        if (leave.LeavetypeId == Convert.ToInt32(LeaveTypeDropDownList.SelectedValue) && leave.EmployeeId.Equals(employee.EmployeeId))
                        {
                            if (leave.LeaveStatus.Equals("Pending"))
                                pendingdays = pendingdays + (int)leave.NumberOfDays;
                            if (leave.LeaveStatus.Equals("Approved"))
                                scheduleddays = scheduleddays + (int)leave.NumberOfDays;
                            if (leave.LeaveStatus.Equals("Consumed"))
                                consumeddays = consumeddays + (int)leave.NumberOfDays;
                        }
                    }

                    DataRow row = dt.NewRow();
                    row["Name"] = ename;
                    row["LeaveEntitlement"] = entitlement;
                    row["PendingLeave"] = pendingdays;
                    row["ScheduledLeave"] = scheduleddays;
                    row["ConsumedLeave"] = consumeddays;
                    row["LeaveBalance"] = entitlement - appliedleave; 
                    dt.Rows.Add(row);
                }
                
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            PrintButton.Visible = true;
            displayChart();
        }

        protected void EmployeeViewButton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("LeaveEntitlement");
            dt.Columns.Add("PendingLeave");
            dt.Columns.Add("ScheduledLeave");
            dt.Columns.Add("ConsumedLeave");
            dt.Columns.Add("LeaveBalance");

            //load latest leave record
            loadleaves(EmpFromDate.Text, EmpToDate.Text);


            int pid = getpersonalid(EnameTextBox.Text);
            string employeeid = "";
            int jobtitleid = 0;
            foreach (var employee in employees)
            {
                if (pid == employee.PersonalDetailId)
                {
                    employeeid = employee.EmployeeId;
                    jobtitleid = (int) employee.JobtitleId;
                    break;
                }
            }
            foreach(var leavetype in leavetypes)
            {
                int entitlement = 0;
                int appliedleave = 0;
                int pendingdays = 0;
                int scheduleddays = 0;
                int consumeddays = 0;

                entitlement = getallocatedleave(jobtitleid, leavetype.LeaveTypeId);
                appliedleave = (int)getconsumedleave(employeeid, leavetype.LeaveTypeId);

                foreach (var leave in leaves)
                {
                    if(leave.EmployeeId.Equals(employeeid) && leave.LeavetypeId==leavetype.LeaveTypeId)
                    {
                        if (leave.LeaveStatus.Equals("Pending"))
                           pendingdays = pendingdays + (int)leave.NumberOfDays;
                        if (leave.LeaveStatus.Equals("Approved"))
                           scheduleddays = scheduleddays + (int)leave.NumberOfDays;
                        if (leave.LeaveStatus.Equals("Consumed"))
                           consumeddays = consumeddays + (int)leave.NumberOfDays;
                    }
                }
                DataRow row = dt.NewRow();
                row["Name"] = leavetype.LeaveTypeName;
                row["LeaveEntitlement"] = entitlement;
                row["PendingLeave"] = pendingdays;
                row["ScheduledLeave"] = scheduleddays;
                row["ConsumedLeave"] = consumeddays;
                row["LeaveBalance"] = entitlement - appliedleave;
                dt.Rows.Add(row);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

            PrintButton.Visible = true;
            displayChart();

            
            

        }

        public void displayChart()
        {
            //bind data with chart
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Status");
            dt1.Columns.Add("Days");
            int pending = 0;
            int scheduled = 0;
            int consumed = 0;
            int remained = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                pending = pending + Convert.ToInt32(GridView1.Rows[i].Cells[2].Text);
                scheduled = scheduled + Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
                consumed = consumed + Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
                remained = remained + Convert.ToInt32(GridView1.Rows[i].Cells[5].Text);
            }
            List<string> status = new List<string>();
            status.Add("Pending Leave"); status.Add("Scheduled Leave"); status.Add("Consumed Leave"); status.Add("Remained Leave");
            List<int> days = new List<int>();
            days.Add(pending); days.Add(scheduled); days.Add(consumed); days.Add(remained);
            for (int i = 0; i < 4; i++)
            {
                DataRow row = dt1.NewRow();
                row["Status"] = status[i];
                row["Days"] = days[i];
                dt1.Rows.Add(row);
            }
            Chart2.DataSource = dt1;
            Chart2.DataBind();
            
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        public void demo()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
            var responseTask = client.GetAsync("Attendance");
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
}