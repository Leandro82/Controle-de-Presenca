namespace ControlePresença
{
    partial class frmRelEnvEquipe
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelEnvEquipe));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.envelopeEquipeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.escaladaDataSet3 = new ControlePresença.escaladaDataSet3();
            this.envelopeEquipeTableAdapter = new ControlePresença.escaladaDataSet3TableAdapters.envelopeEquipeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.envelopeEquipeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escaladaDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.envelopeEquipeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ControlePresença.Report14.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(667, 638);
            this.reportViewer1.TabIndex = 0;
            // 
            // envelopeEquipeBindingSource
            // 
            this.envelopeEquipeBindingSource.DataMember = "envelopeEquipe";
            this.envelopeEquipeBindingSource.DataSource = this.escaladaDataSet3;
            // 
            // escaladaDataSet3
            // 
            this.escaladaDataSet3.DataSetName = "escaladaDataSet3";
            this.escaladaDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // envelopeEquipeTableAdapter
            // 
            this.envelopeEquipeTableAdapter.ClearBeforeFill = true;
            // 
            // frmRelEnvEquipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 637);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRelEnvEquipe";
            this.Text = "Capas de Envelope da Equipe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRelEnvEquipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.envelopeEquipeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escaladaDataSet3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource envelopeEquipeBindingSource;
        private escaladaDataSet3 escaladaDataSet3;
        private escaladaDataSet3TableAdapters.envelopeEquipeTableAdapter envelopeEquipeTableAdapter;

    }
}