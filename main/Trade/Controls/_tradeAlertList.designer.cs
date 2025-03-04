namespace stockTrade.controls
{
    partial class _tradeAlertList
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_tradeAlertList));
            this.dataGrid = new common.control.baseDataGridView();
            this.tradeAlertSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolBarPnl = new common.control.basePanel();
            this.viewBtn = new common.control.baseButton();
            this.recoverBtn = new common.control.baseButton();
            this.refreshBtn = new common.control.baseButton();
            this.ignoreBtn = new common.control.baseButton();
            this.deleteBtn = new common.control.baseButton();
            this.showFilterBtn = new common.control.baseButton();
            this.commonStatusSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeScaleSource = new System.Windows.Forms.BindingSource(this.components);
            this.showHideBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).BeginInit();
            this.toolBarPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonStatusSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeScaleSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showHideBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.DataSource = this.tradeAlertSource;
            this.dataGrid.Location = new System.Drawing.Point(0, 28);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(411, 239);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // toolBarPnl
            // 
            this.toolBarPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolBarPnl.Controls.Add(this.viewBtn);
            this.toolBarPnl.Controls.Add(this.recoverBtn);
            this.toolBarPnl.Controls.Add(this.refreshBtn);
            this.toolBarPnl.Controls.Add(this.ignoreBtn);
            this.toolBarPnl.Controls.Add(this.deleteBtn);
            this.toolBarPnl.Controls.Add(this.showFilterBtn);
            this.toolBarPnl.haveCloseButton = false;
            this.toolBarPnl.Location = new System.Drawing.Point(0, 0);
            this.toolBarPnl.Name = "toolBarPnl";
            this.toolBarPnl.Size = new System.Drawing.Size(531, 25);
            this.toolBarPnl.TabIndex = 147;
            // 
            // viewBtn
            // 
            this.viewBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewBtn.Image = global::stockTrade.Properties.Resources.detail;
            this.viewBtn.Location = new System.Drawing.Point(5, 1);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(23, 20);
            this.viewBtn.TabIndex = 5;
            this.viewBtn.UseVisualStyleBackColor = true;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // recoverBtn
            // 
            this.recoverBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoverBtn.Image = global::stockTrade.Properties.Resources.undo;
            this.recoverBtn.Location = new System.Drawing.Point(74, 1);
            this.recoverBtn.Name = "recoverBtn";
            this.recoverBtn.Size = new System.Drawing.Size(23, 20);
            this.recoverBtn.TabIndex = 20;
            this.recoverBtn.UseVisualStyleBackColor = true;
            this.recoverBtn.Click += new System.EventHandler(this.recoverBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Image = global::stockTrade.Properties.Resources.refresh;
            this.refreshBtn.Location = new System.Drawing.Point(97, 1);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(23, 20);
            this.refreshBtn.TabIndex = 35;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // ignoreBtn
            // 
            this.ignoreBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ignoreBtn.Image = global::stockTrade.Properties.Resources.pause;
            this.ignoreBtn.Location = new System.Drawing.Point(51, 1);
            this.ignoreBtn.Name = "ignoreBtn";
            this.ignoreBtn.Size = new System.Drawing.Size(23, 20);
            this.ignoreBtn.TabIndex = 15;
            this.ignoreBtn.UseVisualStyleBackColor = true;
            this.ignoreBtn.Click += new System.EventHandler(this.ignoreBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Image = global::stockTrade.Properties.Resources.cancel;
            this.deleteBtn.Location = new System.Drawing.Point(28, 1);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(23, 20);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // showFilterBtn
            // 
            this.showFilterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFilterBtn.Image = global::stockTrade.Properties.Resources.filter;
            this.showFilterBtn.Location = new System.Drawing.Point(120, 1);
            this.showFilterBtn.Name = "showFilterBtn";
            this.showFilterBtn.Size = new System.Drawing.Size(23, 20);
            this.showFilterBtn.TabIndex = 40;
            this.showFilterBtn.UseVisualStyleBackColor = true;
            this.showFilterBtn.Click += new System.EventHandler(this.showFilterBtn_Click);
            // 
            // showHideBtn
            // 
            this.showHideBtn.Image = ((System.Drawing.Image)(resources.GetObject("showHideBtn.Image")));
            this.showHideBtn.Location = new System.Drawing.Point(478, 32);
            this.showHideBtn.Name = "showHideBtn";
            this.showHideBtn.Size = new System.Drawing.Size(24, 21);
            this.showHideBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.showHideBtn.TabIndex = 149;
            this.showHideBtn.TabStop = false;
            this.showHideBtn.Click += new System.EventHandler(this.showHideBtn_Click);
            // 
            // tradeAlertList
            // 
            this.Controls.Add(this.showHideBtn);
            this.Controls.Add(this.toolBarPnl);
            this.Controls.Add(this.dataGrid);
            this.Name = "tradeAlertList";
            this.Size = new System.Drawing.Size(531, 269);
            this.Resize += new System.EventHandler(this.tradeAlertList_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertSource)).EndInit();
            this.toolBarPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commonStatusSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeScaleSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showHideBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.TextBox commonNameEd;
        public common.control.baseDataGridView dataGrid;
        protected common.control.basePanel toolBarPnl;
        protected common.control.baseButton viewBtn;
        protected common.control.baseButton recoverBtn;
        protected common.control.baseButton refreshBtn;
        protected common.control.baseButton ignoreBtn;
        protected common.control.baseButton deleteBtn;
        protected common.control.baseButton showFilterBtn;
        protected System.Windows.Forms.BindingSource tradeAlertSource;
        protected System.Windows.Forms.BindingSource commonStatusSource;
        protected System.Windows.Forms.BindingSource timeScaleSource;
        protected System.Windows.Forms.PictureBox showHideBtn;
    }
}
