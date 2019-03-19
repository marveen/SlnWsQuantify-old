using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WsQuantify
{
    public partial class Login : System.Web.UI.Page
    {
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
            string StrUser, Strpass;
            StrUser = txname.Value;
            StrUser = txpass.Value;

            //validar usuario con Servicio. 



            Response.Redirect("Reports.aspx");

        }
    }
}