function Limpia_Resultado()
{
    document.getElementById('div_Resultado').innerHTML = ''; 
}

function Fecha_Hora()
{
    Limpia_Resultado();
    document.getElementById('div_Resultado').innerHTML = '<h2>' + Date() + '</h2>'; 
    document.getElementById('div_Resultado').style.fontSize = "20px"; 
}

function Atributo_Imagen(valor)
{
    var imagen = "";

    if (valor === 0)
    {
        imagen = './Imagenes/NextMenuButtonIcon.png';
    }
    else
    {
        imagen = './Imagenes/PreviousMenuButtonIcon.png';
    }

    document.getElementById('img_Imagen').src = imagen;
}

function Atributo_Estilo()
{
    document.getElementById('div_Resultado').style.fontSize = "50px";
}

function Ocultar_Elemento()
{
    document.getElementById('div_Resultado').style.display = 'none';
}

function Mostrar_Elemento()
{
    document.getElementById('div_Resultado').style.display = 'block';
}

function Formato_Letra()
{
    document.getElementById('tab_Texto').style.fontSize = "30px";
}