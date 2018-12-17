using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Data;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Avontus.Core;
using Avontus.Core.Data;
using Avontus.Rental.Library;
using Avontus.Rental.Library.Security;
using Quantify.API;

namespace Quantify.API
{
    public class Apimethod
    {    
        
        public string GetReportCustomerSL(String StrCodPais, String StrUser, String Strpass)
        {
            String StrSalida ="";

            try{

                AvontusPrincipal.Logout();
                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = StrUser; // ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = Strpass; // ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);


                if (success)
                {
                    AvontusUser AvUser = AvontusUser.GetUser(StrUsrQtfy);

                    BusinessPartnerComboList BpatList = BusinessPartnerComboList.GetCustomerComboList(Guid.Empty, ActiveStatus.Active, ActiveStatus.Active, false, false);

                    DataSet orgData = StockingLocationOrganization.GetOrganizationData(ActiveStatus.Active);

                    StockingLocationOrganization slo = StockingLocationOrganization.GetOrganization(ActiveStatus.Active);

                    DataTable locations = orgData.Tables[0];

                    locations.DefaultView.Sort = "CustomerName DESC";

                    DataTable dw = locations.DefaultView.ToTable();
                  

                    List<Guid> LocationList = new List<Guid>();


                    string StrPivotGuid;
                    foreach (DataRow DR in locations.Rows)
                    {
                        //Obtener Guid de Locacion 

                        Guid Gid = new Guid();
                        //LocationList.Add(Gid);

                        StrPivotGuid = DR.ItemArray[2].ToString();

                        if (StrPivotGuid.Length > 10)
                        {
                            Gid = new Guid(StrPivotGuid);
                            LocationList.Add(Gid);

                        }
                    }




                    ProductCollection ProdList = ProductCollection.GetProductCollection(ProductType.Product);

                    Int32 IntProdlist = 0;
                    IntProdlist = ProdList.Count;
                    //en este punto ya se tiene todos los los locales
                    //hay que armar la salida, para validar la mejor forma es tomar
                    //por poarden alfabetido de customername asi agrupamos comoen quetyfy
                    //depsues buscamos los stocked productos X PAdre y sumamaos como 








                    StockedProductList StockedPrds = StockedProductList.GetStockedProductList(LocationList, Guid.Empty, ProductType.All);
                    int intCountStocked;
                    intCountStocked = StockedPrds.Count;


                    
                    //StockedProductList StockedPrds2 = StockedProductList.GetStockedProductList(Guid.Empty, ProductType.ProductOrConsumable);



                    //StockedProductList StockedProductList2 = StockedProductList.get

                    //IntProdlist = StockedPrds.Count;
                    //foreach (StockedProductListItem PivotProduct in StockedPrds)
                    //{
                    //    StrProductname = PivotProduct.PartNumber;
                        
                    //}



                    // System.Web.UI.WebControls.TreeView tvOrganization = new System.Web.UI.WebControls.TreeView();
                    //System.Windows.Forms.TreeView tvOrganization = new System.Windows.Forms.TreeView();

                    //StockingLocationOrganization orgTree = StockingLocationOrganization.GetOrganization(ActiveStatus.Active);
                    //orgTree.BuildTreeView(tvOrganization, OrgViewGrouping.ByJob, JobTreeNodeDisplayType.Name, AvUser.RelatedID, AvUser.UserID, AvUser.PrimaryTradingPartnerID);

                    //System.Windows.Forms.TreeNode oMainNode = tvOrganization.Nodes[0];

                    //IntProdlist = StockedPrds.Count;


                    StockedProductCollection ProdCol = StockedProductCollection.GetStockedProductCollection(AvUser.PrimaryTradingPartnerID, ProductType.All);
                    IntProdlist = ProdCol.Count;


                    //GET PRODUCTO LIST 

                    //StockedProduct ProdColByLocation = StockedProductCollection.GetStockedProductCollection()


                    //StockedProductList StockedPrds = StockedProductList.GetStockedProductList(Guid.Empty, Guid.Empty, ProductType.Product);


                    //StockingLocationList JobSiteList = StockingLocationList.GetJobsites(false, JobTreeNodeDisplayType.Name, Guid.Parse(bpat.BusinessPartnerID.ToString()), Guid.Empty);

                    //StockedProductList StockedPrds2 = StockedProductList.GetStockedProductList();





                    // ARMANDO LA SALIDAR PARA MANITO PASA LA DATA MANITO 

                    //* Exportacion Objeto Dataset Limpio*//
                    DataSet dataSetProducts = new DataSet("DS_StocketItems");
                    dataSetProducts.Namespace = "Quantify";
                    DataTable tableProducts = new DataTable();
                    tableProducts.TableName = "StockedItems";

                    DataColumn idColumn = new DataColumn("id", typeof(string));
                    DataColumn colCodigo = new DataColumn("Codigo", typeof(string));
                    DataColumn colDescription = new DataColumn("Description", typeof(string));
                    DataColumn colCatalog = new DataColumn("Catalog", typeof(string));
                    DataColumn colWeightEach = new DataColumn("Weight Each", typeof(string));
                    DataColumn colCostEach = new DataColumn("Cost Each", typeof(string));
                    DataColumn colQuantityEnArriendo = new DataColumn("Quantity En Arriendo", typeof(string));
                    DataColumn colQuantityDisponible = new DataColumn("Quantity Disponible", typeof(string));
                    DataColumn colQuantityReserved = new DataColumn("Quantity Reserved", typeof(string));
                    DataColumn colQuantityInTransit = new DataColumn("Quantity In Transit", typeof(string));
                    DataColumn colQuantityNew = new DataColumn("Quantity New", typeof(string));
                  


                    idColumn.AutoIncrement = true;

                    tableProducts.Columns.Add(idColumn);
                    tableProducts.Columns.Add(colCodigo);
                    tableProducts.Columns.Add(colDescription);
                    tableProducts.Columns.Add(colCatalog);
                    tableProducts.Columns.Add(colWeightEach);
                    tableProducts.Columns.Add(colCostEach);
                    tableProducts.Columns.Add(colQuantityEnArriendo);
                    tableProducts.Columns.Add(colQuantityDisponible);
                    tableProducts.Columns.Add(colQuantityReserved);
                    tableProducts.Columns.Add(colQuantityInTransit);
                    tableProducts.Columns.Add(colQuantityNew);

                    dataSetProducts.Tables.Add(tableProducts);



                    foreach (StockedProduct prod in ProdCol)
                    {

                        Product Prodname = Product.GetProduct(new Guid(prod.BaseProductID.ToString()));
                        
                       
                        String StrPartNumbert = (prod.PartNumber != null) ? prod.PartNumber.ToString() : "NoPartNumber";
                        String StrDescription = (Prodname.Description != null) ? Prodname.Description.ToString() : "NoName";
                        String StrProductCategoryName = (Prodname.ProductCategoryNameLazyLoaded != null) ? Prodname.ProductCategoryNameLazyLoaded.ToString() : "No Category";
                        String StrWeight = (prod.Weight != null) ? prod.Weight.ToString() : "0";
                        String StrDelaultCost = (prod.DefaultCost != null) ? prod.DefaultCost.ToString() : "0";
                        String StrQuantityOnRent = (prod.QuantityOnRent != null) ? prod.QuantityOnRent.ToString() : "0";
                        String StrQuantityForRent = (prod.QuantityForRent != null) ? prod.QuantityForRent.ToString() : "0";             
                        String StrQuantityReserved = (prod.QuantityReserved != null) ? prod.QuantityReserved.ToString() : "0";
                        String StrQuantityInTransit = (prod.QuantityInTransit != null) ? prod.QuantityInTransit.ToString() : "0";
                        String StrQuantityNew  = (prod.QuantityNew != null) ? prod.QuantityNew.ToString() : "0";


                        if (prod.QuantityForRent == null)
                        {
                            //Validacion para saltar lo que no tienen Reserva 
                            continue;
                        }


                        DataRow TempRow = tableProducts.NewRow();
                        TempRow["Codigo"] = StrPartNumbert;
                        TempRow["Description"] = StrDescription;
                        TempRow["Catalog"] = StrProductCategoryName; 
                        TempRow["Weight Each"] = StrWeight; 
                        TempRow["Cost Each"] = StrDelaultCost;  
                        TempRow["Quantity En Arriendo"] = StrQuantityOnRent;
                        TempRow["Quantity Disponible"] = StrQuantityForRent; 
                        TempRow["Quantity Reserved"] = StrQuantityReserved;
                        TempRow["Quantity In Transit"] = StrQuantityInTransit;
                        TempRow["Quantity New"] = StrQuantityNew; 


                        tableProducts.Rows.Add(TempRow);


                    }

                    dataSetProducts.AcceptChanges();
                    StrSalida = JsonConvert.SerializeObject(dataSetProducts, Formatting.Indented);


                    // FORMA LARGA

                    //double? SumOnRent = 0; 

                    //foreach (StockedProduct item in ProdCol)
                    //{
                    //    if (item.Description == "PALET")
                    //    {
                    //                    IntProdlist = ProdCol.Count;

                    //        double? QtyRented = (item.QtyOnRentOriginal != null) ? item.QtyOnRentOriginal : 0;

                    //        SumOnRent = SumOnRent + QtyRented;

                    //        // esto esta cuadrando con lo de avpontus , el problema es que hay que recorerlo de mejor manera 
                    //        //pensar en tener un Array de todos los productos es la mejor forma pero hay que estar cuadrado 
                    //        //con los distitnios produtos que tiene Avotuns. 

                    //    }

                    //}

                    //SumOnRent = SumOnRent + 0; 








                }
            }


            catch (Exception ex)
            {
                StrSalida = ex.InnerException.ToString();

            }
            return StrSalida; 
        }

        public string GetProductoReport(String StrCodPais, String StrUser, String Strpass)
        {
            String StrSalida = "";

            try
            {

                AvontusPrincipal.Logout();
                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = StrUser; // ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = Strpass; // ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);


                if (success)
                {
                    AvontusUser AvUser = AvontusUser.GetUser(StrUsrQtfy);


                    //Obtener toda la organizacion 
                    DataSet orgData = StockingLocationOrganization.GetOrganizationData(ActiveStatus.Active);
                    DataTable locations = orgData.Tables[0];

                    List<Guid> LocationList = new List<Guid>();


                    string StrPivotGuid;
                    foreach (DataRow DR in locations.Rows)
                    {
                        //Obtener Guid de Locacion 

                        Guid Gid = new Guid();
                        //LocationList.Add(Gid);

                        StrPivotGuid = DR.ItemArray[2].ToString();

                        if (StrPivotGuid.Length > 10)
                        {
                            Gid = new Guid(StrPivotGuid);
                            LocationList.Add(Gid);

                        }
                    }



                    Int32 IntProdlist = 0;
                    StockedProductList ProdList = StockedProductList.GetStockedProductList(LocationList, Guid.Empty, ProductType.Product);
                    int intCountStocked;
                    intCountStocked = ProdList.Count;

                    // ARMANDO LA SALIDAR PARA MANITO PASA LA DATA MANITO 

                    //* Exportacion Objeto Dataset Limpio*//
                    DataSet dataSetProducts = new DataSet("DS_StocketItems");
                    dataSetProducts.Namespace = "Quantify";
                    DataTable tableProducts = new DataTable();
                    tableProducts.TableName = "StockedItems";

                    DataColumn idColumn = new DataColumn("id", typeof(string));
                    DataColumn colCodigo = new DataColumn("Codigo", typeof(string));
                    DataColumn colDescription = new DataColumn("Description", typeof(string));
                    DataColumn colCatalog = new DataColumn("Catalog", typeof(string));
                    DataColumn colWeightEach = new DataColumn("Weight Each", typeof(string));
                    DataColumn colCostEach = new DataColumn("Cost Each", typeof(string));
                    DataColumn colQuantityEnArriendo = new DataColumn("Quantity En Arriendo", typeof(string));
                    DataColumn colQuantityDisponible = new DataColumn("Quantity Disponible", typeof(string));
                    DataColumn colQuantityReserved = new DataColumn("Quantity Reserved", typeof(string));
                    DataColumn colQuantityInTransit = new DataColumn("Quantity In Transit", typeof(string));
                    DataColumn colQuantityNew = new DataColumn("Quantity New", typeof(string));



                    idColumn.AutoIncrement = true;

                    tableProducts.Columns.Add(idColumn);
                    tableProducts.Columns.Add(colCodigo);
                    tableProducts.Columns.Add(colDescription);
                    tableProducts.Columns.Add(colCatalog);
                    tableProducts.Columns.Add(colWeightEach);
                    tableProducts.Columns.Add(colCostEach);
                    tableProducts.Columns.Add(colQuantityEnArriendo);
                    tableProducts.Columns.Add(colQuantityDisponible);
                    tableProducts.Columns.Add(colQuantityReserved);
                    tableProducts.Columns.Add(colQuantityInTransit);
                    tableProducts.Columns.Add(colQuantityNew);

                    dataSetProducts.Tables.Add(tableProducts);



                    foreach (StockedProductListItem prod in ProdList)
                    {

                        Product Prodname = Product.GetProduct(new Guid(prod.BaseProductID.ToString()));


                        String StrPartNumbert = (prod.PartNumber != null) ? prod.PartNumber.ToString() : "NoPartNumber";
                        String StrDescription = (Prodname.Description != null) ? Prodname.Description.ToString() : "NoName";
                        String StrProductCategoryName = (Prodname.ProductCategoryNameLazyLoaded != null) ? Prodname.ProductCategoryNameLazyLoaded.ToString() : "No Category";
                        String StrWeight = (prod.Weight != null) ? prod.Weight.ToString() : "0";
                        String StrDelaultCost = (prod.DefaultCost != null) ? prod.DefaultCost.ToString() : "0";
                        String StrQuantityOnRent = (prod.QuantityOnRent != null) ? prod.QuantityOnRent.ToString() : "0";
                        String StrQuantityForRent = (prod.QuantityForRent != null) ? prod.QuantityForRent.ToString() : "0";
                        String StrQuantityReserved = (prod.QuantityReserved != null) ? prod.QuantityReserved.ToString() : "0";
                        String StrQuantityInTransit = (prod.QuantityInTransit != null) ? prod.QuantityInTransit.ToString() : "0";
                        String StrQuantityNew = (prod.QuantityNew != null) ? prod.QuantityNew.ToString() : "0";


                        if (prod.QuantityForRent == null)
                        {
                            //Validacion para saltar lo que no tienen Reserva 
                            //continue;
                        }


                        DataRow TempRow = tableProducts.NewRow();
                        TempRow["Codigo"] = StrPartNumbert;
                        TempRow["Description"] = StrDescription;
                        TempRow["Catalog"] = StrProductCategoryName;
                        TempRow["Weight Each"] = StrWeight;
                        TempRow["Cost Each"] = StrDelaultCost;
                        TempRow["Quantity En Arriendo"] = StrQuantityOnRent;
                        TempRow["Quantity Disponible"] = StrQuantityForRent;
                        TempRow["Quantity Reserved"] = StrQuantityReserved;
                        TempRow["Quantity In Transit"] = StrQuantityInTransit;
                        TempRow["Quantity New"] = StrQuantityNew;


                        tableProducts.Rows.Add(TempRow);


                    }

                    dataSetProducts.AcceptChanges();
                    StrSalida = JsonConvert.SerializeObject(dataSetProducts, Formatting.Indented);

                }
            }


            catch (Exception ex)
            {
                StrSalida = ex.InnerException.ToString();

            }
            return StrSalida;
        }


