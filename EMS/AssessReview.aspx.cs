using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EMS
{
    public partial class AssessReview : System.Web.UI.Page
    {
        static List<PERFORMANCEPARAMETER> parameterList;
        static GENERATEREVIEW g;
        protected void Page_Load(object sender, EventArgs e)
        {
            int grid = Convert.ToInt32(Session["GRID"]);
            g=  getgeneratedreview(grid);
            EMPLOYEE emp = getEmployee(g.EmployeeId);


            String ename = getEmployeeName(emp);
            FromLabel.Text = g.StartDate.ToString();
            ToLabel.Text = g.EndDate.ToString();
            NameLabel.Text = ename;

            parameterList = getParameters(emp.JobtitleId.Value);

            foreach (PERFORMANCEPARAMETER p in parameterList) {
                TableRow row = new TableRow();
                TableCell pname = new TableCell();
                Label pnamelabel = new Label();
                pnamelabel.Text = p.ParameterName;
                pname.Controls.Add(pnamelabel);
                row.Cells.Add(pname);

                TableCell review = new TableCell();
                for (int i = p.MinRating; i <= p.MaxRating; i++) {
                    RadioButton r = new RadioButton();
                    r.GroupName = p.ParameterName;
                    r.Text = i.ToString();
                    
                    r.Width = 50;
                    r.ID = p.ParameterName + i;
                    
                    if (i == (p.MinRating + p.MaxRating) / 2)
                        r.Checked = true;
                    else
                        r.Checked = false;

                    review.Controls.Add(r);
                }
                row.Cells.Add(review);

                TableCell comment = new TableCell();
                TextBox commenttb = new TextBox();
                commenttb.ID = p.ParameterId + p.ParameterName;
                comment.Controls.Add(commenttb);
                row.Cells.Add(comment);

                ParametersTable.Rows.Add(row);
                pnamelabel.ID = ParametersTable.Rows.GetRowIndex(row).ToString();

            }

        }

        private List<PERFORMANCEPARAMETER> getParameters(int jobtitleId)
        {
            List<PERFORMANCEPARAMETER> plist = new List<PERFORMANCEPARAMETER>();

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

                     var parameters= readTask.Result;

                    foreach (var p in parameters)
                    {
                        
                        if (jobtitleId == p.JobTitleId)
                        {
                            plist.Add(p);
                        }
                    }

                }
                return plist;
            }

        }

        private EMPLOYEE getEmployee(string employeeID)
        {
            EMPLOYEE e;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Employees/" + employeeID);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<EMPLOYEE>();
                    readTask.Wait();

                    e = readTask.Result;
                    return e;

                }
                else return null;
            }

        }

        private GENERATEREVIEW getgeneratedreview(int grid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("GeneratedReviews/" + grid);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<GENERATEREVIEW>();
                    readTask.Wait();

                    GENERATEREVIEW g = readTask.Result;
                    return g;
                }
                else return null;
            }
        }

        private string getEmployeeName(EMPLOYEE e)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("PersonalDetails/" + e.PersonalDetailId.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<PERSONALDETAILS>();
                    readTask.Wait();

                    PERSONALDETAILS pd = readTask.Result;
                    return pd.FirstName + " " + pd.LastName;
                }
                else return "";
            }

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            bool error = false;
            foreach (TableRow tr in ParametersTable.Rows)
            {
                if (tr.Cells.Count == 3 && tr != ParametersTable.Rows[0])
                {
                    Label paramname = (Label)tr.Cells[0].FindControl(ParametersTable.Rows.GetRowIndex(tr).ToString());
                    PERFORMANCEPARAMETER p = parameterList.FirstOrDefault(pr => pr.ParameterName == paramname.Text);
                    REVIEW r = new REVIEW();
                    r.GenerateReviewId = g.GenerateReviewId;
                    r.EmployeeId = g.EmployeeId;
                    r.PerameterId = p.ParameterId;
                    TextBox comment = (TextBox)tr.Cells[2].FindControl(p.ParameterId + p.ParameterName);
                    r.Comment = comment.Text;

                    for (int i = p.MinRating; i <= p.MaxRating; i++)
                    {
                        RadioButton rb = (RadioButton)tr.Cells[1].FindControl(p.ParameterName + i);
                        if (rb.Checked)
                        {
                            r.Rating = Convert.ToInt32(rb.Text);
                            break;
                        }
                    }
                    //update reviews in db
                    // Response.Write(r.GenerateReviewId + " " +r.PerameterId+" "+ r.Rating + " " + r.Comment + "\n" );
                    var client = new HttpClient();
                    client.BaseAddress = new Uri(Global.URIstring);

                    var postTask = client.PostAsJsonAsync<REVIEW>("reviews", r);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (!result.IsSuccessStatusCode)
                    {
                        // occurs if some error in writing to db
                        Response.Write("Some error occured");
                        //TODO take appt. action for the error
                        error = true;
                        break;

                    }

                }
            }
            if (!error)
            {
                //update generatedreview status
                g.Status = "Assessed";

                var client = new HttpClient();
                client.BaseAddress = new Uri(Global.URIstring);
                var putTask = client.PutAsJsonAsync<GENERATEREVIEW>("generatedreviews/" + g.GenerateReviewId, g);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Response.Write("Review assessed successfully.");
                    Response.Redirect("PendingReviews.aspx");
                }
            }
        }
    }
}