namespace baseClass.forms
{
    partial class basePortfolioEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(basePortfolioEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.portfolioSource = new System.Windows.Forms.BindingSource(this.components);
            this.investorStockSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockCodeSource = new System.Windows.Forms.BindingSource(this.components);
            this.transHistorySource = new System.Windows.Forms.BindingSource(this.components);
            this.tradeActionSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.dataNavigatorCount = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.xpPanelGroup_Info = new UIComponents.XPPanelGroup();
            this.xpPanel_transHistory = new UIComponents.XPPanel(277);
            this.transOrderCriteria = new baseClass.controls.transactionCriteria();
            this.transHistGrid = new common.control.baseDataGridView();
            this.onTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.histTranTypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.stockCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transHistBtn = new common.control.baseButton();
            this.xpPane_ownedStock = new UIComponents.XPPanel(242);
            this.stockGrid = new common.control.baseDataGridView();
            this.stockCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockNameColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qtyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xpPane_generalInfo = new UIComponents.XPPanel(157);
            this.descriptionEd = new common.control.baseTextBox();
            this.codeLbl = new baseClass.controls.baseLabel();
            this.nameLbl = new baseClass.controls.baseLabel();
            this.codeEd = new common.control.baseTextBox();
            this.nameEd = new common.control.baseTextBox();
            this.descriptionLbl = new baseClass.controls.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorStockSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transHistorySource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeActionSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).BeginInit();
            this.dataNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).BeginInit();
            this.xpPanelGroup_Info.SuspendLayout();
            this.xpPanel_transHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transHistGrid)).BeginInit();
            this.xpPane_ownedStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockGrid)).BeginInit();
            this.xpPane_generalInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(442, 7);
            this.exitBtn.Size = new System.Drawing.Size(88, 39);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(90, 7);
            this.saveBtn.Size = new System.Drawing.Size(88, 39);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(178, 7);
            this.deleteBtn.Size = new System.Drawing.Size(88, 39);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(266, 7);
            this.editBtn.Size = new System.Drawing.Size(88, 39);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(2, 7);
            this.addNewBtn.Size = new System.Drawing.Size(88, 39);
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(875, 7);
            this.toExcelBtn.Visible = false;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(665, 7);
            this.findBtn.Visible = false;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Size = new System.Drawing.Size(88, 39);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(805, 7);
            this.printBtn.Visible = false;
            // 
            // portfolioSource
            // 
            this.portfolioSource.DataMember = "portfolio";
            this.portfolioSource.DataSource = this.myDataSet;
            this.portfolioSource.CurrentChanged += new System.EventHandler(this.portfolioSource_CurrentChanged);
            // 
            // investorStockSource
            // 
            this.investorStockSource.DataMember = "investorStock";
            this.investorStockSource.DataSource = this.myDataSet;
            // 
            // stockCodeSource
            // 
            this.stockCodeSource.DataMember = "stockCode";
            this.stockCodeSource.DataSource = this.myDataSet;
            // 
            // transHistorySource
            // 
            this.transHistorySource.DataMember = "investorTransHistory";
            this.transHistorySource.DataSource = this.myDataSet;
            // 
            // dataNavigator
            // 
            this.dataNavigator.AddNewItem = null;
            this.dataNavigator.BackColor = System.Drawing.SystemColors.Control;
            this.dataNavigator.BindingSource = this.portfolioSource;
            this.dataNavigator.CountItem = this.dataNavigatorCount;
            this.dataNavigator.CountItemFormat = "/{0}";
            this.dataNavigator.DeleteItem = null;
            this.dataNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.dataNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.dataNavigatorCount,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5});
            this.dataNavigator.Location = new System.Drawing.Point(336, 46);
            this.dataNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.dataNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.dataNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.dataNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.dataNavigator.Name = "dataNavigator";
            this.dataNavigator.PositionItem = this.bindingNavigatorPositionItem1;
            this.dataNavigator.Size = new System.Drawing.Size(199, 25);
            this.dataNavigator.TabIndex = 359;
            this.dataNavigator.Text = "bindingNavigator1";
            // 
            // dataNavigatorCount
            // 
            this.dataNavigatorCount.Name = "dataNavigatorCount";
            this.dataNavigatorCount.Size = new System.Drawing.Size(27, 22);
            this.dataNavigatorCount.Text = "/{0}";
            this.dataNavigatorCount.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Move last";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // xpPanelGroup_Info
            // 
            this.xpPanelGroup_Info.AutoScroll = true;
            this.xpPanelGroup_Info.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelGroup_Info.BorderMargin = new System.Drawing.Size(0, 0);
            this.xpPanelGroup_Info.Controls.Add(this.xpPanel_transHistory);
            this.xpPanelGroup_Info.Controls.Add(this.xpPane_ownedStock);
            this.xpPanelGroup_Info.Controls.Add(this.xpPane_generalInfo);
            this.xpPanelGroup_Info.Location = new System.Drawing.Point(0, 74);
            this.xpPanelGroup_Info.Name = "xpPanelGroup_Info";
            this.xpPanelGroup_Info.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpPanelGroup_Info.PanelGradient")));
            this.xpPanelGroup_Info.PanelSpacing = 0;
            this.xpPanelGroup_Info.Size = new System.Drawing.Size(529, 433);
            this.xpPanelGroup_Info.TabIndex = 360;
            // 
            // xpPanel_transHistory
            // 
            this.xpPanel_transHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_transHistory.AnimationRate = 0;
            this.xpPanel_transHistory.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_transHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.xpPanel_transHistory.Caption = "Lịch sử giao dịch";
            this.xpPanel_transHistory.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_transHistory.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_transHistory.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_transHistory.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_transHistory.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_transHistory.Controls.Add(this.transOrderCriteria);
            this.xpPanel_transHistory.Controls.Add(this.transHistGrid);
            this.xpPanel_transHistory.Controls.Add(this.transHistBtn);
            this.xpPanel_transHistory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_transHistory.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_transHistory.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_transHistory.ImageItems.ImageSet = null;
            this.xpPanel_transHistory.ImeMode = System.Windows.Forms.ImeMode.On;
            this.xpPanel_transHistory.Location = new System.Drawing.Point(0, 399);
            this.xpPanel_transHistory.Name = "xpPanel_transHistory";
            this.xpPanel_transHistory.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_transHistory.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_transHistory.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_transHistory.Size = new System.Drawing.Size(512, 277);
            this.xpPanel_transHistory.TabIndex = 10;
            this.xpPanel_transHistory.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_transHistory.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_transHistory.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_transHistory.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // transOrderCriteria
            // 
            this.transOrderCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transOrderCriteria.Location = new System.Drawing.Point(-1, 35);
            this.transOrderCriteria.myPortfolio = "";
            this.transOrderCriteria.Name = "transOrderCriteria";
            this.transOrderCriteria.PortfolioChecked = false;
            this.transOrderCriteria.PortfolioEnabled = true;
            this.transOrderCriteria.Size = new System.Drawing.Size(483, 46);
            this.transOrderCriteria.TabIndex = 1;
            // 
            // transHistGrid
            // 
            this.transHistGrid.AllowUserToAddRows = false;
            this.transHistGrid.AllowUserToDeleteRows = false;
            this.transHistGrid.AutoGenerateColumns = false;
            this.transHistGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transHistGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.onTimeDataGridViewTextBoxColumn,
            this.histTranTypeColumn,
            this.stockCodeDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.amtDataGridViewTextBoxColumn});
            this.transHistGrid.DataSource = this.transHistorySource;
            this.transHistGrid.DisableReadOnlyColumn = true;
            this.transHistGrid.Location = new System.Drawing.Point(-2, 86);
            this.transHistGrid.Name = "transHistGrid";
            this.transHistGrid.ReadOnly = true;
            this.transHistGrid.RowHeadersVisible = false;
            this.transHistGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transHistGrid.Size = new System.Drawing.Size(512, 190);
            this.transHistGrid.TabIndex = 20;
            this.transHistGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // onTimeDataGridViewTextBoxColumn
            // 
            this.onTimeDataGridViewTextBoxColumn.DataPropertyName = "onTime";
            this.onTimeDataGridViewTextBoxColumn.HeaderText = "Ngày/Giờ";
            this.onTimeDataGridViewTextBoxColumn.Name = "onTimeDataGridViewTextBoxColumn";
            this.onTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.onTimeDataGridViewTextBoxColumn.Width = 160;
            // 
            // histTranTypeColumn
            // 
            this.histTranTypeColumn.DataPropertyName = "tranType";
            this.histTranTypeColumn.DataSource = this.tradeActionSource;
            this.histTranTypeColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.histTranTypeColumn.HeaderText = "";
            this.histTranTypeColumn.Name = "histTranTypeColumn";
            this.histTranTypeColumn.ReadOnly = true;
            this.histTranTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.histTranTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.histTranTypeColumn.Width = 70;
            // 
            // stockCodeDataGridViewTextBoxColumn
            // 
            this.stockCodeDataGridViewTextBoxColumn.DataPropertyName = "stockCode";
            this.stockCodeDataGridViewTextBoxColumn.HeaderText = "Mã";
            this.stockCodeDataGridViewTextBoxColumn.Name = "stockCodeDataGridViewTextBoxColumn";
            this.stockCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockCodeDataGridViewTextBoxColumn.Width = 75;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "qty";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "KL";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 80;
            // 
            // amtDataGridViewTextBoxColumn
            // 
            this.amtDataGridViewTextBoxColumn.DataPropertyName = "amt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.amtDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.amtDataGridViewTextBoxColumn.HeaderText = "Giá trị";
            this.amtDataGridViewTextBoxColumn.Name = "amtDataGridViewTextBoxColumn";
            this.amtDataGridViewTextBoxColumn.ReadOnly = true;
            this.amtDataGridViewTextBoxColumn.Width = 105;
            // 
            // transHistBtn
            // 
            this.transHistBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transHistBtn.Image = global::baseClass.Properties.Resources.refresh;
            this.transHistBtn.isDownState = false;
            this.transHistBtn.Location = new System.Drawing.Point(484, 58);
            this.transHistBtn.Name = "transHistBtn";
            this.transHistBtn.Size = new System.Drawing.Size(25, 23);
            this.transHistBtn.TabIndex = 10;
            this.transHistBtn.UseVisualStyleBackColor = true;
            this.transHistBtn.Click += new System.EventHandler(this.transHistBtn_Click);
            // 
            // xpPane_ownedStock
            // 
            this.xpPane_ownedStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPane_ownedStock.AnimationRate = 0;
            this.xpPane_ownedStock.BackColor = System.Drawing.Color.Transparent;
            this.xpPane_ownedStock.Caption = "Cổ phiếu sở hữu";
            this.xpPane_ownedStock.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPane_ownedStock.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPane_ownedStock.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPane_ownedStock.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPane_ownedStock.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPane_ownedStock.Controls.Add(this.stockGrid);
            this.xpPane_ownedStock.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPane_ownedStock.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPane_ownedStock.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPane_ownedStock.ImageItems.ImageSet = null;
            this.xpPane_ownedStock.ImeMode = System.Windows.Forms.ImeMode.On;
            this.xpPane_ownedStock.Location = new System.Drawing.Point(0, 157);
            this.xpPane_ownedStock.Name = "xpPane_ownedStock";
            this.xpPane_ownedStock.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPane_ownedStock.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPane_ownedStock.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPane_ownedStock.Size = new System.Drawing.Size(512, 242);
            this.xpPane_ownedStock.TabIndex = 9;
            this.xpPane_ownedStock.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPane_ownedStock.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPane_ownedStock.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPane_ownedStock.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // stockGrid
            // 
            this.stockGrid.AllowUserToAddRows = false;
            this.stockGrid.AllowUserToDeleteRows = false;
            this.stockGrid.AutoGenerateColumns = false;
            this.stockGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stockCodeColumn,
            this.stockNameColumn,
            this.qtyColumn});
            this.stockGrid.DataSource = this.investorStockSource;
            this.stockGrid.DisableReadOnlyColumn = true;
            this.stockGrid.Location = new System.Drawing.Point(2, 34);
            this.stockGrid.Name = "stockGrid";
            this.stockGrid.ReadOnly = true;
            this.stockGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockGrid.Size = new System.Drawing.Size(511, 207);
            this.stockGrid.TabIndex = 40;
            this.stockGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // stockCodeColumn
            // 
            this.stockCodeColumn.DataPropertyName = "stockCode";
            this.stockCodeColumn.HeaderText = "Mã";
            this.stockCodeColumn.Name = "stockCodeColumn";
            this.stockCodeColumn.ReadOnly = true;
            this.stockCodeColumn.Width = 80;
            // 
            // stockNameColumn
            // 
            this.stockNameColumn.DataPropertyName = "stockCode";
            this.stockNameColumn.DataSource = this.stockCodeSource;
            this.stockNameColumn.DisplayMember = "name";
            this.stockNameColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.stockNameColumn.HeaderText = "Tên";
            this.stockNameColumn.Name = "stockNameColumn";
            this.stockNameColumn.ReadOnly = true;
            this.stockNameColumn.ValueMember = "code";
            this.stockNameColumn.Width = 215;
            // 
            // qtyColumn
            // 
            this.qtyColumn.DataPropertyName = "qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.qtyColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.qtyColumn.HeaderText = "Khối lượng";
            this.qtyColumn.Name = "qtyColumn";
            this.qtyColumn.ReadOnly = true;
            // 
            // xpPane_generalInfo
            // 
            this.xpPane_generalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPane_generalInfo.AnimationRate = 0;
            this.xpPane_generalInfo.BackColor = System.Drawing.Color.Transparent;
            this.xpPane_generalInfo.Caption = "Thông tin chung";
            this.xpPane_generalInfo.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPane_generalInfo.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPane_generalInfo.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPane_generalInfo.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPane_generalInfo.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPane_generalInfo.Controls.Add(this.descriptionEd);
            this.xpPane_generalInfo.Controls.Add(this.codeLbl);
            this.xpPane_generalInfo.Controls.Add(this.nameLbl);
            this.xpPane_generalInfo.Controls.Add(this.codeEd);
            this.xpPane_generalInfo.Controls.Add(this.nameEd);
            this.xpPane_generalInfo.Controls.Add(this.descriptionLbl);
            this.xpPane_generalInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPane_generalInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPane_generalInfo.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPane_generalInfo.ImageItems.ImageSet = null;
            this.xpPane_generalInfo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.xpPane_generalInfo.Location = new System.Drawing.Point(0, 0);
            this.xpPane_generalInfo.Name = "xpPane_generalInfo";
            this.xpPane_generalInfo.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPane_generalInfo.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPane_generalInfo.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPane_generalInfo.Size = new System.Drawing.Size(512, 157);
            this.xpPane_generalInfo.TabIndex = 6;
            this.xpPane_generalInfo.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPane_generalInfo.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPane_generalInfo.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPane_generalInfo.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // descriptionEd
            // 
            this.descriptionEd.BackColor = System.Drawing.SystemColors.Window;
            this.descriptionEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "description", true));
            this.descriptionEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionEd.Location = new System.Drawing.Point(25, 106);
            this.descriptionEd.Multiline = true;
            this.descriptionEd.Name = "descriptionEd";
            this.descriptionEd.Size = new System.Drawing.Size(468, 41);
            this.descriptionEd.TabIndex = 3;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(22, 37);
            this.codeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(46, 16);
            this.codeLbl.TabIndex = 364;
            this.codeLbl.Text = "Mã số";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(132, 37);
            this.nameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(31, 16);
            this.nameLbl.TabIndex = 353;
            this.nameLbl.Text = "Tên";
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.SystemColors.Window;
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "code", true));
            this.codeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEd.Location = new System.Drawing.Point(25, 56);
            this.codeEd.Name = "codeEd";
            this.codeEd.ReadOnly = true;
            this.codeEd.Size = new System.Drawing.Size(108, 24);
            this.codeEd.TabIndex = 1;
            this.codeEd.TabStop = false;
            // 
            // nameEd
            // 
            this.nameEd.BackColor = System.Drawing.SystemColors.Window;
            this.nameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "name", true));
            this.nameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameEd.Location = new System.Drawing.Point(133, 56);
            this.nameEd.Name = "nameEd";
            this.nameEd.Size = new System.Drawing.Size(360, 24);
            this.nameEd.TabIndex = 1;
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.Location = new System.Drawing.Point(25, 87);
            this.descriptionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(45, 16);
            this.descriptionLbl.TabIndex = 351;
            this.descriptionLbl.Text = "Mô tả";
            // 
            // basePortfolioEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 531);
            this.Controls.Add(this.xpPanelGroup_Info);
            this.Controls.Add(this.dataNavigator);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "basePortfolioEdit";
            this.Text = "Portfolio";
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.dataNavigator, 0);
            this.Controls.SetChildIndex(this.xpPanelGroup_Info, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorStockSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transHistorySource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeActionSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).EndInit();
            this.dataNavigator.ResumeLayout(false);
            this.dataNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).EndInit();
            this.xpPanelGroup_Info.ResumeLayout(false);
            this.xpPanel_transHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.transHistGrid)).EndInit();
            this.xpPane_ownedStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockGrid)).EndInit();
            this.xpPane_generalInfo.ResumeLayout(false);
            this.xpPane_generalInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.BindingSource portfolioSource;
        protected System.Windows.Forms.BindingSource investorStockSource;
        protected System.Windows.Forms.BindingSource stockCodeSource;
        protected System.Windows.Forms.BindingSource transHistorySource;
        protected System.Windows.Forms.BindingSource tradeActionSource;
        protected System.Windows.Forms.BindingNavigator dataNavigator;
        protected System.Windows.Forms.ToolStripLabel dataNavigatorCount;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        protected UIComponents.XPPanel xpPanel_transHistory;
        protected baseClass.controls.transactionCriteria transOrderCriteria;
        protected common.control.baseDataGridView transHistGrid;
        protected common.control.baseButton transHistBtn;
        protected UIComponents.XPPanel xpPane_ownedStock;
        protected common.control.baseDataGridView stockGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn stockNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyColumn;
        protected UIComponents.XPPanel xpPane_generalInfo;
        protected common.control.baseTextBox descriptionEd;
        protected baseClass.controls.baseLabel codeLbl;
        protected baseClass.controls.baseLabel nameLbl;
        protected common.control.baseTextBox codeEd;
        protected common.control.baseTextBox nameEd;
        protected baseClass.controls.baseLabel descriptionLbl;
        protected UIComponents.XPPanelGroup xpPanelGroup_Info;
        private System.Windows.Forms.DataGridViewTextBoxColumn onTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn histTranTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amtDataGridViewTextBoxColumn;


    }
}