using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlexCodeSDK;
using MySql.Data.MySqlClient;

namespace ControlePresença
{
    public partial class frmChamada : Form
    {
        Conecta co = new Conecta();
        ConectaUsuario cs = new ConectaUsuario();
        Variavel va = new Variavel();
        FlexCodeSDK.FinFPVer ver;
        String empid = "";
        public MySqlConnection conexao;

        public frmChamada()
        {
            InitializeComponent();
        }

        public string Endereco()
        {
            StringConexao str = new StringConexao();
            return str.Endereco();
        }

        private void frmChamada_Load(object sender, EventArgs e)
        {
            ver = new FlexCodeSDK.FinFPVer();
            ver.FPVerificationID += new __FinFPVer_FPVerificationIDEventHandler(ver_FPVerificationID);
            ver.FPVerificationStatus += new __FinFPVer_FPVerificationStatusEventHandler(ver_FPVerificationStatus);
            ver.AddDeviceInfo("44099166", "5136C24F5BF8CFA", "LDU428676B59828C60678JSD");

            try
            {
                conexao = new MySqlConnection(Endereco());
                conexao.Open();
                string chamada = "SELECT cod, digital FROM presenca";
                MySqlCommand comandos = new MySqlCommand(chamada, conexao);
                MySqlDataReader rdr = comandos.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ver.FPLoad(rdr.GetString(0), 0, rdr.GetString(1), "MySecretKey" + rdr.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de comandos: " + ex.Message);
            }

            
            conexao.Close();
            ver.WorkingInBackground(false);
            ver.FPVerificationStart();
        }

       void ver_FPVerificationStatus(VerificationStatus Status)
        {
            string dta = ("data" + Convert.ToDateTime(dateTimePicker1.Text).ToString("ddMMyyyy"));
            
            if (Status == VerificationStatus.v_OK)
            {
                va.Corrigir = dta;
                va.Codigo = Convert.ToInt32(empid);
                if (co.VerificaPresenca(va).ToString() == "ok")
                {
                    string msg = "Data não cadastrada, verifique se realmente há reunião neste dia e cadastre a data!!!";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
                else
                {
                    if (co.VerificaPresenca(va) == "P")
                    {
                        string msg = co.Alpinista(va).Substring(0, co.Alpinista(va).IndexOf(" ")) + " você já está com presença!!!";
                        frmMensagem mg = new frmMensagem(msg);
                        mg.ShowDialog();
                    }
                    else
                    {
                        va.Presenca = "P";
                        textBox1.Text = co.Alpinista(va);
                        MySqlCommand cmd = new MySqlCommand();
                        co.Presenca(va);
                        label2.Text = "Presente";
                        string msg = co.Alpinista(va).Substring(0, co.Alpinista(va).IndexOf(" ")) + " sua presença foi cadastrada!!!";
                        frmMensagem mg = new frmMensagem(msg);
                        mg.ShowDialog();
                        textBox1.Text = "";
                        label2.Text = "";
                    }
                }
            }
            else if (Status == VerificationStatus.v_NotMatch)
            {
                textBox1.Text = textBox1.Text + "\r\n" + "Not recognized";
            }
            else if (Status == VerificationStatus.v_MultiplelMatch)
            {
                textBox1.Text = textBox1.Text + "\r\n" + "Mltiple Match";
            }
            else if (Status == VerificationStatus.v_VerifyCaptureFingerTouch)
            {
            }
            
        }

        void ver_FPVerificationID(string ID, FingerNumber FingerNr)
        {
            empid = ID;
        }

        private void frmChamada_FormClosing(object sender, FormClosingEventArgs e)
        {
            ver.FPVerificationStop();
        }
    }
}
