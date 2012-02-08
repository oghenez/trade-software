namespace admin.forms
{
    partial class sysOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sysOptions));
            this.mainTab = new System.Windows.Forms.TabControl();
            this.setupPg = new System.Windows.Forms.TabPage();
            this.systemTab = new System.Windows.Forms.TabControl();
            this.generalPg = new System.Windows.Forms.TabPage();
            this.useStrongPassChk = new common.controls.baseCheckBox();
            this.cultureCode = new common.controls.baseLabel();
            this.cultureCodeEd = new common.controls.baseComboBox();
            this.pwdMinLenLbl1 = new common.controls.baseLabel();
            this.passwordMinLenEd = new common.controls.baseNumericUpDown();
            this.pwdMinLenLbl = new common.controls.baseLabel();
            this.debugModeChk = new common.controls.baseCheckBox();
            this.autoKeyPg = new System.Windows.Forms.TabPage();
            this.autoVoucheNoFormatLbl = new common.controls.baseLabel();
            this.label7 = new common.controls.baseLabel();
            this.label6 = new common.controls.baseLabel();
            this.label5 = new common.controls.baseLabel();
            this.sysAutoEditKeySizeEd = new common.controls.baseNumericUpDown();
            this.label1 = new common.controls.baseLabel();
            this.timeOutAutoKeyLbl1 = new common.controls.baseLabel();
            this.timeOutAutoKeyLbl = new common.controls.baseLabel();
            this.timeOutAutoKeyEd = new common.controls.baseNumericUpDown();
            this.sysAutoDataKeySizeEd = new common.controls.baseNumericUpDown();
            this.dataKeyPrefixLbl = new common.controls.baseLabel();
            this.sysDataKeyPrefixEd = new common.controls.baseMaskedTextBox();
            this.formatPg = new System.Windows.Forms.TabPage();
            this.percentPrecisionEd = new common.controls.baseNumericUpDown();
            this.qtyPrecisionEd = new common.controls.baseNumericUpDown();
            this.foreignAmtPrecisionEd = new common.controls.baseNumericUpDown();
            this.localAmtPrecisionEd = new common.controls.baseNumericUpDown();
            this.percentMaskLbl = new common.controls.baseLabel();
            this.qtyMaskLbl = new common.controls.baseLabel();
            this.foreignAmtMaskLbl = new common.controls.baseLabel();
            this.localAmtMaskLbl = new common.controls.baseLabel();
            this.percentMaskEd = new common.controls.baseMaskedTextBox();
            this.qtyMaskEd = new common.controls.baseMaskedTextBox();
            this.foreignAmtMaskEd = new common.controls.baseMaskedTextBox();
            this.localAmtMaskEd = new common.controls.baseMaskedTextBox();
            this.emailPg = new System.Windows.Forms.TabPage();
            this.smtpPortLbl = new common.controls.baseLabel();
            this.smtpAuthPasswordEd = new common.controls.baseMaskedTextBox();
            this.smtpAuthPasswordLbl = new common.controls.baseLabel();
            this.smtpAuthAccountEd = new common.controls.baseMaskedTextBox();
            this.label9 = new common.controls.baseLabel();
            this.smtpSSLChk = new common.controls.baseCheckBox();
            this.smtpPortEd = new common.controls.baseMaskedTextBox();
            this.smtpServerLbl = new common.controls.baseLabel();
            this.smtpServerEd = new common.controls.baseMaskedTextBox();
            this.otherPg = new System.Windows.Forms.TabPage();
            this.dataStartDateEd = new common.controls.baseDate();
            this.dateLbl = new common.controls.baseLabel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.screeningGb = new System.Windows.Forms.GroupBox();
            this.screenTimeRangeCb = new baseClass.controls.cbTimeRange();
            this.screenTimeScaleCb = new baseClass.controls.cbTimeScale();
            this.screenTimeRangeLbl = new baseClass.controls.baseLabel();
            this.screenTimeScaleLbl = new baseClass.controls.baseLabel();
            this.refreshRateLbl = new baseClass.controls.baseLabel();
            this.secondLbl = new baseClass.controls.baseLabel();
            this.refreshRateEd = new common.controls.numberTextBox();
            this.defaultGb = new System.Windows.Forms.GroupBox();
            this.defaultTimeRangeCb = new baseClass.controls.cbTimeRange();
            this.defaultTimeScaleCb = new baseClass.controls.cbTimeScale();
            this.defaultTimeRangeLbl = new baseClass.controls.baseLabel();
            this.defaultTimeScaleLbl = new baseClass.controls.baseLabel();
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
            this.otherPg.SuspendLayout();
            this.screeningGb.SuspendLayout();
            this.defaultGb.SuspendLayout();
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
            this.passwordMinLenEd.myValue = new decimal(new int[] {
            5,
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
            this.autoKeyPg.Location = new System.Drawing.Point(4, 22);
            this.autoKeyPg.Name = "autoKeyPg";
            this.autoKeyPg.Padding = new System.Windows.Forms.Padding(3);
            this.autoKeyPg.Size = new System.Drawing.Size(411, 262);
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
            this.sysAutoEditKeySizeEd.myValue = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.sysAutoEditKeySizeEd.Name = "sysAutoEditKeySizeEd";
            this.sysAutoEditKeySizeEd.Size = new System.Drawing.Size(53, 24);
            this.sysAutoEditKeySizeEd.TabIndex = 3;
            this.sysAutoEditKeySizeEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.timeOutAutoKeyEd.myValue = new decimal(new int[] {
            120,
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
            this.sysAutoDataKeySizeEd.myValue = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.sysAutoDataKeySizeEd.Name = "sysAutoDataKeySizeEd";
            this.sysAutoDataKeySizeEd.Size = new System.Drawing.Size(53, 24);
            this.sysAutoDataKeySizeEd.TabIndex = 2;
            this.sysAutoDataKeySizeEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.percentPrecisionEd.myValue = new decimal(new int[] {
            0,
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
            this.qtyPrecisionEd.myValue = new decimal(new int[] {
            2,
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
            this.foreignAmtPrecisionEd.myValue = new decimal(new int[] {
            2,
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
            this.localAmtPrecisionEd.myValue = new decimal(new int[] {
            0,
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
            // otherPg
            // 
            this.otherPg.Controls.Add(this.dataStartDateEd);
            this.otherPg.Controls.Add(this.dateLbl);
            this.otherPg.Location = new System.Drawing.Point(4, 22);
            this.otherPg.Name = "otherPg";
            this.otherPg.Padding = new System.Windows.Forms.Padding(3);
            this.otherPg.Size = new System.Drawing.Size(411, 262);
            this.otherPg.TabIndex = 2;
            this.otherPg.Text = "Khác";
            this.otherPg.UseVisualStyleBackColor = true;
            this.otherPg.Click += new System.EventHandler(this.otherPg_Click);
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
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.Location = new System.Drawing.Point(318, 320);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(73, 29);
            this.closeBtn.TabIndex = 11;
            this.closeBtn.Text = "Đóng";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = global::admin.Properties.Resources.save;
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.Location = new System.Drawing.Point(245, 320);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(73, 29);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "&Lưu";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // screeningGb
            // 
            this.screeningGb.Controls.Add(this.screenTimeRangeCb);
            this.screeningGb.Controls.Add(this.screenTimeScaleCb);
            this.screeningGb.Controls.Add(this.screenTimeRangeLbl);
            this.screeningGb.Controls.Add(this.screenTimeScaleLbl);
            this.screeningGb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screeningGb.Location = new System.Drawing.Point(24, 140);
            this.screeningGb.Name = "screeningGb";
            this.screeningGb.Size = new System.Drawing.Size(375, 76);
            this.screeningGb.TabIndex = 3;
            this.screeningGb.TabStop = false;
            this.screeningGb.Text = "Screening";
            // 
            // screenTimeRangeCb
            // 
            this.screenTimeRangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screenTimeRangeCb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenTimeRangeCb.FormattingEnabled = true;
            this.screenTimeRangeCb.Location = new System.Drawing.Point(125, 17);
            this.screenTimeRangeCb.myValue = commonClass.AppTypes.TimeRanges.None;
            this.screenTimeRangeCb.Name = "screenTimeRangeCb";
            this.screenTimeRangeCb.SelectedValue = ((byte)(0));
            this.screenTimeRangeCb.Size = new System.Drawing.Size(196, 24);
            this.screenTimeRangeCb.TabIndex = 1;
            // 
            // screenTimeScaleCb
            // 
            this.screenTimeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screenTimeScaleCb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenTimeScaleCb.FormattingEnabled = true;
            this.screenTimeScaleCb.Location = new System.Drawing.Point(125, 44);
            this.screenTimeScaleCb.Name = "screenTimeScaleCb";
            this.screenTimeScaleCb.SelectedValue = "RT";
            this.screenTimeScaleCb.Size = new System.Drawing.Size(196, 24);
            this.screenTimeScaleCb.TabIndex = 2;
            // 
            // screenTimeRangeLbl
            // 
            this.screenTimeRangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenTimeRangeLbl.Location = new System.Drawing.Point(11, 22);
            this.screenTimeRangeLbl.Name = "screenTimeRangeLbl";
            this.screenTimeRangeLbl.Size = new System.Drawing.Size(108, 16);
            this.screenTimeRangeLbl.TabIndex = 17;
            this.screenTimeRangeLbl.Text = "Time range";
            this.screenTimeRangeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // screenTimeScaleLbl
            // 
            this.screenTimeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenTimeScaleLbl.Location = new System.Drawing.Point(11, 46);
            this.screenTimeScaleLbl.Name = "screenTimeScaleLbl";
            this.screenTimeScaleLbl.Size = new System.Drawing.Size(108, 16);
            this.screenTimeScaleLbl.TabIndex = 16;
            this.screenTimeScaleLbl.Text = "Time scale";
            this.screenTimeScaleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // refreshRateLbl
            // 
            this.refreshRateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshRateLbl.Location = new System.Drawing.Point(23, 22);
            this.refreshRateLbl.Name = "refreshRateLbl";
            this.refreshRateLbl.Size = new System.Drawing.Size(116, 16);
            this.refreshRateLbl.TabIndex = 12;
            this.refreshRateLbl.Text = "Refresh rate";
            this.refreshRateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // secondLbl
            // 
            this.secondLbl.AutoSize = true;
            this.secondLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondLbl.Location = new System.Drawing.Point(208, 23);
            this.secondLbl.Name = "secondLbl";
            this.secondLbl.Size = new System.Drawing.Size(61, 16);
            this.secondLbl.TabIndex = 13;
            this.secondLbl.Text = "seconds";
            // 
            // refreshRateEd
            // 
            this.refreshRateEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshRateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.refreshRateEd.Location = new System.Drawing.Point(149, 18);
            this.refreshRateEd.myFormat = "###.##";
            this.refreshRateEd.Name = "refreshRateEd";
            this.refreshRateEd.Size = new System.Drawing.Size(53, 26);
            this.refreshRateEd.TabIndex = 1;
            this.refreshRateEd.Text = "1";
            this.refreshRateEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.refreshRateEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.refreshRateEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // defaultGb
            // 
            this.defaultGb.Controls.Add(this.defaultTimeRangeCb);
            this.defaultGb.Controls.Add(this.defaultTimeScaleCb);
            this.defaultGb.Controls.Add(this.defaultTimeRangeLbl);
            this.defaultGb.Controls.Add(this.defaultTimeScaleLbl);
            this.defaultGb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultGb.Location = new System.Drawing.Point(24, 56);
            this.defaultGb.Name = "defaultGb";
            this.defaultGb.Size = new System.Drawing.Size(377, 85);
            this.defaultGb.TabIndex = 2;
            this.defaultGb.TabStop = false;
            this.defaultGb.Text = "Default";
            // 
            // defaultTimeRangeCb
            // 
            this.defaultTimeRangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaultTimeRangeCb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultTimeRangeCb.FormattingEnabled = true;
            this.defaultTimeRangeCb.Location = new System.Drawing.Point(126, 21);
            this.defaultTimeRangeCb.myValue = commonClass.AppTypes.TimeRanges.None;
            this.defaultTimeRangeCb.Name = "defaultTimeRangeCb";
            this.defaultTimeRangeCb.SelectedValue = ((byte)(0));
            this.defaultTimeRangeCb.Size = new System.Drawing.Size(196, 24);
            this.defaultTimeRangeCb.TabIndex = 15;
            // 
            // defaultTimeScaleCb
            // 
            this.defaultTimeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaultTimeScaleCb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultTimeScaleCb.FormattingEnabled = true;
            this.defaultTimeScaleCb.Location = new System.Drawing.Point(126, 48);
            this.defaultTimeScaleCb.Name = "defaultTimeScaleCb";
            this.defaultTimeScaleCb.SelectedValue = "RT";
            this.defaultTimeScaleCb.Size = new System.Drawing.Size(196, 24);
            this.defaultTimeScaleCb.TabIndex = 2;
            // 
            // defaultTimeRangeLbl
            // 
            this.defaultTimeRangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultTimeRangeLbl.Location = new System.Drawing.Point(12, 24);
            this.defaultTimeRangeLbl.Name = "defaultTimeRangeLbl";
            this.defaultTimeRangeLbl.Size = new System.Drawing.Size(108, 16);
            this.defaultTimeRangeLbl.TabIndex = 17;
            this.defaultTimeRangeLbl.Text = "Time range";
            this.defaultTimeRangeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // defaultTimeScaleLbl
            // 
            this.defaultTimeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultTimeScaleLbl.Location = new System.Drawing.Point(12, 47);
            this.defaultTimeScaleLbl.Name = "defaultTimeScaleLbl";
            this.defaultTimeScaleLbl.Size = new System.Drawing.Size(108, 16);
            this.defaultTimeScaleLbl.TabIndex = 16;
            this.defaultTimeScaleLbl.Text = "Time scale";
            this.defaultTimeScaleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sysOptions2
            // 
            this.ClientSize = new System.Drawing.Size(420, 383);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.mainTab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "sysOptions2";
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
            this.otherPg.ResumeLayout(false);
            this.otherPg.PerformLayout();
            this.screeningGb.ResumeLayout(false);
            this.defaultGb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button closeBtn;
        protected System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TabPage setupPg;
        private System.Windows.Forms.TabPage autoKeyPg;
        protected common.controls.baseLabel label1;
        protected common.controls.baseLabel timeOutAutoKeyLbl1;
        protected common.controls.baseLabel timeOutAutoKeyLbl;
        protected common.controls.baseLabel dataKeyPrefixLbl;
        protected common.controls.baseMaskedTextBox sysDataKeyPrefixEd;
        private System.Windows.Forms.TabPage generalPg;
        protected common.controls.baseLabel cultureCode;
        protected common.controls.baseComboBox cultureCodeEd;
        protected common.controls.baseLabel pwdMinLenLbl1;
        protected common.controls.baseLabel pwdMinLenLbl;
        private System.Windows.Forms.TabPage otherPg;
        protected common.controls.baseDate dataStartDateEd;
        protected common.controls.baseLabel dateLbl;
        private System.Windows.Forms.TabPage formatPg;
        protected common.controls.baseLabel percentMaskLbl;
        protected common.controls.baseMaskedTextBox percentMaskEd;
        protected common.controls.baseLabel qtyMaskLbl;
        protected common.controls.baseMaskedTextBox qtyMaskEd;
        protected common.controls.baseLabel foreignAmtMaskLbl;
        protected common.controls.baseMaskedTextBox foreignAmtMaskEd;
        protected common.controls.baseLabel localAmtMaskLbl;
        protected common.controls.baseMaskedTextBox localAmtMaskEd;
        protected System.Windows.Forms.TabControl mainTab;
        protected System.Windows.Forms.TabControl systemTab;
        protected common.controls.baseNumericUpDown timeOutAutoKeyEd;
        protected common.controls.baseNumericUpDown sysAutoDataKeySizeEd;
        protected common.controls.baseCheckBox useStrongPassChk;
        protected common.controls.baseNumericUpDown passwordMinLenEd;
        protected common.controls.baseCheckBox debugModeChk;
        protected common.controls.baseLabel label5;
        protected common.controls.baseNumericUpDown sysAutoEditKeySizeEd;
        protected common.controls.baseLabel label7;
        protected common.controls.baseLabel label6;
        protected common.controls.baseNumericUpDown localAmtPrecisionEd;
        protected common.controls.baseNumericUpDown qtyPrecisionEd;
        protected common.controls.baseNumericUpDown foreignAmtPrecisionEd;
        protected common.controls.baseNumericUpDown percentPrecisionEd;
        protected common.controls.baseLabel autoVoucheNoFormatLbl;
        private System.Windows.Forms.TabPage emailPg;
        protected common.controls.baseLabel smtpServerLbl;
        protected common.controls.baseMaskedTextBox smtpServerEd;
        protected common.controls.baseCheckBox smtpSSLChk;
        protected common.controls.baseMaskedTextBox smtpAuthPasswordEd;
        protected common.controls.baseLabel smtpAuthPasswordLbl;
        protected common.controls.baseMaskedTextBox smtpAuthAccountEd;
        protected common.controls.baseLabel label9;
        protected common.controls.baseMaskedTextBox smtpPortEd;
        protected common.controls.baseLabel smtpPortLbl;
        private System.Windows.Forms.GroupBox screeningGb;
        private baseClass.controls.cbTimeRange screenTimeRangeCb;
        private baseClass.controls.cbTimeScale screenTimeScaleCb;
        private baseClass.controls.baseLabel screenTimeRangeLbl;
        private baseClass.controls.baseLabel screenTimeScaleLbl;
        private baseClass.controls.baseLabel refreshRateLbl;
        private baseClass.controls.baseLabel secondLbl;
        private common.controls.numberTextBox refreshRateEd;
        private System.Windows.Forms.GroupBox defaultGb;
        private baseClass.controls.cbTimeRange defaultTimeRangeCb;
        private baseClass.controls.cbTimeScale defaultTimeScaleCb;
        private baseClass.controls.baseLabel defaultTimeRangeLbl;
        private baseClass.controls.baseLabel defaultTimeScaleLbl;
    }
}
