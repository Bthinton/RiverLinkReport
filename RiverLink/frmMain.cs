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
            bsYear.DataSource = Years;
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYear.SelectedIndex != -1)
            {
                MessageBox.Show(cmbYear.SelectedItem.ToString());
            }
        }
    }
}
