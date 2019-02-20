using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EMS
{
    public partial class ViewReviews : System.Web.UI.Page
    {
        private int supervisorid = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Table table = Table1;
                List<GENERATEREVIEW> list = getAllPendingReviews();

                foreach(GENERATEREVIEW g in list) {
                    String ename = getEmployeeName(g.EmployeeId);
                    TableRow row = new TableRow();
                    TableCell employee = new TableCell();
                    Label employeelabel = new Label();
                    employeelabel.Text = ename;
                    employee.Controls.Add(employeelabel);
                    row.Cells.Add(employee);
                }
            }
        }

        private string getEmployeeName(string employeeId)
        {
            throw new NotImplementedException();
        }

        protected void Search_Click(object sender, EventArgs e)
        {

        }
        public List<GENERATEREVIEW> getAllPendingReviews()
        {
            List<GENERATEREVIEW> list = new List<GENERATEREVIEW>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60464/api/");
                //HTTP GET
                var responseTask = client.GetAsync("GeneratedReviews");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<GENERATEREVIEW[]>();
                    readTask.Wait();

                    var GRs = readTask.Result;

                    foreach (var g in GRs)
                    {
                        int gsid =getEmployeeSID(g.EmployeeId);
                        if (supervisorid == gsid) {
                            list.Add(g);
                        }
                    }
                }
            }
            return list;
        }

        private int getEmployeeSID(string employeeID)
        {
            EMPLOYEE e = getEmployee(employeeID);
            return e.SupervisorId.Value;
        }

        private EMPLOYEE getEmployee(string employeeID) { return null; }
        /*
        [System.Web.Script.Services.ScriptMethod()]

        [System.Web.Services.WebMethod]

        public static List<string> GetEmployeesList(string prefixText)

        {
            List<string> list = new List<string>();
            list.Add("abc");
            list.Add("abb");
            list.Add("acb");
            list.Add("bca");
            list.Add("edfg");
            List<string> temp = new List<string>();
            foreach (string v in list)
            {
                if (v.Contains(prefixText))
                    temp.Add(v);
            }
            return temp;
        } */

    }


}