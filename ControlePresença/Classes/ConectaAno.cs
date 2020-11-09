using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace ControlePresença
{
    class ConectaAno
    {
        public MySqlConnection conexao;

        public string Endereco()
        {
            StringConexao str = new StringConexao();
            return str.Endereco();
        }

        public void Alterar(Ano an)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "UPDATE ano SET dtgerado= '" + an.DataGerado + "', gerado='" + an.Gerado + "' WHERE COD=1";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void AlteraAno(Ano an)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "UPDATE ano SET ano= '" + an.An + "', dtinicio='01/01/" + an.An + "', dtgerado='01/01/" + an.An + "', gerado='' WHERE COD=1";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void ZeraEleicao()
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string zerar = "truncate eleicao";
                MySqlCommand comandos = new MySqlCommand(zerar, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable Ano()
        {
            string vSQL = "Select ano, dtgerado, gerado FROM ano";
            MySqlDataAdapter vDataAdapter = new MySqlDataAdapter(vSQL, Endereco());
            DataTable vTable = new DataTable();
            vDataAdapter.Fill(vTable);
            return vTable;
        }
    }    
}
