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
    public partial class AddProduct : Form
    {
        bool iseditmode = false;
        string ConString = ConfigurationManager.ConnectionStrings["ApplicationForm.Properties.Settings.CMSMDataNewConnectionString"].ConnectionString;
        public AddProduct()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new OleDbConnection(ConString))
                {
                    var txt = sender as TextBox;
                    OleDbCommand cmd = new OleDbCommand("insert into [tbl_Product] (Product_Name,Product_Description,Product_Price) values ('" + txtName.Text + "' , '" + txtDescription.Text + "' , '" + txtPrice.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product Saved Successfully..!!");
                    this.ClearTextBoxes();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void ClearTextBoxes()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gSTInvoiceDataSet.tbl_Categories' table. You can move, or remove it, as needed.
            this.tbl_CategoriesTableAdapter.Fill(this.gSTInvoiceDataSet.tbl_Categories);

        }
    }
}
