using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;


namespace EMS
{
    public partial class LeaveType : System.Web.UI.Page
    {
        static LEAVETYPE[] leavetypes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //               Response.Write("In page load");
                displayrecord();
            }
        }

        public void displayrecord()
        {
            using (var client = new HttpClient())
            {
                CheckBoxList1.Items.Clear();
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
                        CheckBoxList1.Items.Add(li);
                    }
                }
            }

        }


        protected void DeleteLeaveType(object sender, EventArgs e)
        {
            foreach (ListItem lst in CheckBoxList1.Items)
            {
                if (lst.Selected)
                {
                    foreach (var l in leavetypes)
                    {
                        if (l.LeaveTypeName.Equals(lst.Value))
                        {
                            using (var client = new HttpClient())
                            {
                                client.BaseAddress = new Uri(Global.URIstring);

                                //HTTP DELETE
                                var deleteTask = client.DeleteAsync("LeaveType/" + l.LeaveTypeId.ToString());
                                deleteTask.Wait();

                                var result = deleteTask.Result;
                            }
                        }
                    }
                }
            }
            displayrecord();
        }

        protected void AddLeaveType(object sender, EventArgs e)
        {
            LEAVETYPE leavetype = new EMS.LEAVETYPE();
            leavetype.LeaveTypeName = AddNewLeaveTypeBox.Text.Trim();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                var postTask = client.PostAsJsonAsync("LeaveType", leavetype);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    displayrecord();
                    AddNewLeaveTypeBox.Text = null;
                }

            }
        }
    }
}