//  Creamos el objeto: gato
var gato = { 
    jugador_1: 0, celda_1: 0, ocupada_1: false, imagen_celda_1: '',
    jugador_2: 0, celda_2: 0, ocupada_2: false, imagen_celda_2: '',
    jugador_3: 0, celda_3: 0, ocupada_3: false, imagen_celda_3: '',
    jugador_4: 0, celda_4: 0, ocupada_4: false, imagen_celda_4: '',
    jugador_5: 0, celda_5: 0, ocupada_5: false, imagen_celda_5: '',
    jugador_6: 0, celda_6: 0, ocupada_6: false, imagen_celda_6: '',
    jugador_7: 0, celda_7: 0, ocupada_7: false, imagen_celda_7: '',
    jugador_8: 0, celda_8: 0, ocupada_8: false, imagen_celda_8: '',
    jugador_9: 0, celda_9: 0, ocupada_9: false, imagen_celda_9: ''
};
var celda;
var unacelda;
var tirojugador;
var movimientoj1;
var movimientoj2;

function Limpia_Tablero()
{
    tirojugador = 0;
    movimientoj1 = 1;
    movimientoj2 = 1;

    //  Función para limpiar el tablero
    for (i = 1; i < 10; i++)
    {
        celda = document.getElementById('img_' + i);
        if (celda !== undefined)
        {
            celda.src = './Imagenes/Blanco.png';
        }
        else
        {
            break;
        }
    }

    Inicializa_Objeto();
    Inicializa_Celdas();
    Bloquea_Jugada(1, true);
    Bloquea_Jugada(2, false);

    document.getElementById('div_Jugar').style.display = 'block';
}

function Prepara_Envio(numero, jugador)
{
    //  Función para habilitar o desabilitar el botón para iniciar el juego
    unacelda = Elije_Celda(numero, jugador);

    celda = document.getElementById(unacelda);
    if (celda !== undefined)
    {
        if (celda.checked === true)
        {
            if (jugador === 1)
            {
                document.getElementById('btn_EnviarJ1').disabled = false;
                tirojugador = numero;
            }
            else
            {
                document.getElementById('btn_EnviarJ2').disabled = false;
                tirojugador = numero;
            }
        }
        else
        {
            if (jugador === 1)
            {
                document.getElementById('btn_EnviarJ1').disabled = true;
            }
            else
            {
                document.getElementById('btn_EnviarJ2').disabled = true;
            }
        }
    }
}

function Elije_Celda(numero, jugador)
{
    //  Función para obtener el identificador de la celda para habilitar o desabilitar
    if (jugador === 2)
    {
        numero += 9;
    }

    return 'chk_' + numero;
}

function Empezar_Juego(jugador)
{
    //  Función para iniciar el juego del gato
    var resultado;

    resultado = Celdas_Duplicadas(jugador);
    if (resultado)
    {
        alert('Debe seleccionar una sola celda');
        return;
    }

    if (movimientoj1 < 3 || movimientoj2 < 3)
    {
        Valor_Objeto(jugador);
        Asigna_Imagen();
        Bloquea_Celda(jugador);
        Solicita_Turno(jugador);
    }
    else
    {
        if (movimientoj1 === 3)
        {
            resultado = Revisa_Ganador(1);
            if (resultado)
            {
                return;
            }
        }
        else if (movimientoj2 === 3)
        {
            resultado = Revisa_Ganador(2);
            if (resultado)
            {
                return;
            }
        }
        Valor_Objeto(jugador);
        Asigna_Imagen();
        Bloquea_Celda(jugador);
        Solicita_Turno(jugador);

        if (movimientoj1 > 3 || movimientoj2 > 3)
        {
            Valor_Objeto(jugador);
            Asigna_Imagen();
            Bloquea_Celda(jugador);
            resultado = Revisa_Ganador(1);
            if (resultado)
            {
                return;
            }
            resultado = Revisa_Ganador(2);
            if (resultado)
            {
                return;
            }
            Solicita_Turno(jugador);
        }
    }    

    resultado = Tablero_Lleno();
    if (resultado)
    {
        document.getElementById('div_Ganador').innerHTML = '<h2>!!!! NO HAY GANADOR ¡¡¡¡</h2>';
    }
}

