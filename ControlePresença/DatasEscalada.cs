using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlePresença
{
    class DatasEscalada
    {
        private int nEsc;
        private string nPriNovos;
        private string nSegNovos;
        private string nTerNovos;
        private string nPriPais;
        private string nSegPais;
        private string nCam;
        private string nDtEsc;

        public int Escalada
        {
            get { return nEsc; }
            set { nEsc = value; }
        }

        public string PrimeiraNovos
        {
            get { return nPriNovos; }
            set { nPriNovos = value; }
        }

        public string SegundaNovos
        {
            get { return nSegNovos; }
            set { nSegNovos = value; }
        }

        public string TerceiraNovos
        {
            get { return nTerNovos; }
            set { nTerNovos = value; }
        }

        public string PrimeiraPais
        {
            get { return nPriPais; }
            set { nPriPais = value; }
        }

        public string SegundaPais
        {
            get { return nSegPais; }
            set { nSegPais = value; }
        }

        public string Caminhada
        {
            get { return nCam; }
            set { nCam = value; }
        }

        public string DataEscalada
        {
            get { return nDtEsc; }
            set { nDtEsc = value; }
        }
    }
}
