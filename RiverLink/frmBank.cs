using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RiverLink
{
    public partial class frmBank : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Wurmskull\source\repos\RiverLinkReport\RiverLink.DAL\DB\RLinkData.mdf;Initial Catalog=RLinkDB;Integrated Security=True;Connection Timeout=5;");
        int ID = frmMain.ID;

        public frmBank()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbDate.Text != String.Empty && tbAmount.Text != string.Empty)
            {             
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into BankTransaction values('" + tbDate.Text + "', '" + tbAmount.Text + "', '" + tbComment.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please fill out both the Date and Amount boxes.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                SqlCommand cmd = new SqlCommand("delete BankTransaction where Transaction_Id=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                DialogResult = DialogResult.OK;
                MessageBox.Show("Record Deleted Successfully!");
                ID = 0;
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
    }
}
