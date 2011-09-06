namespace baseClass.forms
{
    partial class strategyEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(strategyEdit));
            this.listGrid = new common.control.baseDataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strategySource = new System.Windows.Forms.BindingSource(this.components);
            this.codeLbl = new baseClass.controls.baseLabel();
            this.codeEd = new common.control.baseTextBox();
            this.descriptionEd = new common.control.baseTextBox();
            this.descriptionLbl = new baseClass.controls.baseLabel();
            this.weightLbl = new baseClass.controls.baseLabel();
            this.weightEd = new common.control.baseTextBox();
            this.categoryCb = new baseClass.controls.cbStrategyCat();
            this.categoryLbl = new baseClass.controls.baseLabel();
            this.noteEd = new common.control.baseTextBox();
            this.noteLbl = new baseClass.controls.baseLabel();
            this.indicatorSpecsEd = new common.control.baseTextBox();
            this.indicatorSpecsLbl = new baseClass.controls.baseLabel();
            this.indicatorSpecCheckBtn = new baseClass.controls.baseButton();
            this.enableChk = new baseClass.controls.baseCheckBox();
            this.StrategyTypesCb = new baseClass.controls.cbStrategyType();
            this.baseLabel1 = new baseClass.controls.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strategySource)).BeginInit();
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
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(78, 11);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.myToolTip.SetToolTip(this.saveBtn, "Lưu dữ liệu - [F2]");
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(148, 11);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(218, 11);
            this.editBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(8, 11);
            this.addNewBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
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
            this.listGrid.DataSource = this.strategySource;
            this.listGrid.Location = new System.Drawing.Point(421, -2);
            this.listGrid.Name = "listGrid";
            this.listGrid.ReadOnly = true;
            this.listGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listGrid.Size = new System.Drawing.Size(560, 511);
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
            // strategySource
            // 
            this.strategySource.DataMember = "strategy";
            this.strategySource.DataSource = this.myDataSet;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(24, 56);
            this.codeLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(58, 16);
            this.codeLbl.TabIndex = 165;
            this.codeLbl.Text = "Mã số *";
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.SystemColors.Window;
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.strategySource, "code", true));
            this.codeEd.Location = new System.Drawing.Point(24, 77);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(199, 22);
            this.codeEd.TabIndex = 1;
            this.codeEd.Validating += new System.ComponentModel.CancelEventHandler(this.codeEd_Validating);
            // 
            // descriptionEd
            // 
            this.descriptionEd.BackColor = System.Drawing.SystemColors.Window;
            this.descriptionEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.strategySource, "description", true));
            this.descriptionEd.Location = new System.Drawing.Point(24, 127);
            this.descriptionEd.Name = "descriptionEd";
            this.descriptionEd.Size = new System.Drawing.Size(372, 22);
            this.descriptionEd.TabIndex = 10;
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.Location = new System.Drawing.Point(24, 106);
            this.descriptionLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(43, 16);
            this.descriptionLbl.TabIndex = 164;
            this.descriptionLbl.Text = "Tên *";
            // 
            // weightLbl
            // 
            this.weightLbl.AutoSize = true;
            this.weightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightLbl.Location = new System.Drawing.Point(24, 432);
            this.weightLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.weightLbl.Name = "weightLbl";
            this.weightLbl.Size = new System.Drawing.Size(64, 16);
            this.weightLbl.TabIndex = 175;
            this.weightLbl.Text = "Trọng số";
            // 
            // weightEd
            // 
            this.weightEd.BackColor = System.Drawing.SystemColors.Window;
            this.weightEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.strategySource, "weight", true));
            this.weightEd.Location = new System.Drawing.Point(24, 453);
            this.weightEd.Name = "weightEd";
            this.weightEd.Size = new System.Drawing.Size(96, 22);
            this.weightEd.TabIndex = 50;
            // 
            // categoryCb
            // 
            this.categoryCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.strategySource, "catCode", true));
            this.categoryCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryCb.FormattingEnabled = true;
            this.categoryCb.Location = new System.Drawing.Point(24, 229);
            this.categoryCb.myValue = "";
            this.categoryCb.Name = "categoryCb";
            this.categoryCb.Size = new System.Drawing.Size(199, 24);
            this.categoryCb.TabIndex = 20;
            // 
            // categoryLbl
            // 
            this.categoryLbl.AutoSize = true;
            this.categoryLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLbl.Location = new System.Drawing.Point(24, 208);
            this.categoryLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.categoryLbl.Name = "categoryLbl";
            this.categoryLbl.Size = new System.Drawing.Size(51, 16);
            this.categoryLbl.TabIndex = 177;
            this.categoryLbl.Text = "Nhóm*";
            // 
            // noteEd
            // 
            this.noteEd.BackColor = System.Drawing.SystemColors.Window;
            this.noteEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.strategySource, "note", true));
            this.noteEd.Location = new System.Drawing.Point(24, 367);
            this.noteEd.Multiline = true;
            this.noteEd.Name = "noteEd";
            this.noteEd.Size = new System.Drawing.Size(372, 58);
            this.noteEd.TabIndex = 40;
            // 
            // noteLbl
            // 
            this.noteLbl.AutoSize = true;
            this.noteLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(24, 346);
            this.noteLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(54, 16);
            this.noteLbl.TabIndex = 179;
            this.noteLbl.Text = "Ghi chú";
            // 
            // indicatorSpecsEd
            // 
            this.indicatorSpecsEd.BackColor = System.Drawing.SystemColors.Window;
            this.indicatorSpecsEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.strategySource, "indicatorSpecs", true));
            this.indicatorSpecsEd.Location = new System.Drawing.Point(24, 281);
            this.indicatorSpecsEd.Multiline = true;
            this.indicatorSpecsEd.Name = "indicatorSpecsEd";
            this.indicatorSpecsEd.Size = new System.Drawing.Size(372, 58);
            this.indicatorSpecsEd.TabIndex = 30;
            // 
            // indicatorSpecsLbl
            // 
            this.indicatorSpecsLbl.AutoSize = true;
            this.indicatorSpecsLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indicatorSpecsLbl.Location = new System.Drawing.Point(24, 261);
            this.indicatorSpecsLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.indicatorSpecsLbl.Name = "indicatorSpecsLbl";
            this.indicatorSpecsLbl.Size = new System.Drawing.Size(188, 16);
            this.indicatorSpecsLbl.TabIndex = 181;
            this.indicatorSpecsLbl.Text = "Tham số  phân tích kỹ thuật";
            // 
            // indicatorSpecCheckBtn
            // 
            this.indicatorSpecCheckBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indicatorSpecCheckBtn.Image = global::baseClass.Properties.Resources.select;
            this.indicatorSpecCheckBtn.Location = new System.Drawing.Point(394, 281);
            this.indicatorSpecCheckBtn.Name = "indicatorSpecCheckBtn";
            this.indicatorSpecCheckBtn.Size = new System.Drawing.Size(25, 24);
            this.indicatorSpecCheckBtn.TabIndex = 31;
            this.indicatorSpecCheckBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.indicatorSpecCheckBtn.UseVisualStyleBackColor = true;
            this.indicatorSpecCheckBtn.Visible = false;
            // 
            // enableChk
            // 
            this.enableChk.AutoSize = true;
            this.enableChk.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.strategySource, "enabled", true));
            this.enableChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableChk.Location = new System.Drawing.Point(24, 485);
            this.enableChk.Name = "enableChk";
            this.enableChk.Size = new System.Drawing.Size(117, 20);
            this.enableChk.TabIndex = 60;
            this.enableChk.Text = "Đang sử dụng";
            this.enableChk.UseVisualStyleBackColor = true;
            // 
            // StrategyTypesCb
            // 
            this.StrategyTypesCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.strategySource, "type", true));
            this.StrategyTypesCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StrategyTypesCb.FormattingEnabled = true;
            this.StrategyTypesCb.Location = new System.Drawing.Point(24, 177);
            this.StrategyTypesCb.myValue = application.myTypes.StrategyTypes.Strategy;
            this.StrategyTypesCb.Name = "StrategyTypesCb";
            this.StrategyTypesCb.SelectedValue = ((byte)(0));
            this.StrategyTypesCb.Size = new System.Drawing.Size(199, 24);
            this.StrategyTypesCb.TabIndex = 11;
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel1.Location = new System.Drawing.Point(24, 158);
            this.baseLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(46, 16);
            this.baseLabel1.TabIndex = 183;
            this.baseLabel1.Text = "Lọai *";
            // 
            // strategyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 534);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.StrategyTypesCb);
            this.Controls.Add(this.enableChk);
            this.Controls.Add(this.indicatorSpecCheckBtn);
            this.Controls.Add(this.indicatorSpecsEd);
            this.Controls.Add(this.indicatorSpecsLbl);
            this.Controls.Add(this.noteEd);
            this.Controls.Add(this.noteLbl);
            this.Controls.Add(this.categoryLbl);
            this.Controls.Add(this.categoryCb);
            this.Controls.Add(this.weightLbl);
            this.Controls.Add(this.weightEd);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.codeEd);
            this.Controls.Add(this.descriptionEd);
            this.Controls.Add(this.descriptionLbl);
            this.Controls.Add(this.listGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "strategyEdit";
            this.Text = "Chien luoc / Strategy";
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.listGrid, 0);
            this.Controls.SetChildIndex(this.descriptionLbl, 0);
            this.Controls.SetChildIndex(this.descriptionEd, 0);
            this.Controls.SetChildIndex(this.codeEd, 0);
            this.Controls.SetChildIndex(this.codeLbl, 0);
            this.Controls.SetChildIndex(this.weightEd, 0);
            this.Controls.SetChildIndex(this.weightLbl, 0);
            this.Controls.SetChildIndex(this.categoryCb, 0);
            this.Controls.SetChildIndex(this.categoryLbl, 0);
            this.Controls.SetChildIndex(this.noteLbl, 0);
            this.Controls.SetChildIndex(this.noteEd, 0);
            this.Controls.SetChildIndex(this.indicatorSpecsLbl, 0);
            this.Controls.SetChildIndex(this.indicatorSpecsEd, 0);
            this.Controls.SetChildIndex(this.indicatorSpecCheckBtn, 0);
            this.Controls.SetChildIndex(this.enableChk, 0);
            this.Controls.SetChildIndex(this.StrategyTypesCb, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strategySource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private baseClass.controls.baseLabel codeLbl;
        private common.control.baseTextBox codeEd;
        private common.control.baseTextBox descriptionEd;
        private baseClass.controls.baseLabel descriptionLbl;
        private System.Windows.Forms.BindingSource strategySource;
        private baseClass.controls.baseLabel weightLbl;
        private common.control.baseTextBox weightEd;
        private common.control.baseDataGridView listGrid;
        private baseClass.controls.cbStrategyCat categoryCb;
        private baseClass.controls.baseLabel categoryLbl;
        private common.control.baseTextBox noteEd;
        private baseClass.controls.baseLabel noteLbl;
        private common.control.baseTextBox indicatorSpecsEd;
        private baseClass.controls.baseLabel indicatorSpecsLbl;
        protected baseClass.controls.baseButton indicatorSpecCheckBtn;
        private baseClass.controls.baseCheckBox enableChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private baseClass.controls.cbStrategyType StrategyTypesCb;
        private baseClass.controls.baseLabel baseLabel1;
    }
}