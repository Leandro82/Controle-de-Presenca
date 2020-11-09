namespace ControlePresença
{
    partial class frmSortMeninasOcz
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.escaladaDataSet1 = new ControlePresença.escaladaDataSet1();
            this.inscritosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inscritosTableAdapter = new ControlePresença.escaladaDataSet1TableAdapters.inscritosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.escaladaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inscritosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.inscritosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ControlePresença.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 55);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(559, 427);
            this.reportViewer1.TabIndex = 0;
            // 
            // escaladaDataSet1
            // 
            this.escaladaDataSet1.DataSetName = "escaladaDataSet1";
            this.escaladaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inscritosBindingSource
            // 
            this.inscritosBindingSource.DataMember = "inscritos";
            this.inscritosBindingSource.DataSource = this.escaladaDataSet1;
            // 
            // inscritosTableAdapter
            // 
            this.inscritosTableAdapter.ClearBeforeFill = true;
            // 
            // frmSortMeninasOcz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 483);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmSortMeninasOcz";
            this.Text = "frmSortMeninasOcz";
            this.Load += new System.EventHandler(this.frmSortMeninasOcz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.escaladaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inscritosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource inscritosBindingSource;
        private escaladaDataSet1 escaladaDataSet1;
        private escaladaDataSet1TableAdapters.inscritosTableAdapter inscritosTableAdapter;
    }
}