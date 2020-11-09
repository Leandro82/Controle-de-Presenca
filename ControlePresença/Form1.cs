using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace ControlePresença
{
    public partial class Form1 : Form
    {
        Variavel va = new Variavel();
        Conecta co = new Conecta();
        public Form1()
        {
            InitializeComponent();
        }

        public MySqlConnection conexao;

        public void Atualiza()
        {
            dateTimePicker1.Text = AuxClas.Data;
            textBox2.Text = AuxClas.Palestrante;
            textBox1.Text = AuxClas.Observacao;
        }

        public void CarregaDatas()
        {
            foreach (DataRow item in co.CarregaDatas().Rows)
            {
                DateTime data = Convert.ToDateTime(item["data"].ToString());
                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;
                string semana = dtfi.GetDayName(data.DayOfWeek);
                int dia = data.Day;
                int mes = data.Month;
                string mesExtenso = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(mes).ToLower();
                int ano = data.Year;
                dataGridView1.Rows.Add(semana + ", " + dia + " de " + mesExtenso + " de " + ano, item["observacao"].ToString(), item["palestrante"].ToString());
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int aux = 0;

            foreach (DataGridViewRow itemRow in dataGridView1.Rows)
            {
                int i = 0;
                if (dateTimePicker1.Text == itemRow.Cells[0].Value.ToString())
                {
                    aux = 1;
                }

                i = i + 1;
            }

            if (aux == 0 || dataGridView1.Rows.Count == 0)
                {
                    dataGridView1.Rows.Add(dateTimePicker1.Text);
                    va.Data = Convert.ToDateTime(dateTimePicker1.Text);
                    va.Palestrante = textBox1.Text;
                    va.Observacao = textBox2.Text;
                    co.CadastrarData(va);
                    textBox1.Clear();
                    textBox2.Clear();
                    dataGridView1.Rows.Clear();
                    CarregaDatas();
                }
                else
                {
                    string msg = "Data já cadastrada";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                    dateTimePicker1.Text = Convert.ToString(DateTime.Today);
                    textBox1.Clear();
                    textBox2.Clear();
                }        
            }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            CarregaDatas();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int pos;
            pos = dataGridView1.CurrentRow.Index.GetHashCode();
            va.Data = Convert.ToDateTime(dataGridView1.Rows[pos].Cells[0].Value.ToString());
            string dt = (Convert.ToDateTime(va.Data).ToString("ddMMyyyy"));
            string aux = ("data" + Convert.ToString(dt));

            string message = "Deseja realmente excluir a data " + Convert.ToDateTime(va.Data).ToString("dd/MM/yyyy") + "?";
            string caption = "Confirmar exclusão";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                dataGridView1.Rows.RemoveAt(pos);

                try
                {
                    co.DeletarData(va);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro de comandos: " + ex.Message);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new frmDatas();
            if (Application.OpenForms.OfType<frmDatas>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
            this.Close();
        }
    }
}
