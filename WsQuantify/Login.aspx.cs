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

            String StrAlerta = System.Web.HttpContext.Current.Session["_Error"] as String;

            if (StrAlerta == "logout")
            {

            }
            else
            {
                if (StrAlerta == null)
                {
                    StrAlerta = "";
                }

                if (StrAlerta.Length > 0)
                {
                    Response.Write("<script type='text/javascript'>alert('" + StrAlerta + "')</script>");
                }

            }

            
            


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

            bool AccesoOK = false;
            AccesoOK = StrJsonUser.Contains("OK");



            if (AccesoOK)
            {
                //creaer Variables de sesion 

                //GUARDA
                System.Web.HttpContext.Current.Session["_strpais"] = strpais;
                System.Web.HttpContext.Current.Session["_StrUser"] = StrUser;
                System.Web.HttpContext.Current.Session["_Strpass"] = Strpass;


                //LEE
                //ViewData["sessionString"] = System.Web.HttpContext.Current.Session["sessionString"] as String; 
                string _StrUser, _Strpass, _strpais;
                _StrUser = System.Web.HttpContext.Current.Session["_StrUser"] as String;
                _Strpass = System.Web.HttpContext.Current.Session["_Strpass"] as String;
                _strpais = System.Web.HttpContext.Current.Session["_strpais"] as String;

                               
                Response.Redirect("Reports.aspx");
            }
            else
            {

                System.Web.HttpContext.Current.Session["_Error"] = "Credenciales Inválidas";                                     
                Response.Redirect("Login.aspx");
            }
                

             


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