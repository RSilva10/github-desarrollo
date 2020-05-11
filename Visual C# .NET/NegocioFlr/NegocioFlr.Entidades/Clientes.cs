using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegocioFlr.Entidades
{
    public class Clientes
    {
		#region Variables
		private string _Rso_Cli;
		private string _Cal_Cli;
		private string _NEx_Cli;
		private string _NIn_Cli;
		private string _Col_Cli;
		private string _Cop_Cli;
		private string _Del_Cli;
		private string _Ciu_Cli;
		private string _Ali_Cli;
        #endregion

        #region Propiedades
        public String Rso_Cli
        {
            get { return _Rso_Cli; }
            set { _Rso_Cli = value; }
        }

        public String Cal_Cli
        {
            get { return _Cal_Cli; }
            set { _Cal_Cli = value; }
        }

        public String NEx_Cli
        {
            get { return _NEx_Cli; }
            set { _NEx_Cli = value; }
        }

        public String NIn_Cli
        {
            get { return _NIn_Cli; }
            set { _NIn_Cli = value; }
        }

        public String Col_Cli
        {
            get { return _Col_Cli; }
            set { _Col_Cli = value; }
        }

        public String Cop_Cli
        {
            get { return _Cop_Cli; }
            set { _Cop_Cli = value; }
        }

        public String Del_Cli
        {
            get { return _Del_Cli; }
            set { _Del_Cli = value; }
        }

        public String Ciu_Cli
        {
            get { return _Ciu_Cli; }
            set { _Ciu_Cli = value; }
        }

        public String Ali_Cli
        {
            get { return _Ali_Cli; }
            set { _Ali_Cli = value; }
        }
        #endregion
    }
}
