using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;
using NegocioFlr.Entidades;
using NegocioFlr.Negocio;
using System.IO;
using System.Text;

namespace NegocioFlr.WebIU.Paginas
{
    public partial class Registro : System.Web.UI.Page
    {
        #region Variables
        private Regex _Correo_valido = new Regex("^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$");
        private Usuarios _objUsuarios = new Usuarios();
        private UsuariosNegocio _objNegocioUsuario = new UsuariosNegocio();
        private Utilerias _objUtilerias = new Utilerias();
        private Int32 _iCodigo;
        private String _sMensaje;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _objUtilerias.muestra_Mensaje(this, "!! Se descargara el archivo para ingreso al sistema ... ¡¡", 0);
        }

        protected void btn_Registrar_Click(object sender, EventArgs e)
        {
            String _Reporte_Passwd = HttpContext.Current.Server.MapPath("../Reportes/rpt_Contrasenia.txt");
            FileStream _oSw = null;
            FileInfo _oDescarga = null;
            string _Contrasenia = null;

            if (! valida_Datos())
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

            if (!_objNegocioUsuario.registra_Usuario(_objUsuarios, ref _iCodigo, ref _sMensaje, ref _Contrasenia))
            {
                _objUtilerias.muestra_Mensaje(this, _sMensaje.Trim(), 3);
            }
            else
            {
                try 
                {
                    if (File.Exists(_Reporte_Passwd)) 
                    {
                        File.Delete(_Reporte_Passwd);
                    }

                    _oSw = new FileStream(_Reporte_Passwd, FileMode.Create);
                    using (StreamWriter _oWr = new StreamWriter(_oSw, Encoding.UTF8))
                    {
                        _oWr.WriteLine("Información Alta de Usuario:");
                        _oWr.WriteLine("\r");
                        _oWr.WriteLine("Clave usuario       :   " + _objUsuarios.Cve_Usr.Trim());
                        _oWr.WriteLine("Contraseña usuario  :   " + _Contrasenia.Trim());
                        _oWr.WriteLine("Alias cliente       :   " + _objUsuarios.Ali_Cli.ToUpper());
                        _oWr.WriteLine("\r");
                        _oWr.WriteLine("Utilice esta información para acceder al sistema");
                        _oWr.Close();
                    }

                    _oDescarga = new FileInfo(_Reporte_Passwd);
                    if (_oDescarga.Exists) 
                    {
                        Page.Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + _oDescarga.Name);
                        Response.AddHeader("Content-Length", _oDescarga.Length.ToString());
                        Response.ContentType = "text/plain";
                        Response.TransmitFile(_oDescarga.FullName);
                        Response.End();
                    }
                }
                catch (Exception ex)
                {
                    _objUtilerias.muestra_Mensaje(this, "!! No fue posible crear archivo para alta usuario. " + ex.Message + " ... ¡¡", 3);
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
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione clave usuario ... ¡¡", 1);
                _Resultado = false;
            }
            else if (this.txt_Paterno.Value == string.Empty)
            {
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione apellido paterno ... ¡¡", 1);
                _Resultado = false;
            }
            else if (this.txt_Materno.Value == string.Empty)
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
            else if (! _Correo_valido.IsMatch(this.txt_Correo.Value))
            {
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione dirección correo electrónico valida ... ¡¡", 1);
                _Resultado = false;
            }
            else if (this.txt_Alias.Value == string.Empty)
            {
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione clave de cliente ... ¡¡", 1);
                _Resultado = false;
            }

            return _Resultado; 
        }
    }
}