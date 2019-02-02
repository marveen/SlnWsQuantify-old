using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using ClosedXML.Excel;
using System.IO;


namespace WsQuantify
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            WsQuantify.WebServiceQuantify Wsneed = new WebServiceQuantify();

            String StrJsonReport = "";

            //StrJsonReport   = Wsneed.GetReportCustomerSL("cl", "consultaweb", "Unispan.001");

            //Response.Write(StrJsonReport);


        }

        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            String StrFilename = "Filename";
            StrFilename = ddlReporte.SelectedValue;
            StrFilename = StrFilename + ".xlsx";

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sample Sheet");
                worksheet.Cell("A1").Value = "Hello World!";
                worksheet.Cell("A2").FormulaA1 = "=MID(A1, 7, 5)";
                //workbook.SaveAs(StrFilename);


                // Prepare the response
                HttpResponse httpResponse = Response;
                httpResponse.Clear();
                httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                httpResponse.AddHeader("content-disposition", "attachment;filename=\""+StrFilename+"\"");

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    memoryStream.WriteTo(httpResponse.OutputStream);
                    memoryStream.Close();
                }

                httpResponse.End();
            }




        }
    }
}