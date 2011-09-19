namespace Trade.Forms
{
    partial class tradeAlertEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tradeAlertEdit));
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderBtn = new baseClass.controls.baseButton();
            this.cancelBtn = new baseClass.controls.baseButton();
            this.dataNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLbl = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tooolBarPnl = new common.control.basePanel();
            this.closeBtnq = new baseClass.controls.baseButton();
            this.actionLbl = new common.control.baseLabel();
            this.statusCb = new baseClass.controls.cbTradeAlertStatus();
            this.codeLbl = new common.control.baseLabel();
            this.codeEd = new common.control.baseTextBox();
            this.messageLbl = new common.control.baseLabel();
            this.messageEd = new common.control.baseTextBox();
            this.strategyLbl = new common.control.baseLabel();
            this.strategyCb = new baseClass.controls.cbStrategy();
            this.portfolioLbl = new common.control.baseLabel();
            this.portfolioCb = new baseClass.controls.cbWatchList();
            this.subjectLbl = new common.control.baseLabel();
            this.subjectEd = new common.control.baseTextBox();
            this.statusLbl = new common.control.baseLabel();
            this.onTimeLbl = new common.control.baseLabel();
            this.onTimeEd = new common.control.baseDate();
            this.actionCb = new baseClass.controls.cbTradeAction();
            this.stockLbl = new common.control.baseLabel();
            this.stockEd = new common.control.baseTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).BeginInit();
            this.dataNavigator.SuspendLayout();
            this.tooolBarPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(623, 96);
            this.closeBtn.Visible = false;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(612, 132);
            this.okBtn.Visible = false;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1018, 76);
            this.TitleLbl.Size = new System.Drawing.Size(62, 46);
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
            // orderBtn
            // 
            this.orderBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderBtn.Image = global::Trade.Properties.Resources.edit;
            this.orderBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.orderBtn.Location = new System.Drawing.Point(2, 1);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(130, 40);
            this.orderBtn.TabIndex = 10;
            this.orderBtn.Text = "Giao dịch";
            this.orderBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.orderBtn.UseVisualStyleBackColor = true;
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Image = global::Trade.Properties.Resources.pause;
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cancelBtn.Location = new System.Drawing.Point(132, 1);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(130, 40);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Bỏ qua";
            this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // dataNavigator
            // 
            this.dataNavigator.AddNewItem = null;
            this.dataNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dataNavigator.CountItemFormat = "/ {0}";
            this.dataNavigator.DeleteItem = null;
            this.dataNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLbl,
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.dataNavigator.Location = new System.Drawing.Point(0, 402);
            this.dataNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dataNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dataNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dataNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dataNavigator.Name = "dataNavigator";
            this.dataNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dataNavigator.Size = new System.Drawing.Size(393, 25);
            this.dataNavigator.TabIndex = 146;
            this.dataNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(30, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // toolStripLbl
            // 
            this.toolStripLbl.AutoSize = false;
            this.toolStripLbl.Name = "toolStripLbl";
            this.toolStripLbl.Size = new System.Drawing.Size(60, 22);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
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
            // tooolBarPnl
            // 
            this.tooolBarPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tooolBarPnl.Controls.Add(this.closeBtnq);
            this.tooolBarPnl.Controls.Add(this.cancelBtn);
            this.tooolBarPnl.Controls.Add(this.orderBtn);
            this.tooolBarPnl.haveCloseButton = false;
            this.tooolBarPnl.isExpanded = true;
            this.tooolBarPnl.isVisible = true;
            this.tooolBarPnl.Location = new System.Drawing.Point(-1, 0);
            this.tooolBarPnl.myIconLocations = common.control.basePanel.IconLocations.None;
            this.tooolBarPnl.mySizingOptions = common.control.basePanel.SizingOptions.None;
            this.tooolBarPnl.myWeight = 0;
            this.tooolBarPnl.Name = "tooolBarPnl";
            this.tooolBarPnl.Size = new System.Drawing.Size(404, 48);
            this.tooolBarPnl.TabIndex = 148;
            // 
            // closeBtnq
            // 
            this.closeBtnq.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtnq.Image = global::Trade.Properties.Resources.close;
            this.closeBtnq.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeBtnq.Location = new System.Drawing.Point(262, 1);
            this.closeBtnq.Name = "closeBtnq";
            this.closeBtnq.Size = new System.Drawing.Size(130, 40);
            this.closeBtnq.TabIndex = 13;
            this.closeBtnq.Text = "Đóng";
            this.closeBtnq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeBtnq.UseVisualStyleBackColor = true;
            this.closeBtnq.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // actionLbl
            // 
            this.actionLbl.AutoSize = true;
            this.actionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionLbl.Location = new System.Drawing.Point(157, 251);
            this.actionLbl.Name = "actionLbl";
            this.actionLbl.Size = new System.Drawing.Size(65, 16);
            this.actionLbl.TabIndex = 162;
            this.actionLbl.Text = "Giao dịch";
            // 
            // statusCb
            // 
            this.statusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCb.Enabled = false;
            this.statusCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCb.FormattingEnabled = true;
            this.statusCb.Location = new System.Drawing.Point(285, 271);
            this.statusCb.myValue = application.AppTypes.CommonStatus.None;
            this.statusCb.Name = "statusCb";
            this.statusCb.SelectedValue = ((byte)(0));
            this.statusCb.Size = new System.Drawing.Size(92, 24);
            this.statusCb.TabIndex = 32;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(167, 53);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(46, 16);
            this.codeLbl.TabIndex = 158;
            this.codeLbl.Text = "Mã số";
            // 
            // codeEd
            // 
            this.codeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEd.Location = new System.Drawing.Point(166, 72);
            this.codeEd.Name = "codeEd";
            this.codeEd.ReadOnly = true;
            this.codeEd.Size = new System.Drawing.Size(145, 24);
            this.codeEd.TabIndex = 2;
            // 
            // messageLbl
            // 
            this.messageLbl.AutoSize = true;
            this.messageLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLbl.Location = new System.Drawing.Point(21, 150);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(63, 16);
            this.messageLbl.TabIndex = 157;
            this.messageLbl.Text = "Nội dung";
            // 
            // messageEd
            // 
            this.messageEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageEd.Location = new System.Drawing.Point(21, 169);
            this.messageEd.Multiline = true;
            this.messageEd.Name = "messageEd";
            this.messageEd.ReadOnly = true;
            this.messageEd.Size = new System.Drawing.Size(356, 80);
            this.messageEd.TabIndex = 20;
            // 
            // strategyLbl
            // 
            this.strategyLbl.AutoSize = true;
            this.strategyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyLbl.Location = new System.Drawing.Point(22, 356);
            this.strategyLbl.Name = "strategyLbl";
            this.strategyLbl.Size = new System.Drawing.Size(74, 16);
            this.strategyLbl.TabIndex = 155;
            this.strategyLbl.Text = "Chiến lược";
            // 
            // strategyCb
            // 
            this.strategyCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.strategyCb.Enabled = false;
            this.strategyCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyCb.Location = new System.Drawing.Point(21, 376);
            this.strategyCb.myValue = "";
            this.strategyCb.Name = "strategyCb";
            this.strategyCb.Size = new System.Drawing.Size(356, 24);
            this.strategyCb.TabIndex = 50;
            // 
            // portfolioLbl
            // 
            this.portfolioLbl.AutoSize = true;
            this.portfolioLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioLbl.Location = new System.Drawing.Point(21, 303);
            this.portfolioLbl.Name = "portfolioLbl";
            this.portfolioLbl.Size = new System.Drawing.Size(63, 16);
            this.portfolioLbl.TabIndex = 154;
            this.portfolioLbl.Text = "Portfolio";
            // 
            // portfolioCb
            // 
            this.portfolioCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portfolioCb.Enabled = false;
            this.portfolioCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioCb.Location = new System.Drawing.Point(21, 324);
            this.portfolioCb.myValue = "";
            this.portfolioCb.Name = "portfolioCb";
            this.portfolioCb.Size = new System.Drawing.Size(356, 24);
            this.portfolioCb.TabIndex = 40;
            this.portfolioCb.WatchType = application.AppTypes.PortfolioTypes.Portfolio;
            // 
            // subjectLbl
            // 
            this.subjectLbl.AutoSize = true;
            this.subjectLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectLbl.Location = new System.Drawing.Point(21, 100);
            this.subjectLbl.Name = "subjectLbl";
            this.subjectLbl.Size = new System.Drawing.Size(54, 16);
            this.subjectLbl.TabIndex = 153;
            this.subjectLbl.Text = "Tiêu đề";
            // 
            // subjectEd
            // 
            this.subjectEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectEd.Location = new System.Drawing.Point(21, 121);
            this.subjectEd.Name = "subjectEd";
            this.subjectEd.ReadOnly = true;
            this.subjectEd.Size = new System.Drawing.Size(356, 24);
            this.subjectEd.TabIndex = 10;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(289, 252);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(74, 16);
            this.statusLbl.TabIndex = 152;
            this.statusLbl.Text = "Tình trạng";
            // 
            // onTimeLbl
            // 
            this.onTimeLbl.AutoSize = true;
            this.onTimeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onTimeLbl.Location = new System.Drawing.Point(21, 51);
            this.onTimeLbl.Name = "onTimeLbl";
            this.onTimeLbl.Size = new System.Drawing.Size(65, 16);
            this.onTimeLbl.TabIndex = 150;
            this.onTimeLbl.Text = "Thời gian";
            // 
            // onTimeEd
            // 
            this.onTimeEd.BeepOnError = true;
            this.onTimeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onTimeEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.onTimeEd.Location = new System.Drawing.Point(21, 72);
            this.onTimeEd.Mask = "00/00/0000 90:00";
            this.onTimeEd.myDateTime = new System.DateTime(((long)(0)));
            this.onTimeEd.Name = "onTimeEd";
            this.onTimeEd.ReadOnly = true;
            this.onTimeEd.Size = new System.Drawing.Size(145, 24);
            this.onTimeEd.TabIndex = 1;
            this.onTimeEd.ValidatingType = typeof(System.DateTime);
            // 
            // actionCb
            // 
            this.actionCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionCb.Enabled = false;
            this.actionCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionCb.Location = new System.Drawing.Point(158, 271);
            this.actionCb.myValue = application.AppTypes.TradeActions.None;
            this.actionCb.Name = "actionCb";
            this.actionCb.SelectedValue = ((byte)(0));
            this.actionCb.Size = new System.Drawing.Size(129, 24);
            this.actionCb.TabIndex = 31;
            // 
            // stockLbl
            // 
            this.stockLbl.AutoSize = true;
            this.stockLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockLbl.Location = new System.Drawing.Point(23, 253);
            this.stockLbl.Name = "stockLbl";
            this.stockLbl.Size = new System.Drawing.Size(63, 16);
            this.stockLbl.TabIndex = 164;
            this.stockLbl.Text = "Cổ phiếu";
            // 
            // stockEd
            // 
            this.stockEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockEd.Location = new System.Drawing.Point(21, 271);
            this.stockEd.Name = "stockEd";
            this.stockEd.ReadOnly = true;
            this.stockEd.Size = new System.Drawing.Size(137, 24);
            this.stockEd.TabIndex = 30;
            // 
            // tradeAlertEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(393, 450);
            this.Controls.Add(this.tooolBarPnl);
            this.Controls.Add(this.statusCb);
            this.Controls.Add(this.stockEd);
            this.Controls.Add(this.actionCb);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.stockLbl);
            this.Controls.Add(this.codeEd);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.messageLbl);
            this.Controls.Add(this.actionLbl);
            this.Controls.Add(this.messageEd);
            this.Controls.Add(this.strategyLbl);
            this.Controls.Add(this.strategyCb);
            this.Controls.Add(this.portfolioLbl);
            this.Controls.Add(this.portfolioCb);
            this.Controls.Add(this.subjectLbl);
            this.Controls.Add(this.subjectEd);
            this.Controls.Add(this.onTimeLbl);
            this.Controls.Add(this.onTimeEd);
            this.Controls.Add(this.dataNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = true;
            this.Name = "tradeAlertEdit";
            this.Text = "Trade alerts";
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.dataNavigator, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.onTimeEd, 0);
            this.Controls.SetChildIndex(this.onTimeLbl, 0);
            this.Controls.SetChildIndex(this.subjectEd, 0);
            this.Controls.SetChildIndex(this.subjectLbl, 0);
            this.Controls.SetChildIndex(this.portfolioCb, 0);
            this.Controls.SetChildIndex(this.portfolioLbl, 0);
            this.Controls.SetChildIndex(this.strategyCb, 0);
            this.Controls.SetChildIndex(this.strategyLbl, 0);
            this.Controls.SetChildIndex(this.messageEd, 0);
            this.Controls.SetChildIndex(this.actionLbl, 0);
            this.Controls.SetChildIndex(this.messageLbl, 0);
            this.Controls.SetChildIndex(this.statusLbl, 0);
            this.Controls.SetChildIndex(this.codeEd, 0);
            this.Controls.SetChildIndex(this.stockLbl, 0);
            this.Controls.SetChildIndex(this.codeLbl, 0);
            this.Controls.SetChildIndex(this.actionCb, 0);
            this.Controls.SetChildIndex(this.stockEd, 0);
            this.Controls.SetChildIndex(this.statusCb, 0);
            this.Controls.SetChildIndex(this.tooolBarPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).EndInit();
            this.dataNavigator.ResumeLayout(false);
            this.dataNavigator.PerformLayout();
            this.tooolBarPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        protected baseClass.controls.baseButton orderBtn;
        protected baseClass.controls.baseButton cancelBtn;
        private System.Windows.Forms.BindingNavigator dataNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLbl;
        protected baseClass.controls.baseButton closeBtnq;
        protected common.control.baseLabel actionLbl;
        protected baseClass.controls.cbTradeAlertStatus statusCb;
        protected common.control.baseLabel codeLbl;
        protected common.control.baseTextBox codeEd;
        protected common.control.baseLabel messageLbl;
        protected common.control.baseTextBox messageEd;
        protected common.control.baseLabel strategyLbl;
        protected baseClass.controls.cbStrategy strategyCb;
        protected common.control.baseLabel portfolioLbl;
        protected baseClass.controls.cbWatchList portfolioCb;
        protected common.control.baseLabel subjectLbl;
        protected common.control.baseTextBox subjectEd;
        protected common.control.baseLabel statusLbl;
        protected common.control.baseLabel onTimeLbl;
        protected common.control.baseDate onTimeEd;
        protected baseClass.controls.cbTradeAction actionCb;
        protected common.control.baseLabel stockLbl;
        protected common.control.baseTextBox stockEd;
        protected common.control.basePanel tooolBarPnl;

    }
}