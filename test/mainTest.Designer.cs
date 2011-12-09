namespace test
{
    partial class mainTest
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
            this.timerBtn = new System.Windows.Forms.Button();
            this.zoomInBtn = new System.Windows.Forms.Button();
            this.zoomOutBtn = new System.Windows.Forms.Button();
            this.fowardBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.genDataBtn = new System.Windows.Forms.Button();
            this.baseLabel1 = new common.controls.baseLabel();
            this.intervalEd = new common.controls.numberTextBox();
            this.codeLbl = new common.controls.baseLabel();
            this.codeEd = new common.controls.baseTextBox();
            this.basePanel1 = new common.controls.basePanel();
            this.moveToEndBtn = new System.Windows.Forms.Button();
            this.cbTimeRange = new baseClass.controls.cbTimeRange();
            this.cbTimeScale = new baseClass.controls.cbTimeScale();
            this.graphPane1 = new Charts.Controls.baseGraphPanel();
            this.tmpDataSet1 = new Tools.Data.tmpDataSet();
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
            this.reloadBtn.Location = new System.Drawing.Point(402, 4);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(73, 26);
            this.reloadBtn.TabIndex = 8;
            this.reloadBtn.Text = "Reload";
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.resetBtn.Location = new System.Drawing.Point(930, 4);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(64, 26);
            this.resetBtn.TabIndex = 249;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerBtn
            // 
            this.timerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.timerBtn.Image = global::test.Properties.Resources.timer;
            this.timerBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.timerBtn.Location = new System.Drawing.Point(475, 4);
            this.timerBtn.Name = "timerBtn";
            this.timerBtn.Size = new System.Drawing.Size(99, 26);
            this.timerBtn.TabIndex = 250;
            this.timerBtn.Text = "Stop";
            this.timerBtn.UseVisualStyleBackColor = true;
            this.timerBtn.Click += new System.EventHandler(this.timerBtn_Click);
            // 
            // zoomInBtn
            // 
            this.zoomInBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.zoomInBtn.Location = new System.Drawing.Point(752, 4);
            this.zoomInBtn.Name = "zoomInBtn";
            this.zoomInBtn.Size = new System.Drawing.Size(89, 26);
            this.zoomInBtn.TabIndex = 251;
            this.zoomInBtn.Text = "Zoom Out";
            this.zoomInBtn.UseVisualStyleBackColor = true;
            this.zoomInBtn.Click += new System.EventHandler(this.zoomInBtn_Click);
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.zoomOutBtn.Location = new System.Drawing.Point(841, 4);
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.Size = new System.Drawing.Size(89, 26);
            this.zoomOutBtn.TabIndex = 252;
            this.zoomOutBtn.Text = "Zoom In";
            this.zoomOutBtn.UseVisualStyleBackColor = true;
            this.zoomOutBtn.Click += new System.EventHandler(this.zoomOutBtn_Click);
            // 
            // fowardBtn
            // 
            this.fowardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.fowardBtn.Location = new System.Drawing.Point(1058, 4);
            this.fowardBtn.Name = "fowardBtn";
            this.fowardBtn.Size = new System.Drawing.Size(64, 26);
            this.fowardBtn.TabIndex = 254;
            this.fowardBtn.Text = ">>";
            this.fowardBtn.UseVisualStyleBackColor = true;
            this.fowardBtn.Click += new System.EventHandler(this.fowardBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.backBtn.Location = new System.Drawing.Point(994, 4);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(64, 26);
            this.backBtn.TabIndex = 253;
            this.backBtn.Text = "<<";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // genDataBtn
            // 
            this.genDataBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.genDataBtn.Image = global::test.Properties.Resources.data;
            this.genDataBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.genDataBtn.Location = new System.Drawing.Point(574, 4);
            this.genDataBtn.Name = "genDataBtn";
            this.genDataBtn.Size = new System.Drawing.Size(99, 26);
            this.genDataBtn.TabIndex = 255;
            this.genDataBtn.Text = "Stop";
            this.genDataBtn.UseVisualStyleBackColor = true;
            this.genDataBtn.Click += new System.EventHandler(this.genDataBtn_Click);
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel1.Location = new System.Drawing.Point(2, 8);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(98, 16);
            this.baseLabel1.TabIndex = 256;
            this.baseLabel1.Text = "Interval (sec)";
            // 
            // intervalEd
            // 
            this.intervalEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.intervalEd.Location = new System.Drawing.Point(100, 5);
            this.intervalEd.myFormat = "###,###,###,###,###";
            this.intervalEd.Name = "intervalEd";
            this.intervalEd.Size = new System.Drawing.Size(43, 20);
            this.intervalEd.TabIndex = 257;
            this.intervalEd.Text = "5";
            this.intervalEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.intervalEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.intervalEd.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(151, 9);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(40, 16);
            this.codeLbl.TabIndex = 258;
            this.codeLbl.Text = "Code";
            // 
            // codeEd
            // 
            this.codeEd.isToUpperCase = true;
            this.codeEd.Location = new System.Drawing.Point(192, 5);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(59, 20);
            this.codeEd.TabIndex = 2;
            this.codeEd.Text = "SSI";
            // 
            // basePanel1
            // 
            this.basePanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.basePanel1.Controls.Add(this.moveToEndBtn);
            this.basePanel1.Controls.Add(this.cbTimeRange);
            this.basePanel1.Controls.Add(this.cbTimeScale);
            this.basePanel1.Controls.Add(this.codeEd);
            this.basePanel1.Controls.Add(this.codeLbl);
            this.basePanel1.Controls.Add(this.intervalEd);
            this.basePanel1.Controls.Add(this.baseLabel1);
            this.basePanel1.Controls.Add(this.zoomInBtn);
            this.basePanel1.Controls.Add(this.resetBtn);
            this.basePanel1.Controls.Add(this.backBtn);
            this.basePanel1.Controls.Add(this.zoomOutBtn);
            this.basePanel1.Controls.Add(this.fowardBtn);
            this.basePanel1.Controls.Add(this.reloadBtn);
            this.basePanel1.Controls.Add(this.timerBtn);
            this.basePanel1.Controls.Add(this.genDataBtn);
            this.basePanel1.haveCloseButton = false;
            this.basePanel1.isExpanded = true;
            this.basePanel1.Location = new System.Drawing.Point(-1, 1);
            this.basePanel1.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.basePanel1.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.basePanel1.myWeight = 0;
            this.basePanel1.Name = "basePanel1";
            this.basePanel1.Size = new System.Drawing.Size(1252, 35);
            this.basePanel1.TabIndex = 260;
            // 
            // moveToEndBtn
            // 
            this.moveToEndBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.moveToEndBtn.Location = new System.Drawing.Point(1128, 3);
            this.moveToEndBtn.Name = "moveToEndBtn";
            this.moveToEndBtn.Size = new System.Drawing.Size(64, 26);
            this.moveToEndBtn.TabIndex = 261;
            this.moveToEndBtn.Text = ">|";
            this.moveToEndBtn.UseVisualStyleBackColor = true;
            this.moveToEndBtn.Click += new System.EventHandler(this.moveToEndBtn_Click);
            // 
            // cbTimeRange
            // 
            this.cbTimeRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeRange.FormattingEnabled = true;
            this.cbTimeRange.Location = new System.Drawing.Point(318, 5);
            this.cbTimeRange.myValue = application.AppTypes.TimeRanges.None;
            this.cbTimeRange.Name = "cbTimeRange";
            this.cbTimeRange.SelectedValue = ((byte)(0));
            this.cbTimeRange.Size = new System.Drawing.Size(84, 21);
            this.cbTimeRange.TabIndex = 4;
            // 
            // cbTimeScale
            // 
            this.cbTimeScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeScale.FormattingEnabled = true;
            this.cbTimeScale.Location = new System.Drawing.Point(251, 5);
            this.cbTimeScale.Name = "cbTimeScale";
            this.cbTimeScale.Size = new System.Drawing.Size(67, 21);
            this.cbTimeScale.TabIndex = 3;
            // 
            // graphPane1
            // 
            this.graphPane1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphPane1.haveCloseButton = true;
            this.graphPane1.isExpanded = true;
            this.graphPane1.Location = new System.Drawing.Point(0, 42);
            this.graphPane1.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.graphPane1.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.graphPane1.myWeight = 0;
            this.graphPane1.Name = "graphPane1";
            this.graphPane1.Size = new System.Drawing.Size(1034, 625);
            this.graphPane1.TabIndex = 261;
            // 
            // tmpDataSet1
            // 
            this.tmpDataSet1.DataSetName = "tmpDataSet";
            this.tmpDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mainTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1217, 756);
            this.Controls.Add(this.graphPane1);
            this.Controls.Add(this.basePanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "mainTest";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.basePanel1, 0);
            this.Controls.SetChildIndex(this.graphPane1, 0);
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
        private System.Windows.Forms.Button timerBtn;
        private System.Windows.Forms.Button zoomInBtn;
        private System.Windows.Forms.Button zoomOutBtn;
        private System.Windows.Forms.Button fowardBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button genDataBtn;
        private common.controls.baseLabel baseLabel1;
        private common.controls.numberTextBox intervalEd;
        private common.controls.baseLabel codeLbl;
        private common.controls.baseTextBox codeEd;
        private common.controls.basePanel basePanel1;
        private baseClass.controls.cbTimeScale cbTimeScale;
        private baseClass.controls.cbTimeRange cbTimeRange;
        private System.Windows.Forms.Button moveToEndBtn;
        private Charts.Controls.baseGraphPanel graphPane1;
        private Tools.Data.tmpDataSet tmpDataSet1;
    }
}