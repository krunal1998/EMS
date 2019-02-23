using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;

namespace EMS
{
    public partial class WorkWeek : System.Web.UI.Page
    {
        public static WEEKDAY[] weekdays;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                load_data();
                SetSelectIndex();
            }

        }

        public void load_data()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("WeekDay");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<WEEKDAY[]>();
                    readTask.Wait();

                    weekdays = readTask.Result;
                }
            }
        }

        public void SetSelectIndex()
        {
           /* for (int i = 0; i < DropDownList1.Items.Count; i++)
            {
                if (Convert.ToString(weekdays[0].WeekDayDuration).Equals(DropDownList1.Items[i].Value))
                {
                    DropDownList1.SelectedIndex = i;
                }
            }*/
            DropDownList1.Items.FindByValue(Convert.ToString( weekdays[0].WeekDayDuration)).Selected = true;
            DropDownList2.Items.FindByValue(Convert.ToString(weekdays[1].WeekDayDuration)).Selected = true;
            DropDownList3.Items.FindByValue(Convert.ToString(weekdays[2].WeekDayDuration)).Selected = true;
            DropDownList4.Items.FindByValue(Convert.ToString(weekdays[3].WeekDayDuration)).Selected = true;
            DropDownList5.Items.FindByValue(Convert.ToString(weekdays[4].WeekDayDuration)).Selected = true;
            DropDownList6.Items.FindByValue(Convert.ToString(weekdays[5].WeekDayDuration)).Selected = true;
            DropDownList7.Items.FindByValue(Convert.ToString(weekdays[6].WeekDayDuration)).Selected = true;
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

        
        protected void UpdateButton_Click1(object sender, EventArgs e)
        {
            if(DropDownList1.Enabled)
            {
                WEEKDAY weekday = new WEEKDAY();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Global.URIstring);

                    weekday.WeekDayId = 1;
                    weekday.WeekDayName = "Monday";
                    weekday.WeekDayDuration = Convert.ToInt32(DropDownList1.SelectedValue);
                    //HTTP PUT
                    string str = "WeekDay/1";
                    var updateTask = client.PutAsJsonAsync(str, weekday);
                    updateTask.Wait();

                    weekday.WeekDayId = 2;
                    weekday.WeekDayName = "Tuesday";
                    weekday.WeekDayDuration = Convert.ToInt32(DropDownList2.SelectedValue);
                    //HTTP PUT
                    str = "WeekDay/2";
                    updateTask = client.PutAsJsonAsync(str, weekday);
                    updateTask.Wait();

                    weekday.WeekDayId = 3;
                    weekday.WeekDayName = "Wednesday";
                    weekday.WeekDayDuration = Convert.ToInt32(DropDownList3.SelectedValue);
                    //HTTP PUT
                    str = "WeekDay/3";
                    updateTask = client.PutAsJsonAsync(str, weekday);
                    updateTask.Wait();

                    weekday.WeekDayId = 4;
                    weekday.WeekDayName = "Thursday";
                    weekday.WeekDayDuration = Convert.ToInt32(DropDownList4.SelectedValue);
                    //HTTP PUT
                    str = "WeekDay/4";
                    updateTask = client.PutAsJsonAsync(str, weekday);
                    updateTask.Wait();

                    weekday.WeekDayId = 5;
                    weekday.WeekDayName = "Friday";
                    weekday.WeekDayDuration = Convert.ToInt32(DropDownList5.SelectedValue);
                    //HTTP PUT
                    str = "WeekDay/5";
                    updateTask = client.PutAsJsonAsync(str, weekday);
                    updateTask.Wait();

                    weekday.WeekDayId = 6;
                    weekday.WeekDayName = "Saturday";
                    weekday.WeekDayDuration = Convert.ToInt32(DropDownList6.SelectedValue);
                    //HTTP PUT
                    str = "WeekDay/6";
                    updateTask = client.PutAsJsonAsync(str, weekday);
                    updateTask.Wait();

                    weekday.WeekDayId = 7;
                    weekday.WeekDayName = "Sunday";
                    weekday.WeekDayDuration = Convert.ToInt32(DropDownList7.SelectedValue);
                    //HTTP PUT
                    str = "WeekDay/7";
                    updateTask = client.PutAsJsonAsync(str, weekday);
                    updateTask.Wait();


                    DropDownList1.Enabled = false;
                    DropDownList2.Enabled = false;
                    DropDownList3.Enabled = false;
                    DropDownList4.Enabled = false;
                    DropDownList5.Enabled = false;
                    DropDownList6.Enabled = false;
                    DropDownList7.Enabled = false;

                }

            }
        }
    }
}