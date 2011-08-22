namespace baseClass.controls
{
    partial class stockCodeDetail
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
            this.tickerCodeEd = new common.control.baseTextBox();
            this.regDateEd = new common.control.baseDate();
            this.noSharesEd = new common.control.numberTextBox();
            this.statusCb = new baseClass.controls.cbStockStatus();
            this.statusLblb = new baseClass.controls.baseLabel();
            this.noSharesLbl = new baseClass.controls.baseLabel();
            this.regDateLbl = new baseClass.controls.baseLabel();
            this.tickerCodeLbl = new baseClass.controls.baseLabel();
            this.stockCodeLbl = new baseClass.controls.baseLabel();
            this.stockMarketCb = new baseClass.controls.cbStockExchange();
            this.stockMarketLbl = new baseClass.controls.baseLabel();
            this.noForeignOwnSharesEd = new common.control.numberTextBox();
            this.noForeignOwnSharesLbl = new baseClass.controls.baseLabel();
            this.targetPriceEd = new common.control.numberTextBox();
            this.targetPriceLbl = new baseClass.controls.baseLabel();
            this.targetPriceVariantEd = new common.control.numberTextBox();
            this.targetPriceVariantLbl = new baseClass.controls.baseLabel();
            this.SuspendLayout();
            // 
            // stockCodeEd
            // 
            this.stockCodeEd.BackColor = System.Drawing.SystemColors.Window;
            this.stockCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeEd.Location = new System.Drawing.Point(1, 19);
            this.stockCodeEd.Name = "stockCodeEd";
            this.stockCodeEd.Size = new System.Drawing.Size(121, 24);
            this.stockCodeEd.TabIndex = 1;
            // 
            // tickerCodeEd
            // 
            this.tickerCodeEd.BackColor = System.Drawing.SystemColors.Window;
            this.tickerCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickerCodeEd.Location = new System.Drawing.Point(318, 19);
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
            this.regDateEd.Location = new System.Drawing.Point(1, 118);
            this.regDateEd.Mask = "00/00/0000";
            this.regDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.regDateEd.Name = "regDateEd";
            this.regDateEd.Size = new System.Drawing.Size(101, 24);
            this.regDateEd.TabIndex = 30;
            // 
            // noSharesEd
            // 
            this.noSharesEd.BackColor = System.Drawing.SystemColors.Window;
            this.noSharesEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noSharesEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.noSharesEd.Location = new System.Drawing.Point(1, 71);
            this.noSharesEd.myFormat = "###,###,###,###,###";
            this.noSharesEd.Name = "noSharesEd";
            this.noSharesEd.Size = new System.Drawing.Size(138, 24);
            this.noSharesEd.TabIndex = 21;
            this.noSharesEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.noSharesEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.noSharesEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // statusCb
            // 
            this.statusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCb.FormattingEnabled = true;
            this.statusCb.Location = new System.Drawing.Point(102, 118);
            this.statusCb.Margin = new System.Windows.Forms.Padding(2);
            this.statusCb.myValue = application.myTypes.commonStatus.None;
            this.statusCb.Name = "statusCb";
            this.statusCb.SelectedValue = ((byte)(0));
            this.statusCb.Size = new System.Drawing.Size(101, 24);
            this.statusCb.TabIndex = 31;
            // 
            // statusLblb
            // 
            this.statusLblb.AutoSize = true;
            this.statusLblb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLblb.Location = new System.Drawing.Point(107, 99);
            this.statusLblb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLblb.Name = "statusLblb";
            this.statusLblb.Size = new System.Drawing.Size(74, 16);
            this.statusLblb.TabIndex = 266;
            this.statusLblb.Text = "Tình trạng";
            // 
            // noSharesLbl
            // 
            this.noSharesLbl.AutoSize = true;
            this.noSharesLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noSharesLbl.Location = new System.Drawing.Point(1, 51);
            this.noSharesLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noSharesLbl.Name = "noSharesLbl";
            this.noSharesLbl.Size = new System.Drawing.Size(83, 16);
            this.noSharesLbl.TabIndex = 262;
            this.noSharesLbl.Text = "SL niêm yết";
            // 
            // regDateLbl
            // 
            this.regDateLbl.AutoSize = true;
            this.regDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regDateLbl.Location = new System.Drawing.Point(1, 99);
            this.regDateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.regDateLbl.Name = "regDateLbl";
            this.regDateLbl.Size = new System.Drawing.Size(90, 16);
            this.regDateLbl.TabIndex = 260;
            this.regDateLbl.Text = "Ngày lên sàn";
            // 
            // tickerCodeLbl
            // 
            this.tickerCodeLbl.AutoSize = true;
            this.tickerCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickerCodeLbl.Location = new System.Drawing.Point(320, 1);
            this.tickerCodeLbl.Name = "tickerCodeLbl";
            this.tickerCodeLbl.Size = new System.Drawing.Size(58, 16);
            this.tickerCodeLbl.TabIndex = 256;
            this.tickerCodeLbl.Text = "Mã hiệu";
            // 
            // stockCodeLbl
            // 
            this.stockCodeLbl.AutoSize = true;
            this.stockCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeLbl.Location = new System.Drawing.Point(1, 1);
            this.stockCodeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stockCodeLbl.Name = "stockCodeLbl";
            this.stockCodeLbl.Size = new System.Drawing.Size(46, 16);
            this.stockCodeLbl.TabIndex = 254;
            this.stockCodeLbl.Text = "Mã số";
            // 
            // stockMarketCb
            // 
            this.stockMarketCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockMarketCb.FormattingEnabled = true;
            this.stockMarketCb.Location = new System.Drawing.Point(122, 19);
            this.stockMarketCb.Margin = new System.Windows.Forms.Padding(2);
            this.stockMarketCb.myValue = "";
            this.stockMarketCb.Name = "stockMarketCb";
            this.stockMarketCb.Size = new System.Drawing.Size(198, 24);
            this.stockMarketCb.TabIndex = 2;
            // 
            // stockMarketLbl
            // 
            this.stockMarketLbl.AutoSize = true;
            this.stockMarketLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockMarketLbl.Location = new System.Drawing.Point(124, 1);
            this.stockMarketLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stockMarketLbl.Name = "stockMarketLbl";
            this.stockMarketLbl.Size = new System.Drawing.Size(32, 16);
            this.stockMarketLbl.TabIndex = 252;
            this.stockMarketLbl.Text = "Sàn";
            // 
            // noForeignOwnSharesEd
            // 
            this.noForeignOwnSharesEd.BackColor = System.Drawing.SystemColors.Window;
            this.noForeignOwnSharesEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noForeignOwnSharesEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.noForeignOwnSharesEd.Location = new System.Drawing.Point(139, 71);
            this.noForeignOwnSharesEd.myFormat = "###,###,###,###,###";
            this.noForeignOwnSharesEd.Name = "noForeignOwnSharesEd";
            this.noForeignOwnSharesEd.Size = new System.Drawing.Size(145, 24);
            this.noForeignOwnSharesEd.TabIndex = 22;
            this.noForeignOwnSharesEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.noForeignOwnSharesEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.noForeignOwnSharesEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // noForeignOwnSharesLbl
            // 
            this.noForeignOwnSharesLbl.AutoSize = true;
            this.noForeignOwnSharesLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noForeignOwnSharesLbl.Location = new System.Drawing.Point(142, 51);
            this.noForeignOwnSharesLbl.Name = "noForeignOwnSharesLbl";
            this.noForeignOwnSharesLbl.Size = new System.Drawing.Size(60, 16);
            this.noForeignOwnSharesLbl.TabIndex = 268;
            this.noForeignOwnSharesLbl.Text = "SL NNSH";
            // 
            // targetPriceEd
            // 
            this.targetPriceEd.BackColor = System.Drawing.SystemColors.Window;
            this.targetPriceEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPriceEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.targetPriceEd.Location = new System.Drawing.Point(285, 71);
            this.targetPriceEd.myFormat = "###,###,###.##";
            this.targetPriceEd.Name = "targetPriceEd";
            this.targetPriceEd.Size = new System.Drawing.Size(121, 24);
            this.targetPriceEd.TabIndex = 23;
            this.targetPriceEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.targetPriceEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.targetPriceEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // targetPriceLbl
            // 
            this.targetPriceLbl.AutoSize = true;
            this.targetPriceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPriceLbl.Location = new System.Drawing.Point(287, 52);
            this.targetPriceLbl.Name = "targetPriceLbl";
            this.targetPriceLbl.Size = new System.Drawing.Size(57, 16);
            this.targetPriceLbl.TabIndex = 270;
            this.targetPriceLbl.Text = "Giá đích";
            // 
            // targetPriceVariantEd
            // 
            this.targetPriceVariantEd.BackColor = System.Drawing.SystemColors.Window;
            this.targetPriceVariantEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPriceVariantEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.targetPriceVariantEd.Location = new System.Drawing.Point(405, 71);
            this.targetPriceVariantEd.myFormat = "##";
            this.targetPriceVariantEd.Name = "targetPriceVariantEd";
            this.targetPriceVariantEd.Size = new System.Drawing.Size(35, 24);
            this.targetPriceVariantEd.TabIndex = 24;
            this.targetPriceVariantEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.targetPriceVariantEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.targetPriceVariantEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // targetPriceVariantLbl
            // 
            this.targetPriceVariantLbl.AutoSize = true;
            this.targetPriceVariantLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPriceVariantLbl.Location = new System.Drawing.Point(403, 50);
            this.targetPriceVariantLbl.Name = "targetPriceVariantLbl";
            this.targetPriceVariantLbl.Size = new System.Drawing.Size(33, 16);
            this.targetPriceVariantLbl.TabIndex = 272;
            this.targetPriceVariantLbl.Text = "+/-";
            // 
            // stockCodeDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.targetPriceVariantEd);
            this.Controls.Add(this.targetPriceVariantLbl);
            this.Controls.Add(this.targetPriceEd);
            this.Controls.Add(this.targetPriceLbl);
            this.Controls.Add(this.noForeignOwnSharesEd);
            this.Controls.Add(this.noForeignOwnSharesLbl);
            this.Controls.Add(this.statusCb);
            this.Controls.Add(this.statusLblb);
            this.Controls.Add(this.noSharesEd);
            this.Controls.Add(this.noSharesLbl);
            this.Controls.Add(this.regDateEd);
            this.Controls.Add(this.regDateLbl);
            this.Controls.Add(this.tickerCodeEd);
            this.Controls.Add(this.tickerCodeLbl);
            this.Controls.Add(this.stockCodeEd);
            this.Controls.Add(this.stockCodeLbl);
            this.Controls.Add(this.stockMarketCb);
            this.Controls.Add(this.stockMarketLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "stockCodeDetail";
            this.Size = new System.Drawing.Size(441, 141);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseLabel stockMarketLbl;
        protected common.control.baseTextBox stockCodeEd;
        protected baseLabel stockCodeLbl;
        protected controls.cbStockExchange stockMarketCb;
        protected common.control.baseTextBox tickerCodeEd;
        protected baseLabel tickerCodeLbl;
        protected common.control.baseDate regDateEd;
        protected baseLabel regDateLbl;
        protected common.control.numberTextBox noSharesEd;
        protected baseLabel noSharesLbl;
        protected cbStockStatus statusCb;
        protected baseLabel statusLblb;
        protected common.control.numberTextBox noForeignOwnSharesEd;
        protected baseLabel noForeignOwnSharesLbl;
        protected common.control.numberTextBox targetPriceEd;
        protected baseLabel targetPriceLbl;
        protected common.control.numberTextBox targetPriceVariantEd;
        protected baseLabel targetPriceVariantLbl;
    }
}
