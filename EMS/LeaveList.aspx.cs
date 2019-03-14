using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Data;

namespace EMS
{
    public partial class LeaveList : System.Web.UI.Page
    {
        public static PERSONALDETAILS[] pdlist;
        public static EMPLOYEE[] employees;
        public static LEAVES[] leaves;
        public static LEAVETYPE[] leavetypes;
        public static EMPLOYEELEAVES[] employeeleaves;
        public static LEAVEALLOCATION[] allocatedleaves;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadpersonaldetails();
                loademployee();
                loadleavetypes();
                loadleaveallocation();
                loademployeeleaves();
                display();
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

        //load leave types
        public void loadleavetypes()
        {
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
            }
        }
       
        //load all leave data
        public void loadleaves(string fromdate,string todate)
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

        //display record in table
        protected void display()
        {
            //load latest leave record
            loadleaves(FromDateTextBox.Text, ToDateTextBox.Text);
            DataTable dt = new DataTable();
            dt.Columns.Add("LeaveId");
            dt.Columns.Add("Date");
            dt.Columns.Add("EmployeeName");
            dt.Columns.Add("LeaveType");
            dt.Columns.Add("LeaveBalance");
            dt.Columns.Add("NumberOfDays");
            dt.Columns.Add("Status");
            dt.Columns.Add("Comment");
            
            //if anything from employee name or leave status is selected 
            if(((!EnameTextBox.Text.Equals(""))||Ischecked(CheckBoxList1)))
            {
                //only leave status is selected
                if((EnameTextBox.Text.Equals("") && Ischecked(CheckBoxList1)) || (Ischecked(CheckBoxList1) && !CustomValidator1.IsValid))
                {
                    //get list of all selected leave status
                    List<string> checkeditems=new List<string>();
                    foreach (ListItem l in CheckBoxList1.Items)
                    {
                        if (l.Selected)
                            checkeditems.Add(l.Text);
                    }
                    foreach (var leave in leaves)
                    {
                        if(checkeditems.Contains(leave.LeaveStatus))
                        {
                            DataRow row = dt.NewRow();
                            int pid = getpdid(leave.EmployeeId);
                            string ename = getemployeename(pid);
                            string leavetypename = getleaevetype(leave.LeavetypeId);
                            int jobid = getjobtitleid(leave.EmployeeId);
                            int allocatedleave = getallocatedleave(jobid, leave.LeavetypeId);
                            double consumeleave = getconsumedleave(leave.EmployeeId, leave.LeavetypeId);
                            double leavebalance =(double) allocatedleave - consumeleave;
                            string date = leave.StartDate.ToShortDateString() + " To " + leave.LastDate.ToShortDateString();

                            row["LeaveId"] = leave.LeaveId;
                            row["Date"] = date;
                            row["EmployeeName"] = ename;
                            row["LeaveType"] = leavetypename;
                            row["LeaveBalance"] = leavebalance;
                            row["NumberOfDays"] = leave.NumberOfDays;
                            row["Status"] = leave.LeaveStatus;
                            row["Comment"] = leave.Description;

                            dt.Rows.Add(row);
                        }
                    }

                }
                //if employee name is entered and if any leave status is not selected then Ischecked will return false
                else if(!EnameTextBox.Text.Equals("") && !Ischecked(CheckBoxList1) && CustomValidator1.IsValid)
                {
                    foreach (var leave in leaves)
                    {
                        int pid = getpdid(leave.EmployeeId);
                        string ename = getemployeename(pid);
                        if(ename.Equals(EnameTextBox.Text))
                        {
                            DataRow row = dt.NewRow();
                            string leavetypename = getleaevetype(leave.LeavetypeId);
                            int jobid = getjobtitleid(leave.EmployeeId);
                            int allocatedleave = getallocatedleave(jobid, leave.LeavetypeId);
                            double consumeleave = getconsumedleave(leave.EmployeeId, leave.LeavetypeId);
                            double leavebalance = (double)allocatedleave - consumeleave;
                            string date = leave.StartDate.ToShortDateString() + " To " + leave.LastDate.ToShortDateString();

                            row["LeaveId"] = leave.LeaveId;
                            row["Date"] = date;
                            row["EmployeeName"] = ename;
                            row["LeaveType"] = leavetypename;
                            row["LeaveBalance"] = leavebalance;
                            row["NumberOfDays"] = leave.NumberOfDays;
                            row["Status"] = leave.LeaveStatus;
                            row["Comment"] = leave.Description;

                            dt.Rows.Add(row);
                        }
                        
                    }
                }
                //if both parameter is entered
                else if((!EnameTextBox.Text.Equals("")) && Ischecked(CheckBoxList1) && CustomValidator1.IsValid)
                {
                    //get list of all selected leave status
                    List<string> checkeditems = new List<string>();
                    foreach (ListItem l in CheckBoxList1.Items)
                    {
                        if (l.Selected)
                            checkeditems.Add(l.Text);
                    }
                    foreach (var leave in leaves)
                    {
                        int pid = getpdid(leave.EmployeeId);
                        string ename = getemployeename(pid);
                        if (ename.Equals(EnameTextBox.Text) && checkeditems.Contains(leave.LeaveStatus))
                        {
                            DataRow row = dt.NewRow();
                            string leavetypename = getleaevetype(leave.LeavetypeId);
                            int jobid = getjobtitleid(leave.EmployeeId);
                            int allocatedleave = getallocatedleave(jobid, leave.LeavetypeId);
                            double consumeleave = getconsumedleave(leave.EmployeeId, leave.LeavetypeId);
                            double leavebalance = (double)allocatedleave - consumeleave;
                            string date = leave.StartDate.ToShortDateString() + " To " + leave.LastDate.ToShortDateString();

                            row["LeaveId"] = leave.LeaveId;
                            row["Date"] = date;
                            row["EmployeeName"] = ename;
                            row["LeaveType"] = leavetypename;
                            row["LeaveBalance"] = leavebalance;
                            row["NumberOfDays"] = leave.NumberOfDays;
                            row["Status"] = leave.LeaveStatus;
                            row["Comment"] = leave.Description;

                            dt.Rows.Add(row);
                        }

                    }
                }
            }
            //any employee name or leave status is not selected
            else
            {
                foreach (var leave in leaves)
                {
                    DataRow row = dt.NewRow();
                    int pid = getpdid(leave.EmployeeId);
                    string ename = getemployeename(pid);
                    string leavetypename = getleaevetype(leave.LeavetypeId);
                    int jobid = getjobtitleid(leave.EmployeeId);
                    int allocatedleave = getallocatedleave(jobid, leave.LeavetypeId);
                    double consumeleave = getconsumedleave(leave.EmployeeId, leave.LeavetypeId);
                    double leavebalance = allocatedleave - consumeleave;
                    string date = leave.StartDate.ToShortDateString() + " To " + leave.LastDate.ToShortDateString();

                    row["LeaveId"] = leave.LeaveId;
                    row["Date"] = date;
                    row["EmployeeName"] = ename;
                    row["LeaveType"] = leavetypename;
                    row["LeaveBalance"] = leavebalance;
                    row["NumberOfDays"] = leave.NumberOfDays;
                    row["Status"] = leave.LeaveStatus;
                    row["Comment"] = leave.Description;

                    dt.Rows.Add(row);
                }
            }           
            
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        //get employee name from personal details based on personal id
        public string getemployeename(int pid)
        {
            string name="";
            foreach(var p in pdlist)
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
            foreach(var emp in employees)
            {
                if (emp.EmployeeId.ToLower().Equals(empid.ToLower()))
                {
                    pid = emp.PersonalDetailId.Value;
                }
            }
            return pid;
        }

        //get leave type naem from leavetype id
        public string getleaevetype(int id)
        {
            string leavename = "";
            foreach(var l in leavetypes)
            {
                if(l.LeaveTypeId==id)
                {
                    leavename = l.LeaveTypeName;
                    break;
                }
            }
            return leavename;
        }

        //get job tile id from employeeid
        public int getjobtitleid(string eid)
        {
            int jobid = 0;
            foreach (var emp in employees)
            {
                if (emp.EmployeeId.ToLower().Equals(eid.ToLower()))
                {
                    jobid = emp.JobtitleId.Value; 
                }
            }
            return jobid;
        }

        //get allocated leave for specific jobtitle and leave type
        public int getallocatedleave(int jobid,int leavetypeid)
        {
            int days = 0;
            foreach(var al in allocatedleaves)
            {
                if(al.JobTitleId==jobid && al.LeaveTypeId==leavetypeid)
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

        //check is any item in checkboxlist is selected or not 
        public bool Ischecked(CheckBoxList cklist)
        {
            foreach(ListItem l in cklist.Items)
            {
                if (l.Selected)
                    return true;
            }
            return false;
        }

        
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row.
                DropDownList droplist = e.Row.FindControl("ActionDropDown") as DropDownList;
                droplist.Width = 150;
                string status = e.Row.Cells[5].Text;
                if (status.Equals("Pending"))
                {
                    droplist.Items.Add(new ListItem("--Select--", "0"));
                    droplist.Items.Add(new ListItem("Approve", "Approved"));
                    droplist.Items.Add(new ListItem("Reject", "Rejected"));
                }
                else if (status.Equals("Approved"))
                {
                    droplist.Items.Add(new ListItem("--Select--", "0"));
                    droplist.Items.Add(new ListItem("Cancel", "Cancelled"));
                }
                else
                    droplist.Visible = false;
            }
        }

        //for auto complete
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
        
        //custom validator method 
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

        protected void Save_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                string status = GridView1.Rows[i].Cells[5].Text;
                string leaveid = GridView1.DataKeys[i].Values[0].ToString();

                LEAVES leave = new LEAVES();

                if (status.Equals("Pending") || status.Equals("Approved"))
                {
                    DropDownList drp = GridView1.Rows[i].FindControl("ActionDropDown") as DropDownList;
                    if(!drp.SelectedValue.Equals("0"))
                    {
                        //change in employee consumed leave
                        if(drp.SelectedValue.Equals("Cancelled") || drp.SelectedValue.Equals("Rejected"))
                        {
                            string empid = "";
                            int leavetypeid = 0;
                            double leaveday = 0;
                            foreach(var l in leaves)
                            {
                                if(l.LeaveId== Convert.ToInt32( leaveid))
                                {
                                    empid = l.EmployeeId;
                                    leavetypeid = l.LeavetypeId;
                                    leaveday = l.NumberOfDays;
                                    break;
                                }
                            }
                            double consumedleave = getconsumedleave(empid,leavetypeid);
                            EMPLOYEELEAVES empleave = new EMPLOYEELEAVES();
                            empleave.EmployeeId = empid;
                            empleave.LeaveTypeId = leavetypeid;
                            empleave.NumberOfLeaves = consumedleave - leaveday;
                            var clientemp = new HttpClient();
                            clientemp.BaseAddress = new Uri(Global.URIstring);
                            //HTTP PUT
                            string url = "EmployeeLeaves?employeeid=" + empid+"&leavetypeid="+leavetypeid;
                            var update = clientemp.PutAsJsonAsync(url, empleave);
                            update.Wait();

                            var r = update.Result;

                        }
                        leave.LeaveStatus = drp.SelectedValue; 
                        var client = new HttpClient();
                        client.BaseAddress = new Uri(Global.URIstring);
                        //HTTP PUT
                        string str = "Leave?leaveid=" + leaveid;
                        var updateTask = client.PutAsJsonAsync(str,leave);
                        updateTask.Wait();

                        var result = updateTask.Result;
                    }
                }
            }
            loadleaves(FromDateTextBox.Text,ToDateTextBox.Text);
            display();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            display();
        }
    }
}