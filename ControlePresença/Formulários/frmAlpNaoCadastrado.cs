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
    public partial class frmAlpNaoCadastrado : Form
    {
        ConectaEquipe cq = new ConectaEquipe();
        Equipe eq = new Equipe();
        string escalada;
        frmEquipeTrabalho trab = new frmEquipeTrabalho();
        public frmAlpNaoCadastrado(string esc)
        {
            InitializeComponent();
            escalada = esc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                string msg = "INFORME O NOME COMPLETO DO ALPINISTA";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                textBox1.Focus();
            }
            else if (comboBox1.Text == "")
            {
                string msg = "INFORME A EQUIPE";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                comboBox1.Focus();
            }
            else
            {
                eq.Nome = textBox1.Text.ToUpper();
                eq.Funcao = comboBox1.Text;
                eq.Escalada = escalada;
                eq.NaoCadastrado = "Ok";
                cq.cadastro(eq);
                string msg = "ALPINISTA CADASTRADO NA EQUIPE: " + comboBox1.Text;
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
