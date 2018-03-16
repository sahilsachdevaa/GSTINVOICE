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
        {
            container = mDIContainer;
            this.MdiParent = container;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
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
                    int count = ds.Tables[0].Rows.Count;
                    if (count == 1)
                    {
                        this.isloginsuccess = true;
<<<<<<< HEAD
                       
                       // Application.Run(new MDIContainer());
                        this.Hide();
                        this.container.EnableControls();
>>>>>>> f4f726cd1dee03bcb26b1b08d6cd6729f209d5f4
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

        public  bool CustomDialog()
        {
            this.Show();
            return this.isloginsuccess;
        }
    }
}
