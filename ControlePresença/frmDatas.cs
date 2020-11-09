using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ControlePresença
{
    public partial class frmDatas : Form
    {
        Variavel va = new Variavel();
        ConectaAgenda ag = new ConectaAgenda();
        int aux = 0;
        public frmDatas()
        {
            InitializeComponent();
        }

        public void TrocaCor()
        {
            timer1.Start();
            timer1.Enabled = true;
        }

        private void frmDatas_Load(object sender, EventArgs e)
        {
            string mes = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(Convert.ToInt32(DateTime.Today.ToString("MM"))).ToLower();
            label2.Text = "Agenda do mês de "+ mes + " de " + DateTime.Today.ToString("yyyy");
            va.Data = DateTime.Now;
            foreach (DataRow data in ag.BuscarDatasMes(va).Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = Convert.ToDateTime(data["data"].ToString()).ToString("dd/MM/yyyy");
                dataGridView1.Rows[n].Cells[2].Value = data["responsavel"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = data["evento"].ToString();
            }
            TrocaCor();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            AuxClas.Data = dataGridView1[0, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            AuxClas.Observacao = dataGridView1[2, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            AuxClas.Palestrante = dataGridView1[1, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            form.Atualiza();
            form.Show();
            this.Close();
        }

        private void frmDatas_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = new Form1();
            if (Application.OpenForms.OfType<Form1>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (aux == 0)
            {
                label2.ForeColor = Color.Yellow;
                aux = 1;
            }
            else
            {
                label2.ForeColor = Color.MidnightBlue;
                aux = 0;
            }

            TrocaCor();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            /*int x = (panel1.Size.Width - label2.Width) / 2;
            int y = (panel1.Size.Height - label2.Height) / 2;

            label2.Location = new Point(x, y);*/
        }

        private void label2_SizeChanged(object sender, EventArgs e)
        {
            label2.Left = (this.ClientSize.Width - label2.Size.Width) / 2;
        }
    }
}
