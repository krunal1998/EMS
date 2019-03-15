using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        /*
        PERSONALDETAILS pd;
        LOGINDETAILS ld;
        EMPLOYEE e;
        ALLOCATEDALLOWANCES aa;
        ALLOWANCES a;
        JOBTITLE jt;
        protected void Page_Load(object sender, EventArgs e)
        {
            a=getallowances
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            c.feedbackDescription = FeedbackValue.Text;
            c.ComplainStatus = StatusValue.SelectedValue;
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);

            var putTask = client.PutAsJsonAsync<COMPLAINS>("complains/" + c.ComplainId, c);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                Response.Write("Save successfull!");
            }
            FeedbackValue.Enabled = false;
            StatusValue.Enabled = false;
        }*/
    }
}