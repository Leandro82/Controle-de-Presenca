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
        ConectaEquipe ce = new ConectaEquipe();
        Equipe eq = new Equipe();
        ConectaEquipe cq = new ConectaEquipe();
        int dir = 0, aur = 0, mus = 0, cro = 0, lit = 0, cop = 0, sec = 0, lim = 0, coz = 0, cdg = 0, cor = 0, ceo = 0, cea = 0;

        public frmEquipeTrabalho()
        {
            InitializeComponent();
        }

        public void Equipe()
        {
            eq.Escalada = comboBox1.Text;
            dataGridView3.Rows.Clear();
            foreach(DataRow item in ce.montaEquipe(eq).Rows)
            {
                if (item["funcao"].ToString() == "Dirigente Gr. 01" || item["funcao"].ToString() == "Dirigente Gr. 02" || item["funcao"].ToString() == "Dirigente Gr. 03" || item["funcao"].ToString() == "Dirigente Gr. 04" || item["funcao"].ToString() == "Dirigente Gr. 05")
                {
                    int n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    dataGridView3.Rows[n].Cells[1].Value = item["funcao"].ToString();
                }
            }
            foreach (DataRow item in ce.montaEquipe(eq).Rows)
            {
                int n = dataGridView3.Rows.Count + 1;
                if (item["funcao"].ToString() == "Auxiliar Gr. 01" || item["funcao"].ToString() == "Auxiliar Gr. 02" || item["funcao"].ToString() == "Auxiliar Gr. 03" || item["funcao"].ToString() == "Auxiliar Gr. 04" || item["funcao"].ToString() == "Auxiliar Gr. 05")
                {
                    n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    dataGridView3.Rows[n].Cells[1].Value = item["funcao"].ToString();
                }
            }

            foreach (DataRow item in ce.montaEquipe(eq).Rows)
            {
                int n = dataGridView3.Rows.Count + 1;
                if (item["funcao"].ToString() == "Resp. Liturgia" || item["funcao"].ToString() == "Liturgia")
                {
                    n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    dataGridView3.Rows[n].Cells[1].Value = item["funcao"].ToString();
                }
            }

            foreach (DataRow item in ce.montaEquipe(eq).Rows)
            {
                int n = dataGridView3.Rows.Count + 1;
                if (item["funcao"].ToString() == "Resp. Música" || item["funcao"].ToString() == "Música")
                {
                    n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    dataGridView3.Rows[n].Cells[1].Value = item["funcao"].ToString();
                }
            }

            foreach (DataRow item in ce.montaEquipe(eq).Rows)
            {
                int n = dataGridView3.Rows.Count + 1;
                if (item["funcao"].ToString() == "Resp. Secretaria" || item["funcao"].ToString() == "Secretaria")
                {
                    n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    dataGridView3.Rows[n].Cells[1].Value = item["funcao"].ToString();
                }
            }

            foreach (DataRow item in ce.montaEquipe(eq).Rows)
            {
                int n = dataGridView3.Rows.Count + 1;
                if (item["funcao"].ToString() == "Resp. Copa" || item["funcao"].ToString() == "Copa")
                {
                    n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    dataGridView3.Rows[n].Cells[1].Value = item["funcao"].ToString();
                }
            }

            foreach (DataRow item in ce.montaEquipe(eq).Rows)
            {
                int n = dataGridView3.Rows.Count + 1;
                if (item["funcao"].ToString() == "Resp. Limpeza" || item["funcao"].ToString() == "Limpeza")
                {
                    n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    dataGridView3.Rows[n].Cells[1].Value = item["funcao"].ToString();
                }
            }

            foreach (DataRow item in ce.montaEquipe(eq).Rows)
            {
                int n = dataGridView3.Rows.Count + 1;
                if (item["funcao"].ToString() == "Cozinha")
                {
                    n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    dataGridView3.Rows[n].Cells[1].Value = item["funcao"].ToString();
                }
            }

            foreach (DataRow item in ce.montaEquipe(eq).Rows)
            {
                int n = dataGridView3.Rows.Count + 1;
                if (item["funcao"].ToString() == "Cronometrista")
                {
                    n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    dataGridView3.Rows[n].Cells[1].Value = item["funcao"].ToString();
                }
            }

            foreach (DataRow item in ce.montaEquipe(eq).Rows)
            {
                int n = dataGridView3.Rows.Count + 1;
                if (item["funcao"].ToString() == "Coordenador Geral")
                {
                    n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    dataGridView3.Rows[n].Cells[1].Value = item["funcao"].ToString();
                }
            }

            foreach (DataRow item in ce.montaEquipe(eq).Rows)
            {
                int n = dataGridView3.Rows.Count + 1;
                if (item["funcao"].ToString() == "Casal Orientador")
                {
                    n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    dataGridView3.Rows[n].Cells[1].Value = item["funcao"].ToString();
                }
            }

            foreach (DataRow item in ce.montaEquipe(eq).Rows)
            {
                int n = dataGridView3.Rows.Count + 1;
                if (item["funcao"].ToString() == "Orientador Espiritual")
                {
                    n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    dataGridView3.Rows[n].Cells[1].Value = item["funcao"].ToString();
                }
            }

            foreach (DataRow item in ce.montaEquipe(eq).Rows)
            {
                int n = dataGridView3.Rows.Count + 1;
                if (item["funcao"].ToString() == "Orientadora Espiritual")
                {
                    n = dataGridView3.Rows.Add();
                    dataGridView3.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    dataGridView3.Rows[n].Cells[1].Value = item["funcao"].ToString();
                }
            }
        }
        
        public void Exibir()
        {
            
            if (comboBox1.Text == "")
            {
                string msg = "PRIMEIRO ESCOLHA A ESCALADA!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                dataGridView1.Rows.Clear();
                dir = 0; aur = 0; mus = 0; cro = 0; lit = 0; cop = 0; sec = 0; lim = 0; coz = 0; cdg = 0; cor = 0; ceo = 0; cea= 0;
                eq.Escalada = comboBox1.Text;
                foreach (DataRow item in ci.montarEquipe(eq).Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[1].Value = item["nome"].ToString().ToUpper();
                    DataGridViewComboBoxCell aux = (DataGridViewComboBoxCell)dataGridView1.Rows[n].Cells[2];
                    eq.Nome = item["nome"].ToString().ToUpper();
                    eq.Escalada = comboBox1.Text;
                    if (cq.BuscaEquipe(eq).Rows.Count > 0 && (item["nome"].ToString().ToUpper() == cq.BuscaEquipe(eq).Rows[0][1].ToString() || item["nome"].ToString() == cq.BuscaEquipe(eq).Rows[0][1].ToString()))
                    {
                        dataGridView1.Rows[n].Cells[0].Value = true;
                        aux.Value = cq.BuscaEquipe(eq).Rows[0][2].ToString();
                        if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Dirigente Gr. 01" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Dirigente Gr. 02" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Dirigente Gr. 03" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Dirigente Gr. 04" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Dirigente Gr. 05")
                        {
                            dir = dir + 1;
                            dataGridView2.Rows[0].Cells[1].Value = dir;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Auxiliar Gr. 01" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Auxiliar Gr. 02" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Auxiliar Gr. 03" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Auxiliar Gr. 04" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Auxiliar Gr. 05")
                        {
                            aur = aur + 1;
                            dataGridView2.Rows[1].Cells[1].Value = aur;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Cronometrista")
                        {
                            cro = cro + 1;
                            dataGridView2.Rows[3].Cells[1].Value = cro;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Resp. Música" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Música")
                        {
                            mus = mus + 1;
                            dataGridView2.Rows[2].Cells[1].Value = mus;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Cozinha")
                        {
                            coz = coz + 1;
                            dataGridView2.Rows[8].Cells[1].Value = coz;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Resp. Copa" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Copa")
                        {
                            cop = cop + 1;
                            dataGridView2.Rows[5].Cells[1].Value = cop;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Resp. Limpeza" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Limpeza")
                        {
                            lim = lim + 1;
                            dataGridView2.Rows[7].Cells[1].Value = lim;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Coordenador Geral")
                        {
                            cdg = cdg + 1;
                            dataGridView2.Rows[9].Cells[1].Value = cdg;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Resp. Liturgia" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Liturgia")
                        {
                            lit = lit + 1;
                            dataGridView2.Rows[4].Cells[1].Value = lit;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Resp. Secretaria" || cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Secretaria")
                        {
                            sec = sec + 1;
                            dataGridView2.Rows[6].Cells[1].Value = sec;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Casal Orientador")
                        {
                            cor = cor + 1;
                            dataGridView2.Rows[10].Cells[1].Value = cor;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Orientador Espiritual")
                        {
                            ceo = ceo + 1;
                            dataGridView2.Rows[11].Cells[1].Value = ceo;
                        }
                        else if (cq.BuscaEquipe(eq).Rows[0][2].ToString() == "Orientadora Espiritual")
                        {
                            cea = cea + 1;
                            dataGridView2.Rows[12].Cells[1].Value = cea;
                        }

                        dataGridView2.Rows[13].Cells[1].Value = Convert.ToString(dir+aur+cro+coz+cop+lim+cdg+lit+sec+mus+cor+ceo+cea);
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
                    dataGridView1.Rows[n].Cells[4].Value = item["dtNasc"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item["endereco"].ToString().ToUpper();
                    dataGridView1.Rows[n].Cells[6].Value = item["telefone"].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = item["cidade"].ToString().ToUpper();
                    dataGridView1.Rows[n].Cells[8].Value = item["cep"].ToString();
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
            dataGridView2.Rows[10].Cells[0].Value = "CASAL ORIENTADOR";
            dataGridView2.Rows[10].Cells[1].Value = cor;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[11].Cells[0].Value = "ORIENTADOR ESPIRITUAL";
            dataGridView2.Rows[11].Cells[1].Value = ceo;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[12].Cells[0].Value = "ORIENTADORA ESPIRITUAL";
            dataGridView2.Rows[12].Cells[1].Value = cea;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[13].Cells[0].Value = "TOTAL";
            dataGridView2.Rows[13].Cells[1].Value = Convert.ToString(dir + aur + mus + cro + lit + cop + sec + lim + coz + cdg);

            int prf = cd.SelecionaEscalada().Rows.Count;
            comboBox1.Items.Clear();
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
                        eq.Nome = dataGridView1.Rows[aux].Cells[1].Value.ToString().ToUpper();
                        eq.Nascimento = dataGridView1.Rows[aux].Cells[4].Value.ToString();
                        eq.Endereco = dataGridView1.Rows[aux].Cells[5].Value.ToString().ToUpper();
                        eq.Telefone = dataGridView1.Rows[aux].Cells[6].Value.ToString();
                        eq.Cidade = dataGridView1.Rows[aux].Cells[7].Value.ToString().ToUpper();
                        eq.Cep = dataGridView1.Rows[aux].Cells[8].Value.ToString();
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
                                string msg = "ALPINISTA CADASTRADO NA EQUIPE: " + dataGridView1.Rows[aux].Cells[2].Value.ToString();
                                frmMensagem mg = new frmMensagem(msg);
                                mg.ShowDialog();
                                Exibir();
                            }
                        }
                    }
                }
                else
                {
                    eq.Nome = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().ToUpper();
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
                    eq.Nome = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().ToUpper();
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
            Equipe();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Exibir();
            Equipe();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboBox1.Text == "")
            {
                string msg = "SELECIONE A ESCALADA!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                comboBox1.Focus();
            }
            else
            {
                frmAlpNaoCadastrado frm = new frmAlpNaoCadastrado(comboBox1.Text);
                frm.ShowDialog();
            }
        }
    }
}
