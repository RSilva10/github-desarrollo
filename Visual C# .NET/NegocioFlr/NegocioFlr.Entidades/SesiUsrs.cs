using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegocioFlr.Entidades
{
    public class SesiUsrs
    {
        #region Variables
        private int _Ide_Usr;
        private string _Ide_Ses;
        private DateTime _Fec_Ses;
        #endregion

        #region Propiedades
        public int Ide_Usr
        {
            get { return _Ide_Usr; }
            set { _Ide_Usr = value; }
        }

        public String Ide_Ses
        {
            get { return _Ide_Ses; }
            set { _Ide_Ses = value; }
        }

        public DateTime Fec_Ses
        {
            get { return _Fec_Ses; }
            set { _Fec_Ses = value; }
        }
        #endregion
    }
}
