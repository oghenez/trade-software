namespace admin
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.myMainMenu = new System.Windows.Forms.MenuStrip();
            this.systemMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.loginMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.configureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.resetServiceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.sysCodeCatMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.sysCodeEditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.investorMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.companyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.stockExchangeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.sysWatchListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sysInterestedStrategyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.myMainTimer = new System.Windows.Forms.Timer(this.components);
            this.dataProcessMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(0, 1);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // myMainMenu
            // 
            this.myMainMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemMenuStrip,
            this.listMenuStrip,
            this.infoMenuStrip,
            this.exitMenuStrip});
            this.myMainMenu.Location = new System.Drawing.Point(0, 0);
            this.myMainMenu.Name = "myMainMenu";
            this.myMainMenu.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.myMainMenu.Size = new System.Drawing.Size(720, 24);
            this.myMainMenu.TabIndex = 231;
            // 
            // systemMenuStrip
            // 
            this.systemMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginMenu,
            this.toolStripSeparator9,
            this.configureMenuItem,
            this.configMenuItem,
            this.toolStripSeparator4,
            this.resetServiceMenuItem,
            this.toolStripSeparator7,
            this.sysCodeCatMenu,
            this.sysCodeEditMenu,
            this.toolStripSeparator3,
            this.exitMenuItem});
            this.systemMenuStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemMenuStrip.Name = "systemMenuStrip";
            this.systemMenuStrip.Size = new System.Drawing.Size(79, 22);
            this.systemMenuStrip.Text = "Hệ thống";
            // 
            // loginMenu
            // 
            this.loginMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginMenu.Image = ((System.Drawing.Image)(resources.GetObject("loginMenu.Image")));
            this.loginMenu.Name = "loginMenu";
            this.loginMenu.Size = new System.Drawing.Size(193, 22);
            this.loginMenu.Text = "Đăng nhập";
            this.loginMenu.Click += new System.EventHandler(this.loginMenu_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(190, 6);
            // 
            // configureMenuItem
            // 
            this.configureMenuItem.Image = global::admin.Properties.Resources.configure;
            this.configureMenuItem.Name = "configureMenuItem";
            this.configureMenuItem.Size = new System.Drawing.Size(193, 22);
            this.configureMenuItem.Text = "Cấu hình";
            this.configureMenuItem.Click += new System.EventHandler(this.configureMenuItem_Click);
            // 
            // configMenuItem
            // 
            this.configMenuItem.Image = global::admin.Properties.Resources.properties;
            this.configMenuItem.Name = "configMenuItem";
            this.configMenuItem.Size = new System.Drawing.Size(193, 22);
            this.configMenuItem.Text = "Thiết lập hệ thống";
            this.configMenuItem.Click += new System.EventHandler(this.configMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(190, 6);
            // 
            // resetServiceMenuItem
            // 
            this.resetServiceMenuItem.Image = global::admin.Properties.Resources.services;
            this.resetServiceMenuItem.Name = "resetServiceMenuItem";
            this.resetServiceMenuItem.Size = new System.Drawing.Size(193, 22);
            this.resetServiceMenuItem.Text = "Khởi động lại";
            this.resetServiceMenuItem.Click += new System.EventHandler(this.resetServiceMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(190, 6);
            // 
            // sysCodeCatMenu
            // 
            this.sysCodeCatMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sysCodeCatMenu.Image = global::admin.Properties.Resources.category;
            this.sysCodeCatMenu.Name = "sysCodeCatMenu";
            this.sysCodeCatMenu.Size = new System.Drawing.Size(193, 22);
            this.sysCodeCatMenu.Text = "Phân loại";
            this.sysCodeCatMenu.Click += new System.EventHandler(this.sysCodeCatMenu_Click);
            // 
            // sysCodeEditMenu
            // 
            this.sysCodeEditMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sysCodeEditMenu.Image = global::admin.Properties.Resources.category2;
            this.sysCodeEditMenu.Name = "sysCodeEditMenu";
            this.sysCodeEditMenu.Size = new System.Drawing.Size(193, 22);
            this.sysCodeEditMenu.Text = "Dữ liệu phân loại";
            this.sysCodeEditMenu.Click += new System.EventHandler(this.sysCodeEditMenu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(190, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Image = global::admin.Properties.Resources.close;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exitMenuItem.Text = "Kết thúc";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // listMenuStrip
            // 
            this.listMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.investorMenu,
            this.toolStripSeparator11,
            this.companyMenu,
            this.toolStripSeparator6,
            this.stockExchangeMenu,
            this.toolStripSeparator12,
            this.sysWatchListMenuItem,
            this.sysInterestedStrategyMenuItem});
            this.listMenuStrip.Name = "listMenuStrip";
            this.listMenuStrip.Size = new System.Drawing.Size(83, 22);
            this.listMenuStrip.Text = "Danh mục";
            this.listMenuStrip.Click += new System.EventHandler(this.listMenuStrip_Click);
            // 
            // investorMenu
            // 
            this.investorMenu.Image = global::admin.Properties.Resources.employee;
            this.investorMenu.Name = "investorMenu";
            this.investorMenu.Size = new System.Drawing.Size(208, 22);
            this.investorMenu.Text = "Nhà đầu tư";
            this.investorMenu.Click += new System.EventHandler(this.investorMenu_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(205, 6);
            // 
            // companyMenu
            // 
            this.companyMenu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyMenu.Image = global::admin.Properties.Resources.home1;
            this.companyMenu.Name = "companyMenu";
            this.companyMenu.Size = new System.Drawing.Size(208, 22);
            this.companyMenu.Text = "Công ty";
            this.companyMenu.Click += new System.EventHandler(this.companyMenu_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(205, 6);
            // 
            // stockExchangeMenu
            // 
            this.stockExchangeMenu.Image = global::admin.Properties.Resources.exrate;
            this.stockExchangeMenu.Name = "stockExchangeMenu";
            this.stockExchangeMenu.Size = new System.Drawing.Size(208, 22);
            this.stockExchangeMenu.Tag = "??";
            this.stockExchangeMenu.Text = "Sàn giao dịch";
            this.stockExchangeMenu.Click += new System.EventHandler(this.stockExchangeMenu_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(205, 6);
            // 
            // sysWatchListMenuItem
            // 
            this.sysWatchListMenuItem.Image = global::admin.Properties.Resources.glasses;
            this.sysWatchListMenuItem.Name = "sysWatchListMenuItem";
            this.sysWatchListMenuItem.Size = new System.Drawing.Size(208, 22);
            this.sysWatchListMenuItem.Text = "System Watch List";
            this.sysWatchListMenuItem.Click += new System.EventHandler(this.sysWatchListMenuItem_Click);
            // 
            // sysInterestedStrategyMenuItem
            // 
            this.sysInterestedStrategyMenuItem.Image = global::admin.Properties.Resources.category21;
            this.sysInterestedStrategyMenuItem.Name = "sysInterestedStrategyMenuItem";
            this.sysInterestedStrategyMenuItem.Size = new System.Drawing.Size(208, 22);
            this.sysInterestedStrategyMenuItem.Text = "Interested Strategy";
            this.sysInterestedStrategyMenuItem.Click += new System.EventHandler(this.sysInterestedStrategyMenuItem_Click);
            // 
            // infoMenuStrip
            // 
            this.infoMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.licenseMenu,
            this.aboutMenu});
            this.infoMenuStrip.Name = "infoMenuStrip";
            this.infoMenuStrip.Size = new System.Drawing.Size(80, 22);
            this.infoMenuStrip.Text = "Thông tin";
            // 
            // licenseMenu
            // 
            this.licenseMenu.Image = global::admin.Properties.Resources.license;
            this.licenseMenu.Name = "licenseMenu";
            this.licenseMenu.Size = new System.Drawing.Size(144, 22);
            this.licenseMenu.Text = "Bản quyền";
            this.licenseMenu.Click += new System.EventHandler(this.licenseMenuItem_Click);
            // 
            // aboutMenu
            // 
            this.aboutMenu.Enabled = false;
            this.aboutMenu.Image = global::admin.Properties.Resources.about;
            this.aboutMenu.Name = "aboutMenu";
            this.aboutMenu.Size = new System.Drawing.Size(144, 22);
            this.aboutMenu.Text = "Giới thiệu";
            // 
            // exitMenuStrip
            // 
            this.exitMenuStrip.Name = "exitMenuStrip";
            this.exitMenuStrip.Size = new System.Drawing.Size(57, 22);
            this.exitMenuStrip.Text = "Thóat";
            this.exitMenuStrip.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // dataProcessMenuItem
            // 
            this.dataProcessMenuItem.Image = global::admin.Properties.Resources.waiting;
            this.dataProcessMenuItem.Name = "dataProcessMenuItem";
            this.dataProcessMenuItem.Size = new System.Drawing.Size(116, 20);
            this.dataProcessMenuItem.Text = "Xử lý dữ liệu";
            // 
            // main
            // 
            this.ClientSize = new System.Drawing.Size(720, 406);
            this.Controls.Add(this.myMainMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.myMainMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = true;
            this.Name = "main";
            this.Text = "Stock Trading";
            this.Controls.SetChildIndex(this.myMainMenu, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.myMainMenu.ResumeLayout(false);
            this.myMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.MenuStrip myMainMenu;
        private System.Windows.Forms.ToolStripMenuItem systemMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem loginMenu;
        private System.Windows.Forms.ToolStripMenuItem sysCodeEditMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem licenseMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutMenu;
        private System.Windows.Forms.ToolStripMenuItem sysCodeCatMenu;
        protected System.Windows.Forms.ToolStripMenuItem infoMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem listMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem companyMenu;
        private System.Windows.Forms.ToolStripMenuItem stockExchangeMenu;
        private System.Windows.Forms.ToolStripMenuItem investorMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem dataProcessMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem configMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        protected System.Windows.Forms.Timer myMainTimer;
        private System.Windows.Forms.ToolStripMenuItem sysWatchListMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sysInterestedStrategyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetServiceMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}
