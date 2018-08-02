using RiverLink.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic;

//TODO Display transpondernumber, count of total crossings, calculated $ amount
// Be able to drill down to that specific set of transactions
// put grid in summary detail and display data that goes with it
// add export button on dialog box 
// add close button to bottom right
// add button main form "refresh data" add checkbox that says "show browser" to hide or display browser while getting data

namespace RiverLink
{
    public partial class frmMain : Form
    {
        bool shouldFireYear = true;
        bool shouldFireMonth = true;
        bool shouldFireTransponderNumber = true;
        bool shouldFireFormLoad;
        bool sortAscending;

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
        }

        private void SetDataSources(string Month, string Year, string TransponderNumber)
        {
            shouldFireYear = false;
            shouldFireMonth = false;
            shouldFireTransponderNumber = false;
            //Clears all existing data sources
            bsYear.DataSource = null;
            bsMonth.DataSource = null;

            RiverLinkReport.BAL.RiverLinkLogic.year = ParseSelectedValue(Year);
            RiverLinkReport.BAL.RiverLinkLogic.month = ParseSelectedValue(Month);
            RiverLinkReport.BAL.RiverLinkLogic.transponderNumber = ParseSelectedValue(TransponderNumber);

            //Populate Year Data source
            List<string> Years = RiverLinkReport.BAL.RiverLinkLogic.GetYears();
            bsYear.DataSource = Years;

            //Reset the selected Year inside combobox          
            cmbYear.SelectedIndex = Years.IndexOf(Year);

            //Populate Month data source
            List<string> Months = RiverLinkReport.BAL.RiverLinkLogic.GetMonths();
            bsMonth.DataSource = Months;

            //Reset the selected Month inside combobox            
            cmbMonth.SelectedIndex = Months.IndexOf(Month);

            //Populate Transpondernumber data source
            List<string> TransponderNumbers = RiverLinkReport.BAL.RiverLinkLogic.GetTransponderNumbers();
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
            List<Transaction> Transactions = RiverLinkReport.BAL.RiverLinkLogic.GetTransactions();
            bsTransaction.DataSource = Transactions;
        }

        private void LoadVehiclePaymentGrid()
        {
            List<Transaction> Payments = RiverLinkReport.BAL.RiverLinkLogic.GetPayments();
            bsPayment.DataSource = Payments;
            List<Vehicle> Vehicles = RiverLinkReport.BAL.RiverLinkLogic.GetVehicles();
            bsVehicle.DataSource = Vehicles;
        }

        private void dgTransactions_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Transaction> Transactions = RiverLinkReport.BAL.RiverLinkLogic.GetTransactions();
            if (sortAscending)
                dgTransactions.DataSource = Transactions.OrderBy(dgTransactions.Columns[e.ColumnIndex].DataPropertyName).ToList();
            else
                dgTransactions.DataSource = Transactions.OrderBy(dgTransactions.Columns[e.ColumnIndex].DataPropertyName).Reverse().ToList();
            sortAscending = !sortAscending;
        }

        private void dgPayments_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Transaction> Payments = RiverLinkReport.BAL.RiverLinkLogic.GetPayments();
            if (sortAscending)
                dgPayments.DataSource = Payments.OrderBy(dgPayments.Columns[e.ColumnIndex].DataPropertyName).ToList();
            else
                dgPayments.DataSource = Payments.OrderBy(dgPayments.Columns[e.ColumnIndex].DataPropertyName).Reverse().ToList();
            sortAscending = !sortAscending;
        }

        private void dgVehicles_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Vehicle> Vehicles = RiverLinkReport.BAL.RiverLinkLogic.GetVehicles();
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
            FrmSummaryDetail frm = new FrmSummaryDetail();
            frm.Year = 2000;
            frm.Month = 11;
            frm.TransponderNumber = 13;
            frm.ShowDialog();
        }
    }
}
