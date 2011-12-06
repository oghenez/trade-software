namespace Trade.Forms
{
    partial class transactionBase
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
            this.editGB1 = new System.Windows.Forms.GroupBox();
            this.totalAmtEd = new common.controls.numberTextBox();
            this.feePercEd = new common.controls.numberTextBox();
            this.qtyEd = new common.controls.numberTextBox();
            this.totalAmtLbl = new common.controls.baseLabel();
            this.qtyLbl = new common.controls.baseLabel();
            this.priceEd = new common.controls.numberTextBox();
            this.feeAmtLbl = new common.controls.baseLabel();
            this.priceLbl = new common.controls.baseLabel();
            this.feeAmtEd = new common.controls.numberTextBox();
            this.subTotalEd = new common.controls.numberTextBox();
            this.subTotalLbl = new common.controls.baseLabel();
            this.editGB2 = new System.Windows.Forms.GroupBox();
            this.statusLbl = new common.controls.baseLabel();
            this.statusCb = new baseClass.controls.cbCommonStatus();
            this.onTimeLbl = new common.controls.baseLabel();
            this.onTimeEd = new common.controls.baseDate();
            this.portfolioLbl = new common.controls.baseLabel();
            this.codeLbl = new common.controls.baseLabel();
            this.transTypeLbl = new common.controls.baseLabel();
            this.portfolioCb = new baseClass.controls.cbWatchList();
            this.codeEd = new baseClass.controls.txtStockCode();
            this.transCodeEd = new common.controls.baseTextBox();
            this.transTypeCb = new baseClass.controls.cbTradeAction();
            this.transactionNoLbl = new common.controls.baseLabel();
            this.editGB1.SuspendLayout();
            this.editGB2.SuspendLayout();
            this.SuspendLayout();
            // 
            // editGB1
            // 
            this.editGB1.Controls.Add(this.totalAmtEd);
            this.editGB1.Controls.Add(this.feePercEd);
            this.editGB1.Controls.Add(this.qtyEd);
            this.editGB1.Controls.Add(this.totalAmtLbl);
            this.editGB1.Controls.Add(this.qtyLbl);
            this.editGB1.Controls.Add(this.priceEd);
            this.editGB1.Controls.Add(this.feeAmtLbl);
            this.editGB1.Controls.Add(this.priceLbl);
            this.editGB1.Controls.Add(this.feeAmtEd);
            this.editGB1.Controls.Add(this.subTotalEd);
            this.editGB1.Controls.Add(this.subTotalLbl);
            this.editGB1.Location = new System.Drawing.Point(2, 171);
            this.editGB1.Name = "editGB1";
            this.editGB1.Size = new System.Drawing.Size(354, 145);
            this.editGB1.TabIndex = 162;
            this.editGB1.TabStop = false;
            // 
            // totalAmtEd
            // 
            this.totalAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.totalAmtEd.Location = new System.Drawing.Point(127, 111);
            this.totalAmtEd.myFormat = "###,###,###,###,###";
            this.totalAmtEd.Name = "totalAmtEd";
            this.totalAmtEd.ReadOnly = true;
            this.totalAmtEd.Size = new System.Drawing.Size(154, 24);
            this.totalAmtEd.TabIndex = 6;
            this.totalAmtEd.TabStop = false;
            this.totalAmtEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalAmtEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.totalAmtEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // feePercEd
            // 
            this.feePercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.feePercEd.Location = new System.Drawing.Point(127, 87);
            this.feePercEd.myFormat = "###,###,##0.00";
            this.feePercEd.Name = "feePercEd";
            this.feePercEd.ReadOnly = true;
            this.feePercEd.Size = new System.Drawing.Size(42, 24);
            this.feePercEd.TabIndex = 4;
            this.feePercEd.TabStop = false;
            this.feePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.feePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.feePercEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // qtyEd
            // 
            this.qtyEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.qtyEd.Location = new System.Drawing.Point(127, 15);
            this.qtyEd.myFormat = "###,###,###,###,###";
            this.qtyEd.Name = "qtyEd";
            this.qtyEd.Size = new System.Drawing.Size(154, 24);
            this.qtyEd.TabIndex = 1;
            this.qtyEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.qtyEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.qtyEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // totalAmtLbl
            // 
            this.totalAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAmtLbl.Location = new System.Drawing.Point(16, 114);
            this.totalAmtLbl.Name = "totalAmtLbl";
            this.totalAmtLbl.Size = new System.Drawing.Size(108, 16);
            this.totalAmtLbl.TabIndex = 173;
            this.totalAmtLbl.Text = "Total amount";
            this.totalAmtLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qtyLbl
            // 
            this.qtyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyLbl.Location = new System.Drawing.Point(16, 19);
            this.qtyLbl.Name = "qtyLbl";
            this.qtyLbl.Size = new System.Drawing.Size(108, 16);
            this.qtyLbl.TabIndex = 163;
            this.qtyLbl.Text = "Qty";
            this.qtyLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // priceEd
            // 
            this.priceEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.priceEd.Location = new System.Drawing.Point(127, 39);
            this.priceEd.myFormat = "###,###,###,###,###";
            this.priceEd.Name = "priceEd";
            this.priceEd.ReadOnly = true;
            this.priceEd.Size = new System.Drawing.Size(154, 24);
            this.priceEd.TabIndex = 2;
            this.priceEd.TabStop = false;
            this.priceEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.priceEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.priceEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // feeAmtLbl
            // 
            this.feeAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feeAmtLbl.Location = new System.Drawing.Point(16, 90);
            this.feeAmtLbl.Name = "feeAmtLbl";
            this.feeAmtLbl.Size = new System.Drawing.Size(108, 16);
            this.feeAmtLbl.TabIndex = 171;
            this.feeAmtLbl.Text = "Trans Fee ";
            this.feeAmtLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // priceLbl
            // 
            this.priceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLbl.Location = new System.Drawing.Point(16, 43);
            this.priceLbl.Name = "priceLbl";
            this.priceLbl.Size = new System.Drawing.Size(108, 16);
            this.priceLbl.TabIndex = 165;
            this.priceLbl.Text = "Price";
            this.priceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // feeAmtEd
            // 
            this.feeAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feeAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.feeAmtEd.Location = new System.Drawing.Point(169, 87);
            this.feeAmtEd.myFormat = "###,###,###,###,###";
            this.feeAmtEd.Name = "feeAmtEd";
            this.feeAmtEd.ReadOnly = true;
            this.feeAmtEd.Size = new System.Drawing.Size(111, 24);
            this.feeAmtEd.TabIndex = 5;
            this.feeAmtEd.TabStop = false;
            this.feeAmtEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.feeAmtEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.feeAmtEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // subTotalEd
            // 
            this.subTotalEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTotalEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.subTotalEd.Location = new System.Drawing.Point(127, 63);
            this.subTotalEd.myFormat = "###,###,###,###,###";
            this.subTotalEd.Name = "subTotalEd";
            this.subTotalEd.ReadOnly = true;
            this.subTotalEd.Size = new System.Drawing.Size(154, 24);
            this.subTotalEd.TabIndex = 3;
            this.subTotalEd.TabStop = false;
            this.subTotalEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.subTotalEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.subTotalEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // subTotalLbl
            // 
            this.subTotalLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTotalLbl.Location = new System.Drawing.Point(16, 66);
            this.subTotalLbl.Name = "subTotalLbl";
            this.subTotalLbl.Size = new System.Drawing.Size(108, 16);
            this.subTotalLbl.TabIndex = 167;
            this.subTotalLbl.Text = "Amount";
            this.subTotalLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // editGB2
            // 
            this.editGB2.Controls.Add(this.statusLbl);
            this.editGB2.Controls.Add(this.statusCb);
            this.editGB2.Controls.Add(this.onTimeLbl);
            this.editGB2.Controls.Add(this.onTimeEd);
            this.editGB2.Controls.Add(this.portfolioLbl);
            this.editGB2.Controls.Add(this.codeLbl);
            this.editGB2.Controls.Add(this.transTypeLbl);
            this.editGB2.Controls.Add(this.portfolioCb);
            this.editGB2.Controls.Add(this.codeEd);
            this.editGB2.Controls.Add(this.transCodeEd);
            this.editGB2.Controls.Add(this.transTypeCb);
            this.editGB2.Controls.Add(this.transactionNoLbl);
            this.editGB2.Location = new System.Drawing.Point(3, -1);
            this.editGB2.Name = "editGB2";
            this.editGB2.Size = new System.Drawing.Size(354, 173);
            this.editGB2.TabIndex = 161;
            this.editGB2.TabStop = false;
            // 
            // statusLbl
            // 
            this.statusLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(10, 143);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(114, 16);
            this.statusLbl.TabIndex = 163;
            this.statusLbl.Text = "Status";
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusCb
            // 
            this.statusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCb.Enabled = false;
            this.statusCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCb.Location = new System.Drawing.Point(128, 139);
            this.statusCb.myValue = commonClass.AppTypes.CommonStatus.None;
            this.statusCb.Name = "statusCb";
            this.statusCb.SelectedValue = ((byte)(0));
            this.statusCb.Size = new System.Drawing.Size(158, 24);
            this.statusCb.TabIndex = 13;
            this.statusCb.TabStop = false;
            // 
            // onTimeLbl
            // 
            this.onTimeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onTimeLbl.Location = new System.Drawing.Point(10, 118);
            this.onTimeLbl.Name = "onTimeLbl";
            this.onTimeLbl.Size = new System.Drawing.Size(114, 16);
            this.onTimeLbl.TabIndex = 161;
            this.onTimeLbl.Text = "Date Time";
            this.onTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // onTimeEd
            // 
            this.onTimeEd.BeepOnError = true;
            this.onTimeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onTimeEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.onTimeEd.Location = new System.Drawing.Point(128, 113);
            this.onTimeEd.Mask = "00/00/0000 90:00";
            this.onTimeEd.Name = "onTimeEd";
            this.onTimeEd.ReadOnly = true;
            this.onTimeEd.Size = new System.Drawing.Size(158, 24);
            this.onTimeEd.TabIndex = 12;
            this.onTimeEd.TabStop = false;
            this.onTimeEd.ValidatingType = typeof(System.DateTime);
            // 
            // portfolioLbl
            // 
            this.portfolioLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioLbl.Location = new System.Drawing.Point(10, 93);
            this.portfolioLbl.Name = "portfolioLbl";
            this.portfolioLbl.Size = new System.Drawing.Size(114, 16);
            this.portfolioLbl.TabIndex = 152;
            this.portfolioLbl.Text = "Portfolio";
            this.portfolioLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // codeLbl
            // 
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(10, 18);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(114, 16);
            this.codeLbl.TabIndex = 159;
            this.codeLbl.Text = "Code";
            this.codeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // transTypeLbl
            // 
            this.transTypeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transTypeLbl.Location = new System.Drawing.Point(10, 68);
            this.transTypeLbl.Name = "transTypeLbl";
            this.transTypeLbl.Size = new System.Drawing.Size(114, 16);
            this.transTypeLbl.TabIndex = 157;
            this.transTypeLbl.Text = "Transaction";
            this.transTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // portfolioCb
            // 
            this.portfolioCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portfolioCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioCb.Location = new System.Drawing.Point(128, 87);
            this.portfolioCb.myValue = "";
            this.portfolioCb.Name = "portfolioCb";
            this.portfolioCb.Size = new System.Drawing.Size(158, 24);
            this.portfolioCb.TabIndex = 11;
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.Color.White;
            this.codeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEd.ForeColor = System.Drawing.Color.Black;
            this.codeEd.isToUpperCase = true;
            this.codeEd.Location = new System.Drawing.Point(128, 14);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(81, 24);
            this.codeEd.TabIndex = 1;
            this.codeEd.TabStop = false;
            // 
            // transCodeEd
            // 
            this.transCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transCodeEd.isToUpperCase = false;
            this.transCodeEd.Location = new System.Drawing.Point(128, 38);
            this.transCodeEd.Name = "transCodeEd";
            this.transCodeEd.ReadOnly = true;
            this.transCodeEd.Size = new System.Drawing.Size(81, 24);
            this.transCodeEd.TabIndex = 3;
            this.transCodeEd.TabStop = false;
            // 
            // transTypeCb
            // 
            this.transTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transTypeCb.Location = new System.Drawing.Point(128, 62);
            this.transTypeCb.myValue = commonClass.AppTypes.TradeActions.None;
            this.transTypeCb.Name = "transTypeCb";
            this.transTypeCb.SelectedValue = ((byte)(0));
            this.transTypeCb.Size = new System.Drawing.Size(158, 24);
            this.transTypeCb.TabIndex = 10;
            // 
            // transactionNoLbl
            // 
            this.transactionNoLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionNoLbl.Location = new System.Drawing.Point(10, 43);
            this.transactionNoLbl.Name = "transactionNoLbl";
            this.transactionNoLbl.Size = new System.Drawing.Size(114, 16);
            this.transactionNoLbl.TabIndex = 156;
            this.transactionNoLbl.Text = "Transaction No";
            this.transactionNoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // transactionBase
            // 
            this.ClientSize = new System.Drawing.Size(358, 340);
            this.Controls.Add(this.editGB1);
            this.Controls.Add(this.editGB2);
            this.Name = "transactionBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.editGB2, 0);
            this.Controls.SetChildIndex(this.editGB1, 0);
            this.editGB1.ResumeLayout(false);
            this.editGB1.PerformLayout();
            this.editGB2.ResumeLayout(false);
            this.editGB2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.GroupBox editGB1;
        protected common.controls.numberTextBox totalAmtEd;
        protected common.controls.numberTextBox feePercEd;
        protected common.controls.numberTextBox qtyEd;
        protected common.controls.baseLabel totalAmtLbl;
        protected common.controls.baseLabel qtyLbl;
        protected common.controls.numberTextBox priceEd;
        protected common.controls.baseLabel feeAmtLbl;
        protected common.controls.baseLabel priceLbl;
        protected common.controls.numberTextBox feeAmtEd;
        protected common.controls.numberTextBox subTotalEd;
        protected common.controls.baseLabel subTotalLbl;
        protected System.Windows.Forms.GroupBox editGB2;
        protected common.controls.baseLabel statusLbl;
        protected baseClass.controls.cbCommonStatus statusCb;
        protected common.controls.baseLabel onTimeLbl;
        protected common.controls.baseDate onTimeEd;
        protected common.controls.baseLabel portfolioLbl;
        protected common.controls.baseLabel codeLbl;
        protected common.controls.baseLabel transTypeLbl;
        protected baseClass.controls.cbWatchList portfolioCb;
        protected baseClass.controls.txtStockCode codeEd;
        protected common.controls.baseTextBox transCodeEd;
        protected baseClass.controls.cbTradeAction transTypeCb;
        protected common.controls.baseLabel transactionNoLbl;
    }
}
