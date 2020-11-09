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

        public void apagaDados()
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "TRUNCATE inscritos";
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
                string selecionar = "SELECT cod, nome,  DATE_FORMAT(dtNasc, '%d/%m/%Y') AS dtNasc, endereco, telefone, cidade, cep, sexo, escalada FROM inscritos ORDER BY nome";
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

        public void alteraInscritos(Inscritos ins)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "UPDATE inscritos SET nome= '" + ins.Nome + "', dtNasc= '" + Convert.ToDateTime(ins.DtNascimento).ToString("yyyy-MM-dd") + "', endereco='"+ins.Endereco+"', telefone='"+ins.Telefone+"', cidade='"+ins.Cidade+"', cep='"+ins.Cep+"'WHERE cod= '" + ins.Codigo + "'";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void alteraInscritosPosSorteio(Inscritos ins, Equipe eq)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "UPDATE inscritos SET nome= '" + ins.Nome + "', dtNasc= '" + Convert.ToDateTime(ins.DtNascimento).ToString("yyyy-MM-dd") + "', endereco='" + ins.Endereco + "', telefone='" + ins.Telefone + "', cidade='" + ins.Cidade + "', cep='" + ins.Cep + "'WHERE nome= '" + eq.Nome + "' AND endereco='"+eq.Endereco+"' AND telefone='"+eq.Telefone+"'";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void cadastroSorteados(Inscritos ins)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "INSERT INTO sorteados(nome, dtNasc, endereco, telefone, cidade, cep, sexo, escalada)VALUES('" + ins.Nome + "','" + Convert.ToDateTime(ins.DtNascimento).ToString("yyyy-MM-dd") + "','" + ins.Endereco + "','" + ins.Telefone + "','" + ins.Cidade + "','" + ins.Cep + "','" + ins.Sexo + "','" + ins.Escalada + "')";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void excluirSorteados(Inscritos ins)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string excluir = "DELETE FROM sorteados WHERE nome = '" + ins.Nome + "' AND endereco='" + ins.Endereco + "'";
                MySqlCommand comando = new MySqlCommand(excluir, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable sorteados(Inscritos ins)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string selecionar = "SELECT cod, nome,  DATE_FORMAT(dtNasc, '%d-%m-%Y') AS dtNasc, endereco, telefone, cidade, cep, sexo, escalada, grupo FROM sorteados WHERE escalada='" + ins.Escalada + "'ORDER BY nome";
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

        public DataTable verificaSorteados(Inscritos ins)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string selecionar = "SELECT cod, nome, endereco FROM sorteados WHERE nome= '" + ins.Nome + "' AND endereco='" + ins.Endereco + "' AND escalada='" + ins.Escalada + "'";
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

        public DataTable montarEquipe(Equipe eq)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string selecionar = "SELECT nome, dtNasc, endereco, telefone, cidade, cep FROM presenca UNION SELECT nome, dtNasc, endereco, telefone, cidade, cep FROM equipe WHERE escalada='" + eq.Escalada + "' AND ncad='Ok'ORDER BY nome";
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

        public void CadastraGrupo(Inscritos ins)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "UPDATE sorteados SET nome= '" + ins.Nome + "', grupo= '" + ins.Grupo + "'WHERE cod= '" + ins.Codigo + "'";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable abreviaNomes(Inscritos ins)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string selecionar = "SELECT cod, nome, grupo, escalada FROM sorteados WHERE escalada= '" + ins.Escalada + "' ORDER BY grupo";
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

        public void alteraDadosNovos(Inscritos ins)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "UPDATE sorteados SET nome= '" + ins.Nome + "', dtNasc= '" + Convert.ToDateTime(ins.DtNascimento).ToString("yyyy-MM-dd") + "', endereco='" + ins.Endereco + "', telefone='" + ins.Telefone + "', cidade='" + ins.Cidade + "', cep='" + ins.Cep + "'WHERE cod= '" + ins.Codigo + "'";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void AbreEnvelopeNovos(Inscritos ic)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string alterar = "UPDATE sorteados SET envelope=''WHERE escalada='"+ic.Escalada+"'";
                MySqlCommand comandos = new MySqlCommand(alterar, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void SelecionaTodosNovos(Inscritos ic)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string alterar = "UPDATE sorteados SET envelope='Sim' WHERE escalada='"+ic.Escalada+"'";
                MySqlCommand comandos = new MySqlCommand(alterar, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void EnvelopeNovos(Equipe eq)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string alterar = "UPDATE sorteados SET envelope='" + eq.Envelope + "' WHERE cod = '" + eq.Codigo + "'";
                MySqlCommand comandos = new MySqlCommand(alterar, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable SelecionaNovosEnvelope(Inscritos ins)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string selecionar = "SELECT cod, nome, grupo FROM sorteados WHERE escalada='" + ins.Escalada + "'ORDER BY grupo, nome";
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
