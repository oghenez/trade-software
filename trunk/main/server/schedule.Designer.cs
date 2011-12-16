﻿namespace server
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
            this.fetchStockLbl2 = new common.controls.baseLabel();
            this.tradeAlertLbl2 = new common.controls.baseLabel();
            this.tradeAlertEd = new System.Windows.Forms.NumericUpDown();
            this.scheduleGb = new System.Windows.Forms.GroupBox();
            this.tradeAlertChk = new common.controls.baseCheckBox();
            this.fetchStockChk = new common.controls.baseCheckBox();
            this.basePanel1 = new common.controls.basePanel();
            this.viewConfigBtn = new common.controls.baseButton();
            this.viewLogBtn = new common.controls.baseButton();
            this.saveBtn = new common.controls.baseButton();
            this.runBtn = new common.controls.baseButton();
            this.myTimer = new System.Windows.Forms.Timer(this.components);
            this.startBtn = new common.controls.baseButton();
            this.pauseBtn = new common.controls.baseButton();
            ((System.ComponentModel.ISupportInitialize)(this.fetchStockEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertEd)).BeginInit();
            this.scheduleGb.SuspendLayout();
            this.basePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(435, 24);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.TitleLbl.Size = new System.Drawing.Size(154, 33);
            // 
            // fetchStockEd
            // 
            this.fetchStockEd.Enabled = false;
            this.fetchStockEd.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fetchStockEd.Location = new System.Drawing.Point(172, 24);
            this.fetchStockEd.Margin = new System.Windows.Forms.Padding(2);
            this.fetchStockEd.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.fetchStockEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fetchStockEd.Name = "fetchStockEd";
            this.fetchStockEd.Size = new System.Drawing.Size(58, 23);
            this.fetchStockEd.TabIndex = 2;
            this.fetchStockEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fetchStockEd.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // fetchStockLbl2
            // 
            this.fetchStockLbl2.AutoSize = true;
            this.fetchStockLbl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchStockLbl2.Location = new System.Drawing.Point(230, 25);
            this.fetchStockLbl2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fetchStockLbl2.Name = "fetchStockLbl2";
            this.fetchStockLbl2.Size = new System.Drawing.Size(37, 16);
            this.fetchStockLbl2.TabIndex = 3;
            this.fetchStockLbl2.Text = "secs";
            // 
            // tradeAlertLbl2
            // 
            this.tradeAlertLbl2.AutoSize = true;
            this.tradeAlertLbl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tradeAlertLbl2.Location = new System.Drawing.Point(230, 51);
            this.tradeAlertLbl2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tradeAlertLbl2.Name = "tradeAlertLbl2";
            this.tradeAlertLbl2.Size = new System.Drawing.Size(37, 16);
            this.tradeAlertLbl2.TabIndex = 6;
            this.tradeAlertLbl2.Text = "secs";
            // 
            // tradeAlertEd
            // 
            this.tradeAlertEd.Enabled = false;
            this.tradeAlertEd.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tradeAlertEd.Location = new System.Drawing.Point(172, 46);
            this.tradeAlertEd.Margin = new System.Windows.Forms.Padding(2);
            this.tradeAlertEd.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.tradeAlertEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tradeAlertEd.Name = "tradeAlertEd";
            this.tradeAlertEd.Size = new System.Drawing.Size(58, 23);
            this.tradeAlertEd.TabIndex = 11;
            this.tradeAlertEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tradeAlertEd.Value = new decimal(new int[] {
            30,
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
            this.scheduleGb.Location = new System.Drawing.Point(1, 31);
            this.scheduleGb.Margin = new System.Windows.Forms.Padding(2);
            this.scheduleGb.Name = "scheduleGb";
            this.scheduleGb.Padding = new System.Windows.Forms.Padding(2);
            this.scheduleGb.Size = new System.Drawing.Size(320, 90);
            this.scheduleGb.TabIndex = 10;
            this.scheduleGb.TabStop = false;
            this.scheduleGb.Text = " Scheduling ";
            // 
            // tradeAlertChk
            // 
            this.tradeAlertChk.AutoSize = true;
            this.tradeAlertChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tradeAlertChk.Location = new System.Drawing.Point(19, 46);
            this.tradeAlertChk.Margin = new System.Windows.Forms.Padding(2);
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
            this.fetchStockChk.Location = new System.Drawing.Point(19, 25);
            this.fetchStockChk.Margin = new System.Windows.Forms.Padding(2);
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
            this.basePanel1.isExpanded = true;
            this.basePanel1.Location = new System.Drawing.Point(-1, -1);
            this.basePanel1.Margin = new System.Windows.Forms.Padding(2);
            this.basePanel1.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.basePanel1.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.basePanel1.myWeight = 0;
            this.basePanel1.Name = "basePanel1";
            this.basePanel1.Size = new System.Drawing.Size(327, 28);
            this.basePanel1.TabIndex = 1;
            // 
            // viewConfigBtn
            // 
            this.viewConfigBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewConfigBtn.Image = global::server.Properties.Resources.configure;
            this.viewConfigBtn.isDownState = false;
            this.viewConfigBtn.Location = new System.Drawing.Point(58, 3);
            this.viewConfigBtn.Margin = new System.Windows.Forms.Padding(2);
            this.viewConfigBtn.Name = "viewConfigBtn";
            this.viewConfigBtn.Size = new System.Drawing.Size(24, 22);
            this.viewConfigBtn.TabIndex = 3;
            this.myToolTip.SetToolTip(this.viewConfigBtn, "View config file");
            this.viewConfigBtn.UseVisualStyleBackColor = true;
            this.viewConfigBtn.Click += new System.EventHandler(this.viewConfigBtn_Click);
            // 
            // viewLogBtn
            // 
            this.viewLogBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLogBtn.Image = global::server.Properties.Resources.schedule;
            this.viewLogBtn.isDownState = false;
            this.viewLogBtn.Location = new System.Drawing.Point(82, 3);
            this.viewLogBtn.Margin = new System.Windows.Forms.Padding(2);
            this.viewLogBtn.Name = "viewLogBtn";
            this.viewLogBtn.Size = new System.Drawing.Size(24, 22);
            this.viewLogBtn.TabIndex = 2;
            this.myToolTip.SetToolTip(this.viewLogBtn, "View log");
            this.viewLogBtn.UseVisualStyleBackColor = true;
            this.viewLogBtn.Click += new System.EventHandler(this.viewLogBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = global::server.Properties.Resources.save;
            this.saveBtn.isDownState = false;
            this.saveBtn.Location = new System.Drawing.Point(34, 3);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(24, 22);
            this.saveBtn.TabIndex = 1;
            this.myToolTip.SetToolTip(this.saveBtn, "Save settings");
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runBtn.Image = global::server.Properties.Resources.run;
            this.runBtn.isDownState = false;
            this.runBtn.Location = new System.Drawing.Point(10, 3);
            this.runBtn.Margin = new System.Windows.Forms.Padding(2);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(24, 22);
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
            this.startBtn.isDownState = false;
            this.startBtn.Location = new System.Drawing.Point(413, 24);
            this.startBtn.Margin = new System.Windows.Forms.Padding(2);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(15, 16);
            this.startBtn.TabIndex = 3;
            this.myToolTip.SetToolTip(this.startBtn, "Run ");
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Visible = false;
            // 
            // pauseBtn
            // 
            this.pauseBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseBtn.Image = global::server.Properties.Resources.pause;
            this.pauseBtn.isDownState = false;
            this.pauseBtn.Location = new System.Drawing.Point(394, 24);
            this.pauseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(15, 16);
            this.pauseBtn.TabIndex = 145;
            this.myToolTip.SetToolTip(this.pauseBtn, "Run ");
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Visible = false;
            // 
            // scheduleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(321, 146);
            this.Controls.Add(this.basePanel1);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.scheduleGb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "scheduleForm";
            this.Text = "Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Controls.SetChildIndex(this.scheduleGb, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.pauseBtn, 0);
            this.Controls.SetChildIndex(this.startBtn, 0);
            this.Controls.SetChildIndex(this.basePanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fetchStockEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertEd)).EndInit();
            this.scheduleGb.ResumeLayout(false);
            this.scheduleGb.PerformLayout();
            this.basePanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private common.controls.baseButton runBtn;
        private System.Windows.Forms.NumericUpDown fetchStockEd;
        private common.controls.baseLabel fetchStockLbl2;
        private common.controls.baseLabel tradeAlertLbl2;
        private System.Windows.Forms.NumericUpDown tradeAlertEd;
        private common.controls.baseButton saveBtn;
        private common.controls.baseButton viewLogBtn;
        protected common.controls.baseButton pauseBtn;
        protected System.Windows.Forms.GroupBox scheduleGb;
        protected common.controls.basePanel basePanel1;
        private common.controls.baseButton startBtn;
        protected System.Windows.Forms.Timer myTimer;
        private common.controls.baseCheckBox tradeAlertChk;
        private common.controls.baseCheckBox fetchStockChk;
        private common.controls.baseButton viewConfigBtn;
    }
}

