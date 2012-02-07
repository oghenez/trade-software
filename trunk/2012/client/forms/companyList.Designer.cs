namespace client.forms
{
    partial class companyList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(companyList));
            this.findPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).BeginInit();
            this.xpPanelGroup_Info.SuspendLayout();
            this.xpPanel_OtherInfo.SuspendLayout();
            this.xpPanel_StockInfo.SuspendLayout();
            this.xpPanel_GeneralInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeFindBtn
            // 
            this.closeFindBtn.Location = new System.Drawing.Point(436, 59);
            this.closeFindBtn.Text = "Close";
            // 
            // filterBtn
            // 
            this.filterBtn.Location = new System.Drawing.Point(436, 24);
            this.filterBtn.Text = "Find";
            // 
            // findCriteria
            // 
            this.findCriteria.Location = new System.Drawing.Point(28, 3);
            // 
            // findPnl
            // 
            this.findPnl.Location = new System.Drawing.Point(499, 591);
            this.findPnl.Size = new System.Drawing.Size(586, 116);
            // 
            // xpPanelGroup_Info
            // 
            this.xpPanelGroup_Info.Size = new System.Drawing.Size(500, 669);
            // 
            // xpPanel_OtherInfo
            // 
            this.xpPanel_OtherInfo.ImageItems.ImageSet = null;
            this.xpPanel_OtherInfo.Size = new System.Drawing.Size(483, 207);
            // 
            // companyOtherInfo
            // 
            this.companyOtherInfo.Location = new System.Drawing.Point(29, 27);
            this.companyOtherInfo.Size = new System.Drawing.Size(434, 171);
            // 
            // xpPanel_StockInfo
            // 
            this.xpPanel_StockInfo.ImageItems.ImageSet = null;
            this.xpPanel_StockInfo.Size = new System.Drawing.Size(483, 181);
            // 
            // xpPanel_GeneralInfo
            // 
            this.xpPanel_GeneralInfo.ImageItems.ImageSet = null;
            this.xpPanel_GeneralInfo.Size = new System.Drawing.Size(483, 355);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Text = "Lock";
            // 
            // unLockBtn
            // 
            this.unLockBtn.Location = new System.Drawing.Point(462, 296);
            this.unLockBtn.Margin = new System.Windows.Forms.Padding(3);
            this.unLockBtn.Size = new System.Drawing.Size(27, 20);
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(462, 262);
            this.lockBtn.Margin = new System.Windows.Forms.Padding(3);
            this.lockBtn.Size = new System.Drawing.Size(22, 21);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(964, 122);
            this.TitleLbl.Size = new System.Drawing.Size(87, 20);
            // 
            // companyList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1074, 740);
            this.Name = "companyList";
            this.Text = "Company list";
            this.findPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).EndInit();
            this.xpPanelGroup_Info.ResumeLayout(false);
            this.xpPanel_OtherInfo.ResumeLayout(false);
            this.xpPanel_StockInfo.ResumeLayout(false);
            this.xpPanel_GeneralInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}