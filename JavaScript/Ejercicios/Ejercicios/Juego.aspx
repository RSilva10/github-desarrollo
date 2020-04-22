<%@ Page Title="" Language="C#" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="Juego.aspx.cs" Inherits="Ejercicios.Juego" %>
<asp:Content ID="con_Encabezado" ContentPlaceHolderID="cph_Encabezado" runat="server">
    <script type="text/javascript" src="Scripts/Juego.js?v=<%=Guid.NewGuid().ToString()%>" ></script>
</asp:Content>
<asp:Content ID="con_Cuerpo" ContentPlaceHolderID="cph_Cuerpo" runat="server">
    <table border="1">
        <tr>
            <td>
                <img id="img_1" src="Imagenes/Bicycle.png" />
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>
                <img id="img_2" src="Imagenes/Motorcycle.png" />
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>
                <img id="img_3" src="Imagenes/Bicycle.png" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <img id="img_4" src="Imagenes/Motorcycle.png" />
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>
                <img id="img_5" src="Imagenes/Bicycle.png" />
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>
                <img id="img_6" src="Imagenes/Motorcycle.png" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <img id="img_7" src="Imagenes/Bicycle.png" />
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>
                <img id="img_8" src="Imagenes/Motorcycle.png" />
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>
                <img id="img_9" src="Imagenes/Bicycle.png" />
            </td>
        </tr>
    </table>
    <p></p>
    <p></p>
    <table>
        <tr>
            <td>
                <input id="btn_Limpiar" type="button" value="Limpiar tablero" onclick="Limpia_Tablero()" />
            </td>
            <td>
                <input id="btn_Inicializar" type="button" value="Inicializar juego" onclick="Inicializa_Tablero()" />
            </td>
        </tr>
    </table>
    <p></p>
    <p></p>
    <p></p>
    <div id="div_Jugar" style="display:none">
        <b><asp:Label ID="lbl_Sel1" runat="server" Text="Jugador 1 ==> Seleccione una celda:"></asp:Label></b>
        <p></p>
        <p></p>
        <input id="chk_1" type="checkbox" onclick="Prepara_Envio(1,1)" />C1
        <input id="chk_2" type="checkbox" onclick="Prepara_Envio(2,1)" />C2
        <input id="chk_3" type="checkbox" onclick="Prepara_Envio(3,1)" />C3
        <input id="chk_4" type="checkbox" onclick="Prepara_Envio(4,1)" />C4
        <input id="chk_5" type="checkbox" onclick="Prepara_Envio(5,1)" />C5
        <input id="chk_6" type="checkbox" onclick="Prepara_Envio(6,1)" />C6
        <input id="chk_7" type="checkbox" onclick="Prepara_Envio(7,1)" />C7
        <input id="chk_8" type="checkbox" onclick="Prepara_Envio(8,1)" />C8
        <input id="chk_9" type="checkbox" onclick="Prepara_Envio(9,1)" />C9
        <p></p>
        <p></p>
        <input id="btn_EnviarJ1" type="button" value="Enviar Juego Jugador 1" disabled onclick="Empezar_Juego(1)" /><br /><b><label id="lbl_Mensaje1"></label></b>
        <p></p>
        <p></p>
        <p></p>
        <b><asp:Label ID="lbl_Sel2" runat="server" Text="Jugador 2 ==> Seleccione una celda:"></asp:Label></b>
        <p></p>
        <p></p>
        <input id="chk_10" type="checkbox" onclick="Prepara_Envio(1,2)" />C1
        <input id="chk_11" type="checkbox" onclick="Prepara_Envio(2,2)" />C2
        <input id="chk_12" type="checkbox" onclick="Prepara_Envio(3,2)" />C3
        <input id="chk_13" type="checkbox" onclick="Prepara_Envio(4,2)" />C4
        <input id="chk_14" type="checkbox" onclick="Prepara_Envio(5,2)" />C5
        <input id="chk_15" type="checkbox" onclick="Prepara_Envio(6,2)" />C6
        <input id="chk_16" type="checkbox" onclick="Prepara_Envio(7,2)" />C7
        <input id="chk_17" type="checkbox" onclick="Prepara_Envio(8,2)" />C8
        <input id="chk_18" type="checkbox" onclick="Prepara_Envio(9,2)" />C9
        <p></p>
        <p></p>
        <input id="btn_EnviarJ2" type="button" value="Enviar Juego Jugador 2" disabled onclick="Empezar_Juego(2)" /><br /><b><label id="lbl_Mensaje2" for=""></label></b>
    </div>
    <div id="div_Ganador">
    </div>
</asp:Content>
