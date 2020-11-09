using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace ControlePresença
{
    public partial class frmEnvelopeEquipe : Form
    {
        ConectaDatasEscalada cd = new ConectaDatasEscalada();
        ConectaEquipe ce = new ConectaEquipe();
        Equipe eq = new Equipe();
        string caminho, data;
        public frmEnvelopeEquipe()
        {
            InitializeComponent();
        }

        private void Exibir()
        {
            eq.Escalada = comboBox1.Text;
            dataGridView1.Rows.Clear();
            foreach (DataRow alpinista in ce.BuscaDadosEquipe(eq).Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[1].Value = alpinista["nome"].ToString().ToUpper();
                dataGridView1.Rows[n].Cells[2].Value = alpinista["funcao"].ToString().ToUpper();
                dataGridView1.Rows[n].Cells[3].Value = alpinista["cod"].GetHashCode();
            }
            data = ce.BuscaDataEscalada(eq).Rows[0][0].ToString();
        }

        private void frmEnvelopeEquipe_Load(object sender, EventArgs e)
        {
            int prf = cd.SelecionaEscalada().Rows.Count;
            for (int j = 0; j < prf; j++)
            {
                comboBox1.Items.Add(cd.SelecionaEscalada().Rows[j]["escalada"].ToString());
            }
            ce.AbreEnvelope();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Exibir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "jpg|*.jpg";
            if (file.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = file.FileName;
                caminho = Path.GetDirectoryName(file.FileName) + "\\" + Path.GetFileName(file.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.ImageLocation == null)
            {
                string msg = "PRIMEIRO INSIRA UMA IMAGEM";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else if (textBox1.Text == "")
            {
                string msg = "INFORME A FRASE QUE IRÁ ACIMA DA IMAGEM";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                string msg = "INFORME A FRASE QUE IRÁ ABAIXO DA IMAGEM";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                textBox2.Focus();
            }
            else
            {
                frmRelEnvEquipe frm = new frmRelEnvEquipe(textBox1.Text, textBox2.Text, caminho, comboBox1.Text);
                frm.ShowDialog();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[0].Index)
            {
                dataGridView1.EndEdit();  //Stop editing of cell.
                int cod = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                if ((bool)dataGridView1.Rows[e.RowIndex].Cells[0].Value)
                {
                    eq.Codigo = cod;
                    eq.Envelope = "Sim";
                    ce.EnvelopeEquipe(eq);
                }
                else
                {
                    eq.Codigo = cod;
                    eq.Envelope = "Não";
                    ce.EnvelopeEquipe(eq);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = true;
                }
                ce.SelecionaTodos();
            }
            else if (checkBox1.Checked == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = false;
                }
                ce.AbreEnvelope();
            }
        }
    }
}
