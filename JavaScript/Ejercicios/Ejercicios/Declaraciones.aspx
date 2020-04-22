<%@ Page Title="" Language="C#" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="Declaraciones.aspx.cs" Inherits="Ejercicios.Declaraciones" %>
<asp:Content ID="con_Encabezado" ContentPlaceHolderID="cph_Encabezado" runat="server">
</asp:Content>
<asp:Content ID="con_Cuerpo" ContentPlaceHolderID="cph_Cuerpo" runat="server">
    <input id="btn_1" type="button" value="Cambia Estilo" onclick="Formato_Letra()" />
    <table id="tab_Texto">
        <tr>
            <td>
                <b><asp:Label ID="lbl_Declaracion" runat="server" Text="Declaraciones:"></asp:Label></b>
                <br />
                var x, y, z;
                x = 5;
                y = 6;
                z = x + y;
                <br />
                a = 5; b = 6; c = a + b;
                <br />
                var person = "Hege";
                <br />
                var person = "John Doe", carName = "Volvo", price = 200;
                <br />
                var person = "John Doe",<br />
                carName = "Volvo",<br />
                price = 200;
                <br />
                var x = "5" + 2 + 3; --> Toda la cadena se convierte en string
            </td>
        </tr>
        <tr>
            <td>
                <b><asp:Label ID="lbl_Operadores" runat="server" Text="Operadores Aritmeticos:"></asp:Label></b>
                <br />
                ( + - * ** / % ++ -- )
                <br />
                **  Exponenciación
                <br />
                %   Residuo
            </td>
        </tr>
        <tr>
            <td>
                <b><asp:Label ID="lbl_Logicos" runat="server" Text="Operadores Logicos:"></asp:Label></b>
                <br />
                &&  AND
                <br />
                ||  OR
                <br />
                !   NOT
                <br />
                var x = 5;
                var y = 5;
                var z = 6;
                (x == y)       // Returns true
                (x == z)       // Returns false
            </td>
        </tr>
        <tr>
            <td>
                <b><asp:Label ID="lbl_Arreglos" runat="server" Text="Arreglos:"></asp:Label></b>
                var cars = ["Saab", "Volvo", "BMW"];
            </td>
        </tr>
        <tr>
            <td>
                <b><asp:Label ID="lbl_Objetos" runat="server" Text="Objetos:"></asp:Label></b>
                var person = {firstName:"John", lastName:"Doe", age:50, eyeColor:"blue"};
            </td>
        </tr>
    </table>
</asp:Content>
