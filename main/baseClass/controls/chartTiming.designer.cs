namespace baseClass.controls
{
    partial class chartTiming
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.timeRangeCb = new baseClass.controls.cbTimeRange();
            this.timeScaleCb = new baseClass.controls.cbTimeScale();
            this.SuspendLayout();
            // 
            // timeRangeCb
            // 
            this.timeRangeCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.timeRangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeRangeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeRangeCb.FormattingEnabled = true;
            this.timeRangeCb.Location = new System.Drawing.Point(2, 0);
            this.timeRangeCb.myValue = commonClass.AppTypes.TimeRanges.None;
            this.timeRangeCb.Name = "timeRangeCb";
            this.timeRangeCb.SelectedValue = ((byte)(0));
            this.timeRangeCb.Size = new System.Drawing.Size(223, 23);
            this.timeRangeCb.TabIndex = 11;
            this.timeRangeCb.SelectionChangeCommitted += new System.EventHandler(this.timing_SelectionChangeCommitted);
            // 
            // timeScaleCb
            // 
            this.timeScaleCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeScaleCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeScaleCb.FormattingEnabled = true;
            this.timeScaleCb.Location = new System.Drawing.Point(224, 0);
            this.timeScaleCb.Name = "timeScaleCb";
            this.timeScaleCb.Size = new System.Drawing.Size(141, 24);
            this.timeScaleCb.TabIndex = 3;
            this.timeScaleCb.SelectionChangeCommitted += new System.EventHandler(this.timing_SelectionChangeCommitted);
            // 
            // chartTiming
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.timeRangeCb);
            this.Controls.Add(this.timeScaleCb);

            this.Name = "chartTiming";
            this.Size = new System.Drawing.Size(365, 24);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TextBox commonNameEd;
        protected cbTimeScale timeScaleCb;
        protected cbTimeRange timeRangeCb;
    }
}
