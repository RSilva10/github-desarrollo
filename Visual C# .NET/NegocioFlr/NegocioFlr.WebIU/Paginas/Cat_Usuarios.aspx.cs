using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using NegocioFlr.Entidades;
using NegocioFlr.Negocio;

namespace NegocioFlr.WebIU.Paginas
{
    public partial class Cat_Usuarios : System.Web.UI.Page
    {
        #region Variables
        private Usuarios _objUsuarios = new Usuarios();
        private UsuariosNegocio _objNegocioUsuario = new UsuariosNegocio();
        private Utilerias _objUtilerias = new Utilerias();
        private List<Usuarios> _lstUsuarios;
        private string _sOpcion = string.Empty;
        private Int32 _iCodigo;
        private String _sMensaje;
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

                if (!IsPostBack) 
                {
                    _sOpcion = Request.QueryString.Get("Opcion");
                    if (_sOpcion != null) 
                    { 
                        if (_sOpcion == "A0") 
                        {
                            _objUtilerias.muestra_Mensaje(this, "!! Registro dado de alta ... ¡¡", 0);
                        }
                        else 
                        {
                            _objUtilerias.muestra_Mensaje(this, "!! Registro actualizado ... ¡¡", 0);
                        }
                    }

                    llena_Estatus();
                    carga_Usuarios();
                }
            }
        }

        protected void grd_Usuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Usuarios _objCRUD = new Usuarios();
            bool _bRespuesta = false;

            if (e.CommandName == "Editar_Registro")
            {
                Response.Redirect("./Frm_Usuarios.aspx?Opcion=E&Key=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Eliminar_Registro")
            {
                _objCRUD.Ide_Usr = Convert.ToInt32(e.CommandArgument.ToString());

                _bRespuesta = _objNegocioUsuario.elimina_Usuario(_objCRUD, ref _iCodigo, ref _sMensaje);
                if (_bRespuesta == true)
                {
                    _objUtilerias.muestra_Mensaje(this, "!! Registro dado de baja ... ¡¡", 0);
                    limpia_Grilla();
                    carga_Usuarios();
                }
                else if (_iCodigo > 0)
                {
                    _objUtilerias.muestra_Mensaje(this, "!! " + _iCodigo + " " + _sMensaje + " ... ¡¡", 0);
                }
            }
        }

        protected void grd_Usuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_Usuarios.PageIndex = e.NewPageIndex;
            limpia_Grilla();

            carga_Usuarios();
        }

        /// <summary>
        /// Muestra los usuarios registrados
        /// </summary>
        protected void carga_Usuarios()
        {
            _lstUsuarios = _objNegocioUsuario.regresa_Usuarios(3, "", "", "", 0, ref _iCodigo, ref _sMensaje);
            if (_iCodigo == 0)
            {
                this.limpia_Grilla();

                this.grd_Usuarios.DataSource = _lstUsuarios;
                this.grd_Usuarios.DataBind();
            }
            else 
            {
                _objUtilerias.muestra_Mensaje(this, "!! " + _iCodigo + " " + _sMensaje + " ... ¡¡", 0);
            }
        }

        /// <summary>
        /// Llena el combo de estatus
        /// </summary>
        protected void llena_Estatus() 
        {
            ListItem _Item;

            _Item = new ListItem("Activos", "1");
            this.ddl_Estatus.Items.Add(_Item);
            _Item = new ListItem("Inactivos", "0");
            this.ddl_Estatus.Items.Add(_Item);
            _Item = new ListItem("Todos", "2");
            this.ddl_Estatus.Items.Add(_Item);
        }

        protected void img_Alta_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("./Frm_Usuarios.aspx?Opcion=A");
        }

        protected void img_Buscar_Click(object sender, ImageClickEventArgs e)
        {
            _lstUsuarios = _objNegocioUsuario.regresa_Usuarios(3, this.txt_Nombre.Value, this.txt_APaterno.Value, this.txt_AMaterno.Value, 0, ref _iCodigo, ref _sMensaje);
            if (_iCodigo == 0)
            {
                limpia_Grilla();

                this.grd_Usuarios.DataSource = _lstUsuarios;
                this.grd_Usuarios.DataBind();
            }
        }

        protected void ddl_Estatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _Elemento;

            _Elemento = Convert.ToInt32(this.ddl_Estatus.SelectedValue);

            _lstUsuarios = _objNegocioUsuario.regresa_Usuarios(_Elemento , "", "", "", 0, ref _iCodigo, ref _sMensaje);
            if (_iCodigo == 0) 
            {
                this.grd_Usuarios.DataSource = _lstUsuarios;
                this.grd_Usuarios.DataBind();
            }
            else
            {
                _objUtilerias.muestra_Mensaje(this, "!! " + _iCodigo + " " + _sMensaje + " ... ¡¡", 0);
            }
        }

        protected void limpia_Grilla() 
        {
            this.grd_Usuarios.DataSource = null;
            this.grd_Usuarios.DataBind();
        }
    }
}