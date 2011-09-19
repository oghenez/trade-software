namespace baseClass.forms
{
    partial class watchListEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(watchListEdit));
            this.portfolioSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockCodeSource = new System.Windows.Forms.BindingSource(this.components);
            this.xpPanelGroup_Info = new UIComponents.XPPanelGroup();
            this.xpPanel_options = new UIComponents.XPPanel(400);
            this.interestedStockClb = new baseClass.controls.stockCodeList();
            this.interestedStrategy = new baseClass.controls.watchListStrategy();
            this.interestedBizSectorLbl = new baseClass.controls.baseLabel();
            this.interestedBizSectorClb = new baseClass.controls.subSectorList();
            this.interestedStockLbl = new baseClass.controls.baseLabel();
            this.xpPane_generalInfo = new UIComponents.XPPanel(204);
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
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).BeginInit();
            this.xpPanelGroup_Info.SuspendLayout();
            this.xpPanel_options.SuspendLayout();
            this.xpPane_generalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBox
            // 
            this.toolBox.Size = new System.Drawing.Size(1039, 53);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(427, 7);
            this.exitBtn.Size = new System.Drawing.Size(85, 39);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(87, 7);
            this.saveBtn.Size = new System.Drawing.Size(85, 39);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(172, 7);
            this.deleteBtn.Size = new System.Drawing.Size(85, 39);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(257, 7);
            this.editBtn.Size = new System.Drawing.Size(85, 39);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(2, 7);
            this.addNewBtn.Size = new System.Drawing.Size(85, 39);
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
            this.reloadBtn.Location = new System.Drawing.Point(342, 7);
            this.reloadBtn.Size = new System.Drawing.Size(85, 39);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(805, 7);
            this.printBtn.Visible = false;
            // 
            // unLockBtn
            // 
            this.unLockBtn.Location = new System.Drawing.Point(1026, 328);
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(1026, 287);
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
            this.stockCodeSource.CurrentChanged += new System.EventHandler(this.portfolioSource_CurrentChanged);
            // 
            // xpPanelGroup_Info
            // 
            this.xpPanelGroup_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.xpPanelGroup_Info.AutoScroll = true;
            this.xpPanelGroup_Info.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelGroup_Info.BorderMargin = new System.Drawing.Size(0, 0);
            this.xpPanelGroup_Info.Controls.Add(this.xpPanel_options);
            this.xpPanelGroup_Info.Controls.Add(this.xpPane_generalInfo);
            this.xpPanelGroup_Info.Location = new System.Drawing.Point(0, 50);
            this.xpPanelGroup_Info.Name = "xpPanelGroup_Info";
            this.xpPanelGroup_Info.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpPanelGroup_Info.PanelGradient")));
            this.xpPanelGroup_Info.PanelSpacing = 0;
            this.xpPanelGroup_Info.Size = new System.Drawing.Size(514, 628);
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
            this.xpPanel_options.Location = new System.Drawing.Point(0, 204);
            this.xpPanel_options.Name = "xpPanel_options";
            this.xpPanel_options.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_options.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_options.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_options.Size = new System.Drawing.Size(514, 400);
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
            this.interestedStockClb.Size = new System.Drawing.Size(464, 100);
            this.interestedStockClb.TabIndex = 20;
            // 
            // interestedStrategy
            // 
            this.interestedStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.interestedStrategy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.interestedStrategy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestedStrategy.Location = new System.Drawing.Point(29, 251);
            this.interestedStrategy.Margin = new System.Windows.Forms.Padding(4);
            this.interestedStrategy.Name = "interestedStrategy";
            this.interestedStrategy.Size = new System.Drawing.Size(465, 147);
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
            this.interestedBizSectorClb.Size = new System.Drawing.Size(465, 68);
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
            this.xpPane_generalInfo.Size = new System.Drawing.Size(514, 204);
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
            this.descriptionEd.Location = new System.Drawing.Point(29, 152);
            this.descriptionEd.Multiline = true;
            this.descriptionEd.Name = "descriptionEd";
            this.descriptionEd.Size = new System.Drawing.Size(467, 41);
            this.descriptionEd.TabIndex = 3;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(29, 37);
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
            this.nameLbl.Location = new System.Drawing.Point(29, 87);
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
            this.nameEd.Location = new System.Drawing.Point(29, 106);
            this.nameEd.Name = "nameEd";
            this.nameEd.Size = new System.Drawing.Size(464, 24);
            this.nameEd.TabIndex = 1;
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.Location = new System.Drawing.Point(29, 133);
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
            this.portfolioGrid.Location = new System.Drawing.Point(513, -1);
            this.portfolioGrid.Name = "portfolioGrid";
            this.portfolioGrid.ReadOnly = true;
            this.portfolioGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioGrid.Size = new System.Drawing.Size(364, 679);
            this.portfolioGrid.TabIndex = 362;
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
            // watchListEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(877, 702);
            this.Controls.Add(this.portfolioGrid);
            this.Controls.Add(this.xpPanelGroup_Info);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "watchListEdit";
            this.Text = "Watch List";
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.xpPanelGroup_Info, 0);
            this.Controls.SetChildIndex(this.portfolioGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).EndInit();
            this.xpPanelGroup_Info.ResumeLayout(false);
            this.xpPanel_options.ResumeLayout(false);
            this.xpPanel_options.PerformLayout();
            this.xpPane_generalInfo.ResumeLayout(false);
            this.xpPane_generalInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.BindingSource portfolioSource;
        protected System.Windows.Forms.BindingSource stockCodeSource;
        protected UIComponents.XPPanel xpPanel_options;
        protected baseClass.controls.stockCodeList interestedStockClb;
        protected baseClass.controls.watchListStrategy interestedStrategy;
        protected baseClass.controls.baseLabel interestedBizSectorLbl;
        protected baseClass.controls.subSectorList interestedBizSectorClb;
        protected baseClass.controls.baseLabel interestedStockLbl;
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


    }
}