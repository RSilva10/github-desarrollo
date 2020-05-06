using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioFlr.Entidades;
using NegocioFlr.Negocio;
using System.IO;
using System.Text.RegularExpressions;

namespace NegocioFlr.WebIU.Paginas
{
    public partial class Cat_Usuarios : System.Web.UI.Page
    {
        #region Variables
        private Usuarios _objUsuarios = new Usuarios();
        private ErrExcel _objErrexcel = new ErrExcel();
        private UsuariosNegocio _objNegocioUsuario = new UsuariosNegocio();
        private ErrExcelNegocio _objNegocioErrexcel = new ErrExcelNegocio();
        private List<Usuarios> _lstUsuarios;
        private List<ErrExcel> _lstErrexcel;
        private String _Estatus;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            bool _Resultado;

            if (Session["USR_INF"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                _objUsuarios = (Usuarios)Session["USR_INF"];

                _Resultado = _objNegocioUsuario.existe_Sesion(_objUsuarios, ref _Estatus);
                if (_Resultado && _Estatus == null)
                {
                    if (!IsPostBack)
                    {
                        carga_Usuarios();
                    }
                }
                else if (!_Resultado && _Estatus == null)
                {
                    _Resultado = _objNegocioUsuario.elimina_Sesion(_objUsuarios, ref _Estatus);
                    if (_Resultado && _Estatus == null)
                    {
                        Session.Abandon();
                    }

                    Response.Redirect("~/Login.aspx?S=I");
                }
                else if (_Estatus != null)
                {
                    muestra_Mensaje("!! " + _Estatus.Trim() + " ... ¡¡");
                    return;
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
            _lstUsuarios = _objNegocioUsuario.regresa_Usuarios(ref _Estatus);
            if (_lstUsuarios.Count > 0 && _Estatus == null)
            {
                this.grv_Usuarios.DataSource = _lstUsuarios;
                this.grv_Usuarios.DataBind();
            }
            else if (_Estatus != null)
            {
                muestra_Mensaje("!! " + _Estatus.Trim() + " ... ¡¡");
            }
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

        protected void btn_Consultar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btn_Descargar_Click(object sender, ImageClickEventArgs e)
        {
            string _Template = "Template_Usuarios.xlsx";
            string _Archivo;

            try
            {
                _Archivo = Server.MapPath("~/Documentos/" + System.IO.Path.GetFileName(_Template));

                Response.Clear();
                Response.Buffer = true;
                Response.ClearHeaders();

                Response.AddHeader("Cache-Control", "no-store, no-cache");
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + _Template);
                Response.TransmitFile(_Archivo);
                Response.Flush();
                Response.End();
            }
            catch (Exception _Error)
            {
                muestra_Mensaje("!! Ocurrió un error al descargar el template de usuarios. Detalle: " + _Error.Message.Trim() + " ... ¡¡");
            }
        }

        protected void btn_Cargar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btn_Revisar_Click(object sender, ImageClickEventArgs e)
        {
            String _Archivo = string.Empty;
            String _Extension = string.Empty; 
            String[] _Extensiones = {".xlsx", ".xls" };
            bool _Resultado = false;
            String _Valor = string.Empty; 

            try
            {
                if (this.ful_Revisar.HasFile)
                {
                    _Archivo = this.ful_Revisar.PostedFile.FileName;
                    _Extension = Path.GetExtension(this.ful_Revisar.FileName.ToLower());

                    for (int _i = 0; _i < _Extensiones.Length; _i++)
                    {
                        if (_Extension == _Extensiones[_i])
                        {
                            _Resultado = true;
                            break;
                        }
                    }

                    if (_Resultado)
                    {
                        _lstUsuarios = _objNegocioUsuario.listado_Excel(_Archivo.Trim(), ref _Estatus);
                        if (_lstUsuarios.Count > 0 && _Estatus == null)
                        {
                            _Resultado = _objNegocioErrexcel.elimina_Error(ref _Estatus);
                            if (_Resultado && _Estatus == null)
                            {
                                for (int _i = 0; _i < _lstUsuarios.Count; _i++)
                                {
                                    for (int _Campo = 1; _Campo < 7; _Campo++)
                                    {
                                        switch (_Campo)
                                        {
                                            case 1:
                                                _Valor = _lstUsuarios[_i].Cve_Usr;
                                                break;
                                            case 2:
                                                _Valor = _lstUsuarios[_i].Pas_Usr;
                                                break;
                                            case 3:
                                                _Valor = _lstUsuarios[_i].Ape_Pat;
                                                break;
                                            case 4:
                                                _Valor = _lstUsuarios[_i].Ape_Mat;
                                                break;
                                            case 5:
                                                _Valor = _lstUsuarios[_i].Nom_bre;
                                                break;
                                            default:
                                                _Valor = _lstUsuarios[_i].Cor_reo;
                                                break;
                                        }

                                        _Resultado = valida_Informacion(_i, _Campo, _Valor);
                                        if (_Estatus != null)
                                        {
                                            break;
                                        }
                                    }

                                    if (_Estatus != null)
                                    {
                                        break;
                                    }
                                }

                                if (_Resultado && _Estatus == null)
                                {
                                    carga_Errores();
                                    this.btn_Cargar.Enabled = false;
                                }                                
                                else if (_Estatus != null)
                                {
                                    muestra_Mensaje("!! " + _Estatus.Trim() + " ... ¡¡");
                                    this.btn_Cargar.Enabled = false;
                                }
                                else
                                {
                                    this.btn_Cargar.Enabled = true;
                                }
                            }
                        }
                        else if (_Estatus != null)
                        {
                            muestra_Mensaje("!! " + _Estatus.Trim() + " ... ¡¡");
                        }
                        else
                        {
                            muestra_Mensaje("!! El archivo de Excel " + _Archivo.Trim() + " no contiene información para revisión ... ¡¡");
                        }
                    }
                    else
                    {
                        muestra_Mensaje("!! El formato del archivo a revisar debe ser Excel {.xlxs o .xls} ... ¡¡");
                        this.ful_Revisar.Focus();
                    }
                }
                else
                {
                    muestra_Mensaje("!! Seleccione un archivo para revisión de información ... ¡¡");
                    this.ful_Revisar.Focus();
                }
            }
            catch (Exception _Error)
            {
                muestra_Mensaje("!! Ocurrió un error al descargar el template de usuarios. Detalle: " + _Error.Message.Trim() + " ... ¡¡");
            }                 
        }

        /// <summary>
        /// Valida y registra los errores del contenido del archivo de Excel
        /// </summary>
        /// <param name="_Linea">Número de línea</param>
        /// <param name="_Campo">Número de campo a validar</param>
        /// <param name="_Valor">Valor del campo</param>
        /// <returns>Verdadero si registró el error, Falso si no</returns>
        private Boolean valida_Informacion(int _Linea, int _Campo, string _Valor)
        {
            String[] _Campos = new String[6] { "Clave_Usuario", "Contraseña_Usuario", "Apellido_Paterno", "Apellido_Materno", "Nombre", "Correo_Electrónico"}; 
            Regex _Correo_valido = new Regex("^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$");
            bool _Eserror = false;
            bool _Resultado;

            _Estatus = null;
            _objErrexcel.Num_Lin = _Linea;

            switch (_Campo)
            {
                case 1:
                    //  Clave usuario
                    _objErrexcel.Nom_Cam = _Campos[0];
                    if (_Valor.Trim().Length == 0)
                    {
                        _objErrexcel.Des_Err = "Su valor viene en blanco";
                        _Eserror = true;
                    }
                    else if (_Valor.Trim().Length > 10)
                    {
                        _objErrexcel.Des_Err = "Su valor es mayor a 10 caracteres";
                        _Eserror = true;
                    }
                    break;
                case 2:
                    //  Contraseña usuario
                    _objErrexcel.Nom_Cam = _Campos[1];
                    if (_Valor.Trim().Length == 0)
                    {
                        _objErrexcel.Des_Err = "Su valor viene en blanco";
                        _Eserror = true;
                    }
                    else if (_Valor.Trim().Length > 10)
                    {
                        _objErrexcel.Des_Err = "Su valor es mayor a 10 caracteres";
                        _Eserror = true;
                    }
                    break;
                case 3:
                    //  Apellido paterno
                    _objErrexcel.Nom_Cam = _Campos[2];
                    if (_Valor.Trim().Length == 0)
                    {
                        _objErrexcel.Des_Err = "Su valor viene en blanco";
                        _Eserror = true;
                    }
                    else if (_Valor.Trim().Length > 20)
                    {
                        _objErrexcel.Des_Err = "Su valor es mayor a 20 caracteres";
                        _Eserror = true;
                    }
                    break;
                case 4:
                    //  Apellido materno
                    _objErrexcel.Nom_Cam = _Campos[3];
                    if (_Valor.Trim().Length == 0)
                    {
                        _objErrexcel.Des_Err = "Su valor viene en blanco";
                        _Eserror = true;
                    }
                    else if (_Valor.Trim().Length > 20)
                    {
                        _objErrexcel.Des_Err = "Su valor es mayor a 20 caracteres";
                        _Eserror = true;
                    }
                    break;
                case 5:
                    //  Nombre
                    _objErrexcel.Nom_Cam = _Campos[4];
                    if (_Valor.Trim().Length == 0)
                    {
                        _objErrexcel.Des_Err = "Su valor viene en blanco";
                        _Eserror = true;
                    }
                    else if (_Valor.Trim().Length > 20)
                    {
                        _objErrexcel.Des_Err = "Su valor es mayor a 20 caracteres";
                        _Eserror = true;
                    }
                    break;
                default:
                    //  Correo electrónico
                    _objErrexcel.Nom_Cam = _Campos[5];
                    if (_Valor.Trim().Length == 0)
                    {
                        _objErrexcel.Des_Err = "Su valor viene en blanco";
                        _Eserror = true;
                    }
                    else if (_Valor.Trim().Length > 50)
                    {
                        _objErrexcel.Des_Err = "Su valor es mayor a 50 caracteres";
                        _Eserror = true;
                    }
                    else if (! _Correo_valido.IsMatch(_Valor.Trim()))
                    {
                        _objErrexcel.Des_Err = "Su valor no es valido";
                        _Eserror = true;
                    }
                    break;
            }

            //  Si existe error lo registramos
            if (_Eserror)
            {
                _Resultado = _objNegocioErrexcel.registra_Error(_objErrexcel, ref _Estatus);
            }
            else
            {
                _Resultado = _Eserror;
            }

            return _Resultado;
        }

        /// <summary>
        /// Muestra los errores registrados
        /// </summary>
        protected void carga_Errores()
        {
            _lstErrexcel = _objNegocioErrexcel.regresa_Errores(ref _Estatus);
            if (_lstErrexcel.Count > 0 && _Estatus == null)
            {
                this.grv_Errores.DataSource = _lstErrexcel;
                this.grv_Errores.DataBind();
            }
            else if (_Estatus != null)
            {
                muestra_Mensaje("!! " + _Estatus.Trim() + " ... ¡¡");
            }
        }
    }
}