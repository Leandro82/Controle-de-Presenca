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
            if (textBox1.Text == "" && !maskedTextBox1.MaskCompleted && !maskedTextBox2.MaskCompleted && !maskedTextBox3.MaskCompleted && !maskedTextBox4.MaskCompleted && !maskedTextBox5.MaskCompleted && !maskedTextBox6.MaskCompleted && !maskedTextBox7.MaskCompleted && !maskedTextBox8.MaskCompleted && !maskedTextBox9.MaskCompleted)
            {
                string msg = "PREENCHA TODOS OS CAMPOS!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                dt.Escalada = textBox1.Text;
                if (radioButton1.Checked == true)
                    dt.DataEscalada = maskedTextBox5.Text;
                else if (radioButton2.Checked == true)
                    dt.DataEscalada = maskedTextBox8.Text;
                else if (radioButton3.Checked == true)
                    dt.DataEscalada = maskedTextBox9.Text;
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
                maskedTextBox8.Clear();
                maskedTextBox9.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                maskedTextBox5.Enabled = false;
                maskedTextBox8.Enabled = false;
                maskedTextBox9.Enabled = false;
            }
        }

        private void frmDatasEscalada_Load(object sender, EventArgs e)
        {
            label12.Visible = false;
            maskedTextBox5.Enabled = false;
            maskedTextBox8.Enabled = false;
            maskedTextBox9.Enabled = false;
            textBox1.Focus();

            foreach (DataRow item in cd.Escaladas().Rows)
            { 
                 int n = dataGridView1.Rows.Add();
                 dataGridView1.Rows[n].Cells[0].Value = item["cod"].GetHashCode();
                 dataGridView1.Rows[n].Cells[1].Value = item["escalada"].ToString();
                 if (item["ocultar"].ToString() == "Ok")
                 {
                     dataGridView1.Rows[n].Cells[2].Value = true;
                 }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Salvar")
            {
                if (textBox1.Text == "" && !maskedTextBox1.MaskCompleted && !maskedTextBox2.MaskCompleted && !maskedTextBox3.MaskCompleted && !maskedTextBox4.MaskCompleted && !maskedTextBox5.MaskCompleted && !maskedTextBox6.MaskCompleted && !maskedTextBox7.MaskCompleted && !maskedTextBox8.MaskCompleted && !maskedTextBox9.MaskCompleted)
                {
                    string msg = "PREENCHA TODOS OS CAMPOS!!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
                else
                {
                    dt.Escalada = textBox1.Text;
                    if (radioButton1.Checked == true)
                        dt.DataEscalada = maskedTextBox5.Text;
                    else if (radioButton2.Checked == true)
                        dt.DataEscalada = maskedTextBox8.Text;
                    else if (radioButton3.Checked == true)
                        dt.DataEscalada = maskedTextBox9.Text;
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
                    maskedTextBox8.Clear();
                    maskedTextBox9.Clear();
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    maskedTextBox5.Enabled = false;
                    maskedTextBox8.Enabled = false;
                    maskedTextBox9.Enabled = false;
                }
            }
            else
            {
                label12.Visible = true;
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
                    label12.Visible = false;
                    button5.Enabled = false;
                    dt.Escalada = textBox1.Text;

                    if (cd.BuscarDatas(dt).Rows.Count > 0)
                    {
                        textBox1.BackColor = Color.White;
                        button6.Text = "Salvar";
                        if (cd.BuscarDatas(dt).Rows[0]["dtescalada"].ToString().Length == 19)
                        {
                            radioButton1.Checked = true;
                            maskedTextBox5.Text = cd.BuscarDatas(dt).Rows[0]["dtescalada"].ToString();
                            maskedTextBox8.Enabled = false;
                            maskedTextBox9.Enabled = false;
                        }
                        else if (cd.BuscarDatas(dt).Rows[0]["dtescalada"].ToString().Length == 22 && cd.BuscarDatas(dt).Rows[0]["dtescalada"].ToString()[2].ToString() == "/")
                        {
                            radioButton2.Checked = true;
                            maskedTextBox8.Text = cd.BuscarDatas(dt).Rows[0]["dtescalada"].ToString();
                            maskedTextBox5.Enabled = false;
                            maskedTextBox9.Enabled = false;
                        }
                        else
                        {
                            radioButton3.Checked = true;
                            maskedTextBox9.Text = cd.BuscarDatas(dt).Rows[0]["dtescalada"].ToString();
                            maskedTextBox5.Enabled = false;
                            maskedTextBox8.Enabled = false;
                        }
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
            maskedTextBox8.Clear();
            maskedTextBox9.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            maskedTextBox5.Enabled = false;
            maskedTextBox8.Enabled = false;
            maskedTextBox9.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[2].Index)
            {
                dataGridView1.EndEdit();  //Stop editing of cell.
                int aux = dataGridView1.CurrentRow.Index;
                if ((bool)dataGridView1.Rows[aux].Cells[2].Value)
                {
                    dt.Codigo = dataGridView1.Rows[aux].Cells[0].Value.GetHashCode();
                    dt.Ocultar = "Ok";
                    cd.ocultarEscaladas(dt);
                    string msg = "ESTA ESCALADA FOI OCULTA, PARA VISUALIZÁ-LA NOVAMENTE, DESMARQUE A COLUNA OCULTAR!!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
                else
                {
                    dt.Codigo = dataGridView1.Rows[aux].Cells[0].Value.GetHashCode();
                    dt.Ocultar = null;
                    cd.ocultarEscaladas(dt);
                    string msg = "VOCÊ PODERÁ VER OS DADOS DESTA ESCALADA NOVAMENTE!!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBox5.Enabled = true;
            maskedTextBox5.Focus();
            maskedTextBox8.Clear();
            maskedTextBox9.Clear();
            maskedTextBox8.Enabled = false;
            maskedTextBox9.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBox5.Clear();
            maskedTextBox5.Enabled = false;
            maskedTextBox8.Enabled = true;
            maskedTextBox8.Focus();
            maskedTextBox9.Clear();
            maskedTextBox9.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBox5.Clear();
            maskedTextBox5.Enabled = false;
            maskedTextBox8.Clear();
            maskedTextBox8.Enabled = false;
            maskedTextBox9.Enabled = true;
            maskedTextBox9.Focus();
        }
    }
}
