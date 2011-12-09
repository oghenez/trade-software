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
            this.investorSource = new System.Windows.Forms.BindingSource(this.components);
            this.codeEd = new common.controls.baseTextBox();
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
            this.toolBox.Controls.Add(this.watchListBtn);
            this.toolBox.Controls.Add(this.portfolioBtn);
            this.toolBox.Location = new System.Drawing.Point(-31, -5);
            this.toolBox.Size = new System.Drawing.Size(599, 49);
            this.toolBox.Controls.SetChildIndex(this.portfolioBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.editBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.watchListBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.exitBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.printBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.importBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.reloadBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.findBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.toExcelBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.deleteBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.saveBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.addNewBtn, 0);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(432, 7);
            this.exitBtn.Size = new System.Drawing.Size(73, 38);
            this.exitBtn.Text = "Close";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(106, 7);
            this.saveBtn.Size = new System.Drawing.Size(73, 38);
            this.saveBtn.Text = "Save";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(759, -1);
            this.deleteBtn.Visible = false;
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(179, 7);
            this.editBtn.Size = new System.Drawing.Size(73, 38);
            this.editBtn.Text = "&Edit";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(33, 7);
            this.addNewBtn.Size = new System.Drawing.Size(73, 38);
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(829, -1);
            this.toExcelBtn.Text = "Export";
            this.toExcelBtn.Visible = false;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(899, -1);
            this.findBtn.Visible = false;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(969, -1);
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
            this.printBtn.Location = new System.Drawing.Point(671, 0);
            this.printBtn.Size = new System.Drawing.Size(96, 38);
            this.printBtn.Text = "&Print";
            this.printBtn.Visible = false;
            // 
            // importBtn
            // 
            this.importBtn.Location = new System.Drawing.Point(977, -2);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Size = new System.Drawing.Size(525, 24);
            this.TitleLbl.TabIndex = 149;
            this.TitleLbl.Text = "THÔNG TIN DỰ ÁN";
            // 
            // investorSource
            // 
            this.investorSource.DataMember = "investor";
            this.investorSource.DataSource = this.myDataSet;
            this.investorSource.CurrentChanged += new System.EventHandler(this.investorSource_CurrentChanged);
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.SystemColors.Window;
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "code", true));
            this.codeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEd.isToUpperCase = false;
            this.codeEd.Location = new System.Drawing.Point(182, 32);
            this.codeEd.Margin = new System.Windows.Forms.Padding(4);
            this.codeEd.Name = "codeEd";
            this.codeEd.ReadOnly = true;
            this.codeEd.Size = new System.Drawing.Size(83, 24);
            this.codeEd.TabIndex = 3;
            this.codeEd.TabStop = false;
            // 
            // firstNameEd
            // 
            this.firstNameEd.BackColor = System.Drawing.SystemColors.Window;
            this.firstNameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "firstName", true));
            this.firstNameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameEd.isToUpperCase = false;
            this.firstNameEd.Location = new System.Drawing.Point(332, 132);
            this.firstNameEd.Margin = new System.Windows.Forms.Padding(4);
            this.firstNameEd.Name = "firstNameEd";
            this.firstNameEd.Size = new System.Drawing.Size(128, 22);
            this.firstNameEd.TabIndex = 11;
            this.firstNameEd.Validated += new System.EventHandler(this.firstNameEd_Validated);
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(331, 113);
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
            this.lastNameEd.Location = new System.Drawing.Point(26, 132);
            this.lastNameEd.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameEd.Name = "lastNameEd";
            this.lastNameEd.Size = new System.Drawing.Size(307, 22);
            this.lastNameEd.TabIndex = 10;
            this.lastNameEd.TextChanged += new System.EventHandler(this.lastNameEd_TextChanged);
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.AutoSize = true;
            this.lastNameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLbl.Location = new System.Drawing.Point(26, 112);
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
            this.address1Ed.Location = new System.Drawing.Point(26, 230);
            this.address1Ed.Margin = new System.Windows.Forms.Padding(4);
            this.address1Ed.Name = "address1Ed";
            this.address1Ed.Size = new System.Drawing.Size(435, 22);
            this.address1Ed.TabIndex = 20;
            // 
            // address1Lbl
            // 
            this.address1Lbl.AutoSize = true;
            this.address1Lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Lbl.Location = new System.Drawing.Point(26, 211);
            this.address1Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.address1Lbl.Name = "address1Lbl";
            this.address1Lbl.Size = new System.Drawing.Size(86, 16);
            this.address1Lbl.TabIndex = 269;
            this.address1Lbl.Text = "Address 1 *";
            // 
            // sexCb
            // 
            this.sexCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexCb.FormattingEnabled = true;
            this.sexCb.Location = new System.Drawing.Point(26, 180);
            this.sexCb.myValue = application.AppTypes.Sex.None;
            this.sexCb.Name = "sexCb";
            this.sexCb.SelectedValue = ((byte)(0));
            this.sexCb.Size = new System.Drawing.Size(159, 21);
            this.sexCb.TabIndex = 12;
            // 
            // sexLbl
            // 
            this.sexLbl.AutoSize = true;
            this.sexLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sexLbl.Location = new System.Drawing.Point(26, 161);
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
            this.address2Lbl.Location = new System.Drawing.Point(26, 259);
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
            this.address2Ed.Location = new System.Drawing.Point(26, 278);
            this.address2Ed.Name = "address2Ed";
            this.address2Ed.Size = new System.Drawing.Size(435, 22);
            this.address2Ed.TabIndex = 21;
            // 
            // countryCb
            // 
            this.countryCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.investorSource, "country", true));
            this.countryCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryCb.FormattingEnabled = true;
            this.countryCb.Location = new System.Drawing.Point(26, 326);
            this.countryCb.myValue = "";
            this.countryCb.Name = "countryCb";
            this.countryCb.Size = new System.Drawing.Size(307, 21);
            this.countryCb.TabIndex = 40;
            // 
            // countryLbl
            // 
            this.countryLbl.AutoSize = true;
            this.countryLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLbl.Location = new System.Drawing.Point(26, 307);
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
            this.emailEd.Location = new System.Drawing.Point(26, 424);
            this.emailEd.Name = "emailEd";
            this.emailEd.Size = new System.Drawing.Size(435, 22);
            this.emailEd.TabIndex = 42;
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLbl.Location = new System.Drawing.Point(26, 405);
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
            this.accountLbl.Location = new System.Drawing.Point(26, 13);
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
            this.accountEd.Location = new System.Drawing.Point(26, 32);
            this.accountEd.Name = "accountEd";
            this.accountEd.Size = new System.Drawing.Size(157, 24);
            this.accountEd.TabIndex = 1;
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.Location = new System.Drawing.Point(26, 63);
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
            this.passwordEd.Location = new System.Drawing.Point(26, 82);
            this.passwordEd.Name = "passwordEd";
            this.passwordEd.PasswordChar = '*';
            this.passwordEd.Size = new System.Drawing.Size(153, 24);
            this.passwordEd.TabIndex = 2;
            // 
            // statusCb
            // 
            this.statusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCb.FormattingEnabled = true;
            this.statusCb.Location = new System.Drawing.Point(362, 476);
            this.statusCb.myValue = application.AppTypes.CommonStatus.None;
            this.statusCb.Name = "statusCb";
            this.statusCb.SelectedValue = ((byte)(0));
            this.statusCb.Size = new System.Drawing.Size(99, 21);
            this.statusCb.TabIndex = 52;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(364, 456);
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
            this.expireDateEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "phone", true));
            this.expireDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expireDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.expireDateEd.Location = new System.Drawing.Point(263, 475);
            this.expireDateEd.Margin = new System.Windows.Forms.Padding(4);
            this.expireDateEd.Mask = "00/00/0000";
            this.expireDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.expireDateEd.Name = "expireDateEd";
            this.expireDateEd.Size = new System.Drawing.Size(99, 22);
            this.expireDateEd.TabIndex = 50;
            // 
            // expireDateLbl
            // 
            this.expireDateLbl.AutoSize = true;
            this.expireDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expireDateLbl.Location = new System.Drawing.Point(263, 456);
            this.expireDateLbl.Name = "expireDateLbl";
            this.expireDateLbl.Size = new System.Drawing.Size(87, 16);
            this.expireDateLbl.TabIndex = 322;
            this.expireDateLbl.Text = "Expired on *";
            // 
            // investorCatLbl
            // 
            this.investorCatLbl.AutoSize = true;
            this.investorCatLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.investorCatLbl.Location = new System.Drawing.Point(26, 456);
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
            this.investorCatCb.Location = new System.Drawing.Point(26, 475);
            this.investorCatCb.myValue = "";
            this.investorCatCb.Name = "investorCatCb";
            this.investorCatCb.Size = new System.Drawing.Size(239, 21);
            this.investorCatCb.TabIndex = 51;
            // 
            // phoneEd
            // 
            this.phoneEd.BackColor = System.Drawing.SystemColors.Window;
            this.phoneEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "phone", true));
            this.phoneEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneEd.isToUpperCase = false;
            this.phoneEd.Location = new System.Drawing.Point(26, 376);
            this.phoneEd.Margin = new System.Windows.Forms.Padding(4);
            this.phoneEd.Name = "phoneEd";
            this.phoneEd.Size = new System.Drawing.Size(102, 22);
            this.phoneEd.TabIndex = 41;
            // 
            // phoneLbl
            // 
            this.phoneLbl.AutoSize = true;
            this.phoneLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLbl.Location = new System.Drawing.Point(26, 357);
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
            this.infoPnl.Controls.Add(this.passwordEd2);
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
            this.infoPnl.Location = new System.Drawing.Point(-1, 50);
            this.infoPnl.Name = "infoPnl";
            this.infoPnl.Size = new System.Drawing.Size(485, 558);
            this.infoPnl.TabIndex = 0;
            // 
            // passwordEd2
            // 
            this.passwordEd2.BackColor = System.Drawing.SystemColors.Window;
            this.passwordEd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordEd2.isToUpperCase = false;
            this.passwordEd2.Location = new System.Drawing.Point(180, 82);
            this.passwordEd2.Margin = new System.Windows.Forms.Padding(4);
            this.passwordEd2.Name = "passwordEd2";
            this.passwordEd2.PasswordChar = '*';
            this.passwordEd2.Size = new System.Drawing.Size(153, 24);
            this.passwordEd2.TabIndex = 3;
            // 
            // watchListBtn
            // 
            this.watchListBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.watchListBtn.Image = global::baseClass.Properties.Resources.glasses;
            this.watchListBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.watchListBtn.isDownState = false;
            this.watchListBtn.Location = new System.Drawing.Point(342, 7);
            this.watchListBtn.Name = "watchListBtn";
            this.watchListBtn.Size = new System.Drawing.Size(90, 38);
            this.watchListBtn.TabIndex = 6;
            this.watchListBtn.Text = "Watch List";
            this.watchListBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.watchListBtn.UseVisualStyleBackColor = true;
            this.watchListBtn.Click += new System.EventHandler(this.watchListBtn_Click);
            // 
            // portfolioBtn
            // 
            this.portfolioBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portfolioBtn.Image = global::baseClass.Properties.Resources.book;
            this.portfolioBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.portfolioBtn.isDownState = false;
            this.portfolioBtn.Location = new System.Drawing.Point(252, 7);
            this.portfolioBtn.Name = "portfolioBtn";
            this.portfolioBtn.Size = new System.Drawing.Size(90, 38);
            this.portfolioBtn.TabIndex = 5;
            this.portfolioBtn.Text = "Portfolio";
            this.portfolioBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.portfolioBtn.UseVisualStyleBackColor = true;
            this.portfolioBtn.Click += new System.EventHandler(this.portfolioBtn_Click);
            // 
            // displayNameEd
            // 
            this.displayNameEd.BackColor = System.Drawing.SystemColors.Window;
            this.displayNameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "lastName", true));
            this.displayNameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayNameEd.isToUpperCase = false;
            this.displayNameEd.Location = new System.Drawing.Point(565, 76);
            this.displayNameEd.Margin = new System.Windows.Forms.Padding(4);
            this.displayNameEd.Name = "displayNameEd";
            this.displayNameEd.Size = new System.Drawing.Size(143, 22);
            this.displayNameEd.TabIndex = 323;
            this.displayNameEd.Visible = false;
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
            this.ClientSize = new System.Drawing.Size(484, 636);
            this.Controls.Add(this.infoPnl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        protected System.Windows.Forms.BindingSource investorSource;
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
    }
}