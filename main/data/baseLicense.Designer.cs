namespace common.forms
{
    partial class baseLicense
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
            this.companyEd = new common.control.baseTextBox();
            this.companyLbl = new System.Windows.Forms.Label();
            this.emailLbl = new System.Windows.Forms.Label();
            this.emailEd = new common.control.baseTextBox();
            this.toDateLbl = new System.Windows.Forms.Label();
            this.toDateEd = new common.control.txtDateTime();
            this.serialLbl = new System.Windows.Forms.Label();
            this.serialEd = new common.control.baseTextBox();
            this.prodCodeLbl = new System.Windows.Forms.Label();
            this.prodCodeEd = new common.control.baseTextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.addressLbl = new System.Windows.Forms.Label();
            this.addressEd = new common.control.baseTextBox();
            this.phoneLbl = new System.Windows.Forms.Label();
            this.phoneEd = new common.control.baseTextBox();
            this.faxLbl = new System.Windows.Forms.Label();
            this.faxEd = new common.control.baseTextBox();
            this.vendorNameLbl = new System.Windows.Forms.Label();
            this.vendorNameEd = new common.control.baseTextBox();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Image = global::common.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeBtn.Location = new System.Drawing.Point(403, 286);
            this.closeBtn.Size = new System.Drawing.Size(65, 49);
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // okBtn
            // 
            this.okBtn.Image = global::common.Properties.Resources.saveBtn_Image;
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.okBtn.Location = new System.Drawing.Point(316, 286);
            this.okBtn.Size = new System.Drawing.Size(65, 49);
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.Location = new System.Drawing.Point(1, 2);
            this.TitleLbl.Size = new System.Drawing.Size(492, 26);
            this.TitleLbl.Text = "BẢN QUYỀN";
            // 
            // companyEd
            // 
            this.companyEd.BeepOnError = true;
            this.companyEd.Location = new System.Drawing.Point(30, 106);
            this.companyEd.Name = "companyEd";
            this.companyEd.Size = new System.Drawing.Size(436, 24);
            this.companyEd.TabIndex = 10;
            // 
            // companyLbl
            // 
            this.companyLbl.AutoSize = true;
            this.companyLbl.Location = new System.Drawing.Point(29, 85);
            this.companyLbl.Name = "companyLbl";
            this.companyLbl.Size = new System.Drawing.Size(116, 18);
            this.companyLbl.TabIndex = 149;
            this.companyLbl.Text = "Đơn vị sử dụng *";
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(29, 182);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(98, 18);
            this.emailLbl.TabIndex = 151;
            this.emailLbl.Text = "Địa chỉ email*";
            // 
            // emailEd
            // 
            this.emailEd.BeepOnError = true;
            this.emailEd.Location = new System.Drawing.Point(30, 203);
            this.emailEd.Name = "emailEd";
            this.emailEd.Size = new System.Drawing.Size(257, 24);
            this.emailEd.TabIndex = 20;
            // 
            // toDateLbl
            // 
            this.toDateLbl.AutoSize = true;
            this.toDateLbl.Location = new System.Drawing.Point(29, 234);
            this.toDateLbl.Name = "toDateLbl";
            this.toDateLbl.Size = new System.Drawing.Size(108, 18);
            this.toDateLbl.TabIndex = 153;
            this.toDateLbl.Text = "Cấp đến ngày *";
            // 
            // toDateEd
            // 
            this.toDateEd.BeepOnError = true;
            this.toDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.toDateEd.Location = new System.Drawing.Point(30, 255);
            this.toDateEd.Mask = "00/00/0000";
            this.toDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.toDateEd.Name = "toDateEd";
            this.toDateEd.Size = new System.Drawing.Size(131, 24);
            this.toDateEd.TabIndex = 30;
            this.toDateEd.Text = "110001";
            // 
            // serialLbl
            // 
            this.serialLbl.AutoSize = true;
            this.serialLbl.Location = new System.Drawing.Point(160, 234);
            this.serialLbl.Name = "serialLbl";
            this.serialLbl.Size = new System.Drawing.Size(55, 18);
            this.serialLbl.TabIndex = 155;
            this.serialLbl.Text = "Số sêri";
            // 
            // serialEd
            // 
            this.serialEd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.serialEd.BeepOnError = true;
            this.serialEd.Location = new System.Drawing.Point(162, 255);
            this.serialEd.Name = "serialEd";
            this.serialEd.ReadOnly = true;
            this.serialEd.Size = new System.Drawing.Size(305, 24);
            this.serialEd.TabIndex = 31;
            // 
            // prodCodeLbl
            // 
            this.prodCodeLbl.AutoSize = true;
            this.prodCodeLbl.Location = new System.Drawing.Point(342, 35);
            this.prodCodeLbl.Name = "prodCodeLbl";
            this.prodCodeLbl.Size = new System.Drawing.Size(98, 18);
            this.prodCodeLbl.TabIndex = 157;
            this.prodCodeLbl.Text = "Mã sản phẩm";
            // 
            // prodCodeEd
            // 
            this.prodCodeEd.BackColor = System.Drawing.SystemColors.Info;
            this.prodCodeEd.BeepOnError = true;
            this.prodCodeEd.Enabled = false;
            this.prodCodeEd.Location = new System.Drawing.Point(341, 56);
            this.prodCodeEd.Name = "prodCodeEd";
            this.prodCodeEd.Size = new System.Drawing.Size(126, 24);
            this.prodCodeEd.TabIndex = 2;
            // 
            // addressLbl
            // 
            this.addressLbl.AutoSize = true;
            this.addressLbl.Location = new System.Drawing.Point(29, 134);
            this.addressLbl.Name = "addressLbl";
            this.addressLbl.Size = new System.Drawing.Size(63, 18);
            this.addressLbl.TabIndex = 159;
            this.addressLbl.Text = "Địa chỉ *";
            // 
            // addressEd
            // 
            this.addressEd.BeepOnError = true;
            this.addressEd.Location = new System.Drawing.Point(30, 155);
            this.addressEd.Name = "addressEd";
            this.addressEd.Size = new System.Drawing.Size(436, 24);
            this.addressEd.TabIndex = 11;
            // 
            // phoneLbl
            // 
            this.phoneLbl.AutoSize = true;
            this.phoneLbl.Location = new System.Drawing.Point(287, 181);
            this.phoneLbl.Name = "phoneLbl";
            this.phoneLbl.Size = new System.Drawing.Size(74, 18);
            this.phoneLbl.TabIndex = 161;
            this.phoneLbl.Text = "Điện thọai";
            // 
            // phoneEd
            // 
            this.phoneEd.BeepOnError = true;
            this.phoneEd.Location = new System.Drawing.Point(287, 203);
            this.phoneEd.Name = "phoneEd";
            this.phoneEd.Size = new System.Drawing.Size(90, 24);
            this.phoneEd.TabIndex = 21;
            // 
            // faxLbl
            // 
            this.faxLbl.AutoSize = true;
            this.faxLbl.Location = new System.Drawing.Point(377, 181);
            this.faxLbl.Name = "faxLbl";
            this.faxLbl.Size = new System.Drawing.Size(32, 18);
            this.faxLbl.TabIndex = 163;
            this.faxLbl.Text = "Fax";
            // 
            // faxEd
            // 
            this.faxEd.BeepOnError = true;
            this.faxEd.Location = new System.Drawing.Point(377, 203);
            this.faxEd.Name = "faxEd";
            this.faxEd.Size = new System.Drawing.Size(90, 24);
            this.faxEd.TabIndex = 22;
            // 
            // vendorNameLbl
            // 
            this.vendorNameLbl.AutoSize = true;
            this.vendorNameLbl.Location = new System.Drawing.Point(29, 35);
            this.vendorNameLbl.Name = "vendorNameLbl";
            this.vendorNameLbl.Size = new System.Drawing.Size(99, 18);
            this.vendorNameLbl.TabIndex = 165;
            this.vendorNameLbl.Text = "Nhà cung cấp";
            // 
            // vendorNameEd
            // 
            this.vendorNameEd.BackColor = System.Drawing.SystemColors.Info;
            this.vendorNameEd.BeepOnError = true;
            this.vendorNameEd.Enabled = false;
            this.vendorNameEd.Location = new System.Drawing.Point(30, 56);
            this.vendorNameEd.Name = "vendorNameEd";
            this.vendorNameEd.Size = new System.Drawing.Size(311, 24);
            this.vendorNameEd.TabIndex = 1;
            // 
            // baseLicense
            // 
            this.ClientSize = new System.Drawing.Size(492, 366);
            this.Controls.Add(this.vendorNameLbl);
            this.Controls.Add(this.vendorNameEd);
            this.Controls.Add(this.faxLbl);
            this.Controls.Add(this.faxEd);
            this.Controls.Add(this.phoneLbl);
            this.Controls.Add(this.phoneEd);
            this.Controls.Add(this.addressLbl);
            this.Controls.Add(this.addressEd);
            this.Controls.Add(this.prodCodeLbl);
            this.Controls.Add(this.prodCodeEd);
            this.Controls.Add(this.serialLbl);
            this.Controls.Add(this.serialEd);
            this.Controls.Add(this.toDateLbl);
            this.Controls.Add(this.toDateEd);
            this.Controls.Add(this.emailLbl);
            this.Controls.Add(this.emailEd);
            this.Controls.Add(this.companyLbl);
            this.Controls.Add(this.companyEd);
            this.Name = "baseLicense";
            this.Text = "Ban quyen";
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.companyEd, 0);
            this.Controls.SetChildIndex(this.companyLbl, 0);
            this.Controls.SetChildIndex(this.emailEd, 0);
            this.Controls.SetChildIndex(this.emailLbl, 0);
            this.Controls.SetChildIndex(this.toDateEd, 0);
            this.Controls.SetChildIndex(this.toDateLbl, 0);
            this.Controls.SetChildIndex(this.serialEd, 0);
            this.Controls.SetChildIndex(this.serialLbl, 0);
            this.Controls.SetChildIndex(this.prodCodeEd, 0);
            this.Controls.SetChildIndex(this.prodCodeLbl, 0);
            this.Controls.SetChildIndex(this.addressEd, 0);
            this.Controls.SetChildIndex(this.addressLbl, 0);
            this.Controls.SetChildIndex(this.phoneEd, 0);
            this.Controls.SetChildIndex(this.phoneLbl, 0);
            this.Controls.SetChildIndex(this.faxEd, 0);
            this.Controls.SetChildIndex(this.faxLbl, 0);
            this.Controls.SetChildIndex(this.vendorNameEd, 0);
            this.Controls.SetChildIndex(this.vendorNameLbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseTextBox companyEd;
        protected System.Windows.Forms.Label companyLbl;
        protected System.Windows.Forms.Label emailLbl;
        protected common.control.baseTextBox emailEd;
        protected System.Windows.Forms.Label toDateLbl;
        protected common.control.txtDateTime toDateEd;
        protected System.Windows.Forms.Label serialLbl;
        protected common.control.baseTextBox serialEd;
        protected System.Windows.Forms.Label prodCodeLbl;
        protected common.control.baseTextBox prodCodeEd;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected System.Windows.Forms.OpenFileDialog openFileDialog;
        protected System.Windows.Forms.Label addressLbl;
        protected common.control.baseTextBox addressEd;
        protected System.Windows.Forms.Label phoneLbl;
        protected common.control.baseTextBox phoneEd;
        protected System.Windows.Forms.Label faxLbl;
        protected common.control.baseTextBox faxEd;
        protected System.Windows.Forms.Label vendorNameLbl;
        protected common.control.baseTextBox vendorNameEd;
    }
}
