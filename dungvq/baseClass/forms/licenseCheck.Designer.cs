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
            // vendorNameLbl
            // 
            this.vendorNameLbl.Location = new System.Drawing.Point(25, 34);
            // 
            // vendorNameEd
            // 
            this.vendorNameEd.Location = new System.Drawing.Point(26, 53);
            // 
            // faxLbl
            // 
            this.faxLbl.Location = new System.Drawing.Point(349, 174);
            // 
            // faxEd
            // 
            this.faxEd.BackColor = System.Drawing.SystemColors.Info;
            this.faxEd.Location = new System.Drawing.Point(349, 194);
            // 
            // phoneLbl
            // 
            this.phoneLbl.Location = new System.Drawing.Point(259, 174);
            // 
            // phoneEd
            // 
            this.phoneEd.BackColor = System.Drawing.SystemColors.Info;
            this.phoneEd.Location = new System.Drawing.Point(259, 194);
            // 
            // addressLbl
            // 
            this.addressLbl.Location = new System.Drawing.Point(25, 125);
            // 
            // addressEd
            // 
            this.addressEd.BackColor = System.Drawing.SystemColors.Info;
            this.addressEd.Location = new System.Drawing.Point(26, 145);
            // 
            // prodCodeLbl
            // 
            this.prodCodeLbl.Location = new System.Drawing.Point(314, 34);
            // 
            // prodCodeEd
            // 
            this.prodCodeEd.Location = new System.Drawing.Point(313, 53);
            // 
            // serialLbl
            // 
            this.serialLbl.Location = new System.Drawing.Point(134, 219);
            // 
            // serialEd
            // 
            this.serialEd.BackColor = System.Drawing.SystemColors.Info;
            this.serialEd.Location = new System.Drawing.Point(136, 240);
            // 
            // toDateLbl
            // 
            this.toDateLbl.Location = new System.Drawing.Point(25, 219);
            // 
            // toDateEd
            // 
            this.toDateEd.BackColor = System.Drawing.SystemColors.Info;
            this.toDateEd.Location = new System.Drawing.Point(26, 240);
            // 
            // emailLbl
            // 
            this.emailLbl.Location = new System.Drawing.Point(25, 175);
            // 
            // emailEd
            // 
            this.emailEd.BackColor = System.Drawing.SystemColors.Info;
            this.emailEd.Location = new System.Drawing.Point(26, 194);
            // 
            // companyLbl
            // 
            this.companyLbl.Location = new System.Drawing.Point(25, 80);
            // 
            // companyEd
            // 
            this.companyEd.BackColor = System.Drawing.SystemColors.Info;
            this.companyEd.Location = new System.Drawing.Point(26, 99);
            // 
            // licenseCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 352);
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

