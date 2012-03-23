namespace Tools.Forms
{
    partial class screening
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(screening));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataPnl = new System.Windows.Forms.Panel();
            this.resultDataGrid = new common.controls.baseDataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fullViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportResultMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToWatchListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockCodeLb = new baseClass.controls.stockCodeSelect();
            this.codeListLbl = new baseClass.controls.baseLabel();
            this.optionPnl = new System.Windows.Forms.Panel();
            this.strategyGb = new System.Windows.Forms.GroupBox();
            this.dataCounEd = new common.controls.numberTextBox();
            this.timeScaleLbl = new baseClass.controls.baseLabel();
            this.timeScaleCb = new baseClass.controls.cbTimeScale();
            this.maxDataCountLbl = new baseClass.controls.baseLabel();
            this.selectAllChk = new common.controls.baseCheckBox();
            this.criteriaGrid = new common.controls.baseDataGridView();
            this.selectedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.screeningCodeSource = new System.Windows.Forms.BindingSource(this.components);
            this.tmpDS = new Tools.Data.tmpDataSet();
            this.minColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColumn = new common.controls.gridViewImageColumn();
            this.criteriaSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.dataPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.optionPnl.SuspendLayout();
            this.strategyGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screeningCodeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(585, 2);
            this.TitleLbl.Size = new System.Drawing.Size(10, 46);
            // 
            // dataPnl
            // 
            this.dataPnl.Controls.Add(this.resultDataGrid);
            this.dataPnl.Location = new System.Drawing.Point(479, 0);
            this.dataPnl.Name = "dataPnl";
            this.dataPnl.Size = new System.Drawing.Size(538, 645);
            this.dataPnl.TabIndex = 315;
            // 
            // resultDataGrid
            // 
            this.resultDataGrid.AllowUserToAddRows = false;
            this.resultDataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.resultDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.resultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultDataGrid.Location = new System.Drawing.Point(0, 0);
            this.resultDataGrid.Name = "resultDataGrid";
            this.resultDataGrid.ReadOnly = true;
            this.resultDataGrid.RowTemplate.Height = 24;
            this.resultDataGrid.Size = new System.Drawing.Size(538, 645);
            this.resultDataGrid.TabIndex = 309;
            this.resultDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultDataGrid_RowEnter);
            this.resultDataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentDoubleClick);
            this.resultDataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1015, 24);
            this.menuStrip.TabIndex = 318;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mainMenuItem
            // 
            this.mainMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runMenuItem,
            this.toolStripSeparator2,
            this.fullViewMenuItem,
            this.toolStripSeparator1,
            this.exportResultMenuItem,
            this.toolStripSeparator3,
            this.openMenuItem,
            this.addToWatchListMenuItem});
            this.mainMenuItem.Name = "mainMenuItem";
            this.mainMenuItem.Size = new System.Drawing.Size(84, 20);
            this.mainMenuItem.Text = "Screening";
            // 
            // runMenuItem
            // 
            this.runMenuItem.Name = "runMenuItem";
            this.runMenuItem.Size = new System.Drawing.Size(206, 22);
            this.runMenuItem.Text = "Run";
            this.runMenuItem.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(203, 6);
            // 
            // fullViewMenuItem
            // 
            this.fullViewMenuItem.Enabled = false;
            this.fullViewMenuItem.Name = "fullViewMenuItem";
            this.fullViewMenuItem.Size = new System.Drawing.Size(206, 22);
            this.fullViewMenuItem.Text = "Full View";
            this.fullViewMenuItem.Click += new System.EventHandler(this.fullViewMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // exportResultMenuItem
            // 
            this.exportResultMenuItem.Enabled = false;
            this.exportResultMenuItem.Name = "exportResultMenuItem";
            this.exportResultMenuItem.Size = new System.Drawing.Size(206, 22);
            this.exportResultMenuItem.Text = "Export Results";
            this.exportResultMenuItem.Click += new System.EventHandler(this.exportResultMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(203, 6);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(206, 22);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // addToWatchListMenuItem
            // 
            this.addToWatchListMenuItem.Name = "addToWatchListMenuItem";
            this.addToWatchListMenuItem.Size = new System.Drawing.Size(206, 22);
            this.addToWatchListMenuItem.Text = "Add to Watch List";
            this.addToWatchListMenuItem.Click += new System.EventHandler(this.addToWatchListMenuItem_Click);
            // 
            // stockCodeLb
            // 
            this.stockCodeLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stockCodeLb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeLb.Location = new System.Drawing.Point(2, 309);
            this.stockCodeLb.Margin = new System.Windows.Forms.Padding(2);
            this.stockCodeLb.myItemString = "";
            this.stockCodeLb.myValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeLb.myValues")));
            this.stockCodeLb.Name = "stockCodeLb";
            this.stockCodeLb.ShowCheckedOnly = false;
            this.stockCodeLb.Size = new System.Drawing.Size(476, 305);
            this.stockCodeLb.TabIndex = 2;
            // 
            // codeListLbl
            // 
            this.codeListLbl.AutoSize = true;
            this.codeListLbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeListLbl.Location = new System.Drawing.Point(6, 291);
            this.codeListLbl.Name = "codeListLbl";
            this.codeListLbl.Size = new System.Drawing.Size(64, 14);
            this.codeListLbl.TabIndex = 316;
            this.codeListLbl.Text = "Code List";
            this.codeListLbl.Click += new System.EventHandler(this.strategyLbl_Click);
            // 
            // optionPnl
            // 
            this.optionPnl.Controls.Add(this.codeListLbl);
            this.optionPnl.Controls.Add(this.stockCodeLb);
            this.optionPnl.Controls.Add(this.strategyGb);
            this.optionPnl.Location = new System.Drawing.Point(0, 28);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(478, 617);
            this.optionPnl.TabIndex = 1;
            // 
            // strategyGb
            // 
            this.strategyGb.Controls.Add(this.dataCounEd);
            this.strategyGb.Controls.Add(this.timeScaleLbl);
            this.strategyGb.Controls.Add(this.timeScaleCb);
            this.strategyGb.Controls.Add(this.maxDataCountLbl);
            this.strategyGb.Controls.Add(this.selectAllChk);
            this.strategyGb.Controls.Add(this.criteriaGrid);
            this.strategyGb.Location = new System.Drawing.Point(3, -5);
            this.strategyGb.Name = "strategyGb";
            this.strategyGb.Size = new System.Drawing.Size(475, 289);
            this.strategyGb.TabIndex = 1;
            this.strategyGb.TabStop = false;
            // 
            // dataCounEd
            // 
            this.dataCounEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataCounEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dataCounEd.Location = new System.Drawing.Point(176, 31);
            this.dataCounEd.myFormat = "###,###,###,###,##0";
            this.dataCounEd.Name = "dataCounEd";
            this.dataCounEd.Size = new System.Drawing.Size(99, 21);
            this.dataCounEd.TabIndex = 2;
            this.dataCounEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataCounEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dataCounEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // timeScaleLbl
            // 
            this.timeScaleLbl.AutoSize = true;
            this.timeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeScaleLbl.Location = new System.Drawing.Point(24, 13);
            this.timeScaleLbl.Name = "timeScaleLbl";
            this.timeScaleLbl.Size = new System.Drawing.Size(68, 14);
            this.timeScaleLbl.TabIndex = 381;
            this.timeScaleLbl.Text = "Time scale";
            // 
            // timeScaleCb
            // 
            this.timeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeScaleCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeScaleCb.FormattingEnabled = true;
            this.timeScaleCb.Location = new System.Drawing.Point(23, 31);
            this.timeScaleCb.Name = "timeScaleCb";
            this.timeScaleCb.SelectedValue = "RT";
            this.timeScaleCb.Size = new System.Drawing.Size(155, 21);
            this.timeScaleCb.TabIndex = 1;
            this.timeScaleCb.TabStop = false;
            // 
            // maxDataCountLbl
            // 
            this.maxDataCountLbl.AutoSize = true;
            this.maxDataCountLbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxDataCountLbl.Location = new System.Drawing.Point(178, 13);
            this.maxDataCountLbl.Name = "maxDataCountLbl";
            this.maxDataCountLbl.Size = new System.Drawing.Size(70, 14);
            this.maxDataCountLbl.TabIndex = 379;
            this.maxDataCountLbl.Text = "No of bars";
            // 
            // selectAllChk
            // 
            this.selectAllChk.AutoSize = true;
            this.selectAllChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllChk.Location = new System.Drawing.Point(30, 60);
            this.selectAllChk.Name = "selectAllChk";
            this.selectAllChk.Size = new System.Drawing.Size(15, 14);
            this.selectAllChk.TabIndex = 377;
            this.selectAllChk.TabStop = false;
            this.selectAllChk.UseVisualStyleBackColor = true;
            this.selectAllChk.CheckedChanged += new System.EventHandler(this.selectAllChk_CheckedChanged);
            // 
            // criteriaGrid
            // 
            this.criteriaGrid.AllowUserToAddRows = false;
            this.criteriaGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.criteriaGrid.AutoGenerateColumns = false;
            this.criteriaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.criteriaGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectedColumn,
            this.codeColumn,
            this.minColumn,
            this.maxColumn,
            this.editColumn});
            this.criteriaGrid.DataSource = this.criteriaSource;
            this.criteriaGrid.Location = new System.Drawing.Point(1, 56);
            this.criteriaGrid.Name = "criteriaGrid";
            this.criteriaGrid.RowHeadersWidth = 25;
            this.criteriaGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaGrid.RowTemplate.Height = 24;
            this.criteriaGrid.Size = new System.Drawing.Size(478, 231);
            this.criteriaGrid.TabIndex = 375;
            this.criteriaGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.criteriaGrid_RowEnter);
            this.criteriaGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.criteriaGrid_CellClick);
            // 
            // selectedColumn
            // 
            this.selectedColumn.DataPropertyName = "selected";
            this.selectedColumn.HeaderText = "";
            this.selectedColumn.Name = "selectedColumn";
            this.selectedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selectedColumn.Width = 20;
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "code";
            this.codeColumn.DataSource = this.screeningCodeSource;
            this.codeColumn.DisplayMember = "description";
            this.codeColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.codeColumn.HeaderText = "Criteria";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.codeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.codeColumn.ValueMember = "code";
            this.codeColumn.Width = 235;
            // 
            // screeningCodeSource
            // 
            this.screeningCodeSource.DataMember = "screeningCode";
            this.screeningCodeSource.DataSource = this.tmpDS;
            // 
            // tmpDS
            // 
            this.tmpDS.DataSetName = "tmpDataSet";
            this.tmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // minColumn
            // 
            this.minColumn.DataPropertyName = "min";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.minColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.minColumn.HeaderText = "Min";
            this.minColumn.Name = "minColumn";
            this.minColumn.Width = 70;
            // 
            // maxColumn
            // 
            this.maxColumn.DataPropertyName = "max";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.maxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.maxColumn.HeaderText = "Max";
            this.maxColumn.Name = "maxColumn";
            this.maxColumn.Width = 70;
            // 
            // editColumn
            // 
            this.editColumn.HeaderText = "";
            this.editColumn.myValue = "";
            this.editColumn.Name = "editColumn";
            this.editColumn.Width = 25;
            // 
            // criteriaSource
            // 
            this.criteriaSource.DataMember = "screeningCriteria";
            this.criteriaSource.DataSource = this.tmpDS;
            // 
            // screening
            // 
            this.ClientSize = new System.Drawing.Size(1015, 671);
            this.Controls.Add(this.dataPnl);
            this.Controls.Add(this.optionPnl);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "screening";
            this.Text = "Screening";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.optionPnl, 0);
            this.Controls.SetChildIndex(this.dataPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.dataPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.optionPnl.ResumeLayout(false);
            this.optionPnl.PerformLayout();
            this.strategyGb.ResumeLayout(false);
            this.strategyGb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screeningCodeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel dataPnl;
        protected common.controls.baseDataGridView resultDataGrid;
        protected System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mainMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fullViewMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportResultMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToWatchListMenuItem;
        protected baseClass.controls.baseLabel codeListLbl;
        private System.Windows.Forms.Panel optionPnl;
        private System.Windows.Forms.GroupBox strategyGb;
        protected System.Windows.Forms.BindingSource criteriaSource;
        protected Tools.Data.tmpDataSet tmpDS;
        protected System.Windows.Forms.BindingSource screeningCodeSource;
        protected baseClass.controls.stockCodeSelect stockCodeLb;
        protected common.controls.baseDataGridView criteriaGrid;
        private common.controls.baseCheckBox selectAllChk;
        protected baseClass.controls.baseLabel timeScaleLbl;
        private baseClass.controls.cbTimeScale timeScaleCb;
        protected baseClass.controls.baseLabel maxDataCountLbl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxColumn;
        private common.controls.gridViewImageColumn editColumn;
        private common.controls.numberTextBox dataCounEd;
    }
}
