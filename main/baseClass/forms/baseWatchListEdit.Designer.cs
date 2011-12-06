namespace baseClass.forms
{
    partial class baseWatchListEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseWatchListEdit));
            this.portfolioSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockCodeSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.dataNavigatorCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.xpPanelGroup_Info = new UIComponents.XPPanelGroup();
            this.xpPanel_options = new UIComponents.XPPanel(452);
            this.interestedStockClb = new baseClass.controls.stockCodeList();
            this.interestedStrategy = new baseClass.controls.porfolioStrategy();
            this.interestedBizSectorLbl = new baseClass.controls.baseLabel();
            this.interestedBizSectorClb = new baseClass.controls.subSectorList();
            this.interestedStockLbl = new baseClass.controls.baseLabel();
            this.xpPanel_xxInvestment = new UIComponents.XPPanel(142);
            this.capitalUnitLbl = new baseClass.controls.baseLabel();
            this.stockPercLbl = new baseClass.controls.baseLabel();
            this.capitalAmtLbl = new baseClass.controls.baseLabel();
            this.stockAccumulatePercEd = new common.control.numberTextBox();
            this.cashAmtEd = new common.control.numberTextBox();
            this.maxBuyAmtPercEd = new common.control.numberTextBox();
            this.stockReducePercLbl = new baseClass.controls.baseLabel();
            this.usedAmtLbl = new baseClass.controls.baseLabel();
            this.cashAmtLbl = new baseClass.controls.baseLabel();
            this.maxBuyAmtPercLbl = new baseClass.controls.baseLabel();
            this.stockReducePercEd = new common.control.numberTextBox();
            this.usedAmtEd = new common.control.numberTextBox();
            this.capitalAmtEd = new common.control.numberTextBox();
            this.stockAccumulatePercLbl = new baseClass.controls.baseLabel();
            this.xpPane_generalInfo = new UIComponents.XPPanel(152);
            this.descriptionEd = new common.control.baseTextBox();
            this.codeLbl = new baseClass.controls.baseLabel();
            this.nameLbl = new baseClass.controls.baseLabel();
            this.codeEd = new common.control.baseTextBox();
            this.nameEd = new common.control.baseTextBox();
            this.descriptionLbl = new baseClass.controls.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).BeginInit();
            this.dataNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).BeginInit();
            this.xpPanelGroup_Info.SuspendLayout();
            this.xpPanel_options.SuspendLayout();
            this.xpPanel_xxInvestment.SuspendLayout();
            this.xpPane_generalInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(487, 7);
            this.exitBtn.Size = new System.Drawing.Size(97, 39);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(99, 7);
            this.saveBtn.Size = new System.Drawing.Size(97, 39);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(196, 7);
            this.deleteBtn.Size = new System.Drawing.Size(97, 39);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(293, 7);
            this.editBtn.Size = new System.Drawing.Size(97, 39);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(2, 7);
            this.addNewBtn.Size = new System.Drawing.Size(97, 39);
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
            this.reloadBtn.Location = new System.Drawing.Point(390, 7);
            this.reloadBtn.Size = new System.Drawing.Size(97, 39);
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
            // stockCodeSource
            // 
            this.stockCodeSource.DataMember = "stockCode";
            this.stockCodeSource.DataSource = this.myDataSet;
            // 
            // dataNavigator
            // 
            this.dataNavigator.AddNewItem = null;
            this.dataNavigator.BackColor = System.Drawing.SystemColors.Control;
            this.dataNavigator.BindingSource = this.portfolioSource;
            this.dataNavigator.CountItem = this.dataNavigatorCount;
            this.dataNavigator.CountItemFormat = "{0}";
            this.dataNavigator.DeleteItem = null;
            this.dataNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.dataNavigatorCount,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5});
            this.dataNavigator.Location = new System.Drawing.Point(0, 690);
            this.dataNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.dataNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.dataNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.dataNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.dataNavigator.Name = "dataNavigator";
            this.dataNavigator.PositionItem = this.bindingNavigatorPositionItem1;
            this.dataNavigator.Size = new System.Drawing.Size(585, 25);
            this.dataNavigator.TabIndex = 359;
            this.dataNavigator.Text = "bindingNavigator1";
            // 
            // dataNavigatorCount
            // 
            this.dataNavigatorCount.Name = "dataNavigatorCount";
            this.dataNavigatorCount.Size = new System.Drawing.Size(23, 22);
            this.dataNavigatorCount.Text = "{0}";
            this.dataNavigatorCount.ToolTipText = "Total number of items";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(170, 22);
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
            this.xpPanelGroup_Info.Controls.Add(this.xpPanel_options);
            this.xpPanelGroup_Info.Controls.Add(this.xpPanel_xxInvestment);
            this.xpPanelGroup_Info.Controls.Add(this.xpPane_generalInfo);
            this.xpPanelGroup_Info.Location = new System.Drawing.Point(1, 47);
            this.xpPanelGroup_Info.Name = "xpPanelGroup_Info";
            this.xpPanelGroup_Info.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpPanelGroup_Info.PanelGradient")));
            this.xpPanelGroup_Info.PanelSpacing = 0;
            this.xpPanelGroup_Info.Size = new System.Drawing.Size(585, 639);
            this.xpPanelGroup_Info.TabIndex = 360;
            // 
            // xpPanel_options
            // 
            this.xpPanel_options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_options.AnimationRate = 0;
            this.xpPanel_options.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_options.Caption = "Thông số";
            this.xpPanel_options.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_options.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_options.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_options.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_options.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_options.Controls.Add(this.interestedStockClb);
            this.xpPanel_options.Controls.Add(this.interestedStrategy);
            this.xpPanel_options.Controls.Add(this.interestedBizSectorLbl);
            this.xpPanel_options.Controls.Add(this.interestedBizSectorClb);
            this.xpPanel_options.Controls.Add(this.interestedStockLbl);
            this.xpPanel_options.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_options.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_options.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_options.ImageItems.ImageSet = null;
            this.xpPanel_options.ImeMode = System.Windows.Forms.ImeMode.On;
            this.xpPanel_options.Location = new System.Drawing.Point(0, 294);
            this.xpPanel_options.Name = "xpPanel_options";
            this.xpPanel_options.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_options.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_options.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_options.Size = new System.Drawing.Size(568, 452);
            this.xpPanel_options.TabIndex = 8;
            this.xpPanel_options.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_options.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_options.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_options.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // interestedStockClb
            // 
            this.interestedStockClb.DataBindings.Add(new System.Windows.Forms.Binding("myItemString", this.portfolioSource, "interestedStock", true));
            this.interestedStockClb.Enabled = false;
            this.interestedStockClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestedStockClb.Location = new System.Drawing.Point(29, 147);
            this.interestedStockClb.Margin = new System.Windows.Forms.Padding(2);
            this.interestedStockClb.myItemString = "";
            this.interestedStockClb.Name = "interestedStockClb";
            this.interestedStockClb.Size = new System.Drawing.Size(532, 68);
            this.interestedStockClb.TabIndex = 20;
            // 
            // interestedStrategy
            // 
            this.interestedStrategy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.interestedStrategy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestedStrategy.Location = new System.Drawing.Point(29, 217);
            this.interestedStrategy.Margin = new System.Windows.Forms.Padding(4);
            this.interestedStrategy.Name = "interestedStrategy";
            this.interestedStrategy.Size = new System.Drawing.Size(535, 225);
            this.interestedStrategy.TabIndex = 21;
            // 
            // interestedBizSectorLbl
            // 
            this.interestedBizSectorLbl.AutoSize = true;
            this.interestedBizSectorLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestedBizSectorLbl.Location = new System.Drawing.Point(29, 37);
            this.interestedBizSectorLbl.Name = "interestedBizSectorLbl";
            this.interestedBizSectorLbl.Size = new System.Drawing.Size(132, 16);
            this.interestedBizSectorLbl.TabIndex = 345;
            this.interestedBizSectorLbl.Text = "Lãnh vực quan tâm";
            // 
            // interestedBizSectorClb
            // 
            this.interestedBizSectorClb.DataBindings.Add(new System.Windows.Forms.Binding("myItemString", this.portfolioSource, "interestedSector", true));
            this.interestedBizSectorClb.Enabled = false;
            this.interestedBizSectorClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestedBizSectorClb.Location = new System.Drawing.Point(29, 55);
            this.interestedBizSectorClb.Margin = new System.Windows.Forms.Padding(2);
            this.interestedBizSectorClb.myItemString = "";
            this.interestedBizSectorClb.Name = "interestedBizSectorClb";
            this.interestedBizSectorClb.Size = new System.Drawing.Size(535, 68);
            this.interestedBizSectorClb.TabIndex = 11;
            // 
            // interestedStockLbl
            // 
            this.interestedStockLbl.AutoSize = true;
            this.interestedStockLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestedStockLbl.Location = new System.Drawing.Point(29, 128);
            this.interestedStockLbl.Name = "interestedStockLbl";
            this.interestedStockLbl.Size = new System.Drawing.Size(128, 16);
            this.interestedStockLbl.TabIndex = 344;
            this.interestedStockLbl.Text = "Cổ phiếu quan tâm";
            // 
            // xpPanel_xxInvestment
            // 
            this.xpPanel_xxInvestment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_xxInvestment.AnimationRate = 0;
            this.xpPanel_xxInvestment.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_xxInvestment.Caption = "Đầu tư";
            this.xpPanel_xxInvestment.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_xxInvestment.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_xxInvestment.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_xxInvestment.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_xxInvestment.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_xxInvestment.Controls.Add(this.capitalUnitLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.stockPercLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.capitalAmtLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.stockAccumulatePercEd);
            this.xpPanel_xxInvestment.Controls.Add(this.cashAmtEd);
            this.xpPanel_xxInvestment.Controls.Add(this.maxBuyAmtPercEd);
            this.xpPanel_xxInvestment.Controls.Add(this.stockReducePercLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.usedAmtLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.cashAmtLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.maxBuyAmtPercLbl);
            this.xpPanel_xxInvestment.Controls.Add(this.stockReducePercEd);
            this.xpPanel_xxInvestment.Controls.Add(this.usedAmtEd);
            this.xpPanel_xxInvestment.Controls.Add(this.capitalAmtEd);
            this.xpPanel_xxInvestment.Controls.Add(this.stockAccumulatePercLbl);
            this.xpPanel_xxInvestment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_xxInvestment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_xxInvestment.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_xxInvestment.ImageItems.ImageSet = null;
            this.xpPanel_xxInvestment.Location = new System.Drawing.Point(0, 152);
            this.xpPanel_xxInvestment.Name = "xpPanel_xxInvestment";
            this.xpPanel_xxInvestment.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_xxInvestment.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_xxInvestment.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_xxInvestment.Size = new System.Drawing.Size(568, 142);
            this.xpPanel_xxInvestment.TabIndex = 7;
            this.xpPanel_xxInvestment.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_xxInvestment.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_xxInvestment.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_xxInvestment.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // capitalUnitLbl
            // 
            this.capitalUnitLbl.AutoSize = true;
            this.capitalUnitLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalUnitLbl.Location = new System.Drawing.Point(511, 62);
            this.capitalUnitLbl.Name = "capitalUnitLbl";
            this.capitalUnitLbl.Size = new System.Drawing.Size(36, 16);
            this.capitalUnitLbl.TabIndex = 343;
            this.capitalUnitLbl.Text = "????";
            // 
            // stockPercLbl
            // 
            this.stockPercLbl.AutoSize = true;
            this.stockPercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockPercLbl.Location = new System.Drawing.Point(349, 115);
            this.stockPercLbl.Name = "stockPercLbl";
            this.stockPercLbl.Size = new System.Drawing.Size(22, 16);
            this.stockPercLbl.TabIndex = 363;
            this.stockPercLbl.Text = "%";
            // 
            // capitalAmtLbl
            // 
            this.capitalAmtLbl.AutoSize = true;
            this.capitalAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalAmtLbl.Location = new System.Drawing.Point(26, 41);
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
            this.stockAccumulatePercEd.Location = new System.Drawing.Point(132, 111);
            this.stockAccumulatePercEd.myFormat = "###";
            this.stockAccumulatePercEd.Name = "stockAccumulatePercEd";
            this.stockAccumulatePercEd.Size = new System.Drawing.Size(106, 24);
            this.stockAccumulatePercEd.TabIndex = 11;
            this.stockAccumulatePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stockAccumulatePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.stockAccumulatePercEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // cashAmtEd
            // 
            this.cashAmtEd.BackColor = System.Drawing.SystemColors.Window;
            this.cashAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.cashAmtEd.Location = new System.Drawing.Point(352, 60);
            this.cashAmtEd.myFormat = "###,###,###,###,###";
            this.cashAmtEd.Name = "cashAmtEd";
            this.cashAmtEd.ReadOnly = true;
            this.cashAmtEd.Size = new System.Drawing.Size(163, 24);
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
            // maxBuyAmtPercEd
            // 
            this.maxBuyAmtPercEd.BackColor = System.Drawing.SystemColors.Window;
            this.maxBuyAmtPercEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "maxBuyAmtPerc", true));
            this.maxBuyAmtPercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxBuyAmtPercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.maxBuyAmtPercEd.Location = new System.Drawing.Point(26, 111);
            this.maxBuyAmtPercEd.myFormat = "###";
            this.maxBuyAmtPercEd.Name = "maxBuyAmtPercEd";
            this.maxBuyAmtPercEd.ReadOnly = true;
            this.maxBuyAmtPercEd.Size = new System.Drawing.Size(106, 24);
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
            this.stockReducePercLbl.Location = new System.Drawing.Point(240, 90);
            this.stockReducePercLbl.Name = "stockReducePercLbl";
            this.stockReducePercLbl.Size = new System.Drawing.Size(65, 16);
            this.stockReducePercLbl.TabIndex = 361;
            this.stockReducePercLbl.Text = "K/L giảm";
            // 
            // usedAmtLbl
            // 
            this.usedAmtLbl.AutoSize = true;
            this.usedAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usedAmtLbl.Location = new System.Drawing.Point(189, 40);
            this.usedAmtLbl.Name = "usedAmtLbl";
            this.usedAmtLbl.Size = new System.Drawing.Size(82, 16);
            this.usedAmtLbl.TabIndex = 349;
            this.usedAmtLbl.Text = "Đã sử dụng";
            // 
            // cashAmtLbl
            // 
            this.cashAmtLbl.AutoSize = true;
            this.cashAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashAmtLbl.Location = new System.Drawing.Point(348, 40);
            this.cashAmtLbl.Name = "cashAmtLbl";
            this.cashAmtLbl.Size = new System.Drawing.Size(63, 16);
            this.cashAmtLbl.TabIndex = 356;
            this.cashAmtLbl.Text = "Tiền mặt";
            // 
            // maxBuyAmtPercLbl
            // 
            this.maxBuyAmtPercLbl.AutoSize = true;
            this.maxBuyAmtPercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxBuyAmtPercLbl.Location = new System.Drawing.Point(26, 90);
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
            this.stockReducePercEd.Location = new System.Drawing.Point(238, 111);
            this.stockReducePercEd.myFormat = "###";
            this.stockReducePercEd.Name = "stockReducePercEd";
            this.stockReducePercEd.ReadOnly = true;
            this.stockReducePercEd.Size = new System.Drawing.Size(106, 24);
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
            // usedAmtEd
            // 
            this.usedAmtEd.BackColor = System.Drawing.SystemColors.Window;
            this.usedAmtEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "usedCapAmt", true));
            this.usedAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usedAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.usedAmtEd.Location = new System.Drawing.Point(189, 60);
            this.usedAmtEd.myFormat = "###,###,###,###,###";
            this.usedAmtEd.Name = "usedAmtEd";
            this.usedAmtEd.ReadOnly = true;
            this.usedAmtEd.Size = new System.Drawing.Size(163, 24);
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
            // capitalAmtEd
            // 
            this.capitalAmtEd.BackColor = System.Drawing.SystemColors.Window;
            this.capitalAmtEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.portfolioSource, "startCapAmt", true));
            this.capitalAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.capitalAmtEd.Location = new System.Drawing.Point(26, 60);
            this.capitalAmtEd.myFormat = "###,###,###,###,###";
            this.capitalAmtEd.Name = "capitalAmtEd";
            this.capitalAmtEd.Size = new System.Drawing.Size(163, 24);
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
            this.stockAccumulatePercLbl.Location = new System.Drawing.Point(131, 89);
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
            this.xpPane_generalInfo.Size = new System.Drawing.Size(568, 152);
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
            this.descriptionEd.Location = new System.Drawing.Point(29, 102);
            this.descriptionEd.Multiline = true;
            this.descriptionEd.Name = "descriptionEd";
            this.descriptionEd.Size = new System.Drawing.Size(518, 41);
            this.descriptionEd.TabIndex = 3;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(26, 37);
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
            this.nameLbl.Location = new System.Drawing.Point(136, 37);
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
            this.codeEd.Location = new System.Drawing.Point(29, 56);
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
            this.nameEd.Location = new System.Drawing.Point(137, 56);
            this.nameEd.Name = "nameEd";
            this.nameEd.Size = new System.Drawing.Size(410, 24);
            this.nameEd.TabIndex = 1;
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.Location = new System.Drawing.Point(29, 83);
            this.descriptionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(45, 16);
            this.descriptionLbl.TabIndex = 351;
            this.descriptionLbl.Text = "Mô tả";
            // 
            // baseWatchListEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 738);
            this.Controls.Add(this.xpPanelGroup_Info);
            this.Controls.Add(this.dataNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "baseWatchListEdit";
            this.Text = "Cong ty";
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.dataNavigator, 0);
            this.Controls.SetChildIndex(this.xpPanelGroup_Info, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataNavigator)).EndInit();
            this.dataNavigator.ResumeLayout(false);
            this.dataNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).EndInit();
            this.xpPanelGroup_Info.ResumeLayout(false);
            this.xpPanel_options.ResumeLayout(false);
            this.xpPanel_options.PerformLayout();
            this.xpPanel_xxInvestment.ResumeLayout(false);
            this.xpPanel_xxInvestment.PerformLayout();
            this.xpPane_generalInfo.ResumeLayout(false);
            this.xpPane_generalInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.BindingSource portfolioSource;
        protected System.Windows.Forms.BindingSource stockCodeSource;
        protected System.Windows.Forms.BindingNavigator dataNavigator;
        protected System.Windows.Forms.ToolStripLabel dataNavigatorCount;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        protected UIComponents.XPPanel xpPanel_options;
        protected baseClass.controls.stockCodeList interestedStockClb;
        protected baseClass.controls.porfolioStrategy interestedStrategy;
        protected baseClass.controls.baseLabel interestedBizSectorLbl;
        protected baseClass.controls.subSectorList interestedBizSectorClb;
        protected baseClass.controls.baseLabel interestedStockLbl;
        protected UIComponents.XPPanel xpPanel_xxInvestment;
        protected baseClass.controls.baseLabel capitalUnitLbl;
        protected baseClass.controls.baseLabel stockPercLbl;
        protected baseClass.controls.baseLabel capitalAmtLbl;
        protected common.control.numberTextBox stockAccumulatePercEd;
        protected common.control.numberTextBox cashAmtEd;
        protected common.control.numberTextBox maxBuyAmtPercEd;
        protected baseClass.controls.baseLabel stockReducePercLbl;
        protected baseClass.controls.baseLabel usedAmtLbl;
        protected baseClass.controls.baseLabel cashAmtLbl;
        protected baseClass.controls.baseLabel maxBuyAmtPercLbl;
        protected common.control.numberTextBox stockReducePercEd;
        protected common.control.numberTextBox usedAmtEd;
        protected common.control.numberTextBox capitalAmtEd;
        protected baseClass.controls.baseLabel stockAccumulatePercLbl;
        protected UIComponents.XPPanel xpPane_generalInfo;
        protected common.control.baseTextBox descriptionEd;
        protected baseClass.controls.baseLabel codeLbl;
        protected baseClass.controls.baseLabel nameLbl;
        protected common.control.baseTextBox codeEd;
        protected common.control.baseTextBox nameEd;
        protected baseClass.controls.baseLabel descriptionLbl;
        protected UIComponents.XPPanelGroup xpPanelGroup_Info;


    }
}