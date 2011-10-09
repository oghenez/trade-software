namespace baseClass
{
    partial class licenseCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(licenseCheck));
            common.hardware.mySysInfo mySysInfo1 = new common.hardware.mySysInfo();
            common.license.myLicenseItem myLicenseItem1 = new common.license.myLicenseItem();
            this.SuspendLayout();
            // 
            // viewLicenceBtn
            // 
            this.viewLicenceBtn.Text = "View";
            // 
            // exportBtn
            // 
            this.exportBtn.Text = "Export";
            // 
            // vendorNameLbl
            // 
            this.vendorNameLbl.Size = new System.Drawing.Size(55, 16);
            this.vendorNameLbl.Text = "Vendor";
            // 
            // faxEd
            // 
            this.faxEd.BackColor = System.Drawing.SystemColors.Info;
            // 
            // phoneLbl
            // 
            this.phoneLbl.Size = new System.Drawing.Size(48, 16);
            this.phoneLbl.Text = "Phone";
            // 
            // phoneEd
            // 
            this.phoneEd.BackColor = System.Drawing.SystemColors.Info;
            // 
            // addressLbl
            // 
            this.addressLbl.Size = new System.Drawing.Size(74, 16);
            this.addressLbl.Text = "Address 1";
            // 
            // addressEd
            // 
            this.addressEd.BackColor = System.Drawing.SystemColors.Info;
            // 
            // prodCodeLbl
            // 
            this.prodCodeLbl.Size = new System.Drawing.Size(95, 16);
            this.prodCodeLbl.Text = "Product Code";
            // 
            // serialLbl
            // 
            this.serialLbl.Size = new System.Drawing.Size(64, 16);
            this.serialLbl.Text = "Serial No";
            // 
            // serialEd
            // 
            this.serialEd.BackColor = System.Drawing.SystemColors.Info;
            // 
            // toDateLbl
            // 
            this.toDateLbl.Size = new System.Drawing.Size(75, 16);
            this.toDateLbl.Text = "Expired on";
            // 
            // toDateEd
            // 
            this.toDateEd.BackColor = System.Drawing.SystemColors.Info;
            // 
            // emailEd
            // 
            this.emailEd.BackColor = System.Drawing.SystemColors.Info;
            // 
            // companyLbl
            // 
            this.companyLbl.Size = new System.Drawing.Size(67, 16);
            this.companyLbl.Text = "Company";
            // 
            // companyEd
            // 
            this.companyEd.BackColor = System.Drawing.SystemColors.Info;
            // 
            // hwInfoBtn
            // 
            this.hwInfoBtn.Text = "Hardware";
            // 
            // closeBtn
            // 
            this.closeBtn.Text = "Close";
            // 
            // okBtn
            // 
            this.okBtn.Text = "Ok";
            // 
            // licenseCheck
            // 
            this.ClientSize = new System.Drawing.Size(477, 319);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.myHwInfo = mySysInfo1;
            this.myLicense = myLicenseItem1;
            this.Name = "licenseCheck";
            this.Text = "Ban quyen su dung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


    }
}

