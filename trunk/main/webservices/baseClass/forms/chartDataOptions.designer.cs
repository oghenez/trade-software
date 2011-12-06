namespace baseClass.forms
{
    partial class chartDataOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chartDataOptions));
            this.timeRangeLbl = new baseClass.controls.baseLabel();
            this.timeRangeCb = new baseClass.controls.cbTimeRange();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(168, 61);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(82, 60);
            this.okBtn.Text = "Ok";
            // 
            // timeRangeLbl
            // 
            this.timeRangeLbl.AutoSize = true;
            this.timeRangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeRangeLbl.Location = new System.Drawing.Point(82, 18);
            this.timeRangeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeRangeLbl.Name = "timeRangeLbl";
            this.timeRangeLbl.Size = new System.Drawing.Size(76, 16);
            this.timeRangeLbl.TabIndex = 312;
            this.timeRangeLbl.Text = "Periodicity";
            // 
            // timeRangeCb
            // 
            this.timeRangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeRangeCb.FormattingEnabled = true;
            this.timeRangeCb.Location = new System.Drawing.Point(158, 15);
            this.timeRangeCb.myValue = commonClass.AppTypes.TimeRanges.None;
            this.timeRangeCb.Name = "timeRangeCb";
            this.timeRangeCb.SelectedValue = ((byte)(0));
            this.timeRangeCb.Size = new System.Drawing.Size(96, 24);
            this.timeRangeCb.TabIndex = 1;
            // 
            // chartDataOptions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(337, 128);
            this.Controls.Add(this.timeRangeLbl);
            this.Controls.Add(this.timeRangeCb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "chartDataOptions";
            this.Text = "Periodicity";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.timeRangeCb, 0);
            this.Controls.SetChildIndex(this.timeRangeLbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseLabel timeRangeLbl;
        protected baseClass.controls.cbTimeRange timeRangeCb;


    }
}