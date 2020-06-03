<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cat_Usuarios.aspx.cs" Inherits="NegocioFlr.WebIU.Paginas.Cat_Usuarios" MasterPageFile="~/Paginas/Menu.Master" %>

<asp:Content ID="ctt_Encabezado" runat="server" ContentPlaceHolderID="cph_Encabezado">
    <title>Catálogo de usuarios</title>
</asp:Content>

<asp:Content ID="ctt_Cuerpo" runat="server" ContentPlaceHolderID="cph_Cuerpo">
    <div class="container">
        <center><h4 style="color: black;">Catálogo de Usuarios</h4></center><p></p>
        <div class="row">
            <div class="form-group">
                <table style="height: 50px">
                    <tr style="align-content: flex-start">
                        <td>
                            <div class="col-md-12">
                                <label>Estatus del registro:</label>
                            </div>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_Estatus" runat="server" CssClass="form-control" Height="32px" OnSelectedIndexChanged="ddl_Estatus_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="align-content: flex-start">
                        <td>
                            <div class="col-md-12">
                                <label>Búsqueda:</label>
                            </div>
                        </td>
                        <td>
                            <input id="txt_Nombre" type="text" runat="server" class="form-control" placeholder="Nombre" style="width: 120px; height:32px" />
                        </td>
                        <td>
                            <input id="txt_APaterno" type="text" runat="server" class="form-control" placeholder="A. Paterno" style="width: 120px; height:32px" />
                        </td>
                        <td>
                            <input id="txt_AMaterno" type="text" runat="server" class="form-control" placeholder="A. Materno" style="width: 120px; height:32px" />
                        </td>
                        <td>
                            <asp:ImageButton ID="img_Buscar" runat="server" ImageUrl="~/Imagenes/Consultar.ico" Height="30px" Width="30px" ToolTip="Buscar usuario" OnClick="img_Buscar_Click" />
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td style="align-content:end">
                            <asp:ImageButton ID="img_Alta" runat="server" ImageUrl="~/Imagenes/Alta.ico" Height="40px" Width="40px" ToolTip="Agregar usuario" OnClick="img_Alta_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="grd_Usuarios" runat="server"  AutoGenerateColumns="False" 
                    EmptyDataText="No existen registros" EnableModelValidation="True"
                    CssClass="table table-responsive" AllowPaging="true" PageSize="10">
                    <Columns>
                        <asp:TemplateField HeaderText="Editar" HeaderStyle-BackColor="#b16363" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:ImageButton ID="img_Editar" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Ide_Usr") %>'
                                    CommandName="Editar_Registro" ImageUrl="~/Imagenes/Actualiza.jpg" Height="20px" Width="20px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Nombre" DataField="Nom_bre" HeaderStyle-BackColor="#b16363" HeaderStyle-ForeColor="White" />
                        <asp:BoundField HeaderText="Apellido Paterno" DataField="Ape_Pat" HeaderStyle-BackColor="#b16363" HeaderStyle-ForeColor="White" />
                        <asp:BoundField HeaderText="Apellido Materno" DataField="Ape_Mat" HeaderStyle-BackColor="#b16363" HeaderStyle-ForeColor="White" />
                        <asp:BoundField HeaderText="Correo electrónico" DataField="Cor_reo" HeaderStyle-BackColor="#b16363" HeaderStyle-ForeColor="White" />
                        <asp:TemplateField HeaderText="Eliminar" HeaderStyle-BackColor="#b16363" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:ImageButton ID="img_Eliminar" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Ide_Usr") %>'
                                    CommandName="Eliminar_Registro" ImageUrl="~/Imagenes/Elimina.png" Height="20px" Width="20px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

