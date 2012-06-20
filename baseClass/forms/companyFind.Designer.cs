namespace baseClass.forms
{
    partial class companyFind
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(companyFind));
            this.dataSource = new System.Windows.Forms.BindingSource(this.components);
            this.myTmpDS = new databases.tmpDS();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGrid = new common.controls.baseDataGridView();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.findCriteria = new baseClass.controls.companyCriteria();
            this.closeBtn = new baseClass.controls.baseButton();
            this.selectBtn = new baseClass.controls.baseButton();
            this.findBtn = new baseClass.controls.baseButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(823, 9);
            this.TitleLbl.Size = new System.Drawing.Size(483, 24);
            this.TitleLbl.Text = "TÌM KIẾM";
            this.TitleLbl.Visible = false;
            // 
            // dataSource
            // 
            this.dataSource.DataMember = "stockCode";
            this.dataSource.DataSource = this.myTmpDS;
            // 
            // myTmpDS
            // 
            this.myTmpDS.DataSetName = "tmpDS";
            this.myTmpDS.EnforceConstraints = false;
            this.myTmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "code";
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // dataGrid
            // 
            this.dataGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeColumn,
            this.nameColumn});
            this.dataGrid.DataSource = this.dataSource;
            this.dataGrid.Location = new System.Drawing.Point(0, 97);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(440, 390);
            this.dataGrid.TabIndex = 2;
            this.dataGrid.DoubleClick += new System.EventHandler(this.selectBtn_Click);
            this.dataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "code";
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            this.codeColumn.Width = 80;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "name";
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 300;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "code";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã số";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "fullName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Họ và tên";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "address1";
            this.dataGridViewTextBoxColumn3.HeaderText = "Địa chỉ";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 350;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "mobile";
            this.dataGridViewTextBoxColumn4.HeaderText = "Di.động";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 220;
            // 
            // findCriteria
            // 
            this.findCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findCriteria.Location = new System.Drawing.Point(40, 2);
            this.findCriteria.Margin = new System.Windows.Forms.Padding(4);
            this.findCriteria.Name = "findCriteria";
            this.findCriteria.Size = new System.Drawing.Size(357, 52);
            this.findCriteria.TabIndex = 1;
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeBtn.Location = new System.Drawing.Point(276, 56);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(117, 38);
            this.closeBtn.TabIndex = 13;
            this.closeBtn.Text = "Close";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // selectBtn
            // 
            this.selectBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectBtn.Image = global::baseClass.Properties.Resources.select;
            this.selectBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.selectBtn.Location = new System.Drawing.Point(159, 56);
            this.selectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(117, 38);
            this.selectBtn.TabIndex = 11;
            this.selectBtn.Text = "&Select";
            this.selectBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // findBtn
            // 
            this.findBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findBtn.Image = global::baseClass.Properties.Resources.find;
            this.findBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.findBtn.Location = new System.Drawing.Point(42, 56);
            this.findBtn.Margin = new System.Windows.Forms.Padding(0);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(117, 38);
            this.findBtn.TabIndex = 10;
            this.findBtn.Text = "&Find";
            this.findBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // companyFind
            // 
            this.ClientSize = new System.Drawing.Size(439, 514);
            this.Controls.Add(this.findCriteria);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.findBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "companyFind";
            this.Text = "Company Find";
            this.Load += new System.EventHandler(this.form_Load);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.findBtn, 0);
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.selectBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.findCriteria, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dataSource;
        protected baseClass.controls.baseButton findBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private common.controls.baseDataGridView dataGrid;
        protected baseClass.controls.baseButton selectBtn;
        protected baseClass.controls.baseButton closeBtn;
        protected controls.companyCriteria findCriteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        protected databases.tmpDS myTmpDS;
    }
}
