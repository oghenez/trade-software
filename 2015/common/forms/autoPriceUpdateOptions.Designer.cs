namespace common.forms
{
    partial class autoPriceUpdateOptions
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
            this.label6 = new System.Windows.Forms.Label();
            this.updateTypeCb = new System.Windows.Forms.ComboBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.roundUpCb = new System.Windows.Forms.ComboBox();
            this.byPercentEd = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.byValueRb = new System.Windows.Forms.RadioButton();
            this.byPercentRb = new System.Windows.Forms.RadioButton();
            this.byValueEd = new common.controls.numberTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.byPercentEd)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.Location = new System.Drawing.Point(0, 7);
            this.TitleLbl.Size = new System.Drawing.Size(274, 26);
            this.TitleLbl.Text = "ĐIỀU CHỈNH GIÁ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 39);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Điều chỉnh";
            // 
            // updateTypeCb
            // 
            this.updateTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.updateTypeCb.FormattingEnabled = true;
            this.updateTypeCb.Items.AddRange(new object[] {
            "Tăng ",
            "Giảm"});
            this.updateTypeCb.Location = new System.Drawing.Point(119, 37);
            this.updateTypeCb.Margin = new System.Windows.Forms.Padding(4);
            this.updateTypeCb.Name = "updateTypeCb";
            this.updateTypeCb.Size = new System.Drawing.Size(128, 26);
            this.updateTypeCb.TabIndex = 1;
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(179, 148);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(69, 28);
            this.closeBtn.TabIndex = 8;
            this.closeBtn.Text = "Đóng";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Location = new System.Drawing.Point(118, 148);
            this.okBtn.Margin = new System.Windows.Forms.Padding(4);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(57, 28);
            this.okBtn.TabIndex = 7;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // roundUpCb
            // 
            this.roundUpCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roundUpCb.FormattingEnabled = true;
            this.roundUpCb.Items.AddRange(new object[] {
            "100",
            "1,000",
            "10,000",
            "100,000",
            "1.000.000"});
            this.roundUpCb.Location = new System.Drawing.Point(120, 117);
            this.roundUpCb.Margin = new System.Windows.Forms.Padding(4);
            this.roundUpCb.Name = "roundUpCb";
            this.roundUpCb.Size = new System.Drawing.Size(128, 26);
            this.roundUpCb.TabIndex = 5;
            // 
            // byPercentEd
            // 
            this.byPercentEd.Location = new System.Drawing.Point(120, 65);
            this.byPercentEd.Margin = new System.Windows.Forms.Padding(4);
            this.byPercentEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.byPercentEd.Name = "byPercentEd";
            this.byPercentEd.Size = new System.Drawing.Size(71, 24);
            this.byPercentEd.TabIndex = 3;
            this.byPercentEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.byPercentEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 121);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 18);
            this.label5.TabIndex = 153;
            this.label5.Text = "Làm tròn đến";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 18);
            this.label4.TabIndex = 147;
            this.label4.Text = "%";
            // 
            // byValueRb
            // 
            this.byValueRb.AutoSize = true;
            this.byValueRb.Location = new System.Drawing.Point(25, 93);
            this.byValueRb.Margin = new System.Windows.Forms.Padding(4);
            this.byValueRb.Name = "byValueRb";
            this.byValueRb.Size = new System.Drawing.Size(99, 22);
            this.byValueRb.TabIndex = 148;
            this.byValueRb.Text = "Theo giá trị";
            this.byValueRb.UseVisualStyleBackColor = true;
            this.byValueRb.CheckedChanged += new System.EventHandler(this.byValueRb_CheckedChanged);
            // 
            // byPercentRb
            // 
            this.byPercentRb.AutoSize = true;
            this.byPercentRb.Checked = true;
            this.byPercentRb.Location = new System.Drawing.Point(25, 65);
            this.byPercentRb.Margin = new System.Windows.Forms.Padding(4);
            this.byPercentRb.Name = "byPercentRb";
            this.byPercentRb.Size = new System.Drawing.Size(86, 22);
            this.byPercentRb.TabIndex = 2;
            this.byPercentRb.TabStop = true;
            this.byPercentRb.Text = "Theo tỉ lệ";
            this.byPercentRb.UseVisualStyleBackColor = true;
            this.byPercentRb.CheckedChanged += new System.EventHandler(this.byPercentRb_CheckedChanged);
            // 
            // byValueEd
            // 
            this.byValueEd.Enabled = false;
            this.byValueEd.Location = new System.Drawing.Point(120, 91);
            this.byValueEd.Name = "byValueEd";
            this.byValueEd.Size = new System.Drawing.Size(127, 24);
            this.byValueEd.TabIndex = 4;
            this.byValueEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.byValueEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // autoPriceUpdateOptions
            // 
            this.ClientSize = new System.Drawing.Size(279, 177);
            this.Controls.Add(this.byValueEd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.updateTypeCb);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.roundUpCb);
            this.Controls.Add(this.byPercentEd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.byValueRb);
            this.Controls.Add(this.byPercentRb);
            this.MinimizeBox = false;
            this.Name = "autoPriceUpdateOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Dieu chinh gia";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.byPercentRb, 0);
            this.Controls.SetChildIndex(this.byValueRb, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.byPercentEd, 0);
            this.Controls.SetChildIndex(this.roundUpCb, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.updateTypeCb, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.byValueEd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.byPercentEd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox updateTypeCb;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox roundUpCb;
        private System.Windows.Forms.NumericUpDown byPercentEd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton byValueRb;
        private System.Windows.Forms.RadioButton byPercentRb;
        private common.controls.numberTextBox byValueEd;
    }
}
