using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlePresença
{
    public partial class frmSorteados : Form
    {
        ConectaInscritos ci = new ConectaInscritos();
        Inscritos ins = new Inscritos();
        int masc = 0;
        int fem = 0;
        public frmSorteados()
        {
            InitializeComponent();
        }

        private void frmSorteados_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (DataRow dtRow in ci.sorteioMeninas().Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[1].Value = dtRow["cod"].GetHashCode();
                dataGridView1.Rows[n].Cells[2].Value = dtRow["nome"].ToString().ToUpper();
                dataGridView1.Rows[n].Cells[3].Value = dtRow["dtNasc"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dtRow["endereco"].ToString().ToUpper();
                dataGridView1.Rows[n].Cells[5].Value = dtRow["telefone"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = dtRow["cidade"].ToString().ToUpper();
                dataGridView1.Rows[n].Cells[7].Value = dtRow["cep"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = dtRow["sexo"].ToString().ToUpper();
                dataGridView1.Rows[n].Cells[9].Value = dtRow["escalada"].ToString();
                ins.Nome = dtRow["nome"].ToString().ToUpper();
                ins.Endereco = dtRow["endereco"].ToString().ToUpper();
                ins.Escalada = dtRow["escalada"].ToString();
                //MessageBox.Show("" + ci.verificaSorteados(ins).Rows[1][1].ToString());
                if (ci.verificaSorteados(ins).Rows.Count > 0)
                {
                    if (ci.verificaSorteados(ins).Rows[0][1].ToString() == dtRow["nome"].ToString().ToUpper() && ci.verificaSorteados(ins).Rows[0][2].ToString() == dtRow["endereco"].ToString().ToUpper())
                    {
                        dataGridView1.Rows[n].Cells[0].Value = true;
                        if (dtRow["sexo"].ToString().ToUpper() == "FEMININO")
                        {
                            fem = fem + 1;
                            textBox1.Text = Convert.ToString(fem);
                        }
                        else if (dtRow["sexo"].ToString().ToUpper() == "MASCULINO")
                        {
                            masc = masc + 1;
                            textBox2.Text = Convert.ToString(masc);
                        }
                    }
                }
            }
            string ms = "CONFIRA TODOS OS DADOS E FAÇA AS CORREÇÕES, CASO HOUVER, ANTES DE CLICAR NA COLUNA SORTEADO(A)";
            frmLembrete frm = new frmLembrete(ms);
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[0].Index)
            {
                dataGridView1.EndEdit(); 
                int aux = dataGridView1.CurrentRow.Index;
                string nome = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string sexo = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                string endereco = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                if ((bool)dataGridView1.Rows[e.RowIndex].Cells[0].Value)
                {
                    ins.Codigo = dataGridView1.Rows[aux].Cells[1].Value.GetHashCode();
                    ins.Nome = dataGridView1.Rows[aux].Cells[2].Value.ToString().ToUpper();
                    ins.DtNascimento = dataGridView1.Rows[aux].Cells[3].Value.ToString();
                    ins.Endereco = dataGridView1.Rows[aux].Cells[4].Value.ToString().ToUpper();
                    ins.Telefone = dataGridView1.Rows[aux].Cells[5].Value.ToString();
                    ins.Cidade = dataGridView1.Rows[aux].Cells[6].Value.ToString().ToUpper();
                    ins.Cep = dataGridView1.Rows[aux].Cells[7].Value.ToString();
                    ins.Sexo = dataGridView1.Rows[aux].Cells[8].Value.ToString().ToUpper();
                    ins.Escalada = dataGridView1.Rows[aux].Cells[9].Value.ToString();

                    ci.cadastroSorteados(ins);
                    ci.alteraInscritos(ins);

                    if (sexo == "FEMININO")
                    {
                        fem = fem + 1;
                        textBox1.Text = Convert.ToString(fem);
                    }
                    else if (sexo == "MASCULINO")
                    {
                        masc = masc + 1;
                        textBox2.Text = Convert.ToString(masc);
                    }

                    string msg = "INCLUÍDO NOS SORTEADOS!!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
                else
                {
                    ins.Nome = nome;
                    ins.Endereco = endereco;
                    ci.excluirSorteados(ins);
                    if (sexo == "FEMININO")
                    {
                        fem = fem - 1;
                        textBox1.Text = Convert.ToString(fem);
                    }
                    else if (sexo == "MASCULINO")
                    {
                        masc = masc - 1;
                        textBox2.Text = Convert.ToString(masc);
                    }
                    string msg = "EXCLUÍDO DOS SORTEADOS!!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmNaoInscrito frm = new frmNaoInscrito();
            frm.ShowDialog();
        }
    }
}