        public string GetProductByShippingID(String StrCodPais, String StrUser, String Strpass, String ShipmentID)
        {



            string Salida = "";

            try
            {
                AvontusPrincipal.Logout();
                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = StrUser; // ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = Strpass; // ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);

                if (success)
                {
                    AvontusUser AvUser = AvontusUser.GetUser(StrUsrQtfy);
                    BusinessPartnerComboList BpatList = BusinessPartnerComboList.GetCustomerComboList(Guid.Empty, ActiveStatus.Active, ActiveStatus.Active, false, false);

                   // StockingLocation Local = StockingLocation.GetStockingLocation(Guid.Parse(StrStockingLocation), true, true);
                   // ShipmentList Slist = ShipmentList.GetShipmentList(Local.StockingLocationID);
                   //ShipmentList Slist2 = ShipmentList.GetShipmentList(Guid.Parse(Local.StockingLocationID.ToString()));
                   




                    CICOToolCollection ProdList = CICOToolCollection.GetShipmentProducts(Guid.Parse(ShipmentID));

                    Shipment shii = Shipment.GetShipment(Guid.Parse(ShipmentID),true,true,true);
                    

                    Order Ord = Order.GetOrder(Guid.Parse(shii.OrderID.ToString()));
                    //Ord = Order.GetOrder(Guid.Parse(reparto.OrderID.ToString()));

                    String StrOperation = "";
                    StrOperation = shii.ShipmentNumber.ToString();
                    StrOperation = StrOperation.Substring(0, 3);





                    //* Exportacion Objeto Dataset Limpio*//
                    DataSet dataSetProducts = new DataSet("Ds_Products");
                    dataSetProducts.Namespace = "Quantify";
                    DataTable tableProducts = new DataTable();
                    tableProducts.TableName = "Products";

                    DataColumn idColumn = new DataColumn("id", typeof(string));


                    DataColumn DescriptionColumn = new DataColumn("Description", typeof(string));
                    DataColumn PartNumberColumn = new DataColumn("PartNumber", typeof(string));

                    DataColumn WeightColumn = new DataColumn("Weight", typeof(string));
                    DataColumn ReseveColumn = new DataColumn("Reserverd", typeof(string));
                    DataColumn SentColumn = new DataColumn("Sent", typeof(string));
                    DataColumn RecvrColumn = new DataColumn("Recieved", typeof(string));
                    DataColumn DiColumn = new DataColumn("Discrepancy", typeof(string));
                    DataColumn RrateColumn = new DataColumn("RentRate", typeof(string));


                    idColumn.AutoIncrement = true;

                    tableProducts.Columns.Add(idColumn);
                    tableProducts.Columns.Add(DescriptionColumn);
                    tableProducts.Columns.Add(PartNumberColumn);


                    tableProducts.Columns.Add(WeightColumn);
                    tableProducts.Columns.Add(ReseveColumn);
                    tableProducts.Columns.Add(SentColumn);
                    tableProducts.Columns.Add(RecvrColumn);
                    tableProducts.Columns.Add(DiColumn);
                    tableProducts.Columns.Add(RrateColumn);

                    //Clonando Tabla Productos para llevar los No Reparables 
                    DataTable Dt_NoReperable = tableProducts.Clone();
                    Dt_NoReperable.TableName = "NoReparables";
                    //Cambioando columnaspara la salida 
                    Dt_NoReperable.Columns["Sent"].ColumnName = "Quantity";
                    Dt_NoReperable.Columns["Discrepancy"].ColumnName = "Status";
                    Dt_NoReperable.Columns["RentRate"].ColumnName = "Notes";
                    Dt_NoReperable.Columns.Remove("Recieved");
                    


                    dataSetProducts.Tables.Add(tableProducts);
                    dataSetProducts.Tables.Add(Dt_NoReperable);


                    foreach (CICOTool item in ProdList)
                    {

                        if (item.ProductType == ProductType.Product)
                        {

                            //Product Prodname2 = "";  //Product.GetProduct(new Guid(prod.BaseProductID.ToString()));
                            String StrDescription = "";// (Prodname.Description != null) ? Prodname.Description.ToString() : "NoName";
                            String StrPartNumbert = (item.PartNumber != null) ? item.PartNumber.ToString() : "NoPartNumber";




                            String StrQuantityOnRent = "";//(prod.QuantityOnRent != null) ? prod.QuantityOnRent.ToString() : "0";
                            String StrQuantityInTransit = "";//(prod.QuantityInTransit != null) ? prod.QuantityInTransit.ToString() : "0";
                            String StrQuantityReserved = "";



                            DataRow TempRow = tableProducts.NewRow();
                            TempRow["Description"] = item.Description.ToString();
                            TempRow["PartNumber"] = StrPartNumbert;

                            TempRow["Weight"] = item.Weight.ToString();
                            TempRow["Reserverd"] = item.ReservedQuantity.ToString();
                            TempRow["Sent"] = item.SentQuantity.ToString();
                            TempRow["Recieved"] = item.ActualOriginal.ToString(); 

                            double IntRecieved = 0;
                            IntRecieved = item.ActualOriginal;


                            //TABLA DE IRREPARABLES
                            if (item.ActualOriginal > 0 && item.OutOfServiceNotRepairableQuantity > 0)
                            {
                                //Se Resta el No Reparable de la lista de productos 
                                IntRecieved = item.ActualOriginal -  Double.Parse(item.OutOfServiceNotRepairableQuantity.ToString());                                
                                
                                if (StrOperation == "DEV" || StrOperation == "RET")
                                {
                                    DataRow TempRow_NoReparable = Dt_NoReperable.NewRow();
                                    TempRow_NoReparable["Description"] = item.Description.ToString();
                                    TempRow_NoReparable["PartNumber"] = StrPartNumbert;
                                    TempRow_NoReparable["Weight"] = item.Weight.ToString();
                                    TempRow_NoReparable["Reserverd"] = item.ReservedQuantity.ToString();
                                    TempRow_NoReparable["Quantity"] = item.OutOfServiceNotRepairableQuantity.ToString();
                                    //TempRow_NoReparable["Recieved"] = IntRecieved.ToString();
                                    TempRow_NoReparable["Status"] = "Irreparable";//item.OutOfServiceStatusString.ToString();
                                   TempRow_NoReparable["Notes"] = item.OutOfServiceNotes.ToString();
                                    Dt_NoReperable.Rows.Add(TempRow_NoReparable);
                                }
                                

                            }

                            //TABLA DE PERDIDOS
                            if (item.OutOfServiceLostQuantity > 0)
                            {

                                if (StrOperation == "DEV" || StrOperation == "RET")
                                {
                                    DataRow TempRow_NoReparable = Dt_NoReperable.NewRow();
                                    TempRow_NoReparable["Description"] = item.Description.ToString();
                                    TempRow_NoReparable["PartNumber"] = StrPartNumbert;
                                    TempRow_NoReparable["Weight"] = item.Weight.ToString();
                                    TempRow_NoReparable["Reserverd"] = item.ReservedQuantity.ToString();
                                    TempRow_NoReparable["Quantity"] = item.OutOfServiceLostQuantity.ToString();
                                    //TempRow_NoReparable["Recieved"] = IntRecieved.ToString();
                                    TempRow_NoReparable["Status"] = "Perdido";//item.OutOfServiceStatusString.ToString();
                                    TempRow_NoReparable["Notes"] = item.OutOfServiceLostNotes.ToString();
                                    Dt_NoReperable.Rows.Add(TempRow_NoReparable);

                                    

                                }
                            }

                            //TABLA DE NO APLICA (DAMAGED) REPARABLES                        
                            if (item.OutOfServiceRepairableQuantity > 0)
                            {

                                if (StrOperation == "DEV" || StrOperation == "RET")
                                {
                                    DataRow TempRow_NoReparable = Dt_NoReperable.NewRow();
                                    TempRow_NoReparable["Description"] = item.Description.ToString();
                                    TempRow_NoReparable["PartNumber"] = StrPartNumbert;
                                    TempRow_NoReparable["Weight"] = item.Weight.ToString();
                                    TempRow_NoReparable["Reserverd"] = item.ReservedQuantity.ToString();
                                    TempRow_NoReparable["Quantity"] = item.OutOfServiceRepairableQuantity.ToString();
                                    //TempRow_NoReparable["Recieved"] = IntRecieved.ToString();
                                    TempRow_NoReparable["Status"] = "No Aplica";//item.OutOfServiceStatusString.ToString();
                                    TempRow_NoReparable["Notes"] = item.OutOfServiceRepairableNotes.ToString();
                                    Dt_NoReperable.Rows.Add(TempRow_NoReparable);

                                }
                            }


                            //Se comenta por requerimiento de usuario
                            //TempRow["Recieved"] = IntRecieved.ToString();
                            TempRow["Discrepancy"] = item.DiscrepancyQuantity.ToString();
                            TempRow["RentRate"] = item.RentRate.ToString();


                            tableProducts.Rows.Add(TempRow);
                        }
                      



                    }

                    dataSetProducts.AcceptChanges();
                    Salida = JsonConvert.SerializeObject(dataSetProducts, Formatting.None);



                }
                else
                {
                    Salida = "Error de Acceso";
                }



            }
            catch (Exception ex)
            {
                Salida = ex.InnerException.ToString();

            }

            return Salida;






            




        }


        public string GetAdditionalCharges(string StrCodPais, string StrUser, string Strpass)
        {
            string Salida = "";

            try
            {
                AvontusPrincipal.Logout();
                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = StrUser; // ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = Strpass; // ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);


                //InvoiceProductChargeCollection GetInvoiceProductChargeCollection

                /*
                 Number -  -  - . -  -  -  - - - Order

                 */

           

                //UnitHourRateCollection Addit2 =  UnitHourRateCollection.GetAdditionalChargeCollection(UnitList.First)




                //*Configuracion Dataset Salida*//
                DataSet dataSetProd = new DataSet("Ds_Productos");
                dataSetProd.Namespace = "Quantify";
                DataTable tb_Productos = new DataTable();
                tb_Productos.TableName = "Productos";


                DataColumn idColumn = new DataColumn("id", typeof(string));

                DataColumn PartColumn = new DataColumn("Part", typeof(string));
                DataColumn PartNameColumn = new DataColumn("PartName", typeof(string));
                DataColumn ShipmentColumn = new DataColumn("Shipment", typeof(string));
                DataColumn DateColumn = new DataColumn("Date", typeof(string));
                DataColumn QntyColumn = new DataColumn("Qnty", typeof(string));
                DataColumn FromColumn = new DataColumn("From", typeof(string));
                DataColumn ToColumn = new DataColumn("To", typeof(string));
                DataColumn DaysColumn = new DataColumn("Days", typeof(string));
                DataColumn DayRentColumn = new DataColumn("30DayRent", typeof(string));
                DataColumn TotalColumn = new DataColumn("Total", typeof(string));



                DataColumn DatetColumn = new DataColumn("Datet", typeof(DateTime));

                //DataColumn   BusinessPartnerIDColumn = new DataColumn("BusinessPartnerID", typeof(string));                
                idColumn.AutoIncrement = true;


                tb_Productos.Columns.Add(idColumn);
                tb_Productos.Columns.Add(PartColumn);
                tb_Productos.Columns.Add(PartNameColumn);
                tb_Productos.Columns.Add(ShipmentColumn);
                tb_Productos.Columns.Add(DateColumn);
                tb_Productos.Columns.Add(QntyColumn);
                tb_Productos.Columns.Add(FromColumn);
                tb_Productos.Columns.Add(ToColumn);
                tb_Productos.Columns.Add(DaysColumn);
                tb_Productos.Columns.Add(DayRentColumn);
                tb_Productos.Columns.Add(TotalColumn);
                tb_Productos.Columns.Add(DatetColumn);

                //tableBpat.Columns.Add(BusinessPartnerIDColumn);               
                //dataSetProd.Tables.Add(tb_Productos);

                if (success)
                {
                    AvontusUser AvUser = AvontusUser.GetUser(StrUsrQtfy);
                    BusinessPartnerComboList BpatList = BusinessPartnerComboList.GetCustomerComboList(Guid.Empty, ActiveStatus.Active, ActiveStatus.Active, false, false);                   
                    //List<InvoiceRentProduct> listaRent = new List<InvoiceRentProduct>();

                    


                    UnitPriceCollection prices =    UnitPriceCollection.GetUnitPriceCollection(ActiveStatus.Active, false, Guid.Empty);

                 

                  
                 

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;

                    string myJson = JsonConvert.SerializeObject(prices, settings);

                    Salida = myJson;




                }
                else
                {
                    Salida = "Error de Acceso";
                }



            }
            catch (Exception ex)
            {
                Salida = ex.InnerException.ToString();

            }

            return Salida;


        }

