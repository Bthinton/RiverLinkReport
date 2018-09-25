using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiverLinkReport.BAL;
using RiverLinkReport.CLI;
using System.Threading;

namespace RiverLink
{
    public partial class frmSettings : Form
    {        
        public frmSettings()
        {
            InitializeComponent();
            ttSettings.SetToolTip(btnSave, "Use this button to save your Username and Password as the default Username and Password.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Reset();
            string encryptedUsername = RijndaelSimple.Encrypt<RijndaelManaged>(tboxUsername.Text, "username", "salt");
            string encryptedPassword = RijndaelSimple.Encrypt<RijndaelManaged>(tboxPassword.Text, "password", "salt");
            Properties.Settings.Default.Username = encryptedUsername;
            Properties.Settings.Default.Password = encryptedPassword;
            Properties.Settings.Default.Save();
            RiverLinkLogic.runHeadless = true;
            lblTest.Text = "Testing Password...";
            lblTest.ForeColor = Color.Blue;
            lblTest.Visible = true;
            RiverLinkReport.CLI.Program.TestUsernameAndPassword(encryptedUsername, encryptedPassword);
            if (RiverLinkReport.CLI.Program.test == true)
            {
                lblTest.ForeColor = Color.Green;
                lblTest.Text = "Successful";
            }
            else
            {
                lblTest.ForeColor = Color.Red;
                lblTest.Text = "Failed";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
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

        private void frmSettings_Load(object sender, EventArgs e)
        {
            lblTest.Text = "";
            lblTest.Visible = false;
        }
    }
}
