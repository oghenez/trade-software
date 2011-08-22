namespace baseClass.forms
{
    partial class indicatorEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(indicatorEdit));
            this.listGrid = new common.control.baseDataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indicatorSource = new System.Windows.Forms.BindingSource(this.components);
            this.codeLbl = new baseClass.controls.baseLabel();
            this.codeEd = new common.control.baseTextBox();
            this.descriptionEd = new common.control.baseTextBox();
            this.descriptionLbl = new baseClass.controls.baseLabel();
            this.parameterLbl = new baseClass.controls.baseLabel();
            this.parameterEd = new common.control.baseTextBox();
            this.weightLbl = new baseClass.controls.baseLabel();
            this.weightEd = new common.control.baseTextBox();
            this.categoryCb = new baseClass.controls.cbIndicatorCat();
            this.categoryLbl = new baseClass.controls.baseLabel();
            this.noteEd = new common.control.baseTextBox();
            this.noteLbl = new baseClass.controls.baseLabel();
            this.enableChk = new baseClass.controls.baseCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicatorSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-10, -11);
            this.toolBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Size = new System.Drawing.Size(450, 57);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(358, 11);
            this.exitBtn.Size = new System.Drawing.Size(70, 39);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(78, 11);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.saveBtn.Size = new System.Drawing.Size(70, 39);
            this.myToolTip.SetToolTip(this.saveBtn, "Lưu dữ liệu - [F2]");
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(148, 11);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.deleteBtn.Size = new System.Drawing.Size(70, 39);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(218, 11);
            this.editBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.editBtn.Size = new System.Drawing.Size(70, 39);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(8, 11);
            this.addNewBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.addNewBtn.Size = new System.Drawing.Size(70, 39);
            this.myToolTip.SetToolTip(this.addNewBtn, "Thêm dữ liệu mới - [F3]");
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(560, 19);
            this.toExcelBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toExcelBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(462, 14);
            this.findBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(288, 11);
            this.reloadBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.reloadBtn.Size = new System.Drawing.Size(70, 39);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(466, 13);
            this.printBtn.Size = new System.Drawing.Size(64, 39);
            this.printBtn.Visible = false;
            // 
            // unLockBtn
            // 
            this.unLockBtn.Location = new System.Drawing.Point(742, 278);
            this.unLockBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.unLockBtn.Size = new System.Drawing.Size(34, 26);
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(723, 260);
            this.lockBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lockBtn.Size = new System.Drawing.Size(34, 26);
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(635, 163);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TitleLbl.Size = new System.Drawing.Size(307, 24);
            this.TitleLbl.TabIndex = 149;
            this.TitleLbl.Text = "THÔNG TIN NHÓM PHÂN LOẠI";
            // 
            // listGrid
            // 
            this.listGrid.AllowUserToAddRows = false;
            this.listGrid.AllowUserToDeleteRows = false;
            this.listGrid.AllowUserToOrderColumns = true;
            this.listGrid.AutoGenerateColumns = false;
            this.listGrid.ColumnHeadersHeight = 25;
            this.listGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.listGrid.DataSource = this.indicatorSource;
            this.listGrid.Location = new System.Drawing.Point(421, -2);
            this.listGrid.Name = "listGrid";
            this.listGrid.ReadOnly = true;
            this.listGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listGrid.Size = new System.Drawing.Size(561, 512);
            this.listGrid.TabIndex = 153;
            this.listGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.listGrid_DataError);
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Mã số";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 150;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Tên";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 350;
            // 
            // indicatorSource
            // 
            this.indicatorSource.DataMember = "indicator";
            this.indicatorSource.DataSource = this.myDataSet;
            this.indicatorSource.CurrentChanged += new System.EventHandler(this.indicatorSource_CurrentChanged);
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(24, 66);
            this.codeLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(58, 16);
            this.codeLbl.TabIndex = 165;
            this.codeLbl.Text = "Mã số *";
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.SystemColors.Window;
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.indicatorSource, "code", true));
            this.codeEd.Location = new System.Drawing.Point(24, 85);
            this.codeEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(199, 22);
            this.codeEd.TabIndex = 1;
            this.codeEd.Validating += new System.ComponentModel.CancelEventHandler(this.codeEd_Validating);
            // 
            // descriptionEd
            // 
            this.descriptionEd.BackColor = System.Drawing.SystemColors.Window;
            this.descriptionEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.indicatorSource, "description", true));
            this.descriptionEd.Location = new System.Drawing.Point(24, 133);
            this.descriptionEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.descriptionEd.Name = "descriptionEd";
            this.descriptionEd.Size = new System.Drawing.Size(372, 22);
            this.descriptionEd.TabIndex = 10;
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.Location = new System.Drawing.Point(24, 114);
            this.descriptionLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(43, 16);
            this.descriptionLbl.TabIndex = 164;
            this.descriptionLbl.Text = "Tên *";
            // 
            // parameterLbl
            // 
            this.parameterLbl.AutoSize = true;
            this.parameterLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parameterLbl.Location = new System.Drawing.Point(24, 162);
            this.parameterLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.parameterLbl.Name = "parameterLbl";
            this.parameterLbl.Size = new System.Drawing.Size(74, 16);
            this.parameterLbl.TabIndex = 169;
            this.parameterLbl.Text = "Thông số  ";
            // 
            // parameterEd
            // 
            this.parameterEd.BackColor = System.Drawing.SystemColors.Window;
            this.parameterEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.indicatorSource, "parameter", true));
            this.parameterEd.Location = new System.Drawing.Point(24, 181);
            this.parameterEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.parameterEd.Multiline = true;
            this.parameterEd.Name = "parameterEd";
            this.parameterEd.Size = new System.Drawing.Size(372, 52);
            this.parameterEd.TabIndex = 20;
            // 
            // weightLbl
            // 
            this.weightLbl.AutoSize = true;
            this.weightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightLbl.Location = new System.Drawing.Point(24, 291);
            this.weightLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.weightLbl.Name = "weightLbl";
            this.weightLbl.Size = new System.Drawing.Size(64, 16);
            this.weightLbl.TabIndex = 175;
            this.weightLbl.Text = "Trọng số";
            // 
            // weightEd
            // 
            this.weightEd.BackColor = System.Drawing.SystemColors.Window;
            this.weightEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.indicatorSource, "weight", true));
            this.weightEd.Location = new System.Drawing.Point(24, 310);
            this.weightEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.weightEd.Name = "weightEd";
            this.weightEd.Size = new System.Drawing.Size(96, 22);
            this.weightEd.TabIndex = 40;
            // 
            // categoryCb
            // 
            this.categoryCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.indicatorSource, "catCode", true));
            this.categoryCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryCb.FormattingEnabled = true;
            this.categoryCb.Location = new System.Drawing.Point(24, 259);
            this.categoryCb.myValue = "";
            this.categoryCb.Name = "categoryCb";
            this.categoryCb.Size = new System.Drawing.Size(199, 24);
            this.categoryCb.TabIndex = 30;
            // 
            // categoryLbl
            // 
            this.categoryLbl.AutoSize = true;
            this.categoryLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLbl.Location = new System.Drawing.Point(24, 240);
            this.categoryLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.categoryLbl.Name = "categoryLbl";
            this.categoryLbl.Size = new System.Drawing.Size(66, 16);
            this.categoryLbl.TabIndex = 177;
            this.categoryLbl.Text = "Phân lọai";
            // 
            // noteEd
            // 
            this.noteEd.BackColor = System.Drawing.SystemColors.Window;
            this.noteEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.indicatorSource, "notes", true));
            this.noteEd.Location = new System.Drawing.Point(24, 361);
            this.noteEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.noteEd.Multiline = true;
            this.noteEd.Name = "noteEd";
            this.noteEd.Size = new System.Drawing.Size(372, 111);
            this.noteEd.TabIndex = 50;
            // 
            // noteLbl
            // 
            this.noteLbl.AutoSize = true;
            this.noteLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(24, 341);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(54, 16);
            this.noteLbl.TabIndex = 179;
            this.noteLbl.Text = "Ghi chú";
            // 
            // enableChk
            // 
            this.enableChk.AutoSize = true;
            this.enableChk.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.indicatorSource, "enabled", true));
            this.enableChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableChk.Location = new System.Drawing.Point(26, 484);
            this.enableChk.Name = "enableChk";
            this.enableChk.Size = new System.Drawing.Size(80, 20);
            this.enableChk.TabIndex = 51;
            this.enableChk.Text = "Sử dụng";
            this.enableChk.UseVisualStyleBackColor = true;
            // 
            // indicatorEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 534);
            this.Controls.Add(this.enableChk);
            this.Controls.Add(this.noteLbl);
            this.Controls.Add(this.noteEd);
            this.Controls.Add(this.categoryLbl);
            this.Controls.Add(this.categoryCb);
            this.Controls.Add(this.weightLbl);
            this.Controls.Add(this.weightEd);
            this.Controls.Add(this.parameterLbl);
            this.Controls.Add(this.parameterEd);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.codeEd);
            this.Controls.Add(this.descriptionEd);
            this.Controls.Add(this.descriptionLbl);
            this.Controls.Add(this.listGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "indicatorEdit";
            this.Text = "Chi so / Indicator";
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.listGrid, 0);
            this.Controls.SetChildIndex(this.descriptionLbl, 0);
            this.Controls.SetChildIndex(this.descriptionEd, 0);
            this.Controls.SetChildIndex(this.codeEd, 0);
            this.Controls.SetChildIndex(this.codeLbl, 0);
            this.Controls.SetChildIndex(this.parameterEd, 0);
            this.Controls.SetChildIndex(this.parameterLbl, 0);
            this.Controls.SetChildIndex(this.weightEd, 0);
            this.Controls.SetChildIndex(this.weightLbl, 0);
            this.Controls.SetChildIndex(this.categoryCb, 0);
            this.Controls.SetChildIndex(this.categoryLbl, 0);
            this.Controls.SetChildIndex(this.noteEd, 0);
            this.Controls.SetChildIndex(this.noteLbl, 0);
            this.Controls.SetChildIndex(this.enableChk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicatorSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private baseClass.controls.baseLabel codeLbl;
        private common.control.baseTextBox codeEd;
        private common.control.baseTextBox descriptionEd;
        private baseClass.controls.baseLabel descriptionLbl;
        private System.Windows.Forms.BindingSource indicatorSource;
        private baseClass.controls.baseLabel parameterLbl;
        private common.control.baseTextBox parameterEd;
        private baseClass.controls.baseLabel weightLbl;
        private common.control.baseTextBox weightEd;
        private common.control.baseDataGridView listGrid;
        private baseClass.controls.cbIndicatorCat categoryCb;
        private baseClass.controls.baseLabel categoryLbl;
        private common.control.baseTextBox noteEd;
        private baseClass.controls.baseLabel noteLbl;
        private baseClass.controls.baseCheckBox enableChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
    }
}