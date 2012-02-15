namespace imports.forms
{
    partial class importComSector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(importComSector));
            this.dataFileLbl = new common.controls.baseLabel();
            this.dataFileNameEd = new common.controls.baseTextBox();
            this.myDataSet = new databases.baseDS();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bizIndustryClb = new baseClass.controls.clbBizIndustry();
            this.industryLbl = new common.controls.baseLabel();
            this.viewLogBtn = new common.controls.baseButton();
            this.closeBtn = new common.controls.baseButton();
            this.importBtn = new common.controls.baseButton();
            this.selectFileBtn = new common.controls.baseButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.noteGb = new System.Windows.Forms.GroupBox();
            this.noteLbl = new baseClass.controls.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
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
            this.dataFileLbl.Location = new System.Drawing.Point(39, 5);
            this.dataFileLbl.Name = "dataFileLbl";
            this.dataFileLbl.Size = new System.Drawing.Size(78, 16);
            this.dataFileLbl.TabIndex = 146;
            this.dataFileLbl.Text = "Tệp dữ liệu";
            // 
            // dataFileNameEd
            // 
            this.dataFileNameEd.Location = new System.Drawing.Point(42, 24);
            this.dataFileNameEd.Name = "dataFileNameEd";
            this.dataFileNameEd.Size = new System.Drawing.Size(333, 22);
            this.dataFileNameEd.TabIndex = 1;
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
            // bizIndustryClb
            // 
            this.bizIndustryClb.CheckOnClick = true;
            this.bizIndustryClb.FormattingEnabled = true;
            this.bizIndustryClb.Location = new System.Drawing.Point(42, 70);
            this.bizIndustryClb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("bizIndustryClb.myCheckedItems")));
            this.bizIndustryClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("bizIndustryClb.myCheckedValues")));
            this.bizIndustryClb.myItemString = "";
            this.bizIndustryClb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("bizIndustryClb.myItemValues")));
            this.bizIndustryClb.Name = "bizIndustryClb";
            this.bizIndustryClb.ShowCheckedOnly = false;
            this.bizIndustryClb.Size = new System.Drawing.Size(329, 208);
            this.bizIndustryClb.TabIndex = 10;
            // 
            // industryLbl
            // 
            this.industryLbl.AutoSize = true;
            this.industryLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.industryLbl.Location = new System.Drawing.Point(39, 51);
            this.industryLbl.Name = "industryLbl";
            this.industryLbl.Size = new System.Drawing.Size(132, 16);
            this.industryLbl.TabIndex = 148;
            this.industryLbl.Text = "Bảng (sheet name)";
            // 
            // viewLogBtn
            // 
            this.viewLogBtn.Enabled = false;
            this.viewLogBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLogBtn.Image = global::imports.Properties.Resources.report;
            this.viewLogBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.viewLogBtn.isDownState = false;
            this.viewLogBtn.Location = new System.Drawing.Point(224, 287);
            this.viewLogBtn.Name = "viewLogBtn";
            this.viewLogBtn.Size = new System.Drawing.Size(77, 30);
            this.viewLogBtn.TabIndex = 21;
            this.viewLogBtn.Text = "Nhật ký";
            this.viewLogBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewLogBtn.UseVisualStyleBackColor = true;
            this.viewLogBtn.Click += new System.EventHandler(this.viewLogBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = global::imports.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.isDownState = false;
            this.closeBtn.Location = new System.Drawing.Point(301, 287);
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
            this.importBtn.Location = new System.Drawing.Point(133, 287);
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
            this.selectFileBtn.Location = new System.Drawing.Point(376, 25);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(22, 21);
            this.selectFileBtn.TabIndex = 2;
            this.selectFileBtn.UseVisualStyleBackColor = true;
            this.selectFileBtn.Click += new System.EventHandler(this.selectFileBtn_Click);
            // 
            // noteGb
            // 
            this.noteGb.Controls.Add(this.noteLbl);
            this.noteGb.Location = new System.Drawing.Point(25, 317);
            this.noteGb.Name = "noteGb";
            this.noteGb.Size = new System.Drawing.Size(372, 39);
            this.noteGb.TabIndex = 149;
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
            this.noteLbl.Size = new System.Drawing.Size(359, 27);
            this.noteLbl.TabIndex = 147;
            this.noteLbl.Text = "Cập nhật mã ngành của các công ty niêm yết từ tệp Excel";
            this.noteLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // importComSector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            
            this.ClientSize = new System.Drawing.Size(409, 381);
            this.Controls.Add(this.noteGb);
            this.Controls.Add(this.viewLogBtn);
            this.Controls.Add(this.industryLbl);
            this.Controls.Add(this.dataFileNameEd);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.bizIndustryClb);
            this.Controls.Add(this.dataFileLbl);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.selectFileBtn);

            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "importComSector";
            this.Text = "Nhap danh sach cong ty";
            this.Controls.SetChildIndex(this.selectFileBtn, 0);
            this.Controls.SetChildIndex(this.importBtn, 0);
            this.Controls.SetChildIndex(this.dataFileLbl, 0);
            this.Controls.SetChildIndex(this.bizIndustryClb, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.dataFileNameEd, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.industryLbl, 0);
            this.Controls.SetChildIndex(this.viewLogBtn, 0);
            this.Controls.SetChildIndex(this.noteGb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
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
        protected common.controls.baseLabel industryLbl;
        protected baseClass.controls.clbBizIndustry bizIndustryClb;
        private System.Windows.Forms.BindingSource bindingSource1;
        protected common.controls.baseButton viewLogBtn;
        private System.Windows.Forms.GroupBox noteGb;
        private baseClass.controls.baseLabel noteLbl;

    }
}