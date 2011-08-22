namespace baseClass.forms
{
    partial class baseScreening
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseScreening));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.testResultDataGrid = new common.control.baseDataGridView();
            this.myDataSet = new data.baseDS();
            this.dateRangeEd = new baseClass.controls.chartTiming();
            this.myTmpDS = new data.tmpDS();
            this.mainToolbarPnl = new System.Windows.Forms.Panel();
            this.exportTestResultBtn = new baseClass.controls.baseButton();
            this.chartBtn = new baseClass.controls.baseButton();
            this.fullScreenBtn = new baseClass.controls.baseButton();
            this.closeBtn = new baseClass.controls.baseButton();
            this.okBtn = new baseClass.controls.baseButton();
            this.optionBtn = new baseClass.controls.baseButton();
            this.dataPnl = new System.Windows.Forms.Panel();
            this.strategyLbl = new baseClass.controls.baseLabel();
            this.strategyClb = new baseClass.controls.strategySelect();
            this.xpPanelGroup_Info = new UIComponents.XPPanelGroup();
            this.xpPanel_Advance = new UIComponents.XPPanel();
            this.subSectorSelect = new baseClass.controls.subSectorSelect();
            this.subSectorLbl = new baseClass.controls.baseLabel();
            this.xpPane_generalInfo = new UIComponents.XPPanel();
            this.scrCriteriaGrid = new common.control.baseDataGridView();
            this.scrTypeCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.scrMinCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scrMaxCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.testResultDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            this.mainToolbarPnl.SuspendLayout();
            this.dataPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).BeginInit();
            this.xpPanelGroup_Info.SuspendLayout();
            this.xpPanel_Advance.SuspendLayout();
            this.xpPane_generalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrCriteriaGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1055, 7);
            this.TitleLbl.Size = new System.Drawing.Size(251, 24);
            this.TitleLbl.Text = "TÌM KIẾM";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.xls";
            this.saveFileDialog.Filter = "(*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // testResultDataGrid
            // 
            this.testResultDataGrid.AllowUserToAddRows = false;
            this.testResultDataGrid.AllowUserToDeleteRows = false;
            this.testResultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testResultDataGrid.DisableReadOnlyColumn = true;
            this.testResultDataGrid.Location = new System.Drawing.Point(0, 0);
            this.testResultDataGrid.Name = "testResultDataGrid";
            this.testResultDataGrid.ReadOnly = true;
            this.testResultDataGrid.Size = new System.Drawing.Size(378, 342);
            this.testResultDataGrid.TabIndex = 309;
            this.testResultDataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentDoubleClick);
            this.testResultDataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dateRangeEd
            // 
            this.dateRangeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRangeEd.Location = new System.Drawing.Point(21, 55);
            this.dateRangeEd.myTimeRange = application.myTypes.timeRanges.None;
            this.dateRangeEd.myTimeScale = application.myTypes.timeScales.RealTime;
            this.dateRangeEd.Name = "dateRangeEd";
            this.dateRangeEd.Size = new System.Drawing.Size(365, 24);
            this.dateRangeEd.TabIndex = 1;
            // 
            // myTmpDS
            // 
            this.myTmpDS.DataSetName = "tmpDS";
            this.myTmpDS.EnforceConstraints = false;
            this.myTmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mainToolbarPnl
            // 
            this.mainToolbarPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainToolbarPnl.Controls.Add(this.exportTestResultBtn);
            this.mainToolbarPnl.Controls.Add(this.chartBtn);
            this.mainToolbarPnl.Controls.Add(this.fullScreenBtn);
            this.mainToolbarPnl.Controls.Add(this.closeBtn);
            this.mainToolbarPnl.Controls.Add(this.okBtn);
            this.mainToolbarPnl.Controls.Add(this.optionBtn);
            this.mainToolbarPnl.Location = new System.Drawing.Point(0, 0);
            this.mainToolbarPnl.Name = "mainToolbarPnl";
            this.mainToolbarPnl.Size = new System.Drawing.Size(444, 33);
            this.mainToolbarPnl.TabIndex = 0;
            // 
            // exportTestResultBtn
            // 
            this.exportTestResultBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportTestResultBtn.Image = global::baseClass.Properties.Resources.excel;
            this.exportTestResultBtn.Location = new System.Drawing.Point(135, 3);
            this.exportTestResultBtn.Name = "exportTestResultBtn";
            this.exportTestResultBtn.Size = new System.Drawing.Size(29, 24);
            this.exportTestResultBtn.TabIndex = 4;
            this.myToolTip.SetToolTip(this.exportTestResultBtn, "Xuất kết quả ra Excel");
            this.exportTestResultBtn.UseVisualStyleBackColor = true;
            this.exportTestResultBtn.Click += new System.EventHandler(this.exportTestResultBtn_Click);
            // 
            // chartBtn
            // 
            this.chartBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartBtn.Image = global::baseClass.Properties.Resources.exrate;
            this.chartBtn.Location = new System.Drawing.Point(106, 3);
            this.chartBtn.Name = "chartBtn";
            this.chartBtn.Size = new System.Drawing.Size(29, 24);
            this.chartBtn.TabIndex = 3;
            this.myToolTip.SetToolTip(this.chartBtn, "Biểu đồ lợi nhuận");
            this.chartBtn.UseVisualStyleBackColor = true;
            // 
            // fullScreenBtn
            // 
            this.fullScreenBtn.Enabled = false;
            this.fullScreenBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullScreenBtn.Image = global::baseClass.Properties.Resources.fullScreen;
            this.fullScreenBtn.Location = new System.Drawing.Point(77, 3);
            this.fullScreenBtn.Name = "fullScreenBtn";
            this.fullScreenBtn.Size = new System.Drawing.Size(29, 24);
            this.fullScreenBtn.TabIndex = 6;
            this.myToolTip.SetToolTip(this.fullScreenBtn, "Tòan màn hình");
            this.fullScreenBtn.UseVisualStyleBackColor = true;
            this.fullScreenBtn.Click += new System.EventHandler(this.fullScreenBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeBtn.Location = new System.Drawing.Point(164, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(29, 24);
            this.closeBtn.TabIndex = 10;
            this.myToolTip.SetToolTip(this.closeBtn, "Kết thúc");
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Visible = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.okBtn.FlatAppearance.BorderSize = 0;
            this.okBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Image = global::baseClass.Properties.Resources.run;
            this.okBtn.Location = new System.Drawing.Point(19, 3);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(29, 24);
            this.okBtn.TabIndex = 1;
            this.myToolTip.SetToolTip(this.okBtn, "Thực hiện");
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // optionBtn
            // 
            this.optionBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionBtn.Image = global::baseClass.Properties.Resources.configure;
            this.optionBtn.Location = new System.Drawing.Point(48, 3);
            this.optionBtn.Name = "optionBtn";
            this.optionBtn.Size = new System.Drawing.Size(29, 24);
            this.optionBtn.TabIndex = 4;
            this.myToolTip.SetToolTip(this.optionBtn, "Tùy biến");
            this.optionBtn.UseVisualStyleBackColor = true;
            this.optionBtn.Click += new System.EventHandler(this.optionBtn_Click);
            // 
            // dataPnl
            // 
            this.dataPnl.Controls.Add(this.testResultDataGrid);
            this.dataPnl.Location = new System.Drawing.Point(594, 46);
            this.dataPnl.Name = "dataPnl";
            this.dataPnl.Size = new System.Drawing.Size(337, 650);
            this.dataPnl.TabIndex = 314;
            // 
            // strategyLbl
            // 
            this.strategyLbl.AutoSize = true;
            this.strategyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.strategyLbl.Location = new System.Drawing.Point(23, 36);
            this.strategyLbl.Name = "strategyLbl";
            this.strategyLbl.Size = new System.Drawing.Size(74, 16);
            this.strategyLbl.TabIndex = 315;
            this.strategyLbl.Text = "Chiến lược";
            // 
            // strategyClb
            // 
            this.strategyClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyClb.Location = new System.Drawing.Point(23, 80);
            this.strategyClb.Margin = new System.Windows.Forms.Padding(2);
            this.strategyClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("strategyClb.myCheckedValues")));
            this.strategyClb.myItemString = "";
            this.strategyClb.Name = "strategyClb";
            this.strategyClb.Size = new System.Drawing.Size(400, 144);
            this.strategyClb.TabIndex = 2;
            // 
            // xpPanelGroup_Info
            // 
            this.xpPanelGroup_Info.AutoScroll = true;
            this.xpPanelGroup_Info.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelGroup_Info.BorderMargin = new System.Drawing.Size(0, 0);
            this.xpPanelGroup_Info.Controls.Add(this.xpPanel_Advance);
            this.xpPanelGroup_Info.Controls.Add(this.xpPane_generalInfo);
            this.xpPanelGroup_Info.Location = new System.Drawing.Point(0, 35);
            this.xpPanelGroup_Info.Name = "xpPanelGroup_Info";
            this.xpPanelGroup_Info.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpPanelGroup_Info.PanelGradient")));
            this.xpPanelGroup_Info.PanelSpacing = 2;
            this.xpPanelGroup_Info.Size = new System.Drawing.Size(444, 606);
            this.xpPanelGroup_Info.TabIndex = 360;
            // 
            // xpPanel_Advance
            // 
            this.xpPanel_Advance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_Advance.AnimationRate = 0;
            this.xpPanel_Advance.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_Advance.Caption = "Khác";
            this.xpPanel_Advance.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_Advance.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Advance.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Advance.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Advance.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_Advance.Controls.Add(this.subSectorSelect);
            this.xpPanel_Advance.Controls.Add(this.subSectorLbl);
            this.xpPanel_Advance.Controls.Add(this.strategyClb);
            this.xpPanel_Advance.Controls.Add(this.dateRangeEd);
            this.xpPanel_Advance.Controls.Add(this.strategyLbl);
            this.xpPanel_Advance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_Advance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_Advance.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_Advance.ImageItems.ImageSet = null;
            this.xpPanel_Advance.Location = new System.Drawing.Point(0, 181);
            this.xpPanel_Advance.Name = "xpPanel_Advance";
            this.xpPanel_Advance.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_Advance.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_Advance.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Advance.Size = new System.Drawing.Size(444, 425);
            this.xpPanel_Advance.TabIndex = 2;
            this.xpPanel_Advance.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_Advance.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_Advance.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_Advance.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // subSectorSelect
            // 
            this.subSectorSelect.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subSectorSelect.Location = new System.Drawing.Point(21, 246);
            this.subSectorSelect.Margin = new System.Windows.Forms.Padding(2);
            this.subSectorSelect.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("subSectorSelect.myCheckedValues")));
            this.subSectorSelect.myItemString = "";
            this.subSectorSelect.Name = "subSectorSelect";
            this.subSectorSelect.ShowCheckedOnly = false;
            this.subSectorSelect.Size = new System.Drawing.Size(402, 174);
            this.subSectorSelect.TabIndex = 3;
            // 
            // subSectorLbl
            // 
            this.subSectorLbl.AutoSize = true;
            this.subSectorLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subSectorLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.subSectorLbl.Location = new System.Drawing.Point(23, 228);
            this.subSectorLbl.Name = "subSectorLbl";
            this.subSectorLbl.Size = new System.Drawing.Size(48, 16);
            this.subSectorLbl.TabIndex = 316;
            this.subSectorLbl.Text = "Ngành";
            // 
            // xpPane_generalInfo
            // 
            this.xpPane_generalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPane_generalInfo.AnimationRate = 0;
            this.xpPane_generalInfo.BackColor = System.Drawing.Color.Transparent;
            this.xpPane_generalInfo.Caption = "Điều kiện";
            this.xpPane_generalInfo.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPane_generalInfo.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPane_generalInfo.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPane_generalInfo.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPane_generalInfo.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPane_generalInfo.Controls.Add(this.scrCriteriaGrid);
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
            this.xpPane_generalInfo.Size = new System.Drawing.Size(444, 179);
            this.xpPane_generalInfo.TabIndex = 1;
            this.xpPane_generalInfo.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPane_generalInfo.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPane_generalInfo.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPane_generalInfo.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // scrCriteriaGrid
            // 
            this.scrCriteriaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scrCriteriaGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scrTypeCol,
            this.scrMinCol,
            this.scrMaxCol});
            this.scrCriteriaGrid.DisableReadOnlyColumn = false;
            this.scrCriteriaGrid.Location = new System.Drawing.Point(2, 33);
            this.scrCriteriaGrid.Name = "scrCriteriaGrid";
            this.scrCriteriaGrid.Size = new System.Drawing.Size(442, 142);
            this.scrCriteriaGrid.TabIndex = 0;
            // 
            // scrTypeCol
            // 
            this.scrTypeCol.HeaderText = "Lọai";
            this.scrTypeCol.Name = "scrTypeCol";
            this.scrTypeCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.scrTypeCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.scrTypeCol.Width = 150;
            // 
            // scrMinCol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.scrMinCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.scrMinCol.HeaderText = "Min";
            this.scrMinCol.Name = "scrMinCol";
            // 
            // scrMaxCol
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.scrMaxCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.scrMaxCol.HeaderText = "Max";
            this.scrMaxCol.Name = "scrMaxCol";
            // 
            // baseScreening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(444, 668);
            this.Controls.Add(this.xpPanelGroup_Info);
            this.Controls.Add(this.dataPnl);
            this.Controls.Add(this.mainToolbarPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "baseScreening";
            this.Text = "Loc /  Screening";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResizeEnd += new System.EventHandler(this.baseBackTesting_ResizeEnd);
            this.Controls.SetChildIndex(this.mainToolbarPnl, 0);
            this.Controls.SetChildIndex(this.dataPnl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.xpPanelGroup_Info, 0);
            ((System.ComponentModel.ISupportInitialize)(this.testResultDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            this.mainToolbarPnl.ResumeLayout(false);
            this.dataPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).EndInit();
            this.xpPanelGroup_Info.ResumeLayout(false);
            this.xpPanel_Advance.ResumeLayout(false);
            this.xpPanel_Advance.PerformLayout();
            this.xpPane_generalInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scrCriteriaGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected common.control.baseDataGridView testResultDataGrid;
        protected baseClass.controls.chartTiming dateRangeEd;
        protected data.baseDS myDataSet;
        protected baseClass.controls.baseButton exportTestResultBtn;
        protected baseClass.controls.baseButton chartBtn;
        protected baseClass.controls.baseButton okBtn;
        private data.tmpDS myTmpDS;
        protected baseClass.controls.baseButton optionBtn;
        protected baseClass.controls.baseButton closeBtn;
        protected System.Windows.Forms.Panel mainToolbarPnl;
        protected baseClass.controls.baseButton fullScreenBtn;
        protected System.Windows.Forms.Panel dataPnl;
        protected baseClass.controls.baseLabel strategyLbl;
        protected baseClass.controls.strategySelect strategyClb;
        protected UIComponents.XPPanelGroup xpPanelGroup_Info;
        protected UIComponents.XPPanel xpPanel_Advance;
        protected UIComponents.XPPanel xpPane_generalInfo;
        private common.control.baseDataGridView scrCriteriaGrid;
        protected baseClass.controls.baseLabel subSectorLbl;
        private System.Windows.Forms.DataGridViewComboBoxColumn scrTypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn scrMinCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn scrMaxCol;
        protected baseClass.controls.subSectorSelect subSectorSelect;
    }
}