function Valor_Objeto(jugador)
{
    //  Función para asignar las propiedades para el objeto gato dependiendo de la celda
    var imagen = '';

    if (jugador === 1)
    {
        imagen = './Imagenes/Bicycle.png';
    }
    else
    {
        imagen = './Imagenes/Motorcycle.png';
    }
    switch (tirojugador)
    {
        case 1:
            gato.jugador_1 = jugador;
            gato.celda_1 = tirojugador; 
            gato.ocupada_1 = true;
            gato.imagen_celda_1 = imagen;
            break;
        case 2:
            gato.jugador_2 = jugador;
            gato.celda_2 = tirojugador;
            gato.ocupada_2 = true;
            gato.imagen_celda_2 = imagen;
            break;
        case 3:
            gato.jugador_3 = jugador;
            gato.celda_3 = tirojugador;
            gato.ocupada_3 = true;
            gato.imagen_celda_3 = imagen;
            break;
        case 4:
            gato.jugador_4 = jugador;
            gato.celda_4 = tirojugador;
            gato.ocupada_4 = true;
            gato.imagen_celda_4 = imagen;
            break;
        case 5:
            gato.jugador_5 = jugador;
            gato.celda_5 = tirojugador;
            gato.ocupada_5 = true;
            gato.imagen_celda_5 = imagen;
            break;
        case 6:
            gato.jugador_6 = jugador;
            gato.celda_6 = tirojugador;
            gato.ocupada_6 = true;
            gato.imagen_celda_6 = imagen;
            break;
        case 7:
            gato.jugador_7 = jugador;
            gato.celda_7 = tirojugador;
            gato.ocupada_7 = true;
            gato.imagen_celda_7 = imagen;
            break;
        case 8:
            gato.jugador_8 = jugador;
            gato.celda_8 = tirojugador;
            gato.ocupada_8 = true;
            gato.imagen_celda_8 = imagen;
            break;
        case 9:
            gato.jugador_9 = jugador;
            gato.celda_9 = tirojugador;
            gato.ocupada_9 = true;
            gato.imagen_celda_9 = imagen;
            break;
    }
}

function Asigna_Imagen()
{
    //  Función para asignar la imágen en el control
    celda = document.getElementById('img_' + tirojugador);
    if (celda !== undefined)
    {
        celda.src = Selecciona_Imagen();
    }
}

function Selecciona_Imagen()
{
    //  Función para seleccionar la imágen en el tablero
    var nombreimagen = '';

    switch (tirojugador)
    {
        case 1:
            nombreimagen = gato.imagen_celda_1;
            break;
        case 2:
            nombreimagen = gato.imagen_celda_2;
            break;
        case 3:
            nombreimagen = gato.imagen_celda_3;
            break;
        case 4:
            nombreimagen = gato.imagen_celda_4;
            break;
        case 5:
            nombreimagen = gato.imagen_celda_5;
            break;
        case 6:
            nombreimagen = gato.imagen_celda_6;
            break;
        case 7:
            nombreimagen = gato.imagen_celda_7;
            break;
        case 8:
            nombreimagen = gato.imagen_celda_8;
            break;
        case 9:
            nombreimagen = gato.imagen_celda_9;
            break;
    }

    return nombreimagen;
}

