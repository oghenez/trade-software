namespace baseClass.forms
{
    partial class investorList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(investorList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new common.controls.baseDataGridView();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.findPnl = new System.Windows.Forms.Panel();
            this.filterBtn = new baseClass.controls.baseButton();
            this.closeFindBtn = new baseClass.controls.baseButton();
            this.findCriteria = new baseClass.controls.investorCriteria();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchListSource)).BeginInit();
            this.infoPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.findPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeEd
            // 
            this.codeEd.Margin = new System.Windows.Forms.Padding(3);
            // 
            // firstNameEd
            // 
            this.firstNameEd.ReadOnly = true;
            // 
            // nameLbl
            // 
            this.nameLbl.Size = new System.Drawing.Size(75, 16);
            this.nameLbl.Text = "First Name";
            // 
            // lastNameEd
            // 
            this.lastNameEd.ReadOnly = true;
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.Size = new System.Drawing.Size(75, 16);
            this.lastNameLbl.Text = "Last Name";
            // 
            // address1Ed
            // 
            this.address1Ed.ReadOnly = true;
            // 
            // address1Lbl
            // 
            this.address1Lbl.Size = new System.Drawing.Size(74, 16);
            this.address1Lbl.Text = "Address 1";
            // 
            // address2Ed
            // 
            this.address2Ed.Margin = new System.Windows.Forms.Padding(2);
            this.address2Ed.ReadOnly = true;
            // 
            // emailEd
            // 
            this.emailEd.ReadOnly = true;
            // 
            // accountEd
            // 
            this.accountEd.Margin = new System.Windows.Forms.Padding(2);
            this.accountEd.ReadOnly = true;
            // 
            // passwordLbl
            // 
            this.passwordLbl.Size = new System.Drawing.Size(71, 16);
            this.passwordLbl.Text = "Password";
            // 
            // passwordEd
            // 
            this.passwordEd.ReadOnly = true;
            // 
            // statusLbl
            // 
            this.statusLbl.Size = new System.Drawing.Size(51, 16);
            this.statusLbl.Text = "Status";
            // 
            // investorCatLbl
            // 
            this.investorCatLbl.Size = new System.Drawing.Size(68, 16);
            this.investorCatLbl.Text = "Category";
            // 
            // expireDateLbl
            // 
            this.expireDateLbl.Size = new System.Drawing.Size(90, 16);
            this.expireDateLbl.Text = "Expired Date";
            // 
            // phoneEd
            // 
            this.phoneEd.ReadOnly = true;
            // 
            // countryCb
            // 
            this.countryCb.Margin = new System.Windows.Forms.Padding(2);
            this.countryCb.Size = new System.Drawing.Size(239, 24);
            // 
            // investorCatCb
            // 
            this.investorCatCb.Size = new System.Drawing.Size(285, 24);
            // 
            // statusCb
            // 
            this.statusCb.Size = new System.Drawing.Size(103, 24);
            // 
            // sexCb
            // 
            this.sexCb.Size = new System.Drawing.Size(118, 24);
            // 
            // displayNameEd
            // 
            this.displayNameEd.ReadOnly = true;
            // 
            // passwordEd2
            // 
            this.passwordEd2.ReadOnly = true;
            // 
            // noteEd
            // 
            this.noteEd.ReadOnly = true;
            // 
            // mobileEd
            // 
            this.mobileEd.ReadOnly = true;
            // 
            // displayNameLbl
            // 
            this.displayNameLbl.Text = "Display Name";
            // 
            // toolBox
            // 
            this.toolBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.toolBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.toolBox.Size = new System.Drawing.Size(599, 49);
            // 
            // exitBtn
            // 
            this.exitBtn.Margin = new System.Windows.Forms.Padding(2);
            // 
            // saveBtn
            // 
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(2);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editBtn.Text = "&Khóa";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Margin = new System.Windows.Forms.Padding(2);
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(759, 2);
            this.toExcelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.toExcelBtn.Size = new System.Drawing.Size(82, 36);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.reloadBtn.Visible = true;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(824, 2);
            this.printBtn.Margin = new System.Windows.Forms.Padding(2);
            this.printBtn.Size = new System.Drawing.Size(82, 36);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1167, 122);
            this.TitleLbl.Size = new System.Drawing.Size(153, 24);
            // 
            // dataGrid
            // 
            this.dataGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeColumn,
            this.displayNameColumn});
            this.dataGrid.DataSource = this.investorSource;
            this.dataGrid.Location = new System.Drawing.Point(531, -1);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(433, 652);
            this.dataGrid.TabIndex = 231;
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "code";
            this.codeColumn.HeaderText = "code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            // 
            // displayNameColumn
            // 
            this.displayNameColumn.DataPropertyName = "displayName";
            this.displayNameColumn.HeaderText = "displayName";
            this.displayNameColumn.Name = "displayNameColumn";
            this.displayNameColumn.ReadOnly = true;
            this.displayNameColumn.Width = 250;
            // 
            // findPnl
            // 
            this.findPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.findPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.findPnl.Controls.Add(this.filterBtn);
            this.findPnl.Controls.Add(this.closeFindBtn);
            this.findPnl.Controls.Add(this.findCriteria);
            this.findPnl.Location = new System.Drawing.Point(530, 458);
            this.findPnl.Name = "findPnl";
            this.findPnl.Size = new System.Drawing.Size(432, 193);
            this.findPnl.TabIndex = 239;
            this.findPnl.Visible = false;
            // 
            // filterBtn
            // 
            this.filterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtn.Image = global::baseClass.Properties.Resources.filter;
            this.filterBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.filterBtn.isDownState = false;
            this.filterBtn.Location = new System.Drawing.Point(253, 156);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(79, 31);
            this.filterBtn.TabIndex = 10;
            this.filterBtn.Text = "Find";
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // closeFindBtn
            // 
            this.closeFindBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeFindBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeFindBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeFindBtn.isDownState = false;
            this.closeFindBtn.Location = new System.Drawing.Point(332, 156);
            this.closeFindBtn.Name = "closeFindBtn";
            this.closeFindBtn.Size = new System.Drawing.Size(79, 31);
            this.closeFindBtn.TabIndex = 11;
            this.closeFindBtn.Text = "Close";
            this.closeFindBtn.UseVisualStyleBackColor = true;
            this.closeFindBtn.Click += new System.EventHandler(this.closeFindBtn_Click);
            // 
            // findCriteria
            // 
            this.findCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findCriteria.Location = new System.Drawing.Point(21, 2);
            this.findCriteria.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.findCriteria.Name = "findCriteria";
            this.findCriteria.Size = new System.Drawing.Size(391, 150);
            this.findCriteria.TabIndex = 1;
            // 
            // investorList
            // 
            this.ClientSize = new System.Drawing.Size(962, 677);
            this.Controls.Add(this.findPnl);
            this.Controls.Add(this.dataGrid);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "investorList";
            this.Controls.SetChildIndex(this.infoPnl, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.findPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchListSource)).EndInit();
            this.infoPnl.ResumeLayout(false);
            this.infoPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.findPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseButton closeFindBtn;
        protected baseClass.controls.baseButton filterBtn;
        protected controls.investorCriteria findCriteria;
        protected System.Windows.Forms.Panel findPnl;
        protected common.controls.baseDataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayNameColumn;
    }
}
