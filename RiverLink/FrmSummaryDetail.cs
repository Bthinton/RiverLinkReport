using ClosedXML.Excel;
using System;
using System.Windows.Forms;

//TODO Choose excel or csv for export

namespace RiverLink
{
    public partial class frmSummaryDetail : Form
    {
        bool sortAscending;
        public string TransponderNumber { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

        public frmSummaryDetail(object dataSource)
        {
            InitializeComponent();

            dgSummaryDetail.DataSource = dataSource;
        }

        private void FrmSummaryDetail_Load(object sender, EventArgs e)
        {
            string Message = $"Viewing Transponder Number: {TransponderNumber} For {Month}, {Year}.";
            lblSummaryText.Text = Message;           
        }

        private void btnSummaryClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       public void ExportWithFormatting(DataGridView dataGridView1)
       {
            
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*|csv files (*.csv)|*.csv",
                Title = "To Excel",
                FileName = this.Text + " (" + DateTime.Now.ToString("yyyy-MM-dd") + ")"
            };
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
                if (saveFileDialog1.FilterIndex == 3)
                {
                    int columnCount = dgSummaryDetail.ColumnCount;
                    string columnNames = "";
                    string[] output = new string[dgSummaryDetail.RowCount + 1];
                    for (int i = 0; i < columnCount; i++)
                    {
                        columnNames += dgSummaryDetail.Columns[i].Name.ToString() + ",";
                    }
                    output[0] += columnNames;
                    for (int i = 1; (i - 1) < dgSummaryDetail.RowCount; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            output[i] += dgSummaryDetail.Rows[i - 1].Cells[j].Value.ToString() + ",";
                        }
                    }
                    System.IO.File.WriteAllLines(saveFileDialog1.FileName, output, System.Text.Encoding.UTF8);
                }
                else
                {
                    string fileName = saveFileDialog1.FileName;
                    XLWorkbook workbook = new XLWorkbook();
                    IXLWorksheet worksheet = workbook.Worksheets.Add(this.Text);
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dataGridView1.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            if (worksheet.Cell(i + 2, j + 1).Value.ToString().Length > 0)
                            {
                                XLAlignmentHorizontalValues align;
                                switch (dataGridView1.Rows[i].Cells[j].Style.Alignment)
                                {
                                    case DataGridViewContentAlignment.BottomRight:
                                        align = XLAlignmentHorizontalValues.Right;
                                        break;
                                    case DataGridViewContentAlignment.MiddleRight:
                                        align = XLAlignmentHorizontalValues.Right;
                                        break;
                                    case DataGridViewContentAlignment.TopRight:
                                        align = XLAlignmentHorizontalValues.Right;
                                        break;
                                    case DataGridViewContentAlignment.BottomCenter:
                                        align = XLAlignmentHorizontalValues.Center;
                                        break;
                                    case DataGridViewContentAlignment.MiddleCenter:
                                        align = XLAlignmentHorizontalValues.Center;
                                        break;
                                    case DataGridViewContentAlignment.TopCenter:
                                        align = XLAlignmentHorizontalValues.Center;
                                        break;
                                    default:
                                        align = XLAlignmentHorizontalValues.Left;
                                        break;
                                }
                                worksheet.Cell(i + 2, j + 1).Style.Alignment.Horizontal = align;
                                XLColor xlColor = XLColor.FromColor(dataGridView1.Rows[i].Cells[j].Style.SelectionBackColor);
                                worksheet.Cell(i + 2, j + 1).AddConditionalFormat().WhenLessThan(1).Fill.SetBackgroundColor(xlColor);
                                worksheet.Cell(i + 2, j + 1).Style.Font.FontName = dataGridView1.Font.Name;
                                worksheet.Cell(i + 2, j + 1).Style.Font.FontSize = dataGridView1.Font.Size;
                            }
                        }
                    }
                    worksheet.Columns().AdjustToContents();
                    workbook.SaveAs(fileName);                 
                }
                MessageBox.Show("Export Successful!");
       }

        private void btnExport_Click(object sender, EventArgs e)
        { 
            ExportWithFormatting(dgSummaryDetail);
        }
    }
}
