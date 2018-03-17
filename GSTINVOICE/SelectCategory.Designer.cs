namespace GSTINVOICE
{
    partial class SelectCategory
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gSTDataSet = new GSTINVOICE.GSTDataSet();
            this.gSTDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gSTDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gSTDataSet1 = new GSTINVOICE.GSTDataSet();
            this.hSNCodetblBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hSNCodetblTableAdapter = new GSTINVOICE.GSTDataSetTableAdapters.HSNCodetblTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSTDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSTDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSTDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hSNCodetblBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.hSNCodetblBindingSource;
            this.comboBox1.DisplayMember = "Description";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(149, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(363, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(48, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(753, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // gSTDataSet
            // 
            this.gSTDataSet.DataSetName = "GSTDataSet";
            this.gSTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gSTDataSetBindingSource
            // 
            this.gSTDataSetBindingSource.DataSource = this.gSTDataSet;
            this.gSTDataSetBindingSource.Position = 0;
            // 
            // gSTDataSetBindingSource1
            // 
            this.gSTDataSetBindingSource1.DataSource = this.gSTDataSet;
            this.gSTDataSetBindingSource1.Position = 0;
            // 
            // gSTDataSet1
            // 
            this.gSTDataSet1.DataSetName = "GSTDataSet";
            this.gSTDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hSNCodetblBindingSource
            // 
            this.hSNCodetblBindingSource.DataMember = "HSNCodetbl";
            this.hSNCodetblBindingSource.DataSource = this.gSTDataSet1;
            // 
            // hSNCodetblTableAdapter
            // 
            this.hSNCodetblTableAdapter.ClearBeforeFill = true;
            // 
            // SelectCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 469);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "SelectCategory";
            this.Text = "SelectCategory";
            this.Load += new System.EventHandler(this.SelectCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSTDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSTDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSTDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hSNCodetblBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource gSTDataSetBindingSource1;
        private GSTDataSet gSTDataSet;
        private System.Windows.Forms.BindingSource gSTDataSetBindingSource;
        private GSTDataSet gSTDataSet1;
        private System.Windows.Forms.BindingSource hSNCodetblBindingSource;
        private GSTDataSetTableAdapters.HSNCodetblTableAdapter hSNCodetblTableAdapter;
    }
}