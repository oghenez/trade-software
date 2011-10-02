namespace setup.forms
{
    partial class sysOptionsMenuItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sysOptionsMenuItem));
            this.mainTab = new System.Windows.Forms.TabControl();
            this.setupPg = new System.Windows.Forms.TabPage();
            this.systemTab = new System.Windows.Forms.TabControl();
            this.generalPg = new System.Windows.Forms.TabPage();
            this.useStrongPassChk = new System.Windows.Forms.CheckBox();
            this.cultureCode = new System.Windows.Forms.Label();
            this.cultureCodeEd = new common.controls.baseComboBox();
            this.pwdMinLenLbl1 = new System.Windows.Forms.Label();
            this.passwordMinLenEd = new System.Windows.Forms.NumericUpDown();
            this.pwdMinLenLbl = new System.Windows.Forms.Label();
            this.debugModeChk = new System.Windows.Forms.CheckBox();
            this.autoKeyPg = new System.Windows.Forms.TabPage();
            this.autoVoucheNoFormatLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sysAutoEditKeySizeEd = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.timeOutAutoKeyLbl1 = new System.Windows.Forms.Label();
            this.timeOutAutoKeyLbl = new System.Windows.Forms.Label();
            this.timeOutAutoKeyEd = new System.Windows.Forms.NumericUpDown();
            this.sysAutoDataKeySizeEd = new System.Windows.Forms.NumericUpDown();
            this.dataKeyPrefixLbl = new System.Windows.Forms.Label();
            this.sysDataKeyPrefixEd = new common.controls.baseMaskedTextBox();
            this.formatPg = new System.Windows.Forms.TabPage();
            this.percentPrecisionEd = new System.Windows.Forms.NumericUpDown();
            this.qtyPrecisionEd = new System.Windows.Forms.NumericUpDown();
            this.foreignAmtPrecisionEd = new System.Windows.Forms.NumericUpDown();
            this.localAmtPrecisionEd = new System.Windows.Forms.NumericUpDown();
            this.percentMaskLbl = new System.Windows.Forms.Label();
            this.qtyMaskLbl = new System.Windows.Forms.Label();
            this.foreignAmtMaskLbl = new System.Windows.Forms.Label();
            this.localAmtMaskLbl = new System.Windows.Forms.Label();
            this.percentMaskEd = new common.controls.baseMaskedTextBox();
            this.qtyMaskEd = new common.controls.baseMaskedTextBox();
            this.foreignAmtMaskEd = new common.controls.baseMaskedTextBox();
            this.localAmtMaskEd = new common.controls.baseMaskedTextBox();
            this.emailPg = new System.Windows.Forms.TabPage();
            this.smtpPortLbl = new System.Windows.Forms.Label();
            this.smtpAuthPasswordEd = new common.controls.baseMaskedTextBox();
            this.smtpAuthPasswordLbl = new System.Windows.Forms.Label();
            this.smtpAuthAccountEd = new common.controls.baseMaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.smtpSSLChk = new System.Windows.Forms.CheckBox();
            this.smtpPortEd = new common.controls.baseMaskedTextBox();
            this.smtpServerLbl = new System.Windows.Forms.Label();
            this.smtpServerEd = new common.controls.baseMaskedTextBox();
            this.uploadPg = new System.Windows.Forms.TabPage();
            this.fsCopyModeGb = new System.Windows.Forms.GroupBox();
            this.uploadDataDirNoteLbl = new System.Windows.Forms.Label();
            this.uploadDataDirLbl = new System.Windows.Forms.Label();
            this.uploadDataDirEd = new common.controls.baseTextBox();
            this.httpProtoGb = new System.Windows.Forms.GroupBox();
            this.uploadScriptFileLbl = new System.Windows.Forms.Label();
            this.uploadScriptFileEd = new common.controls.baseTextBox();
            this.showPassChk = new System.Windows.Forms.CheckBox();
            this.uploadUrlNoteLbl = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.uploadPwdEd = new common.controls.baseTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.uploadAccountEd = new common.controls.baseTextBox();
            this.uploadUrlLbl = new System.Windows.Forms.Label();
            this.uploadUrlEd = new common.controls.baseTextBox();
            this.uploadModeCb = new common.controls.cbUploadMethod();
            this.label19 = new System.Windows.Forms.Label();
            this.otherPg = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dataStartDateEd = new common.controls.baseDate();
            this.dateLbl = new System.Windows.Forms.Label();
            this.currencyLbl = new System.Windows.Forms.Label();
            this.currencyCb = new baseClass.controls.cbCurrency();
            this.defauCompanyCodeEd = new common.controls.baseMaskedTextBox();
            this.reportPg = new System.Windows.Forms.TabPage();
            this.repoSignerTitle_whManagerEd = new common.controls.baseMaskedTextBox();
            this.repoSignerTitle_whManagerLbl = new System.Windows.Forms.Label();
            this.repoSignerTitle_CashierEd = new common.controls.baseMaskedTextBox();
            this.repoSignerTitle_CashierLbl = new System.Windows.Forms.Label();
            this.repoSignerTitle_CreatorEd = new common.controls.baseMaskedTextBox();
            this.repoSignerTitle_CreatorLbl = new System.Windows.Forms.Label();
            this.repoSignerTitle_ChiefAcctEd = new common.controls.baseMaskedTextBox();
            this.repoSignerTitle_ChiefAcctLbl = new System.Windows.Forms.Label();
            this.repoSignerTitle_DirectorEd = new common.controls.baseMaskedTextBox();
            this.repoSignerTitle_DirectorLbl = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.mainTab.SuspendLayout();
            this.setupPg.SuspendLayout();
            this.systemTab.SuspendLayout();
            this.generalPg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordMinLenEd)).BeginInit();
            this.autoKeyPg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sysAutoEditKeySizeEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeOutAutoKeyEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysAutoDataKeySizeEd)).BeginInit();
            this.formatPg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentPrecisionEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyPrecisionEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foreignAmtPrecisionEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localAmtPrecisionEd)).BeginInit();
            this.emailPg.SuspendLayout();
            this.uploadPg.SuspendLayout();
            this.fsCopyModeGb.SuspendLayout();
            this.httpProtoGb.SuspendLayout();
            this.otherPg.SuspendLayout();
            this.reportPg.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(834, 236);
            this.TitleLbl.Size = new System.Drawing.Size(46, 29);
            this.TitleLbl.Text = "THIẾT LẬP THÔNG SỐ";
            this.TitleLbl.Visible = false;
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.setupPg);
            this.mainTab.Controls.Add(this.reportPg);
            this.mainTab.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.mainTab.Location = new System.Drawing.Point(0, 2);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(420, 354);
            this.mainTab.TabIndex = 1;
            // 
            // setupPg
            // 
            this.setupPg.Controls.Add(this.systemTab);
            this.setupPg.Location = new System.Drawing.Point(4, 25);
            this.setupPg.Name = "setupPg";
            this.setupPg.Padding = new System.Windows.Forms.Padding(3);
            this.setupPg.Size = new System.Drawing.Size(412, 325);
            this.setupPg.TabIndex = 0;
            this.setupPg.Text = "Hệ thống";
            this.setupPg.UseVisualStyleBackColor = true;
            // 
            // systemTab
            // 
            this.systemTab.Controls.Add(this.generalPg);
            this.systemTab.Controls.Add(this.autoKeyPg);
            this.systemTab.Controls.Add(this.formatPg);
            this.systemTab.Controls.Add(this.emailPg);
            this.systemTab.Controls.Add(this.uploadPg);
            this.systemTab.Controls.Add(this.otherPg);
            this.systemTab.Location = new System.Drawing.Point(-3, 3);
            this.systemTab.Name = "systemTab";
            this.systemTab.SelectedIndex = 0;
            this.systemTab.Size = new System.Drawing.Size(419, 288);
            this.systemTab.TabIndex = 146;
            // 
            // generalPg
            // 
            this.generalPg.Controls.Add(this.useStrongPassChk);
            this.generalPg.Controls.Add(this.cultureCode);
            this.generalPg.Controls.Add(this.cultureCodeEd);
            this.generalPg.Controls.Add(this.pwdMinLenLbl1);
            this.generalPg.Controls.Add(this.passwordMinLenEd);
            this.generalPg.Controls.Add(this.pwdMinLenLbl);
            this.generalPg.Controls.Add(this.debugModeChk);
            this.generalPg.Location = new System.Drawing.Point(4, 25);
            this.generalPg.Name = "generalPg";
            this.generalPg.Padding = new System.Windows.Forms.Padding(3);
            this.generalPg.Size = new System.Drawing.Size(411, 259);
            this.generalPg.TabIndex = 1;
            this.generalPg.Text = "Chung";
            this.generalPg.UseVisualStyleBackColor = true;
            // 
            // useStrongPassChk
            // 
            this.useStrongPassChk.AutoSize = true;
            this.useStrongPassChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useStrongPassChk.Location = new System.Drawing.Point(105, 112);
            this.useStrongPassChk.Name = "useStrongPassChk";
            this.useStrongPassChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.useStrongPassChk.Size = new System.Drawing.Size(163, 20);
            this.useStrongPassChk.TabIndex = 3;
            this.useStrongPassChk.Text = "Dùng mật khẩu mạnh";
            this.useStrongPassChk.UseVisualStyleBackColor = true;
            // 
            // cultureCode
            // 
            this.cultureCode.AutoSize = true;
            this.cultureCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cultureCode.Location = new System.Drawing.Point(105, 47);
            this.cultureCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cultureCode.Name = "cultureCode";
            this.cultureCode.Size = new System.Drawing.Size(63, 16);
            this.cultureCode.TabIndex = 215;
            this.cultureCode.Text = "Mã vùng";
            // 
            // cultureCodeEd
            // 
            this.cultureCodeEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cultureCodeEd.Items.AddRange(new object[] {
            "vi-VN",
            "us-US"});
            this.cultureCodeEd.Location = new System.Drawing.Point(188, 46);
            this.cultureCodeEd.myValue = "";
            this.cultureCodeEd.Name = "cultureCodeEd";
            this.cultureCodeEd.Size = new System.Drawing.Size(80, 24);
            this.cultureCodeEd.TabIndex = 1;
            // 
            // pwdMinLenLbl1
            // 
            this.pwdMinLenLbl1.AutoSize = true;
            this.pwdMinLenLbl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdMinLenLbl1.Location = new System.Drawing.Point(240, 80);
            this.pwdMinLenLbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pwdMinLenLbl1.Name = "pwdMinLenLbl1";
            this.pwdMinLenLbl1.Size = new System.Drawing.Size(46, 16);
            this.pwdMinLenLbl1.TabIndex = 213;
            this.pwdMinLenLbl1.Text = "ký tự ";
            // 
            // passwordMinLenEd
            // 
            this.passwordMinLenEd.Location = new System.Drawing.Point(188, 77);
            this.passwordMinLenEd.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.passwordMinLenEd.Name = "passwordMinLenEd";
            this.passwordMinLenEd.Size = new System.Drawing.Size(45, 23);
            this.passwordMinLenEd.TabIndex = 2;
            this.passwordMinLenEd.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // pwdMinLenLbl
            // 
            this.pwdMinLenLbl.AutoSize = true;
            this.pwdMinLenLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdMinLenLbl.Location = new System.Drawing.Point(105, 80);
            this.pwdMinLenLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pwdMinLenLbl.Name = "pwdMinLenLbl";
            this.pwdMinLenLbl.Size = new System.Drawing.Size(68, 16);
            this.pwdMinLenLbl.TabIndex = 212;
            this.pwdMinLenLbl.Text = "Mật khẩu";
            // 
            // debugModeChk
            // 
            this.debugModeChk.AutoSize = true;
            this.debugModeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugModeChk.Location = new System.Drawing.Point(105, 145);
            this.debugModeChk.Name = "debugModeChk";
            this.debugModeChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.debugModeChk.Size = new System.Drawing.Size(194, 20);
            this.debugModeChk.TabIndex = 4;
            this.debugModeChk.Text = "Bật chế độ tìm lỗi (debug)";
            this.debugModeChk.UseVisualStyleBackColor = true;
            // 
            // autoKeyPg
            // 
            this.autoKeyPg.Controls.Add(this.autoVoucheNoFormatLbl);
            this.autoKeyPg.Controls.Add(this.label7);
            this.autoKeyPg.Controls.Add(this.label6);
            this.autoKeyPg.Controls.Add(this.label5);
            this.autoKeyPg.Controls.Add(this.sysAutoEditKeySizeEd);
            this.autoKeyPg.Controls.Add(this.label1);
            this.autoKeyPg.Controls.Add(this.timeOutAutoKeyLbl1);
            this.autoKeyPg.Controls.Add(this.timeOutAutoKeyLbl);
            this.autoKeyPg.Controls.Add(this.timeOutAutoKeyEd);
            this.autoKeyPg.Controls.Add(this.sysAutoDataKeySizeEd);
            this.autoKeyPg.Controls.Add(this.dataKeyPrefixLbl);
            this.autoKeyPg.Controls.Add(this.sysDataKeyPrefixEd);
            this.autoKeyPg.Location = new System.Drawing.Point(4, 25);
            this.autoKeyPg.Name = "autoKeyPg";
            this.autoKeyPg.Padding = new System.Windows.Forms.Padding(3);
            this.autoKeyPg.Size = new System.Drawing.Size(411, 259);
            this.autoKeyPg.TabIndex = 0;
            this.autoKeyPg.Text = "Số tự động";
            this.autoKeyPg.UseVisualStyleBackColor = true;
            // 
            // autoVoucheNoFormatLbl
            // 
            this.autoVoucheNoFormatLbl.AutoSize = true;
            this.autoVoucheNoFormatLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoVoucheNoFormatLbl.Location = new System.Drawing.Point(50, 155);
            this.autoVoucheNoFormatLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.autoVoucheNoFormatLbl.Name = "autoVoucheNoFormatLbl";
            this.autoVoucheNoFormatLbl.Size = new System.Drawing.Size(147, 16);
            this.autoVoucheNoFormatLbl.TabIndex = 217;
            this.autoVoucheNoFormatLbl.Text = "Định dạng số tự động";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(313, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 215;
            this.label7.Text = "ký tự";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(313, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 214;
            this.label6.Text = "ký tự";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 97);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 16);
            this.label5.TabIndex = 213;
            this.label5.Text = "Độ dài tối đa của số tự động";
            // 
            // sysAutoEditKeySizeEd
            // 
            this.sysAutoEditKeySizeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.sysAutoEditKeySizeEd.Location = new System.Drawing.Point(254, 95);
            this.sysAutoEditKeySizeEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sysAutoEditKeySizeEd.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sysAutoEditKeySizeEd.Name = "sysAutoEditKeySizeEd";
            this.sysAutoEditKeySizeEd.Size = new System.Drawing.Size(53, 24);
            this.sysAutoEditKeySizeEd.TabIndex = 3;
            this.sysAutoEditKeySizeEd.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 16);
            this.label1.TabIndex = 211;
            this.label1.Text = "Độ dài tối đa của dữ liệu khóa";
            // 
            // timeOutAutoKeyLbl1
            // 
            this.timeOutAutoKeyLbl1.AutoSize = true;
            this.timeOutAutoKeyLbl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeOutAutoKeyLbl1.Location = new System.Drawing.Point(313, 126);
            this.timeOutAutoKeyLbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeOutAutoKeyLbl1.Name = "timeOutAutoKeyLbl1";
            this.timeOutAutoKeyLbl1.Size = new System.Drawing.Size(35, 16);
            this.timeOutAutoKeyLbl1.TabIndex = 210;
            this.timeOutAutoKeyLbl1.Text = "giây";
            // 
            // timeOutAutoKeyLbl
            // 
            this.timeOutAutoKeyLbl.AutoSize = true;
            this.timeOutAutoKeyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeOutAutoKeyLbl.Location = new System.Drawing.Point(50, 126);
            this.timeOutAutoKeyLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeOutAutoKeyLbl.Name = "timeOutAutoKeyLbl";
            this.timeOutAutoKeyLbl.Size = new System.Drawing.Size(163, 16);
            this.timeOutAutoKeyLbl.TabIndex = 209;
            this.timeOutAutoKeyLbl.Text = "Thời gian giữ số tự động";
            // 
            // timeOutAutoKeyEd
            // 
            this.timeOutAutoKeyEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.timeOutAutoKeyEd.Location = new System.Drawing.Point(254, 123);
            this.timeOutAutoKeyEd.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.timeOutAutoKeyEd.Name = "timeOutAutoKeyEd";
            this.timeOutAutoKeyEd.Size = new System.Drawing.Size(53, 24);
            this.timeOutAutoKeyEd.TabIndex = 4;
            this.timeOutAutoKeyEd.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // sysAutoDataKeySizeEd
            // 
            this.sysAutoDataKeySizeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.sysAutoDataKeySizeEd.Location = new System.Drawing.Point(254, 67);
            this.sysAutoDataKeySizeEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sysAutoDataKeySizeEd.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sysAutoDataKeySizeEd.Name = "sysAutoDataKeySizeEd";
            this.sysAutoDataKeySizeEd.Size = new System.Drawing.Size(53, 24);
            this.sysAutoDataKeySizeEd.TabIndex = 2;
            this.sysAutoDataKeySizeEd.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // dataKeyPrefixLbl
            // 
            this.dataKeyPrefixLbl.AutoSize = true;
            this.dataKeyPrefixLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataKeyPrefixLbl.Location = new System.Drawing.Point(50, 39);
            this.dataKeyPrefixLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataKeyPrefixLbl.Name = "dataKeyPrefixLbl";
            this.dataKeyPrefixLbl.Size = new System.Drawing.Size(161, 16);
            this.dataKeyPrefixLbl.TabIndex = 208;
            this.dataKeyPrefixLbl.Text = "Tiền tố của khóa dữ liệu";
            // 
            // sysDataKeyPrefixEd
            // 
            this.sysDataKeyPrefixEd.BeepOnError = true;
            this.sysDataKeyPrefixEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.sysDataKeyPrefixEd.Location = new System.Drawing.Point(254, 39);
            this.sysDataKeyPrefixEd.Margin = new System.Windows.Forms.Padding(4);
            this.sysDataKeyPrefixEd.Name = "sysDataKeyPrefixEd";
            this.sysDataKeyPrefixEd.Size = new System.Drawing.Size(29, 24);
            this.sysDataKeyPrefixEd.TabIndex = 1;
            this.sysDataKeyPrefixEd.Text = "A";
            // 
            // formatPg
            // 
            this.formatPg.Controls.Add(this.percentPrecisionEd);
            this.formatPg.Controls.Add(this.qtyPrecisionEd);
            this.formatPg.Controls.Add(this.foreignAmtPrecisionEd);
            this.formatPg.Controls.Add(this.localAmtPrecisionEd);
            this.formatPg.Controls.Add(this.percentMaskLbl);
            this.formatPg.Controls.Add(this.qtyMaskLbl);
            this.formatPg.Controls.Add(this.foreignAmtMaskLbl);
            this.formatPg.Controls.Add(this.localAmtMaskLbl);
            this.formatPg.Controls.Add(this.percentMaskEd);
            this.formatPg.Controls.Add(this.qtyMaskEd);
            this.formatPg.Controls.Add(this.foreignAmtMaskEd);
            this.formatPg.Controls.Add(this.localAmtMaskEd);
            this.formatPg.Location = new System.Drawing.Point(4, 22);
            this.formatPg.Name = "formatPg";
            this.formatPg.Padding = new System.Windows.Forms.Padding(3);
            this.formatPg.Size = new System.Drawing.Size(411, 262);
            this.formatPg.TabIndex = 4;
            this.formatPg.Text = "Định dạng";
            this.formatPg.UseVisualStyleBackColor = true;
            // 
            // percentPrecisionEd
            // 
            this.percentPrecisionEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.percentPrecisionEd.Location = new System.Drawing.Point(195, 118);
            this.percentPrecisionEd.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.percentPrecisionEd.Name = "percentPrecisionEd";
            this.percentPrecisionEd.Size = new System.Drawing.Size(46, 24);
            this.percentPrecisionEd.TabIndex = 31;
            // 
            // qtyPrecisionEd
            // 
            this.qtyPrecisionEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.qtyPrecisionEd.Location = new System.Drawing.Point(308, 93);
            this.qtyPrecisionEd.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.qtyPrecisionEd.Name = "qtyPrecisionEd";
            this.qtyPrecisionEd.Size = new System.Drawing.Size(46, 24);
            this.qtyPrecisionEd.TabIndex = 21;
            this.qtyPrecisionEd.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // foreignAmtPrecisionEd
            // 
            this.foreignAmtPrecisionEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.foreignAmtPrecisionEd.Location = new System.Drawing.Point(308, 68);
            this.foreignAmtPrecisionEd.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.foreignAmtPrecisionEd.Name = "foreignAmtPrecisionEd";
            this.foreignAmtPrecisionEd.Size = new System.Drawing.Size(46, 24);
            this.foreignAmtPrecisionEd.TabIndex = 11;
            this.foreignAmtPrecisionEd.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // localAmtPrecisionEd
            // 
            this.localAmtPrecisionEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.localAmtPrecisionEd.Location = new System.Drawing.Point(308, 43);
            this.localAmtPrecisionEd.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.localAmtPrecisionEd.Name = "localAmtPrecisionEd";
            this.localAmtPrecisionEd.Size = new System.Drawing.Size(46, 24);
            this.localAmtPrecisionEd.TabIndex = 2;
            // 
            // percentMaskLbl
            // 
            this.percentMaskLbl.AutoSize = true;
            this.percentMaskLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.percentMaskLbl.Location = new System.Drawing.Point(48, 120);
            this.percentMaskLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.percentMaskLbl.Name = "percentMaskLbl";
            this.percentMaskLbl.Size = new System.Drawing.Size(33, 16);
            this.percentMaskLbl.TabIndex = 202;
            this.percentMaskLbl.Text = "Tỉ lệ";
            // 
            // qtyMaskLbl
            // 
            this.qtyMaskLbl.AutoSize = true;
            this.qtyMaskLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.qtyMaskLbl.Location = new System.Drawing.Point(48, 96);
            this.qtyMaskLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.qtyMaskLbl.Name = "qtyMaskLbl";
            this.qtyMaskLbl.Size = new System.Drawing.Size(64, 16);
            this.qtyMaskLbl.TabIndex = 201;
            this.qtyMaskLbl.Text = "Số lượng";
            // 
            // foreignAmtMaskLbl
            // 
            this.foreignAmtMaskLbl.AutoSize = true;
            this.foreignAmtMaskLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.foreignAmtMaskLbl.Location = new System.Drawing.Point(48, 72);
            this.foreignAmtMaskLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.foreignAmtMaskLbl.Name = "foreignAmtMaskLbl";
            this.foreignAmtMaskLbl.Size = new System.Drawing.Size(65, 16);
            this.foreignAmtMaskLbl.TabIndex = 200;
            this.foreignAmtMaskLbl.Text = "Ngọai  tệ";
            // 
            // localAmtMaskLbl
            // 
            this.localAmtMaskLbl.AutoSize = true;
            this.localAmtMaskLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.localAmtMaskLbl.Location = new System.Drawing.Point(48, 47);
            this.localAmtMaskLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.localAmtMaskLbl.Name = "localAmtMaskLbl";
            this.localAmtMaskLbl.Size = new System.Drawing.Size(74, 16);
            this.localAmtMaskLbl.TabIndex = 199;
            this.localAmtMaskLbl.Text = "Nguyên tệ";
            // 
            // percentMaskEd
            // 
            this.percentMaskEd.BeepOnError = true;
            this.percentMaskEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.percentMaskEd.Location = new System.Drawing.Point(123, 118);
            this.percentMaskEd.Margin = new System.Windows.Forms.Padding(4);
            this.percentMaskEd.Name = "percentMaskEd";
            this.percentMaskEd.Size = new System.Drawing.Size(71, 24);
            this.percentMaskEd.TabIndex = 30;
            this.percentMaskEd.Text = "#0";
            // 
            // qtyMaskEd
            // 
            this.qtyMaskEd.BeepOnError = true;
            this.qtyMaskEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.qtyMaskEd.Location = new System.Drawing.Point(123, 93);
            this.qtyMaskEd.Margin = new System.Windows.Forms.Padding(4);
            this.qtyMaskEd.Name = "qtyMaskEd";
            this.qtyMaskEd.Size = new System.Drawing.Size(184, 24);
            this.qtyMaskEd.TabIndex = 20;
            this.qtyMaskEd.Text = "###,###,##0.00";
            // 
            // foreignAmtMaskEd
            // 
            this.foreignAmtMaskEd.BeepOnError = true;
            this.foreignAmtMaskEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.foreignAmtMaskEd.Location = new System.Drawing.Point(123, 68);
            this.foreignAmtMaskEd.Margin = new System.Windows.Forms.Padding(4);
            this.foreignAmtMaskEd.Name = "foreignAmtMaskEd";
            this.foreignAmtMaskEd.Size = new System.Drawing.Size(184, 24);
            this.foreignAmtMaskEd.TabIndex = 10;
            this.foreignAmtMaskEd.Text = "###,###,###,##0.00";
            // 
            // localAmtMaskEd
            // 
            this.localAmtMaskEd.BeepOnError = true;
            this.localAmtMaskEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.localAmtMaskEd.Location = new System.Drawing.Point(123, 43);
            this.localAmtMaskEd.Margin = new System.Windows.Forms.Padding(4);
            this.localAmtMaskEd.Name = "localAmtMaskEd";
            this.localAmtMaskEd.Size = new System.Drawing.Size(184, 24);
            this.localAmtMaskEd.TabIndex = 1;
            this.localAmtMaskEd.Text = "###,###,###,###,##0";
            // 
            // emailPg
            // 
            this.emailPg.Controls.Add(this.smtpPortLbl);
            this.emailPg.Controls.Add(this.smtpAuthPasswordEd);
            this.emailPg.Controls.Add(this.smtpAuthPasswordLbl);
            this.emailPg.Controls.Add(this.smtpAuthAccountEd);
            this.emailPg.Controls.Add(this.label9);
            this.emailPg.Controls.Add(this.smtpSSLChk);
            this.emailPg.Controls.Add(this.smtpPortEd);
            this.emailPg.Controls.Add(this.smtpServerLbl);
            this.emailPg.Controls.Add(this.smtpServerEd);
            this.emailPg.Location = new System.Drawing.Point(4, 22);
            this.emailPg.Name = "emailPg";
            this.emailPg.Padding = new System.Windows.Forms.Padding(3);
            this.emailPg.Size = new System.Drawing.Size(411, 262);
            this.emailPg.TabIndex = 5;
            this.emailPg.Text = "E-mail";
            this.emailPg.UseVisualStyleBackColor = true;
            // 
            // smtpPortLbl
            // 
            this.smtpPortLbl.AutoSize = true;
            this.smtpPortLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.smtpPortLbl.Location = new System.Drawing.Point(34, 107);
            this.smtpPortLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.smtpPortLbl.Name = "smtpPortLbl";
            this.smtpPortLbl.Size = new System.Drawing.Size(90, 16);
            this.smtpPortLbl.TabIndex = 223;
            this.smtpPortLbl.Text = "Cổng dịch vụ";
            // 
            // smtpAuthPasswordEd
            // 
            this.smtpAuthPasswordEd.BeepOnError = true;
            this.smtpAuthPasswordEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smtpAuthPasswordEd.Location = new System.Drawing.Point(142, 80);
            this.smtpAuthPasswordEd.Margin = new System.Windows.Forms.Padding(4);
            this.smtpAuthPasswordEd.Name = "smtpAuthPasswordEd";
            this.smtpAuthPasswordEd.Size = new System.Drawing.Size(132, 24);
            this.smtpAuthPasswordEd.TabIndex = 3;
            // 
            // smtpAuthPasswordLbl
            // 
            this.smtpAuthPasswordLbl.AutoSize = true;
            this.smtpAuthPasswordLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.smtpAuthPasswordLbl.Location = new System.Drawing.Point(34, 83);
            this.smtpAuthPasswordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.smtpAuthPasswordLbl.Name = "smtpAuthPasswordLbl";
            this.smtpAuthPasswordLbl.Size = new System.Drawing.Size(68, 16);
            this.smtpAuthPasswordLbl.TabIndex = 222;
            this.smtpAuthPasswordLbl.Text = "Mật khẩu";
            // 
            // smtpAuthAccountEd
            // 
            this.smtpAuthAccountEd.BeepOnError = true;
            this.smtpAuthAccountEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smtpAuthAccountEd.Location = new System.Drawing.Point(142, 55);
            this.smtpAuthAccountEd.Margin = new System.Windows.Forms.Padding(4);
            this.smtpAuthAccountEd.Name = "smtpAuthAccountEd";
            this.smtpAuthAccountEd.Size = new System.Drawing.Size(132, 24);
            this.smtpAuthAccountEd.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(34, 59);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 16);
            this.label9.TabIndex = 220;
            this.label9.Text = "T.K xác thực";
            // 
            // smtpSSLChk
            // 
            this.smtpSSLChk.AutoSize = true;
            this.smtpSSLChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.smtpSSLChk.Location = new System.Drawing.Point(34, 130);
            this.smtpSSLChk.Name = "smtpSSLChk";
            this.smtpSSLChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.smtpSSLChk.Size = new System.Drawing.Size(121, 20);
            this.smtpSSLChk.TabIndex = 6;
            this.smtpSSLChk.Text = "Mã hóa (SSL)  ";
            // 
            // smtpPortEd
            // 
            this.smtpPortEd.BeepOnError = true;
            this.smtpPortEd.Enabled = false;
            this.smtpPortEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smtpPortEd.Location = new System.Drawing.Point(142, 105);
            this.smtpPortEd.Margin = new System.Windows.Forms.Padding(4);
            this.smtpPortEd.Name = "smtpPortEd";
            this.smtpPortEd.Size = new System.Drawing.Size(50, 24);
            this.smtpPortEd.TabIndex = 5;
            this.smtpPortEd.Text = "25";
            // 
            // smtpServerLbl
            // 
            this.smtpServerLbl.AutoSize = true;
            this.smtpServerLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.smtpServerLbl.Location = new System.Drawing.Point(34, 35);
            this.smtpServerLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.smtpServerLbl.Name = "smtpServerLbl";
            this.smtpServerLbl.Size = new System.Drawing.Size(100, 16);
            this.smtpServerLbl.TabIndex = 210;
            this.smtpServerLbl.Text = "Máy chủ SMTP";
            // 
            // smtpServerEd
            // 
            this.smtpServerEd.BeepOnError = true;
            this.smtpServerEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smtpServerEd.Location = new System.Drawing.Point(142, 30);
            this.smtpServerEd.Margin = new System.Windows.Forms.Padding(4);
            this.smtpServerEd.Name = "smtpServerEd";
            this.smtpServerEd.Size = new System.Drawing.Size(221, 24);
            this.smtpServerEd.TabIndex = 1;
            this.smtpServerEd.Text = "127.0.0.1";
            // 
            // uploadPg
            // 
            this.uploadPg.Controls.Add(this.fsCopyModeGb);
            this.uploadPg.Controls.Add(this.httpProtoGb);
            this.uploadPg.Controls.Add(this.uploadModeCb);
            this.uploadPg.Controls.Add(this.label19);
            this.uploadPg.Location = new System.Drawing.Point(4, 25);
            this.uploadPg.Name = "uploadPg";
            this.uploadPg.Padding = new System.Windows.Forms.Padding(3);
            this.uploadPg.Size = new System.Drawing.Size(411, 259);
            this.uploadPg.TabIndex = 6;
            this.uploadPg.Text = "Tải dữ liệu";
            this.uploadPg.UseVisualStyleBackColor = true;
            // 
            // fsCopyModeGb
            // 
            this.fsCopyModeGb.Controls.Add(this.uploadDataDirNoteLbl);
            this.fsCopyModeGb.Controls.Add(this.uploadDataDirLbl);
            this.fsCopyModeGb.Controls.Add(this.uploadDataDirEd);
            this.fsCopyModeGb.Location = new System.Drawing.Point(9, 184);
            this.fsCopyModeGb.Name = "fsCopyModeGb";
            this.fsCopyModeGb.Size = new System.Drawing.Size(398, 69);
            this.fsCopyModeGb.TabIndex = 72;
            this.fsCopyModeGb.TabStop = false;
            this.fsCopyModeGb.Text = " Hệ thống tệp";
            // 
            // uploadDataDirNoteLbl
            // 
            this.uploadDataDirNoteLbl.AutoSize = true;
            this.uploadDataDirNoteLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadDataDirNoteLbl.ForeColor = System.Drawing.Color.Navy;
            this.uploadDataDirNoteLbl.Location = new System.Drawing.Point(94, 46);
            this.uploadDataDirNoteLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uploadDataDirNoteLbl.Name = "uploadDataDirNoteLbl";
            this.uploadDataDirNoteLbl.Size = new System.Drawing.Size(71, 15);
            this.uploadDataDirNoteLbl.TabIndex = 63;
            this.uploadDataDirNoteLbl.Text = "VD :  z:/data";
            // 
            // uploadDataDirLbl
            // 
            this.uploadDataDirLbl.AutoSize = true;
            this.uploadDataDirLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadDataDirLbl.Location = new System.Drawing.Point(22, 24);
            this.uploadDataDirLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uploadDataDirLbl.Name = "uploadDataDirLbl";
            this.uploadDataDirLbl.Size = new System.Drawing.Size(66, 16);
            this.uploadDataDirLbl.TabIndex = 58;
            this.uploadDataDirLbl.Text = "Thư mục ";
            // 
            // uploadDataDirEd
            // 
            this.uploadDataDirEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadDataDirEd.Location = new System.Drawing.Point(94, 22);
            this.uploadDataDirEd.Margin = new System.Windows.Forms.Padding(4);
            this.uploadDataDirEd.Name = "uploadDataDirEd";
            this.uploadDataDirEd.Size = new System.Drawing.Size(291, 22);
            this.uploadDataDirEd.TabIndex = 1;
            // 
            // httpProtoGb
            // 
            this.httpProtoGb.Controls.Add(this.uploadScriptFileLbl);
            this.httpProtoGb.Controls.Add(this.uploadScriptFileEd);
            this.httpProtoGb.Controls.Add(this.showPassChk);
            this.httpProtoGb.Controls.Add(this.uploadUrlNoteLbl);
            this.httpProtoGb.Controls.Add(this.label32);
            this.httpProtoGb.Controls.Add(this.uploadPwdEd);
            this.httpProtoGb.Controls.Add(this.label21);
            this.httpProtoGb.Controls.Add(this.uploadAccountEd);
            this.httpProtoGb.Controls.Add(this.uploadUrlLbl);
            this.httpProtoGb.Controls.Add(this.uploadUrlEd);
            this.httpProtoGb.Location = new System.Drawing.Point(9, 32);
            this.httpProtoGb.Name = "httpProtoGb";
            this.httpProtoGb.Size = new System.Drawing.Size(398, 149);
            this.httpProtoGb.TabIndex = 71;
            this.httpProtoGb.TabStop = false;
            this.httpProtoGb.Text = " HTTP ";
            // 
            // uploadScriptFileLbl
            // 
            this.uploadScriptFileLbl.AllowDrop = true;
            this.uploadScriptFileLbl.AutoSize = true;
            this.uploadScriptFileLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadScriptFileLbl.Location = new System.Drawing.Point(18, 64);
            this.uploadScriptFileLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uploadScriptFileLbl.Name = "uploadScriptFileLbl";
            this.uploadScriptFileLbl.Size = new System.Drawing.Size(72, 16);
            this.uploadScriptFileLbl.TabIndex = 65;
            this.uploadScriptFileLbl.Text = "Tệp script";
            // 
            // uploadScriptFileEd
            // 
            this.uploadScriptFileEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadScriptFileEd.Location = new System.Drawing.Point(94, 63);
            this.uploadScriptFileEd.Margin = new System.Windows.Forms.Padding(4);
            this.uploadScriptFileEd.Name = "uploadScriptFileEd";
            this.uploadScriptFileEd.Size = new System.Drawing.Size(134, 22);
            this.uploadScriptFileEd.TabIndex = 2;
            // 
            // showPassChk
            // 
            this.showPassChk.AutoSize = true;
            this.showPassChk.Location = new System.Drawing.Point(231, 111);
            this.showPassChk.Name = "showPassChk";
            this.showPassChk.Size = new System.Drawing.Size(119, 20);
            this.showPassChk.TabIndex = 5;
            this.showPassChk.Text = "Hiện mật khẩu";
            this.showPassChk.UseVisualStyleBackColor = true;
            this.showPassChk.CheckedChanged += new System.EventHandler(this.showPassChk_CheckedChanged);
            // 
            // uploadUrlNoteLbl
            // 
            this.uploadUrlNoteLbl.AutoSize = true;
            this.uploadUrlNoteLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadUrlNoteLbl.ForeColor = System.Drawing.Color.Navy;
            this.uploadUrlNoteLbl.Location = new System.Drawing.Point(95, 45);
            this.uploadUrlNoteLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uploadUrlNoteLbl.Name = "uploadUrlNoteLbl";
            this.uploadUrlNoteLbl.Size = new System.Drawing.Size(234, 16);
            this.uploadUrlNoteLbl.TabIndex = 63;
            this.uploadUrlNoteLbl.Text = "VD :  http://server.domain.name/folder";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(18, 113);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(68, 16);
            this.label32.TabIndex = 62;
            this.label32.Text = "Mật khẩu";
            // 
            // uploadPwdEd
            // 
            this.uploadPwdEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadPwdEd.Location = new System.Drawing.Point(94, 109);
            this.uploadPwdEd.Margin = new System.Windows.Forms.Padding(4);
            this.uploadPwdEd.Name = "uploadPwdEd";
            this.uploadPwdEd.PasswordChar = '*';
            this.uploadPwdEd.Size = new System.Drawing.Size(130, 22);
            this.uploadPwdEd.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(18, 90);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 16);
            this.label21.TabIndex = 60;
            this.label21.Text = "Tài khỏan";
            // 
            // uploadAccountEd
            // 
            this.uploadAccountEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadAccountEd.Location = new System.Drawing.Point(94, 86);
            this.uploadAccountEd.Margin = new System.Windows.Forms.Padding(4);
            this.uploadAccountEd.Name = "uploadAccountEd";
            this.uploadAccountEd.Size = new System.Drawing.Size(130, 22);
            this.uploadAccountEd.TabIndex = 3;
            // 
            // uploadUrlLbl
            // 
            this.uploadUrlLbl.AllowDrop = true;
            this.uploadUrlLbl.AutoSize = true;
            this.uploadUrlLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadUrlLbl.Location = new System.Drawing.Point(18, 22);
            this.uploadUrlLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uploadUrlLbl.Name = "uploadUrlLbl";
            this.uploadUrlLbl.Size = new System.Drawing.Size(51, 16);
            this.uploadUrlLbl.TabIndex = 58;
            this.uploadUrlLbl.Text = "Địa chỉ";
            // 
            // uploadUrlEd
            // 
            this.uploadUrlEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadUrlEd.Location = new System.Drawing.Point(94, 21);
            this.uploadUrlEd.Margin = new System.Windows.Forms.Padding(4);
            this.uploadUrlEd.Name = "uploadUrlEd";
            this.uploadUrlEd.Size = new System.Drawing.Size(291, 22);
            this.uploadUrlEd.TabIndex = 1;
            // 
            // uploadModeCb
            // 
            this.uploadModeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uploadModeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadModeCb.FormattingEnabled = true;
            this.uploadModeCb.Location = new System.Drawing.Point(146, 5);
            this.uploadModeCb.myValue = common.uploadMethod.None;
            this.uploadModeCb.Name = "uploadModeCb";
            this.uploadModeCb.Size = new System.Drawing.Size(257, 24);
            this.uploadModeCb.TabIndex = 70;
            this.uploadModeCb.SelectedIndexChanged += new System.EventHandler(this.copyModeCb_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(19, 9);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(117, 16);
            this.label19.TabIndex = 69;
            this.label19.Text = "Giao thức kết nối";
            // 
            // otherPg
            // 
            this.otherPg.Controls.Add(this.label2);
            this.otherPg.Controls.Add(this.dataStartDateEd);
            this.otherPg.Controls.Add(this.dateLbl);
            this.otherPg.Controls.Add(this.currencyLbl);
            this.otherPg.Controls.Add(this.currencyCb);
            this.otherPg.Controls.Add(this.defauCompanyCodeEd);
            this.otherPg.Location = new System.Drawing.Point(4, 22);
            this.otherPg.Name = "otherPg";
            this.otherPg.Padding = new System.Windows.Forms.Padding(3);
            this.otherPg.Size = new System.Drawing.Size(411, 262);
            this.otherPg.TabIndex = 2;
            this.otherPg.Text = "Khác";
            this.otherPg.UseVisualStyleBackColor = true;
            this.otherPg.Click += new System.EventHandler(this.otherPg_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(83, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 218;
            this.label2.Text = "CT mặc định";
            // 
            // dataStartDateEd
            // 
            this.dataStartDateEd.BackColor = System.Drawing.Color.White;
            this.dataStartDateEd.BeepOnError = true;
            this.dataStartDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.dataStartDateEd.ForeColor = System.Drawing.Color.Black;
            this.dataStartDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dataStartDateEd.Location = new System.Drawing.Point(188, 38);
            this.dataStartDateEd.Mask = "00/00/0000";
            this.dataStartDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.dataStartDateEd.Name = "dataStartDateEd";
            this.dataStartDateEd.Size = new System.Drawing.Size(81, 24);
            this.dataStartDateEd.TabIndex = 1;
            this.dataStartDateEd.Text = "01010001";
            this.dataStartDateEd.ValidatingType = typeof(System.DateTime);
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.dateLbl.Location = new System.Drawing.Point(83, 40);
            this.dateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(98, 16);
            this.dateLbl.TabIndex = 215;
            this.dateLbl.Text = "Ngày bắt đầu ";
            // 
            // currencyLbl
            // 
            this.currencyLbl.AutoSize = true;
            this.currencyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.currencyLbl.Location = new System.Drawing.Point(83, 76);
            this.currencyLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currencyLbl.Name = "currencyLbl";
            this.currencyLbl.Size = new System.Drawing.Size(101, 16);
            this.currencyLbl.TabIndex = 211;
            this.currencyLbl.Text = "Lọai tiền chính";
            // 
            // currencyCb
            // 
            this.currencyCb.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.currencyCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currencyCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.currencyCb.Location = new System.Drawing.Point(188, 70);
            this.currencyCb.myValue = "";
            this.currencyCb.Name = "currencyCb";
            this.currencyCb.Size = new System.Drawing.Size(81, 26);
            this.currencyCb.TabIndex = 2;
            // 
            // defauCompanyCodeEd
            // 
            this.defauCompanyCodeEd.BeepOnError = true;
            this.defauCompanyCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.defauCompanyCodeEd.Location = new System.Drawing.Point(188, 104);
            this.defauCompanyCodeEd.Margin = new System.Windows.Forms.Padding(4);
            this.defauCompanyCodeEd.Name = "defauCompanyCodeEd";
            this.defauCompanyCodeEd.Size = new System.Drawing.Size(42, 24);
            this.defauCompanyCodeEd.TabIndex = 4;
            this.myToolTip.SetToolTip(this.defauCompanyCodeEd, "Giá trị mặc định nếu không nhập Công ty");
            // 
            // reportPg
            // 
            this.reportPg.Controls.Add(this.repoSignerTitle_whManagerEd);
            this.reportPg.Controls.Add(this.repoSignerTitle_whManagerLbl);
            this.reportPg.Controls.Add(this.repoSignerTitle_CashierEd);
            this.reportPg.Controls.Add(this.repoSignerTitle_CashierLbl);
            this.reportPg.Controls.Add(this.repoSignerTitle_CreatorEd);
            this.reportPg.Controls.Add(this.repoSignerTitle_CreatorLbl);
            this.reportPg.Controls.Add(this.repoSignerTitle_ChiefAcctEd);
            this.reportPg.Controls.Add(this.repoSignerTitle_ChiefAcctLbl);
            this.reportPg.Controls.Add(this.repoSignerTitle_DirectorEd);
            this.reportPg.Controls.Add(this.repoSignerTitle_DirectorLbl);
            this.reportPg.Location = new System.Drawing.Point(4, 25);
            this.reportPg.Name = "reportPg";
            this.reportPg.Padding = new System.Windows.Forms.Padding(3);
            this.reportPg.Size = new System.Drawing.Size(412, 325);
            this.reportPg.TabIndex = 2;
            this.reportPg.Text = "Báo cáo";
            this.reportPg.UseVisualStyleBackColor = true;
            // 
            // repoSignerTitle_whManagerEd
            // 
            this.repoSignerTitle_whManagerEd.BeepOnError = true;
            this.repoSignerTitle_whManagerEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.repoSignerTitle_whManagerEd.Location = new System.Drawing.Point(148, 145);
            this.repoSignerTitle_whManagerEd.Margin = new System.Windows.Forms.Padding(4);
            this.repoSignerTitle_whManagerEd.Name = "repoSignerTitle_whManagerEd";
            this.repoSignerTitle_whManagerEd.Size = new System.Drawing.Size(188, 24);
            this.repoSignerTitle_whManagerEd.TabIndex = 4;
            this.repoSignerTitle_whManagerEd.Text = "Thủ kho";
            // 
            // repoSignerTitle_whManagerLbl
            // 
            this.repoSignerTitle_whManagerLbl.AutoSize = true;
            this.repoSignerTitle_whManagerLbl.Location = new System.Drawing.Point(61, 151);
            this.repoSignerTitle_whManagerLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.repoSignerTitle_whManagerLbl.Name = "repoSignerTitle_whManagerLbl";
            this.repoSignerTitle_whManagerLbl.Size = new System.Drawing.Size(58, 16);
            this.repoSignerTitle_whManagerLbl.TabIndex = 218;
            this.repoSignerTitle_whManagerLbl.Text = "Thủ kho";
            // 
            // repoSignerTitle_CashierEd
            // 
            this.repoSignerTitle_CashierEd.BeepOnError = true;
            this.repoSignerTitle_CashierEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.repoSignerTitle_CashierEd.Location = new System.Drawing.Point(148, 115);
            this.repoSignerTitle_CashierEd.Margin = new System.Windows.Forms.Padding(4);
            this.repoSignerTitle_CashierEd.Name = "repoSignerTitle_CashierEd";
            this.repoSignerTitle_CashierEd.Size = new System.Drawing.Size(188, 24);
            this.repoSignerTitle_CashierEd.TabIndex = 3;
            this.repoSignerTitle_CashierEd.Text = "Thủ quỹ";
            // 
            // repoSignerTitle_CashierLbl
            // 
            this.repoSignerTitle_CashierLbl.AutoSize = true;
            this.repoSignerTitle_CashierLbl.Location = new System.Drawing.Point(61, 119);
            this.repoSignerTitle_CashierLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.repoSignerTitle_CashierLbl.Name = "repoSignerTitle_CashierLbl";
            this.repoSignerTitle_CashierLbl.Size = new System.Drawing.Size(59, 16);
            this.repoSignerTitle_CashierLbl.TabIndex = 216;
            this.repoSignerTitle_CashierLbl.Text = "Thủ quỹ";
            // 
            // repoSignerTitle_CreatorEd
            // 
            this.repoSignerTitle_CreatorEd.BeepOnError = true;
            this.repoSignerTitle_CreatorEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.repoSignerTitle_CreatorEd.Location = new System.Drawing.Point(148, 175);
            this.repoSignerTitle_CreatorEd.Margin = new System.Windows.Forms.Padding(4);
            this.repoSignerTitle_CreatorEd.Name = "repoSignerTitle_CreatorEd";
            this.repoSignerTitle_CreatorEd.Size = new System.Drawing.Size(188, 24);
            this.repoSignerTitle_CreatorEd.TabIndex = 5;
            this.repoSignerTitle_CreatorEd.Text = "Lập biểu";
            // 
            // repoSignerTitle_CreatorLbl
            // 
            this.repoSignerTitle_CreatorLbl.AutoSize = true;
            this.repoSignerTitle_CreatorLbl.Location = new System.Drawing.Point(61, 179);
            this.repoSignerTitle_CreatorLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.repoSignerTitle_CreatorLbl.Name = "repoSignerTitle_CreatorLbl";
            this.repoSignerTitle_CreatorLbl.Size = new System.Drawing.Size(62, 16);
            this.repoSignerTitle_CreatorLbl.TabIndex = 214;
            this.repoSignerTitle_CreatorLbl.Text = "Lập biểu";
            // 
            // repoSignerTitle_ChiefAcctEd
            // 
            this.repoSignerTitle_ChiefAcctEd.BeepOnError = true;
            this.repoSignerTitle_ChiefAcctEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.repoSignerTitle_ChiefAcctEd.Location = new System.Drawing.Point(148, 85);
            this.repoSignerTitle_ChiefAcctEd.Margin = new System.Windows.Forms.Padding(4);
            this.repoSignerTitle_ChiefAcctEd.Name = "repoSignerTitle_ChiefAcctEd";
            this.repoSignerTitle_ChiefAcctEd.Size = new System.Drawing.Size(188, 24);
            this.repoSignerTitle_ChiefAcctEd.TabIndex = 2;
            this.repoSignerTitle_ChiefAcctEd.Text = "Kế tóan trưởng";
            // 
            // repoSignerTitle_ChiefAcctLbl
            // 
            this.repoSignerTitle_ChiefAcctLbl.AutoSize = true;
            this.repoSignerTitle_ChiefAcctLbl.Location = new System.Drawing.Point(61, 89);
            this.repoSignerTitle_ChiefAcctLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.repoSignerTitle_ChiefAcctLbl.Name = "repoSignerTitle_ChiefAcctLbl";
            this.repoSignerTitle_ChiefAcctLbl.Size = new System.Drawing.Size(73, 16);
            this.repoSignerTitle_ChiefAcctLbl.TabIndex = 212;
            this.repoSignerTitle_ChiefAcctLbl.Text = "KT Trưởng";
            // 
            // repoSignerTitle_DirectorEd
            // 
            this.repoSignerTitle_DirectorEd.BeepOnError = true;
            this.repoSignerTitle_DirectorEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.repoSignerTitle_DirectorEd.Location = new System.Drawing.Point(148, 55);
            this.repoSignerTitle_DirectorEd.Margin = new System.Windows.Forms.Padding(4);
            this.repoSignerTitle_DirectorEd.Name = "repoSignerTitle_DirectorEd";
            this.repoSignerTitle_DirectorEd.Size = new System.Drawing.Size(188, 24);
            this.repoSignerTitle_DirectorEd.TabIndex = 1;
            this.repoSignerTitle_DirectorEd.Text = "Giám đốc";
            this.myToolTip.SetToolTip(this.repoSignerTitle_DirectorEd, "TK cho bảng CDKT ");
            // 
            // repoSignerTitle_DirectorLbl
            // 
            this.repoSignerTitle_DirectorLbl.AutoSize = true;
            this.repoSignerTitle_DirectorLbl.Location = new System.Drawing.Point(61, 56);
            this.repoSignerTitle_DirectorLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.repoSignerTitle_DirectorLbl.Name = "repoSignerTitle_DirectorLbl";
            this.repoSignerTitle_DirectorLbl.Size = new System.Drawing.Size(79, 16);
            this.repoSignerTitle_DirectorLbl.TabIndex = 210;
            this.repoSignerTitle_DirectorLbl.Text = "Ký báo cáo";
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.Location = new System.Drawing.Point(324, 320);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(67, 31);
            this.closeBtn.TabIndex = 11;
            this.closeBtn.Text = "Đóng";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = global::setup.Properties.Resources.save;
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.Location = new System.Drawing.Point(270, 320);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(54, 31);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "&Lưu";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // sysOptionsMenuItem
            // 
            this.ClientSize = new System.Drawing.Size(420, 383);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.mainTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "sysOptionsMenuItem";
            this.Text = "Thiet lap thong so";
            this.Load += new System.EventHandler(this.paraSetup_Load);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.mainTab, 0);
            this.Controls.SetChildIndex(this.saveBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.mainTab.ResumeLayout(false);
            this.setupPg.ResumeLayout(false);
            this.systemTab.ResumeLayout(false);
            this.generalPg.ResumeLayout(false);
            this.generalPg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordMinLenEd)).EndInit();
            this.autoKeyPg.ResumeLayout(false);
            this.autoKeyPg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sysAutoEditKeySizeEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeOutAutoKeyEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysAutoDataKeySizeEd)).EndInit();
            this.formatPg.ResumeLayout(false);
            this.formatPg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentPrecisionEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyPrecisionEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foreignAmtPrecisionEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localAmtPrecisionEd)).EndInit();
            this.emailPg.ResumeLayout(false);
            this.emailPg.PerformLayout();
            this.uploadPg.ResumeLayout(false);
            this.uploadPg.PerformLayout();
            this.fsCopyModeGb.ResumeLayout(false);
            this.fsCopyModeGb.PerformLayout();
            this.httpProtoGb.ResumeLayout(false);
            this.httpProtoGb.PerformLayout();
            this.otherPg.ResumeLayout(false);
            this.otherPg.PerformLayout();
            this.reportPg.ResumeLayout(false);
            this.reportPg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button closeBtn;
        protected System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TabPage setupPg;
        private System.Windows.Forms.TabPage autoKeyPg;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label timeOutAutoKeyLbl1;
        protected System.Windows.Forms.Label timeOutAutoKeyLbl;
        protected System.Windows.Forms.Label dataKeyPrefixLbl;
        protected common.controls.baseMaskedTextBox sysDataKeyPrefixEd;
        private System.Windows.Forms.TabPage generalPg;
        protected System.Windows.Forms.Label cultureCode;
        protected common.controls.baseComboBox cultureCodeEd;
        protected System.Windows.Forms.Label pwdMinLenLbl1;
        protected System.Windows.Forms.Label pwdMinLenLbl;
        private System.Windows.Forms.TabPage otherPg;
        protected common.controls.baseDate dataStartDateEd;
        protected System.Windows.Forms.Label dateLbl;
        protected common.controls.baseMaskedTextBox defauCompanyCodeEd;
        protected System.Windows.Forms.Label currencyLbl;
        protected baseClass.controls.cbCurrency currencyCb;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage formatPg;
        protected System.Windows.Forms.Label percentMaskLbl;
        protected common.controls.baseMaskedTextBox percentMaskEd;
        protected System.Windows.Forms.Label qtyMaskLbl;
        protected common.controls.baseMaskedTextBox qtyMaskEd;
        protected System.Windows.Forms.Label foreignAmtMaskLbl;
        protected common.controls.baseMaskedTextBox foreignAmtMaskEd;
        protected System.Windows.Forms.Label localAmtMaskLbl;
        protected common.controls.baseMaskedTextBox localAmtMaskEd;
        protected System.Windows.Forms.TabControl mainTab;
        protected System.Windows.Forms.TabControl systemTab;
        protected System.Windows.Forms.NumericUpDown timeOutAutoKeyEd;
        protected System.Windows.Forms.NumericUpDown sysAutoDataKeySizeEd;
        protected System.Windows.Forms.CheckBox useStrongPassChk;
        protected System.Windows.Forms.NumericUpDown passwordMinLenEd;
        protected System.Windows.Forms.CheckBox debugModeChk;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.NumericUpDown sysAutoEditKeySizeEd;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.NumericUpDown localAmtPrecisionEd;
        protected System.Windows.Forms.NumericUpDown qtyPrecisionEd;
        protected System.Windows.Forms.NumericUpDown foreignAmtPrecisionEd;
        protected System.Windows.Forms.NumericUpDown percentPrecisionEd;
        protected System.Windows.Forms.Label autoVoucheNoFormatLbl;
        private System.Windows.Forms.TabPage emailPg;
        protected System.Windows.Forms.Label smtpServerLbl;
        protected common.controls.baseMaskedTextBox smtpServerEd;
        protected System.Windows.Forms.CheckBox smtpSSLChk;
        protected common.controls.baseMaskedTextBox smtpAuthPasswordEd;
        protected System.Windows.Forms.Label smtpAuthPasswordLbl;
        protected common.controls.baseMaskedTextBox smtpAuthAccountEd;
        protected System.Windows.Forms.Label label9;
        protected common.controls.baseMaskedTextBox smtpPortEd;
        protected System.Windows.Forms.Label smtpPortLbl;
        private System.Windows.Forms.TabPage reportPg;
        protected common.controls.baseMaskedTextBox repoSignerTitle_CreatorEd;
        protected System.Windows.Forms.Label repoSignerTitle_CreatorLbl;
        protected common.controls.baseMaskedTextBox repoSignerTitle_ChiefAcctEd;
        protected System.Windows.Forms.Label repoSignerTitle_ChiefAcctLbl;
        protected common.controls.baseMaskedTextBox repoSignerTitle_DirectorEd;
        protected System.Windows.Forms.Label repoSignerTitle_DirectorLbl;
        protected common.controls.baseMaskedTextBox repoSignerTitle_whManagerEd;
        protected System.Windows.Forms.Label repoSignerTitle_whManagerLbl;
        protected common.controls.baseMaskedTextBox repoSignerTitle_CashierEd;
        protected System.Windows.Forms.Label repoSignerTitle_CashierLbl;
        private System.Windows.Forms.TabPage uploadPg;
        private System.Windows.Forms.GroupBox fsCopyModeGb;
        private System.Windows.Forms.Label uploadDataDirNoteLbl;
        private System.Windows.Forms.Label uploadDataDirLbl;
        private common.controls.baseTextBox uploadDataDirEd;
        private System.Windows.Forms.GroupBox httpProtoGb;
        private System.Windows.Forms.Label uploadUrlNoteLbl;
        private System.Windows.Forms.Label label32;
        private common.controls.baseTextBox uploadPwdEd;
        private System.Windows.Forms.Label label21;
        private common.controls.baseTextBox uploadAccountEd;
        private System.Windows.Forms.Label uploadUrlLbl;
        private common.controls.baseTextBox uploadUrlEd;
        private common.controls.cbUploadMethod uploadModeCb;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox showPassChk;
        private System.Windows.Forms.Label uploadScriptFileLbl;
        private common.controls.baseTextBox uploadScriptFileEd;
    }
}
