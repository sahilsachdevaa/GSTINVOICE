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
    public partial class AddContracter : Form
    {
        bool iseditmode = false;
        string ConString = ConfigurationManager.ConnectionStrings["ApplicationForm.Properties.Settings.CMSMDataNewConnectionString"].ConnectionString;
        public AddContracter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new OleDbConnection(ConString))
                {
                    var txt = sender as TextBox;
                    OleDbCommand cmd = new OleDbCommand("insert into [tbl_Contractor] (Name, Address,City,PinCode,Mobile,GSTIN,UserName,Pswd) values ('" + txtName.Text + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtPinCode.Text + "','" + txtMobile.Text + "','" + txtGSTIN.Text + "','" + txtUserName.Text + "','"+txtPassword.Text+"')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Contrator Saved Successfully..!!");
                    new LoginForm().ShowDialog();
                    this.Close();
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
            txtAddress.Clear();
            txtCity.Clear();
            txtGSTIN.Clear();
            txtMobile.Clear();
            txtPinCode.Clear();
            txtPassword.Clear();
            txtUserName.Clear();
        }
    }
}
