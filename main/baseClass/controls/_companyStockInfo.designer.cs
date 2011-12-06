namespace baseClass.controls
{
    partial class _companyStockInfo
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
            this.listedStockEd = new common.controls.numberTextBox();
            this.outstandingStockEd = new common.controls.numberTextBox();
            this.targetPriceEd = new common.controls.numberTextBox();
            this.targetPriceVariantEd = new common.controls.numberTextBox();
            this.workingCapitalEd = new common.controls.numberTextBox();
            this.treasuryStockEd = new common.controls.numberTextBox();
            this.foreignOwnStockEd = new common.controls.numberTextBox();
            this.salesEd = new common.controls.numberTextBox();
            this.profitEd = new common.controls.numberTextBox();
            this.equityEd = new common.controls.numberTextBox();
            this.totalDebtEd = new common.controls.numberTextBox();
            this.totalAssetEd = new common.controls.numberTextBox();
            this.pricePerBookEd = new common.controls.numberTextBox();
            this.earnPerShareEd = new common.controls.numberTextBox();
            this.prixePerEarningEd = new common.controls.numberTextBox();
            this.roaEd = new common.controls.numberTextBox();
            this.roeEd = new common.controls.numberTextBox();
            this.betaEd = new common.controls.numberTextBox();
            this.bookPriceEd = new common.controls.numberTextBox();
            this.bookPriceLbl = new baseClass.controls.baseLabel();
            this.roaLbl = new baseClass.controls.baseLabel();
            this.roeLbl = new baseClass.controls.baseLabel();
            this.betaLbl = new baseClass.controls.baseLabel();
            this.pricePerBookLbl = new baseClass.controls.baseLabel();
            this.earnPerShareLbl = new baseClass.controls.baseLabel();
            this.prixePerEarningLbl = new baseClass.controls.baseLabel();
            this.baseLabel3 = new baseClass.controls.baseLabel();
            this.totalAssetLbl = new baseClass.controls.baseLabel();
            this.totalDebtLbl = new baseClass.controls.baseLabel();
            this.equityLbl = new baseClass.controls.baseLabel();
            this.profitLbl = new baseClass.controls.baseLabel();
            this.salesLbl = new baseClass.controls.baseLabel();
            this.treasuryStockLbl = new baseClass.controls.baseLabel();
            this.outstandingStockLbl = new baseClass.controls.baseLabel();
            this.capitalUnitCb = new baseClass.controls.cbCurrency();
            this.workingCapitalLbl = new baseClass.controls.baseLabel();
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
            this.regDateEd.Location = new System.Drawing.Point(250, 265);
            this.regDateEd.Mask = "00/00/0000";
            this.regDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.regDateEd.Name = "regDateEd";
            this.regDateEd.Size = new System.Drawing.Size(102, 24);
            this.regDateEd.TabIndex = 53;
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
            // targetPriceEd
            // 
            this.targetPriceEd.BackColor = System.Drawing.SystemColors.Window;
            this.targetPriceEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPriceEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.targetPriceEd.Location = new System.Drawing.Point(112, 265);
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
            this.targetPriceVariantEd.Location = new System.Drawing.Point(219, 265);
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
            // workingCapitalEd
            // 
            this.workingCapitalEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workingCapitalEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.workingCapitalEd.Location = new System.Drawing.Point(105, 119);
            this.workingCapitalEd.myFormat = "###,###,###,###,###";
            this.workingCapitalEd.Name = "workingCapitalEd";
            this.workingCapitalEd.Size = new System.Drawing.Size(115, 22);
            this.workingCapitalEd.TabIndex = 21;
            this.workingCapitalEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.workingCapitalEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.workingCapitalEd.Value = new decimal(new int[] {
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
            // salesEd
            // 
            this.salesEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.salesEd.Location = new System.Drawing.Point(235, 170);
            this.salesEd.myFormat = "###,###,###,###,###";
            this.salesEd.Name = "salesEd";
            this.salesEd.Size = new System.Drawing.Size(112, 22);
            this.salesEd.TabIndex = 32;
            this.salesEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.salesEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.salesEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // profitEd
            // 
            this.profitEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profitEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.profitEd.Location = new System.Drawing.Point(347, 170);
            this.profitEd.myFormat = "###,###,###,###,###";
            this.profitEd.Name = "profitEd";
            this.profitEd.Size = new System.Drawing.Size(91, 22);
            this.profitEd.TabIndex = 33;
            this.profitEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.profitEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.profitEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // equityEd
            // 
            this.equityEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equityEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.equityEd.Location = new System.Drawing.Point(220, 119);
            this.equityEd.myFormat = "###,###,###,###,###";
            this.equityEd.Name = "equityEd";
            this.equityEd.Size = new System.Drawing.Size(116, 22);
            this.equityEd.TabIndex = 22;
            this.equityEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.equityEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.equityEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // totalDebtEd
            // 
            this.totalDebtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDebtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.totalDebtEd.Location = new System.Drawing.Point(117, 170);
            this.totalDebtEd.myFormat = "###,###,###,###,###";
            this.totalDebtEd.Name = "totalDebtEd";
            this.totalDebtEd.Size = new System.Drawing.Size(118, 22);
            this.totalDebtEd.TabIndex = 31;
            this.totalDebtEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalDebtEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.totalDebtEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // totalAssetEd
            // 
            this.totalAssetEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAssetEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.totalAssetEd.Location = new System.Drawing.Point(-1, 170);
            this.totalAssetEd.myFormat = "###,###,###,###,###";
            this.totalAssetEd.Name = "totalAssetEd";
            this.totalAssetEd.Size = new System.Drawing.Size(118, 22);
            this.totalAssetEd.TabIndex = 30;
            this.totalAssetEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalAssetEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.totalAssetEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // pricePerBookEd
            // 
            this.pricePerBookEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pricePerBookEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.pricePerBookEd.Location = new System.Drawing.Point(-1, 217);
            this.pricePerBookEd.myFormat = "#,###.#0";
            this.pricePerBookEd.Name = "pricePerBookEd";
            this.pricePerBookEd.Size = new System.Drawing.Size(76, 22);
            this.pricePerBookEd.TabIndex = 40;
            this.pricePerBookEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pricePerBookEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.pricePerBookEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // earnPerShareEd
            // 
            this.earnPerShareEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.earnPerShareEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.earnPerShareEd.Location = new System.Drawing.Point(75, 217);
            this.earnPerShareEd.myFormat = "###,###";
            this.earnPerShareEd.Name = "earnPerShareEd";
            this.earnPerShareEd.Size = new System.Drawing.Size(76, 22);
            this.earnPerShareEd.TabIndex = 41;
            this.earnPerShareEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.earnPerShareEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.earnPerShareEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // prixePerEarningEd
            // 
            this.prixePerEarningEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prixePerEarningEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.prixePerEarningEd.Location = new System.Drawing.Point(151, 217);
            this.prixePerEarningEd.myFormat = "#,###.#0";
            this.prixePerEarningEd.Name = "prixePerEarningEd";
            this.prixePerEarningEd.Size = new System.Drawing.Size(70, 22);
            this.prixePerEarningEd.TabIndex = 42;
            this.prixePerEarningEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.prixePerEarningEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.prixePerEarningEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // roaEd
            // 
            this.roaEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roaEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.roaEd.Location = new System.Drawing.Point(221, 217);
            this.roaEd.myFormat = "#,###.#0";
            this.roaEd.Name = "roaEd";
            this.roaEd.Size = new System.Drawing.Size(76, 22);
            this.roaEd.TabIndex = 43;
            this.roaEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.roaEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.roaEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // roeEd
            // 
            this.roeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roeEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.roeEd.Location = new System.Drawing.Point(297, 217);
            this.roeEd.myFormat = "#,###.#0";
            this.roeEd.Name = "roeEd";
            this.roeEd.Size = new System.Drawing.Size(76, 22);
            this.roeEd.TabIndex = 44;
            this.roeEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.roeEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.roeEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // betaEd
            // 
            this.betaEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.betaEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.betaEd.Location = new System.Drawing.Point(373, 217);
            this.betaEd.myFormat = "#,###.#0";
            this.betaEd.Name = "betaEd";
            this.betaEd.Size = new System.Drawing.Size(70, 22);
            this.betaEd.TabIndex = 45;
            this.betaEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.betaEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.betaEd.Value = new decimal(new int[] {
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
            this.bookPriceEd.Location = new System.Drawing.Point(-1, 265);
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
            this.bookPriceLbl.Location = new System.Drawing.Point(2, 245);
            this.bookPriceLbl.Name = "bookPriceLbl";
            this.bookPriceLbl.Size = new System.Drawing.Size(75, 16);
            this.bookPriceLbl.TabIndex = 332;
            this.bookPriceLbl.Text = "Book price";
            // 
            // roaLbl
            // 
            this.roaLbl.AutoSize = true;
            this.roaLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roaLbl.Location = new System.Drawing.Point(223, 198);
            this.roaLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roaLbl.Name = "roaLbl";
            this.roaLbl.Size = new System.Drawing.Size(36, 16);
            this.roaLbl.TabIndex = 330;
            this.roaLbl.Text = "ROA";
            // 
            // roeLbl
            // 
            this.roeLbl.AutoSize = true;
            this.roeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roeLbl.Location = new System.Drawing.Point(297, 198);
            this.roeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roeLbl.Name = "roeLbl";
            this.roeLbl.Size = new System.Drawing.Size(33, 16);
            this.roeLbl.TabIndex = 328;
            this.roeLbl.Text = "ROE";
            // 
            // betaLbl
            // 
            this.betaLbl.AutoSize = true;
            this.betaLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.betaLbl.Location = new System.Drawing.Point(374, 199);
            this.betaLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.betaLbl.Name = "betaLbl";
            this.betaLbl.Size = new System.Drawing.Size(40, 16);
            this.betaLbl.TabIndex = 326;
            this.betaLbl.Text = "BETA";
            // 
            // pricePerBookLbl
            // 
            this.pricePerBookLbl.AutoSize = true;
            this.pricePerBookLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pricePerBookLbl.Location = new System.Drawing.Point(2, 198);
            this.pricePerBookLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pricePerBookLbl.Name = "pricePerBookLbl";
            this.pricePerBookLbl.Size = new System.Drawing.Size(32, 16);
            this.pricePerBookLbl.TabIndex = 324;
            this.pricePerBookLbl.Text = "P/B";
            // 
            // earnPerShareLbl
            // 
            this.earnPerShareLbl.AutoSize = true;
            this.earnPerShareLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.earnPerShareLbl.Location = new System.Drawing.Point(76, 198);
            this.earnPerShareLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.earnPerShareLbl.Name = "earnPerShareLbl";
            this.earnPerShareLbl.Size = new System.Drawing.Size(31, 16);
            this.earnPerShareLbl.TabIndex = 322;
            this.earnPerShareLbl.Text = "EPS";
            // 
            // prixePerEarningLbl
            // 
            this.prixePerEarningLbl.AutoSize = true;
            this.prixePerEarningLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prixePerEarningLbl.Location = new System.Drawing.Point(153, 199);
            this.prixePerEarningLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.prixePerEarningLbl.Name = "prixePerEarningLbl";
            this.prixePerEarningLbl.Size = new System.Drawing.Size(31, 16);
            this.prixePerEarningLbl.TabIndex = 318;
            this.prixePerEarningLbl.Text = "P/E";
            // 
            // baseLabel3
            // 
            this.baseLabel3.AutoSize = true;
            this.baseLabel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel3.Location = new System.Drawing.Point(2, 99);
            this.baseLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.baseLabel3.Name = "baseLabel3";
            this.baseLabel3.Size = new System.Drawing.Size(67, 16);
            this.baseLabel3.TabIndex = 316;
            this.baseLabel3.Text = "Currency";
            // 
            // totalAssetLbl
            // 
            this.totalAssetLbl.AutoSize = true;
            this.totalAssetLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAssetLbl.Location = new System.Drawing.Point(2, 150);
            this.totalAssetLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalAssetLbl.Name = "totalAssetLbl";
            this.totalAssetLbl.Size = new System.Drawing.Size(89, 16);
            this.totalAssetLbl.TabIndex = 315;
            this.totalAssetLbl.Text = "Total Assest";
            // 
            // totalDebtLbl
            // 
            this.totalDebtLbl.AutoSize = true;
            this.totalDebtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDebtLbl.Location = new System.Drawing.Point(119, 150);
            this.totalDebtLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalDebtLbl.Name = "totalDebtLbl";
            this.totalDebtLbl.Size = new System.Drawing.Size(75, 16);
            this.totalDebtLbl.TabIndex = 313;
            this.totalDebtLbl.Text = "Total Debt";
            // 
            // equityLbl
            // 
            this.equityLbl.AutoSize = true;
            this.equityLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equityLbl.Location = new System.Drawing.Point(221, 99);
            this.equityLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.equityLbl.Name = "equityLbl";
            this.equityLbl.Size = new System.Drawing.Size(76, 16);
            this.equityLbl.TabIndex = 311;
            this.equityLbl.Text = "Equity Cap";
            // 
            // profitLbl
            // 
            this.profitLbl.AutoSize = true;
            this.profitLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profitLbl.Location = new System.Drawing.Point(348, 151);
            this.profitLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.profitLbl.Name = "profitLbl";
            this.profitLbl.Size = new System.Drawing.Size(70, 16);
            this.profitLbl.TabIndex = 309;
            this.profitLbl.Text = "Net profit";
            // 
            // salesLbl
            // 
            this.salesLbl.AutoSize = true;
            this.salesLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesLbl.Location = new System.Drawing.Point(237, 150);
            this.salesLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.salesLbl.Name = "salesLbl";
            this.salesLbl.Size = new System.Drawing.Size(42, 16);
            this.salesLbl.TabIndex = 307;
            this.salesLbl.Text = "Sales";
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
            // capitalUnitCb
            // 
            this.capitalUnitCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.capitalUnitCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalUnitCb.FormattingEnabled = true;
            this.capitalUnitCb.Location = new System.Drawing.Point(-1, 119);
            this.capitalUnitCb.myValue = "";
            this.capitalUnitCb.Name = "capitalUnitCb";
            this.capitalUnitCb.Size = new System.Drawing.Size(108, 24);
            this.capitalUnitCb.TabIndex = 20;
            // 
            // workingCapitalLbl
            // 
            this.workingCapitalLbl.AutoSize = true;
            this.workingCapitalLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workingCapitalLbl.Location = new System.Drawing.Point(106, 99);
            this.workingCapitalLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.workingCapitalLbl.Name = "workingCapitalLbl";
            this.workingCapitalLbl.Size = new System.Drawing.Size(52, 16);
            this.workingCapitalLbl.TabIndex = 299;
            this.workingCapitalLbl.Text = "Capital";
            // 
            // targetPriceVariantLbl
            // 
            this.targetPriceVariantLbl.AutoSize = true;
            this.targetPriceVariantLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPriceVariantLbl.Location = new System.Drawing.Point(212, 245);
            this.targetPriceVariantLbl.Name = "targetPriceVariantLbl";
            this.targetPriceVariantLbl.Size = new System.Drawing.Size(33, 16);
            this.targetPriceVariantLbl.TabIndex = 272;
            this.targetPriceVariantLbl.Text = "+/-";
            // 
            // targetPriceLbl
            // 
            this.targetPriceLbl.AutoSize = true;
            this.targetPriceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPriceLbl.Location = new System.Drawing.Point(113, 247);
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
            this.statusCb.Location = new System.Drawing.Point(353, 265);
            this.statusCb.Margin = new System.Windows.Forms.Padding(2);
            this.statusCb.myValue = commonClass.AppTypes.CommonStatus.None;
            this.statusCb.Name = "statusCb";
            this.statusCb.SelectedValue = ((byte)(0));
            this.statusCb.Size = new System.Drawing.Size(90, 21);
            this.statusCb.TabIndex = 54;
            // 
            // statusLblb
            // 
            this.statusLblb.AutoSize = true;
            this.statusLblb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLblb.Location = new System.Drawing.Point(353, 247);
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
            this.regDateLbl.Location = new System.Drawing.Point(252, 247);
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
            // companyStockInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.bookPriceEd);
            this.Controls.Add(this.bookPriceLbl);
            this.Controls.Add(this.roaLbl);
            this.Controls.Add(this.roaEd);
            this.Controls.Add(this.roeLbl);
            this.Controls.Add(this.roeEd);
            this.Controls.Add(this.betaLbl);
            this.Controls.Add(this.betaEd);
            this.Controls.Add(this.pricePerBookLbl);
            this.Controls.Add(this.pricePerBookEd);
            this.Controls.Add(this.earnPerShareLbl);
            this.Controls.Add(this.earnPerShareEd);
            this.Controls.Add(this.prixePerEarningLbl);
            this.Controls.Add(this.prixePerEarningEd);
            this.Controls.Add(this.baseLabel3);
            this.Controls.Add(this.totalAssetLbl);
            this.Controls.Add(this.totalAssetEd);
            this.Controls.Add(this.totalDebtLbl);
            this.Controls.Add(this.totalDebtEd);
            this.Controls.Add(this.equityLbl);
            this.Controls.Add(this.equityEd);
            this.Controls.Add(this.profitLbl);
            this.Controls.Add(this.profitEd);
            this.Controls.Add(this.salesLbl);
            this.Controls.Add(this.salesEd);
            this.Controls.Add(this.treasuryStockLbl);
            this.Controls.Add(this.outstandingStockLbl);
            this.Controls.Add(this.treasuryStockEd);
            this.Controls.Add(this.foreignOwnStockEd);
            this.Controls.Add(this.capitalUnitCb);
            this.Controls.Add(this.workingCapitalLbl);
            this.Controls.Add(this.workingCapitalEd);
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
            this.Size = new System.Drawing.Size(441, 290);
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
        protected common.controls.numberTextBox listedStockEd;
        protected baseLabel noListedStockLbl;
        protected cbStockStatus statusCb;
        protected baseLabel statusLblb;
        protected common.controls.numberTextBox outstandingStockEd;
        protected baseLabel foreignOwnStockLbl;
        protected common.controls.numberTextBox targetPriceEd;
        protected baseLabel targetPriceLbl;
        protected common.controls.numberTextBox targetPriceVariantEd;
        protected baseLabel targetPriceVariantLbl;
        private cbCurrency capitalUnitCb;
        protected baseLabel workingCapitalLbl;
        private common.controls.numberTextBox workingCapitalEd;
        protected common.controls.numberTextBox treasuryStockEd;
        protected common.controls.numberTextBox foreignOwnStockEd;
        protected baseLabel outstandingStockLbl;
        protected baseLabel treasuryStockLbl;
        protected baseLabel salesLbl;
        private common.controls.numberTextBox salesEd;
        protected baseLabel profitLbl;
        private common.controls.numberTextBox profitEd;
        protected baseLabel equityLbl;
        private common.controls.numberTextBox equityEd;
        protected baseLabel totalDebtLbl;
        private common.controls.numberTextBox totalDebtEd;
        protected baseLabel totalAssetLbl;
        private common.controls.numberTextBox totalAssetEd;
        protected baseLabel baseLabel3;
        protected baseLabel pricePerBookLbl;
        private common.controls.numberTextBox pricePerBookEd;
        protected baseLabel earnPerShareLbl;
        private common.controls.numberTextBox earnPerShareEd;
        protected baseLabel prixePerEarningLbl;
        private common.controls.numberTextBox prixePerEarningEd;
        protected baseLabel roaLbl;
        private common.controls.numberTextBox roaEd;
        protected baseLabel roeLbl;
        private common.controls.numberTextBox roeEd;
        protected baseLabel betaLbl;
        private common.controls.numberTextBox betaEd;
        protected common.controls.numberTextBox bookPriceEd;
        protected baseLabel bookPriceLbl;
    }
}
