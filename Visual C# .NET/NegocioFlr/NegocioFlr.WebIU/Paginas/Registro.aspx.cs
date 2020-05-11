using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using NegocioFlr.Entidades;
using NegocioFlr.Negocio;
using System.IO;
using System.Text;
using System.Net.Mime;

namespace NegocioFlr.WebIU.Paginas
{
    public partial class Registro : System.Web.UI.Page
    {
        #region Variables
        private Regex _Correo_valido = new Regex("^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$");
        private Usuarios _objUsuarios = new Usuarios();
        private UsuariosNegocio _objNegocioUsuario = new UsuariosNegocio();
        private Int32 _Codigo;
        private String _Mensaje;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Registrar_Click(object sender, EventArgs e)
        {
            String _Reporte_Passwd = HttpContext.Current.Server.MapPath("./Reportes/rpt_Contrasenia.txt");
            FileStream _oSw = null;
            FileInfo _oDescarga = null;

            if (!valida_Datos())
            {
                return;
            }

            _objUsuarios.Ope_Rac = 1;  
            _objUsuarios.Cve_Usr = this.txt_Usuario.Value;
            _objUsuarios.Ape_Pat = this.txt_Paterno.Value;
            _objUsuarios.Ape_Mat = this.txt_Materno.Value;
            _objUsuarios.Nom_bre = this.txt_Nombre.Value;
            _objUsuarios.Pas_Usr = string.Empty;
            _objUsuarios.Fec_Ing = Convert.ToDateTime("01/01/1900");
            _objUsuarios.Fec_Vig = Convert.ToDateTime("01/01/1900");
            _objUsuarios.Cor_reo = this.txt_Correo.Value;
            _objUsuarios.Ali_Cli = this.txt_Alias.Value;

            if (!_objNegocioUsuario.registra_Usuario(_objUsuarios, ref _Codigo, ref _Mensaje))
            {
                muestra_Mensaje(_Mensaje.Trim()); 
            }
            else
            {
                try 
                {
                    _oSw = new FileStream(_Reporte_Passwd, FileMode.CreateNew);
                    using (StreamWriter _oWr =  new StreamWriter(_oSw, Encoding.UTF8))
                    {
                        _oWr.WriteLine("Información Alta de Usuario:");
                        _oWr.WriteLine("\r");
                        _oWr.WriteLine("Clave usuario       :   " + _objUsuarios.Cve_Usr.Trim());
                        _oWr.WriteLine("Contraseña usuario  :   " + _objUsuarios.genera_Pwd);
                        _oWr.WriteLine("Alias cliente       :   " + _objUsuarios.Ali_Cli.ToUpper());
                        _oWr.WriteLine("\r");
                        _oWr.WriteLine("Utilice esta información para acceder al sistema");
                        _oWr.Close();
                    }

                    _oDescarga = new FileInfo(_Reporte_Passwd + "rpt_Contrasenia.txt");
                    if (_oDescarga.Exists) 
                    {
                        Page.Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + _oDescarga.Name);
                        Response.AddHeader("Content-Length", _oDescarga.Length.ToString());
                        Response.ContentType = "application/text/plain";
                        Response.Write(_Reporte_Passwd);
                    }
                }
                catch (Exception ex)
                {
                    muestra_Mensaje("!! No fue posible crear archivo para alta usuario. " + ex.Message + " ... ¡¡");
                }
                finally 
                {
                    if (_oSw != null) 
                    {
                        _oSw.Dispose();
                    }
                }
            }
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected Boolean valida_Datos()
        {
            bool _Resultado = true;
            
            if (this.txt_Usuario.Value == string.Empty)
            {
                muestra_Mensaje("!! Proporcione clave usuario ... ¡¡"); 
                _Resultado = false;
            }
            else if (this.txt_Paterno.Value == string.Empty)
            {
                muestra_Mensaje("!! Proporcione apellido paterno ... ¡¡"); 
                _Resultado = false;
            }
            else if (this.txt_Materno.Value == string.Empty)
            {
                muestra_Mensaje("!! Proporcione apellido materno ... ¡¡"); 
                _Resultado = false;
            }
            else if (this.txt_Nombre.Value == string.Empty)
            {
                muestra_Mensaje("!! Proporcione nombre ... ¡¡"); 
                _Resultado = false;
            }
            else if (this.txt_Correo.Value == string.Empty)
            {
                muestra_Mensaje("!! Proporcione dirección correo electrónico ... ¡¡"); 
                _Resultado = false;
            }
            else if (! _Correo_valido.IsMatch(this.txt_Correo.Value))
            {
                muestra_Mensaje("!! Proporcione dirección correo electrónico valida ... ¡¡"); 
                _Resultado = false;
            }
            else if (this.txt_Alias.Value == string.Empty)
            {
                muestra_Mensaje("!! Proporcione clave de cliente ... ¡¡");
                _Resultado = false;
            }

            return _Resultado; 
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