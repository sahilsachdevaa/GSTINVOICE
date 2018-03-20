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


        private void ClearTextBoxes()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtCustomerMobile.Clear();
            txtCustomerGSTIN.Clear();
            txtEmail.Clear();
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var con = new OleDbConnection(HelperClass.ConString))
                {
                    var txt = sender as TextBox;
                    OleDbCommand cmd = new OleDbCommand("insert into [Customertbl] (CustomerName, Address,CustomerGSTIN,CustomerMobile,CustomerEmail) values ('" + txtName.Text + "' , '" + txtAddress.Text + "' , '" + txtCustomerGSTIN.Text + "', '" + txtCustomerMobile.Text + "','" + txtEmail.Text + "')", con);
                    con.Open();
                    if (txtName.Text == "")
                    {
                        MessageBox.Show("Please Enter CustomerName");
                        return;
                    }
                    else if (txtAddress.Text == "")
                    {
                        MessageBox.Show("Please Enter Address");
                        return;
                    }
                    else if (txtCustomerGSTIN.Text == "")
                    {
                        MessageBox.Show("Please Enter GSTIN");
                        return;
                    }
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