        public string GetInvoiceProducts(string StrCodPais, string StrUser, string Strpass, string StrinvoiceID)
        {
            string Salida = "";

            try
            {
                AvontusPrincipal.Logout();
                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = StrUser; // ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = Strpass; // ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);




                //InvoiceProductChargeCollection GetInvoiceProductChargeCollection

                /*
                 Number -  -  - . -  -  -  - - - Order

                 */

                //*Configuracion Dataset Salida*//
                DataSet dataSetProd = new DataSet("Ds_Productos");
                dataSetProd.Namespace = "Quantify";
                DataTable tb_Productos = new DataTable();
                tb_Productos.TableName = "Productos";


                DataColumn idColumn = new DataColumn("id", typeof(string));

                DataColumn PartColumn = new DataColumn("Part", typeof(string));
                DataColumn PartNameColumn = new DataColumn("PartName", typeof(string));
                DataColumn ShipmentColumn = new DataColumn("Shipment", typeof(string));
                DataColumn DateColumn = new DataColumn("Date", typeof(string));
                DataColumn QntyColumn = new DataColumn("Qnty", typeof(string));
                DataColumn FromColumn = new DataColumn("From", typeof(string));
                DataColumn ToColumn = new DataColumn("To", typeof(string));
                DataColumn DaysColumn = new DataColumn("Days", typeof(string));
                DataColumn DayRentColumn = new DataColumn("30DayRent", typeof(string));
                DataColumn TotalColumn = new DataColumn("Total", typeof(string));
                DataColumn WeightColumn = new DataColumn("Weight", typeof(string));




                DataColumn DatetColumn = new DataColumn("Datet", typeof(DateTime));

                //DataColumn BusinessPartnerIDColumn = new DataColumn("BusinessPartnerID", typeof(string));                
                idColumn.AutoIncrement = true;


                tb_Productos.Columns.Add(idColumn);
                tb_Productos.Columns.Add(PartColumn);
                tb_Productos.Columns.Add(PartNameColumn);
                tb_Productos.Columns.Add(ShipmentColumn);                            
                tb_Productos.Columns.Add(DateColumn);
                tb_Productos.Columns.Add(QntyColumn);
                tb_Productos.Columns.Add(FromColumn);
                tb_Productos.Columns.Add(ToColumn);
                tb_Productos.Columns.Add(DaysColumn);
                tb_Productos.Columns.Add(DayRentColumn);
                tb_Productos.Columns.Add(TotalColumn);
                tb_Productos.Columns.Add(DatetColumn);
                tb_Productos.Columns.Add(WeightColumn);

                //tableBpat.Columns.Add(BusinessPartnerIDColumn);               
                //dataSetProd.Tables.Add(tb_Productos);

                if (success)
                {
                    AvontusUser AvUser = AvontusUser.GetUser(StrUsrQtfy);
                    BusinessPartnerComboList BpatList = BusinessPartnerComboList.GetCustomerComboList(Guid.Empty, ActiveStatus.Active, ActiveStatus.Active, false, false);

                    InvoiceProductChargeCollection ItemsFactura = InvoiceProductChargeCollection.GetInvoiceProductChargeCollection(Guid.Parse(StrinvoiceID));
                    Invoice Factura = Invoice.GetInvoice(Guid.Parse(StrinvoiceID), true);


                    //List<InvoiceRentProduct> listaRent = new List<InvoiceRentProduct>();

                    StockingLocation Local = StockingLocation.GetStockingLocation(Guid.Parse(Factura.BillingLocationID.ToString()), true, true);

                    foreach (InvoiceRentProduct item in Factura.InvoiceRentProducts)
                    {

                        string strtemp = "";
                        strtemp = item.Description;
                        //listaRent.Add(rProd);



                        DataRow TempRow = tb_Productos.NewRow();
                        TempRow["Part"] = item.PartNumber.ToString();
                        TempRow["PartName"] = item.Description.ToString();

                        //Shipment Shi = Shipment.GetShipment(Guid.Parse(item.ShipmentID.ToString()), true, true, true);


                        TempRow["Shipment"] = item.ReportAllocatedShipmentNumber.ToString();
                        TempRow["Date"] = item.AllocatedShipmentDate.ToString();
                        TempRow["Qnty"] = item.Quantity.ToString();
                        TempRow["From"] = item.StartDate.ToString();
                        TempRow["To"] = item.EndDate.ToString();
                        TempRow["Days"] = item.Days.ToString();
                        TempRow["30DayRent"] = item.RentRate.ToString();
                        TempRow["Total"] = item.TotalRent.ToString();
                        TempRow["Datet"] = DateTime.Parse(item.AllocatedShipmentDate);
                        TempRow["Weight"] = item.Weight.ToString();
                        

                        string StrRateProfileID = Local.DefaultRateProfileID.ToString();
                        RateProfileProduct Larate4 = RateProfileProduct.GetRateProfileProduct(Guid.Parse(StrRateProfileID), Guid.Parse(item.ProductID.ToString()));

                        String Strprice = "0";
                        
                        Strprice = (Larate4.RentRate != null) ? Larate4.RentRate.ToString() : "0";


                        if (Strprice != null)
                        {
                             TempRow["30DayRent"] = Strprice;
                        }


                        double a, b, total;
                        total = 0;
                        a = Convert.ToDouble(item.Quantity.ToString());
                        b = Convert.ToDouble((Strprice));

                        if (a != 0 && b != 0)
                        {
                            total = a * b;
                        }

                        if (total != 0)
                        {
                            //TempRow["Total"] = total.ToString();
                        }



                        tb_Productos.Rows.Add(TempRow);                       
                    }


                    DataTable dtsalida = new DataTable();

                    tb_Productos.DefaultView.Sort = "Datet Desc";
                    dtsalida = tb_Productos.DefaultView.ToTable();

                    dataSetProd.Clear();
                    dataSetProd.Tables.Add(dtsalida);
                    dataSetProd.AcceptChanges();


                    //StockingLocation Local = StockingLocation.GetStockingLocation(Guid.Parse(StrStockingLocation), true, true);

                    //dataSetBpat.AcceptChanges();


                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;                   

                    string myJson = JsonConvert.SerializeObject(dataSetProd, settings);

                    Salida = myJson;




                }
                else
                {
                    Salida = "Error de Acceso";
                }



            }
            catch (Exception ex)
            {
                Salida = ex.InnerException.ToString();

            }

            return Salida;


        }

        public string GetInvoicesByTradingPatner(String StrCodPais, String StrUser, String Strpass, String StrTradingPartnerID, String StrStockLocatinID)
        {

            string Salida = "";

            try
            {
                AvontusPrincipal.Logout();
                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = StrUser; // ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = Strpass; // ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);



                InvoiceList Facturas = InvoiceList.GetInvoiceList(InvoiceSyncStatus.All, InvoiceExportStatus.All, Guid.Parse(StrTradingPartnerID), true);

            
               // StockingLocation Local2 = StockingLocation.GetStockingLocation(Guid.Parse(TradingPartnerID), true, true);
               //*Configuracion Dataset Salida*//
                DataSet dataSetBpat = new DataSet("Ds_Shipments");
                dataSetBpat.Namespace = "Quantify";
                DataTable table_Shioment = new DataTable();
                table_Shioment.TableName = "Shipments";

                DataColumn idColumn = new DataColumn("id", typeof(string));
                DataColumn NumberColumn = new DataColumn("Number", typeof(string));
                DataColumn FromColumn = new DataColumn("From", typeof(string));
                DataColumn FromnroColumn = new DataColumn("From No", typeof(string));
                DataColumn ToColumn = new DataColumn("To", typeof(string));
                DataColumn ToNroColumn = new DataColumn("To No", typeof(string));
                DataColumn ReveivedColumn = new DataColumn("Received", typeof(string));
                DataColumn RentStartColumn = new DataColumn("Rent Start", typeof(string));
                DataColumn RentStopColumn = new DataColumn("Rent Stop Return", typeof(string));
                DataColumn OrderColumn = new DataColumn("Order", typeof(string));



                //DataColumn BusinessPartnerIDColumn = new DataColumn("BusinessPartnerID", typeof(string));                
                idColumn.AutoIncrement = true;


                table_Shioment.Columns.Add(idColumn);
                table_Shioment.Columns.Add(NumberColumn);
                table_Shioment.Columns.Add(FromColumn);
                table_Shioment.Columns.Add(FromnroColumn);
                table_Shioment.Columns.Add(ToColumn);
                table_Shioment.Columns.Add(ToNroColumn);
                table_Shioment.Columns.Add(ReveivedColumn);
                table_Shioment.Columns.Add(RentStartColumn);
                table_Shioment.Columns.Add(RentStopColumn);
                table_Shioment.Columns.Add(OrderColumn);

                //tableBpat.Columns.Add(BusinessPartnerIDColumn);               
                dataSetBpat.Tables.Add(table_Shioment);


                List<InvoiceListItem> Llimpia = new List<InvoiceListItem>();

                if (success)
                {
                    AvontusUser AvUser = AvontusUser.GetUser(StrUsrQtfy);

                    Salida = JsonConvert.SerializeObject(Facturas, Formatting.Indented);

                    foreach (InvoiceListItem item in Facturas)
                    {
                        Invoice Factura = Invoice.GetInvoice(Guid.Parse(item.InvoiceID.ToString()), true);

                        if (Factura.BillingLocationID.ToString() == StrStockLocatinID)
                        {

                            Llimpia.Add(item);
                        }



                    }


                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;

                    BoolConverter aa = new BoolConverter();

                    
                    string myJson = JsonConvert.SerializeObject(Llimpia, typeof(InvoiceListItem),settings);




                    Salida = myJson;


                }
                else
                {
                    Salida = "Error de Acceso";
                }



            }
            catch (Exception ex)
            {
                Salida = ex.InnerException.ToString();

            }

            return Salida;

        }

