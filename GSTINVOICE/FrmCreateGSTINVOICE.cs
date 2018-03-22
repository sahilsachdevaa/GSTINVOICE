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
        bool isEditForm = false;
        bool isGstForm = true;
        public int CatID { get; set; }
        public FrmCreateGSTINVOICE(bool isGst, bool isedit)
        {
            isGstForm = isGst;
            isEditForm = isedit;
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
                    if (amount != null && cgst != null && sgst != null && qty != null && getdiscountvalue != null)
                    {

                        double rate = Convert.ToDouble(amount);
                        double totalsale = Convert.ToDouble(qty) * rate;
                        double totaltax = 0;
                        double dis = Convert.ToDouble(getdiscountvalue);
                        if (dis > 0)
                            totaltax = totalsale - (totalsale * dis / 100);
                        else
                            totaltax = totalsale;

                        double cgstamount = ((double)cgst * totaltax / 100);
                        double sgstamount = ((double)sgst * totaltax / 100);

                        dataGridView1.CurrentRow.Cells[4].Value = Math.Ceiling(totalsale);
                        dataGridView1.CurrentRow.Cells[6].Value = Math.Ceiling(totaltax);
                        dataGridView1.CurrentRow.Cells[8].Value = Math.Ceiling(cgstamount);
                        dataGridView1.CurrentRow.Cells[10].Value = Math.Ceiling(sgstamount);
                        double sumtotalsale = 0;
                        double sumtotalcgst = 0;
                        double sumtotalsgst = 0;
                        double sumtotaldiscount = 0;

                        for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                        {
                            double addtotalsalevalue = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                            double discount = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                            sumtotaldiscount += Math.Ceiling((addtotalsalevalue * discount / 100));
                            sumtotalcgst += Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                            sumtotalsgst += Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                            sumtotalsale += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                        }

                        txttotalCgst.Text = sumtotalcgst.ToString();
                        txttotalsgst.Text = sumtotalsgst.ToString();
                        txttotalinvoice.Text = sumtotalsale.ToString();
                        txttotaldiscounts.Text = sumtotaldiscount.ToString();
                        txttotalTaxval.Text = (sumtotalsale - sumtotaldiscount).ToString();
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

            if (!isEditForm)
            {
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
            else
            {
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtInvoice.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtInvoice.AutoCompleteCustomSource = AutoCompleteLoad();
                txtInvoice.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtInvoice.ReadOnly = false;
                txtInvoice.Focus();
            }
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
            if (!isEditForm)
            {
                OleDbConnection conn = new OleDbConnection(HelperClass.ConString);
                OleDbDataAdapter da = new OleDbDataAdapter("Select CustomerName, CustomerGSTIN from Customertbl ", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                AutoCompleteStringCollection str = new AutoCompleteStringCollection();

                for (int i = 0; i < dt.Rows.Count; i++)

                    str.Add(dt.Rows[i][0].ToString() + " : " + dt.Rows[i][1].ToString());

                return str;
            }
            else
            {
                string query = string.Empty;
                if (isGstForm)
                {
                    query = "Select InvoiceNo from GSTInvoicetbl";
                }
                else
                {
                    query = "Select InvoiceNo from BOSInvoicetbl";
                }

                OleDbConnection conn = new OleDbConnection(HelperClass.ConString);
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                AutoCompleteStringCollection str = new AutoCompleteStringCollection();

                for (int i = 0; i < dt.Rows.Count; i++)

                    str.Add(dt.Rows[i][0].ToString());

                return str;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isEditForm)
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value == null && dataGridView1.Rows[i].Cells[1].Value == null)
                        {
                            break;
                        }

                        var ts = (double)dataGridView1.Rows[i].Cells[4].Value;
                        var tta = (double)dataGridView1.Rows[i].Cells[6].Value;
                    }

                    if (string.IsNullOrEmpty(txtCustomer.Text) || string.IsNullOrEmpty(txtCustomer.Text))
                    {
                        MessageBox.Show("please check fields");
                        return;
                    }

                    SaveTextBoxValues();
                    SaveGridData();
                    MessageBox.Show("Invoice Saved Succesfully");
                    this.btnSave.Enabled = false;
                    this.button2.Visible = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error Validating invoice");
                }
            }
            else
            {
                this.UpdateInvoiceData();
                this.UpdateGridData();
                this.SaveGridData();
                MessageBox.Show("Invoice Updated Succesfully");
                this.btnSave.Enabled = false;
                this.button2.Visible = true;
            }
        }

        public void UpdateInvoiceData()
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(HelperClass.ConString);
                string update = "Update "+(isGstForm?"GSTInvoicetbl":"BOSInvoicetbl")+" set invoiceDate='" + txtinvoicedate.Text + "',TotalInvoiceValue=" + txttotalinvoice.Text + ",TotalDiscountValue=" + txttotaldiscounts.Text + ",TotalCgst=" + txttotalCgst.Text + ",totalsgst=" + txttotalsgst.Text + ",GrandTotal=" + txtgrandtotal.Text + " where InvoiceNo='"+txtInvoice.Text+"'";
                OleDbCommand cmd=new OleDbCommand(update,conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public void UpdateGridData()
        {
            OleDbConnection conn = new OleDbConnection(HelperClass.ConString);
            string update = "delete from " + (isGstForm ? "GSTTransactions" : "BOSTransactions") + " where InvoiceId='" + txtInvoice.Text + "'";
            OleDbCommand cmd = new OleDbCommand(update, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
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
                var totalCGST = dataGridView1.Rows[i].Cells[8].Value;
                var totalSGST = dataGridView1.Rows[i].Cells[10].Value;
                if (GoodsDetail == null)
                {
                    break;
                }

                if (isGstForm)
                {
                    cmdtext.AppendLine("insert into [GstTransactions] " +
                       "(GoodsDetail, CategoryId,discount,Qty,TotalSale,TaxableValue,InvoiceID,TCGST,TSGST) values" +
                       " ('" + GoodsDetail + "',"
                       + CategoryId + "," + discount + "," + Qty + ","
                       + TotalSale + "," + TaxableValue
                       + ",'" + invoiceno + "'," + totalCGST + "," + totalSGST + ")");
                }
                else
                {
                    cmdtext.AppendLine("insert into [BOSTransactions] " +
           "(GoodsDetail, CategoryId,discount,Qty,TotalSale,TaxableValue,InvoiceID,TCGST,TSGST) values" +
           " ('" + GoodsDetail + "',"
           + CategoryId + "," + discount + "," + Qty + ","
           + TotalSale + "," + TaxableValue
           + ",'" + invoiceno + "'," + totalCGST + "," + totalSGST + ")");

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
            var obj = txtCustomer.Text.Split();

            OleDbDataAdapter da = new OleDbDataAdapter("Select ID from Customertbl where CustomerGSTIN ='" + obj[2] + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int getid = Convert.ToInt16(dt.Rows[0][0]);


            string query = "insert into " + (isGstForm ? "[GSTInvoicetbl]" : "[BOSInvoicetbl]") +
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.txtinvoicedate.Text = dateTimePicker1.Value.Date.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void ClearForm()
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
            if (!isEditForm)
            {
                string invoice = this.genrateInvoiceCode(counter + 1);
                txtInvoice.Text = invoice;
            }

            dataGridView1.Rows.Clear();
            txttotalCgst.Clear();
            txttotaldiscounts.Clear();
            txttotalsgst.Clear();
            txttotalTaxval.Clear();
            txtgrandtotal.Clear();
            txtCustomer.Clear();
            txtCustomer.Focus();
            txttotalinvoice.Clear();
            btnSave.Enabled = true;
            button2.Visible = false;
        }

        private void txtCustomer_Leave(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new PrintGstInvoice(txtInvoice.Text, isGstForm).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (isEditForm)
                {
                    this.ClearForm();
                    this.dataGridView1.Rows.Clear();

                    try
                    {
                        this.FillFormData();
                    }
                    catch (Exception eg)
                    {
                        MessageBox.Show("No record found");
                    }
                }
            }
        }

        private void FillFormData()
        {
            string invoice = txtInvoice.Text;
            if (isEditForm)
            {
                if (string.IsNullOrEmpty(invoice) || string.IsNullOrWhiteSpace(invoice))
                {
                    MessageBox.Show("Please Enter Valid Invoice ID");
                    return;
                }
            }


            DataSet gstransds = new DataSet();
            gstransds = GetGSTranDataset(invoice);

            DataSet gsinvoiceds = new DataSet();
            gsinvoiceds = GetGSInvDataset(invoice);

            int id = 0;
            var custid = gsinvoiceds.Tables[0].Rows[0][2];
            if (custid != null)
            {
                id = Convert.ToInt32(custid);
            }

            DataSet custds = new DataSet();
            custds = GetCustomerDataset(id);


            txtCustomer.Text = custds.Tables[0].Rows[0][1].ToString() + " : " + custds.Tables[0].Rows[0][3].ToString();
            txtgrandtotal.Text = gsinvoiceds.Tables[0].Rows[0][9].ToString();
            txtinvoicedate.Text = gsinvoiceds.Tables[0].Rows[0][3].ToString();
            txttotalCgst.Text = gsinvoiceds.Tables[0].Rows[0][7].ToString();
            txttotalsgst.Text = gsinvoiceds.Tables[0].Rows[0][8].ToString();
            txttotalinvoice.Text = gsinvoiceds.Tables[0].Rows[0][4].ToString();
            txttotaldiscounts.Text = gsinvoiceds.Tables[0].Rows[0][6].ToString();
            var InvoiceValue = Convert.ToDouble(txttotalinvoice.Text);
            var TotalDisVal = Convert.ToDouble(txttotaldiscounts.Text);
            txttotalTaxval.Text = (InvoiceValue - TotalDisVal).ToString();

            for (int i = 0; i < gstransds.Tables[0].Rows.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                dataGridView1.Rows.Add(row);
            }

            for (int i = 0; i < gstransds.Tables[0].Rows.Count; i++)
            {

                var totalinvoice = Convert.ToDouble(gstransds.Tables[0].Rows[i][3]);
                var qty = Convert.ToDouble(gstransds.Tables[0].Rows[i][2]);
                double rate = totalinvoice / qty;

                dataGridView1.Rows[i].Cells[0].Value = gstransds.Tables[0].Rows[i][0];
                dataGridView1.Rows[i].Cells[1].Value = gstransds.Tables[0].Rows[i][1];
                dataGridView1.Rows[i].Cells[2].Value = gstransds.Tables[0].Rows[i][2];
                dataGridView1.Rows[i].Cells[3].Value = rate;
                dataGridView1.Rows[i].Cells[4].Value = gstransds.Tables[0].Rows[i][3];
                dataGridView1.Rows[i].Cells[5].Value = gstransds.Tables[0].Rows[i][5];
                dataGridView1.Rows[i].Cells[6].Value = gstransds.Tables[0].Rows[i][4];
                dataGridView1.Rows[i].Cells[7].Value = gstransds.Tables[0].Rows[i][7];
                dataGridView1.Rows[i].Cells[9].Value = gstransds.Tables[0].Rows[i][8];
                dataGridView1.Rows[i].Cells[8].Value = gstransds.Tables[0].Rows[i][9];
                dataGridView1.Rows[i].Cells[10].Value = gstransds.Tables[0].Rows[i][10];
                dataGridView1.Rows[i].Cells[11].Value = gstransds.Tables[0].Rows[i][11];
                dataGridView1.Rows[i].Cells[12].Value = gstransds.Tables[0].Rows[i][12];

            }

        }



        private DataSet GetGSInvDataset(string p)
        {
            try
            {
                using (var con = new OleDbConnection(HelperClass.ConString))
                {
                    OleDbCommand cmd = new OleDbCommand("Select * from " + (isGstForm ? "GSTInvoicetbl" : "BOSInvoicetbl") + " where invoiceno='" + p + "'", con);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private DataSet GetGSTranDataset(string p)
        {
            string query = string.Empty;
            if (this.isGstForm)
            {
                query = "SELECT GstTransactions.GoodsDetail, HSNCodetbl.HSN_SAC, GstTransactions.Qty, GstTransactions.TotalSale, GstTransactions.TaxableValue, GstTransactions.discount, HSNCodetbl.GST, HSNCodetbl.CGST, HSNCodetbl.SGST, GstTransactions.TCGST, GstTransactions.TSGST,HSNCodetbl.ID,GstTransactions.ID FROM (GstTransactions INNER JOIN HSNCodetbl ON GstTransactions.CategoryId = HSNCodetbl.ID) where GstTransactions.invoiceID ='" + p + "'";
            }
            else
            {
                query = "SELECT BOSTransactions.GoodsDetail, HSNCodetbl.HSN_SAC, BOSTransactions.Qty, BOSTransactions.TotalSale, BOSTransactions.TaxableValue, BOSTransactions.discount, HSNCodetbl.GST, HSNCodetbl.CGST, HSNCodetbl.SGST, BOSTransactions.TCGST, BOSTransactions.TSGST, HSNCodetbl.ID,BOSTransactions.ID FROM (BOSTransactions INNER JOIN HSNCodetbl ON BOSTransactions.CategoryId = HSNCodetbl.ID) where BOSTransactions.invoiceID ='" + p + "'";
            }

            try
            {
                using (var con = new OleDbConnection(HelperClass.ConString))
                {
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private DataSet GetCustomerDataset(int p)
        {
            try
            {
                using (var con = new OleDbConnection(HelperClass.ConString))
                {
                    OleDbCommand cmd = new OleDbCommand("Select * from customertbl where id=" + p, con);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtinvoicedate.Text = dateTimePicker2.Value.Date.ToShortDateString();
        }

    }
}
