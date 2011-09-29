namespace Trade.Forms
{
    partial class marketWatch
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
            this.stockCodeList = new baseClass.controls.stockCodeSelectByWatchList();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(930, 150);
            this.TitleLbl.Size = new System.Drawing.Size(312, 46);
            this.TitleLbl.Visible = false;
            // 
            // stockCodeList
            // 
            this.stockCodeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stockCodeList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeList.Location = new System.Drawing.Point(0, 0);
            this.stockCodeList.Margin = new System.Windows.Forms.Padding(2);
            this.stockCodeList.Name = "stockCodeList";
            this.stockCodeList.Size = new System.Drawing.Size(255, 909);
            this.stockCodeList.TabIndex = 145;
            this.stockCodeList.myOnError += new common.myEventHandler(this.stockCodeList_myOnError);
            // 
            // marketWatch
            // 
            this.ClientSize = new System.Drawing.Size(253, 933);
            this.Controls.Add(this.stockCodeList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "marketWatch";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.stockCodeList, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.stockCodeSelectByWatchList stockCodeList;

    }
}
