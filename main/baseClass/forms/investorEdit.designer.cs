namespace baseClass.forms
{
    partial class investorEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(investorEdit));
            this.codeEd = new common.controls.baseTextBox();
            this.investorSource = new System.Windows.Forms.BindingSource(this.components);
            this.firstNameEd = new common.controls.baseTextBox();
            this.nameLbl = new baseClass.controls.baseLabel();
            this.lastNameEd = new common.controls.baseTextBox();
            this.lastNameLbl = new baseClass.controls.baseLabel();
            this.address1Ed = new common.controls.baseTextBox();
            this.address1Lbl = new baseClass.controls.baseLabel();
            this.sexCb = new baseClass.controls.cbSex();
            this.sexLbl = new baseClass.controls.baseLabel();
            this.address2Lbl = new baseClass.controls.baseLabel();
            this.address2Ed = new common.controls.baseTextBox();
            this.countryCb = new baseClass.controls.cbCountry();
            this.countryLbl = new baseClass.controls.baseLabel();
            this.emailEd = new common.controls.baseTextBox();
            this.emailLbl = new baseClass.controls.baseLabel();
            this.accountLbl = new baseClass.controls.baseLabel();
            this.accountEd = new common.controls.baseTextBox();
            this.passwordLbl = new baseClass.controls.baseLabel();
            this.passwordEd = new common.controls.baseTextBox();
            this.statusCb = new baseClass.controls.cbCommonStatus();
            this.statusLbl = new baseClass.controls.baseLabel();
            this.portfolioSource = new System.Windows.Forms.BindingSource(this.components);
            this.expireDateEd = new common.controls.baseDate();
            this.expireDateLbl = new baseClass.controls.baseLabel();
            this.investorCatLbl = new baseClass.controls.baseLabel();
            this.investorCatCb = new baseClass.controls.cbInvestorCat();
            this.phoneEd = new common.controls.baseTextBox();
            this.phoneLbl = new baseClass.controls.baseLabel();
            this.infoPnl = new System.Windows.Forms.Panel();
            this.displayNameLbl = new baseClass.controls.baseLabel();
            this.mobileLbl = new baseClass.controls.baseLabel();
            this.mobileEd = new common.controls.baseTextBox();
            this.noteLbl = new baseClass.controls.baseLabel();
            this.noteEd = new common.controls.baseTextBox();
            this.passwordEd2 = new common.controls.baseTextBox();
            this.watchListBtn = new common.controls.baseButton();
            this.portfolioBtn = new common.controls.baseButton();
            this.displayNameEd = new common.controls.baseTextBox();
            this.watchListSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).BeginInit();
            this.infoPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watchListSource)).BeginInit();
            this.SuspendLayout();
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myBaseDS";
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-34, -5);
            this.toolBox.Size = new System.Drawing.Size(1174, 49);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(486, 5);
            this.exitBtn.Size = new System.Drawing.Size(75, 39);
            this.exitBtn.Text = "Close";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(109, 5);
            this.saveBtn.Size = new System.Drawing.Size(75, 39);
            this.saveBtn.Text = "Save";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Location = new System.Drawing.Point(259, 5);
            this.deleteBtn.Size = new System.Drawing.Size(75, 39);
            this.deleteBtn.TabIndex = 4;
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(184, 5);
            this.editBtn.Size = new System.Drawing.Size(75, 39);
            this.editBtn.TabIndex = 3;
            this.editBtn.Text = "&Edit";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(34, 5);
            this.addNewBtn.Size = new System.Drawing.Size(75, 39);
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(818, 5);
            this.toExcelBtn.Size = new System.Drawing.Size(81, 39);
            this.toExcelBtn.Text = "Export";
            this.toExcelBtn.Visible = false;
            // 
            // findBtn
            // 
            this.findBtn.Enabled = false;
            this.findBtn.Location = new System.Drawing.Point(334, 5);
            this.findBtn.Size = new System.Drawing.Size(75, 39);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(409, 5);
            this.reloadBtn.Size = new System.Drawing.Size(77, 39);
            this.reloadBtn.Visible = false;
            // 
            // unLockBtn
            // 
            this.unLockBtn.Location = new System.Drawing.Point(1174, 292);
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(1174, 251);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(737, 5);
            this.printBtn.Size = new System.Drawing.Size(81, 39);
            this.printBtn.Text = "&Print";
            this.printBtn.Visible = false;
            // 
            // importBtn
            // 
            this.importBtn.Location = new System.Drawing.Point(899, 5);
            this.importBtn.Size = new System.Drawing.Size(81, 39);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(953, 9);
            this.TitleLbl.Size = new System.Drawing.Size(356, 24);
            this.TitleLbl.TabIndex = 149;
            this.TitleLbl.Text = "THÔNG TIN DỰ ÁN";
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.SystemColors.Window;
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "code", true));
            this.codeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEd.isToUpperCase = false;
            this.codeEd.Location = new System.Drawing.Point(162, 66);
            this.codeEd.Margin = new System.Windows.Forms.Padding(4);
            this.codeEd.Name = "codeEd";
            this.codeEd.ReadOnly = true;
            this.codeEd.Size = new System.Drawing.Size(103, 24);
            this.codeEd.TabIndex = 3;
            this.codeEd.TabStop = false;
            // 
            // investorSource
            // 
            this.investorSource.DataMember = "investor";
            this.investorSource.DataSource = this.myDataSet;
            // 
            // firstNameEd
            // 
            this.firstNameEd.BackColor = System.Drawing.SystemColors.Window;
            this.firstNameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "firstName", true));
            this.firstNameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameEd.isToUpperCase = false;
            this.firstNameEd.Location = new System.Drawing.Point(265, 119);
            this.firstNameEd.Name = "firstNameEd";
            this.firstNameEd.Size = new System.Drawing.Size(124, 22);
            this.firstNameEd.TabIndex = 11;
            this.firstNameEd.TextChanged += new System.EventHandler(this.firstNameEd_TextChanged);
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(264, 99);
            this.nameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(87, 16);
            this.nameLbl.TabIndex = 257;
            this.nameLbl.Text = "First Name *";
            // 
            // lastNameEd
            // 
            this.lastNameEd.BackColor = System.Drawing.SystemColors.Window;
            this.lastNameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "lastName", true));
            this.lastNameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameEd.isToUpperCase = false;
            this.lastNameEd.Location = new System.Drawing.Point(25, 119);
            this.lastNameEd.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameEd.Name = "lastNameEd";
            this.lastNameEd.Size = new System.Drawing.Size(242, 22);
            this.lastNameEd.TabIndex = 10;
            this.lastNameEd.TextChanged += new System.EventHandler(this.lastNameEd_TextChanged);
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.AutoSize = true;
            this.lastNameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLbl.Location = new System.Drawing.Point(25, 99);
            this.lastNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastNameLbl.Name = "lastNameLbl";
            this.lastNameLbl.Size = new System.Drawing.Size(87, 16);
            this.lastNameLbl.TabIndex = 265;
            this.lastNameLbl.Text = "Last Name *";
            // 
            // address1Ed
            // 
            this.address1Ed.BackColor = System.Drawing.SystemColors.Window;
            this.address1Ed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "address1", true));
            this.address1Ed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Ed.isToUpperCase = false;
            this.address1Ed.Location = new System.Drawing.Point(25, 221);
            this.address1Ed.Margin = new System.Windows.Forms.Padding(4);
            this.address1Ed.Multiline = true;
            this.address1Ed.Name = "address1Ed";
            this.address1Ed.Size = new System.Drawing.Size(482, 40);
            this.address1Ed.TabIndex = 20;
            // 
            // address1Lbl
            // 
            this.address1Lbl.AutoSize = true;
            this.address1Lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Lbl.Location = new System.Drawing.Point(25, 202);
            this.address1Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.address1Lbl.Name = "address1Lbl";
            this.address1Lbl.Size = new System.Drawing.Size(86, 16);
            this.address1Lbl.TabIndex = 269;
            this.address1Lbl.Text = "Address 1 *";
            // 
            // sexCb
            // 
            this.sexCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.investorSource, "sex", true));
            this.sexCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexCb.FormattingEnabled = true;
            this.sexCb.Location = new System.Drawing.Point(389, 119);
            this.sexCb.myValue = commonClass.AppTypes.Sex.None;
            this.sexCb.Name = "sexCb";
            this.sexCb.SelectedValue = ((byte)(0));
            this.sexCb.Size = new System.Drawing.Size(118, 24);
            this.sexCb.TabIndex = 13;
            // 
            // sexLbl
            // 
            this.sexLbl.AutoSize = true;
            this.sexLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sexLbl.Location = new System.Drawing.Point(389, 100);
            this.sexLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sexLbl.Name = "sexLbl";
            this.sexLbl.Size = new System.Drawing.Size(31, 16);
            this.sexLbl.TabIndex = 271;
            this.sexLbl.Text = "Sex";
            // 
            // address2Lbl
            // 
            this.address2Lbl.AutoSize = true;
            this.address2Lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address2Lbl.Location = new System.Drawing.Point(25, 271);
            this.address2Lbl.Name = "address2Lbl";
            this.address2Lbl.Size = new System.Drawing.Size(74, 16);
            this.address2Lbl.TabIndex = 308;
            this.address2Lbl.Text = "Address 2";
            // 
            // address2Ed
            // 
            this.address2Ed.BackColor = System.Drawing.SystemColors.Window;
            this.address2Ed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "address2", true));
            this.address2Ed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address2Ed.isToUpperCase = false;
            this.address2Ed.Location = new System.Drawing.Point(25, 290);
            this.address2Ed.Multiline = true;
            this.address2Ed.Name = "address2Ed";
            this.address2Ed.Size = new System.Drawing.Size(482, 40);
            this.address2Ed.TabIndex = 21;
            // 
            // countryCb
            // 
            this.countryCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.investorSource, "country", true));
            this.countryCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryCb.FormattingEnabled = true;
            this.countryCb.Location = new System.Drawing.Point(24, 358);
            this.countryCb.myValue = "";
            this.countryCb.Name = "countryCb";
            this.countryCb.Size = new System.Drawing.Size(251, 24);
            this.countryCb.TabIndex = 40;
            // 
            // countryLbl
            // 
            this.countryLbl.AutoSize = true;
            this.countryLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLbl.Location = new System.Drawing.Point(24, 339);
            this.countryLbl.Name = "countryLbl";
            this.countryLbl.Size = new System.Drawing.Size(77, 16);
            this.countryLbl.TabIndex = 309;
            this.countryLbl.Text = "Nationality";
            // 
            // emailEd
            // 
            this.emailEd.BackColor = System.Drawing.SystemColors.Window;
            this.emailEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "email", true));
            this.emailEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailEd.isToUpperCase = false;
            this.emailEd.Location = new System.Drawing.Point(268, 408);
            this.emailEd.Name = "emailEd";
            this.emailEd.Size = new System.Drawing.Size(241, 22);
            this.emailEd.TabIndex = 43;
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLbl.Location = new System.Drawing.Point(268, 389);
            this.emailLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(52, 16);
            this.emailLbl.TabIndex = 312;
            this.emailLbl.Text = "Email *";
            // 
            // accountLbl
            // 
            this.accountLbl.AutoSize = true;
            this.accountLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountLbl.Location = new System.Drawing.Point(25, 47);
            this.accountLbl.Name = "accountLbl";
            this.accountLbl.Size = new System.Drawing.Size(62, 16);
            this.accountLbl.TabIndex = 314;
            this.accountLbl.Text = "Account";
            // 
            // accountEd
            // 
            this.accountEd.BackColor = System.Drawing.SystemColors.Window;
            this.accountEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "account", true));
            this.accountEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountEd.isToUpperCase = false;
            this.accountEd.Location = new System.Drawing.Point(25, 66);
            this.accountEd.Name = "accountEd";
            this.accountEd.Size = new System.Drawing.Size(137, 24);
            this.accountEd.TabIndex = 5;
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.Location = new System.Drawing.Point(265, 47);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(83, 16);
            this.passwordLbl.TabIndex = 316;
            this.passwordLbl.Text = "Password *";
            // 
            // passwordEd
            // 
            this.passwordEd.BackColor = System.Drawing.SystemColors.Window;
            this.passwordEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "password", true));
            this.passwordEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordEd.isToUpperCase = false;
            this.passwordEd.Location = new System.Drawing.Point(265, 66);
            this.passwordEd.Name = "passwordEd";
            this.passwordEd.PasswordChar = '*';
            this.passwordEd.Size = new System.Drawing.Size(124, 24);
            this.passwordEd.TabIndex = 6;
            // 
            // statusCb
            // 
            this.statusCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.investorSource, "status", true));
            this.statusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCb.FormattingEnabled = true;
            this.statusCb.Location = new System.Drawing.Point(406, 461);
            this.statusCb.myValue = commonClass.AppTypes.CommonStatus.None;
            this.statusCb.Name = "statusCb";
            this.statusCb.SelectedValue = ((byte)(0));
            this.statusCb.Size = new System.Drawing.Size(103, 24);
            this.statusCb.TabIndex = 52;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(408, 442);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(63, 16);
            this.statusLbl.TabIndex = 318;
            this.statusLbl.Text = "Status *";
            // 
            // portfolioSource
            // 
            this.portfolioSource.DataMember = "portfolio";
            this.portfolioSource.DataSource = this.myDataSet;
            // 
            // expireDateEd
            // 
            this.expireDateEd.BackColor = System.Drawing.SystemColors.Window;
            this.expireDateEd.BeepOnError = true;
            this.expireDateEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "expireDate", true));
            this.expireDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.expireDateEd.Location = new System.Drawing.Point(307, 461);
            this.expireDateEd.Margin = new System.Windows.Forms.Padding(4);
            this.expireDateEd.Mask = "00/00/0000";
            this.expireDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.expireDateEd.Name = "expireDateEd";
            this.expireDateEd.Size = new System.Drawing.Size(99, 23);
            this.expireDateEd.TabIndex = 50;
            // 
            // expireDateLbl
            // 
            this.expireDateLbl.AutoSize = true;
            this.expireDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expireDateLbl.Location = new System.Drawing.Point(307, 442);
            this.expireDateLbl.Name = "expireDateLbl";
            this.expireDateLbl.Size = new System.Drawing.Size(87, 16);
            this.expireDateLbl.TabIndex = 322;
            this.expireDateLbl.Text = "Expired on *";
            // 
            // investorCatLbl
            // 
            this.investorCatLbl.AutoSize = true;
            this.investorCatLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.investorCatLbl.Location = new System.Drawing.Point(24, 441);
            this.investorCatLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.investorCatLbl.Name = "investorCatLbl";
            this.investorCatLbl.Size = new System.Drawing.Size(80, 16);
            this.investorCatLbl.TabIndex = 320;
            this.investorCatLbl.Text = "Category *";
            // 
            // investorCatCb
            // 
            this.investorCatCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.investorSource, "catCode", true));
            this.investorCatCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.investorCatCb.FormattingEnabled = true;
            this.investorCatCb.Location = new System.Drawing.Point(24, 461);
            this.investorCatCb.myValue = "";
            this.investorCatCb.Name = "investorCatCb";
            this.investorCatCb.Size = new System.Drawing.Size(285, 24);
            this.investorCatCb.TabIndex = 51;
            // 
            // phoneEd
            // 
            this.phoneEd.BackColor = System.Drawing.SystemColors.Window;
            this.phoneEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "phone", true));
            this.phoneEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneEd.isToUpperCase = false;
            this.phoneEd.Location = new System.Drawing.Point(24, 408);
            this.phoneEd.Name = "phoneEd";
            this.phoneEd.Size = new System.Drawing.Size(119, 22);
            this.phoneEd.TabIndex = 41;
            // 
            // phoneLbl
            // 
            this.phoneLbl.AutoSize = true;
            this.phoneLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLbl.Location = new System.Drawing.Point(24, 389);
            this.phoneLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phoneLbl.Name = "phoneLbl";
            this.phoneLbl.Size = new System.Drawing.Size(48, 16);
            this.phoneLbl.TabIndex = 310;
            this.phoneLbl.Text = "Phone";
            // 
            // infoPnl
            // 
            this.infoPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.infoPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.infoPnl.Controls.Add(this.displayNameLbl);
            this.infoPnl.Controls.Add(this.mobileLbl);
            this.infoPnl.Controls.Add(this.mobileEd);
            this.infoPnl.Controls.Add(this.noteLbl);
            this.infoPnl.Controls.Add(this.noteEd);
            this.infoPnl.Controls.Add(this.passwordEd2);
            this.infoPnl.Controls.Add(this.watchListBtn);
            this.infoPnl.Controls.Add(this.portfolioBtn);
            this.infoPnl.Controls.Add(this.displayNameEd);
            this.infoPnl.Controls.Add(this.expireDateEd);
            this.infoPnl.Controls.Add(this.accountLbl);
            this.infoPnl.Controls.Add(this.expireDateLbl);
            this.infoPnl.Controls.Add(this.phoneLbl);
            this.infoPnl.Controls.Add(this.investorCatLbl);
            this.infoPnl.Controls.Add(this.phoneEd);
            this.infoPnl.Controls.Add(this.investorCatCb);
            this.infoPnl.Controls.Add(this.emailLbl);
            this.infoPnl.Controls.Add(this.passwordLbl);
            this.infoPnl.Controls.Add(this.sexLbl);
            this.infoPnl.Controls.Add(this.statusLbl);
            this.infoPnl.Controls.Add(this.emailEd);
            this.infoPnl.Controls.Add(this.nameLbl);
            this.infoPnl.Controls.Add(this.sexCb);
            this.infoPnl.Controls.Add(this.statusCb);
            this.infoPnl.Controls.Add(this.countryLbl);
            this.infoPnl.Controls.Add(this.firstNameEd);
            this.infoPnl.Controls.Add(this.codeEd);
            this.infoPnl.Controls.Add(this.countryCb);
            this.infoPnl.Controls.Add(this.passwordEd);
            this.infoPnl.Controls.Add(this.address1Lbl);
            this.infoPnl.Controls.Add(this.lastNameLbl);
            this.infoPnl.Controls.Add(this.address2Ed);
            this.infoPnl.Controls.Add(this.lastNameEd);
            this.infoPnl.Controls.Add(this.address2Lbl);
            this.infoPnl.Controls.Add(this.accountEd);
            this.infoPnl.Controls.Add(this.address1Ed);
            this.infoPnl.Location = new System.Drawing.Point(0, 44);
            this.infoPnl.Name = "infoPnl";
            this.infoPnl.Size = new System.Drawing.Size(530, 606);
            this.infoPnl.TabIndex = 0;
            // 
            // displayNameLbl
            // 
            this.displayNameLbl.AutoSize = true;
            this.displayNameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayNameLbl.Location = new System.Drawing.Point(25, 150);
            this.displayNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.displayNameLbl.Name = "displayNameLbl";
            this.displayNameLbl.Size = new System.Drawing.Size(93, 16);
            this.displayNameLbl.TabIndex = 328;
            this.displayNameLbl.Text = "Display name";
            // 
            // mobileLbl
            // 
            this.mobileLbl.AutoSize = true;
            this.mobileLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobileLbl.Location = new System.Drawing.Point(146, 389);
            this.mobileLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mobileLbl.Name = "mobileLbl";
            this.mobileLbl.Size = new System.Drawing.Size(49, 16);
            this.mobileLbl.TabIndex = 327;
            this.mobileLbl.Text = "Mobile";
            // 
            // mobileEd
            // 
            this.mobileEd.BackColor = System.Drawing.SystemColors.Window;
            this.mobileEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "mobile", true));
            this.mobileEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobileEd.isToUpperCase = false;
            this.mobileEd.Location = new System.Drawing.Point(143, 408);
            this.mobileEd.Margin = new System.Windows.Forms.Padding(4);
            this.mobileEd.Name = "mobileEd";
            this.mobileEd.Size = new System.Drawing.Size(125, 22);
            this.mobileEd.TabIndex = 42;
            // 
            // noteLbl
            // 
            this.noteLbl.AutoSize = true;
            this.noteLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(24, 495);
            this.noteLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(45, 16);
            this.noteLbl.TabIndex = 325;
            this.noteLbl.Text = "Notes";
            // 
            // noteEd
            // 
            this.noteEd.BackColor = System.Drawing.SystemColors.Window;
            this.noteEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteEd.isToUpperCase = false;
            this.noteEd.Location = new System.Drawing.Point(24, 514);
            this.noteEd.Margin = new System.Windows.Forms.Padding(4);
            this.noteEd.Multiline = true;
            this.noteEd.Name = "noteEd";
            this.noteEd.Size = new System.Drawing.Size(483, 82);
            this.noteEd.TabIndex = 60;
            // 
            // passwordEd2
            // 
            this.passwordEd2.BackColor = System.Drawing.SystemColors.Window;
            this.passwordEd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordEd2.isToUpperCase = false;
            this.passwordEd2.Location = new System.Drawing.Point(389, 66);
            this.passwordEd2.Margin = new System.Windows.Forms.Padding(4);
            this.passwordEd2.Name = "passwordEd2";
            this.passwordEd2.PasswordChar = '*';
            this.passwordEd2.Size = new System.Drawing.Size(119, 24);
            this.passwordEd2.TabIndex = 7;
            // 
            // watchListBtn
            // 
            this.watchListBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.watchListBtn.Image = global::baseClass.Properties.Resources.glasses;
            this.watchListBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.watchListBtn.isDownState = false;
            this.watchListBtn.Location = new System.Drawing.Point(136, 6);
            this.watchListBtn.Name = "watchListBtn";
            this.watchListBtn.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.watchListBtn.Size = new System.Drawing.Size(119, 31);
            this.watchListBtn.TabIndex = 2;
            this.watchListBtn.Text = "Watch List";
            this.watchListBtn.UseVisualStyleBackColor = true;
            this.watchListBtn.Click += new System.EventHandler(this.watchListBtn_Click);
            // 
            // portfolioBtn
            // 
            this.portfolioBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioBtn.Image = global::baseClass.Properties.Resources.book;
            this.portfolioBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.portfolioBtn.isDownState = false;
            this.portfolioBtn.Location = new System.Drawing.Point(23, 6);
            this.portfolioBtn.Name = "portfolioBtn";
            this.portfolioBtn.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.portfolioBtn.Size = new System.Drawing.Size(113, 31);
            this.portfolioBtn.TabIndex = 1;
            this.portfolioBtn.Text = "Portfolio";
            this.portfolioBtn.UseVisualStyleBackColor = true;
            this.portfolioBtn.Click += new System.EventHandler(this.portfolioBtn_Click);
            // 
            // displayNameEd
            // 
            this.displayNameEd.BackColor = System.Drawing.SystemColors.Window;
            this.displayNameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "displayName", true));
            this.displayNameEd.Enabled = false;
            this.displayNameEd.isToUpperCase = false;
            this.displayNameEd.Location = new System.Drawing.Point(24, 169);
            this.displayNameEd.Name = "displayNameEd";
            this.displayNameEd.Size = new System.Drawing.Size(251, 23);
            this.displayNameEd.TabIndex = 14;
            // 
            // watchListSource
            // 
            this.watchListSource.DataMember = "portfolio";
            this.watchListSource.DataSource = this.myDataSet;
            // 
            // investorEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(530, 677);
            this.Controls.Add(this.infoPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "investorEdit";
            this.Tag = "";
            this.Text = "Investor";
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.infoPnl, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).EndInit();
            this.infoPnl.ResumeLayout(false);
            this.infoPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watchListSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseButton checkIdCardBtn;
        protected common.controls.baseTextBox codeEd;
        protected common.controls.baseTextBox firstNameEd;
        protected baseClass.controls.baseLabel nameLbl;
        protected common.controls.baseTextBox lastNameEd;
        protected baseClass.controls.baseLabel lastNameLbl;
        protected common.controls.baseTextBox address1Ed;
        protected baseClass.controls.baseLabel address1Lbl;
        protected baseClass.controls.baseLabel sexLbl;
        protected baseClass.controls.baseLabel address2Lbl;
        protected common.controls.baseTextBox address2Ed;
        protected baseClass.controls.baseLabel countryLbl;
        protected common.controls.baseTextBox emailEd;
        protected baseClass.controls.baseLabel emailLbl;
        protected baseClass.controls.baseLabel accountLbl;
        protected common.controls.baseTextBox accountEd;
        protected baseClass.controls.baseLabel passwordLbl;
        protected common.controls.baseTextBox passwordEd;
        protected baseClass.controls.baseLabel statusLbl;
        protected baseClass.controls.baseLabel investorCatLbl;
        protected common.controls.baseDate expireDateEd;
        protected baseClass.controls.baseLabel expireDateLbl;
        protected common.controls.baseTextBox phoneEd;
        protected baseClass.controls.baseLabel phoneLbl;
        protected controls.cbCountry countryCb;
        protected controls.cbInvestorCat investorCatCb;
        protected controls.cbCommonStatus statusCb;
        protected baseClass.controls.cbSex sexCb;
        protected System.Windows.Forms.BindingSource portfolioSource;
        protected System.Windows.Forms.BindingSource watchListSource;
        protected common.controls.baseTextBox displayNameEd;
        protected System.Windows.Forms.Panel infoPnl;
        protected common.controls.baseButton portfolioBtn;
        protected common.controls.baseButton watchListBtn;
        protected common.controls.baseTextBox passwordEd2;
        protected baseClass.controls.baseLabel noteLbl;
        protected common.controls.baseTextBox noteEd;
        protected System.Windows.Forms.BindingSource investorSource;
        protected baseClass.controls.baseLabel mobileLbl;
        protected common.controls.baseTextBox mobileEd;
        protected baseClass.controls.baseLabel displayNameLbl;
    }
}