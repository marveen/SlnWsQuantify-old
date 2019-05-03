<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WsQuantify.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Unispan </title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet" id="bootstrap" />
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="./assets/docs.css" rel="stylesheet" />
    <link href="./css/flag-icon.css" rel="stylesheet" />
    <script src="./assets/docs.js"></script>


</head>
<style type="text/css">
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        text-align: center;
    }

    #titulo {
        margin-top:0px;
    }
    .input-group {
        width:30%;
    }
</style>

<body>

    <script type="text/javascript">
    $(document).ready(function () {

                                 $(".label").click(function () {
                                     //label label-primary
                                     $(".label").each(function () {
                                         $(this).removeClass("label label-primary");
                                         $(this).addClass("label label-default");
                                     })

                                     $(this).addClass("label label-primary");

                                     $("#titulo").html("Unispan " + this.id);

                                     var pais; 

                                     pais = $(this).attr("alt");

                                     $(".inputpais").val(pais);
                                     $(".btn-success").show();

                            });




                             });
    </script>


       <form id="FrmReports" method="post" runat="server" style="text-align: center;">
        <div align="center">
            <img src="img/logo.png" />
        </div>
                           
        <h1 id="titulo">Welcome Select your Country.</h1>

        <h3>
            <span id="Chile" alt="cl" class="label label-default" style="cursor: pointer;"><span class="flag-icon flag-icon-cl"></span> Chile</span>
            <span id="Perú" alt="pe" class="label label-default" style="cursor: pointer;"><span class="flag-icon flag-icon-pe"></span> Perú</span>
            <span id="Panamá" alt="pa" class="label label-default" style="cursor: pointer;"><span class="flag-icon flag-icon-pa"></span> Panamá</span>
            <span id="Mexico" alt="mx" class="label label-default" style="cursor: pointer;"><span class="flag-icon flag-icon-mx"></span> Mexico</span>
            <span id="Colombia" alt="co" class="label label-default" style="cursor: pointer;"><span class="flag-icon flag-icon-co"></span> Colombia</span>
            <span id="Usa" alt="usa" class="label label-default" style="cursor: pointer;"><span class="flag-icon flag-icon-um"></span> USA</span>

        </h3>

        <div align="center" style="margin-top:30px;">
        
            <div class="input-group" style="margin-bottom:5px;">
                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                <input runat="server" id="txname" type="text" class="form-control" name="email" placeholder="User"/>
            </div>
                
            <div class="input-group">
                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                <input id="txpass" runat="server" type="password" class="form-control" name="password" placeholder="Password"/>
                </div>

                <br/>


                 <asp:Button  ID="Button1" runat="server" Text="Ingresar" OnClick="Button1_Click" class="btn-success" style="padding:5px; width:150px; display:none;"/>
       <br />
                  <input runat="server" id="txPais" class="inputpais" style="border:none; color:white;"/>


        </div>

    </form>

</body>

</html>

