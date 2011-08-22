namespace client.forms
{
    partial class tradeAnalysis
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
            this.toolPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.SuspendLayout();
            this.toolPnl.Controls.SetChildIndex(this.resetBtn, 0);
            this.toolPnl.Controls.SetChildIndex(this.cbStrategy, 0);
            this.toolPnl.Controls.SetChildIndex(this.chartTiming, 0);
            this.toolPnl.Controls.SetChildIndex(this.tradeEstimateBtn, 0);
            // 
            // stockChart
            // 
            this.stockChart.BorderSkin.BackColor = System.Drawing.Color.White;
            this.stockChart.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            // 
            // resetBtn
            // 
            this.myToolTip.SetToolTip(this.resetBtn, "Làm lại");
            // 
            // tradeEstimateBtn
            // 
            this.myToolTip.SetToolTip(this.tradeEstimateBtn, "Đánh giá");
            // 
            // tradeAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(970, 610);
            this.Name = "tradeAnalysis";
            this.toolPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
