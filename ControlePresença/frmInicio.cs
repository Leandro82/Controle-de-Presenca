using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace ControlePresença
{
    public partial class frmInicio : Form
    {
        StringConexao sc = new StringConexao();
        OpenFileDialog arquivo = new OpenFileDialog();

        public frmInicio()
        {
            InitializeComponent();
        }

        private void porEscaladaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmCadAlpinistas();
            if (Application.OpenForms.OfType<frmCadAlpinistas>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void frmInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           SaveFileDialog caminho = new SaveFileDialog();
            caminho.FileName = "Backup";
            caminho.DefaultExt = ".sql";
            caminho.Filter = "Todos os Aquivos de banco (*.sql)|*.sql| Todos os arquivos (*.*)|*.*";
            if (caminho.ShowDialog() == DialogResult.OK)
            {
                //string constring = "Persist Security Info=false;SERVER=localhost;DATABASE=escalada;UID=root;pwd=";
                using (MySqlConnection conn = new MySqlConnection(sc.Endereco()))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            string dest = caminho.FileName;
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(dest);
                            conn.Close();
                            string msg = "Backup exportado com sucesso!!!";
                            frmMensagem mg = new frmMensagem(msg);
                            mg.ShowDialog();
                        }
                    }
                }
            }
        }

        private void porAlpinistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmBio();
            if (Application.OpenForms.OfType<frmBio>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void chamadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmChamada();
            if (Application.OpenForms.OfType<frmChamada>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void porcentagemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new frmPorcentagem();
            if (Application.OpenForms.OfType<frmPorcentagem>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void faltasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmVerifica();
            if (Application.OpenForms.OfType<frmVerifica>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (arquivo.ShowDialog() == DialogResult.OK)
            {
                using (MySqlConnection conn = new MySqlConnection(sc.Endereco()))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(arquivo.FileName);
                            conn.Close();
                            string msg = "Backup importado com sucesso!!!";
                            frmMensagem mg = new frmMensagem(msg);
                            mg.ShowDialog();
                        }
                    }
                }
            }
        }

        private void datasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            if (Application.OpenForms.OfType<Form1>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void cadastrarUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmCadUsuario("", "", "");
            if (Application.OpenForms.OfType<frmCadUsuario>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void pesquisarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmPeqUsuario();
            if (Application.OpenForms.OfType<frmPeqUsuario>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void correçãoDeFaltasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new frmCorrigir();
            if (Application.OpenForms.OfType<frmCorrigir>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmAgenda();
            if (Application.OpenForms.OfType<frmAgenda>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new frmInativos();
            if (Application.OpenForms.OfType<frmInativos>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void inscritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmInscritos();
            if (Application.OpenForms.OfType<frmInscritos>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }
    }
}
