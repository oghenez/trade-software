namespace admin.forms
{
    partial class editTools
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.priceDiagnoseSource = new System.Windows.Forms.BindingSource(this.components);
            this.tmpDS = new databases.tmpDS();
            this.priceDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.baseDS = new databases.baseDS();
            this.editFrDateLbl = new common.controls.baseLabel();
            this.editFrDateEd = new common.controls.baseDate();
            this.editToDateLbl = new common.controls.baseLabel();
            this.editToDateEd = new common.controls.baseDate();
            this.dataCodeLbl = new common.controls.baseLabel();
            this.dataCodeEd = new baseClass.controls.txtStockCode();
            this.dataEditPnl = new common.controls.basePanel();
            this.dataGrid = new common.controls.baseDataGridView();
            this.dataOnDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataHighPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataLowPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataOpenPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataClosePriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataVolumeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importBtn = new baseClass.controls.baseButton();
            this.reAggregateBtn = new baseClass.controls.baseButton();
            this.loadPriceBtn = new baseClass.controls.baseButton();
            this.saveDataBtn = new baseClass.controls.baseButton();
            ((System.ComponentModel.ISupportInitialize)(this.priceDiagnoseSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.dataEditPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(916, 340);
            this.TitleLbl.Size = new System.Drawing.Size(10, 46);
            this.TitleLbl.Visible = false;
            // 
            // priceDiagnoseSource
            // 
            this.priceDiagnoseSource.DataMember = "priceDiagnose";
            this.priceDiagnoseSource.DataSource = this.tmpDS;
            // 
            // tmpDS
            // 
            this.tmpDS.DataSetName = "tmpDS";
            this.tmpDS.EnforceConstraints = false;
            this.tmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // priceDataSource
            // 
            this.priceDataSource.DataMember = "priceData";
            this.priceDataSource.DataSource = this.baseDS;
            // 
            // baseDS
            // 
            this.baseDS.DataSetName = "baseDS";
            this.baseDS.EnforceConstraints = false;
            this.baseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // editFrDateLbl
            // 
            this.editFrDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editFrDateLbl.Location = new System.Drawing.Point(174, 2);
            this.editFrDateLbl.Name = "editFrDateLbl";
            this.editFrDateLbl.Size = new System.Drawing.Size(88, 18);
            this.editFrDateLbl.TabIndex = 185;
            this.editFrDateLbl.Text = "Từ ngày";
            // 
            // editFrDateEd
            // 
            this.editFrDateEd.BeepOnError = true;
            this.editFrDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editFrDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.editFrDateEd.Location = new System.Drawing.Point(175, 21);
            this.editFrDateEd.Mask = "00/00/0000";
            this.editFrDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.editFrDateEd.Name = "editFrDateEd";
            this.editFrDateEd.Size = new System.Drawing.Size(93, 24);
            this.editFrDateEd.TabIndex = 1;
            // 
            // editToDateLbl
            // 
            this.editToDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editToDateLbl.Location = new System.Drawing.Point(267, 2);
            this.editToDateLbl.Name = "editToDateLbl";
            this.editToDateLbl.Size = new System.Drawing.Size(88, 18);
            this.editToDateLbl.TabIndex = 184;
            this.editToDateLbl.Text = "Đến ngày";
            // 
            // editToDateEd
            // 
            this.editToDateEd.BeepOnError = true;
            this.editToDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editToDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.editToDateEd.Location = new System.Drawing.Point(268, 21);
            this.editToDateEd.Mask = "00/00/0000";
            this.editToDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.editToDateEd.Name = "editToDateEd";
            this.editToDateEd.Size = new System.Drawing.Size(93, 24);
            this.editToDateEd.TabIndex = 2;
            // 
            // dataCodeLbl
            // 
            this.dataCodeLbl.AutoSize = true;
            this.dataCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataCodeLbl.Location = new System.Drawing.Point(362, 2);
            this.dataCodeLbl.Name = "dataCodeLbl";
            this.dataCodeLbl.Size = new System.Drawing.Size(46, 16);
            this.dataCodeLbl.TabIndex = 183;
            this.dataCodeLbl.Text = "Mã số";
            // 
            // dataCodeEd
            // 
            this.dataCodeEd.BackColor = System.Drawing.Color.White;
            this.dataCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataCodeEd.ForeColor = System.Drawing.Color.Black;
            this.dataCodeEd.isRequired = true;
            this.dataCodeEd.isToUpperCase = true;
            this.dataCodeEd.Location = new System.Drawing.Point(361, 21);
            this.dataCodeEd.Name = "dataCodeEd";
            this.dataCodeEd.Size = new System.Drawing.Size(80, 24);
            this.dataCodeEd.TabIndex = 3;
            // 
            // dataEditPnl
            // 
            this.dataEditPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataEditPnl.Controls.Add(this.dataGrid);
            this.dataEditPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataEditPnl.haveCloseButton = false;
            this.dataEditPnl.isExpanded = true;
            this.dataEditPnl.Location = new System.Drawing.Point(-1, 91);
            this.dataEditPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.dataEditPnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.dataEditPnl.myWeight = 0;
            this.dataEditPnl.Name = "dataEditPnl";
            this.dataEditPnl.Size = new System.Drawing.Size(725, 394);
            this.dataEditPnl.TabIndex = 186;
            // 
            // dataGrid
            // 
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataOnDateColumn,
            this.dataHighPriceColumn,
            this.dataLowPriceColumn,
            this.dataOpenPriceColumn,
            this.dataClosePriceColumn,
            this.dataVolumeColumn});
            this.dataGrid.DataSource = this.priceDataSource;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.Height = 24;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(721, 390);
            this.dataGrid.TabIndex = 10;
            this.dataGrid.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGrid_DefaultValuesNeeded);
            // 
            // dataOnDateColumn
            // 
            this.dataOnDateColumn.DataPropertyName = "onDate";
            this.dataOnDateColumn.HeaderText = "Date/Time";
            this.dataOnDateColumn.Name = "dataOnDateColumn";
            this.dataOnDateColumn.Width = 140;
            // 
            // dataHighPriceColumn
            // 
            this.dataHighPriceColumn.DataPropertyName = "highPrice";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.dataHighPriceColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataHighPriceColumn.HeaderText = "High";
            this.dataHighPriceColumn.Name = "dataHighPriceColumn";
            // 
            // dataLowPriceColumn
            // 
            this.dataLowPriceColumn.DataPropertyName = "lowPrice";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.dataLowPriceColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataLowPriceColumn.HeaderText = "Low";
            this.dataLowPriceColumn.Name = "dataLowPriceColumn";
            // 
            // dataOpenPriceColumn
            // 
            this.dataOpenPriceColumn.DataPropertyName = "openPrice";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.dataOpenPriceColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataOpenPriceColumn.HeaderText = "Open";
            this.dataOpenPriceColumn.Name = "dataOpenPriceColumn";
            // 
            // dataClosePriceColumn
            // 
            this.dataClosePriceColumn.DataPropertyName = "closePrice";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.dataClosePriceColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataClosePriceColumn.HeaderText = "Close";
            this.dataClosePriceColumn.Name = "dataClosePriceColumn";
            // 
            // dataVolumeColumn
            // 
            this.dataVolumeColumn.DataPropertyName = "volume";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Format = "N0";
            dataGridViewCellStyle15.NullValue = null;
            this.dataVolumeColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataVolumeColumn.HeaderText = "Volume";
            this.dataVolumeColumn.Name = "dataVolumeColumn";
            this.dataVolumeColumn.Width = 120;
            // 
            // importBtn
            // 
            this.importBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.Image = global::admin.Properties.Resources.excel;
            this.importBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.importBtn.isDownState = false;
            this.importBtn.Location = new System.Drawing.Point(265, 50);
            this.importBtn.Name = "importBtn";
            this.importBtn.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.importBtn.Size = new System.Drawing.Size(89, 34);
            this.importBtn.TabIndex = 11;
            this.importBtn.Text = "Excel";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // reAggregateBtn
            // 
            this.reAggregateBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reAggregateBtn.Image = global::admin.Properties.Resources.run;
            this.reAggregateBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.reAggregateBtn.isDownState = false;
            this.reAggregateBtn.Location = new System.Drawing.Point(457, 21);
            this.reAggregateBtn.Name = "reAggregateBtn";
            this.reAggregateBtn.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.reAggregateBtn.Size = new System.Drawing.Size(113, 63);
            this.reAggregateBtn.TabIndex = 30;
            this.reAggregateBtn.Text = "Aggregate";
            this.reAggregateBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.reAggregateBtn.UseVisualStyleBackColor = true;
            this.reAggregateBtn.Click += new System.EventHandler(this.reAggregateBtn_Click);
            // 
            // loadPriceBtn
            // 
            this.loadPriceBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadPriceBtn.Image = global::admin.Properties.Resources.refresh;
            this.loadPriceBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loadPriceBtn.isDownState = false;
            this.loadPriceBtn.Location = new System.Drawing.Point(176, 50);
            this.loadPriceBtn.Name = "loadPriceBtn";
            this.loadPriceBtn.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.loadPriceBtn.Size = new System.Drawing.Size(89, 34);
            this.loadPriceBtn.TabIndex = 10;
            this.loadPriceBtn.Text = "Load";
            this.loadPriceBtn.UseVisualStyleBackColor = true;
            this.loadPriceBtn.Click += new System.EventHandler(this.loadPriceBtn_Click);
            // 
            // saveDataBtn
            // 
            this.saveDataBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveDataBtn.Image = global::admin.Properties.Resources.save;
            this.saveDataBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveDataBtn.isDownState = false;
            this.saveDataBtn.Location = new System.Drawing.Point(354, 50);
            this.saveDataBtn.Name = "saveDataBtn";
            this.saveDataBtn.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.saveDataBtn.Size = new System.Drawing.Size(89, 34);
            this.saveDataBtn.TabIndex = 12;
            this.saveDataBtn.Text = "Save";
            this.saveDataBtn.UseVisualStyleBackColor = true;
            this.saveDataBtn.Click += new System.EventHandler(this.saveDataBtn_Click);
            // 
            // editTools
            // 
            this.ClientSize = new System.Drawing.Size(721, 508);
            this.Controls.Add(this.dataEditPnl);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.editFrDateLbl);
            this.Controls.Add(this.editFrDateEd);
            this.Controls.Add(this.editToDateLbl);
            this.Controls.Add(this.editToDateEd);
            this.Controls.Add(this.reAggregateBtn);
            this.Controls.Add(this.loadPriceBtn);
            this.Controls.Add(this.saveDataBtn);
            this.Controls.Add(this.dataCodeLbl);
            this.Controls.Add(this.dataCodeEd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "editTools";
            this.Text = "Data tools";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.dataCodeEd, 0);
            this.Controls.SetChildIndex(this.dataCodeLbl, 0);
            this.Controls.SetChildIndex(this.saveDataBtn, 0);
            this.Controls.SetChildIndex(this.loadPriceBtn, 0);
            this.Controls.SetChildIndex(this.reAggregateBtn, 0);
            this.Controls.SetChildIndex(this.editToDateEd, 0);
            this.Controls.SetChildIndex(this.editToDateLbl, 0);
            this.Controls.SetChildIndex(this.editFrDateEd, 0);
            this.Controls.SetChildIndex(this.editFrDateLbl, 0);
            this.Controls.SetChildIndex(this.importBtn, 0);
            this.Controls.SetChildIndex(this.dataEditPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.priceDiagnoseSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.dataEditPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected databases.baseDS baseDS;
        protected System.Windows.Forms.BindingSource priceDataSource;
        protected databases.tmpDS tmpDS;
        protected System.Windows.Forms.BindingSource priceDiagnoseSource;
        protected common.controls.baseLabel editFrDateLbl;
        protected common.controls.baseDate editFrDateEd;
        protected common.controls.baseLabel editToDateLbl;
        protected common.controls.baseDate editToDateEd;
        protected baseClass.controls.baseButton reAggregateBtn;
        protected baseClass.controls.baseButton loadPriceBtn;
        protected baseClass.controls.baseButton saveDataBtn;
        protected common.controls.baseLabel dataCodeLbl;
        protected baseClass.controls.txtStockCode dataCodeEd;
        protected common.controls.basePanel dataEditPnl;
        protected common.controls.baseDataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataOnDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataHighPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataLowPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataOpenPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataClosePriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataVolumeColumn;
        protected baseClass.controls.baseButton importBtn;
    }
}
