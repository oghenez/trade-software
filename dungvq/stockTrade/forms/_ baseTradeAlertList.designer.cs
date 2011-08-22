namespace stockTrade.forms
{
    partial class _baseTradeAlertList
    {

        //common.libs.appAvailable myAvail = new common.libs.appAvailable();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_basePortfolioView));
            this.myDataSet = new data.baseDS();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolBarPnl = new common.control.basePanel();
            this.orderBtn = new common.control.baseButton();
            this.viewBtn = new common.control.baseButton();
            this.recoverBtn = new common.control.baseButton();
            this.collapseAllBtn = new common.control.baseButton();
            this.expandAllBtn = new common.control.baseButton();
            this.refreshBtn = new common.control.baseButton();
            this.ignoreBtn = new common.control.baseButton();
            this.deleteBtn = new common.control.baseButton();
            this.showFilterBtn = new common.control.baseButton();
            this.viewModeCb = new common.control.baseComboBox();
            this.imageStrip = new System.Windows.Forms.ImageList(this.components);
            this.tradeAlertList = new AdvancedDataGridView.TreeGridView();
            this.subjectColumn = new AdvancedDataGridView.TreeGridColumn();
            this.actionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeColunm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tradeAlertSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBarPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1018, 76);
            this.TitleLbl.Size = new System.Drawing.Size(62, 46);
            this.TitleLbl.Visible = false;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "tickerCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "stockExchange";
            this.dataGridViewTextBoxColumn2.HeaderText = "Sàn ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "noOpenShares";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "SL niêm yết";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // toolBarPnl
            // 
            this.toolBarPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolBarPnl.Controls.Add(this.orderBtn);
            this.toolBarPnl.Controls.Add(this.viewBtn);
            this.toolBarPnl.Controls.Add(this.recoverBtn);
            this.toolBarPnl.Controls.Add(this.collapseAllBtn);
            this.toolBarPnl.Controls.Add(this.expandAllBtn);
            this.toolBarPnl.Controls.Add(this.refreshBtn);
            this.toolBarPnl.Controls.Add(this.ignoreBtn);
            this.toolBarPnl.Controls.Add(this.deleteBtn);
            this.toolBarPnl.Controls.Add(this.showFilterBtn);
            this.toolBarPnl.Controls.Add(this.viewModeCb);
            this.toolBarPnl.haveCloseButton = false;
            this.toolBarPnl.Location = new System.Drawing.Point(0, -2);
            this.toolBarPnl.Name = "toolBarPnl";
            this.toolBarPnl.Size = new System.Drawing.Size(854, 33);
            this.toolBarPnl.TabIndex = 146;
            // 
            // orderBtn
            // 
            this.orderBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderBtn.Image = global::stockTrade.Properties.Resources.edit;
            this.orderBtn.Location = new System.Drawing.Point(14, 4);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(27, 24);
            this.orderBtn.TabIndex = 1;
            this.myToolTip.SetToolTip(this.orderBtn, "Đặt lệnh");
            this.orderBtn.UseVisualStyleBackColor = true;
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // viewBtn
            // 
            this.viewBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBtn.Image = global::stockTrade.Properties.Resources.detail;
            this.viewBtn.Location = new System.Drawing.Point(41, 4);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(27, 24);
            this.viewBtn.TabIndex = 5;
            this.myToolTip.SetToolTip(this.viewBtn, "Chi tiết");
            this.viewBtn.UseVisualStyleBackColor = true;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // recoverBtn
            // 
            this.recoverBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoverBtn.Image = global::stockTrade.Properties.Resources.undo;
            this.recoverBtn.Location = new System.Drawing.Point(122, 4);
            this.recoverBtn.Name = "recoverBtn";
            this.recoverBtn.Size = new System.Drawing.Size(27, 24);
            this.recoverBtn.TabIndex = 20;
            this.myToolTip.SetToolTip(this.recoverBtn, "Phục hồi");
            this.recoverBtn.UseVisualStyleBackColor = true;
            this.recoverBtn.Click += new System.EventHandler(this.recoverBtn_Click);
            // 
            // collapseAllBtn
            // 
            this.collapseAllBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collapseAllBtn.Image = global::stockTrade.Properties.Resources.collapseAll;
            this.collapseAllBtn.Location = new System.Drawing.Point(176, 4);
            this.collapseAllBtn.Name = "collapseAllBtn";
            this.collapseAllBtn.Size = new System.Drawing.Size(27, 24);
            this.collapseAllBtn.TabIndex = 30;
            this.myToolTip.SetToolTip(this.collapseAllBtn, "Thu gọn tất cả");
            this.collapseAllBtn.UseVisualStyleBackColor = true;
            this.collapseAllBtn.Click += new System.EventHandler(this.collapseAllBtn_Click);
            // 
            // expandAllBtn
            // 
            this.expandAllBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expandAllBtn.Image = global::stockTrade.Properties.Resources.expandAll;
            this.expandAllBtn.Location = new System.Drawing.Point(149, 4);
            this.expandAllBtn.Name = "expandAllBtn";
            this.expandAllBtn.Size = new System.Drawing.Size(27, 24);
            this.expandAllBtn.TabIndex = 25;
            this.myToolTip.SetToolTip(this.expandAllBtn, "Mở rộng tất cả");
            this.expandAllBtn.UseVisualStyleBackColor = true;
            this.expandAllBtn.Click += new System.EventHandler(this.expandAllBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Image = global::stockTrade.Properties.Resources.refresh;
            this.refreshBtn.Location = new System.Drawing.Point(203, 4);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(27, 24);
            this.refreshBtn.TabIndex = 35;
            this.myToolTip.SetToolTip(this.refreshBtn, "Tải lại dữ liệu");
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // ignoreBtn
            // 
            this.ignoreBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ignoreBtn.Image = global::stockTrade.Properties.Resources.pause;
            this.ignoreBtn.Location = new System.Drawing.Point(95, 4);
            this.ignoreBtn.Name = "ignoreBtn";
            this.ignoreBtn.Size = new System.Drawing.Size(27, 24);
            this.ignoreBtn.TabIndex = 15;
            this.myToolTip.SetToolTip(this.ignoreBtn, "Bỏ qua");
            this.ignoreBtn.UseVisualStyleBackColor = true;
            this.ignoreBtn.Click += new System.EventHandler(this.ignoreBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Image = global::stockTrade.Properties.Resources.cancel;
            this.deleteBtn.Location = new System.Drawing.Point(68, 4);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(27, 24);
            this.deleteBtn.TabIndex = 10;
            this.myToolTip.SetToolTip(this.deleteBtn, "Hủy bỏ");
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // showFilterBtn
            // 
            this.showFilterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFilterBtn.Image = global::stockTrade.Properties.Resources.filter;
            this.showFilterBtn.Location = new System.Drawing.Point(230, 4);
            this.showFilterBtn.Name = "showFilterBtn";
            this.showFilterBtn.Size = new System.Drawing.Size(27, 24);
            this.showFilterBtn.TabIndex = 40;
            this.myToolTip.SetToolTip(this.showFilterBtn, "Lọc dữ liệu");
            this.showFilterBtn.UseVisualStyleBackColor = true;
            this.showFilterBtn.Click += new System.EventHandler(this.showFilterBtn_Click);
            // 
            // viewModeCb
            // 
            this.viewModeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.viewModeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewModeCb.FormattingEnabled = true;
            this.viewModeCb.Items.AddRange(new object[] {
            "Portfolio-Stock-Strategy",
            "Portfolio-Strategy-Stock",
            "Stock-Strategy",
            "Strategy-Stock",
            "StockOnly"});
            this.viewModeCb.Location = new System.Drawing.Point(258, 3);
            this.viewModeCb.myValue = "";
            this.viewModeCb.Name = "viewModeCb";
            this.viewModeCb.Size = new System.Drawing.Size(233, 24);
            this.viewModeCb.TabIndex = 45;
            this.viewModeCb.SelectedIndexChanged += new System.EventHandler(this.viewModeCb_SelectedIndexChanged);
            // 
            // imageStrip
            // 
            this.imageStrip.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageStrip.ImageSize = new System.Drawing.Size(16, 16);
            this.imageStrip.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tradeAlertList
            // 
            this.tradeAlertList.AllowUserToAddRows = false;
            this.tradeAlertList.AllowUserToDeleteRows = false;
            this.tradeAlertList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tradeAlertList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tradeAlertList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tradeAlertList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.tradeAlertList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subjectColumn,
            this.actionColumn,
            this.timeColunm,
            this.idColumn});
            this.tradeAlertList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tradeAlertList.ImageList = this.imageStrip;
            this.tradeAlertList.Location = new System.Drawing.Point(0, 34);
            this.tradeAlertList.Name = "tradeAlertList";
            this.tradeAlertList.RowHeadersVisible = false;
            this.tradeAlertList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tradeAlertList.ShowLines = false;
            this.tradeAlertList.Size = new System.Drawing.Size(849, 296);
            this.tradeAlertList.TabIndex = 10;
            this.tradeAlertList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tradeAlertList_CellDoubleClick);
            this.tradeAlertList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tradeAlertList_DataError);
            // 
            // subjectColumn
            // 
            this.subjectColumn.DefaultNodeImage = null;
            this.subjectColumn.FillWeight = 8F;
            this.subjectColumn.HeaderText = "Diễn giải";
            this.subjectColumn.Name = "subjectColumn";
            this.subjectColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.subjectColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // actionColumn
            // 
            this.actionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.actionColumn.FillWeight = 1F;
            this.actionColumn.HeaderText = "";
            this.actionColumn.Name = "actionColumn";
            this.actionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.actionColumn.Width = 50;
            // 
            // timeColunm
            // 
            this.timeColunm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.timeColunm.FillWeight = 1F;
            this.timeColunm.HeaderText = "Thời gian";
            this.timeColunm.Name = "timeColunm";
            this.timeColunm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.timeColunm.Width = 170;
            // 
            // idColumn
            // 
            this.idColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idColumn.FillWeight = 1F;
            this.idColumn.HeaderText = "id";
            this.idColumn.Name = "idColumn";
            this.idColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idColumn.Width = 50;
            // 
            // tradeAlertSource
            // 
            this.tradeAlertSource.DataMember = "tradeAlert";
            this.tradeAlertSource.DataSource = this.myDataSet;
            // 
            // baseTradeAlertList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 353);
            this.Controls.Add(this.toolBarPnl);
            this.Controls.Add(this.tradeAlertList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.Name = "baseTradeAlertList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trade alerts";
            this.Shown += new System.EventHandler(this.baseTradeAlertList_Shown);
            this.Resize += new System.EventHandler(this.baseTradeAlert_Resize);
            this.Controls.SetChildIndex(this.tradeAlertList, 0);
            this.Controls.SetChildIndex(this.toolBarPnl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBarPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected data.baseDS myDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        protected common.control.basePanel toolBarPnl;
        protected common.control.baseComboBox viewModeCb;
        private System.Windows.Forms.ImageList imageStrip;
        private AdvancedDataGridView.TreeGridView tradeAlertList;
        protected common.control.baseButton deleteBtn;
        protected common.control.baseButton ignoreBtn;
        protected System.Windows.Forms.BindingSource tradeAlertSource;
        protected common.control.baseButton recoverBtn;
        protected common.control.baseButton collapseAllBtn;
        protected common.control.baseButton expandAllBtn;
        protected common.control.baseButton refreshBtn;
        protected common.control.baseButton showFilterBtn;
        private AdvancedDataGridView.TreeGridColumn subjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeColunm;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        protected common.control.baseButton viewBtn;
        protected common.control.baseButton orderBtn;

    }
}