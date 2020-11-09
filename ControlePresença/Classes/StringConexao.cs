using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlePresença
{
    class StringConexao
    {
        string caminho;

        public string Endereco()
        {
            caminho = "Persist Security Info=false;SERVER=localhost;DATABASE=escalada;UID=root;pwd=;Allow User Variables=True;Convert Zero Datetime=True;Allow Zero DateTime=true;default command timeout=0";
            return caminho;
        }
    }
}
