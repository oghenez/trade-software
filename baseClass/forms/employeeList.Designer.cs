namespace baseClass.forms
{
    partial class employeeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(employeeList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.findPnl = new System.Windows.Forms.Panel();
            this.filterBtn = new baseClass.controls.baseButton();
            this.closeFindBtn = new baseClass.controls.baseButton();
            this.employeeCriteria = new application.control.employeeCriteria();
            this.emCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dobDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.employeeSource)).BeginInit();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Info)).BeginInit();
            this.xpGroup_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Education)).BeginInit();
            this.xpGroup_Education.SuspendLayout();
            this.xpPanel_General.SuspendLayout();
            this.xpPanel_Private.SuspendLayout();
            this.xpPanel_Work.SuspendLayout();
            this.xpPanel_Identity.SuspendLayout();
            this.xpPanel_Edu_Cerificate.SuspendLayout();
            this.xpPanel_Edu_Language.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Profile)).BeginInit();
            this.xpGroup_Profile.SuspendLayout();
            this.xpPanel_WorkHistory.SuspendLayout();
            this.xpPanel_Relatives.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_WorkReward)).BeginInit();
            this.xpGroup_WorkReward.SuspendLayout();
            this.xpPanel_Reward.SuspendLayout();
            this.xpPanel_Punishment.SuspendLayout();
            this.xpPanel_Emergency.SuspendLayout();
            this.xpPanel_emDocFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Leave)).BeginInit();
            this.xpGroup_Leave.SuspendLayout();
            this.xpPanel_Leave.SuspendLayout();
            this.leavePg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.findPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpPanel_General
            // 
            this.xpPanel_General.ImageItems.ImageSet = null;
            this.xpPanel_General.Size = new System.Drawing.Size(493, 322);
            // 
            // xpPanel_Private
            // 
            this.xpPanel_Private.ImageItems.ImageSet = null;
            this.xpPanel_Private.Size = new System.Drawing.Size(493, 384);
            // 
            // xpPanel_Work
            // 
            this.xpPanel_Work.ImageItems.ImageSet = null;
            this.xpPanel_Work.Size = new System.Drawing.Size(493, 201);
            // 
            // xpPanel_Identity
            // 
            this.xpPanel_Identity.ImageItems.ImageSet = null;
            this.xpPanel_Identity.Size = new System.Drawing.Size(493, 420);
            // 
            // xpPanel_Edu_Cerificate
            // 
            this.xpPanel_Edu_Cerificate.ImageItems.ImageSet = null;
            this.xpPanel_Edu_Cerificate.Size = new System.Drawing.Size(493, 453);
            // 
            // xpPanel_Edu_Language
            // 
            this.xpPanel_Edu_Language.ImageItems.ImageSet = null;
            this.xpPanel_Edu_Language.Size = new System.Drawing.Size(493, 318);
            // 
            // xpPanel_WorkHistory
            // 
            this.xpPanel_WorkHistory.ImageItems.ImageSet = null;
            this.xpPanel_WorkHistory.Size = new System.Drawing.Size(493, 506);
            // 
            // xpPanel_Relatives
            // 
            this.xpPanel_Relatives.ImageItems.ImageSet = null;
            this.xpPanel_Relatives.Size = new System.Drawing.Size(493, 378);
            // 
            // xpPanel_Reward
            // 
            this.xpPanel_Reward.ImageItems.ImageSet = null;
            this.xpPanel_Reward.Size = new System.Drawing.Size(493, 509);
            // 
            // xpPanel_Punishment
            // 
            this.xpPanel_Punishment.ImageItems.ImageSet = null;
            this.xpPanel_Punishment.Size = new System.Drawing.Size(493, 494);
            // 
            // xpPanel_Emergency
            // 
            this.xpPanel_Emergency.ImageItems.ImageSet = null;
            this.xpPanel_Emergency.Size = new System.Drawing.Size(493, 304);
            // 
            // xpPanel_emDocFile
            // 
            this.xpPanel_emDocFile.ImageItems.ImageSet = null;
            this.xpPanel_emDocFile.Size = new System.Drawing.Size(493, 418);
            // 
            // xpPanel_Leave
            // 
            this.xpPanel_Leave.ImageItems.ImageSet = null;
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-14, -10);
            this.toolBox.Size = new System.Drawing.Size(573, 53);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(461, 11);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(77, 11);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(141, 11);
            this.editBtn.Text = "&Khóa";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(13, 11);
            this.addNewBtn.Visible = true;
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(397, 11);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(205, 11);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(269, 11);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(333, 11);
            // 
            // dataGrid
            // 
            this.dataGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.emCodeDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.dobDataGridViewTextBoxColumn,
            this.cardIdDataGridViewTextBoxColumn});
            this.dataGrid.DataSource = this.employeeSource;
            this.dataGrid.Location = new System.Drawing.Point(512, -1);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(471, 600);
            this.dataGrid.TabIndex = 231;
            // 
            // findPnl
            // 
            this.findPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.findPnl.Controls.Add(this.filterBtn);
            this.findPnl.Controls.Add(this.closeFindBtn);
            this.findPnl.Controls.Add(this.employeeCriteria);
            this.findPnl.Location = new System.Drawing.Point(512, 324);
            this.findPnl.Name = "findPnl";
            this.findPnl.Size = new System.Drawing.Size(471, 275);
            this.findPnl.TabIndex = 240;
            // 
            // filterBtn
            // 
            this.filterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtn.Image = global::baseClass.Properties.Resources.filter;
            this.filterBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.filterBtn.Location = new System.Drawing.Point(320, 247);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(52, 25);
            this.filterBtn.TabIndex = 10;
            this.filterBtn.Text = "Lọc";
            this.filterBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // closeFindBtn
            // 
            this.closeFindBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeFindBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeFindBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeFindBtn.Location = new System.Drawing.Point(380, 247);
            this.closeFindBtn.Name = "closeFindBtn";
            this.closeFindBtn.Size = new System.Drawing.Size(64, 25);
            this.closeFindBtn.TabIndex = 11;
            this.closeFindBtn.Text = "Đóng";
            this.closeFindBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeFindBtn.UseVisualStyleBackColor = true;
            this.closeFindBtn.Click += new System.EventHandler(this.closeFindBtn_Click);
            // 
            // employeeCriteria
            // 
            this.employeeCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeCriteria.Location = new System.Drawing.Point(-3, -1);
            this.employeeCriteria.Margin = new System.Windows.Forms.Padding(0);
            this.employeeCriteria.Name = "employeeCriteria";
            this.employeeCriteria.Size = new System.Drawing.Size(471, 246);
            this.employeeCriteria.TabIndex = 1;
            // 
            // emCodeDataGridViewTextBoxColumn
            // 
            this.emCodeDataGridViewTextBoxColumn.DataPropertyName = "emCode";
            this.emCodeDataGridViewTextBoxColumn.HeaderText = "Mã số";
            this.emCodeDataGridViewTextBoxColumn.Name = "emCodeDataGridViewTextBoxColumn";
            this.emCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.emCodeDataGridViewTextBoxColumn.Width = 120;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "fullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "Họ và tên";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fullNameDataGridViewTextBoxColumn.Width = 210;
            // 
            // dobDataGridViewTextBoxColumn
            // 
            this.dobDataGridViewTextBoxColumn.DataPropertyName = "dob";
            this.dobDataGridViewTextBoxColumn.HeaderText = "Ngày.sinh";
            this.dobDataGridViewTextBoxColumn.Name = "dobDataGridViewTextBoxColumn";
            this.dobDataGridViewTextBoxColumn.ReadOnly = true;
            this.dobDataGridViewTextBoxColumn.Width = 80;
            // 
            // cardIdDataGridViewTextBoxColumn
            // 
            this.cardIdDataGridViewTextBoxColumn.DataPropertyName = "cardId";
            this.cardIdDataGridViewTextBoxColumn.HeaderText = "Số CMND";
            this.cardIdDataGridViewTextBoxColumn.Name = "cardIdDataGridViewTextBoxColumn";
            this.cardIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.cardIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // employeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(982, 627);
            this.Controls.Add(this.findPnl);
            this.Controls.Add(this.dataGrid);
            this.Name = "employeeList";
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.tabMain, 0);
            this.Controls.SetChildIndex(this.findPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.employeeSource)).EndInit();
            this.tabMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Info)).EndInit();
            this.xpGroup_Info.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Education)).EndInit();
            this.xpGroup_Education.ResumeLayout(false);
            this.xpPanel_General.ResumeLayout(false);
            this.xpPanel_Private.ResumeLayout(false);
            this.xpPanel_Work.ResumeLayout(false);
            this.xpPanel_Identity.ResumeLayout(false);
            this.xpPanel_Edu_Cerificate.ResumeLayout(false);
            this.xpPanel_Edu_Language.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Profile)).EndInit();
            this.xpGroup_Profile.ResumeLayout(false);
            this.xpPanel_WorkHistory.ResumeLayout(false);
            this.xpPanel_Relatives.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_WorkReward)).EndInit();
            this.xpGroup_WorkReward.ResumeLayout(false);
            this.xpPanel_Reward.ResumeLayout(false);
            this.xpPanel_Punishment.ResumeLayout(false);
            this.xpPanel_Emergency.ResumeLayout(false);
            this.xpPanel_emDocFile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Leave)).EndInit();
            this.xpGroup_Leave.ResumeLayout(false);
            this.xpPanel_Leave.ResumeLayout(false);
            this.leavePg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.findPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel findPnl;
        protected baseClass.controls.baseButton filterBtn;
        protected baseClass.controls.baseButton closeFindBtn;
        protected application.control.employeeCriteria employeeCriteria;
        protected System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn emCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dobDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardIdDataGridViewTextBoxColumn;
    }
}
