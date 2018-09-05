using OpenQA.Selenium.Chrome;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using RiverLinkReport.BAL;
using System.Security.Cryptography;
using OpenQA.Selenium;

namespace RiverLink
{

    //TODO Bring window to front after launch
    //Add lbl for testing password on settings page remove checkbox
    //New form for entering bank data for payment verification display via grid, allow user input via separate window
    //add button tooltips to helpify the app
    //Make cli menu work
    //Extra credit: Data variance display via pdf
    //display how much charged, how much they recorded charged, how much was actually taken out of the bank

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
        public IWebDriver driver;

        public void SetProgressEvent(object sender, ProgressEventArgs e)
        {
        }

        public void Logic_PrimaryStatusChanged(string Message)
        {
            if (lblPrimary.InvokeRequired)
            {
                lblPrimary.Invoke((MethodInvoker)(() => lblPrimary.Text = Message));
            }
            else
            {
                lblPrimary.Text = Message;
            }
        }

        public void Logic_SecondaryStatusChanged(string Message)
        {
            if (lblSecondary.InvokeRequired)
            {
                lblSecondary.Invoke((MethodInvoker)(() => lblSecondary.Text = Message));
            }
            else
            {
                lblSecondary.Text = Message;
            }
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            driver = RiverLinkLogic.GetNewDriver();
            RiverLinkLogic Logic = new RiverLinkLogic("https://riverlink.com/", 2000, 1000, driver);
            Logic.PrimaryStatusChanged += Logic_PrimaryStatusChanged;
            Logic.SecondaryStatusChanged += Logic_SecondaryStatusChanged;
            if (onProgressEvent != null)
            {
                onProgressEvent(this, new ProgressEventArgs($"Working on item 1", $"Working on sub item 1"));
                Logic.Login(decryptedUsername, decryptedPassword);
                backgroundWorker1.ReportProgress(25);

                onProgressEvent(this, new ProgressEventArgs($"Working on item 2", $"Working on sub item 1"));
                Logic.GetData();
                backgroundWorker1.ReportProgress(75);

                onProgressEvent(this, new ProgressEventArgs($"Working on item 3", $"Working on sub item 1"));
                Logic.InsertData();
                backgroundWorker1.ReportProgress(100);
                System.Threading.Thread.Sleep(1000);               
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
