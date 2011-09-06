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
            this.dataFileLbl = new common.control.baseLabel();
            this.dataFileNameEd = new common.control.baseTextBox();
            this.stockExchangeLbl = new common.control.baseLabel();
            this.cancelBtn = new common.control.baseButton();
            this.closeBtn = new common.control.baseButton();
            this.importBtn = new common.control.baseButton();
            this.selectFileBtn = new common.control.baseButton();
            this.myDataSet = new data.baseDS();
            this.stockExchangeCb = new baseClass.controls.cbStockExchange();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.viewLogBtn = new common.control.baseButton();
            this.noteGb = new System.Windows.Forms.GroupBox();
            this.noteLbl = new baseClass.controls.baseLabel();
            this.actionCb = new common.control.baseComboBox();
            this.actionLbl = new common.control.baseLabel();
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
            this.dataFileLbl.Location = new System.Drawing.Point(29, 55);
            this.dataFileLbl.Name = "dataFileLbl";
            this.dataFileLbl.Size = new System.Drawing.Size(78, 16);
            this.dataFileLbl.TabIndex = 146;
            this.dataFileLbl.Text = "Tệp dữ liệu";
            // 
            // dataFileNameEd
            // 
            this.dataFileNameEd.Location = new System.Drawing.Point(32, 74);
            this.dataFileNameEd.Name = "dataFileNameEd";
            this.dataFileNameEd.Size = new System.Drawing.Size(306, 22);
            this.dataFileNameEd.TabIndex = 2;
            // 
            // stockExchangeLbl
            // 
            this.stockExchangeLbl.AutoSize = true;
            this.stockExchangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockExchangeLbl.Location = new System.Drawing.Point(29, 105);
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
            this.cancelBtn.Location = new System.Drawing.Point(124, 155);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(68, 30);
            this.cancelBtn.TabIndex = 21;
            this.cancelBtn.Text = "Dừng";
            this.cancelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = global::imports.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.isDownState = false;
            this.closeBtn.Location = new System.Drawing.Point(269, 155);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(68, 30);
            this.closeBtn.TabIndex = 23;
            this.closeBtn.Text = "Đóng";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.Image = global::imports.Properties.Resources.select;
            this.importBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.importBtn.isDownState = false;
            this.importBtn.Location = new System.Drawing.Point(33, 155);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(91, 30);
            this.importBtn.TabIndex = 20;
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
            this.selectFileBtn.Location = new System.Drawing.Point(339, 74);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(22, 21);
            this.selectFileBtn.TabIndex = 3;
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
            this.stockExchangeCb.Location = new System.Drawing.Point(32, 124);
            this.stockExchangeCb.myValue = "";
            this.stockExchangeCb.Name = "stockExchangeCb";
            this.stockExchangeCb.Size = new System.Drawing.Size(306, 24);
            this.stockExchangeCb.TabIndex = 10;
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
            this.viewLogBtn.Location = new System.Drawing.Point(192, 155);
            this.viewLogBtn.Name = "viewLogBtn";
            this.viewLogBtn.Size = new System.Drawing.Size(77, 30);
            this.viewLogBtn.TabIndex = 22;
            this.viewLogBtn.Text = "Nhật ký";
            this.viewLogBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewLogBtn.UseVisualStyleBackColor = true;
            this.viewLogBtn.Click += new System.EventHandler(this.viewLogBtn_Click);
            // 
            // noteGb
            // 
            this.noteGb.Controls.Add(this.noteLbl);
            this.noteGb.Location = new System.Drawing.Point(17, 184);
            this.noteGb.Name = "noteGb";
            this.noteGb.Size = new System.Drawing.Size(335, 38);
            this.noteGb.TabIndex = 150;
            this.noteGb.TabStop = false;
            // 
            // noteLbl
            // 
            this.noteLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.noteLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(1, 9);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(322, 26);
            this.noteLbl.TabIndex = 147;
            this.noteLbl.Text = "Cập nhật dữ liệu giá  từ tệp Excel vào hệ thống";
            this.noteLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // actionCb
            // 
            this.actionCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionCb.FormattingEnabled = true;
            this.actionCb.Items.AddRange(new object[] {
            "Import + Tổng hợp dữ liệu",
            "Import dữ liệu",
            "Tông hợp dữ liệu (Tuần,Tháng,Năm...)"});
            this.actionCb.Location = new System.Drawing.Point(32, 23);
            this.actionCb.myValue = "";
            this.actionCb.Name = "actionCb";
            this.actionCb.Size = new System.Drawing.Size(305, 24);
            this.actionCb.TabIndex = 1;
            this.actionCb.SelectionChangeCommitted += new System.EventHandler(this.actionCb_SelectionChangeCommitted);
            // 
            // actionLbl
            // 
            this.actionLbl.AutoSize = true;
            this.actionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionLbl.Location = new System.Drawing.Point(32, 5);
            this.actionLbl.Name = "actionLbl";
            this.actionLbl.Size = new System.Drawing.Size(64, 16);
            this.actionLbl.TabIndex = 152;
            this.actionLbl.Text = "Thao tác";
            // 
            // importPriceData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 250);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "importPriceData";
            this.Text = "Nhap du lieu/Import";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.noteGb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseButton selectFileBtn;
        protected common.control.baseLabel dataFileLbl;
        protected common.control.baseTextBox dataFileNameEd;
        protected baseClass.controls.cbStockExchange stockExchangeCb;
        protected common.control.baseLabel stockExchangeLbl;
        protected common.control.baseButton importBtn;
        protected common.control.baseButton closeBtn;
        protected common.control.baseButton cancelBtn;
        protected data.baseDS myDataSet;
        protected System.Windows.Forms.OpenFileDialog openFileDialog;
        protected common.control.baseButton viewLogBtn;
        private System.Windows.Forms.GroupBox noteGb;
        private baseClass.controls.baseLabel noteLbl;
        private common.control.baseComboBox actionCb;
        protected common.control.baseLabel actionLbl;

    }
}