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
    public partial class ViewInvoiceDetail : Form
    {
        public ViewInvoiceDetail()
        {
            InitializeComponent();
        }

        private void txtInvoice_Leave(object sender, EventArgs e)
        {
          try
            {
                if (txtInvoice.Text == "")
                {
                    MessageBox.Show("Please Enter Invoice No");
                }
                else
                {
                    var getValue = txtInvoice.Text;
                    OleDbConnection conn = new OleDbConnection(HelperClass.ConString);
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Customerid,invoiceDate,TotalInvoiceValue,Discount,TotalDiscountValue,TotalCgst,totalsgst,GrandTotal from BOSInvoicetbL where InvoiceNo='" + getValue + "'", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int value=Convert.ToInt16(dt.Rows[0][0]);
                    OleDbDataAdapter da1 = new OleDbDataAdapter("Select CustomerName from Customertbl where Id=" + value,conn);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    txtCustomer.Text = dt1.Rows[0][0].ToString();
                    
                    txtinvoicedate.Text = dt.Rows[0][1].ToString();
                    dataGridView1.Rows[0].Cells[2].Value = dt.Rows[0][2].ToString();
                    dataGridView1.Rows[0].Cells[3].Value = dt.Rows[0][3].ToString();
                    dataGridView1.Rows[0].Cells[4].Value = dt.Rows[0][4].ToString();
                    dataGridView1.Rows[0].Cells[5].Value = dt.Rows[0][5].ToString();
                    dataGridView1.Rows[0].Cells[7].Value = dt.Rows[0][6].ToString();
                    dataGridView1.Rows[0].Cells[9].Value = dt.Rows[0][7].ToString();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
