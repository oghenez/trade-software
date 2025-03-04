namespace baseClass.forms
{
    partial class baseTradeAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseTradeAlert));
            this.alertGrid = new common.control.baseDataGridView();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.onTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelColumn = new common.control.gridViewImageColumn();
            this.viewColumn = new common.control.gridViewImageColumn();
            this.tradeAlertSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDataSet = new data.baseDS();
            this.filterPnl = new common.control.basePanel();
            this.portpolioChk = new common.control.baseCheckBox();
            this.tradeAlertStatusChk = new common.control.baseCheckBox();
            this.frDateChk = new common.control.baseCheckBox();
            this.frDateEd = new common.control.baseDate();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolbarPnl = new common.control.basePanel();
            this.countLbl = new common.control.baseLabel();
            this.refreshBtn = new common.control.baseButton();
            this.makeOrderBtn = new common.control.baseButton();
            this.showFilterBtn = new common.control.baseButton();
            this.filterBtn = new common.control.baseButton();
            this.portpolioCb = new baseClass.controls.cbPorpolio();
            this.tradeAlertStatusCb = new baseClass.controls.cbTradeAlertStatus();
            ((System.ComponentModel.ISupportInitialize)(this.alertGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.filterPnl.SuspendLayout();
            this.toolbarPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1018, 76);
            this.TitleLbl.Size = new System.Drawing.Size(62, 46);
            this.TitleLbl.Visible = false;
            // 
            // alertGrid
            // 
            this.alertGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.alertGrid.AllowUserToAddRows = false;
            this.alertGrid.AllowUserToDeleteRows = false;
            this.alertGrid.AutoGenerateColumns = false;
            this.alertGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.alertGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusDataGridViewTextBoxColumn,
            this.onTimeDataGridViewTextBoxColumn,
            this.stockCodeDataGridViewTextBoxColumn,
            this.subjectDataGridViewTextBoxColumn,
            this.cancelColumn,
            this.viewColumn});
            this.alertGrid.DataSource = this.tradeAlertSource;
            this.alertGrid.Location = new System.Drawing.Point(0, 25);
            this.alertGrid.Name = "alertGrid";
            this.alertGrid.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.alertGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.alertGrid.Size = new System.Drawing.Size(639, 277);
            this.alertGrid.TabIndex = 232;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.statusDataGridViewTextBoxColumn.HeaderText = "";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.statusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.statusDataGridViewTextBoxColumn.Width = 50;
            // 
            // onTimeDataGridViewTextBoxColumn
            // 
            this.onTimeDataGridViewTextBoxColumn.DataPropertyName = "onTime";
            this.onTimeDataGridViewTextBoxColumn.HeaderText = "Thời gian";
            this.onTimeDataGridViewTextBoxColumn.Name = "onTimeDataGridViewTextBoxColumn";
            this.onTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockCodeDataGridViewTextBoxColumn
            // 
            this.stockCodeDataGridViewTextBoxColumn.DataPropertyName = "stockCode";
            this.stockCodeDataGridViewTextBoxColumn.HeaderText = "Mã CK";
            this.stockCodeDataGridViewTextBoxColumn.Name = "stockCodeDataGridViewTextBoxColumn";
            this.stockCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockCodeDataGridViewTextBoxColumn.Width = 80;
            // 
            // subjectDataGridViewTextBoxColumn
            // 
            this.subjectDataGridViewTextBoxColumn.DataPropertyName = "subject";
            this.subjectDataGridViewTextBoxColumn.HeaderText = "Tiêu đề";
            this.subjectDataGridViewTextBoxColumn.Name = "subjectDataGridViewTextBoxColumn";
            this.subjectDataGridViewTextBoxColumn.ReadOnly = true;
            this.subjectDataGridViewTextBoxColumn.Width = 300;
            // 
            // cancelColumn
            // 
            this.cancelColumn.HeaderText = "";
            this.cancelColumn.myValue = "";
            this.cancelColumn.Name = "cancelColumn";
            this.cancelColumn.ReadOnly = true;
            this.cancelColumn.Width = 25;
            // 
            // viewColumn
            // 
            this.viewColumn.HeaderText = "";
            this.viewColumn.myValue = "";
            this.viewColumn.Name = "viewColumn";
            this.viewColumn.ReadOnly = true;
            this.viewColumn.Width = 25;
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
            // filterPnl
            // 
            this.filterPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.filterPnl.Controls.Add(this.portpolioChk);
            this.filterPnl.Controls.Add(this.portpolioCb);
            this.filterPnl.Controls.Add(this.filterBtn);
            this.filterPnl.Controls.Add(this.tradeAlertStatusChk);
            this.filterPnl.Controls.Add(this.frDateChk);
            this.filterPnl.Controls.Add(this.frDateEd);
            this.filterPnl.Controls.Add(this.tradeAlertStatusCb);
            this.filterPnl.haveCloseButton = true;
            this.filterPnl.Location = new System.Drawing.Point(201, 3);
            this.filterPnl.Name = "filterPnl";
            this.filterPnl.Size = new System.Drawing.Size(436, 67);
            this.filterPnl.TabIndex = 239;
            this.filterPnl.Visible = false;
            // 
            // portpolioChk
            // 
            this.portpolioChk.AutoSize = true;
            this.portpolioChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portpolioChk.Location = new System.Drawing.Point(157, 8);
            this.portpolioChk.Name = "portpolioChk";
            this.portpolioChk.Size = new System.Drawing.Size(85, 20);
            this.portpolioChk.TabIndex = 3;
            this.portpolioChk.Text = "Portpolio";
            this.portpolioChk.UseVisualStyleBackColor = true;
            this.portpolioChk.CheckedChanged += new System.EventHandler(this.portpolioChk_CheckedChanged);
            // 
            // tradeAlertStatusChk
            // 
            this.tradeAlertStatusChk.AutoSize = true;
            this.tradeAlertStatusChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tradeAlertStatusChk.Location = new System.Drawing.Point(35, 7);
            this.tradeAlertStatusChk.Name = "tradeAlertStatusChk";
            this.tradeAlertStatusChk.Size = new System.Drawing.Size(93, 20);
            this.tradeAlertStatusChk.TabIndex = 1;
            this.tradeAlertStatusChk.Text = "Trạng thái";
            this.tradeAlertStatusChk.UseVisualStyleBackColor = true;
            this.tradeAlertStatusChk.CheckedChanged += new System.EventHandler(this.tradeAlertStatusChk_CheckedChanged);
            // 
            // frDateChk
            // 
            this.frDateChk.AutoSize = true;
            this.frDateChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frDateChk.Location = new System.Drawing.Point(277, 6);
            this.frDateChk.Name = "frDateChk";
            this.frDateChk.Size = new System.Drawing.Size(87, 20);
            this.frDateChk.TabIndex = 5;
            this.frDateChk.Text = "Sau ngày";
            this.frDateChk.UseVisualStyleBackColor = true;
            this.frDateChk.CheckedChanged += new System.EventHandler(this.frDateChk_CheckedChanged);
            // 
            // frDateEd
            // 
            this.frDateEd.BeepOnError = true;
            this.frDateEd.Enabled = false;
            this.frDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.frDateEd.Location = new System.Drawing.Point(277, 28);
            this.frDateEd.Mask = "00/00/0000";
            this.frDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.frDateEd.Name = "frDateEd";
            this.frDateEd.Size = new System.Drawing.Size(95, 26);
            this.frDateEd.TabIndex = 6;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn3.HeaderText = "SL niêm yết";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // toolbarPnl
            // 
            this.toolbarPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolbarPnl.Controls.Add(this.countLbl);
            this.toolbarPnl.Controls.Add(this.refreshBtn);
            this.toolbarPnl.Controls.Add(this.makeOrderBtn);
            this.toolbarPnl.Controls.Add(this.showFilterBtn);
            this.toolbarPnl.haveCloseButton = false;
            this.toolbarPnl.Location = new System.Drawing.Point(-1, -1);
            this.toolbarPnl.Name = "toolbarPnl";
            this.toolbarPnl.Size = new System.Drawing.Size(642, 27);
            this.toolbarPnl.TabIndex = 240;
            // 
            // countLbl
            // 
            this.countLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLbl.Location = new System.Drawing.Point(566, 1);
            this.countLbl.Name = "countLbl";
            this.countLbl.Size = new System.Drawing.Size(70, 22);
            this.countLbl.TabIndex = 4;
            this.countLbl.Text = "???";
            this.countLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Image = global::baseClass.Properties.Resources.refresh;
            this.refreshBtn.Location = new System.Drawing.Point(26, 1);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(24, 21);
            this.refreshBtn.TabIndex = 2;
            this.myToolTip.SetToolTip(this.refreshBtn, "Lọc dữ liệu");
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // makeOrderBtn
            // 
            this.makeOrderBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makeOrderBtn.Image = global::baseClass.Properties.Resources.pencil;
            this.makeOrderBtn.Location = new System.Drawing.Point(2, 1);
            this.makeOrderBtn.Name = "makeOrderBtn";
            this.makeOrderBtn.Size = new System.Drawing.Size(24, 21);
            this.makeOrderBtn.TabIndex = 1;
            this.myToolTip.SetToolTip(this.makeOrderBtn, "Thực hiện giao dịch");
            this.makeOrderBtn.UseVisualStyleBackColor = true;
            // 
            // showFilterBtn
            // 
            this.showFilterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFilterBtn.Image = global::baseClass.Properties.Resources.filter;
            this.showFilterBtn.Location = new System.Drawing.Point(50, 1);
            this.showFilterBtn.Name = "showFilterBtn";
            this.showFilterBtn.Size = new System.Drawing.Size(24, 21);
            this.showFilterBtn.TabIndex = 3;
            this.myToolTip.SetToolTip(this.showFilterBtn, "Lọc dữ liệu");
            this.showFilterBtn.UseVisualStyleBackColor = true;
            this.showFilterBtn.Click += new System.EventHandler(this.showFilterBtn_Click);
            // 
            // filterBtn
            // 
            this.filterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtn.Image = global::baseClass.Properties.Resources.filter;
            this.filterBtn.Location = new System.Drawing.Point(375, 28);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(29, 25);
            this.filterBtn.TabIndex = 20;
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // portpolioCb
            // 
            this.portpolioCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portpolioCb.Enabled = false;
            this.portpolioCb.FormattingEnabled = true;
            this.portpolioCb.Location = new System.Drawing.Point(156, 28);
            this.portpolioCb.myValue = "";
            this.portpolioCb.Name = "portpolioCb";
            this.portpolioCb.Size = new System.Drawing.Size(121, 26);
            this.portpolioCb.TabIndex = 4;
            // 
            // tradeAlertStatusCb
            // 
            this.tradeAlertStatusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tradeAlertStatusCb.Enabled = false;
            this.tradeAlertStatusCb.FormattingEnabled = true;
            this.tradeAlertStatusCb.Location = new System.Drawing.Point(35, 28);
            this.tradeAlertStatusCb.myValue = application.myTypes.commonStatus.None;
            this.tradeAlertStatusCb.Name = "tradeAlertStatusCb";
            this.tradeAlertStatusCb.SelectedValue = ((byte)(0));
            this.tradeAlertStatusCb.Size = new System.Drawing.Size(121, 26);
            this.tradeAlertStatusCb.TabIndex = 2;
            // 
            // baseTradeAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 324);
            this.Controls.Add(this.filterPnl);
            this.Controls.Add(this.alertGrid);
            this.Controls.Add(this.toolbarPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.Name = "baseTradeAlert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trade alerts";
            this.Load += new System.EventHandler(this.baseTradeAlert_Load);
            this.Controls.SetChildIndex(this.toolbarPnl, 0);
            this.Controls.SetChildIndex(this.alertGrid, 0);
            this.Controls.SetChildIndex(this.filterPnl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.alertGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.filterPnl.ResumeLayout(false);
            this.filterPnl.PerformLayout();
            this.toolbarPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected data.baseDS myDataSet;
        protected common.control.baseDataGridView alertGrid;
        private System.Windows.Forms.BindingSource tradeAlertSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn onTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn statusDataGridViewTextBoxColumn;
        private common.control.gridViewImageColumn cancelColumn;
        private common.control.gridViewImageColumn viewColumn;
        protected common.control.basePanel filterPnl;
        protected common.control.baseButton filterBtn;
        protected common.control.baseCheckBox tradeAlertStatusChk;
        protected common.control.baseCheckBox frDateChk;
        protected common.control.baseDate frDateEd;
        protected common.control.baseCheckBox portpolioChk;
        protected baseClass.controls.cbPorpolio portpolioCb;
        protected baseClass.controls.cbTradeAlertStatus tradeAlertStatusCb;
        protected common.control.basePanel toolbarPnl;
        protected common.control.baseButton makeOrderBtn;
        protected common.control.baseButton showFilterBtn;
        protected common.control.baseButton refreshBtn;
        private common.control.baseLabel countLbl;

    }
}