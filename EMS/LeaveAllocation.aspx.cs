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
    public partial class LeaveAllocation : System.Web.UI.Page
    {
        public static JOBTITLE[] jobtitles;
        public static LEAVETYPE[] leavetypes;
        public static LEAVEALLOCATION[] leaveallocations;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadjobtitle();
                loadleavetype();
                loadleaveallocation();
                filterdata();
                //gvbind();
            }
        }

        //load job tiles in dropdownlist 
        public void loadjobtitle()
        {
            DropDownList1.Items.Clear();
            DropDownList3.Items.Clear();
            ListItem select = new ListItem("Select job title","0");
            DropDownList1.Items.Add(select);
            DropDownList3.Items.Add(select);
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
                        DropDownList1.Items.Add(li);
                        DropDownList3.Items.Add(li);
                    }
                }
            }

        }
        //load leave type in dropdownlist
        public void loadleavetype()
        {
            using (var client = new HttpClient())
            {
                DropDownList2.Items.Clear();
                DropDownList4.Items.Clear();
                ListItem select = new ListItem("Select leave type", "0");
                DropDownList2.Items.Add(select);
                DropDownList4.Items.Add(select);

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

                    foreach (var leavetype in leavetypes)
                    {
                        ListItem li = new ListItem();

                        li.Text = leavetype.LeaveTypeName;
                        li.Value = leavetype.LeaveTypeName;
                        DropDownList2.Items.Add(li);
                        DropDownList4.Items.Add(li);
                    }
                }
            }
        }

        //load data in leave allocations
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

                    leaveallocations = readTask.Result;
                }
            }
        }
        
        //filter data based on filter parameter and display in gridview
        public void filterdata()
        {
            //get latest updated data in leaveallocations array
            //gvbind();
            DataTable dt = new DataTable();
            dt.Columns.Add("JobTitle", Type.GetType("System.String"));
            dt.Columns.Add("LeaveType", Type.GetType("System.String"));
            dt.Columns.Add("numberofLeaves", Type.GetType("System.Int32"));

            //if job title or leave type as filter is choosen 
            if ((DropDownList3.SelectedIndex != 0) || (DropDownList4.SelectedIndex != 0))
            {
                //if only job title is choosen as filter
                if ((DropDownList3.SelectedIndex != 0) && (DropDownList4.SelectedIndex == 0))
                {
                    foreach (var leaveallocation in leaveallocations)
                    {
                        int flag = 0;
                        DataRow row = dt.NewRow();


                        foreach (var jobtitle in jobtitles)
                        {
                            if ((jobtitle.JobTitleId == leaveallocation.JobTitleId) && jobtitle.JobTitleName.Equals(DropDownList3.SelectedValue))
                            {
                                flag = 1;
                                row["JobTitle"] = jobtitle.JobTitleName;
                            }
                        }
                        if (flag == 1)
                        {
                            foreach (var leavetype in leavetypes)
                            {
                                if (leavetype.LeaveTypeId == leaveallocation.LeaveTypeId)
                                    row["LeaveType"] = leavetype.LeaveTypeName;
                            }
                            row["numberofLeaves"] = leaveallocation.NumberOfLeave;
                            dt.Rows.Add(row);
                        }
                    }
                }
                //if only leave type is choosen as filter parameter
                else if ((DropDownList3.SelectedIndex == 0) && (DropDownList4.SelectedIndex != 0))
                {
                    foreach (var leaveallocation in leaveallocations)
                    {
                        int flag = 0;
                        DataRow row = dt.NewRow();

                        foreach (var leavetype in leavetypes)
                        {
                            if ((leavetype.LeaveTypeId == leaveallocation.LeaveTypeId) && leavetype.LeaveTypeName.Equals(DropDownList4.SelectedValue))
                            {
                                flag = 1;
                                row["LeaveType"] = leavetype.LeaveTypeName;
                            }
                        }
                        if (flag == 1)
                        {
                            foreach (var jobtitle in jobtitles)
                            {
                                if (jobtitle.JobTitleId == leaveallocation.JobTitleId)
                                    row["JobTitle"] = jobtitle.JobTitleName;
                            }
                            row["numberofLeaves"] = leaveallocation.NumberOfLeave;
                            dt.Rows.Add(row);
                        }
                    }
                }
                //if job title and leave type both choosen as filter parameter
                else if ((DropDownList3.SelectedIndex != 0) && (DropDownList4.SelectedIndex != 0))
                {
                    foreach (var leaveallocation in leaveallocations)
                    {
                        int flag = 0;
                        var temp = "";
                        DataRow row = dt.NewRow();

                        foreach (var jobtitle in jobtitles)
                        {
                            if ((jobtitle.JobTitleId == leaveallocation.JobTitleId) && jobtitle.JobTitleName.Equals(DropDownList3.SelectedValue))
                            {
                                flag = 1;
                                temp = jobtitle.JobTitleName;
                            }
                        }
                        if (flag == 1)
                        {
                            foreach (var leavetype in leavetypes)
                            {
                                if (leavetype.LeaveTypeId == leaveallocation.LeaveTypeId && leavetype.LeaveTypeName.Equals(DropDownList4.SelectedValue))
                                {
                                    row["LeaveType"] = leavetype.LeaveTypeName;
                                    row["JobTitle"] = temp;
                                    row["numberofLeaves"] = leaveallocation.NumberOfLeave;
                                    dt.Rows.Add(row);
                                }
                            }
                        }
                    }
                }
            }
            //if no filter is choosen
            else
            {
                foreach (var leaveallocation in leaveallocations)
                {
                    DataRow row = dt.NewRow();

                    row["numberofLeaves"] = leaveallocation.NumberOfLeave;
                    foreach (var jobtitle in jobtitles)
                    {
                        if (jobtitle.JobTitleId == leaveallocation.JobTitleId)
                            row["JobTitle"] = jobtitle.JobTitleName;
                    }
                    foreach (var leavetype in leavetypes)
                    {
                        if (leavetype.LeaveTypeId == leaveallocation.LeaveTypeId)
                            row["LeaveType"] = leavetype.LeaveTypeName;
                    }
                    dt.Rows.Add(row);
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();


        }

        /*       protected void gvbind()
               {
                   DataTable dt = new DataTable();
                   DataColumn dc1 = new DataColumn("JobTitle");
                   DataColumn dc2 = new DataColumn("LeaveType");
                   DataColumn dc3 = new DataColumn("numberofLeaves");
                   dt.Columns.Add("JobTitle",Type.GetType("System.String"));
                   dt.Columns.Add("LeaveType", Type.GetType("System.String"));
                   dt.Columns.Add("numberofLeaves", Type.GetType("System.Int32"));

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

                           leaveallocations = readTask.Result;

                           foreach (var leaveallocation in leaveallocations )
                           {
                               DataRow row = dt.NewRow();

                               row["numberofLeaves"] = leaveallocation.NumberOfLeave;
                               foreach(var jobtitle in jobtitles)
                               {
                                   if(jobtitle.JobTitleId==leaveallocation.JobTitleId)
                                       row["JobTitle"] = jobtitle.JobTitleName;
                               }
                               foreach (var leavetype in leavetypes)
                               {
                                   if (leavetype.LeaveTypeId == leaveallocation.LeaveTypeId)
                                       row["LeaveType"] = leavetype.LeaveTypeName;
                               }
                               dt.Rows.Add(row);
                           }
                       }
                   }


                   GridView1.DataSource = dt;
                   GridView1.DataBind();

               }*/

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            filterdata();
           // gvbind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            TextBox leavedays = row.Cells[3].Controls[0] as TextBox;
            string title = row.Cells[1].Text;
            string type = row.Cells[2].Text;
            LEAVEALLOCATION leaveallocation = new LEAVEALLOCATION();
            GridView1.EditIndex = -1;

            using (var client = new HttpClient())
            {
                string titleid = null, typeid = null;
                //assign new value to leave allocation oject
                foreach (var jobtitle in jobtitles)
                {
                    if (jobtitle.JobTitleName.Equals(title))
                    {
                        leaveallocation.JobTitleId = jobtitle.JobTitleId;
                        titleid = jobtitle.JobTitleId.ToString();
                    }
                }
                foreach (var leavetype in leavetypes)
                {
                    if (leavetype.LeaveTypeName.Equals(type))
                    {
                        leaveallocation.LeaveTypeId = leavetype.LeaveTypeId;
                        typeid = leavetype.LeaveTypeId.ToString();
                    }
                }
                leaveallocation.NumberOfLeave = Convert.ToInt32( leavedays.Text);
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP PUT
                string str = "LeaveAllocation?jobtitleid=" + titleid + "&leavetypeid=" + typeid;
                var updateTask = client.PutAsJsonAsync(str,leaveallocation);
                updateTask.Wait();

                var result = updateTask.Result;
            }

            loadleaveallocation();
            filterdata();
           // gvbind();
            
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            filterdata();
            //gvbind();
        }

        //Add new record
        protected void Add_Click(object sender, EventArgs e)
        {
            LEAVEALLOCATION new_leaveallocation = new LEAVEALLOCATION();
            
            //get job title id
            foreach (var jobtitle in jobtitles)
            {
                if(DropDownList1.SelectedValue.Equals(jobtitle.JobTitleName))
                {
                    new_leaveallocation.JobTitleId = jobtitle.JobTitleId;
                    break;
                }
            }
            
            //get leave type id
            foreach (var leavetype in leavetypes)
            {
                if (DropDownList2.SelectedValue.Equals(leavetype.LeaveTypeName))
                {
                    new_leaveallocation.LeaveTypeId = leavetype.LeaveTypeId;
                    break;
                }
            }

            new_leaveallocation.NumberOfLeave = Convert.ToInt32(DaysTextBox.Text);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                var postTask = client.PostAsJsonAsync("LeaveAllocation", new_leaveallocation);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    DaysTextBox.Text = null;
                    DropDownList1.SelectedIndex = 0;
                    DropDownList2.SelectedIndex = 0;
                }

            }
            DropDownList3.SelectedIndex = 0;
            DropDownList4.SelectedIndex = 0;
            loadleaveallocation();
            filterdata();
            //gvbind();
        }

        
        //search records
        protected void Search_Click(object sender, EventArgs e)
        {
            filterdata();   
        }

        
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            for(int i=0; i< GridView1.Rows.Count;i++)
            {
                CheckBox checkbox = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Selector");
                if(checkbox !=null)
                {
                    if(checkbox.Checked)
                    {
                        string title = GridView1.Rows[i].Cells[1].Text;
                        string type = GridView1.Rows[i].Cells[2].Text;
                        deleterecord(title, type);
                    }
                }
            }
            loadleaveallocation();
            filterdata();
            //gvbind();
        }

        public void deleterecord(string title,string type)
        {
            
            using (var client = new HttpClient())
            {
                string titleid=null, typeid=null;
                foreach (var jobtitle in jobtitles)
                {
                    if (jobtitle.JobTitleName.Equals(title))
                    {
                        titleid = jobtitle.JobTitleId.ToString();
                    }
                }
                foreach (var leavetype in leavetypes)
                {
                    if (leavetype.LeaveTypeName.Equals(type))
                    {
                        typeid = leavetype.LeaveTypeId.ToString();
                    }
                }
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP DELETE
                var deleteTask = client.DeleteAsync("LeaveAllocation?jobtitleid=" + titleid + "&leavetypeid=" + typeid);
                deleteTask.Wait();

                var result = deleteTask.Result;
            }
        }
    }
}