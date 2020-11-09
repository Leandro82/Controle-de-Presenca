using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace ControlePresença
{
    public partial class frmLoad : Form
    {
        int mat1, seg;
        //int cont1 = 0;
        int cod;
        string caminho;
        DataTable dt = new System.Data.DataTable();
        string data = Convert.ToString(DateTime.Today);
        ConectaUsuario cs = new ConectaUsuario();
        Conecta co = new Conecta();
        Usuario us = new Usuario();
        Variavel va = new Variavel();
        public frmLoad(int mat, string cam)
        {
            InitializeComponent();
            caminho = cam;
            mat1 = mat;
        }

        public void Fechar()
        {
            timer2.Interval = 20000;
            timer2.Start();
        }

        private Timer time = new Timer();


        private void InitializeMyTimer()
        {
            time.Interval = 250;
            time.Tick += new EventHandler(frmLoad_Load);
            time.Start();
        }

        private void frmLoad_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 10;
            progressBar1.Maximum = mat1;
            timer1.Tick += new EventHandler(timer1_Tick);
            foreach (DataRow item in co.ultimoCodigo().Rows)
            {
                cod = item["cod"].GetHashCode();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int j = 0;
            int cont = cs.Usuario().Rows.Count;
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + caminho + ";Extended Properties=Excel 12.0;");
            con.Open();
            OleDbDataAdapter query = new OleDbDataAdapter(" SELECT * FROM [Planilha1$]", con);
            DataTable dataTable = new DataTable();
            query.Fill(dataTable);
            timer1.Enabled = true;
            timer1.Start();
            progressBar1.Maximum = mat1;
            Conecta cl = new Conecta();
            Variavel va = new Variavel();

            foreach (DataRow dtRow in dataTable.Rows)
            {
                us.Nome = dtRow[0].ToString();
                int aux = co.pesquisaFalta(us).Rows.Count;
                if (mat1 > progressBar1.Value)
                {
                    if (j == 0)
                    {
                    }
                    else
                    {
                        if (cont == 0)
                        {
                            if (aux == 0)
                            {
                                va.Nome = dtRow[0].ToString();
                                va.DtCadastro = Convert.ToDateTime(data).ToString("dd/MM/yyyy");
                                cl.cadastro(va);
                            }
                        }
                        else
                        {
                            if (aux == 0)
                            {
                                va.Nome = dtRow[0].ToString();
                                va.DtCadastro = Convert.ToDateTime(data).ToString("dd/MM/yyyy");
                                cl.cadastro(va);
                                cont = cs.Usuario().Rows.Count;
                            }
                        }
                    }
                    j = j + 1;
                    if (j + 1 <= mat1)
                    {
                        progressBar1.Value++;
                    }
                }
            }
            con.Close();
            timer1.Stop();
            timer2.Enabled = true;
            seg = 10;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            seg--;
            label1.Text = "Finalizado";
            if (seg == 0)
            {
                this.Close();
            }
        }
    }
}
