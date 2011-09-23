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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(screening));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.myTmpDS = new data.tmpDS();
            this.dataPnl = new System.Windows.Forms.Panel();
            this.resultDataGrid = new common.control.baseDataGridView();
            this.xpPanelGroup_Info = new UIComponents.XPPanelGroup();
            this.xpPanel_Advance = new UIComponents.XPPanel(425);
            this.subSectorSelect = new baseClass.controls.subSectorSelect();
            this.subSectorLbl = new baseClass.controls.baseLabel();
            this.strategyClb = new baseClass.controls.strategySelect();
            this.strategyLbl = new baseClass.controls.baseLabel();
            this.dateRangeEd = new baseClass.controls.chartTiming();
            this.xpPane_generalInfo = new UIComponents.XPPanel(179);
            this.scrCriteriaGrid = new common.control.baseDataGridView();
            this.scrTypeCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.scrMinCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scrMaxCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            this.dataPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).BeginInit();
            this.xpPanelGroup_Info.SuspendLayout();
            this.xpPanel_Advance.SuspendLayout();
            this.xpPane_generalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrCriteriaGrid)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(585, 2);
            this.TitleLbl.Size = new System.Drawing.Size(10, 46);
            // 
            // myTmpDS
            // 
            this.myTmpDS.DataSetName = "tmpDS";
            this.myTmpDS.EnforceConstraints = false;
            this.myTmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataPnl
            // 
            this.dataPnl.Controls.Add(this.resultDataGrid);
            this.dataPnl.Location = new System.Drawing.Point(445, 0);
            this.dataPnl.Name = "dataPnl";
            this.dataPnl.Size = new System.Drawing.Size(617, 642);
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
            this.resultDataGrid.Location = new System.Drawing.Point(0, 1);
            this.resultDataGrid.Name = "resultDataGrid";
            this.resultDataGrid.ReadOnly = true;
            this.resultDataGrid.Size = new System.Drawing.Size(596, 638);
            this.resultDataGrid.TabIndex = 309;
            this.resultDataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentDoubleClick);
            this.resultDataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
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
            this.xpPanelGroup_Info.PanelSpacing = 0;
            this.xpPanelGroup_Info.Size = new System.Drawing.Size(444, 606);
            this.xpPanelGroup_Info.TabIndex = 316;
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
            this.xpPanel_Advance.Controls.Add(this.strategyLbl);
            this.xpPanel_Advance.Controls.Add(this.dateRangeEd);
            this.xpPanel_Advance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_Advance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_Advance.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_Advance.ImageItems.ImageSet = null;
            this.xpPanel_Advance.Location = new System.Drawing.Point(0, 179);
            this.xpPanel_Advance.Name = "xpPanel_Advance";
            this.xpPanel_Advance.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_Advance.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_Advance.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Advance.Size = new System.Drawing.Size(444, 425);
            this.xpPanel_Advance.TabIndex = 4;
            this.xpPanel_Advance.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_Advance.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_Advance.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_Advance.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // subSectorSelect
            // 
            this.subSectorSelect.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subSectorSelect.Location = new System.Drawing.Point(21, 247);
            this.subSectorSelect.Margin = new System.Windows.Forms.Padding(2);
            this.subSectorSelect.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("subSectorSelect.myCheckedValues")));
            this.subSectorSelect.myItemString = "";
            this.subSectorSelect.Name = "subSectorSelect";
            this.subSectorSelect.ShowCheckedOnly = false;
            this.subSectorSelect.Size = new System.Drawing.Size(402, 158);
            this.subSectorSelect.TabIndex = 3;
            // 
            // subSectorLbl
            // 
            this.subSectorLbl.AutoSize = true;
            this.subSectorLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subSectorLbl.Location = new System.Drawing.Point(21, 228);
            this.subSectorLbl.Name = "subSectorLbl";
            this.subSectorLbl.Size = new System.Drawing.Size(48, 16);
            this.subSectorLbl.TabIndex = 316;
            this.subSectorLbl.Text = "Ngành";
            // 
            // strategyClb
            // 
            this.strategyClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyClb.Location = new System.Drawing.Point(23, 81);
            this.strategyClb.Margin = new System.Windows.Forms.Padding(2);
            this.strategyClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("strategyClb.myCheckedValues")));
            this.strategyClb.myItemString = "";
            this.strategyClb.Name = "strategyClb";
            this.strategyClb.Size = new System.Drawing.Size(400, 142);
            this.strategyClb.TabIndex = 2;
            // 
            // strategyLbl
            // 
            this.strategyLbl.AutoSize = true;
            this.strategyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyLbl.Location = new System.Drawing.Point(23, 37);
            this.strategyLbl.Name = "strategyLbl";
            this.strategyLbl.Size = new System.Drawing.Size(74, 16);
            this.strategyLbl.TabIndex = 315;
            this.strategyLbl.Text = "Chiến lược";
            // 
            // dateRangeEd
            // 
            this.dateRangeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRangeEd.Location = new System.Drawing.Point(21, 56);
            this.dateRangeEd.Name = "dateRangeEd";
            this.dateRangeEd.Size = new System.Drawing.Size(402, 24);
            this.dateRangeEd.TabIndex = 1;
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
            this.xpPane_generalInfo.TabIndex = 3;
            this.xpPane_generalInfo.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPane_generalInfo.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPane_generalInfo.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPane_generalInfo.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // scrCriteriaGrid
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.scrCriteriaGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.scrCriteriaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scrCriteriaGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scrTypeCol,
            this.scrMinCol,
            this.scrMaxCol});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.scrCriteriaGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.scrCriteriaGrid.DisableReadOnlyColumn = false;
            this.scrCriteriaGrid.Location = new System.Drawing.Point(2, 33);
            this.scrCriteriaGrid.Name = "scrCriteriaGrid";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.scrCriteriaGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.scrMinCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.scrMinCol.HeaderText = "Min";
            this.scrMinCol.Name = "scrMinCol";
            // 
            // scrMaxCol
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.scrMaxCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.scrMaxCol.HeaderText = "Max";
            this.scrMaxCol.Name = "scrMaxCol";
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1041, 24);
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
            // screening
            // 
            this.ClientSize = new System.Drawing.Size(1041, 668);
            this.Controls.Add(this.xpPanelGroup_Info);
            this.Controls.Add(this.dataPnl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "screening";
            this.Text = "Screening";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            this.Controls.SetChildIndex(this.dataPnl, 0);
            this.Controls.SetChildIndex(this.xpPanelGroup_Info, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            this.dataPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).EndInit();
            this.xpPanelGroup_Info.ResumeLayout(false);
            this.xpPanel_Advance.ResumeLayout(false);
            this.xpPanel_Advance.PerformLayout();
            this.xpPane_generalInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scrCriteriaGrid)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private data.tmpDS myTmpDS;
        protected System.Windows.Forms.Panel dataPnl;
        protected common.control.baseDataGridView resultDataGrid;
        protected UIComponents.XPPanel xpPanel_Advance;
        protected baseClass.controls.subSectorSelect subSectorSelect;
        protected baseClass.controls.baseLabel subSectorLbl;
        protected baseClass.controls.strategySelect strategyClb;
        protected baseClass.controls.chartTiming dateRangeEd;
        protected baseClass.controls.baseLabel strategyLbl;
        protected UIComponents.XPPanel xpPane_generalInfo;
        private common.control.baseDataGridView scrCriteriaGrid;
        private System.Windows.Forms.DataGridViewComboBoxColumn scrTypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn scrMinCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn scrMaxCol;
        protected UIComponents.XPPanelGroup xpPanelGroup_Info;
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
    }
}
