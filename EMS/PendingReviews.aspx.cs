using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class ViewReviews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
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
        }

        protected void Search_Click(object sender, EventArgs e)
        {

        }
    }
}