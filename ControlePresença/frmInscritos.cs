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
                OleDbDataAdapter query = new OleDbDataAdapter(" SELECT * FROM [Banco de Dados$]", con);
                DataTable dataTable = new DataTable();
                query.Fill(dataTable);
                int mat = dataTable.Rows.Count;

                foreach (DataRow dtRow in dataTable.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = dtRow[1].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = Convert.ToDateTime(dtRow[3].ToString()).ToString("dd/MM/yyyy");
                    dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(dtRow[4].ToString()).TrimEnd() + ", " + dtRow[5].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = dtRow[7].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = dtRow[8].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = dtRow[9].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = dtRow[10].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = dtRow[2].ToString();
                }
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
                progressBar1.Visible = true;
                progressBar1.Maximum = dataGridView1.Rows.Count;
                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {
                    ins.Nome = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    ins.DtNascimento = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    ins.Endereco = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    ins.Telefone = dataGridView1.Rows[i].Cells[6].Value.ToString();
                    ins.Cidade = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    ins.Cep = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    ins.Sexo = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    ins.Escalada = textBox1.Text;

                    ci.cadastro(ins);
                    progressBar1.Value++;
                }
                string msg = "DADOS CADASTRADOS!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                progressBar1.Visible = false;
            }
        }

        private void frmInscritos_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var peq = new frmSortMeninasOcz();
            if (System.Windows.Forms.Application.OpenForms.OfType<frmSortMeninasOcz>().Count() > 0)
            {
                System.Windows.Forms.Application.OpenForms[peq.Name].Focus();
            }
            else
            {
                peq.ShowDialog();
            }
        }
    }
}
