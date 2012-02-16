namespace baseClass.forms
{
    partial class sysOptionGlobal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sysOptionGlobal));
            this.mainTab = new System.Windows.Forms.TabControl();
            this.systemPg = new System.Windows.Forms.TabPage();
            this.systemTab = new System.Windows.Forms.TabControl();
            this.generalPg = new System.Windows.Forms.TabPage();
            this.generalGb = new System.Windows.Forms.GroupBox();
            this.defaLanguageLbl = new baseClass.controls.baseLabel();
            this.useStrongPassChk = new common.controls.baseCheckBox();
            this.pwdMinLenLbl = new common.controls.baseLabel();
            this.pwdCharLbl = new common.controls.baseLabel();
            this.passwordMinLenEd = new common.controls.baseNumericUpDown();
            this.defaLanguageCb = new baseClass.controls.cbLanguages();
            this.autoKeyPg = new System.Windows.Forms.TabPage();
            this.autoKeyGb = new System.Windows.Forms.GroupBox();
            this.sysAutoEditKeySizeLbl = new common.controls.baseLabel();
            this.timeOutAutoKeyLbl = new common.controls.baseLabel();
            this.sysAutoEditKeySizeEd = new common.controls.baseNumericUpDown();
            this.sysDataKeyPrefixEd = new common.controls.baseMaskedTextBox();
            this.sysAutoDataKeySizeLbl = new common.controls.baseLabel();
            this.dataKeyPrefixLbl = new common.controls.baseLabel();
            this.secondLbl = new common.controls.baseLabel();
            this.sysAutoDataKeySizeEd = new common.controls.baseNumericUpDown();
            this.timeOutAutoKeyEd = new common.controls.baseNumericUpDown();
            this.emailPg = new System.Windows.Forms.TabPage();
            this.emailGb = new System.Windows.Forms.GroupBox();
            this.smtpAuthAccountLbl = new common.controls.baseLabel();
            this.smtpSSLChk = new common.controls.baseCheckBox();
            this.smtpPortLbl = new common.controls.baseLabel();
            this.smtpServerEd = new common.controls.baseMaskedTextBox();
            this.smtpAuthPasswordEd = new common.controls.baseMaskedTextBox();
            this.smtpServerLbl = new common.controls.baseLabel();
            this.smtpAuthPasswordLbl = new common.controls.baseLabel();
            this.smtpPortEd = new common.controls.baseMaskedTextBox();
            this.smtpAuthAccountEd = new common.controls.baseMaskedTextBox();
            this.defaultPg = new System.Windows.Forms.TabPage();
            this.screeningGb = new System.Windows.Forms.GroupBox();
            this.screenTimeScaleLbl = new baseClass.controls.baseLabel();
            this.screenDataCounEd = new common.controls.numberTextBox();
            this.screenDataCounLbl = new baseClass.controls.baseLabel();
            this.screenTimeScaleCb = new baseClass.controls.cbTimeScale();
            this.defaultGb = new System.Windows.Forms.GroupBox();
            this.defaTimeScaleCb = new baseClass.controls.cbTimeScale();
            this.defaTimeRangeCb = new baseClass.controls.cbTimeRange();
            this.defaTimeRangeLbl = new baseClass.controls.baseLabel();
            this.defaTimeScaleLbl = new baseClass.controls.baseLabel();
            this.timingPg = new System.Windows.Forms.TabPage();
            this.timingGb = new System.Windows.Forms.GroupBox();
            this.noTimerUnitLbl = new baseClass.controls.baseLabel();
            this.timerUnitToAutoCheckLbl = new baseClass.controls.baseLabel();
            this.timerUnitToAutoCheckEd = new common.controls.baseNumericUpDown();
            this.timerUnitLbl = new baseClass.controls.baseLabel();
            this.timerUnitEd = new common.controls.baseNumericUpDown();
            this.secondLbl2 = new baseClass.controls.baseLabel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.screenTimeRangeCb = new baseClass.controls.cbTimeRange();
            this.screenTimeRangeLbl = new baseClass.controls.baseLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTimeRange1 = new baseClass.controls.cbTimeRange();
            this.cbTimeScale1 = new baseClass.controls.cbTimeScale();
            this.numberTextBox1 = new common.controls.numberTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTimeRange2 = new baseClass.controls.cbTimeRange();
            this.cbTimeScale2 = new baseClass.controls.cbTimeScale();
            this.mainTab.SuspendLayout();
            this.systemPg.SuspendLayout();
            this.systemTab.SuspendLayout();
            this.generalPg.SuspendLayout();
            this.generalGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordMinLenEd)).BeginInit();
            this.autoKeyPg.SuspendLayout();
            this.autoKeyGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sysAutoEditKeySizeEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysAutoDataKeySizeEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeOutAutoKeyEd)).BeginInit();
            this.emailPg.SuspendLayout();
            this.emailGb.SuspendLayout();
            this.defaultPg.SuspendLayout();
            this.screeningGb.SuspendLayout();
            this.defaultGb.SuspendLayout();
            this.timingPg.SuspendLayout();
            this.timingGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerUnitToAutoCheckEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerUnitEd)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.mainTab.Controls.Add(this.systemPg);
            this.mainTab.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.mainTab.Location = new System.Drawing.Point(-1, 1);
            this.mainTab.Multiline = true;
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(427, 252);
            this.mainTab.TabIndex = 1;
            // 
            // systemPg
            // 
            this.systemPg.Controls.Add(this.systemTab);
            this.systemPg.Location = new System.Drawing.Point(4, 25);
            this.systemPg.Name = "systemPg";
            this.systemPg.Padding = new System.Windows.Forms.Padding(3);
            this.systemPg.Size = new System.Drawing.Size(419, 223);
            this.systemPg.TabIndex = 0;
            this.systemPg.Text = "Hệ thống";
            this.systemPg.UseVisualStyleBackColor = true;
            // 
            // systemTab
            // 
            this.systemTab.Controls.Add(this.generalPg);
            this.systemTab.Controls.Add(this.autoKeyPg);
            this.systemTab.Controls.Add(this.emailPg);
            this.systemTab.Controls.Add(this.defaultPg);
            this.systemTab.Controls.Add(this.timingPg);
            this.systemTab.Location = new System.Drawing.Point(-3, 0);
            this.systemTab.Multiline = true;
            this.systemTab.Name = "systemTab";
            this.systemTab.SelectedIndex = 0;
            this.systemTab.Size = new System.Drawing.Size(424, 231);
            this.systemTab.TabIndex = 146;
            // 
            // generalPg
            // 
            this.generalPg.Controls.Add(this.generalGb);
            this.generalPg.Location = new System.Drawing.Point(4, 25);
            this.generalPg.Name = "generalPg";
            this.generalPg.Padding = new System.Windows.Forms.Padding(3);
            this.generalPg.Size = new System.Drawing.Size(416, 202);
            this.generalPg.TabIndex = 1;
            this.generalPg.Text = "Chung";
            this.generalPg.UseVisualStyleBackColor = true;
            // 
            // generalGb
            // 
            this.generalGb.Controls.Add(this.defaLanguageLbl);
            this.generalGb.Controls.Add(this.useStrongPassChk);
            this.generalGb.Controls.Add(this.pwdMinLenLbl);
            this.generalGb.Controls.Add(this.pwdCharLbl);
            this.generalGb.Controls.Add(this.passwordMinLenEd);
            this.generalGb.Controls.Add(this.defaLanguageCb);
            this.generalGb.Location = new System.Drawing.Point(18, 3);
            this.generalGb.Name = "generalGb";
            this.generalGb.Size = new System.Drawing.Size(389, 160);
            this.generalGb.TabIndex = 154;
            this.generalGb.TabStop = false;
            // 
            // defaLanguageLbl
            // 
            this.defaLanguageLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaLanguageLbl.Location = new System.Drawing.Point(61, 40);
            this.defaLanguageLbl.Name = "defaLanguageLbl";
            this.defaLanguageLbl.Size = new System.Drawing.Size(133, 16);
            this.defaLanguageLbl.TabIndex = 215;
            this.defaLanguageLbl.Text = "Default language";
            this.defaLanguageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // useStrongPassChk
            // 
            this.useStrongPassChk.AutoSize = true;
            this.useStrongPassChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useStrongPassChk.Location = new System.Drawing.Point(61, 97);
            this.useStrongPassChk.Name = "useStrongPassChk";
            this.useStrongPassChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.useStrongPassChk.Size = new System.Drawing.Size(163, 20);
            this.useStrongPassChk.TabIndex = 3;
            this.useStrongPassChk.Text = "Dùng mật khẩu mạnh";
            this.useStrongPassChk.UseVisualStyleBackColor = true;
            // 
            // pwdMinLenLbl
            // 
            this.pwdMinLenLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdMinLenLbl.Location = new System.Drawing.Point(61, 69);
            this.pwdMinLenLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pwdMinLenLbl.Name = "pwdMinLenLbl";
            this.pwdMinLenLbl.Size = new System.Drawing.Size(133, 16);
            this.pwdMinLenLbl.TabIndex = 212;
            this.pwdMinLenLbl.Text = "Độ dài mật khẩu";
            // 
            // pwdCharLbl
            // 
            this.pwdCharLbl.AutoSize = true;
            this.pwdCharLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdCharLbl.Location = new System.Drawing.Point(249, 69);
            this.pwdCharLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pwdCharLbl.Name = "pwdCharLbl";
            this.pwdCharLbl.Size = new System.Drawing.Size(46, 16);
            this.pwdCharLbl.TabIndex = 213;
            this.pwdCharLbl.Text = "ký tự ";
            // 
            // passwordMinLenEd
            // 
            this.passwordMinLenEd.Location = new System.Drawing.Point(197, 66);
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
            this.passwordMinLenEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordMinLenEd.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // defaLanguageCb
            // 
            this.defaLanguageCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaLanguageCb.FormattingEnabled = true;
            this.defaLanguageCb.Location = new System.Drawing.Point(197, 37);
            this.defaLanguageCb.myCulture = new System.Globalization.CultureInfo("en-US");
            this.defaLanguageCb.myValue = commonTypes.AppTypes.LanguageCodes.EN;
            this.defaLanguageCb.Name = "defaLanguageCb";
            this.defaLanguageCb.Size = new System.Drawing.Size(121, 24);
            this.defaLanguageCb.TabIndex = 1;
            // 
            // autoKeyPg
            // 
            this.autoKeyPg.Controls.Add(this.autoKeyGb);
            this.autoKeyPg.Location = new System.Drawing.Point(4, 25);
            this.autoKeyPg.Name = "autoKeyPg";
            this.autoKeyPg.Padding = new System.Windows.Forms.Padding(3);
            this.autoKeyPg.Size = new System.Drawing.Size(416, 202);
            this.autoKeyPg.TabIndex = 0;
            this.autoKeyPg.Text = "Số tự động";
            this.autoKeyPg.UseVisualStyleBackColor = true;
            // 
            // autoKeyGb
            // 
            this.autoKeyGb.Controls.Add(this.sysAutoEditKeySizeLbl);
            this.autoKeyGb.Controls.Add(this.timeOutAutoKeyLbl);
            this.autoKeyGb.Controls.Add(this.sysAutoEditKeySizeEd);
            this.autoKeyGb.Controls.Add(this.sysDataKeyPrefixEd);
            this.autoKeyGb.Controls.Add(this.sysAutoDataKeySizeLbl);
            this.autoKeyGb.Controls.Add(this.dataKeyPrefixLbl);
            this.autoKeyGb.Controls.Add(this.secondLbl);
            this.autoKeyGb.Controls.Add(this.sysAutoDataKeySizeEd);
            this.autoKeyGb.Controls.Add(this.timeOutAutoKeyEd);
            this.autoKeyGb.Location = new System.Drawing.Point(18, 3);
            this.autoKeyGb.Name = "autoKeyGb";
            this.autoKeyGb.Size = new System.Drawing.Size(389, 160);
            this.autoKeyGb.TabIndex = 156;
            this.autoKeyGb.TabStop = false;
            // 
            // sysAutoEditKeySizeLbl
            // 
            this.sysAutoEditKeySizeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sysAutoEditKeySizeLbl.Location = new System.Drawing.Point(39, 87);
            this.sysAutoEditKeySizeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sysAutoEditKeySizeLbl.Name = "sysAutoEditKeySizeLbl";
            this.sysAutoEditKeySizeLbl.Size = new System.Drawing.Size(191, 18);
            this.sysAutoEditKeySizeLbl.TabIndex = 218;
            this.sysAutoEditKeySizeLbl.Text = "Độ dài tối đa của số tự động";
            this.sysAutoEditKeySizeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeOutAutoKeyLbl
            // 
            this.timeOutAutoKeyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeOutAutoKeyLbl.Location = new System.Drawing.Point(39, 115);
            this.timeOutAutoKeyLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeOutAutoKeyLbl.Name = "timeOutAutoKeyLbl";
            this.timeOutAutoKeyLbl.Size = new System.Drawing.Size(191, 18);
            this.timeOutAutoKeyLbl.TabIndex = 209;
            this.timeOutAutoKeyLbl.Text = "Thời gian giữ số tự động";
            this.timeOutAutoKeyLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sysAutoEditKeySizeEd
            // 
            this.sysAutoEditKeySizeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.sysAutoEditKeySizeEd.Location = new System.Drawing.Point(235, 83);
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
            // sysDataKeyPrefixEd
            // 
            this.sysDataKeyPrefixEd.BeepOnError = true;
            this.sysDataKeyPrefixEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.sysDataKeyPrefixEd.Location = new System.Drawing.Point(235, 27);
            this.sysDataKeyPrefixEd.Margin = new System.Windows.Forms.Padding(4);
            this.sysDataKeyPrefixEd.Name = "sysDataKeyPrefixEd";
            this.sysDataKeyPrefixEd.Size = new System.Drawing.Size(35, 24);
            this.sysDataKeyPrefixEd.TabIndex = 1;
            this.sysDataKeyPrefixEd.Text = "A";
            this.sysDataKeyPrefixEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sysAutoDataKeySizeLbl
            // 
            this.sysAutoDataKeySizeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sysAutoDataKeySizeLbl.Location = new System.Drawing.Point(39, 58);
            this.sysAutoDataKeySizeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sysAutoDataKeySizeLbl.Name = "sysAutoDataKeySizeLbl";
            this.sysAutoDataKeySizeLbl.Size = new System.Drawing.Size(191, 18);
            this.sysAutoDataKeySizeLbl.TabIndex = 211;
            this.sysAutoDataKeySizeLbl.Text = "Độ dài tối đa của dữ liệu khóa";
            this.sysAutoDataKeySizeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataKeyPrefixLbl
            // 
            this.dataKeyPrefixLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataKeyPrefixLbl.Location = new System.Drawing.Point(39, 29);
            this.dataKeyPrefixLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataKeyPrefixLbl.Name = "dataKeyPrefixLbl";
            this.dataKeyPrefixLbl.Size = new System.Drawing.Size(191, 18);
            this.dataKeyPrefixLbl.TabIndex = 208;
            this.dataKeyPrefixLbl.Text = "Tiền tố của khóa dữ liệu";
            this.dataKeyPrefixLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // secondLbl
            // 
            this.secondLbl.AutoSize = true;
            this.secondLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondLbl.Location = new System.Drawing.Point(294, 115);
            this.secondLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.secondLbl.Name = "secondLbl";
            this.secondLbl.Size = new System.Drawing.Size(35, 16);
            this.secondLbl.TabIndex = 210;
            this.secondLbl.Text = "giây";
            // 
            // sysAutoDataKeySizeEd
            // 
            this.sysAutoDataKeySizeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.sysAutoDataKeySizeEd.Location = new System.Drawing.Point(235, 55);
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
            // timeOutAutoKeyEd
            // 
            this.timeOutAutoKeyEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.timeOutAutoKeyEd.Location = new System.Drawing.Point(235, 111);
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
            this.timeOutAutoKeyEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timeOutAutoKeyEd.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // emailPg
            // 
            this.emailPg.Controls.Add(this.emailGb);
            this.emailPg.Location = new System.Drawing.Point(4, 22);
            this.emailPg.Name = "emailPg";
            this.emailPg.Padding = new System.Windows.Forms.Padding(3);
            this.emailPg.Size = new System.Drawing.Size(416, 205);
            this.emailPg.TabIndex = 5;
            this.emailPg.Text = "E-mail";
            this.emailPg.UseVisualStyleBackColor = true;
            // 
            // emailGb
            // 
            this.emailGb.Controls.Add(this.smtpAuthAccountLbl);
            this.emailGb.Controls.Add(this.smtpSSLChk);
            this.emailGb.Controls.Add(this.smtpPortLbl);
            this.emailGb.Controls.Add(this.smtpServerEd);
            this.emailGb.Controls.Add(this.smtpAuthPasswordEd);
            this.emailGb.Controls.Add(this.smtpServerLbl);
            this.emailGb.Controls.Add(this.smtpAuthPasswordLbl);
            this.emailGb.Controls.Add(this.smtpPortEd);
            this.emailGb.Controls.Add(this.smtpAuthAccountEd);
            this.emailGb.Location = new System.Drawing.Point(18, 3);
            this.emailGb.Name = "emailGb";
            this.emailGb.Size = new System.Drawing.Size(389, 160);
            this.emailGb.TabIndex = 155;
            this.emailGb.TabStop = false;
            // 
            // smtpAuthAccountLbl
            // 
            this.smtpAuthAccountLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.smtpAuthAccountLbl.Location = new System.Drawing.Point(15, 48);
            this.smtpAuthAccountLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.smtpAuthAccountLbl.Name = "smtpAuthAccountLbl";
            this.smtpAuthAccountLbl.Size = new System.Drawing.Size(114, 18);
            this.smtpAuthAccountLbl.TabIndex = 224;
            this.smtpAuthAccountLbl.Text = "Tài khỏan";
            this.smtpAuthAccountLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // smtpSSLChk
            // 
            this.smtpSSLChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.smtpSSLChk.Location = new System.Drawing.Point(137, 120);
            this.smtpSSLChk.Name = "smtpSSLChk";
            this.smtpSSLChk.Size = new System.Drawing.Size(219, 21);
            this.smtpSSLChk.TabIndex = 6;
            this.smtpSSLChk.Text = "Dùng mã hóa (SSL)  ";
            // 
            // smtpPortLbl
            // 
            this.smtpPortLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.smtpPortLbl.Location = new System.Drawing.Point(15, 96);
            this.smtpPortLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.smtpPortLbl.Name = "smtpPortLbl";
            this.smtpPortLbl.Size = new System.Drawing.Size(114, 18);
            this.smtpPortLbl.TabIndex = 223;
            this.smtpPortLbl.Text = "Cổng dịch vụ";
            this.smtpPortLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // smtpServerEd
            // 
            this.smtpServerEd.BeepOnError = true;
            this.smtpServerEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smtpServerEd.Location = new System.Drawing.Point(136, 18);
            this.smtpServerEd.Margin = new System.Windows.Forms.Padding(4);
            this.smtpServerEd.Name = "smtpServerEd";
            this.smtpServerEd.Size = new System.Drawing.Size(221, 24);
            this.smtpServerEd.TabIndex = 1;
            this.smtpServerEd.Text = "127.0.0.1";
            // 
            // smtpAuthPasswordEd
            // 
            this.smtpAuthPasswordEd.BeepOnError = true;
            this.smtpAuthPasswordEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smtpAuthPasswordEd.Location = new System.Drawing.Point(136, 68);
            this.smtpAuthPasswordEd.Margin = new System.Windows.Forms.Padding(4);
            this.smtpAuthPasswordEd.Name = "smtpAuthPasswordEd";
            this.smtpAuthPasswordEd.Size = new System.Drawing.Size(132, 24);
            this.smtpAuthPasswordEd.TabIndex = 3;
            // 
            // smtpServerLbl
            // 
            this.smtpServerLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.smtpServerLbl.Location = new System.Drawing.Point(15, 22);
            this.smtpServerLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.smtpServerLbl.Name = "smtpServerLbl";
            this.smtpServerLbl.Size = new System.Drawing.Size(114, 18);
            this.smtpServerLbl.TabIndex = 210;
            this.smtpServerLbl.Text = "Máy chủ SMTP";
            this.smtpServerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // smtpAuthPasswordLbl
            // 
            this.smtpAuthPasswordLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.smtpAuthPasswordLbl.Location = new System.Drawing.Point(15, 72);
            this.smtpAuthPasswordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.smtpAuthPasswordLbl.Name = "smtpAuthPasswordLbl";
            this.smtpAuthPasswordLbl.Size = new System.Drawing.Size(114, 18);
            this.smtpAuthPasswordLbl.TabIndex = 222;
            this.smtpAuthPasswordLbl.Text = "Mật khẩu";
            this.smtpAuthPasswordLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // smtpPortEd
            // 
            this.smtpPortEd.BeepOnError = true;
            this.smtpPortEd.Enabled = false;
            this.smtpPortEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smtpPortEd.Location = new System.Drawing.Point(136, 93);
            this.smtpPortEd.Margin = new System.Windows.Forms.Padding(4);
            this.smtpPortEd.Name = "smtpPortEd";
            this.smtpPortEd.Size = new System.Drawing.Size(50, 24);
            this.smtpPortEd.TabIndex = 5;
            this.smtpPortEd.Text = "25";
            // 
            // smtpAuthAccountEd
            // 
            this.smtpAuthAccountEd.BeepOnError = true;
            this.smtpAuthAccountEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smtpAuthAccountEd.Location = new System.Drawing.Point(136, 43);
            this.smtpAuthAccountEd.Margin = new System.Windows.Forms.Padding(4);
            this.smtpAuthAccountEd.Name = "smtpAuthAccountEd";
            this.smtpAuthAccountEd.Size = new System.Drawing.Size(132, 24);
            this.smtpAuthAccountEd.TabIndex = 2;
            // 
            // defaultPg
            // 
            this.defaultPg.Controls.Add(this.screeningGb);
            this.defaultPg.Controls.Add(this.defaultGb);
            this.defaultPg.Location = new System.Drawing.Point(4, 22);
            this.defaultPg.Name = "defaultPg";
            this.defaultPg.Padding = new System.Windows.Forms.Padding(3);
            this.defaultPg.Size = new System.Drawing.Size(416, 205);
            this.defaultPg.TabIndex = 6;
            this.defaultPg.Text = "Mặc định";
            this.defaultPg.UseVisualStyleBackColor = true;
            // 
            // screeningGb
            // 
            this.screeningGb.Controls.Add(this.screenTimeScaleLbl);
            this.screeningGb.Controls.Add(this.screenDataCounEd);
            this.screeningGb.Controls.Add(this.screenDataCounLbl);
            this.screeningGb.Controls.Add(this.screenTimeScaleCb);
            this.screeningGb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screeningGb.Location = new System.Drawing.Point(18, 85);
            this.screeningGb.Name = "screeningGb";
            this.screeningGb.Size = new System.Drawing.Size(375, 76);
            this.screeningGb.TabIndex = 221;
            this.screeningGb.TabStop = false;
            this.screeningGb.Text = " Screening ";
            // 
            // screenTimeScaleLbl
            // 
            this.screenTimeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenTimeScaleLbl.Location = new System.Drawing.Point(7, 46);
            this.screenTimeScaleLbl.Name = "screenTimeScaleLbl";
            this.screenTimeScaleLbl.Size = new System.Drawing.Size(115, 20);
            this.screenTimeScaleLbl.TabIndex = 382;
            this.screenTimeScaleLbl.Text = "Time scale";
            this.screenTimeScaleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // screenDataCounEd
            // 
            this.screenDataCounEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenDataCounEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.screenDataCounEd.Location = new System.Drawing.Point(125, 18);
            this.screenDataCounEd.myFormat = "###,###,###,###,##0";
            this.screenDataCounEd.Name = "screenDataCounEd";
            this.screenDataCounEd.Size = new System.Drawing.Size(78, 24);
            this.screenDataCounEd.TabIndex = 380;
            this.screenDataCounEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.screenDataCounEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.screenDataCounEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // screenDataCounLbl
            // 
            this.screenDataCounLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenDataCounLbl.Location = new System.Drawing.Point(7, 21);
            this.screenDataCounLbl.Name = "screenDataCounLbl";
            this.screenDataCounLbl.Size = new System.Drawing.Size(115, 20);
            this.screenDataCounLbl.TabIndex = 381;
            this.screenDataCounLbl.Text = "No of bars";
            this.screenDataCounLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // screenTimeScaleCb
            // 
            this.screenTimeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screenTimeScaleCb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenTimeScaleCb.FormattingEnabled = true;
            this.screenTimeScaleCb.Location = new System.Drawing.Point(125, 45);
            this.screenTimeScaleCb.Name = "screenTimeScaleCb";
            this.screenTimeScaleCb.SelectedValue = "RT";
            this.screenTimeScaleCb.Size = new System.Drawing.Size(196, 24);
            this.screenTimeScaleCb.TabIndex = 2;
            // 
            // defaultGb
            // 
            this.defaultGb.Controls.Add(this.defaTimeScaleCb);
            this.defaultGb.Controls.Add(this.defaTimeRangeCb);
            this.defaultGb.Controls.Add(this.defaTimeRangeLbl);
            this.defaultGb.Controls.Add(this.defaTimeScaleLbl);
            this.defaultGb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultGb.Location = new System.Drawing.Point(17, 7);
            this.defaultGb.Name = "defaultGb";
            this.defaultGb.Size = new System.Drawing.Size(377, 77);
            this.defaultGb.TabIndex = 220;
            this.defaultGb.TabStop = false;
            this.defaultGb.Text = " Default ";
            // 
            // defaTimeScaleCb
            // 
            this.defaTimeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaTimeScaleCb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaTimeScaleCb.FormattingEnabled = true;
            this.defaTimeScaleCb.Location = new System.Drawing.Point(126, 43);
            this.defaTimeScaleCb.Name = "defaTimeScaleCb";
            this.defaTimeScaleCb.SelectedValue = "RT";
            this.defaTimeScaleCb.Size = new System.Drawing.Size(196, 24);
            this.defaTimeScaleCb.TabIndex = 16;
            // 
            // defaTimeRangeCb
            // 
            this.defaTimeRangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaTimeRangeCb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaTimeRangeCb.FormattingEnabled = true;
            this.defaTimeRangeCb.Location = new System.Drawing.Point(126, 18);
            this.defaTimeRangeCb.myValue = commonTypes.AppTypes.TimeRanges.None;
            this.defaTimeRangeCb.Name = "defaTimeRangeCb";
            this.defaTimeRangeCb.SelectedValue = ((byte)(0));
            this.defaTimeRangeCb.Size = new System.Drawing.Size(196, 24);
            this.defaTimeRangeCb.TabIndex = 15;
            // 
            // defaTimeRangeLbl
            // 
            this.defaTimeRangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaTimeRangeLbl.Location = new System.Drawing.Point(7, 21);
            this.defaTimeRangeLbl.Name = "defaTimeRangeLbl";
            this.defaTimeRangeLbl.Size = new System.Drawing.Size(115, 20);
            this.defaTimeRangeLbl.TabIndex = 17;
            this.defaTimeRangeLbl.Text = "Time range";
            this.defaTimeRangeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // defaTimeScaleLbl
            // 
            this.defaTimeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaTimeScaleLbl.Location = new System.Drawing.Point(7, 48);
            this.defaTimeScaleLbl.Name = "defaTimeScaleLbl";
            this.defaTimeScaleLbl.Size = new System.Drawing.Size(115, 20);
            this.defaTimeScaleLbl.TabIndex = 16;
            this.defaTimeScaleLbl.Text = "Time scale";
            this.defaTimeScaleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timingPg
            // 
            this.timingPg.Controls.Add(this.timingGb);
            this.timingPg.Location = new System.Drawing.Point(4, 22);
            this.timingPg.Name = "timingPg";
            this.timingPg.Padding = new System.Windows.Forms.Padding(3);
            this.timingPg.Size = new System.Drawing.Size(416, 205);
            this.timingPg.TabIndex = 7;
            this.timingPg.Text = "Định thời";
            this.timingPg.UseVisualStyleBackColor = true;
            // 
            // timingGb
            // 
            this.timingGb.Controls.Add(this.noTimerUnitLbl);
            this.timingGb.Controls.Add(this.timerUnitToAutoCheckLbl);
            this.timingGb.Controls.Add(this.timerUnitToAutoCheckEd);
            this.timingGb.Controls.Add(this.timerUnitLbl);
            this.timingGb.Controls.Add(this.timerUnitEd);
            this.timingGb.Controls.Add(this.secondLbl2);
            this.timingGb.Location = new System.Drawing.Point(18, 3);
            this.timingGb.Name = "timingGb";
            this.timingGb.Size = new System.Drawing.Size(380, 163);
            this.timingGb.TabIndex = 153;
            this.timingGb.TabStop = false;
            // 
            // noTimerUnitLbl
            // 
            this.noTimerUnitLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noTimerUnitLbl.Location = new System.Drawing.Point(240, 83);
            this.noTimerUnitLbl.Name = "noTimerUnitLbl";
            this.noTimerUnitLbl.Size = new System.Drawing.Size(119, 21);
            this.noTimerUnitLbl.TabIndex = 19;
            this.noTimerUnitLbl.Text = "times";
            // 
            // timerUnitToAutoCheckLbl
            // 
            this.timerUnitToAutoCheckLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerUnitToAutoCheckLbl.Location = new System.Drawing.Point(7, 83);
            this.timerUnitToAutoCheckLbl.Name = "timerUnitToAutoCheckLbl";
            this.timerUnitToAutoCheckLbl.Size = new System.Drawing.Size(172, 18);
            this.timerUnitToAutoCheckLbl.TabIndex = 18;
            this.timerUnitToAutoCheckLbl.Text = "Auto check rate";
            this.timerUnitToAutoCheckLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerUnitToAutoCheckEd
            // 
            this.timerUnitToAutoCheckEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerUnitToAutoCheckEd.Location = new System.Drawing.Point(183, 79);
            this.timerUnitToAutoCheckEd.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.timerUnitToAutoCheckEd.myValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.timerUnitToAutoCheckEd.Name = "timerUnitToAutoCheckEd";
            this.timerUnitToAutoCheckEd.Size = new System.Drawing.Size(53, 26);
            this.timerUnitToAutoCheckEd.TabIndex = 2;
            this.timerUnitToAutoCheckEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timerUnitToAutoCheckEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // timerUnitLbl
            // 
            this.timerUnitLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerUnitLbl.Location = new System.Drawing.Point(7, 55);
            this.timerUnitLbl.Name = "timerUnitLbl";
            this.timerUnitLbl.Size = new System.Drawing.Size(172, 18);
            this.timerUnitLbl.TabIndex = 15;
            this.timerUnitLbl.Text = "Timer unit";
            this.timerUnitLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerUnitEd
            // 
            this.timerUnitEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerUnitEd.Location = new System.Drawing.Point(183, 51);
            this.timerUnitEd.myValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.timerUnitEd.Name = "timerUnitEd";
            this.timerUnitEd.Size = new System.Drawing.Size(53, 26);
            this.timerUnitEd.TabIndex = 1;
            this.timerUnitEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timerUnitEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // secondLbl2
            // 
            this.secondLbl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondLbl2.Location = new System.Drawing.Point(240, 56);
            this.secondLbl2.Name = "secondLbl2";
            this.secondLbl2.Size = new System.Drawing.Size(119, 21);
            this.secondLbl2.TabIndex = 16;
            this.secondLbl2.Text = "seconds";
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.Location = new System.Drawing.Point(315, 218);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(84, 29);
            this.closeBtn.TabIndex = 11;
            this.closeBtn.Text = "Đóng";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = global::baseClass.Properties.Resources.save;
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.Location = new System.Drawing.Point(231, 218);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(84, 29);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "&Lưu";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // screenTimeRangeCb
            // 
            this.screenTimeRangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screenTimeRangeCb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenTimeRangeCb.FormattingEnabled = true;
            this.screenTimeRangeCb.Location = new System.Drawing.Point(125, 17);
            this.screenTimeRangeCb.myValue = commonTypes.AppTypes.TimeRanges.None;
            this.screenTimeRangeCb.Name = "screenTimeRangeCb";
            this.screenTimeRangeCb.SelectedValue = ((byte)(0));
            this.screenTimeRangeCb.Size = new System.Drawing.Size(196, 24);
            this.screenTimeRangeCb.TabIndex = 1;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTimeRange1);
            this.groupBox1.Controls.Add(this.cbTimeScale1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 76);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Screening";
            // 
            // cbTimeRange1
            // 
            this.cbTimeRange1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeRange1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTimeRange1.FormattingEnabled = true;
            this.cbTimeRange1.Location = new System.Drawing.Point(125, 17);
            this.cbTimeRange1.myValue = commonTypes.AppTypes.TimeRanges.None;
            this.cbTimeRange1.Name = "cbTimeRange1";
            this.cbTimeRange1.SelectedValue = ((byte)(0));
            this.cbTimeRange1.Size = new System.Drawing.Size(196, 24);
            this.cbTimeRange1.TabIndex = 1;
            // 
            // cbTimeScale1
            // 
            this.cbTimeScale1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeScale1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTimeScale1.FormattingEnabled = true;
            this.cbTimeScale1.Location = new System.Drawing.Point(125, 44);
            this.cbTimeScale1.Name = "cbTimeScale1";
            this.cbTimeScale1.SelectedValue = "RT";
            this.cbTimeScale1.Size = new System.Drawing.Size(196, 24);
            this.cbTimeScale1.TabIndex = 2;
            // 
            // numberTextBox1
            // 
            this.numberTextBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberTextBox1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.numberTextBox1.Location = new System.Drawing.Point(149, 18);
            this.numberTextBox1.myFormat = "###.##";
            this.numberTextBox1.Name = "numberTextBox1";
            this.numberTextBox1.Size = new System.Drawing.Size(53, 26);
            this.numberTextBox1.TabIndex = 1;
            this.numberTextBox1.Text = "1";
            this.numberTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numberTextBox1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.numberTextBox1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTimeRange2);
            this.groupBox2.Controls.Add(this.cbTimeScale2);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(24, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 85);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Default";
            // 
            // cbTimeRange2
            // 
            this.cbTimeRange2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeRange2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTimeRange2.FormattingEnabled = true;
            this.cbTimeRange2.Location = new System.Drawing.Point(126, 21);
            this.cbTimeRange2.myValue = commonTypes.AppTypes.TimeRanges.None;
            this.cbTimeRange2.Name = "cbTimeRange2";
            this.cbTimeRange2.SelectedValue = ((byte)(0));
            this.cbTimeRange2.Size = new System.Drawing.Size(196, 24);
            this.cbTimeRange2.TabIndex = 15;
            // 
            // cbTimeScale2
            // 
            this.cbTimeScale2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeScale2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTimeScale2.FormattingEnabled = true;
            this.cbTimeScale2.Location = new System.Drawing.Point(126, 48);
            this.cbTimeScale2.Name = "cbTimeScale2";
            this.cbTimeScale2.SelectedValue = "RT";
            this.cbTimeScale2.Size = new System.Drawing.Size(196, 24);
            this.cbTimeScale2.TabIndex = 2;
            // 
            // sysOptionGlobal
            // 
            this.ClientSize = new System.Drawing.Size(419, 276);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.mainTab);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "sysOptionGlobal";
            this.Text = "Thiet lap thong so";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.mainTab, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.saveBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.mainTab.ResumeLayout(false);
            this.systemPg.ResumeLayout(false);
            this.systemTab.ResumeLayout(false);
            this.generalPg.ResumeLayout(false);
            this.generalGb.ResumeLayout(false);
            this.generalGb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordMinLenEd)).EndInit();
            this.autoKeyPg.ResumeLayout(false);
            this.autoKeyGb.ResumeLayout(false);
            this.autoKeyGb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sysAutoEditKeySizeEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysAutoDataKeySizeEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeOutAutoKeyEd)).EndInit();
            this.emailPg.ResumeLayout(false);
            this.emailGb.ResumeLayout(false);
            this.emailGb.PerformLayout();
            this.defaultPg.ResumeLayout(false);
            this.screeningGb.ResumeLayout(false);
            this.screeningGb.PerformLayout();
            this.defaultGb.ResumeLayout(false);
            this.timingPg.ResumeLayout(false);
            this.timingGb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timerUnitToAutoCheckEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerUnitEd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button closeBtn;
        protected System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TabPage systemPg;
        private System.Windows.Forms.TabPage autoKeyPg;
        protected common.controls.baseLabel sysAutoDataKeySizeLbl;
        protected common.controls.baseLabel secondLbl;
        protected common.controls.baseLabel timeOutAutoKeyLbl;
        protected common.controls.baseLabel dataKeyPrefixLbl;
        protected common.controls.baseMaskedTextBox sysDataKeyPrefixEd;
        private System.Windows.Forms.TabPage generalPg;
        protected common.controls.baseLabel pwdCharLbl;
        protected common.controls.baseLabel pwdMinLenLbl;
        protected System.Windows.Forms.TabControl mainTab;
        protected System.Windows.Forms.TabControl systemTab;
        protected common.controls.baseNumericUpDown timeOutAutoKeyEd;
        protected common.controls.baseNumericUpDown sysAutoDataKeySizeEd;
        protected common.controls.baseNumericUpDown passwordMinLenEd;
        protected common.controls.baseNumericUpDown sysAutoEditKeySizeEd;
        private System.Windows.Forms.TabPage emailPg;
        protected common.controls.baseLabel smtpServerLbl;
        protected common.controls.baseMaskedTextBox smtpServerEd;
        protected common.controls.baseCheckBox smtpSSLChk;
        protected common.controls.baseMaskedTextBox smtpAuthPasswordEd;
        protected common.controls.baseLabel smtpAuthPasswordLbl;
        protected common.controls.baseMaskedTextBox smtpAuthAccountEd;
        protected common.controls.baseMaskedTextBox smtpPortEd;
        protected common.controls.baseLabel smtpPortLbl;
        private baseClass.controls.cbTimeRange screenTimeRangeCb;
        private baseClass.controls.baseLabel screenTimeRangeLbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private baseClass.controls.cbTimeRange cbTimeRange1;
        private baseClass.controls.cbTimeScale cbTimeScale1;
        private common.controls.numberTextBox numberTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private baseClass.controls.cbTimeRange cbTimeRange2;
        private baseClass.controls.cbTimeScale cbTimeScale2;
        protected common.controls.baseLabel sysAutoEditKeySizeLbl;
        protected common.controls.baseLabel smtpAuthAccountLbl;
        protected common.controls.baseCheckBox useStrongPassChk;
        protected baseClass.controls.baseLabel defaLanguageLbl;
        protected baseClass.controls.cbLanguages defaLanguageCb;
        private System.Windows.Forms.TabPage defaultPg;
        private System.Windows.Forms.GroupBox screeningGb;
        protected baseClass.controls.baseLabel screenTimeScaleLbl;
        private common.controls.numberTextBox screenDataCounEd;
        protected baseClass.controls.baseLabel screenDataCounLbl;
        private baseClass.controls.cbTimeScale screenTimeScaleCb;
        private System.Windows.Forms.GroupBox defaultGb;
        private baseClass.controls.cbTimeScale defaTimeScaleCb;
        private baseClass.controls.cbTimeRange defaTimeRangeCb;
        private baseClass.controls.baseLabel defaTimeRangeLbl;
        private baseClass.controls.baseLabel defaTimeScaleLbl;
        private System.Windows.Forms.TabPage timingPg;
        protected System.Windows.Forms.GroupBox timingGb;
        protected baseClass.controls.baseLabel timerUnitToAutoCheckLbl;
        protected common.controls.baseNumericUpDown timerUnitToAutoCheckEd;
        protected baseClass.controls.baseLabel timerUnitLbl;
        protected common.controls.baseNumericUpDown timerUnitEd;
        protected baseClass.controls.baseLabel secondLbl2;
        protected baseClass.controls.baseLabel noTimerUnitLbl;
        protected System.Windows.Forms.GroupBox generalGb;
        protected System.Windows.Forms.GroupBox autoKeyGb;
        protected System.Windows.Forms.GroupBox emailGb;
    }
}
