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
    public partial class LoginForm : Form
    {
        MDIContainer container;
        bool isloginsuccess = false;
        string ConString = ConfigurationManager.ConnectionStrings["ApplicationForm.Properties.Settings.CMSMDataNewConnectionString"].ConnectionString;
        public LoginForm(MDIContainer mDIContainer)
        {
            container = mDIContainer;
            this.MdiParent = container;
            InitializeComponent();
        }

    
        public  bool CustomDialog()
        {
            this.Show();
            return this.isloginsuccess;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var con = new OleDbConnection(ConString))
                {
                    OleDbCommand cmd = new OleDbCommand("Select * from Contractortbl where UserName='" + txtUserName.Text + "' and pswd='" + txtPassword.Text + "'", con);
                    con.Open();
                    OleDbDataAdapter adapt = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    con.Close();
                    if (txtUserName.Text == "")
                    {
                        MessageBox.Show("Please Enter User Name");
                        return;
                    }
                    else if(txtPassword.Text == "")
                    {
                        MessageBox.Show("Please Enter Password");
                        return;
                    }
                    
                    int count = ds.Tables[0].Rows.Count;
                    
                    if (count == 1)
                    {
                        this.isloginsuccess = true;
                        this.Hide();
                        this.container.EnableControls();
                    }

                    else
                    {
                        MessageBox.Show("Login Failed!");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
