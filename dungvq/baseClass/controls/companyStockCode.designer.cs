namespace baseClass.controls
{
    partial class companyStockCode
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockCodeDetail = new baseClass.controls.stockCodeDetail();
            ((System.ComponentModel.ISupportInitialize)(this.gridDataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteLineBtn
            // 
            this.deleteLineBtn.Location = new System.Drawing.Point(270, 116);
            this.deleteLineBtn.Size = new System.Drawing.Size(58, 26);
            // 
            // addLineBtn
            // 
            this.addLineBtn.Location = new System.Drawing.Point(203, 116);
            this.addLineBtn.Size = new System.Drawing.Size(67, 26);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "schoolName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Trường";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "gradYear";
            this.dataGridViewTextBoxColumn2.HeaderText = "Năm TN";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // stockCodeDetail
            // 
            this.stockCodeDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeDetail.Location = new System.Drawing.Point(0, 0);
            this.stockCodeDetail.Name = "stockCodeDetail";
            this.stockCodeDetail.Size = new System.Drawing.Size(440, 142);
            this.stockCodeDetail.TabIndex = 1;
            // 
            // companyStockCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stockCodeDetail);
            this.Name = "companyStockCode";
            this.Size = new System.Drawing.Size(440, 230);
            this.Controls.SetChildIndex(this.stockCodeDetail, 0);
            this.Controls.SetChildIndex(this.addLineBtn, 0);
            this.Controls.SetChildIndex(this.deleteLineBtn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridDataSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private stockCodeDetail stockCodeDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;


    }
}
