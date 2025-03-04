namespace baseClass.forms
{
    partial class syslogViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(syslogViewer));
            this.dateRange = new common.controls.dateRange0();
            this.okBtn = new common.controls.baseButton();
            this.exitBtn = new common.controls.baseButton();
            this.syslogGrid = new common.controls.baseDataGridView();
            this.onDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.investorCodeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.investorSource = new System.Windows.Forms.BindingSource(this.components);
            this.myTempDS = new databases.tmpDS();
            this.syslogSource = new System.Windows.Forms.BindingSource(this.components);
            this.myBaseDS = new databases.baseDS();
            this.sourceChk = new common.controls.baseCheckBox();
            this.descChk = new common.controls.baseCheckBox();
            this.descEd = new common.controls.baseTextBox();
            this.optionPnl = new System.Windows.Forms.Panel();
            this.accountEd = new baseClass.controls.txtInvestor();
            this.logTypeCb = new baseClass.controls.cbSyslogTypes();
            this.messageChk = new common.controls.baseCheckBox();
            this.messageEd = new common.controls.baseTextBox();
            this.sourceEd = new common.controls.baseTextBox();
            this.accountChk = new common.controls.baseCheckBox();
            this.logTypeChk = new common.controls.baseCheckBox();
            this.infoPnl = new System.Windows.Forms.Panel();
            this.dateTimeEd = new common.controls.baseDate();
            this.investorEd = new common.controls.baseTextBox();
            this.typeCb = new baseClass.controls.cbSyslogTypes();
            this.investorLbl = new common.controls.baseLabel();
            this.onDateLbl = new common.controls.baseLabel();
            this.typeLbl = new common.controls.baseLabel();
            this.infoEd = new common.controls.baseTextBox();
            this.infoLbl = new common.controls.baseLabel();
            this.desc3Ed = new common.controls.baseTextBox();
            this.sourceLbl = new common.controls.baseLabel();
            this.desc3Lbl = new common.controls.baseLabel();
            this.desc1Ed = new common.controls.baseTextBox();
            this.codeLbl = new common.controls.baseLabel();
            this.codeEd = new common.controls.baseTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.syslogGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTempDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.syslogSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).BeginInit();
            this.optionPnl.SuspendLayout();
            this.infoPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(884, 2);
            this.TitleLbl.Size = new System.Drawing.Size(10, 27);
            this.TitleLbl.Text = "NHẬT KÝ HỆ THỐNG";
            this.TitleLbl.Visible = false;
            // 
            // dateRange
            // 
            this.dateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRange.Location = new System.Drawing.Point(33, 3);
            this.dateRange.Margin = new System.Windows.Forms.Padding(4);
            this.dateRange.Name = "dateRange";
            this.dateRange.Size = new System.Drawing.Size(394, 50);
            this.dateRange.TabIndex = 1;
            // 
            // okBtn
            // 
            this.okBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Image = global::baseClass.Properties.Resources.report;
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okBtn.isDownState = false;
            this.okBtn.Location = new System.Drawing.Point(384, 102);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(93, 32);
            this.okBtn.TabIndex = 30;
            this.okBtn.Text = "&Xem";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Image = global::baseClass.Properties.Resources.close;
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.isDownState = false;
            this.exitBtn.Location = new System.Drawing.Point(474, 102);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(93, 32);
            this.exitBtn.TabIndex = 31;
            this.exitBtn.Text = "Th&oát";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // syslogGrid
            // 
            this.syslogGrid.AllowUserToAddRows = false;
            this.syslogGrid.AllowUserToDeleteRows = false;
            this.syslogGrid.AutoGenerateColumns = false;
            this.syslogGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.syslogGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.onDateColumn,
            this.descriptionColumn,
            this.investorCodeColumn});
            this.syslogGrid.DataSource = this.syslogSource;
            this.syslogGrid.Location = new System.Drawing.Point(0, 145);
            this.syslogGrid.Name = "syslogGrid";
            this.syslogGrid.ReadOnly = true;
            this.syslogGrid.RowHeadersWidth = 40;
            this.syslogGrid.RowTemplate.Height = 24;
            this.syslogGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.syslogGrid.Size = new System.Drawing.Size(599, 361);
            this.syslogGrid.TabIndex = 1;
            // 
            // onDateColumn
            // 
            this.onDateColumn.DataPropertyName = "onDate";
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.onDateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.onDateColumn.HeaderText = "Ngày/Giờ";
            this.onDateColumn.Name = "onDateColumn";
            this.onDateColumn.ReadOnly = true;
            this.onDateColumn.Width = 140;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.DataPropertyName = "description";
            this.descriptionColumn.HeaderText = "Mô tả";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.ReadOnly = true;
            this.descriptionColumn.Width = 300;
            // 
            // investorCodeColumn
            // 
            this.investorCodeColumn.DataPropertyName = "investorCode";
            this.investorCodeColumn.DataSource = this.investorSource;
            this.investorCodeColumn.DisplayMember = "account";
            this.investorCodeColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.investorCodeColumn.HeaderText = "investorCode";
            this.investorCodeColumn.Name = "investorCodeColumn";
            this.investorCodeColumn.ReadOnly = true;
            this.investorCodeColumn.ValueMember = "code";
            // 
            // investorSource
            // 
            this.investorSource.DataMember = "investor";
            this.investorSource.DataSource = this.myTempDS;
            // 
            // myTempDS
            // 
            this.myTempDS.DataSetName = "tempDS";
            this.myTempDS.EnforceConstraints = false;
            this.myTempDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // syslogSource
            // 
            this.syslogSource.DataMember = "sysLog";
            this.syslogSource.DataSource = this.myBaseDS;
            this.syslogSource.CurrentChanged += new System.EventHandler(this.syslogSource_CurrentChanged);
            // 
            // myBaseDS
            // 
            this.myBaseDS.DataSetName = "baseDS";
            this.myBaseDS.EnforceConstraints = false;
            this.myBaseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sourceChk
            // 
            this.sourceChk.AutoSize = true;
            this.sourceChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceChk.Location = new System.Drawing.Point(171, 51);
            this.sourceChk.Name = "sourceChk";
            this.sourceChk.Size = new System.Drawing.Size(67, 20);
            this.sourceChk.TabIndex = 12;
            this.sourceChk.Text = "Nguồn";
            this.sourceChk.UseVisualStyleBackColor = true;
            this.sourceChk.CheckedChanged += new System.EventHandler(this.sourceChk_CheckedChanged);
            // 
            // descChk
            // 
            this.descChk.AutoSize = true;
            this.descChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descChk.Location = new System.Drawing.Point(279, 51);
            this.descChk.Name = "descChk";
            this.descChk.Size = new System.Drawing.Size(64, 20);
            this.descChk.TabIndex = 14;
            this.descChk.Text = "Mô tả";
            this.descChk.UseVisualStyleBackColor = true;
            this.descChk.CheckedChanged += new System.EventHandler(this.descChk_CheckedChanged);
            // 
            // descEd
            // 
            this.descEd.Enabled = false;
            this.descEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descEd.isRequired = true;
            this.descEd.isToUpperCase = false;
            this.descEd.Location = new System.Drawing.Point(279, 74);
            this.descEd.Name = "descEd";
            this.descEd.Size = new System.Drawing.Size(144, 24);
            this.descEd.TabIndex = 15;
            // 
            // optionPnl
            // 
            this.optionPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.optionPnl.Controls.Add(this.accountEd);
            this.optionPnl.Controls.Add(this.logTypeCb);
            this.optionPnl.Controls.Add(this.messageChk);
            this.optionPnl.Controls.Add(this.messageEd);
            this.optionPnl.Controls.Add(this.sourceEd);
            this.optionPnl.Controls.Add(this.accountChk);
            this.optionPnl.Controls.Add(this.logTypeChk);
            this.optionPnl.Controls.Add(this.dateRange);
            this.optionPnl.Controls.Add(this.descChk);
            this.optionPnl.Controls.Add(this.okBtn);
            this.optionPnl.Controls.Add(this.descEd);
            this.optionPnl.Controls.Add(this.exitBtn);
            this.optionPnl.Controls.Add(this.sourceChk);
            this.optionPnl.Location = new System.Drawing.Point(0, 1);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(599, 143);
            this.optionPnl.TabIndex = 1;
            // 
            // accountEd
            // 
            this.accountEd.Enabled = false;
            this.accountEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountEd.isRequired = true;
            this.accountEd.isToUpperCase = true;
            this.accountEd.Location = new System.Drawing.Point(33, 74);
            this.accountEd.MaxLength = 20;
            this.accountEd.Name = "accountEd";
            this.accountEd.Size = new System.Drawing.Size(138, 24);
            this.accountEd.TabIndex = 5;
            // 
            // logTypeCb
            // 
            this.logTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logTypeCb.Enabled = false;
            this.logTypeCb.FormattingEnabled = true;
            this.logTypeCb.Location = new System.Drawing.Point(425, 26);
            this.logTypeCb.myValue = commonTypes.AppTypes.SyslogTypes.Others;
            this.logTypeCb.Name = "logTypeCb";
            this.logTypeCb.SelectedValue = ((byte)(255));
            this.logTypeCb.Size = new System.Drawing.Size(140, 24);
            this.logTypeCb.TabIndex = 3;
            // 
            // messageChk
            // 
            this.messageChk.AutoSize = true;
            this.messageChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageChk.Location = new System.Drawing.Point(423, 51);
            this.messageChk.Name = "messageChk";
            this.messageChk.Size = new System.Drawing.Size(105, 20);
            this.messageChk.TabIndex = 16;
            this.messageChk.Text = "Thông tin lỗi";
            this.messageChk.UseVisualStyleBackColor = true;
            this.messageChk.CheckedChanged += new System.EventHandler(this.messageChk_CheckedChanged);
            // 
            // messageEd
            // 
            this.messageEd.Enabled = false;
            this.messageEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageEd.isRequired = true;
            this.messageEd.isToUpperCase = false;
            this.messageEd.Location = new System.Drawing.Point(423, 74);
            this.messageEd.Name = "messageEd";
            this.messageEd.Size = new System.Drawing.Size(142, 24);
            this.messageEd.TabIndex = 17;
            // 
            // sourceEd
            // 
            this.sourceEd.Enabled = false;
            this.sourceEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceEd.isRequired = true;
            this.sourceEd.isToUpperCase = false;
            this.sourceEd.Location = new System.Drawing.Point(170, 74);
            this.sourceEd.Name = "sourceEd";
            this.sourceEd.Size = new System.Drawing.Size(109, 24);
            this.sourceEd.TabIndex = 13;
            // 
            // accountChk
            // 
            this.accountChk.AutoSize = true;
            this.accountChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountChk.Location = new System.Drawing.Point(35, 53);
            this.accountChk.Name = "accountChk";
            this.accountChk.Size = new System.Drawing.Size(88, 20);
            this.accountChk.TabIndex = 4;
            this.accountChk.Text = "Tài khỏan";
            this.accountChk.UseVisualStyleBackColor = true;
            this.accountChk.CheckedChanged += new System.EventHandler(this.accountChk_CheckedChanged);
            // 
            // logTypeChk
            // 
            this.logTypeChk.AutoSize = true;
            this.logTypeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTypeChk.Location = new System.Drawing.Point(427, 5);
            this.logTypeChk.Name = "logTypeChk";
            this.logTypeChk.Size = new System.Drawing.Size(53, 20);
            this.logTypeChk.TabIndex = 2;
            this.logTypeChk.Text = "Loại";
            this.logTypeChk.UseVisualStyleBackColor = true;
            this.logTypeChk.CheckedChanged += new System.EventHandler(this.logTypeChk_CheckedChanged);
            // 
            // infoPnl
            // 
            this.infoPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.infoPnl.Controls.Add(this.dateTimeEd);
            this.infoPnl.Controls.Add(this.investorEd);
            this.infoPnl.Controls.Add(this.typeCb);
            this.infoPnl.Controls.Add(this.investorLbl);
            this.infoPnl.Controls.Add(this.onDateLbl);
            this.infoPnl.Controls.Add(this.typeLbl);
            this.infoPnl.Controls.Add(this.infoEd);
            this.infoPnl.Controls.Add(this.infoLbl);
            this.infoPnl.Controls.Add(this.desc3Ed);
            this.infoPnl.Controls.Add(this.sourceLbl);
            this.infoPnl.Controls.Add(this.desc3Lbl);
            this.infoPnl.Controls.Add(this.desc1Ed);
            this.infoPnl.Controls.Add(this.codeLbl);
            this.infoPnl.Controls.Add(this.codeEd);
            this.infoPnl.Location = new System.Drawing.Point(600, 1);
            this.infoPnl.Name = "infoPnl";
            this.infoPnl.Size = new System.Drawing.Size(416, 504);
            this.infoPnl.TabIndex = 10;
            // 
            // dateTimeEd
            // 
            this.dateTimeEd.BeepOnError = true;
            this.dateTimeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.syslogSource, "onDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "g"));
            this.dateTimeEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dateTimeEd.Location = new System.Drawing.Point(24, 79);
            this.dateTimeEd.Mask = "00/00/0000";
            this.dateTimeEd.myDateTime = new System.DateTime(((long)(0)));
            this.dateTimeEd.Name = "dateTimeEd";
            this.dateTimeEd.ReadOnly = true;
            this.dateTimeEd.Size = new System.Drawing.Size(142, 23);
            this.dateTimeEd.TabIndex = 3;
            // 
            // investorEd
            // 
            this.investorEd.isRequired = true;
            this.investorEd.isToUpperCase = false;
            this.investorEd.Location = new System.Drawing.Point(22, 136);
            this.investorEd.Name = "investorEd";
            this.investorEd.ReadOnly = true;
            this.investorEd.Size = new System.Drawing.Size(371, 23);
            this.investorEd.TabIndex = 266;
            // 
            // typeCb
            // 
            this.typeCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.syslogSource, "type", true));
            this.typeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.typeCb.Enabled = false;
            this.typeCb.FormattingEnabled = true;
            this.typeCb.Location = new System.Drawing.Point(166, 26);
            this.typeCb.myValue = commonTypes.AppTypes.SyslogTypes.Others;
            this.typeCb.Name = "typeCb";
            this.typeCb.SelectedValue = ((byte)(255));
            this.typeCb.Size = new System.Drawing.Size(224, 26);
            this.typeCb.TabIndex = 2;
            // 
            // investorLbl
            // 
            this.investorLbl.AutoSize = true;
            this.investorLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.investorLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.investorLbl.Location = new System.Drawing.Point(19, 116);
            this.investorLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.investorLbl.Name = "investorLbl";
            this.investorLbl.Size = new System.Drawing.Size(79, 16);
            this.investorLbl.TabIndex = 265;
            this.investorLbl.Text = "Nhà đầu tư";
            // 
            // onDateLbl
            // 
            this.onDateLbl.AutoSize = true;
            this.onDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.onDateLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.onDateLbl.Location = new System.Drawing.Point(20, 58);
            this.onDateLbl.Name = "onDateLbl";
            this.onDateLbl.Size = new System.Drawing.Size(67, 16);
            this.onDateLbl.TabIndex = 262;
            this.onDateLbl.Text = "Ngày/Giờ";
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.typeLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.typeLbl.Location = new System.Drawing.Point(165, 6);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(34, 16);
            this.typeLbl.TabIndex = 257;
            this.typeLbl.Text = "Loại";
            // 
            // infoEd
            // 
            this.infoEd.BackColor = System.Drawing.SystemColors.Window;
            this.infoEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.syslogSource, "message", true));
            this.infoEd.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.infoEd.isRequired = true;
            this.infoEd.isToUpperCase = false;
            this.infoEd.Location = new System.Drawing.Point(20, 300);
            this.infoEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.infoEd.Multiline = true;
            this.infoEd.Name = "infoEd";
            this.infoEd.ReadOnly = true;
            this.infoEd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infoEd.Size = new System.Drawing.Size(374, 201);
            this.infoEd.TabIndex = 7;
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.infoLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoLbl.Location = new System.Drawing.Point(20, 280);
            this.infoLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(72, 16);
            this.infoLbl.TabIndex = 261;
            this.infoLbl.Text = "Thông tin ";
            // 
            // desc3Ed
            // 
            this.desc3Ed.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.desc3Ed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.syslogSource, "description", true));
            this.desc3Ed.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.desc3Ed.ForeColor = System.Drawing.Color.Black;
            this.desc3Ed.isRequired = true;
            this.desc3Ed.isToUpperCase = false;
            this.desc3Ed.Location = new System.Drawing.Point(20, 233);
            this.desc3Ed.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.desc3Ed.Multiline = true;
            this.desc3Ed.Name = "desc3Ed";
            this.desc3Ed.ReadOnly = true;
            this.desc3Ed.Size = new System.Drawing.Size(374, 42);
            this.desc3Ed.TabIndex = 6;
            // 
            // sourceLbl
            // 
            this.sourceLbl.AutoSize = true;
            this.sourceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.sourceLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.sourceLbl.Location = new System.Drawing.Point(20, 168);
            this.sourceLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sourceLbl.Name = "sourceLbl";
            this.sourceLbl.Size = new System.Drawing.Size(48, 16);
            this.sourceLbl.TabIndex = 259;
            this.sourceLbl.Text = "Nguồn";
            // 
            // desc3Lbl
            // 
            this.desc3Lbl.AutoSize = true;
            this.desc3Lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.desc3Lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.desc3Lbl.Location = new System.Drawing.Point(20, 214);
            this.desc3Lbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.desc3Lbl.Name = "desc3Lbl";
            this.desc3Lbl.Size = new System.Drawing.Size(45, 16);
            this.desc3Lbl.TabIndex = 260;
            this.desc3Lbl.Text = "Mô tả";
            // 
            // desc1Ed
            // 
            this.desc1Ed.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.desc1Ed.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.syslogSource, "source", true));
            this.desc1Ed.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.desc1Ed.ForeColor = System.Drawing.Color.Black;
            this.desc1Ed.isRequired = true;
            this.desc1Ed.isToUpperCase = false;
            this.desc1Ed.Location = new System.Drawing.Point(20, 187);
            this.desc1Ed.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.desc1Ed.Multiline = true;
            this.desc1Ed.Name = "desc1Ed";
            this.desc1Ed.ReadOnly = true;
            this.desc1Ed.Size = new System.Drawing.Size(374, 20);
            this.desc1Ed.TabIndex = 5;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.codeLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.codeLbl.Location = new System.Drawing.Point(20, 6);
            this.codeLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(46, 16);
            this.codeLbl.TabIndex = 258;
            this.codeLbl.Text = "Mã số";
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.syslogSource, "id", true));
            this.codeEd.ForeColor = System.Drawing.Color.Black;
            this.codeEd.isRequired = true;
            this.codeEd.isToUpperCase = false;
            this.codeEd.Location = new System.Drawing.Point(20, 26);
            this.codeEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.codeEd.Name = "codeEd";
            this.codeEd.ReadOnly = true;
            this.codeEd.Size = new System.Drawing.Size(146, 23);
            this.codeEd.TabIndex = 1;
            // 
            // syslogViewer
            // 
            this.ClientSize = new System.Drawing.Size(1015, 532);
            this.Controls.Add(this.infoPnl);
            this.Controls.Add(this.optionPnl);
            this.Controls.Add(this.syslogGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "syslogViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Nhat ky he thong";
            this.ResizeEnd += new System.EventHandler(this.syslogViewer_ResizeEnd);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.syslogGrid, 0);
            this.Controls.SetChildIndex(this.optionPnl, 0);
            this.Controls.SetChildIndex(this.infoPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.syslogGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTempDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.syslogSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).EndInit();
            this.optionPnl.ResumeLayout(false);
            this.optionPnl.PerformLayout();
            this.infoPnl.ResumeLayout(false);
            this.infoPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private databases.baseDS myBaseDS;
        private common.controls.baseDataGridView syslogGrid;
        private System.Windows.Forms.BindingSource syslogSource;
        protected baseClass.controls.cbSyslogTypes logTypeCb;
        protected databases.tmpDS myTempDS;
        protected common.controls.baseLabel onDateLbl;
        protected common.controls.baseLabel typeLbl;
        protected common.controls.baseTextBox desc3Ed;
        protected common.controls.baseLabel sourceLbl;
        protected common.controls.baseLabel desc3Lbl;
        protected common.controls.baseTextBox desc1Ed;
        protected common.controls.baseLabel codeLbl;
        protected common.controls.baseTextBox codeEd;
        protected common.controls.baseLabel investorLbl;
        protected common.controls.baseTextBox infoEd;
        protected common.controls.baseLabel infoLbl;
        protected common.controls.baseButton exitBtn;
        protected common.controls.baseButton okBtn;
        protected common.controls.dateRange0 dateRange;
        protected common.controls.baseCheckBox sourceChk;
        protected common.controls.baseCheckBox descChk;
        protected common.controls.baseTextBox descEd;
        protected System.Windows.Forms.Panel optionPnl;
        protected common.controls.baseCheckBox logTypeChk;
        protected common.controls.baseCheckBox accountChk;
        protected common.controls.baseTextBox sourceEd;
        protected common.controls.baseCheckBox messageChk;
        protected common.controls.baseTextBox messageEd;
        protected System.Windows.Forms.Panel infoPnl;
        protected baseClass.controls.cbSyslogTypes typeCb;
        protected baseClass.controls.txtInvestor accountEd;
        private System.Windows.Forms.BindingSource investorSource;
        private common.controls.baseTextBox investorEd;
        private System.Windows.Forms.DataGridViewTextBoxColumn onDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn investorCodeColumn;
        protected common.controls.baseDate dateTimeEd;
    }
}

