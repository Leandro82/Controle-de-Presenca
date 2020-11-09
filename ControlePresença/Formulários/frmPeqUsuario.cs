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
    public partial class frmPeqUsuario : Form
    {
        ConectaUsuario cs = new ConectaUsuario();
        public frmPeqUsuario()
        {
            InitializeComponent();
        }

        private void frmPeqUsuario_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (DataRow item in cs.buscaUsuario().Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["nome"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["login"].ToString();
            }
        }


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string nome = dataGridView1[0, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            string login = dataGridView1[1, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            string aux = "ok";
            var form = new frmCadUsuario(nome, login, aux);
            form.Show();
        }
    }
}
