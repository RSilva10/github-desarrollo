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
        private SqlConnection _oConexion = new SqlConnection();
        private SqlCommand _oComando;
        private SqlDataReader _oResultado;
        #endregion

        #region Métodos
        /// <summary>
        /// Consulta la sesion del usuario registrado
        /// </summary>
        /// <param name="_oSesiusrs">Clase sesion usuario</param>
        /// <param name="_iCodigo">Código de error</param>
        /// <param name="_sMensaje">Mensaje de error</param>
        /// <returns>Listado de sesiones de usuarios</returns>
        public List<SesiUsrs> consulta_Sesion(SesiUsrs _oSesiusrs, ref Int32 _iCodigo, ref string _sMensaje)
        {
            Usuarios _oUsuario = new Usuarios();

            _oConexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            List<SesiUsrs> lstSesiUsrs = new List<SesiUsrs>();
            _iCodigo = 0;
            _sMensaje = "OK";

            try
            {
                _oConexion.Open();

                //  Parámetros:
                //  Identificador del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.Int32;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Ide_Usr";
                _Parametro1.Value = _oSesiusrs.Ide_Usr;

                _oComando = new SqlCommand();
                _oComando.CommandType = System.Data.CommandType.StoredProcedure;
                _oComando.CommandText = "sp_Consulta_Sesion";
                _oComando.Connection = _oConexion;
                _oComando.Parameters.Add(_Parametro1);
                _oResultado = _oComando.ExecuteReader();

                while (_oResultado.Read())
                {
                    SesiUsrs sesiusrs = new SesiUsrs();

                    sesiusrs.Ide_Ses = _oResultado.GetGuid(0).ToString();
                    sesiusrs.Fec_Ses = _oResultado.GetDateTime(1);

                    lstSesiUsrs.Add(sesiusrs);
                }
            }
            catch (SqlException Error)
            {
                _iCodigo = Error.ErrorCode;
                _sMensaje = Error.Message;
            }
            finally
            {
                if (_oComando != null)
                {
                    _oComando.Dispose();
                    _oConexion.Close();
                }
            }

            return lstSesiUsrs;
        }

        /// <summary>
        /// Consulta la sesion del usuario que ingreso al sistema
        /// </summary>
        /// <param name="_oSesiusrs">Clase sesion usuario</param>
        /// <param name="_iCodigo">Código de error</param>
        /// <param name="_sMensaje">Mensaje de error</param>
        /// <returns>Cantidad de sesiones del usuario</returns>
        public Boolean existe_Sesion(SesiUsrs _oSesiusrs, ref Int32 _iCodigo, ref string _sMensaje)
        {
            Usuarios _oUsuario = new Usuarios();

            _oConexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            _iCodigo = 0;
            _sMensaje = null;
            bool _oResultado;

            try
            {
                _oConexion.Open();

                //  Parámetros:
                //  Identificador del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.Int32;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Ide_Usr";
                _Parametro1.Value = _oSesiusrs.Ide_Usr;
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

                _oComando = new SqlCommand();
                _oComando.CommandType = System.Data.CommandType.StoredProcedure;
                _oComando.CommandText = "sp_Existe_Sesion";
                _oComando.Connection = _oConexion;
                _oComando.Parameters.Add(_Parametro1);
                _oComando.Parameters.Add(_Parametro2);
                _oComando.Parameters.Add(_Parametro3);
                _oComando.ExecuteNonQuery();

                _iCodigo = Convert.ToInt32(_oComando.Parameters["@Cod_Err"].Value);
                _sMensaje = _oComando.Parameters["@Des_Err"].Value.ToString();

                if (_iCodigo == 0)
                {
                    _oResultado = true;
                }
                else
                {
                    _oResultado = false;
                }
            }
            catch (SqlException Error)
            {
                _iCodigo = Error.ErrorCode;
                _sMensaje = Error.Message;
                _oResultado = false;
            }
            finally
            {
                if (_oComando != null)
                {
                    _oComando.Dispose();
                    _oConexion.Close();
                }
            }

            return _oResultado;
        }

        /// <summary>
        /// Alta de la sesion del usuario en el sistema
        /// </summary>
        /// <param name="_oSesiusrs">Clase sesion usuario</param>
        /// <param name="_iCodigo">Código de error</param>
        /// <param name="_sMensaje">Mensaje de error</param>
        /// <returns>Verdadero o Falso</returns>
        public Boolean registra_Sesion(SesiUsrs _oSesiusrs, ref Int32 _iCodigo, ref string _sMensaje)
        {
            Usuarios _oUsuario = new Usuarios();

            _oConexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            _iCodigo = 0;
            _sMensaje = null;
            bool _oResultado;

            try
            {
                _oConexion.Open();

                //  Parámetros:
                //  Identificador del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.Int32;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Ide_Usr";
                _Parametro1.Value = _oSesiusrs.Ide_Usr;
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

                _oComando = new SqlCommand();
                _oComando.CommandType = System.Data.CommandType.StoredProcedure;
                _oComando.CommandText = "sp_Registra_Sesion";
                _oComando.Connection = _oConexion;
                _oComando.Parameters.Add(_Parametro1);
                _oComando.Parameters.Add(_Parametro2);
                _oComando.Parameters.Add(_Parametro3);
                _oComando.ExecuteNonQuery();

                _iCodigo = Convert.ToInt32(_oComando.Parameters["@Cod_Err"].Value);
                _sMensaje = _oComando.Parameters["@Des_Err"].Value.ToString();

                if (_iCodigo == 0)
                {
                    _oResultado = true;
                }
                else
                {
                    _oResultado = false;
                }
            }
            catch (SqlException Error)
            {
                _iCodigo = Error.ErrorCode;
                _sMensaje = Error.Message;
                _oResultado = false;
            }
            finally
            {
                if (_oComando != null)
                {
                    _oComando.Dispose();
                    _oConexion.Close();
                }
            }

            return _oResultado;
        }

        /// <summary>
        /// Elimina la sesion del usuario del sistema
        /// </summary>
        /// <param name="_oSesiusrs">Clase sesion usuario</param>
        /// <param name="_iCodigo">Código de error</param>
        /// <param name="_sMensaje">Mensaje de error</param>
        /// <returns>Verdadero o Falso</returns>
        public Boolean elimina_Sesion(SesiUsrs _oSesiusrs, ref Int32 _iCodigo, ref string _sMensaje)
        {
            Usuarios _oUsuario = new Usuarios();

            _oConexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            _iCodigo = 0;
            _sMensaje = null;
            bool _oResultado;

            try
            {
                _oConexion.Open();

                //  Parámetros:
                //  Identificador del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.Int32;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Ide_Usr";
                _Parametro1.Value = _oSesiusrs.Ide_Usr;
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

                _oComando = new SqlCommand();
                _oComando.CommandType = System.Data.CommandType.StoredProcedure;
                _oComando.CommandText = "sp_Elimina_Sesion";
                _oComando.Connection = _oConexion;
                _oComando.Parameters.Add(_Parametro1);
                _oComando.Parameters.Add(_Parametro2);
                _oComando.Parameters.Add(_Parametro3);
                _oComando.ExecuteNonQuery();

                _oResultado = true;
            }
            catch (SqlException Error)
            {
                _iCodigo = Error.ErrorCode;
                _sMensaje = Error.Message;
                _oResultado = false;
            }
            finally
            {
                if (_oComando != null)
                {
                    _oComando.Dispose();
                    _oConexion.Close();
                }
            }

            return _oResultado;
        }
        #endregion
    }
}
