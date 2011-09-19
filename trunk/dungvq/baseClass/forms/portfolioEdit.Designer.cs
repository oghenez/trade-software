namespace baseClass.forms
{
    partial class portfolioEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(portfolioEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.portfolioSource = new System.Windows.Forms.BindingSource(this.components);
            this.investorStockSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockCodeSource = new System.Windows.Forms.BindingSource(this.components);
            this.transHistorySource = new System.Windows.Forms.BindingSource(this.components);
            this.tradeActionSource = new System.Windows.Forms.BindingSource(this.components);
            this.xpPanelGroup_Info = new UIComponents.XPPanelGroup();
            this.xpPane_ownedStock = new UIComponents.XPPanel(133);
            this.stockGrid = new common.control.baseDataGridView();
            this.stockCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockNameColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qtyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xpPanel_Investment = new UIComponents.XPPanel(163);
            this.cashAmtEd = new common.control.numberTextBox();
            this.usedAmtLbl = new baseClass.controls.baseLabel();
            this.cashAmtLbl = new baseClass.controls.baseLabel();
            this.usedAmtEd = new common.control.numberTextBox();
            this.capitalUnitLbl = new baseClass.controls.baseLabel();
            this.stockPercLbl = new baseClass.controls.baseLabel();
            this.capitalAmtLbl = new baseClass.controls.baseLabel();
            this.stockAccumulatePercEd = new common.control.numberTextBox();
            this.maxBuyAmtPercEd = new common.control.numberTextBox();
            this.stockReducePercLbl = new baseClass.controls.baseLabel();
            this.maxBuyAmtPercLbl = new baseClass.controls.baseLabel();
            this.stockReducePercEd = new common.control.numberTextBox();
            this.capitalAmtEd = new common.control.numberTextBox();
            this.stockAccumulatePercLbl = new baseClass.controls.baseLabel();
            this.xpPane_generalInfo = new UIComponents.XPPanel(223);
            this.descriptionEd = new common.control.baseTextBox();
            this.codeLbl = new baseClass.controls.baseLabel();
            this.nameLbl = new baseClass.controls.baseLabel();
            this.codeEd = new common.control.baseTextBox();
            this.nameEd = new common.control.baseTextBox();
            this.descriptionLbl = new baseClass.controls.baseLabel();
            this.portfolioGrid = new common.control.baseDataGridView();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorStockSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transHistorySource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeActionSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).BeginInit();
            this.xpPanelGroup_Info.SuspendLayout();
            this.xpPane_ownedStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockGrid)).BeginInit();
            this.xpPanel_Investment.SuspendLayout();
            this.xpPane_generalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-5, -3);
            this.toolBox.Size = new System.Drawing.Size(486, 53);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(404, 5);
            this.exitBtn.Size = new System.Drawing.Size(80, 39);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(84, 5);
            this.saveBtn.Size = new System.Drawing.Size(80, 39);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(164, 5);
            this.deleteBtn.Size = new System.Drawing.Size(80, 39);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(244, 5);
            this.editBtn.Size = new System.Drawing.Size(80, 39);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(4, 5);
            this.addNewBtn.Size = new System.Drawing.Size(80, 39);
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
            this.reloadBtn.Location = new System.Drawing.Point(324, 5);
            this.reloadBtn.Size = new System.Drawing.Size(80, 39);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(805, 7);
            this.printBtn.Visible = false;
            // 
            // unLockBtn
            // 
            this.unLockBtn.Location = new System.Drawing.Point(1114, 296);
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(1114, 255);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1125, 9);
            this.TitleLbl.Size = new System.Drawing.Size(72, 24);
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
            this.transHistorySource.DataMember = "transactions";
            this.transHistorySource.DataSource = this.myDataSet;
            // 
            // xpPanelGroup_Info
            // 
            this.xpPanelGroup_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.xpPanelGroup_Info.AutoScroll = true;
            this.xpPanelGroup_Info.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelGroup_Info.BorderMargin = new System.Drawing.Size(0, 0);
            this.xpPanelGroup_Info.Controls.Add(this.xpPane_ownedStock);
            this.xpPanelGroup_Info.Controls.Add(this.xpPanel_Investment);
            this.xpPanelGroup_Info.Controls.Add(this.xpPane_generalInfo);
            this.xpPanelGroup_Info.Location = new System.Drawing.Point(0, 48);
            this.xpPanelGroup_Info.Name = "xpPanelGroup_Info";
            this.xpPanelGroup_Info.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpPanelGroup_Info.PanelGradient")));
            this.xpPanelGroup_Info.PanelSpacing = 0;
            this.xpPanelGroup_Info.Size = new System.Drawing.Size(483, 730);
            this.xpPanelGroup_Info.TabIndex = 360;
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
            this.xpPane_ownedStock.Location = new System.Drawing.Point(0, 386);
            this.xpPane_ownedStock.Name = "xpPane_ownedStock";
            this.xpPane_ownedStock.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPane_ownedStock.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPane_ownedStock.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPane_ownedStock.Size = new System.Drawing.Size(483, 133);
            this.xpPane_ownedStock.TabIndex = 363;
            this.xpPane_ownedStock.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPane_ownedStock.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPane_ownedStock.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPane_ownedStock.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // stockGrid
            // 
            this.stockGrid.AllowUserToAddRows = false;
            this.stockGrid.AllowUserToDeleteRows = false;
            this.stockGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.stockGrid.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stockGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.stockGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stockCodeColumn,
            this.stockNameColumn,
            this.qtyColumn});
            this.stockGrid.DataSource = this.investorStockSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.stockGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.stockGrid.DisableReadOnlyColumn = true;
            this.stockGrid.Location = new System.Drawing.Point(2, 34);
            this.stockGrid.Name = "stockGrid";
            this.stockGrid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stockGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.stockGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockGrid.Size = new System.Drawing.Size(479, 99);
            this.stockGrid.TabIndex = 40;
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
            this.stockNameColumn.Width = 220;
            // 
            // qtyColumn
            // 
            this.qtyColumn.DataPropertyName = "qty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.qtyColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.qtyColumn.HeaderText = "Khối lượng";
            this.qtyColumn.Name = "qtyColumn";
            this.qtyColumn.ReadOnly = true;
            // 
            // xpPanel_Investment
            // 
            this.xpPanel_Investment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_Investment.AnimationRate = 0;
            this.xpPanel_Investment.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_Investment.Caption = "Đầu tư";
            this.xpPanel_Investment.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_Investment.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Investment.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Investment.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Investment.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_Investment.Controls.Add(this.cashAmtEd);
            this.xpPanel_Investment.Controls.Add(this.usedAmtLbl);
            this.xpPanel_Investment.Controls.Add(this.cashAmtLbl);
            this.xpPanel_Investment.Controls.Add(this.usedAmtEd);
            this.xpPanel_Investment.Controls.Add(this.capitalUnitLbl);
            this.xpPanel_Investment.Controls.Add(this.stockPercLbl);
            this.xpPanel_Investment.Controls.Add(this.capitalAmtLbl);
            this.xpPanel_Investment.Controls.Add(this.stockAccumulatePercEd);
            this.xpPanel_Investment.Controls.Add(this.maxBuyAmtPercEd);
            this.xpPanel_Investment.Controls.Add(this.stockReducePercLbl);
            this.xpPanel_Investment.Controls.Add(this.maxBuyAmtPercLbl);
            this.xpPanel_Investment.Controls.Add(this.stockReducePercEd);
            this.xpPanel_Investment.Controls.Add(this.capitalAmtEd);
            this.xpPanel_Investment.Controls.Add(this.stockAccumulatePercLbl);
            this.xpPanel_Investment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_Investment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_Investment.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_Investment.ImageItems.ImageSet = null;
            this.xpPanel_Investment.Location = new System.Drawing.Point(0, 223);
            this.xpPanel_Investment.Name = "xpPanel_Investment";
            this.xpPanel_Investment.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_Investment.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_Investment.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Investment.Size = new System.Drawing.Size(483, 163);
            this.xpPanel_Investment.TabIndex = 362;
            this.xpPanel_Investment.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_Investment.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_Investment.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_Investment.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // cashAmtEd
            // 
            this.cashAmtEd.BackColor = System.Drawing.SystemColors.Window;
            this.cashAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.cashAmtEd.Location = new System.Drawing.Point(284, 67);
            this.cashAmtEd.myFormat = "###,###,###,###,###";
            this.cashAmtEd.Name = "cashAmtEd";
            this.cashAmtEd.ReadOnly = true;
            this.cashAmtEd.Size = new System.Drawing.Size(130, 24);
            this.cashAmtEd.TabIndex = 3;
            this.cashAmtEd.TabStop = false;
            this.cashAmtEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cashAmtEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.cashAmtEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // usedAmtLbl
            // 
            this.usedAmtLbl.AutoSize = true;
            this.usedAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usedAmtLbl.Location = new System.Drawing.Point(152, 47);
            this.usedAmtLbl.Name = "usedAmtLbl";
            this.usedAmtLbl.Size = new System.Drawing.Size(82, 16);
            this.usedAmtLbl.TabIndex = 366;
            this.usedAmtLbl.Text = "Đã sử dụng";
            // 
            // cashAmtLbl
            // 
            this.cashAmtLbl.AutoSize = true;
            this.cashAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashAmtLbl.Location = new System.Drawing.Point(283, 49);
            this.cashAmtLbl.Name = "cashAmtLbl";
            this.cashAmtLbl.Size = new System.Drawing.Size(63, 16);
            this.cashAmtLbl.TabIndex = 367;
            this.cashAmtLbl.Text = "Tiền mặt";
            // 
            // usedAmtEd
            // 
            this.usedAmtEd.BackColor = System.Drawing.SystemColors.Window;
            this.usedAmtEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "usedCapAmt", true));
            this.usedAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usedAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.usedAmtEd.Location = new System.Drawing.Point(154, 67);
            this.usedAmtEd.myFormat = "###,###,###,###,###";
            this.usedAmtEd.Name = "usedAmtEd";
            this.usedAmtEd.ReadOnly = true;
            this.usedAmtEd.Size = new System.Drawing.Size(130, 24);
            this.usedAmtEd.TabIndex = 2;
            this.usedAmtEd.TabStop = false;
            this.usedAmtEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.usedAmtEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.usedAmtEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // capitalUnitLbl
            // 
            this.capitalUnitLbl.AutoSize = true;
            this.capitalUnitLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalUnitLbl.Location = new System.Drawing.Point(414, 70);
            this.capitalUnitLbl.Name = "capitalUnitLbl";
            this.capitalUnitLbl.Size = new System.Drawing.Size(36, 16);
            this.capitalUnitLbl.TabIndex = 343;
            this.capitalUnitLbl.Text = "????";
            // 
            // stockPercLbl
            // 
            this.stockPercLbl.AutoSize = true;
            this.stockPercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockPercLbl.Location = new System.Drawing.Point(414, 129);
            this.stockPercLbl.Name = "stockPercLbl";
            this.stockPercLbl.Size = new System.Drawing.Size(22, 16);
            this.stockPercLbl.TabIndex = 363;
            this.stockPercLbl.Text = "%";
            // 
            // capitalAmtLbl
            // 
            this.capitalAmtLbl.AutoSize = true;
            this.capitalAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalAmtLbl.Location = new System.Drawing.Point(24, 48);
            this.capitalAmtLbl.Name = "capitalAmtLbl";
            this.capitalAmtLbl.Size = new System.Drawing.Size(100, 16);
            this.capitalAmtLbl.TabIndex = 342;
            this.capitalAmtLbl.Text = "Số tiền đầu tư";
            // 
            // stockAccumulatePercEd
            // 
            this.stockAccumulatePercEd.BackColor = System.Drawing.SystemColors.Window;
            this.stockAccumulatePercEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "stockAccumulatePerc", true));
            this.stockAccumulatePercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockAccumulatePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.stockAccumulatePercEd.Location = new System.Drawing.Point(156, 124);
            this.stockAccumulatePercEd.myFormat = "###";
            this.stockAccumulatePercEd.Name = "stockAccumulatePercEd";
            this.stockAccumulatePercEd.Size = new System.Drawing.Size(130, 24);
            this.stockAccumulatePercEd.TabIndex = 11;
            this.stockAccumulatePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stockAccumulatePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.stockAccumulatePercEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // maxBuyAmtPercEd
            // 
            this.maxBuyAmtPercEd.BackColor = System.Drawing.SystemColors.Window;
            this.maxBuyAmtPercEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "maxBuyAmtPerc", true));
            this.maxBuyAmtPercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxBuyAmtPercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.maxBuyAmtPercEd.Location = new System.Drawing.Point(26, 124);
            this.maxBuyAmtPercEd.myFormat = "###";
            this.maxBuyAmtPercEd.Name = "maxBuyAmtPercEd";
            this.maxBuyAmtPercEd.ReadOnly = true;
            this.maxBuyAmtPercEd.Size = new System.Drawing.Size(130, 24);
            this.maxBuyAmtPercEd.TabIndex = 10;
            this.maxBuyAmtPercEd.TabStop = false;
            this.maxBuyAmtPercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxBuyAmtPercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.maxBuyAmtPercEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // stockReducePercLbl
            // 
            this.stockReducePercLbl.AutoSize = true;
            this.stockReducePercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockReducePercLbl.Location = new System.Drawing.Point(289, 104);
            this.stockReducePercLbl.Name = "stockReducePercLbl";
            this.stockReducePercLbl.Size = new System.Drawing.Size(65, 16);
            this.stockReducePercLbl.TabIndex = 361;
            this.stockReducePercLbl.Text = "K/L giảm";
            // 
            // maxBuyAmtPercLbl
            // 
            this.maxBuyAmtPercLbl.AutoSize = true;
            this.maxBuyAmtPercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxBuyAmtPercLbl.Location = new System.Drawing.Point(26, 104);
            this.maxBuyAmtPercLbl.Name = "maxBuyAmtPercLbl";
            this.maxBuyAmtPercLbl.Size = new System.Drawing.Size(103, 16);
            this.maxBuyAmtPercLbl.TabIndex = 362;
            this.maxBuyAmtPercLbl.Text = "G/T mua tối đa";
            // 
            // stockReducePercEd
            // 
            this.stockReducePercEd.BackColor = System.Drawing.SystemColors.Window;
            this.stockReducePercEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "stockReducePerc", true));
            this.stockReducePercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockReducePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.stockReducePercEd.Location = new System.Drawing.Point(286, 124);
            this.stockReducePercEd.myFormat = "###";
            this.stockReducePercEd.Name = "stockReducePercEd";
            this.stockReducePercEd.ReadOnly = true;
            this.stockReducePercEd.Size = new System.Drawing.Size(130, 24);
            this.stockReducePercEd.TabIndex = 12;
            this.stockReducePercEd.TabStop = false;
            this.stockReducePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stockReducePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.stockReducePercEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // capitalAmtEd
            // 
            this.capitalAmtEd.BackColor = System.Drawing.SystemColors.Window;
            this.capitalAmtEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "startCapAmt", true));
            this.capitalAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.capitalAmtEd.Location = new System.Drawing.Point(24, 67);
            this.capitalAmtEd.myFormat = "###,###,###,###,###";
            this.capitalAmtEd.Name = "capitalAmtEd";
            this.capitalAmtEd.Size = new System.Drawing.Size(130, 24);
            this.capitalAmtEd.TabIndex = 1;
            this.capitalAmtEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.capitalAmtEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.capitalAmtEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.capitalAmtEd.Validating += new System.ComponentModel.CancelEventHandler(this.capitalAmtEd_Validating);
            // 
            // stockAccumulatePercLbl
            // 
            this.stockAccumulatePercLbl.AutoSize = true;
            this.stockAccumulatePercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockAccumulatePercLbl.Location = new System.Drawing.Point(160, 104);
            this.stockAccumulatePercLbl.Name = "stockAccumulatePercLbl";
            this.stockAccumulatePercLbl.Size = new System.Drawing.Size(82, 16);
            this.stockAccumulatePercLbl.TabIndex = 360;
            this.stockAccumulatePercLbl.Text = "K/L tích lũy";
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
            this.xpPane_generalInfo.Size = new System.Drawing.Size(483, 223);
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
            this.descriptionEd.Location = new System.Drawing.Point(25, 161);
            this.descriptionEd.Multiline = true;
            this.descriptionEd.Name = "descriptionEd";
            this.descriptionEd.Size = new System.Drawing.Size(422, 41);
            this.descriptionEd.TabIndex = 3;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(24, 43);
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
            this.nameLbl.Location = new System.Drawing.Point(25, 91);
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
            this.codeEd.Location = new System.Drawing.Point(25, 62);
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
            this.nameEd.Location = new System.Drawing.Point(26, 110);
            this.nameEd.Name = "nameEd";
            this.nameEd.Size = new System.Drawing.Size(421, 24);
            this.nameEd.TabIndex = 1;
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.Location = new System.Drawing.Point(25, 142);
            this.descriptionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(45, 16);
            this.descriptionLbl.TabIndex = 351;
            this.descriptionLbl.Text = "Mô tả";
            // 
            // portfolioGrid
            // 
            this.portfolioGrid.AllowUserToAddRows = false;
            this.portfolioGrid.AllowUserToDeleteRows = false;
            this.portfolioGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.portfolioGrid.AutoGenerateColumns = false;
            this.portfolioGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.portfolioGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeColumn,
            this.nameColumn});
            this.portfolioGrid.DataSource = this.portfolioSource;
            this.portfolioGrid.DisableReadOnlyColumn = false;
            this.portfolioGrid.Location = new System.Drawing.Point(483, -1);
            this.portfolioGrid.Name = "portfolioGrid";
            this.portfolioGrid.ReadOnly = true;
            this.portfolioGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioGrid.Size = new System.Drawing.Size(363, 777);
            this.portfolioGrid.TabIndex = 361;
            this.portfolioGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "code";
            this.codeColumn.HeaderText = "Mã số";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            this.codeColumn.Width = 80;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "name";
            this.nameColumn.HeaderText = "Tên";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 225;
            // 
            // portfolioEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(846, 798);
            this.Controls.Add(this.xpPanelGroup_Info);
            this.Controls.Add(this.portfolioGrid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "portfolioEdit";
            this.Text = "Portfolio";
            this.Resize += new System.EventHandler(this.basePortfolioEdit_Resize);
            this.Controls.SetChildIndex(this.portfolioGrid, 0);
            this.Controls.SetChildIndex(this.xpPanelGroup_Info, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorStockSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transHistorySource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeActionSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).EndInit();
            this.xpPanelGroup_Info.ResumeLayout(false);
            this.xpPane_ownedStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockGrid)).EndInit();
            this.xpPanel_Investment.ResumeLayout(false);
            this.xpPanel_Investment.PerformLayout();
            this.xpPane_generalInfo.ResumeLayout(false);
            this.xpPane_generalInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.BindingSource portfolioSource;
        protected System.Windows.Forms.BindingSource investorStockSource;
        protected System.Windows.Forms.BindingSource stockCodeSource;
        protected System.Windows.Forms.BindingSource transHistorySource;
        protected System.Windows.Forms.BindingSource tradeActionSource;
        protected UIComponents.XPPanel xpPane_generalInfo;
        protected common.control.baseTextBox descriptionEd;
        protected baseClass.controls.baseLabel codeLbl;
        protected baseClass.controls.baseLabel nameLbl;
        protected common.control.baseTextBox codeEd;
        protected common.control.baseTextBox nameEd;
        protected baseClass.controls.baseLabel descriptionLbl;
        protected UIComponents.XPPanelGroup xpPanelGroup_Info;
        protected common.control.baseDataGridView portfolioGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        protected UIComponents.XPPanel xpPanel_Investment;
        protected common.control.numberTextBox cashAmtEd;
        protected baseClass.controls.baseLabel usedAmtLbl;
        protected baseClass.controls.baseLabel cashAmtLbl;
        protected common.control.numberTextBox usedAmtEd;
        protected baseClass.controls.baseLabel capitalUnitLbl;
        protected baseClass.controls.baseLabel stockPercLbl;
        protected baseClass.controls.baseLabel capitalAmtLbl;
        protected common.control.numberTextBox stockAccumulatePercEd;
        protected common.control.numberTextBox maxBuyAmtPercEd;
        protected baseClass.controls.baseLabel stockReducePercLbl;
        protected baseClass.controls.baseLabel maxBuyAmtPercLbl;
        protected common.control.numberTextBox stockReducePercEd;
        protected common.control.numberTextBox capitalAmtEd;
        protected baseClass.controls.baseLabel stockAccumulatePercLbl;
        protected UIComponents.XPPanel xpPane_ownedStock;
        protected common.control.baseDataGridView stockGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn stockNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyColumn;


    }
}