﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioFlr.Entidades;
using NegocioFlr.Negocio;
using System.Text.RegularExpressions;

namespace NegocioFlr.WebIU.Paginas
{
    public partial class Cat_Usuarios : System.Web.UI.Page
    {
        #region Variables
        private Usuarios _objUsuarios = new Usuarios();
        private UsuariosNegocio _objNegocioUsuario = new UsuariosNegocio();
        private Utilerias _objUtilerias = new Utilerias();
        private List<Usuarios> _lstUsuarios;
        private Int32 _Codigo;
        private String _Mensaje;
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
                    llena_Estatus();
                    carga_Usuarios();
                }
            }
        }

        protected void grv_Usuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {             
            if (e.CommandName == "Actualizar")
            {
                Response.Redirect("~/Paginas/Registro.aspx?O=A; K=" + e.CommandArgument.ToString());
            }
            else
            {
            }
        }

        /// <summary>
        /// Muestra los usuarios registrados
        /// </summary>
        protected void carga_Usuarios()
        {
            _lstUsuarios = _objNegocioUsuario.regresa_Usuarios(3, "", "", "", ref _Codigo, ref _Mensaje);
            if (_Codigo == 0)
            {
                this.grd_Usuarios.DataSource = _lstUsuarios;
                this.grd_Usuarios.DataBind();
            }
            else 
            {
                _objUtilerias.muestra_Mensaje(this, "!! " + _Codigo + " " + _Mensaje + " ... ¡¡", 0);
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
            Response.Redirect("./Frm_Usuarios.aspx");
        }

        protected void img_Buscar_Click(object sender, ImageClickEventArgs e)
        {
            _lstUsuarios = _objNegocioUsuario.regresa_Usuarios(3, this.txt_Nombre.Value, this.txt_APaterno.Value, this.txt_AMaterno.Value, ref _Codigo, ref _Mensaje);
            if (_Codigo == 0)
            {
                this.grd_Usuarios.DataSource = _lstUsuarios;
                this.grd_Usuarios.DataBind();
            }
        }

        protected void ddl_Estatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _Elemento;

            _Elemento = Convert.ToInt32(this.ddl_Estatus.SelectedValue);

            _lstUsuarios = _objNegocioUsuario.regresa_Usuarios(_Elemento , "", "", "", ref _Codigo, ref _Mensaje);
            if (_Codigo == 0) 
            {
                this.grd_Usuarios.DataSource = _lstUsuarios;
                this.grd_Usuarios.DataBind();
            }
            else
            {
                _objUtilerias.muestra_Mensaje(this, "!! " + _Codigo + " " + _Mensaje + " ... ¡¡", 0);
            }
        }
    }
}