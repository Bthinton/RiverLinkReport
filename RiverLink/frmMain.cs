using Microsoft.Win32;
using RiverLink.Models;
using RiverLinkReport.BAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;
using System.Windows.Forms;

//TODO
//Fix code so can count number of steps on progress bar


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

        private void lblTransponder_Click(object sender, EventArgs e)
        {
            frmSummaryDetail frm = new frmSummaryDetail(dgTransactions.DataSource);
            frm.Year = cmbYear.SelectedItem.ToString();
            frm.Month = cmbMonth.SelectedItem.ToString();
            frm.TransponderNumber = cmbTransponder.SelectedItem.ToString();
            frm.ShowDialog();

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
            if (Properties.Settings.Default.Username == "" || Properties.Settings.Default.Password == "")
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
    }
}
