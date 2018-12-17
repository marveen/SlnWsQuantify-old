using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
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



namespace WsQuantify
{
    /// <summary>
    /// Descripción breve de qtfyService
    /// </summary>
    [WebService(Namespace = "http://www.unispan.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class WebServiceQuantify : System.Web.Services.WebService
    {

        [WebMethod(CacheDuration=300)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLocations(String StrCodPais, String StrPartnerNumber)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.GetLocations(StrCodPais, StrPartnerNumber);
            return Strsalida;
        }


        [WebMethod(CacheDuration = 300)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetProductsbyStockLocal(String StrCodPais, String StrStockingLocationID)
        {
            Apimethod GetLocations = new Apimethod();
            string Strsalida = "";
            Strsalida = GetLocations.GetProductsbyStockLocal(StrCodPais, StrStockingLocationID);
            return Strsalida;

        }


        [WebMethod(CacheDuration = 300)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetProductsbyPartnerNumber(String StrCodPais, String PartnerNumber)
        {
            Apimethod _api = new Apimethod();
            string Strsalida = "";
            Strsalida = _api.GetProductsbyPartnerNumber(StrCodPais, PartnerNumber);
            return Strsalida;

        }


        [WebMethod(CacheDuration=300)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetBusinessPatners(String StrCodPais)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.GetBusinessPatners(StrCodPais);
            return Strsalida;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLocationsByUser(String StrCodPais, String StrUser, String Strpass)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.GetLocationsByUser(StrCodPais, StrUser,Strpass);
            return Strsalida;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetShipingbylocation(String StrCodPais, String StrUser, String Strpass, String StrLocation)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.GetShipingbylocation(StrCodPais,  StrUser,  Strpass,  StrLocation);
            return Strsalida;
        }

        //Por Error 14-09-2017
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetShipingbylocations(String StrCodPais, String StrUser, String Strpass, String StrLocation)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.GetShipingbylocation(StrCodPais, StrUser, Strpass, StrLocation);
            return Strsalida;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetShipingbylocationDeliveries(String StrCodPais, String StrUser, String Strpass, String StrLocation)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.GetShipingbylocationDeliveries(StrCodPais, StrUser, Strpass, StrLocation);
            return Strsalida;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetShipingbyId(String StrCodPais, String StrUser, String Strpass, String StrLocation,String StrShipID)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.GetShipingbyId(StrCodPais, StrUser, Strpass,  StrLocation,StrShipID);
            return Strsalida;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string CreateShipment(String StrCodPais, String StrUser, String StrFromLocation, String StrToLocation, String StrProductArray)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.CreateShipment(StrCodPais, StrUser, StrFromLocation, StrToLocation, StrProductArray);
            return Strsalida;
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetProductsByShipping(String StrCodPais, String StrUser, String Strpass, String ShipmentID)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.GetProductByShippingID(StrCodPais, StrUser, Strpass, ShipmentID);
            return Strsalida;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetInvoicesByTradingPatner(String StrCodPais, String StrUser, String Strpass, String StrTradingPartnerID, String StrStockLocatinID)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.GetInvoicesByTradingPatner(StrCodPais, StrUser, Strpass, StrTradingPartnerID, StrStockLocatinID);
            return Strsalida;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetInvoiceProducts(String StrCodPais, String StrUser, String Strpass, String StrinvoiceID)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.GetInvoiceProducts(StrCodPais, StrUser, Strpass, StrinvoiceID);
            return Strsalida;
        }



        [WebMethod(CacheDuration = 300)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetPaises()
        {

            DataSet dataSet = new DataSet("Ds_Paises");
            dataSet.Namespace = "Quantify";
            DataTable table = new DataTable();
            table.TableName = "Paises";
            DataColumn idColumn = new DataColumn("id", typeof(string));
            DataColumn NameColumn = new DataColumn("name", typeof(string));
            DataColumn CodeColumn = new DataColumn("code", typeof(string));
            idColumn.AutoIncrement = true;


            table.Columns.Add(idColumn);
            table.Columns.Add(NameColumn);
            table.Columns.Add(CodeColumn);

            dataSet.Tables.Add(table);



            DataRow newRow1 = table.NewRow();
            newRow1["name"] = "Chile";
            newRow1["code"] = "CL";
            table.Rows.Add(newRow1);


            DataRow newRow2 = table.NewRow();
            newRow2["name"] = "Colombia";
            newRow2["code"] = "Co";
            table.Rows.Add(newRow2);


            DataRow newRow5 = table.NewRow();
            newRow5["name"] = "Mexico ";
            newRow5["code"] = "mx";
            table.Rows.Add(newRow5);

            DataRow newRow6 = table.NewRow();
            newRow6["name"] = "Panama";
            newRow6["code"] = "pa";
            table.Rows.Add(newRow6);

            DataRow newRow3 = table.NewRow();
            newRow3["name"] = "Peru";
            newRow3["code"] = "pe";
            table.Rows.Add(newRow3);


            //DataRow newRow4 = table.NewRow();
            //newRow4["name"] = "Usa";
            //newRow4["code"] = "us";
            //table.Rows.Add(newRow4);


            dataSet.AcceptChanges();

            string StrPaises = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

            return StrPaises;



        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ValidateUser(String StrPais, String StrUser, String Strpass)
        {
            String StrSalida = "false";
            Apimethod Api_ = new Apimethod();
            StrSalida = Api_.ValidateUser(StrPais, StrUser, Strpass);
            return StrSalida;                        
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetAdditionalCharges(String StrCodPais, String StrUser, String Strpass)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.GetAdditionalCharges(StrCodPais, StrUser, Strpass);
            return Strsalida;
        }


        //GetProductoReport
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetProductoReport(String StrCodPais, String StrUser, String Strpass)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.GetProductoReport(StrCodPais, StrUser, Strpass);
            return Strsalida;
        }


        //GetReportCustomerSL

        //GetProductoReport
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetReportCustomerSL(String StrCodPais, String StrUser, String Strpass)
        {
            Apimethod Api_ = new Apimethod();
            string Strsalida = "";
            Strsalida = Api_.GetReportCustomerSL(StrCodPais, StrUser, Strpass);
            return Strsalida;
        }


    }
}
