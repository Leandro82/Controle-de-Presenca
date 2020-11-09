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
    public partial class frmNaoInscrito : Form
    {
        ConectaInscritos ci = new ConectaInscritos();
        Inscritos ins = new Inscritos();
        public frmNaoInscrito()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || maskedTextBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
            {
                string msg = "INFORME TODOS OS DADOS";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else 
            {
                ins.Nome = textBox1.Text.ToUpper();
                ins.DtNascimento = maskedTextBox1.Text;
                ins.Endereco = textBox2.Text.ToUpper();
                ins.Telefone = textBox3.Text;
                ins.Cidade = textBox4.Text.ToUpper();
                ins.Cep = textBox5.Text;
                ins.Sexo = comboBox1.Text.ToUpper();
                ins.Escalada = textBox6.Text;
                ci.cadastroSorteados(ins);
                string msg = "INCLUÍDO NOS SORTEADOS!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
