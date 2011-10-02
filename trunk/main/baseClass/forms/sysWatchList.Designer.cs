namespace baseClass.forms
{
    partial class sysWatchList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sysWatchList));
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).BeginInit();
            this.xpPanel_options.SuspendLayout();
            this.xpPane_generalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).BeginInit();
            this.xpPanelGroup_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpPanel_options
            // 
            this.xpPanel_options.ImageItems.ImageSet = null;
            this.xpPanel_options.Size = new System.Drawing.Size(563, 466);
            // 
            // interestedStockClb
            // 
            this.interestedStockClb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.interestedStockClb.Size = new System.Drawing.Size(534, 404);
            // 
            // interestedStrategy
            // 
            this.interestedStrategy.Location = new System.Drawing.Point(600, 138);
            this.interestedStrategy.Size = new System.Drawing.Size(537, 308);
            this.interestedStrategy.Visible = false;
            // 
            // xpPane_generalInfo
            // 
            this.xpPane_generalInfo.ImageItems.ImageSet = null;
            // 
            // xpPanelGroup_Info
            // 
            this.xpPanelGroup_Info.Size = new System.Drawing.Size(563, 630);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Text = "&Lock";
            // 
            // sysWatchList
            // 
            this.ClientSize = new System.Drawing.Size(877, 703);
            this.Name = "sysWatchList";
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).EndInit();
            this.xpPanel_options.ResumeLayout(false);
            this.xpPanel_options.PerformLayout();
            this.xpPane_generalInfo.ResumeLayout(false);
            this.xpPane_generalInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).EndInit();
            this.xpPanelGroup_Info.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
