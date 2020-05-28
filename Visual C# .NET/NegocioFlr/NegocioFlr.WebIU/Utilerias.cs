using System.Web.UI;

namespace NegocioFlr.WebIU
{
    public class Utilerias
    {
        enum Mensajes
        {
            Informacion,
            Precaucion,
            Satisfactorio,
            Error
        }

        /// <summary>
        /// Muestra un mensaje en pantalla 
        /// </summary>
        /// <param name="control">Controles de la página</param>
        /// <param name="_mensaje">Descripción del mensaje</param>
        /// <param name="_tipomensaje">Tipo de mensaje a mostrar:
        ///                            0 = Informacion
        ///                            1 = Precaucion
        ///                            2 = Satisfactorio
        ///                            3 = Error
        /// </param>
        public void muestra_Mensaje(Control control, string _mensaje, int _tipomensaje)
        {
            string _script = "muestra_Mensaje('" + _mensaje.Trim() + "', " + _tipomensaje + ");";

            control.Page.ClientScript.RegisterStartupScript(control.GetType(), "muestra_Mensaje", _script, true);
        }
    }
}