using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NegocioFlr.Datos;
using NegocioFlr.Entidades; 

namespace NegocioFlr.Negocio
{
    public class UsuariosNegocio
    {
        #region Variables
        private UsuariosDatos _objDatosUsuario = new UsuariosDatos();
        #endregion

        #region Métodos
        public List<Usuarios> regresa_Usuario(Usuarios _oUsuarios, ref Int32 _iCodigo, ref string _sMensaje)
        {
            return _objDatosUsuario.consulta_Usuario(_oUsuarios, ref _iCodigo, ref _sMensaje); 
        }

        public List<Usuarios> regresa_Usuarios(int _iEstatus, string _sNombre, string _sAPaterno, string _sAMaterno, int iLlave, ref Int32 _iCodigo, ref string _sMensaje)
        {
            return _objDatosUsuario.consulta_Usuarios(_iEstatus, _sNombre, _sAPaterno, _sAMaterno, iLlave, ref _iCodigo, ref _sMensaje);
        }

        public Boolean registra_Usuario(Usuarios _oUsuarios, ref Int32 _iCodigo, ref string _sMensaje, ref string _Contrasenia)
        {                         
            return _objDatosUsuario.registra_Usuario(_oUsuarios, ref _iCodigo, ref _sMensaje, ref _Contrasenia);
        }

        public Boolean actualiza_Usuario(Usuarios _oUsuarios, ref Int32 _iCodigo, ref string _sMensaje) 
        {
            return _objDatosUsuario.actualiza_Usuario(_oUsuarios, ref _iCodigo, ref _sMensaje);
        }

        public Boolean existe_Usuario(Usuarios _oUsuarios, ref Int32 _iCodigo, ref string _sMensaje)
        {
            return _objDatosUsuario.existe_Usuario(_oUsuarios, ref _iCodigo, ref _sMensaje);
        }

        public Boolean elimina_Usuario(Usuarios _oUsuarios, ref Int32 _iCodigo, ref string _sMensaje)
        {
            return _objDatosUsuario.elimina_Usuario(_oUsuarios, ref _iCodigo, ref _sMensaje);
        }

        public int dias_Vigencia(Usuarios _oUsuarios, ref Int32 _iCodigo, ref string _sMensaje) 
        {
            return _objDatosUsuario.dias_Vigencia(_oUsuarios, ref _iCodigo, ref _sMensaje);
        }

        public Boolean actualiza_Vigencia(Usuarios _oUsuarios, ref string _sContrasenia, ref Int32 _iCodigo, ref string _sMensaje) 
        {
            return _objDatosUsuario.actualiza_Vigencia(_oUsuarios, ref _sContrasenia, ref _iCodigo, ref _sMensaje);
        }
        #endregion
    }
}
