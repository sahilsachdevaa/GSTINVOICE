using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTINVOICE
{
    public partial class MDIContainer : Form
    {
        public static AddContracter FrmContracter = new AddContracter();

        public static AddCustomerFrm FrmCustomer = new AddCustomerFrm();

        public static AddProduct FrmProduct = new AddProduct();

        public MDIContainer()
        {
            InitializeComponent();
            FrmContracter.MdiParent = this;
            FrmCustomer.MdiParent = this;
            FrmProduct.MdiParent = this;
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllMDIForms();
            FrmCustomer.Show();
        }

        private void addContracterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllMDIForms();
            FrmContracter.Show();
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
    }
}
