using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;

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
                loadleaves();
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
        public void loadleaves()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Leave");
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
            foreach(var leave in leaves)
            {
                int pid = getpdid(leave.EmployeeId);
                string ename = getemployeename(pid);
                string leavetypename = getleaevetype(leave.LeavetypeId);
                int jobid = getjobtitleid(leave.EmployeeId);
                int allocatedleave = getallocatedleave(jobid,leave.LeavetypeId);
                int consumeleave = getconsumedleave(leave.EmployeeId,leave.LeavetypeId);
                int leavebalance = allocatedleave - consumeleave;
                string date = leave.StartDate.ToShortDateString() + " To " + leave.LastDate.ToShortDateString();

                createrow(leave.LeaveId,date,ename,leavetypename,leavebalance,leave.NumberOfDays,leave.LeaveStatus,leave.Description);
            }
            Table1.DataBind();
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
        public int getconsumedleave(string empid, int leavetypeid)
        {
            int days = 0;
            foreach (var cl in employeeleaves)
            {
                if (cl.EmployeeId.ToLower().Equals(empid.ToLower()) && cl.LeaveTypeId == leavetypeid)
                {
                    days = cl.NumberOfLeaves;
                    break;
                }
            }
            return days;
        }

        //create row for display in table
        public void createrow(int leaveid,string date,string ename,string leavetype,int remainedleaves,double numberofdays,string status,string comment)
        {
            TableRow row = new TableRow();
            row.ID = leaveid.ToString();

            TableCell datecell = new TableCell();
            datecell.HorizontalAlign = HorizontalAlign.Center;
            Label datelabel = new Label();
            datelabel.Text = date;
            datecell.Controls.Add(datelabel);
            row.Cells.Add(datecell);

            TableCell enamecell = new TableCell();
            enamecell.HorizontalAlign = HorizontalAlign.Center;
            Label enamelabel = new Label();
            enamelabel.Text = ename;
            enamecell.Controls.Add(enamelabel);
            row.Cells.Add(enamecell);

            TableCell leavetypecell = new TableCell();
            leavetypecell.HorizontalAlign = HorizontalAlign.Center;
            Label leavetypelabel = new Label();
            leavetypelabel.Text = leavetype; ;
            leavetypecell.Controls.Add(leavetypelabel);
            row.Cells.Add(leavetypecell);

            TableCell remainleavecell = new TableCell();
            remainleavecell.HorizontalAlign = HorizontalAlign.Center;  
            Label remainleavelabel = new Label();
            remainleavelabel.Text = Convert.ToString( remainedleaves);
            remainleavecell.Controls.Add(remainleavelabel);
            row.Cells.Add(remainleavecell);

            TableCell dayscell = new TableCell();
            dayscell.HorizontalAlign = HorizontalAlign.Center;
            Label dayslabel = new Label();
            dayslabel.Text = Convert.ToString(numberofdays);
            dayscell.Controls.Add(dayslabel);
            row.Cells.Add(dayscell);

            TableCell statuscell = new TableCell();
            statuscell.HorizontalAlign = HorizontalAlign.Center;
            Label statuslabel = new Label();
            statuslabel.Text = status;
            statuscell.Controls.Add(statuslabel);
            row.Cells.Add(statuscell);

            TableCell descriptioncell = new TableCell();
            descriptioncell.HorizontalAlign = HorizontalAlign.Center;
            Label descriptionlabel = new Label();
            descriptionlabel.Text = comment;
            descriptioncell.Controls.Add(descriptionlabel);
            row.Cells.Add(descriptioncell);

            TableCell Actioncell = new TableCell();
            Actioncell.HorizontalAlign = HorizontalAlign.Center;
            if (status.Equals("Pending"))
            {
                DropDownList drp = new DropDownList();
                drp.ID = "drp" + leaveid.ToString();
                drp.Width = 150;
                drp.Items.Add(new ListItem("--Select--", "0"));
                drp.Items.Add(new ListItem("Accept", "Accept"));
                drp.Items.Add(new ListItem("Reject", "Reject"));
                Actioncell.Controls.Add(drp);
            }
            else if(status.Equals("Approved"))
            {
                DropDownList drp = new DropDownList();
                drp.ID = "drp" + leaveid.ToString();
                drp.Width = 150;
                drp.Items.Add(new ListItem("--Select--", "0"));
                drp.Items.Add(new ListItem("Cancel", "Cancelled"));
                Actioncell.Controls.Add(drp);
            }
            row.Cells.Add(Actioncell);
            //add row in table
            Table1.Rows.Add(row);
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
        }

        protected void Save_Click(object sender, EventArgs e)
        {
           // var c = (Content)Page.FindControl("Content3");
           // Table tb = (Table)Page.FindControl("Table1");
            foreach(TableRow tr in Table1.Rows)
            {
                string status = tr.Cells[5].Text;
                LEAVES leave = new LEAVES();
                leave.LeaveStatus = status;
                if(status.Equals("Pending") || status.Equals("Approved"))
                {
                    //generate id for dropdown list
                    string id = "drp" + tr.ID;
                    DropDownList drp = tr.Cells[7].FindControl(id) as DropDownList;
                    if(!drp.SelectedValue.Equals("0"))
                    {
                        var client = new HttpClient();
                        client.BaseAddress = new Uri(Global.URIstring);
                        //HTTP PUT
                        string str = "LeaveAllocation?leaveid=" + tr.ID.ToString();
                        var updateTask = client.PutAsJsonAsync(str,leave);
                        updateTask.Wait();

                        var result = updateTask.Result;
                    }
                }
            }
            loadleaves();
            display();
        }
    }
}