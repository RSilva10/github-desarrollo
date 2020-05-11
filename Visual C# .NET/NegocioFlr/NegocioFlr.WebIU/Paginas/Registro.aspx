<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="NegocioFlr.WebIU.Paginas.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de usuario</title>
    <script src="../Scripts/jquery-3.2.0.js"></script>
    <script src="../Scripts/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <link href="../Scripts/bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Estilos/NegocioFlr.css" rel="stylesheet" />
</head>
<body class="cuerpo_fondo">
    <br />
    <br />
    <center>
        <div class="container">
            <div class="row">
                <h4 style="color:white">Registrar usuario :</h4>
                <form id="pag_Registro" runat="server" role="form">
                    <div class="form-group">
                        <input id="txt_Usuario" type="text" runat="server" class="form-control" placeholder="Usuario" style="width:300px" maxlength="10" title="Clave de usuario" />
                    </div>
                    <div class="form-group">
                        <input id="txt_Paterno" type="text" runat="server" class="form-control" placeholder="Apellido Paterno" style="width:300px" maxlength="20" title="Apellido paterno" />
                    </div>
                    <div class="form-group">
                        <input id="txt_Materno" type="text" runat="server" class="form-control" placeholder="Apellido Materno" style="width:300px" maxlength="20" title="Apellido materno" />
                    </div>
                    <div class="form-group">
                        <input id="txt_Nombre" type="text" runat="server" class="form-control" placeholder="Nombre" maxlength="20" style="width:300px" title="Nombre" />
                    </div>
                    <div class="form-group">
                        <input id="txt_Correo" type="text" runat="server" class="form-control" placeholder="Correo electrónico" style="width:300px" maxlength="50" title="Correo electrónico" />
                    </div>
                    <div class="form-group">
                        <input id="txt_Alias" type="text" runat="server" class="form-control" placeholder="Alias" maxlength="5" style="width:300px" title="Clave de cliente" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btn_Registrar" runat="server" CssClass="btn btn-secondary" Text="Registrar" OnClick="btn_Registrar_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_Cancelar" runat="server" CssClass="btn btn-secondary" Text="Cancelar" OnClick="btn_Cancelar_Click" />
                    </div>
                </form>
            </div>
        </div>
    </center>
</body>
</html>
