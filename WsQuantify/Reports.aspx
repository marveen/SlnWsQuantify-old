<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="WsQuantify.Reports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style type="text/css">

        body {
             font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
             text-align:center;

        }

        </style>
    <script src="https://code.jquery.com/jquery-3.3.1.js" integrity="sha256-2Kok7MbOyxpgUVvAk/HJ2jigOSYS2auK4Pfzbm7uH60=" crossorigin="anonymous"></script>

<script type="text/javascript">


    $(document).ready(function ()
    {
        //alert("ready!");

        //mensaje();

     });


    function mensaje()
    {
                var strParams = {
                        StrCodPais: "cl",
                        StrUser: "consultaweb",
                        Strpass: "Unispan.001"
                };

        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "http://localhost:58177/WebServiceQuantify.asmx/GetReportCustomerSL",
            data: JSON.stringify(strParams),
            dataType: "json",
            error: function (msg) {
                console.log("Error");
                console.log(msg);
            },

            success: function (data) {
                var rs = $.parseJSON(data["d"]);
                var exists_the_json = true;
                body = "<h3 class='text-left'>Productos</h3>";
                console.log(rs);

            },
           });



    }
</script>
   
    <body>

        <div align="center">

            <img src="img/logo.png" />
        </div>

        <h1> Generador de Reportes </h1>


            <form id="FrmReports" method="post" runat="server">
        
        
                <asp:DropDownList ID="ddlReporte" runat="server" Height="18px" Width="205px">
                    <asp:ListItem Selected="True" Value="StockedItemCost">Stocked Item Cost</asp:ListItem>
                    <asp:ListItem Value="StockedItemCostCostumer">Stocked Item Cost Costumer</asp:ListItem>
                    <asp:ListItem>demo</asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        
                <asp:Button ID="BtnExcel" runat="server" Text="Generar Excel" OnClick="BtnExcel_Click" />
        
        
        </form>




</body>
</html>
