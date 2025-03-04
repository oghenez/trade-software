namespace baseClass.forms
{
    partial class chartTimeOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sysOptions));
            this.toDateLbl = new baseClass.controls.baseLabel();
            this.frDateLbl = new baseClass.controls.baseLabel();
            this.timeRangeLbl = new baseClass.controls.baseLabel();
            this.timeRangeCb = new baseClass.controls.cbTimeRange();
            this.toDateEd = new common.control.baseDate();
            this.frDateEd = new common.control.baseDate();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(169, 93);
            this.closeBtn.Size = new System.Drawing.Size(86, 26);
            this.closeBtn.TabIndex = 102;
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(83, 92);
            this.okBtn.Size = new System.Drawing.Size(86, 27);
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(635, 163);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TitleLbl.Size = new System.Drawing.Size(89, 20);
            this.TitleLbl.TabIndex = 149;
            this.TitleLbl.Visible = false;
            // 
            // toDateLbl
            // 
            this.toDateLbl.AutoSize = true;
            this.toDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateLbl.Location = new System.Drawing.Point(82, 65);
            this.toDateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toDateLbl.Name = "toDateLbl";
            this.toDateLbl.Size = new System.Drawing.Size(70, 16);
            this.toDateLbl.TabIndex = 314;
            this.toDateLbl.Text = "Đến ngày";
            // 
            // frDateLbl
            // 
            this.frDateLbl.AutoSize = true;
            this.frDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frDateLbl.Location = new System.Drawing.Point(82, 42);
            this.frDateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.frDateLbl.Name = "frDateLbl";
            this.frDateLbl.Size = new System.Drawing.Size(60, 16);
            this.frDateLbl.TabIndex = 313;
            this.frDateLbl.Text = "Từ ngày";
            // 
            // timeRangeLbl
            // 
            this.timeRangeLbl.AutoSize = true;
            this.timeRangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeRangeLbl.Location = new System.Drawing.Point(82, 18);
            this.timeRangeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeRangeLbl.Name = "timeRangeLbl";
            this.timeRangeLbl.Size = new System.Drawing.Size(65, 16);
            this.timeRangeLbl.TabIndex = 312;
            this.timeRangeLbl.Text = "Thời gian";
            // 
            // timeRangeCb
            // 
            this.timeRangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeRangeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeRangeCb.FormattingEnabled = true;
            this.timeRangeCb.Location = new System.Drawing.Point(158, 15);
            this.timeRangeCb.myValue = application.myTypes.timeRanges.None;
            this.timeRangeCb.Name = "timeRangeCb";
            this.timeRangeCb.SelectedValue = ((byte)(0));
            this.timeRangeCb.Size = new System.Drawing.Size(96, 23);
            this.timeRangeCb.TabIndex = 311;
            this.timeRangeCb.SelectionChangeCommitted += new System.EventHandler(this.timeRangeCb_SelectionChangeCommitted);
            // 
            // toDateEd
            // 
            this.toDateEd.BeepOnError = true;
            this.toDateEd.Enabled = false;
            this.toDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.toDateEd.Location = new System.Drawing.Point(158, 62);
            this.toDateEd.Mask = "00/00/0000";
            this.toDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.toDateEd.Name = "toDateEd";
            this.toDateEd.Size = new System.Drawing.Size(96, 24);
            this.toDateEd.TabIndex = 310;
            // 
            // frDateEd
            // 
            this.frDateEd.BeepOnError = true;
            this.frDateEd.Enabled = false;
            this.frDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.frDateEd.Location = new System.Drawing.Point(158, 38);
            this.frDateEd.Mask = "00/00/0000";
            this.frDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.frDateEd.Name = "frDateEd";
            this.frDateEd.Size = new System.Drawing.Size(96, 24);
            this.frDateEd.TabIndex = 309;
            // 
            // baseSysOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 158);
            this.Controls.Add(this.toDateLbl);
            this.Controls.Add(this.frDateLbl);
            this.Controls.Add(this.timeRangeLbl);
            this.Controls.Add(this.timeRangeCb);
            this.Controls.Add(this.toDateEd);
            this.Controls.Add(this.frDateEd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "baseSysOptions";
            this.Text = "Thoi gian";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.frDateEd, 0);
            this.Controls.SetChildIndex(this.toDateEd, 0);
            this.Controls.SetChildIndex(this.timeRangeCb, 0);
            this.Controls.SetChildIndex(this.timeRangeLbl, 0);
            this.Controls.SetChildIndex(this.frDateLbl, 0);
            this.Controls.SetChildIndex(this.toDateLbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseLabel toDateLbl;
        protected baseClass.controls.baseLabel frDateLbl;
        protected baseClass.controls.baseLabel timeRangeLbl;
        protected baseClass.controls.cbTimeRange timeRangeCb;
        private common.control.baseDate toDateEd;
        private common.control.baseDate frDateEd;


    }
}