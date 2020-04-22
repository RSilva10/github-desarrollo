<%@ Page Title="" Language="C#" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="Objetos.aspx.cs" Inherits="Ejercicios.Objetos" %>
<asp:Content ID="con_Encabezado" ContentPlaceHolderID="cph_Encabezado" runat="server">
</asp:Content>
<asp:Content ID="con_Cuerpo" ContentPlaceHolderID="cph_Cuerpo" runat="server">
    <input id="btn_1" type="button" value="Cambia Estilo" onclick="Formato_Letra()" />
    <table id="tab_Texto">
        <tr>
            <td>
                <b><asp:Label ID="lbl_Definicion" runat="server" Text="Definición:"></asp:Label><br /></b>
                var person = {firstName:"John", lastName:"Doe", age:50, eyeColor:"blue"};<br />
            </td>
        </tr>
        <tr>
            <td>
                <b><asp:Label ID="lbl_Propiedad" runat="server" Text="Propiedad:"></asp:Label><br /></b>
                person.lastName;<br />
                person["lastName"];
            </td>
        </tr>
        <tr>
            <td>
                <b><asp:Label ID="lbl_FuncionObj" runat="server" Text="Funcion en objeto:"></asp:Label><br /></b>
                var person = {<br />
                    firstName: "John",<br />
                    lastName : "Doe",<br />
                    id       : 5566,<br />
                    fullName : function() {<br />
                    return this.firstName + " " + this.lastName;<br />
                    }<br />
                };
                <br /><br />
                name = person.fullName();<br /><br />
                var x = new String();<br />
                var y = new Number();<br />
                var z = new Boolean();
            </td>
        </tr>
    </table>
</asp:Content>
