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

//TODO Sort grid when column header is clicked
//Filter Grid by combobox choices
//filter out payments only show tolls
//add tab for payments and vehicles

namespace RiverLink
{
    public partial class frmMain : Form
    {

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
            List<int> Years = RiverLinkReport.BAL.RiverLinkLogic.GetYears();
            List<int> Months = RiverLinkReport.BAL.RiverLinkLogic.GetMonths();
            List<int> TransponderNumbers = RiverLinkReport.BAL.RiverLinkLogic.GetTransponderNumbers();      
            bsYear.DataSource = Years;
            bsMonth.DataSource = Months;
            bsTransponderNumber.DataSource = TransponderNumbers;
            LoadGridData();
            LoadVehiclePaymentGrid();
            foreach (DataGridViewColumn c in dgTransactions.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.Automatic;
                c.Selected = false;
            }
        }

        internal void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYear.SelectedIndex != -1)
            {
                MessageBox.Show(cmbYear.SelectedItem.ToString());
                LoadGridData();
                RiverLinkReport.BAL.RiverLinkLogic.year = int.Parse(cmbYear.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.transponderNumber = int.Parse(cmbTransponder.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.month = int.Parse(cmbMonth.SelectedItem.ToString());
                bsMonth.DataSource = new List<Transaction>();
                List<int> Months = RiverLinkReport.BAL.RiverLinkLogic.GetMonths();
                bsMonth.DataSource = Months;
                bsTransponderNumber.DataSource = new List<Transaction>();
                List<int> TransponderNumbers = RiverLinkReport.BAL.RiverLinkLogic.GetTransponderNumbers();
                bsTransponderNumber.DataSource = TransponderNumbers;
            }            
        }

        internal void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonth.SelectedIndex != -1)
            {
                LoadGridData();
                MessageBox.Show(cmbMonth.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.year = int.Parse(cmbYear.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.transponderNumber = int.Parse(cmbTransponder.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.month = int.Parse(cmbMonth.SelectedItem.ToString());
                bsTransponderNumber.DataSource = new List<Transaction>();
                List<int> TransponderNumbers = RiverLinkReport.BAL.RiverLinkLogic.GetTransponderNumbers();
                bsTransponderNumber.DataSource = TransponderNumbers;
            }
        }

        internal void cmbTransponder_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbTransponder.SelectedIndex != -1)
            {
                bsMonth.DataSource = new List<Transaction>();
                List<int> Months = RiverLinkReport.BAL.RiverLinkLogic.GetMonths();
                bsMonth.DataSource = Months;
                LoadGridData();
                MessageBox.Show(cmbTransponder.SelectedItem.ToString());
            }
        }

        private void LoadGridData()
        {
            RiverLinkReport.BAL.RiverLinkLogic.year = int.Parse(cmbYear.SelectedItem.ToString());
            RiverLinkReport.BAL.RiverLinkLogic.transponderNumber = int.Parse(cmbTransponder.SelectedItem.ToString());
            RiverLinkReport.BAL.RiverLinkLogic.month = int.Parse(cmbMonth.SelectedItem.ToString());
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
            bsTransaction.DataSource = Transactions.OrderBy("TransactionDate ASC").ToList();
        }

        private void dgPayments_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Transaction> Payments = RiverLinkReport.BAL.RiverLinkLogic.GetPayments();
            List<Transaction> SortedPaymentsList = Payments.OrderBy(t => t.TransactionDate).ToList();
            bsPayment.DataSource = SortedPaymentsList;
            
        }
    }
}
