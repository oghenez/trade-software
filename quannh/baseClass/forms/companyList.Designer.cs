namespace baseClass.forms
{
    partial class companyList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(companyList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new common.control.baseDataGridView();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.findPnl = new System.Windows.Forms.Panel();
            this.filterBtn = new baseClass.controls.baseButton();
            this.closeFindBtn = new baseClass.controls.baseButton();
            this.findCriteria = new baseClass.controls.companyCriteria();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).BeginInit();
            this.xpPanelGroup_Info.SuspendLayout();
            this.xpPanel_OtherInfo.SuspendLayout();
            this.xpPanel_StockInfo.SuspendLayout();
            this.xpPanel_GeneralInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myMasterSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.findPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpPanel_OtherInfo
            // 
            this.xpPanel_OtherInfo.ImageItems.ImageSet = null;
            this.xpPanel_OtherInfo.Size = new System.Drawing.Size(483, 185);
            // 
            // xpPanel_StockInfo
            // 
            this.xpPanel_StockInfo.ImageItems.ImageSet = null;
            this.xpPanel_StockInfo.Size = new System.Drawing.Size(483, 325);
            // 
            // xpPanel_GeneralInfo
            // 
            this.xpPanel_GeneralInfo.ImageItems.ImageSet = null;
            this.xpPanel_GeneralInfo.Size = new System.Drawing.Size(483, 320);
            // 
            // exitBtn
            // 
            this.exitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.exitBtn.Size = new System.Drawing.Size(69, 39);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(71, 7);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.saveBtn.Size = new System.Drawing.Size(69, 39);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(140, 7);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.deleteBtn.Size = new System.Drawing.Size(69, 39);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(209, 7);
            this.editBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editBtn.Size = new System.Drawing.Size(69, 39);
            this.editBtn.Text = "&Khóa";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(2, 7);
            this.addNewBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addNewBtn.Size = new System.Drawing.Size(69, 39);
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(746, 15);
            this.toExcelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.toExcelBtn.Size = new System.Drawing.Size(44, 31);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(278, 7);
            this.findBtn.Size = new System.Drawing.Size(69, 39);
            this.findBtn.Visible = true;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(347, 7);
            this.reloadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.reloadBtn.Size = new System.Drawing.Size(69, 39);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(789, 15);
            this.printBtn.Margin = new System.Windows.Forms.Padding(2);
            this.printBtn.Size = new System.Drawing.Size(44, 31);
            // 
            // unLockBtn
            // 
            this.unLockBtn.Location = new System.Drawing.Point(579, 241);
            this.unLockBtn.Margin = new System.Windows.Forms.Padding(2);
            this.unLockBtn.Size = new System.Drawing.Size(20, 16);
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(579, 214);
            this.lockBtn.Margin = new System.Windows.Forms.Padding(2);
            this.lockBtn.Size = new System.Drawing.Size(16, 17);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1003, 120);
            this.TitleLbl.Size = new System.Drawing.Size(65, 16);
            // 
            // dataGrid
            // 
            this.dataGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.ColumnHeadersHeight = 32;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeColumn,
            this.nameColumn});
            this.dataGrid.DataSource = this.myMasterSource;
            this.dataGrid.DisableReadOnlyColumn = true;
            this.dataGrid.Location = new System.Drawing.Point(503, -1);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(463, 716);
            this.dataGrid.TabIndex = 231;
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "code";
            this.codeColumn.HeaderText = "Mã số";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "name";
            this.nameColumn.HeaderText = "Tên";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 300;
            // 
            // findPnl
            // 
            this.findPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.findPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.findPnl.Controls.Add(this.filterBtn);
            this.findPnl.Controls.Add(this.closeFindBtn);
            this.findPnl.Controls.Add(this.findCriteria);
            this.findPnl.Location = new System.Drawing.Point(500, 560);
            this.findPnl.Margin = new System.Windows.Forms.Padding(2);
            this.findPnl.Name = "findPnl";
            this.findPnl.Size = new System.Drawing.Size(463, 155);
            this.findPnl.TabIndex = 239;
            this.findPnl.Visible = false;
            // 
            // filterBtn
            // 
            this.filterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtn.Image = global::baseClass.Properties.Resources.filter;
            this.filterBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.filterBtn.Location = new System.Drawing.Point(251, 109);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(86, 36);
            this.filterBtn.TabIndex = 10;
            this.filterBtn.Text = "Lọc";
            this.filterBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // closeFindBtn
            // 
            this.closeFindBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.closeFindBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeFindBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeFindBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeFindBtn.Location = new System.Drawing.Point(337, 109);
            this.closeFindBtn.Name = "closeFindBtn";
            this.closeFindBtn.Size = new System.Drawing.Size(86, 36);
            this.closeFindBtn.TabIndex = 11;
            this.closeFindBtn.Text = "Đóng";
            this.closeFindBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeFindBtn.UseVisualStyleBackColor = true;
            this.closeFindBtn.Click += new System.EventHandler(this.closeFindBtn_Click);
            // 
            // findCriteria
            // 
            this.findCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findCriteria.Location = new System.Drawing.Point(34, 4);
            this.findCriteria.Name = "findCriteria";
            this.findCriteria.Size = new System.Drawing.Size(392, 101);
            this.findCriteria.TabIndex = 1;
            // 
            // companyList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(964, 738);
            this.Controls.Add(this.findPnl);
            this.Controls.Add(this.dataGrid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "companyList";
            this.Resize += new System.EventHandler(this.companyList_Resize);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.xpPanelGroup_Info, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.findPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).EndInit();
            this.xpPanelGroup_Info.ResumeLayout(false);
            this.xpPanel_OtherInfo.ResumeLayout(false);
            this.xpPanel_StockInfo.ResumeLayout(false);
            this.xpPanel_GeneralInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myMasterSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.findPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseButton closeFindBtn;
        protected baseClass.controls.baseButton filterBtn;
        protected controls.companyCriteria findCriteria;
        protected System.Windows.Forms.Panel findPnl;
        protected common.control.baseDataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
    }
}
