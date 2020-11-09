using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace ControlePresença
{
    class ConectaUsuario
    {
        public MySqlConnection conexao;

        public string Endereco()
        {
            StringConexao str = new StringConexao();
            return str.Endereco();
        }
        //string caminho = "Persist Security Info=false;SERVER=127.0.0.1;DATABASE=escalada;UID=root;pwd=";

        public void altera(Usuario us)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string alterar = "UPDATE usuario SET senha='" + us.Senha + "' , login = '" + us.Login + "'WHERE nome = '" + us.Nome + "'";
                MySqlCommand comandos = new MySqlCommand(alterar, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void cadastro(Usuario us)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "INSERT INTO usuario(nome, login, senha)VALUES('" + us.Nome + "','" + us.Login + "','" + us.Senha + "')";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }


        public void excluir(Usuario us)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string excluir = "DELETE FROM usuario WHERE nome = '" + us.Nome + "'";
                MySqlCommand comandos = new MySqlCommand(excluir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable PesquisaNome(Usuario us)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string selecionar = "SELECT cod, nome FROM presenca WHERE nome LIKE '%" + us.Nome + "%'";
                MySqlDataAdapter comandos = new MySqlDataAdapter(selecionar, conexao);
                DataTable dt = new System.Data.DataTable();
                comandos.Fill(dt);
                conexao.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void cadastrarDigital(Usuario us)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string cadastrar = "UPDATE presenca SET digital = '" + us.Template + "'WHERE cod = '" + us.Codigo + "'";
                MySqlCommand comandos = new MySqlCommand(cadastrar, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable Usuario()
        {
            conexao = new MySqlConnection(Endereco());
            conexao.Open();
            string vSQL = "Select * FROM presenca";
            MySqlDataAdapter vDataAdapter = new MySqlDataAdapter(vSQL, conexao);
            DataTable vTable = new DataTable();
            vDataAdapter.Fill(vTable);
            conexao.Close();
            return vTable;
        }

        public DataTable UsuarioPorc()
        {
            conexao = new MySqlConnection(Endereco());
            conexao.Open();
            string vSQL = "Select * FROM presenca ORDER BY nome";
            MySqlDataAdapter vDataAdapter = new MySqlDataAdapter(vSQL, conexao);
            DataTable vTable = new DataTable();
            vDataAdapter.Fill(vTable);
            conexao.Close();
            return vTable;
        }

        public DataTable usuarioLogin()
        {
            conexao = new MySqlConnection(Endereco());
            conexao.Open();
            string vSQL = "Select * FROM usuario";
            MySqlDataAdapter vDataAdapter = new MySqlDataAdapter(vSQL, conexao);
            DataTable vTable = new DataTable();
            vDataAdapter.Fill(vTable);
            conexao.Close();
            return vTable;
        }

        public DataTable buscaUsuario()
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string selecionar = "SELECT nome, login FROM usuario ORDER BY nome";
                MySqlDataAdapter comandos = new MySqlDataAdapter(selecionar, conexao);
                DataTable dt = new System.Data.DataTable();
                comandos.Fill(dt);
                conexao.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }
    }
}
