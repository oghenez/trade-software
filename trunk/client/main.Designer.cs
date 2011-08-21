namespace client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.systemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeAlertMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portfolioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.companyListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backTestingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strategyRankingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeHorizontalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeVerticalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.maximizeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cascadeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemMenuItem,
            this.viewMenuItem,
            this.toolsMenuItem,
            this.windowsMenuItem,
            this.helpMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1080, 24);
            this.mainMenu.TabIndex = 146;
            this.mainMenu.Text = "menuStrip1";
            // 
            // systemMenuItem
            // 
            this.systemMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.systemMenuItem.Name = "systemMenuItem";
            this.systemMenuItem.Size = new System.Drawing.Size(62, 20);
            this.systemMenuItem.Text = "&System";
            // 
            // loginMenuItem
            // 
            this.loginMenuItem.Image = global::client.Properties.Resources.login;
            this.loginMenuItem.Name = "loginMenuItem";
            this.loginMenuItem.Size = new System.Drawing.Size(118, 22);
            this.loginMenuItem.Text = "Log in";
            this.loginMenuItem.Click += new System.EventHandler(this.loginMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(115, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::client.Properties.Resources.close;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.watchListMenuItem,
            this.tradeAlertMenuItem,
            this.portfolioMenuItem,
            this.orderMenuItem,
            this.toolStripSeparator1,
            this.companyListMenuItem,
            this.myInfoMenuItem});
            this.viewMenuItem.Name = "viewMenuItem";
            this.viewMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewMenuItem.Text = "View";
            // 
            // watchListMenuItem
            // 
            this.watchListMenuItem.CheckOnClick = true;
            this.watchListMenuItem.Name = "watchListMenuItem";
            this.watchListMenuItem.Size = new System.Drawing.Size(158, 22);
            this.watchListMenuItem.Text = "Wath list";
            this.watchListMenuItem.Click += new System.EventHandler(this.watchListMenuItem_Click);
            // 
            // tradeAlertMenuItem
            // 
            this.tradeAlertMenuItem.CheckOnClick = true;
            this.tradeAlertMenuItem.Name = "tradeAlertMenuItem";
            this.tradeAlertMenuItem.Size = new System.Drawing.Size(158, 22);
            this.tradeAlertMenuItem.Text = "Trade Alert";
            this.tradeAlertMenuItem.Click += new System.EventHandler(this.tradeAlertMenuItem_Click);
            // 
            // portfolioMenuItem
            // 
            this.portfolioMenuItem.Name = "portfolioMenuItem";
            this.portfolioMenuItem.Size = new System.Drawing.Size(158, 22);
            this.portfolioMenuItem.Text = "My portfolio";
            this.portfolioMenuItem.Click += new System.EventHandler(this.portfolioMenuItem_Click);
            // 
            // orderMenuItem
            // 
            this.orderMenuItem.Name = "orderMenuItem";
            this.orderMenuItem.Size = new System.Drawing.Size(158, 22);
            this.orderMenuItem.Text = "Orders";
            this.orderMenuItem.Click += new System.EventHandler(this.orderMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // companyListMenuItem
            // 
            this.companyListMenuItem.Name = "companyListMenuItem";
            this.companyListMenuItem.Size = new System.Drawing.Size(158, 22);
            this.companyListMenuItem.Text = "Company list";
            this.companyListMenuItem.Click += new System.EventHandler(this.companyListMenuItem_Click);
            // 
            // myInfoMenuItem
            // 
            this.myInfoMenuItem.Name = "myInfoMenuItem";
            this.myInfoMenuItem.Size = new System.Drawing.Size(158, 22);
            this.myInfoMenuItem.Text = "My Info";
            this.myInfoMenuItem.Click += new System.EventHandler(this.myInfoMenuItem_Click);
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backTestingMenuItem,
            this.strategyRankingMenuItem,
            this.toolStripSeparator6,
            this.optionsToolStripMenuItem});
            this.toolsMenuItem.Name = "toolsMenuItem";
            this.toolsMenuItem.Size = new System.Drawing.Size(49, 20);
            this.toolsMenuItem.Text = "&Tools";
            // 
            // backTestingMenuItem
            // 
            this.backTestingMenuItem.Name = "backTestingMenuItem";
            this.backTestingMenuItem.Size = new System.Drawing.Size(184, 22);
            this.backTestingMenuItem.Text = "Back Testing";
            this.backTestingMenuItem.Click += new System.EventHandler(this.backTestingMenuItem_Click);
            // 
            // strategyRankingMenuItem
            // 
            this.strategyRankingMenuItem.Name = "strategyRankingMenuItem";
            this.strategyRankingMenuItem.Size = new System.Drawing.Size(184, 22);
            this.strategyRankingMenuItem.Text = "Strategy Ranking";
            this.strategyRankingMenuItem.Click += new System.EventHandler(this.strategyRankingMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(181, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // windowsMenuItem
            // 
            this.windowsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arrangeHorizontalMenuItem,
            this.arrangeVerticalMenuItem,
            this.arrangeIconsMenuItem,
            this.toolStripSeparator3,
            this.maximizeAllMenuItem,
            this.minimizeAllMenuItem,
            this.toolStripSeparator4,
            this.cascadeMenuItem});
            this.windowsMenuItem.Name = "windowsMenuItem";
            this.windowsMenuItem.Size = new System.Drawing.Size(69, 20);
            this.windowsMenuItem.Text = "Windows";
            // 
            // arrangeHorizontalMenuItem
            // 
            this.arrangeHorizontalMenuItem.Name = "arrangeHorizontalMenuItem";
            this.arrangeHorizontalMenuItem.Size = new System.Drawing.Size(192, 22);
            this.arrangeHorizontalMenuItem.Text = "Arrange &Horizontal";
            this.arrangeHorizontalMenuItem.Click += new System.EventHandler(this.arrangeHorizontalMenuItem_Click);
            // 
            // arrangeVerticalMenuItem
            // 
            this.arrangeVerticalMenuItem.Name = "arrangeVerticalMenuItem";
            this.arrangeVerticalMenuItem.Size = new System.Drawing.Size(192, 22);
            this.arrangeVerticalMenuItem.Text = "Arrange &Vertical";
            this.arrangeVerticalMenuItem.Click += new System.EventHandler(this.arrangeVerticalMenuItem_Click);
            // 
            // arrangeIconsMenuItem
            // 
            this.arrangeIconsMenuItem.Name = "arrangeIconsMenuItem";
            this.arrangeIconsMenuItem.Size = new System.Drawing.Size(192, 22);
            this.arrangeIconsMenuItem.Text = "Arrange&Icons";
            this.arrangeIconsMenuItem.Click += new System.EventHandler(this.arrangeIconsMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
            // 
            // maximizeAllMenuItem
            // 
            this.maximizeAllMenuItem.Name = "maximizeAllMenuItem";
            this.maximizeAllMenuItem.Size = new System.Drawing.Size(192, 22);
            this.maximizeAllMenuItem.Text = "Ma&ximize all";
            this.maximizeAllMenuItem.Click += new System.EventHandler(this.maximizeAllMenuItem_Click);
            // 
            // minimizeAllMenuItem
            // 
            this.minimizeAllMenuItem.Name = "minimizeAllMenuItem";
            this.minimizeAllMenuItem.Size = new System.Drawing.Size(192, 22);
            this.minimizeAllMenuItem.Text = "Mi&nimize all";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(189, 6);
            // 
            // cascadeMenuItem
            // 
            this.cascadeMenuItem.Name = "cascadeMenuItem";
            this.cascadeMenuItem.Size = new System.Drawing.Size(192, 22);
            this.cascadeMenuItem.Text = "&Cascade";
            this.cascadeMenuItem.Click += new System.EventHandler(this.cascadeMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsMenuItem,
            this.indexMenuItem,
            this.searchMenuItem,
            this.toolStripSeparator5,
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "&Help";
            // 
            // contentsMenuItem
            // 
            this.contentsMenuItem.Name = "contentsMenuItem";
            this.contentsMenuItem.Size = new System.Drawing.Size(136, 22);
            this.contentsMenuItem.Text = "&Contents";
            // 
            // indexMenuItem
            // 
            this.indexMenuItem.Name = "indexMenuItem";
            this.indexMenuItem.Size = new System.Drawing.Size(136, 22);
            this.indexMenuItem.Text = "&Index";
            // 
            // searchMenuItem
            // 
            this.searchMenuItem.Name = "searchMenuItem";
            this.searchMenuItem.Size = new System.Drawing.Size(136, 22);
            this.searchMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(133, 6);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(136, 22);
            this.aboutMenuItem.Text = "&About...";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 672);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "main";
            this.Text = "Stock trading ";
            this.Resize += new System.EventHandler(this.main_Resize);
            this.Controls.SetChildIndex(this.mainMenu, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem windowsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeHorizontalMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeVerticalMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maximizeAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backTestingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradeAlertMenuItem;
        private System.Windows.Forms.ToolStripMenuItem watchListMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem companyListMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portfolioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strategyRankingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem orderMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem myInfoMenuItem;
    }
}