        public string GetShipingbylocation(String StrCodPais, String StrUser, String Strpass, String StrStockingLocation)
        {

            string Salida = "";

            try
            {
                AvontusPrincipal.Logout();
                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = StrUser; // ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = Strpass; // ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);



                /*
                 Number -  -  - . -  -  -  - - - Order

                 */

                //*Configuracion Dataset Salida*//
                DataSet dataSetBpat = new DataSet("Ds_Shipments");
                dataSetBpat.Namespace = "Quantify";
                DataTable table_Shioment = new DataTable();
                table_Shioment.TableName = "Shipments";

                DataColumn idColumn = new DataColumn("id", typeof(string));

                DataColumn ShipmentIdColumn = new DataColumn("ShipmentId", typeof(string));




                DataColumn NumberColumn = new DataColumn("Number", typeof(string));
                DataColumn StatusColumn = new DataColumn("Status", typeof(string));

                DataColumn FromColumn = new DataColumn("From", typeof(string));
                DataColumn FromnroColumn = new DataColumn("From No", typeof(string));
                DataColumn ToColumn = new DataColumn("To", typeof(string));
                DataColumn ToNroColumn = new DataColumn("To No", typeof(string));
                DataColumn ReveivedColumn = new DataColumn("Received", typeof(string));
                DataColumn RentStartColumn = new DataColumn("Rent Start", typeof(string));
                DataColumn RentStopColumn = new DataColumn("Rent Stop Return", typeof(string));
                DataColumn OrderColumn = new DataColumn("Order", typeof(string));



                //DataColumn BusinessPartnerIDColumn = new DataColumn("BusinessPartnerID", typeof(string));                
                idColumn.AutoIncrement = true;


                table_Shioment.Columns.Add(idColumn);
                table_Shioment.Columns.Add(ShipmentIdColumn);

                // DataColumn  = new DataColumn("Shipmentid", typeof(string));



                table_Shioment.Columns.Add(NumberColumn);
                table_Shioment.Columns.Add(StatusColumn);

                table_Shioment.Columns.Add(FromColumn);
                table_Shioment.Columns.Add(FromnroColumn);
                table_Shioment.Columns.Add(ToColumn);
                table_Shioment.Columns.Add(ToNroColumn);
                table_Shioment.Columns.Add(ReveivedColumn);
                table_Shioment.Columns.Add(RentStartColumn);
                table_Shioment.Columns.Add(RentStopColumn);
                table_Shioment.Columns.Add(OrderColumn);

                //tableBpat.Columns.Add(BusinessPartnerIDColumn);               
                dataSetBpat.Tables.Add(table_Shioment);

                if (success)
                {
                    AvontusUser AvUser = AvontusUser.GetUser(StrUsrQtfy);
                    BusinessPartnerComboList BpatList = BusinessPartnerComboList.GetCustomerComboList(Guid.Empty, ActiveStatus.Active, ActiveStatus.Active, false, false);



                    StockingLocation Local = StockingLocation.GetStockingLocation(Guid.Parse(StrStockingLocation), true, true);


                    ShipmentList Slist = ShipmentList.GetShipmentList(Local.StockingLocationID);
                    ShipmentList Slist2 = ShipmentList.GetShipmentList(Guid.Parse(Local.StockingLocationID.ToString()));


                    foreach (ShipmentListItem reparto in Slist)
                    {

                        //obtener empresa 
                        StockingLocation Loc = StockingLocation.GetStockingLocation(reparto.FromStockingLocationID.ToString());
                        //StockingLocation Lo2c = StockingLocation.GetStockingLocation(Guid.Parse(reparto.FromStockingLocationID.ToString()));

                        StockingLocation FromPlace = StockingLocation.GetStockingLocation(Guid.Parse(reparto.FromStockingLocationID.ToString()), true, true);
                        StockingLocation ToPlace = StockingLocation.GetStockingLocation(Guid.Parse(reparto.ToStockingLocationID.ToString()), true, true);



                        //reparto.ToLocationNumber = ToPlace.Number;
                        //reparto.Driver ="dummy";

                        DataRow TempRow = table_Shioment.NewRow();

                        //TempRow["id"] = "";
                        TempRow["Number"] = reparto.ShipmentNumber.ToString();
                        TempRow["ShipmentId"] = reparto.ShipmentID.ToString();
                        TempRow["Status"] = reparto.ShipmentStatusText.ToString();
                        TempRow["From"] = FromPlace.FormattedName.ToString();
                        TempRow["From No"] = FromPlace.Number.ToString();
                        TempRow["To"] = ToPlace.FormattedName.ToString();
                        TempRow["To No"] = ToPlace.Number.ToString();
                        TempRow["Received"] = reparto.ReceiveDate.ToShortDateString();
                        TempRow["Rent Start"] = reparto.RentStartDate.ToShortDateString();
                        TempRow["Rent Stop Return"] = reparto.ReturnRentStopDate.ToShortDateString();




                        string StrTempOrd = "";
                        if (reparto.OrderID.ToString() != "00000000-0000-0000-0000-000000000000")
                        {
                            Order Ord = Order.GetOrder(Guid.Parse(reparto.OrderID.ToString()));

                            StrTempOrd = Ord.DisplayName.ToString();
                        }

                        TempRow["Order"] = StrTempOrd;

                        //string StrCodpaisUPER = "";
                        //StrCodpaisUPER = StrCodPais.ToUpper();
                        //if (StrCodpaisUPER == "CL") // || StrCodpaisUPER == "PE")
                        //{

                        //    string SearchString = "RETORNO";
                        //    int FirstChr = reparto.ShipmentNumber.IndexOf(SearchString);
                        //    if (FirstChr == 0)
                        //    {
                        //        table_Shioment.Rows.Add(TempRow);
                        //    }


                        //}
                        //else
                        //{
                            table_Shioment.Rows.Add(TempRow);
                       // }

                        

                    }



                    dataSetBpat.AcceptChanges();




                    //string Salida2 = JsonConvert.SerializeObject(dataSetBpat, Formatting.Indented);
                    //Salida = JsonConvert.SerializeObject(Slist, Formatting.Indented);
                    //Salida = Salida2;
                    Salida = JsonConvert.SerializeObject(dataSetBpat, Formatting.Indented); 




                }
                else
                {
                    Salida = "Error de Acceso";
                }



            }
            catch (Exception ex)
            {
                Salida = ex.InnerException.ToString();

            }

            return Salida;

        }

        public string GetShipingbylocationDeliveries(String StrCodPais, String StrUser, String Strpass, String StrStockingLocation)
        {


            string Salida = "";

            try
            {
                AvontusPrincipal.Logout();
                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = StrUser; // ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = Strpass; // ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);



                /*
                 Number -  -  - . -  -  -  - - - Order

                 */

                //*Configuracion Dataset Salida*//
                DataSet dataSetBpat = new DataSet("Ds_Shipments");
                dataSetBpat.Namespace = "Quantify";
                DataTable table_Shioment = new DataTable();
                table_Shioment.TableName = "Shipments";

                DataColumn idColumn = new DataColumn("id", typeof(string));

                DataColumn ShipmentIdColumn = new DataColumn("ShipmentId", typeof(string));




                DataColumn NumberColumn = new DataColumn("Number", typeof(string));
                DataColumn StatusColumn = new DataColumn("Status", typeof(string));

                DataColumn FromColumn = new DataColumn("From", typeof(string));
                DataColumn FromnroColumn = new DataColumn("From No", typeof(string));
                DataColumn ToColumn = new DataColumn("To", typeof(string));
                DataColumn ToNroColumn = new DataColumn("To No", typeof(string));
                DataColumn ReveivedColumn = new DataColumn("Received", typeof(string));
                DataColumn RentStartColumn = new DataColumn("Rent Start", typeof(string));
                DataColumn RentStopColumn = new DataColumn("Rent Stop Return", typeof(string));
                DataColumn OrderColumn = new DataColumn("Order", typeof(string));



                //DataColumn BusinessPartnerIDColumn = new DataColumn("BusinessPartnerID", typeof(string));                
                idColumn.AutoIncrement = true;


                table_Shioment.Columns.Add(idColumn);
                table_Shioment.Columns.Add(ShipmentIdColumn);

                // DataColumn  = new DataColumn("Shipmentid", typeof(string));



                table_Shioment.Columns.Add(NumberColumn);
                table_Shioment.Columns.Add(StatusColumn);

                table_Shioment.Columns.Add(FromColumn);
                table_Shioment.Columns.Add(FromnroColumn);
                table_Shioment.Columns.Add(ToColumn);
                table_Shioment.Columns.Add(ToNroColumn);
                table_Shioment.Columns.Add(ReveivedColumn);
                table_Shioment.Columns.Add(RentStartColumn);
                table_Shioment.Columns.Add(RentStopColumn);
                table_Shioment.Columns.Add(OrderColumn);

                //tableBpat.Columns.Add(BusinessPartnerIDColumn);               
                dataSetBpat.Tables.Add(table_Shioment);

                if (success)
                {
                    AvontusUser AvUser = AvontusUser.GetUser(StrUsrQtfy);
                    BusinessPartnerComboList BpatList = BusinessPartnerComboList.GetCustomerComboList(Guid.Empty, ActiveStatus.Active, ActiveStatus.Active, false, false);



                    StockingLocation Local = StockingLocation.GetStockingLocation(Guid.Parse(StrStockingLocation), true, true);


                    ShipmentList Slist = ShipmentList.GetShipmentList(Local.StockingLocationID);
                    ShipmentList Slist2 = ShipmentList.GetShipmentList(Guid.Parse(Local.StockingLocationID.ToString()));


                    foreach (ShipmentListItem reparto in Slist)
                    {

                        //obtener empresa 
                        StockingLocation Loc = StockingLocation.GetStockingLocation(reparto.FromStockingLocationID.ToString());
                        //StockingLocation Lo2c = StockingLocation.GetStockingLocation(Guid.Parse(reparto.FromStockingLocationID.ToString()));

                        StockingLocation FromPlace = StockingLocation.GetStockingLocation(Guid.Parse(reparto.FromStockingLocationID.ToString()), true, true);
                        StockingLocation ToPlace = StockingLocation.GetStockingLocation(Guid.Parse(reparto.ToStockingLocationID.ToString()), true, true);



                        //reparto.ToLocationNumber = ToPlace.Number;
                        //reparto.Driver ="dummy";

                        DataRow TempRow = table_Shioment.NewRow();

                        //TempRow["id"] = "";
                        TempRow["Number"] = reparto.ShipmentNumber.ToString();
                        TempRow["ShipmentId"] = reparto.ShipmentID.ToString();
                        TempRow["Status"] = reparto.ShipmentStatusText.ToString();
                        TempRow["From"] = FromPlace.FormattedName.ToString();
                        TempRow["From No"] = FromPlace.Number.ToString();
                        TempRow["To"] = ToPlace.FormattedName.ToString();
                        TempRow["To No"] = ToPlace.Number.ToString();
                        TempRow["Received"] = reparto.ReceiveDate.ToShortDateString();
                        TempRow["Rent Start"] = reparto.RentStartDate.ToShortDateString();
                        TempRow["Rent Stop Return"] = reparto.ReturnRentStopDate.ToShortDateString();




                        string StrTempOrd = "";
                        if (reparto.OrderID.ToString() != "00000000-0000-0000-0000-000000000000")
                        {
                            Order Ord = Order.GetOrder(Guid.Parse(reparto.OrderID.ToString()));

                            StrTempOrd = Ord.DisplayName.ToString();
                        }

                        TempRow["Order"] = StrTempOrd;

                        string StrCodpaisUPER = "";
                        StrCodpaisUPER = StrCodPais.ToUpper();
                        if (StrCodpaisUPER == "CL" || StrCodpaisUPER == "PE")
                        {

                            string SearchString = "RETORNO";
                            int FirstChr = reparto.ShipmentNumber.IndexOf(SearchString);
                            if (FirstChr == 0)
                            {
                                table_Shioment.Rows.Add(TempRow);
                            }


                        }
                        else
                        {
                            table_Shioment.Rows.Add(TempRow);
                        }

                        //HACK PARA PERU 

                        if (StrCodpaisUPER == "PE" )
                        {

                            string SearchString = "RET";
                            int FirstChr = reparto.ShipmentNumber.IndexOf(SearchString);
                            if (FirstChr == 0)
                            {
                                table_Shioment.Rows.Add(TempRow);
                            }


                        }
                        //else
                        //{
                        //    table_Shioment.Rows.Add(TempRow);
                        //}


                    }



                    dataSetBpat.AcceptChanges();




                    //string Salida2 = JsonConvert.SerializeObject(dataSetBpat, Formatting.Indented);
                    //Salida = JsonConvert.SerializeObject(Slist, Formatting.Indented);
                    //Salida = Salida2;
                    Salida = JsonConvert.SerializeObject(dataSetBpat, Formatting.Indented);




                }
                else
                {
                    Salida = "Error de Acceso";
                }



            }
            catch (Exception ex)
            {
                Salida = ex.InnerException.ToString();

            }

            return Salida;



        }

