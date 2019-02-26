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
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring1);
                //HTTP GET
                var responseTask = client.GetAsync("Documents");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<DOCUMENTS[]>();
                    readTask.Wait();

                    var documents = readTask.Result;
                    Table1.CellPadding = 20;
                    foreach (DOCUMENTS document in documents)
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
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
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
                client.BaseAddress = new Uri(Global.URIstring1);

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
        protected void Button2_Click(object sender, EventArgs e)
        {

            
        }
        protected void image_click(object sender, CommandEventArgs e)
        {
            int docid = Convert.ToInt32(e.CommandArgument);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Global.URIstring1);
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