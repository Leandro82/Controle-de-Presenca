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
    public partial class frmVerifica : Form
    {
        string dta;
        Conecta co = new Conecta();
        ConectaUsuario cs = new ConectaUsuario();
        Variavel va = new Variavel();
        Usuario us = new Usuario();
        List<string> lista = new List<string>();
        public frmVerifica()
        {
            InitializeComponent();
        }

        private void frmVerifica_Load(object sender, EventArgs e)
        {
            this.comboBox1.DisplayMember = "nomeMaisculo";
            this.comboBox1.DataSource = co.Falta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            us.Nome = comboBox1.Text;
            int cont = co.CarregaDatas().Rows.Count;
            int i = 0, data = 0, aux = 0, col = 1;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            DataGridViewColumn grid = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add("nomeMaisculo", "Nome");
            this.dataGridView1.Rows.Insert(0, comboBox1.Text);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida Bright",11, FontStyle.Bold);           
            while (i < cont)
            {
                data = data + 1;
                i = i + 1;
            }

            foreach (DataRow item in co.pesquisaFalta(us).Rows)
            {
                for (int j = 0; j < cont; j++)
                {
                    us.Nome = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    dta = "data" + Convert.ToDateTime(co.CarregaDatas().Rows[j]["data"].ToString()).ToString("ddMMyyyy");
                    if (Convert.ToDateTime(Convert.ToDateTime(co.CarregaDatas().Rows[j]["data"].ToString()).ToString("dd/MM/yyyy")) >= Convert.ToDateTime(Convert.ToDateTime(cs.faltaApinista(us).Rows[aux]["dtCad"].ToString()).ToString("dd/MM/yyyy")))
                    {
                        if (item[dta].ToString() == "F" || item[dta].ToString() == "")
                        {
                            dataGridView1.Columns.Add("colum"+col, Convert.ToDateTime(co.CarregaDatas().Rows[j]["data"].ToString()).ToString("dd/MM/yyyy"));
                            dataGridView1.Columns["colum" + col].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridView1.Columns["colum"+col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridView1.RowsDefaultCellStyle.Font = new Font("Lucida Bright", 11);
                            dataGridView1.Rows[0].Cells[col].Value = "F";
                            col = col + 1;
                        }
                    }
                }
            }
        }
    }
}
