namespace GSTINVOICE
{
    partial class ViewInvoiceDetail
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.goodDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hsccode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalsale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Taxableval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cgst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cgstamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sgstamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdSgstAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtinvoicedate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtgrandtotal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txttotalsgst = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txttotalCgst = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txttotalTaxval = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txttotaldiscounts = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txttotalinvoice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.goodDesc,
            this.Hsccode,
            this.Quantity,
            this.Rate,
            this.totalsale,
            this.Discount,
            this.Taxableval,
            this.cgst,
            this.cgstamount,
            this.Sgstamount,
            this.grdSgstAmount,
            this.catid});
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1149, 214);
            this.dataGridView1.TabIndex = 3;
            // 
            // goodDesc
            // 
            this.goodDesc.HeaderText = "Description of Goods";
            this.goodDesc.Name = "goodDesc";
            this.goodDesc.ReadOnly = true;
            this.goodDesc.Width = 250;
            // 
            // Hsccode
            // 
            this.Hsccode.HeaderText = "HSE/SAC Code";
            this.Hsccode.Name = "Hsccode";
            this.Hsccode.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Qty.";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 50;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            // 
            // totalsale
            // 
            this.totalsale.HeaderText = "Total Sale";
            this.totalsale.Name = "totalsale";
            this.totalsale.ReadOnly = true;
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            // 
            // Taxableval
            // 
            this.Taxableval.HeaderText = "Taxable Value";
            this.Taxableval.Name = "Taxableval";
            this.Taxableval.ReadOnly = true;
            // 
            // cgst
            // 
            this.cgst.HeaderText = "CGST Rate %";
            this.cgst.Name = "cgst";
            this.cgst.ReadOnly = true;
            this.cgst.Width = 50;
            // 
            // cgstamount
            // 
            this.cgstamount.HeaderText = "Amount";
            this.cgstamount.Name = "cgstamount";
            this.cgstamount.ReadOnly = true;
            // 
            // Sgstamount
            // 
            this.Sgstamount.HeaderText = "SGST Rate %";
            this.Sgstamount.Name = "Sgstamount";
            this.Sgstamount.ReadOnly = true;
            this.Sgstamount.Width = 50;
            // 
            // grdSgstAmount
            // 
            this.grdSgstAmount.HeaderText = "Amount";
            this.grdSgstAmount.Name = "grdSgstAmount";
            this.grdSgstAmount.ReadOnly = true;
            // 
            // catid
            // 
            this.catid.HeaderText = "Column1";
            this.catid.Name = "catid";
            this.catid.ReadOnly = true;
            this.catid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.catid.Width = 5;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(187, 80);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(147, 20);
            this.txtInvoice.TabIndex = 4;
            this.txtInvoice.Leave += new System.EventHandler(this.txtInvoice_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Invoice No";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(511, 76);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(251, 20);
            this.txtCustomer.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Customer Name\r\n";
            // 
            // txtinvoicedate
            // 
            this.txtinvoicedate.Location = new System.Drawing.Point(988, 74);
            this.txtinvoicedate.Name = "txtinvoicedate";
            this.txtinvoicedate.Size = new System.Drawing.Size(147, 20);
            this.txtinvoicedate.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(883, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Invoice date";
            // 
            // txtgrandtotal
            // 
            this.txtgrandtotal.Location = new System.Drawing.Point(1078, 529);
            this.txtgrandtotal.Name = "txtgrandtotal";
            this.txtgrandtotal.ReadOnly = true;
            this.txtgrandtotal.Size = new System.Drawing.Size(143, 20);
            this.txtgrandtotal.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(926, 532);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 51;
            this.label12.Text = "Grand Total";
            // 
            // txttotalsgst
            // 
            this.txttotalsgst.Location = new System.Drawing.Point(1078, 503);
            this.txttotalsgst.Name = "txttotalsgst";
            this.txttotalsgst.ReadOnly = true;
            this.txttotalsgst.Size = new System.Drawing.Size(143, 20);
            this.txttotalsgst.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(926, 506);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Total SGST";
            // 
            // txttotalCgst
            // 
            this.txttotalCgst.Location = new System.Drawing.Point(1078, 477);
            this.txttotalCgst.Name = "txttotalCgst";
            this.txttotalCgst.ReadOnly = true;
            this.txttotalCgst.Size = new System.Drawing.Size(143, 20);
            this.txttotalCgst.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(926, 480);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "Total CGST";
            // 
            // txttotalTaxval
            // 
            this.txttotalTaxval.Location = new System.Drawing.Point(1078, 451);
            this.txttotalTaxval.Name = "txttotalTaxval";
            this.txttotalTaxval.ReadOnly = true;
            this.txttotalTaxval.Size = new System.Drawing.Size(143, 20);
            this.txttotalTaxval.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(926, 454);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Total Taxable Value";
            // 
            // txttotaldiscounts
            // 
            this.txttotaldiscounts.Location = new System.Drawing.Point(1078, 425);
            this.txttotaldiscounts.Name = "txttotaldiscounts";
            this.txttotaldiscounts.ReadOnly = true;
            this.txttotaldiscounts.Size = new System.Drawing.Size(143, 20);
            this.txttotaldiscounts.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(926, 428);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Total Discounts";
            // 
            // txttotalinvoice
            // 
            this.txttotalinvoice.Location = new System.Drawing.Point(1078, 399);
            this.txttotalinvoice.Name = "txttotalinvoice";
            this.txttotalinvoice.ReadOnly = true;
            this.txttotalinvoice.Size = new System.Drawing.Size(143, 20);
            this.txttotalinvoice.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(926, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Total Invoice value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1073, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 45;
            this.label5.Text = "Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(925, 375);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 20);
            this.label9.TabIndex = 44;
            this.label9.Text = "Summary";
            // 
            // ViewInvoiceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 518);
            this.Controls.Add(this.txtgrandtotal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txttotalsgst);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txttotalCgst);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txttotalTaxval);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txttotaldiscounts);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txttotalinvoice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtinvoicedate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewInvoiceDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ViewInvoiceDetail";
            this.Load += new System.EventHandler(this.ViewInvoiceDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hsccode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalsale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Taxableval;
        private System.Windows.Forms.DataGridViewTextBoxColumn cgst;
        private System.Windows.Forms.DataGridViewTextBoxColumn cgstamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sgstamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdSgstAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn catid;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtinvoicedate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtgrandtotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txttotalsgst;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txttotalCgst;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txttotalTaxval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txttotaldiscounts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txttotalinvoice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
    }
}