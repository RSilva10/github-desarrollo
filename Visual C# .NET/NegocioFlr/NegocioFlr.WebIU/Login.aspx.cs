using System;
using System.Collections.Generic;
using NegocioFlr.Entidades;
using NegocioFlr.Negocio;  

namespace NegocioFlr.WebIU
{
    public partial class Login : System.Web.UI.Page
    {
        #region Variables
        private Usuarios _objUsuarios = new Usuarios();
        private SesiUsrs _objSesiUsrs = new SesiUsrs();
        private UsuariosNegocio _objNegocioUsuario = new UsuariosNegocio();
        private SesiUsrsNegocio _objNegocioSesiUsr = new SesiUsrsNegocio();
        private Utilerias _objUtilerias = new Utilerias();
        private List<Usuarios> _lstUsuarios;
        private List<SesiUsrs> _lstSesiUsrs;
        private Int32 _iCodigo;
        private String _sMensaje;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            bool _Resultado;

            if (!valida_Datos())
            {
                return;
            }

            _objUsuarios.Cve_Usr = this.txt_Usuario.Value;
            _objUsuarios.Pas_Usr = _objUsuarios.encripta_Password(this.txt_Password.Value);
            _objUsuarios.Ali_Cli = this.txt_Alias.Value;

            if (! _objNegocioUsuario.existe_Usuario(_objUsuarios, ref _iCodigo, ref _sMensaje)) 
            {
                _objUtilerias.muestra_Mensaje(this, _sMensaje, 3);
                return;
            }

            _lstUsuarios = _objNegocioUsuario.regresa_Usuario(_objUsuarios, ref _iCodigo, ref _sMensaje);
            if (_iCodigo > 0)
            {
                _objUtilerias.muestra_Mensaje(this, "!! " + _iCodigo + ": " + _sMensaje.Trim() + " ... ¡¡", 3);
                return;
            }

            foreach (Usuarios _usuario in _lstUsuarios)
            {
                _objUsuarios.Ide_Usr = _lstUsuarios[0].Ide_Usr;
                _objUsuarios.Ape_Pat = _lstUsuarios[0].Ape_Pat;
                _objUsuarios.Ape_Mat = _lstUsuarios[0].Ape_Mat;
                _objUsuarios.Nom_bre = _lstUsuarios[0].Nom_bre;
                _objUsuarios.Fec_Vig = _lstUsuarios[0].Fec_Vig;
                _objUsuarios.Cor_reo = _lstUsuarios[0].Cor_reo;
                _objUsuarios.Rso_Cli = _lstUsuarios[0].Rso_Cli;
                _objUsuarios.Cal_Cli = _lstUsuarios[0].Cal_Cli;
                _objUsuarios.NEx_Cli = _lstUsuarios[0].NEx_Cli;
                _objUsuarios.NIn_Cli = _lstUsuarios[0].NIn_Cli;
                _objUsuarios.Col_Cli = _lstUsuarios[0].Col_Cli;
                _objUsuarios.Cop_Cli = _lstUsuarios[0].Cop_Cli;
                _objUsuarios.Del_Cli = _lstUsuarios[0].Del_Cli;
                _objUsuarios.Ciu_Cli = _lstUsuarios[0].Ciu_Cli;
                _objUsuarios.Ico_Cli = _lstUsuarios[0].Ico_Cli;
            }
            _objSesiUsrs.Ide_Usr = _objUsuarios.Ide_Usr;

            if (this.chk_SActivas.Checked == true)
            {
                _Resultado = _objNegocioSesiUsr.elimina_Sesion(_objSesiUsrs, ref _iCodigo, ref _sMensaje);
                if (_Resultado)
                {
                    _objUtilerias.muestra_Mensaje(this, "!! Se eliminó la sesión activa de " + _objUsuarios.Nom_bre.Trim() + " " + _objUsuarios.Ape_Pat.Trim() + " " + _objUsuarios.Ape_Mat.Trim() + " ... ¡¡", 0);
                    Session.Abandon();
                }
                else
                {
                    _objUtilerias.muestra_Mensaje(this, "!! " + _iCodigo.ToString() + " " + _sMensaje.Trim() + " ... ¡¡", 3);
                }
                this.chk_SActivas.Checked = false;

                return;
            }

            if (! _objNegocioSesiUsr.existe_Sesion(_objSesiUsrs, ref _iCodigo, ref _sMensaje))
            {
                _objUtilerias.muestra_Mensaje(this, _sMensaje, 3);
                return;
            }
            else 
            { 
                if (!_objNegocioSesiUsr.registra_Sesion(_objSesiUsrs, ref _iCodigo, ref _sMensaje)) 
                {
                    _objUtilerias.muestra_Mensaje(this, _sMensaje, 3);
                    return;
                }
                else 
                {
                    _lstSesiUsrs = _objNegocioSesiUsr.regresa_Sesion(_objSesiUsrs, ref _iCodigo, ref _sMensaje);
                    if (_iCodigo > 0)
                    {
                        _objUtilerias.muestra_Mensaje(this, "!! " + _iCodigo + ": " + _sMensaje.Trim() + " ... ¡¡", 3);
                        return;
                    }

                    foreach (SesiUsrs _sesiusrs in _lstSesiUsrs)
                    {
                        _objSesiUsrs.Ide_Ses = _lstSesiUsrs[0].Ide_Ses;
                        _objSesiUsrs.Fec_Ses = _lstSesiUsrs[0].Fec_Ses;
                    }

                    Session["USR_INF"] = _objUsuarios;
                    Session["USR_SES"] = _objSesiUsrs;

                    Response.Redirect("~/Paginas/Principal.aspx");
                }
            }
        }

        protected void btn_Registro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Registro.aspx"); 
        }

        /// <summary>
        /// Validación de información proporcionada
        /// </summary>
        /// <returns>Verdadero si los datos son correctos, Falso si no lo son</returns>
        protected Boolean valida_Datos()
        {
            bool _Resultado = true;

            if (this.txt_Usuario.Value == string.Empty)
            {
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione el usuario ... ¡¡", 0);
                _Resultado = false;
            }
            else if (this.txt_Password.Value == string.Empty)
            {
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione la contraseña ... ¡¡", 0);
                _Resultado = false;
            }
            else if (this.txt_Alias.Value == string.Empty)
            {
                _objUtilerias.muestra_Mensaje(this, "!! Proporcione el alias del cliente ... ¡¡", 0);
                _Resultado = false;
            }

            return _Resultado;
        }
    }
}