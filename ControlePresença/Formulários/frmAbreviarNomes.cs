using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ControlePresença
{
    public partial class frmAbreviarNomes : Form
    {
        ConectaDatasEscalada cd = new ConectaDatasEscalada();
        ConectaInscritos ci = new ConectaInscritos();
        Inscritos ins = new Inscritos();
        ConectaEquipe ce = new ConectaEquipe();
        Cracha cr = new Cracha();
        Equipe eq = new Equipe();
        string esc;
        public frmAbreviarNomes()
        {
            InitializeComponent();
        }

        public static string Abreviatte(string nome)
        {
            var meio = " ";
            var nomes = nome.Split(' ');
            for (var i = 1; i < nomes.Length - 1; i++)
            {
                if (!nomes[i].Equals("de", StringComparison.OrdinalIgnoreCase) &&
                    !nomes[i].Equals("da", StringComparison.OrdinalIgnoreCase) &&
                    !nomes[i].Equals("do", StringComparison.OrdinalIgnoreCase) &&
                    !nomes[i].Equals("das", StringComparison.OrdinalIgnoreCase) &&
                    !nomes[i].Equals("dos", StringComparison.OrdinalIgnoreCase))
                    meio += nomes[i][0] + ". ";
            }
            return nomes[0] + meio + nomes[nomes.Length - 1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            eq.Escalada = comboBox1.Text;
            foreach (DataRow item in ce.montarCracha(eq).Rows)
            {
                int n = dataGridView1.Rows.Add();
                string nome = item["nome"].ToString();
                string primeiro = "";
                string meio = " "; // Sim, tem um espaço aqui!
                string ultimo = "";

                string[] nomes = nome.Split(' '); // Separa cada nome pelo espaço.

                primeiro = nomes[0]; // Reserva o primeiro nome.

                if (primeiro != "Pe.")
                {
                    for (int i = 1; i < nomes.Length - 1; i++)
                    {
                        if (!nomes[i].ToLower().Equals("de") && !nomes[i].ToLower().Equals("da") && !nomes[i].ToLower().Equals("do") && !nomes[i].ToLower().Equals("das") && !nomes[i].ToLower().Equals("dos") && !nomes[i].ToLower().Equals("e"))
                        {
                            if (nomes[i] != "")
                            {
                                meio += nomes[i].Substring(0, 1); // Reserva a inicial do próximo nome.
                                meio += ". "; // Põe um ponto e um espaço após a inicial.
                            }
                        }
                        else
                        {
                            meio += nomes[i] + " ";
                        }
                    }

                    ultimo = nomes[nomes.Length - 1]; // Reserva o ultimo nome.

                    nome = primeiro + meio + ultimo; // Junta todos os nomes.
                    if (nome.ToUpper() == "PE. J. LUÍS" || nome.ToUpper() == "PE. J. LUIS")
                    {
                        dataGridView1.Rows[n].Cells[0].Value = "PE. JOSÉ LUÍS";
                    }
                    else
                    {
                        dataGridView1.Rows[n].Cells[0].Value = nome.ToUpper();
                    }
                }
                else
                {
                    dataGridView1.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                }
                dataGridView1.Rows[n].Cells[1].Value = item["funcao"].ToString().ToUpper();
                esc = item["escalada"].ToString().ToUpper();
            }

            if (dataGridView1.Rows.Count == 0)
            {
                string msg = "AINDA NÃO HÁ ALPINISTAS CADASTRADOS PARA ESTA ESCALADA!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                label1.Visible = true;
                progressBar1.Visible = true;
                cr.Escalada = comboBox1.Text;
                ce.limparCracha(cr);

                progressBar1.Maximum = 0;
                progressBar1.Maximum = dataGridView1.Rows.Count;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    cr.Nome = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    cr.Grupo = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    cr.Escalada = esc;
                    ce.cadastrarCracha(cr);
                    progressBar1.Value++;
                }
                label1.Text = "Pronto para gerar os crachás!!";
                progressBar1.Visible = false;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
            }
        }

        private void frmAbreviarNomes_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label1.Visible = false;
            progressBar1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;

            int prf = cd.SelecionaEscalada().Rows.Count;
            for (int j = 0; j < prf; j++)
            {
                comboBox1.Items.Add(cd.SelecionaEscalada().Rows[j]["escalada"].ToString());
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCrachaQuarto frm = new frmCrachaQuarto(1);
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCrachaQuarto frm = new frmCrachaQuarto(2);
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmCrachaPeito frm = new frmCrachaPeito(1);
            frm.Text = "Crachás dos novos Alpinistas";
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmCrachaPeito frm = new frmCrachaPeito(2);
            frm.Text = "Crachás da Equipe de Trabalho";
            frm.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

    }

}
