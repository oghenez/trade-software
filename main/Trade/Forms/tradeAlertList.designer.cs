namespace Trade.Forms
{
    partial class tradeAlertList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tradeAlertList));
            this.viewBtn = new common.controls.baseButton();
            this.recoverBtn = new common.controls.baseButton();
            this.refreshBtn = new common.controls.baseButton();
            this.ignoreBtn = new common.controls.baseButton();
            this.deleteBtn = new common.controls.baseButton();
            this.showFilterBtn = new common.controls.baseButton();
            this.dataGrid = new common.controls.baseDataGridView();
            this.strategySource = new System.Windows.Forms.BindingSource(this.components);
            this.myTmpDS = new data.tmpDS();
            this.timeScaleSource = new System.Windows.Forms.BindingSource(this.components);
            this.tradeActionSource = new System.Windows.Forms.BindingSource(this.components);
            this.CommonStatusSource = new System.Windows.Forms.BindingSource(this.components);
            this.tradeAlertSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDataSet = new data.baseDS();
            this.toolBarPnl = new common.controls.basePanel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.onDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strategyColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.timeScaleColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.actionColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.viewColumn = new common.controls.gridViewImageColumn();
            this.cancelColumn = new common.controls.gridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strategySource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeScaleSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeActionSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommonStatusSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBarPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1527, 105);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.TitleLbl.Size = new System.Drawing.Size(93, 64);
            this.TitleLbl.Visible = false;
            // 
            // viewBtn
            // 
            this.viewBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBtn.Image = global::Trade.Properties.Resources.detail;
            this.viewBtn.isDownState = false;
            this.viewBtn.Location = new System.Drawing.Point(15, 2);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(25, 23);
            this.viewBtn.TabIndex = 5;
            this.viewBtn.UseVisualStyleBackColor = true;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // recoverBtn
            // 
            this.recoverBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoverBtn.Image = global::Trade.Properties.Resources.undo;
            this.recoverBtn.isDownState = false;
            this.recoverBtn.Location = new System.Drawing.Point(90, 2);
            this.recoverBtn.Name = "recoverBtn";
            this.recoverBtn.Size = new System.Drawing.Size(25, 23);
            this.recoverBtn.TabIndex = 20;
            this.recoverBtn.UseVisualStyleBackColor = true;
            this.recoverBtn.Click += new System.EventHandler(this.recoverBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Image = global::Trade.Properties.Resources.refresh;
            this.refreshBtn.isDownState = false;
            this.refreshBtn.Location = new System.Drawing.Point(115, 2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(25, 23);
            this.refreshBtn.TabIndex = 35;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // ignoreBtn
            // 
            this.ignoreBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ignoreBtn.Image = global::Trade.Properties.Resources.pause;
            this.ignoreBtn.isDownState = false;
            this.ignoreBtn.Location = new System.Drawing.Point(65, 2);
            this.ignoreBtn.Name = "ignoreBtn";
            this.ignoreBtn.Size = new System.Drawing.Size(25, 23);
            this.ignoreBtn.TabIndex = 15;
            this.ignoreBtn.UseVisualStyleBackColor = true;
            this.ignoreBtn.Click += new System.EventHandler(this.ignoreBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Image = global::Trade.Properties.Resources.cancel;
            this.deleteBtn.isDownState = false;
            this.deleteBtn.Location = new System.Drawing.Point(40, 2);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(25, 23);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // showFilterBtn
            // 
            this.showFilterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFilterBtn.Image = global::Trade.Properties.Resources.filter;
            this.showFilterBtn.isDownState = false;
            this.showFilterBtn.Location = new System.Drawing.Point(140, 2);
            this.showFilterBtn.Name = "showFilterBtn";
            this.showFilterBtn.Size = new System.Drawing.Size(25, 23);
            this.showFilterBtn.TabIndex = 40;
            this.showFilterBtn.UseVisualStyleBackColor = true;
            this.showFilterBtn.Click += new System.EventHandler(this.showFilterBtn_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.onDateColumn,
            this.codeColumn,
            this.strategyColumn,
            this.timeScaleColumn,
            this.actionColumn,
            this.statusColumn,
            this.viewColumn,
            this.cancelColumn});
            this.dataGrid.DataSource = this.tradeAlertSource;
            this.dataGrid.DisableReadOnlyColumn = true;
            this.dataGrid.Location = new System.Drawing.Point(0, 33);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(649, 202);
            this.dataGrid.TabIndex = 153;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            this.dataGrid.Resize += new System.EventHandler(this.tradeAlertList_Resize);
            // 
            // strategySource
            // 
            this.strategySource.DataMember = "codeList";
            this.strategySource.DataSource = this.myTmpDS;
            this.strategySource.CurrentChanged += new System.EventHandler(this.strategySource_CurrentChanged);
            // 
            // myTmpDS
            // 
            this.myTmpDS.DataSetName = "tmpDS";
            this.myTmpDS.EnforceConstraints = false;
            this.myTmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timeScaleSource
            // 
            this.timeScaleSource.DataMember = "codeList";
            this.timeScaleSource.DataSource = this.myTmpDS;
            // 
            // tradeActionSource
            // 
            this.tradeActionSource.DataMember = "codeList";
            this.tradeActionSource.DataSource = this.myTmpDS;
            // 
            // CommonStatusSource
            // 
            this.CommonStatusSource.DataMember = "codeList";
            this.CommonStatusSource.DataSource = this.myTmpDS;
            // 
            // tradeAlertSource
            // 
            this.tradeAlertSource.DataMember = "tradeAlert";
            this.tradeAlertSource.DataSource = this.myDataSet;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolBarPnl
            // 
            this.toolBarPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolBarPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolBarPnl.Controls.Add(this.viewBtn);
            this.toolBarPnl.Controls.Add(this.recoverBtn);
            this.toolBarPnl.Controls.Add(this.refreshBtn);
            this.toolBarPnl.Controls.Add(this.ignoreBtn);
            this.toolBarPnl.Controls.Add(this.deleteBtn);
            this.toolBarPnl.Controls.Add(this.showFilterBtn);
            this.toolBarPnl.haveCloseButton = false;
            this.toolBarPnl.isExpanded = true;
            this.toolBarPnl.Location = new System.Drawing.Point(0, 0);
            this.toolBarPnl.Margin = new System.Windows.Forms.Padding(4);
            this.toolBarPnl.myIconLocations = common.controls.basePanel.IconLocations.TopRight;
            this.toolBarPnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.toolBarPnl.myWeight = 0;
            this.toolBarPnl.Name = "toolBarPnl";
            this.toolBarPnl.Size = new System.Drawing.Size(646, 29);
            this.toolBarPnl.TabIndex = 1;
            this.toolBarPnl.myOnShowStateChanged += new common.controls.basePanel.OnShowStateChanged(this.toolBarPnl_myOnShowStateChanged);
            // 
            // onDateColumn
            // 
            this.onDateColumn.DataPropertyName = "onTime";
            this.onDateColumn.HeaderText = "Date/Time";
            this.onDateColumn.Name = "onDateColumn";
            this.onDateColumn.ReadOnly = true;
            this.onDateColumn.Width = 140;
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "stockCode";
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            this.codeColumn.Width = 60;
            // 
            // strategyColumn
            // 
            this.strategyColumn.DataPropertyName = "strategy";
            this.strategyColumn.DataSource = this.strategySource;
            this.strategyColumn.DisplayMember = "description";
            this.strategyColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.strategyColumn.HeaderText = "Strategy";
            this.strategyColumn.Name = "strategyColumn";
            this.strategyColumn.ReadOnly = true;
            this.strategyColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.strategyColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.strategyColumn.ValueMember = "code";
            this.strategyColumn.Width = 160;
            // 
            // timeScaleColumn
            // 
            this.timeScaleColumn.DataPropertyName = "timeScale";
            this.timeScaleColumn.DataSource = this.timeScaleSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.timeScaleColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.timeScaleColumn.DisplayMember = "description";
            this.timeScaleColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.timeScaleColumn.HeaderText = "Time Scale";
            this.timeScaleColumn.Name = "timeScaleColumn";
            this.timeScaleColumn.ReadOnly = true;
            this.timeScaleColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.timeScaleColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.timeScaleColumn.ValueMember = "code";
            this.timeScaleColumn.Width = 70;
            // 
            // actionColumn
            // 
            this.actionColumn.DataPropertyName = "tradeAction";
            this.actionColumn.DataSource = this.tradeActionSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.actionColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.actionColumn.DisplayMember = "description";
            this.actionColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.actionColumn.HeaderText = "Action";
            this.actionColumn.Name = "actionColumn";
            this.actionColumn.ReadOnly = true;
            this.actionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.actionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.actionColumn.ValueMember = "byteValue";
            this.actionColumn.Width = 55;
            // 
            // statusColumn
            // 
            this.statusColumn.DataPropertyName = "status";
            this.statusColumn.DataSource = this.CommonStatusSource;
            this.statusColumn.DisplayMember = "description";
            this.statusColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.statusColumn.HeaderText = "";
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.ReadOnly = true;
            this.statusColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.statusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.statusColumn.ValueMember = "byteValue";
            this.statusColumn.Width = 50;
            // 
            // viewColumn
            // 
            this.viewColumn.HeaderText = "";
            this.viewColumn.myValue = "";
            this.viewColumn.Name = "viewColumn";
            this.viewColumn.ReadOnly = true;
            this.viewColumn.Width = 25;
            // 
            // cancelColumn
            // 
            this.cancelColumn.HeaderText = "";
            this.cancelColumn.myValue = "";
            this.cancelColumn.Name = "cancelColumn";
            this.cancelColumn.ReadOnly = true;
            this.cancelColumn.Width = 25;
            // 
            // tradeAlertList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(645, 258);
            this.Controls.Add(this.toolBarPnl);
            this.Controls.Add(this.dataGrid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.Name = "tradeAlertList";
            this.Text = "Trade alerts";
            this.Resize += new System.EventHandler(this.tradeAlertList_Resize);
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.toolBarPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strategySource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeScaleSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeActionSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommonStatusSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBarPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected data.baseDS myDataSet;
        protected System.Windows.Forms.BindingSource tradeAlertSource;
        protected common.controls.baseButton viewBtn;
        protected common.controls.baseButton recoverBtn;
        protected common.controls.baseButton refreshBtn;
        protected common.controls.baseButton ignoreBtn;
        protected common.controls.baseButton deleteBtn;
        protected common.controls.baseButton showFilterBtn;
        protected System.Windows.Forms.BindingSource CommonStatusSource;
        protected System.Windows.Forms.BindingSource timeScaleSource;
        protected common.controls.baseDataGridView dataGrid;
        private common.controls.basePanel toolBarPnl;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected data.tmpDS myTmpDS;
        protected System.Windows.Forms.BindingSource strategySource;
        protected System.Windows.Forms.BindingSource tradeActionSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn onDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn strategyColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn timeScaleColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn actionColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn statusColumn;
        private common.controls.gridViewImageColumn viewColumn;
        private common.controls.gridViewImageColumn cancelColumn;

    }
}