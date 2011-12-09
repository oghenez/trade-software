namespace baseClass.forms
{
    partial class makeIndicatorData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(makeIndicatorData));
            this.process1 = new System.Diagnostics.Process();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cancelBtn = new common.control.baseButton();
            this.closeBtn = new common.control.baseButton();
            this.okBtn = new common.control.baseButton();
            this.dateRange = new common.control.dateRange0();
            this.myDataSet = new data.baseDS();
            this.allIndicatorChk = new baseClass.controls.baseCheckBox();
            this.clbIndicator = new baseClass.controls.clbIndicator();
            this.stockCodeClb = new baseClass.controls.stockCodeSelect();
            this.stockCodeLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(896, 91);
            this.TitleLbl.Visible = false;
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Enabled = false;
            this.cancelBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Image = global::baseClass.Properties.Resources.remove;
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelBtn.Location = new System.Drawing.Point(318, 415);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(68, 30);
            this.cancelBtn.TabIndex = 31;
            this.cancelBtn.Text = "Dừng";
            this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.Location = new System.Drawing.Point(386, 415);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(68, 30);
            this.closeBtn.TabIndex = 32;
            this.closeBtn.Text = "Đóng";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Image = global::baseClass.Properties.Resources.select;
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okBtn.Location = new System.Drawing.Point(227, 415);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(91, 30);
            this.okBtn.TabIndex = 30;
            this.okBtn.Text = "Thực hiện";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // dateRange
            // 
            this.dateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRange.Location = new System.Drawing.Point(26, 10);
            this.dateRange.Margin = new System.Windows.Forms.Padding(4);
            this.dateRange.Name = "dateRange";
            this.dateRange.Size = new System.Drawing.Size(428, 49);
            this.dateRange.TabIndex = 1;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // allIndicatorChk
            // 
            this.allIndicatorChk.AutoSize = true;
            this.allIndicatorChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allIndicatorChk.Location = new System.Drawing.Point(26, 68);
            this.allIndicatorChk.Name = "allIndicatorChk";
            this.allIndicatorChk.Size = new System.Drawing.Size(67, 20);
            this.allIndicatorChk.TabIndex = 10;
            this.allIndicatorChk.Text = "Tất cả";
            this.allIndicatorChk.UseVisualStyleBackColor = true;
            this.allIndicatorChk.CheckedChanged += new System.EventHandler(this.allIndicatorChk_CheckedChanged);
            // 
            // clbIndicator
            // 
            this.clbIndicator.CheckOnClick = true;
            this.clbIndicator.FormattingEnabled = true;
            this.clbIndicator.Location = new System.Drawing.Point(26, 92);
            this.clbIndicator.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("clbIndicator.myCheckedItems")));
            this.clbIndicator.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("clbIndicator.myCheckedValues")));
            this.clbIndicator.myItemString = "";
            this.clbIndicator.Name = "clbIndicator";
            this.clbIndicator.ShowCheckedOnly = false;
            this.clbIndicator.Size = new System.Drawing.Size(428, 72);
            this.clbIndicator.TabIndex = 11;
            // 
            // stockCodeClb
            // 
            this.stockCodeClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeClb.Location = new System.Drawing.Point(26, 170);
            this.stockCodeClb.Margin = new System.Windows.Forms.Padding(2);
            this.stockCodeClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeClb.myCheckedValues")));
            this.stockCodeClb.myItemString = "";
            this.stockCodeClb.Name = "stockCodeClb";
            this.stockCodeClb.ShowCheckedOnly = false;
            this.stockCodeClb.Size = new System.Drawing.Size(428, 235);
            this.stockCodeClb.TabIndex = 21;
            // 
            // stockCodeLbl
            // 
            this.stockCodeLbl.AutoSize = true;
            this.stockCodeLbl.Location = new System.Drawing.Point(23, 167);
            this.stockCodeLbl.Name = "stockCodeLbl";
            this.stockCodeLbl.Size = new System.Drawing.Size(45, 16);
            this.stockCodeLbl.TabIndex = 145;
            this.stockCodeLbl.Text = "label1";
            // 
            // makeIndicatorData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 477);
            this.Controls.Add(this.stockCodeClb);
            this.Controls.Add(this.allIndicatorChk);
            this.Controls.Add(this.clbIndicator);
            this.Controls.Add(this.dateRange);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.stockCodeLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "makeIndicatorData";
            this.Text = "Tao du lieu chi so";
            this.Load += new System.EventHandler(this.makeIndicatorData_Load);
            this.Controls.SetChildIndex(this.stockCodeLbl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.cancelBtn, 0);
            this.Controls.SetChildIndex(this.dateRange, 0);
            this.Controls.SetChildIndex(this.clbIndicator, 0);
            this.Controls.SetChildIndex(this.allIndicatorChk, 0);
            this.Controls.SetChildIndex(this.stockCodeClb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseButton okBtn;
        protected common.control.baseButton closeBtn;
        private System.Diagnostics.Process process1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        protected common.control.baseButton cancelBtn;
        private common.control.dateRange0 dateRange;
        private baseClass.controls.baseCheckBox allIndicatorChk;
        protected baseClass.controls.clbIndicator clbIndicator;
        protected data.baseDS myDataSet;
        protected baseClass.controls.stockCodeSelect stockCodeClb;
        protected System.Windows.Forms.Label stockCodeLbl;

    }
}