function Solicita_Turno(jugador)
{
    //  Función para mostrar el mensaje del turno del jugador en curso
    if (jugador === 1)
    {
        movimientoj1++;
        document.getElementById('lbl_Mensaje1').innerHTML = '';
        document.getElementById('lbl_Mensaje2').innerHTML = 'ES TU TURNO ...';
        document.getElementById('btn_EnviarJ1').disabled = true;
        document.getElementById('btn_EnviarJ2').disabled = false;
        Bloquea_Jugada(1, false);
        Bloquea_Jugada(2, true);
    }
    else
    {
        movimientoj2++;
        document.getElementById('lbl_Mensaje1').innerHTML = 'ES TU TURNO ...';
        document.getElementById('lbl_Mensaje2').innerHTML = '';
        document.getElementById('btn_EnviarJ1').disabled = false;
        document.getElementById('btn_EnviarJ2').disabled = true;
        Bloquea_Jugada(1, true);
        Bloquea_Jugada(2, false);
    }
}

function Bloquea_Celda(jugador)
{
    //  Función para bloquear la celda una vez seleccionada
    var indice = 0;
    var maximo = 0;

    if (jugador === 1)
    {
        indice = 1;
        maximo = 9;
    }
    else
    {
        indice = 10;
        maximo = 18;
    }

    for (i = indice; i <= maximo; i++)
    {
        celda = document.getElementById('chk_' + i);
        if (celda !== undefined)
        {
            if (celda.checked)
            {
                celda.disabled = true;
                Bloquea_CeldaE('chk_' + i);
            }
        }
    }
}

function Bloquea_CeldaE(celda)
{
    //  Función para bloquear la celda equivalente del jugador 1 o del jugador 2
    switch (celda)
    {
        case 'chk_1':
            document.getElementById('chk_1').color = 'ff0000';
            document.getElementById('chk_10').color = 'ff0000';
            document.getElementById('chk_10').disabled = true;
            break;
        case 'chk_2':
            document.getElementById('chk_2').color = 'ff0000';
            document.getElementById('chk_11').color = 'ff0000';
            document.getElementById('chk_11').disabled = true;
            break;
        case 'chk_3':
            document.getElementById('chk_3').color = 'ff0000';
            document.getElementById('chk_12').color = 'ff0000';
            document.getElementById('chk_12').disabled = true;
            break;
        case 'chk_4':
            document.getElementById('chk_4').color = 'ff0000';
            document.getElementById('chk_13').color = 'ff0000';
            document.getElementById('chk_13').disabled = true;
            break;
        case 'chk_5':
            document.getElementById('chk_5').color = 'ff0000';
            document.getElementById('chk_14').color = 'ff0000';
            document.getElementById('chk_14').disabled = true;
            break;
        case 'chk_6':
            document.getElementById('chk_6').color = 'ff0000';
            document.getElementById('chk_15').color = 'ff0000';
            document.getElementById('chk_15').disabled = true;
            break;
        case 'chk_7':
            document.getElementById('chk_7').color = 'ff0000';
            document.getElementById('chk_16').color = 'ff0000';
            document.getElementById('chk_16').disabled = true;
            break;
        case 'chk_8':
            document.getElementById('chk_8').color = 'ff0000';
            document.getElementById('chk_17').color = 'ff0000';
            document.getElementById('chk_17').disabled = true;
            break;
        case 'chk_9':
            document.getElementById('chk_9').color = 'ff0000';
            document.getElementById('chk_18').color = 'ff0000';
            document.getElementById('chk_18').disabled = true;
            break;
        case 'chk_10':
            document.getElementById('chk_10').color = 'ff0000';
            document.getElementById('chk_1').color = 'ff0000';
            document.getElementById('chk_1').disabled = true;
            break;
        case 'chk_11':
            document.getElementById('chk_11').color = 'ff0000';
            document.getElementById('chk_2').color = 'ff0000';
            document.getElementById('chk_2').disabled = true;
            break;
        case 'chk_12':
            document.getElementById('chk_12').color = 'ff0000';
            document.getElementById('chk_3').color = 'ff0000';
            document.getElementById('chk_3').disabled = true;
            break;
        case 'chk_13':
            document.getElementById('chk_13').color = 'ff0000';
            document.getElementById('chk_4').color = 'ff0000';
            document.getElementById('chk_4').disabled = true;
            break;
        case 'chk_14':
            document.getElementById('chk_14').color = 'ff0000';
            document.getElementById('chk_5').color = 'ff0000';
            document.getElementById('chk_5').disabled = true;
            break;
        case 'chk_15':
            document.getElementById('chk_15').color = 'ff0000';
            document.getElementById('chk_6').color = 'ff0000';
            document.getElementById('chk_6').disabled = true;
            break;
        case 'chk_16':
            document.getElementById('chk_16').color = 'ff0000';
            document.getElementById('chk_7').color = 'ff0000';
            document.getElementById('chk_7').disabled = true;
            break;
        case 'chk_17':
            document.getElementById('chk_17').color = 'ff0000';
            document.getElementById('chk_8').color = 'ff0000';
            document.getElementById('chk_8').disabled = true;
            break;
        case 'chk_18':
            document.getElementById('chk_18').color = 'ff0000';
            document.getElementById('chk_9').color = 'ff0000';
            document.getElementById('chk_9').disabled = true;
            break;
    }
}

