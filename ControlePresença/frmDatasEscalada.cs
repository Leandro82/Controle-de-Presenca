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
    public partial class frmDatasEscalada : Form
    {
        DatasEscalada dt = new DatasEscalada();
        ConectaDatasEscalada cd = new ConectaDatasEscalada();

        public frmDatasEscalada()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && !maskedTextBox1.MaskCompleted && !maskedTextBox2.MaskCompleted && !maskedTextBox3.MaskCompleted && !maskedTextBox4.MaskCompleted && !maskedTextBox5.MaskCompleted && !maskedTextBox6.MaskCompleted && !maskedTextBox7.MaskCompleted)
            {
                string msg = "PREENCHA TODOS OS CAMPOS!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                dt.Escalada = Convert.ToInt32(textBox1.Text);
                dt.DataEscalada = maskedTextBox5.Text;
                dt.PrimeiraNovos = maskedTextBox1.Text;
                dt.SegundaNovos = maskedTextBox2.Text;
                dt.TerceiraNovos = maskedTextBox3.Text;
                dt.Caminhada = maskedTextBox4.Text;
                dt.PrimeiraPais = maskedTextBox6.Text;
                dt.SegundaPais = maskedTextBox7.Text;
                cd.cadastro(dt);
                string msg = "DATAS CADASTRADAS!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();

                textBox1.Clear();
                maskedTextBox5.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                maskedTextBox3.Clear();
                maskedTextBox4.Clear();
                maskedTextBox6.Clear();
                maskedTextBox7.Clear();
            }
        }

        private void frmDatasEscalada_Load(object sender, EventArgs e)
        {
            maskedTextBox5.Focus();
            textBox1.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Salvar")
            {
                if (textBox1.Text == "" && !maskedTextBox1.MaskCompleted && !maskedTextBox2.MaskCompleted && !maskedTextBox3.MaskCompleted && !maskedTextBox4.MaskCompleted && !maskedTextBox5.MaskCompleted && !maskedTextBox6.MaskCompleted && !maskedTextBox7.MaskCompleted)
                {
                    string msg = "PREENCHA TODOS OS CAMPOS!!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
                else
                {
                    dt.Escalada = Convert.ToInt32(textBox1.Text);
                    dt.DataEscalada = maskedTextBox5.Text;
                    dt.PrimeiraNovos = maskedTextBox1.Text;
                    dt.SegundaNovos = maskedTextBox2.Text;
                    dt.TerceiraNovos = maskedTextBox3.Text;
                    dt.Caminhada = maskedTextBox4.Text;
                    dt.PrimeiraPais = maskedTextBox6.Text;
                    dt.SegundaPais = maskedTextBox7.Text;
                    cd.atualizarDatas(dt);
                    string msg = "DATAS ATUALIZADAS!!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();

                    button6.Text = "Editar";
                    button5.Enabled = true;
                    textBox1.Clear();
                    maskedTextBox5.Clear();
                    maskedTextBox1.Clear();
                    maskedTextBox2.Clear();
                    maskedTextBox3.Clear();
                    maskedTextBox4.Clear();
                    maskedTextBox6.Clear();
                    maskedTextBox7.Clear();
                }
            }
            else
            {
                textBox1.BackColor = Color.Yellow;
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.BackColor == Color.Yellow)
                {
                    button5.Enabled = false;
                    dt.Escalada = Convert.ToInt32(textBox1.Text);

                    if (cd.BuscarDatas(dt).Rows.Count > 0)
                    {
                        textBox1.BackColor = Color.White;
                        button6.Text = "Salvar";

                        maskedTextBox5.Text = cd.BuscarDatas(dt).Rows[0]["dtescalada"].ToString();
                        maskedTextBox1.Text = Convert.ToString(Convert.ToDateTime(cd.BuscarDatas(dt).Rows[0]["pdtnovos"].ToString()).ToString("dd/MM/yyyy"));
                        maskedTextBox2.Text = Convert.ToString(Convert.ToDateTime(cd.BuscarDatas(dt).Rows[0]["sdtnovos"].ToString()).ToString("dd/MM/yyyy"));
                        maskedTextBox3.Text = Convert.ToString(Convert.ToDateTime(cd.BuscarDatas(dt).Rows[0]["tdtnovos"].ToString()).ToString("dd/MM/yyyy"));
                        maskedTextBox4.Text = Convert.ToString(Convert.ToDateTime(cd.BuscarDatas(dt).Rows[0]["dtcaminhada"].ToString()).ToString("dd/MM/yyyy"));
                        maskedTextBox6.Text = Convert.ToString(Convert.ToDateTime(cd.BuscarDatas(dt).Rows[0]["pdtpais"].ToString()).ToString("dd/MM/yyyy"));
                        maskedTextBox7.Text = Convert.ToString(Convert.ToDateTime(cd.BuscarDatas(dt).Rows[0]["sdtpais"].ToString()).ToString("dd/MM/yyyy"));
                    }
                    else
                    {
                        string msg = "AINDA NÃO HÁ DATAS CADASTRADAS PARA ESTA ESCALADA!!";
                        frmMensagem mg = new frmMensagem(msg);
                        mg.ShowDialog();
                        textBox1.Clear();
                        textBox1.BackColor = Color.White;
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            button5.Enabled = true;
            button6.Text = "Editar";
            textBox1.Clear();
            maskedTextBox5.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            maskedTextBox6.Clear();
            maskedTextBox7.Clear();
        }
    }
}
