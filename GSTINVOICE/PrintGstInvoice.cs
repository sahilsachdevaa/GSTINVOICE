using Microsoft.Reporting.WinForms;
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
    public partial class PrintGstInvoice : Form
    {
        public PrintGstInvoice()
        {
            InitializeComponent();
        }

        private void PrintGstInvoice_Load(object sender, EventArgs e)
        {
            DataSet contds = new DataSet();
            contds = GetContracterDataset("IN00001");
            DataSet custds = new DataSet();
            custds = GetCustomerDataset(11);
            DataSet gstransds = new DataSet();
            gstransds = GetGSTranDataset("IN00001");
            DataSet gsinvoiceds = new DataSet();
            gsinvoiceds = GetGSInvDataset("IN00001");

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
                    OleDbCommand cmd = new OleDbCommand("Select * from GSTInvoicetbl where invoiceno='"+p+"'", con);
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
            try
            {
                using (var con = new OleDbConnection(HelperClass.ConString))
                {
                    OleDbCommand cmd = new OleDbCommand("SELECT GstTransactions.GoodsDetail, HSNCodetbl.HSN_SAC, GstTransactions.Qty, GstTransactions.TotalSale, GstTransactions.TaxableValue, GstTransactions.discount, HSNCodetbl.GST, HSNCodetbl.CGST, HSNCodetbl.SGST, GstTransactions.TCGST, GstTransactions.TSGST FROM (GstTransactions INNER JOIN HSNCodetbl ON GstTransactions.CategoryId = HSNCodetbl.ID) where GstTransactions.invoiceID ='" + p + "'", con);
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
    }
}
