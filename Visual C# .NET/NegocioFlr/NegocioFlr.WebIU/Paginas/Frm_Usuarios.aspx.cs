using NegocioFlr.Entidades;
using NegocioFlr.Negocio;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NegocioFlr.WebIU.Paginas
{
    public partial class Frm_Usuarios : System.Web.UI.Page
    {
        #region Variables
        private Regex _Formato_Uno = new Regex("^[a-zA-Z0-9]*$");
        private Regex _Formato_Dos = new Regex("^[0-9a-zA-Z]*$");
        private Regex _Correo_valido = new Regex("^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$");
        private Usuarios _objUsuarios = new Usuarios();
        private Usuarios _objCRUD = new Usuarios();
        private UsuariosNegocio _objNegocioUsuario = new UsuariosNegocio();
        private Utilerias _objUtilerias = new Utilerias();
        private string _sOpcion = string.Empty;
        private string _sLlave = string.Empty;
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
                llena_Estatus();

                _sOpcion = Request.QueryString.Get("Opcion");
                if (_sOpcion == "A")
                {
                    this.ddl_Estatus.SelectedIndex = 0;
                    this.ddl_Estatus.Enabled = false;
                }
                else 
                {
                    _sLlave = Request.QueryString.Get("Key");

                    this.ddl_Estatus.Enabled= true;
                    carga_Usuario(_sLlave);
                }
            }
        }

        protected void img_Guardar_Click(object sender, ImageClickEventArgs e)
        {
            string _Contrasenia = string.Empty;
            bool _Resultado = false;

            if (!valida_Datos())
            {
                return;
            }

            _objCRUD.Ali_Cli = _objUsuarios.Ali_Cli;
            _objCRUD.Cve_Usr = this.txt_Usuario.Value;
            if (_sOpcion == "A") 
            {
                _objCRUD.Pas_Usr = string.Empty;
                _Contrasenia = this.txt_Contraseña.Value;
            }
            else 
            {
                _objCRUD.Ide_Usr = Convert.ToInt32(_sLlave);
                _objCRUD.Pas_Usr = this.txt_Contraseña.Value;
                _Contrasenia = string.Empty;
            }
            _objCRUD.Ape_Pat = txt_APaterno.Value;
            _objCRUD.Ape_Mat = this.txt_AMaterno.Value;
            _objCRUD.Nom_bre = this.txt_Nombre.Value;
            _objCRUD.Fec_Ing = Convert.ToDateTime(DateTime.Today);
            _objCRUD.Fec_Vig = Convert.ToDateTime(DateTime.Today);
            _objCRUD.Cor_reo = this.txt_Correo.Value;
            if (this.ddl_Estatus.SelectedItem.Value == "Activo") 
            {
                _objCRUD.Est_Usr = 1;
            }
            else
            {
                _objCRUD.Est_Usr = 0;
            }

            if (_sOpcion == "A") 
            {
                _Resultado = _objNegocioUsuario.registra_Usuario(_objCRUD, ref _Codigo, ref _Mensaje, ref _Contrasenia);
            }
            else 
            {
                _Resultado = _objNegocioUsuario.actualiza_Usuario(_objCRUD, ref _Codigo, ref _Mensaje);
            }

            if (_Resultado == true && _Codigo == 0) 
            {
                if (_sOpcion == "A") 
                {
                    Response.Redirect("./Cat_Usuarios.aspx?Opcion=A0");
                }
                else 
                {
                    Response.Redirect("./Cat_Usuarios.aspx?Opcion=E0");
                }
            }
            else 
            {
                _objUtilerias.muestra_Mensaje(this, "!! " + _Codigo + ": " + _Mensaje.Trim() + " ... ¡¡", 3);
            }
        }

        protected void img_Cancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("./Cat_Usuarios.aspx");
        }

        protected Boolean valida_Datos()
        {
            bool _Resultado = true;

            if (this.txt_Usuario.Value == string.Empty)
            {
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione clave usuario ... ¡¡", 1);
                _Resultado = false;
            }
            else if (this.txt_Contraseña.Value == string.Empty)
            {
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione contraseña ... ¡¡", 1);
                _Resultado = false;
            }
            else if (!_Formato_Uno.IsMatch(this.txt_Contraseña.Value) || !_Formato_Dos.IsMatch(this.txt_Contraseña.Value)) 
            {
                _objUtilerias.muestra_Mensaje(this, "!! Contraseña con formato incorrecto ... ¡¡", 1);
                _Resultado = false;
            }
            else if (this.txt_APaterno.Value == string.Empty)
            {
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione apellido paterno ... ¡¡", 1);
                _Resultado = false;
            }
            else if (this.txt_AMaterno.Value == string.Empty)
            {
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione apellido materno ... ¡¡", 1);
                _Resultado = false;
            }
            else if (this.txt_Nombre.Value == string.Empty)
            {
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione nombre ... ¡¡", 1);
                _Resultado = false;
            }
            else if (this.txt_Correo.Value == string.Empty)
            {
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione dirección correo electrónico ... ¡¡", 1);
                _Resultado = false;
            }
            else if (!_Correo_valido.IsMatch(this.txt_Correo.Value))
            {
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione dirección correo electrónico valida ... ¡¡", 1);
                _Resultado = false;
            }

            return _Resultado;
        }

        protected void img_Limpiar_Click(object sender, ImageClickEventArgs e)
        {
            this.txt_Usuario.Value = String.Empty;
            this.txt_Contraseña.Value = String.Empty;
            this.txt_APaterno.Value = String.Empty;
            this.txt_AMaterno.Value = String.Empty;
            this.txt_Nombre.Value = String.Empty;
            this.txt_Correo.Value = String.Empty;
        }

        protected void carga_Usuario(string Llave) 
        { 
            List<Usuarios> _lstUsuario;

            _lstUsuario = _objNegocioUsuario.regresa_Usuarios(3, "", "", "", Convert.ToInt32(Llave), ref _Codigo, ref _Mensaje);
            if (_lstUsuario.Count > 0) 
            {
                foreach (Usuarios _elemento in _lstUsuario)
                {
                    this.txt_Usuario.Value = _elemento.Cve_Usr;
                    this.txt_Contraseña.Value = _elemento.desencripta_Password(_elemento.Pas_Usr);
                    this.txt_APaterno.Value = _elemento.Ape_Pat;
                    this.txt_AMaterno.Value = _elemento.Ape_Mat;
                    this.txt_Nombre.Value = _elemento.Nom_bre;
                    this.txt_Correo.Value = _elemento.Cor_reo;

                    for (int _indice = 0; _indice < this.ddl_Estatus.Items.Count; _indice++)
                    {
                        if (this.ddl_Estatus.Items[_indice].Value == _elemento.Est_Usr.ToString())
                        {
                            this.ddl_Estatus.Items[_indice].Selected = true;
                            break;
                        }
                    }
                }                
            }
        }

        /// <summary>
        /// Llena el combo de estatus
        /// </summary>
        protected void llena_Estatus()
        {
            ListItem _Item;

            _Item = new ListItem("Activo", "1");
            this.ddl_Estatus.Items.Add(_Item);
            _Item = new ListItem("Inactivo", "0");
            this.ddl_Estatus.Items.Add(_Item);
        }
    }
}