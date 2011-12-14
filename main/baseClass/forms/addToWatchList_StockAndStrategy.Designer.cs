namespace baseClass.Forms
{
    partial class addToWatchList_StockAndStrategy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addToWatchList_StockAndStrategy));
            this.strategyLbl = new baseClass.controls.baseLabel();
            this.strategyLb = new common.controls.baseListBox();
            this.timeScaleCb = new baseClass.controls.cbTimeScale();
            this.timeScaleLbl = new baseClass.controls.baseLabel();
            this.codeLbl = new baseClass.controls.baseLabel();
            this.codeEd = new common.controls.baseTextBox();
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
            this.watchListLb.Size = new System.Drawing.Size(333, 94);
            // 
            // newWatchListBtn
            // 
            this.newWatchListBtn.Location = new System.Drawing.Point(171, 292);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(261, 292);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(81, 292);
            // 
            // strategyLbl
            // 
            this.strategyLbl.AutoSize = true;
            this.strategyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.strategyLbl.Location = new System.Drawing.Point(18, 165);
            this.strategyLbl.Name = "strategyLbl";
            this.strategyLbl.Size = new System.Drawing.Size(66, 16);
            this.strategyLbl.TabIndex = 314;
            this.strategyLbl.Text = "Strategy";
            // 
            // strategyLb
            // 
            this.strategyLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.strategyLb.FormattingEnabled = true;
            this.strategyLb.ItemHeight = 16;
            this.strategyLb.Location = new System.Drawing.Point(18, 182);
            this.strategyLb.myItemString = "";
            this.strategyLb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("strategyLb.myItemValues")));
            this.strategyLb.Name = "strategyLb";
            this.strategyLb.Size = new System.Drawing.Size(333, 84);
            this.strategyLb.TabIndex = 20;
            this.strategyLb.TabStop = false;
            // 
            // timeScaleCb
            // 
            this.timeScaleCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.timeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeScaleCb.FormattingEnabled = true;
            this.timeScaleCb.Location = new System.Drawing.Point(190, 140);
            this.timeScaleCb.Name = "timeScaleCb";
            this.timeScaleCb.Size = new System.Drawing.Size(162, 24);
            this.timeScaleCb.TabIndex = 11;
            // 
            // timeScaleLbl
            // 
            this.timeScaleLbl.AutoSize = true;
            this.timeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeScaleLbl.Location = new System.Drawing.Point(190, 121);
            this.timeScaleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeScaleLbl.Name = "timeScaleLbl";
            this.timeScaleLbl.Size = new System.Drawing.Size(74, 16);
            this.timeScaleLbl.TabIndex = 328;
            this.timeScaleLbl.Text = "Time scale";
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(15, 120);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(40, 16);
            this.codeLbl.TabIndex = 329;
            this.codeLbl.Text = "Code";
            // 
            // codeEd
            // 
            this.codeEd.Location = new System.Drawing.Point(19, 140);
            this.codeEd.Name = "codeEd";
            this.codeEd.ReadOnly = true;
            this.codeEd.Size = new System.Drawing.Size(171, 23);
            this.codeEd.TabIndex = 10;
            this.codeEd.TabStop = false;
            // 
            // addToWatchList_StockAndStrategy
            // 
            this.ClientSize = new System.Drawing.Size(372, 346);
            this.Controls.Add(this.codeEd);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.timeScaleLbl);
            this.Controls.Add(this.timeScaleCb);
            this.Controls.Add(this.strategyLb);
            this.Controls.Add(this.strategyLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addToWatchList_StockAndStrategy";
            this.Controls.SetChildIndex(this.newWatchListBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.addToLbl, 0);
            this.Controls.SetChildIndex(this.watchListLb, 0);
            this.Controls.SetChildIndex(this.strategyLbl, 0);
            this.Controls.SetChildIndex(this.strategyLb, 0);
            this.Controls.SetChildIndex(this.timeScaleCb, 0);
            this.Controls.SetChildIndex(this.timeScaleLbl, 0);
            this.Controls.SetChildIndex(this.codeLbl, 0);
            this.Controls.SetChildIndex(this.codeEd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseLabel strategyLbl;
        private common.controls.baseListBox strategyLb;
        protected baseClass.controls.cbTimeScale timeScaleCb;
        protected baseClass.controls.baseLabel timeScaleLbl;
        protected baseClass.controls.baseLabel codeLbl;
        private common.controls.baseTextBox codeEd;
    }
}
