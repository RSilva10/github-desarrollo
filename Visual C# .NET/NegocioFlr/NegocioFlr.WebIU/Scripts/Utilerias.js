//Muestra un mensaje dependiendo del tipo de mensaje:
function muestra_Mensaje(mensaje, tipomensaje)
{
    toastr.options.closeButton = true;

    switch (tipomensaje)
    {
        case 0:
            toastr.info(mensaje, "Información", {timeOut: 5000});
            break;
        case 1:
            toastr.warning(mensaje, "Precaución", {timeOut: 5000});
            break;
        case 2:
            toastr.success(mensaje, "Satisfactoria", {timeOut: 5000});
            break;
        case 3:
            toastr.error(mensaje, "Error", {timeOut: 5000});
    }
}