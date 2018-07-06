using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        //Populate Month/Transponder Drop downs
        //Allow dropdowns to respond to eachother
        private void frmMain_Load(object sender, EventArgs e)
        {
            List<int> Years = RiverLinkReport.BAL.RiverLinkLogic.GetYears();
            List<int> Months = RiverLinkReport.BAL.RiverLinkLogic.GetMonths();
            List<int> TransponderNumbers = RiverLinkReport.BAL.RiverLinkLogic.GetTransponderNumbers();
            bsYear.DataSource = Years;
            bsMonth.DataSource = Months;
            bsTransponderNumber.DataSource = TransponderNumbers;
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYear.SelectedIndex != -1)
            {
                MessageBox.Show(cmbYear.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.year = int.Parse(cmbYear.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.transponderNumber = int.Parse(cmbTransponder.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.month = int.Parse(cmbMonth.SelectedItem.ToString());
                bsMonth.DataSource = null;
                List<int> Months = RiverLinkReport.BAL.RiverLinkLogic.GetMonths();
                bsMonth.DataSource = Months;
            }

        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonth.SelectedIndex != -1)
            {
                MessageBox.Show(cmbMonth.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.year = int.Parse(cmbYear.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.transponderNumber = int.Parse(cmbTransponder.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.month = int.Parse(cmbMonth.SelectedItem.ToString());
                bsTransponderNumber.DataSource = null;
                List<int> TransponderNumbers = RiverLinkReport.BAL.RiverLinkLogic.GetTransponderNumbers();
                bsTransponderNumber.DataSource = TransponderNumbers;
            }

        }

        private void cmbTransponder_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbTransponder.SelectedIndex != -1)
            {
                MessageBox.Show(cmbTransponder.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.year = int.Parse(cmbYear.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.transponderNumber = int.Parse(cmbTransponder.SelectedItem.ToString());
                RiverLinkReport.BAL.RiverLinkLogic.month = int.Parse(cmbMonth.SelectedItem.ToString());
                bsMonth.DataSource = null;
                List<int> Months = RiverLinkReport.BAL.RiverLinkLogic.GetMonths();
                bsMonth.DataSource = Months;
            }

        }
    }
}
