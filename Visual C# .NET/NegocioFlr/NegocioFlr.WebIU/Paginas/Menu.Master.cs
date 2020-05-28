using System;
using NegocioFlr.Entidades; 
using NegocioFlr.Negocio;

namespace NegocioFlr.WebIU.Paginas
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        #region Variables
        private Usuarios _objUsuarios = new Usuarios();
        private SesiUsrs _objSesiUsrs = new SesiUsrs();
        private SesiUsrsNegocio _objNegocioSesiUsr = new SesiUsrsNegocio();
        private Utilerias _objUtilerias = new Utilerias();
        private Int32 _Codigo;
        private String _Mensaje;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime _Hoy = DateTime.Today;
            TimeSpan _Vigencia;
                         
            if (Session["USR_INF"] == null || Session["USR_SES"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                _objUsuarios = (Usuarios)Session["USR_INF"];
                _objSesiUsrs = (SesiUsrs)Session["USR_SES"];

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

            _Resultado = _objNegocioSesiUsr.elimina_Sesion(_objSesiUsrs, ref _Codigo, ref _Mensaje);
            if (_Resultado) 
            {
                Session.Abandon();
            }
            else 
            {
                _objUtilerias.muestra_Mensaje(this, "!! " + _Codigo.ToString() + " " + _Mensaje.Trim() + " ... ¡¡", 3);
            }

            Response.Redirect("~/Login.aspx");
        }
    }
}