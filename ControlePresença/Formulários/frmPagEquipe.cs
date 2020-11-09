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
    public partial class frmPagEquipe : Form
    {
        ConectaDatasEscalada cd = new ConectaDatasEscalada();
        public frmPagEquipe()
        {
            InitializeComponent();
        }

        private void frmPagEquipe_Load(object sender, EventArgs e)
        {
            int prf = cd.SelecionaEscalada().Rows.Count;
            for (int j = 0; j < prf; j++)
            {
                comboBox1.Items.Add(cd.SelecionaEscalada().Rows[j]["escalada"].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DisplayName = "Controle de Pagamento - Equipe";
            this.equipeTableAdapter.Fill(this.escaladaDataSet3.equipe, comboBox1.Text);
            reportViewer1.RefreshReport();
        }
    }
}
