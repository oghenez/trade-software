namespace baseClass.forms
{
    partial class projectList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(projectList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.findPnl = new System.Windows.Forms.Panel();
            this.filterBtn = new baseClass.controls.baseButton();
            this.closeFindBtn = new baseClass.controls.baseButton();
            this.projectCriteria = new application.control.projectCriteria();
            this.projectCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.projectsSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projCommentSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.findPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ownerEd
            // 
            this.ownerEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            // 
            // codeEd
            // 
            this.codeEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            // 
            // projTitleEd
            // 
            this.projTitleEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            // 
            // subjectCodeCb
            // 
            this.subjectCodeCb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("subjectCodeCb.myCheckedItems")));
            this.subjectCodeCb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("subjectCodeCb.myCheckedValues")));
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-1, -2);
            this.toolBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Size = new System.Drawing.Size(606, 48);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(467, 5);
            this.exitBtn.Size = new System.Drawing.Size(58, 38);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(3, 5);
            this.saveBtn.Size = new System.Drawing.Size(58, 38);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(119, 5);
            this.deleteBtn.Size = new System.Drawing.Size(58, 38);
            this.deleteBtn.Visible = true;
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(177, 5);
            this.editBtn.Size = new System.Drawing.Size(58, 38);
            this.editBtn.Text = "&Khóa";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(61, 5);
            this.addNewBtn.Size = new System.Drawing.Size(58, 38);
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(351, 5);
            this.toExcelBtn.Size = new System.Drawing.Size(58, 38);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(293, 5);
            this.findBtn.Size = new System.Drawing.Size(58, 38);
            this.findBtn.Visible = true;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(235, 5);
            this.reloadBtn.Size = new System.Drawing.Size(58, 38);
            this.reloadBtn.Visible = true;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(409, 5);
            this.printBtn.Size = new System.Drawing.Size(58, 38);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1285, 150);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            // 
            // dataGrid
            // 
            this.dataGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.projectCodeDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn});
            this.dataGrid.DataSource = this.projectsSource;
            this.dataGrid.Location = new System.Drawing.Point(527, -1);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(566, 495);
            this.dataGrid.TabIndex = 231;
            // 
            // findPnl
            // 
            this.findPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.findPnl.Controls.Add(this.filterBtn);
            this.findPnl.Controls.Add(this.closeFindBtn);
            this.findPnl.Controls.Add(this.projectCriteria);
            this.findPnl.Location = new System.Drawing.Point(523, 327);
            this.findPnl.Name = "findPnl";
            this.findPnl.Size = new System.Drawing.Size(565, 167);
            this.findPnl.TabIndex = 239;
            // 
            // filterBtn
            // 
            this.filterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtn.Image = global::baseClass.Properties.Resources.filter;
            this.filterBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.filterBtn.Location = new System.Drawing.Point(477, 26);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(70, 38);
            this.filterBtn.TabIndex = 10;
            this.filterBtn.Text = "Lọc";
            this.filterBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // closeFindBtn
            // 
            this.closeFindBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeFindBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeFindBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeFindBtn.Location = new System.Drawing.Point(477, 66);
            this.closeFindBtn.Name = "closeFindBtn";
            this.closeFindBtn.Size = new System.Drawing.Size(70, 38);
            this.closeFindBtn.TabIndex = 11;
            this.closeFindBtn.Text = "Đóng";
            this.closeFindBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeFindBtn.UseVisualStyleBackColor = true;
            this.closeFindBtn.Click += new System.EventHandler(this.closeFindBtn_Click);
            // 
            // projectCriteria
            // 
            this.projectCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectCriteria.Location = new System.Drawing.Point(16, 2);
            this.projectCriteria.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.projectCriteria.Name = "projectCriteria";
            this.projectCriteria.Size = new System.Drawing.Size(454, 164);
            this.projectCriteria.TabIndex = 1;
            // 
            // projectCodeDataGridViewTextBoxColumn
            // 
            this.projectCodeDataGridViewTextBoxColumn.DataPropertyName = "projectCode";
            this.projectCodeDataGridViewTextBoxColumn.HeaderText = "Mã số";
            this.projectCodeDataGridViewTextBoxColumn.Name = "projectCodeDataGridViewTextBoxColumn";
            this.projectCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.projectCodeDataGridViewTextBoxColumn.Width = 120;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Tên";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 385;
            // 
            // projectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1088, 522);
            this.Controls.Add(this.findPnl);
            this.Controls.Add(this.dataGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "projectList";
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.projectTab, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.findPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.projectsSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projCommentSource)).EndInit();
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
        protected application.control.projectCriteria projectCriteria;
        protected System.Windows.Forms.Panel findPnl;
        protected System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
    }
}
