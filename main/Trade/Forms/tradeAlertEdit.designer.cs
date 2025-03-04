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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tradeAlertEdit));
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderBtn = new baseClass.controls.baseButton();
            this.disableAlertBtn = new baseClass.controls.baseButton();
            this.dataNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.alertSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.tooolBarPnl = new common.controls.basePanel();
            this.enableAlertBtn = new baseClass.controls.baseButton();
            this.closeBtnq = new baseClass.controls.baseButton();
            this.actionLbl = new common.controls.baseLabel();
            this.statusCb = new baseClass.controls.cbTradeAlertStatus();
            this.alertCodeEd = new common.controls.baseTextBox();
            this.informationLbl = new common.controls.baseLabel();
            this.informationEd = new common.controls.baseTextBox();
            this.strategyLbl = new common.controls.baseLabel();
            this.strategyCb = new baseClass.controls.cbStrategy();
            this.subjectLbl = new common.controls.baseLabel();
            this.subjectEd = new common.controls.baseTextBox();
            this.statusLbl = new common.controls.baseLabel();
            this.onDateLbl = new common.controls.baseLabel();
            this.onDateEd = new common.controls.baseDate();
            this.actionCb = new baseClass.controls.cbTradeAction();
            this.codeLbl = new common.controls.baseLabel();
            this.codeEd = new common.controls.baseTextBox();
            this.portfolioLbl = new common.controls.baseLabel();
            this.portfolioCb = new baseClass.controls.cbWatchList();
            this.timeScaleCb = new baseClass.controls.cbTimeScale();
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).BeginInit();
            this.dataNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertSource)).BeginInit();
            this.tooolBarPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(623, 96);
            this.closeBtn.Text = "Close";
            this.closeBtn.Visible = false;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(612, 132);
            this.okBtn.Text = "Ok";
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.orderBtn.Location = new System.Drawing.Point(1, 1);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(98, 40);
            this.orderBtn.TabIndex = 10;
            this.orderBtn.Text = "Order";
            this.orderBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.orderBtn.UseVisualStyleBackColor = true;
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // disableAlertBtn
            // 
            this.disableAlertBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disableAlertBtn.Image = global::Trade.Properties.Resources.pause;
            this.disableAlertBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.disableAlertBtn.Location = new System.Drawing.Point(99, 1);
            this.disableAlertBtn.Name = "disableAlertBtn";
            this.disableAlertBtn.Size = new System.Drawing.Size(98, 40);
            this.disableAlertBtn.TabIndex = 11;
            this.disableAlertBtn.Text = "Disable";
            this.disableAlertBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.disableAlertBtn.UseVisualStyleBackColor = true;
            this.disableAlertBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // dataNavigator
            // 
            this.dataNavigator.AddNewItem = null;
            this.dataNavigator.BindingSource = this.alertSource;
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
            this.dataNavigator.Location = new System.Drawing.Point(0, 403);
            this.dataNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dataNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dataNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dataNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dataNavigator.Name = "dataNavigator";
            this.dataNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dataNavigator.Size = new System.Drawing.Size(390, 25);
            this.dataNavigator.TabIndex = 146;
            this.dataNavigator.Text = "bindingNavigator1";
            // 
            // alertSource
            // 
            this.alertSource.CurrentChanged += new System.EventHandler(this.alertSource_CurrentChanged);
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
            this.tooolBarPnl.Controls.Add(this.enableAlertBtn);
            this.tooolBarPnl.Controls.Add(this.closeBtnq);
            this.tooolBarPnl.Controls.Add(this.disableAlertBtn);
            this.tooolBarPnl.Controls.Add(this.orderBtn);
            this.tooolBarPnl.haveCloseButton = false;
            this.tooolBarPnl.isExpanded = true;
            this.tooolBarPnl.Location = new System.Drawing.Point(-1, 0);
            this.tooolBarPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.tooolBarPnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.tooolBarPnl.myWeight = 0;
            this.tooolBarPnl.Name = "tooolBarPnl";
            this.tooolBarPnl.Size = new System.Drawing.Size(522, 48);
            this.tooolBarPnl.TabIndex = 148;
            // 
            // enableAlertBtn
            // 
            this.enableAlertBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableAlertBtn.Image = global::Trade.Properties.Resources.undo;
            this.enableAlertBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.enableAlertBtn.Location = new System.Drawing.Point(197, 1);
            this.enableAlertBtn.Name = "enableAlertBtn";
            this.enableAlertBtn.Size = new System.Drawing.Size(98, 40);
            this.enableAlertBtn.TabIndex = 12;
            this.enableAlertBtn.Text = "Recover";
            this.enableAlertBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.enableAlertBtn.UseVisualStyleBackColor = true;
            this.enableAlertBtn.Click += new System.EventHandler(this.recoverBtn_Click);
            // 
            // closeBtnq
            // 
            this.closeBtnq.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtnq.Image = global::Trade.Properties.Resources.close;
            this.closeBtnq.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeBtnq.Location = new System.Drawing.Point(295, 1);
            this.closeBtnq.Name = "closeBtnq";
            this.closeBtnq.Size = new System.Drawing.Size(98, 40);
            this.closeBtnq.TabIndex = 13;
            this.closeBtnq.Text = "Close";
            this.closeBtnq.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeBtnq.UseVisualStyleBackColor = true;
            this.closeBtnq.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // actionLbl
            // 
            this.actionLbl.AutoSize = true;
            this.actionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionLbl.Location = new System.Drawing.Point(157, 149);
            this.actionLbl.Name = "actionLbl";
            this.actionLbl.Size = new System.Drawing.Size(65, 16);
            this.actionLbl.TabIndex = 162;
            this.actionLbl.Text = "Giao dịch";
            // 
            // statusCb
            // 
            this.statusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCb.Enabled = false;
            this.statusCb.FormattingEnabled = true;
            this.statusCb.Location = new System.Drawing.Point(284, 169);
            this.statusCb.myValue = commonClass.AppTypes.CommonStatus.None;
            this.statusCb.Name = "statusCb";
            this.statusCb.SelectedValue = ((byte)(0));
            this.statusCb.Size = new System.Drawing.Size(88, 24);
            this.statusCb.TabIndex = 32;
            // 
            // alertCodeEd
            // 
            this.alertCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alertCodeEd.isToUpperCase = false;
            this.alertCodeEd.Location = new System.Drawing.Point(166, 72);
            this.alertCodeEd.Name = "alertCodeEd";
            this.alertCodeEd.ReadOnly = true;
            this.alertCodeEd.Size = new System.Drawing.Size(97, 24);
            this.alertCodeEd.TabIndex = 2;
            // 
            // informationLbl
            // 
            this.informationLbl.AutoSize = true;
            this.informationLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.informationLbl.Location = new System.Drawing.Point(19, 307);
            this.informationLbl.Name = "informationLbl";
            this.informationLbl.Size = new System.Drawing.Size(84, 16);
            this.informationLbl.TabIndex = 157;
            this.informationLbl.Text = "Information";
            // 
            // informationEd
            // 
            this.informationEd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.informationEd.isToUpperCase = false;
            this.informationEd.Location = new System.Drawing.Point(22, 326);
            this.informationEd.Multiline = true;
            this.informationEd.Name = "informationEd";
            this.informationEd.ReadOnly = true;
            this.informationEd.Size = new System.Drawing.Size(347, 66);
            this.informationEd.TabIndex = 60;
            // 
            // strategyLbl
            // 
            this.strategyLbl.AutoSize = true;
            this.strategyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyLbl.Location = new System.Drawing.Point(25, 255);
            this.strategyLbl.Name = "strategyLbl";
            this.strategyLbl.Size = new System.Drawing.Size(66, 16);
            this.strategyLbl.TabIndex = 155;
            this.strategyLbl.Text = "Strategy";
            // 
            // strategyCb
            // 
            this.strategyCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.strategyCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.strategyCb.Enabled = false;
            this.strategyCb.Location = new System.Drawing.Point(22, 275);
            this.strategyCb.myValue = "";
            this.strategyCb.Name = "strategyCb";
            this.strategyCb.SelectedValue = "";
            this.strategyCb.Size = new System.Drawing.Size(282, 24);
            this.strategyCb.TabIndex = 50;
            // 
            // subjectLbl
            // 
            this.subjectLbl.AutoSize = true;
            this.subjectLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectLbl.Location = new System.Drawing.Point(21, 100);
            this.subjectLbl.Name = "subjectLbl";
            this.subjectLbl.Size = new System.Drawing.Size(57, 16);
            this.subjectLbl.TabIndex = 153;
            this.subjectLbl.Text = "Subject";
            // 
            // subjectEd
            // 
            this.subjectEd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectEd.isToUpperCase = false;
            this.subjectEd.Location = new System.Drawing.Point(22, 121);
            this.subjectEd.Name = "subjectEd";
            this.subjectEd.ReadOnly = true;
            this.subjectEd.Size = new System.Drawing.Size(347, 24);
            this.subjectEd.TabIndex = 10;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(288, 150);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(51, 16);
            this.statusLbl.TabIndex = 152;
            this.statusLbl.Text = "Status";
            // 
            // onDateLbl
            // 
            this.onDateLbl.AutoSize = true;
            this.onDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onDateLbl.Location = new System.Drawing.Point(21, 51);
            this.onDateLbl.Name = "onDateLbl";
            this.onDateLbl.Size = new System.Drawing.Size(76, 16);
            this.onDateLbl.TabIndex = 150;
            this.onDateLbl.Text = "Date/Time";
            // 
            // onDateEd
            // 
            this.onDateEd.BeepOnError = true;
            this.onDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.onDateEd.Location = new System.Drawing.Point(21, 72);
            this.onDateEd.Mask = "00/00/0000 90:00";
            this.onDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.onDateEd.Name = "onDateEd";
            this.onDateEd.ReadOnly = true;
            this.onDateEd.Size = new System.Drawing.Size(145, 24);
            this.onDateEd.TabIndex = 1;
            this.onDateEd.ValidatingType = typeof(System.DateTime);
            // 
            // actionCb
            // 
            this.actionCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionCb.Enabled = false;
            this.actionCb.Location = new System.Drawing.Point(158, 169);
            this.actionCb.myValue = commonClass.AppTypes.TradeActions.None;
            this.actionCb.Name = "actionCb";
            this.actionCb.SelectedValue = ((byte)(0));
            this.actionCb.Size = new System.Drawing.Size(129, 24);
            this.actionCb.TabIndex = 31;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(23, 151);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(40, 16);
            this.codeLbl.TabIndex = 164;
            this.codeLbl.Text = "Code";
            // 
            // codeEd
            // 
            this.codeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEd.isToUpperCase = false;
            this.codeEd.Location = new System.Drawing.Point(21, 169);
            this.codeEd.Name = "codeEd";
            this.codeEd.ReadOnly = true;
            this.codeEd.Size = new System.Drawing.Size(137, 24);
            this.codeEd.TabIndex = 30;
            // 
            // portfolioLbl
            // 
            this.portfolioLbl.AutoSize = true;
            this.portfolioLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioLbl.Location = new System.Drawing.Point(22, 200);
            this.portfolioLbl.Name = "portfolioLbl";
            this.portfolioLbl.Size = new System.Drawing.Size(63, 16);
            this.portfolioLbl.TabIndex = 166;
            this.portfolioLbl.Text = "Portfolio";
            // 
            // portfolioCb
            // 
            this.portfolioCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.portfolioCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portfolioCb.Enabled = false;
            this.portfolioCb.Location = new System.Drawing.Point(22, 220);
            this.portfolioCb.myValue = "";
            this.portfolioCb.Name = "portfolioCb";
            this.portfolioCb.Size = new System.Drawing.Size(347, 24);
            this.portfolioCb.TabIndex = 40;
            // 
            // timeScaleCb
            // 
            this.timeScaleCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeScaleCb.Enabled = false;
            this.timeScaleCb.FormattingEnabled = true;
            this.timeScaleCb.Location = new System.Drawing.Point(302, 275);
            this.timeScaleCb.Name = "timeScaleCb";
            this.timeScaleCb.SelectedValue = "RT";
            this.timeScaleCb.Size = new System.Drawing.Size(69, 24);
            this.timeScaleCb.TabIndex = 51;
            // 
            // tradeAlertEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(390, 450);
            this.Controls.Add(this.tooolBarPnl);
            this.Controls.Add(this.timeScaleCb);
            this.Controls.Add(this.portfolioLbl);
            this.Controls.Add(this.portfolioCb);
            this.Controls.Add(this.statusCb);
            this.Controls.Add(this.codeEd);
            this.Controls.Add(this.actionCb);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.alertCodeEd);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.informationLbl);
            this.Controls.Add(this.actionLbl);
            this.Controls.Add(this.informationEd);
            this.Controls.Add(this.strategyLbl);
            this.Controls.Add(this.strategyCb);
            this.Controls.Add(this.subjectLbl);
            this.Controls.Add(this.subjectEd);
            this.Controls.Add(this.onDateLbl);
            this.Controls.Add(this.onDateEd);
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
            this.Controls.SetChildIndex(this.onDateEd, 0);
            this.Controls.SetChildIndex(this.onDateLbl, 0);
            this.Controls.SetChildIndex(this.subjectEd, 0);
            this.Controls.SetChildIndex(this.subjectLbl, 0);
            this.Controls.SetChildIndex(this.strategyCb, 0);
            this.Controls.SetChildIndex(this.strategyLbl, 0);
            this.Controls.SetChildIndex(this.informationEd, 0);
            this.Controls.SetChildIndex(this.actionLbl, 0);
            this.Controls.SetChildIndex(this.informationLbl, 0);
            this.Controls.SetChildIndex(this.statusLbl, 0);
            this.Controls.SetChildIndex(this.alertCodeEd, 0);
            this.Controls.SetChildIndex(this.codeLbl, 0);
            this.Controls.SetChildIndex(this.actionCb, 0);
            this.Controls.SetChildIndex(this.codeEd, 0);
            this.Controls.SetChildIndex(this.statusCb, 0);
            this.Controls.SetChildIndex(this.portfolioCb, 0);
            this.Controls.SetChildIndex(this.portfolioLbl, 0);
            this.Controls.SetChildIndex(this.timeScaleCb, 0);
            this.Controls.SetChildIndex(this.tooolBarPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).EndInit();
            this.dataNavigator.ResumeLayout(false);
            this.dataNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertSource)).EndInit();
            this.tooolBarPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        protected baseClass.controls.baseButton orderBtn;
        protected baseClass.controls.baseButton disableAlertBtn;
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
        protected common.controls.baseLabel actionLbl;
        protected baseClass.controls.cbTradeAlertStatus statusCb;
        protected common.controls.baseTextBox alertCodeEd;
        protected common.controls.baseLabel informationLbl;
        protected common.controls.baseTextBox informationEd;
        protected common.controls.baseLabel strategyLbl;
        protected baseClass.controls.cbStrategy strategyCb;
        protected common.controls.baseLabel subjectLbl;
        protected common.controls.baseTextBox subjectEd;
        protected common.controls.baseLabel statusLbl;
        protected common.controls.baseLabel onDateLbl;
        protected common.controls.baseDate onDateEd;
        protected baseClass.controls.cbTradeAction actionCb;
        protected common.controls.baseLabel codeLbl;
        protected common.controls.baseTextBox codeEd;
        protected common.controls.basePanel tooolBarPnl;
        protected common.controls.baseLabel portfolioLbl;
        protected baseClass.controls.cbWatchList portfolioCb;
        protected baseClass.controls.baseButton enableAlertBtn;
        protected baseClass.controls.cbTimeScale timeScaleCb;
        protected System.Windows.Forms.BindingSource alertSource;

    }
}