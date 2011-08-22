namespace stockTrade.controls
{
    partial class tradeOrderEdit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.totalAmtEd = new common.control.numberTextBox();
            this.feePercEd = new common.control.numberTextBox();
            this.qtyEd = new common.control.numberTextBox();
            this.totalAmtLbl = new common.control.baseLabel();
            this.qtyLbl = new common.control.baseLabel();
            this.priceEd = new common.control.numberTextBox();
            this.feeAmtLbl = new common.control.baseLabel();
            this.priceLbl = new common.control.baseLabel();
            this.feeAmtEd = new common.control.numberTextBox();
            this.subTotalEd = new common.control.numberTextBox();
            this.subTotalLbl = new common.control.baseLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.onTimeLbl = new common.control.baseLabel();
            this.onTimeEd = new common.control.baseDate();
            this.portpolioLbl = new common.control.baseLabel();
            this.stockCodeLbl = new common.control.baseLabel();
            this.transTypeLbl = new common.control.baseLabel();
            this.portpolioCb = new baseClass.controls.cbPorpolio();
            this.stockCodeEd = new common.control.baseTextBox();
            this.codeEd = new common.control.baseTextBox();
            this.transTypeCb = new baseClass.controls.cbTradeAction();
            this.codeLbl = new common.control.baseLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.totalAmtEd);
            this.groupBox1.Controls.Add(this.feePercEd);
            this.groupBox1.Controls.Add(this.qtyEd);
            this.groupBox1.Controls.Add(this.totalAmtLbl);
            this.groupBox1.Controls.Add(this.qtyLbl);
            this.groupBox1.Controls.Add(this.priceEd);
            this.groupBox1.Controls.Add(this.feeAmtLbl);
            this.groupBox1.Controls.Add(this.priceLbl);
            this.groupBox1.Controls.Add(this.feeAmtEd);
            this.groupBox1.Controls.Add(this.subTotalEd);
            this.groupBox1.Controls.Add(this.subTotalLbl);
            this.groupBox1.Location = new System.Drawing.Point(1, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 145);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
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
            this.qtyEd.Validated += new System.EventHandler(this.qtyEd_Validated);
            // 
            // totalAmtLbl
            // 
            this.totalAmtLbl.AutoSize = true;
            this.totalAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAmtLbl.Location = new System.Drawing.Point(48, 115);
            this.totalAmtLbl.Name = "totalAmtLbl";
            this.totalAmtLbl.Size = new System.Drawing.Size(68, 16);
            this.totalAmtLbl.TabIndex = 173;
            this.totalAmtLbl.Text = "Tổng tiền";
            // 
            // qtyLbl
            // 
            this.qtyLbl.AutoSize = true;
            this.qtyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyLbl.Location = new System.Drawing.Point(41, 19);
            this.qtyLbl.Name = "qtyLbl";
            this.qtyLbl.Size = new System.Drawing.Size(75, 16);
            this.qtyLbl.TabIndex = 163;
            this.qtyLbl.Text = "Khối lượng";
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
            this.feeAmtLbl.AutoSize = true;
            this.feeAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feeAmtLbl.Location = new System.Drawing.Point(55, 91);
            this.feeAmtLbl.Name = "feeAmtLbl";
            this.feeAmtLbl.Size = new System.Drawing.Size(61, 16);
            this.feeAmtLbl.TabIndex = 171;
            this.feeAmtLbl.Text = "Tiền phí ";
            // 
            // priceLbl
            // 
            this.priceLbl.AutoSize = true;
            this.priceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLbl.Location = new System.Drawing.Point(59, 43);
            this.priceLbl.Name = "priceLbl";
            this.priceLbl.Size = new System.Drawing.Size(57, 16);
            this.priceLbl.TabIndex = 165;
            this.priceLbl.Text = "Đơn giá";
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
            this.subTotalLbl.AutoSize = true;
            this.subTotalLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTotalLbl.Location = new System.Drawing.Point(63, 67);
            this.subTotalLbl.Name = "subTotalLbl";
            this.subTotalLbl.Size = new System.Drawing.Size(53, 16);
            this.subTotalLbl.TabIndex = 167;
            this.subTotalLbl.Text = "Số tiền";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.onTimeLbl);
            this.groupBox2.Controls.Add(this.onTimeEd);
            this.groupBox2.Controls.Add(this.portpolioLbl);
            this.groupBox2.Controls.Add(this.stockCodeLbl);
            this.groupBox2.Controls.Add(this.transTypeLbl);
            this.groupBox2.Controls.Add(this.portpolioCb);
            this.groupBox2.Controls.Add(this.stockCodeEd);
            this.groupBox2.Controls.Add(this.codeEd);
            this.groupBox2.Controls.Add(this.transTypeCb);
            this.groupBox2.Controls.Add(this.codeLbl);
            this.groupBox2.Location = new System.Drawing.Point(1, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 146);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // onTimeLbl
            // 
            this.onTimeLbl.AutoSize = true;
            this.onTimeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onTimeLbl.Location = new System.Drawing.Point(41, 115);
            this.onTimeLbl.Name = "onTimeLbl";
            this.onTimeLbl.Size = new System.Drawing.Size(65, 16);
            this.onTimeLbl.TabIndex = 161;
            this.onTimeLbl.Text = "Thời gian";
            // 
            // onTimeEd
            // 
            this.onTimeEd.BeepOnError = true;
            this.onTimeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onTimeEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.onTimeEd.Location = new System.Drawing.Point(128, 113);
            this.onTimeEd.Mask = "00/00/0000 90:00";
            this.onTimeEd.myDateTime = new System.DateTime(((long)(0)));
            this.onTimeEd.Name = "onTimeEd";
            this.onTimeEd.ReadOnly = true;
            this.onTimeEd.Size = new System.Drawing.Size(124, 24);
            this.onTimeEd.TabIndex = 22;
            this.onTimeEd.TabStop = false;
            this.onTimeEd.ValidatingType = typeof(System.DateTime);
            // 
            // portpolioLbl
            // 
            this.portpolioLbl.AutoSize = true;
            this.portpolioLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portpolioLbl.Location = new System.Drawing.Point(45, 90);
            this.portpolioLbl.Name = "portpolioLbl";
            this.portpolioLbl.Size = new System.Drawing.Size(66, 16);
            this.portpolioLbl.TabIndex = 152;
            this.portpolioLbl.Text = "Portpolio";
            // 
            // stockCodeLbl
            // 
            this.stockCodeLbl.AutoSize = true;
            this.stockCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeLbl.Location = new System.Drawing.Point(26, 18);
            this.stockCodeLbl.Name = "stockCodeLbl";
            this.stockCodeLbl.Size = new System.Drawing.Size(85, 16);
            this.stockCodeLbl.TabIndex = 159;
            this.stockCodeLbl.Text = "Mã cổ phiếu";
            // 
            // transTypeLbl
            // 
            this.transTypeLbl.AutoSize = true;
            this.transTypeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transTypeLbl.Location = new System.Drawing.Point(16, 66);
            this.transTypeLbl.Name = "transTypeLbl";
            this.transTypeLbl.Size = new System.Drawing.Size(95, 16);
            this.transTypeLbl.TabIndex = 157;
            this.transTypeLbl.Text = "Loại giao dịch";
            // 
            // portpolioCb
            // 
            this.portpolioCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portpolioCb.Enabled = false;
            this.portpolioCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portpolioCb.Location = new System.Drawing.Point(128, 87);
            this.portpolioCb.myValue = "";
            this.portpolioCb.Name = "portpolioCb";
            this.portpolioCb.Size = new System.Drawing.Size(158, 24);
            this.portpolioCb.TabIndex = 21;
            // 
            // stockCodeEd
            // 
            this.stockCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeEd.Location = new System.Drawing.Point(128, 14);
            this.stockCodeEd.Name = "stockCodeEd";
            this.stockCodeEd.ReadOnly = true;
            this.stockCodeEd.Size = new System.Drawing.Size(90, 24);
            this.stockCodeEd.TabIndex = 20;
            // 
            // codeEd
            // 
            this.codeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEd.Location = new System.Drawing.Point(128, 38);
            this.codeEd.Name = "codeEd";
            this.codeEd.ReadOnly = true;
            this.codeEd.Size = new System.Drawing.Size(90, 24);
            this.codeEd.TabIndex = 3;
            // 
            // transTypeCb
            // 
            this.transTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transTypeCb.Enabled = false;
            this.transTypeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transTypeCb.Location = new System.Drawing.Point(128, 62);
            this.transTypeCb.myValue = application.analysis.tradeActions.None;
            this.transTypeCb.Name = "transTypeCb";
            this.transTypeCb.SelectedValue = ((byte)(0));
            this.transTypeCb.Size = new System.Drawing.Size(158, 24);
            this.transTypeCb.TabIndex = 10;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(23, 42);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(88, 16);
            this.codeLbl.TabIndex = 156;
            this.codeLbl.Text = "Mã giao dịch";
            // 
            // tradeOrderEdit
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "tradeOrderEdit";
            this.Size = new System.Drawing.Size(356, 282);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private common.control.numberTextBox totalAmtEd;
        private common.control.numberTextBox feePercEd;
        private common.control.numberTextBox qtyEd;
        protected common.control.baseLabel totalAmtLbl;
        protected common.control.baseLabel qtyLbl;
        private common.control.numberTextBox priceEd;
        protected common.control.baseLabel feeAmtLbl;
        protected common.control.baseLabel priceLbl;
        private common.control.numberTextBox feeAmtEd;
        private common.control.numberTextBox subTotalEd;
        protected common.control.baseLabel subTotalLbl;
        private System.Windows.Forms.GroupBox groupBox2;
        protected common.control.baseLabel portpolioLbl;
        protected common.control.baseLabel stockCodeLbl;
        protected common.control.baseLabel transTypeLbl;
        protected baseClass.controls.cbPorpolio portpolioCb;
        protected common.control.baseTextBox stockCodeEd;
        protected common.control.baseTextBox codeEd;
        protected baseClass.controls.cbTradeAction transTypeCb;
        protected common.control.baseLabel codeLbl;
        protected common.control.baseLabel onTimeLbl;
        protected common.control.baseDate onTimeEd;


    }
}