        public string GetShipingbyId(String StrCodPais, String StrUser, String Strpass, String StrStockingLocation, String StrShipID)
        {

            string Salida = "";


            /*
      string filterExp = "Status = 'Active'";
string sortExp = "City";
*/

         try
         {
             AvontusPrincipal.Logout();
             string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
             string strdbname;
             strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
             System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
             builder.ConnectionString = Conex;
             builder.DataSource = strdbname;

             //Base de Datos Rotativa                                
             Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
             String StrUsrQtfy = StrUser; // ConfigurationManager.AppSettings["UsrQtfy"];
             String StrPassQtfy = Strpass; // ConfigurationManager.AppSettings["PassQtfy"];
             bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);



             /*
              Number -  -  - . -  -  -  - - - Order

              */

            //*Configuracion Dataset Salida*//
            DataSet dataSetBpat = new DataSet("Ds_Shipments");
                dataSetBpat.Namespace = "Quantify";
                DataTable table_Shioment = new DataTable();
                table_Shioment.TableName = "Shipments";

                DataColumn idColumn = new DataColumn("id", typeof(string));

                DataColumn ShipmentIdColumn = new DataColumn("ShipmentId", typeof(string));




                DataColumn NumberColumn = new DataColumn("Number", typeof(string));
                DataColumn StatusColumn = new DataColumn("Status", typeof(string));

                DataColumn FromColumn = new DataColumn("From", typeof(string));
                DataColumn FromnroColumn = new DataColumn("From No", typeof(string));
                DataColumn ToColumn = new DataColumn("To", typeof(string));
                DataColumn ToNroColumn = new DataColumn("To No", typeof(string));
                DataColumn ReveivedColumn = new DataColumn("Received", typeof(string));
                DataColumn RentStartColumn = new DataColumn("Rent Start", typeof(string));
                DataColumn RentStopColumn = new DataColumn("Rent Stop Return", typeof(string));
                DataColumn OrderColumn = new DataColumn("Order", typeof(string));

                DataColumn FechaColumn = new DataColumn("Fecha", typeof(string));
                DataColumn ClienteColumn = new DataColumn("Cliente", typeof(string));
                DataColumn DireColumn = new DataColumn("Dire", typeof(string));
                DataColumn GiroColumn = new DataColumn("Giro", typeof(string));
                DataColumn TelColumn = new DataColumn("Tel", typeof(string));
                DataColumn AdmColumn = new DataColumn("Adm", typeof(string));
                DataColumn DespaColumn = new DataColumn("Despa", typeof(string));
                DataColumn NotaColumn = new DataColumn("Nota", typeof(string));
                DataColumn NroCliColumn = new DataColumn("NroCli", typeof(string));
                DataColumn RfcCliColumn = new DataColumn("Rfc", typeof(string));
                DataColumn CiudadColumn = new DataColumn("Ciudad", typeof(string));
                DataColumn ObCliColumn = new DataColumn("Obra", typeof(string));
                DataColumn NroObraColumn = new DataColumn("NroObra", typeof(string));
                DataColumn NroObraCliColumn = new DataColumn("Empresa", typeof(string));
                DataColumn PlacaColumn = new DataColumn("Placa", typeof(string));





                //DataColumn BusinessPartnerIDColumn = new DataColumn("BusinessPartnerID", typeof(string));                
                idColumn.AutoIncrement = true;


                table_Shioment.Columns.Add(idColumn);
                table_Shioment.Columns.Add(ShipmentIdColumn);

                // DataColumn  = new DataColumn("Shipmentid", typeof(string));



                table_Shioment.Columns.Add(NumberColumn);
                table_Shioment.Columns.Add(StatusColumn);

                table_Shioment.Columns.Add(FromColumn);
                table_Shioment.Columns.Add(FromnroColumn);
                table_Shioment.Columns.Add(ToColumn);
                table_Shioment.Columns.Add(ToNroColumn);
                table_Shioment.Columns.Add(ReveivedColumn);
                table_Shioment.Columns.Add(RentStartColumn);
                table_Shioment.Columns.Add(RentStopColumn);
                table_Shioment.Columns.Add(OrderColumn);


                table_Shioment.Columns.Add(FechaColumn);
                table_Shioment.Columns.Add(ClienteColumn);
                table_Shioment.Columns.Add(DireColumn);
                table_Shioment.Columns.Add(GiroColumn);
                table_Shioment.Columns.Add(TelColumn);
                table_Shioment.Columns.Add(AdmColumn);
                table_Shioment.Columns.Add(DespaColumn);
                table_Shioment.Columns.Add(NotaColumn);
                table_Shioment.Columns.Add(NroCliColumn);
                table_Shioment.Columns.Add(RfcCliColumn);
                table_Shioment.Columns.Add(CiudadColumn);
                table_Shioment.Columns.Add(ObCliColumn);
                table_Shioment.Columns.Add(NroObraColumn);
                table_Shioment.Columns.Add(NroObraCliColumn);
                table_Shioment.Columns.Add(PlacaColumn);

                //tableBpat.Columns.Add(BusinessPartnerIDColumn);       


                //ADITIONAL CHARGES
                //SE AGREGA ADITION CHANGES !!! 


                DataTable table_AdditionalCharges = new DataTable();
                table_AdditionalCharges.TableName = "AdditionalCharges";

                DataColumn idCol_ = new DataColumn("id", typeof(string));

                DataColumn PartNumberCol_ = new DataColumn("Name", typeof(string));
                DataColumn DescriptionCol_ = new DataColumn("Description", typeof(string));
                DataColumn WeightCol_ = new DataColumn("Weight", typeof(string));
                DataColumn UnitCol_ = new DataColumn("Uni", typeof(string));
                DataColumn UnitPriceCol_ = new DataColumn("UnitPrice", typeof(string));
                DataColumn NroUnitsCol_ = new DataColumn("NroUnits", typeof(string));
                DataColumn TaxableCol_ = new DataColumn("Taxable", typeof(string));
                DataColumn Total_ = new DataColumn("Total", typeof(string));


                idCol_.AutoIncrement = true;


                table_AdditionalCharges.Columns.Add(idCol_);
                table_AdditionalCharges.Columns.Add(PartNumberCol_);
                table_AdditionalCharges.Columns.Add(DescriptionCol_);
                table_AdditionalCharges.Columns.Add(WeightCol_);
                table_AdditionalCharges.Columns.Add(UnitCol_);
                table_AdditionalCharges.Columns.Add(UnitPriceCol_);
                table_AdditionalCharges.Columns.Add(NroUnitsCol_);
                table_AdditionalCharges.Columns.Add(TaxableCol_);
                table_AdditionalCharges.Columns.Add(Total_);




                if (success)
                {
                    AvontusUser AvUser = AvontusUser.GetUser(StrUsrQtfy);
                    BusinessPartnerComboList BpatList = BusinessPartnerComboList.GetCustomerComboList(Guid.Empty, ActiveStatus.Active, ActiveStatus.Active, false, false);



                    StockingLocation Local = StockingLocation.GetStockingLocation(Guid.Parse(StrStockingLocation), true, true);


                    ShipmentList Slist = ShipmentList.GetShipmentList(Local.StockingLocationID);
                    ShipmentList Slist2 = ShipmentList.GetShipmentList(Guid.Parse(Local.StockingLocationID.ToString()));


                    foreach (ShipmentListItem reparto in Slist)
                    {

                        



                        string StrTempOrd = "";
                        if (reparto.OrderID.ToString() != "00000000-0000-0000-0000-000000000000")
                        {
                            Order Ord = Order.GetOrder(Guid.Parse(reparto.OrderID.ToString()));
                                                       Ord = Order.GetOrder(Guid.Parse(reparto.OrderID.ToString()));



                            

                            StrTempOrd = Ord.DisplayName.ToString();
                        }





                        //obtener empresa 
                        StockingLocation Loc = StockingLocation.GetStockingLocation(reparto.FromStockingLocationID.ToString());
                        //StockingLocation Lo2c = StockingLocation.GetStockingLocation(Guid.Parse(reparto.FromStockingLocationID.ToString()));

                        StockingLocation FromPlace = StockingLocation.GetStockingLocation(Guid.Parse(reparto.FromStockingLocationID.ToString()), true, true);
                        StockingLocation ToPlace = StockingLocation.GetStockingLocation(Guid.Parse(reparto.ToStockingLocationID.ToString()), true, true);


                        if (reparto.ShipmentID.ToString() == StrShipID)
                        {

             

                            //--------
                            //hay que dar vuelta los ORder si son DEV o DES 
                            //hay que confirmar eso . 




                            String StrOperation = "";

                            StrOperation = reparto.ShipmentNumber.ToString();
                            StrOperation = StrOperation.Substring(0, 3);

                            BusinessPartner BpFromLocation = BusinessPartner.GetBusinessPartner(Guid.Parse(FromPlace.BusinessPartnerID.ToString()));
                            BusinessPartner BpToLocation = BusinessPartner.GetBusinessPartner(Guid.Parse(ToPlace.BusinessPartnerID.ToString()));
                            //creacion de la fila 
                            DataRow TempRow = table_Shioment.NewRow();
                            String StrNroCli = "";



                            String StrObra = ""; 
                           
                            String StrNroObra = "";
                            
                            
                            

                            //busqeuda additional charges
                            ShipmentUnitPricePivotList ListAditionalCharges = ShipmentUnitPricePivotList.GetShipmentUnitPricePivotList(Guid.Parse(FromPlace.TradingPartnerID.ToString()), ShipmentStatusType.ShowAll, false);
                            JobsitePropertiesItem jsite = JobsitePropertiesItem.GetJobsitePropertiesItem(Guid.Parse(reparto.ToStockingLocationID.ToString()));

                            
                            




                            switch (StrOperation)
                            {

                                case "DEV":
                                    //EN LA DEVOLUCION SE DEVEN INVERTIR EL  FORM Y EL TO 
                                     BpFromLocation = BusinessPartner.GetBusinessPartner(Guid.Parse(ToPlace.BusinessPartnerID.ToString()));
                                     BpToLocation = BusinessPartner.GetBusinessPartner(Guid.Parse(FromPlace.BusinessPartnerID.ToString()));
                                    ListAditionalCharges = ShipmentUnitPricePivotList.GetShipmentUnitPricePivotList(Guid.Parse(FromPlace.TradingPartnerID.ToString()), ShipmentStatusType.ShowAll, false);
                                    StrNroCli = (BpToLocation.PartnerNumber != null) ? BpToLocation.PartnerNumber.ToString() : "No Data";
                                    TempRow["NroCli"] = StrNroCli;

                                    TempRow["Obra"] = (FromPlace.Name != null) ? FromPlace.Name.ToString() : "No Data"; 
                                    TempRow["NroObra"] = (FromPlace.Number != null) ? FromPlace.Number.ToString() : "No Data";
                                    

                                    break;

                                case "RET":
                                    //EN LA DEVOLUCION SE DEVEN INVERTIR EL  FORM Y EL TO 
                                    BpFromLocation = BusinessPartner.GetBusinessPartner(Guid.Parse(ToPlace.BusinessPartnerID.ToString()));
                                    BpToLocation = BusinessPartner.GetBusinessPartner(Guid.Parse(FromPlace.BusinessPartnerID.ToString()));
                                    ListAditionalCharges = ShipmentUnitPricePivotList.GetShipmentUnitPricePivotList(Guid.Parse(FromPlace.TradingPartnerID.ToString()), ShipmentStatusType.ShowAll, false);
                                    StrNroCli = (BpToLocation.PartnerNumber != null) ? BpToLocation.PartnerNumber.ToString() : "No Data";
                                    TempRow["NroCli"] = StrNroCli;

                                    TempRow["Obra"] = (FromPlace.Name != null) ? FromPlace.Name.ToString() : "No Data";
                                    TempRow["NroObra"] = (FromPlace.Number != null) ? FromPlace.Number.ToString() : "No Data";
                                    
                                    jsite = JobsitePropertiesItem.GetJobsitePropertiesItem(Guid.Parse(reparto.FromStockingLocationID.ToString()));











                                    break;
                                case "DES":
                                     BpFromLocation = BusinessPartner.GetBusinessPartner(Guid.Parse(FromPlace.BusinessPartnerID.ToString()));
                                     BpToLocation = BusinessPartner.GetBusinessPartner(Guid.Parse(ToPlace.BusinessPartnerID.ToString()));
                                    ListAditionalCharges = ShipmentUnitPricePivotList.GetShipmentUnitPricePivotList(Guid.Parse(ToPlace.TradingPartnerID.ToString()), ShipmentStatusType.ShowAll, false);

                                    StrNroCli = (BpToLocation.PartnerNumber != null) ? BpToLocation.PartnerNumber.ToString() : "No Data";
                                    TempRow["NroCli"] = StrNroCli;

                                    TempRow["Obra"] = (ToPlace.Name != null) ? ToPlace.Name.ToString() : "No Data";
                                    TempRow["NroObra"] = (ToPlace.Number != null) ? ToPlace.Number.ToString() : "No Data";

                                    break;

                            }






                            //reparto.ToLocationNumber = ToPlace.Number;
                            //reparto.Driver ="dummy";
                                                      
                            // String StrDescription = (Prodname.Description != null) ? Prodname.Description.ToString() : "NoName";

                            //TempRow["id"] = "";
                            String StrNumber = (reparto.ShipmentNumber != null) ? reparto.ShipmentNumber.ToString() : "No Data"; 
                            TempRow["Number"] = StrNumber;

                            String StrShipmentId = (reparto.ShipmentID != null) ? reparto.ShipmentID.ToString() : "No Data";
                            TempRow["ShipmentId"] = StrShipmentId;

                            String StrStatus = (reparto.ShipmentStatusText != null) ? reparto.ShipmentStatusText.ToString() : "No Data";
                            TempRow["Status"] = StrStatus;

                            String StrFrom = (FromPlace.FormattedName != null) ? FromPlace.FormattedName.ToString() : "No Data";
                            TempRow["From"] = StrFrom;

                            String StrFromNro = (FromPlace.Number != null) ? FromPlace.Number.ToString() : "No Data";
                            TempRow["From No"] = StrFromNro;

                            String StrTo = (ToPlace.FormattedName != null) ? ToPlace.FormattedName.ToString() : "No Data";
                            TempRow["To"] = StrTo;

                            String StrToNro = (ToPlace.Number != null) ? ToPlace.Number.ToString() : "No Data";
                            TempRow["To No"] = StrToNro;

                            String StrReceived = (reparto.ReceiveDate != null) ? reparto.ReceiveDate.ToString() : "No Data";
                            TempRow["Received"] = StrReceived;

                            String StrRentStart = (reparto.RentStartDate != null) ? reparto.RentStartDate.ToString() : "No Data";
                            TempRow["Rent Start"] = StrRentStart;

                            String StrStopReturn = (reparto.ReturnRentStopDate != null) ? reparto.ReturnRentStopDate.ToString() : "No Data";
                            TempRow["Rent Stop Return"] = StrStopReturn;

                            String StrFecha = (reparto.ActualShipDate != null) ? reparto.ActualShipDate.ToString() : "No Data";
                            TempRow["Fecha"] = StrFecha;

                            String StrCliente = (BpToLocation.Name != null) ? BpToLocation.Name.ToString() : "No Data";
                            TempRow["Cliente"] = StrCliente;

                            String StrDire = (BpToLocation.BusinessStreet != null) ? BpToLocation.BusinessStreet.ToString() : "No Data";
                            TempRow["Dire"] = StrDire;

                           // String StrGiro = (reparto.ShipmentNumber != null) ? reparto.ShipmentNumber.ToString() : "No Data";
                            TempRow["Giro"] = "No Disponible.";

                            String StrTel = (BpToLocation.PhoneNumber != null) ? BpToLocation.PhoneNumber.ToString() : "No Data";
                            TempRow["Tel"] = StrTel;

                            String StrAdm = (jsite.JobEmployee1 != null) ? jsite.JobEmployee1.ToString() : "No Data";
                            TempRow["Adm"] = StrAdm;

                            String StrDespa = (reparto.CreatedByName != null) ? reparto.CreatedByName.ToString() : "No Data";
                            TempRow["Despa"] = StrDespa;

                            String StrNota = (reparto.Notes != null) ? reparto.Notes.ToString() : "No Data";
                            TempRow["Nota"] = StrNota;

                           

                            //String StrRfc = (reparto.ShipmentNumber != null) ? reparto.ShipmentNumber.ToString() : "No Data";
                            TempRow["Rfc"] = "No Disponible";

                            String StrCiduad = (BpToLocation.BusinessState != null) ? BpToLocation.BusinessState.ToString() : "No Data";
                            TempRow["Ciudad"] = StrCiduad;

                          

                            /* transporte  */

                            //String StrEmpresa = (BpFromLocation.Name != null) ? BpFromLocation.Name.ToString() : "No Data";
                            TempRow["Empresa"] = "No Disponible"; 

                            //String StrPlace = (reparto.ShipmentNumber != null) ? reparto.ShipmentNumber.ToString() : "No Data";
                            TempRow["Placa"] = "No Disponible";

                            //String StrORder = (reparto.ShipmentNumber != null) ? reparto.ShipmentNumber.ToString() : "No Data";
                            TempRow["Order"] = StrTempOrd;
                            table_Shioment.Rows.Add(TempRow);


                     

                            foreach (ShipmentUnitPricePivotListItem item in ListAditionalCharges)
                            {

                                if (item.ShipmentNumber == reparto.ShipmentNumber)
                                {

                                    UnitPrice upp = UnitPrice.GetUnitPrice(Guid.Parse(item.BaseUnitPriceID.ToString()));


                                    DataRow TempRow_ = table_AdditionalCharges.NewRow();
                                    String StrName = (item.UnitPriceName != null) ? item.UnitPriceName.ToString() : "No Data";
                                    TempRow_["Name"] = StrName;

                                    String StrDescription = (item.Description != null) ? item.Description.ToString() : "No Data";
                                    TempRow_["Description"] = StrDescription;

                                    String StrWeight = (item.Weight != null) ? item.Weight.ToString() : "No Data";
                                    TempRow_["Weight"] = StrWeight;

                                    String StrUnit = (item.Units != null) ? item.Units.ToString() : "No Data";
                                    TempRow_["Uni"] = StrUnit;

                                    String StrUnitPrice = (item.PricePerUnit != 0) ? item.PricePerUnit.ToString() : "No Data";
                                    TempRow_["UnitPrice"] = StrUnitPrice;


                                    String StrNroUnits = (item.NumberOfUnits != null) ? item.NumberOfUnits.ToString() : "No Data";
                                    TempRow_["NroUnits"] = StrNroUnits;

                                    String StrTaxableCol = (upp.IsTaxable != null) ? upp.IsTaxable.ToString() : "No Data";
                                    TempRow_["Taxable"] = StrTaxableCol;

                                    String StrTotal = (item.TotalPrice != null) ? item.TotalPrice.ToString() : "No Data";
                                    TempRow_["Total"] = StrTotal;



                                    table_AdditionalCharges.Rows.Add(TempRow_);
                                }

                                





                            }









                         



                        }





                    }



                    //ShipmentList Slist2 = ShipmentList.GetShipmentList(Guid.Parse(Local.StockingLocationID.ToString()));

                    /*Concatenar shipment consumables*/

                    DataTable table_consumables = new DataTable();
                    table_consumables.TableName = "consumables";

                    DataColumn idCol = new DataColumn("id", typeof(string));

                    DataColumn PartNumberCol = new DataColumn("PartNumber", typeof(string));
                    DataColumn DescriptionCol = new DataColumn("Description", typeof(string));
                    DataColumn WeightCol = new DataColumn("Weight", typeof(string));
                    DataColumn ReservedCol = new DataColumn("Reserved", typeof(string));
                    DataColumn SentCol = new DataColumn("Sent", typeof(string));
                    DataColumn SellCol = new DataColumn("Sell", typeof(string));


                    idCol.AutoIncrement = true;


                    table_consumables.Columns.Add(idCol);
                    table_consumables.Columns.Add(PartNumberCol);
                    table_consumables.Columns.Add(DescriptionCol);
                    table_consumables.Columns.Add(WeightCol);
                    table_consumables.Columns.Add(ReservedCol);
                    table_consumables.Columns.Add(SentCol);
                    table_consumables.Columns.Add(SellCol);


                   

                    Shipment Ship = Shipment.GetShipment(Guid.Parse(StrShipID.ToString()),true,true,true);
                    FilteredBindingList<ShipmentProduct> ConsumableList = Ship.ShipmentConsumables;

                    foreach (ShipmentProduct Prduct in ConsumableList)
                    {

                        

                        DataRow TempRow = table_consumables.NewRow();
                        TempRow["PartNumber"] = Prduct.PartNumber.ToString();
                        TempRow["Description"] = Prduct.Description.ToString();
                        TempRow["Weight"] = Prduct.Weight.ToString();
                        TempRow["Reserved"] = Prduct.ReservedQuantity.ToString();
                        TempRow["Sent"] = Prduct.SentQuantity.ToString();
                        TempRow["Sell"] = Prduct.Sell.ToString();

                        if (Prduct.SentQuantity>0)
                        {
                            table_consumables.Rows.Add(TempRow);
                        }
                        

                    }







                    dataSetBpat.Tables.Add(table_Shioment);
                    dataSetBpat.Tables.Add(table_consumables);
                    dataSetBpat.Tables.Add(table_AdditionalCharges);


                    //obtener los consumbles

                    dataSetBpat.AcceptChanges();

                   




                    //string Salida2 = JsonConvert.SerializeObject(drarray, Formatting.Indented);

                    Salida = JsonConvert.SerializeObject(dataSetBpat, Formatting.Indented);




                }
                else
                {
                    Salida = "Error de Acceso";
                }



            }
            catch (Exception ex)
            {
                Salida = ex.InnerException.ToString();

            }

