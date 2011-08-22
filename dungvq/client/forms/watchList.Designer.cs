namespace client.forms
{
    partial class watchList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(watchList));
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBarPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioListSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBarPnl
            // 
            this.toolBarPnl.Location = new System.Drawing.Point(-1, -3);
            this.toolBarPnl.Size = new System.Drawing.Size(1088, 30);
            this.toolBarPnl.Controls.SetChildIndex(this.refreshBtn, 0);
            this.toolBarPnl.Controls.SetChildIndex(this.porfolioCb, 0);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(213, 3);
            this.myToolTip.SetToolTip(this.refreshBtn, "Tải lại dữ liệu");
            // 
            // porfolioCb
            // 
            this.porfolioCb.Location = new System.Drawing.Point(0, 2);
            this.porfolioCb.Size = new System.Drawing.Size(212, 26);
            // 
            // watchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 443);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "watchList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Watch list";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBarPnl.ResumeLayout(false);
            this.toolBarPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioListSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}