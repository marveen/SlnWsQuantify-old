using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quantify.API;
using Avontus.Core;
using Avontus.Core.Data;
using Avontus.Rental.Library;
using Avontus.Rental.Library.Security;
using ClosedXML.Excel;
using System.Data;



namespace WsQuantify
{
    public partial class ExcelReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void BtnReport_Click(object sender, EventArgs e)
        {

            try
            {
                var wb = new XLWorkbook();

                var dataSet = GetDataSet();

                // Add all DataTables in the DataSet as a worksheets
                wb.Worksheets.Add(dataSet);

                wb.SaveAs("AddingDataSet.xlsx");









                // Create the workbook
                XLWorkbook workbook = new XLWorkbook();
                workbook.Worksheets.Add("Sample").Cell(1, 1).SetValue("Hello World");

                // Prepare the response
                HttpResponse httpResponse = Response;
                httpResponse.Clear();
                httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                httpResponse.AddHeader("content-disposition", "attachment;filename=\"HelloWorld.xlsx\"");

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    wb.SaveAs(memoryStream);
                    memoryStream.WriteTo(httpResponse.OutputStream);
                    memoryStream.Close();
                }

                httpResponse.End();


            }
            catch (Exception ex)
            {

               // throw ex.InnerException;
            }

        




        }

        private DataSet GetDataSet()
        {
            var ds = new DataSet();
            ds.Tables.Add(GetTable("Patients"));
            ds.Tables.Add(GetTable("Employees"));
            ds.Tables.Add(GetTable("Information"));
            return ds;
        }


        private DataTable GetTable(String tableName)
        {
            DataTable table = new DataTable();
            table.TableName = tableName;
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            return table;
        }

    }









}