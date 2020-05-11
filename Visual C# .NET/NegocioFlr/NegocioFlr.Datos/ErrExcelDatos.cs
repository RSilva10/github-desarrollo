using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using NegocioFlr.Entidades;
using System.Configuration;

namespace NegocioFlr.Datos
{
    public class ErrExcelDatos
    {
        #region Variables
        private SqlConnection _Conexion = new SqlConnection();
        private SqlCommand _Comando;
        private SqlDataReader _Resultado;
        #endregion

        #region Métodos
        /// <summary>
        /// Consulta de los errores registrados
        /// </summary>
        /// <param name="_errexcel">Clase errexcel</param>
        /// <param name="_Estatus">Resultado de la consulta</param>
        /// <returns>Listado de errores</returns>
        public List<ErrExcel> regresa_Errores(ref string _Estatus)
        {
            Usuarios _oUsuario = new Usuarios();

            _Conexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            List<ErrExcel> lstErrexcel = new List<ErrExcel>();
            _Estatus = null;

            try
            {
                _Conexion.Open();

                _Comando = new SqlCommand();
                _Comando.CommandType = System.Data.CommandType.StoredProcedure;
                _Comando.CommandText = "sp_Consulta_Errores";
                _Comando.Connection = _Conexion;
                _Resultado = _Comando.ExecuteReader();

                while (_Resultado.Read())
                {
                    ErrExcel errexcel = new ErrExcel();

                    errexcel.Num_Lin = _Resultado.GetInt32(0);
                    errexcel.Nom_Cam = _Resultado.GetString(1);
                    errexcel.Des_Err = _Resultado.GetString(2);

                    lstErrexcel.Add(errexcel);
                }
            }
            catch (SqlException Error)
            {
                _Estatus = Error.ErrorCode.ToString() + ": " + Error.Message;
            }
            finally
            {
                if (_Comando != null)
                {
                    _Comando.Dispose();
                    _Conexion.Close();
                }
            }

            return lstErrexcel;
        }

        /// <summary>
        /// Alta del error en el sistema
        /// </summary>
        /// <param name="_errexcel">Clase errexcel</param>
        /// <param name="_Estatus">Resultado de la alta</param>
        /// <returns>Verdadero o Falso</returns>
        public Boolean registra_Error(ErrExcel _errexcel, ref string _Estatus)
        {
            Usuarios _oUsuario = new Usuarios();

            _Conexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            _Estatus = null;
            bool _Resultado;

            try
            {
                _Conexion.Open();

                //  Parámetros:
                //  Número de línea
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.Int32;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Num_Lin";
                _Parametro1.Value = _errexcel.Num_Lin;
                //  Nombre del campo
                SqlParameter _Parametro2 = new SqlParameter();
                _Parametro2.DbType = System.Data.DbType.String;
                _Parametro2.Direction = System.Data.ParameterDirection.Input;
                _Parametro2.ParameterName = "@Nom_Cam";
                _Parametro2.Value = _errexcel.Nom_Cam;
                //  Descripción del error
                SqlParameter _Parametro3 = new SqlParameter();
                _Parametro3.DbType = System.Data.DbType.String;
                _Parametro3.Direction = System.Data.ParameterDirection.Input;
                _Parametro3.ParameterName = "@Des_Err";
                _Parametro3.Value = _errexcel.Des_Err;

                _Comando = new SqlCommand();
                _Comando.CommandType = System.Data.CommandType.StoredProcedure;
                _Comando.CommandText = "sp_Registra_Errores";
                _Comando.Connection = _Conexion;
                _Comando.Parameters.Add(_Parametro1);
                _Comando.Parameters.Add(_Parametro2);
                _Comando.Parameters.Add(_Parametro3);
                _Comando.ExecuteNonQuery();

                _Resultado = true;
            }
            catch (SqlException Error)
            {
                _Estatus = Error.ErrorCode.ToString() + ": " + Error.Message;
                _Resultado = false;
            }
            finally
            {
                if (_Comando != null)
                {
                    _Comando.Dispose();
                    _Conexion.Close();
                }
            }

            return _Resultado;
        }

        /// <summary>
        /// Elimina el error en el sistema
        /// </summary>
        /// <param name="_Estatus">Resultado del borrado</param>
        /// <returns>Verdadero o Falso</returns>
        public Boolean elimina_Error(ref string _Estatus)
        {
            Usuarios _oUsuario = new Usuarios();

            _Conexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            _Estatus = null;
            bool _Resultado;

            try
            {
                _Conexion.Open();

                _Comando = new SqlCommand();
                _Comando.CommandType = System.Data.CommandType.StoredProcedure;
                _Comando.CommandText = "sp_Elimina_Errores";
                _Comando.Connection = _Conexion;
                _Comando.ExecuteNonQuery();

                _Resultado = true;
            }
            catch (SqlException Error)
            {
                _Estatus = Error.ErrorCode.ToString() + ": " + Error.Message;
                _Resultado = false;
            }
            finally
            {
                if (_Comando != null)
                {
                    _Comando.Dispose();
                    _Conexion.Close();
                }
            }

            return _Resultado;
        }
        #endregion
    }
}
