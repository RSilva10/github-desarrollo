using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NegocioFlr.Entidades
{
    public class ErrExcel
    {
        #region Variables
        private int _Num_Lin;
        private string _Nom_Cam;
        private string _Des_Err;
        #endregion

        #region Propiedades
        public int Num_Lin
        {
            get { return _Num_Lin; }
            set { _Num_Lin = value; }
        }

        public String Nom_Cam
        {
            get { return _Nom_Cam; }
            set { _Nom_Cam = value; }
        }

        public String Des_Err
        {
            get { return _Des_Err; }
            set { _Des_Err = value; }
        }
        #endregion
    }
}
