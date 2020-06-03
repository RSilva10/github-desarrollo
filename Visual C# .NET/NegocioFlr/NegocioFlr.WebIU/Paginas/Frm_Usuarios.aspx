<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Menu.Master" AutoEventWireup="true" CodeBehind="Frm_Usuarios.aspx.cs" Inherits="NegocioFlr.WebIU.Paginas.Frm_Usuarios" %>

<asp:Content ID="ctt_Encabezado" ContentPlaceHolderID="cph_Encabezado" runat="server">
    <title>Alta/Edición usuarios</title>
    <script src="../Scripts/jquery-3.5.1.js"></script>
    <script src="../Scripts/bootstrap-4.5.0-dist/js/bootstrap.min.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <script src="../Scripts/toastr.min.js"></script>
    <script src="../Scripts/Utilerias.js"></script>
    <link href="../Scripts/bootstrap-4.5.0-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Estilos/toastr.css" rel="stylesheet" />
    <link href="../Estilos/NegocioFlr.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="ctt_Cuerpo" ContentPlaceHolderID="cph_Cuerpo" runat="server">
    <div class="container">
        <div class="row">
            <div class="form-group">
                <table style="height: 50px">
                    <tr style="align-content: flex-start">
                        <td style="align-content: end">
                            <div>
                                <asp:ImageButton ID="img_Guardar" runat="server" ImageUrl="~/Imagenes/Guardar.jpg" Height="30px" Width="30px" ToolTip="Guardar/Editar usuario" OnClick="img_Guardar_Click" />
                                <asp:ImageButton ID="img_Cancelar" runat="server" ImageUrl="~/Imagenes/Cancelar.png" Height="30px" Width="30px" ToolTip="Cancelar proceso" OnClick="img_Cancelar_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="form-group">
            <label style="color: red">Usuario:</label>
        </div>

    </div>
</asp:Content>
