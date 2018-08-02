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
        public int TransponderNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public FrmSummaryDetail()
        {
            InitializeComponent();
        }

        private void FrmSummaryDetail_Load(object sender, EventArgs e)
        {
            string Message = $"Viewing Transponder Number: {TransponderNumber} For {Month} {Year}.";
            lblSummaryText.Text = Message;
        }
    }
}
