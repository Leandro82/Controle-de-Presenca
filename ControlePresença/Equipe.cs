using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlePresença
{
    class Equipe
    {
        private int nCod;
        private string nNome;
        private string nEq;
        private string nEsc;

        public int Codigo
        {
            get { return nCod; }
            set { nCod = value; }
        }

        public string Nome
        {
            get { return nNome; }
            set { nNome = value; }
        }

        public string Funcao
        {
            get { return nEq; }
            set { nEq = value; }
        }

        public string Escalada
        {
            get { return nEsc; }
            set { nEsc = value; }
        }
    }
}
