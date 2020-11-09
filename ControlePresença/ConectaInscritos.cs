using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace ControlePresença
{
    class ConectaInscritos
    {

        public MySqlConnection conexao;

        public string Endereco()
        {
            StringConexao str = new StringConexao();
            return str.Endereco();
        }

        public void cadastro(Inscritos ins)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "INSERT INTO inscritos(nome, dtNasc, endereco, telefone, cidade, cep, sexo, escalada)VALUES('" + ins.Nome + "','" + Convert.ToDateTime(ins.DtNascimento).ToString("yyyy-MM-dd") + "','" + ins.Endereco + "','" + ins.Telefone + "','" + ins.Cidade + "','" + ins.Cep + "','" + ins.Sexo + "','" + ins.Escalada + "')";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable sorteioMeninas()
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string selecionar = "SELECT nome, dtNasc, endereco, telefone, cidade, cep, sexo, escalada FROM inscritos";
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
