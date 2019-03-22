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
    public partial class GeneratePayslip : System.Web.UI.Page
    {
        static List<PERSONALDETAILS> pdlist;
        static List<PAYMENTRECORD> prlist;
        static List<EMPLOYEE> elist;

        protected void Page_Load(object sender, EventArgs e)
        {
            pdlist = getallpersonaldetails();
            elist = getallemployees();
          
        }

        private List<EMPLOYEE> getallemployees()
        {
            {
                List<EMPLOYEE> list = new List<EMPLOYEE>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Global.URIstring);
                    //HTTP GET
                    var responseTask = client.GetAsync("Employees");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        var readTask = result.Content.ReadAsAsync<EMPLOYEE[]>();
                        readTask.Wait();

                        var employees = readTask.Result;

                        foreach (var employee in employees)
                        {
                            list.Add(employee);
                        }
                    }
                }
                return list;
            }
        }

        private List<PAYMENTRECORD> getallpaymentrecord()
        {

            List<PAYMENTRECORD> list = new List<PAYMENTRECORD>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);
            //HTTP GET
            var responseTask = client.GetAsync("PaymentRecord/");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<PAYMENTRECORD[]>();
                readTask.Wait();

                var payment = readTask.Result;

                foreach (PAYMENTRECORD pr in payment)
                {
                    list.Add(pr);
                }
            }

            return list;
        }

        private List<PERSONALDETAILS> getallpersonaldetails()
        {
            List<PERSONALDETAILS> list = new List<PERSONALDETAILS>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(Global.URIstring);
            //HTTP GET
            var responseTask = client.GetAsync("PersonalDetails/");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<PERSONALDETAILS[]>();
                readTask.Wait();

                var employees = readTask.Result;

                foreach (PERSONALDETAILS e in employees)
                {
                    list.Add(e);
                }
            }

            return list;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            List<string> list = GetEmployeeName();
            if (!list.Contains(TextBox1.Text))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetListofEmployeeName(string prefixText)
        {
            //get all employee name 
            List<string> namelist = GetEmployeeName();

            List<string> temp = new List<string>();
            //generate employee name list based on prefix
            foreach (string v in namelist)
            {
                if (v.ToLower().Contains(prefixText.ToLower()))
                    temp.Add(v);
            }
            return temp;
        }

        private static List<string> GetEmployeeName()
        {
            List<string> namelist = new List<string>();
            foreach (PERSONALDETAILS p in pdlist)
            {
                namelist.Add(p.FirstName + " " + p.MiddleName + " " + p.LastName);
            }
            return namelist;
        }

        protected void ViewPayslip_Click(object sender, EventArgs e)
        {

            Table2.Visible = true;
            Table3.Visible = true;
            Print.Visible = true;
            prlist = getallpaymentrecord();
            
            int month = Convert.ToInt32(MonthValue.SelectedValue);
            int year= Convert.ToInt32(YearValue.SelectedValue);
            string name = TextBox1.Text;
            PERSONALDETAILS pd = pdlist.Find(p => (p.FirstName + " " + p.MiddleName + " " + p.LastName).Equals(name));
            EMPLOYEE emp = elist.Find(em => em.PersonalDetailId == pd.PersonalDetailId);
            string eid = emp.EmployeeId;
            PAYMENTRECORD pr = prlist.Find(p => p.PaymentMonth == month && p.PaymentYear == year && p.EmployeeId.Equals(eid));
            PaymentDateValue.Text = pr.PaymentMonth + " / " + pr.PaymentYear;
            EmployeeNameValue.Text = TextBox1.Text;
            JobTitleValue.Text = pr.JobTitle;
            BasicPayValue.Text = pr.BasicPay.ToString();
            TAValue.Text = pr.TA.ToString();
            HRAValue.Text = pr.HRA.ToString();
            OtherAllowancesValue.Text = pr.OtherAllowances.ToString();
            EPFValue.Text = pr.EPF.ToString();
            TaxValue.Text = pr.Tax.ToString();
            AbsenceValue.Text = pr.Absence.ToString();
            TotalEarningsValue.Text = (pr.BasicPay + pr.TA + pr.HRA + pr.OtherAllowances).ToString();
            TotalDeductionsValue.Text = (pr.EPF + pr.Tax + pr.Absence).ToString();
            NetSalaryValue.Text = (Convert.ToInt32(TotalEarningsValue.Text) - Convert.ToInt32(TotalDeductionsValue.Text)).ToString();
            
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }
    }
}