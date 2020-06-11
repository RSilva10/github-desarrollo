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
                                <asp:ImageButton ID="img_Limpiar" runat="server" ImageUrl="~/Imagenes/Limpiar.png" Height="30px" Width="30px" ToolTip="Limpiar campos" OnClick="img_Limpiar_Click"   />
                                <asp:ImageButton ID="img_Cancelar" runat="server" ImageUrl="~/Imagenes/Cancelar.png" Height="30px" Width="30px" ToolTip="Cancelar proceso" OnClick="img_Cancelar_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="form-group">
            <table style="height: 120px">
                <tr>
                    <td>
                        <label style="color: red">Usuario:</label>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <input id="txt_Usuario" type="text" runat="server" class="form-control" style="width: 120px; height: 32px" maxlength="10" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <label style="color: red">Contraseña:</label>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <input id="txt_Contraseña" type="text" runat="server" class="form-control" style="width: 120px; height: 32px" maxlength="10" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td style="border: solid">
                        <label style="color: black">Criterios para contraseña:</label><br />
                        <label style="color: black">* Máximo 10 caracteres.</label><br />
                        <label style="color: black">* Combinación de 6 letras y 4 números.</label><br />
                        <label style="color: black">* Combinación de 6 números y 4 letras.</label><br />
                        <label style="color: black">* Sin caracteres especiales.</label>
                    </td>
                </tr>
                <tr></tr>
                <tr></tr>
                <tr>
                    <td>
                        <label style="color: red">Apellido Paterno:</label>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <input id="txt_APaterno" type="text" runat="server" class="form-control" style="width: 120px; height: 32px" maxlength="20" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <label style="color: red">Apellido Materno:</label>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <input id="txt_AMaterno" type="text" runat="server" class="form-control" style="width: 120px; height: 32px" maxlength="20" />
                    </td>
                </tr>
                <tr></tr>
                <tr></tr>
                <tr>
                    <td>
                        <br />
                        <br />
                        <label style="color: red">Nombre:</label>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <br />
                        <br />
                        <input id="txt_Nombre" type="text" runat="server" class="form-control" style="width: 120px; height: 32px" maxlength="20" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <br />
                        <br />
                        <label style="color: red">Correo electrónico:</label>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <br />
                        <br />
                        <input id="txt_Correo" type="text" runat="server" class="form-control" style="width: 250px; height: 32px" maxlength="50" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <br />
                        <label style="color: red">Estatus:</label>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <br />
                        <br />
                        <asp:DropDownList ID="ddl_Estatus" runat="server" CssClass="form-control" Height="32px" ></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
