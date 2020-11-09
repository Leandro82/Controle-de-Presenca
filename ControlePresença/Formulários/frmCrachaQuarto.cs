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
    public partial class frmCrachaQuarto : Form
    {
        ConectaDatasEscalada cd = new ConectaDatasEscalada();
        int aux;
        public frmCrachaQuarto(int pg)
        {
            InitializeComponent();
            aux = pg;
        }

        private void frmCrachaQuarto_Load(object sender, EventArgs e)
        {
            int prf = cd.SelecionaEscalada().Rows.Count;
            for (int j = 0; j < prf; j++)
            {
                comboBox1.Items.Add(cd.SelecionaEscalada().Rows[j]["escalada"].ToString());
            }      
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'escaladaDataSet3.cracha' table. You can move, or remove it, as needed.
            if (aux == 1)
            {
                reportViewer1.LocalReport.DisplayName = "Crachás de Mesa";
                this.crachaTableAdapter.Fill(this.escaladaDataSet3.cracha, comboBox1.Text);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                this.reportViewer1.RefreshReport();
            }
            else if (aux == 2)
            {
                reportViewer1.LocalReport.DisplayName = "Crachás de Quarto";
                this.crachaTableAdapter.FillBy(this.escaladaDataSet3.cracha, comboBox1.Text);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                this.reportViewer1.RefreshReport();
            }
        }
        
    }
}
