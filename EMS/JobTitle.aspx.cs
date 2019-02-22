using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;

namespace EMS
{
    public partial class JobTitle : System.Web.UI.Page
    {
        static JOBTITLE[] jobtitles;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                displayrecord();
        }

        public void displayrecord()
        {
            using (var client = new HttpClient())
            {
                CheckBoxList1.Items.Clear();
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("JobTitle");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<JOBTITLE[]>();
                    readTask.Wait();

                    jobtitles = readTask.Result;

                    foreach (var jobtitle in jobtitles)
                    {
                        ListItem li = new ListItem();
                        li.Text = jobtitle.JobTitleName;
                        li.Value = jobtitle.JobTitleName; 
                        CheckBoxList1.Items.Add(li);
                    }
                }
            }
        }

        //Add new jobtitle
        protected void AddButton_Click(object sender, EventArgs e)
        {
            JOBTITLE jobtitle = new EMS.JOBTITLE();
            jobtitle.JobTitleName = JobTitleTextBox.Text.Trim();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                var postTask = client.PostAsJsonAsync("JobTitle", jobtitle);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    displayrecord();
                    JobTitleTextBox.Text = null;
                }
            }
        }

        //delete job title record
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach (ListItem lst in CheckBoxList1.Items)
            {
                if (lst.Selected)
                {
                    foreach (var title in jobtitles)
                    {
                        if (title.JobTitleName.Equals(lst.Value))
                        {
                            using (var client = new HttpClient())
                            {
                                client.BaseAddress = new Uri(Global.URIstring);

                                //HTTP DELETE
                                var deleteTask = client.DeleteAsync("JobTitle/" + title.JobTitleId.ToString());
                                deleteTask.Wait();

                                var result = deleteTask.Result;
                            }
                        }
                    }
                }
            }
            displayrecord();
        }



    }
}