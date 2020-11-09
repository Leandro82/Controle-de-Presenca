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
    public partial class frmRelEnvNovos : Form
    {
        string msg1, msg2, caminho, escalada;
        public frmRelEnvNovos(string txt1, string txt2, string cam, string esc)
        {
            InitializeComponent();
            msg1 = txt1;
            msg2 = txt2;
            caminho = cam;
            escalada = esc;
        }

        private void frmRelEnvNovos_Load(object sender, EventArgs e)
        {
            string nomeRelatorio = "ControlePresença.Report15.rdlc";
            List<ReportParameter> arrayRP = new List<ReportParameter>();
            arrayRP.Add(new ReportParameter("mensagemUm", msg1.Trim()));
            arrayRP.Add(new ReportParameter("mensagemDois", msg2.Trim()));
            reportViewer1.LocalReport.EnableExternalImages = true;
            arrayRP.Add(new ReportParameter("imagem", @"File://" + caminho, true));
            reportViewer1.LocalReport.ReportEmbeddedResource = nomeRelatorio;
            foreach (ReportParameter rp in arrayRP)
                this.reportViewer1.LocalReport.SetParameters(rp);
            reportViewer1.LocalReport.DisplayName = "Envelope Novos";
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.envelopeNovosTableAdapter.Fill(this.escaladaDataSet3.envelopeNovos, escalada);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
    }
}
