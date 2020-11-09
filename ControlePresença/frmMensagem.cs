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
    public partial class frmMensagem : Form
    {
        string msg;
        public frmMensagem(string mg)
        {
            InitializeComponent();
            msg = mg;
        }

        public void Fechar()
        {
            timer1.Interval = 3000;
            timer1.Start();
        }

        private void frmMensagem_Load(object sender, EventArgs e)
        {
            Fechar();
            textBox1.Text = msg;
            textBox2.Select();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("{ESC}");
            timer1.Stop();
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 27)
            {
                this.Close();
            }
        }
    }
}
