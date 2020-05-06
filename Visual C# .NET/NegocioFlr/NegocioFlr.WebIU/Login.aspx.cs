using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioFlr.Entidades;
using NegocioFlr.Negocio;  

namespace NegocioFlr.WebIU
{
    public partial class Login : System.Web.UI.Page
    {
        #region Variables
        private Usuarios _objUsuarios = new Usuarios();
        private UsuariosNegocio _objNegocioUsuario = new UsuariosNegocio();
        private List<Usuarios> _lstUsuarios;
        private String _Estatus; 
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string _SActiva = string.Empty;

            if (! IsPostBack)
            {
                _SActiva = Request.QueryString["S"];
                if (_SActiva != null)
                {
                    muestra_Mensaje("!! Su sesión ha caducado. Vuelva a ingresar al sistema ... ¡¡");
                    return;
                }
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            int _Sesion;
            bool _Resultado;

            if (!valida_Datos())
            {
                return;
            }

            _objUsuarios.Cve_Usr = this.txt_Usuario.Value;
            _objUsuarios.Pas_Usr = this.txt_Password.Value;
            _lstUsuarios = _objNegocioUsuario.regresa_Usuario(_objUsuarios, ref _Estatus);
            if (_lstUsuarios.Count == 0 && _Estatus == null)
            {
                muestra_Mensaje("!! Usuario no registrado ... ¡¡");
                return;
            }
            else if (_Estatus != null)
            {
                muestra_Mensaje("!! " + _Estatus.Trim() + " ... ¡¡");
                return;
            }

            foreach (Usuarios _usuario in _lstUsuarios)
            {
                _objUsuarios.Ide_Usr = _lstUsuarios[0].Ide_Usr;
                _objUsuarios.Ape_Pat = _lstUsuarios[0].Ape_Pat;
                _objUsuarios.Ape_Mat = _lstUsuarios[0].Ape_Mat;
                _objUsuarios.Nom_bre = _lstUsuarios[0].Nom_bre;
                _objUsuarios.Fec_Vig = _lstUsuarios[0].Fec_Vig;
                _objUsuarios.Cor_reo = _lstUsuarios[0].Cor_reo;
            }

            _Sesion = _objNegocioUsuario.regresa_Sesion(_objUsuarios, ref _Estatus);
            if (_Sesion == 0 && _Estatus == null)
            {
                _Resultado = _objNegocioUsuario.registra_Sesion(_objUsuarios, ref _Estatus);
                if (_Resultado && _Estatus == null)
                {
                    Session["USR_INF"] = _objUsuarios;
                }
                else if (_Estatus != null)
                {
                    muestra_Mensaje("!! " + _Estatus.Trim() + " ... ¡¡");
                    return;
                }
            }
            else
            {
                muestra_Mensaje("!! El usuario " + _objUsuarios.Nom_bre.Trim() + " " + _objUsuarios.Ape_Pat.Trim() + " " + _objUsuarios.Ape_Mat.Trim() + " ya ha iniciado una sesion antes ... ¡¡");
                return;
            }

            Response.Redirect("~/Paginas/Principal.aspx");
        }

        protected void btn_Registro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Registro.aspx"); 
        }

        /// <summary>
        /// Validación de información proporcionada
        /// </summary>
        /// <returns>Verdadero si los datos son correctos, Falso si no lo son</returns>
        protected Boolean valida_Datos()
        {
            bool _Resultado = true;
            
            if (this.txt_Usuario.Value == string.Empty)
            {
                muestra_Mensaje("!! Proporcione el usuario ... ¡¡");
                _Resultado = false; 
            }
            else if (this.txt_Password.Value == string.Empty)
            {
                muestra_Mensaje("!! Proporcione la contraseña ... ¡¡"); 
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