<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WsQuantify.Login" %>

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

<body>


    <form id="FrmReports" method="post" runat="server" style="text-align: center;">
        <div align="center">
            <img src="img/logo.png" />
        </div>
        <h1>Consola de Reportes</h1>

        <div align="center">
            
        
            <table border="0" width="20%">
                    <tr>
                        <td>Usuario: </td>
                        <td>
                            <input runat="server" type="text" style="width: 150px;" id="txname" value="consultaweb" /></td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txname" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Password: </td>
                        <td>
                            <input runat="server" type="password" style="width: 150px" id="txpass" value="Unispan.001" /></td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txpass" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Pais:</td>
                        <td>
                              <select id="DdlPais" runat="server" style="width:150px;">
                                  <option value="cl">Chile</option>
                              <option value="co">Colombia</option>
                                  <option value="mx">Mexico</option>
                                  <option value="pa">Panama</option>
                                  <option value="pe">Peru</option>
                                  <option value="usa">Usa</option>
                              </select>      

                        </td>
                    </tr>

                    <tr>
                        <td colspan="3" style="text-align:center;">
                            <br />
                            <asp:Button ID="Button1" runat="server" Text="Ingresar" OnClick="Button1_Click" style="width:120px;"/>
                        </td>

                    </tr>


                </table>   

        </div>

    </form>

</body>

</html>