function Revisa_Ganador(jugador)
{
    //  Funcion que revisa las jugadas que hayan realizado los jugadores
    var indice = '';
    var elemento = 0;
    var numelemento = 1;
    var continua = false;
    var celdas = [];
    var ocupadas = [];
    var imagenes = [];
    var contador = 0;
    var cadena = '';
    var inicio;
    var resultado = false;

    Object.getOwnPropertyNames(gato).forEach(function (val, idx, array)
    {
        //  Número de jugador
        elemento = val.indexOf('jugador_');
        if (elemento !== -1)
        {
            if (gato[val] > 0 && gato[val] === jugador)
            {
                indice = val.substr(8, val.length - 1);
                if (numelemento === 1)
                {
                    numelemento++;
                }
                else
                {
                    numelemento = 1;
                    numelemento++;
                }
                continua = true;
            }
        }
        else
        {
            if (continua)
            {
                switch (numelemento)
                {
                    case 2:
                        //  Número de celda
                        elemento = val.indexOf('celda_' + indice);
                        if (elemento !== -1)
                        {
                            celdas.push(gato[val]);
                        }
                        break;
                    case 3:
                        //  Celda ocupada
                        elemento = val.indexOf('ocupada_' + indice);
                        if (elemento !== -1)
                        {
                            ocupadas.push(gato[val]);
                        }
                        break;
                    case 4:
                        //  Imágen jugador
                        elemento = val.indexOf('imagen_celda_' + indice);
                        if (elemento !== -1)
                        {
                            imagenes.push(gato[val]);
                        }
                        break;
                }
                numelemento++;
            }
        }
    });

    //  Revisamos después de 3 jugadas si existe un ganador
    if (celdas.length >= 3 && ocupadas.length >= 3 && imagenes.length >= 3)
    {
        if (celdas.length > 3)
        {
            inicio = 1;
            contador = 3;
        }
        else
        {
            inicio = 0;
            contador = 2;
        }

        for (i = inicio; i < celdas.length; i++)
        {
            if (i < contador)
            {
                cadena += celdas[i] + ',' + ocupadas[i] + ',' + imagenes[i] + ';';
            }
            else
            {
                cadena += celdas[i] + ',' + ocupadas[i] + ',' + imagenes[i];
                resultado = Combinacion_Ganadora(jugador, cadena);
                if (resultado)
                {
                    document.getElementById('div_Ganador').innerHTML = '<h2>!!!! JUGADOR: ' + jugador + ' ERES EL GANADOR ¡¡¡¡</h2>';
                    document.getElementById('btn_EnviarJ1').disabled = true;
                    document.getElementById('btn_EnviarJ2').disabled = true;
                    break;
                }
                contador += 3;
            }
        }
    }

    return resultado;
}

