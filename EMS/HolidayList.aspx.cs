using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Http;

namespace EMS
{
    public partial class HolidayList : System.Web.UI.Page
    {
        public static HOLIDAYS[] holidays;
        public static DateTime olddate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loaddata();
                filterdata();
            }
        }

        //load data in holidays
        protected void loaddata()
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

        //filter data based on filter and display in gridview
        public void filterdata()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("HolidayName");
            dt.Columns.Add("HolidayDate");
            dt.Columns.Add("WorkingHours");
            dt.Columns.Add("RepeatedAnnually");
            //if From date or To date is selected 
            if((!FromDateTextBox.Text.Equals("")) || (!ToDateTextBox.Text.Equals("")))
            {
                //only from date is selected
                if((!FromDateTextBox.Text.Equals("")) && ToDateTextBox.Text.Equals(""))
                {
                    DateTime fromdate = Convert.ToDateTime(FromDateTextBox.Text);
                    foreach (var holiday in holidays)
                    {   
                        //check, from date is less than or equal to holiday date or not 
                        if(holiday.HolidayDate > fromdate.Date || fromdate.Date == holiday.HolidayDate)
                        {
                            DataRow row = dt.NewRow();
                            row["HolidayName"] = holiday.HolidayName;
                            row["HolidayDate"] = holiday.HolidayDate.ToString("dd-MM-yyyy");

                            if (holiday.WorkDuration == 0)
                                row["WorkingHours"] = "Non-working day";
                            else
                                row["WorkingHours"] = "Half day";

                            if (holiday.RepeatedAnnually == 1)
                                row["RepeatedAnnually"] = "Yes";
                            else
                                row["RepeatedAnnually"] = "No";

                            dt.Rows.Add(row);
                        }
                    }
                }
                //only To date is selected
                else if(FromDateTextBox.Text.Equals("") && (!ToDateTextBox.Text.Equals("")))
                {
                    DateTime todate = Convert.ToDateTime(ToDateTextBox.Text);
                    foreach (var holiday in holidays)
                    {
                        //check, To date is greater than or equal to holiday date or not 
                        if (holiday.HolidayDate < todate || todate.Date == holiday.HolidayDate)
                        {
                            DataRow row = dt.NewRow();
                            row["HolidayName"] = holiday.HolidayName;
                            row["HolidayDate"] = holiday.HolidayDate.ToString("dd-MM-yyyy");

                            if (holiday.WorkDuration == 0)
                                row["WorkingHours"] = "Non-working day";
                            else
                                row["WorkingHours"] = "Half day";

                            if (holiday.RepeatedAnnually == 1)
                                row["RepeatedAnnually"] = "Yes";
                            else
                                row["RepeatedAnnually"] = "No";

                            dt.Rows.Add(row);
                        }
                    }
                }
                //both From and To date selected
                else
                {
                    DateTime fromdate = Convert.ToDateTime(FromDateTextBox.Text);
                    DateTime todate = Convert.ToDateTime(ToDateTextBox.Text);
                    foreach (var holiday in holidays)
                    {
                        //check, To date is greater than or equal to holiday date or not 
                        if ((holiday.HolidayDate < todate && holiday.HolidayDate > fromdate.Date) || todate.Date == holiday.HolidayDate || fromdate.Date == holiday.HolidayDate)
                        {
                            DataRow row = dt.NewRow();
                            row["HolidayName"] = holiday.HolidayName;
                            row["HolidayDate"] = holiday.HolidayDate.ToString("dd-MM-yyyy");

                            if (holiday.WorkDuration == 0)
                                row["WorkingHours"] = "Non-working day";
                            else
                                row["WorkingHours"] = "Half day";

                            if (holiday.RepeatedAnnually == 1)
                                row["RepeatedAnnually"] = "Yes";
                            else
                                row["RepeatedAnnually"] = "No";

                            dt.Rows.Add(row);
                        }
                    }

                }
            }
            //if no date is selected
            else
            {
                if (holidays == null)
                    Response.Write("error");
                else
                {
                    foreach (var holiday in holidays)
                    {
                        DataRow row = dt.NewRow();
                        row["HolidayName"] = holiday.HolidayName;
                        row["HolidayDate"] = holiday.HolidayDate.ToString("dd-MM-yyyy");

                        if (holiday.WorkDuration == 0)
                            row["WorkingHours"] = "Non-working day";
                        else
                            row["WorkingHours"] = "Half day";

                        if (holiday.RepeatedAnnually == 1)
                            row["RepeatedAnnually"] = "Yes";
                        else
                            row["RepeatedAnnually"] = "No";

                        dt.Rows.Add(row);
                    }
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            filterdata();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            HOLIDAYS holiday = new EMS.HOLIDAYS();
            TextBox nametextbox = row.Cells[1].Controls[0] as TextBox;
            TextBox datetextbox = row.FindControl("TextBox1") as TextBox;
            DropDownList worklist = row.FindControl("DropDownList1") as DropDownList;
            DropDownList repeatlist = row.FindControl("DropDownList2") as DropDownList;
            GridView1.EditIndex = -1;

            holiday.HolidayName = nametextbox.Text;
            holiday.HolidayDate = Convert.ToDateTime(datetextbox.Text);
            holiday.WorkDuration = Convert.ToInt32( worklist.SelectedValue);
            holiday.RepeatedAnnually = Convert.ToInt32(repeatlist.SelectedValue);
            foreach(var temp in holidays)
            {
                if(temp.HolidayDate == olddate)
                {
                    holiday.HolidayId = temp.HolidayId;
                    break;
                }
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP PUT
                var updateTask = client.PutAsJsonAsync("Holiday/" + holiday.HolidayId.ToString() , holiday);
                updateTask.Wait();

                var result = updateTask.Result;
            }

            loaddata();
            filterdata();

        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;

            filterdata();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddHoliday.aspx");
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            filterdata();
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            ToDateTextBox.Text = null;
            FromDateTextBox.Text = null;
            filterdata();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                int id = 0;
                CheckBox checkbox = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("HolidaySelector");
                if (checkbox != null)
                {
                    if (checkbox.Checked)
                    {
                        Label l = (Label) GridView1.Rows[i].FindControl("label3");
                        DateTime date = Convert.ToDateTime(l.Text);
                        foreach(var holiday in holidays)
                        {
                            if (holiday.HolidayDate == date)
                            {
                                id = holiday.HolidayId;
                                deleterecord(id);
                                break;
                            }
                        }
                    }
                }
            }

            loaddata();
            filterdata();
        }

        public void deleterecord(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Holiday/"+id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {   
                //set value of dropdown list in edit mode for work hours
                DropDownList droplist = e.Row.FindControl("DropDownList1") as DropDownList;
                string selected = DataBinder.Eval(e.Row.DataItem, "WorkingHours").ToString();
                droplist.Items.FindByText(selected).Selected = true;

                //set value of dropdown list in edit mode for repeatation
                DropDownList droplist1 = e.Row.FindControl("DropDownList2") as DropDownList;
                string str = DataBinder.Eval(e.Row.DataItem, "RepeatedAnnually").ToString();
                droplist1.Items.FindByText(str).Selected = true;

                //set value for date textbox in edit mode
                TextBox t = e.Row.FindControl("TextBox1") as TextBox;
                DateTime s = Convert.ToDateTime( DataBinder.Eval(e.Row.DataItem, "HolidayDate"));
                t.Text = s.ToString("yyyy-MM-dd");
                //set olddate for use at time of record update
                olddate = s;
            }
        }
    }
}