using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;

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
            holiday.HolidayDate = Convert.ToDateTime(DateTextBox.Text);
            if (DropDownList1.SelectedItem.Text.Equals("Half day"))
            {
                holiday.WorkDuration = 4;
            }
            else
                holiday.WorkDuration = 0;
            if (CheckBox1.Checked)
            {
                holiday.RepeatedAnnually = 1;
            }
            else
                holiday.RepeatedAnnually = 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                var postTask = client.PostAsJsonAsync("Holiday", holiday);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Response.Redirect("~/HolidayList.aspx");
                }
            }
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