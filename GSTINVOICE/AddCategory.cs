using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTINVOICE
{
    public partial class AddCategory : Form
    {
        string ConString = ConfigurationManager.ConnectionStrings["ApplicationForm.Properties.Settings.CMSMDataNewConnectionString"].ConnectionString;
        public AddCategory()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new OleDbConnection(ConString))
                {
                    OleDbCommand cmd = new OleDbCommand("insert into [tbl_Categories] (Name, Description,GST,CGST,SGST,IGST) values ('" + txtName.Text + "','" + txtDescription.Text + "','" + txtGST.Text + "','" + txtCGST.Text + "','" + txtSGST.Text + "','" + txtIGST.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Category Saved Successfully..!!");
                    this.ClearTextBoxes();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ClearTextBoxes()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtGST.Clear();
            txtCGST.Clear();
            txtSGST.Clear();
            txtIGST.Clear();
        }
    }
}
