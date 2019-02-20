using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class AddHoliday : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            HOLIDAYS holiday = new HOLIDAYS();
            holiday.HolidayName= NameTextBox.Text.Trim();
            Response.Write(DateTextBox.Text);
            Response.Write(NameTextBox.Text);
            //Response.Redirect("~/HolidayList.aspx");
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            NameTextBox.Text = null;
            DateTextBox.Text = null;
            DropDownList1.SelectedIndex = 0;
            CheckBox1.Checked = true;
        }
    }
}