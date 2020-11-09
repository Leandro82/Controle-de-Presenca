using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlePresença
{
    class Inscritos
    {
        private int nCod;
        private string nNome;
        private string nDtNasc;
        private string nEnd;
        private string nTel;
        private string nCid;
        private string nCep;
        private string nSexo;
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

        public string DtNascimento
        {
            get { return nDtNasc; }
            set { nDtNasc = value; }
        }

        public string Endereco
        {
            get { return nEnd; }
            set { nEnd = value; }
        }

        public string Telefone
        {
            get { return nTel; }
            set { nTel = value; }
        }

        public string Cidade
        {
            get { return nCid; }
            set { nCid = value; }
        }

        public string Cep
        {
            get { return nCep; }
            set { nCep = value; }
        }

        public string Sexo
        {
            get { return nSexo; }
            set { nSexo = value; }
        }

        public string Escalada
        {
            get { return nEsc; }
            set { nEsc = value; }
        }
    }
}
