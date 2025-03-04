namespace application
{
    partial class baseVoucherEntry
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseVoucherEntry));
            this.accountSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountEd = new System.Windows.Forms.TextBox();
            this.accountLbl = new System.Windows.Forms.Label();
            this.debitCreditCb = new System.Windows.Forms.ComboBox();
            this.voucherDetailsTableAdapter = new data.applicationDataSetTableAdapters.VoucherDetailsTableAdapter();
            this.accountTableAdapter = new data.masterDataSetTableAdapters.AccountTableAdapter();
            this.voucherDetailsSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.voucherSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myApplicationDataSet)).BeginInit();
            this.toolBarGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myMasterDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysAutoIncreaseSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkerSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherDetailsSource)).BeginInit();
            this.SuspendLayout();
            // 
            // voucherNoEd
            // 
            this.voucherNoEd.Location = new System.Drawing.Point(19, 84);
            // 
            // orderNoLbl
            // 
            this.orderNoLbl.Location = new System.Drawing.Point(22, 64);
            // 
            // dateLbl
            // 
            this.dateLbl.Location = new System.Drawing.Point(201, 64);
            // 
            // descLbl
            // 
            this.descLbl.Location = new System.Drawing.Point(18, 156);
            // 
            // documentNoteEd
            // 
            this.documentNoteEd.Location = new System.Drawing.Point(19, 175);
            this.documentNoteEd.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.documentNoteEd.Size = new System.Drawing.Size(700, 28);
            this.documentNoteEd.TabIndex = 39;
            // 
            // refNoLbl
            // 
            this.refNoLbl.Location = new System.Drawing.Point(107, 64);
            // 
            // voucherIdEd
            // 
            this.voucherIdEd.Location = new System.Drawing.Point(108, 84);
            // 
            // subTotalEd
            // 
            this.subTotalEd.Location = new System.Drawing.Point(588, 449);
            this.subTotalEd.Size = new System.Drawing.Size(126, 22);
            // 
            // toolBarGroup
            // 
            this.toolBarGroup.Location = new System.Drawing.Point(0, 466);
            this.toolBarGroup.Size = new System.Drawing.Size(739, 54);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(638, 14);
            this.exitBtn.Size = new System.Drawing.Size(77, 33);
            // 
            // saveBtn
            // 
            this.saveBtn.Size = new System.Drawing.Size(63, 33);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Size = new System.Drawing.Size(64, 33);
            // 
            // addLineBtn
            // 
            this.addLineBtn.Location = new System.Drawing.Point(455, 16);
            this.addLineBtn.Size = new System.Drawing.Size(77, 29);
            // 
            // deleteLineBtn
            // 
            this.deleteLineBtn.Location = new System.Drawing.Point(540, 16);
            this.deleteLineBtn.Size = new System.Drawing.Size(67, 29);
            // 
            // FindBtn
            // 
            this.FindBtn.Location = new System.Drawing.Point(285, 14);
            this.FindBtn.Size = new System.Drawing.Size(66, 33);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Size = new System.Drawing.Size(59, 33);
            // 
            // subTotalLbl
            // 
            this.subTotalLbl.Location = new System.Drawing.Point(548, 452);
            // 
            // custCodeEd
            // 
            this.custCodeEd.Location = new System.Drawing.Point(19, 129);
            this.custCodeEd.Visible = false;
            // 
            // custNameEd
            // 
            this.custNameEd.Location = new System.Drawing.Point(101, 129);
            // 
            // invoiceNoEd
            // 
            this.invoiceNoEd.Location = new System.Drawing.Point(605, 84);
            this.invoiceNoEd.Size = new System.Drawing.Size(114, 22);
            this.invoiceNoEd.TabIndex = 36;
            this.invoiceNoEd.Visible = false;
            // 
            // invoiceChk
            // 
            this.invoiceChk.Location = new System.Drawing.Point(605, 64);
            this.invoiceChk.TabIndex = 34;
            this.invoiceChk.Visible = false;
            // 
            // bookLbl
            // 
            this.bookLbl.Location = new System.Drawing.Point(784, 190);
            this.bookLbl.Visible = false;
            // 
            // seriLbl
            // 
            this.seriLbl.Location = new System.Drawing.Point(847, 190);
            this.seriLbl.Visible = false;
            // 
            // bookNoEd
            // 
            this.bookNoEd.Location = new System.Drawing.Point(783, 209);
            this.bookNoEd.Visible = false;
            // 
            // seriEd
            // 
            this.seriEd.Location = new System.Drawing.Point(842, 209);
            this.seriEd.Visible = false;
            // 
            // custAddressEd
            // 
            this.custAddressEd.Enabled = true;
            this.custAddressEd.Location = new System.Drawing.Point(248, 129);
            // 
            // custNameLbl
            // 
            this.custNameLbl.Location = new System.Drawing.Point(105, 111);
            // 
            // custAddressLbl
            // 
            this.custAddressLbl.Location = new System.Drawing.Point(251, 111);
            // 
            // custTaxCodeEd
            // 
            this.custTaxCodeEd.Enabled = true;
            this.custTaxCodeEd.Location = new System.Drawing.Point(657, 129);
            // 
            // custTaxCodeLbl
            // 
            this.custTaxCodeLbl.Location = new System.Drawing.Point(661, 113);
            // 
            // custIdCardLbl
            // 
            this.custIdCardLbl.Location = new System.Drawing.Point(965, 114);
            // 
            // custIdCardEd
            // 
            this.custIdCardEd.Location = new System.Drawing.Point(787, 73);
            // 
            // dateEd
            // 
            this.dateEd.Location = new System.Drawing.Point(195, 84);
            // 
            // personNameLbl
            // 
            this.personNameLbl.Location = new System.Drawing.Point(100, 129);
            // 
            // personNameEd
            // 
            this.personNameEd.Location = new System.Drawing.Point(787, 43);
            // 
            // custCodeChk
            // 
            this.custCodeChk.Location = new System.Drawing.Point(19, 111);
            this.myToolTip.SetToolTip(this.custCodeChk, "Chi tiết sử dụng cùng [Đon vị] ");
            this.custCodeChk.Visible = false;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(220, 14);
            this.printBtn.Size = new System.Drawing.Size(57, 33);
            // 
            // copyAppendModeChk
            // 
            this.myToolTip.SetToolTip(this.copyAppendModeChk, "Chi tiết sử dụng cùng [Đon vị] ");
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(255, 26);
            this.TitleLbl.Size = new System.Drawing.Size(157, 33);
            // 
            // accountSource
            // 
            this.accountSource.AllowNew = false;
            this.accountSource.DataMember = "Account";
            this.accountSource.DataSource = this.myMasterDataSet;
            // 
            // accountEd
            // 
            this.accountEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountEd.Location = new System.Drawing.Point(641, 37);
            this.accountEd.Margin = new System.Windows.Forms.Padding(4);
            this.accountEd.Name = "accountEd";
            this.accountEd.Size = new System.Drawing.Size(75, 24);
            this.accountEd.TabIndex = 2;
            this.accountEd.Text = "1111";
            this.accountEd.Visible = false;
            this.accountEd.Validating += new System.ComponentModel.CancelEventHandler(this.accountEd_Validating);
            // 
            // accountLbl
            // 
            this.accountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountLbl.Location = new System.Drawing.Point(521, 40);
            this.accountLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.accountLbl.Name = "accountLbl";
            this.accountLbl.Size = new System.Drawing.Size(71, 19);
            this.accountLbl.TabIndex = 111;
            this.accountLbl.Text = "Tài  khoản";
            this.accountLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // debitCreditCb
            // 
            this.debitCreditCb.BackColor = System.Drawing.SystemColors.Info;
            this.debitCreditCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.debitCreditCb.FormattingEnabled = true;
            this.debitCreditCb.Items.AddRange(new object[] {
            "Nợ",
            "Có"});
            this.debitCreditCb.Location = new System.Drawing.Point(594, 37);
            this.debitCreditCb.Name = "debitCreditCb";
            this.debitCreditCb.Size = new System.Drawing.Size(48, 24);
            this.debitCreditCb.TabIndex = 1;
            this.debitCreditCb.TabStop = false;
            // 
            // voucherDetailsTableAdapter
            // 
            this.voucherDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // accountTableAdapter
            // 
            this.accountTableAdapter.ClearBeforeFill = true;
            // 
            // voucherDetailsSource
            // 
            this.voucherDetailsSource.DataMember = "VoucherDetails";
            this.voucherDetailsSource.DataSource = this.myApplicationDataSet;
            // 
            // baseVoucherEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 548);
            this.Controls.Add(this.accountLbl);
            this.Controls.Add(this.accountEd);
            this.Controls.Add(this.debitCreditCb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "baseVoucherEntry";
            this.Text = "Phieu thu";
            this.Load += new System.EventHandler(this.voucherEntry_Load);
            this.Controls.SetChildIndex(this.custCodeChk, 0);
            this.Controls.SetChildIndex(this.toolBarGroup, 0);
            this.Controls.SetChildIndex(this.personNameEd, 0);
            this.Controls.SetChildIndex(this.personNameLbl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.custIdCardEd, 0);
            this.Controls.SetChildIndex(this.custNameEd, 0);
            this.Controls.SetChildIndex(this.custIdCardLbl, 0);
            this.Controls.SetChildIndex(this.custAddressEd, 0);
            this.Controls.SetChildIndex(this.custNameLbl, 0);
            this.Controls.SetChildIndex(this.custTaxCodeEd, 0);
            this.Controls.SetChildIndex(this.custTaxCodeLbl, 0);
            this.Controls.SetChildIndex(this.custAddressLbl, 0);
            this.Controls.SetChildIndex(this.seriEd, 0);
            this.Controls.SetChildIndex(this.seriLbl, 0);
            this.Controls.SetChildIndex(this.bookNoEd, 0);
            this.Controls.SetChildIndex(this.custCodeEd, 0);
            this.Controls.SetChildIndex(this.bookLbl, 0);
            this.Controls.SetChildIndex(this.orderNoLbl, 0);
            this.Controls.SetChildIndex(this.voucherNoEd, 0);
            this.Controls.SetChildIndex(this.dateEd, 0);
            this.Controls.SetChildIndex(this.dateLbl, 0);
            this.Controls.SetChildIndex(this.invoiceChk, 0);
            this.Controls.SetChildIndex(this.documentNoteEd, 0);
            this.Controls.SetChildIndex(this.descLbl, 0);
            this.Controls.SetChildIndex(this.voucherIdEd, 0);
            this.Controls.SetChildIndex(this.refNoLbl, 0);
            this.Controls.SetChildIndex(this.subTotalLbl, 0);
            this.Controls.SetChildIndex(this.subTotalEd, 0);
            this.Controls.SetChildIndex(this.invoiceNoEd, 0);
            this.Controls.SetChildIndex(this.debitCreditCb, 0);
            this.Controls.SetChildIndex(this.accountEd, 0);
            this.Controls.SetChildIndex(this.accountLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.voucherSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myApplicationDataSet)).EndInit();
            this.toolBarGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myMasterDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysAutoIncreaseSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkerSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherDetailsSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private data.masterDataSetTableAdapters.AccountTableAdapter accountTableAdapter;
        protected System.Windows.Forms.ComboBox debitCreditCb;
        protected data.applicationDataSetTableAdapters.VoucherDetailsTableAdapter voucherDetailsTableAdapter;
        protected System.Windows.Forms.BindingSource voucherDetailsSource;
        protected System.Windows.Forms.TextBox accountEd;
        protected System.Windows.Forms.BindingSource accountSource;
        protected System.Windows.Forms.Label accountLbl;
    }
}