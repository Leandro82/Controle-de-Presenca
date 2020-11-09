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
    public partial class frmLogin : Form
    {
        ConectaUsuario cs = new ConectaUsuario();
        Ano a = new Ano();
        ConectaAno ca = new ConectaAno();
        string hoje;
        int ano;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            int rec1 = 100000;
            int rec2 = 100001;

            int cont = cs.usuarioLogin().Rows.Count;

            while (i < cont && rec1 != rec2)
            {
                if (textBox1.Text == cs.usuarioLogin().Rows[i]["login"].ToString())
                {
                    rec1 = i;
                }


                if (textBox2.Text == cs.usuarioLogin().Rows[i]["senha"].ToString())
                {
                    rec2 = i;
                }

                i = i + 1;
            }

            if (rec1 == 100000)
            {
                string msg = "Usuário não cadastrado";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                textBox1.Focus();
            }
            else
            {
                if (rec1 != rec2)
                {
                    string msg = "Usuário ou senha inválido";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
                else
                {
                    frmInicio f2 = new frmInicio();
                    f2.Show();
                    this.Hide();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                int i = 0;
                int rec1 = 100000;
                int rec2 = 100001;

                int cont = cs.usuarioLogin().Rows.Count;

                while (i < cont && rec1 != rec2)
                {
                    if (textBox1.Text == cs.usuarioLogin().Rows[i]["login"].ToString())
                    {
                        rec1 = i;
                    }


                    if (textBox2.Text == cs.usuarioLogin().Rows[i]["senha"].ToString())
                    {
                        rec2 = i;
                    }

                    i = i + 1;
                }

                if (rec1 == 100000)
                {
                    string msg = "Usuário não cadastrado";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                    textBox1.Focus();
                }
                else
                {
                    if (rec1 != rec2)
                    {
                        string msg = "Usuário ou senha inválido";
                        frmMensagem mg = new frmMensagem(msg);
                        mg.ShowDialog();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                    else
                    {
                        frmInicio f2 = new frmInicio();
                        f2.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            int con = ca.Ano().Rows.Count;
            hoje = Convert.ToString(DateTime.Today.ToString("yyyy"));

            for (int j = 0; j < con; j++)
            {
                ano = Convert.ToInt32(ca.Ano().Rows[j]["ano"].ToString());
            }
            
            if (ano < Convert.ToUInt32(hoje))
            {
                DialogResult alerta1 = MessageBox.Show("A data do computador está correta?", "ATENÇÃO", MessageBoxButtons.YesNo);
                if (alerta1 == DialogResult.Yes)
                {
                    DialogResult alerta2 = MessageBox.Show("Se a data estiver errada trará erros ao sistema, confirma esta ação?", "ATENÇÃO", MessageBoxButtons.YesNo);
                    if (alerta2 == DialogResult.Yes)
                    {
                        a.An = Convert.ToString(DateTime.Today.ToString("yyyy"));
                        a.DataGerado = Convert.ToString(DateTime.Today.ToString("yyyy"));
                        ca.AlteraAno(a);
                        ca.ZeraEleicao();
                        string msg = "Ano Iniciado";
                        frmMensagem mg = new frmMensagem(msg);
                        mg.ShowDialog();
                    }
                    else if (alerta2 == DialogResult.No)
                    {
                        string msg = "Atualize a data do computador!!";
                        frmMensagem mg = new frmMensagem(msg);
                        mg.ShowDialog();
                        this.Close();
                    }
                }
                else if (alerta1 == DialogResult.No)
                {
                    string msg = "Atualize a data do computador!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
