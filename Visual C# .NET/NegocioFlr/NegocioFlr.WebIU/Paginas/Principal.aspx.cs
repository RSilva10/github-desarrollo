using System;
using System.IO;
using System.Text;
using System.Web;
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
        private Utilerias _objUtilerias = new Utilerias();
        private Int32 _iCodigo;
        private String _sMensaje;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios _objVigencia = new Usuarios();
            string _sContrasenia = null;
            bool _bResultado;
            String _Reporte_Passwd = HttpContext.Current.Server.MapPath("../Reportes/rpt_CambioContrasenia.txt");
            FileStream _oSw = null;
            FileInfo _oDescarga = null;

            if (Session["USR_INF"] == null || Session["USR_SES"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                _objUsuarios = (Usuarios)Session["USR_INF"];
                _objSesiUsrs = (SesiUsrs)Session["USR_SES"];

                _objVigencia.Ide_Usr = _objUsuarios.Ide_Usr;
                _objVigencia.Ape_Pat = _objUsuarios.Ape_Pat;
                _objVigencia.Ape_Mat = _objUsuarios.Ape_Mat;
                _objVigencia.Nom_bre = _objUsuarios.Nom_bre;
                _objSesiUsrs.Ide_Usr = _objUsuarios.Ide_Usr;

                int _iVigencia = _objNegocioUsuario.dias_Vigencia(_objVigencia, ref _iCodigo, ref _sMensaje);
                if (_iCodigo == 0)
                {
                    if (_iVigencia == 0)
                    {
                        _bResultado = _objNegocioUsuario.actualiza_Vigencia(_objVigencia, ref _sContrasenia, ref _iCodigo, ref _sMensaje);
                        if (_bResultado == true) 
                        {
                            try 
                            {
                                _bResultado = _objNegocioSesiUsr.elimina_Sesion(_objSesiUsrs, ref _iCodigo, ref _sMensaje);
                                if (_bResultado)
                                {
                                    Session.Abandon();
                                }
                                else
                                {
                                    _objUtilerias.muestra_Mensaje(this, "!! " + _iCodigo.ToString() + " " + _sMensaje.Trim() + " ... ¡¡", 3);
                                }

                                if (File.Exists(_Reporte_Passwd))
                                {
                                    File.Delete(_Reporte_Passwd);
                                }

                                _oSw = new FileStream(_Reporte_Passwd, FileMode.Create);
                                using (StreamWriter _oWr = new StreamWriter(_oSw, Encoding.UTF8))
                                {
                                    _oWr.WriteLine("Información Cambio Contraseña de Usuario:");
                                    _oWr.WriteLine("\r");
                                    _oWr.WriteLine("Clave usuario       :   " + _objUsuarios.Cve_Usr.Trim());
                                    _oWr.WriteLine("Contraseña usuario  :   " + _sContrasenia.Trim());
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
                                _objUtilerias.muestra_Mensaje(this, "!! No fue posible crear archivo para actualizar vigencia usuario. " + ex.Message + " ... ¡¡", 3);
                            }
                            finally
                            {
                                if (_oSw != null)
                                {
                                    _oSw.Dispose();
                                }
                            }
                        }
                        else                        
                        {
                            _objUtilerias.muestra_Mensaje(this, "!! " + _iCodigo.ToString() + " " + _sMensaje.Trim() + " ... ¡¡", 3);
                        }
                    }
                }
                else
                {
                    _objUtilerias.muestra_Mensaje(this, "!! " + _iCodigo.ToString() + " " + _sMensaje.Trim() + " ... ¡¡", 3);
                }
            }
        }
    }
}