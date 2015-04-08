namespace Imports.Forms
{
    partial class reAggregatePrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reAggregatePrice));
            this.closeBtn = new common.controls.baseButton();
            this.okBtn = new common.controls.baseButton();
            this.myBaseDS = new databases.baseDS();
            this.myImportDS = new databases.importDS();
            this.noteGb = new System.Windows.Forms.GroupBox();
            this.noteLbl = new baseClass.controls.baseLabel();
            this.codeEd = new common.controls.baseTextBox();
            this.codeChk = new System.Windows.Forms.CheckBox();
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
            this.closeBtn.Image = global::Imports.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.isDownState = false;
            this.closeBtn.Location = new System.Drawing.Point(177, 62);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(82, 30);
            this.closeBtn.TabIndex = 22;
            this.closeBtn.Text = "Đóng";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Image = global::Imports.Properties.Resources.select;
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okBtn.isDownState = false;
            this.okBtn.Location = new System.Drawing.Point(89, 62);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(82, 30);
            this.okBtn.TabIndex = 20;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
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
            this.noteGb.Location = new System.Drawing.Point(2, 104);
            this.noteGb.Name = "noteGb";
            this.noteGb.Size = new System.Drawing.Size(357, 43);
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
            this.noteLbl.Size = new System.Drawing.Size(255, 28);
            this.noteLbl.TabIndex = 147;
            this.noteLbl.Text = "Tổ hợp lại  từ dữ liệu chính";
            this.noteLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // codeEd
            // 
            this.codeEd.isRequired = true;
            this.codeEd.isToUpperCase = true;
            this.codeEd.Location = new System.Drawing.Point(89, 36);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(170, 23);
            this.codeEd.TabIndex = 2;
            this.codeEd.Text = "ACB";
            // 
            // codeChk
            // 
            this.codeChk.AutoSize = true;
            this.codeChk.Checked = true;
            this.codeChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.codeChk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.codeChk.Location = new System.Drawing.Point(92, 13);
            this.codeChk.Name = "codeChk";
            this.codeChk.Size = new System.Drawing.Size(84, 21);
            this.codeChk.TabIndex = 1;
            this.codeChk.Text = "Mã hiệu";
            this.codeChk.UseVisualStyleBackColor = true;
            this.codeChk.CheckedChanged += new System.EventHandler(this.codeChk_CheckedChanged);
            // 
            // reAggregatePrice
            // 
            this.ClientSize = new System.Drawing.Size(358, 173);
            this.Controls.Add(this.codeChk);
            this.Controls.Add(this.codeEd);
            this.Controls.Add(this.noteGb);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.okBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "reAggregatePrice";
            this.Text = "To hop lai du lieu";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.noteGb, 0);
            this.Controls.SetChildIndex(this.codeEd, 0);
            this.Controls.SetChildIndex(this.codeChk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myImportDS)).EndInit();
            this.noteGb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.controls.baseButton okBtn;
        protected common.controls.baseButton closeBtn;
        protected databases.baseDS myBaseDS;
        private databases.importDS myImportDS;
        private System.Windows.Forms.GroupBox noteGb;
        private baseClass.controls.baseLabel noteLbl;
        protected common.controls.baseTextBox codeEd;
        private System.Windows.Forms.CheckBox codeChk;

    }
}