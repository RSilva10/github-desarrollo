<%@ Page Title="" Language="C#" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="Ejercicios.Asignaciones" %>

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
<asp:Content ID="con_Cuerpo" ContentPlaceHolderID="cph_Cuerpo" runat="server">
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
                <th scope="row">document.getElementById('ID_elemento')</th>
                <td>Devuelve una referencia al elemento por su ID</td>
                <td><input id="btn_1" type="button" value="Fecha-Hora" onclick="Fecha_Hora()" /></td>
            </tr>
        </tbody>
    </table>
    <div id="div_Resultado">

    </div>
    <div class="footer">
        <p><a href="Indice.aspx">Regresar al ménu principal</a></p>
    </div>
</asp:Content>
