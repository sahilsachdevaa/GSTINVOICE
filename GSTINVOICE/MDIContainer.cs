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
    public partial class MDIContainer : Form
    {
        public LoginForm frmLogin { get; set; }
        public AddContracter FrmContracter { get; set; }
        public AddCustomerFrm FrmCustomer = new AddCustomerFrm();
        public AddProduct FrmProduct = new AddProduct();
        public AddCategory FrmCategory= new AddCategory();

        public MDIContainer()
        {
            InitializeComponent();
            this.menuStrip1.Visible = false;
            frmLogin = new LoginForm(this);
            FrmContracter = new AddContracter(this);
            CheckContractor();
            FrmCustomer.MdiParent = this;
            FrmProduct.MdiParent = this;
            FrmCategory.MdiParent = this;
        }
        

        
        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllMDIForms();
            FrmCustomer.Show();
        }

        private void addContracterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllMDIForms();
         //   FrmContracter.Show();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllMDIForms();
            FrmProduct.Show();
        }

        public void HideAllMDIForms()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Hide();
            }
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllMDIForms();
            FrmCategory.Show();
        }
        public void CheckContractor()
        {
            try
            {
                using (var con = new OleDbConnection(HelperClass.ConString))
                {
                    OleDbCommand cmd = new OleDbCommand("Select * from Contractortbl", con);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        frmLogin.Show();
                    }
                    else
                    {
                        FrmContracter.Show();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void EnableControls()
        {
            this.menuStrip1.Visible = true;
        }

    }

}
