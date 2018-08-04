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
    public partial class FrmSummaryDetail : Form
    {
        public string TransponderNumber { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

        public FrmSummaryDetail()
        {
            InitializeComponent();
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
    }
}
