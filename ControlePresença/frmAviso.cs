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
    public partial class frmAviso : Form
    {
        string nome, data;
        Conecta co = new Conecta();
        Variavel va = new Variavel();
        public frmAviso(string dt, string nm)
        {
            InitializeComponent();
            data = dt;
            nome = nm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            va.Nome = nome;
            va.DtCadastro = data;
            co.cadastro(va);

            string msg = "Alpinista cadastrado!!!";
            frmMensagem mg = new frmMensagem(msg);
            mg.ShowDialog();
            this.Close();
        }
    }
}
