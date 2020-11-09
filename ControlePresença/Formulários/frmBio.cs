using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlexCodeSDK;
using System.IO;
using MySql.Data.MySqlClient;

namespace ControlePresença
{
    public partial class frmBio : Form
    {
        Variavel va = new Variavel();
        Usuario us = new Usuario();
        Conecta co = new Conecta();
        ConectaUsuario cs = new ConectaUsuario();
        FlexCodeSDK.FinFPReg reg;
        String template = "";
        //MySqlConnection conn = null;
        string imgPath = "";
        //MySqlConnection conn1 = new MySqlConnection("Persist Security Info=false;SERVER=localhost;DATABASE=escalada;UID=root;pwd=");
        int aux;

        public frmBio()
        {
            InitializeComponent();
        }
     
        private void frmBio_Load(object sender, EventArgs e)
        {
            button4.Enabled = false;
            reg = new FlexCodeSDK.FinFPReg();
            reg.FPSamplesNeeded += new __FinFPReg_FPSamplesNeededEventHandler(reg_FPSamplesNeeded);
            reg.FPRegistrationTemplate += new __FinFPReg_FPRegistrationTemplateEventHandler(reg_FPRegistrationTemplate);
            reg.FPRegistrationImage += new __FinFPReg_FPRegistrationImageEventHandler(reg_FPRegistrationImage);
            reg.FPRegistrationStatus += new __FinFPReg_FPRegistrationStatusEventHandler(reg_FPRegistrationStatus);

            reg.AddDeviceInfo("44099166", "5136C24F5BF8CFA", "LDU428676B59828C60678JSD");

            reg.PictureSampleHeight = (short)(pictureBox1.Height * 15); //FlexCodeSDK use Twips. 1 pixel = 15 twips
            reg.PictureSampleWidth = (short)(pictureBox1.Width * 15); //FlexCodeSDK use Twips. 1 pixel = 15 twips
            imgPath = AppDomain.CurrentDomain.BaseDirectory + "Finger3.bmp";
            reg.PictureSamplePath = imgPath;
        }

        void reg_FPRegistrationStatus(RegistrationStatus Status)
        {
            if (Status == RegistrationStatus.r_OK)
            {
                us.Template = template;
                us.Codigo = Convert.ToInt32(textBox1.Text);
                cs.cadastrarDigital(us);

                string msg = "Digital cadastrada com successo!!!";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                textBox1.Text = "";
                textBox2.Text = "";
                template = "";
                label1.Text = "Samples Needed: ";
                button1.Enabled = true;
                button2.Enabled = false;
            }

            else if (Status == RegistrationStatus.r_NoDevice)
            {
                string msg = "Dispositivo não detectado";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else if (Status == RegistrationStatus.r_ActivationIncorrect)
            {
                string msg = "Ativação incorreta! Por favor, insira o correto";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else if (Status == RegistrationStatus.r_RegistrationFailed)
            {
                string msg = "Não é possível registrar";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
        }

        void reg_FPRegistrationImage()
        {
            pictureBox1.Load(imgPath);
            if (imgPath == AppDomain.CurrentDomain.BaseDirectory + "Finger3.bmp")
            {
                imgPath = AppDomain.CurrentDomain.BaseDirectory + "Finger4.bmp";
            }
            else
            {
                imgPath = AppDomain.CurrentDomain.BaseDirectory + "Finger3.bmp";
            }
            reg.PictureSamplePath = imgPath;
        }

        void reg_FPRegistrationTemplate(string FPTemplate)
        {
            template = FPTemplate;
        }

        void reg_FPSamplesNeeded(short Samples)
        {
            label1.Text = "Quantidade: " + Convert.ToString(Samples);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cont = cs.Usuario().Rows.Count;
            int i = 0;

            while (i < cont)
            {
                if (textBox1.Text == Convert.ToString(cs.Usuario().Rows[i]["cod"].GetHashCode()))
                {
                    aux = i;
                }
                i = i + 1;
            }

            if (cs.Usuario().Rows[aux]["digital"].ToString() == null || cs.Usuario().Rows[aux]["digital"].ToString() == "")
            {
                if (textBox1.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("Selecione um nome na lista ao lado");
                }
                else
                {
                    button1.Enabled = false;
                    button2.Enabled = true;
                    reg.FPRegistrationStart("MySecretKey" + textBox1.Text);
                }
            }
            else
            {
                MessageBox.Show("Alpinista já possui digital cadastrada");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Canceled!");
            textBox1.Text = "";
            textBox2.Text = "";
            template = "";
            label1.Text = "Samples Needed: ";
            button1.Enabled = true;
            button2.Enabled = false;
        }

        public void BuscarNome()
        {
            Usuario us = new Usuario();


            if (textBox3.Text == "")
            {
                MessageBox.Show("Informe um nome");
            }
            else
            {
                us.Nome = textBox3.Text;
                dataGridView1.Rows.Clear();
                foreach (DataRow item in cs.PesquisaNome(us).Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item["cod"].GetHashCode();
                    dataGridView1.Rows[n].Cells[1].Value = item["nome"].ToString().ToUpper();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuscarNome();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1[0, dataGridView1.CurrentCellAddress.Y].Value.ToString();
            textBox2.Text = dataGridView1[1, dataGridView1.CurrentCellAddress.Y].Value.ToString().ToUpper();
            dataGridView1.Rows.Clear();
            textBox3.Text = "";
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BuscarNome();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (textBox1.Text == "")
                {
                    string msg = "Primeiro selecione o alpinista";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                    checkBox1.Checked = false;
                }
                else 
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button4.Enabled = true;
                }
            }
            else if (checkBox1.Checked == false)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            us.Codigo = Convert.ToInt32(textBox1.Text);
            cs.RestauraDigital(us);
            string msg = "Digital restaurada, iniciando novo cadastro!!!";
            frmMensagem mg = new frmMensagem(msg);
            mg.ShowDialog();
            checkBox1.Checked = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = false;
            button1.PerformClick();
        }
    }
}
