using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class WorkWeek : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = DropDownList1.SelectedIndex;
            DropDownList1.Items[i].Selected=false;
            DropDownList1.Items[1].Selected = true;


        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            DropDownList1.Enabled = true;
            DropDownList2.Enabled = true;
            DropDownList3.Enabled = true;
            DropDownList4.Enabled = true;
            DropDownList5.Enabled = true;
            DropDownList6.Enabled = true;
            DropDownList7.Enabled = true;
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {

        }

        
    }
}