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
    public partial class Principal : System.Web.UI.Page
    {
        #region Variables
        private Usuarios _objUsuarios = new Usuarios();
        private SesiUsrs _objSesiUsrs = new SesiUsrs();
        private UsuariosNegocio _objNegocioUsuario = new UsuariosNegocio();
        private SesiUsrsNegocio _objNegocioSesiUsr = new SesiUsrsNegocio();
        private Int32 _Codigo;
        private String _Mensaje;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            bool _Resultado;

            if (Session["USR_INF"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            //else
            //{
            //    _objUsuarios = (Usuarios)Session["USR_INF"];
            //    _objSesiUsrs.Ide_Usr = _objUsuarios.Ide_Usr;

            //    _Resultado = _objNegocioSesiUsr.existe_Sesion(_objSesiUsrs, ref _Codigo, ref _Mensaje);





            //    if (_objNegocioSesiUsr.existe_Sesion(_objSesiUsrs, ref _Codigo, ref _Mensaje)) 
            //    {
            //        if (!IsPostBack)
            //        {
            //            this.lbl_Usuario.Text = _objUsuarios.Nom_bre.Trim() + " ";
            //            this.lbl_Usuario.Text += _objUsuarios.Ape_Pat.Trim() + " ";
            //            this.lbl_Usuario.Text += _objUsuarios.Ape_Mat.Trim();
            //        }
            //    }
            //    else 
            //    { 
            //        if (_objNegocioSesiUsr.elimina_Sesion()
            //    }







            //    else if (! _Resultado && _Estatus == null)
            //    {
            //        _Resultado = _objNegocioUsuario.elimina_Sesion(_objUsuarios, ref _Estatus);
            //        if (_Resultado && _Estatus == null)
            //        {
            //            Session.Abandon();
            //        }

            //        Response.Redirect("~/Login.aspx?S=I");
            //    }
            //    else if (_Estatus != null)
            //    {
            //        muestra_Mensaje("!! " + _Estatus.Trim() + " ... ¡¡");
            //        return;
            //    }
            //}
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