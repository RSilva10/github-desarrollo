<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NegocioFlr.WebIU.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ingreso al sistema</title>
    <script src="Scripts/jquery-3.2.0.js"></script>
    <script src="Scripts/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <link href="Scripts/bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <form id="pag_Login" runat="server" role="form">
                    <div class="jumbotron" style="background-color:dodgerblue">
                        <div class="form-horizontal">
                            <h4 style="color:white">Iniciar sesión</h4>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <input id="txt_Usuario" type="text" runat="server" class="form-control" placeholder="Usuario" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <input id="txt_Password" type="password" runat="server" class="form-control" placeholder="Contraseña" />
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <div class="col-md-6">
                                    <asp:Button ID="btn_Login" runat="server" CssClass="btn btn-info" Text="Ingresar" OnClick="btn_Login_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_Registro" runat="server" CssClass="btn btn-info" Text="Registro" OnClick="btn_Registro_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>


</body>
</html>
