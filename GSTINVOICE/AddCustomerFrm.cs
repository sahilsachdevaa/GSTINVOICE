using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTINVOICE
{
    public partial class AddCustomerFrm : Form
    {
        public AddCustomerFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new OleDbConnection(HelperClass.ConString))
                {
                    var txt = sender as TextBox;
                    OleDbCommand cmd = new OleDbCommand("insert into [tbl_CustomerDetail] (Name, Address,City,PinCode,Mobile,GSTIN) values ('" + txtName.Text + "' , '" + txtAddress.Text + "' , '" + txtCity.Text + "', '" + txtPinCode.Text + "', '" + txtMobile.Text + "', '" + txtGSTIN.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer Saved Successfully..!!");
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
            txtAddress.Clear();
            txtCity.Clear();
            txtGSTIN.Clear();
            txtMobile.Clear();
            txtPinCode.Clear();
        }
    }
}
