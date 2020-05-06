using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NegocioFlr.Datos;
using NegocioFlr.Entidades;

namespace NegocioFlr.Negocio
{
    public class ErrExcelNegocio
    {
        #region Variables
        private ErrExcelDatos _objDatosErrexcel = new ErrExcelDatos();
        #endregion

        #region Métodos
        public List<ErrExcel>regresa_Errores(ref string _Estatus)
        {
            return _objDatosErrexcel.regresa_Errores(ref _Estatus);
        }

        public Boolean registra_Error(ErrExcel _errexcel, ref string _Estatus)
        {
            return _objDatosErrexcel.registra_Error(_errexcel, ref _Estatus);
        }

        public Boolean elimina_Error(ref string _Estatus)
        {
            return _objDatosErrexcel.elimina_Error(ref _Estatus);
        }
        #endregion
    }
}
