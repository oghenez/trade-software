namespace baseClass.Forms
{
    partial class baseAddToWatchList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseAddToWatchList));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.newWatchListBtn = new common.controls.baseButton();
            this.addToLbl = new baseClass.controls.baseLabel();
            this.watchListLb = new baseClass.controls.clbWatchList();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.Location = new System.Drawing.Point(201, 216);
            this.closeBtn.Size = new System.Drawing.Size(90, 26);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(21, 216);
            this.okBtn.Size = new System.Drawing.Size(90, 26);
            this.okBtn.Text = "Ok";
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(560, 68);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // newWatchListBtn
            // 
            this.newWatchListBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newWatchListBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newWatchListBtn.Image = global::baseClass.Properties.Resources.adddata;
            this.newWatchListBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.newWatchListBtn.isDownState = false;
            this.newWatchListBtn.Location = new System.Drawing.Point(111, 216);
            this.newWatchListBtn.Name = "newWatchListBtn";
            this.newWatchListBtn.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.newWatchListBtn.Size = new System.Drawing.Size(90, 26);
            this.newWatchListBtn.TabIndex = 101;
            this.newWatchListBtn.Text = "New";
            this.newWatchListBtn.UseVisualStyleBackColor = true;
            this.newWatchListBtn.Click += new System.EventHandler(this.newWatchListBtn_Click);
            // 
            // addToLbl
            // 
            this.addToLbl.AutoSize = true;
            this.addToLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToLbl.Location = new System.Drawing.Point(18, 4);
            this.addToLbl.Name = "addToLbl";
            this.addToLbl.Size = new System.Drawing.Size(52, 16);
            this.addToLbl.TabIndex = 312;
            this.addToLbl.Text = "Add to";
            // 
            // watchListLb
            // 
            this.watchListLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.watchListLb.CheckOnClick = true;
            this.watchListLb.FormattingEnabled = true;
            this.watchListLb.Location = new System.Drawing.Point(18, 23);
            this.watchListLb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("watchListLb.myCheckedItems")));
            this.watchListLb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("watchListLb.myCheckedValues")));
            this.watchListLb.myItemString = "";
            this.watchListLb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("watchListLb.myItemValues")));
            this.watchListLb.Name = "watchListLb";
            this.watchListLb.ShowCheckedOnly = false;
            this.watchListLb.Size = new System.Drawing.Size(274, 184);
            this.watchListLb.TabIndex = 1;
            this.watchListLb.WatchType = commonTypes.AppTypes.PortfolioTypes.Portfolio;
            // 
            // baseAddToWatchList
            // 
            this.ClientSize = new System.Drawing.Size(310, 270);
            this.Controls.Add(this.watchListLb);
            this.Controls.Add(this.addToLbl);
            this.Controls.Add(this.newWatchListBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "baseAddToWatchList";
            this.Text = "Add to watch list";
            this.myOnProcess += new common.forms.baseDialogForm.onProcess(this.Form_myOnProcess);
            this.Controls.SetChildIndex(this.newWatchListBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.addToLbl, 0);
            this.Controls.SetChildIndex(this.watchListLb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseLabel addToLbl;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        protected baseClass.controls.clbWatchList watchListLb;
        protected common.controls.baseButton newWatchListBtn;
    }
}
