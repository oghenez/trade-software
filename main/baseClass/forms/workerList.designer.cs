namespace baseClass.forms
{
    partial class workerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(workerList));
            this.workerSource = new System.Windows.Forms.BindingSource(this.components);
            this.userTab = new System.Windows.Forms.TabPage();
            this.workerPnl = new System.Windows.Forms.Panel();
            this.workerTypeCb = new baseClass.Controls.cbWorkerType();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.chkSystem = new System.Windows.Forms.CheckBox();
            this.createDateEd = new common.control.baseTextBox();
            this.createDateLbl = new System.Windows.Forms.Label();
            this.expireDateEd = new common.control.txtDateTime();
            this.expireDateLbl = new System.Windows.Forms.Label();
            this.emailLbl = new System.Windows.Forms.Label();
            this.emailEd = new common.control.baseTextBox();
            this.mobileLbl = new System.Windows.Forms.Label();
            this.mobileEd = new common.control.baseTextBox();
            this.telephoneLbl = new System.Windows.Forms.Label();
            this.telephoneEd = new common.control.baseTextBox();
            this.workerIdEd = new common.control.baseTextBox();
            this.showPwdChk = new System.Windows.Forms.CheckBox();
            this.passwordEd = new common.control.baseTextBox();
            this.noteEd = new System.Windows.Forms.TextBox();
            this.noteLbl = new System.Windows.Forms.Label();
            this.lastNameEd = new common.control.baseTextBox();
            this.firstNameEd = new common.control.baseTextBox();
            this.userAccountLbl = new System.Windows.Forms.Label();
            this.userAccountEd = new common.control.baseTextBox();
            this.lastNameLbl = new System.Windows.Forms.Label();
            this.firstNameLbl = new System.Windows.Forms.Label();
            this.typeLbl = new System.Windows.Forms.Label();
            this.groupPnl = new System.Windows.Forms.Panel();
            this.baseTextBox1 = new common.control.baseTextBox();
            this.addMemberBtn = new System.Windows.Forms.Button();
            this.deleteMemberBtn = new System.Windows.Forms.Button();
            this.groupMemberLbl = new System.Windows.Forms.Label();
            this.groupMemberLb = new System.Windows.Forms.ListBox();
            this.groupNoteLbl = new System.Windows.Forms.Label();
            this.groupNoteEd = new System.Windows.Forms.TextBox();
            this.groupAccountLbl = new System.Windows.Forms.Label();
            this.groupAccountEd = new common.control.baseTextBox();
            this.mainPage = new System.Windows.Forms.TabControl();
            this.customerGrid = new System.Windows.Forms.DataGridView();
            this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridWorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newGroupBtn = new System.Windows.Forms.Button();
            this.address1Lbl = new System.Windows.Forms.Label();
            this.address1Ed = new common.control.baseTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workerSource)).BeginInit();
            this.userTab.SuspendLayout();
            this.workerPnl.SuspendLayout();
            this.groupPnl.SuspendLayout();
            this.mainPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "appDataSet";
            // 
            // toolBox
            // 
            this.toolBox.Controls.Add(this.newGroupBtn);
            this.toolBox.Location = new System.Drawing.Point(1, 376);
            this.toolBox.Size = new System.Drawing.Size(538, 65);
            this.toolBox.Controls.SetChildIndex(this.exitBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.addNewBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.newGroupBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.reloadBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.saveBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.deleteBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.editBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.toExcelBtn, 0);
            this.toolBox.Controls.SetChildIndex(this.findBtn, 0);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(463, 12);
            this.exitBtn.Size = new System.Drawing.Size(56, 47);
            this.exitBtn.TabIndex = 7;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(21, 12);
            this.saveBtn.Size = new System.Drawing.Size(50, 47);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(266, 12);
            this.deleteBtn.Size = new System.Drawing.Size(50, 47);
            this.deleteBtn.TabIndex = 5;
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(207, 12);
            this.editBtn.Size = new System.Drawing.Size(52, 47);
            this.editBtn.Text = "&Xem";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Image = global::baseClass.Properties.Resources.small_user;
            this.addNewBtn.Location = new System.Drawing.Point(79, 12);
            this.addNewBtn.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.addNewBtn.Size = new System.Drawing.Size(52, 47);
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(548, 12);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(561, 12);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(324, 12);
            this.reloadBtn.Size = new System.Drawing.Size(50, 47);
            this.reloadBtn.TabIndex = 6;
            this.reloadBtn.Visible = true;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(879, 22);
            this.TitleLbl.Size = new System.Drawing.Size(392, 28);
            this.TitleLbl.Text = "THÔNG TIN NGƯỜI SỬ DỤNG";
            this.TitleLbl.Visible = false;
            // 
            // workerSource
            // 
            this.workerSource.DataMember = "workers";
            this.workerSource.DataSource = this.myDataSet;
            // 
            // userTab
            // 
            this.userTab.Controls.Add(this.workerPnl);
            this.userTab.Controls.Add(this.groupPnl);
            this.userTab.Location = new System.Drawing.Point(4, 25);
            this.userTab.Margin = new System.Windows.Forms.Padding(4);
            this.userTab.Name = "userTab";
            this.userTab.Padding = new System.Windows.Forms.Padding(4);
            this.userTab.Size = new System.Drawing.Size(534, 350);
            this.userTab.TabIndex = 0;
            this.userTab.Text = "Người dùng";
            this.userTab.UseVisualStyleBackColor = true;
            // 
            // workerPnl
            // 
            this.workerPnl.Controls.Add(this.address1Lbl);
            this.workerPnl.Controls.Add(this.address1Ed);
            this.workerPnl.Controls.Add(this.workerTypeCb);
            this.workerPnl.Controls.Add(this.passwordLbl);
            this.workerPnl.Controls.Add(this.chkSystem);
            this.workerPnl.Controls.Add(this.createDateEd);
            this.workerPnl.Controls.Add(this.createDateLbl);
            this.workerPnl.Controls.Add(this.expireDateEd);
            this.workerPnl.Controls.Add(this.expireDateLbl);
            this.workerPnl.Controls.Add(this.emailLbl);
            this.workerPnl.Controls.Add(this.emailEd);
            this.workerPnl.Controls.Add(this.mobileLbl);
            this.workerPnl.Controls.Add(this.mobileEd);
            this.workerPnl.Controls.Add(this.telephoneLbl);
            this.workerPnl.Controls.Add(this.telephoneEd);
            this.workerPnl.Controls.Add(this.workerIdEd);
            this.workerPnl.Controls.Add(this.showPwdChk);
            this.workerPnl.Controls.Add(this.passwordEd);
            this.workerPnl.Controls.Add(this.noteEd);
            this.workerPnl.Controls.Add(this.noteLbl);
            this.workerPnl.Controls.Add(this.lastNameEd);
            this.workerPnl.Controls.Add(this.firstNameEd);
            this.workerPnl.Controls.Add(this.userAccountLbl);
            this.workerPnl.Controls.Add(this.userAccountEd);
            this.workerPnl.Controls.Add(this.lastNameLbl);
            this.workerPnl.Controls.Add(this.firstNameLbl);
            this.workerPnl.Controls.Add(this.typeLbl);
            this.workerPnl.Location = new System.Drawing.Point(2, 2);
            this.workerPnl.Name = "workerPnl";
            this.workerPnl.Size = new System.Drawing.Size(533, 349);
            this.workerPnl.TabIndex = 131;
            // 
            // workerTypeCb
            // 
            this.workerTypeCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.workerSource, "workerType", true));
            this.workerTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workerTypeCb.FormattingEnabled = true;
            this.workerTypeCb.Location = new System.Drawing.Point(378, 79);
            this.workerTypeCb.myValue = "";
            this.workerTypeCb.Name = "workerTypeCb";
            this.workerTypeCb.Size = new System.Drawing.Size(134, 24);
            this.workerTypeCb.TabIndex = 6;
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.Location = new System.Drawing.Point(183, 11);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(70, 16);
            this.passwordLbl.TabIndex = 217;
            this.passwordLbl.Text = "Mật khẩu *";
            this.passwordLbl.Visible = false;
            // 
            // chkSystem
            // 
            this.chkSystem.AutoSize = true;
            this.chkSystem.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.workerSource, "isSystem", true));
            this.chkSystem.Enabled = false;
            this.chkSystem.Location = new System.Drawing.Point(29, 319);
            this.chkSystem.Name = "chkSystem";
            this.chkSystem.Size = new System.Drawing.Size(81, 20);
            this.chkSystem.TabIndex = 24;
            this.chkSystem.TabStop = false;
            this.chkSystem.Text = "Hệ thống";
            this.chkSystem.UseVisualStyleBackColor = true;
            // 
            // createDateEd
            // 
            this.createDateEd.BackColor = System.Drawing.SystemColors.Info;
            this.createDateEd.BeepOnError = true;
            this.createDateEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "createDate", true));
            this.createDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.createDateEd.Location = new System.Drawing.Point(29, 219);
            this.createDateEd.Mask = "00/00/0000";
            this.createDateEd.Name = "createDateEd";
            this.createDateEd.ReadOnly = true;
            this.createDateEd.Size = new System.Drawing.Size(94, 22);
            this.createDateEd.TabIndex = 21;
            this.createDateEd.ValidatingType = typeof(System.DateTime);
            // 
            // createDateLbl
            // 
            this.createDateLbl.AutoSize = true;
            this.createDateLbl.Location = new System.Drawing.Point(29, 198);
            this.createDateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.createDateLbl.Name = "createDateLbl";
            this.createDateLbl.Size = new System.Drawing.Size(71, 16);
            this.createDateLbl.TabIndex = 215;
            this.createDateLbl.Text = "Ngày tạo *";
            // 
            // expireDateEd
            // 
            this.expireDateEd.BeepOnError = true;
            this.expireDateEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "expireDate", true));
            this.expireDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expireDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.expireDateEd.Location = new System.Drawing.Point(123, 219);
            this.expireDateEd.Mask = "00/00/0000";
            this.expireDateEd.Name = "expireDateEd";
            this.expireDateEd.Size = new System.Drawing.Size(100, 22);
            this.expireDateEd.TabIndex = 22;
            this.expireDateEd.ValidatingType = typeof(System.DateTime);
            // 
            // expireDateLbl
            // 
            this.expireDateLbl.AutoSize = true;
            this.expireDateLbl.Location = new System.Drawing.Point(123, 198);
            this.expireDateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.expireDateLbl.Name = "expireDateLbl";
            this.expireDateLbl.Size = new System.Drawing.Size(92, 16);
            this.expireDateLbl.TabIndex = 214;
            this.expireDateLbl.Text = "Ngày hết hạn*";
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLbl.Location = new System.Drawing.Point(269, 109);
            this.emailLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(50, 16);
            this.emailLbl.TabIndex = 213;
            this.emailLbl.Text = "Email *";
            // 
            // emailEd
            // 
            this.emailEd.BackColor = System.Drawing.SystemColors.Window;
            this.emailEd.BeepOnError = true;
            this.emailEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "email", true));
            this.emailEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailEd.Location = new System.Drawing.Point(268, 128);
            this.emailEd.Margin = new System.Windows.Forms.Padding(4);
            this.emailEd.Name = "emailEd";
            this.emailEd.Size = new System.Drawing.Size(243, 22);
            this.emailEd.TabIndex = 9;
            // 
            // mobileLbl
            // 
            this.mobileLbl.AutoSize = true;
            this.mobileLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobileLbl.Location = new System.Drawing.Point(149, 109);
            this.mobileLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mobileLbl.Name = "mobileLbl";
            this.mobileLbl.Size = new System.Drawing.Size(63, 16);
            this.mobileLbl.TabIndex = 212;
            this.mobileLbl.Text = "Di động *";
            // 
            // mobileEd
            // 
            this.mobileEd.BackColor = System.Drawing.SystemColors.Window;
            this.mobileEd.BeepOnError = true;
            this.mobileEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "mobile", true));
            this.mobileEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobileEd.Location = new System.Drawing.Point(148, 128);
            this.mobileEd.Margin = new System.Windows.Forms.Padding(4);
            this.mobileEd.Name = "mobileEd";
            this.mobileEd.Size = new System.Drawing.Size(120, 22);
            this.mobileEd.TabIndex = 8;
            // 
            // telephoneLbl
            // 
            this.telephoneLbl.AutoSize = true;
            this.telephoneLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telephoneLbl.Location = new System.Drawing.Point(24, 110);
            this.telephoneLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.telephoneLbl.Name = "telephoneLbl";
            this.telephoneLbl.Size = new System.Drawing.Size(75, 16);
            this.telephoneLbl.TabIndex = 211;
            this.telephoneLbl.Text = "Điện thọai *";
            // 
            // telephoneEd
            // 
            this.telephoneEd.BackColor = System.Drawing.SystemColors.Window;
            this.telephoneEd.BeepOnError = true;
            this.telephoneEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "phone", true));
            this.telephoneEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telephoneEd.Location = new System.Drawing.Point(27, 128);
            this.telephoneEd.Margin = new System.Windows.Forms.Padding(4);
            this.telephoneEd.Name = "telephoneEd";
            this.telephoneEd.Size = new System.Drawing.Size(120, 22);
            this.telephoneEd.TabIndex = 7;
            // 
            // workerIdEd
            // 
            this.workerIdEd.BackColor = System.Drawing.SystemColors.Info;
            this.workerIdEd.BeepOnError = true;
            this.workerIdEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "workerid", true));
            this.workerIdEd.Enabled = false;
            this.workerIdEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workerIdEd.Location = new System.Drawing.Point(332, 31);
            this.workerIdEd.Margin = new System.Windows.Forms.Padding(4);
            this.workerIdEd.Name = "workerIdEd";
            this.workerIdEd.Size = new System.Drawing.Size(128, 22);
            this.workerIdEd.TabIndex = 210;
            this.workerIdEd.TabStop = false;
            // 
            // showPwdChk
            // 
            this.showPwdChk.AutoSize = true;
            this.showPwdChk.Location = new System.Drawing.Point(179, 9);
            this.showPwdChk.Name = "showPwdChk";
            this.showPwdChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.showPwdChk.Size = new System.Drawing.Size(112, 20);
            this.showPwdChk.TabIndex = 2;
            this.showPwdChk.Text = "Hiện mật khẩu";
            this.showPwdChk.UseVisualStyleBackColor = true;
            this.showPwdChk.Visible = false;
            this.showPwdChk.CheckedChanged += new System.EventHandler(this.showPwdChk_CheckedChanged);
            // 
            // passwordEd
            // 
            this.passwordEd.BeepOnError = true;
            this.passwordEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "password", true));
            this.passwordEd.Location = new System.Drawing.Point(179, 31);
            this.passwordEd.Name = "passwordEd";
            this.passwordEd.PasswordChar = '*';
            this.passwordEd.Size = new System.Drawing.Size(154, 22);
            this.passwordEd.TabIndex = 3;
            // 
            // noteEd
            // 
            this.noteEd.BackColor = System.Drawing.SystemColors.Window;
            this.noteEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "note", true));
            this.noteEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteEd.Location = new System.Drawing.Point(27, 261);
            this.noteEd.Margin = new System.Windows.Forms.Padding(4);
            this.noteEd.Multiline = true;
            this.noteEd.Name = "noteEd";
            this.noteEd.Size = new System.Drawing.Size(484, 55);
            this.noteEd.TabIndex = 23;
            // 
            // noteLbl
            // 
            this.noteLbl.AutoSize = true;
            this.noteLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(27, 243);
            this.noteLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(52, 16);
            this.noteLbl.TabIndex = 209;
            this.noteLbl.Text = "Ghi chú";
            // 
            // lastNameEd
            // 
            this.lastNameEd.BackColor = System.Drawing.SystemColors.Window;
            this.lastNameEd.BeepOnError = true;
            this.lastNameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "firstName", true));
            this.lastNameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameEd.Location = new System.Drawing.Point(269, 79);
            this.lastNameEd.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameEd.Name = "lastNameEd";
            this.lastNameEd.Size = new System.Drawing.Size(109, 22);
            this.lastNameEd.TabIndex = 5;
            // 
            // firstNameEd
            // 
            this.firstNameEd.BackColor = System.Drawing.SystemColors.Window;
            this.firstNameEd.BeepOnError = true;
            this.firstNameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "lastName", true));
            this.firstNameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameEd.Location = new System.Drawing.Point(26, 80);
            this.firstNameEd.Margin = new System.Windows.Forms.Padding(4);
            this.firstNameEd.Name = "firstNameEd";
            this.firstNameEd.Size = new System.Drawing.Size(242, 22);
            this.firstNameEd.TabIndex = 4;
            // 
            // userAccountLbl
            // 
            this.userAccountLbl.AutoSize = true;
            this.userAccountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountLbl.Location = new System.Drawing.Point(23, 9);
            this.userAccountLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userAccountLbl.Name = "userAccountLbl";
            this.userAccountLbl.Size = new System.Drawing.Size(76, 16);
            this.userAccountLbl.TabIndex = 208;
            this.userAccountLbl.Text = "Tài khoản *";
            // 
            // userAccountEd
            // 
            this.userAccountEd.BackColor = System.Drawing.SystemColors.Window;
            this.userAccountEd.BeepOnError = true;
            this.userAccountEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "login", true));
            this.userAccountEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userAccountEd.Location = new System.Drawing.Point(26, 31);
            this.userAccountEd.Margin = new System.Windows.Forms.Padding(4);
            this.userAccountEd.Name = "userAccountEd";
            this.userAccountEd.Size = new System.Drawing.Size(154, 22);
            this.userAccountEd.TabIndex = 1;
            this.userAccountEd.Validating += new System.ComponentModel.CancelEventHandler(this.userAccountEd_Validating);
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.AutoSize = true;
            this.lastNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLbl.Location = new System.Drawing.Point(269, 62);
            this.lastNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastNameLbl.Name = "lastNameLbl";
            this.lastNameLbl.Size = new System.Drawing.Size(40, 16);
            this.lastNameLbl.TabIndex = 207;
            this.lastNameLbl.Text = "Tên *";
            // 
            // firstNameLbl
            // 
            this.firstNameLbl.AutoSize = true;
            this.firstNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLbl.Location = new System.Drawing.Point(23, 59);
            this.firstNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firstNameLbl.Name = "firstNameLbl";
            this.firstNameLbl.Size = new System.Drawing.Size(69, 16);
            this.firstNameLbl.TabIndex = 206;
            this.firstNameLbl.Text = "Họ và lót *";
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLbl.Location = new System.Drawing.Point(374, 59);
            this.typeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(52, 16);
            this.typeLbl.TabIndex = 205;
            this.typeLbl.Text = "Nhóm *";
            // 
            // groupPnl
            // 
            this.groupPnl.Controls.Add(this.baseTextBox1);
            this.groupPnl.Controls.Add(this.addMemberBtn);
            this.groupPnl.Controls.Add(this.deleteMemberBtn);
            this.groupPnl.Controls.Add(this.groupMemberLbl);
            this.groupPnl.Controls.Add(this.groupMemberLb);
            this.groupPnl.Controls.Add(this.groupNoteLbl);
            this.groupPnl.Controls.Add(this.groupNoteEd);
            this.groupPnl.Controls.Add(this.groupAccountLbl);
            this.groupPnl.Controls.Add(this.groupAccountEd);
            this.groupPnl.Location = new System.Drawing.Point(0, 3);
            this.groupPnl.Name = "groupPnl";
            this.groupPnl.Size = new System.Drawing.Size(459, 348);
            this.groupPnl.TabIndex = 153;
            this.groupPnl.Visible = false;
            // 
            // baseTextBox1
            // 
            this.baseTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.baseTextBox1.BeepOnError = true;
            this.baseTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "workerid", true));
            this.baseTextBox1.Enabled = false;
            this.baseTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseTextBox1.Location = new System.Drawing.Point(167, 23);
            this.baseTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.baseTextBox1.Name = "baseTextBox1";
            this.baseTextBox1.Size = new System.Drawing.Size(105, 22);
            this.baseTextBox1.TabIndex = 219;
            this.baseTextBox1.TabStop = false;
            // 
            // addMemberBtn
            // 
            this.addMemberBtn.Enabled = false;
            this.addMemberBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addMemberBtn.Image = ((System.Drawing.Image)(resources.GetObject("addMemberBtn.Image")));
            this.addMemberBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addMemberBtn.Location = new System.Drawing.Point(24, 312);
            this.addMemberBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addMemberBtn.Name = "addMemberBtn";
            this.addMemberBtn.Size = new System.Drawing.Size(80, 29);
            this.addMemberBtn.TabIndex = 126;
            this.addMemberBtn.Text = "&Thêm";
            this.addMemberBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addMemberBtn.UseVisualStyleBackColor = true;
            // 
            // deleteMemberBtn
            // 
            this.deleteMemberBtn.Enabled = false;
            this.deleteMemberBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteMemberBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteMemberBtn.Image")));
            this.deleteMemberBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteMemberBtn.Location = new System.Drawing.Point(109, 312);
            this.deleteMemberBtn.Margin = new System.Windows.Forms.Padding(4);
            this.deleteMemberBtn.Name = "deleteMemberBtn";
            this.deleteMemberBtn.Size = new System.Drawing.Size(70, 29);
            this.deleteMemberBtn.TabIndex = 127;
            this.deleteMemberBtn.Text = "&Xóa";
            this.deleteMemberBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteMemberBtn.UseVisualStyleBackColor = true;
            // 
            // groupMemberLbl
            // 
            this.groupMemberLbl.AutoSize = true;
            this.groupMemberLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupMemberLbl.Location = new System.Drawing.Point(24, 121);
            this.groupMemberLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.groupMemberLbl.Name = "groupMemberLbl";
            this.groupMemberLbl.Size = new System.Drawing.Size(164, 16);
            this.groupMemberLbl.TabIndex = 130;
            this.groupMemberLbl.Text = "Thành viên trong nhóm";
            // 
            // groupMemberLb
            // 
            this.groupMemberLb.FormattingEnabled = true;
            this.groupMemberLb.ItemHeight = 16;
            this.groupMemberLb.Location = new System.Drawing.Point(24, 141);
            this.groupMemberLb.Name = "groupMemberLb";
            this.groupMemberLb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.groupMemberLb.Size = new System.Drawing.Size(407, 164);
            this.groupMemberLb.TabIndex = 125;
            // 
            // groupNoteLbl
            // 
            this.groupNoteLbl.AutoSize = true;
            this.groupNoteLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNoteLbl.Location = new System.Drawing.Point(24, 52);
            this.groupNoteLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.groupNoteLbl.Name = "groupNoteLbl";
            this.groupNoteLbl.Size = new System.Drawing.Size(52, 16);
            this.groupNoteLbl.TabIndex = 129;
            this.groupNoteLbl.Text = "Ghi chú";
            // 
            // groupNoteEd
            // 
            this.groupNoteEd.BackColor = System.Drawing.SystemColors.Window;
            this.groupNoteEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "note", true));
            this.groupNoteEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNoteEd.Location = new System.Drawing.Point(24, 71);
            this.groupNoteEd.Margin = new System.Windows.Forms.Padding(4);
            this.groupNoteEd.Multiline = true;
            this.groupNoteEd.Name = "groupNoteEd";
            this.groupNoteEd.Size = new System.Drawing.Size(407, 44);
            this.groupNoteEd.TabIndex = 124;
            // 
            // groupAccountLbl
            // 
            this.groupAccountLbl.AutoSize = true;
            this.groupAccountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAccountLbl.Location = new System.Drawing.Point(21, 3);
            this.groupAccountLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.groupAccountLbl.Name = "groupAccountLbl";
            this.groupAccountLbl.Size = new System.Drawing.Size(68, 16);
            this.groupAccountLbl.TabIndex = 128;
            this.groupAccountLbl.Text = "Tài khoản";
            // 
            // groupAccountEd
            // 
            this.groupAccountEd.BackColor = System.Drawing.SystemColors.Window;
            this.groupAccountEd.BeepOnError = true;
            this.groupAccountEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "login", true));
            this.groupAccountEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAccountEd.Location = new System.Drawing.Point(24, 23);
            this.groupAccountEd.Margin = new System.Windows.Forms.Padding(4);
            this.groupAccountEd.Name = "groupAccountEd";
            this.groupAccountEd.Size = new System.Drawing.Size(143, 22);
            this.groupAccountEd.TabIndex = 123;
            // 
            // mainPage
            // 
            this.mainPage.Controls.Add(this.userTab);
            this.mainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPage.Location = new System.Drawing.Point(-3, 2);
            this.mainPage.Name = "mainPage";
            this.mainPage.SelectedIndex = 0;
            this.mainPage.Size = new System.Drawing.Size(542, 379);
            this.mainPage.TabIndex = 100;
            // 
            // customerGrid
            // 
            this.customerGrid.AllowUserToAddRows = false;
            this.customerGrid.AllowUserToDeleteRows = false;
            this.customerGrid.AutoGenerateColumns = false;
            this.customerGrid.ColumnHeadersHeight = 28;
            this.customerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loginDataGridViewTextBoxColumn,
            this.gridWorkerName});
            this.customerGrid.DataSource = this.workerSource;
            this.customerGrid.Location = new System.Drawing.Point(540, 1);
            this.customerGrid.Name = "customerGrid";
            this.customerGrid.ReadOnly = true;
            this.customerGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.customerGrid.Size = new System.Drawing.Size(442, 439);
            this.customerGrid.TabIndex = 152;
            this.customerGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.customerGrid_DataError);
            // 
            // loginDataGridViewTextBoxColumn
            // 
            this.loginDataGridViewTextBoxColumn.DataPropertyName = "login";
            this.loginDataGridViewTextBoxColumn.HeaderText = "Tài khoản";
            this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
            this.loginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gridWorkerName
            // 
            this.gridWorkerName.HeaderText = "Tên";
            this.gridWorkerName.Name = "gridWorkerName";
            this.gridWorkerName.ReadOnly = true;
            this.gridWorkerName.Width = 280;
            // 
            // newGroupBtn
            // 
            this.newGroupBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGroupBtn.Image = global::baseClass.Properties.Resources.usergroup;
            this.newGroupBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newGroupBtn.Location = new System.Drawing.Point(139, 12);
            this.newGroupBtn.Margin = new System.Windows.Forms.Padding(4);
            this.newGroupBtn.Name = "newGroupBtn";
            this.newGroupBtn.Size = new System.Drawing.Size(61, 47);
            this.newGroupBtn.TabIndex = 3;
            this.newGroupBtn.Text = "&Nhóm";
            this.newGroupBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.newGroupBtn.UseVisualStyleBackColor = true;
            // 
            // address1Lbl
            // 
            this.address1Lbl.AutoSize = true;
            this.address1Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Lbl.Location = new System.Drawing.Point(22, 154);
            this.address1Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.address1Lbl.Name = "address1Lbl";
            this.address1Lbl.Size = new System.Drawing.Size(56, 16);
            this.address1Lbl.TabIndex = 219;
            this.address1Lbl.Text = "Địa chỉ *";
            // 
            // address1Ed
            // 
            this.address1Ed.BackColor = System.Drawing.SystemColors.Window;
            this.address1Ed.BeepOnError = true;
            this.address1Ed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.workerSource, "address1", true));
            this.address1Ed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Ed.Location = new System.Drawing.Point(25, 172);
            this.address1Ed.Margin = new System.Windows.Forms.Padding(4);
            this.address1Ed.Name = "address1Ed";
            this.address1Ed.Size = new System.Drawing.Size(486, 22);
            this.address1Ed.TabIndex = 20;
            // 
            // workerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(981, 467);
            this.Controls.Add(this.customerGrid);
            this.Controls.Add(this.mainPage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "workerList";
            this.Tag = "\"\"";
            this.Text = " Nguoi su dung";
            this.Load += new System.EventHandler(this.workerEdit_Load);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.mainPage, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.customerGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.workerSource)).EndInit();
            this.userTab.ResumeLayout(false);
            this.workerPnl.ResumeLayout(false);
            this.workerPnl.PerformLayout();
            this.groupPnl.ResumeLayout(false);
            this.groupPnl.PerformLayout();
            this.mainPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage userTab;
        private System.Windows.Forms.TabControl mainPage;
        private System.Windows.Forms.DataGridView customerGrid;
        private System.Windows.Forms.BindingSource workerSource;
        private System.Windows.Forms.Panel workerPnl;
        protected System.Windows.Forms.CheckBox chkSystem;
        protected common.control.baseTextBox createDateEd;
        protected System.Windows.Forms.Label createDateLbl;
        protected common.control.txtDateTime expireDateEd;
        protected System.Windows.Forms.Label expireDateLbl;
        private System.Windows.Forms.Label emailLbl;
        private common.control.baseTextBox emailEd;
        private System.Windows.Forms.Label mobileLbl;
        private common.control.baseTextBox mobileEd;
        private System.Windows.Forms.Label telephoneLbl;
        private common.control.baseTextBox telephoneEd;
        private common.control.baseTextBox workerIdEd;
        private System.Windows.Forms.CheckBox showPwdChk;
        private common.control.baseTextBox passwordEd;
        private System.Windows.Forms.TextBox noteEd;
        private System.Windows.Forms.Label noteLbl;
        private common.control.baseTextBox lastNameEd;
        private common.control.baseTextBox firstNameEd;
        private System.Windows.Forms.Label userAccountLbl;
        private common.control.baseTextBox userAccountEd;
        private System.Windows.Forms.Label lastNameLbl;
        private System.Windows.Forms.Label firstNameLbl;
        private System.Windows.Forms.Label typeLbl;
        private System.Windows.Forms.Panel groupPnl;
        protected System.Windows.Forms.Button addMemberBtn;
        protected System.Windows.Forms.Button deleteMemberBtn;
        private System.Windows.Forms.Label groupMemberLbl;
        private System.Windows.Forms.ListBox groupMemberLb;
        private System.Windows.Forms.Label groupNoteLbl;
        private System.Windows.Forms.TextBox groupNoteEd;
        private System.Windows.Forms.Label groupAccountLbl;
        private common.control.baseTextBox groupAccountEd;
        protected System.Windows.Forms.Button newGroupBtn;
        private System.Windows.Forms.Label passwordLbl;
        private common.control.baseTextBox baseTextBox1;
        private baseClass.Controls.cbWorkerType workerTypeCb;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridWorkerName;
        private System.Windows.Forms.Label address1Lbl;
        private common.control.baseTextBox address1Ed;
    }
}