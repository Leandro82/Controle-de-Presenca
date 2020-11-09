using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace ControlePresença
{
    public partial class frmCadAlpinistas : Form
    {
        public frmCadAlpinistas()
        {
            InitializeComponent();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog salvarArquivo = new SaveFileDialog();

            salvarArquivo.FileName = "Alpinistas";
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
                xlWorkSheet.Name = "Planilha1";
                xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 3]].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                xlWorkSheet.Cells[1, 1] = "Lista - Novos Alpinistas";
                xlWorkSheet.Cells[1, 1].ColumnWidth = 60;
                xlWorkSheet.Cells[1, 1].Font.Size = 16;
                xlWorkSheet.Cells[2, 1] = "Nomes";
                xlWorkSheet.Cells[2, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                xlWorkSheet.Range[xlWorkSheet.Cells[2, 1], xlWorkSheet.Cells[2, 3]].Font.Size = 12;

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

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog arquivoExcel = new OpenFileDialog();

            if (arquivoExcel.ShowDialog() == DialogResult.OK)
            {
                string caminho = arquivoExcel.FileName;
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + arquivoExcel.FileName + ";Extended Properties=Excel 12.0;");
                con.Open();
                //DataSet excelDataSet = new DataSet();
                OleDbDataAdapter query = new OleDbDataAdapter(" SELECT * FROM [Planilha1$]", con);
                DataTable dataTable = new DataTable();
                query.Fill(dataTable);
                int mat = dataTable.Rows.Count;
                if (mat == 1)
                {
                    string msg = "Não existe dados para cadastrar";
                    frmMensagem mg = new frmMensagem(msg);
                    mg.ShowDialog();
                }
                else
                {
                    var form = new frmLoad(mat, caminho);
                    form.Show();
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                string msg = "Informe o nome do Alpinista.";
                frmMensagem mg = new frmMensagem(msg);
                mg.ShowDialog();
                textBox1.Focus();
            }
            else
            {
                var form = new frmAviso(Convert.ToDateTime(dateTimePicker1.Text).ToString("dd/MM/yyyy"), textBox1.Text);
                form.ShowDialog();
                textBox1.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmCadPres cad = new frmCadPres();
            cad.ShowDialog();
        }
    }
}
