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
            this.fetchStockLbl = new common.controls.baseLabel();
            this.tradeAlertLbl = new common.controls.baseLabel();
            this.scheduleGb = new System.Windows.Forms.GroupBox();
            this.tradeAlertChk = new common.controls.baseCheckBox();
            this.fetchDataChk = new common.controls.baseCheckBox();
            this.basePanel1 = new common.controls.basePanel();
            this.viewLogBtn = new common.controls.baseButton();
            this.runBtn = new common.controls.baseButton();
            this.myTimer = new System.Windows.Forms.Timer(this.components);
            this.startBtn = new common.controls.baseButton();
            this.pauseBtn = new common.controls.baseButton();
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
            // fetchStockLbl
            // 
            this.fetchStockLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchStockLbl.Location = new System.Drawing.Point(147, 24);
            this.fetchStockLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fetchStockLbl.Name = "fetchStockLbl";
            this.fetchStockLbl.Size = new System.Drawing.Size(158, 20);
            this.fetchStockLbl.TabIndex = 3;
            this.fetchStockLbl.Text = "secs";
            // 
            // tradeAlertLbl
            // 
            this.tradeAlertLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tradeAlertLbl.Location = new System.Drawing.Point(146, 46);
            this.tradeAlertLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tradeAlertLbl.Name = "tradeAlertLbl";
            this.tradeAlertLbl.Size = new System.Drawing.Size(158, 20);
            this.tradeAlertLbl.TabIndex = 6;
            this.tradeAlertLbl.Text = "secs";
            // 
            // scheduleGb
            // 
            this.scheduleGb.Controls.Add(this.tradeAlertChk);
            this.scheduleGb.Controls.Add(this.fetchDataChk);
            this.scheduleGb.Controls.Add(this.tradeAlertLbl);
            this.scheduleGb.Controls.Add(this.fetchStockLbl);
            this.scheduleGb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleGb.Location = new System.Drawing.Point(1, 32);
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
            this.tradeAlertChk.Checked = true;
            this.tradeAlertChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tradeAlertChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tradeAlertChk.Location = new System.Drawing.Point(36, 46);
            this.tradeAlertChk.Margin = new System.Windows.Forms.Padding(2);
            this.tradeAlertChk.Name = "tradeAlertChk";
            this.tradeAlertChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tradeAlertChk.Size = new System.Drawing.Size(106, 20);
            this.tradeAlertChk.TabIndex = 10;
            this.tradeAlertChk.Text = "Create alert";
            this.tradeAlertChk.UseVisualStyleBackColor = true;
            // 
            // fetchDataChk
            // 
            this.fetchDataChk.AutoSize = true;
            this.fetchDataChk.Checked = true;
            this.fetchDataChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fetchDataChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchDataChk.Location = new System.Drawing.Point(38, 25);
            this.fetchDataChk.Margin = new System.Windows.Forms.Padding(2);
            this.fetchDataChk.Name = "fetchDataChk";
            this.fetchDataChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.fetchDataChk.Size = new System.Drawing.Size(104, 20);
            this.fetchDataChk.TabIndex = 1;
            this.fetchDataChk.Text = "Fetch  data ";
            this.fetchDataChk.UseVisualStyleBackColor = true;
            // 
            // basePanel1
            // 
            this.basePanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.basePanel1.Controls.Add(this.viewLogBtn);
            this.basePanel1.Controls.Add(this.runBtn);
            this.basePanel1.haveCloseButton = false;
            this.basePanel1.isExpanded = true;
            this.basePanel1.Location = new System.Drawing.Point(0, 0);
            this.basePanel1.Margin = new System.Windows.Forms.Padding(2);
            this.basePanel1.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.basePanel1.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.basePanel1.myWeight = 0;
            this.basePanel1.Name = "basePanel1";
            this.basePanel1.Size = new System.Drawing.Size(327, 31);
            this.basePanel1.TabIndex = 1;
            // 
            // viewLogBtn
            // 
            this.viewLogBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLogBtn.Image = global::server.Properties.Resources.schedule;
            this.viewLogBtn.isDownState = false;
            this.viewLogBtn.Location = new System.Drawing.Point(35, 2);
            this.viewLogBtn.Margin = new System.Windows.Forms.Padding(2);
            this.viewLogBtn.Name = "viewLogBtn";
            this.viewLogBtn.Size = new System.Drawing.Size(24, 24);
            this.viewLogBtn.TabIndex = 2;
            this.myToolTip.SetToolTip(this.viewLogBtn, "View log");
            this.viewLogBtn.UseVisualStyleBackColor = true;
            this.viewLogBtn.Click += new System.EventHandler(this.viewLogBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runBtn.Image = global::server.Properties.Resources.run;
            this.runBtn.isDownState = false;
            this.runBtn.Location = new System.Drawing.Point(10, 2);
            this.runBtn.Margin = new System.Windows.Forms.Padding(2);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(24, 24);
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
            this.ClientSize = new System.Drawing.Size(321, 148);
            this.Controls.Add(this.basePanel1);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.scheduleGb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "scheduleForm";
            this.Text = "Tool";
            this.Controls.SetChildIndex(this.scheduleGb, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.pauseBtn, 0);
            this.Controls.SetChildIndex(this.startBtn, 0);
            this.Controls.SetChildIndex(this.basePanel1, 0);
            this.scheduleGb.ResumeLayout(false);
            this.scheduleGb.PerformLayout();
            this.basePanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private common.controls.baseButton runBtn;
        private common.controls.baseLabel fetchStockLbl;
        private common.controls.baseLabel tradeAlertLbl;
        private common.controls.baseButton viewLogBtn;
        protected common.controls.baseButton pauseBtn;
        protected System.Windows.Forms.GroupBox scheduleGb;
        protected common.controls.basePanel basePanel1;
        private common.controls.baseButton startBtn;
        protected System.Windows.Forms.Timer myTimer;
        private common.controls.baseCheckBox tradeAlertChk;
        private common.controls.baseCheckBox fetchDataChk;
    }
}