function Combinacion_Ganadora(jugador, juego)
{
    //  Función que busca las combinaciones ganadoras
    var resultado;

    resultado = Ganadora_Horizontal(jugador, juego);
    if (!resultado)
    {
        resultado = Ganadora_Vertical(jugador, juego);
        if (!resultado)
        {
            resultado = Ganadora_Diagonal(jugador, juego);
        }
    }

    return resultado;
}

function Ganadora_Horizontal(jugador, juego)
{
    //  Funcion que busca las combinaciones ganadoras horizontalmente
    var tiradas = juego.split(';');
    var cadena = Llena_Combinaciones(tiradas);
    var combinaciones = cadena.split(',');
    var continuar;
    var resultado = false;

    //  Celda ocupada
    if (combinaciones[1] === 'true' && combinaciones[4] === 'true' && combinaciones[7] === 'true')
    {
        //  Número de celda
        if (combinaciones[0] === '1' && combinaciones[3] === '2' && combinaciones[6] === '3')
        {
            continuar = true;
        }
        else if (combinaciones[0] === '4' && combinaciones[3] === '5' && combinaciones[6] === '6')
        {
            continuar = true;
        }
        else if (combinaciones[0] === '7' && combinaciones[3] === '8' && combinaciones[6] === '9')
        {
            continuar = true;
        }
        else
        {
            continuar = false;
        }

        if (continuar)
        {
            if (jugador === 1)
            {
                if (combinaciones[2] === './Imagenes/Bicycle.png' && combinaciones[5] === './Imagenes/Bicycle.png' && combinaciones[8] === './Imagenes/Bicycle.png')
                {
                    document.getElementById('img_' + combinaciones[0]).src = './Imagenes/BicycleWin.png';
                    document.getElementById('img_' + combinaciones[3]).src = './Imagenes/BicycleWin.png';
                    document.getElementById('img_' + combinaciones[6]).src = './Imagenes/BicycleWin.png';
                    resultado = true;
                }
            }
            else
            {
                if (combinaciones[2] === './Imagenes/Motorcycle.png' && combinaciones[5] === './Imagenes/Motorcycle.png' && combinaciones[8] === './Imagenes/Motorcycle.png')
                {
                    document.getElementById('img_' + combinaciones[0]).src = './Imagenes/MotorcycleWin.png';
                    document.getElementById('img_' + combinaciones[3]).src = './Imagenes/MotorcycleWin.png';
                    document.getElementById('img_' + combinaciones[6]).src = './Imagenes/MotorcycleWin.png';
                    resultado = true;
                }
            }
        }
    }

    return resultado;
}

function Ganadora_Vertical(jugador, juego)
{
    //  Funcion que busca las combinaciones ganadoras verticalmente
    var tiradas = juego.split(';');
    var cadena = Llena_Combinaciones(tiradas);
    var combinaciones = cadena.split(',');
    var continuar;
    var resultado = false;

    //  Celda ocupada
    if (combinaciones[1] === 'true' && combinaciones[4] === 'true' && combinaciones[7] === 'true')
    {
        //  Número de celda
        if (combinaciones[0] === '1' && combinaciones[3] === '4' && combinaciones[6] === '7')
        {
            continuar = true;
        }
        else if (combinaciones[0] === '2' && combinaciones[3] === '5' && combinaciones[6] === '8')
        {
            continuar = true;
        }
        else if (combinaciones[0] === '3' && combinaciones[3] === '6' && combinaciones[6] === '9')
        {
            continuar = true;
        }
        else
        {
            continuar = false;
        }

        if (continuar)
        {
            if (jugador === 1)
            {
                if (combinaciones[2] === './Imagenes/Bicycle.png' && combinaciones[5] === './Imagenes/Bicycle.png' && combinaciones[8] === './Imagenes/Bicycle.png')
                {
                    document.getElementById('img_' + combinaciones[0]).src = './Imagenes/BicycleWin.png';
                    document.getElementById('img_' + combinaciones[3]).src = './Imagenes/BicycleWin.png';
                    document.getElementById('img_' + combinaciones[6]).src = './Imagenes/BicycleWin.png';
                    resultado = true;
                }
            }
            else
            {
                if (combinaciones[2] === './Imagenes/Motorcycle.png' && combinaciones[5] === './Imagenes/Motorcycle.png' && combinaciones[8] === './Imagenes/Motorcycle.png')
                {
                    document.getElementById('img_' + combinaciones[0]).src = './Imagenes/MotorcycleWin.png';
                    document.getElementById('img_' + combinaciones[3]).src = './Imagenes/MotorcycleWin.png';
                    document.getElementById('img_' + combinaciones[6]).src = './Imagenes/MotorcycleWin.png';
                    resultado = true;
                }
            }
        }
    }

    return resultado;
}

