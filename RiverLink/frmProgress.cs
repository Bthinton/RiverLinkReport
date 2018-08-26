﻿using OpenQA.Selenium.Chrome;
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
            string decryptedUsername = RijndaelSimple.Decrypt<RijndaelManaged>(Properties.Settings.Default.Username, "username", "salt");
            string decryptedPassword = RijndaelSimple.Decrypt<RijndaelManaged>(Properties.Settings.Default.Password, "password", "salt");
            if (action == "GetData")
            {
                if (RiverLinkLogic.runHeadless == false)
                {
                    Program.showConsole = true;
                    Program.Console();
                }
                RiverLinkLogic Logic = new RiverLinkLogic("https://riverlink.com/", 2000, 1000);
                Logic.Login(decryptedUsername, decryptedPassword);
                Logic.GetData();
                Logic.InsertData();
                this.Close();
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
