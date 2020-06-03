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
        public List<Usuarios> regresa_Usuario(Usuarios _usuarios, ref Int32 _Codigo, ref string _Mensaje)
        {
            return _objDatosUsuario.consulta_Usuario(_usuarios, ref _Codigo, ref _Mensaje); 
        }

        public List<Usuarios> regresa_Usuarios(int _Estatus, string _Nombre, string _APaterno, string _AMaterno, ref Int32 _Codigo, ref string _Mensaje)
        {
            return _objDatosUsuario.consulta_Usuarios(_Estatus, _Nombre, _APaterno, _AMaterno, ref _Codigo, ref _Mensaje);
        }

        public Boolean registra_Usuario(Usuarios _usuarios, ref Int32 _Codigo, ref string _Mensaje, ref string _Contrasenia)
        {                         
            return _objDatosUsuario.registra_Usuario(_usuarios, ref _Codigo, ref _Mensaje, ref _Contrasenia);
        }

        public Boolean existe_Usuario(Usuarios _usuarios, ref Int32 _Codigo, ref string _Mensaje)
        {
            return _objDatosUsuario.existe_Usuario(_usuarios, ref _Codigo, ref _Mensaje);
        }
        
        public List<Usuarios> listado_Excel(string _ubicarchivo, ref string _Estatus)
        {
            return _objDatosUsuario.listado_Excel(_ubicarchivo, ref _Estatus);
        } 
        #endregion
    }
}
