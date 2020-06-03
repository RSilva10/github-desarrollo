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
        private SqlConnection _Conexion = new SqlConnection();
        private SqlCommand _Comando;
        private SqlDataReader _Resultado;
        #endregion

        #region Métodos
        /// <summary>
        /// Consulta del usuario registrado
        /// </summary>
        /// <param name="_usuarios">Clase usuario</param>
        /// <param name="_Codigo">Código de error</param>
        /// <param name="_Mensaje">Mensaje de error</param>
        /// <returns>Listado de usuario</returns>
        public List<Usuarios> consulta_Usuario(Usuarios _usuarios, ref Int32 _Codigo, ref string _Mensaje)
        {
            Usuarios _oUsuario = new Usuarios();

            _Conexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            List<Usuarios> lstUsuarios = new List<Usuarios>();
            _Codigo = 0;
            _Mensaje = "OK";

            try
            {
                _Conexion.Open();

                //  Parámetros:
                //  Clave del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.String;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Cve_Usr";
                _Parametro1.Value = _usuarios.Cve_Usr;
                //  Contraseña del usuario
                SqlParameter _Parametro2 = new SqlParameter();
                _Parametro2.DbType = System.Data.DbType.String;
                _Parametro2.Direction = System.Data.ParameterDirection.Input;
                _Parametro2.ParameterName = "@Pas_Usr";
                _Parametro2.Value = _usuarios.Pas_Usr;
                //  Alias del cliente
                SqlParameter _Parametro3 = new SqlParameter();
                _Parametro3.DbType = System.Data.DbType.String;
                _Parametro3.Direction = System.Data.ParameterDirection.Input;
                _Parametro3.ParameterName = "@Ali_Usr";
                _Parametro3.Value = _usuarios.Ali_Cli;

                _Comando = new SqlCommand();
                _Comando.CommandType = System.Data.CommandType.StoredProcedure;
                _Comando.CommandText = "sp_Consulta_Usuario";  
                _Comando.Connection = _Conexion;
                _Comando.Parameters.Add(_Parametro1);
                _Comando.Parameters.Add(_Parametro2);
                _Comando.Parameters.Add(_Parametro3);
                _Resultado = _Comando.ExecuteReader();

                while (_Resultado.Read())
                {
                    Usuarios usuarios = new Usuarios();

                    usuarios.Ide_Usr = _Resultado.GetInt32(0);
                    usuarios.Cve_Usr = _Resultado.GetString(1);
                    usuarios.Ape_Pat = _Resultado.GetString(2);
                    usuarios.Ape_Mat = _Resultado.GetString(3);
                    usuarios.Nom_bre = _Resultado.GetString(4);
                    usuarios.Fec_Ing = _Resultado.GetDateTime(5);
                    usuarios.Fec_Vig = _Resultado.GetDateTime(6);
                    usuarios.Cor_reo = _Resultado.GetString(7);
                    usuarios.Rso_Cli = _Resultado.GetString(8);
                    usuarios.Cal_Cli = _Resultado.GetString(9);
                    usuarios.NEx_Cli = _Resultado.GetString(10);
                    usuarios.NIn_Cli = _Resultado.GetString(11);
                    usuarios.Col_Cli = _Resultado.GetString(12);
                    usuarios.Cop_Cli = _Resultado.GetString(13);
                    usuarios.Del_Cli = _Resultado.GetString(14);
                    usuarios.Ciu_Cli = _Resultado.GetString(15);
                    usuarios.Ico_Cli = _Resultado.GetString(16);

                    lstUsuarios.Add(usuarios);
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

            return lstUsuarios;
        }

        /// <summary>
        /// Consulta todos los usuarios registrados
        /// </summary>
        /// <param name="_Estatus">Criterio de estatus</param>
        /// <param name="_Nombre">Criterio de nombre</param>
        /// <param name="_APaterno">Criterio de apellido paterno</param>
        /// <param name="_AMaterno">Criterio de apellido materno</param>
        /// <param name="_Codigo">Código de error</param>
        /// <param name="_Mensaje">Mensaje de error</param>
        /// <returns>Listado de usuarios</returns>
        public List<Usuarios> consulta_Usuarios(int _Estatus, string _Nombre, string _APaterno, string _AMaterno, ref Int32 _Codigo, ref string _Mensaje)
        {
            Usuarios _oUsuario = new Usuarios();

            _Conexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            List<Usuarios> lstUsuarios = new List<Usuarios>();
            _Codigo = 0;
            _Mensaje = "OK";

            try
            {
                _Conexion.Open();

                //  Parámetros:
                //  Estatus del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.Int32;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Est_Usr";
                _Parametro1.Value = _Estatus;
                //  Nombre del usuario
                SqlParameter _Parametro2 = new SqlParameter();
                _Parametro2.DbType = System.Data.DbType.String;
                _Parametro2.Direction = System.Data.ParameterDirection.Input;
                _Parametro2.ParameterName = "@Nom_bre";
                _Parametro2.Value = _Nombre;
                //  Apellido Paterno del usuario
                SqlParameter _Parametro3 = new SqlParameter();
                _Parametro3.DbType = System.Data.DbType.String;
                _Parametro3.Direction = System.Data.ParameterDirection.Input;
                _Parametro3.ParameterName = "@Ape_Pat";
                _Parametro3.Value = _APaterno;
                //  Apellido Materno del usuario
                SqlParameter _Parametro4 = new SqlParameter();
                _Parametro4.DbType = System.Data.DbType.String;
                _Parametro4.Direction = System.Data.ParameterDirection.Input;
                _Parametro4.ParameterName = "@Ape_Mat";
                _Parametro4.Value = _AMaterno;

                _Comando = new SqlCommand();
                _Comando.CommandType = System.Data.CommandType.StoredProcedure;
                _Comando.CommandText = "sp_Consulta_Usuarios";
                _Comando.Connection = _Conexion;
                _Comando.Parameters.Add(_Parametro1);
                _Comando.Parameters.Add(_Parametro2);
                _Comando.Parameters.Add(_Parametro3);
                _Comando.Parameters.Add(_Parametro4);
                _Resultado = _Comando.ExecuteReader();

                while (_Resultado.Read())
                {
                    Usuarios usuarios = new Usuarios();

                    usuarios.Ide_Usr = _Resultado.GetInt32(0);
                    usuarios.Nom_bre = _Resultado.GetString(1);
                    usuarios.Ape_Pat = _Resultado.GetString(2);
                    usuarios.Ape_Mat = _Resultado.GetString(3);
                    usuarios.Cor_reo = _Resultado.GetString(4);
                    usuarios.Ide_Usr = _Resultado.GetInt32(5);

                    lstUsuarios.Add(usuarios);
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

            return lstUsuarios;
        }

        /// <summary>
        /// Alta del usuario en el sistema
        /// </summary>
        /// <param name="_usuarios">Clase usuario</param>
        /// <param name="_Codigo">Código de error</param>
        /// <param name="_Mensaje">Mensaje de error</param>
        /// <param name="_Contrasenia">Contraseña generada para el usuario</param>
        /// <returns>Verdadero o Falso</returns>
        public Boolean registra_Usuario(Usuarios _usuarios, ref Int32 _Codigo, ref string _Mensaje, ref string _Contrasenia)
        {
            Usuarios _oUsuario = new Usuarios();

            _Conexion.ConnectionString = _oUsuario.desencripta_Password(ConfigurationManager.AppSettings["Conexion"]);
            _Codigo = 0;
            _Mensaje = null;
            _Contrasenia = null;
            bool _Resultado; 

            try
            {
                _usuarios.Pas_Usr = _usuarios.genera_Pwd;
                _Contrasenia = _usuarios.Pas_Usr;

                _Conexion.Open();

                //  Parámetros:
                //  Clave del usuario
                SqlParameter _Parametro1 = new SqlParameter();
                _Parametro1.DbType = System.Data.DbType.String;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Cve_Usr";
                _Parametro1.Value = _usuarios.Cve_Usr;
                //  Contraseña del usuario
                SqlParameter _Parametro2 = new SqlParameter();
                _Parametro2.DbType = System.Data.DbType.String;
                _Parametro2.Direction = System.Data.ParameterDirection.Input;
                _Parametro2.ParameterName = "@Pas_Usr";
                _Parametro2.Value = _usuarios.encripta_Pwd;
                //  Apellido paterno
                SqlParameter _Parametro3 = new SqlParameter();
                _Parametro3.DbType = System.Data.DbType.String;
                _Parametro3.Direction = System.Data.ParameterDirection.Input;
                _Parametro3.ParameterName = "@Ape_Pat";
                _Parametro3.Value = _usuarios.Ape_Pat;
                //  Apellido materno
                SqlParameter _Parametro4 = new SqlParameter();
                _Parametro4.DbType = System.Data.DbType.String;
                _Parametro4.Direction = System.Data.ParameterDirection.Input;
                _Parametro4.ParameterName = "@Ape_Mat";
                _Parametro4.Value = _usuarios.Ape_Mat;
                //  Nombre
                SqlParameter _Parametro5 = new SqlParameter();
                _Parametro5.DbType = System.Data.DbType.String;
                _Parametro5.Direction = System.Data.ParameterDirection.Input;
                _Parametro5.ParameterName = "@Nom_bre";
                _Parametro5.Value = _usuarios.Nom_bre;
                //  Fecha de ingreso
                SqlParameter _Parametro6 = new SqlParameter();
                _Parametro6.DbType = System.Data.DbType.DateTime;
                _Parametro6.Direction = System.Data.ParameterDirection.Input;
                _Parametro6.ParameterName = "@Fec_Ing";
                _Parametro6.Value = _usuarios.Fec_Ing;
                //  Fecha de vigencia
                SqlParameter _Parametro7 = new SqlParameter();
                _Parametro7.DbType = System.Data.DbType.DateTime;
                _Parametro7.Direction = System.Data.ParameterDirection.Input;
                _Parametro7.ParameterName = "@Fec_Vig";
                _Parametro7.Value = _usuarios.Fec_Vig;
                //  Correo electrónico
                SqlParameter _Parametro8 = new SqlParameter();
                _Parametro8.DbType = System.Data.DbType.String;
                _Parametro8.Direction = System.Data.ParameterDirection.Input;
                _Parametro8.ParameterName = "@Cor_reo";
                _Parametro8.Value = _usuarios.Cor_reo;
                //  Clave del cliente
                SqlParameter _Parametro9 = new SqlParameter();
                _Parametro9.DbType = System.Data.DbType.String;
                _Parametro9.Direction = System.Data.ParameterDirection.Input;
                _Parametro9.ParameterName = "@Ali_Cli";
                _Parametro9.Value = _usuarios.Ali_Cli;
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

                _Comando = new SqlCommand();
                _Comando.CommandType = System.Data.CommandType.StoredProcedure;
                _Comando.CommandText = "sp_Registra_Usuario";
                _Comando.Connection = _Conexion;
                _Comando.Parameters.Add(_Parametro1);
                _Comando.Parameters.Add(_Parametro2);
                _Comando.Parameters.Add(_Parametro3);
                _Comando.Parameters.Add(_Parametro4);
                _Comando.Parameters.Add(_Parametro5);
                _Comando.Parameters.Add(_Parametro6);
                _Comando.Parameters.Add(_Parametro7);
                _Comando.Parameters.Add(_Parametro8);
                _Comando.Parameters.Add(_Parametro9);
                _Comando.Parameters.Add(_Parametro10);
                _Comando.Parameters.Add(_Parametro11);
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
        /// Revisa si el usuario existe en el sistema
        /// </summary>
        /// <param name="_usuarios">Clase usuario</param>
        /// <param name="_Codigo">Código de error</param>
        /// <param name="_Mensaje">Mensaje de error</param>
        /// <returns>Verdadero o Falso</returns>
        public Boolean existe_Usuario(Usuarios _usuarios, ref Int32 _Codigo, ref string _Mensaje)
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
                _Parametro1.DbType = System.Data.DbType.String;
                _Parametro1.Direction = System.Data.ParameterDirection.Input;
                _Parametro1.ParameterName = "@Cve_Usr";
                _Parametro1.Value = _usuarios.Cve_Usr;
                //  Contraseña del usuario
                SqlParameter _Parametro2 = new SqlParameter();
                _Parametro2.DbType = System.Data.DbType.String;
                _Parametro2.Direction = System.Data.ParameterDirection.Input;
                _Parametro2.ParameterName = "@Pas_Usr";
                _Parametro2.Value = _usuarios.Pas_Usr;
                //  Alias del cliente
                SqlParameter _Parametro3 = new SqlParameter();
                _Parametro3.DbType = System.Data.DbType.String;
                _Parametro3.Direction = System.Data.ParameterDirection.Input;
                _Parametro3.ParameterName = "@Ali_Cli";
                _Parametro3.Value = _usuarios.Ali_Cli;
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

                _Comando = new SqlCommand();
                _Comando.CommandType = System.Data.CommandType.StoredProcedure;
                _Comando.CommandText = "sp_Existe_Usuario";
                _Comando.Connection = _Conexion;
                _Comando.Parameters.Add(_Parametro1);
                _Comando.Parameters.Add(_Parametro2);
                _Comando.Parameters.Add(_Parametro3);
                _Comando.Parameters.Add(_Parametro4);
                _Comando.Parameters.Add(_Parametro5);

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
                _Mensaje = Error.ErrorCode.ToString() + ": " + Error.Message;
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
        /// Consulta los usuarios del archivo de Excel
        /// </summary>
        /// <param name="_ubicaarchivo">Ubicación y nombre del archivo de Excel</param>
        /// <param name="_Estatus">Resultado de la consulta</param>
        /// <returns>Listado de usuarios</returns>
        public List<Usuarios> listado_Excel(string _ubicaarchivo, ref string _Estatus)
        {
            String _ConexionExcel = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _ubicaarchivo.Trim() + ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
            List<Usuarios> lstUsuarios = new List<Usuarios>();
            _Estatus = null;

            try
            {
                OleDbConnection _Conexion = new OleDbConnection(_ConexionExcel);
                _Conexion.Open();

                OleDbCommand _Comando = new OleDbCommand("SELECT [Clave_Usuario], [Contraseña_Usuario], [Apellido_Paterno], [Apellido_Materno], [Nombre], [Correo_Electrónico] FROM [Template Usuarios$]", _Conexion);
                OleDbDataReader _Resultado = _Comando.ExecuteReader();

                while (_Resultado.Read())
                {
                    Usuarios usuarios = new Usuarios();
                    
                    usuarios.Cve_Usr = _Resultado.IsDBNull(0) ? String.Empty: _Resultado.GetString(0);
                    usuarios.Pas_Usr = _Resultado.IsDBNull(1) ? String.Empty: _Resultado.GetString(1);
                    usuarios.Ape_Pat = _Resultado.IsDBNull(2) ? String.Empty: _Resultado.GetString(2);
                    usuarios.Ape_Mat = _Resultado.IsDBNull(3) ? String.Empty: _Resultado.GetString(3);
                    usuarios.Nom_bre = _Resultado.IsDBNull(4) ? String.Empty: _Resultado.GetString(4);
                    usuarios.Cor_reo = _Resultado.IsDBNull(5) ? String.Empty: _Resultado.GetString(5);

                    lstUsuarios.Add(usuarios);
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

            return lstUsuarios;
        }
        #endregion
    }
}
