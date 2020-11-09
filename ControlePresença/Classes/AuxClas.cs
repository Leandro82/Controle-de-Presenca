using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlePresença
{
    class AuxClas
    {
        private static string dta;

        public static string Data
        {
            get { return dta; }
            set { dta = value; }
        }

        private static string plt;

        public static string Palestrante
        {
            get { return plt; }
            set { plt = value; }
        }

        private static string obs;

        public static string Observacao
        {
            get { return obs; }
            set { obs = value; }
        }
    }
}
