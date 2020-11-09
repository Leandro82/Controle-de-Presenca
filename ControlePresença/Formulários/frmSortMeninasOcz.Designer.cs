
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSortMeninasOcz));
            this.inscritosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.escaladaDataSet11 = new ControlePresença.escaladaDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.inscritosTableAdapter1 = new ControlePresença.escaladaDataSet1TableAdapters.inscritosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.inscritosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.escaladaDataSet11)).BeginInit();
            this.SuspendLayout();
            // 
            // inscritosBindingSource
            // 
            this.inscritosBindingSource.DataMember = "inscritos";
            this.inscritosBindingSource.DataSource = this.escaladaDataSet11;
            // 
            // escaladaDataSet11
            // 
            this.escaladaDataSet11.DataSetName = "escaladaDataSet1";
            this.escaladaDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.inscritosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ControlePresença.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(558, 483);
            this.reportViewer1.TabIndex = 0;
            // 
            // inscritosTableAdapter1
            // 
            this.inscritosTableAdapter1.ClearBeforeFill = true;
            // 
            // frmSortMeninasOcz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 483);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSortMeninasOcz";
            this.Text = "frmSortMeninasOcz";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSortMeninasOcz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inscritosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.escaladaDataSet11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        //private escaladaDataSet1 escaladaDataSet1;
        //private escaladaDataSet1TableAdapters.inscritosTableAdapter inscritosTableAdapter;
        private escaladaDataSet1 escaladaDataSet11;
        private System.Windows.Forms.BindingSource inscritosBindingSource;
        private escaladaDataSet1TableAdapters.inscritosTableAdapter inscritosTableAdapter1;
    }
}