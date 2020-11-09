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
        public frmSortMeninasOcz()
        {
            InitializeComponent();
        }

        private void frmSortMeninasOcz_Load(object sender, EventArgs e)
        {
            foreach (DataRow item in ci.sorteioMeninas().Rows)
            {
                this.inscritosTableAdapter.Fill(this.escaladaDataSet1.inscritos);
                reportViewer1.RefreshReport();
            }   
        }
    }
}
