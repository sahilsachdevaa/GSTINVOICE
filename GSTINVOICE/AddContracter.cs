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
        MDIContainer parent;
        string ConString = ConfigurationManager.ConnectionStrings["ApplicationForm.Properties.Settings.CMSMDataNewConnectionString"].ConnectionString;
        public AddContracter(MDIContainer mDIContainer)
        {
            this.parent = mDIContainer;
            this.MdiParent = this.parent;
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            txtContractorName.Clear();
            txtAddress.Clear();
            textBox3.Clear();
            txtEmailID.Clear();
            txtMobile.Clear();
            txtPassword.Clear();
            txtUserName.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new OleDbConnection(ConString))
                {
                    var txt = sender as TextBox;
                    OleDbCommand cmd = new OleDbCommand("insert into [Contractortbl] (ContractorName, Address,GSTIN,Mobile,EmailID,UserName,Pswd) values ('" + txtContractorName.Text + "','" + txtAddress.Text + "','" + textBox3.Text + "','" + txtMobile.Text + "','" + txtEmailID.Text + "','" + txtUserName.Text + "','" + txtPassword.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Contrator Saved Successfully..!!");
                    parent.frmLogin.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void AddContracter_Load(object sender, EventArgs e)
        {

        }
    }
}
