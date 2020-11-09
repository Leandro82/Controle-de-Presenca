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

        private void frmInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog caminho = new SaveFileDialog();
            caminho.FileName = "Backup - Presença";
            caminho.DefaultExt = ".sql";
            caminho.Filter = "Todos os Aquivos de banco (*.sql)|*.sql| Todos os arquivos (*.*)|*.*";
            if (caminho.ShowDialog() == DialogResult.OK)
            {
                //string constring = ba.backuptb();  
                using (MySqlConnection conn = new MySqlConnection(sc.Endereco()))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            string dest = caminho.FileName;
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportInfo.ExcludeTables = new List<string> {
                            "agenda",
                            "datas",
                            "presenca",
                            "usuario",
                            "ano",
                            "eleicao"
                            };

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

        private void equipeDeTrabalhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void datasEscaladaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmDatasEscalada();
            if (Application.OpenForms.OfType<frmDatasEscalada>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void listaDePresençaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = new frmListaPresenca();
            if (Application.OpenForms.OfType<frmListaPresenca>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void listaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmListaPag();
            if (Application.OpenForms.OfType<frmListaPag>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void listaDePresençaPaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmListaPresençaPais();
            if (Application.OpenForms.OfType<frmListaPresençaPais>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void listaDeCamisetasControleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmListaCamisetas();
            if (Application.OpenForms.OfType<frmListaCamisetas>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void crachásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmAbreviarNomes();
            if (Application.OpenForms.OfType<frmAbreviarNomes>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void exportarEscaladaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog caminho = new SaveFileDialog();
            caminho.FileName = "Backup - Escalada";
            caminho.DefaultExt = ".sql";
            caminho.Filter = "Todos os Aquivos de banco (*.sql)|*.sql| Todos os arquivos (*.*)|*.*";
            if (caminho.ShowDialog() == DialogResult.OK)
            {
                //string constring = ba.backuptb();  
                using (MySqlConnection conn = new MySqlConnection(sc.Endereco()))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            string dest = caminho.FileName;
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportInfo.TablesToBeExportedList = new List<string> {
                            "sorteados",
                            "equipe",
                            "cracha",
                            "datasescalada",
                            "inscritos"
                            };

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

        private void listaPagamentoEquipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmPagEquipe();
            if (Application.OpenForms.OfType<frmPagEquipe>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void montarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmEquipeTrabalho();
            if (Application.OpenForms.OfType<frmEquipeTrabalho>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmRelEquipe();
            if (Application.OpenForms.OfType<frmRelEquipe>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void atualizarDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmAtDadosEquipe();
            if (Application.OpenForms.OfType<frmAtDadosEquipe>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void dividirGruposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new frmDividirGrupos();
            if (Application.OpenForms.OfType<frmDividirGrupos>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void relatórioGruposDivididosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmRelGrupos();
            if (Application.OpenForms.OfType<frmRelGrupos>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmSorteados();
            if (Application.OpenForms.OfType<frmSorteados>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void conferênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmConfNovos();
            if (Application.OpenForms.OfType<frmConfNovos>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void conferênciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new frmConfDadosEquipe();
            if (Application.OpenForms.OfType<frmConfDadosEquipe>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void atualizarDadosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = new frmAtDadosNovos();
            if (Application.OpenForms.OfType<frmAtDadosNovos>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void alterarCadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmAlterarCadastro();
            if (Application.OpenForms.OfType<frmAlterarCadastro>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void equipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmEnvelopeEquipe();
            if (Application.OpenForms.OfType<frmEnvelopeEquipe>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void novosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmEnvelopeNovos();
            if (Application.OpenForms.OfType<frmEnvelopeNovos>().Count() > 0)
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
