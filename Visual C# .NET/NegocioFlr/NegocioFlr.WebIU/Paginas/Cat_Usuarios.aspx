<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cat_Usuarios.aspx.cs" Inherits="NegocioFlr.WebIU.Paginas.Cat_Usuarios" MasterPageFile="~/Paginas/Menu.Master" %>

<asp:Content ID="ctt_Encabezado" runat="server" ContentPlaceHolderID="cph_Encabezado">
    <title>Catálogo de usuarios</title>
</asp:Content>

<asp:Content ID="ctt_Cuerpo" runat="server" ContentPlaceHolderID="cph_Cuerpo">
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-11 col-md-offset-1">
                <div class="jumbotron" style="background-color: dodgerblue">
                    <div class="form-horizontal">
                        <h3 style="color: white">Usuarios</h3>
                        <h4 style="color: white">Criterios de búsqueda</h4>
                        <table class="tab-content">
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_Usuario" runat="server" ForeColor="White" Text="Usuario:"></asp:Label>
                                    <input id="txt_Usuario" type="text" runat="server" class="form-control" maxlength="10" />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Paterno" runat="server" ForeColor="White" Text="Apellido Paterno:"></asp:Label>
                                    <input id="txt_Paterno" type="text" runat="server" class="form-control" maxlength="20" />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Materno" runat="server" ForeColor="White" Text="Apellido Materno:"></asp:Label>
                                    <input id="txt_Materno" type="text" runat="server" class="form-control" maxlength="20" />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Nombre" runat="server" ForeColor="White" Text="Nombre:"></asp:Label>
                                    <input id="txt_Nombre" type="text" runat="server" class="form-control" maxlength="20" />
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Correo" runat="server" ForeColor="White" Text="Correo electrónico:"></asp:Label>
                                    <input id="txt_Correo" type="text" runat="server" class="form-control" maxlength="50" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 16%; text-align: center">
                                    <asp:ImageButton ID="btn_Consultar" runat="server" ImageUrl="~/Imagenes/Consultar.ico" Height="50" Width="50" ToolTip="Consultar" OnClick="btn_Consultar_Click" />
                                </td>
                                <td style="width: 16%; text-align: center">
                                    <asp:ImageButton ID="btn_Descargar" runat="server" ImageUrl="~/Imagenes/Descargar_Excel.ico" Height="50" Width="50" ToolTip="Descargar archivo Excel" OnClick="btn_Descargar_Click" />
                                </td>
                                <td style="width: 16%; text-align: center">
                                    <asp:FileUpload ID="ful_Revisar" runat="server" CssClass="btn btn-info" />
                                </td>
                                <td style="width: 16%; text-align: center">
                                    <asp:ImageButton ID="btn_Revisar" runat="server" ImageUrl="~/Imagenes/Checar_Datos.ico" Height="50" Width="50" ToolTip="Revisar datos archivo Excel" OnClick="btn_Revisar_Click" />
                                </td>
                                <td style="width: 16%; text-align: center">
                                    <asp:ImageButton ID="btn_Cargar" runat="server" ImageUrl="~/Imagenes/Cargar_Excel.ico" Height="50" Width="50" ToolTip="Cargar archivo Excel" Enabled="false" OnClick="btn_Cargar_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <h4 style="color: white">Errores del archivo de Excel</h4>
                    <asp:GridView ID="grv_Errores" runat="server" AutoGenerateColumns="False"
                        EmptyDataText="No existen registros" EnableModelValidation="True"
                        CssClass="table table-striped table-bordered table-hover table-condensed small-top-margin">
                        <Columns>
                            <asp:BoundField DataField="Num_Lin" HeaderText="Línea">
                                <HeaderStyle ForeColor="White" BackColor="SteelBlue" />
                                <ItemStyle BackColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nom_Cam" HeaderText="Campo">
                                <HeaderStyle ForeColor="White" BackColor="SteelBlue" />
                                <ItemStyle BackColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Des_Err" HeaderText="Error">
                                <HeaderStyle ForeColor="White" BackColor="SteelBlue" />
                                <ItemStyle BackColor="White" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
            </div>
            <div class="col-md-11 col-md-offset-1">
                <div class="jumbotron" style="background-color: dodgerblue">
                    <div class="form-horizontal">
                        <h4 style="color: white">Listado</h4>
                        <div class="form-group">
                            <div class="col-md-11">
                                <asp:GridView ID="grv_Usuarios" runat="server" AutoGenerateColumns="False"
                                    EmptyDataText="No existen registros" EnableModelValidation="True"
                                    CssClass="table table-striped table-bordered table-hover table-condensed small-top-margin"
                                    OnRowCommand="grv_Usuarios_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Registrar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="img_Registrar" runat="server" CausesValidation="false"
                                                    CommandArgument='<%# Bind("Ide_Usr") %>' CommandName="Registrar"
                                                    ImageUrl="~/Imagenes/Alta.ico" Height="20" />
                                            </ItemTemplate>
                                            <HeaderStyle ForeColor="White" BackColor="SteelBlue" />
                                            <ItemStyle BackColor="White" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actualizar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="img_Editar" runat="server" CausesValidation="false"
                                                    CommandArgument='<%# Bind("Ide_Usr") %>' CommandName="Actualizar"
                                                    ImageUrl="~/Imagenes/Actualiza.ico" Height="20" />
                                            </ItemTemplate>
                                            <HeaderStyle ForeColor="White" BackColor="SteelBlue" />
                                            <ItemStyle BackColor="White" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Eliminar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="img_Eliminar" runat="server" CausesValidation="false"
                                                    CommandArgument='<%# Bind("Ide_Usr") %>' CommandName="Eliminar"
                                                    ImageUrl="~/Imagenes/Elimina.ico" Height="20" />
                                            </ItemTemplate>
                                            <HeaderStyle ForeColor="White" BackColor="SteelBlue" />
                                            <ItemStyle BackColor="White" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cambiar Contraseña">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="img_Contrasena" runat="server" CausesValidation="false"
                                                    CommandArgument='<%# Bind("Ide_Usr") %>' CommandName="Contraseña"
                                                    ImageUrl="~/Imagenes/Contraseña.ico" Height="20" />
                                            </ItemTemplate>
                                            <HeaderStyle ForeColor="White" BackColor="SteelBlue" />
                                            <ItemStyle BackColor="White" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Ide_Usr" HeaderText="ID Usuario">
                                            <HeaderStyle ForeColor="White" BackColor="SteelBlue" />
                                            <ItemStyle BackColor="White" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cve_Usr" HeaderText="Usuario">
                                            <HeaderStyle ForeColor="White" BackColor="SteelBlue" />
                                            <ItemStyle BackColor="White" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ape_Pat" HeaderText="Apellido Paterno">
                                            <HeaderStyle ForeColor="White" BackColor="SteelBlue" />
                                            <ItemStyle BackColor="White" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ape_Mat" HeaderText="Apellido Materno">
                                            <HeaderStyle ForeColor="White" BackColor="SteelBlue" />
                                            <ItemStyle BackColor="White" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nom_bre" HeaderText="Nombre">
                                            <HeaderStyle ForeColor="White" BackColor="SteelBlue" />
                                            <ItemStyle BackColor="White" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cor_reo" HeaderText="Correo Electrónico">
                                            <HeaderStyle ForeColor="White" BackColor="SteelBlue" />
                                            <ItemStyle BackColor="White" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

