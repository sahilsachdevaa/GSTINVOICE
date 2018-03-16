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
                    OleDbCommand cmd = new OleDbCommand("insert into [Customertbl] (CustomerName, Address,CustomerGSTIN,CustomerMobile) values ('" + txtName.Text + "' , '" + txtAddress.Text + "' , '" + txtCustomerGSTIN.Text + "', '" + txtCustomerMobile.Text + "')", con);
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
            txtCustomerMobile.Clear();
            txtCustomerGSTIN.Clear();
        }
    }
}
