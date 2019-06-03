<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="WsQuantify.Reports" %>
<%@ Register TagName="FileViewer" TagPrefix="uc" Src="~/controls/fileViewer.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>My Unispan </title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet" id="bootstrap" />
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css" rel="stylesheet" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <link href="./assets/docs.css" rel="stylesheet" />
    <link href="./css/flag-icon.css" rel="stylesheet" />
    <script src="./assets/docs.js"></script>

</head>
<style type="text/css">
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        text-align: center;
    }

    #DivTabs {
        width: 90%;
    }
</style>
<script src="https://code.jquery.com/jquery-3.3.1.js" integrity="sha256-2Kok7MbOyxpgUVvAk/HJ2jigOSYS2auK4Pfzbm7uH60=" crossorigin="anonymous"></script>

        <body>

            <form id="FrmReports" method="post" runat="server">

               

                <div align="left" style="padding: 10px; margin-left:40px;">
                    <table border="0" cellpadding="0">
                        <tr>
                            <td>
                                <div id="logo" style="background-position-x: -38px; background-position-y: -16px; background-image: url('logo.png'); width: 320px; height: 105px;"></div>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-left: 10px; font-size: 24px;">
                                    <span id="cl" runat="server" visible="false" alt="cl" class="label label-primary" style="cursor: pointer;"><span class="flag-icon flag-icon-cl"></span> Chile</span>
                                    <span id="pe" runat="server" visible="false" alt="pe" class="label label-primary" style="cursor: pointer;"><span class="flag-icon flag-icon-pe"></span> Perú</span>
                                    <span id="pa" runat="server" visible="false" alt="pa" class="label label-primary" style="cursor: pointer;"><span class="flag-icon flag-icon-pa"></span> Panamá</span>
                                    <span id="mx" runat="server" visible="false" alt="mx" class="label label-primary" style="cursor: pointer;"><span class="flag-icon flag-icon-mx"></span> Mexico</span>
                                    <span id="co" runat="server" visible="false" alt="co" class="label label-primary" style="cursor: pointer;"><span class="flag-icon flag-icon-co"></span> Colombia</span>
                                    <span id="usa" runat="server" visible="false" alt="usa" class="label label-primary" style="cursor: pointer;"><span class="flag-icon flag-icon-um"></span> USA</span>
                                </div>
                            </td>
                            <td>
                                 <div id="DivBtnSalir" style="position: absolute; right: 0px; margin-right: 80px; margin-top: 50px;">
                                <asp:Button ID="BtnSalir"  class="btn-danger" runat="server" Text="Cerrar Sesión" OnClick="BtnSalir_Click" />

                         </div>

                            </td>
                        </tr>
                    </table>

                    <br />

                </div>

                <div id="DivLoading" runat="server" visible="false" style="color:white; background-color:darkblue; font-size:15px; font-weight:bolder; padding:20px; position:absolute; top:0px; height:40px; width:100%">
                     
                    Cargando..

                </div>

                <div align="center">

                
                <div id="DivTabs">

                    <ul class="nav nav-tabs">
                        <li class="active"><a data-toggle="tab" href="#home">Generar Reportes</a></li>
                        <li><a data-toggle="tab" href="#menu1">Reportes Historicos</a></li>

                    </ul>

                    <div class="tab-content">
                        <div id="home" class="tab-pane fade in active" align="left">

                            <h3> Seleccione Reporte </h3>
                            <p>
                                <asp:DropDownList ID="ddlReporte" runat="server" Height="25px" Width="205px">
                                     <asp:ListItem Selected="True" Value="StockedItemCost">Stocked Item Cost</asp:ListItem>
                                     <asp:ListItem Value="StockedItemCostCotumer">Stocked Item Cost Costumer</asp:ListItem>
                                     <asp:ListItem Value="ReportAdmin">Reporte Por Admin</asp:ListItem>                                  
                                 </asp:DropDownList>

                                
                       <asp:Button ID="BtnExcel" runat="server" Text="Generar Excel"  class="btn-success"  OnClick="BtnExcel_Click" />

                         
                    </p>
                        </div>
            <div id="menu1" class="tab-pane fade" align="left">
                
       <div class="row">
        <div class="col-xs-12">
            <uc:FileViewer ID="_fileViewer" AltRelFilePath="" runat="server" />
        </div>
    </div> 




            </div>
                
                    </div>

                </div >

                    </div>
      







    </form >




</body >
</html >
