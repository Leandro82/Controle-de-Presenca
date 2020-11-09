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
    public partial class frmDecisao : Form
    {
        ConectaInscritos ci = new ConectaInscritos();
        string msg;
        public frmDecisao(string ms)
        {
            InitializeComponent();
            msg = ms;
        }

        private void frmDecisao_Load(object sender, EventArgs e)
        {
            textBox1.Text = msg;
            button2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ci.apagaDados();
            string msg = "BANCO DE DADOS LIBERADO!!!";
            frmMensagem mg = new frmMensagem(msg);
            mg.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
