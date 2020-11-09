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
    public partial class frmDividirGrupos : Form
    {
        ConectaInscritos ci = new ConectaInscritos();
        ConectaDatasEscalada cd = new ConectaDatasEscalada();
        ConectaInscritos co = new ConectaInscritos();
        Inscritos ins = new Inscritos();
        int g1, g2, g3, g4, g5, cod, ver, j = 0;
        int[] pos = new int[200];
      
        public frmDividirGrupos()
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
                ins.Escalada = comboBox1.Text;
                g1 = 0; g2 = 0; g3 = 0; g4 = 0; g5 = 0;
                foreach (DataRow item in co.sorteados(ins).Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item["nome"].ToString();
                    DataGridViewComboBoxCell aux = (DataGridViewComboBoxCell)dataGridView1.Rows[n].Cells[1];
                    aux.Value = co.sorteados(ins).Rows[n][9].ToString();
                    eq.Nome = item["nome"].ToString();
                    eq.Escalada = comboBox1.Text;
                    if (co.sorteados(ins).Rows.Count > 0 && item["nome"].ToString() == co.sorteados(ins).Rows[n][1].ToString())
                    {
                        if (co.sorteados(ins).Rows[n][9].ToString() == "Grupo 01")
                        {
                            g1 = g1 + 1;
                            dataGridView2.Rows[0].Cells[1].Value = g1;
                        }
                        else if (co.sorteados(ins).Rows[n][9].ToString() == "Grupo 02")
                        {
                            g2 = g2 + 1;
                            dataGridView2.Rows[1].Cells[1].Value = g2;
                        }
                        else if (co.sorteados(ins).Rows[n][9].ToString() == "Grupo 03")
                        {
                            g3 = g3 + 1;
                            dataGridView2.Rows[2].Cells[1].Value = g3;
                        }
                        else if (co.sorteados(ins).Rows[n][9].ToString() == "Grupo 04")
                        {
                            g4 = g4 + 1;
                            dataGridView2.Rows[3].Cells[1].Value = g4;
                        }
                        else if (co.sorteados(ins).Rows[n][9].ToString() == "Grupo 05")
                        {
                            g5 = g5 + 1;
                            dataGridView2.Rows[4].Cells[1].Value = g5;
                        }

                        dataGridView2.Rows[5].Cells[1].Value = Convert.ToString(g1 + g2 + g3 + g4 + g5);
                    }
                    aux.Items.Add("");
                    aux.Items.Add("Grupo 01");
                    aux.Items.Add("Grupo 02");
                    aux.Items.Add("Grupo 03");
                    aux.Items.Add("Grupo 04");
                    aux.Items.Add("Grupo 05");
                    dataGridView1.Rows[n].Cells[2].Value = "Salvar";
                    dataGridView1.Rows[n].Cells[3].Value = item["cod"].GetHashCode();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Exibir();
        }

        private void frmDividirGrupos_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[0].Cells[0].Value = "GRUPO 01";
            dataGridView2.Rows[0].Cells[1].Value = g1;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[1].Cells[0].Value = "GRUPO 02";
            dataGridView2.Rows[1].Cells[1].Value = g2;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[2].Cells[0].Value = "GRUPO 03";
            dataGridView2.Rows[2].Cells[1].Value = g3;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[3].Cells[0].Value = "GRUPO 04";
            dataGridView2.Rows[3].Cells[1].Value = g4;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[4].Cells[0].Value = "GRUPO 05";
            dataGridView2.Rows[4].Cells[1].Value = g5;
            dataGridView2.Rows.Add();
            dataGridView2.Rows[5].Cells[0].Value = "TOTAL";
            dataGridView2.Rows[5].Cells[1].Value = g1+g2+g3+g4+g5;

            int prf = cd.SelecionaEscalada().Rows.Count;
            for (int j = 0; j < prf; j++)
            {
                comboBox1.Items.Add(cd.SelecionaEscalada().Rows[j]["escalada"].ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Selected)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
                {
                    string msg = "ESCOLHA UM GRUPO!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
                else
                {
                    cod = dataGridView1.Rows[e.RowIndex].Cells[3].Value.GetHashCode();
                    ins.Codigo = cod;
                    ins.Nome = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().ToUpper();
                    ins.Grupo = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    co.CadastraGrupo(ins);
                    Exibir();
                    string msg = "CADASTRO ATUALIZADO!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                string msg = "BUSQUE OS DADOS PARA DIVIDIR OS GRUPOS!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value != null)
                    {
                        ver = 1;
                        pos[j] = i;
                        j = j + 1;
                    }
                }

                if (ver == 0)
                {
                    string msg = "NÃO NINGUÉM INSERIDO EM GRUPO PARA SALVAR!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
                else
                {
                    progressBar1.Visible = true;
                    progressBar1.Maximum = j;
                    for (int v = 0; v < j; v++)
                    {
                        cod = dataGridView1.Rows[pos[v]].Cells[3].Value.GetHashCode();
                        ins.Codigo = cod;
                        ins.Nome = dataGridView1.Rows[pos[v]].Cells[0].Value.ToString().ToUpper();
                        ins.Grupo = dataGridView1.Rows[pos[v]].Cells[1].Value.ToString();
                        co.CadastraGrupo(ins);
                        progressBar1.Value++;
                    }
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                    Exibir();
                    string msg = "DADOS SALVOS!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
            }
        }
    }
}
