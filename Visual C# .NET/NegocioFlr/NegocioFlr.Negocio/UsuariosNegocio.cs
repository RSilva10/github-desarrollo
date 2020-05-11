using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public List<Usuarios> regresa_Usuario(Usuarios _usuarios, ref string _Estatus)
        {
            return _objDatosUsuario.regresa_Usuario(_usuarios, ref _Estatus); 
        }

        public List<Usuarios> regresa_Usuarios(ref string _Estatus)
        {
            return _objDatosUsuario.regresa_Usuarios(ref _Estatus);
        }

        public Boolean registra_Usuario(Usuarios _usuarios, ref Int32 _Codigo, ref string _Mensaje)
        {                         
            return _objDatosUsuario.registra_Usuario(_usuarios, ref _Codigo, ref _Mensaje);
        }

        public int regresa_Sesion(Usuarios _usuarios, ref string _Estatus)
        {
            return _objDatosUsuario.regresa_Sesion(_usuarios, ref _Estatus);
        }

        public Boolean registra_Sesion(Usuarios _usuarios, ref string _Estatus)
        {
            return _objDatosUsuario.registra_Sesion(_usuarios, ref _Estatus);
        }

        public Boolean elimina_Sesion(Usuarios _usuarios, ref string _Estatus)
        {
            return _objDatosUsuario.elimina_Sesion(_usuarios, ref _Estatus);
        }

        public Boolean existe_Sesion(Usuarios _usuarios, ref string _Estatus)
        {
            return _objDatosUsuario.existe_Sesion(_usuarios, ref _Estatus);
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
