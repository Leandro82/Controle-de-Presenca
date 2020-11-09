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
    public partial class frmLembrete : Form
    {
        string msg;
        public frmLembrete(string ms)
        {
            InitializeComponent();
            msg = ms;
        }

        private void frmLembrete_Load(object sender, EventArgs e)
        {
            textBox1.Text = msg;
            button1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
