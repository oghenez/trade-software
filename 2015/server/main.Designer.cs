namespace server
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
            this.myMainMenu = new System.Windows.Forms.MenuStrip();
            this.systemMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.loginMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPriceDataMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.importIcbMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.importCompanyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.importComSectorMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.updateDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.reUpdatePriceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.reAggregateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.bestStrategyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dataProcessMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
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
            this.toolMenuItem,
            this.exitMenuStrip});
            this.myMainMenu.Location = new System.Drawing.Point(0, 0);
            this.myMainMenu.Name = "myMainMenu";
            this.myMainMenu.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.myMainMenu.Size = new System.Drawing.Size(720, 27);
            this.myMainMenu.TabIndex = 231;
            // 
            // systemMenuStrip
            // 
            this.systemMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginMenu,
            this.toolStripSeparator3,
            this.exitMenuItem});
            this.systemMenuStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemMenuStrip.Name = "systemMenuStrip";
            this.systemMenuStrip.Size = new System.Drawing.Size(101, 25);
            this.systemMenuStrip.Text = "Hệ thống";
            // 
            // loginMenu
            // 
            this.loginMenu.Enabled = false;
            this.loginMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginMenu.Image = ((System.Drawing.Image)(resources.GetObject("loginMenu.Image")));
            this.loginMenu.Name = "loginMenu";
            this.loginMenu.Size = new System.Drawing.Size(173, 26);
            this.loginMenu.Text = "Đăng nhập";
            this.loginMenu.Click += new System.EventHandler(this.loginMenu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Image = global::server.Properties.Resources.close;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(173, 26);
            this.exitMenuItem.Text = "Kết thúc";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // toolMenuItem
            // 
            this.toolMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importPriceDataMenu,
            this.importIcbMenu,
            this.importCompanyMenu,
            this.importComSectorMenu,
            this.toolStripSeparator5,
            this.updateDataMenuItem,
            this.toolStripSeparator4,
            this.reUpdatePriceMenuItem,
            this.toolStripSeparator6,
            this.reAggregateMenuItem,
            this.toolStripSeparator7,
            this.bestStrategyToolStripMenuItem});
            this.toolMenuItem.Name = "toolMenuItem";
            this.toolMenuItem.Size = new System.Drawing.Size(91, 25);
            this.toolMenuItem.Text = "Công cụ";
            // 
            // importPriceDataMenu
            // 
            this.importPriceDataMenu.Image = global::server.Properties.Resources.import;
            this.importPriceDataMenu.Name = "importPriceDataMenu";
            this.importPriceDataMenu.Size = new System.Drawing.Size(306, 26);
            this.importPriceDataMenu.Text = "Nhập dữ liệu giá";
            this.importPriceDataMenu.Click += new System.EventHandler(this.importPriceDataMenu_Click);
            // 
            // importIcbMenu
            // 
            this.importIcbMenu.Image = global::server.Properties.Resources.data;
            this.importIcbMenu.Name = "importIcbMenu";
            this.importIcbMenu.Size = new System.Drawing.Size(306, 26);
            this.importIcbMenu.Text = "Nhập bộ mã ICB ";
            this.importIcbMenu.Click += new System.EventHandler(this.importIcbMenu_Click);
            // 
            // importCompanyMenu
            // 
            this.importCompanyMenu.Image = global::server.Properties.Resources.home1;
            this.importCompanyMenu.Name = "importCompanyMenu";
            this.importCompanyMenu.Size = new System.Drawing.Size(306, 26);
            this.importCompanyMenu.Text = "Nhập công ty";
            this.importCompanyMenu.Click += new System.EventHandler(this.importCompanyMenu_Click);
            // 
            // importComSectorMenu
            // 
            this.importComSectorMenu.Image = global::server.Properties.Resources.product;
            this.importComSectorMenu.Name = "importComSectorMenu";
            this.importComSectorMenu.Size = new System.Drawing.Size(306, 26);
            this.importComSectorMenu.Text = "Nhập mã ngành";
            this.importComSectorMenu.Click += new System.EventHandler(this.importComSectorMenu_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(303, 6);
            // 
            // updateDataMenuItem
            // 
            this.updateDataMenuItem.Image = global::server.Properties.Resources.schedule;
            this.updateDataMenuItem.Name = "updateDataMenuItem";
            this.updateDataMenuItem.Size = new System.Drawing.Size(306, 26);
            this.updateDataMenuItem.Text = "Lấy giá trực tuyến";
            this.updateDataMenuItem.Click += new System.EventHandler(this.updateDataMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(303, 6);
            // 
            // reUpdatePriceMenuItem
            // 
            this.reUpdatePriceMenuItem.Image = global::server.Properties.Resources.exrate;
            this.reUpdatePriceMenuItem.Name = "reUpdatePriceMenuItem";
            this.reUpdatePriceMenuItem.Size = new System.Drawing.Size(306, 26);
            this.reUpdatePriceMenuItem.Text = "Cập nhật lại giá trực tuyến";
            this.reUpdatePriceMenuItem.Click += new System.EventHandler(this.reUpdatePriceMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(303, 6);
            // 
            // reAggregateMenuItem
            // 
            this.reAggregateMenuItem.Image = global::server.Properties.Resources.exrate;
            this.reAggregateMenuItem.Name = "reAggregateMenuItem";
            this.reAggregateMenuItem.Size = new System.Drawing.Size(306, 26);
            this.reAggregateMenuItem.Text = "Tổ hợp lại giá";
            this.reAggregateMenuItem.Click += new System.EventHandler(this.reAggregateMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(303, 6);
            // 
            // bestStrategyToolStripMenuItem
            // 
            this.bestStrategyToolStripMenuItem.Name = "bestStrategyToolStripMenuItem";
            this.bestStrategyToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.bestStrategyToolStripMenuItem.Text = "Tạo chiến lược tốt nhất";
            this.bestStrategyToolStripMenuItem.Click += new System.EventHandler(this.bestStrategyToolStripMenuItem_Click);
            // 
            // exitMenuStrip
            // 
            this.exitMenuStrip.Name = "exitMenuStrip";
            this.exitMenuStrip.Size = new System.Drawing.Size(71, 25);
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
            this.dataProcessMenuItem.Name = "dataProcessMenuItem";
            this.dataProcessMenuItem.Size = new System.Drawing.Size(116, 20);
            this.dataProcessMenuItem.Text = "Xử lý dữ liệu";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 360);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(720, 23);
            this.progressBar1.TabIndex = 233;
            // 
            // main
            // 
            this.ClientSize = new System.Drawing.Size(720, 406);
            this.Controls.Add(this.progressBar1);
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
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.myMainMenu.ResumeLayout(false);
            this.myMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.MenuStrip myMainMenu;
        private System.Windows.Forms.ToolStripMenuItem systemMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem loginMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem dataProcessMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPriceDataMenu;
        private System.Windows.Forms.ToolStripMenuItem importIcbMenu;
        private System.Windows.Forms.ToolStripMenuItem importCompanyMenu;
        private System.Windows.Forms.ToolStripMenuItem importComSectorMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem reUpdatePriceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateDataMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem reAggregateMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem bestStrategyToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
