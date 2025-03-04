namespace baseClass.forms
{
    partial class configure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configure));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.configureTab = new System.Windows.Forms.TabControl();
            this.connectionPg = new System.Windows.Forms.TabPage();
            this.toolBarPnl = new common.controls.basePanel();
            this.saveBtn = new common.controls.baseButton();
            this.checkConnBtn = new common.controls.baseButton();
            this.exitBtn = new common.controls.baseButton();
            this.errorPnl = new common.controls.basePanel();
            this.errorMsgEd = new common.controls.baseTextBox();
            this.wsConnection = new common.controls.wsConnection();
            this.optionPage = new System.Windows.Forms.TabPage();
            this.imgFileGb = new System.Windows.Forms.GroupBox();
            this.logoImgFileLbl2 = new common.controls.baseLabel();
            this.logoImgFileEd2 = new common.controls.baseTextBox();
            this.iconImgFileLbl = new common.controls.baseLabel();
            this.iconImgFileEd = new common.controls.baseTextBox();
            this.bgImgFileLbl = new common.controls.baseLabel();
            this.bgImgFileEd = new common.controls.baseTextBox();
            this.logoImgFileLbl1 = new common.controls.baseLabel();
            this.logoImgFileEd1 = new common.controls.baseTextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configureTab.SuspendLayout();
            this.connectionPg.SuspendLayout();
            this.toolBarPnl.SuspendLayout();
            this.errorPnl.SuspendLayout();
            this.optionPage.SuspendLayout();
            this.imgFileGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(477, 1);
            this.TitleLbl.Size = new System.Drawing.Size(344, 27);
            this.TitleLbl.Text = "THIẾT LẬP HỆ THỐNG";
            this.TitleLbl.Visible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Chọn tệp";
            // 
            // configureTab
            // 
            this.configureTab.Controls.Add(this.connectionPg);
            this.configureTab.Controls.Add(this.optionPage);
            this.configureTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configureTab.Location = new System.Drawing.Point(0, 1);
            this.configureTab.Name = "configureTab";
            this.configureTab.SelectedIndex = 0;
            this.configureTab.Size = new System.Drawing.Size(470, 485);
            this.configureTab.TabIndex = 208;
            // 
            // connectionPg
            // 
            this.connectionPg.Controls.Add(this.errorPnl);
            this.connectionPg.Controls.Add(this.toolBarPnl);
            this.connectionPg.Controls.Add(this.wsConnection);
            this.connectionPg.Location = new System.Drawing.Point(4, 25);
            this.connectionPg.Name = "connectionPg";
            this.connectionPg.Padding = new System.Windows.Forms.Padding(3);
            this.connectionPg.Size = new System.Drawing.Size(462, 456);
            this.connectionPg.TabIndex = 6;
            this.connectionPg.Text = "Connection";
            this.connectionPg.UseVisualStyleBackColor = true;
            // 
            // toolBarPnl
            // 
            this.toolBarPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolBarPnl.Controls.Add(this.saveBtn);
            this.toolBarPnl.Controls.Add(this.checkConnBtn);
            this.toolBarPnl.Controls.Add(this.exitBtn);
            this.toolBarPnl.haveCloseButton = false;
            this.toolBarPnl.isExpanded = true;
            this.toolBarPnl.Location = new System.Drawing.Point(1, 237);
            this.toolBarPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.toolBarPnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.toolBarPnl.myWeight = 0;
            this.toolBarPnl.Name = "toolBarPnl";
            this.toolBarPnl.Size = new System.Drawing.Size(461, 40);
            this.toolBarPnl.TabIndex = 2;
            // 
            // saveBtn
            // 
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.isDownState = false;
            this.saveBtn.Location = new System.Drawing.Point(253, 3);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(97, 33);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "&Lưu";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // checkConnBtn
            // 
            this.checkConnBtn.Image = global::baseClass.Properties.Resources.connection;
            this.checkConnBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkConnBtn.isDownState = false;
            this.checkConnBtn.Location = new System.Drawing.Point(156, 3);
            this.checkConnBtn.Margin = new System.Windows.Forms.Padding(0);
            this.checkConnBtn.Name = "checkConnBtn";
            this.checkConnBtn.Size = new System.Drawing.Size(97, 33);
            this.checkConnBtn.TabIndex = 10;
            this.checkConnBtn.Text = "Test";
            this.checkConnBtn.UseVisualStyleBackColor = true;
            this.checkConnBtn.Click += new System.EventHandler(this.checkConnBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.isDownState = false;
            this.exitBtn.Location = new System.Drawing.Point(350, 3);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(97, 33);
            this.exitBtn.TabIndex = 12;
            this.exitBtn.Text = "Đó&ng";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // errorPnl
            // 
            this.errorPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.errorPnl.Controls.Add(this.errorMsgEd);
            this.errorPnl.haveCloseButton = true;
            this.errorPnl.isExpanded = true;
            this.errorPnl.Location = new System.Drawing.Point(0, 278);
            this.errorPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.errorPnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.errorPnl.myWeight = 0;
            this.errorPnl.Name = "errorPnl";
            this.errorPnl.Size = new System.Drawing.Size(462, 100);
            this.errorPnl.TabIndex = 236;
            this.errorPnl.Visible = false;
            this.errorPnl.myOnClosing += new common.controls.basePanel.OnClosing(this.errorPnl_myOnClosing);
            // 
            // errorMsgEd
            // 
            this.errorMsgEd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorMsgEd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorMsgEd.isToUpperCase = false;
            this.errorMsgEd.Location = new System.Drawing.Point(0, 0);
            this.errorMsgEd.Multiline = true;
            this.errorMsgEd.Name = "errorMsgEd";
            this.errorMsgEd.ReadOnly = true;
            this.errorMsgEd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorMsgEd.Size = new System.Drawing.Size(458, 96);
            this.errorMsgEd.TabIndex = 11;
            // 
            // wsConnection
            // 
            this.wsConnection.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wsConnection.Location = new System.Drawing.Point(8, 4);
            this.wsConnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wsConnection.myInfo = null;
            this.wsConnection.Name = "wsConnection";
            this.wsConnection.Size = new System.Drawing.Size(446, 231);
            this.wsConnection.TabIndex = 1;
            // 
            // optionPage
            // 
            this.optionPage.Controls.Add(this.imgFileGb);
            this.optionPage.Location = new System.Drawing.Point(4, 25);
            this.optionPage.Name = "optionPage";
            this.optionPage.Padding = new System.Windows.Forms.Padding(3);
            this.optionPage.Size = new System.Drawing.Size(462, 456);
            this.optionPage.TabIndex = 4;
            this.optionPage.Text = "Options";
            this.optionPage.UseVisualStyleBackColor = true;
            // 
            // imgFileGb
            // 
            this.imgFileGb.Controls.Add(this.logoImgFileLbl2);
            this.imgFileGb.Controls.Add(this.logoImgFileEd2);
            this.imgFileGb.Controls.Add(this.iconImgFileLbl);
            this.imgFileGb.Controls.Add(this.iconImgFileEd);
            this.imgFileGb.Controls.Add(this.bgImgFileLbl);
            this.imgFileGb.Controls.Add(this.bgImgFileEd);
            this.imgFileGb.Controls.Add(this.logoImgFileLbl1);
            this.imgFileGb.Controls.Add(this.logoImgFileEd1);
            this.imgFileGb.Location = new System.Drawing.Point(12, 31);
            this.imgFileGb.Name = "imgFileGb";
            this.imgFileGb.Size = new System.Drawing.Size(439, 177);
            this.imgFileGb.TabIndex = 1;
            this.imgFileGb.TabStop = false;
            this.imgFileGb.Text = " Tệp hình ";
            // 
            // logoImgFileLbl2
            // 
            this.logoImgFileLbl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoImgFileLbl2.Location = new System.Drawing.Point(19, 123);
            this.logoImgFileLbl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logoImgFileLbl2.Name = "logoImgFileLbl2";
            this.logoImgFileLbl2.Size = new System.Drawing.Size(81, 16);
            this.logoImgFileLbl2.TabIndex = 36;
            this.logoImgFileLbl2.Text = "Logo 2";
            // 
            // logoImgFileEd2
            // 
            this.logoImgFileEd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoImgFileEd2.isToUpperCase = false;
            this.logoImgFileEd2.Location = new System.Drawing.Point(105, 121);
            this.logoImgFileEd2.Margin = new System.Windows.Forms.Padding(4);
            this.logoImgFileEd2.Name = "logoImgFileEd2";
            this.logoImgFileEd2.Size = new System.Drawing.Size(315, 22);
            this.logoImgFileEd2.TabIndex = 4;
            this.myToolTip.SetToolTip(this.logoImgFileEd2, "Nhấp kép chuột để chọn ");
            this.logoImgFileEd2.DoubleClick += new System.EventHandler(this.logoImgFileEd2_DoubleClick);
            // 
            // iconImgFileLbl
            // 
            this.iconImgFileLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconImgFileLbl.Location = new System.Drawing.Point(19, 61);
            this.iconImgFileLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.iconImgFileLbl.Name = "iconImgFileLbl";
            this.iconImgFileLbl.Size = new System.Drawing.Size(81, 16);
            this.iconImgFileLbl.TabIndex = 34;
            this.iconImgFileLbl.Text = "Biểu tượng";
            // 
            // iconImgFileEd
            // 
            this.iconImgFileEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconImgFileEd.isToUpperCase = false;
            this.iconImgFileEd.Location = new System.Drawing.Point(105, 59);
            this.iconImgFileEd.Margin = new System.Windows.Forms.Padding(4);
            this.iconImgFileEd.Name = "iconImgFileEd";
            this.iconImgFileEd.Size = new System.Drawing.Size(315, 22);
            this.iconImgFileEd.TabIndex = 2;
            this.myToolTip.SetToolTip(this.iconImgFileEd, "Nhấp kép chuột để chọn ");
            this.iconImgFileEd.DoubleClick += new System.EventHandler(this.iconImgFileEd_DoubleClick);
            // 
            // bgImgFileLbl
            // 
            this.bgImgFileLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bgImgFileLbl.Location = new System.Drawing.Point(19, 31);
            this.bgImgFileLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bgImgFileLbl.Name = "bgImgFileLbl";
            this.bgImgFileLbl.Size = new System.Drawing.Size(81, 16);
            this.bgImgFileLbl.TabIndex = 33;
            this.bgImgFileLbl.Text = "Hình nền";
            // 
            // bgImgFileEd
            // 
            this.bgImgFileEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bgImgFileEd.isToUpperCase = false;
            this.bgImgFileEd.Location = new System.Drawing.Point(105, 29);
            this.bgImgFileEd.Margin = new System.Windows.Forms.Padding(4);
            this.bgImgFileEd.Name = "bgImgFileEd";
            this.bgImgFileEd.Size = new System.Drawing.Size(315, 22);
            this.bgImgFileEd.TabIndex = 1;
            this.myToolTip.SetToolTip(this.bgImgFileEd, "Nhấp kép chuột để chọn ");
            this.bgImgFileEd.DoubleClick += new System.EventHandler(this.bgImgFileEd_DoubleClick);
            // 
            // logoImgFileLbl1
            // 
            this.logoImgFileLbl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoImgFileLbl1.Location = new System.Drawing.Point(19, 91);
            this.logoImgFileLbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logoImgFileLbl1.Name = "logoImgFileLbl1";
            this.logoImgFileLbl1.Size = new System.Drawing.Size(81, 16);
            this.logoImgFileLbl1.TabIndex = 32;
            this.logoImgFileLbl1.Text = "Logo 1";
            // 
            // logoImgFileEd1
            // 
            this.logoImgFileEd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoImgFileEd1.isToUpperCase = false;
            this.logoImgFileEd1.Location = new System.Drawing.Point(105, 89);
            this.logoImgFileEd1.Margin = new System.Windows.Forms.Padding(4);
            this.logoImgFileEd1.Name = "logoImgFileEd1";
            this.logoImgFileEd1.Size = new System.Drawing.Size(315, 22);
            this.logoImgFileEd1.TabIndex = 3;
            this.myToolTip.SetToolTip(this.logoImgFileEd1, "Nhấp kép chuột để chọn ");
            this.logoImgFileEd1.DoubleClick += new System.EventHandler(this.logoImgFileEd_DoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "key";
            this.dataGridViewTextBoxColumn1.HeaderText = "Loại";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "value";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn2.HeaderText = "Giá trị";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 240;
            // 
            // configure
            // 
            this.ClientSize = new System.Drawing.Size(467, 510);
            this.Controls.Add(this.configureTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "configure";
            this.Text = "Thiet lap he thong";
            this.Load += new System.EventHandler(this.configure_Load);
            this.Controls.SetChildIndex(this.configureTab, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.configureTab.ResumeLayout(false);
            this.connectionPg.ResumeLayout(false);
            this.toolBarPnl.ResumeLayout(false);
            this.errorPnl.ResumeLayout(false);
            this.errorPnl.PerformLayout();
            this.optionPage.ResumeLayout(false);
            this.imgFileGb.ResumeLayout(false);
            this.imgFileGb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabControl configureTab;
        private System.Windows.Forms.TabPage connectionPg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        protected System.Windows.Forms.GroupBox imgFileGb;
        protected common.controls.baseButton checkConnBtn;
        protected common.controls.baseButton saveBtn;
        protected common.controls.baseButton exitBtn;
        protected System.Windows.Forms.TabPage optionPage;
        protected common.controls.baseLabel logoImgFileLbl2;
        protected common.controls.baseTextBox logoImgFileEd2;
        protected common.controls.baseLabel iconImgFileLbl;
        protected common.controls.baseTextBox iconImgFileEd;
        protected common.controls.baseLabel bgImgFileLbl;
        protected common.controls.baseTextBox bgImgFileEd;
        protected common.controls.baseLabel logoImgFileLbl1;
        protected common.controls.baseTextBox logoImgFileEd1;
        protected common.controls.wsConnection wsConnection;
        private common.controls.basePanel toolBarPnl;
        protected common.controls.basePanel errorPnl;
        protected common.controls.baseTextBox errorMsgEd;
    }
}