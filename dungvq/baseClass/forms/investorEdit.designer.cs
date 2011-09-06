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
            this.codeEd = new common.control.baseTextBox();
            this.firstNameEd = new common.control.baseTextBox();
            this.nameLbl = new baseClass.controls.baseLabel();
            this.lastNameEd = new common.control.baseTextBox();
            this.lastNameLbl = new baseClass.controls.baseLabel();
            this.address1Ed = new common.control.baseTextBox();
            this.address1Lbl = new baseClass.controls.baseLabel();
            this.sexCb = new baseClass.controls.cbSex();
            this.baseLabel4 = new baseClass.controls.baseLabel();
            this.address2Lbl = new baseClass.controls.baseLabel();
            this.address2Ed = new common.control.baseTextBox();
            this.countryCb = new baseClass.controls.cbCountry();
            this.countryLbl = new baseClass.controls.baseLabel();
            this.emailEd = new common.control.baseTextBox();
            this.emailLbl = new baseClass.controls.baseLabel();
            this.accountLbl = new baseClass.controls.baseLabel();
            this.accountEd = new common.control.baseTextBox();
            this.passwordLbl = new baseClass.controls.baseLabel();
            this.passwordEd = new common.control.baseTextBox();
            this.statusCb = new baseClass.controls.cbCommonStatus();
            this.statusLbl = new baseClass.controls.baseLabel();
            this.portfolioSource = new System.Windows.Forms.BindingSource(this.components);
            this.expireDateEd = new common.control.baseDate();
            this.expireDatelbl = new baseClass.controls.baseLabel();
            this.investorCatLbl = new baseClass.controls.baseLabel();
            this.investorCatCb = new baseClass.controls.cbInvestorCat();
            this.phoneEd = new common.control.baseTextBox();
            this.phoneLbl = new baseClass.controls.baseLabel();
            this.infoPnl = new System.Windows.Forms.Panel();
            this.displayNameEd = new common.control.baseTextBox();
            this.watchListSource = new System.Windows.Forms.BindingSource(this.components);
            this.addWatchListBtn = new baseClass.controls.baseButton();
            this.watchListGrid = new common.control.baseDataGridView();
            this.watchListCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.watchListNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.watchListEditColumn = new common.control.gridViewImageColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.portfolioPg = new System.Windows.Forms.TabPage();
            this.addPortfolioBtn = new baseClass.controls.baseButton();
            this.portfolioGrid = new common.control.baseDataGridView();
            this.portfolioCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portfolioNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portfolioEditColumn = new common.control.gridViewImageColumn();
            this.watchListPg = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).BeginInit();
            this.infoPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watchListSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchListGrid)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.portfolioPg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioGrid)).BeginInit();
            this.watchListPg.SuspendLayout();
            this.SuspendLayout();
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myBaseDS";
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-31, -5);
            this.toolBox.Size = new System.Drawing.Size(1167, 49);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(416, 7);
            this.exitBtn.Size = new System.Drawing.Size(96, 38);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(128, 7);
            this.saveBtn.Size = new System.Drawing.Size(96, 38);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(562, 6);
            this.deleteBtn.Visible = false;
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(224, 7);
            this.editBtn.Size = new System.Drawing.Size(96, 38);
            this.editBtn.Text = "&Xem";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(32, 7);
            this.addNewBtn.Size = new System.Drawing.Size(96, 38);
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(632, 6);
            this.toExcelBtn.Visible = false;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(702, 6);
            this.findBtn.Visible = false;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(772, 6);
            this.reloadBtn.Visible = false;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(320, 7);
            this.printBtn.Size = new System.Drawing.Size(96, 38);
            // 
            // unLockBtn
            // 
            this.unLockBtn.Location = new System.Drawing.Point(1174, 292);
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(1174, 251);
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
            this.codeEd.Location = new System.Drawing.Point(339, 28);
            this.codeEd.Margin = new System.Windows.Forms.Padding(4);
            this.codeEd.Name = "codeEd";
            this.codeEd.ReadOnly = true;
            this.codeEd.Size = new System.Drawing.Size(122, 24);
            this.codeEd.TabIndex = 3;
            this.codeEd.TabStop = false;
            // 
            // firstNameEd
            // 
            this.firstNameEd.BackColor = System.Drawing.SystemColors.Window;
            this.firstNameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "firstName", true));
            this.firstNameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameEd.Location = new System.Drawing.Point(293, 76);
            this.firstNameEd.Margin = new System.Windows.Forms.Padding(4);
            this.firstNameEd.Name = "firstNameEd";
            this.firstNameEd.Size = new System.Drawing.Size(88, 22);
            this.firstNameEd.TabIndex = 11;
            this.firstNameEd.Validated += new System.EventHandler(this.firstNameEd_Validated);
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(293, 55);
            this.nameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(43, 16);
            this.nameLbl.TabIndex = 257;
            this.nameLbl.Text = "Tên *";
            // 
            // lastNameEd
            // 
            this.lastNameEd.BackColor = System.Drawing.SystemColors.Window;
            this.lastNameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "lastName", true));
            this.lastNameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameEd.Location = new System.Drawing.Point(26, 76);
            this.lastNameEd.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameEd.Name = "lastNameEd";
            this.lastNameEd.Size = new System.Drawing.Size(268, 22);
            this.lastNameEd.TabIndex = 10;
            this.lastNameEd.TextChanged += new System.EventHandler(this.lastNameEd_TextChanged);
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.AutoSize = true;
            this.lastNameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLbl.Location = new System.Drawing.Point(25, 56);
            this.lastNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastNameLbl.Name = "lastNameLbl";
            this.lastNameLbl.Size = new System.Drawing.Size(78, 16);
            this.lastNameLbl.TabIndex = 265;
            this.lastNameLbl.Text = "Họ và lót *";
            // 
            // address1Ed
            // 
            this.address1Ed.BackColor = System.Drawing.SystemColors.Window;
            this.address1Ed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "address1", true));
            this.address1Ed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Ed.Location = new System.Drawing.Point(26, 122);
            this.address1Ed.Margin = new System.Windows.Forms.Padding(4);
            this.address1Ed.Name = "address1Ed";
            this.address1Ed.Size = new System.Drawing.Size(435, 22);
            this.address1Ed.TabIndex = 20;
            // 
            // address1Lbl
            // 
            this.address1Lbl.AutoSize = true;
            this.address1Lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Lbl.Location = new System.Drawing.Point(26, 102);
            this.address1Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.address1Lbl.Name = "address1Lbl";
            this.address1Lbl.Size = new System.Drawing.Size(75, 16);
            this.address1Lbl.TabIndex = 269;
            this.address1Lbl.Text = "Địa chỉ 1 *";
            // 
            // sexCb
            // 
            this.sexCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexCb.FormattingEnabled = true;
            this.sexCb.Location = new System.Drawing.Point(381, 76);
            this.sexCb.myValue = application.myTypes.sex.None;
            this.sexCb.Name = "sexCb";
            this.sexCb.SelectedValue = ((byte)(0));
            this.sexCb.Size = new System.Drawing.Size(80, 21);
            this.sexCb.TabIndex = 12;
            // 
            // baseLabel4
            // 
            this.baseLabel4.AutoSize = true;
            this.baseLabel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel4.Location = new System.Drawing.Point(382, 57);
            this.baseLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.baseLabel4.Name = "baseLabel4";
            this.baseLabel4.Size = new System.Drawing.Size(59, 16);
            this.baseLabel4.TabIndex = 271;
            this.baseLabel4.Text = "Giới tính";
            // 
            // address2Lbl
            // 
            this.address2Lbl.AutoSize = true;
            this.address2Lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address2Lbl.Location = new System.Drawing.Point(26, 148);
            this.address2Lbl.Name = "address2Lbl";
            this.address2Lbl.Size = new System.Drawing.Size(63, 16);
            this.address2Lbl.TabIndex = 308;
            this.address2Lbl.Text = "Địa chỉ 2";
            // 
            // address2Ed
            // 
            this.address2Ed.BackColor = System.Drawing.SystemColors.Window;
            this.address2Ed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "address2", true));
            this.address2Ed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address2Ed.Location = new System.Drawing.Point(26, 168);
            this.address2Ed.Name = "address2Ed";
            this.address2Ed.Size = new System.Drawing.Size(435, 22);
            this.address2Ed.TabIndex = 21;
            // 
            // countryCb
            // 
            this.countryCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.investorSource, "country", true));
            this.countryCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryCb.FormattingEnabled = true;
            this.countryCb.Location = new System.Drawing.Point(26, 214);
            this.countryCb.myValue = "";
            this.countryCb.Name = "countryCb";
            this.countryCb.Size = new System.Drawing.Size(435, 21);
            this.countryCb.TabIndex = 40;
            // 
            // countryLbl
            // 
            this.countryLbl.AutoSize = true;
            this.countryLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLbl.Location = new System.Drawing.Point(26, 194);
            this.countryLbl.Name = "countryLbl";
            this.countryLbl.Size = new System.Drawing.Size(63, 16);
            this.countryLbl.TabIndex = 309;
            this.countryLbl.Text = "Quốc gia";
            // 
            // emailEd
            // 
            this.emailEd.BackColor = System.Drawing.SystemColors.Window;
            this.emailEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "email", true));
            this.emailEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailEd.Location = new System.Drawing.Point(127, 262);
            this.emailEd.Name = "emailEd";
            this.emailEd.Size = new System.Drawing.Size(335, 22);
            this.emailEd.TabIndex = 42;
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLbl.Location = new System.Drawing.Point(129, 244);
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
            this.accountLbl.Location = new System.Drawing.Point(26, 8);
            this.accountLbl.Name = "accountLbl";
            this.accountLbl.Size = new System.Drawing.Size(81, 16);
            this.accountLbl.TabIndex = 314;
            this.accountLbl.Text = "Tài khỏan *";
            // 
            // accountEd
            // 
            this.accountEd.BackColor = System.Drawing.SystemColors.Window;
            this.accountEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "account", true));
            this.accountEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountEd.Location = new System.Drawing.Point(26, 28);
            this.accountEd.Name = "accountEd";
            this.accountEd.Size = new System.Drawing.Size(157, 24);
            this.accountEd.TabIndex = 1;
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.Location = new System.Drawing.Point(182, 8);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(80, 16);
            this.passwordLbl.TabIndex = 316;
            this.passwordLbl.Text = "Mật khẩu *";
            // 
            // passwordEd
            // 
            this.passwordEd.BackColor = System.Drawing.SystemColors.Window;
            this.passwordEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "password", true));
            this.passwordEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordEd.Location = new System.Drawing.Point(183, 28);
            this.passwordEd.Margin = new System.Windows.Forms.Padding(4);
            this.passwordEd.Name = "passwordEd";
            this.passwordEd.PasswordChar = '*';
            this.passwordEd.Size = new System.Drawing.Size(156, 24);
            this.passwordEd.TabIndex = 2;
            // 
            // statusCb
            // 
            this.statusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCb.FormattingEnabled = true;
            this.statusCb.Location = new System.Drawing.Point(349, 309);
            this.statusCb.myValue = application.myTypes.CommonStatus.None;
            this.statusCb.Name = "statusCb";
            this.statusCb.SelectedValue = ((byte)(0));
            this.statusCb.Size = new System.Drawing.Size(112, 21);
            this.statusCb.TabIndex = 52;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(345, 290);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(86, 16);
            this.statusLbl.TabIndex = 318;
            this.statusLbl.Text = "Tình trạng *";
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
            this.expireDateEd.Location = new System.Drawing.Point(26, 308);
            this.expireDateEd.Margin = new System.Windows.Forms.Padding(4);
            this.expireDateEd.Mask = "00/00/0000";
            this.expireDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.expireDateEd.Name = "expireDateEd";
            this.expireDateEd.Size = new System.Drawing.Size(99, 22);
            this.expireDateEd.TabIndex = 50;
            // 
            // expireDatelbl
            // 
            this.expireDatelbl.AutoSize = true;
            this.expireDatelbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expireDatelbl.Location = new System.Drawing.Point(24, 288);
            this.expireDatelbl.Name = "expireDatelbl";
            this.expireDatelbl.Size = new System.Drawing.Size(71, 16);
            this.expireDatelbl.TabIndex = 322;
            this.expireDatelbl.Text = "Hết hạn *";
            // 
            // investorCatLbl
            // 
            this.investorCatLbl.AutoSize = true;
            this.investorCatLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.investorCatLbl.Location = new System.Drawing.Point(128, 291);
            this.investorCatLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.investorCatLbl.Name = "investorCatLbl";
            this.investorCatLbl.Size = new System.Drawing.Size(78, 16);
            this.investorCatLbl.TabIndex = 320;
            this.investorCatLbl.Text = "Phân lọai *";
            // 
            // investorCatCb
            // 
            this.investorCatCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.investorSource, "catCode", true));
            this.investorCatCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.investorCatCb.FormattingEnabled = true;
            this.investorCatCb.Location = new System.Drawing.Point(126, 309);
            this.investorCatCb.myValue = "";
            this.investorCatCb.Name = "investorCatCb";
            this.investorCatCb.Size = new System.Drawing.Size(225, 21);
            this.investorCatCb.TabIndex = 51;
            // 
            // phoneEd
            // 
            this.phoneEd.BackColor = System.Drawing.SystemColors.Window;
            this.phoneEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "phone", true));
            this.phoneEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneEd.Location = new System.Drawing.Point(25, 262);
            this.phoneEd.Margin = new System.Windows.Forms.Padding(4);
            this.phoneEd.Name = "phoneEd";
            this.phoneEd.Size = new System.Drawing.Size(102, 22);
            this.phoneEd.TabIndex = 41;
            // 
            // phoneLbl
            // 
            this.phoneLbl.AutoSize = true;
            this.phoneLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLbl.Location = new System.Drawing.Point(25, 242);
            this.phoneLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phoneLbl.Name = "phoneLbl";
            this.phoneLbl.Size = new System.Drawing.Size(74, 16);
            this.phoneLbl.TabIndex = 310;
            this.phoneLbl.Text = "Điện thọai";
            // 
            // infoPnl
            // 
            this.infoPnl.Controls.Add(this.displayNameEd);
            this.infoPnl.Controls.Add(this.expireDateEd);
            this.infoPnl.Controls.Add(this.accountLbl);
            this.infoPnl.Controls.Add(this.expireDatelbl);
            this.infoPnl.Controls.Add(this.phoneLbl);
            this.infoPnl.Controls.Add(this.investorCatLbl);
            this.infoPnl.Controls.Add(this.phoneEd);
            this.infoPnl.Controls.Add(this.investorCatCb);
            this.infoPnl.Controls.Add(this.emailLbl);
            this.infoPnl.Controls.Add(this.passwordLbl);
            this.infoPnl.Controls.Add(this.baseLabel4);
            this.infoPnl.Controls.Add(this.statusLbl);
            this.infoPnl.Controls.Add(this.emailEd);
            this.infoPnl.Controls.Add(this.nameLbl);
            this.infoPnl.Controls.Add(this.sexCb);
            this.infoPnl.Controls.Add(this.statusCb);
            this.infoPnl.Controls.Add(this.countryLbl);
            this.infoPnl.Controls.Add(this.firstNameEd);
            this.infoPnl.Controls.Add(this.address1Ed);
            this.infoPnl.Controls.Add(this.codeEd);
            this.infoPnl.Controls.Add(this.countryCb);
            this.infoPnl.Controls.Add(this.passwordEd);
            this.infoPnl.Controls.Add(this.address1Lbl);
            this.infoPnl.Controls.Add(this.lastNameLbl);
            this.infoPnl.Controls.Add(this.address2Ed);
            this.infoPnl.Controls.Add(this.lastNameEd);
            this.infoPnl.Controls.Add(this.address2Lbl);
            this.infoPnl.Controls.Add(this.accountEd);
            this.infoPnl.Location = new System.Drawing.Point(-1, 50);
            this.infoPnl.Name = "infoPnl";
            this.infoPnl.Size = new System.Drawing.Size(485, 340);
            this.infoPnl.TabIndex = 0;
            // 
            // displayNameEd
            // 
            this.displayNameEd.BackColor = System.Drawing.SystemColors.Window;
            this.displayNameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investorSource, "lastName", true));
            this.displayNameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // addWatchListBtn
            // 
            this.addWatchListBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addWatchListBtn.Image = global::baseClass.Properties.Resources.edit;
            this.addWatchListBtn.Location = new System.Drawing.Point(440, 1);
            this.addWatchListBtn.Margin = new System.Windows.Forms.Padding(0);
            this.addWatchListBtn.Name = "addWatchListBtn";
            this.addWatchListBtn.Size = new System.Drawing.Size(21, 21);
            this.addWatchListBtn.TabIndex = 1;
            this.addWatchListBtn.UseVisualStyleBackColor = true;
            this.addWatchListBtn.Click += new System.EventHandler(this.addWatchListBtn_Click);
            // 
            // watchListGrid
            // 
            this.watchListGrid.AllowUserToAddRows = false;
            this.watchListGrid.AllowUserToDeleteRows = false;
            this.watchListGrid.AutoGenerateColumns = false;
            this.watchListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.watchListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.watchListCodeColumn,
            this.watchListNameColumn,
            this.watchListEditColumn});
            this.watchListGrid.DataSource = this.watchListSource;
            this.watchListGrid.DisableReadOnlyColumn = true;
            this.watchListGrid.Location = new System.Drawing.Point(0, 0);
            this.watchListGrid.Name = "watchListGrid";
            this.watchListGrid.ReadOnly = true;
            this.watchListGrid.Size = new System.Drawing.Size(481, 166);
            this.watchListGrid.TabIndex = 10;
            this.watchListGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.watchListGrid_CellClick);
            this.watchListGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // watchListCodeColumn
            // 
            this.watchListCodeColumn.DataPropertyName = "code";
            this.watchListCodeColumn.HeaderText = "Mã số";
            this.watchListCodeColumn.Name = "watchListCodeColumn";
            this.watchListCodeColumn.ReadOnly = true;
            this.watchListCodeColumn.Width = 90;
            // 
            // watchListNameColumn
            // 
            this.watchListNameColumn.DataPropertyName = "name";
            this.watchListNameColumn.HeaderText = "Tên";
            this.watchListNameColumn.Name = "watchListNameColumn";
            this.watchListNameColumn.ReadOnly = true;
            this.watchListNameColumn.Width = 305;
            // 
            // watchListEditColumn
            // 
            this.watchListEditColumn.HeaderText = "";
            this.watchListEditColumn.myValue = "";
            this.watchListEditColumn.Name = "watchListEditColumn";
            this.watchListEditColumn.ReadOnly = true;
            this.watchListEditColumn.Width = 25;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.portfolioPg);
            this.tabControl1.Controls.Add(this.watchListPg);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 394);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(486, 194);
            this.tabControl1.TabIndex = 60;
            // 
            // portfolioPg
            // 
            this.portfolioPg.Controls.Add(this.addPortfolioBtn);
            this.portfolioPg.Controls.Add(this.portfolioGrid);
            this.portfolioPg.Location = new System.Drawing.Point(4, 25);
            this.portfolioPg.Name = "portfolioPg";
            this.portfolioPg.Padding = new System.Windows.Forms.Padding(3);
            this.portfolioPg.Size = new System.Drawing.Size(478, 165);
            this.portfolioPg.TabIndex = 0;
            this.portfolioPg.Text = "Portfolios";
            this.portfolioPg.UseVisualStyleBackColor = true;
            // 
            // addPortfolioBtn
            // 
            this.addPortfolioBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addPortfolioBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPortfolioBtn.Image = global::baseClass.Properties.Resources.edit;
            this.addPortfolioBtn.Location = new System.Drawing.Point(440, 1);
            this.addPortfolioBtn.Margin = new System.Windows.Forms.Padding(0);
            this.addPortfolioBtn.Name = "addPortfolioBtn";
            this.addPortfolioBtn.Size = new System.Drawing.Size(21, 21);
            this.addPortfolioBtn.TabIndex = 1;
            this.addPortfolioBtn.UseVisualStyleBackColor = true;
            this.addPortfolioBtn.Click += new System.EventHandler(this.addPortfolioBtn_Click);
            // 
            // portfolioGrid
            // 
            this.portfolioGrid.AllowUserToAddRows = false;
            this.portfolioGrid.AllowUserToDeleteRows = false;
            this.portfolioGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.portfolioGrid.AutoGenerateColumns = false;
            this.portfolioGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.portfolioGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.portfolioCodeColumn,
            this.portfolioNameColumn,
            this.portfolioEditColumn});
            this.portfolioGrid.DataSource = this.portfolioSource;
            this.portfolioGrid.DisableReadOnlyColumn = true;
            this.portfolioGrid.Location = new System.Drawing.Point(0, 0);
            this.portfolioGrid.Name = "portfolioGrid";
            this.portfolioGrid.ReadOnly = true;
            this.portfolioGrid.Size = new System.Drawing.Size(478, 166);
            this.portfolioGrid.TabIndex = 10;
            this.portfolioGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.stockGrid_CellClick);
            this.portfolioGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // portfolioCodeColumn
            // 
            this.portfolioCodeColumn.DataPropertyName = "code";
            this.portfolioCodeColumn.HeaderText = "Mã số";
            this.portfolioCodeColumn.Name = "portfolioCodeColumn";
            this.portfolioCodeColumn.ReadOnly = true;
            this.portfolioCodeColumn.Width = 95;
            // 
            // portfolioNameColumn
            // 
            this.portfolioNameColumn.DataPropertyName = "name";
            this.portfolioNameColumn.HeaderText = "Tên";
            this.portfolioNameColumn.Name = "portfolioNameColumn";
            this.portfolioNameColumn.ReadOnly = true;
            this.portfolioNameColumn.Width = 300;
            // 
            // portfolioEditColumn
            // 
            this.portfolioEditColumn.HeaderText = "";
            this.portfolioEditColumn.myValue = "";
            this.portfolioEditColumn.Name = "portfolioEditColumn";
            this.portfolioEditColumn.ReadOnly = true;
            this.portfolioEditColumn.Width = 25;
            // 
            // watchListPg
            // 
            this.watchListPg.Controls.Add(this.addWatchListBtn);
            this.watchListPg.Controls.Add(this.watchListGrid);
            this.watchListPg.Location = new System.Drawing.Point(4, 25);
            this.watchListPg.Name = "watchListPg";
            this.watchListPg.Padding = new System.Windows.Forms.Padding(3);
            this.watchListPg.Size = new System.Drawing.Size(478, 165);
            this.watchListPg.TabIndex = 1;
            this.watchListPg.Text = "Watch List";
            this.watchListPg.UseVisualStyleBackColor = true;
            // 
            // investorEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(484, 612);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.infoPnl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "investorEdit";
            this.Tag = "";
            this.Text = "Nha dau tu / Investors";
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.infoPnl, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).EndInit();
            this.infoPnl.ResumeLayout(false);
            this.infoPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watchListSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchListGrid)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.portfolioPg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.portfolioGrid)).EndInit();
            this.watchListPg.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseButton checkIdCardBtn;
        protected System.Windows.Forms.BindingSource investorSource;
        protected common.control.baseTextBox codeEd;
        protected common.control.baseTextBox firstNameEd;
        protected baseClass.controls.baseLabel nameLbl;
        protected common.control.baseTextBox lastNameEd;
        protected baseClass.controls.baseLabel lastNameLbl;
        protected common.control.baseTextBox address1Ed;
        protected baseClass.controls.baseLabel address1Lbl;
        protected baseClass.controls.baseLabel baseLabel4;
        protected baseClass.controls.baseLabel address2Lbl;
        protected common.control.baseTextBox address2Ed;
        protected baseClass.controls.baseLabel countryLbl;
        protected common.control.baseTextBox emailEd;
        protected baseClass.controls.baseLabel emailLbl;
        protected baseClass.controls.baseLabel accountLbl;
        protected common.control.baseTextBox accountEd;
        protected baseClass.controls.baseLabel passwordLbl;
        protected common.control.baseTextBox passwordEd;
        protected baseClass.controls.baseLabel statusLbl;
        protected baseClass.controls.baseLabel investorCatLbl;
        protected common.control.baseDate expireDateEd;
        protected baseClass.controls.baseLabel expireDatelbl;
        protected common.control.baseTextBox phoneEd;
        protected baseClass.controls.baseLabel phoneLbl;
        protected controls.cbCountry countryCb;
        protected controls.cbInvestorCat investorCatCb;
        protected controls.cbCommonStatus statusCb;
        protected baseClass.controls.cbSex sexCb;
        protected System.Windows.Forms.BindingSource portfolioSource;
        protected System.Windows.Forms.BindingSource watchListSource;
        private baseClass.controls.baseButton addWatchListBtn;
        protected common.control.baseDataGridView watchListGrid;
        protected common.control.baseTextBox displayNameEd;
        private System.Windows.Forms.TabPage watchListPg;
        private System.Windows.Forms.TabPage portfolioPg;
        protected baseClass.controls.baseButton addPortfolioBtn;
        protected common.control.baseDataGridView portfolioGrid;
        protected System.Windows.Forms.TabControl tabControl1;
        protected System.Windows.Forms.Panel infoPnl;
        private System.Windows.Forms.DataGridViewTextBoxColumn watchListCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn watchListNameColumn;
        private common.control.gridViewImageColumn watchListEditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portfolioCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portfolioNameColumn;
        private common.control.gridViewImageColumn portfolioEditColumn;
    }
}