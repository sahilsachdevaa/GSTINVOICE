using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTINVOICE
{
    public partial class PrintGstInvoice : Form
    {
        string invoiceid;
        bool IsGstForm;
        public PrintGstInvoice(string invoiceid, bool isGstform = true)
        {
            this.IsGstForm = isGstform;
            this.invoiceid = invoiceid;
            InitializeComponent();
        }

        private void PrintGstInvoice_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            reportViewer1.Visible = true;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            var asem = Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(asem);
            if (this.IsGstForm)
            this.reportViewer1.LocalReport.ReportPath = path + "\\GSTINVOICErpt.rdlc";
            else
            this.reportViewer1.LocalReport.ReportPath = path + "\\BOSINVOICErpt.rdlc";

            DataSet contds = new DataSet();
            contds = GetContracterDataset(invoiceid);

            DataSet gstransds = new DataSet();
            gstransds = GetGSTranDataset(invoiceid);

            DataSet gsinvoiceds = new DataSet();
            gsinvoiceds = GetGSInvDataset(invoiceid);

            int id = 0;
            var custid = gsinvoiceds.Tables[0].Rows[0][2];
            if (custid != null)
            {
                id = Convert.ToInt32(custid);
            }

            DataSet custds = new DataSet();
            custds = GetCustomerDataset(id);
            
            if (contds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rdscont = new ReportDataSource("rpt_Contactor", contds.Tables[0]);
                ReportDataSource rdscust = new ReportDataSource("rpt_Customer", custds.Tables[0]);
                ReportDataSource rdsgstinv = new ReportDataSource("rpt_GstTrans", gstransds.Tables[0]);
                ReportDataSource rdsgstrans = new ReportDataSource("rpt_gsinvoice", gsinvoiceds.Tables[0]);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rdscont);
                reportViewer1.LocalReport.DataSources.Add(rdscust);
                reportViewer1.LocalReport.DataSources.Add(rdsgstrans);
                reportViewer1.LocalReport.DataSources.Add(rdsgstinv);
                reportViewer1.LocalReport.Refresh();
                reportViewer1.RefreshReport();
            }



            this.reportViewer1.RefreshReport();
        }

        private DataSet GetGSInvDataset(string p)
        {
            try
            {
                using (var con = new OleDbConnection(HelperClass.ConString))
                {
                    OleDbCommand cmd = new OleDbCommand("Select * from " + (IsGstForm ? "GSTInvoicetbl" : "BOSInvoicetbl") + " where invoiceno='" + p + "'", con);
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
            if (this.IsGstForm)
            {
                query = "SELECT GstTransactions.GoodsDetail, HSNCodetbl.HSN_SAC, GstTransactions.Qty, GstTransactions.TotalSale, GstTransactions.TaxableValue, GstTransactions.discount, HSNCodetbl.GST, HSNCodetbl.CGST, HSNCodetbl.SGST, GstTransactions.TCGST, GstTransactions.TSGST FROM (GstTransactions INNER JOIN HSNCodetbl ON GstTransactions.CategoryId = HSNCodetbl.ID) where GstTransactions.invoiceID ='" + p + "'";
            }
            else
            {
                query = "SELECT BOSTransactions.GoodsDetail, HSNCodetbl.HSN_SAC, BOSTransactions.Qty, BOSTransactions.TotalSale, BOSTransactions.TaxableValue, BOSTransactions.discount, HSNCodetbl.GST, HSNCodetbl.CGST, HSNCodetbl.SGST, BOSTransactions.TCGST, BOSTransactions.TSGST FROM (BOSTransactions INNER JOIN HSNCodetbl ON BOSTransactions.CategoryId = HSNCodetbl.ID) where BOSTransactions.invoiceID ='" + p + "'";
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
                    OleDbCommand cmd = new OleDbCommand("Select * from customertbl where id="+p, con);
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

        private DataSet GetContracterDataset(string p)
        {
            try
            {
                using (var con = new OleDbConnection(HelperClass.ConString))
                {
                    OleDbCommand cmd = new OleDbCommand("Select * from contractortbl",con);
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

        private void reportViewer1_PrintingBegin(object sender, ReportPrintEventArgs e)
        {
            this.Hide();
        }
    }
}
