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
    public partial class ManageAllowances : System.Web.UI.Page
    {

        public static JOBTITLE jt;
        public static JOBTITLE[] jobtitles;
        public static List<ALLOWANCES> allowlist;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 

              
                deleteerrorlabel.Visible = false;
                loadjobtitle();

            }
            addallowancestable.Visible = false;

        }

        private void loadjobtitle()
        {
            JobTitleValue.Items.Clear();

            ListItem select = new ListItem("Select job title", "0");
            JobTitleValue.Items.Add(select);
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
                        JobTitleValue.Items.Add(li);

                    }
                }
            }
        }

        private void filterdata()
        {
            DataTable dt = new DataTable();
           dt.Columns.Add("AllowanceId", Type.GetType("System.String"));
            dt.Columns.Add("AllowanceName", Type.GetType("System.String"));
            dt.Columns.Add("DefaultAmount", Type.GetType("System.Int32"));
            foreach (ALLOWANCES all in allowlist)
            {
                DataRow row = dt.NewRow();
                row["AllowanceId"] = all.AllowanceId;
                row["AllowanceName"] = all.AllowanceName;

                row["DefaultAmount"] = all.DefaultPay;

                dt.Rows.Add(row);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private void getallowances(int jobTitleId)
        {
            allowlist = new List<ALLOWANCES>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Allowances/");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<ALLOWANCES[]>();
                    readTask.Wait();

                    var allowances = readTask.Result;

                    foreach (var a in allowances)
                    {

                        if (jobTitleId == a.JobTitleId)
                        {
                            allowlist.Add(a);
                        }
                    }

                }
            }
        }

        private JOBTITLE getjobtitle(int jobtitleId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);
            var responsetask = client.GetAsync("jobtitle/" + jobtitleId);
            responsetask.Wait();

            var result = responsetask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readtask = result.Content.ReadAsAsync<JOBTITLE>();
                readtask.Wait();

                return readtask.Result;
            }
            return null;
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            
            filterdata();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            
            TextBox allowanceName = row.Cells[2].Controls[0] as TextBox;
            TextBox defaultAmount = row.Cells[3].Controls[0] as TextBox;
           // int allowanceid = Convert.ToInt32( row.Cells[1].Text);

            ALLOWANCES all = new ALLOWANCES();
            all.JobTitleId = jt.JobTitleId;
            all.DefaultPay = Convert.ToInt32(defaultAmount.Text);
            all.AllowanceName = allowanceName.Text;
            all.AllowanceId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            Response.Write(all.AllowanceId);
            GridView1.EditIndex = -1;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP PUT
                var updateTask = client.PutAsJsonAsync("allowances/" + all.AllowanceId, all);
                updateTask.Wait();

                var result = updateTask.Result;
            }

            getallowances(jt.JobTitleId);
            filterdata();
            // gvbind(); */

        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            filterdata();
            //gvbind();
        }

        protected void AddNewAllowanceButton_Click(object sender, EventArgs e)
        {
            addallowancestable.Visible = true;
        }
        protected void addbutton_Click(object sender, EventArgs e)
        {
            ALLOWANCES all = new ALLOWANCES();
            all.JobTitleId = jt.JobTitleId;
            all.DefaultPay = Convert.ToInt32(newdefaultamounttextbox.Text);
            all.AllowanceName = newallowancetextbox.Text;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP PUT
                var updateTask = client.PostAsJsonAsync("allowances/", all);
                updateTask.Wait();

                var result = updateTask.Result;
            }
            getallowances(jt.JobTitleId);
            filterdata();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            AddNewAllowanceButton.Visible = true;
            DeleteButton.Visible = true;
            int jtv = Convert.ToInt32(JobTitleValue.SelectedIndex);
            jt = getjobtitle(jtv);

            getallowances(jt.JobTitleId);

            filterdata();
            
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

/* public static JOBTITLE[] jobtitles;
        static List<PERSONALDETAILS> pdlist;
        static List<EMPLOYEE> elist;
        protected void Page_Load(object sender, EventArgs e)
        {


                loadjobtitle();
            pdlist = getallpersonaldetails();

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

        private void loademployeename()
         {
             EmployeeValue.Items.Clear();
             ListItem select = new ListItem("Select Employee", "0");
             EmployeeValue.Items.Add(select);
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri(Global.URIstring);
                 //HTTP GET
                 var responseTask = client.GetAsync("PersonalDetails");
                 responseTask.Wait();

                 var result = responseTask.Result;
                 if (result.IsSuccessStatusCode)
                 {

                     var readTask = result.Content.ReadAsAsync<PERSONALDETAILS[]>();
                     readTask.Wait();

                     pd = readTask.Result;

                     foreach (var ename in pd)
                     {
                         ListItem li = new ListItem(ename.FirstName+""+ename.MiddleName+""+ename.LastName);
                         li.Text = ename.FirstName + "" + ename.MiddleName + "" + ename.LastName;
                         li.Value = ename.FirstName + "" + ename.MiddleName + "" + ename.LastName;
                         EmployeeValue.Items.Add(li);
                     }
                 }
             }
         }

        private void loadjobtitle()
        {
            JobTitleValue.Items.Clear();
            ListItem select = new ListItem("Select job title", "0");
            JobTitleValue.Items.Add(select);
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
                        li.Value = jobtitle.JobTitleName;
                        JobTitleValue.Items.Add(li);
                    }
                }
            }

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if(CustomValidator1.IsValid)
            {
                string name = EmployeeNameValue.Text;
                PERSONALDETAILS pd = pdlist.Find(p => (p.FirstName + " " + p.MiddleName + " " + p.LastName).Equals(name));
                EMPLOYEE emp = elist.Find(em => em.PersonalDetailId == pd.PersonalDetailId);
                emp.EmployeeId
                elist = getallemployees();
            }
        }

        private void getpid()
        {

        }
    }*/
