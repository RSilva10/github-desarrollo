<%@ Page Title="" Language="C#" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="Attributos.aspx.cs" Inherits="Ejercicios.Attributos" %>

<asp:Content ID="con_Encabezado" ContentPlaceHolderID="cph_Encabezado" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    <script src="Scripts/Indice.js"></script>
    <link href="Estilos/Estilo_Curso.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Con_Cuerpo" ContentPlaceHolderID="cph_Cuerpo" runat="server">
    <table class="table">
        <thead class="thead-dark">
            <tr>
                <th scope="col">Comando</th>
                <th scope="col">Funcionalidad</th>
                <th scope="col">Ejemplo</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope="row">document.getElementById('ID_Elemento').src = 'Ubicacion_Imagen';</th>
                <td>Con la propiedad: src asigna una determinada imágen</td>
                <td>
                    <b><asp:Label ID="lbl_Imagen" runat="server" Text="Cambio Imagen:"></asp:Label></b>
                </td>
                <td>
                    <input id="btn_1" type="button" value="Derecha" onclick="Atributo_Imagen(0)" />
                    <input id="btn_2" type="button" value="Izquierda" onclick="Atributo_Imagen(1)" />
                </td>
                <td>
                    <img id="img_Imagen" src="./Imagenes/PreviousMenuButtonIcon.png" />
                </td>
            </tr>
            <tr>
                <th scope="row">document.getElementById('ID_Elemento').style.fontSize = 'cantidad_pixeles';</th>
                <td>Con la propiedad: style.fontSize asigna un determinado estilo de letra y tamaño. Ejem: (50px)</td>
                <td>
                    <b><asp:Label ID="lbl_Estilo" runat="server" Text="Cambio Estilo:"></asp:Label></b>
                </td>
                <td>
                    <input id="btn_3" type="button" value="Estilo" onclick="Atributo_Estilo()" />
                </td>
            </tr>
            <tr>
                <th scope="row">document.getElementById('ID_Elemento').style.display = 'none';</th>
                <td>Con la propiedad: style.display = 'none' oculta un elemento</td>
                <td>
                    <input id="btn_4" type="button" value="Ocultar" onclick="Ocultar_Elemento()" />
                </td>
            </tr>
            <tr>
                <th scope="row">document.getElementById('ID_Elemento').style.display = 'block';</th>
                <td>Con la propiedad: style.display = 'blobk' muestra un elemento</td>
                <td>
                    <input id="btn_5" type="button" value="Mostrar" onclick="Mostrar_Elemento()" />
                </td>
            </tr>
        </tbody>
    </table>
    <div id="div_Resultado">
        Este es un texto de ejemplo para los atributos
    </div>
    <div class="footer">
        <p><a href="Indice.aspx">Regresar al ménu principal</a></p>
    </div>
</asp:Content>
