﻿namespace baseClass.forms
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
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchListSource)).BeginInit();
            this.infoPnl.SuspendLayout();
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
            this.firstNameEd.Margin = new System.Windows.Forms.Padding(3);
            // 
            // nameLbl
            // 
            this.nameLbl.Size = new System.Drawing.Size(75, 16);
            this.nameLbl.Text = "First Name";
            // 
            // lastNameEd
            // 
            this.lastNameEd.Margin = new System.Windows.Forms.Padding(3);
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.Size = new System.Drawing.Size(75, 16);
            this.lastNameLbl.Text = "Last Name";
            // 
            // address1Ed
            // 
            this.address1Ed.Margin = new System.Windows.Forms.Padding(3);
            // 
            // address1Lbl
            // 
            this.address1Lbl.Size = new System.Drawing.Size(74, 16);
            this.address1Lbl.Text = "Address 1";
            // 
            // address2Ed
            // 
            this.address2Ed.Margin = new System.Windows.Forms.Padding(2);
            // 
            // emailEd
            // 
            this.emailEd.Size = new System.Drawing.Size(239, 22);
            // 
            // accountEd
            // 
            this.accountEd.Margin = new System.Windows.Forms.Padding(2);
            // 
            // passwordLbl
            // 
            this.passwordLbl.Size = new System.Drawing.Size(71, 16);
            this.passwordLbl.Text = "Password";
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
            // countryCb
            // 
            this.countryCb.Margin = new System.Windows.Forms.Padding(2);
            this.countryCb.Size = new System.Drawing.Size(239, 24);
            // 
            // investorCatCb
            // 
            this.investorCatCb.Size = new System.Drawing.Size(239, 24);
            // 
            // statusCb
            // 
            this.statusCb.Size = new System.Drawing.Size(99, 24);
            // 
            // sexCb
            // 
            this.sexCb.Margin = new System.Windows.Forms.Padding(2);
            this.sexCb.Size = new System.Drawing.Size(61, 24);
            // 
            // displayNameEd
            // 
            this.displayNameEd.Margin = new System.Windows.Forms.Padding(3);
            // 
            // infoPnl
            // 
            this.infoPnl.Size = new System.Drawing.Size(485, 562);
            // 
            // watchListBtn
            // 
            this.watchListBtn.Location = new System.Drawing.Point(244, 502);
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-2, -2);
            this.toolBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.toolBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(415, 5);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.exitBtn.Size = new System.Drawing.Size(69, 39);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(70, 5);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.saveBtn.Size = new System.Drawing.Size(69, 39);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(139, 5);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.deleteBtn.Size = new System.Drawing.Size(69, 39);
            this.deleteBtn.Visible = true;
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(346, 5);
            this.editBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editBtn.Size = new System.Drawing.Size(69, 39);
            this.editBtn.Text = "&Khóa";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(1, 5);
            this.addNewBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addNewBtn.Size = new System.Drawing.Size(69, 39);
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(590, 6);
            this.toExcelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.toExcelBtn.Size = new System.Drawing.Size(44, 31);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(208, 5);
            this.findBtn.Size = new System.Drawing.Size(69, 39);
            this.findBtn.Visible = true;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(277, 5);
            this.reloadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.reloadBtn.Size = new System.Drawing.Size(69, 39);
            this.reloadBtn.Visible = true;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(633, 6);
            this.printBtn.Margin = new System.Windows.Forms.Padding(2);
            this.printBtn.Size = new System.Drawing.Size(44, 31);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(964, 122);
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
            this.dataGrid.DisableReadOnlyColumn = true;
            this.dataGrid.Location = new System.Drawing.Point(485, -1);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(419, 617);
            this.dataGrid.TabIndex = 231;
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "code";
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            // 
            // displayNameColumn
            // 
            this.displayNameColumn.DataPropertyName = "displayName";
            this.displayNameColumn.HeaderText = "Name";
            this.displayNameColumn.Name = "displayNameColumn";
            this.displayNameColumn.ReadOnly = true;
            this.displayNameColumn.Width = 260;
            // 
            // findPnl
            // 
            this.findPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.findPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.findPnl.Controls.Add(this.filterBtn);
            this.findPnl.Controls.Add(this.closeFindBtn);
            this.findPnl.Controls.Add(this.findCriteria);
            this.findPnl.Location = new System.Drawing.Point(484, 456);
            this.findPnl.Margin = new System.Windows.Forms.Padding(2);
            this.findPnl.Name = "findPnl";
            this.findPnl.Size = new System.Drawing.Size(419, 160);
            this.findPnl.TabIndex = 239;
            this.findPnl.Visible = false;
            // 
            // filterBtn
            // 
            this.filterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtn.Image = global::baseClass.Properties.Resources.filter;
            this.filterBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.filterBtn.Location = new System.Drawing.Point(341, 72);
            this.filterBtn.Margin = new System.Windows.Forms.Padding(2);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(65, 40);
            this.filterBtn.TabIndex = 10;
            this.filterBtn.Text = "Find";
            this.filterBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // closeFindBtn
            // 
            this.closeFindBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeFindBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeFindBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeFindBtn.Location = new System.Drawing.Point(341, 28);
            this.closeFindBtn.Margin = new System.Windows.Forms.Padding(2);
            this.closeFindBtn.Name = "closeFindBtn";
            this.closeFindBtn.Size = new System.Drawing.Size(65, 40);
            this.closeFindBtn.TabIndex = 11;
            this.closeFindBtn.Text = "Close";
            this.closeFindBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeFindBtn.UseVisualStyleBackColor = true;
            this.closeFindBtn.Click += new System.EventHandler(this.closeFindBtn_Click);
            // 
            // findCriteria
            // 
            this.findCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findCriteria.Location = new System.Drawing.Point(33, 2);
            this.findCriteria.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.findCriteria.Name = "findCriteria";
            this.findCriteria.Size = new System.Drawing.Size(293, 150);
            this.findCriteria.TabIndex = 1;
            // 
            // investorList
            // 
            this.ClientSize = new System.Drawing.Size(903, 643);
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
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchListSource)).EndInit();
            this.infoPnl.ResumeLayout(false);
            this.infoPnl.PerformLayout();
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
