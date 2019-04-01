using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class MasterPageSupervisor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["username"].ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("userid");
            Session.Remove("username");
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
    }
}