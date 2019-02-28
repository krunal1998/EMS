using System;
using System.Web.UI;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Data;

namespace EMS
{
    public partial class sample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField1.Value = "krunal";
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("JobTitle");
            DataColumn dc2 = new DataColumn("LeaveType");
            DataColumn dc3 = new DataColumn("numberofLeaves");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);

            DataRow dr = dt.NewRow();
            dr[0] = "Software designer";
            dr[1] = "FMLA";
            dr[2] = "5";
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1[0] = "Software designer";
            dr1[1] = "Sick";
            dr1[2] = "4";
            dt.Rows.Add(dr1);

            GridView1.DataSource = dt;
            GridView1.DataBind();

            Response.Write(DateTime.Now.Date.ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Text = HiddenField1.Value;
            //ExportGridToPDF();
        }
        private void ExportGridToPDF()
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=list.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.RenderControl(hw);
            
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Image1.ImageUrl);
            pdfDoc.Add(img);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            GridView1.AllowPaging = true;
            GridView1.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

    }

}