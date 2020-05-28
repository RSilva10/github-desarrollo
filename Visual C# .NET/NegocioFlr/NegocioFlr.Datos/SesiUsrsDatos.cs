using NegocioFlr.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NegocioFlr.Datos
{
    public class SesiUsrsDatos
    {
        #region Variables
        private SqlConnection _Conexion = new SqlConnection();
        private SqlCommand _Comando;
        private SqlDataReader _Resultado;
        #endregion

        #region Métodos
        /// <summary>
        /// Consulta la sesion del usuario registrado
        /// </summary>
        /// <param name="_sesiusrs">Clase sesion usuario</param>
        /// <param name="_Codigo">Código de error</param>
        /// <param name="_Mensaje">Mensaje de error</param>
        /// <returns>Listado de sesiones de usuarios</returns>
        public List<SesiUsrs> consulta_Sesion(SesiUsrs _sesiusrs, ref Int32 _Codigo, ref string _Mensaje)
        {
            Usuarios _oUsuario = new Usuarios();

            _Conexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            List<SesiUsrs> lstSesiUsrs = new List<SesiUsrs>();
            _Codigo = 0;
            _Mensaje = "OK";

            try
            {
                _Conexion.Open();

                //  Parámetros:
                //  Identificador del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.Int32;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Ide_Usr";
                _Parametro1.Value = _sesiusrs.Ide_Usr;

                _Comando = new SqlCommand();
                _Comando.CommandType = System.Data.CommandType.StoredProcedure;
                _Comando.CommandText = "sp_Consulta_Sesion";
                _Comando.Connection = _Conexion;
                _Comando.Parameters.Add(_Parametro1);
                _Resultado = _Comando.ExecuteReader();

                while (_Resultado.Read())
                {
                    SesiUsrs sesiusrs = new SesiUsrs();

                    sesiusrs.Ide_Ses = _Resultado.GetGuid(0).ToString();
                    sesiusrs.Fec_Ses = _Resultado.GetDateTime(1);

                    lstSesiUsrs.Add(sesiusrs);
                }
            }
            catch (SqlException Error)
            {
                _Codigo = Error.ErrorCode;
                _Mensaje = Error.Message;
            }
            finally
            {
                if (_Comando != null)
                {
                    _Comando.Dispose();
                    _Conexion.Close();
                }
            }

            return lstSesiUsrs;
        }

        /// <summary>
        /// Consulta la sesion del usuario que ingreso al sistema
        /// </summary>
        /// <param name="_sesiusrs">Clase sesion usuario</param>
        /// <param name="_Codigo">Código de error</param>
        /// <param name="_Mensaje">Mensaje de error</param>
        /// <returns>Cantidad de sesiones del usuario</returns>
        public Boolean existe_Sesion(SesiUsrs _sesiusrs, ref Int32 _Codigo, ref string _Mensaje)
        {
            Usuarios _oUsuario = new Usuarios();

            _Conexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            _Codigo = 0;
            _Mensaje = null;
            bool _Resultado;

            try
            {
                _Conexion.Open();

                //  Parámetros:
                //  Identificador del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.Int32;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Ide_Usr";
                _Parametro1.Value = _sesiusrs.Ide_Usr;
                //  Código de error
                SqlParameter _Parametro2 = new SqlParameter();
                _Parametro2.DbType = System.Data.DbType.Int32;
                _Parametro2.Direction = System.Data.ParameterDirection.Output;
                _Parametro2.Size = 4;
                _Parametro2.ParameterName = "@Cod_Err";
                //  Descripción de error
                SqlParameter _Parametro3 = new SqlParameter();
                _Parametro3.DbType = System.Data.DbType.String;
                _Parametro3.Direction = System.Data.ParameterDirection.Output;
                _Parametro3.Size = 100;
                _Parametro3.ParameterName = "@Des_Err";

                _Comando = new SqlCommand();
                _Comando.CommandType = System.Data.CommandType.StoredProcedure;
                _Comando.CommandText = "sp_Existe_Sesion";
                _Comando.Connection = _Conexion;
                _Comando.Parameters.Add(_Parametro1);
                _Comando.Parameters.Add(_Parametro2);
                _Comando.Parameters.Add(_Parametro3);
                _Comando.ExecuteNonQuery();

                _Codigo = Convert.ToInt32(_Comando.Parameters["@Cod_Err"].Value);
                _Mensaje = _Comando.Parameters["@Des_Err"].Value.ToString();

                if (_Codigo == 0)
                {
                    _Resultado = true;
                }
                else
                {
                    _Resultado = false;
                }
            }
            catch (SqlException Error)
            {
                _Codigo = Error.ErrorCode;
                _Mensaje = Error.Message;
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
        /// Alta de la sesion del usuario en el sistema
        /// </summary>
        /// <param name="_sesiusrs">Clase sesion usuario</param>
        /// <param name="_Codigo">Código de error</param>
        /// <param name="_Mensaje">Mensaje de error</param>
        /// <returns>Verdadero o Falso</returns>
        public Boolean registra_Sesion(SesiUsrs _sesiusrs, ref Int32 _Codigo, ref string _Mensaje)
        {
            Usuarios _oUsuario = new Usuarios();

            _Conexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            _Codigo = 0;
            _Mensaje = null;
            bool _Resultado;

            try
            {
                _Conexion.Open();

                //  Parámetros:
                //  Identificador del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.Int32;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Ide_Usr";
                _Parametro1.Value = _sesiusrs.Ide_Usr;
                //  Código de error
                SqlParameter _Parametro2 = new SqlParameter();
                _Parametro2.DbType = System.Data.DbType.Int32;
                _Parametro2.Direction = System.Data.ParameterDirection.Output;
                _Parametro2.Size = 4;
                _Parametro2.ParameterName = "@Cod_Err";
                //  Descripción de error
                SqlParameter _Parametro3 = new SqlParameter();
                _Parametro3.DbType = System.Data.DbType.String;
                _Parametro3.Direction = System.Data.ParameterDirection.Output;
                _Parametro3.Size = 100;
                _Parametro3.ParameterName = "@Des_Err";

                _Comando = new SqlCommand();
                _Comando.CommandType = System.Data.CommandType.StoredProcedure;
                _Comando.CommandText = "sp_Registra_Sesion";
                _Comando.Connection = _Conexion;
                _Comando.Parameters.Add(_Parametro1);
                _Comando.Parameters.Add(_Parametro2);
                _Comando.Parameters.Add(_Parametro3);
                _Comando.ExecuteNonQuery();

                _Codigo = Convert.ToInt32(_Comando.Parameters["@Cod_Err"].Value);
                _Mensaje = _Comando.Parameters["@Des_Err"].Value.ToString();

                if (_Codigo == 0)
                {
                    _Resultado = true;
                }
                else
                {
                    _Resultado = false;
                }
            }
            catch (SqlException Error)
            {
                _Codigo = Error.ErrorCode;
                _Mensaje = Error.Message;
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
        /// Elimina la sesion del usuario del sistema
        /// </summary>
        /// <param name="_sesiusrs">Clase sesion usuario</param>
        /// <param name="_Codigo">Código de error</param>
        /// <param name="_Mensaje">Mensaje de error</param>
        /// <returns>Verdadero o Falso</returns>
        public Boolean elimina_Sesion(SesiUsrs _sesiusrs, ref Int32 _Codigo, ref string _Mensaje)
        {
            Usuarios _oUsuario = new Usuarios();

            _Conexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            _Codigo = 0;
            _Mensaje = null;
            bool _Resultado;

            try
            {
                _Conexion.Open();

                //  Parámetros:
                //  Identificador del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.Int32;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Ide_Usr";
                _Parametro1.Value = _sesiusrs.Ide_Usr;

                _Comando = new SqlCommand();
                _Comando.CommandType = System.Data.CommandType.StoredProcedure;
                _Comando.CommandText = "sp_Elimina_Sesion";
                _Comando.Connection = _Conexion;
                _Comando.Parameters.Add(_Parametro1);
                _Comando.ExecuteNonQuery();

                _Resultado = true;
            }
            catch (SqlException Error)
            {
                _Codigo = Error.ErrorCode;
                _Mensaje = Error.Message;
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
