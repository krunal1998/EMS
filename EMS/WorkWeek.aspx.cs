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
            for (int i = 0; i < DropDownList1.Items.Count; i++)
            {
                if (Convert.ToString(weekdays[0].WeekDayDuration).Equals(DropDownList1.Items[i].Value))
                {
                    DropDownList1.SelectedIndex = i;
                }
            }
            for (int i = 0; i < DropDownList2.Items.Count; i++)
            {
                if (Convert.ToString(weekdays[1].WeekDayDuration).Equals(DropDownList2.Items[i].Value))
                {
                    DropDownList2.SelectedIndex = i;
                }
            }
            for (int i = 0; i < DropDownList3.Items.Count; i++)
            {
                if (Convert.ToString(weekdays[2].WeekDayDuration).Equals(DropDownList3.Items[i].Value))
                {
                    DropDownList3.SelectedIndex = i;
                }
            }
            for (int i = 0; i < DropDownList4.Items.Count; i++)
            {
                if (Convert.ToString(weekdays[3].WeekDayDuration).Equals(DropDownList4.Items[i].Value))
                {
                    DropDownList4.SelectedIndex = i;
                }
            }
            for (int i = 0; i < DropDownList5.Items.Count; i++)
            {
                if (Convert.ToString(weekdays[4].WeekDayDuration).Equals(DropDownList5.Items[i].Value))
                {
                    DropDownList5.SelectedIndex = i;
                }
            }
            for (int i = 0; i < DropDownList6.Items.Count; i++)
            {
                if (Convert.ToString(weekdays[5].WeekDayDuration).Equals(DropDownList6.Items[i].Value))
                {
                    DropDownList6.SelectedIndex = i;
                }
            }
            for (int i = 0; i < DropDownList7.Items.Count; i++)
            {
                if (Convert.ToString(weekdays[6].WeekDayDuration).Equals(DropDownList7.Items[i].Value))
                {
                    DropDownList7.SelectedIndex = i;
                }
            }
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