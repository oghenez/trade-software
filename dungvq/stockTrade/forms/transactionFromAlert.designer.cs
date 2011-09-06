namespace stockTrade.forms
{
    partial class transactionFromAlert
    {

        //common.libs.appAvailable myAvail = new common.libs.appAvailable();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(transactionFromAlert));
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.myTransactionsTbl)).BeginInit();
            this.editGB1.SuspendLayout();
            this.editGB2.SuspendLayout();
            this.SuspendLayout();
            // 
            // stockCodeEd
            // 
            this.stockCodeEd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // codeEd
            // 
            this.codeEd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // onTimeEd
            // 
            this.onTimeEd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // totalAmtEd
            // 
            this.totalAmtEd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // feePercEd
            // 
            this.feePercEd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // qtyEd
            // 
            this.qtyEd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // priceEd
            // 
            this.priceEd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // feeAmtEd
            // 
            this.feeAmtEd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // subTotalEd
            // 
            this.subTotalEd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // editGB2
            // 
            this.editGB2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editGB2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editGB2.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "tickerCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // tradeOrderNewFromAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 377);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "tradeOrderNewFromAlert";
            ((System.ComponentModel.ISupportInitialize)(this.myTransactionsTbl)).EndInit();
            this.editGB1.ResumeLayout(false);
            this.editGB1.PerformLayout();
            this.editGB2.ResumeLayout(false);
            this.editGB2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

    }
}