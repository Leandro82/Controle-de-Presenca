using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlePresença
{
    class Cracha
    {
        private int nCod;
        private string nNome;
        private string nEq;
        private string esc;

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

        public string Grupo
        {
            get { return nEq; }
            set { nEq = value; }
        }

        public string Escalada
        {
            get { return esc; }
            set { esc = value; }
        }
    }
}
