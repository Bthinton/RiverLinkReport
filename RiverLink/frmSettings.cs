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
            string encryptedUsername = RijndaelSimple.Encrypt<RijndaelManaged>(tboxUsername.Text, "username", "salt");
            string encryptedPassword = RijndaelSimple.Encrypt<RijndaelManaged>(tboxPassword.Text, "password", "salt");
            Properties.Settings.Default.Username = encryptedUsername;
            Properties.Settings.Default.Password = encryptedPassword;
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
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
