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
        public List<SesiUsrs> regresa_Sesion(SesiUsrs _oSesiusrs, ref Int32 _iCodigo, ref string _sMensaje)
        {
            return _objDatosSesiUsrs.consulta_Sesion(_oSesiusrs, ref _iCodigo, ref _sMensaje);
        }

        public Boolean existe_Sesion(SesiUsrs _oSesiusrs, ref Int32 _iCodigo, ref string _sMensaje) 
        {
            return _objDatosSesiUsrs.existe_Sesion(_oSesiusrs, ref _iCodigo, ref _sMensaje);
        }

        public Boolean registra_Sesion(SesiUsrs _oSesiusrs, ref Int32 _iCodigo, ref string _sMensaje) 
        {
            return _objDatosSesiUsrs.registra_Sesion(_oSesiusrs, ref _iCodigo, ref _sMensaje);
        }

        public Boolean elimina_Sesion(SesiUsrs _oSesiusrs, ref Int32 _iCodigo, ref string _sMensaje) 
        {
            return _objDatosSesiUsrs.elimina_Sesion(_oSesiusrs, ref _iCodigo, ref _sMensaje);
        }
        #endregion
    }
}
