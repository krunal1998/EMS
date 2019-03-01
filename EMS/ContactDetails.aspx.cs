using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class ContactDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EMPLOYEE emp;
                String eid = Session["EID"].ToString();
                emp = getselectedemployee(eid);
                CONTACTDETAILS cd = getcontactdetails(emp.ContactId);

                String street = cd.Street;
                StreetValue.Text = street;

                String lm = cd.Landmark;
                LandmarkValue.Text = lm;

                String city = cd.City;
                CityValue.Text = city;

                String state = cd.State;
                StateValue.Text = state;

                Decimal pin = cd.Pincode.Value;
                PincodeValue.Text = pin.ToString();

                String country = cd.Country;
                CountryValue.Text = country;

                Decimal tno = cd.Telephone.Value;
                TelephoneNoValue.Text = tno.ToString();

                Decimal mno = cd.Mobile.Value;
                MobileNoValue.Text = mno.ToString();

                String email = cd.Email;
                EmailIDValue.Text = email;

            }
        }

        private CONTACTDETAILS getcontactdetails(int? contactId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("ContactDetails/" + contactId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<CONTACTDETAILS>();
                    readTask.Wait();

                    CONTACTDETAILS cd = readTask.Result;
                    return cd;
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