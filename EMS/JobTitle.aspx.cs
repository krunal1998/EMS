using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class JobTitle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckBoxList ckl = new CheckBoxList();
            String[] item = { "Software Designer", "Software devloper" };
            for (int i = 0; i < 2; i++)
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