function Ganadora_Diagonal(jugador, juego)
{
    //  Funcion que busca las combinaciones ganadoras diagonalmente
    var tiradas = juego.split(';');
    var cadena = Llena_Combinaciones(tiradas);
    var combinaciones = cadena.split(',');
    var continuar;
    var resultado = false;

    //  Celda ocupada
    if (combinaciones[1] === 'true' && combinaciones[4] === 'true' && combinaciones[7] === 'true')
    {
        //  Número de celda
        if (combinaciones[0] === '1' && combinaciones[3] === '5' && combinaciones[6] === '9')
        {
            continuar = true;
        }
        else if (combinaciones[0] === '3' && combinaciones[3] === '5' && combinaciones[6] === '7')
        {
            continuar = true;
        }
        else
        {
            continuar = false;
        }

        if (continuar)
        {
            if (jugador === 1)
            {
                if (combinaciones[2] === './Imagenes/Bicycle.png' && combinaciones[5] === './Imagenes/Bicycle.png' && combinaciones[8] === './Imagenes/Bicycle.png')
                {
                    document.getElementById('img_' + combinaciones[0]).src = './Imagenes/BicycleWin.png';
                    document.getElementById('img_' + combinaciones[3]).src = './Imagenes/BicycleWin.png';
                    document.getElementById('img_' + combinaciones[6]).src = './Imagenes/BicycleWin.png';
                    resultado = true;
                }
            }
            else
            {
                if (combinaciones[2] === './Imagenes/Motorcycle.png' && combinaciones[5] === './Imagenes/Motorcycle.png' && combinaciones[8] === './Imagenes/Motorcycle.png')
                {
                    document.getElementById('img_' + combinaciones[0]).src = './Imagenes/MotorcycleWin.png';
                    document.getElementById('img_' + combinaciones[3]).src = './Imagenes/MotorcycleWin.png';
                    document.getElementById('img_' + combinaciones[6]).src = './Imagenes/MotorcycleWin.png';
                    resultado = true;
                }
            }
        }
    }

    return resultado;
}

function Inicializa_Tablero()
{
    //  Función que inicializa el proceso para empezar un nuevo juego
    celda = null;
    unacelda = null;
    tirojugador = 0;
    movimientoj1 = 1;
    movimientoj2 = 1;

    Limpia_Tablero();
    Inicializa_Objeto();
    Inicializa_Celdas();
    Bloquea_Jugada(1, true);
    Bloquea_Jugada(2, false);

    document.getElementById('lbl_Mensaje1').innerHTML = '';
    document.getElementById('lbl_Mensaje2').innerHTML = '';
    document.getElementById('div_Ganador').innerHTML = '';
    document.getElementById('btn_EnviarJ1').disabled = true;
    document.getElementById('btn_EnviarJ2').disabled = true;
}

