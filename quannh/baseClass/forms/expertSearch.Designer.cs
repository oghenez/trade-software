namespace baseClass.forms
{
    partial class expertSearch
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
            this.expertSource = new System.Windows.Forms.BindingSource(this.components);
            this.mybaseDS = new data.baseDS();
            this.expertGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.findBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expertCriteria1 = new application.control.expertCriteria();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridEditBtn = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.expertSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mybaseDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(0, 1);
            this.TitleLbl.Size = new System.Drawing.Size(795, 24);
            this.TitleLbl.Text = "TÌM KIẾM";
            // 
            // expertSource
            // 
            this.expertSource.DataMember = "expert";
            this.expertSource.DataSource = this.mybaseDS;
            // 
            // mybaseDS
            // 
            this.mybaseDS.DataSetName = "baseDS";
            this.mybaseDS.EnforceConstraints = false;
            this.mybaseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // expertGrid
            // 
            this.expertGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.expertGrid.AllowUserToAddRows = false;
            this.expertGrid.AutoGenerateColumns = false;
            this.expertGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expertGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.Column1,
            this.mobile,
            this.gridEditBtn});
            this.expertGrid.DataSource = this.expertSource;
            this.expertGrid.Location = new System.Drawing.Point(-1, 156);
            this.expertGrid.Name = "expertGrid";
            this.expertGrid.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expertGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.expertGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.expertGrid.Size = new System.Drawing.Size(792, 383);
            this.expertGrid.TabIndex = 232;
            this.expertGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.expertGrid_CellClick);
            this.expertGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.expertGrid_DataError);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "code";
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::baseClass.Properties.Resources.EDIT;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // findBtn
            // 
            this.findBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findBtn.Image = global::baseClass.Properties.Resources.find;
            this.findBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.findBtn.Location = new System.Drawing.Point(717, 49);
            this.findBtn.Margin = new System.Windows.Forms.Padding(4);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(52, 48);
            this.findBtn.TabIndex = 147;
            this.findBtn.Text = "&Tìm";
            this.findBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Image = global::baseClass.Properties.Resources.CLOSE;
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.exitBtn.Location = new System.Drawing.Point(717, 99);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(52, 48);
            this.exitBtn.TabIndex = 148;
            this.exitBtn.Text = "Đóng";
            this.exitBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
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
            // 
            // expertCriteria1
            // 
            this.expertCriteria1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expertCriteria1.Location = new System.Drawing.Point(25, 27);
            this.expertCriteria1.Margin = new System.Windows.Forms.Padding(4);
            this.expertCriteria1.Name = "expertCriteria1";
            this.expertCriteria1.Size = new System.Drawing.Size(673, 129);
            this.expertCriteria1.TabIndex = 145;
            this.expertCriteria1.withAdvancedOption = false;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Mã số";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 80;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "fullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "Họ và tên";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fullNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "address1";
            this.Column1.HeaderText = "Địa chỉ";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 325;
            // 
            // mobile
            // 
            this.mobile.DataPropertyName = "mobile";
            this.mobile.HeaderText = "Di.động";
            this.mobile.Name = "mobile";
            this.mobile.ReadOnly = true;
            // 
            // gridEditBtn
            // 
            this.gridEditBtn.HeaderText = "";
            this.gridEditBtn.Image = global::baseClass.Properties.Resources.EDIT;
            this.gridEditBtn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.gridEditBtn.Name = "gridEditBtn";
            this.gridEditBtn.ReadOnly = true;
            this.gridEditBtn.Width = 25;
            // 
            // expertSearch
            // 
            this.ClientSize = new System.Drawing.Size(791, 566);
            this.Controls.Add(this.expertGrid);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.expertCriteria1);
            this.Name = "expertSearch";
            this.Load += new System.EventHandler(this.expertSearch_Load);
            this.Controls.SetChildIndex(this.expertCriteria1, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.exitBtn, 0);
            this.Controls.SetChildIndex(this.findBtn, 0);
            this.Controls.SetChildIndex(this.expertGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.expertSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mybaseDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expertGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private application.control.expertCriteria expertCriteria1;
        private System.Windows.Forms.BindingSource expertSource;
        protected System.Windows.Forms.Button findBtn;
        protected System.Windows.Forms.Button exitBtn;
        private data.baseDS mybaseDS;
        private System.Windows.Forms.DataGridView expertGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile;
        private System.Windows.Forms.DataGridViewImageColumn gridEditBtn;
    }
}
