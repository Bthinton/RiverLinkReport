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

namespace RiverLink
{
    public partial class frmSettings : Form
    {        
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Reset();
            string encryptedUsername = RijndaelSimple.Encrypt<RijndaelManaged>(tboxUsername.Text, "username", "salt");
            string encryptedPassword = RijndaelSimple.Encrypt<RijndaelManaged>(tboxPassword.Text, "password", "salt");
            Properties.Settings.Default.Username = encryptedUsername;
            Properties.Settings.Default.Password = encryptedPassword;
            Properties.Settings.Default.Save();
            if (cbTestPW.Checked)
            {
                string decryptedUsername = RijndaelSimple.Decrypt<RijndaelManaged>(encryptedUsername, "username", "salt");
                string decryptedPassword = RijndaelSimple.Decrypt<RijndaelManaged>(encryptedPassword, "password", "salt");
                RiverLinkLogic.runHeadless = true;
                RiverLinkReport.CLI.Program.TestUsernameAndPassword(decryptedUsername, decryptedPassword);
                if (RiverLinkReport.CLI.Program.test == true)
                {
                    MessageBox.Show("The test of your Username and Password was successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The test of your Username and Password has failed.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                this.Close();
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
    }
}
