using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlePresença
{
    class Ano
    {
        private int nCod;
        private string dtInicio;
        private string nAno;
        private string nGer;
        private string ndtGer;

        public int Codigo
        {
            get { return nCod; }
            set { nCod = value; }
        }

        public string TotalPresenca
        {
            get { return dtInicio; }
            set { dtInicio = value; }
        }

        public string An
        {
            get { return nAno; }
            set { nAno = value; }
        }

        public string Gerado
        {
            get { return nGer; }
            set { nGer = value; }
        }

        public string DataGerado
        {
            get { return ndtGer; }
            set { ndtGer = value; }
        }
    }
}
