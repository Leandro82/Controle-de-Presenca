using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace ControlePresença
{
    class ConectaEleicao
    {   
        public MySqlConnection conexao;

        public string Endereco()
        {
            StringConexao str = new StringConexao();
            return str.Endereco();
        }

        public void cadastro(Eleicao el)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "INSERT INTO eleicao(cod, nome, t_presenca, t_reuniao)VALUES('" + el.Codigo + "','" + el.Nome + "','" + el.TotalPresenca + "','" + el.TotalReuniao + "')";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable PesquisaAlpinista(Eleicao el)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "SELECT COD FROM ELEICAO WHERE COD='" + el.Codigo + "'";
                MySqlDataAdapter comandos = new MySqlDataAdapter(inserir, conexao);
                DataTable vTable = new DataTable();
                comandos.Fill(vTable);
                conexao.Close();
                return vTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable SelecionaDados(Eleicao el)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "SELECT COD, NOME, T_PRESENCA, T_REUNIAO FROM ELEICAO WHERE COD='" + el.Codigo + "'";
                MySqlDataAdapter comandos = new MySqlDataAdapter(inserir, conexao);
                DataTable vTable = new DataTable();
                comandos.Fill(vTable);
                conexao.Close();
                return vTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void AtualizaPorcentagem(Eleicao el)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string atualizar = "UPDATE eleicao SET t_presenca= '" + el.TotalPresenca + "', t_reuniao='" + el.TotalReuniao + "' WHERE COD='" + el.Codigo + "'";
                MySqlCommand comandos = new MySqlCommand(atualizar, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable Dados()
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "SELECT * FROM ELEICAO";
                MySqlDataAdapter comandos = new MySqlDataAdapter(inserir, conexao);
                DataTable vTable = new DataTable();
                comandos.Fill(vTable);
                conexao.Close();
                return vTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }
    }    
}
