using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class E_mergencyContacts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EMPLOYEE emp;
                String eid = Session["EID"].ToString();
                emp = getselectedemployee(eid);
                EMERGENCYCONTACT ecd = getemergencycontactdetails(emp.EmergencyContactId);

                String name = ecd.Name;
                NameValue.Text = name;

                String relation =ecd.Relation;
                RelationValue.Text = relation;

                Decimal tno = ecd.Telephone.Value;
                TelephoneNoValue.Text = tno.ToString();

                Decimal mno = ecd.Mobile.Value;
                MobileNoValue.Text = mno.ToString();
            }
        }

        private EMERGENCYCONTACT getemergencycontactdetails(int? emergencyContactId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("EmergencyContact/" + emergencyContactId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<EMERGENCYCONTACT>();
                    readTask.Wait();

                    EMERGENCYCONTACT ecd = readTask.Result;
                    return ecd;
                }
                return null;
            }
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
    }
}