using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using NegocioFlr.Entidades;
using System.Data.OleDb;
using System.Configuration;

namespace NegocioFlr.Datos
{
    public class UsuariosDatos
    {
        #region Variables
        private SqlConnection _oConexion = new SqlConnection();
        private SqlCommand _oComando;
        private SqlDataReader _oResultado;
        #endregion

        #region Métodos
        /// <summary>
        /// Consulta del usuario registrado
        /// </summary>
        /// <param name="_oUsuarios">Clase usuario</param>
        /// <param name="_iCodigo">Código de error</param>
        /// <param name="_sMensaje">Mensaje de error</param>
        /// <returns>Listado de usuario</returns>
        public List<Usuarios> consulta_Usuario(Usuarios _oUsuarios, ref Int32 _iCodigo, ref string _sMensaje)
        {
            Usuarios _oUsuario = new Usuarios();

            _oConexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            List<Usuarios> lstUsuarios = new List<Usuarios>();
            _iCodigo = 0;
            _sMensaje = "OK";

            try
            {
                _oConexion.Open();

                //  Parámetros:
                //  Clave del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.String;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Cve_Usr";
                _Parametro1.Value = _oUsuarios.Cve_Usr;
                //  Contraseña del usuario
                SqlParameter _Parametro2 = new SqlParameter();
                _Parametro2.DbType = System.Data.DbType.String;
                _Parametro2.Direction = System.Data.ParameterDirection.Input;
                _Parametro2.ParameterName = "@Pas_Usr";
                _Parametro2.Value = _oUsuarios.Pas_Usr;
                //  Alias del cliente
                SqlParameter _Parametro3 = new SqlParameter();
                _Parametro3.DbType = System.Data.DbType.String;
                _Parametro3.Direction = System.Data.ParameterDirection.Input;
                _Parametro3.ParameterName = "@Ali_Usr";
                _Parametro3.Value = _oUsuarios.Ali_Cli;

                _oComando = new SqlCommand();
                _oComando.CommandType = System.Data.CommandType.StoredProcedure;
                _oComando.CommandText = "sp_Consulta_Usuario";  
                _oComando.Connection = _oConexion;
                _oComando.Parameters.Add(_Parametro1);
                _oComando.Parameters.Add(_Parametro2);
                _oComando.Parameters.Add(_Parametro3);
                _oResultado = _oComando.ExecuteReader();

                while (_oResultado.Read())
                {
                    Usuarios usuarios = new Usuarios();

                    usuarios.Ide_Usr = _oResultado.GetInt32(0);
                    usuarios.Cve_Usr = _oResultado.GetString(1);
                    usuarios.Ape_Pat = _oResultado.GetString(2);
                    usuarios.Ape_Mat = _oResultado.GetString(3);
                    usuarios.Nom_bre = _oResultado.GetString(4);
                    usuarios.Fec_Ing = _oResultado.GetDateTime(5);
                    usuarios.Fec_Vig = _oResultado.GetDateTime(6);
                    usuarios.Cor_reo = _oResultado.GetString(7);
                    usuarios.Rso_Cli = _oResultado.GetString(8);
                    usuarios.Cal_Cli = _oResultado.GetString(9);
                    usuarios.NEx_Cli = _oResultado.GetString(10);
                    usuarios.NIn_Cli = _oResultado.GetString(11);
                    usuarios.Col_Cli = _oResultado.GetString(12);
                    usuarios.Cop_Cli = _oResultado.GetString(13);
                    usuarios.Del_Cli = _oResultado.GetString(14);
                    usuarios.Ciu_Cli = _oResultado.GetString(15);
                    usuarios.Ico_Cli = _oResultado.GetString(16);

                    lstUsuarios.Add(usuarios);
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

            return lstUsuarios;
        }

        /// <summary>
        /// Consulta todos los usuarios registrados 
        /// </summary>
        /// <param name="_iEstatus">Criterio de estatus</param>
        /// <param name="_sNombre">Criterio de nombre</param>
        /// <param name="_sAPaterno">Criterio de apellido paterno</param>
        /// <param name="_sAMaterno">Criterio de apellido materno</param>
        /// <param name="_iLlave">Criterio de identificador del usuario</param>
        /// <param name="_iCodigo">Código de error</param>
        /// <param name="_sMensaje">Mensaje de error</param>
        /// <returns>Listado de usuarios</returns>
        public List<Usuarios> consulta_Usuarios(int _iEstatus, string _sNombre, string _sAPaterno, string _sAMaterno, int _iLlave, ref Int32 _iCodigo, ref string _sMensaje)
        {
            Usuarios _oUsuario = new Usuarios();

            _oConexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            List<Usuarios> lstUsuarios = new List<Usuarios>();
            _iCodigo = 0;
            _sMensaje = "OK";

            try
            {
                _oConexion.Open();

                //  Parámetros:
                //  Estatus del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.Int32;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Est_Usr";
                _Parametro1.Value = _iEstatus;
                //  Nombre del usuario
                SqlParameter _Parametro2 = new SqlParameter();
                _Parametro2.DbType = System.Data.DbType.String;
                _Parametro2.Direction = System.Data.ParameterDirection.Input;
                _Parametro2.ParameterName = "@Nom_bre";
                _Parametro2.Value = _sNombre;
                //  Apellido Paterno del usuario
                SqlParameter _Parametro3 = new SqlParameter();
                _Parametro3.DbType = System.Data.DbType.String;
                _Parametro3.Direction = System.Data.ParameterDirection.Input;
                _Parametro3.ParameterName = "@Ape_Pat";
                _Parametro3.Value = _sAPaterno;
                //  Apellido Materno del usuario
                SqlParameter _Parametro4 = new SqlParameter();
                _Parametro4.DbType = System.Data.DbType.String;
                _Parametro4.Direction = System.Data.ParameterDirection.Input;
                _Parametro4.ParameterName = "@Ape_Mat";
                _Parametro4.Value = _sAMaterno;
                //  Identificador del usuario
                SqlParameter _Parametro5 = new SqlParameter();
                _Parametro5.DbType = System.Data.DbType.Int32;
                _Parametro5.Direction = System.Data.ParameterDirection.Input;
                _Parametro5.ParameterName = "@Ide_Usr";
                _Parametro5.Value = _iLlave;

                _oComando = new SqlCommand();
                _oComando.CommandType = System.Data.CommandType.StoredProcedure;
                _oComando.CommandText = "sp_Consulta_Usuarios";
                _oComando.Connection = _oConexion;
                _oComando.Parameters.Add(_Parametro1);
                _oComando.Parameters.Add(_Parametro2);
                _oComando.Parameters.Add(_Parametro3);
                _oComando.Parameters.Add(_Parametro4);
                _oComando.Parameters.Add(_Parametro5);
                _oResultado = _oComando.ExecuteReader();

                while (_oResultado.Read())
                {
                    Usuarios usuarios = new Usuarios();

                    usuarios.Ide_Usr = _oResultado.GetInt32(0);
                    usuarios.Nom_bre = _oResultado.GetString(1);
                    usuarios.Ape_Pat = _oResultado.GetString(2);
                    usuarios.Ape_Mat = _oResultado.GetString(3);
                    usuarios.Cor_reo = _oResultado.GetString(4);
                    usuarios.Ide_Usr = _oResultado.GetInt32(5);
                    if (_iLlave > 0)
                    {
                        usuarios.Cve_Usr = _oResultado.GetString(6);
                        usuarios.Pas_Usr = _oResultado.GetString(7);
                        usuarios.Est_Usr = _oResultado.GetByte(8);
                    }

                    lstUsuarios.Add(usuarios);
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

            return lstUsuarios;
        }

        /// <summary>
        /// Alta del usuario en el sistema
        /// </summary>
        /// <param name="_oUsuarios">Clase usuario</param>
        /// <param name="_iCodigo">Código de error</param>
        /// <param name="_sMensaje">Mensaje de error</param>
        /// <param name="_Contrasenia">Contraseña generada para el usuario</param>
        /// <returns>Verdadero o Falso</returns>
        public Boolean registra_Usuario(Usuarios _oUsuarios, ref Int32 _iCodigo, ref string _sMensaje, ref string _Contrasenia)
        {
            Usuarios _oUsuario = new Usuarios();

            _oConexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            _iCodigo = 0;
            _sMensaje = null;
            bool _oResultado; 

            try
            {
                if (_Contrasenia != null) 
                {
                    _oUsuarios.Pas_Usr = _oUsuarios.genera_Pwd;
                }
                else 
                {
                    _oUsuarios.Pas_Usr = _Contrasenia;
                }
                _Contrasenia = _oUsuarios.Pas_Usr;

                _oConexion.Open();

                //  Parámetros:
                //  Clave del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.String;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Cve_Usr";
                _Parametro1.Value = _oUsuarios.Cve_Usr;
                //  Contraseña del usuario
                SqlParameter _Parametro2 = new SqlParameter();
                _Parametro2.DbType = System.Data.DbType.String;
                _Parametro2.Direction = System.Data.ParameterDirection.Input;
                _Parametro2.ParameterName = "@Pas_Usr";
                _Parametro2.Value = _oUsuarios.encripta_Pwd;
                //  Apellido paterno
                SqlParameter _Parametro3 = new SqlParameter();
                _Parametro3.DbType = System.Data.DbType.String;
                _Parametro3.Direction = System.Data.ParameterDirection.Input;
                _Parametro3.ParameterName = "@Ape_Pat";
                _Parametro3.Value = _oUsuarios.Ape_Pat;
                //  Apellido materno
                SqlParameter _Parametro4 = new SqlParameter();
                _Parametro4.DbType = System.Data.DbType.String;
                _Parametro4.Direction = System.Data.ParameterDirection.Input;
                _Parametro4.ParameterName = "@Ape_Mat";
                _Parametro4.Value = _oUsuarios.Ape_Mat;
                //  Nombre
                SqlParameter _Parametro5 = new SqlParameter();
                _Parametro5.DbType = System.Data.DbType.String;
                _Parametro5.Direction = System.Data.ParameterDirection.Input;
                _Parametro5.ParameterName = "@Nom_bre";
                _Parametro5.Value = _oUsuarios.Nom_bre;
                //  Fecha de ingreso
                SqlParameter _Parametro6 = new SqlParameter();
                _Parametro6.DbType = System.Data.DbType.DateTime;
                _Parametro6.Direction = System.Data.ParameterDirection.Input;
                _Parametro6.ParameterName = "@Fec_Ing";
                _Parametro6.Value = _oUsuarios.Fec_Ing;
                //  Fecha de vigencia
                SqlParameter _Parametro7 = new SqlParameter();
                _Parametro7.DbType = System.Data.DbType.DateTime;
                _Parametro7.Direction = System.Data.ParameterDirection.Input;
                _Parametro7.ParameterName = "@Fec_Vig";
                _Parametro7.Value = _oUsuarios.Fec_Vig;
                //  Correo electrónico
                SqlParameter _Parametro8 = new SqlParameter();
                _Parametro8.DbType = System.Data.DbType.String;
                _Parametro8.Direction = System.Data.ParameterDirection.Input;
                _Parametro8.ParameterName = "@Cor_reo";
                _Parametro8.Value = _oUsuarios.Cor_reo;
                //  Clave del cliente
                SqlParameter _Parametro9 = new SqlParameter();
                _Parametro9.DbType = System.Data.DbType.String;
                _Parametro9.Direction = System.Data.ParameterDirection.Input;
                _Parametro9.ParameterName = "@Ali_Cli";
                _Parametro9.Value = _oUsuarios.Ali_Cli;
                //  Código de error
                SqlParameter _Parametro10 = new SqlParameter();
                _Parametro10.DbType = System.Data.DbType.Int32;
                _Parametro10.Direction = System.Data.ParameterDirection.Output;
                _Parametro10.Size = 4;
                _Parametro10.ParameterName = "@Cod_Err";
                //  Descripción de error
                SqlParameter _Parametro11 = new SqlParameter();
                _Parametro11.DbType = System.Data.DbType.String;
                _Parametro11.Direction = System.Data.ParameterDirection.Output;
                _Parametro11.Size = 100;
                _Parametro11.ParameterName = "@Des_Err";

                _oComando = new SqlCommand();
                _oComando.CommandType = System.Data.CommandType.StoredProcedure;
                _oComando.CommandText = "sp_Registra_Usuario";
                _oComando.Connection = _oConexion;
                _oComando.Parameters.Add(_Parametro1);
                _oComando.Parameters.Add(_Parametro2);
                _oComando.Parameters.Add(_Parametro3);
                _oComando.Parameters.Add(_Parametro4);
                _oComando.Parameters.Add(_Parametro5);
                _oComando.Parameters.Add(_Parametro6);
                _oComando.Parameters.Add(_Parametro7);
                _oComando.Parameters.Add(_Parametro8);
                _oComando.Parameters.Add(_Parametro9);
                _oComando.Parameters.Add(_Parametro10);
                _oComando.Parameters.Add(_Parametro11);
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
        /// Actualización del usuario en el sistema 
        /// </summary>
        /// <param name="_oUsuarios">Clase usuario</param>
        /// <param name="_iCodigo">Código de error</param>
        /// <param name="_sMensaje">Mensaje de error</param>
        /// <returns>Verdadero o Falso</returns>
        public Boolean actualiza_Usuario(Usuarios _oUsuarios, ref Int32 _iCodigo, ref string _sMensaje)
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
                //  Clave usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.String;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Cve_Usr";
                _Parametro1.Value = _oUsuarios.Cve_Usr;
                //  Contraseña del usuario
                SqlParameter _Parametro2 = new SqlParameter();
                _Parametro2.DbType = System.Data.DbType.String;
                _Parametro2.Direction = System.Data.ParameterDirection.Input;
                _Parametro2.ParameterName = "@Pas_Usr";
                _Parametro2.Value = _oUsuarios.encripta_Pwd;
                //  Apellido paterno
                SqlParameter _Parametro3 = new SqlParameter();
                _Parametro3.DbType = System.Data.DbType.String;
                _Parametro3.Direction = System.Data.ParameterDirection.Input;
                _Parametro3.ParameterName = "@Ape_Pat";
                _Parametro3.Value = _oUsuarios.Ape_Pat;
                //  Apellido materno
                SqlParameter _Parametro4 = new SqlParameter();
                _Parametro4.DbType = System.Data.DbType.String;
                _Parametro4.Direction = System.Data.ParameterDirection.Input;
                _Parametro4.ParameterName = "@Ape_Mat";
                _Parametro4.Value = _oUsuarios.Ape_Mat;
                //  Nombre
                SqlParameter _Parametro5 = new SqlParameter();
                _Parametro5.DbType = System.Data.DbType.String;
                _Parametro5.Direction = System.Data.ParameterDirection.Input;
                _Parametro5.ParameterName = "@Nom_bre";
                _Parametro5.Value = _oUsuarios.Nom_bre;
                //  Correo electrónico
                SqlParameter _Parametro6 = new SqlParameter();
                _Parametro6.DbType = System.Data.DbType.String;
                _Parametro6.Direction = System.Data.ParameterDirection.Input;
                _Parametro6.ParameterName = "@Cor_reo";
                _Parametro6.Value = _oUsuarios.Cor_reo;
                //  Estatus
                SqlParameter _Parametro7 = new SqlParameter();
                _Parametro7.DbType = System.Data.DbType.Byte;
                _Parametro7.Direction = System.Data.ParameterDirection.Input;
                _Parametro7.ParameterName = "@Est_Usr";
                _Parametro7.Value = _oUsuarios.Est_Usr;
                //  Identificador del usuario
                SqlParameter _Parametro8 = new SqlParameter();
                _Parametro8.DbType = System.Data.DbType.Byte;
                _Parametro8.Direction = System.Data.ParameterDirection.Input;
                _Parametro8.ParameterName = "@Ide_Usr";
                _Parametro8.Value = _oUsuarios.Ide_Usr;
                //  Código de error
                SqlParameter _Parametro9 = new SqlParameter();
                _Parametro9.DbType = System.Data.DbType.Int32;
                _Parametro9.Direction = System.Data.ParameterDirection.Output;
                _Parametro9.Size = 4;
                _Parametro9.ParameterName = "@Cod_Err";
                //  Descripción de error
                SqlParameter _Parametro10 = new SqlParameter();
                _Parametro10.DbType = System.Data.DbType.String;
                _Parametro10.Direction = System.Data.ParameterDirection.Output;
                _Parametro10.Size = 100;
                _Parametro10.ParameterName = "@Des_Err";

                _oComando = new SqlCommand();
                _oComando.CommandType = System.Data.CommandType.StoredProcedure;
                _oComando.CommandText = "sp_Actualiza_Usuario";
                _oComando.Connection = _oConexion;
                _oComando.Parameters.Add(_Parametro1);
                _oComando.Parameters.Add(_Parametro2);
                _oComando.Parameters.Add(_Parametro3);
                _oComando.Parameters.Add(_Parametro4);
                _oComando.Parameters.Add(_Parametro5);
                _oComando.Parameters.Add(_Parametro6);
                _oComando.Parameters.Add(_Parametro7);
                _oComando.Parameters.Add(_Parametro8);
                _oComando.Parameters.Add(_Parametro9);
                _oComando.Parameters.Add(_Parametro10);
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
            /// Revisa si el usuario existe en el sistema
            /// </summary>
            /// <param name="_oUsuarios">Clase usuario</param>
            /// <param name="_iCodigo">Código de error</param>
            /// <param name="_sMensaje">Mensaje de error</param>
            /// <returns>Verdadero o Falso</returns>
        public Boolean existe_Usuario(Usuarios _oUsuarios, ref Int32 _iCodigo, ref string _sMensaje)
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
                _Parametro1.DbType = System.Data.DbType.String;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Cve_Usr";
                _Parametro1.Value = _oUsuarios.Cve_Usr;
                //  Contraseña del usuario
                SqlParameter _Parametro2 = new SqlParameter();
                _Parametro2.DbType = System.Data.DbType.String;
                _Parametro2.Direction = System.Data.ParameterDirection.Input;
                _Parametro2.ParameterName = "@Pas_Usr";
                _Parametro2.Value = _oUsuarios.Pas_Usr;
                //  Alias del cliente
                SqlParameter _Parametro3 = new SqlParameter();
                _Parametro3.DbType = System.Data.DbType.String;
                _Parametro3.Direction = System.Data.ParameterDirection.Input;
                _Parametro3.ParameterName = "@Ali_Cli";
                _Parametro3.Value = _oUsuarios.Ali_Cli;
                //  Código de error
                SqlParameter _Parametro4 = new SqlParameter();
                _Parametro4.DbType = System.Data.DbType.Int32;
                _Parametro4.Direction = System.Data.ParameterDirection.Output;
                _Parametro4.Size = 4;
                _Parametro4.ParameterName = "@Cod_Err";
                //  Descripción de error
                SqlParameter _Parametro5 = new SqlParameter();
                _Parametro5.DbType = System.Data.DbType.String;
                _Parametro5.Direction = System.Data.ParameterDirection.Output;
                _Parametro5.Size = 100;
                _Parametro5.ParameterName = "@Des_Err";

                _oComando = new SqlCommand();
                _oComando.CommandType = System.Data.CommandType.StoredProcedure;
                _oComando.CommandText = "sp_Existe_Usuario";
                _oComando.Connection = _oConexion;
                _oComando.Parameters.Add(_Parametro1);
                _oComando.Parameters.Add(_Parametro2);
                _oComando.Parameters.Add(_Parametro3);
                _oComando.Parameters.Add(_Parametro4);
                _oComando.Parameters.Add(_Parametro5);

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
                _sMensaje = Error.ErrorCode.ToString() + ": " + Error.Message;
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
        /// Elimina un usuario del sistema
        /// </summary>
        /// <param name="_oUsuarios">Clase usuario</param>
        /// <param name="_iCodigo">Código de error</param>
        /// <param name="_sMensaje">Mensaje de error</param>
        /// <returns>Verdadero o Falso</returns>
        public Boolean elimina_Usuario(Usuarios _oUsuarios, ref Int32 _iCodigo, ref string _sMensaje)
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
                _Parametro1.Value = _oUsuarios.Ide_Usr;
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
                _oComando.CommandText = "sp_Elimina_Usuario";
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
        /// Consulta los días de vigencia de un usuario
        /// </summary>
        /// <param name="_oUsuarios">Clase usuario</param>
        /// <param name="_iCodigo">Código de error</param>
        /// <param name="_sMensaje">Mensaje de error</param>
        /// <returns>Cantidad de días de vigencia</returns>
        public int dias_Vigencia(Usuarios _oUsuarios, ref Int32 _iCodigo, ref string _sMensaje) 
        {
            Usuarios _oUsuario = new Usuarios();
            _iCodigo = 0;
            _sMensaje = null;
            int _iResultado = 0;

            _oConexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);

            try 
            {
                _oConexion.Open();

                //  Parámetros:
                //  Identificador del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.Int32;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Ide_Usr";
                _Parametro1.Value = _oUsuarios.Ide_Usr;

                _oComando = new SqlCommand();
                _oComando.CommandType = System.Data.CommandType.StoredProcedure;
                _oComando.CommandText = "sp_Consulta_Vigencia";
                _oComando.Connection = _oConexion;
                _oComando.Parameters.Add(_Parametro1);
                _oResultado = _oComando.ExecuteReader();

                while (_oResultado.Read())
                {
                    _iResultado = _oResultado.GetInt32(0);
                }
            }
            catch (SqlException Error)
            {
                _iCodigo = Error.ErrorCode;
                _sMensaje = Error.Message;
                _iResultado = -1;
            }
            finally
            {
                if (_oComando != null)
                {
                    _oComando.Dispose();
                    _oConexion.Close();
                }
            }

            return _iResultado;
        }

        /// <summary>
        /// Actualiza la contraseña y la fecha de vigencia del usuario
        /// </summary>
        /// <param name="_oUsuarios">Clase usuario</param>
        /// <param name="_sContrasenia">Nueva contraseña generada</param>
        /// <param name="_iCodigo">Código de error</param>
        /// <param name="_sMensaje">Mensaje de error</param>
        /// <returns>Verdadero o Falso</returns>
        public Boolean actualiza_Vigencia(Usuarios _oUsuarios, ref string _sContrasenia, ref Int32 _iCodigo, ref string _sMensaje) 
        {
            Usuarios _oUsuario = new Usuarios();

            _oConexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            _iCodigo = 0;
            _sMensaje = null;
            _sContrasenia = null;
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
                _Parametro1.Value = _oUsuarios.Ide_Usr;
                //  Contraseña del usuario
                SqlParameter _Parametro2 = new SqlParameter();
                _Parametro2.DbType = System.Data.DbType.String;
                _Parametro2.Direction = System.Data.ParameterDirection.Input;
                _Parametro2.ParameterName = "@Pas_Usr";
                _oUsuarios.Pas_Usr = _oUsuarios.genera_Pwd;
                _sContrasenia = _oUsuarios.Pas_Usr;
                _Parametro2.Value = _oUsuarios.encripta_Pwd;
                //  Código de error
                SqlParameter _Parametro3 = new SqlParameter();
                _Parametro3.DbType = System.Data.DbType.Int32;
                _Parametro3.Direction = System.Data.ParameterDirection.Output;
                _Parametro3.Size = 4;
                _Parametro3.ParameterName = "@Cod_Err";
                //  Descripción de error
                SqlParameter _Parametro4 = new SqlParameter();
                _Parametro4.DbType = System.Data.DbType.String;
                _Parametro4.Direction = System.Data.ParameterDirection.Output;
                _Parametro4.Size = 100;
                _Parametro4.ParameterName = "@Des_Err";

                _oComando = new SqlCommand();
                _oComando.CommandType = System.Data.CommandType.StoredProcedure;
                _oComando.CommandText = "sp_Actualiza_Vigencia";
                _oComando.Connection = _oConexion;
                _oComando.Parameters.Add(_Parametro1);
                _oComando.Parameters.Add(_Parametro2);
                _oComando.Parameters.Add(_Parametro3);
                _oComando.Parameters.Add(_Parametro4);
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
        #endregion
    }
}
