using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioFlr.WebIU.Paginas
{
    public partial class Frm_Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void img_Guardar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void img_Cancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("./Cat_Usuarios.aspx");
        }
    }
}