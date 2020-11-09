namespace ControlePresença
{
    partial class frmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chamadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeAlpinistasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porEscaladaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porAlpinistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarUsuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisarUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porcentagemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porcentagemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.faltasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.correçãoDeFaltasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.agendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.escaladaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscritosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chamadaToolStripMenuItem,
            this.cadastroDeAlpinistasToolStripMenuItem,
            this.porcentagemToolStripMenuItem,
            this.agendaToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.escaladaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(817, 26);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chamadaToolStripMenuItem
            // 
            this.chamadaToolStripMenuItem.Name = "chamadaToolStripMenuItem";
            this.chamadaToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.chamadaToolStripMenuItem.Text = "Chamada";
            this.chamadaToolStripMenuItem.Click += new System.EventHandler(this.chamadaToolStripMenuItem_Click);
            // 
            // cadastroDeAlpinistasToolStripMenuItem
            // 
            this.cadastroDeAlpinistasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porEscaladaToolStripMenuItem,
            this.porAlpinistaToolStripMenuItem,
            this.datasToolStripMenuItem1,
            this.usuáriosToolStripMenuItem});
            this.cadastroDeAlpinistasToolStripMenuItem.Name = "cadastroDeAlpinistasToolStripMenuItem";
            this.cadastroDeAlpinistasToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cadastroDeAlpinistasToolStripMenuItem.Text = "Cadastros";
            // 
            // porEscaladaToolStripMenuItem
            // 
            this.porEscaladaToolStripMenuItem.Name = "porEscaladaToolStripMenuItem";
            this.porEscaladaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.porEscaladaToolStripMenuItem.Text = "Alpinistas";
            this.porEscaladaToolStripMenuItem.Click += new System.EventHandler(this.porEscaladaToolStripMenuItem_Click);
            // 
            // porAlpinistaToolStripMenuItem
            // 
            this.porAlpinistaToolStripMenuItem.Name = "porAlpinistaToolStripMenuItem";
            this.porAlpinistaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.porAlpinistaToolStripMenuItem.Text = "Digital";
            this.porAlpinistaToolStripMenuItem.Click += new System.EventHandler(this.porAlpinistaToolStripMenuItem_Click);
            // 
            // datasToolStripMenuItem1
            // 
            this.datasToolStripMenuItem1.Name = "datasToolStripMenuItem1";
            this.datasToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.datasToolStripMenuItem1.Text = "Datas";
            this.datasToolStripMenuItem1.Click += new System.EventHandler(this.datasToolStripMenuItem1_Click);
            // 
            // usuáriosToolStripMenuItem
            // 
            this.usuáriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarUsuáriosToolStripMenuItem,
            this.pesquisarUsuárioToolStripMenuItem});
            this.usuáriosToolStripMenuItem.Name = "usuáriosToolStripMenuItem";
            this.usuáriosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.usuáriosToolStripMenuItem.Text = "Usuários";
            // 
            // cadastrarUsuáriosToolStripMenuItem
            // 
            this.cadastrarUsuáriosToolStripMenuItem.Name = "cadastrarUsuáriosToolStripMenuItem";
            this.cadastrarUsuáriosToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.cadastrarUsuáriosToolStripMenuItem.Text = "Cadastrar Usuário";
            this.cadastrarUsuáriosToolStripMenuItem.Click += new System.EventHandler(this.cadastrarUsuáriosToolStripMenuItem_Click);
            // 
            // pesquisarUsuárioToolStripMenuItem
            // 
            this.pesquisarUsuárioToolStripMenuItem.Name = "pesquisarUsuárioToolStripMenuItem";
            this.pesquisarUsuárioToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.pesquisarUsuárioToolStripMenuItem.Text = "Pesquisar Usuário";
            this.pesquisarUsuárioToolStripMenuItem.Click += new System.EventHandler(this.pesquisarUsuárioToolStripMenuItem_Click);
            // 
            // porcentagemToolStripMenuItem
            // 
            this.porcentagemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porcentagemToolStripMenuItem1,
            this.faltasToolStripMenuItem,
            this.correçãoDeFaltasToolStripMenuItem1,
            this.toolStripMenuItem1});
            this.porcentagemToolStripMenuItem.Name = "porcentagemToolStripMenuItem";
            this.porcentagemToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.porcentagemToolStripMenuItem.Text = "Frequência";
            // 
            // porcentagemToolStripMenuItem1
            // 
            this.porcentagemToolStripMenuItem1.Name = "porcentagemToolStripMenuItem1";
            this.porcentagemToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            this.porcentagemToolStripMenuItem1.Text = "Porcentagem";
            this.porcentagemToolStripMenuItem1.Click += new System.EventHandler(this.porcentagemToolStripMenuItem1_Click);
            // 
            // faltasToolStripMenuItem
            // 
            this.faltasToolStripMenuItem.Name = "faltasToolStripMenuItem";
            this.faltasToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.faltasToolStripMenuItem.Text = "Faltas";
            this.faltasToolStripMenuItem.Click += new System.EventHandler(this.faltasToolStripMenuItem_Click);
            // 
            // correçãoDeFaltasToolStripMenuItem1
            // 
            this.correçãoDeFaltasToolStripMenuItem1.Name = "correçãoDeFaltasToolStripMenuItem1";
            this.correçãoDeFaltasToolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            this.correçãoDeFaltasToolStripMenuItem1.Text = "Correção de Faltas";
            this.correçãoDeFaltasToolStripMenuItem1.Click += new System.EventHandler(this.correçãoDeFaltasToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(229, 22);
            this.toolStripMenuItem1.Text = "Deletar Inativos";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // agendaToolStripMenuItem
            // 
            this.agendaToolStripMenuItem.Name = "agendaToolStripMenuItem";
            this.agendaToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.agendaToolStripMenuItem.Text = "Agenda";
            this.agendaToolStripMenuItem.Click += new System.EventHandler(this.agendaToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarToolStripMenuItem,
            this.importarToolStripMenuItem});
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(79, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exportarToolStripMenuItem.Text = "Exportar";
            this.exportarToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
            // 
            // importarToolStripMenuItem
            // 
            this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
            this.importarToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.importarToolStripMenuItem.Text = "Importar";
            this.importarToolStripMenuItem.Click += new System.EventHandler(this.importarToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "“Backup Controle de Frequência (“.bk)|”.bk|All files(“.”)|”.””";
            // 
            // escaladaToolStripMenuItem
            // 
            this.escaladaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inscritosToolStripMenuItem});
            this.escaladaToolStripMenuItem.Name = "escaladaToolStripMenuItem";
            this.escaladaToolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.escaladaToolStripMenuItem.Text = "Escalada";
            // 
            // inscritosToolStripMenuItem
            // 
            this.inscritosToolStripMenuItem.Name = "inscritosToolStripMenuItem";
            this.inscritosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.inscritosToolStripMenuItem.Text = "Inscritos";
            this.inscritosToolStripMenuItem.Click += new System.EventHandler(this.inscritosToolStripMenuItem_Click);
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(817, 420);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInicio";
            this.Text = "Controle de Presença";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInicio_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeAlpinistasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porEscaladaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porAlpinistaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem chamadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porcentagemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porcentagemToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem faltasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarUsuáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesquisarUsuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem correçãoDeFaltasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem agendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem escaladaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscritosToolStripMenuItem;
    }
}