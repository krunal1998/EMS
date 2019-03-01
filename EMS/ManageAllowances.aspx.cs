using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS
{
    public partial class ManageAllowances : System.Web.UI.Page
    {
        /* public static JOBTITLE[] jobtitles;
         static List<PERSONALDETAILS> pdlist;
         static List<EMPLOYEE> elist;
         protected void Page_Load(object sender, EventArgs e)
         {


                 loadjobtitle();
             pdlist = getallpersonaldetails();

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
             if (!list.Contains(EmployeeNameValue.Text))
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

         /* private void loademployeename()
          {
              EmployeeValue.Items.Clear();
              ListItem select = new ListItem("Select Employee", "0");
              EmployeeValue.Items.Add(select);
              using (var client = new HttpClient())
              {
                  client.BaseAddress = new Uri(Global.URIstring);
                  //HTTP GET
                  var responseTask = client.GetAsync("PersonalDetails");
                  responseTask.Wait();

                  var result = responseTask.Result;
                  if (result.IsSuccessStatusCode)
                  {

                      var readTask = result.Content.ReadAsAsync<PERSONALDETAILS[]>();
                      readTask.Wait();

                      pd = readTask.Result;

                      foreach (var ename in pd)
                      {
                          ListItem li = new ListItem(ename.FirstName+""+ename.MiddleName+""+ename.LastName);
                          li.Text = ename.FirstName + "" + ename.MiddleName + "" + ename.LastName;
                          li.Value = ename.FirstName + "" + ename.MiddleName + "" + ename.LastName;
                          EmployeeValue.Items.Add(li);
                      }
                  }
              }
          }

         private void loadjobtitle()
         {
             JobTitleValue.Items.Clear();
             ListItem select = new ListItem("Select job title", "0");
             JobTitleValue.Items.Add(select);
             using (var client = new HttpClient())
             {
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
                         ListItem li = new ListItem(jobtitle.JobTitleName, jobtitle.JobTitleName);
                         li.Text = jobtitle.JobTitleName;
                         li.Value = jobtitle.JobTitleName;
                         JobTitleValue.Items.Add(li);
                     }
                 }
             }

         }

         protected void Add_Click(object sender, EventArgs e)
         {
             if(CustomValidator1.IsValid)
             {
                 string name = EmployeeNameValue.Text;
                 PERSONALDETAILS pd = pdlist.Find(p => (p.FirstName + " " + p.MiddleName + " " + p.LastName).Equals(name));
                 EMPLOYEE emp = elist.Find(em => em.PersonalDetailId == pd.PersonalDetailId);
                 emp.EmployeeId
                 elist = getallemployees();
             }
         }

         private void getpid()
         {

         }
     }*/
    }
}