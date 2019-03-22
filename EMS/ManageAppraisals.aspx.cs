using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace EMS
{
    public partial class ManageAppraisals : System.Web.UI.Page
    {
        public static JOBTITLE jt;
        static List<ALLOCATEDALLOWANCES> allocallowlist;
        static List<ALLOWANCES> allowlist;
        static List<PERSONALDETAILS> pdlist;
        static List<EMPLOYEE> elist;
        public static EMPLOYEE emp;

        protected void Page_Load(object sender, EventArgs e)
        {
            pdlist = getallpersonaldetails();
            elist = getallemployees();
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

        private EMPLOYEE getEmployee(string employeeId)
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

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            List<string> list = GetEmployeeName();
            if (!list.Contains(TextBox1.Text))
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

        protected void Show_Click(object sender, EventArgs e)
        {
            if (CustomValidator1.IsValid)
            {
                string name = TextBox1.Text;
                PERSONALDETAILS pd = pdlist.Find(p => (p.FirstName + " " + p.MiddleName + " " + p.LastName).Equals(name));
                emp = elist.Find(em => em.PersonalDetailId == pd.PersonalDetailId);
                      
               
                filterdata();       



            }
        }


        private ALLOWANCES getallowance(int allowanceId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Allowances/"+allowanceId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<ALLOWANCES>();
                    readTask.Wait();

                    var allowances = readTask.Result;

                    return allowances;

                }
                else return null;
            }
        }

        private void getallocatedallowances(string employeeId)
        {
            allocallowlist = new List<ALLOCATEDALLOWANCES>();
            allowlist = new List<ALLOWANCES>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("ALLOCATEDAllowances/");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<ALLOCATEDALLOWANCES[]>();
                    readTask.Wait();

                    var allocallowances = readTask.Result;

                    foreach (var aa in allocallowances)
                    {

                        if(employeeId.Equals(aa.EmployeeId))
                        {
                            allocallowlist.Add(aa);
                            allowlist.Add(getallowance(aa.AllowanceId));
                        }
                    }

                }
            }
        }
        private void filterdata()
        {

            getallocatedallowances(emp.EmployeeId);
            DataTable dt = new DataTable();
            dt.Columns.Add("AllowanceId", Type.GetType("System.String"));
            dt.Columns.Add("AllowanceName", Type.GetType("System.String"));
            dt.Columns.Add("AllowanceAmount", Type.GetType("System.Int32"));
            dt.Columns.Add("ChangeAmount", Type.GetType("System.Int32"));
            //dt.Columns.Add("Action", Type.GetType("System.Int32"));
            foreach (ALLOCATEDALLOWANCES all in allocallowlist)
            {
                DataRow row = dt.NewRow();
                row["AllowanceId"] = all.AllowanceId;

                row["AllowanceName"] = allowlist.Find(al => al.AllowanceId == all.AllowanceId).AllowanceName;

                row["AllowanceAmount"] = all.Salary;
                
               

                dt.Rows.Add(row);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.Columns[3].Visible = false;
            GridView1.Columns[4].Visible = false;
            filterdata();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.Columns[4].Visible = true;
            GridView1.Columns[3].Visible = true;
            GridView1.EditIndex = e.NewEditIndex;

            filterdata();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            TextBox changedamt = row.Cells[4].Controls[0] as TextBox;
            DropDownList actionlist = row.Cells[3].FindControl("ActionDropDown") as DropDownList;
            int allowanceid =Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            int ammt = Convert.ToInt32(row.Cells[2].Text);
            //int parameterid = Convert.ToInt32( row.Cells[1].Text);

            if (actionlist.SelectedIndex == 0)
            {
                ammt += Convert.ToInt32(changedamt.Text);
            }
            else {
                ammt -= Convert.ToInt32(changedamt.Text);
                if (ammt < 0)
                    ammt = 0;
            }
            GridView1.EditIndex = -1;

            ALLOCATEDALLOWANCES aa = new ALLOCATEDALLOWANCES();
            aa.AllowanceId = allowanceid;
            aa.EmployeeId = emp.EmployeeId;
            aa.Salary = ammt;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP PUT
                var putTask = client.PutAsJsonAsync("allocatedallowances/" + aa.AllowanceId + "?employeeid="+emp.EmployeeId, aa);
                putTask.Wait();

                var result = putTask.Result;
            }
            GridView1.Columns[3].Visible = false;
            GridView1.Columns[4].Visible = false;
            filterdata();

        }
    }
}



       
