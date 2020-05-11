<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NegocioFlr.WebIU.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ingreso al sistema</title>
    <script src="Scripts/jquery-3.2.0.js"></script>
    <script src="Scripts/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <link href="Scripts/bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Estilos/NegocioFlr.css" rel="stylesheet" />
</head>
<body class="cuerpo_fondo">
    <div>
        <br />
        <br />
        <br />
        <center><img src="Imagenes/Logo_NF.png" width="150" class="logo_centrado" style="border:1px solid" /></center>
        <br />
        <br />
    </div>
    <center>
        <div class="container">
            <div class="row">
                <form id="pag_Login" runat="server" role="form">
                    <h4 style="color: white">Iniciar sesión :</h4>
                    <div class="form-group">
                        <input id="txt_Usuario" type="text" runat="server" class="form-control" placeholder="Usuario" style="width:200px" title="Clave de usuario" />
                    </div>
                    <div class="form-group">
                        <input id="txt_Password" type="password" runat="server" class="form-control" placeholder="Contraseña" style="width:200px" title="Contraseña de usuario" />
                    </div>
                    <div class="form-group">
                        <input id="txt_Alias" type="text" runat="server" class="form-control" placeholder="Alias" style="width:200px" title="Clave de cliente" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btn_Login" runat="server" CssClass="btn btn-secondary" Text="Ingresar" OnClick="btn_Login_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_Registro" runat="server" CssClass="btn btn-secondary" Text="Registro" OnClick="btn_Registro_Click" />
                    </div>
                </form>
            </div>
        </div>
    </center>
</body>
</html>
