namespace GSTINVOICE
{
    partial class PrintGstInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DS_Contractor = new GSTINVOICE.DS_Contractor();
            this.ContractortblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ContractortblTableAdapter = new GSTINVOICE.DS_ContractorTableAdapters.ContractortblTableAdapter();
            this.CommonDs = new GSTINVOICE.CommonDs();
            this.CustomertblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomertblTableAdapter = new GSTINVOICE.CommonDsTableAdapters.CustomertblTableAdapter();
            this.GstTransactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GstTransactionsTableAdapter = new GSTINVOICE.CommonDsTableAdapters.GstTransactionsTableAdapter();
            this.HSNCodetblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HSNCodetblTableAdapter = new GSTINVOICE.CommonDsTableAdapters.HSNCodetblTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Contractor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractortblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommonDs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomertblBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GstTransactionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HSNCodetblBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "rpt_Contactor";
            reportDataSource1.Value = this.ContractortblBindingSource;
            reportDataSource2.Name = "rpt_Customer";
            reportDataSource2.Value = this.CustomertblBindingSource;
            reportDataSource3.Name = "rpt_gsTrans";
            reportDataSource3.Value = this.GstTransactionsBindingSource;
            reportDataSource4.Name = "rpt_gsinvoice";
            reportDataSource4.Value = this.HSNCodetblBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GSTINVOICE.GSTINVOICErpt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1237, 510);
            this.reportViewer1.TabIndex = 0;
            // 
            // DS_Contractor
            // 
            this.DS_Contractor.DataSetName = "DS_Contractor";
            this.DS_Contractor.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ContractortblBindingSource
            // 
            this.ContractortblBindingSource.DataMember = "Contractortbl";
            this.ContractortblBindingSource.DataSource = this.DS_Contractor;
            // 
            // ContractortblTableAdapter
            // 
            this.ContractortblTableAdapter.ClearBeforeFill = true;
            // 
            // CommonDs
            // 
            this.CommonDs.DataSetName = "CommonDs";
            this.CommonDs.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CustomertblBindingSource
            // 
            this.CustomertblBindingSource.DataMember = "Customertbl";
            this.CustomertblBindingSource.DataSource = this.CommonDs;
            // 
            // CustomertblTableAdapter
            // 
            this.CustomertblTableAdapter.ClearBeforeFill = true;
            // 
            // GstTransactionsBindingSource
            // 
            this.GstTransactionsBindingSource.DataMember = "GstTransactions";
            this.GstTransactionsBindingSource.DataSource = this.CommonDs;
            // 
            // GstTransactionsTableAdapter
            // 
            this.GstTransactionsTableAdapter.ClearBeforeFill = true;
            // 
            // HSNCodetblBindingSource
            // 
            this.HSNCodetblBindingSource.DataMember = "HSNCodetbl";
            this.HSNCodetblBindingSource.DataSource = this.CommonDs;
            // 
            // HSNCodetblTableAdapter
            // 
            this.HSNCodetblTableAdapter.ClearBeforeFill = true;
            // 
            // PrintGstInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 510);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrintGstInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PrintGstInvoice";
            this.Load += new System.EventHandler(this.PrintGstInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS_Contractor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractortblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommonDs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomertblBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GstTransactionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HSNCodetblBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ContractortblBindingSource;
        private DS_Contractor DS_Contractor;
        private System.Windows.Forms.BindingSource CustomertblBindingSource;
        private CommonDs CommonDs;
        private System.Windows.Forms.BindingSource GstTransactionsBindingSource;
        private System.Windows.Forms.BindingSource HSNCodetblBindingSource;
        private DS_ContractorTableAdapters.ContractortblTableAdapter ContractortblTableAdapter;
        private CommonDsTableAdapters.CustomertblTableAdapter CustomertblTableAdapter;
        private CommonDsTableAdapters.GstTransactionsTableAdapter GstTransactionsTableAdapter;
        private CommonDsTableAdapters.HSNCodetblTableAdapter HSNCodetblTableAdapter;
    }
}