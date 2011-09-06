namespace stockTrade.forms
{
    partial class transactionBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(transactionBase));
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.paddingStrip = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editGB1 = new System.Windows.Forms.GroupBox();
            this.totalAmtEd = new common.control.numberTextBox();
            this.feePercEd = new common.control.numberTextBox();
            this.qtyEd = new common.control.numberTextBox();
            this.totalAmtLbl = new common.control.baseLabel();
            this.qtyLbl = new common.control.baseLabel();
            this.priceEd = new common.control.numberTextBox();
            this.feeAmtLbl = new common.control.baseLabel();
            this.priceLbl = new common.control.baseLabel();
            this.feeAmtEd = new common.control.numberTextBox();
            this.subTotalEd = new common.control.numberTextBox();
            this.subTotalLbl = new common.control.baseLabel();
            this.portfolioCb = new baseClass.controls.cbPortpolio();
            this.stockCodeEd = new baseClass.controls.txtStockCode();
            this.transTypeLbl = new common.control.baseLabel();
            this.codeEd = new common.control.baseTextBox();
            this.transTypeCb = new baseClass.controls.cbTradeAction();
            this.stockCodeLbl = new common.control.baseLabel();
            this.onTimeLbl = new common.control.baseLabel();
            this.onTimeEd = new common.control.baseDate();
            this.editGB2 = new System.Windows.Forms.GroupBox();
            this.statusLbl = new common.control.baseLabel();
            this.statusCb = new baseClass.controls.cbCommonStatus();
            this.portfolioLbl = new common.control.baseLabel();
            this.codeLbl = new common.control.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).BeginInit();
            this.dataNavigator.SuspendLayout();
            this.editGB1.SuspendLayout();
            this.editGB2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(736, 97);
            this.TitleLbl.Size = new System.Drawing.Size(314, 32);
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
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataNavigator
            // 
            this.dataNavigator.AddNewItem = null;
            this.dataNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dataNavigator.CountItemFormat = "{0}";
            this.dataNavigator.DeleteItem = null;
            this.dataNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paddingStrip,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.dataNavigator.Location = new System.Drawing.Point(0, 317);
            this.dataNavigator.MoveFirstItem = null;
            this.dataNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dataNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dataNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dataNavigator.Name = "dataNavigator";
            this.dataNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dataNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.dataNavigator.Size = new System.Drawing.Size(358, 25);
            this.dataNavigator.TabIndex = 160;
            this.dataNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorCountItem.Text = "{0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // paddingStrip
            // 
            this.paddingStrip.AutoSize = false;
            this.paddingStrip.Name = "paddingStrip";
            this.paddingStrip.Size = new System.Drawing.Size(120, 22);
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
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // editGB1
            // 
            this.editGB1.Controls.Add(this.totalAmtEd);
            this.editGB1.Controls.Add(this.feePercEd);
            this.editGB1.Controls.Add(this.qtyEd);
            this.editGB1.Controls.Add(this.totalAmtLbl);
            this.editGB1.Controls.Add(this.qtyLbl);
            this.editGB1.Controls.Add(this.priceEd);
            this.editGB1.Controls.Add(this.feeAmtLbl);
            this.editGB1.Controls.Add(this.priceLbl);
            this.editGB1.Controls.Add(this.feeAmtEd);
            this.editGB1.Controls.Add(this.subTotalEd);
            this.editGB1.Controls.Add(this.subTotalLbl);
            this.editGB1.Location = new System.Drawing.Point(2, 169);
            this.editGB1.Name = "editGB1";
            this.editGB1.Size = new System.Drawing.Size(354, 145);
            this.editGB1.TabIndex = 2;
            this.editGB1.TabStop = false;
            // 
            // totalAmtEd
            // 
            this.totalAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.totalAmtEd.Location = new System.Drawing.Point(127, 111);
            this.totalAmtEd.myFormat = "###,###,###,###,###";
            this.totalAmtEd.Name = "totalAmtEd";
            this.totalAmtEd.ReadOnly = true;
            this.totalAmtEd.Size = new System.Drawing.Size(154, 24);
            this.totalAmtEd.TabIndex = 6;
            this.totalAmtEd.TabStop = false;
            this.totalAmtEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalAmtEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.totalAmtEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // feePercEd
            // 
            this.feePercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.feePercEd.Location = new System.Drawing.Point(127, 87);
            this.feePercEd.myFormat = "###,###,##0.00";
            this.feePercEd.Name = "feePercEd";
            this.feePercEd.ReadOnly = true;
            this.feePercEd.Size = new System.Drawing.Size(42, 24);
            this.feePercEd.TabIndex = 4;
            this.feePercEd.TabStop = false;
            this.feePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.feePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.feePercEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // qtyEd
            // 
            this.qtyEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.qtyEd.Location = new System.Drawing.Point(127, 15);
            this.qtyEd.myFormat = "###,###,###,###,###";
            this.qtyEd.Name = "qtyEd";
            this.qtyEd.Size = new System.Drawing.Size(154, 24);
            this.qtyEd.TabIndex = 1;
            this.qtyEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.qtyEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.qtyEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // totalAmtLbl
            // 
            this.totalAmtLbl.AutoSize = true;
            this.totalAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAmtLbl.Location = new System.Drawing.Point(48, 115);
            this.totalAmtLbl.Name = "totalAmtLbl";
            this.totalAmtLbl.Size = new System.Drawing.Size(68, 16);
            this.totalAmtLbl.TabIndex = 173;
            this.totalAmtLbl.Text = "Tổng tiền";
            // 
            // qtyLbl
            // 
            this.qtyLbl.AutoSize = true;
            this.qtyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyLbl.Location = new System.Drawing.Point(41, 19);
            this.qtyLbl.Name = "qtyLbl";
            this.qtyLbl.Size = new System.Drawing.Size(75, 16);
            this.qtyLbl.TabIndex = 163;
            this.qtyLbl.Text = "Khối lượng";
            // 
            // priceEd
            // 
            this.priceEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.priceEd.Location = new System.Drawing.Point(127, 39);
            this.priceEd.myFormat = "###,###,###,###,###";
            this.priceEd.Name = "priceEd";
            this.priceEd.ReadOnly = true;
            this.priceEd.Size = new System.Drawing.Size(154, 24);
            this.priceEd.TabIndex = 2;
            this.priceEd.TabStop = false;
            this.priceEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.priceEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.priceEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // feeAmtLbl
            // 
            this.feeAmtLbl.AutoSize = true;
            this.feeAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feeAmtLbl.Location = new System.Drawing.Point(55, 91);
            this.feeAmtLbl.Name = "feeAmtLbl";
            this.feeAmtLbl.Size = new System.Drawing.Size(61, 16);
            this.feeAmtLbl.TabIndex = 171;
            this.feeAmtLbl.Text = "Tiền phí ";
            // 
            // priceLbl
            // 
            this.priceLbl.AutoSize = true;
            this.priceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLbl.Location = new System.Drawing.Point(59, 43);
            this.priceLbl.Name = "priceLbl";
            this.priceLbl.Size = new System.Drawing.Size(57, 16);
            this.priceLbl.TabIndex = 165;
            this.priceLbl.Text = "Đơn giá";
            // 
            // feeAmtEd
            // 
            this.feeAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feeAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.feeAmtEd.Location = new System.Drawing.Point(169, 87);
            this.feeAmtEd.myFormat = "###,###,###,###,###";
            this.feeAmtEd.Name = "feeAmtEd";
            this.feeAmtEd.ReadOnly = true;
            this.feeAmtEd.Size = new System.Drawing.Size(111, 24);
            this.feeAmtEd.TabIndex = 5;
            this.feeAmtEd.TabStop = false;
            this.feeAmtEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.feeAmtEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.feeAmtEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // subTotalEd
            // 
            this.subTotalEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTotalEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.subTotalEd.Location = new System.Drawing.Point(127, 63);
            this.subTotalEd.myFormat = "###,###,###,###,###";
            this.subTotalEd.Name = "subTotalEd";
            this.subTotalEd.ReadOnly = true;
            this.subTotalEd.Size = new System.Drawing.Size(154, 24);
            this.subTotalEd.TabIndex = 3;
            this.subTotalEd.TabStop = false;
            this.subTotalEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.subTotalEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.subTotalEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // subTotalLbl
            // 
            this.subTotalLbl.AutoSize = true;
            this.subTotalLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTotalLbl.Location = new System.Drawing.Point(63, 67);
            this.subTotalLbl.Name = "subTotalLbl";
            this.subTotalLbl.Size = new System.Drawing.Size(53, 16);
            this.subTotalLbl.TabIndex = 167;
            this.subTotalLbl.Text = "Số tiền";
            // 
            // portfolioCb
            // 
            this.portfolioCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portfolioCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioCb.Location = new System.Drawing.Point(128, 87);
            this.portfolioCb.myValue = "";
            this.portfolioCb.Name = "portfolioCb";
            this.portfolioCb.Size = new System.Drawing.Size(158, 24);
            this.portfolioCb.TabIndex = 11;
            this.portfolioCb.WatchType = application.myTypes.PortfolioTypes.Portfolio;
            // 
            // stockCodeEd
            // 
            this.stockCodeEd.BackColor = System.Drawing.Color.White;
            this.stockCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeEd.ForeColor = System.Drawing.Color.Black;
            this.stockCodeEd.Location = new System.Drawing.Point(128, 14);
            this.stockCodeEd.Name = "stockCodeEd";
            this.stockCodeEd.Size = new System.Drawing.Size(82, 24);
            this.stockCodeEd.TabIndex = 1;
            this.stockCodeEd.TabStop = false;
            // 
            // transTypeLbl
            // 
            this.transTypeLbl.AutoSize = true;
            this.transTypeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transTypeLbl.Location = new System.Drawing.Point(13, 68);
            this.transTypeLbl.Name = "transTypeLbl";
            this.transTypeLbl.Size = new System.Drawing.Size(95, 16);
            this.transTypeLbl.TabIndex = 157;
            this.transTypeLbl.Text = "Loại giao dịch";
            // 
            // codeEd
            // 
            this.codeEd.Enabled = false;
            this.codeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEd.Location = new System.Drawing.Point(128, 38);
            this.codeEd.Name = "codeEd";
            this.codeEd.ReadOnly = true;
            this.codeEd.Size = new System.Drawing.Size(81, 24);
            this.codeEd.TabIndex = 3;
            this.codeEd.TabStop = false;
            // 
            // transTypeCb
            // 
            this.transTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transTypeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transTypeCb.Location = new System.Drawing.Point(128, 62);
            this.transTypeCb.myValue = application.analysis.tradeActions.None;
            this.transTypeCb.Name = "transTypeCb";
            this.transTypeCb.SelectedValue = ((byte)(0));
            this.transTypeCb.Size = new System.Drawing.Size(158, 24);
            this.transTypeCb.TabIndex = 10;
            // 
            // stockCodeLbl
            // 
            this.stockCodeLbl.AutoSize = true;
            this.stockCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeLbl.Location = new System.Drawing.Point(23, 18);
            this.stockCodeLbl.Name = "stockCodeLbl";
            this.stockCodeLbl.Size = new System.Drawing.Size(85, 16);
            this.stockCodeLbl.TabIndex = 159;
            this.stockCodeLbl.Text = "Mã cổ phiếu";
            // 
            // onTimeLbl
            // 
            this.onTimeLbl.AutoSize = true;
            this.onTimeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onTimeLbl.Location = new System.Drawing.Point(43, 118);
            this.onTimeLbl.Name = "onTimeLbl";
            this.onTimeLbl.Size = new System.Drawing.Size(65, 16);
            this.onTimeLbl.TabIndex = 161;
            this.onTimeLbl.Text = "Thời gian";
            // 
            // onTimeEd
            // 
            this.onTimeEd.BeepOnError = true;
            this.onTimeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onTimeEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.onTimeEd.Location = new System.Drawing.Point(128, 113);
            this.onTimeEd.Mask = "00/00/0000 90:00";
            this.onTimeEd.myDateTime = new System.DateTime(((long)(0)));
            this.onTimeEd.Name = "onTimeEd";
            this.onTimeEd.ReadOnly = true;
            this.onTimeEd.Size = new System.Drawing.Size(158, 24);
            this.onTimeEd.TabIndex = 12;
            this.onTimeEd.TabStop = false;
            this.onTimeEd.ValidatingType = typeof(System.DateTime);
            // 
            // editGB2
            // 
            this.editGB2.Controls.Add(this.statusLbl);
            this.editGB2.Controls.Add(this.statusCb);
            this.editGB2.Controls.Add(this.onTimeLbl);
            this.editGB2.Controls.Add(this.onTimeEd);
            this.editGB2.Controls.Add(this.portfolioLbl);
            this.editGB2.Controls.Add(this.stockCodeLbl);
            this.editGB2.Controls.Add(this.transTypeLbl);
            this.editGB2.Controls.Add(this.portfolioCb);
            this.editGB2.Controls.Add(this.stockCodeEd);
            this.editGB2.Controls.Add(this.codeEd);
            this.editGB2.Controls.Add(this.transTypeCb);
            this.editGB2.Controls.Add(this.codeLbl);
            this.editGB2.Location = new System.Drawing.Point(3, -3);
            this.editGB2.Name = "editGB2";
            this.editGB2.Size = new System.Drawing.Size(354, 173);
            this.editGB2.TabIndex = 1;
            this.editGB2.TabStop = false;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(34, 143);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(74, 16);
            this.statusLbl.TabIndex = 163;
            this.statusLbl.Text = "Tình trạng";
            // 
            // statusCb
            // 
            this.statusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCb.Enabled = false;
            this.statusCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCb.Location = new System.Drawing.Point(128, 139);
            this.statusCb.myValue = application.myTypes.CommonStatus.None;
            this.statusCb.Name = "statusCb";
            this.statusCb.SelectedValue = ((byte)(0));
            this.statusCb.Size = new System.Drawing.Size(158, 24);
            this.statusCb.TabIndex = 13;
            this.statusCb.TabStop = false;
            // 
            // portfolioLbl
            // 
            this.portfolioLbl.AutoSize = true;
            this.portfolioLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioLbl.Location = new System.Drawing.Point(42, 93);
            this.portfolioLbl.Name = "portfolioLbl";
            this.portfolioLbl.Size = new System.Drawing.Size(63, 16);
            this.portfolioLbl.TabIndex = 152;
            this.portfolioLbl.Text = "Portfolio";
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(20, 43);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(88, 16);
            this.codeLbl.TabIndex = 156;
            this.codeLbl.Text = "Mã giao dịch";
            // 
            // transactionBase
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(358, 365);
            this.Controls.Add(this.editGB1);
            this.Controls.Add(this.editGB2);
            this.Controls.Add(this.dataNavigator);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "transactionBase";
            this.Text = "Transactions";
            this.Controls.SetChildIndex(this.dataNavigator, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.editGB2, 0);
            this.Controls.SetChildIndex(this.editGB1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).EndInit();
            this.dataNavigator.ResumeLayout(false);
            this.dataNavigator.PerformLayout();
            this.editGB1.ResumeLayout(false);
            this.editGB1.PerformLayout();
            this.editGB2.ResumeLayout(false);
            this.editGB2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripLabel paddingStrip;
        protected System.Windows.Forms.BindingNavigator dataNavigator;
        protected common.control.baseLabel totalAmtLbl;
        protected common.control.baseLabel qtyLbl;
        protected common.control.baseLabel feeAmtLbl;
        protected common.control.baseLabel priceLbl;
        protected common.control.baseLabel subTotalLbl;
        protected baseClass.controls.cbPortpolio portfolioCb;
        protected baseClass.controls.txtStockCode stockCodeEd;
        protected common.control.baseLabel transTypeLbl;
        protected common.control.baseTextBox codeEd;
        protected baseClass.controls.cbTradeAction transTypeCb;
        protected common.control.baseLabel stockCodeLbl;
        protected common.control.baseLabel onTimeLbl;
        protected common.control.baseDate onTimeEd;
        protected common.control.baseLabel portfolioLbl;
        protected common.control.baseLabel codeLbl;
        protected System.Windows.Forms.GroupBox editGB1;
        protected common.control.numberTextBox totalAmtEd;
        protected common.control.numberTextBox feePercEd;
        protected common.control.numberTextBox qtyEd;
        protected common.control.numberTextBox priceEd;
        protected common.control.numberTextBox feeAmtEd;
        protected common.control.numberTextBox subTotalEd;
        protected System.Windows.Forms.GroupBox editGB2;
        protected common.control.baseLabel statusLbl;
        protected baseClass.controls.cbCommonStatus statusCb;

    }
}