namespace Tools.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addToWatchList_StockOnly));
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // watchListLb
            // 
            this.watchListLb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("watchListLb.myCheckedItems")));
            this.watchListLb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("watchListLb.myCheckedValues")));
            this.watchListLb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("watchListLb.myItemValues")));
            // 
            // addToWatchList
            // 
            this.ClientSize = new System.Drawing.Size(322, 275);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addToWatchList";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
