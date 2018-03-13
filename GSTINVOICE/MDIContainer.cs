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
        public MDIContainer()
        {
            InitializeComponent();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addContracterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddContracter() { MdiParent = this }.Show();
        }
    }
}
