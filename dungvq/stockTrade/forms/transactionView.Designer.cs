namespace stockTrade.forms
{
    partial class transactionView
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
            ((System.ComponentModel.ISupportInitialize)(this.myTransactionsTbl)).BeginInit();
            this.editGB1.SuspendLayout();
            this.editGB2.SuspendLayout();
            this.SuspendLayout();
            // 
            // portfolioCb
            // 
            this.portfolioCb.Enabled = false;
            // 
            // stockCodeEd
            // 
            this.stockCodeEd.ReadOnly = true;
            // 
            // transTypeCb
            // 
            this.transTypeCb.Enabled = false;
            // 
            // qtyEd
            // 
            this.qtyEd.ReadOnly = true;
            // 
            // transactionView
            // 
            this.ClientSize = new System.Drawing.Size(360, 363);
            this.Name = "transactionView";
            ((System.ComponentModel.ISupportInitialize)(this.myTransactionsTbl)).EndInit();
            this.editGB1.ResumeLayout(false);
            this.editGB1.PerformLayout();
            this.editGB2.ResumeLayout(false);
            this.editGB2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
