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
    public partial class frmRelAgenda : Form
    {
        ConectaAgenda ag = new ConectaAgenda();
        string dt = "";
        public frmRelAgenda()
        {
            InitializeComponent();
        }

        private void frmRelAgenda_Load(object sender, EventArgs e)
        {
            if (ag.BuscarAnos().Rows.Count > 0)
            {
                comboBox1.Items.Clear();
                foreach (DataRow ano1 in ag.BuscarAnos().Rows)
                {
                    comboBox1.Items.Add(Convert.ToString(ano1["ano"].GetHashCode()));
                    if (ano1["ano"].GetHashCode() == Convert.ToInt32(DateTime.Now.Year))
                        dt = "ok";
                }
            }

            if (dt == "ok")
            {
                comboBox1.SelectedIndex = comboBox1.FindString(Convert.ToString(Convert.ToInt32(DateTime.Now.Year)));
            }

            string nomeDinamico = "Calendário Escalada";

            reportViewer1.LocalReport.DisplayName = nomeDinamico;
            // TODO: This line of code loads data into the 'escaladaDataSet.agenda' table. You can move, or remove it, as needed.
            if (comboBox1.Text != "")
            {
                this.agendaTableAdapter.Fill(this.escaladaDataSet.agenda, Convert.ToInt32(comboBox1.Text));

                this.reportViewer1.RefreshReport();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'escaladaDataSet.agenda' table. You can move, or remove it, as needed.
            if (comboBox1.Text != "")
            {
                this.agendaTableAdapter.Fill(this.escaladaDataSet.agenda, Convert.ToInt32(comboBox1.Text));

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
