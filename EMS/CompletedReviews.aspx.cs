using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class CompletedReviews : System.Web.UI.Page
    {
        public static List<GENERATEREVIEW> grlist;
        public static List<PERSONALDETAILS> pdlist;
        public static List<EMPLOYEE> elist;
        public static int supervisorid;
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (!IsPostBack)
            {
                supervisorid = 1;//change to get from session
                getemployees();
                filterdata();
            }

        }

        private void getemployees()
        {
            elist = new List<EMPLOYEE>();
            pdlist = new List<PERSONALDETAILS>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Employees/");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<EMPLOYEE[]>();
                    readTask.Wait();

                    var employees = readTask.Result;
                    foreach(EMPLOYEE e in employees)
                    {
                        if (e.SupervisorId == supervisorid) {
                            elist.Add(e);
                            PERSONALDETAILS pd = getpersonaldetails(e.PersonalDetailId.Value);
                            pdlist.Add(pd);
                        }
                    }

                }
            }


        }

        private PERSONALDETAILS getpersonaldetails(int personaldetailId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("personaldetails/" + personaldetailId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<PERSONALDETAILS>();
                    readTask.Wait();

                    var p = readTask.Result;
                    return p;

                }
                else return null;
            }

        }

        //load data in table with filters
        private void filterdata()
        {
            getgeneratedreviews();
            List<GENERATEREVIEW> filterlist = grlist;
            //date filter not selected
            if (fromdatetb.Text != "" )
            {
                foreach (GENERATEREVIEW g in filterlist.ToList()) {
                    DateTime date = Convert.ToDateTime(fromdatetb.Text);
                    if (g.DueDate <= date)
                        filterlist.Remove(g);
                }                      
            }
            if (todatetb.Text != "")
            {
                foreach (GENERATEREVIEW g in filterlist.ToList())
                {
                    DateTime date = Convert.ToDateTime(todatetb.Text);
                    if (g.DueDate >= date)
                        filterlist.Remove(g);
                }
            }
            if (statusddl.SelectedValue!="0")
            {
                foreach (GENERATEREVIEW g in filterlist.ToList())
                {
                    if (!g.Status.Equals(statusddl.SelectedValue))
                        filterlist.Remove(g);
                }
            }
            if (EnameTextBox.Text != "")
            {
                PERSONALDETAILS pd = pdlist.Find(p => (p.FirstName + " " + p.LastName).Equals(EnameTextBox.Text));
                EMPLOYEE e = elist.Find(emp => emp.PersonalDetailId == pd.PersonalDetailId);

                if (pd != null)
                {
                    foreach (GENERATEREVIEW g in filterlist.ToList())
                    {
                        if (!g.EmployeeId.Equals(e.EmployeeId))
                            filterlist.Remove(g);
                    }
                }
                else {
                    filterlist.RemoveAll(g => true);
                }
            }
            loadtable(filterlist);

        }

        private void loadtable(List<GENERATEREVIEW> filterlist)
        {
            if (filterlist.Count == 0)
            {
                Table1.Visible = false;
                noreviewslabel.Visible = true;

            }
            else
            {
                noreviewslabel.Visible = false;
                Table1.Visible = true;
            }

            for (int i = 1; i < Table1.Rows.Count; i++)
            {
                Table1.Rows.RemoveAt(i);
            }

            foreach (GENERATEREVIEW g in filterlist)
            {
                EMPLOYEE e = elist.Find(emp => emp.EmployeeId == g.EmployeeId);
                PERSONALDETAILS pd = pdlist.Find(p => p.PersonalDetailId == e.PersonalDetailId);
                TableRow row = new TableRow();
                row.ID = g.GenerateReviewId.ToString();
                TableCell employee = new TableCell();
                employee.HorizontalAlign = HorizontalAlign.Center;
                Label employeelabel = new Label();
                employeelabel.Text = pd.FirstName + " " + pd.LastName;
                employee.Controls.Add(employeelabel);
                row.Cells.Add(employee);


                TableCell duration = new TableCell();
                duration.HorizontalAlign = HorizontalAlign.Center;
                Label dlabel = new Label();
                dlabel.Text = g.StartDate.ToShortDateString() + " to "+g.EndDate.ToShortDateString();
                duration.Controls.Add(dlabel);
                row.Cells.Add(duration);

                TableCell dd = new TableCell();
                Label ddlabel = new Label();
                dd.HorizontalAlign = HorizontalAlign.Center;
                ddlabel.Text = g.DueDate.ToShortDateString();
                dd.Controls.Add(ddlabel);
                row.Cells.Add(dd);

                TableCell status = new TableCell();
                status.HorizontalAlign = HorizontalAlign.Center;
                Label statuslabel = new Label();
                statuslabel.Text = g.Status;
                status.Controls.Add(statuslabel);
                row.Cells.Add(status);



                TableCell review = new TableCell();
                review.HorizontalAlign = HorizontalAlign.Center;
                Table reviewtable = new Table();
                reviewtable.GridLines = GridLines.Both;
                TableHeaderRow hr = new TableHeaderRow();

                TableHeaderCell h1 = new TableHeaderCell();
                Label h1label = new Label();
                h1label.Text = "Parameter";
                h1.Controls.Add(h1label);
                hr.Cells.Add(h1);

                TableHeaderCell h2 = new TableHeaderCell();
                Label h2label = new Label();
                h2label.Text = "Rating";
                h2.Controls.Add(h2label);
                hr.Cells.Add(h2);

                TableHeaderCell h3 = new TableHeaderCell();
                Label h3label = new Label();
                h3label.Text = "Comment";
                h3.Controls.Add(h3label);
                hr.Cells.Add(h3);
                reviewtable.Rows.Add(hr);
                List<REVIEW> rlist = getreviews(g.GenerateReviewId);
                foreach(REVIEW r in rlist)
                {
                    TableRow tr = new TableRow();


                    TableCell parameter = new TableCell();
                    parameter.HorizontalAlign = HorizontalAlign.Center;
                    parameter.Width = 200;
                    PERFORMANCEPARAMETER p = getparameter(r.PerameterId);
                    String pname = p.ParameterName;
                    Label parametername = new Label();
                    parametername.Text = pname;
                    parameter.Controls.Add(parametername);
                    tr.Cells.Add(parameter);

                    TableCell rating = new TableCell();
                    rating.HorizontalAlign = HorizontalAlign.Center;
                    rating.Width = 200;
                    double rate = ((double)r.Rating/((double)p.MaxRating-(double)p.MinRating+1)) * 100.0;
                    Label ratinglabel = new Label();
                    ratinglabel.Text = rate+"% ";
                    rating.Controls.Add(ratinglabel);
                    tr.Cells.Add(rating);

                    TableCell comment = new TableCell();
                    comment.HorizontalAlign = HorizontalAlign.Center;
                    comment.Width = 200;
                    Label commentlabel = new Label();
                    commentlabel.Text = r.Comment;
                    comment.Controls.Add(commentlabel);
                    tr.Cells.Add(comment);

                    reviewtable.Rows.Add(tr);
                }
                review.Controls.Add(reviewtable);
                row.Cells.Add(review);

                TableCell c1 = new TableCell();
                c1.HorizontalAlign = HorizontalAlign.Center;
                if (g.DueDate >= DateTime.Today) { 
                    Button edit = new Button();
                    edit.Text = "Edit";
                    edit.Command += new CommandEventHandler(editbutton_Click);
                    edit.CommandArgument = g.GenerateReviewId.ToString();
                    c1.Controls.Add(edit);
                }
                row.Cells.Add(c1);
                Table1.Rows.Add(row);

            }
        }

        protected void editbutton_Click(object sender, CommandEventArgs e)
        {
            Session["GRID"] = e.CommandArgument;
            Response.Redirect("EditReview.aspx");

        }
        private PERFORMANCEPARAMETER getparameter(int parameterId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("parameters/"+parameterId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<PERFORMANCEPARAMETER>();
                    readTask.Wait();

                    var p = readTask.Result;
                    return p;

                }
                else return null;
            }
        }

        private List<REVIEW> getreviews(int generateReviewId)
        {
            List<REVIEW> rlist = new List<REVIEW>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("reviews/");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<REVIEW[]>();
                    readTask.Wait();

                    var reviews = readTask.Result;
                    
                    foreach(REVIEW r in reviews)
                    {
                        if (r.GenerateReviewId == generateReviewId)
                            rlist.Add(r);
                    }

                }
                return rlist;
            }
        }

        private void getgeneratedreviews()
        {
            grlist = new List<GENERATEREVIEW>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("GeneratedReviews");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<GENERATEREVIEW[]>();
                    readTask.Wait();

                    var GRs = readTask.Result;

                    foreach (var g in GRs)
                    {
                        int gsid = elist.Find(e => e.SupervisorId == supervisorid).SupervisorId.Value;
                        if (supervisorid == gsid && (g.Status.Equals("Assessed") || g.Status.Equals("Completed")))
                        {
                            grlist.Add(g);
                        }
                    }
                }
            }
        }

        protected void searchbutton_Click(object sender, EventArgs e)
        {
            filterdata();
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetEmployeesList(string prefixText)
        {
            List<string> namelist = new List<string>();
            foreach (PERSONALDETAILS p in pdlist)
            {
                namelist.Add(p.FirstName + " " + p.LastName);
            }

            List<string> temp = new List<string>();
            foreach (string v in namelist)
            {
                if (v.ToLower().Contains(prefixText.ToLower()))
                    temp.Add(v);
            }
            return temp;
        }

    }
}