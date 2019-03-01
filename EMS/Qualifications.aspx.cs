using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class Qualifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EMPLOYEE emp;
            String eid = Session["EID"].ToString();
            emp = getselectedemployee(eid);
            List<EDUCATION> elist = getAllEducation(emp.EmployeeId);
            List<WORKEXPERIENCE> welist = getAllWorkExeperience(emp.EmployeeId);

            foreach(EDUCATION edu in elist)
            {
                TableRow row = new TableRow();
                row.ID = edu.EducationId.ToString();


                TableCell degree = new TableCell();
                Label degreelabel = new Label();
                degreelabel.Text = edu.Degree;
                degree.Controls.Add(degreelabel);
                row.Cells.Add(degree);

                TableCell institution = new TableCell();
                Label institutionlabel = new Label();
                institutionlabel.Text = edu.Institution;
                institution.Controls.Add(institutionlabel);
                row.Cells.Add(institution);

                TableCell sd = new TableCell();
                Label sdlabel = new Label();
                sdlabel.Text = edu.StartYear.Value.Year.ToString();
                sd.Controls.Add(sdlabel);
                row.Cells.Add(sd);

                TableCell ed = new TableCell();
                Label edlabel = new Label();
                edlabel.Text = edu.EndYear.Value.Year.ToString();
                ed.Controls.Add(edlabel);
                row.Cells.Add(ed);
                Table1.Rows.Add(row);
            }

            foreach (WORKEXPERIENCE we in welist)
            {
                TableRow row = new TableRow();
                row.ID = we.WorkExperienceId.ToString();


                TableCell cn = new TableCell();
                Label cnlabel = new Label();
                cnlabel.Text = we.CompanyName;
                cn.Controls.Add(cnlabel);
                row.Cells.Add(cn);

                TableCell jt = new TableCell();
                Label jtlabel = new Label();
                jtlabel.Text = we.JobTitle;
                jt.Controls.Add(jtlabel);
                row.Cells.Add(jt);

                TableCell sd = new TableCell();
                Label sdlabel = new Label();
                sdlabel.Text = we.StartDate.Value.ToShortDateString();
                sd.Controls.Add(sdlabel);
                row.Cells.Add(sd);

                TableCell ed = new TableCell();
                Label edlabel = new Label();
                edlabel.Text = we.Enddate.Value.ToShortDateString();
                ed.Controls.Add(edlabel);
                row.Cells.Add(ed);

                Table2.Rows.Add(row);
            }

        }
        private List<WORKEXPERIENCE> getAllWorkExeperience(string EmployeeId)
        {
            List<WORKEXPERIENCE> list = new List<WORKEXPERIENCE>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("WorkExperience");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<WORKEXPERIENCE[]>();
                    readTask.Wait();

                    var workexp = readTask.Result;

                    foreach (var we in workexp)
                    {
                        if (we.EmployeeId==EmployeeId)
                        {
                            list.Add(we);
                        }
                    }
                }
            }
            return list;
        }

        private EMPLOYEE getselectedemployee(string eid)
        {
            EMPLOYEE e;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Employees/" + eid);
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

        private List<EDUCATION> getAllEducation(String EmployeeId)
        {
            List<EDUCATION> list = new List<EDUCATION>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Education");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<EDUCATION[]>();
                    readTask.Wait();

                    var education = readTask.Result;

                    foreach (var e in education)
                    {
                        if (e.EmployeeId == EmployeeId)
                        {
                            list.Add(e);
                        }
                    }
                }
            }
            return list;
        }
    }
}

            /*foreach (COMPLAINS c in clist)
            {
                String ctype = ctlist.FirstOrDefault(ct => ct.ComplaintypeId == c.ComplainTypeId).ComplainType;
                TableRow row = new TableRow();
                row.ID = c.ComplainId.ToString();


                TableCell complaintype = new TableCell();
                Label ctlabel = new Label();
                ctlabel.Text = ctype;
                complaintype.Controls.Add(ctlabel);
                row.Cells.Add(complaintype);


                String ename = getEmployeeName(c.EmployeeId);
                TableCell employee = new TableCell();
                Label employeelabel = new Label();
                employeelabel.Text = ename;
                employee.Controls.Add(employeelabel);
                row.Cells.Add(employee);

                TableCell cdescription = new TableCell();
                Label cdescriptionlabel = new Label();
                cdescriptionlabel.Text = c.ComplainDescription;
                cdescription.Controls.Add(cdescriptionlabel);
                row.Cells.Add(cdescription);


                TableCell cstatus = new TableCell();
                Label cstatuslabel = new Label();
                cstatuslabel.Text = c.ComplainStatus;
                cstatus.Controls.Add(cstatuslabel);
                row.Cells.Add(cstatus);


                TableCell cfeedback = new TableCell();
                Label cfeedbacklabel = new Label();
                cfeedbacklabel.Text = c.feedbackDescription;
                cfeedback.Controls.Add(cfeedbacklabel);
                row.Cells.Add(cfeedback);



                TableCell c1 = new TableCell();
                Button view = new Button();
                view.Text = "view";
                view.Command += new CommandEventHandler(viewbutton_click);
                view.CommandArgument = c.ComplainId.ToString();
                c1.Controls.Add(view);
                row.Cells.Add(c1);
                Table2.Rows.Add(row);

            }
        }
    }
}*/