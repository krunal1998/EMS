using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Http;
using System.Web.UI.WebControls;
using System.IO;

namespace EMS
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public static List<DOCUMENTS> dlist;
        protected void Page_Load(object sender, EventArgs e)
        {
            EMPLOYEE emp;
            String eid = Session["EID"].ToString();
            emp = getselectedemployee(eid);
            getalldocuments(emp.EmployeeId);
            foreach (DOCUMENTS document in dlist)
            {
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                TableCell tc1 = new TableCell();

                Byte[] bytes = document.DocumentPhoto;
                LinkButton dt = new LinkButton();
                dt.Text = document.DocumentTitle;
                dt.CommandArgument = document.DocumentId.ToString();
                dt.Command += new CommandEventHandler(image_click);
                Image image = new Image();
                image.Width = 100;

                image.Height = 100;
                image.ImageUrl = "data:image;base64," + Convert.ToBase64String(bytes);
                tc.Controls.Add(image);
                tc1.Controls.Add(dt);
                tr.Cells.Add(tc);
                tr.Cells.Add(tc1);
                Table1.Rows.Add(tr);

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

        public void getalldocuments(string employeeId)
        {
            using (var client = new HttpClient())
            {
                dlist = new List<DOCUMENTS>();
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Documents");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<DOCUMENTS[]>();
                    readTask.Wait();

                    var documents = readTask.Result;
                    foreach (DOCUMENTS d in documents) {
                        if (d.EmployeeId == employeeId)
                            dlist.Add(d);

                    }
                }
            }

        }

        /*   protected void Button1_Click(object sender, EventArgs e)
           {
               HttpPostedFile postedFile = FileUpload1.PostedFile;
               string fileName = Path.GetFileName(postedFile.FileName);
               string fileExtension = Path.GetExtension(fileName);
               int fileSize = postedFile.ContentLength;

               if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
               {
                   Stream stream = postedFile.InputStream;
                   BinaryReader binaryReader = new BinaryReader(stream);
                   byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                   DOCUMENTS d = new DOCUMENTS();
                   d.DocumentPhoto = bytes;
                   d.DocumentTitle = "asdf";
                   var client = new HttpClient();
                   client.BaseAddress = new Uri(Global.URIstring);

                   var postTask = client.PostAsJsonAsync<DOCUMENTS>("documents", d);
                   postTask.Wait();

                   var result = postTask.Result;
                   if (result.IsSuccessStatusCode)
                   {

                       var readTask = result.Content.ReadAsAsync<DOCUMENTS>();
                       readTask.Wait();

                       var insertedStudent = readTask.Result;

                       Response.Write(insertedStudent.DocumentTitle + insertedStudent.DocumentId);
                   }
                   else
                   {
                       Response.Write(result.StatusCode);
                   }
               }
               else
               {
                   Label1.Visible = true;
                   Label1.Text = "Only .jpg and .png files can be Uploaded";
               }


               }
               */
        protected void image_click(object sender, CommandEventArgs e)
        {
            expandedImage.Visible = true;
            int docid = Convert.ToInt32(e.CommandArgument);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring);
                //HTTP GET
                var responseTask = client.GetAsync("Documents/" + docid);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DOCUMENTS>();
                    readTask.Wait();

                    var doc = readTask.Result;
                    expandedImage.ImageUrl = "data:image;base64," + Convert.ToBase64String(doc.DocumentPhoto);
                }
            }
        }
    }


}
                    