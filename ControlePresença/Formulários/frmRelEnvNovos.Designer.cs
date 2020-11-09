namespace ControlePresença
{
    partial class frmRelEnvNovos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelEnvNovos));
            this.envelopeNovosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.escaladaDataSet3 = new ControlePresença.escaladaDataSet3();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.envelopeNovosTableAdapter = new ControlePresença.escaladaDataSet3TableAdapters.envelopeNovosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.envelopeNovosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escaladaDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // envelopeNovosBindingSource
            // 
            this.envelopeNovosBindingSource.DataMember = "envelopeNovos";
            this.envelopeNovosBindingSource.DataSource = this.escaladaDataSet3;
            // 
            // escaladaDataSet3
            // 
            this.escaladaDataSet3.DataSetName = "escaladaDataSet3";
            this.escaladaDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.envelopeNovosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ControlePresença.Report15.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, -1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(667, 639);
            this.reportViewer1.TabIndex = 0;
            // 
            // envelopeNovosTableAdapter
            // 
            this.envelopeNovosTableAdapter.ClearBeforeFill = true;
            // 
            // frmRelEnvNovos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 637);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRelEnvNovos";
            this.Text = "Capa de Envelope dos Novos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRelEnvNovos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.envelopeNovosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escaladaDataSet3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource envelopeNovosBindingSource;
        private escaladaDataSet3 escaladaDataSet3;
        private escaladaDataSet3TableAdapters.envelopeNovosTableAdapter envelopeNovosTableAdapter;
    }
}