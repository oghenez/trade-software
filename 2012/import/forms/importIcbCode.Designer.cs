namespace imports.forms
{
    partial class importIcbCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(importIcbCode));
            this.dataFileLbl = new common.controls.baseLabel();
            this.dataFileNameEd = new common.controls.baseTextBox();
            this.closeBtn = new common.controls.baseButton();
            this.importBtn = new common.controls.baseButton();
            this.selectFileBtn = new common.controls.baseButton();
            this.myDataSet = new databases.baseDS();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.sheetNameEd = new common.controls.baseTextBox();
            this.sheetNameLbl = new common.controls.baseLabel();
            this.sysCodeCatEd = new common.controls.baseTextBox();
            this.sysCodeCatLbl = new common.controls.baseLabel();
            this.viewLogBtn = new common.controls.baseButton();
            this.noteGb = new System.Windows.Forms.GroupBox();
            this.noteLbl = new baseClass.controls.baseLabel();
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
            this.dataFileLbl.Location = new System.Drawing.Point(39, 12);
            this.dataFileLbl.Name = "dataFileLbl";
            this.dataFileLbl.Size = new System.Drawing.Size(78, 16);
            this.dataFileLbl.TabIndex = 146;
            this.dataFileLbl.Text = "Tệp dữ liệu";
            // 
            // dataFileNameEd
            // 
            this.dataFileNameEd.Location = new System.Drawing.Point(42, 31);
            this.dataFileNameEd.Name = "dataFileNameEd";
            this.dataFileNameEd.Size = new System.Drawing.Size(333, 22);
            this.dataFileNameEd.TabIndex = 1;
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = global::imports.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.isDownState = false;
            this.closeBtn.Location = new System.Drawing.Point(307, 106);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(68, 30);
            this.closeBtn.TabIndex = 22;
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
            this.importBtn.Location = new System.Drawing.Point(139, 106);
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
            this.selectFileBtn.Location = new System.Drawing.Point(376, 32);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(22, 21);
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
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel|*.xls|All files|*.*";
            // 
            // sheetNameEd
            // 
            this.sheetNameEd.Location = new System.Drawing.Point(43, 76);
            this.sheetNameEd.Name = "sheetNameEd";
            this.sheetNameEd.Size = new System.Drawing.Size(166, 22);
            this.sheetNameEd.TabIndex = 2;
            this.sheetNameEd.Text = "list";
            // 
            // sheetNameLbl
            // 
            this.sheetNameLbl.AutoSize = true;
            this.sheetNameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheetNameLbl.Location = new System.Drawing.Point(40, 56);
            this.sheetNameLbl.Name = "sheetNameLbl";
            this.sheetNameLbl.Size = new System.Drawing.Size(120, 16);
            this.sheetNameLbl.TabIndex = 151;
            this.sheetNameLbl.Text = "Tên bảng (sheet)";
            // 
            // sysCodeCatEd
            // 
            this.sysCodeCatEd.Location = new System.Drawing.Point(209, 76);
            this.sysCodeCatEd.Name = "sysCodeCatEd";
            this.sysCodeCatEd.Size = new System.Drawing.Size(166, 22);
            this.sysCodeCatEd.TabIndex = 10;
            this.sysCodeCatEd.Text = "BIZCODE_ICB";
            // 
            // sysCodeCatLbl
            // 
            this.sysCodeCatLbl.AutoSize = true;
            this.sysCodeCatLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sysCodeCatLbl.Location = new System.Drawing.Point(210, 57);
            this.sysCodeCatLbl.Name = "sysCodeCatLbl";
            this.sysCodeCatLbl.Size = new System.Drawing.Size(89, 16);
            this.sysCodeCatLbl.TabIndex = 153;
            this.sysCodeCatLbl.Text = "Mã phân lọai";
            // 
            // viewLogBtn
            // 
            this.viewLogBtn.Enabled = false;
            this.viewLogBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLogBtn.Image = global::imports.Properties.Resources.report;
            this.viewLogBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.viewLogBtn.isDownState = false;
            this.viewLogBtn.Location = new System.Drawing.Point(230, 106);
            this.viewLogBtn.Name = "viewLogBtn";
            this.viewLogBtn.Size = new System.Drawing.Size(77, 30);
            this.viewLogBtn.TabIndex = 21;
            this.viewLogBtn.Text = "Nhật ký";
            this.viewLogBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewLogBtn.UseVisualStyleBackColor = true;
            this.viewLogBtn.Click += new System.EventHandler(this.viewLogBtn_Click);
            // 
            // noteGb
            // 
            this.noteGb.Controls.Add(this.noteLbl);
            this.noteGb.Location = new System.Drawing.Point(29, 139);
            this.noteGb.Name = "noteGb";
            this.noteGb.Size = new System.Drawing.Size(362, 42);
            this.noteGb.TabIndex = 154;
            this.noteGb.TabStop = false;
            // 
            // noteLbl
            // 
            this.noteLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.noteLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(7, 9);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(349, 27);
            this.noteLbl.TabIndex = 147;
            this.noteLbl.Text = "Cập nhật bộ mã ICB từ tệp Excel vào hệ thống";
            this.noteLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // importIcbCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            
            this.ClientSize = new System.Drawing.Size(421, 214);
            this.Controls.Add(this.noteGb);
            this.Controls.Add(this.viewLogBtn);
            this.Controls.Add(this.sysCodeCatEd);
            this.Controls.Add(this.sysCodeCatLbl);
            this.Controls.Add(this.sheetNameEd);
            this.Controls.Add(this.sheetNameLbl);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.dataFileNameEd);
            this.Controls.Add(this.dataFileLbl);
            this.Controls.Add(this.selectFileBtn);

            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "importIcbCode";
            this.Text = "Nhap bo ma ICB / Import ICB";
            this.Controls.SetChildIndex(this.selectFileBtn, 0);
            this.Controls.SetChildIndex(this.dataFileLbl, 0);
            this.Controls.SetChildIndex(this.dataFileNameEd, 0);
            this.Controls.SetChildIndex(this.importBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.sheetNameLbl, 0);
            this.Controls.SetChildIndex(this.sheetNameEd, 0);
            this.Controls.SetChildIndex(this.sysCodeCatLbl, 0);
            this.Controls.SetChildIndex(this.sysCodeCatEd, 0);
            this.Controls.SetChildIndex(this.viewLogBtn, 0);
            this.Controls.SetChildIndex(this.noteGb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.noteGb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.controls.baseButton selectFileBtn;
        protected common.controls.baseLabel dataFileLbl;
        protected common.controls.baseTextBox dataFileNameEd;
        protected common.controls.baseButton importBtn;
        protected common.controls.baseButton closeBtn;
        protected databases.baseDS myDataSet;
        protected System.Windows.Forms.OpenFileDialog openFileDialog;
        protected common.controls.baseTextBox sheetNameEd;
        protected common.controls.baseLabel sheetNameLbl;
        protected common.controls.baseTextBox sysCodeCatEd;
        protected common.controls.baseLabel sysCodeCatLbl;
        protected common.controls.baseButton viewLogBtn;
        private System.Windows.Forms.GroupBox noteGb;
        private baseClass.controls.baseLabel noteLbl;

    }
}