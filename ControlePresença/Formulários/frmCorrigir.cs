using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ControlePresença
{
    public partial class frmCorrigir : Form
    {
        Variavel va = new Variavel();
        Conecta co = new Conecta();
        int cont;
        public frmCorrigir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cont = 0;
            string dta = ("data" + Convert.ToDateTime(dateTimePicker1.Text).ToString("ddMMyyyy"));
            va.Corrigir = dta;
            dataGridView1.Rows.Clear();
            if (co.PresencaDia(va).Rows[0][0].ToString() == "Não houve reunião nesta data")
            {
                string msg = "Não houve reunião nesta data!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                foreach (DataRow item in co.PresencaDia(va).Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item["nome"].ToString().ToUpper();
                    if (item[dta].ToString() == "P")
                    {
                        dataGridView1.Rows[n].Cells[1].Value = true;
                        cont = cont + 1;
                    }
                }
            }
            label3.Text = Convert.ToString(cont);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[1].Index)
            {
                dataGridView1.EndEdit();  //Stop editing of cell.

                string dta = ("data" + Convert.ToDateTime(dateTimePicker1.Text).ToString("ddMMyyyy"));
                DataGridViewCheckBoxCell cell;

                cell = dataGridView1.Rows[e.RowIndex].Cells[1] as DataGridViewCheckBoxCell;// linha.Cells["nomeDaColuna"] ou linha.Cells[0]
                bool bChecked = (null != cell && null != cell.Value && true == (bool)cell.Value);
                if (bChecked == true)
                {
                    va.Opcao = "P";
                    va.Presenca = "P";
                    va.Nome = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    va.Corrigir = dta;
                    co.presencaporPessoa(va);
                    cont = cont + 1;
                    label3.Text = Convert.ToString(cont);
                    string msg = "Presença Registrada";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
                else
                {                  
                    va.Opcao = "F";
                    va.Nome = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    va.Corrigir = dta;
                    co.presencaporPessoa(va);
                    cont = cont - 1;
                    label3.Text = Convert.ToString(cont);
                    string msg = "Falta Registrada";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = "";
        }
    }
}
