namespace imports.forms
{
    partial class updatePrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(updatePrice));
            this.urlLbl = new common.control.baseLabel();
            this.urlEd = new common.control.baseTextBox();
            this.stockExchangeLbl = new common.control.baseLabel();
            this.closeBtn = new common.control.baseButton();
            this.importBtn = new common.control.baseButton();
            this.myBaseDS = new data.baseDS();
            this.stockExchangeCb = new baseClass.controls.cbStockExchange();
            this.myImportDS = new data.importDS();
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myImportDS)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(896, 91);
            this.TitleLbl.Visible = false;
            // 
            // urlLbl
            // 
            this.urlLbl.AutoSize = true;
            this.urlLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlLbl.Location = new System.Drawing.Point(39, 12);
            this.urlLbl.Name = "urlLbl";
            this.urlLbl.Size = new System.Drawing.Size(78, 16);
            this.urlLbl.TabIndex = 146;
            this.urlLbl.Text = "Tệp dữ liệu";
            // 
            // urlEd
            // 
            this.urlEd.Location = new System.Drawing.Point(42, 31);
            this.urlEd.Name = "urlEd";
            this.urlEd.Size = new System.Drawing.Size(289, 22);
            this.urlEd.TabIndex = 1;
            this.urlEd.Text = "http://online.mhbs.vn/quote/hose.aspx";
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
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = global::imports.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.Location = new System.Drawing.Point(263, 110);
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
            this.importBtn.Location = new System.Drawing.Point(166, 110);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(91, 30);
            this.importBtn.TabIndex = 20;
            this.importBtn.Text = "Thực hiện";
            this.importBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // myBaseDS
            // 
            this.myBaseDS.DataSetName = "myBaseDS";
            this.myBaseDS.EnforceConstraints = false;
            this.myBaseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stockExchangeCb
            // 
            this.stockExchangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockExchangeCb.FormattingEnabled = true;
            this.stockExchangeCb.Location = new System.Drawing.Point(42, 80);
            this.stockExchangeCb.myValue = "";
            this.stockExchangeCb.Name = "stockExchangeCb";
            this.stockExchangeCb.Size = new System.Drawing.Size(289, 24);
            this.stockExchangeCb.TabIndex = 10;
            // 
            // myImportDS
            // 
            this.myImportDS.DataSetName = "myImportDS";
            this.myImportDS.EnforceConstraints = false;
            this.myImportDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // updatePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 172);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.stockExchangeLbl);
            this.Controls.Add(this.stockExchangeCb);
            this.Controls.Add(this.urlEd);
            this.Controls.Add(this.urlLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "updatePrice";
            this.Text = "Lay du lieu gia / Update price data";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.urlLbl, 0);
            this.Controls.SetChildIndex(this.urlEd, 0);
            this.Controls.SetChildIndex(this.stockExchangeCb, 0);
            this.Controls.SetChildIndex(this.stockExchangeLbl, 0);
            this.Controls.SetChildIndex(this.importBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myBaseDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myImportDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseLabel urlLbl;
        protected common.control.baseTextBox urlEd;
        protected baseClass.controls.cbStockExchange stockExchangeCb;
        protected common.control.baseLabel stockExchangeLbl;
        protected common.control.baseButton importBtn;
        protected common.control.baseButton closeBtn;
        protected data.baseDS myBaseDS;
        private data.importDS myImportDS;

    }
}