using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GSTINVOICE
{
    public partial class FrmCreateGSTINVOICE : Form
    {
        bool isGstForm = true;
        public int CatID { get; set; }
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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int column = dataGridView1.CurrentCell.ColumnIndex;

            if (column == 0)
            {
                try
                {
                    var result = new SelectCategory(this).ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        var categoryid = this.CatID;
                        this.UpdateGridOnCategorySelection();
                    }
                    
                    dataGridView1.CurrentRow.Cells[11].Value = this.CatID;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            try
            {
                if (column == 3 || column == 2 || column == 5)
                {
                    var qty = dataGridView1.CurrentRow.Cells[2].Value;
                    var amount = dataGridView1.CurrentRow.Cells[3].Value;
                    var cgst = dataGridView1.CurrentRow.Cells[7].Value;
                    var sgst = dataGridView1.CurrentRow.Cells[9].Value;
                    var getdiscountvalue = dataGridView1.CurrentRow.Cells[5].Value;
                    if (amount != null && cgst != null && sgst != null && qty != null && getdiscountvalue !=null)
                    {
                        
                        double rate = Convert.ToDouble(amount);
                        double totalsale = Convert.ToDouble(qty) * rate;
                        double cgstamount = ((double)cgst * totalsale / 100);
                        double sgstamount = ((double)sgst * totalsale / 100);
                        double totaltax = cgstamount + sgstamount;
                        dataGridView1.CurrentRow.Cells[4].Value = totalsale;
                        dataGridView1.CurrentRow.Cells[6].Value = totaltax;
                        dataGridView1.CurrentRow.Cells[8].Value = cgstamount;
                        dataGridView1.CurrentRow.Cells[10].Value = sgstamount;
                        double sumtotalsale = 0;
                        double sumtotalcgst = 0;
                        double sumtotalsgst = 0;
                        double sumtotaldiscount =0;

                        for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                        {
                            double addtotalsalevalue = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) + Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                            double discount = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                            sumtotaldiscount += (addtotalsalevalue * discount / 100);
                            sumtotalcgst += Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                            sumtotalsgst += Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                            sumtotalsale += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                        }

                        txttotalCgst.Text = sumtotalcgst.ToString();
                        txttotalsgst.Text = sumtotalsgst.ToString();
                        txttotalinvoice.Text = sumtotalsale.ToString();
                        txttotaldiscounts.Text = sumtotaldiscount.ToString();
                        txttotalTaxval.Text = (sumtotalcgst + sumtotalsgst).ToString();
                        txtgrandtotal.Text = (sumtotalsale + sumtotalcgst + sumtotalsgst - sumtotaldiscount).ToString();
                    }
                }
            }
            catch (Exception ke)
            {


            }

        }

        private void UpdateGridOnCategorySelection()
        {
            OleDbConnection conn = new OleDbConnection(HelperClass.ConString);
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from Hsncodetbl where id =" + this.CatID, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.CurrentRow.Cells[1].Value = dt.Rows[0][2];
            dataGridView1.CurrentRow.Cells[7].Value = dt.Rows[0][5];
            dataGridView1.CurrentRow.Cells[9].Value = dt.Rows[0][6];
            dataGridView1.CurrentRow.Cells[5].Value = 0;
            DataGridViewCell cell = dataGridView1.CurrentRow.Cells[2];
            dataGridView1.CurrentCell = cell;
            dataGridView1.BeginEdit(true);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void FrmCreateGSTINVOICE_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(HelperClass.ConString);
            string query = string.Empty;

            if (isGstForm)
            {
                query = "Select * from GSTInvoicetbl";
            }
            else
            {
                query = "Select * from BOSInvoicetbl";
            }

            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int counter = dt.Rows.Count;
            string invoice = this.genrateInvoiceCode(counter + 1);
            txtInvoice.Text = invoice;
            txtinvoicedate.Text = DateTime.Now.ToShortDateString();
            txtCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCustomer.AutoCompleteCustomSource = AutoCompleteLoad();
            txtCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private string genrateInvoiceCode(int counter)
        {
            var str = counter.ToString();
            if (str.Length == 0)
            {
                return string.Empty;
            }

            if (str.Length == 1)
            {
                str = "0000" + str;
            }
            if (str.Length == 2)
            {
                str = "000" + str;
            }
            if (str.Length == 3)
            {
                str = "00" + str;
            }
            if (str.Length == 4)
            {
                str = "00" + str;
            }

            if (this.isGstForm)
            {
                return "IN" + str;
            }
            return "BS" + str;
        }

        private string genrateInvoiceCode()
        {
            throw new NotImplementedException();
        }

        public AutoCompleteStringCollection AutoCompleteLoad()

        {
            OleDbConnection conn = new OleDbConnection(HelperClass.ConString);
            OleDbDataAdapter da = new OleDbDataAdapter("Select CustomerName from Customertbl ", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();

            for (int i = 0; i < dt.Rows.Count; i++)

                str.Add(dt.Rows[i][0].ToString());

            return str;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveTextBoxValues();
            SaveGridData();
            MessageBox.Show("Record Saved Succesfully");
            this.btnSave.Enabled = false;
        }

        private void SaveGridData()
        {
            OleDbConnection conn = new OleDbConnection(HelperClass.ConString);
            OleDbCommand cmd = new OleDbCommand();
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                StringBuilder cmdtext = new StringBuilder();
                var invoiceno = this.txtInvoice.Text;
                var GoodsDetail = dataGridView1.Rows[i].Cells[0].Value;
                var CategoryId = dataGridView1.Rows[i].Cells[11].Value;
                var discount = dataGridView1.Rows[i].Cells[5].Value ?? 0;
                var Qty = dataGridView1.Rows[i].Cells[2].Value;
                var TotalSale = dataGridView1.Rows[i].Cells[4].Value;
                var TaxableValue = dataGridView1.Rows[i].Cells[6].Value;
                if (GoodsDetail == null)
                {
                    break;
                }

                if (isGstForm)
                {
                    cmdtext.AppendLine("insert into [GstTransactions] " +
                       "(GoodsDetail, CategoryId,discount,Qty,TotalSale,TaxableValue,InvoiceID) values" +
                       " ('" + GoodsDetail + "',"
                       + CategoryId + "," + discount + "," + Qty + ","
                       + TotalSale + "," + TaxableValue
                       + ",'" + invoiceno + "')");
                }
                else
                {
                    cmdtext.AppendLine("insert into [BOSTransactions] " +
           "(GoodsDetail, CategoryId,discount,Qty,TotalSale,TaxableValue,InvoiceID) values" +
           " ('" + GoodsDetail + "',"
           + CategoryId + "," + discount + "," + Qty + ","
           + TotalSale + "," + TaxableValue
           + ",'" + invoiceno + "')");

                }
                cmd.Connection = conn;
                cmd.CommandText = cmdtext.ToString();
                cmd.ExecuteNonQuery();
             }
            conn.Close();
          }

        public void SaveTextBoxValues()
        {
            OleDbConnection conn = new OleDbConnection(HelperClass.ConString);
            string sql = null;
            DateTime date = Convert.ToDateTime(txtinvoicedate.Text);
            OleDbDataAdapter da = new OleDbDataAdapter("Select ID from Customertbl where CustomerName ='" + txtCustomer.Text+"'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int getid =Convert.ToInt16(dt.Rows[0][0]);


            string query = "insert into " + (isGstForm ? "[GSTInvoicetbl]": "[BOSInvoicetbl]") +
                "(InvoiceNo, customerid,invoiceDate,TotalInvoiceValue,Discount,TotalDiscountValue,TotalCgst,totalsgst,GrandTotal) values" +
                " ('" + txtInvoice.Text + "'," + getid + ",'"
                + date + "'," + txttotalinvoice.Text + ",0,"
                + txttotaldiscounts.Text + "," + txttotalCgst.Text
                + "," + txttotalCgst.Text + "," + txtgrandtotal.Text + ")";

            OleDbCommand cmd = new OleDbCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
           }
    }
}
