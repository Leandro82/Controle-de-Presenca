using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlePresença
{
    class Eleicao
    {
        private int nCod;
        private int tPres;
        private string nNome;
        private int tReun;

        public int Codigo
        {
            get { return nCod; }
            set { nCod = value; }
        }

        public int TotalPresenca
        {
            get { return tPres; }
            set { tPres = value; }
        }

        public int TotalReuniao
        {
            get { return tReun; }
            set { tReun = value; }
        }

        public string Nome
        {
            get { return nNome; }
            set { nNome = value; }
        }
    }
}
