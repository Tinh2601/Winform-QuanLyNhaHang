using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Drawing.Printing;

namespace DoAnQuanLyNhanVien
{
    public partial class frmBangLuongNhanVien : Form
    {
        My_DB mydb = new My_DB();
        DataTable dtBangLuong = new DataTable();
        public frmBangLuongNhanVien()
        {
            InitializeComponent();
        }

        private void frmBangLuongNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                mydb.openConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spLayBangLuong";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = mydb.getConnection;

                var rd = cmd.ExecuteReader();
                dtBangLuong.Clear();
                dtBangLuong.Load(rd);
                dgvBangLuongNV.DataSource = dtBangLuong;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu, Lỗi rồi!!!");
            }
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Course_list.txt";

            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                int bdate;

                for (int i = 0; i < dgvBangLuongNV.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvBangLuongNV.Rows.Count; j++)
                    {
                        if (j == 3)
                        {
                            bdate = Convert.ToInt32(dgvBangLuongNV.Rows[i].Cells[j].Value.ToString());
                            writer.Write("\t" + bdate.ToString("dd/MM/yyyy") + "\t" + "|");
                        }
                        else if (j == dgvBangLuongNV.Columns.Count - 2)
                        {
                            writer.Write("\t" + dgvBangLuongNV.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                        {
                           // writer.Write("\t" + dgvBangLuongNV.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                        }
                    }
                    writer.WriteLine("");
                    writer.WriteLine("------------------------------------------------------------------------------------");
                }
            }
        }


        
        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (dgvBangLuongNV.Rows.Count != 0)
            {
                int RowCount = dgvBangLuongNV.Rows.Count;
                int ColumnCount = dgvBangLuongNV.Columns.Count;

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                string oTemp = "";
                Object oMissing = System.Reflection.Missing.Value;

                for (int r = 0; r < RowCount - 1; r++)
                {
                    oTemp = "";
                    for (int c = 0; c < ColumnCount; c++)
                    {
                        oTemp = oTemp + dgvBangLuongNV.Rows[r].Cells[c].Value + "\t";
                    }
                    var oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    oPara1.Range.Text = oTemp;
                    oPara1.Range.InsertParagraphAfter();
                    
                    oTemp += "\n";
                }
                //save the file
                oDoc.SaveAs2(filename);
            }
        }


        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            object Nothing = System.Reflection.Missing.Value;
            var app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Add(Nothing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets[1];
            worksheet.Name = "WorkSheet";
            // Write data
            worksheet.Cells[1, 1] = "MaNV";
            worksheet.Cells[1, 2] = "Thang";
            worksheet.Cells[1, 3] = "Nam";
            worksheet.Cells[1, 4] = "So Ngay Di Lam";
            worksheet.Cells[1, 5] = "Luong co ban";
            worksheet.Cells[1, 6] = "Tong Phu cap";
            worksheet.Cells[1, 7] = "Tong luong";
            //worksheet.Cells[1, 8] = "Picture";


            //worksheet.Cells[2, 1] = dataGridView1.Rows[0].Cells[0].Value;

            for (int i = 0; i < dgvBangLuongNV.Rows.Count; i++)
            {
                for (int j = 0; j < dgvBangLuongNV.Columns.Count; j++)
                {
                    if (j == 3)
                    {
                        // DateTime bdate = Convert.ToDateTime(dgvBangLuongNV.Rows[i].Cells[j].Value);
                        // worksheet.Cells[i + 2, j + 1] = bdate.ToString("yyyy-MM-dd");
                    }
                    //string text01 = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    worksheet.Cells[i + 2, j + 1] = dgvBangLuongNV.Rows[i].Cells[j].Value;
                }
            }
            // Show save file dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                worksheet.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
                workBook.Close(false, Type.Missing, Type.Missing);
                app.Quit();
            }
        }

        private void btnWordExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (.docx)|.docx";
            sfd.FileName = "export.docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(dgvBangLuongNV, sfd.FileName);
            }
        }

        private void btnPDFExport_Click(object sender, EventArgs e)
        {
            if (dgvBangLuongNV.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dgvBangLuongNV.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dgvBangLuongNV.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dgvBangLuongNV.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Dữ liệu Export thành công!!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mô tả lỗi :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có bản ghi nào được Export!!!", "Info");
            }
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowCurrentPage = true;
            if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        }
    }
    }

