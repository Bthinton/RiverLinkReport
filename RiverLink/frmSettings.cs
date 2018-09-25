using RiverLinkReport.BAL;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace RiverLink
{
    public partial class frmSettings : Form
    {        
        public frmSettings()
        {
            InitializeComponent();
            ttSettings.SetToolTip(btnSave, "Use this button to save your Username and Password as the default Username and Password.");
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string encryptedUsername = RijndaelSimple.Encrypt<RijndaelManaged>(tboxUsername.Text, "username", "salt");
            string encryptedPassword = RijndaelSimple.Encrypt<RijndaelManaged>(tboxPassword.Text, "password", "salt");
            if (encryptedUsername != Properties.Settings.Default.Username || encryptedPassword != Properties.Settings.Default.Password)
            {
                Properties.Settings.Default.Username = encryptedUsername;
                Properties.Settings.Default.Password = encryptedPassword;
                Properties.Settings.Default.Save();
                RiverLinkLogic.runHeadless = true;
                lblTest.Text = "Testing Password...";
                lblTest.ForeColor = Color.Blue;
                lblTest.Visible = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (backgroundWorker1.CancellationPending != true)
            {
                System.Threading.Thread.Sleep(1000);
                RiverLinkReport.CLI.Program.TestUsernameAndPassword(Properties.Settings.Default.Username, Properties.Settings.Default.Password);
                if (RiverLinkReport.CLI.Program.test == true)
                {
                    lblTest.Invoke((MethodInvoker)(() => lblTest.ForeColor = Color.Green));
                    lblTest.Invoke((MethodInvoker)(() => lblTest.Text = "Successful"));
                }
                else
                {
                    lblTest.Invoke((MethodInvoker)(() => lblTest.ForeColor = Color.Red));
                    lblTest.Invoke((MethodInvoker)(() => lblTest.Text = "Failed"));
                }
                backgroundWorker1.CancelAsync();
            }
            if (backgroundWorker1.CancellationPending == true)
            {
                e.Cancel = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPassword.Checked)
            {
                tboxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tboxPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
