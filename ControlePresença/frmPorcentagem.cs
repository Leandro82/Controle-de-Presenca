using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace ControlePresença
{
    public partial class frmPorcentagem : Form
    {
        string dta;
        int linha, coluna;
        ConectaUsuario cs = new ConectaUsuario();
        Conecta co = new Conecta();
        public frmPorcentagem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                string msg = "Escolha uma opção";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                int cont = co.CarregaDatas().Rows.Count;
                int i = 0, data = 0, pres = 0, falt = 0;

                while (i < cont)
                {
                    if (Convert.ToDateTime(co.CarregaDatas().Rows[i]["data"].ToString()) <= DateTime.Today)
                    {
                        data = data + 1;
                    }
                    i = i + 1;
                }

                try
                {
                    int aux = 0;
                    int gera = co.presencaPorcentagem().Rows.Count;
                    dataGridView1.Rows.Clear();
                    progressBar1.Maximum = gera;
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

                        double total = pres + falt;
                        double soma = (pres / total) * 100;
                        if (comboBox1.Text == "0% a 50%")
                        {
                            if (pres == 0 || soma <= 50)
                            {
                                if (pres == 0)
                                {
                                    int n = dataGridView1.Rows.Add();
                                    dataGridView1.Rows[n].Cells[0].Value = item["nome"].ToString();
                                    dataGridView1.Rows[n].Cells[1].Value = pres;
                                    dataGridView1.Rows[n].Cells[2].Value = falt;
                                    dataGridView1.Rows[n].Cells[3].Value = 0 + "%";
                                }
                                else
                                {
                                    int n = dataGridView1.Rows.Add();
                                    dataGridView1.Rows[n].Cells[0].Value = item["nome"].ToString();
                                    dataGridView1.Rows[n].Cells[1].Value = pres;
                                    dataGridView1.Rows[n].Cells[2].Value = falt;
                                    if (total == 0)
                                    {
                                        dataGridView1.Rows[n].Cells[3].Value = 0 + "%";
                                    }
                                    else
                                    {
                                        dataGridView1.Rows[n].Cells[3].Value = Math.Round(soma, 0) + "%";
                                    }
                                }
                            }
                        }
                        else if (comboBox1.Text == "50% a 75%")
                        {
                            if (soma > 50 && soma <= 75)
                            {
                                int n = dataGridView1.Rows.Add();
                                dataGridView1.Rows[n].Cells[0].Value = item["nome"].ToString();
                                dataGridView1.Rows[n].Cells[1].Value = pres;
                                dataGridView1.Rows[n].Cells[2].Value = falt;
                                if (total == 0)
                                {
                                    dataGridView1.Rows[n].Cells[3].Value = 0 + "%";
                                }
                                else
                                {
                                    dataGridView1.Rows[n].Cells[3].Value = Math.Round(soma, 0) + "%";
                                }
                            }
                        }
                        else if (comboBox1.Text == "75% a 100%")
                        {
                            if (soma > 75)
                            {
                                int n = dataGridView1.Rows.Add();
                                dataGridView1.Rows[n].Cells[0].Value = item["nome"].ToString();
                                dataGridView1.Rows[n].Cells[1].Value = pres;
                                dataGridView1.Rows[n].Cells[2].Value = falt;
                                if (total == 0)
                                {
                                    dataGridView1.Rows[n].Cells[3].Value = 0 + "%";
                                }
                                else
                                {
                                    dataGridView1.Rows[n].Cells[3].Value = Math.Round(soma, 0) + "%";
                                }
                            }
                        }
                        else if (comboBox1.Text == "Todos")
                        {
                            int n = dataGridView1.Rows.Add();
                            dataGridView1.Rows[n].Cells[0].Value = item["nome"].ToString();
                            dataGridView1.Rows[n].Cells[1].Value = pres;
                            dataGridView1.Rows[n].Cells[2].Value = falt;
                            if (total == 0)
                            {
                                dataGridView1.Rows[n].Cells[3].Value = 0 + "%";
                            }
                            else
                            {
                                dataGridView1.Rows[n].Cells[3].Value = Math.Round(soma, 0) + "%";
                            }
                        }

                        pres = 0;
                        falt = 0;
                        aux = aux + 1;
                        progressBar1.Value++;
                    }
                    progressBar1.Value = 0;
                }
                catch
                {
                    string msg = "Não houve reunião nesta data";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                string msg = "Não existe dados para gerar o arquivo";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
            }
            else
            {
                int l = 3, c = 1;
                linha = dataGridView1.Rows.Count;
                coluna = dataGridView1.Columns.Count;
                progressBar1.Maximum = linha;
                SaveFileDialog salvarArquivo = new SaveFileDialog(); // novo
                salvarArquivo.FileName = "Presença";
                salvarArquivo.DefaultExt = "*.xls";
                salvarArquivo.Filter = "Todos os Aquivos do Excel (*.xls)|*.xls| Todos os arquivos (*.*)|*.*";

                try
                {
                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
                    xlWorkSheet.PageSetup.TopMargin = 40;
                    xlWorkSheet.PageSetup.BottomMargin = 40;
                    xlWorkSheet.PageSetup.LeftMargin = 85;
                    xlWorkSheet.PageSetup.RightMargin = 20;
                    xlWorkSheet.PageSetup.PrintTitleRows = "$A$2:$D$2";
                    xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 4]].Merge();
                    xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 4]].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    xlWorkSheet.Cells[1, 1] = "Controle de Presença - "+comboBox1.Text;
                    xlWorkSheet.Cells[1, 1].ColumnWidth = 35;
                    xlWorkSheet.Cells[1, 2].ColumnWidth = 10;
                    xlWorkSheet.Cells[1, 3].ColumnWidth = 10;
                    xlWorkSheet.Cells[1, 4].ColumnWidth = 13;
                    xlWorkSheet.Cells[1, 1].Font.Size = 16;
                    xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 4]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorkSheet.Cells[2, 1] = "Nome";
                    xlWorkSheet.Cells[2, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    xlWorkSheet.Cells[2, 1].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorkSheet.Cells[2, 2] = "Presença";
                    xlWorkSheet.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    xlWorkSheet.Cells[2, 2].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorkSheet.Cells[2, 3] = "Falta";
                    xlWorkSheet.Cells[2, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    xlWorkSheet.Cells[2, 3].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorkSheet.Cells[2, 4] = "Porcentagem";
                    xlWorkSheet.Cells[2, 4].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    xlWorkSheet.Cells[2, 4].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    xlWorkSheet.Range[xlWorkSheet.Cells[2, 1], xlWorkSheet.Cells[2, 4]].Font.Size = 12;
                    for (int i = 0; i < linha; i++)
                    {
                        for (int j = 0; j < coluna; j++)
                        {
                            xlWorkSheet.Cells[l, c] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            xlWorkSheet.Cells[l, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                            xlWorkSheet.Cells[l, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                            xlWorkSheet.Cells[l, 4].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                            xlWorkSheet.Cells[l, c].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            c = c + 1;
                        }
                        if (l % 2 == 0)
                        {
                            xlWorkSheet.Range[xlWorkSheet.Cells[l, 1], xlWorkSheet.Cells[l, 4]].Interior.Color = ColorTranslator.ToWin32(Color.Yellow);
                        }
                        l = l + 1;
                        c = 1;
                        progressBar1.Value++;
                    }

                    progressBar1.Value = 0;
                    if (salvarArquivo.ShowDialog() == System.Windows.Forms.DialogResult.OK && salvarArquivo.FileName.Length > 0)
                    {
                        xlWorkBook.SaveAs(salvarArquivo.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                        Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();

                        liberarObjetos(xlWorkSheet);
                        liberarObjetos(xlWorkBook);
                        liberarObjetos(xlApp);

                        string msg = "O arquivo Excel foi criado com sucesso. Você pode encontrá-lo em : " + salvarArquivo.FileName;
                        frmMensagem mg = new frmMensagem(msg);
                        mg.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    string msg = "Erro : " + ex.Message;
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
            }
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
