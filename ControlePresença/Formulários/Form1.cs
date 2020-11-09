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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace ControlePresença
{
    public partial class Form1 : Form
    {
        string dta, gerado, aviso = "";
        int aux = 0;
        double porcent;
        Ano an = new Ano();
        ConectaAno ca = new ConectaAno();
        Eleicao el = new Eleicao();
        ConectaEleicao ce = new ConectaEleicao();
        Variavel va = new Variavel();
        ConectaUsuario cs = new ConectaUsuario();
        Conecta co = new Conecta();
        frmCarregando frm = new frmCarregando();
        SaveFileDialog salvarArquivo = new SaveFileDialog(); // novo
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;

        public Form1()
        {
            InitializeComponent();
        }

        private void CarregaFormAguarde()
        {
            frm.ShowDialog();
        }

        private void CarregaFormAguarde1()
        {
            frm.ShowDialog();
        }

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
            /*if (ca.Ano().Rows[0]["gerado"].ToString() == "Ok")
            {
                button2.Enabled = false;
            }*/
            CarregaDatas();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (aviso == "")
            {
                string msg = "Sempre antes de apagar uma data, a não ser que tenha cadastrado errado, atualize as porcentagens para eleição.";
                frmLembrete mg = new frmLembrete(msg);
                mg.ShowDialog();
                button2.Focus();
                aviso = "Ok";
            }
            else
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

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime datas = Convert.ToDateTime(ca.Ano().Rows[0]["dtgerado"].ToString());
            TimeSpan diferenca = DateTime.Today - datas;
            int totalDias = diferenca.Days;

            if (totalDias < 7)
            {
                string msg = "Você só poderá executar esta ação novamente dia: " + Convert.ToDateTime(ca.Ano().Rows[0]["dtgerado"].ToString()).AddDays(7).ToString("dd/MM/yyyy");
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                System.Threading.Thread tFormAguarde = new System.Threading.Thread(new System.Threading.ThreadStart(CarregaFormAguarde));
                tFormAguarde.Start();
                gerado = ca.Ano().Rows[0]["gerado"].ToString();
                el.Codigo = Convert.ToInt32(cs.UsuarioPorc().Rows[aux]["cod"].ToString());
                Convert.ToDateTime(ca.Ano().Rows[0][1].ToString());
                int cont = co.CarregaDatas().Rows.Count;
                int i = 0, data = 0, pres = 0, falt = 0;

                while (i < cont)
                {
                    if (Convert.ToDateTime(co.CarregaDatas().Rows[i]["data"].ToString()) >= Convert.ToDateTime(ca.Ano().Rows[0][1].ToString()) && Convert.ToDateTime(co.CarregaDatas().Rows[i]["data"].ToString()) <= DateTime.Today)
                    {
                        data = data + 1;
                    }
                    i = i + 1;
                }

                try
                {
                    int gera = co.presencaPorcentagem().Rows.Count;
                    foreach (DataRow item in co.presencaPorcentagem().Rows)
                    {
                        for (int j = 0; j < cont; j++)
                        {
                            if (Convert.ToDateTime(co.CarregaDatas().Rows[j]["data"].ToString()) >= Convert.ToDateTime(ca.Ano().Rows[0][1].ToString()) && Convert.ToDateTime(co.CarregaDatas().Rows[j]["data"].ToString()) <= DateTime.Today)
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

                        el.Codigo = Convert.ToInt32(cs.UsuarioPorc().Rows[aux]["cod"].ToString());
                        int alp = ce.PesquisaAlpinista(el).Rows.Count;

                        if (alp == 0)
                        {
                            el.Codigo = Convert.ToInt32(cs.UsuarioPorc().Rows[aux]["cod"].ToString());
                            el.Nome = cs.UsuarioPorc().Rows[aux]["nome"].ToString().ToUpper();
                            el.TotalPresenca = pres;
                            el.TotalReuniao = pres + falt;
                            ce.cadastro(el);
                        }
                        else if (alp > 0 && gerado == "Ok")
                        {
                            el.TotalPresenca = ce.SelecionaDados(el).Rows[0]["t_presenca"].GetHashCode() + pres;
                            el.TotalReuniao = ce.SelecionaDados(el).Rows[0]["t_reuniao"].GetHashCode() + pres + falt;
                            ce.AtualizaPorcentagem(el);
                        }
                        double total = pres + falt;
                        double soma = (pres / total) * 100;

                        pres = 0;
                        falt = 0;
                        aux = aux + 1;
                    }
                    an.DataGerado = Convert.ToString(DateTime.Today).ToString();
                    an.Gerado = "Ok";
                    ca.Alterar(an);
                    tFormAguarde.Abort();
                    string msg = "As porcentagens para eleição foram geradas";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro de comandos: " + ex.Message);
                }
                tFormAguarde.Abort();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cont = ce.Dados().Rows.Count;
            if (cont == 0)
            {
                string msg = "Não existe dados para gerar o excel";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                System.Threading.Thread carregando = new System.Threading.Thread(new System.Threading.ThreadStart(CarregaFormAguarde));
                carregando.Start();
                int l = 3;
                salvarArquivo.FileName = "Lista de porcentagem para eleição";
                salvarArquivo.DefaultExt = "*.xls";
                salvarArquivo.Filter = "Todos os Aquivos do Excel (*.xls)|*.xls| Todos os arquivos (*.*)|*.*";

                try
                {
                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 5]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 5]].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    xlWorkSheet.Cells[1, 1] = "Lista de porcentagem para eleição";
                    xlWorkSheet.Cells[1, 1].ColumnWidth = 35;
                    xlWorkSheet.Cells[1, 2].ColumnWidth = 13;
                    xlWorkSheet.Cells[1, 3].ColumnWidth = 13;
                    xlWorkSheet.Cells[1, 4].ColumnWidth = 13;
                    xlWorkSheet.Cells[1, 5].ColumnWidth = 13;
                    xlWorkSheet.Cells[1, 1].Font.Size = 16;
                    xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 5]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorkSheet.Cells[2, 1] = "NOME";
                    xlWorkSheet.Cells[2, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    xlWorkSheet.Cells[2, 1].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorkSheet.Cells[2, 2] = "PRES.";
                    xlWorkSheet.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    xlWorkSheet.Cells[2, 2].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorkSheet.Cells[2, 3] = "FALTA";
                    xlWorkSheet.Cells[2, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    xlWorkSheet.Cells[2, 3].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorkSheet.Cells[2, 4] = "T. DE REUN.";
                    xlWorkSheet.Cells[2, 4].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    xlWorkSheet.Cells[2, 4].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorkSheet.Cells[2, 5] = "PORC. %";
                    xlWorkSheet.Cells[2, 5].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    xlWorkSheet.Cells[2, 5].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorkSheet.Range[xlWorkSheet.Cells[2, 1], xlWorkSheet.Cells[2, 5]].Font.Size = 12;

                    foreach(DataRow item in ce.Dados().Rows)
                    {
                        xlWorkSheet.Cells[l, 1] = item["nome"].ToString();
                        xlWorkSheet.Cells[l, 1].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        xlWorkSheet.Cells[l, 2] = item["t_presenca"].GetHashCode();
                        xlWorkSheet.Cells[l, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        xlWorkSheet.Cells[l, 2].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        xlWorkSheet.Cells[l, 3] = item["t_reuniao"].GetHashCode() - item["t_presenca"].GetHashCode();
                        xlWorkSheet.Cells[l, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        xlWorkSheet.Cells[l, 3].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        xlWorkSheet.Cells[l, 4] = item["t_reuniao"].GetHashCode();
                        xlWorkSheet.Cells[l, 4].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        xlWorkSheet.Cells[l, 4].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        porcent = (Convert.ToDouble(item["t_presenca"].GetHashCode()) / Convert.ToDouble(item["t_reuniao"].GetHashCode()))*100;
                        xlWorkSheet.Cells[l, 5] = porcent + "%";
                        xlWorkSheet.Cells[l, 5].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        xlWorkSheet.Cells[l, 5].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        l = l + 1;
                    }
                    xlWorkSheet.Application.Columns[1].ShrinkToFit = true;
                    new System.Threading.Thread(delegate()
                    {
                        carregando.Abort();
                        Export();
                    }).Start();
                }
                catch (Exception ex)
                {
                    string msg = "Erro : " + ex.Message;
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
            }
        }

        private void Export()
        {
            System.Threading.Thread arquivo = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                if (salvarArquivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    xlWorkBook.SaveAs(salvarArquivo.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                    Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    liberarObjetos(xlWorkSheet);
                    liberarObjetos(xlWorkBook);
                    liberarObjetos(xlApp);
                }
            }));
            arquivo.SetApartmentState(System.Threading.ApartmentState.STA);
            arquivo.IsBackground = false;
            arquivo.Start();
        }


        private void liberarObjetos(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                string msg = "Ocorreu um erro durante a liberação do objeto " + ex.ToString();
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
