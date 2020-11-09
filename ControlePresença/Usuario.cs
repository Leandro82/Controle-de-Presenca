using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlePresença
{
    class Usuario
    {
        private int nCod;
        private string nNome;
        private string nLogin;
        private string nSenha;
        private String nTemp;

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

        public string Login
        {
            get { return nLogin; }
            set { nLogin = value; }
        }

        public string Senha
        {
            get { return nSenha; }
            set { nSenha = value; }
        }

        public String Template
        {
            get { return nTemp; }
            set { nTemp = value; }
        }
    }
}
