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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(screening));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.criteriaGridLbl = new baseClass.controls.baseLabel();
            this.editBtn = new System.Windows.Forms.Button();
            this.maxScrollBar = new System.Windows.Forms.HScrollBar();
            this.criteriaSource = new System.Windows.Forms.BindingSource(this.components);
            this.tmpDS = new Tools.Data.tmpDataSet();
            this.minScrollBar = new System.Windows.Forms.HScrollBar();
            this.screeningCodeNav = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.strategyCb = new common.controls.baseComboBox();
            this.screeningCodeSource = new System.Windows.Forms.BindingSource(this.components);
            this.criteriaGrid = new common.controls.baseDataGridView();
            this.selectedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.minColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editColumn = new common.controls.gridViewImageColumn();
            this.delBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.descriptionLbl = new baseClass.controls.baseLabel();
            this.strategyDescEd = new common.controls.baseTextBox();
            this.maxLbl = new baseClass.controls.baseLabel();
            this.minLbl = new baseClass.controls.baseLabel();
            this.criteriaLbl = new baseClass.controls.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.dataPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.optionPnl.SuspendLayout();
            this.strategyGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screeningCodeNav)).BeginInit();
            this.screeningCodeNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screeningCodeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaGrid)).BeginInit();
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
            this.dataPnl.Location = new System.Drawing.Point(468, 0);
            this.dataPnl.Name = "dataPnl";
            this.dataPnl.Size = new System.Drawing.Size(633, 641);
            this.dataPnl.TabIndex = 315;
            // 
            // resultDataGrid
            // 
            this.resultDataGrid.AllowUserToAddRows = false;
            this.resultDataGrid.AllowUserToDeleteRows = false;
            this.resultDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGrid.DisableReadOnlyColumn = true;
            this.resultDataGrid.Location = new System.Drawing.Point(0, 0);
            this.resultDataGrid.Name = "resultDataGrid";
            this.resultDataGrid.ReadOnly = true;
            this.resultDataGrid.Size = new System.Drawing.Size(628, 662);
            this.resultDataGrid.TabIndex = 309;
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
            this.menuStrip.Size = new System.Drawing.Size(1004, 24);
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
            this.stockCodeLb.Location = new System.Drawing.Point(3, 392);
            this.stockCodeLb.Margin = new System.Windows.Forms.Padding(2);
            this.stockCodeLb.myItemString = "";
            this.stockCodeLb.myValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeLb.myValues")));
            this.stockCodeLb.Name = "stockCodeLb";
            this.stockCodeLb.ShowCheckedOnly = false;
            this.stockCodeLb.Size = new System.Drawing.Size(464, 247);
            this.stockCodeLb.TabIndex = 2;
            // 
            // codeListLbl
            // 
            this.codeListLbl.AutoSize = true;
            this.codeListLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeListLbl.Location = new System.Drawing.Point(0, 374);
            this.codeListLbl.Name = "codeListLbl";
            this.codeListLbl.Size = new System.Drawing.Size(67, 16);
            this.codeListLbl.TabIndex = 316;
            this.codeListLbl.Text = "Code List";
            this.codeListLbl.Click += new System.EventHandler(this.strategyLbl_Click);
            // 
            // optionPnl
            // 
            this.optionPnl.Controls.Add(this.codeListLbl);
            this.optionPnl.Controls.Add(this.stockCodeLb);
            this.optionPnl.Controls.Add(this.strategyGb);
            this.optionPnl.Location = new System.Drawing.Point(0, -1);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(466, 642);
            this.optionPnl.TabIndex = 1;
            // 
            // strategyGb
            // 
            this.strategyGb.Controls.Add(this.criteriaGridLbl);
            this.strategyGb.Controls.Add(this.editBtn);
            this.strategyGb.Controls.Add(this.maxScrollBar);
            this.strategyGb.Controls.Add(this.minScrollBar);
            this.strategyGb.Controls.Add(this.screeningCodeNav);
            this.strategyGb.Controls.Add(this.strategyCb);
            this.strategyGb.Controls.Add(this.criteriaGrid);
            this.strategyGb.Controls.Add(this.delBtn);
            this.strategyGb.Controls.Add(this.addBtn);
            this.strategyGb.Controls.Add(this.descriptionLbl);
            this.strategyGb.Controls.Add(this.strategyDescEd);
            this.strategyGb.Controls.Add(this.maxLbl);
            this.strategyGb.Controls.Add(this.minLbl);
            this.strategyGb.Controls.Add(this.criteriaLbl);
            this.strategyGb.Location = new System.Drawing.Point(3, -2);
            this.strategyGb.Name = "strategyGb";
            this.strategyGb.Size = new System.Drawing.Size(460, 373);
            this.strategyGb.TabIndex = 1;
            this.strategyGb.TabStop = false;
            // 
            // criteriaGridLbl
            // 
            this.criteriaGridLbl.AutoSize = true;
            this.criteriaGridLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaGridLbl.Location = new System.Drawing.Point(4, 201);
            this.criteriaGridLbl.Name = "criteriaGridLbl";
            this.criteriaGridLbl.Size = new System.Drawing.Size(16, 16);
            this.criteriaGridLbl.TabIndex = 376;
            this.criteriaGridLbl.Text = "  ";
            // 
            // editBtn
            // 
            this.editBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Image = global::Tools.Properties.Resources.edit;
            this.editBtn.Location = new System.Drawing.Point(438, 27);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(20, 20);
            this.editBtn.TabIndex = 2;
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // maxScrollBar
            // 
            this.maxScrollBar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.criteriaSource, "max", true));
            this.maxScrollBar.Location = new System.Drawing.Point(231, 144);
            this.maxScrollBar.Name = "maxScrollBar";
            this.maxScrollBar.Size = new System.Drawing.Size(208, 18);
            this.maxScrollBar.TabIndex = 11;
            this.maxScrollBar.ValueChanged += new System.EventHandler(this.maxScrollBar_ValueChanged);
            // 
            // criteriaSource
            // 
            this.criteriaSource.DataMember = "screeningCriteria";
            this.criteriaSource.DataSource = this.tmpDS;
            // 
            // tmpDS
            // 
            this.tmpDS.DataSetName = "tmpDataSet";
            this.tmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // minScrollBar
            // 
            this.minScrollBar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.criteriaSource, "min", true));
            this.minScrollBar.Location = new System.Drawing.Point(23, 144);
            this.minScrollBar.Name = "minScrollBar";
            this.minScrollBar.Size = new System.Drawing.Size(208, 18);
            this.minScrollBar.TabIndex = 10;
            this.minScrollBar.ValueChanged += new System.EventHandler(this.minScrollBar_ValueChanged);
            // 
            // screeningCodeNav
            // 
            this.screeningCodeNav.AddNewItem = null;
            this.screeningCodeNav.BindingSource = this.criteriaSource;
            this.screeningCodeNav.CountItem = null;
            this.screeningCodeNav.DeleteItem = null;
            this.screeningCodeNav.Dock = System.Windows.Forms.DockStyle.None;
            this.screeningCodeNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.screeningCodeNav.Location = new System.Drawing.Point(23, 169);
            this.screeningCodeNav.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.screeningCodeNav.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.screeningCodeNav.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.screeningCodeNav.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.screeningCodeNav.Name = "screeningCodeNav";
            this.screeningCodeNav.PositionItem = null;
            this.screeningCodeNav.Size = new System.Drawing.Size(108, 25);
            this.screeningCodeNav.TabIndex = 319;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // strategyCb
            // 
            this.strategyCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.criteriaSource, "code", true));
            this.strategyCb.DataSource = this.screeningCodeSource;
            this.strategyCb.DisplayMember = "description";
            this.strategyCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.strategyCb.FormattingEnabled = true;
            this.strategyCb.Location = new System.Drawing.Point(23, 28);
            this.strategyCb.myValue = "";
            this.strategyCb.Name = "strategyCb";
            this.strategyCb.Size = new System.Drawing.Size(417, 24);
            this.strategyCb.TabIndex = 1;
            this.strategyCb.ValueMember = "code";
            this.strategyCb.SelectedIndexChanged += new System.EventHandler(this.strategyCb_SelectedIndexChanged);
            // 
            // screeningCodeSource
            // 
            this.screeningCodeSource.DataMember = "screeningCode";
            this.screeningCodeSource.DataSource = this.tmpDS;
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
            this.criteriaGrid.DisableReadOnlyColumn = false;
            this.criteriaGrid.Location = new System.Drawing.Point(0, 200);
            this.criteriaGrid.Name = "criteriaGrid";
            this.criteriaGrid.RowHeadersWidth = 25;
            this.criteriaGrid.Size = new System.Drawing.Size(463, 170);
            this.criteriaGrid.TabIndex = 375;
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
            this.codeColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.codeColumn.HeaderText = "Criteria";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.codeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.codeColumn.ValueMember = "code";
            this.codeColumn.Width = 175;
            // 
            // minColumn
            // 
            this.minColumn.DataPropertyName = "min";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.minColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.minColumn.HeaderText = "Min";
            this.minColumn.Name = "minColumn";
            // 
            // maxColumn
            // 
            this.maxColumn.DataPropertyName = "max";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.maxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.maxColumn.HeaderText = "Max";
            this.maxColumn.Name = "maxColumn";
            // 
            // editColumn
            // 
            this.editColumn.HeaderText = "";
            this.editColumn.myValue = "";
            this.editColumn.Name = "editColumn";
            this.editColumn.Width = 25;
            // 
            // delBtn
            // 
            this.delBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delBtn.Image = global::Tools.Properties.Resources.delete;
            this.delBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delBtn.Location = new System.Drawing.Point(362, 169);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(74, 27);
            this.delBtn.TabIndex = 21;
            this.delBtn.Text = "  Delete";
            this.delBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Image = global::Tools.Properties.Resources.adddata;
            this.addBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBtn.Location = new System.Drawing.Point(287, 169);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(74, 27);
            this.addBtn.TabIndex = 20;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.Location = new System.Drawing.Point(23, 52);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(81, 16);
            this.descriptionLbl.TabIndex = 324;
            this.descriptionLbl.Text = "Description";
            // 
            // strategyDescEd
            // 
            this.strategyDescEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.screeningCodeSource, "description", true));
            this.strategyDescEd.Location = new System.Drawing.Point(23, 71);
            this.strategyDescEd.Multiline = true;
            this.strategyDescEd.Name = "strategyDescEd";
            this.strategyDescEd.ReadOnly = true;
            this.strategyDescEd.Size = new System.Drawing.Size(414, 50);
            this.strategyDescEd.TabIndex = 15;
            this.strategyDescEd.TabStop = false;
            // 
            // maxLbl
            // 
            this.maxLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxLbl.Location = new System.Drawing.Point(232, 125);
            this.maxLbl.Name = "maxLbl";
            this.maxLbl.Size = new System.Drawing.Size(207, 19);
            this.maxLbl.TabIndex = 322;
            this.maxLbl.Text = "Max";
            this.maxLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // minLbl
            // 
            this.minLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minLbl.Location = new System.Drawing.Point(23, 125);
            this.minLbl.Name = "minLbl";
            this.minLbl.Size = new System.Drawing.Size(206, 19);
            this.minLbl.TabIndex = 321;
            this.minLbl.Text = "Min";
            this.minLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // criteriaLbl
            // 
            this.criteriaLbl.AutoSize = true;
            this.criteriaLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaLbl.Location = new System.Drawing.Point(23, 10);
            this.criteriaLbl.Name = "criteriaLbl";
            this.criteriaLbl.Size = new System.Drawing.Size(56, 16);
            this.criteriaLbl.TabIndex = 318;
            this.criteriaLbl.Text = "Criteria";
            // 
            // screening
            // 
            this.ClientSize = new System.Drawing.Size(1004, 668);
            this.Controls.Add(this.dataPnl);
            this.Controls.Add(this.optionPnl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "screening";
            this.Text = "Screening";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.menuStrip, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.criteriaSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screeningCodeNav)).EndInit();
            this.screeningCodeNav.ResumeLayout(false);
            this.screeningCodeNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screeningCodeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaGrid)).EndInit();
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
        protected baseClass.controls.baseLabel criteriaLbl;
        protected baseClass.controls.baseLabel maxLbl;
        protected baseClass.controls.baseLabel minLbl;
        private System.Windows.Forms.GroupBox strategyGb;
        protected baseClass.controls.baseLabel descriptionLbl;
        protected System.Windows.Forms.Button addBtn;
        protected System.Windows.Forms.Button delBtn;
        protected System.Windows.Forms.BindingSource criteriaSource;
        protected Tools.Data.tmpDataSet tmpDS;
        protected System.Windows.Forms.BindingSource screeningCodeSource;
        protected common.controls.baseComboBox strategyCb;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        protected baseClass.controls.stockCodeSelect stockCodeLb;
        protected common.controls.baseTextBox strategyDescEd;
        protected common.controls.baseDataGridView criteriaGrid;
        protected System.Windows.Forms.BindingNavigator screeningCodeNav;
        protected System.Windows.Forms.HScrollBar maxScrollBar;
        protected System.Windows.Forms.HScrollBar minScrollBar;
        protected System.Windows.Forms.Button editBtn;
        protected baseClass.controls.baseLabel criteriaGridLbl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxColumn;
        private common.controls.gridViewImageColumn editColumn;
    }
}
