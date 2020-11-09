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
    public partial class frmAtDadosEquipe : Form
    {
        ConectaDatasEscalada cd = new ConectaDatasEscalada();
        ConectaEquipe ce = new ConectaEquipe();
        Conecta co = new Conecta();
        Equipe eq = new Equipe();
        int cod, codPres;
        public frmAtDadosEquipe()
        {
            InitializeComponent();
        }

        private void Exibir()
        {
            eq.Escalada = comboBox1.Text;
            dataGridView1.Rows.Clear();
            foreach (DataRow alpinista in ce.BuscaDadosEquipe(eq).Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = alpinista["cod"].GetHashCode();
                dataGridView1.Rows[n].Cells[1].Value = alpinista["nome"].ToString().ToUpper();
                dataGridView1.Rows[n].Cells[2].Value = alpinista["dtNasc"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = alpinista["endereco"].ToString().ToUpper();
                dataGridView1.Rows[n].Cells[4].Value = alpinista["telefone"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = alpinista["cidade"].ToString().ToUpper();
                dataGridView1.Rows[n].Cells[6].Value = alpinista["cep"].ToString();
            }
        }

        private void frmAtDadosEquipe_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            textBox1.Enabled = false;
            maskedTextBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;

            int prf = cd.SelecionaEscalada().Rows.Count;
            comboBox1.Items.Clear();
            for (int j = 0; j < prf; j++)
            {
                comboBox1.Items.Add(cd.SelecionaEscalada().Rows[j]["escalada"].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Exibir();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            maskedTextBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            eq.Nome = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (co.pesquisaAlteraDados(eq).Rows.Count > 0)
            {
                codPres = co.pesquisaAlteraDados(eq).Rows[0][0].GetHashCode();
            }
            else
            {
                codPres = 0;
            }
            cod = dataGridView1.CurrentRow.Cells[0].Value.GetHashCode();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().ToUpper();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().ToUpper();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString().ToUpper();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "")
            {
                string msg = "DATA DE NASCIMENTO É OBRIGATÓRIO!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                eq.Codigo = cod;
                eq.CodigoPresenca = codPres;
                eq.Nome = textBox1.Text.ToUpper();
                eq.Nascimento = maskedTextBox1.Text;
                eq.Endereco = textBox2.Text.ToUpper();
                eq.Telefone = textBox3.Text;
                eq.Cidade = textBox4.Text.ToUpper();
                eq.Cep = textBox5.Text;
                ce.atualizarDadosEquipe(eq);
                if (codPres != 0)
                {
                    co.atualizarDados(eq);
                }
                Exibir();
                string msg = "DADOS ATUALIZADOS";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                button1.Enabled = false;
                button2.Enabled = false;
                textBox1.Enabled = false;
                maskedTextBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox1.Text = "";
                maskedTextBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            textBox1.Enabled = false;
            maskedTextBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox1.Text = "";
            maskedTextBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
