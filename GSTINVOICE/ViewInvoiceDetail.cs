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
        private bool isGstForm;

        public ViewInvoiceDetail()
        {
            InitializeComponent();
        }

        public ViewInvoiceDetail(bool p):this()
        {
            // TODO: Complete member initialization
            this.isGstForm = p;
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
                    OleDbDataAdapter da = new OleDbDataAdapter("Select Customerid,invoiceDate,TotalInvoiceValue,TotalDiscountValue,TotalCgst,totalsgst,GrandTotal from BOSInvoicetbL where InvoiceNo='" + getValue + "'", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int value = Convert.ToInt16(dt.Rows[0][0]);
                    OleDbDataAdapter da1 = new OleDbDataAdapter("Select CustomerName from Customertbl where Id=" + value, conn);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    txtCustomer.Text = dt1.Rows[0][0].ToString();
                    
                    txtinvoicedate.Text = dt.Rows[0][1].ToString();
                    txttotalinvoice.Text = dt.Rows[0][2].ToString();
                    txttotaldiscounts.Text= dt.Rows[0][3].ToString();
                    txttotalCgst.Text= dt.Rows[0][4].ToString();
                    txttotalsgst.Text = dt.Rows[0][5].ToString();
                    txtgrandtotal.Text= dt.Rows[0][6].ToString();
                    var InvoiceValue = Convert.ToDouble(txttotalinvoice.Text);
                    var TotalDisVal= Convert.ToDouble(txttotaldiscounts.Text);
                    txttotalTaxval.Text = (InvoiceValue - TotalDisVal).ToString();
                    }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ViewInvoiceDetail_Load(object sender, EventArgs e)
        {
            txtInvoice.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtInvoice.AutoCompleteCustomSource = AutoCompleteLoad();
            txtInvoice.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        
        public AutoCompleteStringCollection AutoCompleteLoad()
        {
            OleDbConnection conn = new OleDbConnection(HelperClass.ConString);
            OleDbDataAdapter da = new OleDbDataAdapter("Select InvoiceNo from GstInvoicetbl ", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();

            for (int i = 0; i < dt.Rows.Count; i++)

                str.Add(dt.Rows[i][0].ToString());

            return str;

        }
    }
}
