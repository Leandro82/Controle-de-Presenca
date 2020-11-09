using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace ControlePresença
{
    public partial class frmAgenda : Form
    {
        Variavel va = new Variavel();
        ConectaAgenda ag = new ConectaAgenda();
        int cod;
        string ok, dt = "", vis, evento = "";

        public frmAgenda()
        {
            InitializeComponent();
        }

        public static DialogResult InputBox(int msg, string promptText, string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = "MENSAGEM";
            label.Text = "Já existe(m) " +msg+ " evento(s) cadastrado(s) para a data "+promptText+ ", deseja continuar?";
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        public void Datas()
        {
            int cont = ag.BuscarAnos().Rows.Count, aux = 0;
            int[] ano = new int[cont];

            foreach (DataRow item in ag.BuscarAnos().Rows)
            {
                ano[aux] = item["ano"].GetHashCode();
                aux = aux + 1;
            }

            for(int i = 0; i < aux; i++)
            {
                if (ano[i] == Convert.ToInt32(DateTime.Now.Year))
                {
                    ok = "Sim";
                }
                else
                {
                    if (comboBox1.Text != "")
                    {
                        ok = "Sim";
                    }
                }
            }

            if (ok == "Sim")
            {
                var diasMarcados = new List<DateTime>();
                
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                if (comboBox1.Text != "")
                {
                    va.Ano = Convert.ToInt32(comboBox1.Text);
                    foreach (DataRow data in ag.BuscarDatas(va).Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = data["cod"].GetHashCode();
                        dataGridView1.Rows[n].Cells[1].Value = Convert.ToDateTime(data["data"].ToString()).ToString("dd/MM/yyyy");
                        dataGridView1.Rows[n].Cells[2].Value = data["evento"].ToString();
                        dataGridView1.Rows[n].Cells[3].Value = data["responsavel"].ToString();
                        diasMarcados.Add(Convert.ToDateTime(data["data"]));
                    }
                    monthCalendar1.BoldedDates = diasMarcados.ToArray();
                }
                else
                {
                    comboBox1.Text = "";
                }
            }

            
            //comboBox1.SelectedIndex = comboBox1.FindString(Convert.ToString(Convert.ToInt32(DateTime.Now.Year)));
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            monthCalendar1.TitleBackColor = System.Drawing.Color.Black;
            monthCalendar1.TrailingForeColor = System.Drawing.Color.White;
            monthCalendar1.TitleForeColor = System.Drawing.Color.Yellow;
            monthCalendar1.BackColor = System.Drawing.Color.LightSteelBlue;

            if (ag.BuscarAnos().Rows.Count > 0)
            {
                foreach (DataRow ano in ag.BuscarAnos().Rows)
                {
                    comboBox1.Items.Add(Convert.ToString(ano["ano"].GetHashCode()));
                    if (ano["ano"].GetHashCode() == Convert.ToInt32(DateTime.Now.Year))
                        dt = "ok";
                }
            }

            if (dt == "ok")
            {
                comboBox1.SelectedIndex = comboBox1.FindString(Convert.ToString(Convert.ToInt32(DateTime.Now.Year)));
            }

            Datas();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            label2.Text = "";
            dt = "";
            va.Ano = Convert.ToInt32(monthCalendar1.SelectionStart.ToString("yyyy"));
            foreach (DataRow dia in ag.BuscarDatas(va).Rows)
            {
                if (Convert.ToDateTime(dia["data"].ToString()).ToString("dd/MM/yyyy") == monthCalendar1.SelectionStart.ToString("dd/MM/yyyy"))
                {
                    dt = "ok";
                    vis = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
                }
            }

            if (dt == "ok")
            {
               /* string message = "Já existe um evento cadastrado em "+monthCalendar1.SelectionStart.ToString("dd/MM/yyy")+", deseja continuar?";
                string caption = "Mensagem";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                InputBox("teste", "teste") = MessageBox.Show(message, caption, buttons);

                result = MessageBox.Show(message, caption, buttons);*/
                va.Data = Convert.ToDateTime(vis);
                int cont = ag.BuscarEvento(va).Rows.Count;
                foreach (DataRow dia in ag.BuscarEvento(va).Rows)
                {
                    if (cont > 1)
                    {
                        evento = evento + "- " + dia["evento"].ToString();
                    }
                    else
                    {
                        evento = dia["evento"].ToString();
                    }
                }

                if (InputBox(cont, vis, evento) == System.Windows.Forms.DialogResult.OK)
                {
                    label2.Text = Convert.ToString(monthCalendar1.SelectionStart.ToString("dd/MM/yyyy"));
                }
            }
            else 
            {
                label2.Text = Convert.ToString(monthCalendar1.SelectionStart.ToString("dd/MM/yyyy"));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (comboBox1.Items.Count > 0)
            {
                comboBox1.Items.Clear();
            }*/

            if (label1.Text == "" || textBox1.Text == "")
            {
                string msg = "Por favor, informe uma data e o evento!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                va.Data = Convert.ToDateTime(label2.Text);
                va.Nome = textBox1.Text;
                va.Observacao = textBox2.Text;
                va.Ano = Convert.ToInt32(Convert.ToDateTime(label2.Text).ToString("yyyy"));
                ag.cadastro(va);

                string msg = "Evento cadastrado!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                label2.Text = "";
                textBox1.Clear();
                textBox2.Clear();
                 
                if (ag.BuscarAnos().Rows.Count > 0)
                {
                    comboBox1.Items.Clear();
                    foreach (DataRow ano1 in ag.BuscarAnos().Rows)
                    {
                        comboBox1.Items.Add(Convert.ToString(ano1["ano"].GetHashCode()));
                    }
                }
                comboBox1.SelectedIndex = comboBox1.FindString(Convert.ToString(Convert.ToInt32(DateTime.Now.Year)));
                if (comboBox1.Text != "")
                {
                    Datas();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cod = dataGridView1[0, dataGridView1.CurrentCellAddress.Y].Value.GetHashCode();
            label2.Text = dataGridView1[1, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            textBox1.Text = dataGridView1[2, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            textBox2.Text = dataGridView1[3, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label2.Text == "" || textBox1.Text == "")
            {
                string msg = "Clique duas vezes sobre a linha do evento que deseja alterar!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                va.Codigo = cod;
                va.Data = Convert.ToDateTime(label2.Text);
                va.Ano = Convert.ToInt32(Convert.ToDateTime(label2.Text).ToString("yyyy"));
                va.Nome = textBox1.Text;
                va.Observacao = textBox2.Text;
                ag.atualizarEvento(va);

                string msg = "Evento alterado!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                label2.Text = "";
                textBox1.Clear();
                textBox2.Clear();
                button1.Enabled = true;

                if (ag.BuscarAnos().Rows.Count > 0)
                {
                    comboBox1.Items.Clear();
                    foreach (DataRow ano1 in ag.BuscarAnos().Rows)
                    {
                        comboBox1.Items.Add(Convert.ToString(ano1["ano"].GetHashCode()));
                    }
                }
                comboBox1.SelectedIndex = comboBox1.FindString(Convert.ToString(Convert.ToInt32(DateTime.Now.Year)));
                if (comboBox1.Text != "")
                {
                    Datas();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label2.Text == "" || textBox1.Text == "")
            {
                string msg = "Clique duas vezes sobre a linha do evento que deseja excluir!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                string message = "Deseja realmente excluir este Evento?";
                string caption = "Confirmar exclusão";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    va.Codigo = cod;
                    ag.excluirEvento(va);

                    string msg = "Evento excluído!!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                    label2.Text = "";
                    textBox1.Clear();
                    textBox2.Clear();
                    button1.Enabled = true;
                    if (ag.BuscarAnos().Rows.Count > 0)
                    {
                        comboBox1.Items.Clear();
                        foreach (DataRow ano1 in ag.BuscarAnos().Rows)
                        {
                            comboBox1.Items.Add(Convert.ToString(ano1["ano"].GetHashCode()));
                        }
                    }
                    comboBox1.SelectedIndex = comboBox1.FindString(Convert.ToString(Convert.ToInt32(DateTime.Now.Year)));
                    if (comboBox1.Text != "")
                    {
                        Datas();
                    }
                }
                else
                {
                    label2.Text = "";
                    textBox1.Clear();
                    textBox2.Clear();
                    button1.Enabled = true;
                }
            }

            if (ag.BuscarAnos().Rows.Count > 0)
            {
                comboBox1.Items.Clear();
                foreach (DataRow ano1 in ag.BuscarAnos().Rows)
                {
                    comboBox1.Items.Add(Convert.ToString(ano1["ano"].GetHashCode()));
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            button1.Enabled = true;
            button1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new frmRelAgenda();
            if (Application.OpenForms.OfType<frmRelAgenda>().Count() > 0)
            {
                Application.OpenForms[form.Name].Focus();
            }
            else
            {
                form.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Datas();
        }
    }
}
