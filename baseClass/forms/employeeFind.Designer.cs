namespace baseClass.forms
{
    partial class employeeFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(employeeFind));
            this.employeeSource = new System.Windows.Forms.BindingSource(this.components);
            this.myBaseDS = new data.baseDS();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.dataPnl = new System.Windows.Forms.Panel();
            this.optionPnl = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emCriteria = new application.control.employeeCriteria();
            this.closeBtn = new baseClass.controls.baseButton();
            this.selectBtn = new baseClass.controls.baseButton();
            this.findBtn = new baseClass.controls.baseButton();
            this.newBtn = new baseClass.controls.baseButton();
            this.closeListBtn = new baseClass.controls.baseButton();
            this.emCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dobDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.employeeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.dataPnl.SuspendLayout();
            this.optionPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(823, 9);
            this.TitleLbl.Size = new System.Drawing.Size(483, 24);
            this.TitleLbl.Text = "TÌM KIẾM";
            this.TitleLbl.Visible = false;
            // 
            // employeeSource
            // 
            this.employeeSource.DataMember = "employee";
            this.employeeSource.DataSource = this.myBaseDS;
            // 
            // myBaseDS
            // 
            this.myBaseDS.DataSetName = "baseDS";
            this.myBaseDS.EnforceConstraints = false;
            this.myBaseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.emCodeDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.dobDataGridViewTextBoxColumn});
            this.dataGrid.DataSource = this.employeeSource;
            this.dataGrid.Location = new System.Drawing.Point(-1, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(469, 405);
            this.dataGrid.TabIndex = 232;
            this.dataGrid.DoubleClick += new System.EventHandler(this.selectBtn_Click);
            // 
            // dataPnl
            // 
            this.dataPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataPnl.Controls.Add(this.closeListBtn);
            this.dataPnl.Controls.Add(this.dataGrid);
            this.dataPnl.Location = new System.Drawing.Point(-2, -1);
            this.dataPnl.Name = "dataPnl";
            this.dataPnl.Size = new System.Drawing.Size(472, 512);
            this.dataPnl.TabIndex = 233;
            // 
            // optionPnl
            // 
            this.optionPnl.Controls.Add(this.emCriteria);
            this.optionPnl.Controls.Add(this.closeBtn);
            this.optionPnl.Controls.Add(this.selectBtn);
            this.optionPnl.Controls.Add(this.findBtn);
            this.optionPnl.Controls.Add(this.newBtn);
            this.optionPnl.Location = new System.Drawing.Point(-2, 1);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(471, 279);
            this.optionPnl.TabIndex = 1;
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
            // emCriteria
            // 
            this.emCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emCriteria.Location = new System.Drawing.Point(1, 3);
            this.emCriteria.Margin = new System.Windows.Forms.Padding(4);
            this.emCriteria.Name = "emCriteria";
            this.emCriteria.Size = new System.Drawing.Size(472, 233);
            this.emCriteria.TabIndex = 1;
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeBtn.Location = new System.Drawing.Point(370, 239);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(80, 38);
            this.closeBtn.TabIndex = 13;
            this.closeBtn.Text = "Đóng";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // selectBtn
            // 
            this.selectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectBtn.Image = global::baseClass.Properties.Resources.select;
            this.selectBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.selectBtn.Location = new System.Drawing.Point(210, 239);
            this.selectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(80, 38);
            this.selectBtn.TabIndex = 11;
            this.selectBtn.Text = "&Chọn";
            this.selectBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // findBtn
            // 
            this.findBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findBtn.Image = global::baseClass.Properties.Resources.find;
            this.findBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.findBtn.Location = new System.Drawing.Point(130, 239);
            this.findBtn.Margin = new System.Windows.Forms.Padding(0);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(80, 38);
            this.findBtn.TabIndex = 10;
            this.findBtn.Text = "&Tìm";
            this.findBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // newBtn
            // 
            this.newBtn.Enabled = false;
            this.newBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBtn.Image = ((System.Drawing.Image)(resources.GetObject("newBtn.Image")));
            this.newBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newBtn.Location = new System.Drawing.Point(290, 239);
            this.newBtn.Margin = new System.Windows.Forms.Padding(0);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(80, 38);
            this.newBtn.TabIndex = 12;
            this.newBtn.Text = "&Mới";
            this.newBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // closeListBtn
            // 
            this.closeListBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeListBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeListBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeListBtn.Location = new System.Drawing.Point(451, 2);
            this.closeListBtn.Margin = new System.Windows.Forms.Padding(0);
            this.closeListBtn.Name = "closeListBtn";
            this.closeListBtn.Size = new System.Drawing.Size(18, 23);
            this.closeListBtn.TabIndex = 234;
            this.closeListBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeListBtn.UseVisualStyleBackColor = true;
            this.closeListBtn.Click += new System.EventHandler(this.closeListBtn_Click);
            // 
            // emCodeDataGridViewTextBoxColumn
            // 
            this.emCodeDataGridViewTextBoxColumn.DataPropertyName = "emCode";
            this.emCodeDataGridViewTextBoxColumn.HeaderText = "Mã số";
            this.emCodeDataGridViewTextBoxColumn.Name = "emCodeDataGridViewTextBoxColumn";
            this.emCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "fullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "Họ và tên";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fullNameDataGridViewTextBoxColumn.Width = 220;
            // 
            // dobDataGridViewTextBoxColumn
            // 
            this.dobDataGridViewTextBoxColumn.DataPropertyName = "dob";
            this.dobDataGridViewTextBoxColumn.HeaderText = "Ngày.sinh";
            this.dobDataGridViewTextBoxColumn.Name = "dobDataGridViewTextBoxColumn";
            this.dobDataGridViewTextBoxColumn.ReadOnly = true;
            this.dobDataGridViewTextBoxColumn.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "mobile";
            this.dataGridViewTextBoxColumn4.HeaderText = "Di.động";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 220;
            // 
            // employeeFind
            // 
            this.ClientSize = new System.Drawing.Size(468, 538);
            this.Controls.Add(this.optionPnl);
            this.Controls.Add(this.dataPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "employeeFind";
            this.Text = "Tim kiem";
            this.Load += new System.EventHandler(this.employeeFind_Load);
            this.Controls.SetChildIndex(this.dataPnl, 0);
            this.Controls.SetChildIndex(this.optionPnl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.employeeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.dataPnl.ResumeLayout(false);
            this.optionPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource employeeSource;
        protected baseClass.controls.baseButton findBtn;
        private data.baseDS myBaseDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        protected baseClass.controls.baseButton newBtn;
        protected baseClass.controls.baseButton selectBtn;
        protected baseClass.controls.baseButton closeBtn;
        protected application.control.employeeCriteria emCriteria;
        protected System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn emCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dobDataGridViewTextBoxColumn;
        protected System.Windows.Forms.Panel dataPnl;
        protected baseClass.controls.baseButton closeListBtn;
        protected System.Windows.Forms.Panel optionPnl;
    }
}
