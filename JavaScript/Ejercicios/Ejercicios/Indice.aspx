<%@ Page Title="" Language="C#" MasterPageFile="~/Indice.Master" AutoEventWireup="true" CodeBehind="Indice.aspx.cs" Inherits="Ejercicios.Indice1" %>

<asp:Content ID="cph_Titulo" ContentPlaceHolderID="cph_Encabezado" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="cph_Detalle" ContentPlaceHolderID="cph_Cuerpo" runat="server">
    <div class="container p-3 my-3 bg-dark text-white">
        <center><h1>Ejercicios JavaScript</h1>
        <h2>Indice Curso</h2></center>
    </div>
    <div class="container">
        <nav class="navbar navbar-expand-sm bg-light justify-content-center">

            <a class="navbar-brand" href="#">
                <img src="Imagenes/Logo.jpg" alt="logo" style="width: 50px;">
            </a>

            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="Asignaciones.aspx">Asignaciones</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Attributos.aspx">Atributos</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Declaraciones.aspx">Declaraciones</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Funciones.aspx">Funciones</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Objetos.aspx">Objetos</a>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbardrop" data-toggle="dropdown">Proyectos
                    </a>
                    <div class="dropdown-menu">
                        <a class="dropdown-item" href="Juego.aspx">Juego del Gato (Usuario1 vs Usuario2)</a>
                    </div>
                </li>
            </ul>
        </nav>
    </div>
</asp:Content>
