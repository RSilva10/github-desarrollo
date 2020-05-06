 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="NegocioFlr.WebIU.Paginas.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de usuario</title>
    <script src="../Scripts/jquery-3.2.0.js"></script>
    <script src="../Scripts/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <link href="../Scripts/bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <form id="pag_Registro" runat="server" role="form">
                    <div class="jumbotron" style="background-color:dodgerblue">
                        <div class="form-horizontal">
                            <h4 style="color:white">Registrar usuario</h4>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <input id="txt_Usuario" type="text" runat="server" class="form-control" placeholder="Usuario" maxlength="10" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <input id="txt_Paterno" type="text" runat="server" class="form-control" placeholder="Apellido Paterno" maxlength="20" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <input id="txt_Materno" type="text" runat="server" class="form-control" placeholder="Apellido Materno" maxlength="20" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <input id="txt_Nombre" type="text" runat="server" class="form-control" placeholder="Nombre" maxlength="20" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <input id="txt_Correo" type="text" runat="server" class="form-control" placeholder="Correo electrónico" maxlength="50" />
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <div class="col-md-6">
                                    <asp:Button ID="btn_Registrar" runat="server" CssClass="btn btn-info" Text="Registrar" OnClick="btn_Registrar_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_Cancelar" runat="server" CssClass="btn btn-info" Text="Cancelar" OnClick="btn_Cancelar_Click" />
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
