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
        public static HOLIDAYS[] holidays;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                loadholidays();
        }

        public void loadholidays()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Holiday");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<HOLIDAYS[]>();
                    readTask.Wait();

                    holidays = readTask.Result;
                }
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            DateTime date= Convert.ToDateTime(DateTextBox.Text);
            int flag = 0;
            foreach (var h in holidays)
            {
                if(h.HolidayDate==date)
                {
                    flag = 1;break;
                }

            }
            if(flag==1)
            {
                Response.Write("<script>alert('Already holiday exists with same date.')</script>");
            }
            else
            {
                HOLIDAYS holiday = new HOLIDAYS();
                holiday.HolidayName = NameTextBox.Text.Trim();
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