namespace baseClass.forms
{
    partial class stockExchangeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stockExchangeEdit));
            this.listGrid = new common.controls.baseDataGridView();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockExchangeSource = new System.Windows.Forms.BindingSource(this.components);
            this.codeLbl = new baseClass.controls.baseLabel();
            this.codeEd = new common.controls.baseTextBox();
            this.nameEd = new common.controls.baseTextBox();
            this.nameLbl = new baseClass.controls.baseLabel();
            this.weightLbl = new baseClass.controls.baseLabel();
            this.weightEd = new common.controls.baseTextBox();
            this.countryCb = new baseClass.controls.cbCountry();
            this.countryLbl = new baseClass.controls.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockExchangeSource)).BeginInit();
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
            this.exitBtn.Text = "Close";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(78, 11);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.saveBtn.Text = "Save";
            this.myToolTip.SetToolTip(this.saveBtn, "Lưu dữ liệu - [F2]");
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(148, 11);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(218, 11);
            this.editBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.editBtn.Text = "Lock";
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
            this.toExcelBtn.Text = "Export";
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
            this.printBtn.Text = "&Print";
            this.printBtn.Visible = false;
            // 
            // unLockBtn
            // 
            this.unLockBtn.Location = new System.Drawing.Point(742, 327);
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
            this.codeColumn,
            this.nameColumn});
            this.listGrid.DataSource = this.stockExchangeSource;
            this.listGrid.DisableReadOnlyColumn = true;
            this.listGrid.Location = new System.Drawing.Point(422, -1);
            this.listGrid.Name = "listGrid";
            this.listGrid.ReadOnly = true;
            this.listGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listGrid.Size = new System.Drawing.Size(431, 287);
            this.listGrid.TabIndex = 153;
            this.listGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.listGrid_DataError);
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "code";
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            this.codeColumn.Width = 120;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "description";
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 250;
            // 
            // stockExchangeSource
            // 
            this.stockExchangeSource.DataMember = "stockExchange";
            this.stockExchangeSource.DataSource = this.myDataSet;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(28, 65);
            this.codeLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(52, 16);
            this.codeLbl.TabIndex = 165;
            this.codeLbl.Text = "Code *";
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.SystemColors.Window;
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "code", true));
            this.codeEd.Location = new System.Drawing.Point(28, 86);
            this.codeEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(132, 23);
            this.codeEd.TabIndex = 1;
            this.codeEd.Validating += new System.ComponentModel.CancelEventHandler(this.codeEd_Validating);
            // 
            // nameEd
            // 
            this.nameEd.BackColor = System.Drawing.SystemColors.Window;
            this.nameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "description", true));
            this.nameEd.Location = new System.Drawing.Point(28, 137);
            this.nameEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.nameEd.Name = "nameEd";
            this.nameEd.Size = new System.Drawing.Size(372, 23);
            this.nameEd.TabIndex = 10;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(28, 116);
            this.nameLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(55, 16);
            this.nameLbl.TabIndex = 164;
            this.nameLbl.Text = "Name *";
            // 
            // weightLbl
            // 
            this.weightLbl.AutoSize = true;
            this.weightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightLbl.Location = new System.Drawing.Point(28, 220);
            this.weightLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.weightLbl.Name = "weightLbl";
            this.weightLbl.Size = new System.Drawing.Size(54, 16);
            this.weightLbl.TabIndex = 175;
            this.weightLbl.Text = "Weight";
            // 
            // weightEd
            // 
            this.weightEd.BackColor = System.Drawing.SystemColors.Window;
            this.weightEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "weight", true));
            this.weightEd.Location = new System.Drawing.Point(28, 241);
            this.weightEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.weightEd.Name = "weightEd";
            this.weightEd.Size = new System.Drawing.Size(96, 23);
            this.weightEd.TabIndex = 40;
            // 
            // countryCb
            // 
            this.countryCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.stockExchangeSource, "country", true));
            this.countryCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryCb.FormattingEnabled = true;
            this.countryCb.Location = new System.Drawing.Point(28, 188);
            this.countryCb.myValue = "";
            this.countryCb.Name = "countryCb";
            this.countryCb.Size = new System.Drawing.Size(372, 24);
            this.countryCb.TabIndex = 20;
            // 
            // countryLbl
            // 
            this.countryLbl.AutoSize = true;
            this.countryLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLbl.Location = new System.Drawing.Point(28, 167);
            this.countryLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.countryLbl.Name = "countryLbl";
            this.countryLbl.Size = new System.Drawing.Size(76, 16);
            this.countryLbl.TabIndex = 177;
            this.countryLbl.Text = "Country  *";
            // 
            // stockExchangeEdit
            // 
            this.ClientSize = new System.Drawing.Size(852, 314);
            this.Controls.Add(this.countryLbl);
            this.Controls.Add(this.countryCb);
            this.Controls.Add(this.weightLbl);
            this.Controls.Add(this.weightEd);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.codeEd);
            this.Controls.Add(this.nameEd);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.listGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "stockExchangeEdit";
            this.Text = "Stock Exchange";
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.listGrid, 0);
            this.Controls.SetChildIndex(this.nameLbl, 0);
            this.Controls.SetChildIndex(this.nameEd, 0);
            this.Controls.SetChildIndex(this.codeEd, 0);
            this.Controls.SetChildIndex(this.codeLbl, 0);
            this.Controls.SetChildIndex(this.weightEd, 0);
            this.Controls.SetChildIndex(this.weightLbl, 0);
            this.Controls.SetChildIndex(this.countryCb, 0);
            this.Controls.SetChildIndex(this.countryLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockExchangeSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private baseClass.controls.baseLabel codeLbl;
        private common.controls.baseTextBox codeEd;
        private common.controls.baseTextBox nameEd;
        private baseClass.controls.baseLabel nameLbl;
        private System.Windows.Forms.BindingSource stockExchangeSource;
        private baseClass.controls.baseLabel weightLbl;
        private common.controls.baseTextBox weightEd;
        private common.controls.baseDataGridView listGrid;
        private baseClass.controls.baseLabel countryLbl;
        private baseClass.controls.cbCountry countryCb;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
    }
}