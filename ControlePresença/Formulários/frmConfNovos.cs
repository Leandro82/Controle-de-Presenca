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
    public partial class frmConfNovos : Form
    {
        ConectaDatasEscalada cd = new ConectaDatasEscalada();
        public frmConfNovos()
        {
            InitializeComponent();
        }

        private void frmConfNovos_Load(object sender, EventArgs e)
        {
            int prf = cd.SelecionaEscalada().Rows.Count;
            for (int j = 0; j < prf; j++)
            {
                comboBox1.Items.Add(cd.SelecionaEscalada().Rows[j]["escalada"].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DisplayName = "Dados para Conferência - Novos";
            this.sorteadosTableAdapter.FillBy(this.escaladaDataSet3.sorteados, comboBox1.Text);
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
        }
    }
}
