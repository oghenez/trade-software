namespace baseClass.Forms
{
    partial class addToWatchList_StockOnly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addToWatchList_StockOnly));
            this.codeLbl = new baseClass.controls.baseLabel();
            this.stockCodeEd = new common.controls.baseTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // addToLbl
            // 
            this.addToLbl.Size = new System.Drawing.Size(119, 16);
            this.addToLbl.Text = "Add to watch list";
            // 
            // watchListLb
            // 
            this.watchListLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.watchListLb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("watchListLb.myCheckedItems")));
            this.watchListLb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("watchListLb.myCheckedValues")));
            this.watchListLb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("watchListLb.myItemValues")));
            this.watchListLb.Size = new System.Drawing.Size(274, 94);
            // 
            // newWatchListBtn
            // 
            this.newWatchListBtn.Location = new System.Drawing.Point(112, 189);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(202, 189);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(22, 189);
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(18, 123);
            this.codeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(63, 16);
            this.codeLbl.TabIndex = 313;
            this.codeLbl.Text = "Code list";
            // 
            // stockCodeEd
            // 
            this.stockCodeEd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stockCodeEd.Location = new System.Drawing.Point(21, 142);
            this.stockCodeEd.Multiline = true;
            this.stockCodeEd.Name = "stockCodeEd";
            this.stockCodeEd.ReadOnly = true;
            this.stockCodeEd.Size = new System.Drawing.Size(271, 37);
            this.stockCodeEd.TabIndex = 2;
            this.stockCodeEd.TabStop = false;
            // 
            // addToWatchList_StockOnly
            // 
            this.ClientSize = new System.Drawing.Size(310, 245);
            this.Controls.Add(this.stockCodeEd);
            this.Controls.Add(this.codeLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addToWatchList_StockOnly";
            this.Controls.SetChildIndex(this.newWatchListBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.addToLbl, 0);
            this.Controls.SetChildIndex(this.watchListLb, 0);
            this.Controls.SetChildIndex(this.codeLbl, 0);
            this.Controls.SetChildIndex(this.stockCodeEd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseLabel codeLbl;
        private common.controls.baseTextBox stockCodeEd;
    }
}