function Tablero_Lleno()
{
    //  Funcion que verifica si el tablero esta lleno, indicativo de que nadie gano
    var elemento;
    var estalleno;

    for (i = 1; i <= 9; i++)
    {
        celda = document.getElementById('img_' + i);
        if (celda !== undefined)
        {
            elemento = celda.src.indexOf('/Imagenes/Blanco.png');
            if (elemento !== -1)
            {
                estalleno = false; 
                break;
            }
            else
            {
                estalleno = true;
            }
        }
        else
        {
            break;
        }
    }

    return estalleno;
}

function Llena_Combinaciones(tiradas)
{
    //  Función que regresa una cadena con las tiradas realizadas por el jugador
    var cadena = '';

    for (j = 0; j < tiradas.length; j++)
    {
        cadena += tiradas[j] + ',';
    }

    return cadena;
}

function Inicializa_Objeto()
{
    //  Función que inicializa el objeto gato
    gato.jugador_1 = 0;
    gato.celda_1 = 0;
    gato.ocupada_1 = false;
    gato.imagen_celda_1 = '';
    gato.jugador_2 = 0;
    gato.celda_2 = 0;
    gato.ocupada_2 = false;
    gato.imagen_celda_2 = '';
    gato.jugador_3 = 0;
    gato.celda_3 = 0;
    gato.ocupada_3 = false;
    gato.imagen_celda_3 = '';
    gato.jugador_4 = 0;
    gato.celda_4 = 0;
    gato.ocupada_4 = false;
    gato.imagen_celda_4 = '';
    gato.jugador_5 = 0;
    gato.celda_5 = 0;
    gato.ocupada_5 = false;
    gato.imagen_celda_5 = '';
    gato.jugador_6 = 0;
    gato.celda_6 = 0;
    gato.ocupada_6 = false;
    gato.imagen_celda_6 = '';
    gato.jugador_7 = 0;
    gato.celda_7 = 0;
    gato.ocupada_7 = false;
    gato.imagen_celda_7 = '';
    gato.jugador_8 = 0;
    gato.celda_8 = 0;
    gato.ocupada_8 = false;
    gato.imagen_celda_8 = '';
    gato.jugador_9 = 0;
    gato.celda_9 = 0;
    gato.ocupada_9 = false;
    gato.imagen_celda_9 = '';
}

function Inicializa_Celdas()
{
    //  Función que inicializa el color de las celdas para iniciar el juego
    for (k = 1; k <= 18; k++)
    {
        celda = document.getElementById('chk_' + k);
        if (celda !== undefined)
        {
            celda.color = 'ffffff';
            celda.checked = false;
        }
        else
        {
            break;
        }
    }
}

function Bloquea_Jugada(jugador, bandera)
{
    //  Función que bloquea las celdas del jugador contrario para que no las pueda seleccionar
    var indice = 0;
    var maximo = 0;

    if (jugador === 1)
    {
        indice = 10;
        maximo = 18;
    }
    else
    {
        indice = 1;
        maximo = 9;
    }

    for (i = indice; i <= maximo; i++)
    {
        celda = document.getElementById('chk_' + i);
        if (celda !== undefined)
        {
            if (celda.color !== 'ff0000')
            {
                celda.disabled = bandera;
            }
        }
    }
}

function Celdas_Duplicadas(jugador)
{
    //  Función que valida que no hayan seleccionado mas de una celda
    var indice = 0;
    var maximo = 0;
    var contador = 0;
    var duplicadas = false;

    if (jugador === 1)
    {
        indice = 1;
        maximo = 9;
    }
    else
    {
        indice = 10;
        maximo = 18;
    }

    for (i = indice; i <= maximo; i++)
    {
        celda = document.getElementById('chk_' + i);
        if (celda !== undefined)
        {
            if (celda.color !== 'ff0000')
            {
                if (celda.checked)
                {
                    contador++;
                }
            }
        }
        if (contador > 1)
        {
            duplicadas = true;
            break;
        }
    }

    return duplicadas;
}