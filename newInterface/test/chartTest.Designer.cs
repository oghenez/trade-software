namespace test
{
    partial class chartTest
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
            this.reloadBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.zoomInBtn = new System.Windows.Forms.Button();
            this.zoomOutBtn = new System.Windows.Forms.Button();
            this.fowardBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.codeLbl = new common.controls.baseLabel();
            this.codeEd = new common.controls.baseTextBox();
            this.basePanel1 = new common.controls.basePanel();
            this.cbChartType = new baseClass.controls.cbChartType();
            this.cbTimeScale = new baseClass.controls.cbTimeScale();
            this.updateChartChk = new System.Windows.Forms.CheckBox();
            this.moveToEndBtn = new System.Windows.Forms.Button();
            this.xRangeChk = new System.Windows.Forms.CheckBox();
            this.pricePane = new Charts.Controls.baseGraphPanel();
            this.tmpDataSet1 = new Tools.Data.tmpDataSet();
            this.volumePanel = new Charts.Controls.baseGraphPanel();
            this.intervalEd = new common.controls.numberTextBox();
            this.basePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1043, 34);
            this.TitleLbl.Size = new System.Drawing.Size(32, 23);
            this.TitleLbl.Visible = false;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.reloadBtn.Image = global::test.Properties.Resources.exrate;
            this.reloadBtn.Location = new System.Drawing.Point(308, 4);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(27, 24);
            this.reloadBtn.TabIndex = 8;
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.resetBtn.Image = global::test.Properties.Resources.undo;
            this.resetBtn.Location = new System.Drawing.Point(335, 4);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(27, 24);
            this.resetBtn.TabIndex = 249;
            this.myToolTip.SetToolTip(this.resetBtn, "Reset chart");
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // zoomInBtn
            // 
            this.zoomInBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.zoomInBtn.Image = global::test.Properties.Resources.zoomOut;
            this.zoomInBtn.Location = new System.Drawing.Point(362, 4);
            this.zoomInBtn.Name = "zoomInBtn";
            this.zoomInBtn.Size = new System.Drawing.Size(27, 24);
            this.zoomInBtn.TabIndex = 251;
            this.zoomInBtn.UseVisualStyleBackColor = true;
            this.zoomInBtn.Click += new System.EventHandler(this.zoomInBtn_Click);
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.zoomOutBtn.Image = global::test.Properties.Resources.zoomIn;
            this.zoomOutBtn.Location = new System.Drawing.Point(389, 4);
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.Size = new System.Drawing.Size(27, 24);
            this.zoomOutBtn.TabIndex = 252;
            this.zoomOutBtn.UseVisualStyleBackColor = true;
            this.zoomOutBtn.Click += new System.EventHandler(this.zoomOutBtn_Click);
            // 
            // fowardBtn
            // 
            this.fowardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.fowardBtn.Location = new System.Drawing.Point(443, 4);
            this.fowardBtn.Name = "fowardBtn";
            this.fowardBtn.Size = new System.Drawing.Size(27, 24);
            this.fowardBtn.TabIndex = 254;
            this.fowardBtn.Text = ">>";
            this.fowardBtn.UseVisualStyleBackColor = true;
            this.fowardBtn.Click += new System.EventHandler(this.fowardBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.backBtn.Location = new System.Drawing.Point(416, 4);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(27, 24);
            this.backBtn.TabIndex = 253;
            this.backBtn.Text = "<<";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(6, 6);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(40, 16);
            this.codeLbl.TabIndex = 258;
            this.codeLbl.Text = "Code";
            // 
            // codeEd
            // 
            this.codeEd.isRequired = true;
            this.codeEd.isToUpperCase = true;
            this.codeEd.Location = new System.Drawing.Point(49, 5);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(59, 23);
            this.codeEd.TabIndex = 2;
            this.codeEd.Text = "XAUUSD";
            // 
            // basePanel1
            // 
            this.basePanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.basePanel1.Controls.Add(this.intervalEd);
            this.basePanel1.Controls.Add(this.cbChartType);
            this.basePanel1.Controls.Add(this.cbTimeScale);
            this.basePanel1.Controls.Add(this.codeEd);
            this.basePanel1.Controls.Add(this.codeLbl);
            this.basePanel1.Controls.Add(this.reloadBtn);
            this.basePanel1.Controls.Add(this.resetBtn);
            this.basePanel1.Controls.Add(this.backBtn);
            this.basePanel1.Controls.Add(this.zoomInBtn);
            this.basePanel1.Controls.Add(this.zoomOutBtn);
            this.basePanel1.Controls.Add(this.moveToEndBtn);
            this.basePanel1.Controls.Add(this.fowardBtn);
            this.basePanel1.Controls.Add(this.updateChartChk);
            this.basePanel1.Controls.Add(this.xRangeChk);
            this.basePanel1.haveCloseButton = false;
            this.basePanel1.isExpanded = true;
            this.basePanel1.Location = new System.Drawing.Point(0, 1);
            this.basePanel1.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.basePanel1.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.basePanel1.myWeight = 0;
            this.basePanel1.Name = "basePanel1";
            this.basePanel1.Size = new System.Drawing.Size(1252, 37);
            this.basePanel1.TabIndex = 260;
            // 
            // cbChartType
            // 
            this.cbChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChartType.FormattingEnabled = true;
            this.cbChartType.Location = new System.Drawing.Point(190, 5);
            this.cbChartType.myValue = commonTypes.AppTypes.ChartTypes.None;
            this.cbChartType.Name = "cbChartType";
            this.cbChartType.SelectedValue = ((byte)(0));
            this.cbChartType.Size = new System.Drawing.Size(118, 24);
            this.cbChartType.TabIndex = 263;
            // 
            // cbTimeScale
            // 
            this.cbTimeScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeScale.FormattingEnabled = true;
            this.cbTimeScale.Location = new System.Drawing.Point(108, 5);
            this.cbTimeScale.Name = "cbTimeScale";
            this.cbTimeScale.SelectedValue = "RT";
            this.cbTimeScale.Size = new System.Drawing.Size(83, 24);
            this.cbTimeScale.TabIndex = 3;
            // 
            // updateChartChk
            // 
            this.updateChartChk.AutoSize = true;
            this.updateChartChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.updateChartChk.Location = new System.Drawing.Point(521, 6);
            this.updateChartChk.Name = "updateChartChk";
            this.updateChartChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.updateChartChk.Size = new System.Drawing.Size(147, 21);
            this.updateChartChk.TabIndex = 262;
            this.updateChartChk.Text = "Realtime Update";
            this.updateChartChk.CheckedChanged += new System.EventHandler(this.updateChartChk_CheckedChanged);
            // 
            // moveToEndBtn
            // 
            this.moveToEndBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.moveToEndBtn.Location = new System.Drawing.Point(470, 4);
            this.moveToEndBtn.Name = "moveToEndBtn";
            this.moveToEndBtn.Size = new System.Drawing.Size(27, 24);
            this.moveToEndBtn.TabIndex = 261;
            this.moveToEndBtn.Text = ">|";
            this.moveToEndBtn.UseVisualStyleBackColor = true;
            this.moveToEndBtn.Click += new System.EventHandler(this.moveToEndBtn_Click);
            // 
            // xRangeChk
            // 
            this.xRangeChk.AutoSize = true;
            this.xRangeChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.xRangeChk.Location = new System.Drawing.Point(723, 5);
            this.xRangeChk.Name = "xRangeChk";
            this.xRangeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xRangeChk.Size = new System.Drawing.Size(128, 21);
            this.xRangeChk.TabIndex = 264;
            this.xRangeChk.Text = "Show X-range";
            this.xRangeChk.CheckedChanged += new System.EventHandler(this.xRangeChk_CheckedChanged);
            // 
            // pricePane
            // 
            this.pricePane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pricePane.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pricePane.haveCloseButton = true;
            this.pricePane.HaveRangeBarX = false;
            this.pricePane.isExpanded = true;
            this.pricePane.Location = new System.Drawing.Point(0, 42);
            this.pricePane.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.pricePane.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.pricePane.myWeight = 0;
            this.pricePane.Name = "pricePane";
            this.pricePane.Size = new System.Drawing.Size(1249, 514);
            this.pricePane.TabIndex = 261;
            this.pricePane.myGetMoreData += new Charts.Controls.myGraphControl.OnGetMoreData(this.pricePane_myGetMoreData);
            // 
            // tmpDataSet1
            // 
            this.tmpDataSet1.DataSetName = "tmpDataSet";
            this.tmpDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // volumePanel
            // 
            this.volumePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.volumePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.volumePanel.haveCloseButton = true;
            this.volumePanel.HaveRangeBarX = false;
            this.volumePanel.isExpanded = true;
            this.volumePanel.Location = new System.Drawing.Point(0, 561);
            this.volumePanel.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.volumePanel.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.volumePanel.myWeight = 0;
            this.volumePanel.Name = "volumePanel";
            this.volumePanel.Size = new System.Drawing.Size(1249, 150);
            this.volumePanel.TabIndex = 262;
            // 
            // intervalEd
            // 
            this.intervalEd.Enabled = false;
            this.intervalEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.intervalEd.Location = new System.Drawing.Point(674, 5);
            this.intervalEd.myFormat = "###,###,###,###,###";
            this.intervalEd.Name = "intervalEd";
            this.intervalEd.Size = new System.Drawing.Size(43, 23);
            this.intervalEd.TabIndex = 265;
            this.intervalEd.Text = "5";
            this.intervalEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.intervalEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.intervalEd.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chartTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1249, 741);
            this.Controls.Add(this.basePanel1);
            this.Controls.Add(this.volumePanel);
            this.Controls.Add(this.pricePane);
            this.Name = "chartTest";
            this.Resize += new System.EventHandler(this.mainTest_Resize);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.pricePane, 0);
            this.Controls.SetChildIndex(this.volumePanel, 0);
            this.Controls.SetChildIndex(this.basePanel1, 0);
            this.basePanel1.ResumeLayout(false);
            this.basePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button reloadBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button zoomInBtn;
        private System.Windows.Forms.Button zoomOutBtn;
        private System.Windows.Forms.Button fowardBtn;
        private System.Windows.Forms.Button backBtn;
        private common.controls.baseLabel codeLbl;
        private common.controls.baseTextBox codeEd;
        private common.controls.basePanel basePanel1;
        private baseClass.controls.cbTimeScale cbTimeScale;
        private System.Windows.Forms.Button moveToEndBtn;
        private Charts.Controls.baseGraphPanel pricePane;
        private Tools.Data.tmpDataSet tmpDataSet1;
        private Charts.Controls.baseGraphPanel volumePanel;
        private System.Windows.Forms.CheckBox updateChartChk;
        private baseClass.controls.cbChartType cbChartType;
        private System.Windows.Forms.CheckBox xRangeChk;
        private common.controls.numberTextBox intervalEd;
    }
}