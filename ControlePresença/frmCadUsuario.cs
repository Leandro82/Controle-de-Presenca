using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ControlePresença
{
    public partial class frmCadUsuario : Form
    {
        int cont = 0;
        string nome, login, aux;
        Usuario us = new Usuario();
        ConectaUsuario co = new ConectaUsuario();

        public frmCadUsuario(string n, string l, string a)
        {
            InitializeComponent();
            nome = n;
            login = l;
            aux = a;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            int aux = 0;
            cont = co.usuarioLogin().Rows.Count - 1; ;
            //CriaUsuario ca = new CriaUsuario();

            while (i <= cont)
            {
                if (co.usuarioLogin().Rows[i]["nome"].ToString() == textBox1.Text)
                {
                    aux = 1;
                }
                i = i + 1;
            }

            if (aux == 1)
            {
                string msg = "Usuário já cadastrado";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                label5.Text = "";
            }
            else
            {
                us.Nome = textBox1.Text;
                us.Login = textBox2.Text;
                us.Senha = textBox4.Text;

                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    string msg = "Preencha todos os campos";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
                else
                {
                    co.cadastro(us);
                    string msg = "Usuário cadastrado";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    label5.Text = "";
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox4.Text)
            {
                label5.Text = "Senhas não batem";
                label5.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label5.Text = "OK";
                label5.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            us.Nome = textBox1.Text;
            us.Login = textBox2.Text;
            us.Senha = textBox3.Text;

            co.altera(us);
            string msg = "Dado(s) alterado(s)";
            frmMensagem mg = new frmMensagem(msg);
            mg.ShowDialog();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            label5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            us.Nome = textBox1.Text;

            co.excluir(us);
            string msg = "Usuário excluído";
            frmMensagem mg = new frmMensagem(msg);
            mg.ShowDialog();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            label5.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {
            textBox1.Text = nome;
            textBox2.Text = login;
            if (aux == "ok")
            {
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
            }
        }
    }
}
