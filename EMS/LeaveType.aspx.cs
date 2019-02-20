using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class LeaveType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckBoxList ckl = new CheckBoxList();
            String[] item = { "FMLA", "Sick Leave", "Maternity leave" };
            for(int i=0;i<3;i++)
            {
                ListItem li = new ListItem();
                li.Text = item[i];
                li.Value = item[i];
                ckl.Items.Add(li);
            }
            PlaceHolder1.Controls.Add(ckl);

        }
    }
}