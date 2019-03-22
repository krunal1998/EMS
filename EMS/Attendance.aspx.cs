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
    public partial class Attendance : System.Web.UI.Page
    {
        //list of array of employee's personal detail
        public static PERSONALDETAILS[] pdlist;
        public static EMPLOYEE[] employees;
        public static ATTENDANCE[] attendance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["HRId"] != null)
            {
                if (!IsPostBack)
                {
                    loadpersonaldetails();
                    loademployee();
                    filterdata();
                }
            }
            else
                Response.Redirect("~/Login.aspx");
            

        }

        //load personal details of employee
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

        public void loadattendance(DateTime date)
        {
            
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);
            //HTTP GET
            var responseTask = client.GetAsync("Attendance?date="+ date.Date.ToString("yyyy-MM-dd"));
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<ATTENDANCE[]>();
                readTask.Wait();

                attendance = readTask.Result;

            }
        }

        public void loadattendance(String employeename)
        {
            //first check employee name in personal detail and find personal detail id
            foreach(var detail in pdlist)
            {
                string name = detail.FirstName + " " + detail.LastName;
                if(name.ToLower().Equals(employeename.ToLower()))
                {
                    //find employee id from personal detail id 
                    foreach(var emp in employees)
                    {
                        if(emp.PersonalDetailId==detail.PersonalDetailId)
                        {
                            var client = new HttpClient();
                            client.BaseAddress = new Uri(Global.URIstring);
                            //HTTP GET
                            var responseTask = client.GetAsync("Attendance?employeeid=" + emp.EmployeeId);
                            responseTask.Wait();

                            var result = responseTask.Result;
                            if (result.IsSuccessStatusCode)
                            {

                                var readTask = result.Content.ReadAsAsync<ATTENDANCE[]>();
                                readTask.Wait();

                                attendance = readTask.Result;

                            }
                        }
                    }
                }
            }
        }
        //display data based on filter parameter
        public void filterdata()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EmployeeId");
            dt.Columns.Add("EmployeeName");
            dt.Columns.Add("Date");
            dt.Columns.Add("Attendance");

            //if employee name and date is not selected
            if ( (EnameTextBox.Text.Equals("") && DateTextBox.Text.Equals("")) || (!CustomValidator1.IsValid && DateTextBox.Text.Equals("")) )
            {
                //if any filter parameter is not selected then fetch attendance data of current day in attendance[]
                loadattendance(DateTime.Today);
                foreach (var a in attendance)
                {
                    int pid = 0;
                    DataRow row = dt.NewRow();
                    row["EmployeeId"] = a.EmployeeId;
                    row["Date"] = a.PunchInDate.Date.ToString("dd-MM-yyyy");

                    if (a.WorkingHours == 4)
                        row["Attendance"] = "Present(Half day)";
                    else if(a.WorkingHours==8)
                        row["Attendance"] = "Present(Full day)";
                    else
                        row["Attendance"] = "Absent";
                    
                    foreach(var emp in employees)
                    {
                        if(emp.EmployeeId.ToLower().Equals(a.EmployeeId.ToLower()))
                        {
                            pid = Convert.ToInt32(emp.PersonalDetailId);
                            break;
                        }
                    }
                    foreach(var p in pdlist)
                    {
                        if (pid == p.PersonalDetailId)
                        {
                            row["EmployeeName"] = p.FirstName + " " + p.LastName;
                            break;
                        }
                    }
                    dt.Rows.Add(row);
                }
            }
            else
            {
                //if employee name is given and date not
                if((!EnameTextBox.Text.Equals("")) && DateTextBox.Text.Equals("") && CustomValidator1.IsValid)
                {
                    loadattendance(EnameTextBox.Text);

                    //display record in gridview
                    foreach (var a in attendance)
                    {
                        int p_id = 0;
                        DataRow row = dt.NewRow();
                        row["EmployeeId"] = a.EmployeeId;
                        row["Date"] = a.PunchInDate.Date.ToString("dd-MM-yyyy");

                        if (a.WorkingHours == 4)
                            row["Attendance"] = "Present(Half day)";
                        else if (a.WorkingHours == 8)
                            row["Attendance"] = "Present(Full day)";
                        else
                            row["Attendance"] = "Absent";

                        foreach (var emp in employees)
                        {
                            if (emp.EmployeeId.ToLower().Equals(a.EmployeeId.ToLower()))
                            {
                                p_id = Convert.ToInt32(emp.PersonalDetailId);
                                break;
                            }
                        }
                        foreach (var p in pdlist)
                        {
                            if (p_id == p.PersonalDetailId)
                            {
                                row["EmployeeName"] = p.FirstName + " " + p.LastName;
                                break;
                            }
                        }
                        dt.Rows.Add(row);
                    }
                    
                }
                //if employee name is not entered and date is entered
                else if(EnameTextBox.Text.Equals("") && (!DateTextBox.Text.Equals("")) || (!DateTextBox.Text.Equals("")) && !CustomValidator1.IsValid)
                {
                    //load attendance data based on entered date
                    DateTime date = Convert.ToDateTime(DateTextBox.Text);
                    loadattendance(date);
                    //display data in gridview
                    foreach (var a in attendance)
                    {
                        int pid = 0;
                        DataRow row = dt.NewRow();
                        row["EmployeeId"] = a.EmployeeId;
                        row["Date"] = a.PunchInDate.Date.ToString("dd-MM-yyyy");

                        if (a.WorkingHours == 4)
                            row["Attendance"] = "Present(Half day)";
                        else if (a.WorkingHours == 8)
                            row["Attendance"] = "Present(Full day)";
                        else
                            row["Attendance"] = "Absent";

                        foreach (var emp in employees)
                        {
                            if (emp.EmployeeId.ToLower().Equals(a.EmployeeId.ToLower()))
                            {
                                pid = Convert.ToInt32(emp.PersonalDetailId);
                                break;
                            }
                        }
                        foreach (var p in pdlist)
                        {
                            if (pid == p.PersonalDetailId)
                            {
                                row["EmployeeName"] = p.FirstName + " " + p.LastName;
                                break;
                            }
                        }
                        dt.Rows.Add(row);
                    }

                }
                //both employee name and date is entered
                else
                {
                    //load attendance data based on entered date
                    DateTime date = Convert.ToDateTime(DateTextBox.Text);
                    loadattendance(date.Date);

                    //get employee id of entered employee name
                    int pid = 0;
                    string empid = "";
                    string ename;
                    foreach (var p in pdlist)
                    {
                        ename= p.FirstName + " " + p.LastName;
                        if (ename.Equals(EnameTextBox.Text))
                        {
                            pid = p.PersonalDetailId;
                            break;
                        }
                    }
                    foreach (var emp in employees)
                    {
                        if (emp.PersonalDetailId==pid)
                        {
                            empid = emp.EmployeeId;
                        }
                    }

                    //display data in gridview
                    foreach (var a in attendance)
                    {
                        if(a.EmployeeId.Equals(empid)&& a.PunchInDate==date)
                        {
                            DataRow row = dt.NewRow();
                            row["EmployeeId"] = a.EmployeeId;
                            row["Date"] = a.PunchInDate.Date.ToString("dd-MM-yyyy");

                            if (a.WorkingHours == 4)
                                row["Attendance"] = "Present(Half day)";
                            else if (a.WorkingHours == 8)
                                row["Attendance"] = "Present(Full day)";
                            else
                                row["Attendance"] = "Absent";
                            row["EmployeeName"] = EnameTextBox.Text;
                            dt.Rows.Add(row);

                        }
                    }

                }

            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void ViewButton_Click(object sender, EventArgs e)
        {
            filterdata();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

           filterdata();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row= (GridViewRow)GridView1.Rows[e.RowIndex];
            ATTENDANCE updateatd = new ATTENDANCE();
            string empid = row.Cells[0].Text;
            string empname= row.Cells[1].Text;
            DateTime date = Convert.ToDateTime(row.Cells[2].Text);
            DropDownList drplist = row.FindControl("DropDownList1") as DropDownList;
            GridView1.EditIndex = -1;

            foreach (ATTENDANCE atd in attendance)
            {
                if(atd.EmployeeId.ToLower().Equals(empid.ToLower()) && date==atd.PunchInDate)
                {
                    updateatd.EmployeeId = atd.EmployeeId;
                    updateatd.PunchInDate = atd.PunchInDate;
                    updateatd.PunchInTime = atd.PunchInTime;
                    updateatd.PunchOutTime = atd.PunchOutTime;
                    break;
                }
            }
            updateatd.WorkingHours = Convert.ToInt32( drplist.SelectedValue);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                string url = "Attendance?employeeid=" + empid + "&date=" + date.Date.ToString("yyyy-MM-dd");
                //HTTP PUT
                var updateTask = client.PutAsJsonAsync(url,updateatd);
                updateTask.Wait();

                var result = updateTask.Result;
            }

            filterdata();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            filterdata();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                //set value of dropdown list in edit mode for work hours
                DropDownList droplist = e.Row.FindControl("DropDownList1") as DropDownList;
                string selected = DataBinder.Eval(e.Row.DataItem, "Attendance").ToString();
                droplist.Items.FindByText(selected).Selected = true;
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

        //reset filter parameter
        protected void ResetButton_Click(object sender, EventArgs e)
        {
            EnameTextBox.Text = null;
            DateTextBox.Text = null;
            filterdata();
        }
       
        //custom validator method to check entered name is in employee name list or not
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            List<string> list = GetEmployeeName();
            if (!list.Contains(EnameTextBox.Text))
            {
                args.IsValid = false;
            }
        }
    }
}