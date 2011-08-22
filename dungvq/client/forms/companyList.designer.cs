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
            ((System.ComponentModel.ISupportInitialize)(this.companySource)).BeginInit();
            this.xpPanel_GeneralInfo.SuspendLayout();
            this.xpPanel_StockInfo.SuspendLayout();
            this.xpPanel_OtherInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).BeginInit();
            this.xpPanelGroup_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // companySource
            // 
            this.companySource.Position = 0;
            // 
            // xpPanel_GeneralInfo
            // 
            this.xpPanel_GeneralInfo.ImageItems.ImageSet = null;
            this.xpPanel_GeneralInfo.Size = new System.Drawing.Size(483, 375);
            // 
            // xpPanel_StockInfo
            // 
            this.xpPanel_StockInfo.ImageItems.ImageSet = null;
            this.xpPanel_StockInfo.Location = new System.Drawing.Point(0, 383);
            this.xpPanel_StockInfo.Size = new System.Drawing.Size(483, 245);
            // 
            // xpPanel_OtherInfo
            // 
            this.xpPanel_OtherInfo.ImageItems.ImageSet = null;
            this.xpPanel_OtherInfo.Location = new System.Drawing.Point(0, 636);
            this.xpPanel_OtherInfo.Size = new System.Drawing.Size(483, 287);
            // 
            // toolBox
            // 
            this.toolBox.Size = new System.Drawing.Size(502, 48);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(416, 3);
            this.exitBtn.Size = new System.Drawing.Size(83, 38);
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(1, 3);
            this.saveBtn.Size = new System.Drawing.Size(83, 38);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(84, 3);
            this.deleteBtn.Size = new System.Drawing.Size(83, 38);
            // 
            // editBtn
            // 
            this.editBtn.Enabled = false;
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(250, 3);
            this.editBtn.Size = new System.Drawing.Size(83, 38);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(701, 8);
            this.addNewBtn.Visible = false;
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(563, 2);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(167, 3);
            this.findBtn.Size = new System.Drawing.Size(83, 38);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(919, 9);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(333, 3);
            this.printBtn.Size = new System.Drawing.Size(83, 38);
            this.printBtn.Visible = true;
            // 
            // feCompanyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(962, 661);
            this.Name = "feCompanyList";
            this.findPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.companySource)).EndInit();
            this.xpPanel_GeneralInfo.ResumeLayout(false);
            this.xpPanel_StockInfo.ResumeLayout(false);
            this.xpPanel_OtherInfo.ResumeLayout(false);
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
