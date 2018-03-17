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
    public partial class FrmCreateGSTINVOICE : Form
    {
        bool isGstForm = true;
        public FrmCreateGSTINVOICE(bool v)
        {
            isGstForm = v;
            InitializeComponent();
            if (isGstForm)
            {
                this.label1.Text = "GST Invoice";
            }
            else
            {
                this.label1.Text = "Bill Of Supply"; 
            }
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
