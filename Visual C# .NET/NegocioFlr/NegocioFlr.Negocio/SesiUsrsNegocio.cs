using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NegocioFlr.Datos;
using NegocioFlr.Entidades;

namespace NegocioFlr.Negocio
{
    public class SesiUsrsNegocio
    {
        #region Variables
        private SesiUsrsDatos _objDatosSesiUsrs = new SesiUsrsDatos();
        #endregion

        #region Métodos
        public List<SesiUsrs> regresa_Sesion(SesiUsrs _sesiusrs, ref Int32 _Codigo, ref string _Mensaje)
        {
            return _objDatosSesiUsrs.consulta_Sesion(_sesiusrs, ref _Codigo, ref _Mensaje);
        }

        public Boolean existe_Sesion(SesiUsrs _sesiusrs, ref Int32 _Codigo, ref string _Mensaje) 
        {
            return _objDatosSesiUsrs.existe_Sesion(_sesiusrs, ref _Codigo, ref _Mensaje);
        }

        public Boolean registra_Sesion(SesiUsrs _sesiusrs, ref Int32 _Codigo, ref string _Mensaje) 
        {
            return _objDatosSesiUsrs.registra_Sesion(_sesiusrs, ref _Codigo, ref _Mensaje);
        }

        public Boolean elimina_Sesion(SesiUsrs _sesiusrs, ref Int32 _Codigo, ref string _Mensaje) 
        {
            return _objDatosSesiUsrs.elimina_Sesion(_sesiusrs, ref _Codigo, ref _Mensaje);
        }
        #endregion
    }
}
