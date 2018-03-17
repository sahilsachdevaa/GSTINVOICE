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
    public partial class SelectCategory : Form
    {
        FrmCreateGSTINVOICE form;
        public SelectCategory(FrmCreateGSTINVOICE frmCreateGSTINVOICE)
        {
            form = frmCreateGSTINVOICE;
            InitializeComponent();
        }

        private void SelectCategory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gSTDataSet1.HSNCodetbl' table. You can move, or remove it, as needed.
            this.hSNCodetblTableAdapter.Fill(this.gSTDataSet1.HSNCodetbl);
            this.comboBox1.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(HelperClass.ConString);
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from Hsncodetbl where id =" + comboBox1.SelectedValue,conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedValue != null)
            {
                form.CatID = Convert.ToInt32(this.comboBox1.SelectedValue);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("please select any category");
                return;
            }
        }
    }
}
