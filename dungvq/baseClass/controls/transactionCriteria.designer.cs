namespace baseClass.controls
{
    partial class transactionCriteria
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
            this.stockCodeEd = new common.control.baseTextBox();
            this.stockExchangeChk = new baseClass.controls.baseCheckBox();
            this.stockCodeChk = new baseClass.controls.baseCheckBox();
            this.stockExchangeCb = new baseClass.controls.cbStockExchange();
            this.dateRange = new common.control.dateRange2();
            this.dummyLbl = new System.Windows.Forms.Label();
            this.dateRangeChk = new baseClass.controls.baseCheckBox();
            this.portfolioChk = new common.control.baseCheckBox();
            this.portfolioCb = new baseClass.controls.cbPortpolio();
            this.SuspendLayout();
            // 
            // stockCodeEd
            // 
            this.stockCodeEd.BackColor = System.Drawing.Color.White;
            this.stockCodeEd.Enabled = false;
            this.stockCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeEd.ForeColor = System.Drawing.Color.Black;
            this.stockCodeEd.Location = new System.Drawing.Point(392, 22);
            this.stockCodeEd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockCodeEd.Name = "stockCodeEd";
            this.stockCodeEd.Size = new System.Drawing.Size(91, 24);
            this.stockCodeEd.TabIndex = 8;
            // 
            // stockExchangeChk
            // 
            this.stockExchangeChk.AutoSize = true;
            this.stockExchangeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockExchangeChk.Location = new System.Drawing.Point(291, -1);
            this.stockExchangeChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockExchangeChk.Name = "stockExchangeChk";
            this.stockExchangeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stockExchangeChk.Size = new System.Drawing.Size(51, 20);
            this.stockExchangeChk.TabIndex = 5;
            this.stockExchangeChk.Text = "Sàn";
            this.stockExchangeChk.UseVisualStyleBackColor = true;
            this.stockExchangeChk.CheckedChanged += new System.EventHandler(this.stockExchangeChk_CheckedChanged);
            // 
            // stockCodeChk
            // 
            this.stockCodeChk.AutoSize = true;
            this.stockCodeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeChk.Location = new System.Drawing.Point(389, -1);
            this.stockCodeChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockCodeChk.Name = "stockCodeChk";
            this.stockCodeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stockCodeChk.Size = new System.Drawing.Size(77, 20);
            this.stockCodeChk.TabIndex = 7;
            this.stockCodeChk.Text = "Mã hiệu";
            this.stockCodeChk.UseVisualStyleBackColor = true;
            this.stockCodeChk.CheckedChanged += new System.EventHandler(this.stockCodeChk_CheckedChanged);
            // 
            // stockExchangeCb
            // 
            this.stockExchangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockExchangeCb.Enabled = false;
            this.stockExchangeCb.FormattingEnabled = true;
            this.stockExchangeCb.Location = new System.Drawing.Point(292, 22);
            this.stockExchangeCb.Margin = new System.Windows.Forms.Padding(2);
            this.stockExchangeCb.myValue = "";
            this.stockExchangeCb.Name = "stockExchangeCb";
            this.stockExchangeCb.Size = new System.Drawing.Size(101, 24);
            this.stockExchangeCb.TabIndex = 6;
            // 
            // dateRange
            // 
            this.dateRange.Enabled = false;
            this.dateRange.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRange.Location = new System.Drawing.Point(131, 1);
            this.dateRange.Margin = new System.Windows.Forms.Padding(4);
            this.dateRange.Name = "dateRange";
            this.dateRange.Size = new System.Drawing.Size(160, 45);
            this.dateRange.TabIndex = 4;
            // 
            // dummyLbl
            // 
            this.dummyLbl.Location = new System.Drawing.Point(133, 3);
            this.dummyLbl.Name = "dummyLbl";
            this.dummyLbl.Size = new System.Drawing.Size(148, 18);
            this.dummyLbl.TabIndex = 8;
            // 
            // dateRangeChk
            // 
            this.dateRangeChk.AutoSize = true;
            this.dateRangeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRangeChk.Location = new System.Drawing.Point(129, 0);
            this.dateRangeChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateRangeChk.Name = "dateRangeChk";
            this.dateRangeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateRangeChk.Size = new System.Drawing.Size(84, 20);
            this.dateRangeChk.TabIndex = 3;
            this.dateRangeChk.Text = "Thời gian";
            this.dateRangeChk.UseVisualStyleBackColor = true;
            this.dateRangeChk.CheckedChanged += new System.EventHandler(this.dateRangeChk_CheckedChanged);
            // 
            // portfolioChk
            // 
            this.portfolioChk.AutoSize = true;
            this.portfolioChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioChk.Location = new System.Drawing.Point(4, 0);
            this.portfolioChk.Name = "portfolioChk";
            this.portfolioChk.Size = new System.Drawing.Size(82, 20);
            this.portfolioChk.TabIndex = 1;
            this.portfolioChk.Text = "Portfolio";
            this.portfolioChk.UseVisualStyleBackColor = true;
            this.portfolioChk.CheckedChanged += new System.EventHandler(this.portfolioChk_CheckedChanged);
            // 
            // portfolioCb
            // 
            this.portfolioCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portfolioCb.Enabled = false;
            this.portfolioCb.FormattingEnabled = true;
            this.portfolioCb.Location = new System.Drawing.Point(1, 22);
            this.portfolioCb.myValue = "";
            this.portfolioCb.Name = "portfolioCb";
            this.portfolioCb.Size = new System.Drawing.Size(131, 24);
            this.portfolioCb.TabIndex = 2;
            // 
            // transHistoryCriteria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.portfolioChk);
            this.Controls.Add(this.portfolioCb);
            this.Controls.Add(this.dateRangeChk);
            this.Controls.Add(this.dummyLbl);
            this.Controls.Add(this.dateRange);
            this.Controls.Add(this.stockExchangeChk);
            this.Controls.Add(this.stockExchangeCb);
            this.Controls.Add(this.stockCodeChk);
            this.Controls.Add(this.stockCodeEd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "transHistoryCriteria";
            this.Size = new System.Drawing.Size(483, 46);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox commonNameEd;
        protected baseCheckBox stockCodeChk;
        protected common.control.baseTextBox stockCodeEd;
        protected baseCheckBox stockExchangeChk;
        protected cbStockExchange stockExchangeCb;
        protected common.control.dateRange2 dateRange;
        private System.Windows.Forms.Label dummyLbl;
        protected baseCheckBox dateRangeChk;
        protected common.control.baseCheckBox portfolioChk;
        protected cbPortpolio portfolioCb;
    }
}
