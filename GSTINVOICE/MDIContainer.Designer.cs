namespace GSTINVOICE
{
    partial class MDIContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIContainer));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addContracterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewGSTInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBillOfSupplyInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1269, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.billInvoiceToolStripMenuItem,
            this.addContracterToolStripMenuItem,
            this.addCategoryToolStripMenuItem,
            this.productsToolStripMenuItem,
            this.viewGSTInvoiceToolStripMenuItem,
            this.viewBillOfSupplyInvoiceToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "File";
            // 
            // billInvoiceToolStripMenuItem
            // 
            this.billInvoiceToolStripMenuItem.Name = "billInvoiceToolStripMenuItem";
            this.billInvoiceToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.billInvoiceToolStripMenuItem.Text = "Bill of Supply";
            this.billInvoiceToolStripMenuItem.Click += new System.EventHandler(this.billInvoiceToolStripMenuItem_Click);
            // 
            // addContracterToolStripMenuItem
            // 
            this.addContracterToolStripMenuItem.Name = "addContracterToolStripMenuItem";
            this.addContracterToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.addContracterToolStripMenuItem.Text = "GST Invoice";
            this.addContracterToolStripMenuItem.Click += new System.EventHandler(this.addContracterToolStripMenuItem_Click);
            // 
            // addCategoryToolStripMenuItem
            // 
            this.addCategoryToolStripMenuItem.Name = "addCategoryToolStripMenuItem";
            this.addCategoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.addCategoryToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.addCategoryToolStripMenuItem.Text = "Add Category";
            this.addCategoryToolStripMenuItem.Click += new System.EventHandler(this.addCategoryToolStripMenuItem_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.productsToolStripMenuItem.Text = "Add Customer";
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.productsToolStripMenuItem_Click);
            // 
            // viewGSTInvoiceToolStripMenuItem
            // 
            this.viewGSTInvoiceToolStripMenuItem.Name = "viewGSTInvoiceToolStripMenuItem";
            this.viewGSTInvoiceToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.viewGSTInvoiceToolStripMenuItem.Text = "View GST Invoice";
            this.viewGSTInvoiceToolStripMenuItem.Click += new System.EventHandler(this.viewGSTInvoiceToolStripMenuItem_Click);
            // 
            // viewBillOfSupplyInvoiceToolStripMenuItem
            // 
            this.viewBillOfSupplyInvoiceToolStripMenuItem.Name = "viewBillOfSupplyInvoiceToolStripMenuItem";
            this.viewBillOfSupplyInvoiceToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.viewBillOfSupplyInvoiceToolStripMenuItem.Text = "View Bill of Supply Invoice";
            this.viewBillOfSupplyInvoiceToolStripMenuItem.Click += new System.EventHandler(this.viewBillOfSupplyInvoiceToolStripMenuItem_Click);
            // 
            // MDIContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 436);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDIContainer";
            this.Text = "GST Invoice ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addContracterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewGSTInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewBillOfSupplyInvoiceToolStripMenuItem;
    }
}

