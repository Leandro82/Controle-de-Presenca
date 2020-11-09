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
    public partial class frmInativos : Form
    {
        string dta;
        int cont, pos = 0, p = 1;
        int[] cod;
        ConectaUsuario cs = new ConectaUsuario();
        Conecta co = new Conecta();
        Variavel va = new Variavel();
        public frmInativos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int aux = 0;
            int gera = co.presencaPorcentagem().Rows.Count;
            int pres = 0, falt = 0;
            cod = new int[gera];
            progressBar1.Maximum = gera;
            cont = co.CarregaDatas().Rows.Count;
            
            foreach (DataRow item in co.presencaPorcentagem().Rows)
            {
                for (int j = 0; j < cont; j++)
                {
                    if (Convert.ToDateTime(co.CarregaDatas().Rows[j]["data"].ToString()) <= DateTime.Today)
                    {
                        dta = "data" + Convert.ToDateTime(co.CarregaDatas().Rows[j]["data"].ToString()).ToString("ddMMyyyy");
                        if (Convert.ToDateTime(co.CarregaDatas().Rows[j]["data"].ToString()) >= Convert.ToDateTime(cs.UsuarioPorc().Rows[aux]["dtCad"].ToString()))
                        {
                            if (item[dta].ToString() == "P")
                            {
                                pres = pres + 1;
                            }
                            else
                            {
                                
                                falt = falt + 1;
                                
                            }
                        }
                    }
                }
                if (pres == 0)
                {
                    cod[pos] = item["cod"].GetHashCode();
                    p = p + 1;
                    pos = pos + 1;
                }
                progressBar1.Value++;
                falt = 0;
                pres = 0;
                aux = aux + 1;
            }
            progressBar1.Value = 0;
            progressBar1.Maximum = p;

            for(int d = 0; d < pos; d++)
            {
                va.Codigo = cod[d];
                co.Inativo(va);
                progressBar1.Value++;
            }
            progressBar1.Value = 0;
            string msg = "TODOS OS INATIVOS FORAM DELETADOS";
            frmMensagem mg = new frmMensagem(msg);
            mg.ShowDialog();
            this.Close();
        }
    }
}
