using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace ControlePresença
{
    class Conecta
    {
        public MySqlConnection conexao;

        public string Endereco()
        {
            StringConexao str = new StringConexao();
            return str.Endereco();
        }

        //string caminho = "Persist Security Info=false;SERVER=127.0.0.1;DATABASE=escalada;UID=root;pwd=";
        public void cadastro(Variavel va)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "INSERT INTO presenca(nome, dtCad)VALUES('" + va.Nome + "','"+va.DtCadastro+"')";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void cadastroNovos(Inscritos ins)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "INSERT INTO presenca(nome, dtCad, dtNasc, endereco, telefone, cidade, cep)VALUES('" + ins.Nome + "','" + ins.DtCadastro + "','"+Convert.ToDateTime(ins.DtNascimento).ToString("yyyy-MM-dd")+"','"+ins.Endereco+"','"+ins.Telefone+"','"+ins.Cidade+"','"+ins.Cep+"')";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void cadastroDigital(Usuario us)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "INSERT INTO presenca(digital)VALUES('" + us.Nome + "','" + us.Login + "','" + us.Senha + "')";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void verificaDigital(Variavel va)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "UPDATE presenca SET " + va.Data + " = '" + va.Presenca + "'WHERE cod= '" + va.Codigo + "'";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void alteraDadosAlp(Variavel va)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "UPDATE presenca SET nome = '" + va.Nome + "', dtCad='" + Convert.ToDateTime(va.DtCadastro).ToString("yyyy-MM-dd") + "' WHERE cod= '" + va.Codigo + "'";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }


        //------- CAMPOS PARA CADASTRO E BUSCA DE DATAS DE REUNIÕES --------
        public void CadastrarData(Variavel va)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "Alter TABLE presenca ADD data" + Convert.ToDateTime(va.Data).ToString("ddMMyyyy") + " varchar(20)";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();

                string data = "INSERT INTO datas(data, palestrante, observacao)VALUES('" + Convert.ToDateTime(va.Data).ToString("yyyy-MM-dd") + "','" + va.Palestrante + "','" + va.Observacao + "')";
                MySqlCommand comando = new MySqlCommand(data, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }   
        }

        public void DeletarData(Variavel va)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "Alter TABLE presenca DROP data" + Convert.ToString(Convert.ToDateTime(va.Data).ToString("ddMMyyyy")) + "";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();

                string data = "DELETE FROM datas WHERE data = '" + Convert.ToDateTime(va.Data).ToString("yyyy-MM-dd") + "'";
                MySqlCommand comando = new MySqlCommand(data, conexao);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable CarregaDatas()
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string selecionar = "SELECT * FROM datas order by data";
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
        //-------------------------------------------------------------------------

        public MySqlDataReader Chamada()
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string chamada = "SELECT cod, digital FROM presenca";
                MySqlCommand comandos = new MySqlCommand(chamada, conexao);
                MySqlDataReader rdr = comandos.ExecuteReader();
                return rdr;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable Alpinistas(Variavel va)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string buscar = "SELECT cod, nome, dtCad FROM presenca where nome LIKE '%" + va.Nome + "%' ORDER BY nome";
                MySqlDataAdapter comandos = new MySqlDataAdapter(buscar, conexao);
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

        public void Presenca(Variavel va)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "UPDATE presenca SET " + va.Corrigir + " = '" + va.Presenca + "'WHERE cod= '" + va.Codigo + "'";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public String Alpinista(Variavel va)
        {
            string nome;
            conexao = new MySqlConnection(Endereco());
            conexao.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("Select nome from presenca WHERE cod= '" + va.Codigo + "'",conexao);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            nome = dt.Rows[0][0].ToString();
            conexao.Close();
            return nome;
        }

        public String VerificaPresenca(Variavel va)
        {
            string pres;
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("Select " + va.Corrigir + " from presenca WHERE cod= '" + va.Codigo + "'", conexao);
                DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);
                pres = dt.Rows[0][0].ToString();
                conexao.Close();
                return pres;
            }
            catch (Exception)
            {
                conexao.Close();
                string msg = "ok";
                return msg;
            }
        }

        public void presencaporPessoa(Variavel va)
        {
            try
            {
                if (va.Opcao == "P")
                {
                    conexao = new MySqlConnection(Endereco());
                    conexao.Open();
                    string inserir = "UPDATE presenca SET " + va.Corrigir + " = '" + va.Presenca + "'WHERE nome= '" + va.Nome + "'";
                    MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                    comandos.ExecuteNonQuery();
                }
                else if (va.Opcao == "F")
                {
                    conexao = new MySqlConnection(Endereco());
                    conexao.Open();
                    string inserir = "UPDATE presenca SET " + va.Corrigir + " = '" + null + "'WHERE nome= '" + va.Nome + "'";
                    MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                    comandos.ExecuteNonQuery();
                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable PresencaDia(Variavel va)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string buscar = "SELECT nome," + va.Corrigir + " FROM presenca ORDER BY nome";
                MySqlDataAdapter comandos = new MySqlDataAdapter(buscar, conexao);
                DataTable dt = new System.Data.DataTable();
                comandos.Fill(dt);
                conexao.Close();
                return dt;
            }
            catch (Exception)
            {
                conexao.Close();
                DataTable dt = new System.Data.DataTable();
                dt.Columns.Add("Mensagem", typeof(string));
                dt.Rows.Add("Não houve reunião nesta data");
                return dt;
            }
        }

        public DataTable presencaPorcentagem()
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string buscar = "SELECT * FROM presenca ORDER BY nome";
                MySqlDataAdapter comandos = new MySqlDataAdapter(buscar, conexao);
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

        public DataTable Falta()
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string buscar = "SELECT UPPER(nome) AS nomeMaisculo FROM presenca ORDER BY nome";
                MySqlDataAdapter comandos = new MySqlDataAdapter(buscar, conexao);
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

        public DataTable pesquisaFalta(Usuario us)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string buscar = "SELECT * FROM presenca where nome= '" + us.Nome + "'";
                MySqlDataAdapter comandos = new MySqlDataAdapter(buscar, conexao);
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

        public void atualizarDados(Equipe eq)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "UPDATE presenca SET nome= '" + eq.Nome + "', dtNasc= '" + Convert.ToDateTime(eq.Nascimento).ToString("yyyy-MM-dd") + "', endereco='" + eq.Endereco + "', telefone='" + eq.Telefone + "', cidade='" + eq.Cidade + "', cep='" + eq.Cep + "'WHERE cod='" + eq.CodigoPresenca + "'";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable pesquisaAlteraDados(Equipe us)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string buscar = "SELECT cod FROM presenca where nome= '" + us.Nome + "'";
                MySqlDataAdapter comandos = new MySqlDataAdapter(buscar, conexao);
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

        public DataTable ultimoCodigo()
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string buscar = "select * from presenca where cod = (select max(cod) from presenca)";
                MySqlDataAdapter comandos = new MySqlDataAdapter(buscar, conexao);
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

        public void Inativo(Variavel va)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string deletar = "delete from presenca where cod='" + va.Codigo + "'";
                MySqlCommand comandos = new MySqlCommand(deletar, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void presencaInativo()
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string buscar = "SELECT * FROM presenca ORDER BY nome";
                MySqlCommand comandos = new MySqlCommand(buscar, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }
    }
}
