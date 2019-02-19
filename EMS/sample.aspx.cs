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
    public partial class sample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62255/api/");
                //HTTP GET
                var responseTask = client.GetAsync("LeaveType");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<LEAVETYPE[]>();
                    readTask.Wait();

                    var students = readTask.Result;

                    foreach (var leavetype in students)
                    {
                        Response.Write(leavetype.LeaveTypeName);
                    }
                }
            }
        }
    }
}