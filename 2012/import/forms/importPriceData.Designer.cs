namespace imports.forms
{
    partial class importPriceData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(importPriceData));
            this.dataFileLbl = new common.controls.baseLabel();
            this.dataFileNameEd = new common.controls.baseTextBox();
            this.stockExchangeLbl = new common.controls.baseLabel();
            this.cancelBtn = new common.controls.baseButton();
            this.closeBtn = new common.controls.baseButton();
            this.importBtn = new common.controls.baseButton();
            this.selectFileBtn = new common.controls.baseButton();
            this.myDataSet = new data.baseDS();
            this.stockExchangeCb = new baseClass.controls.cbStockExchange();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.viewLogBtn = new common.controls.baseButton();
            this.noteGb = new System.Windows.Forms.GroupBox();
            this.noteLbl = new baseClass.controls.baseLabel();
            this.actionCb = new common.controls.baseComboBox();
            this.actionLbl = new common.controls.baseLabel();
            this.baseLabel1 = new common.controls.baseLabel();
            this.importTypeCb = new common.controls.baseComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.noteGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(896, 91);
            this.TitleLbl.Visible = false;
            // 
            // dataFileLbl
            // 
            this.dataFileLbl.AutoSize = true;
            this.dataFileLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataFileLbl.Location = new System.Drawing.Point(20, 8);
            this.dataFileLbl.Name = "dataFileLbl";
            this.dataFileLbl.Size = new System.Drawing.Size(78, 16);
            this.dataFileLbl.TabIndex = 146;
            this.dataFileLbl.Text = "Tệp dữ liệu";
            // 
            // dataFileNameEd
            // 
            this.dataFileNameEd.isToUpperCase = false;
            this.dataFileNameEd.Location = new System.Drawing.Point(18, 27);
            this.dataFileNameEd.Name = "dataFileNameEd";
            this.dataFileNameEd.Size = new System.Drawing.Size(361, 23);
            this.dataFileNameEd.TabIndex = 1;
            // 
            // stockExchangeLbl
            // 
            this.stockExchangeLbl.AutoSize = true;
            this.stockExchangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockExchangeLbl.Location = new System.Drawing.Point(20, 102);
            this.stockExchangeLbl.Name = "stockExchangeLbl";
            this.stockExchangeLbl.Size = new System.Drawing.Size(243, 16);
            this.stockExchangeLbl.TabIndex = 149;
            this.stockExchangeLbl.Text = "Sàn giao dịch (dành cho các mã mới)";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Enabled = false;
            this.cancelBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Image = global::imports.Properties.Resources.remove;
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelBtn.isDownState = false;
            this.cancelBtn.Location = new System.Drawing.Point(111, 152);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(90, 30);
            this.cancelBtn.TabIndex = 31;
            this.cancelBtn.Text = "Dừng";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = global::imports.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.isDownState = false;
            this.closeBtn.Location = new System.Drawing.Point(291, 152);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(90, 30);
            this.closeBtn.TabIndex = 33;
            this.closeBtn.Text = "Đóng";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.Image = global::imports.Properties.Resources.select;
            this.importBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.importBtn.isDownState = false;
            this.importBtn.Location = new System.Drawing.Point(21, 152);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(90, 30);
            this.importBtn.TabIndex = 30;
            this.importBtn.Text = "Thực hiện";
            this.importBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // selectFileBtn
            // 
            this.selectFileBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFileBtn.Image = global::imports.Properties.Resources.open;
            this.selectFileBtn.isDownState = false;
            this.selectFileBtn.Location = new System.Drawing.Point(381, 27);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(23, 24);
            this.selectFileBtn.TabIndex = 2;
            this.selectFileBtn.UseVisualStyleBackColor = true;
            this.selectFileBtn.Click += new System.EventHandler(this.selectFileBtn_Click);
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stockExchangeCb
            // 
            this.stockExchangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockExchangeCb.FormattingEnabled = true;
            this.stockExchangeCb.Location = new System.Drawing.Point(20, 121);
            this.stockExchangeCb.myValue = "";
            this.stockExchangeCb.Name = "stockExchangeCb";
            this.stockExchangeCb.Size = new System.Drawing.Size(361, 24);
            this.stockExchangeCb.TabIndex = 20;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "CSV file|*.csv|All files|*.*";
            // 
            // viewLogBtn
            // 
            this.viewLogBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLogBtn.Image = global::imports.Properties.Resources.report;
            this.viewLogBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.viewLogBtn.isDownState = false;
            this.viewLogBtn.Location = new System.Drawing.Point(201, 152);
            this.viewLogBtn.Name = "viewLogBtn";
            this.viewLogBtn.Size = new System.Drawing.Size(90, 30);
            this.viewLogBtn.TabIndex = 32;
            this.viewLogBtn.Text = "Nhật ký";
            this.viewLogBtn.UseVisualStyleBackColor = true;
            this.viewLogBtn.Click += new System.EventHandler(this.viewLogBtn_Click);
            // 
            // noteGb
            // 
            this.noteGb.Controls.Add(this.noteLbl);
            this.noteGb.Location = new System.Drawing.Point(13, 187);
            this.noteGb.Name = "noteGb";
            this.noteGb.Size = new System.Drawing.Size(395, 38);
            this.noteGb.TabIndex = 150;
            this.noteGb.TabStop = false;
            // 
            // noteLbl
            // 
            this.noteLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.noteLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(1, 8);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(382, 26);
            this.noteLbl.TabIndex = 147;
            this.noteLbl.Text = "Cập nhật dữ liệu giá  từ tệp Excel vào hệ thống";
            this.noteLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // actionCb
            // 
            this.actionCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionCb.FormattingEnabled = true;
            this.actionCb.Items.AddRange(new object[] {
            "Import dữ liệu",
            "Tông hợp dữ liệu (Tuần,Tháng,Năm...)"});
            this.actionCb.Location = new System.Drawing.Point(18, 75);
            this.actionCb.myValue = "";
            this.actionCb.Name = "actionCb";
            this.actionCb.Size = new System.Drawing.Size(160, 24);
            this.actionCb.TabIndex = 3;
            this.actionCb.SelectionChangeCommitted += new System.EventHandler(this.actionCb_SelectionChangeCommitted);
            // 
            // actionLbl
            // 
            this.actionLbl.AutoSize = true;
            this.actionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionLbl.Location = new System.Drawing.Point(18, 57);
            this.actionLbl.Name = "actionLbl";
            this.actionLbl.Size = new System.Drawing.Size(64, 16);
            this.actionLbl.TabIndex = 152;
            this.actionLbl.Text = "Thao tác";
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel1.Location = new System.Drawing.Point(32, 101);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(78, 16);
            this.baseLabel1.TabIndex = 154;
            this.baseLabel1.Text = "Tệp dữ liệu";
            // 
            // importTypeCb
            // 
            this.importTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.importTypeCb.FormattingEnabled = true;
            this.importTypeCb.Items.AddRange(new object[] {
            "CP68  - YYYYMMDD",
            "Gold   - YYYYMMDDhhmmss"});
            this.importTypeCb.Location = new System.Drawing.Point(177, 75);
            this.importTypeCb.myValue = "";
            this.importTypeCb.Name = "importTypeCb";
            this.importTypeCb.Size = new System.Drawing.Size(202, 24);
            this.importTypeCb.TabIndex = 4;
            // 
            // importPriceData
            // 
            this.ClientSize = new System.Drawing.Size(410, 250);
            this.Controls.Add(this.importTypeCb);
            this.Controls.Add(this.actionLbl);
            this.Controls.Add(this.actionCb);
            this.Controls.Add(this.noteGb);
            this.Controls.Add(this.viewLogBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.stockExchangeLbl);
            this.Controls.Add(this.stockExchangeCb);
            this.Controls.Add(this.dataFileNameEd);
            this.Controls.Add(this.dataFileLbl);
            this.Controls.Add(this.selectFileBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "importPriceData";
            this.Text = "Nhap du lieu/Import";
            this.Controls.SetChildIndex(this.selectFileBtn, 0);
            this.Controls.SetChildIndex(this.dataFileLbl, 0);
            this.Controls.SetChildIndex(this.dataFileNameEd, 0);
            this.Controls.SetChildIndex(this.stockExchangeCb, 0);
            this.Controls.SetChildIndex(this.stockExchangeLbl, 0);
            this.Controls.SetChildIndex(this.importBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.cancelBtn, 0);
            this.Controls.SetChildIndex(this.viewLogBtn, 0);
            this.Controls.SetChildIndex(this.noteGb, 0);
            this.Controls.SetChildIndex(this.actionCb, 0);
            this.Controls.SetChildIndex(this.actionLbl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.importTypeCb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.noteGb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.controls.baseButton selectFileBtn;
        protected common.controls.baseLabel dataFileLbl;
        protected common.controls.baseTextBox dataFileNameEd;
        protected baseClass.controls.cbStockExchange stockExchangeCb;
        protected common.controls.baseLabel stockExchangeLbl;
        protected common.controls.baseButton importBtn;
        protected common.controls.baseButton closeBtn;
        protected common.controls.baseButton cancelBtn;
        protected data.baseDS myDataSet;
        protected System.Windows.Forms.OpenFileDialog openFileDialog;
        protected common.controls.baseButton viewLogBtn;
        private System.Windows.Forms.GroupBox noteGb;
        private baseClass.controls.baseLabel noteLbl;
        private common.controls.baseComboBox actionCb;
        protected common.controls.baseLabel actionLbl;
        protected common.controls.baseLabel baseLabel1;
        private common.controls.baseComboBox importTypeCb;

    }
}