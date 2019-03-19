using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Newtonsoft.Json;

namespace WsQuantify
{
    public partial class Login : System.Web.UI.Page
    {


        DataSet DsetReport = new DataSet();
        WsQuantify.WebServiceQuantify Wsneed = new WebServiceQuantify();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnIngresa_Click(object sender, EventArgs e)
        {

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            //validar usuario 
            string StrUser, Strpass, strpais;
            StrUser = txname.Value;
            Strpass = txpass.Value;
            strpais = DdlPais.Value;

            //validar usuario con Servicio. 
            String StrJsonUser = "";


            StrJsonUser = Wsneed.ValidateUser(strpais, StrUser, Strpass);
            //DsetReport = GetDataSet(StrJsonUser);


            Response.Redirect("Reports.aspx");

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

    }
}