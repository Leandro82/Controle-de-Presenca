using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace ControlePresença
{
    public partial class frmInscritos : Form
    {
        Inscritos ins = new Inscritos();
        ConectaInscritos ci = new ConectaInscritos();

        public frmInscritos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog arquivoExcel = new OpenFileDialog();

            if (arquivoExcel.ShowDialog() == DialogResult.OK)
            {
                string caminho = arquivoExcel.FileName;
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + arquivoExcel.FileName + ";Extended Properties=Excel 12.0;");
                con.Open();
                //DataSet excelDataSet = new DataSet();
                OleDbDataAdapter query = new OleDbDataAdapter(" SELECT * FROM [Banco de Dados$]order by nome", con);
                DataTable dataTable = new DataTable();
                query.Fill(dataTable);
                int mat = dataTable.Rows.Count;

                dataGridView1.Rows.Clear();
                foreach (DataRow dtRow in dataTable.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dtRow[1].ToString().ToUpper();
                    dataGridView1.Rows[n].Cells[1].Value = Convert.ToDateTime(dtRow[3].ToString()).ToString("dd/MM/yyyy");
                    dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(dtRow[4].ToString()).TrimEnd().ToUpper() + ", " + dtRow[5].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dtRow[7].ToString().ToUpper();
                    dataGridView1.Rows[n].Cells[4].Value = dtRow[8].ToString().ToUpper();
                    dataGridView1.Rows[n].Cells[5].Value = dtRow[9].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dtRow[10].ToString().ToUpper();
                    dataGridView1.Rows[n].Cells[7].Value = dtRow[2].ToString().ToUpper();               
                }
                string ms = "ANTES DE PROSSEGUIR VERIFIQUE SE HÁ CADASTROS DUPLICADOS, CASO ENCONTRE, CLIQUE DUAS VEZES SOBRE A LINHA PARA EXCLUÍ-LO, APÓS VERIFICAR, CLIQUE NO BOTÃO 3º GRAVAR DADOS";
                frmLembrete frm = new frmLembrete(ms);
                frm.ShowDialog();
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                string msg = "INFORME A ESCALADA!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                textBox1.Focus();
            }            
            else
            {
                if (ci.sorteioMeninas().Rows.Count != 0 && ci.sorteioMeninas().Rows[0][7].ToString() == textBox1.Text)
                {
                    string msg = "OS DADOS PARA ESTA ESCALADA JÁ ESTÃO SALVOS NO BANCO, PODE GERAR AS FICHAS!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
                else
                {
                    progressBar1.Visible = true;
                    progressBar1.Maximum = dataGridView1.Rows.Count;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        ins.Nome = dataGridView1.Rows[i].Cells[0].Value.ToString().ToUpper();
                        ins.DtNascimento = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        ins.Endereco = dataGridView1.Rows[i].Cells[2].Value.ToString().ToUpper();
                        ins.Telefone = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        ins.Cidade = dataGridView1.Rows[i].Cells[3].Value.ToString().ToUpper(); ;
                        ins.Cep = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        ins.Sexo = dataGridView1.Rows[i].Cells[7].Value.ToString().ToUpper();
                        ins.Escalada = textBox1.Text;
                        ci.cadastro(ins);
                        progressBar1.Value++;
                    }
                    string msg = "DADOS CADASTRADOS!!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                    dataGridView1.Rows.Clear();
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                }
            }
        }

        private void frmInscritos_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmSortMeninasOcz form = new frmSortMeninasOcz(1);
            form.Text = "FICHAS - Meninas de Osvaldo Cruz";
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSortMeninasOcz form = new frmSortMeninasOcz(2);
            form.Text = "FICHAS - Meninos de Osvaldo Cruz";
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSortMeninasOcz form = new frmSortMeninasOcz(3);
            form.Text = "FICHAS - Meninas de outras cidades";
            form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmSortMeninasOcz form = new frmSortMeninasOcz(4);
            form.Text = "FICHAS - Meninos de outras cidades";
            form.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string msg = "USAR ESTE RECURSO APENAS PARA COMEÇAR UMA NOVA ESCALADA, DESEJA CONTINUAR?";
            frmDecisao des = new frmDecisao(msg);
            des.ShowDialog();        
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }
    }
}
