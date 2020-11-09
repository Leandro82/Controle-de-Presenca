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
    public partial class frmCadPres : Form
    {
        ConectaInscritos ci = new ConectaInscritos();
        Inscritos ins = new Inscritos();
        ConectaDatasEscalada cd = new ConectaDatasEscalada();
        Conecta co = new Conecta();

        public frmCadPres()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ins.Escalada = comboBox1.Text;

            if (ci.sorteados(ins).Rows.Count == 0)
            {

            }
            else
            {
                string mens = "DATA DO CADASTRO " + Convert.ToDateTime(dateTimePicker1.Text).ToString("dd/MM/yyyy");
                string titulo = "DESEJA CONTINUAR?";
                MessageBoxButtons botao = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(mens,titulo,botao);
                if (result == DialogResult.Yes)
                {
                    progressBar1.Visible = true;
                    progressBar1.Maximum = ci.sorteados(ins).Rows.Count;
                    label1.Visible = true;
                    foreach (DataRow alp in ci.sorteados(ins).Rows)
                    {
                        label1.Text = "CADASTRANDO " + alp["nome"].ToString();
                        label1.Location = new Point(this.Location.X / 2, 600);
                        ins.Nome = alp["nome"].ToString();
                        ins.DtNascimento = alp["dtNasc"].ToString();
                        ins.Endereco = alp["endereco"].ToString();
                        ins.Telefone = alp["telefone"].ToString();
                        ins.Cidade = alp["cidade"].ToString();
                        ins.Cep = alp["cep"].ToString();
                        ins.DtCadastro = Convert.ToDateTime(dateTimePicker1.Text).ToString("dd/MM/yyyy");
                        co.cadastroNovos(ins);
                        progressBar1.Value++;
                    }
                    progressBar1.Visible = false;
                    string msg = "OS NOVOS ALPINISTAS FORAM CADASTRADOS PARA RECEBER PRESENÇA";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void frmCadPres_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            progressBar1.Visible = false;
            int prf = cd.SelecionaEscalada().Rows.Count;
            for (int j = 0; j < prf; j++)
            {
                comboBox1.Items.Add(cd.SelecionaEscalada().Rows[j]["escalada"].ToString());
            }
        }
    }
}
