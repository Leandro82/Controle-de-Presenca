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
    public partial class frmAtDadosNovos : Form
    {
        ConectaDatasEscalada cd = new ConectaDatasEscalada();
        ConectaInscritos ci = new ConectaInscritos();
        Inscritos ins = new Inscritos();
        Equipe eq = new Equipe();
        string nome, endereco, telefone;
        int cod;
        public frmAtDadosNovos()
        {
            InitializeComponent();
        }

        private void Exibir()
        {
            ins.Escalada = comboBox1.Text;
            dataGridView1.Rows.Clear();
            foreach (DataRow alpinista in ci.sorteados(ins).Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = alpinista["cod"].GetHashCode();
                dataGridView1.Rows[n].Cells[1].Value = alpinista["nome"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = alpinista["dtNasc"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = alpinista["endereco"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = alpinista["telefone"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = alpinista["cidade"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = alpinista["cep"].ToString();
            }
        }

        private void frmAtDadosNovos_Load(object sender, EventArgs e)
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
            ins.Nome = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cod = dataGridView1.CurrentRow.Cells[0].Value.GetHashCode();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            nome = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            endereco = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            telefone = dataGridView1.CurrentRow.Cells[4].Value.ToString();
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
                ins.Codigo = cod;
                ins.Nome = textBox1.Text;
                ins.DtNascimento = maskedTextBox1.Text;
                ins.Endereco = textBox2.Text;
                ins.Telefone = textBox3.Text;
                ins.Cidade = textBox4.Text;
                ins.Cep = textBox5.Text;
                ci.alteraDadosNovos(ins);
                eq.Nome = nome;
                eq.Endereco = endereco;
                eq.Telefone = telefone;
                ci.alteraInscritosPosSorteio(ins, eq);
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
