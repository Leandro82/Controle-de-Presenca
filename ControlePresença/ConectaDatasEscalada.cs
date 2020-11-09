using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace ControlePresença
{
    class ConectaDatasEscalada
    {
        public MySqlConnection conexao;

        public string Endereco()
        {
            StringConexao str = new StringConexao();
            return str.Endereco();
        }

        public void cadastro(DatasEscalada dt)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string inserir = "INSERT INTO datasescalada(escalada, pdtnovos, sdtnovos, tdtnovos, pdtpais, sdtpais, dtcaminhada, dtescalada)VALUES('" + dt.Escalada + "','" + Convert.ToDateTime(dt.PrimeiraNovos).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(dt.SegundaNovos).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(dt.TerceiraNovos).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(dt.PrimeiraPais).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(dt.SegundaPais).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(dt.Caminhada).ToString("yyyy-MM-dd") + "','" + dt.DataEscalada + "')";
                MySqlCommand comandos = new MySqlCommand(inserir, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public void atualizarDatas(DatasEscalada dt)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string atualizar = "UPDATE datasescalada SET escalada= '" + dt.Escalada + "', pdtnovos= '" + Convert.ToDateTime(dt.PrimeiraNovos).ToString("yyyy-MM-dd") + "', sdtnovos= '" + Convert.ToDateTime(dt.SegundaNovos).ToString("yyyy-MM-dd") + "', tdtnovos='" + Convert.ToDateTime(dt.TerceiraNovos).ToString("yyyy-MM-dd") + "',pdtpais='" + dt.PrimeiraPais + "',sdtpais='" + dt.SegundaPais + "', dtcaminhada='" + dt.Caminhada + "',dtescalada='" + dt.DataEscalada + "'WHERE escalada= '" + dt.Escalada + "'";
                MySqlCommand comandos = new MySqlCommand(atualizar, conexao);
                comandos.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable BuscarDatas(DatasEscalada dt)
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string selecionar = "SELECT pdtnovos, sdtnovos, tdtnovos, pdtpais, sdtpais, dtcaminhada, dtescalada FROM datasescalada WhERE escalada='" + dt.Escalada + "'";
                MySqlDataAdapter comandos = new MySqlDataAdapter(selecionar, conexao);
                DataTable db = new System.Data.DataTable();
                comandos.Fill(db);
                conexao.Close();
                return db;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }

        public DataTable SelecionaEscalada()
        {
            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string selecionar = "SELECT escalada FROM datasescalada";
                MySqlDataAdapter comandos = new MySqlDataAdapter(selecionar, conexao);
                DataTable db = new System.Data.DataTable();
                comandos.Fill(db);
                conexao.Close();
                return db;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }
        }
    }
}
