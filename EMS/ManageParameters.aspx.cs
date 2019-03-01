using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class ManageParameters : System.Web.UI.Page
    {
        public static JOBTITLE jt;
        public static List<PERFORMANCEPARAMETER> pplist;
        public static List<REVIEW> rlist;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int jobtitleId = 2;
                //int jobtitleId = Session["JTID"];
                jt = getjobtitle(jobtitleId);
                getParameters(jt.JobTitleId);
                
                filterdata();
                deleteerrorlabel.Visible = false;
              
             }
             addparametertable.Visible = false; 
                 
        }

        private void filterdata()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Parameter", Type.GetType("System.String"));
            dt.Columns.Add("MinRating", Type.GetType("System.String"));
            dt.Columns.Add("MaxRating", Type.GetType("System.Int32"));
            dt.Columns.Add("ParameterId", Type.GetType("System.Int32"));
            foreach (PERFORMANCEPARAMETER p  in pplist)
            {
                DataRow row = dt.NewRow();
                row["ParameterId"] = p.ParameterId;
                row["Parameter"] = p.ParameterName;
                
                row["MinRating"] = p.MinRating;
                row["MaxRating"] = p.MaxRating;

                dt.Rows.Add(row);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private void getParameters(int jobtitleId)
        {
            pplist = new List<PERFORMANCEPARAMETER>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Parameters/");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<PERFORMANCEPARAMETER[]>();
                    readTask.Wait();

                    var parameters = readTask.Result;

                    foreach (var p in parameters)
                    {

                        if (jobtitleId == p.JobTitleId)
                        {
                            pplist.Add(p);
                        }
                    }

                }
          }

        }

        private JOBTITLE getjobtitle(int jobtitleId)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);
            var responsetask = client.GetAsync("jobtitle/"+jobtitleId);
            responsetask.Wait();

            var result = responsetask.Result;
            if (result.IsSuccessStatusCode) {
                var readtask = result.Content.ReadAsAsync<JOBTITLE>();
                readtask.Wait();

                return readtask.Result;
            }
            return null;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Add_Click(object sender, EventArgs e)
        {

        }

        protected void Search_Click(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            filterdata();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            TextBox parameter = row.Cells[2].Controls[0] as TextBox;
            TextBox minRating = row.Cells[3].Controls[0] as TextBox;
            TextBox maxRating = row.Cells[4].Controls[0] as TextBox;
            //int parameterid = Convert.ToInt32( row.Cells[1].Text);
            
            PERFORMANCEPARAMETER p = new PERFORMANCEPARAMETER();
            p.JobTitleId = jt.JobTitleId;
            p.MaxRating = Convert.ToInt32(maxRating.Text);
            p.MinRating = Convert.ToInt32(minRating.Text);
            p.ParameterName = parameter.Text;
            p.ParameterId =(int) GridView1.DataKeys[e.RowIndex].Value;
            Response.Write(p.ParameterId);
            GridView1.EditIndex = -1;

            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP PUT
                var updateTask = client.PutAsJsonAsync("parameters/" + p.ParameterId, p);
                updateTask.Wait();

               var result = updateTask.Result;
            }

            getParameters(jt.JobTitleId);
            filterdata();
            // gvbind(); */

        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            filterdata();
            //gvbind();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            List<PERFORMANCEPARAMETER> errorplist = new List<PERFORMANCEPARAMETER>();
            getReviews();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox c = GridView1.Rows[i].Cells[0].FindControl("Selector") as CheckBox;
                if (c.Checked)
                {
                    int parameterid = (int)GridView1.DataKeys[i].Value;
                    PERFORMANCEPARAMETER p = pplist.FirstOrDefault(pp => pp.ParameterId == parameterid);
                    if (isparameterused(p))
                    {
                        deleteparameter(p.ParameterId);
                    }
                    else
                    {
                        errorplist.Add(p);
                    }
                }
            }    
            if (errorplist.Count > 0)
            {
                deleteerrorlabel.Text = "Following parameters could not be deleted as they are being used in some other reviews: <br/>";
                int i = 1;
                foreach (PERFORMANCEPARAMETER pp in errorplist)
                {
                    deleteerrorlabel.Text += i+". " + pp.ParameterName+"<br/>";
                }
                deleteerrorlabel.Visible = true;
            }
        }

        private void deleteparameter(int parameterId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);

            var deletetask = client.DeleteAsync("Parameters/" + parameterId);
            deletetask.Wait();

            var result = deletetask.Result;   
        }

        private bool isparameterused(PERFORMANCEPARAMETER p)
        {
            if (rlist == null)
                return true;
            REVIEW rev = rlist.Find(r => r.PerameterId == p.ParameterId);
            if (rev == null)
                return true;
            else
                return false;
            
        }

        private void getReviews()
        {
            rlist = new List<REVIEW>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);
            var responseTask = client.GetAsync("Reviews/");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<REVIEW[]>();
                readTask.Wait();

                var reviews = readTask.Result;

                foreach (var r in reviews)
                {
                    rlist.Add(r);
                }
            }
        }

        //display new row
        protected void AddNewParameterButton_Click(object sender, EventArgs e)
        {
            addparametertable.Visible = true;
        }

        //update new row in table
        protected void addbutton_Click(object sender, EventArgs e)
        {
            PERFORMANCEPARAMETER p = new PERFORMANCEPARAMETER();
            p.JobTitleId = jt.JobTitleId;
            p.MaxRating = Convert.ToInt32(newmaxratingtextbox.Text);
            p.MinRating = Convert.ToInt32(newminratingtextbox.Text);
            p.ParameterName = newparametertextbox.Text;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP PUT
                var updateTask = client.PostAsJsonAsync("parameters/", p);
                updateTask.Wait();

                var result = updateTask.Result;
            }
            getParameters(jt.JobTitleId);
            filterdata();
        }

    }
}