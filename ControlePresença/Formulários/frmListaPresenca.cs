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
    public partial class frmListaPresenca : Form
    {
        ConectaDatasEscalada cd = new ConectaDatasEscalada();
        int aux;

        public frmListaPresenca()
        {
            InitializeComponent();
        }

        private void frmListaPresenca_Load(object sender, EventArgs e)
        {
            int prf = cd.SelecionaEscalada().Rows.Count;
            for (int j = 0; j < prf; j++)
            {
                comboBox1.Items.Add(cd.SelecionaEscalada().Rows[j]["escalada"].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                string msg = "Escolha um gênero";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else if(aux == 1)
            {
                reportViewer1.LocalReport.DisplayName = "Controle de Presença - Meninos";
                this.ListaTableAdapter.Fill(this.escaladaDataSet2.Lista, comboBox2.Text, comboBox1.Text);
                reportViewer1.RefreshReport();
            }
            else if (aux == 2)
            {
                reportViewer1.LocalReport.DisplayName = "Controle de Presença - Meninas";
                this.ListaTableAdapter.Fill(this.escaladaDataSet2.Lista, comboBox2.Text, comboBox1.Text);
                reportViewer1.RefreshReport();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Masculino")
            {
                aux = 1;
            }
            else if (comboBox2.Text == "Feminino")
            {
                aux = 2;
            }

            comboBox1.Text = "";
        }
    }
}
