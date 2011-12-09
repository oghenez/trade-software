namespace baseClass.forms
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
            this.process1 = new System.Diagnostics.Process();
            this.cancelBtn = new common.control.baseButton();
            this.closeBtn = new common.control.baseButton();
            this.importBtn = new common.control.baseButton();
            this.selectFileBtn = new common.control.baseButton();
            this.myDataSet = new data.baseDS();
            this.stockExchangeCb = new baseClass.controls.cbStockExchange();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
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
            this.dataFileNameEd.Size = new System.Drawing.Size(229, 22);
            this.dataFileNameEd.TabIndex = 1;
            // 
            // stockExchangeLbl
            // 
            this.stockExchangeLbl.AutoSize = true;
            this.stockExchangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockExchangeLbl.Location = new System.Drawing.Point(39, 61);
            this.stockExchangeLbl.Name = "stockExchangeLbl";
            this.stockExchangeLbl.Size = new System.Drawing.Size(93, 16);
            this.stockExchangeLbl.TabIndex = 149;
            this.stockExchangeLbl.Text = "Sàn giao dịch";
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Enabled = false;
            this.cancelBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Image = global::baseClass.Properties.Resources.remove;
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelBtn.Location = new System.Drawing.Point(135, 110);
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
            this.closeBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.Location = new System.Drawing.Point(203, 110);
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
            this.importBtn.Image = global::baseClass.Properties.Resources.select;
            this.importBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.importBtn.Location = new System.Drawing.Point(44, 110);
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
            this.selectFileBtn.Image = global::baseClass.Properties.Resources.open;
            this.selectFileBtn.Location = new System.Drawing.Point(272, 31);
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
            // stockExchangeCb
            // 
            this.stockExchangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockExchangeCb.FormattingEnabled = true;
            this.stockExchangeCb.Location = new System.Drawing.Point(42, 80);
            this.stockExchangeCb.myValue = "";
            this.stockExchangeCb.Name = "stockExchangeCb";
            this.stockExchangeCb.Size = new System.Drawing.Size(229, 24);
            this.stockExchangeCb.TabIndex = 10;
            // 
            // importPriceData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 178);
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
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
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
        private System.Diagnostics.Process process1;
        protected common.control.baseButton cancelBtn;
        protected data.baseDS myDataSet;

    }
}