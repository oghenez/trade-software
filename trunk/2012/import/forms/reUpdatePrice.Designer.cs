namespace imports.forms
{
    partial class reUpdatePrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reUpdatePrice));
            this.closeBtn = new common.controls.baseButton();
            this.importBtn = new common.controls.baseButton();
            this.myBaseDS = new databases.baseDS();
            this.myImportDS = new databases.importDS();
            this.noteGb = new System.Windows.Forms.GroupBox();
            this.noteLbl = new baseClass.controls.baseLabel();
            this.dateRangeEd = new common.controls.dateRange2();
            this.codeEd = new common.controls.baseTextBox();
            this.codeLbl = new common.controls.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myImportDS)).BeginInit();
            this.noteGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(896, 91);
            this.TitleLbl.Visible = false;
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = global::imports.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.isDownState = false;
            this.closeBtn.Location = new System.Drawing.Point(250, 79);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(82, 30);
            this.closeBtn.TabIndex = 22;
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
            this.importBtn.Location = new System.Drawing.Point(250, 49);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(82, 30);
            this.importBtn.TabIndex = 20;
            this.importBtn.Text = "Ok";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // myBaseDS
            // 
            this.myBaseDS.DataSetName = "myBaseDS";
            this.myBaseDS.EnforceConstraints = false;
            this.myBaseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // myImportDS
            // 
            this.myImportDS.DataSetName = "myImportDS";
            this.myImportDS.EnforceConstraints = false;
            this.myImportDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // noteGb
            // 
            this.noteGb.Controls.Add(this.noteLbl);
            this.noteGb.Location = new System.Drawing.Point(2, 137);
            this.noteGb.Name = "noteGb";
            this.noteGb.Size = new System.Drawing.Size(357, 38);
            this.noteGb.TabIndex = 151;
            this.noteGb.TabStop = false;
            // 
            // noteLbl
            // 
            this.noteLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.noteLbl.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(56, 11);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(255, 23);
            this.noteLbl.TabIndex = 147;
            this.noteLbl.Text = "Cập nhật lại dữ liệu giá trực tuyến";
            this.noteLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateRangeEd
            // 
            this.dateRangeEd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRangeEd.frDate = new System.DateTime(((long)(0)));
            this.dateRangeEd.Location = new System.Drawing.Point(68, 24);
            this.dateRangeEd.Margin = new System.Windows.Forms.Padding(4);
            this.dateRangeEd.Name = "dateRangeEd";
            this.dateRangeEd.Size = new System.Drawing.Size(172, 45);
            this.dateRangeEd.TabIndex = 1;
            this.dateRangeEd.toDate = new System.DateTime(((long)(0)));
            // 
            // codeEd
            // 
            this.codeEd.isToUpperCase = true;
            this.codeEd.Location = new System.Drawing.Point(68, 91);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(161, 23);
            this.codeEd.TabIndex = 2;
            this.codeEd.Text = "ACB";
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(65, 72);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(58, 16);
            this.codeLbl.TabIndex = 153;
            this.codeLbl.Text = "Mã hiệu";
            // 
            // reUpdatePrice
            // 
            this.ClientSize = new System.Drawing.Size(358, 206);
            this.Controls.Add(this.codeEd);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.dateRangeEd);
            this.Controls.Add(this.noteGb);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.importBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "reUpdatePrice";
            this.Text = "Cap nhat lai du lieu gia truc tuyen";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.importBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.noteGb, 0);
            this.Controls.SetChildIndex(this.dateRangeEd, 0);
            this.Controls.SetChildIndex(this.codeLbl, 0);
            this.Controls.SetChildIndex(this.codeEd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myImportDS)).EndInit();
            this.noteGb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.controls.baseButton importBtn;
        protected common.controls.baseButton closeBtn;
        protected databases.baseDS myBaseDS;
        private databases.importDS myImportDS;
        private System.Windows.Forms.GroupBox noteGb;
        private baseClass.controls.baseLabel noteLbl;
        private common.controls.dateRange2 dateRangeEd;
        protected common.controls.baseTextBox codeEd;
        protected common.controls.baseLabel codeLbl;

    }
}