using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioFlr.Entidades; 
using NegocioFlr.Negocio;

namespace NegocioFlr.WebIU.Paginas
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        #region Variables
        private Usuarios _objUsuarios = new Usuarios();
        private UsuariosNegocio _objNegocioUsuario = new UsuariosNegocio();
        private String _Estatus;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime _Hoy = DateTime.Today;
            TimeSpan _Vigencia;
                         
            if (Session["USR_INF"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                _objUsuarios = (Usuarios)Session["USR_INF"];

                if (!IsPostBack)
                {
                    _Vigencia = _objUsuarios.Fec_Vig - _Hoy;

                    this.lbl_Copyrigth.Text = "Desarrollo de Aplicaciones a la Medida &copy; Copyrigth " + DateTime.Now.Year.ToString() + " todos los derechos reservados.";
                    this.lbl_Informativo.Text = "Fecha vigencia acceso: " + _objUsuarios.Fec_Vig.Date.ToString().Substring(0, 10);
                    this.lbl_Vigencia.Text = "Días vigencia acceso: " + _Vigencia.ToString().Substring(0, 2);

                }
            }
        }

        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            bool _Resultado;

            _Resultado = _objNegocioUsuario.elimina_Sesion(_objUsuarios, ref _Estatus);
            if (_Resultado && _Estatus == null)
            {
                Session.Abandon();
            }

            Response.Redirect("~/Login.aspx");
        }
    }
}