            return Salida;

        }


     
        public string GetShipingbyId_none(String StrCodPais, String StrUser, String Strpass, String StrShipID)
        {

            string Salida = "";

            try
            {
                AvontusPrincipal.Logout();
                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = StrUser; // ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = Strpass; // ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);


                //get shipment by id 

                //Shipment Ship = Shipment.GetShipment(StrShipID,true,true);               

                
                if (success)
                {


                    Shipment DDD = Shipment.GetShipmentForReport(Guid.Parse(StrShipID));                    
                    Salida = JsonConvert.SerializeObject(DDD, Formatting.None);

                }
                else
                {
                    Salida = "Error de Acceso";
                }



            }
            catch (Exception ex)
            {
                Salida = ex.InnerException.ToString();

            }

            return Salida;

        }
        public string GetLocationsByUser(String StrCodPais, String StrUser, String Strpass)
        {

            string Salida = "";

            try
            {
                AvontusPrincipal.Logout();                
                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = StrUser; // ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = Strpass; // ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);

                if (success)
                {

                    int ii = 0;
                    string StrCodpaisUPER = "";

                    AvontusUser AvUser = AvontusUser.GetUser(StrUsrQtfy);
                    BusinessPartnerComboList BpatList = BusinessPartnerComboList.GetCustomerComboList(Guid.Empty, ActiveStatus.Active, ActiveStatus.Active, false, false);

                    // System.Web.UI.WebControls.TreeView tvOrganization = new System.Web.UI.WebControls.TreeView();
                    System.Windows.Forms.TreeView tvOrganization = new System.Windows.Forms.TreeView();

                    StockingLocationOrganization orgTree = StockingLocationOrganization.GetOrganization(ActiveStatus.Active);
                    orgTree.BuildTreeView(tvOrganization, OrgViewGrouping.ByJob, JobTreeNodeDisplayType.Name, AvUser.RelatedID, AvUser.UserID, AvUser.PrimaryTradingPartnerID);

                    System.Windows.Forms.TreeNode oMainNode = tvOrganization.Nodes[0];


                    NodeTag MainTag = (NodeTag)oMainNode.Tag;


                    DataSet dataSetBpat = new DataSet("Ds_Locations");
                    dataSetBpat.Namespace = "Quantify";
                    DataTable tableBpat = new DataTable();
                    tableBpat.TableName = "Locations";

                    DataColumn idColumn = new DataColumn("id", typeof(string));
                    DataColumn StrStockingLocationIDColumn = new DataColumn("StockingLocationID", typeof(string));
                    DataColumn TradingPartnerIDColumn = new DataColumn("TradingPartnerID", typeof(string));
                    DataColumn nameColumn = new DataColumn("name", typeof(string));
                    DataColumn RateProfileIDColumn = new DataColumn("RateProfileID", typeof(string));
                    DataColumn NroObraBpat = new DataColumn("NroObra", typeof(string));

                    idColumn.AutoIncrement = true;


                    tableBpat.Columns.Add(idColumn);
                    tableBpat.Columns.Add(StrStockingLocationIDColumn);
                    tableBpat.Columns.Add(TradingPartnerIDColumn);
                    tableBpat.Columns.Add(nameColumn);
                    tableBpat.Columns.Add(RateProfileIDColumn);
                    tableBpat.Columns.Add(NroObraBpat);



                    //Agregar Tabla Con Patner

                    //*Configuracion Dataset Salida*//

                    dataSetBpat.Namespace = "Quantify";
                    DataTable TablePatner = new DataTable();
                    TablePatner.TableName = "BusinessPartners";

                    DataColumn idColumnt2 = new DataColumn("id", typeof(string));
                    DataColumn NameColumt2n = new DataColumn("Name", typeof(string));
                    //DataColumn BusinessPartnerIDColumn = new DataColumn("BusinessPartnerID", typeof(string));
                    DataColumn PartnerNumberColumnt2 = new DataColumn("PartnerNumber", typeof(string));
                    DataColumn BillingContactInfoCol = new DataColumn("BillingContactInfo", typeof(string));
                    DataColumn NroObraPat = new DataColumn("NroObra", typeof(string));







                    idColumnt2.AutoIncrement = true;


                    TablePatner.Columns.Add(idColumnt2);
                    TablePatner.Columns.Add(NameColumt2n);
                    //tableBpat.Columns.Add(BusinessPartnerIDColumn);
                    TablePatner.Columns.Add(PartnerNumberColumnt2);
                    TablePatner.Columns.Add(BillingContactInfoCol);
                    TablePatner.Columns.Add(NroObraPat);

                    dataSetBpat.Tables.Add(TablePatner);
                    //aqui x ordem
                    dataSetBpat.Tables.Add(tableBpat);


                    TradingPartner trad = TradingPartner.GetTradingPartner(Guid.Parse(MainTag.TradingPartnerID.ToString()));
                    BusinessPartner bGpat1 = BusinessPartner.GetBusinessPartner(Guid.Parse(trad.BusinessPartnerID.ToString()));


                    //Datos para Factura de empresa 
                    String StrAdress;
                    StrAdress = bGpat1.BillingContactInfo;




                    DataRow TempRw = TablePatner.NewRow();
                    TempRw["Name"] = bGpat1.Name;
                    //Campo  llave para proximas consultas
                    // TempRow["BusinessPartnerID"] = Bpat.BusinessPartnerID.ToString();
                    TempRw["PartnerNumber"] = bGpat1.PartnerNumber.ToString();
                    TempRw["BillingContactInfo"] = StrAdress;




                    //IDENTIFICAR QUE TANTOS HIJOS TIENEN LOS NODOS. 

                    BusinessPartner BpToLocation;
                    String StrNroObra = "";

                    Int32 intctn = 0;

                    //NIVEL 1
                    foreach (System.Windows.Forms.TreeNode item in oMainNode.Nodes)
                    {

                        if (item.Nodes.Count > 0)
                        {
                            // PE
                            //NIVEL2
                            foreach (System.Windows.Forms.TreeNode item2 in item.Nodes)
                            {

                                String StrNode = item2.Name;
                                String StrStockingLocationID = "";
                                String strTradingPartnerID = "";
                                NodeTag Ntag = (NodeTag)item2.Tag;

                                if (item2.Nodes.Count > 0)
                                {
                                    //Nivel 3
                                    foreach (System.Windows.Forms.TreeNode item3 in item2.Nodes)
                                    {

                                        if (item3.Nodes.Count > 0)
                                        //1if(false)
                                        {
                                            //Codigo Nuevo 
                                            foreach (System.Windows.Forms.TreeNode item4 in item3.Nodes)
                                            {
                                            
                                               StrNode = item4.Name;
                                               StrStockingLocationID = "";
                                               strTradingPartnerID = "";
                                                NodeTag Ntag4 = (NodeTag)item4.Tag;
                                                //Crecion de Fila Para Mostar nivel 4 en Front 

                                                StrStockingLocationID = Ntag4.StockingLocationID.ToString();

                                                strTradingPartnerID = Ntag4.TradingPartnerID.ToString();


                                                StrNode = item4.Name;

                                                DataRow TempRow3 = tableBpat.NewRow();
                                                TempRow3["name"] = StrNode;


                                                TempRow3["StockingLocationID"] = StrStockingLocationID;
                                                TempRow3["TradingPartnerID"] = strTradingPartnerID;
                                                StockingLocation Local4 = StockingLocation.GetStockingLocation(Guid.Parse(StrStockingLocationID), true, true);
                                                TempRow3["RateProfileID"] = Local4.DefaultRateProfileID.ToString();

                                                //NroObra Fix                                            
                                                TempRow3["NroObra"] = "";


                                                RateProfileProductList Rlist4 = RateProfileProductList.GetRateProfileProductList(Guid.Parse(Local4.DefaultRateProfileID.ToString()));


                                                //REGLA PARA CHILE 

                                                StrCodpaisUPER = StrCodPais.ToUpper();
                                                if (StrCodpaisUPER == "CL" || StrCodpaisUPER == "PE") // || StrCodpaisUPER == "MX")
                                                {
                                                    //agregar cosas 

                                                    string SearchString = "Consumables";
                                                    string SearchString2 = "Fuera de Servicio";
                                                    string SearchString3 = "Fungibles";

                                                    int FirstChr = StrNode.IndexOf(SearchString);
                                                    int FirstCh2 = StrNode.IndexOf(SearchString2);
                                                    int FirstCh3 = StrNode.IndexOf(SearchString3);

                                                    //NroObra Fix                                                
                                                    StrNroObra = Local4.Number.ToString();
                                                    TempRow3["NroObra"] = StrNroObra;



                                                    if (FirstChr >= 0 || FirstCh2 >= 0) // || FirstCh3 >= 0)
                                                    {
                                                        //no debe hacer nada      
                                                        ii = ii + 1;

                                                    }
                                                    else
                                                    {
                                                        //ii = ii + 1;

                                                        if (StrNroObra != "")
                                                        {
                                                            tableBpat.Rows.Add(TempRow3);
                                                        }

                                                    }



                                                }
                                                else
                                                {
                                                    tableBpat.Rows.Add(TempRow3);
                                                }
                                                //REGLA PARA CHILE 

                                            }

                                            //fin Nuevo Release 

                                        }


                                        String Straviso = "";
                                        Straviso = "hay datos de tercer nivel";
                                        NodeTag Nta2g = (NodeTag)item3.Tag;

                                        StrStockingLocationID = Nta2g.StockingLocationID.ToString();

                                        strTradingPartnerID = Nta2g.TradingPartnerID.ToString();


                                        StrNode = item3.Name;

                                        DataRow TempRow2 = tableBpat.NewRow();
                                        TempRow2["name"] = StrNode;

                                     
                                        TempRow2["StockingLocationID"] = StrStockingLocationID;
                                        TempRow2["TradingPartnerID"] = strTradingPartnerID;
                                        StockingLocation Local2 = StockingLocation.GetStockingLocation(Guid.Parse(StrStockingLocationID), true, true);
                                        TempRow2["RateProfileID"] = Local2.DefaultRateProfileID.ToString();

                                        //NroObra Fix                                            
                                        TempRow2["NroObra"] = "";


                                        RateProfileProductList Rlist2 = RateProfileProductList.GetRateProfileProductList(Guid.Parse(Local2.DefaultRateProfileID.ToString()));


                                        //REGLA PARA CHILE 
                                        
                                        StrCodpaisUPER = StrCodPais.ToUpper();
                                        if (StrCodpaisUPER == "CL" || StrCodpaisUPER  == "PE")
                                        {
                                            //agregar cosas 

                                            string SearchString = "Consumables";
                                            string SearchString2 = "Fuera de Servicio";
                                            string SearchString3 = "Fungibles";

                                            int FirstChr = StrNode.IndexOf(SearchString);
                                            int FirstCh2 = StrNode.IndexOf(SearchString2);
                                            int FirstCh3 = StrNode.IndexOf(SearchString3);

                                            //NroObra Fix                                                
                                            StrNroObra = Local2.Number.ToString();
                                            TempRow2["NroObra"] = StrNroObra;



                                            if (FirstChr >= 0 || FirstCh2 >= 0) // || FirstCh3 >= 0)
                                            {
                                                //no debe hacer nada      
                                                ii = ii + 1;  
                                                                                          
                                            }
                                            else
                                            {
                                                //ii = ii + 1;

                                                if (StrNroObra != "")
                                                {
                                                    tableBpat.Rows.Add(TempRow2);
                                                }
                                                
                                            }


                                         
                                        }
                                        else
                                        {                                            
                                            tableBpat.Rows.Add(TempRow2);
                                        }
                                        //REGLA PARA CHILE 

                                        


                                    }

                                }

                                StrNode = item2.Name;
                                StrStockingLocationID = Ntag.StockingLocationID.ToString();
                                strTradingPartnerID = Ntag.TradingPartnerID.ToString();

                                DataRow TempRow = tableBpat.NewRow();
                                TempRow["name"] = StrNode;

                                

                                TempRow["StockingLocationID"] = StrStockingLocationID;
                                TempRow["TradingPartnerID"] = strTradingPartnerID;
                                StockingLocation Local = StockingLocation.GetStockingLocation(Guid.Parse(StrStockingLocationID), true, true);
                                TempRow["RateProfileID"] = Local.DefaultRateProfileID.ToString();


                                
                                
                                //NroObra Fix 
                                TempRow["NroObra"] = "";
                                RateProfileProductList Rlist = RateProfileProductList.GetRateProfileProductList(Guid.Parse(Local.DefaultRateProfileID.ToString()));

                                //REGLA PARA CHILE 
                                
                                StrCodpaisUPER = StrCodPais.ToUpper();
                                if (StrCodpaisUPER == "CL" || StrCodpaisUPER == "PE")
                                {
                                    //agregar cosas 

                                    string SearchString = "Consumables";
                                    string SearchString2 = "Fuera de Servicio";
                                    string SearchString3 = "Fungibles";

                                    int FirstChr = StrNode.IndexOf(SearchString);
                                    int FirstCh2 = StrNode.IndexOf(SearchString2);
                                    int FirstCh3 = StrNode.IndexOf(SearchString3);

                                    //NroObra
                                    StrNroObra = Local.Number.ToString();
                                    TempRow["NroObra"] = StrNroObra;


                                    if (FirstChr >= 0 || FirstCh2 >= 0) // || FirstCh3 >= 0)
                                    {
                                        //no debe hacer nada      
                                        ii = ii + 1;

                                    }
                                    else
                                    {
                                        //ii = ii + 1;
                                        if (StrNroObra != "")
                                        {
                                            tableBpat.Rows.Add(TempRow);
                                        }
                                        
                                    }



                                }
                                else
                                {
                                    //ii = ii + 1;
                                    tableBpat.Rows.Add(TempRow);
                                }
                                //REGLA PARA CHILE 

                                
                            }
                            

                        }
                        else
                        {
                            //TEST
                            String StrNode = item.Name;
                            String StrStockingLocationID = "";
                            String strTradingPartnerID = "";

                            NodeTag Ntag = (NodeTag)item.Tag;


                            StrStockingLocationID = Ntag.StockingLocationID.ToString();
                            strTradingPartnerID = Ntag.TradingPartnerID.ToString();

                            DataRow TempRow = tableBpat.NewRow();
                            TempRow["name"] = StrNode;

              

                            // TempRow["BusinessPartnerID"] = Bpat.BusinessPartnerID;.ToString();
                            TempRow["StockingLocationID"] = StrStockingLocationID;
                            TempRow["TradingPartnerID"] = strTradingPartnerID;

                            StockingLocation Local = StockingLocation.GetStockingLocation(Guid.Parse(StrStockingLocationID), true, true);

                            TempRow["RateProfileID"] = Local.DefaultRateProfileID.ToString();


                            //NroObra                                                                                                            
                            TempRow["NroObra"] = "";                                                        
                            RateProfileProductList Rlist = RateProfileProductList.GetRateProfileProductList(Guid.Parse(Local.DefaultRateProfileID.ToString()));

                            //REGLA PARA CHILE 
                            
                            StrCodpaisUPER = StrCodPais.ToUpper();
                            if (StrCodpaisUPER == "CL" || StrCodpaisUPER  == "PE")
                            {
                                //agregar cosas 

                                string SearchString = "Consumables";
                                string SearchString2 = "Fuera de Servicio";
                                string SearchString3 = "Fungibles";
                                
                                int FirstChr = StrNode.IndexOf(SearchString);
                                int FirstCh2 = StrNode.IndexOf(SearchString2);
                                int FirstCh3 = StrNode.IndexOf(SearchString3);

                                //NroObra
                                StrNroObra = Local.Number.ToString();
                                TempRow["NroObra"] = StrNroObra;

                                if (FirstChr >= 0 || FirstCh2 >= 0) // || FirstCh3 >= 0)
                                {
                                    //no debe hacer nada      
                                    ii = ii + 1;

                                }
                                else
                                {
                                    //ii = ii + 1;
                                    if (StrNroObra != "")
                                    {
                                        tableBpat.Rows.Add(TempRow);
                                    }
                                }



                            }
                            else
                            {
                                tableBpat.Rows.Add(TempRow);
                            }
                            //REGLA PARA CHILE 


                            
                        }

                        

                    }

                    intctn++;
                    TablePatner.Rows.Add(TempRw);
                    dataSetBpat.AcceptChanges();

                    StrCodpaisUPER = StrCodPais.ToUpper();
                    if (StrCodpaisUPER == "CL" || StrCodpaisUPER == "PE")
                    {

                        //tableBpat

                        DataTable dtsalidaCL = new DataTable();
                        tableBpat.DefaultView.Sort = "NroObra asc";
                        dtsalidaCL = tableBpat.DefaultView.ToTable();

                        dataSetBpat.Tables.Remove(tableBpat);
                        dataSetBpat.Tables.Add(dtsalidaCL);
                        dataSetBpat.AcceptChanges();


                    }

                    /*
                   

                     */

                    Salida = JsonConvert.SerializeObject(dataSetBpat, Formatting.Indented);



              

                }
                else
                {
                    Salida = "Error de Acceso";
                }

              
                
            }
            catch (Exception ex)
            {
                Salida =  ex.InnerException.ToString();

            }

            return Salida;

        }
        public string GetBusinessPatners(String StrCodPais)
        {
            try
            {
                AvontusPrincipal.Logout();

                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);


                BusinessPartnerComboList BpatList = BusinessPartnerComboList.GetCustomerComboList(Guid.Empty, ActiveStatus.Active, ActiveStatus.Active, false, false);


                //*Configuracion Dataset Salida*//
                DataSet dataSetBpat = new DataSet("Ds_BusinessPartner");
                dataSetBpat.Namespace = "Quantify";
                DataTable tableBpat = new DataTable();
                tableBpat.TableName = "BusinessPartners";

                DataColumn idColumn = new DataColumn("id", typeof(string));
                DataColumn NameColumn = new DataColumn("Name", typeof(string));
                //DataColumn BusinessPartnerIDColumn = new DataColumn("BusinessPartnerID", typeof(string));
                DataColumn PartnerNumberColumn = new DataColumn("PartnerNumber", typeof(string));
                idColumn.AutoIncrement = true;


                tableBpat.Columns.Add(idColumn);
                tableBpat.Columns.Add(NameColumn);
                //tableBpat.Columns.Add(BusinessPartnerIDColumn);
                tableBpat.Columns.Add(PartnerNumberColumn);
                dataSetBpat.Tables.Add(tableBpat);

                //*Recorrido y llenado de Objeto a Dset                
                foreach (BusinessPartnerListItem Bpat in BpatList)
                {

                    //tiene locations?
                    //JobSiteList = StockingLocationList.GetJobsites(false, JobTreeNodeDisplayType.Name, Guid.Parse(Bpat.BusinessPartnerID.ToString()), Guid.Empty);
                    //int IntCountLocations = JobSiteList.Count;

                    //20100113962

                    if (Bpat.PartnerNumber != null)
                    {
                        DataRow TempRow = tableBpat.NewRow();
                        TempRow["Name"] = Bpat.Name;
                        //Campo  llave para proximas consultas
                        // TempRow["BusinessPartnerID"] = Bpat.BusinessPartnerID.ToString();
                        TempRow["PartnerNumber"] = Bpat.PartnerNumber.ToString();
                        tableBpat.Rows.Add(TempRow);

                    }

                }

                //Parseo y Salida JSON
                dataSetBpat.AcceptChanges();
                string StrPaises = JsonConvert.SerializeObject(dataSetBpat, Formatting.Indented);
                return StrPaises;
            }
            catch (Exception ex)
            {


                return ex.InnerException.ToString();
            }



        }
        public string GetLocations(string StrCodPais, string PartnerNumber)
        {

            try
            {


                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);

                //StockingLocationList jobs = StockingLocationList.GetJobsites(false, JobTreeNodeDisplayType.Name, Guid.Empty);
                //BusinessPartnerComboList BpatList = BusinessPartnerComboList.GetCustomerComboList(Guid.Empty, ActiveStatus.Active, ActiveStatus.Active, false, false);

                BusinessPartner bpat = BusinessPartner.GetBusinessPartnerByNumber(PartnerNumber);

                //StockingLocationList JobSiteList = StockingLocationList.GetJobsites(false, JobTreeNodeDisplayType.Name, bpat.BusinessPartnerID);
                StockingLocationList JobSiteList = StockingLocationList.GetJobsites(false, JobTreeNodeDisplayType.Name, Guid.Parse(bpat.BusinessPartnerID.ToString()), Guid.Empty);
                //StockingLocationList JobSiteList2 = StockingLocationList.GetJobsites(false, JobTreeNodeDisplayType.NameNumber, bpat.BusinessPartnerID);

                // StockingLocationList JobSiteLis3 = StockingLocationList.get


                //* Exportacion Objeto Dataset Limpio*//
                DataSet dataSetJsites = new DataSet("Ds_Jobsites");
                dataSetJsites.Namespace = "Quantify";
                DataTable tableJsites = new DataTable();
                tableJsites.TableName = "Locations";

                DataColumn idColumn = new DataColumn("id", typeof(string));
                DataColumn NameColumn = new DataColumn("name", typeof(string));
                DataColumn StockingLocationIDColumn = new DataColumn("StockingLocationID", typeof(string));
                DataColumn BusinessPartnerIDColumn = new DataColumn("BusinessPartnerID", typeof(string));

                DataColumn RateProfileIDColumn = new DataColumn("RateProfileID", typeof(string));


                idColumn.AutoIncrement = true;

                tableJsites.Columns.Add(idColumn);
                tableJsites.Columns.Add(NameColumn);
                tableJsites.Columns.Add(StockingLocationIDColumn);
                tableJsites.Columns.Add(BusinessPartnerIDColumn);
                tableJsites.Columns.Add(RateProfileIDColumn);
                dataSetJsites.Tables.Add(tableJsites);

                //* Exportacion Objeto Dataset Limpio*//
                foreach (StockingLocationListItem item in JobSiteList)
                {

                    //falta el for 

                    //file2.WriteLine("StrNumber|" + StrNumber + "|Name|" + item.Name + "|item.StockingLocationID|" +
                    //item.StockingLocationID + "|BusinessPartnerID" + item.BusinessPartnerID.ToString());
                    DataRow TempRow = tableJsites.NewRow();
                    TempRow["name"] = item.Name;
                    //Campo  llave para proximas consultas
                    TempRow["StockingLocationID"] = item.StockingLocationID.ToString();
                    TempRow["BusinessPartnerID"] = item.BusinessPartnerID.ToString();
                    TempRow["RateProfileID"] = item.DefaultRateProfile.ToString();
                    tableJsites.Rows.Add(TempRow);
                }



                //Parseo y Salida JSON

                dataSetJsites.AcceptChanges();
                string StrPaises = JsonConvert.SerializeObject(dataSetJsites, Formatting.Indented);
                return StrPaises;


            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();

            }



        }
        public string GetProductsbyStockLocal(string StrCodPais, string StrStockingLocationID)
        {

            int i = 0;

            string strsalida = ""; 
            try
            {

                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);


                StockingLocation Local = StockingLocation.GetStockingLocation(Guid.Parse(StrStockingLocationID), true, true);


                //* Exportacion Objeto Dataset Limpio*//
                DataSet dataSetProducts = new DataSet("Ds_Products");
                dataSetProducts.Namespace = "Quantify";
                DataTable tableProducts = new DataTable();
                tableProducts.TableName = "Products";

                DataColumn idColumn = new DataColumn("id", typeof(string));
                DataColumn DescriptionColumn = new DataColumn("Description", typeof(string));
                DataColumn PartNumberColumn = new DataColumn("PartNumber", typeof(string));
                DataColumn QuantityOnRentColumn = new DataColumn("QuantityOnRent", typeof(string));
                DataColumn QuantityInTransitColumn = new DataColumn("QuantityInTransit", typeof(string));
                DataColumn QuantityReservedColumn = new DataColumn("QuantityReserved", typeof(string));
                DataColumn PriceColumn = new DataColumn("SellPrice", typeof(string));
                DataColumn TotalPriceColumn = new DataColumn("TotalPrice", typeof(string));
                DataColumn WeightColumn = new DataColumn("Weight", typeof(string));
                


                idColumn.AutoIncrement = true;

                tableProducts.Columns.Add(idColumn);
                tableProducts.Columns.Add(DescriptionColumn);
                tableProducts.Columns.Add(PartNumberColumn);
                tableProducts.Columns.Add(QuantityOnRentColumn);
                tableProducts.Columns.Add(QuantityInTransitColumn);
                tableProducts.Columns.Add(QuantityReservedColumn);
                tableProducts.Columns.Add(PriceColumn);
                tableProducts.Columns.Add(TotalPriceColumn);
                tableProducts.Columns.Add(WeightColumn);




                dataSetProducts.Tables.Add(tableProducts);


                

                foreach (StockedProduct prod in Local.StockedProducts)
                {

                    Product Prodname = Product.GetProduct(new Guid(prod.BaseProductID.ToString()));



                    String StrDescription = (Prodname.Description != null) ? Prodname.Description.ToString() : "NoName";
                    String StrPartNumbert = (prod.PartNumber != null) ? prod.PartNumber.ToString() : "NoPartNumber";


                    String StrQuantityOnRent = (prod.QuantityOnRent != null) ? prod.QuantityOnRent.ToString() : "0";
                    String StrQuantityInTransit = (prod.QuantityInTransit != null) ? prod.QuantityInTransit.ToString() : "0";
                    String StrQuantityReserved = (prod.QuantityReserved != null) ? prod.QuantityReserved.ToString() : "0";
                    String StrWeight = (prod.Weight != null) ? prod.Weight.ToString() : "0";


                    string ss;
                    if (i == 148)
                    {
                        ss = "SS";                        
                    }

                    DataRow TempRow = tableProducts.NewRow();
                    TempRow["Description"] = StrDescription;
                    TempRow["PartNumber"] = StrPartNumbert;
                    TempRow["QuantityOnRent"] = StrQuantityOnRent;
                    TempRow["QuantityInTransit"] = StrQuantityInTransit;
                    TempRow["SellPrice"] = "0";
                    TempRow["TotalPrice"] = "0";
                    TempRow["Weight"] = StrWeight;
                    


                    String Strprice = "0";
                    string StrRateProfileID  = Local.DefaultRateProfileID.ToString();
                    RateProfileProduct Larate4 = RateProfileProduct.GetRateProfileProduct(Guid.Parse(StrRateProfileID), Guid.Parse(prod.BaseProductID.ToString()));
                    Strprice =  (Larate4.SellPrice != null) ? Larate4.SellPrice.ToString() : "0"; 
                    

                    if (Strprice != null)
                    {
                        TempRow["SellPrice"] = Strprice;
                    }
                    

                    double a, b,total;
                    total = 0;
                    a = Convert.ToDouble(StrQuantityOnRent);
                    b = Convert.ToDouble((Strprice));

                    if (a != 0 && b != 0)
                    {
                        total = a * b;
                    }

                    if (total != 0)
                    {
                        TempRow["TotalPrice"] = total.ToString();
                    }


                    i++;

                    //Parseo y Salida JSON

                    tableProducts.Rows.Add(TempRow);


                }

                dataSetProducts.AcceptChanges();
                strsalida = JsonConvert.SerializeObject(dataSetProducts, Formatting.Indented);
                return strsalida;                

            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString() + i.ToString();


            }


        }
        public string GetProductsbyPartnerNumber(string StrCodPais, string PartnerNumber)
        {
            try
            {

                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrCodPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);


                BusinessPartner bpat = BusinessPartner.GetBusinessPartnerByNumber(PartnerNumber);

                //StockingLocationList JobSiteList = StockingLocationList.GetJobsites(false, JobTreeNodeDisplayType.Name, bpat.BusinessPartnerID);
                StockingLocationList JobSiteList = StockingLocationList.GetJobsites(false, JobTreeNodeDisplayType.Name, Guid.Parse(bpat.BusinessPartnerID.ToString()), Guid.Empty);



                //* Exportacion Objeto Dataset Limpio*//



                //* Exportacion Objeto Dataset Limpio*//
                DataSet dataSetProducts = new DataSet("Ds_Products");
                dataSetProducts.Namespace = "Quantify";





                foreach (StockingLocationListItem item in JobSiteList)
                {
                    StockingLocation Local = StockingLocation.GetStockingLocation(Guid.Parse(item.StockingLocationID.ToString()), true, true);


                    DataTable tableProducts = new DataTable();
                    tableProducts.TableName = Local.StockingLocationID.ToString();

                    DataColumn idColumn = new DataColumn("id", typeof(string));
                    DataColumn NameColumn = new DataColumn("name", typeof(string));
                    DataColumn StockingLocationIDColumn = new DataColumn("StockingLocationID", typeof(string));
                    DataColumn DescriptionColumn = new DataColumn("Description", typeof(string));
                    DataColumn PartNumberColumn = new DataColumn("PartNumber", typeof(string));
                    DataColumn QuantityOnRentColumn = new DataColumn("QuantityOnRent", typeof(string));
                    DataColumn QuantityInTransitColumn = new DataColumn("QuantityInTransit", typeof(string));
                    DataColumn QuantityReservedColumn = new DataColumn("QuantityReserved", typeof(string));

                    idColumn.AutoIncrement = true;

                    tableProducts.Columns.Add(idColumn);

                    tableProducts.Columns.Add(NameColumn);
                    tableProducts.Columns.Add(StockingLocationIDColumn);

                    tableProducts.Columns.Add(DescriptionColumn);
                    tableProducts.Columns.Add(PartNumberColumn);
                    tableProducts.Columns.Add(QuantityOnRentColumn);
                    tableProducts.Columns.Add(QuantityInTransitColumn);
                    tableProducts.Columns.Add(QuantityReservedColumn);

                    foreach (StockedProduct prod in Local.StockedProducts)
                    {

                        Product Prodname = Product.GetProduct(new Guid(prod.BaseProductID.ToString()));



                        String StrDescription = (Prodname.Description != null) ? Prodname.Description.ToString() : "NoName";
                        String StrPartNumbert = (prod.PartNumber != null) ? prod.PartNumber.ToString() : "NoPartNumber";


                        String StrQuantityOnRent = (prod.QuantityOnRent != null) ? prod.QuantityOnRent.ToString() : "0";
                        String StrQuantityInTransit = (prod.QuantityInTransit != null) ? prod.QuantityInTransit.ToString() : "0";
                        String StrQuantityReserved = (prod.QuantityReserved != null) ? prod.QuantityReserved.ToString() : "0";


                        DataRow TempRow = tableProducts.NewRow();

                        TempRow["name"] = Local.Name;
                        TempRow["StockingLocationID"] = Local.StockingLocationID.ToString();

                        TempRow["Description"] = StrDescription;
                        TempRow["PartNumber"] = StrPartNumbert;
                        TempRow["QuantityOnRent"] = StrQuantityOnRent;
                        TempRow["QuantityInTransit"] = StrQuantityInTransit;
                        TempRow["QuantityReserved"] = StrQuantityReserved;

                        tableProducts.Rows.Add(TempRow);

                    }
                    dataSetProducts.Tables.Add(tableProducts);


                }



                //Parseo y Salida JSON

                dataSetProducts.AcceptChanges();
                string StrPaises = JsonConvert.SerializeObject(dataSetProducts, Formatting.Indented);
                return StrPaises;


            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();

            }


        }
        public string ValidateUser(String StrPais, String StrUser, String Strpass)
        {

            String StrSalida = "false";

            try
            {


                string Conex = Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString;
                string strdbname;
                strdbname = "quantify-srv02\\SQLUN" + StrPais;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder.ConnectionString = Conex;
                builder.DataSource = strdbname;

                //Base de Datos Rotativa                                
                Avontus.Rental.Library.Settings.CommonConfigurationSettings.ConnectionString = builder.ConnectionString;
                String StrUsrQtfy = StrUser; // ConfigurationManager.AppSettings["UsrQtfy"];
                String StrPassQtfy = Strpass; // ConfigurationManager.AppSettings["PassQtfy"];
                bool success = AvontusPrincipal.Login(StrUsrQtfy, StrPassQtfy);

                if (success)
                {
                    StrSalida = "OK";
                }
                else
                {
                    StrSalida = "FAIL";
                }

            }
            catch (Exception ex)
            {
                StrSalida = ex.InnerException.ToString();
             
            }

            return  JsonConvert.SerializeObject(StrSalida, Formatting.Indented);  


        }


        public class BoolConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteValue(((bool)value) ? 1 : 0);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.Value == null || reader.Value.ToString() == "False")
                {
                    return false;
                }
                return true;
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(bool);
            }
        }


        public string CreateShipment(String StrCodPais, String StrUser, String StrFromLocation, String StrToLocation, String StrProductArray)
        {

            string Salida = "";

            try
            {

                //Necesito serializar los productos desde Front 
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(StrProductArray);
                DataTable dataTable = dataSet.Tables["Products"];
            
                return Salida;


                /*
                        {"Products":[{"id":0,"Description":"PANEL MURO ALL STEEL 600X200","PartNumber":"1APM 060.200","QuantityOnRent":"48","QuantityInTransit":"0","QuantityReserved":null,"SellPrice":"16314.0000","TotalPrice":"783072","Weight":"8.2"},{"id":1,"Description":"PANEL MURO ALL STEEL 600X450","PartNumber":"1APM 060.450","QuantityOnRent":"42","QuantityInTransit":"0","QuantityReserved":null,"SellPrice":"30949.0000","TotalPrice":"1299858","Weight":"15.1"},{"id":2,"Description":"PANEL MURO ALL STEEL 600X300","PartNumber":"1APM 060.300","QuantityOnRent":"39","QuantityInTransit":"0","QuantityReserved":null,"SellPrice":"21201.0000","TotalPrice":"826839","Weight":"11.2"}]}                 
                 */



            }
            catch (Exception ex )
            {
                
                throw ex;
            }

      

        }


    }

}
