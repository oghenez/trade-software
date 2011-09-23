namespace stock.forms
{
    partial class backTesting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(backTesting));
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.optionPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateRangeLbl
            // 
            this.dateRangeLbl.Location = new System.Drawing.Point(22, 6);
            // 
            // dateRangeEd
            // 
            this.dateRangeEd.Location = new System.Drawing.Point(21, 25);
            // 
            // stockCodeSelect
            // 
            this.stockCodeSelect.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeSelect.myCheckedValues")));
            this.stockCodeSelect.Size = new System.Drawing.Size(399, 365);
            // 
            // strategyLbl
            // 
            this.strategyLbl.Location = new System.Drawing.Point(22, 55);
            // 
            // strategyClb
            // 
            this.strategyClb.Location = new System.Drawing.Point(21, 73);
            this.strategyClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("strategyClb.myCheckedValues")));
            this.strategyClb.Size = new System.Drawing.Size(392, 156);
            // 
            // stockCodeLbl
            // 
            this.stockCodeLbl.Location = new System.Drawing.Point(21, 235);
            // 
            // stockCodeOptionCb
            // 
            this.stockCodeOptionCb.Size = new System.Drawing.Size(127, 26);
            // 
            // backTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(440, 710);
            this.Name = "backTesting";
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.optionPnl.ResumeLayout(false);
            this.optionPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
