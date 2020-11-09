using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlePresença
{
    class Variavel
    {
        private int nCod;
        private int nAno;
        private string nNome;
        private string nPal;
        private string nObs;
        private DateTime nData;
        private string nDt;
        private string nPres;
        private string nDtCad;
        private string nOp;
        private string nCam;
        private string nArq;

        public int Codigo
        {
            get { return nCod; }
            set { nCod = value; }
        }

        public int Ano
        {
            get { return nAno; }
            set { nAno = value; }
        }

        public string Nome
        {
            get { return nNome; }
            set { nNome = value; }
        }

        public string Palestrante
        {
            get { return nPal; }
            set { nPal = value; }
        }

        public string Observacao
        {
            get { return nObs; }
            set { nObs = value; }
        }

        public DateTime Data
        {
            get { return nData; }
            set { nData = value; }
        }

        public string Presenca
        {
            get { return nPres; }
            set { nPres = value; }
        }

        public string DtCadastro
        {
            get { return nDtCad; }
            set { nDtCad = value; }
        }

        public string Opcao
        {
            get { return nOp; }
            set { nOp = value; }
        }

        public string Corrigir
        {
            get { return nDt; }
            set { nDt = value; }
        }

        public string Caminho
        {
            get { return nCam; }
            set { nCam = value; }
        }

        public string Arquivo
        {
            get { return nArq; }
            set { nArq = value; }
        }
    }
}
