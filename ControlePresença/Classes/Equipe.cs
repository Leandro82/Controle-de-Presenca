using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlePresença
{
    class Equipe
    {
        private int nCod;
        private int nCodPres;
        private string nNome;
        private string nDtNasc;
        private string end;
        private string tel;
        private string cid;
        private string cp;
        private string nEq;
        private string nEsc;
        private string nCad;
        private string nEnv;

        public int Codigo
        {
            get { return nCod; }
            set { nCod = value; }
        }

        public int CodigoPresenca
        {
            get { return nCodPres; }
            set { nCodPres = value; }
        }

        public string Nome
        {
            get { return nNome; }
            set { nNome = value; }
        }

        public string Nascimento
        {
            get { return nDtNasc; }
            set { nDtNasc = value; }
        }

        public string Endereco
        {
            get { return end; }
            set { end = value; }
        }

        public string Telefone
        {
            get { return tel; }
            set { tel = value; }
        }

        public string Cidade
        {
            get { return cid; }
            set { cid = value; }
        }

        public string Cep
        {
            get { return cp; }
            set { cp = value; }
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

        public string NaoCadastrado
        {
            get { return nCad; }
            set { nCad = value; }
        }

        public string Envelope
        {
            get { return nEnv; }
            set { nEnv = value; }
        }
    }
}
