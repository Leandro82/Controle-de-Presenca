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
    public partial class frmSortMeninasOcz : Form
    {
        ConectaInscritos ci = new ConectaInscritos();
        int num;
        public frmSortMeninasOcz(int aux)
        {
            InitializeComponent();
            num = aux;
        }

        private void frmSortMeninasOcz_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'escaladaDataSet11.inscritos' table. You can move, or remove it, as needed.
            this.inscritosTableAdapter1.Fill(this.escaladaDataSet11.inscritos);
            // TODO: This line of code loads data into the 'escaladaDataSet11.inscritos' table. You can move, or remove it, as needed.
            this.inscritosTableAdapter1.Fill(this.escaladaDataSet11.inscritos);
            var fieldInfo = typeof(Microsoft.Reporting.WinForms.RenderingExtension).GetField("m_isVisible", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            foreach (var extension in this.reportViewer1.LocalReport.ListRenderingExtensions())
            {
                if (string.Compare("EXCELOPENXML", extension.Name) == 0)
                    fieldInfo.SetValue(extension, false);
            }

            if (num == 1)
            {

                reportViewer1.LocalReport.DisplayName = "Meninas de Osvaldo Cruz";
                this.inscritosTableAdapter1.Fill(this.escaladaDataSet11.inscritos);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
            else if (num == 2)
            {
                reportViewer1.LocalReport.DisplayName = "Meninos de Osvaldo Cruz";
                this.inscritosTableAdapter1.FillBy(this.escaladaDataSet11.inscritos);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
            else if (num == 3)
            {
                reportViewer1.LocalReport.DisplayName = "Meninas de outras cidades";
                this.inscritosTableAdapter1.FillBy1(this.escaladaDataSet11.inscritos);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
            else if (num == 4)
            {
                reportViewer1.LocalReport.DisplayName = "Meninos de outras cidades";
                this.inscritosTableAdapter1.FillBy2(this.escaladaDataSet11.inscritos);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                reportViewer1.RefreshReport();
            }
        }
    }
}
