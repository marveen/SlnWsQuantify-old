using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using ClosedXML.Excel;
using System.IO;
using System.Data;



namespace WsQuantify
{
    public partial class Reports : System.Web.UI.Page
    {

        DataSet DsetReport = new DataSet();
        WsQuantify.WebServiceQuantify Wsneed = new WebServiceQuantify();

        String StrJsonReport = "";

        protected void Page_Load(object sender, EventArgs e)
        {




            //Response.Write(StrJsonReport);


        }



        private DataSet GetDataSet(String StrJsonInput)
        {

            var ds = new DataSet();
            try
            {

                ds = JsonConvert.DeserializeObject<DataSet>(StrJsonInput);

            }
            catch (Exception)
            {

                throw;
            }


            return ds;
        }




        private void GeneraExcel(string StrFilename)
        {


            using (var workbook = new XLWorkbook())
            {
                  workbook.Worksheets.Add(DsetReport);
                //workbook.SaveAs(StrFilename);





                // Prepare the response
                HttpResponse httpResponse = Response;
                httpResponse.Clear();
                httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                httpResponse.AddHeader("content-disposition", "attachment;filename=\"" + StrFilename + "\"");

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

              


        
   
        protected void BtnExcel_Click(object sender, EventArgs e)
        {
            String StrFilename = "Filename";
            StrFilename = ddlReporte.SelectedValue;
            

            switch (StrFilename)
            {
                case "StockedItemCost":

                    StrFilename = "StockedItemCost_CL.xlsx";
                    StrJsonReport = Wsneed.GetProductoReport("cl", "consultaweb", "Unispan.001");
                    DsetReport = GetDataSet(StrJsonReport);
                    GeneraExcel(StrFilename);

                    break;

                case "StockedItemCostCostumer":

                    StrFilename = "StockedItemCostCostumer_CL.xlsx";
                    StrJsonReport = Wsneed.GetReportCustomerSL("cl", "consultaweb", "Unispan.001");
                    DsetReport = GetDataSet(StrJsonReport);
                    GeneraExcel(StrFilename);
                    break;

            }

            //llamr a GeneraExcel

        

        


        }
    }
}