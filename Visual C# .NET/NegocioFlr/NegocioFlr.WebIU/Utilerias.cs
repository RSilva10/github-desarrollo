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
        /// <param name="_oControl">Controles de la página</param>
        /// <param name="_sMensaje">Descripción del mensaje</param>
        /// <param name="_iTipomensaje">Tipo de mensaje a mostrar:
        ///                            0 = Informacion
        ///                            1 = Precaucion
        ///                            2 = Satisfactorio
        ///                            3 = Error
        /// </param>
        public void muestra_Mensaje(Control _oControl, string _sMensaje, int _iTipomensaje)
        {
            _sMensaje = _sMensaje.Replace("'", "");

            string _sScript = "muestra_Mensaje('" + _sMensaje.Trim() + "', " + _iTipomensaje + ");";
                
            _oControl.Page.ClientScript.RegisterStartupScript(_oControl.GetType(), "muestra_Mensaje", _sScript, true);
        }
    }
}