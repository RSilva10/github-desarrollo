<%@ Page Title="" Language="C#" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="Funciones.aspx.cs" Inherits="Ejercicios.Funciones" %>
<asp:Content ID="con_Encabezado" ContentPlaceHolderID="cph_Encabezado" runat="server">
</asp:Content>
<asp:Content ID="con_Cuerpo" ContentPlaceHolderID="cph_Cuerpo" runat="server">
    <input id="btn_1" type="button" value="Cambia Estilo" onclick="Formato_Letra()" />
    <table id="tab_Texto">
        <tr>
            <td>
                <b><asp:Label ID="lbl_Definicion" runat="server" Text="Definición:"></asp:Label><br /></b>
                function name(parameter1, parameter2, parameter3)<br /> 
                {<br />
                    // code to be executed<br />
                }
            </td>
        </tr>
        <tr>
            <td>
                <b><asp:Label ID="lbl_Retornar" runat="server" Text="Retornar valor:"></asp:Label><br /></b>
                var x = myFunction(4, 3);<br />

                function myFunction(a, b) <br />
                {<br />
                    return a * b;         <br />
                }
            </td>
        </tr>
    </table>
</asp:Content>
