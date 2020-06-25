using System;
using System.Security.Cryptography;
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
        private UsuariosNegocio _objUsuarioNegocio = new UsuariosNegocio();
        private Utilerias _objUtilerias = new Utilerias();
        private Int32 _iCodigo;
        private String _sMensaje;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios _objVigencia = new Usuarios();
            int _iVigencia = 0;
            
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
                    _objVigencia.Ide_Usr = _objUsuarios.Ide_Usr;
                    _iVigencia = _objUsuarioNegocio.dias_Vigencia(_objVigencia, ref _iCodigo, ref _sMensaje);
                    if (_iCodigo != 0)
                    {
                        _objUtilerias.muestra_Mensaje(this, "!! " + _iCodigo.ToString() + " " + _sMensaje.Trim() + " ... ¡¡", 3);
                    }

                    if (_objUsuarios.Ico_Cli.Trim() != "")
                    {
                        this.img_Logo.ImageUrl = "~/Imagenes/Empresas/" + _objUsuarios.Ico_Cli + "";
                    }

                    string _sCadena = _objUsuarios.Rso_Cli.Trim() + "<br></br>";
                    _sCadena += _objUsuarios.Cal_Cli.Trim() + "<br>";
                    _sCadena += _objUsuarios.Col_Cli.Trim() + "<br>";
                    _sCadena += "Ext: " + _objUsuarios.NEx_Cli.Trim() + ", Int: " + _objUsuarios.NIn_Cli.Trim() + "<br>";
                    _sCadena += _objUsuarios.Del_Cli.Trim() + ", " + _objUsuarios.Ciu_Cli.Trim() + "<br>";
                    this.lbl_Empresa.InnerHtml = _sCadena.Trim();

                    _sCadena = "Bienvenido " + _objUsuarios.Nom_bre.Trim() + " " + _objUsuarios.Ape_Pat.Trim() + " " + _objUsuarios.Ape_Mat.Trim() + ":";
                    this.lbl_Bienvenido.InnerHtml = _sCadena;

                    _sCadena = "( Fecha vigencia acceso: " + _objUsuarios.Fec_Vig.Date.ToString().Substring(0, 10) + ", Días vigencia acceso: " + _iVigencia.ToString() + " )";
                    this.lbl_Informativo.InnerHtml = _sCadena;

                    this.lbl_CP.InnerHtml = "Desarrollo de Aplicaciones a la Medida &copy; Copyrigth " + DateTime.Now.Year.ToString() + " todos los derechos reservados.";
                }
            }
        }

        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            bool _Resultado;

            _Resultado = _objNegocioSesiUsr.elimina_Sesion(_objSesiUsrs, ref _iCodigo, ref _sMensaje);
            if (_Resultado) 
            {
                Session.Abandon();
            }
            else 
            {
                _objUtilerias.muestra_Mensaje(this, "!! " + _iCodigo.ToString() + " " + _sMensaje.Trim() + " ... ¡¡", 3);
            }

            Response.Redirect("~/Login.aspx");
        }
    }
}