using OpenQA.Selenium.Chrome;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using RiverLinkReport.BAL;
using System.Security.Cryptography;

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
        private readonly string decryptedUsername = RijndaelSimple.Decrypt<RijndaelManaged>(Properties.Settings.Default.Username, "username", "salt");
        private readonly string decryptedPassword = RijndaelSimple.Decrypt<RijndaelManaged>(Properties.Settings.Default.Password, "password", "salt");

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
            if (RiverLinkLogic.runHeadless == false)
            {
                Program.showConsole = true;
                Program.Console();
            }
            RiverLinkLogic Logic = new RiverLinkLogic("https://riverlink.com/", 2000, 1000);
            for (int i = 1; i <= 50; i++)
            {
                System.Threading.Thread.Sleep(200);
                if (onProgressEvent != null)
                {
                    for (int j = 1; j <= 100; j++)
                    {
                        switch (j)
                        {
                            case 1:
                                onProgressEvent(this, new ProgressEventArgs($"Working on item {i}", $"Working on sub item {j}"));
                                Logic.Login(decryptedUsername, decryptedPassword);
                                backgroundWorker1.ReportProgress(25);
                                break;
                            case 2:
                                onProgressEvent(this, new ProgressEventArgs($"Working on item {i}", $"Working on sub item {j}"));
                                Logic.GetData();
                                backgroundWorker1.ReportProgress(75);
                                break;
                            case 3:
                                onProgressEvent(this, new ProgressEventArgs($"Working on item {i}", $"Working on sub item {j}"));
                                Logic.InsertData();
                                backgroundWorker1.ReportProgress(100);
                                System.Threading.Thread.Sleep(3000);
                                break;
                            case 4:
                                break;
                            default:
                                return;
                        }                       
                    }
                }
            }
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
