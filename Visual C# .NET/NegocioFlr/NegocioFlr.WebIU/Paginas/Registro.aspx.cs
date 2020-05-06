using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using NegocioFlr.Entidades;
using NegocioFlr.Negocio;

namespace NegocioFlr.WebIU.Paginas
{
    public partial class Registro : System.Web.UI.Page
    {
        #region Variables
        private Regex _Correo_valido = new Regex("^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$");
        private Usuarios _objUsuarios = new Usuarios();
        private UsuariosNegocio _objNegocioUsuario = new UsuariosNegocio();
        private String _Estatus;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Registrar_Click(object sender, EventArgs e)
        {
            bool _Resultado;
             
            if (!valida_Datos())
            {
                return;
            }

            _objUsuarios.Ope_Rac = 1;  
            _objUsuarios.Cve_Usr = this.txt_Usuario.Value;
            _objUsuarios.Ape_Pat = this.txt_Paterno.Value;
            _objUsuarios.Ape_Mat = this.txt_Materno.Value;
            _objUsuarios.Nom_bre = this.txt_Nombre.Value;
            _objUsuarios.Pas_Usr = string.Empty;
            _objUsuarios.Fec_Ing = Convert.ToDateTime("01/01/1900");
            _objUsuarios.Fec_Vig = Convert.ToDateTime("01/01/1900");
            _objUsuarios.Cor_reo = this.txt_Correo.Value;

            _Resultado = _objNegocioUsuario.registra_Usuario(_objUsuarios, ref _Estatus);             
            if (_Estatus != null)
            {
                muestra_Mensaje("!! " + _Estatus.Trim() + " ... ¡¡"); 
            }
            else
            {
                muestra_Mensaje("!! Su contraseña temporal es: " + _objUsuarios.genera_Pwd + " ... ¡¡");
            }
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected Boolean valida_Datos()
        {
            bool _Resultado = true;
            
            if (this.txt_Usuario.Value == string.Empty)
            {
                muestra_Mensaje("!! Proporcione clave usuario ... ¡¡"); 
                _Resultado = false;
            }
            else if (this.txt_Paterno.Value == string.Empty)
            {
                muestra_Mensaje("!! Proporcione apellido paterno ... ¡¡"); 
                _Resultado = false;
            }
            else if (this.txt_Materno.Value == string.Empty)
            {
                muestra_Mensaje("!! Proporcione apellido materno ... ¡¡"); 
                _Resultado = false;
            }
            else if (this.txt_Nombre.Value == string.Empty)
            {
                muestra_Mensaje("!! Proporcione nombre ... ¡¡"); 
                _Resultado = false;
            }
            else if (this.txt_Correo.Value == string.Empty)
            {
                muestra_Mensaje("!! Proporcione dirección correo electrónico ... ¡¡"); 
                _Resultado = false;
            }
            else if (! _Correo_valido.IsMatch(this.txt_Correo.Value))
            {
                muestra_Mensaje("!! Proporcione dirección correo electrónico valida ... ¡¡"); 
                _Resultado = false;
            }

            return _Resultado; 
        }

        /// <summary>
        /// Muestra un aviso en pantalla
        /// </summary>
        /// <param name="_mensaje">Mensaje que se va a mostrar</param>
        protected void muestra_Mensaje(string _mensaje)
        {
            string _script = @"<script type='text/javascript'> alert('" + _mensaje.Trim() + "')" + "</script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", _script, false);
        }
    }
}