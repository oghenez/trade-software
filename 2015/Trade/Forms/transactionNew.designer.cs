namespace Trade.Forms
{
    partial class transactionNew
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newBtn = new baseClass.controls.baseButton();
            this.saveBtn = new baseClass.controls.baseButton();
            this.closeBtn = new baseClass.controls.baseButton();
            this.checkBtn = new baseClass.controls.baseButton();
            this.remainCashEd = new common.controls.numberTextBox();
            this.availableCashEd = new common.controls.numberTextBox();
            this.newCashLbl = new common.controls.baseLabel();
            this.currentCashLbl = new common.controls.baseLabel();
            this.editGB1.SuspendLayout();
            this.SuspendLayout();
            // 
            // totalAmtEd
            // 
            this.totalAmtEd.Location = new System.Drawing.Point(178, 221);
            this.totalAmtEd.Size = new System.Drawing.Size(187, 23);
            this.totalAmtEd.TabIndex = 25;
            // 
            // feePercEd
            // 
            this.feePercEd.Location = new System.Drawing.Point(178, 197);
            this.feePercEd.Size = new System.Drawing.Size(42, 23);
            this.feePercEd.TabIndex = 23;
            // 
            // qtyEd
            // 
            this.qtyEd.Location = new System.Drawing.Point(178, 73);
            this.qtyEd.Size = new System.Drawing.Size(102, 23);
            this.qtyEd.TabIndex = 3;
            this.qtyEd.Validated += new System.EventHandler(this.qtyEd_Validated);
            // 
            // totalAmtLbl
            // 
            this.totalAmtLbl.Location = new System.Drawing.Point(16, 224);
            this.totalAmtLbl.Size = new System.Drawing.Size(154, 20);
            this.totalAmtLbl.Text = "Total Amount";
            // 
            // qtyLbl
            // 
            this.qtyLbl.Location = new System.Drawing.Point(16, 76);
            this.qtyLbl.Size = new System.Drawing.Size(154, 20);
            this.qtyLbl.Text = "Quantity";
            // 
            // priceEd
            // 
            this.priceEd.Location = new System.Drawing.Point(178, 122);
            this.priceEd.Size = new System.Drawing.Size(102, 23);
            this.priceEd.TabIndex = 20;
            // 
            // feeAmtLbl
            // 
            this.feeAmtLbl.Location = new System.Drawing.Point(16, 200);
            this.feeAmtLbl.Size = new System.Drawing.Size(154, 20);
            this.feeAmtLbl.Text = "Fee ";
            // 
            // priceLbl
            // 
            this.priceLbl.Location = new System.Drawing.Point(16, 126);
            this.priceLbl.Size = new System.Drawing.Size(154, 20);
            // 
            // feeAmtEd
            // 
            this.feeAmtEd.Location = new System.Drawing.Point(219, 197);
            this.feeAmtEd.Size = new System.Drawing.Size(146, 23);
            this.feeAmtEd.TabIndex = 24;
            // 
            // subTotalEd
            // 
            this.subTotalEd.Location = new System.Drawing.Point(178, 173);
            this.subTotalEd.Size = new System.Drawing.Size(187, 23);
            this.subTotalEd.TabIndex = 22;
            // 
            // subTotalLbl
            // 
            this.subTotalLbl.Location = new System.Drawing.Point(16, 176);
            this.subTotalLbl.Size = new System.Drawing.Size(154, 20);
            this.subTotalLbl.Text = "Sub total";
            // 
            // editGB1
            // 
            this.editGB1.Controls.Add(this.checkBtn);
            this.editGB1.Controls.Add(this.closeBtn);
            this.editGB1.Controls.Add(this.remainCashEd);
            this.editGB1.Controls.Add(this.saveBtn);
            this.editGB1.Controls.Add(this.availableCashEd);
            this.editGB1.Controls.Add(this.newBtn);
            this.editGB1.Controls.Add(this.newCashLbl);
            this.editGB1.Controls.Add(this.currentCashLbl);
            this.editGB1.Location = new System.Drawing.Point(2, -4);
            this.editGB1.Size = new System.Drawing.Size(492, 353);
            this.editGB1.TabIndex = 10;
            this.editGB1.Controls.SetChildIndex(this.onTimeEd, 0);
            this.editGB1.Controls.SetChildIndex(this.totalAmtEd, 0);
            this.editGB1.Controls.SetChildIndex(this.statusLbl, 0);
            this.editGB1.Controls.SetChildIndex(this.feePercEd, 0);
            this.editGB1.Controls.SetChildIndex(this.onTimeLbl, 0);
            this.editGB1.Controls.SetChildIndex(this.totalAmtLbl, 0);
            this.editGB1.Controls.SetChildIndex(this.priceEd, 0);
            this.editGB1.Controls.SetChildIndex(this.feeAmtLbl, 0);
            this.editGB1.Controls.SetChildIndex(this.priceLbl, 0);
            this.editGB1.Controls.SetChildIndex(this.feeAmtEd, 0);
            this.editGB1.Controls.SetChildIndex(this.subTotalEd, 0);
            this.editGB1.Controls.SetChildIndex(this.subTotalLbl, 0);
            this.editGB1.Controls.SetChildIndex(this.statusCb, 0);
            this.editGB1.Controls.SetChildIndex(this.currentCashLbl, 0);
            this.editGB1.Controls.SetChildIndex(this.transCodeEd, 0);
            this.editGB1.Controls.SetChildIndex(this.transactionNoLbl, 0);
            this.editGB1.Controls.SetChildIndex(this.newCashLbl, 0);
            this.editGB1.Controls.SetChildIndex(this.newBtn, 0);
            this.editGB1.Controls.SetChildIndex(this.availableCashEd, 0);
            this.editGB1.Controls.SetChildIndex(this.saveBtn, 0);
            this.editGB1.Controls.SetChildIndex(this.remainCashEd, 0);
            this.editGB1.Controls.SetChildIndex(this.closeBtn, 0);
            this.editGB1.Controls.SetChildIndex(this.portfolioCb, 0);
            this.editGB1.Controls.SetChildIndex(this.qtyEd, 0);
            this.editGB1.Controls.SetChildIndex(this.transTypeCb, 0);
            this.editGB1.Controls.SetChildIndex(this.codeEd, 0);
            this.editGB1.Controls.SetChildIndex(this.qtyLbl, 0);
            this.editGB1.Controls.SetChildIndex(this.portfolioLbl, 0);
            this.editGB1.Controls.SetChildIndex(this.transTypeLbl, 0);
            this.editGB1.Controls.SetChildIndex(this.codeLbl, 0);
            this.editGB1.Controls.SetChildIndex(this.checkBtn, 0);
            // 
            // statusLbl
            // 
            this.statusLbl.Location = new System.Drawing.Point(651, 47);
            this.statusLbl.Visible = false;
            // 
            // statusCb
            // 
            this.statusCb.Location = new System.Drawing.Point(804, 43);
            this.statusCb.Size = new System.Drawing.Size(163, 24);
            this.statusCb.Visible = false;
            // 
            // onTimeLbl
            // 
            this.onTimeLbl.Location = new System.Drawing.Point(16, 153);
            this.onTimeLbl.Size = new System.Drawing.Size(154, 20);
            this.onTimeLbl.Text = "Date/Time";
            // 
            // onTimeEd
            // 
            this.onTimeEd.Location = new System.Drawing.Point(178, 148);
            this.onTimeEd.Size = new System.Drawing.Size(187, 23);
            this.onTimeEd.TabIndex = 21;
            // 
            // portfolioLbl
            // 
            this.portfolioLbl.Location = new System.Drawing.Point(16, 101);
            this.portfolioLbl.Size = new System.Drawing.Size(154, 20);
            // 
            // codeLbl
            // 
            this.codeLbl.Location = new System.Drawing.Point(16, 25);
            this.codeLbl.Size = new System.Drawing.Size(154, 20);
            // 
            // transTypeLbl
            // 
            this.transTypeLbl.Location = new System.Drawing.Point(16, 51);
            this.transTypeLbl.Size = new System.Drawing.Size(154, 20);
            // 
            // portfolioCb
            // 
            this.portfolioCb.Location = new System.Drawing.Point(178, 97);
            this.portfolioCb.Size = new System.Drawing.Size(255, 24);
            this.portfolioCb.SelectionChangeCommitted += new System.EventHandler(this.portfolioCb_SelectionChangeCommitted);
            // 
            // codeEd
            // 
            this.codeEd.Location = new System.Drawing.Point(178, 21);
            this.codeEd.Size = new System.Drawing.Size(102, 23);
            // 
            // transCodeEd
            // 
            this.transCodeEd.Location = new System.Drawing.Point(804, 20);
            this.transCodeEd.Size = new System.Drawing.Size(81, 23);
            this.transCodeEd.Visible = false;
            // 
            // transTypeCb
            // 
            this.transTypeCb.Location = new System.Drawing.Point(178, 47);
            this.transTypeCb.myValue = commonTypes.AppTypes.TradeActions.Buy;
            this.transTypeCb.SelectedValue = ((byte)(1));
            this.transTypeCb.Size = new System.Drawing.Size(187, 24);
            this.transTypeCb.TabIndex = 2;
            this.transTypeCb.SelectionChangeCommitted += new System.EventHandler(this.transTypeCb_SelectionChangeCommitted);
            // 
            // transactionNoLbl
            // 
            this.transactionNoLbl.Location = new System.Drawing.Point(651, 25);
            this.transactionNoLbl.Text = "Transaction no.";
            this.transactionNoLbl.Visible = false;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(500, 2);
            this.TitleLbl.Visible = false;
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
            // newBtn
            // 
            this.newBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBtn.Image = global::Trade.Properties.Resources.addNew;
            this.newBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newBtn.isDownState = false;
            this.newBtn.Location = new System.Drawing.Point(264, 303);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(85, 40);
            this.newBtn.TabIndex = 51;
            this.newBtn.Text = "New";
            this.newBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = global::Trade.Properties.Resources.select;
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveBtn.isDownState = false;
            this.saveBtn.Location = new System.Drawing.Point(179, 303);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(85, 40);
            this.saveBtn.TabIndex = 50;
            this.saveBtn.Text = "Accept";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = global::Trade.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeBtn.isDownState = false;
            this.closeBtn.Location = new System.Drawing.Point(349, 303);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(85, 40);
            this.closeBtn.TabIndex = 52;
            this.closeBtn.Text = "Close";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // checkBtn
            // 
            this.checkBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBtn.Image = global::Trade.Properties.Resources.refresh;
            this.checkBtn.isDownState = false;
            this.checkBtn.Location = new System.Drawing.Point(433, 98);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(23, 22);
            this.checkBtn.TabIndex = 12;
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // remainCashEd
            // 
            this.remainCashEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainCashEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.remainCashEd.Location = new System.Drawing.Point(178, 272);
            this.remainCashEd.myFormat = "###,###,###,###,###";
            this.remainCashEd.Name = "remainCashEd";
            this.remainCashEd.ReadOnly = true;
            this.remainCashEd.Size = new System.Drawing.Size(187, 29);
            this.remainCashEd.TabIndex = 27;
            this.remainCashEd.TabStop = false;
            this.remainCashEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.remainCashEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.remainCashEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // availableCashEd
            // 
            this.availableCashEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableCashEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.availableCashEd.Location = new System.Drawing.Point(178, 247);
            this.availableCashEd.myFormat = "###,###,###,###,###";
            this.availableCashEd.Name = "availableCashEd";
            this.availableCashEd.ReadOnly = true;
            this.availableCashEd.Size = new System.Drawing.Size(187, 29);
            this.availableCashEd.TabIndex = 26;
            this.availableCashEd.TabStop = false;
            this.availableCashEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.availableCashEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.availableCashEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // newCashLbl
            // 
            this.newCashLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCashLbl.Location = new System.Drawing.Point(16, 275);
            this.newCashLbl.Name = "newCashLbl";
            this.newCashLbl.Size = new System.Drawing.Size(154, 20);
            this.newCashLbl.TabIndex = 192;
            this.newCashLbl.Text = "Cash";
            this.newCashLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // currentCashLbl
            // 
            this.currentCashLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentCashLbl.Location = new System.Drawing.Point(16, 250);
            this.currentCashLbl.Name = "currentCashLbl";
            this.currentCashLbl.Size = new System.Drawing.Size(154, 20);
            this.currentCashLbl.TabIndex = 191;
            this.currentCashLbl.Text = "Current Cash";
            this.currentCashLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // transactionNew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(494, 372);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "transactionNew";
            this.Text = "New Order";
            this.Load += new System.EventHandler(this.transactionNew_Load);
            this.editGB1.ResumeLayout(false);
            this.editGB1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        protected baseClass.controls.baseButton saveBtn;
        protected baseClass.controls.baseButton closeBtn;
        protected baseClass.controls.baseButton newBtn;
        protected baseClass.controls.baseButton checkBtn;
        protected common.controls.numberTextBox remainCashEd;
        protected common.controls.numberTextBox availableCashEd;
        protected common.controls.baseLabel newCashLbl;
        protected common.controls.baseLabel currentCashLbl;

    }
}