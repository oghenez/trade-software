namespace server
{
    partial class scheduleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(scheduleForm));
            this.fetchStockEd = new System.Windows.Forms.NumericUpDown();
            this.fetchStockLbl2 = new common.control.baseLabel();
            this.tradeAlertLbl2 = new common.control.baseLabel();
            this.tradeAlertEd = new System.Windows.Forms.NumericUpDown();
            this.scheduleGb = new System.Windows.Forms.GroupBox();
            this.tradeAlertChk = new common.control.baseCheckBox();
            this.fetchStockChk = new common.control.baseCheckBox();
            this.basePanel1 = new common.control.basePanel();
            this.viewConfigBtn = new common.control.baseButton();
            this.viewLogBtn = new common.control.baseButton();
            this.saveBtn = new common.control.baseButton();
            this.runBtn = new common.control.baseButton();
            this.myTimer = new System.Windows.Forms.Timer(this.components);
            this.startBtn = new common.control.baseButton();
            this.pauseBtn = new common.control.baseButton();
            ((System.ComponentModel.ISupportInitialize)(this.fetchStockEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertEd)).BeginInit();
            this.scheduleGb.SuspendLayout();
            this.basePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(652, 33);
            this.TitleLbl.Size = new System.Drawing.Size(231, 46);
            // 
            // fetchStockEd
            // 
            this.fetchStockEd.Enabled = false;
            this.fetchStockEd.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fetchStockEd.Location = new System.Drawing.Point(236, 33);
            this.fetchStockEd.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.fetchStockEd.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fetchStockEd.Name = "fetchStockEd";
            this.fetchStockEd.Size = new System.Drawing.Size(75, 23);
            this.fetchStockEd.TabIndex = 2;
            this.fetchStockEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fetchStockEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // fetchStockLbl2
            // 
            this.fetchStockLbl2.AutoSize = true;
            this.fetchStockLbl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchStockLbl2.Location = new System.Drawing.Point(317, 35);
            this.fetchStockLbl2.Name = "fetchStockLbl2";
            this.fetchStockLbl2.Size = new System.Drawing.Size(61, 16);
            this.fetchStockLbl2.TabIndex = 3;
            this.fetchStockLbl2.Text = "seconds";
            // 
            // tradeAlertLbl2
            // 
            this.tradeAlertLbl2.AutoSize = true;
            this.tradeAlertLbl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tradeAlertLbl2.Location = new System.Drawing.Point(317, 62);
            this.tradeAlertLbl2.Name = "tradeAlertLbl2";
            this.tradeAlertLbl2.Size = new System.Drawing.Size(61, 16);
            this.tradeAlertLbl2.TabIndex = 6;
            this.tradeAlertLbl2.Text = "seconds";
            // 
            // tradeAlertEd
            // 
            this.tradeAlertEd.Enabled = false;
            this.tradeAlertEd.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tradeAlertEd.Location = new System.Drawing.Point(236, 59);
            this.tradeAlertEd.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.tradeAlertEd.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tradeAlertEd.Name = "tradeAlertEd";
            this.tradeAlertEd.Size = new System.Drawing.Size(75, 23);
            this.tradeAlertEd.TabIndex = 11;
            this.tradeAlertEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tradeAlertEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // scheduleGb
            // 
            this.scheduleGb.Controls.Add(this.tradeAlertChk);
            this.scheduleGb.Controls.Add(this.fetchStockChk);
            this.scheduleGb.Controls.Add(this.tradeAlertLbl2);
            this.scheduleGb.Controls.Add(this.tradeAlertEd);
            this.scheduleGb.Controls.Add(this.fetchStockEd);
            this.scheduleGb.Controls.Add(this.fetchStockLbl2);
            this.scheduleGb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleGb.Location = new System.Drawing.Point(1, 28);
            this.scheduleGb.Name = "scheduleGb";
            this.scheduleGb.Size = new System.Drawing.Size(462, 111);
            this.scheduleGb.TabIndex = 10;
            this.scheduleGb.TabStop = false;
            this.scheduleGb.Text = " Scheduling ";
            // 
            // tradeAlertChk
            // 
            this.tradeAlertChk.AutoSize = true;
            this.tradeAlertChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tradeAlertChk.Location = new System.Drawing.Point(76, 59);
            this.tradeAlertChk.Name = "tradeAlertChk";
            this.tradeAlertChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tradeAlertChk.Size = new System.Drawing.Size(146, 20);
            this.tradeAlertChk.TabIndex = 10;
            this.tradeAlertChk.Text = "Create trade alert";
            this.tradeAlertChk.UseVisualStyleBackColor = true;
            this.tradeAlertChk.CheckedChanged += new System.EventHandler(this.tradeAlertChk_CheckedChanged);
            // 
            // fetchStockChk
            // 
            this.fetchStockChk.AutoSize = true;
            this.fetchStockChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchStockChk.Location = new System.Drawing.Point(76, 35);
            this.fetchStockChk.Name = "fetchStockChk";
            this.fetchStockChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.fetchStockChk.Size = new System.Drawing.Size(147, 20);
            this.fetchStockChk.TabIndex = 1;
            this.fetchStockChk.Text = "Fetch  stock  data ";
            this.fetchStockChk.UseVisualStyleBackColor = true;
            this.fetchStockChk.CheckedChanged += new System.EventHandler(this.fetchStockChk_CheckedChanged);
            // 
            // basePanel1
            // 
            this.basePanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.basePanel1.Controls.Add(this.viewConfigBtn);
            this.basePanel1.Controls.Add(this.viewLogBtn);
            this.basePanel1.Controls.Add(this.saveBtn);
            this.basePanel1.Controls.Add(this.runBtn);
            this.basePanel1.haveCloseButton = false;
            this.basePanel1.haveShowHideButton = false;
            this.basePanel1.Location = new System.Drawing.Point(-1, -1);
            this.basePanel1.Name = "basePanel1";
            this.basePanel1.Size = new System.Drawing.Size(489, 27);
            this.basePanel1.TabIndex = 1;
            // 
            // viewConfigBtn
            // 
            this.viewConfigBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewConfigBtn.Image = global::server.Properties.Resources.configure;
            this.viewConfigBtn.Location = new System.Drawing.Point(57, 1);
            this.viewConfigBtn.Name = "viewConfigBtn";
            this.viewConfigBtn.Size = new System.Drawing.Size(23, 22);
            this.viewConfigBtn.TabIndex = 3;
            this.myToolTip.SetToolTip(this.viewConfigBtn, "View config file");
            this.viewConfigBtn.UseVisualStyleBackColor = true;
            this.viewConfigBtn.Click += new System.EventHandler(this.viewConfigBtn_Click);
            // 
            // viewLogBtn
            // 
            this.viewLogBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLogBtn.Image = global::server.Properties.Resources.schedule;
            this.viewLogBtn.Location = new System.Drawing.Point(80, 1);
            this.viewLogBtn.Name = "viewLogBtn";
            this.viewLogBtn.Size = new System.Drawing.Size(23, 22);
            this.viewLogBtn.TabIndex = 2;
            this.myToolTip.SetToolTip(this.viewLogBtn, "View log");
            this.viewLogBtn.UseVisualStyleBackColor = true;
            this.viewLogBtn.Click += new System.EventHandler(this.viewLogBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = global::server.Properties.Resources.save;
            this.saveBtn.Location = new System.Drawing.Point(34, 1);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(23, 22);
            this.saveBtn.TabIndex = 1;
            this.myToolTip.SetToolTip(this.saveBtn, "Save settings");
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runBtn.Image = global::server.Properties.Resources.run;
            this.runBtn.Location = new System.Drawing.Point(11, 1);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(23, 22);
            this.runBtn.TabIndex = 0;
            this.myToolTip.SetToolTip(this.runBtn, "Run ");
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // myTimer
            // 
            this.myTimer.Enabled = true;
            this.myTimer.Interval = 1000;
            this.myTimer.Tick += new System.EventHandler(this.myTimer_Tick);
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Image = global::server.Properties.Resources.run;
            this.startBtn.Location = new System.Drawing.Point(620, 33);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(23, 22);
            this.startBtn.TabIndex = 3;
            this.myToolTip.SetToolTip(this.startBtn, "Run ");
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Visible = false;
            // 
            // pauseBtn
            // 
            this.pauseBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseBtn.Image = global::server.Properties.Resources.pause;
            this.pauseBtn.Location = new System.Drawing.Point(591, 33);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(23, 22);
            this.pauseBtn.TabIndex = 145;
            this.myToolTip.SetToolTip(this.pauseBtn, "Run ");
            this.pauseBtn.UseVisualStyleBackColor = true;
            // 
            // scheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 162);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.basePanel1);
            this.Controls.Add(this.scheduleGb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "scheduleForm";
            this.Text = "Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.scheduleGb, 0);
            this.Controls.SetChildIndex(this.basePanel1, 0);
            this.Controls.SetChildIndex(this.pauseBtn, 0);
            this.Controls.SetChildIndex(this.startBtn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fetchStockEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertEd)).EndInit();
            this.scheduleGb.ResumeLayout(false);
            this.scheduleGb.PerformLayout();
            this.basePanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private common.control.baseButton runBtn;
        private System.Windows.Forms.NumericUpDown fetchStockEd;
        private common.control.baseLabel fetchStockLbl2;
        private common.control.baseLabel tradeAlertLbl2;
        private System.Windows.Forms.NumericUpDown tradeAlertEd;
        private common.control.baseButton saveBtn;
        private common.control.baseButton viewLogBtn;
        protected common.control.baseButton pauseBtn;
        protected System.Windows.Forms.GroupBox scheduleGb;
        protected common.control.basePanel basePanel1;
        private common.control.baseButton startBtn;
        protected System.Windows.Forms.Timer myTimer;
        private common.control.baseCheckBox tradeAlertChk;
        private common.control.baseCheckBox fetchStockChk;
        private common.control.baseButton viewConfigBtn;
    }
}

