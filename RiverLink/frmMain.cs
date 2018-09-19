using Microsoft.Win32;
using RiverLink.Models;
using RiverLinkReport.BAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace RiverLink
{
    public partial class frmMain : Form
    {
        bool shouldFireYear = true;
        bool shouldFireMonth = true;
        bool shouldFireTransponderNumber = true;
        bool shouldFireFormLoad;
        bool sortAscending;
        object path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "", null);
        public static int ID = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            filter();
            LoadVehiclePaymentGrid();
            ttMain.SetToolTip(btnExport, "Use this button to export data from the transaction grid.");
            ttMain.SetToolTip(btnBankTrans, "Use this button to enter in your bank transactions for comparison.");
            ttMain.SetToolTip(btnExit, "Use this button to exit the application.");
            ttMain.SetToolTip(btnRefreshData, "Use this button to gather all Vehicle, Transponder, and Transaction data.");
            ttMain.SetToolTip(cbHeadless, "Checking this box will make 'Refresh Data' run in the background.");
        }

        internal void filter()
        {
            string Year = "All";
            string Month = "All";
            string TransponderNumber = "All";
            if (cmbYear.SelectedIndex != -1)
            {
                Year = cmbYear.SelectedItem.ToString();
            }
            if (cmbMonth.SelectedIndex != -1)
            {
                Month = cmbMonth.SelectedItem.ToString();
            }
            if (cmbTransponder.SelectedIndex != -1)
            {
                TransponderNumber = cmbTransponder.SelectedItem.ToString();
            }
            SetDataSources(Month, Year, TransponderNumber);
            lblTransponder.Text = "Transponder Number: ";
            lblTransponder.Text = lblTransponder.Text + cmbTransponder.SelectedItem;
            lblTotalCrossings.Text = "Total Crossings: ";
            lblTotalCrossings.Text = lblTotalCrossings.Text + dgTransactions.Rows.Count;
            lblCalcCost.Text = "Calculated Cost: $";
            lblCalcCost.Text = lblCalcCost.Text + calculateTotalCost();
        }

        private void SetDataSources(string Month, string Year, string TransponderNumber)
        {
            shouldFireYear = false;
            shouldFireMonth = false;
            shouldFireTransponderNumber = false;
            //Clears all existing data sources
            bsYear.DataSource = null;
            bsMonth.DataSource = null;

            RiverLinkLogic.year = ParseSelectedValue(Year);
            RiverLinkLogic.month = ParseSelectedValue(Month);
            RiverLinkLogic.transponderNumber = ParseSelectedValue(TransponderNumber);

            //Populate Year Data source
            List<string> Years = RiverLinkLogic.GetYears();
            bsYear.DataSource = Years;

            //Reset the selected Year inside combobox          
            cmbYear.SelectedIndex = Years.IndexOf(Year);

            //Populate Month data source
            List<string> Months = RiverLinkLogic.GetMonths();
            bsMonth.DataSource = Months;

            //Reset the selected Month inside combobox            
            cmbMonth.SelectedIndex = Months.IndexOf(Month);

            //Populate Transpondernumber data source
            List<string> TransponderNumbers = RiverLinkLogic.GetTransponderNumbers();
            bsTransponderNumber.DataSource = TransponderNumbers;

            //Reset the selected Transponder inside combobox
            cmbTransponder.SelectedIndex = TransponderNumbers.IndexOf(TransponderNumber);

            //Reload grid data based on selected options
            LoadGridData();
            shouldFireFormLoad = true;
            shouldFireYear = true;
            shouldFireMonth = true;
            shouldFireTransponderNumber = true;
        }

        private int ParseSelectedValue(string valueToParse)
        {
            if (valueToParse == "All")
            {
                return 0;
            }
            else
            {
                return int.Parse(valueToParse);
            }
        }

        private void LoadGridData()
        {
            List<Transaction> Transactions = RiverLinkLogic.GetTransactions();
            bsTransaction.DataSource = Transactions;
            List<BankTransaction> bankTransactions = RiverLinkLogic.GetBankTransactions();
            bsBankTransactions.DataSource = bankTransactions;
        }

        private void LoadVehiclePaymentGrid()
        {
            List<Transaction> Payments = RiverLinkLogic.GetPayments();
            bsPayment.DataSource = Payments;
            List<Vehicle> Vehicles = RiverLinkLogic.GetVehicles();
            bsVehicle.DataSource = Vehicles;
        }

        private void dgTransactions_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Transaction> Transactions = RiverLinkLogic.GetTransactions();
            if (sortAscending)
                dgTransactions.DataSource = Transactions.OrderBy(dgTransactions.Columns[e.ColumnIndex].DataPropertyName).ToList();
            else
                dgTransactions.DataSource = Transactions.OrderBy(dgTransactions.Columns[e.ColumnIndex].DataPropertyName).Reverse().ToList();
            sortAscending = !sortAscending;
        }

        private void dgPayments_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Transaction> Payments = RiverLinkLogic.GetPayments();
            if (sortAscending)
                dgPayments.DataSource = Payments.OrderBy(dgPayments.Columns[e.ColumnIndex].DataPropertyName).ToList();
            else
                dgPayments.DataSource = Payments.OrderBy(dgPayments.Columns[e.ColumnIndex].DataPropertyName).Reverse().ToList();
            sortAscending = !sortAscending;
        }

        private void dgVehicles_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Vehicle> Vehicles = RiverLinkLogic.GetVehicles();
            if (sortAscending)
                dgVehicles.DataSource = Vehicles.OrderBy(dgVehicles.Columns[e.ColumnIndex].DataPropertyName).ToList();
            else
                dgVehicles.DataSource = Vehicles.OrderBy(dgVehicles.Columns[e.ColumnIndex].DataPropertyName).Reverse().ToList();
            sortAscending = !sortAscending;
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shouldFireFormLoad && shouldFireYear)
            {
                filter();
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shouldFireFormLoad && shouldFireMonth)
            {
                filter();
            }
        }

        private void cmbTransponder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shouldFireFormLoad && shouldFireTransponderNumber)
            {
                filter();
            }
        }

        private double calculateTotalCost(double sum = 0)
        {            
            for (int i = 0; i < dgTransactions.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dgTransactions.Rows[i].Cells[8].Value);
            }
            sum = Math.Round(sum, 2);
            if (cmbYear.SelectedIndex != 0 && cmbMonth.SelectedIndex != 0 && cmbTransponder.SelectedIndex != 0)
            {
                if (dgTransactions.Rows.Count >= 40)
                {
                    return sum / 2;
                }
            }       
            return sum;
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Username == string.Empty || Properties.Settings.Default.Password == string.Empty)
            {
                frmSettings settings = new frmSettings();
                settings.ShowDialog();
                if (settings.DialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (cbHeadless.Checked)
            {
                RiverLinkLogic.runHeadless = true;
            }
            else
            {
                RiverLinkLogic.runHeadless = false;
            }

            if (path == null)
            {
                frmChrome frmC = new frmChrome();
                if (frmC.ShowDialog() == DialogResult.Cancel)
                {
                    Application.Exit();
                }
                else
                {
                    checkChrome();
                }
            }
         
            frmProgress frm = new frmProgress();
            if (frm.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("User Cancelled");
            }
            else
            {
                MessageBox.Show("Completed");
            }
        }

        public void checkChrome()
        {
            //path = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "", null);        
            //path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "", null);
            if (path == null)
            {
                Process.Start("http://dl.google.com/chrome/install/375.126/chrome_installer.exe");                
                Process.Start(@"C:\Users\" + Environment.UserName + @"\Downloads\ChromeSetup.exe");
            }
            path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "", null);
        }

        private void enterUsernamePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
        }

        private void resetUsernamePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Would you like to reset your default password?", "Reset Username/Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                if (Properties.Settings.Default.Username == "" || Properties.Settings.Default.Password == "")
                {
                    MessageBox.Show("You have successfully reset your default Username and Password.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                             
            }
            else
            {
                MessageBox.Show("You have not reset your default Username and Password.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportWithFormatting(dgTransactions);
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
                int columnCount = dgTransactions.ColumnCount;
                string columnNames = "";
                string[] output = new string[dgTransactions.RowCount + 1];
                for (int i = 0; i < columnCount; i++)
                {
                    columnNames += dgTransactions.Columns[i].Name.ToString() + ",";
                }
                output[0] += columnNames;
                for (int i = 1; (i - 1) < dgTransactions.RowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        output[i] += dgTransactions.Rows[i - 1].Cells[j].Value.ToString() + ",";
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

        private void btnBankTrans_Click(object sender, EventArgs e)
        {
            frmBank bank = new frmBank();
            bank.ShowDialog();
            bsBankTransactions.DataSource = null;
            List<BankTransaction> bankTransactions = RiverLinkLogic.GetBankTransactions();
            bsBankTransactions.DataSource = bankTransactions;           
        }

        private void dgBankTrans_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dgBankTrans.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
    }
}
