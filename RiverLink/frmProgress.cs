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
    public partial class frmProgress : Form
    {
        public frmProgress()
        {
            InitializeComponent();
        }
        public delegate void ProgressEvent(object sender, ProgressEventArgs e);
        private event ProgressEvent onProgressEvent;
        public string action;

        public void SetProgressEvent(object sender, ProgressEventArgs e)
        {
            if (lblPrimary.InvokeRequired)
            {
                ProgressEvent d = new ProgressEvent(SetProgressEvent);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                lblPrimary.Text = e.PrimaryText;
                lblSecondary.Text = e.SecondaryText;                
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (action == "GetData")
            {
                RiverLinkReport.BAL.RiverLinkLogic Logic = new RiverLinkReport.BAL.RiverLinkLogic("https://riverlink.com/", 2000, 1000);
                Logic.Login("Ericallenpaul@hotmail.com", "!Sttng0812");
            }
            //for (int i = 1; i <= 50; i++)
            //{
            //    System.Threading.Thread.Sleep(200);
            //    backgroundWorker1.ReportProgress(i * 2);
            //    if (onProgressEvent != null)
            //    {
            //        for (int j = 1; j <= 100; j++)
            //        {
            //            onProgressEvent(this, new ProgressEventArgs($"Working on item {i}", $"Working on sub item {j}"));                       
            //        }
            //    }
            //}
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmProgress_Load(object sender, EventArgs e)
        {
            onProgressEvent += new ProgressEvent(SetProgressEvent);
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
    public class ProgressEventArgs : EventArgs
    {
        public ProgressEventArgs(string PrimaryT, string SecondaryT)
        {
            _PrimaryText = PrimaryT;
            _SecondaryText = SecondaryT;        
        }

        private string _PrimaryText;

        public string PrimaryText
        {
            get { return _PrimaryText; }
            set { _PrimaryText = value; }
        }

        private string _SecondaryText;

        public string SecondaryText
        {
            get { return _SecondaryText; }
            set { _SecondaryText = value; }
        }
    }
}
