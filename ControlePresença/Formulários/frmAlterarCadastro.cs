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
    public partial class frmAlterarCadastro : Form
    {
        Variavel va = new Variavel();
        Conecta co = new Conecta();
        int cod, codAlt;

        public frmAlterarCadastro()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            va.Nome = textBox3.Text;
            int cont = co.Alpinistas(va).Rows.Count;

            if (cont > 0)
            {
                dataGridView1.Rows.Clear();
                foreach (DataRow alp in co.Alpinistas(va).Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    cod = alp["cod"].GetHashCode();
                    dataGridView1.Rows[n].Cells[0].Value = alp["nome"].ToString().ToUpper();
                    dataGridView1.Rows[n].Cells[1].Value = Convert.ToDateTime(alp["dtCad"].ToString()).ToString("dd/MM/yyyy");
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }
        
        public void Enable()
        {
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void frmAlterarCadastro_Load(object sender, EventArgs e)
        {
            panel2.Focus();
            textBox3.Focus();
            Enable();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            codAlt = cod;
            textBox1.Text = dataGridView1[0, dataGridView1.CurrentCellAddress.Y].Value.ToString().ToUpper();
            dateTimePicker1.Text = dataGridView1[1, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            textBox3.Clear();
            dataGridView1.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                string msg = "SELECIONE OS DADOS DO ALPINISTA NA TELA AO LADO";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                panel2.Focus();
                textBox3.Focus();
            }
            else
            {
                va.Codigo = codAlt;
                va.Nome = textBox1.Text.ToUpper();
                va.DtCadastro = dateTimePicker1.Text;
                co.alteraDadosAlp(va);
                textBox1.Clear();
                dateTimePicker1.Text = Convert.ToDateTime(DateTime.Today).ToString("dd/MM/yyyy");
                Enable();
                string msg = "DADOS ATUALIZADOS!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            dateTimePicker1.Text = Convert.ToDateTime(DateTime.Today).ToString("dd/MM/yyyy");
            Enable();
        }
    }
}
