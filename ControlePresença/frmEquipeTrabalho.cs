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
    public partial class frmEquipeTrabalho : Form
    {
        ConectaInscritos ci = new ConectaInscritos();
        ConectaDatasEscalada cd = new ConectaDatasEscalada();
        Equipe eq = new Equipe();
        ConectaEquipe cq = new ConectaEquipe();
        int dir = 0, aur = 0, mus = 0, cro = 0, lit = 0, cop = 0, sec = 0, lim = 0, coz = 0, cdg = 0, total = 0;

        public frmEquipeTrabalho()
        {
            InitializeComponent();
        }

        public void Exibir()
        {
            Equipe eq = new Equipe();
            ConectaEquipe cq = new ConectaEquipe();
            if (comboBox1.Text == "")
            {
                string msg = "PRIMEIRO ESCOLHA A ESCALADA!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                dataGridView1.Rows.Clear();
                foreach (DataRow item in ci.montarEquipe().Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[1].Value = item["nome"].ToString();
                    DataGridViewComboBoxCell aux = (DataGridViewComboBoxCell)dataGridView1.Rows[n].Cells[2];
                    eq.Nome = item["nome"].ToString();
                    eq.Escalada = comboBox1.Text;
                    if (cq.BuscaEquipe(eq).Rows.Count > 0 && item["nome"].ToString() == cq.BuscaEquipe(eq).Rows[0][1].ToString())
                    {
                        dataGridView1.Rows[n].Cells[0].Value = true;
                        aux.Value = cq.BuscaEquipe(eq).Rows[0][2].ToString();
                        if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Dirigente Gr. 01" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Dirigente Gr. 02" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Dirigente Gr. 03" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Dirigente Gr. 04" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Dirigente Gr. 05")
                        {
                            dir = 0;
                            dir = dir + 1;
                            dataGridView2.Rows[0].Cells[1].Value = dir;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Auxiliar Gr. 01" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Auxiliar Gr. 02" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Auxiliar Gr. 03" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Auxiliar Gr. 04" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Auxiliar Gr. 05")
                        {
                            aur = 0;
                            aur = aur + 1;
                            dataGridView2.Rows[1].Cells[1].Value = aur;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Cronometrista")
                        {
                            cro = 0;
                            cro = cro + 1;
                            dataGridView2.Rows[3].Cells[1].Value = cro;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Resp. Música" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Música")
                        {
                            mus = 0;
                            mus = mus + 1;
                            dataGridView2.Rows[2].Cells[1].Value = mus;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Cozinha")
                        {
                            coz = 0;
                            coz = coz + 1;
                            dataGridView2.Rows[8].Cells[1].Value = coz;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Resp. Copa" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Copa")
                        {
                            cop = 0;
                            cop = cop + 1;
                            dataGridView2.Rows[5].Cells[1].Value = cop;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Resp. Limpeza" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Limpeza")
                        {
                            lim = 0;
                            lim = lim + 1;
                            dataGridView2.Rows[7].Cells[1].Value = lim;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Coordenador Geral")
                        {
                            cdg = 0;
                            cdg = cdg + 1;
                            dataGridView2.Rows[9].Cells[1].Value = cdg;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Resp. Liturgia" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Liturgia")
                        {
                            lim = 0;
                            lim = lim + 1;
                            dataGridView2.Rows[4].Cells[1].Value = lim;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Resp. Secretaria" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Secretaria")
                        {
                            sec = 0;
                            sec = sec + 1;
                            dataGridView2.Rows[6].Cells[1].Value = sec;
                        }

                        dataGridView2.Rows[10].Cells[1].Value = Convert.ToString(dir+aur+cro+coz+cop+lim+cdg+lim+sec+mus);
                    }
                    aux.Items.Add("");
                    aux.Items.Add("Dirigente Gr. 01");
                    aux.Items.Add("Dirigente Gr. 02");
                    aux.Items.Add("Dirigente Gr. 03");
                    aux.Items.Add("Dirigente Gr. 04");
                    aux.Items.Add("Dirigente Gr. 05");
                    aux.Items.Add("Auxiliar Gr. 01");
                    aux.Items.Add("Auxiliar Gr. 02");
                    aux.Items.Add("Auxiliar Gr. 03");
                    aux.Items.Add("Auxiliar Gr. 04");
                    aux.Items.Add("Auxiliar Gr. 05");
                    aux.Items.Add("Cronometrista");
                    aux.Items.Add("Resp. Música");
                    aux.Items.Add("Música");
                    aux.Items.Add("Resp. Liturgia");
                    aux.Items.Add("Liturgia");
                    aux.Items.Add("Casal Orientador");
                    aux.Items.Add("Orientador Espiritual");
                    aux.Items.Add("Orientadora Espiritual");
                    aux.Items.Add("Cozinha");
                    aux.Items.Add("Resp. Secretaria");
                    aux.Items.Add("Secretaria");
                    aux.Items.Add("Resp. Limpeza");
                    aux.Items.Add("Limpeza");
                    aux.Items.Add("Resp. Copa");
                    aux.Items.Add("Copa");
                    aux.Items.Add("Coordenador Geral");
                    dataGridView1.Rows[n].Cells[3].Value = "Atualizar";
                }
            }
        }

        private void frmEquipeTrabalho_Load(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Cells[0].Value = "DIRIGENTES";
            dataGridView2.Rows[0].Cells[1].Value = dir;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[1].Cells[0].Value = "AUXILIARES";
            dataGridView2.Rows[1].Cells[1].Value = aur;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[2].Cells[0].Value = "MÚSICA";
            dataGridView2.Rows[2].Cells[1].Value = mus;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[3].Cells[0].Value = "CRONOMETRISTA";
            dataGridView2.Rows[3].Cells[1].Value = cro;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[4].Cells[0].Value = "LITURGIA";
            dataGridView2.Rows[4].Cells[1].Value = lit;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[5].Cells[0].Value = "COPA";
            dataGridView2.Rows[5].Cells[1].Value = cop;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[6].Cells[0].Value = "SECRETARIA";
            dataGridView2.Rows[6].Cells[1].Value = sec;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[7].Cells[0].Value = "LIMPEZA";
            dataGridView2.Rows[7].Cells[1].Value = lim;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[8].Cells[0].Value = "COZINHA";
            dataGridView2.Rows[8].Cells[1].Value = coz;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[9].Cells[0].Value = "COORDERNADOR GERAL";
            dataGridView2.Rows[9].Cells[1].Value = cdg;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[10].Cells[0].Value = "TOTAL";
            dataGridView2.Rows[10].Cells[1].Value = Convert.ToString(dir + aur + mus + cro + lit + cop + sec + lim + coz + cdg);
            
            int prf = cd.SelecionaEscalada().Rows.Count;
            for (int j = 0; j < prf; j++)
            {
                comboBox1.Items.Add(cd.SelecionaEscalada().Rows[j]["escalada"].ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewComboBoxCell linha = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[2];
            if (e.ColumnIndex == dataGridView1.Columns[0].Index)
            {
                dataGridView1.EndEdit();  //Stop editing of cell.
                int aux = dataGridView1.CurrentRow.Index;
                if ((bool)dataGridView1.Rows[e.RowIndex].Cells[0].Value)
                {
                    if (comboBox1.Text == "")
                    {
                        string msg = "SELECIONE A ESCALADA!!";
                        frmMensagem mg = new frmMensagem(msg);
                        mg.ShowDialog();
                        dataGridView1.Rows[aux].Cells[0].Value = false;
                    }
                    else if (dataGridView1.Rows[aux].Cells[2].Value == null)
                    {
                        string msg = "PRIMEIRO ESCOLHA UMA EQUIPE!!";
                        frmMensagem mg = new frmMensagem(msg);
                        mg.ShowDialog();
                        dataGridView1.Rows[aux].Cells[0].Value = false;
                    }
                    else
                    {
                        eq.Nome = dataGridView1.Rows[aux].Cells[1].Value.ToString();
                        eq.Funcao = dataGridView1.Rows[aux].Cells[2].Value.ToString();
                        eq.Escalada = comboBox1.Text;
                        if (cq.VerificaCadastro(eq).Rows.Count == 0)
                        {
                            cq.cadastro(eq);
                            Exibir();
                            string msg = "ALPINISTA CADASTRADO NA EQUIPE: " + dataGridView1.Rows[aux].Cells[2].Value.ToString();
                            frmMensagem mg = new frmMensagem(msg);
                            mg.ShowDialog();
                        }
                        else
                        {
                            if (cq.VerificaCadastro(eq).Rows[0][2].ToString() == "Dirigente Gr. 01" ||
                                cq.VerificaCadastro(eq).Rows[0][2].ToString() == "Dirigente Gr. 02" ||
                                cq.VerificaCadastro(eq).Rows[0][2].ToString() == "Dirigente Gr. 03" ||
                                cq.VerificaCadastro(eq).Rows[0][2].ToString() == "Dirigente Gr. 04" ||
                                cq.VerificaCadastro(eq).Rows[0][2].ToString() == "Dirigente Gr. 05" ||
                                cq.VerificaCadastro(eq).Rows[0][2].ToString() == "Auxiliar Gr. 01" ||
                                cq.VerificaCadastro(eq).Rows[0][2].ToString() == "Auxiliar Gr. 02" ||
                                cq.VerificaCadastro(eq).Rows[0][2].ToString() == "Auxiliar Gr. 03" ||
                                cq.VerificaCadastro(eq).Rows[0][2].ToString() == "Auxiliar Gr. 04" ||
                                cq.VerificaCadastro(eq).Rows[0][2].ToString() == "Auxiliar Gr. 05" ||
                                cq.VerificaCadastro(eq).Rows[0][2].ToString() == "Cronometrista")
                            {
                                string msg = "FUNÇÃO JÁ CADASTRADA!!";
                                frmMensagem mg = new frmMensagem(msg);
                                mg.ShowDialog();
                                dataGridView1.Rows[aux].Cells[0].Value = false;
                                linha.Value = "";
                            }
                            else
                            {
                                cq.cadastro(eq);
                                Exibir();
                                string msg = "ALPINISTA CADASTRADO NA EQUIPE: " + dataGridView1.Rows[aux].Cells[2].Value.ToString();
                                frmMensagem mg = new frmMensagem(msg);
                                mg.ShowDialog();
                            }
                        }
                    }
                }
                else
                {
                    eq.Nome = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    eq.Escalada = comboBox1.Text;
                    eq.Codigo = cq.BuscaEquipe(eq).Rows[0][0].GetHashCode();
                    cq.excluirAlpEquipe(eq);
                    Exibir();
                    string msg = "ALPINISTA EXCLUÍDO DA EQUIPE!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
            }

            if (dataGridView1.Rows[e.RowIndex].Cells[3].Selected)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    eq.Nome = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    eq.Escalada = comboBox1.Text;
                    eq.Codigo = cq.BuscaEquipe(eq).Rows[0][0].GetHashCode();
                    eq.Funcao = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    cq.atualizarEquipe(eq);
                    Exibir();
                    string msg = "CADASTRO ATUALIZADO!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Exibir();
        }
    }
}
