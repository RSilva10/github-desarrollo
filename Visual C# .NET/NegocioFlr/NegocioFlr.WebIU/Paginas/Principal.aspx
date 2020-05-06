<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="NegocioFlr.WebIU.Paginas.Principal" MasterPageFile="~/Paginas/Menu.Master" %>

<asp:Content ContentPlaceHolderID="cph_Encabezado" runat="server">
    <title>Menú principal</title>
</asp:Content>    

<asp:Content ContentPlaceHolderID="cph_Cuerpo" runat="server">
    <br />
    <div class="container">
        <h3>Bienvenido <asp:Label ID="lbl_Usuario" runat="server" Text="Usuario"></asp:Label></h3>
    </div>
</asp:Content>