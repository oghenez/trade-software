namespace baseClass.controls
{
    partial class companyStockInfo
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
            this.stockCodeEd = new common.controls.baseTextBox();
            this.tickerCodeEd = new common.controls.baseTextBox();
            this.regDateEd = new common.controls.baseDate();
            this.targetPriceEd = new common.controls.numberTextBox();
            this.targetPriceVariantEd = new common.controls.numberTextBox();
            this.treasuryStockEd = new common.controls.numberTextBox();
            this.foreignOwnStockEd = new common.controls.numberTextBox();
            this.bookPriceEd = new common.controls.numberTextBox();
            this.bookPriceLbl = new baseClass.controls.baseLabel();
            this.treasuryStockLbl = new baseClass.controls.baseLabel();
            this.outstandingStockLbl = new baseClass.controls.baseLabel();
            this.targetPriceVariantLbl = new baseClass.controls.baseLabel();
            this.targetPriceLbl = new baseClass.controls.baseLabel();
            this.foreignOwnStockLbl = new baseClass.controls.baseLabel();
            this.statusCb = new baseClass.controls.cbStockStatus();
            this.statusLblb = new baseClass.controls.baseLabel();
            this.noListedStockLbl = new baseClass.controls.baseLabel();
            this.regDateLbl = new baseClass.controls.baseLabel();
            this.tickerCodeLbl = new baseClass.controls.baseLabel();
            this.stockCodeLbl = new baseClass.controls.baseLabel();
            this.stockMarketCb = new baseClass.controls.cbStockExchange();
            this.stockMarketLbl = new baseClass.controls.baseLabel();
            this.listedStockEd = new common.controls.numberTextBox();
            this.outstandingStockEd = new common.controls.numberTextBox();
            this.SuspendLayout();
            // 
            // stockCodeEd
            // 
            this.stockCodeEd.BackColor = System.Drawing.SystemColors.Window;
            this.stockCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeEd.Location = new System.Drawing.Point(-1, 19);
            this.stockCodeEd.Name = "stockCodeEd";
            this.stockCodeEd.Size = new System.Drawing.Size(122, 24);
            this.stockCodeEd.TabIndex = 1;
            // 
            // tickerCodeEd
            // 
            this.tickerCodeEd.BackColor = System.Drawing.SystemColors.Window;
            this.tickerCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickerCodeEd.Location = new System.Drawing.Point(320, 19);
            this.tickerCodeEd.Name = "tickerCodeEd";
            this.tickerCodeEd.Size = new System.Drawing.Size(121, 24);
            this.tickerCodeEd.TabIndex = 3;
            // 
            // regDateEd
            // 
            this.regDateEd.BackColor = System.Drawing.SystemColors.Window;
            this.regDateEd.BeepOnError = true;
            this.regDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.regDateEd.Location = new System.Drawing.Point(251, 118);
            this.regDateEd.Mask = "00/00/0000";
            this.regDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.regDateEd.Name = "regDateEd";
            this.regDateEd.Size = new System.Drawing.Size(102, 24);
            this.regDateEd.TabIndex = 53;
            // 
            // targetPriceEd
            // 
            this.targetPriceEd.BackColor = System.Drawing.SystemColors.Window;
            this.targetPriceEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPriceEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.targetPriceEd.Location = new System.Drawing.Point(113, 118);
            this.targetPriceEd.myFormat = "###,###,###.##";
            this.targetPriceEd.Name = "targetPriceEd";
            this.targetPriceEd.Size = new System.Drawing.Size(107, 24);
            this.targetPriceEd.TabIndex = 51;
            this.targetPriceEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.targetPriceEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.targetPriceEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // targetPriceVariantEd
            // 
            this.targetPriceVariantEd.BackColor = System.Drawing.SystemColors.Window;
            this.targetPriceVariantEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPriceVariantEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.targetPriceVariantEd.Location = new System.Drawing.Point(220, 118);
            this.targetPriceVariantEd.myFormat = "##";
            this.targetPriceVariantEd.Name = "targetPriceVariantEd";
            this.targetPriceVariantEd.Size = new System.Drawing.Size(31, 24);
            this.targetPriceVariantEd.TabIndex = 52;
            this.targetPriceVariantEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.targetPriceVariantEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.targetPriceVariantEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // treasuryStockEd
            // 
            this.treasuryStockEd.BackColor = System.Drawing.SystemColors.Window;
            this.treasuryStockEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treasuryStockEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.treasuryStockEd.Location = new System.Drawing.Point(221, 68);
            this.treasuryStockEd.myFormat = "###,###,###,###,###";
            this.treasuryStockEd.Name = "treasuryStockEd";
            this.treasuryStockEd.Size = new System.Drawing.Size(111, 24);
            this.treasuryStockEd.TabIndex = 12;
            this.treasuryStockEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.treasuryStockEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.treasuryStockEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // foreignOwnStockEd
            // 
            this.foreignOwnStockEd.BackColor = System.Drawing.SystemColors.Window;
            this.foreignOwnStockEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreignOwnStockEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.foreignOwnStockEd.Location = new System.Drawing.Point(332, 68);
            this.foreignOwnStockEd.myFormat = "###,###,###,###,###";
            this.foreignOwnStockEd.Name = "foreignOwnStockEd";
            this.foreignOwnStockEd.Size = new System.Drawing.Size(111, 24);
            this.foreignOwnStockEd.TabIndex = 13;
            this.foreignOwnStockEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.foreignOwnStockEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.foreignOwnStockEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // bookPriceEd
            // 
            this.bookPriceEd.BackColor = System.Drawing.SystemColors.Window;
            this.bookPriceEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookPriceEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.bookPriceEd.Location = new System.Drawing.Point(0, 118);
            this.bookPriceEd.myFormat = "###,###,###.##";
            this.bookPriceEd.Name = "bookPriceEd";
            this.bookPriceEd.Size = new System.Drawing.Size(112, 24);
            this.bookPriceEd.TabIndex = 50;
            this.bookPriceEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bookPriceEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.bookPriceEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // bookPriceLbl
            // 
            this.bookPriceLbl.AutoSize = true;
            this.bookPriceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookPriceLbl.Location = new System.Drawing.Point(1, 98);
            this.bookPriceLbl.Name = "bookPriceLbl";
            this.bookPriceLbl.Size = new System.Drawing.Size(75, 16);
            this.bookPriceLbl.TabIndex = 332;
            this.bookPriceLbl.Text = "Book price";
            // 
            // treasuryStockLbl
            // 
            this.treasuryStockLbl.AutoSize = true;
            this.treasuryStockLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treasuryStockLbl.Location = new System.Drawing.Point(221, 49);
            this.treasuryStockLbl.Name = "treasuryStockLbl";
            this.treasuryStockLbl.Size = new System.Drawing.Size(66, 16);
            this.treasuryStockLbl.TabIndex = 305;
            this.treasuryStockLbl.Text = "Treasury";
            // 
            // outstandingStockLbl
            // 
            this.outstandingStockLbl.AutoSize = true;
            this.outstandingStockLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outstandingStockLbl.Location = new System.Drawing.Point(107, 49);
            this.outstandingStockLbl.Name = "outstandingStockLbl";
            this.outstandingStockLbl.Size = new System.Drawing.Size(114, 16);
            this.outstandingStockLbl.TabIndex = 304;
            this.outstandingStockLbl.Text = "Outstanding Qty";
            // 
            // targetPriceVariantLbl
            // 
            this.targetPriceVariantLbl.AutoSize = true;
            this.targetPriceVariantLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPriceVariantLbl.Location = new System.Drawing.Point(213, 98);
            this.targetPriceVariantLbl.Name = "targetPriceVariantLbl";
            this.targetPriceVariantLbl.Size = new System.Drawing.Size(33, 16);
            this.targetPriceVariantLbl.TabIndex = 272;
            this.targetPriceVariantLbl.Text = "+/-";
            // 
            // targetPriceLbl
            // 
            this.targetPriceLbl.AutoSize = true;
            this.targetPriceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPriceLbl.Location = new System.Drawing.Point(114, 100);
            this.targetPriceLbl.Name = "targetPriceLbl";
            this.targetPriceLbl.Size = new System.Drawing.Size(87, 16);
            this.targetPriceLbl.TabIndex = 270;
            this.targetPriceLbl.Text = "Target price";
            // 
            // foreignOwnStockLbl
            // 
            this.foreignOwnStockLbl.AutoSize = true;
            this.foreignOwnStockLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foreignOwnStockLbl.Location = new System.Drawing.Point(336, 49);
            this.foreignOwnStockLbl.Name = "foreignOwnStockLbl";
            this.foreignOwnStockLbl.Size = new System.Drawing.Size(104, 16);
            this.foreignOwnStockLbl.TabIndex = 268;
            this.foreignOwnStockLbl.Text = "Foreign-owned";
            // 
            // statusCb
            // 
            this.statusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCb.FormattingEnabled = true;
            this.statusCb.Location = new System.Drawing.Point(354, 118);
            this.statusCb.Margin = new System.Windows.Forms.Padding(2);
            this.statusCb.myValue = application.AppTypes.CommonStatus.None;
            this.statusCb.Name = "statusCb";
            this.statusCb.SelectedValue = ((byte)(0));
            this.statusCb.Size = new System.Drawing.Size(89, 21);
            this.statusCb.TabIndex = 54;
            // 
            // statusLblb
            // 
            this.statusLblb.AutoSize = true;
            this.statusLblb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLblb.Location = new System.Drawing.Point(354, 100);
            this.statusLblb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLblb.Name = "statusLblb";
            this.statusLblb.Size = new System.Drawing.Size(51, 16);
            this.statusLblb.TabIndex = 266;
            this.statusLblb.Text = "Status";
            // 
            // noListedStockLbl
            // 
            this.noListedStockLbl.AutoSize = true;
            this.noListedStockLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noListedStockLbl.Location = new System.Drawing.Point(1, 49);
            this.noListedStockLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noListedStockLbl.Name = "noListedStockLbl";
            this.noListedStockLbl.Size = new System.Drawing.Size(74, 16);
            this.noListedStockLbl.TabIndex = 262;
            this.noListedStockLbl.Text = "Listed Qty";
            // 
            // regDateLbl
            // 
            this.regDateLbl.AutoSize = true;
            this.regDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regDateLbl.Location = new System.Drawing.Point(253, 100);
            this.regDateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.regDateLbl.Name = "regDateLbl";
            this.regDateLbl.Size = new System.Drawing.Size(72, 16);
            this.regDateLbl.TabIndex = 260;
            this.regDateLbl.Text = "Reg. Date";
            // 
            // tickerCodeLbl
            // 
            this.tickerCodeLbl.AutoSize = true;
            this.tickerCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickerCodeLbl.Location = new System.Drawing.Point(322, 1);
            this.tickerCodeLbl.Name = "tickerCodeLbl";
            this.tickerCodeLbl.Size = new System.Drawing.Size(46, 16);
            this.tickerCodeLbl.TabIndex = 256;
            this.tickerCodeLbl.Text = "Ticker";
            // 
            // stockCodeLbl
            // 
            this.stockCodeLbl.AutoSize = true;
            this.stockCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeLbl.Location = new System.Drawing.Point(1, 1);
            this.stockCodeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stockCodeLbl.Name = "stockCodeLbl";
            this.stockCodeLbl.Size = new System.Drawing.Size(40, 16);
            this.stockCodeLbl.TabIndex = 254;
            this.stockCodeLbl.Text = "Code";
            // 
            // stockMarketCb
            // 
            this.stockMarketCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockMarketCb.FormattingEnabled = true;
            this.stockMarketCb.Location = new System.Drawing.Point(121, 19);
            this.stockMarketCb.Margin = new System.Windows.Forms.Padding(2);
            this.stockMarketCb.myValue = "";
            this.stockMarketCb.Name = "stockMarketCb";
            this.stockMarketCb.Size = new System.Drawing.Size(201, 21);
            this.stockMarketCb.TabIndex = 2;
            // 
            // stockMarketLbl
            // 
            this.stockMarketLbl.AutoSize = true;
            this.stockMarketLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockMarketLbl.Location = new System.Drawing.Point(124, 1);
            this.stockMarketLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stockMarketLbl.Name = "stockMarketLbl";
            this.stockMarketLbl.Size = new System.Drawing.Size(69, 16);
            this.stockMarketLbl.TabIndex = 252;
            this.stockMarketLbl.Text = "Exchange";
            // 
            // listedStockEd
            // 
            this.listedStockEd.BackColor = System.Drawing.SystemColors.Window;
            this.listedStockEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listedStockEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.listedStockEd.Location = new System.Drawing.Point(-1, 68);
            this.listedStockEd.myFormat = "###,###,###,###,###";
            this.listedStockEd.Name = "listedStockEd";
            this.listedStockEd.Size = new System.Drawing.Size(111, 24);
            this.listedStockEd.TabIndex = 10;
            this.listedStockEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.listedStockEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.listedStockEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // outstandingStockEd
            // 
            this.outstandingStockEd.BackColor = System.Drawing.SystemColors.Window;
            this.outstandingStockEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outstandingStockEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.outstandingStockEd.Location = new System.Drawing.Point(110, 68);
            this.outstandingStockEd.myFormat = "###,###,###,###,###";
            this.outstandingStockEd.Name = "outstandingStockEd";
            this.outstandingStockEd.Size = new System.Drawing.Size(111, 24);
            this.outstandingStockEd.TabIndex = 11;
            this.outstandingStockEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.outstandingStockEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.outstandingStockEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // companyStockInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.bookPriceEd);
            this.Controls.Add(this.bookPriceLbl);
            this.Controls.Add(this.treasuryStockLbl);
            this.Controls.Add(this.outstandingStockLbl);
            this.Controls.Add(this.treasuryStockEd);
            this.Controls.Add(this.foreignOwnStockEd);
            this.Controls.Add(this.targetPriceVariantEd);
            this.Controls.Add(this.targetPriceVariantLbl);
            this.Controls.Add(this.targetPriceEd);
            this.Controls.Add(this.targetPriceLbl);
            this.Controls.Add(this.outstandingStockEd);
            this.Controls.Add(this.foreignOwnStockLbl);
            this.Controls.Add(this.statusCb);
            this.Controls.Add(this.statusLblb);
            this.Controls.Add(this.listedStockEd);
            this.Controls.Add(this.noListedStockLbl);
            this.Controls.Add(this.regDateEd);
            this.Controls.Add(this.regDateLbl);
            this.Controls.Add(this.tickerCodeEd);
            this.Controls.Add(this.tickerCodeLbl);
            this.Controls.Add(this.stockCodeEd);
            this.Controls.Add(this.stockCodeLbl);
            this.Controls.Add(this.stockMarketCb);
            this.Controls.Add(this.stockMarketLbl);
            this.Name = "companyStockInfo";
            this.Size = new System.Drawing.Size(441, 139);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseLabel stockMarketLbl;
        protected common.controls.baseTextBox stockCodeEd;
        protected baseLabel stockCodeLbl;
        protected controls.cbStockExchange stockMarketCb;
        protected common.controls.baseTextBox tickerCodeEd;
        protected baseLabel tickerCodeLbl;
        protected common.controls.baseDate regDateEd;
        protected baseLabel regDateLbl;
        protected baseLabel noListedStockLbl;
        protected cbStockStatus statusCb;
        protected baseLabel statusLblb;
        protected baseLabel foreignOwnStockLbl;
        protected common.controls.numberTextBox targetPriceEd;
        protected baseLabel targetPriceLbl;
        protected common.controls.numberTextBox targetPriceVariantEd;
        protected baseLabel targetPriceVariantLbl;
        protected common.controls.numberTextBox treasuryStockEd;
        protected common.controls.numberTextBox foreignOwnStockEd;
        protected baseLabel outstandingStockLbl;
        protected baseLabel treasuryStockLbl;
        protected common.controls.numberTextBox bookPriceEd;
        protected baseLabel bookPriceLbl;
        protected common.controls.numberTextBox listedStockEd;
        protected common.controls.numberTextBox outstandingStockEd;
    }
}
