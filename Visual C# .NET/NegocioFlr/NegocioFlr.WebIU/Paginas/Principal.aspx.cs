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
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USR_INF"] == null || Session["USR_SES"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                _objUsuarios = (Usuarios)Session["USR_INF"];
                _objSesiUsrs = (SesiUsrs)Session["USR_SES"];
            }
        }
    }
}