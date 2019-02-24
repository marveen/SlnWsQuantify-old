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
 
        
                var workbook = new XLWorkbook();



            //esto hay que cambiar para hacer custom las celdas 
            //hay que pasar a 

            /*
             // From a DataTable
                      var dataTable = GetTable();
                      ws.Cell(6, 1).Value = "From DataTable";
                      ws.Range(6, 1, 6, 4).Merge().AddToNamed("Titles");
                      var rangeWithData = ws.Cell(7, 1).InsertData(dataTable.AsEnumerable());

            https://github.com/ClosedXML/ClosedXML/wiki/Inserting-Data


             */
            var ws = workbook.Worksheets.Add(DsetReport.Tables[0]);


                //formulas por reporte 

                switch (StrFilename)
                {
                    case "StockedItemCost_CL.xlsx":
                        //workbook.Worksheets.Add(DsetReport);

                        int IntColumnas = 0;
                        int IntFilas = 0;

                        IntColumnas = DsetReport.Tables[0].Columns.Count;
                        IntFilas = DsetReport.Tables[0].Rows.Count;
                        IntFilas = IntFilas + 2;

                        //Primera Columna de formula
                        ws.Cell(1, 11).Value = "$ Renta";
                    ws.Cell(1, 12).Value = "$ En Bodega";

                    ws.Cell(1, 13).Value = "$ Total";
                    ws.Cell(1, 14).Value = "$ Porcentaje";

                    ws.Cell(1, 15).Value = "$ Kg Unit";
                    ws.Cell(1, 16).Value = "$ Kg en renta";
                    ws.Cell(1, 17).Value = "$ Kg en bodega";
          
                    ws.Cell(1, 18).Value = "$ Kg total";

                    ws.Cell(1, 19).Value = "$ m2 Unit";
                    ws.Cell(1, 20).Value = "$ m2 en Renta";

                    ws.Cell(1, 21).Value = "$ m2 en bodega";
                    ws.Cell(1, 22).Value = "$ M2 total ";
                    ws.Cell(1, 23).Value = "$ Total U ";
                    ws.Cell(1, 24).Value = 0.7;
                    ws.Cell(1, 24).Style.NumberFormat.NumberFormatId = 2;

                    ws.Cell(1, 25).Value = "$ Falta ";
                    ws.Cell(1, 26).Value = "$ Comprar";
                    ws.Cell(1, 27).Value = "$ Sobra ";
                    ws.Cell(1, 28).Value = "$ Vender";



                    for (int i = 2; i < IntFilas; i++)
                        {                      
                            var cellWithFormulaA1 = ws.Cell(i, 11);                      
                            string Formula = "=F"+i.ToString()+"*E"+i.ToString()+"";
                            cellWithFormulaA1.FormulaA1 = Formula;

                            var cellWithFormula12 = ws.Cell(i, 12);
                            Formula = "=(G" + i.ToString() + " + I" + i.ToString() + " + H" + i.ToString() + " + J" + i.ToString() + ") *$E" + i.ToString() + "";
                            cellWithFormula12.FormulaA1 = Formula;


                            var cellWithFormula13 = ws.Cell(i, 13);
                            Formula = "=K" + i.ToString() + "+L" + i.ToString() + "";
                            cellWithFormula13.FormulaA1 = Formula;

                            var cellWithFormula14 = ws.Cell(i, 14);
                            Formula = "=IF(M" + i.ToString() + "=0,0,K" + i.ToString() + "/M" + i.ToString() + ")"; //  "IFERROR(K" + i.ToString() + "/M" + i.ToString() + ";0)";
                            cellWithFormula14.FormulaA1 = Formula;
                            cellWithFormula14.Style.NumberFormat.NumberFormatId = 9; 






                            var cellWithFormula15 = ws.Cell(i, 15);
                            Formula = "=+D" + i.ToString();
                            cellWithFormula15.FormulaA1 = Formula;

                            var cellWithFormula16 = ws.Cell(i, 16);
                            Formula = "=+O" + i.ToString() + "*F" + i.ToString();
                            cellWithFormula16.FormulaA1 = Formula;

                        var cellWithFormula17 = ws.Cell(i, 17);
                        Formula = "=+O" + i.ToString() + "*(G" + i.ToString() + "+H" + i.ToString() + "+I" + i.ToString() + "+J" + i.ToString() + ")";
                        cellWithFormula17.FormulaA1 = Formula;

                        var cellWithFormula18 = ws.Cell(i, 18);
                        Formula = "=+Q" + i.ToString() + "+P" + i.ToString() + "";
                        cellWithFormula18.FormulaA1 = Formula;

                        var cellWithFormula19 = ws.Cell(i, 19);
                        Formula = ""; // "=BUSCARV(A3;area!A$2:F$1000;6;FALSO)";
                        cellWithFormula19.FormulaA1 = Formula;


                        var cellWithFormula20 = ws.Cell(i, 20);
                        Formula = "=+S" + i.ToString() + "*F" + i.ToString() + "";
                        cellWithFormula20.FormulaA1 = Formula;

                        var cellWithFormula21 = ws.Cell(i, 21);
                        Formula = "=+S" + i.ToString() + "*(G" + i.ToString() + "+H" + i.ToString() + "+I" + i.ToString() + "+J" + i.ToString() + ")";
                        cellWithFormula21.FormulaA1 = Formula;

                        var cellWithFormula22 = ws.Cell(i, 22);
                        Formula = "=+U" + i.ToString() + "+T" + i.ToString() + "";
                        cellWithFormula22.FormulaA1 = Formula;


                        var cellWithFormula23 = ws.Cell(i, 23);
                        Formula = "=+F" + i.ToString() + "+G" + i.ToString() + "+H" + i.ToString() + "+I" + i.ToString() + "+J" + i.ToString() + "";
                        cellWithFormula23.FormulaA1 = Formula;


                        var cellWithFormula24 = ws.Cell(i, 24);
                        Formula = "=INT(F" + i.ToString() + "/X$1)*(1)";
                        cellWithFormula24.FormulaA1 = Formula;

                        cellWithFormula24.Style.NumberFormat.NumberFormatId = 3;


                        var cellWithFormula25 = ws.Cell(i, 25);
                        Formula = ""; // "IF(+X" + i.ToString() + "-F" + i.ToString() + "-G" + i.ToString() + "-H" + i.ToString() + "-I" + i.ToString() + "-J" + i.ToString() + ">0;X" + i.ToString() + "-F" + i.ToString() + "-G" + i.ToString() + "-H" + i.ToString() + "-I" + i.ToString() + "-J" + i.ToString() + ";0)";
                        cellWithFormula25.FormulaA1 = Formula;

                        var cellWithFormula26 = ws.Cell(i, 26);
                        Formula = ""; // "=Y" + i.ToString() + "*E" + i.ToString() + "";
                        cellWithFormula26.FormulaA1 = Formula;


                        var cellWithFormula27 = ws.Cell(i, 27);
                        Formula = ""; //"=+IF(X" + i.ToString() + "-F" + i.ToString() + "-G" + i.ToString() + "-H" + i.ToString() + "-I" + i.ToString() + "-J" + i.ToString() + "<0;-(X" + i.ToString() + "-F" + i.ToString() + "-G" + i.ToString() + "-H" + i.ToString() + "-I" + i.ToString() + "-J" + i.ToString() + ");0)";
                        cellWithFormula27.FormulaA1 = Formula;


                        var cellWithFormula28 = ws.Cell(i, 28);
                        Formula = "=+AA" + i.ToString() + "*E" + i.ToString() + "";
                        cellWithFormula28.FormulaA1 = Formula;

                   


                    }


                    break;



                }



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

                case "demo":
                    var wb = new XLWorkbook();
                    var ws = wb.Worksheets.Add("Formulas");

                    ws.Cell(1, 1).Value = "Num1";
                    ws.Cell(1, 2).Value = "Num2";
                    ws.Cell(1, 3).Value = "Total";
                    ws.Cell(1, 4).Value = "cell.FormulaA1";
                    ws.Cell(1, 5).Value = "cell.FormulaR1C1";
                    ws.Cell(1, 6).Value = "cell.Value";
                    ws.Cell(1, 7).Value = "Are Equal?";

                    ws.Cell(2, 1).Value = 1;
                    ws.Cell(2, 2).Value = 2;
                    var cellWithFormulaA1 = ws.Cell(2, 3);
                    // Use A1 notation
                    cellWithFormulaA1.FormulaA1 = "=A2+$B$2"; // The equal sign (=) in a formula is optional
                    ws.Cell(2, 4).Value = cellWithFormulaA1.FormulaA1;
                    ws.Cell(2, 5).Value = cellWithFormulaA1.FormulaR1C1;

                    ws.Cell(2, 6).Value = cellWithFormulaA1.Value;

                    ws.Cell(3, 1).Value = 1;
                    ws.Cell(3, 2).Value = 2;
                    var cellWithFormulaR1C1 = ws.Cell(3, 3);
                    // Use R1C1 notation
                    cellWithFormulaR1C1.FormulaR1C1 = "RC[-2]+R3C2"; // The equal sign (=) in a formula is optional
                    ws.Cell(3, 4).Value = cellWithFormulaR1C1.FormulaA1;
                    ws.Cell(3, 5).Value = cellWithFormulaR1C1.FormulaR1C1;
                    ws.Cell(3, 6).Value = cellWithFormulaR1C1.Value;

                    ws.Cell(4, 1).Value = "A";
                    ws.Cell(4, 2).Value = "B";
                    var cellWithStringFormula = ws.Cell(4, 3);

                    // Use R1C1 notation
                    cellWithStringFormula.FormulaR1C1 = "=\"Test\" & RC[-2] & \"R3C2\"";
                    ws.Cell(4, 4).Value = cellWithStringFormula.FormulaA1;
                    ws.Cell(4, 5).Value = cellWithStringFormula.FormulaR1C1;
                    ws.Cell(4, 6).Value = cellWithStringFormula.Value;

                    // Setting the formula of a range
                    var rngData = ws.Range(2, 1, 4, 7);
                    rngData.LastColumn().FormulaR1C1 = "=IF(RC[-3]=RC[-1],\"Yes\", \"No\")";

                    // Using an array formula:
                    // Just put the formula between curly braces
                    ws.Cell("A6").Value = "Array Formula: ";
                    ws.Cell("B6").FormulaA1 = "{A2+A3}";

                    ws.Range(1, 1, 1, 7).Style.Fill.BackgroundColor = XLColor.Cyan;
                    ws.Range(1, 1, 1, 7).Style.Font.Bold = true;
                    ws.Columns().AdjustToContents();

                    // You can also change the reference notation:
                    wb.ReferenceStyle = XLReferenceStyle.R1C1;

                    // And the workbook calculation mode:
                    wb.CalculateMode = XLCalculateMode.Auto;

                    //wb.SaveAs("Formulas.xlsx");

                    // Prepare the response
                    HttpResponse httpResponse = Response;
                    httpResponse.Clear();
                    httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    httpResponse.AddHeader("content-disposition", "attachment;filename=\"" + "demo.xlsx" + "\"");

                    // Flush the workbook to the Response.OutputStream
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        wb.SaveAs(memoryStream);
                        memoryStream.WriteTo(httpResponse.OutputStream);
                        memoryStream.Close();
                    }

                    httpResponse.End();

                    break;


            }

            //llamr a GeneraExcel

        

        


        }
    }
}