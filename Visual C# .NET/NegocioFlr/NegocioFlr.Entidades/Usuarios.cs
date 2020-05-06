using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegocioFlr.Entidades
{
    public class Usuarios
    {
        #region Variables
        public enum Operacion : byte { Consulta = 0, Alta, Modificacion };

        private byte _Ope_Rac;
        private int _Ide_Usr;
        private string _Cve_Usr;
        private string _Pas_Usr;
        private string _Ape_Pat;
        private string _Ape_Mat;
        private string _Nom_bre;
        private DateTime _Fec_Ing;
        private DateTime _Fec_Vig;
        private string _Cor_reo;
        #endregion

        #region Propiedades
        public byte Ope_Rac
        {
            get { return _Ope_Rac; }
            set { _Ope_Rac = value; }
        }

        public int Ide_Usr
        {
            get { return _Ide_Usr; }
            set { _Ide_Usr = value; }
        }

        public String Cve_Usr
        {
            get { return _Cve_Usr; }
            set { _Cve_Usr = value; }
        }

        public String Pas_Usr
        {
            get { return _Pas_Usr; }
            set
            {
                if (_Ope_Rac == Convert.ToByte(Operacion.Alta) || _Ope_Rac == Convert.ToByte(Operacion.Modificacion))
                {
                    _Pas_Usr = asigna_Contrasenia();
                }
                else
                {
                    _Pas_Usr = value;
                }
            }
        }

        public String Ape_Pat
        {
            get { return _Ape_Pat; }
            set { _Ape_Pat = value; }
        }

        public String Ape_Mat
        {
            get { return _Ape_Mat; }
            set { _Ape_Mat = value; }
        }

        public String Nom_bre
        {
            get { return _Nom_bre; }
            set { _Nom_bre = value; }
        }

        public DateTime Fec_Ing
        {
            get { return _Fec_Ing; }
            set
            {
                if (_Ope_Rac == Convert.ToByte(Operacion.Alta) || _Ope_Rac == Convert.ToByte(Operacion.Modificacion))
                {
                    _Fec_Ing = asigna_Ingreso();
                }
                else
                {
                    _Fec_Ing = value;
                }
            }
        }

        public DateTime Fec_Vig
        {
            get { return _Fec_Vig; }
            set
            {
                if (_Ope_Rac == Convert.ToByte(Operacion.Alta) || _Ope_Rac == Convert.ToByte(Operacion.Modificacion))
                {
                    _Fec_Vig = asigna_Vigencia();
                }
                else
                {
                    _Fec_Vig = value;
                }
            }
        }

        public String Cor_reo
        {
            get { return _Cor_reo; }
            set { _Cor_reo = value; }
        }

        public String encripta_Pwd
        {
            get
            {
                return encripta_Password(_Pas_Usr); 
            } 
        }

        public String desencripta_Pwd
        {
            get
            {
                return desencripta_Password(_Pas_Usr); 
            }
        }

        public String genera_Pwd
        {
            get
            {
                return asigna_Contrasenia(); 
            }
        } 
        #endregion

        #region Métodos
        /// <summary>
        /// Crea una contraseña utilizando los apellidos, nombre del usuario y un número aleatorio
        /// </summary>
        /// <returns>Contraseña generada</returns>
        private String asigna_Contrasenia()
        {
            Random rnd = new Random();
            string _Resultado = string.Empty;

            _Resultado = _Ape_Pat.Substring(0, 2) + _Ape_Mat.Substring(0, 2) + _Nom_bre.Substring(0, 2);

            for (int indice = 1; indice <= 10; indice++)
            {
                _Resultado += rnd.Next(10, 90).ToString();
            }

            if (_Resultado.Length > 10)
            {
                _Resultado = _Resultado.Substring(0, 10);
            }

            return _Resultado;
        }

        /// <summary>
        /// Crea la fecha de ingreso del usuario al sistema
        /// </summary>
        /// <returns>Fecha del sistema actual</returns>
        private DateTime asigna_Ingreso()
        {
            DateTime _Hoy = DateTime.Today;

            return _Hoy;
        }

        /// <summary>
        /// Crea la fecha de vigencia del usuario al sistema
        /// </summary>
        /// <returns>Fecha de vigencia</returns>
        private DateTime asigna_Vigencia()
        {
            DateTime _Hoy = DateTime.Today;

            return _Hoy.AddDays(30);
        }

        /// <summary>
        /// Encripta la contraseña del usuario 
        /// </summary>
        /// <returns></returns>
        private String encripta_Password(string _pasword)
        {
            string _Resultado = string.Empty;

            byte[] _Encriptado = Encoding.Unicode.GetBytes(_pasword);
            _Resultado = Convert.ToBase64String(_Encriptado);

            return _Resultado;
        }

        /// <summary>
        /// Desencripta la contraseña del usuario 
        /// </summary>
        /// <returns></returns>
        private String desencripta_Password(string _pasword)
        {
            string _Resultado = string.Empty;

            byte[] _Desencriptado = Convert.FromBase64String(_pasword);
            _Resultado = Encoding.Unicode.GetString(_Desencriptado);

            return _Resultado;
        }
        #endregion
    }
}
