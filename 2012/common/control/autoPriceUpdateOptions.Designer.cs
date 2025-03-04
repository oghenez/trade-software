namespace common.controls
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

        #region Component Designer generated code

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
            this.title = new System.Windows.Forms.Label();
            this.byValueRb = new System.Windows.Forms.RadioButton();
            this.byPercentRb = new System.Windows.Forms.RadioButton();
            this.byValueEd = new common.controls.numberTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.byPercentEd)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Điều chỉnh";
            // 
            // updateTypeCb
            // 
            this.updateTypeCb.FormattingEnabled = true;
            this.updateTypeCb.Items.AddRange(new object[] {
            "Tăng ",
            "Giảm"});
            this.updateTypeCb.Location = new System.Drawing.Point(113, 104);
            this.updateTypeCb.Margin = new System.Windows.Forms.Padding(4);
            this.updateTypeCb.Name = "updateTypeCb";
            this.updateTypeCb.Size = new System.Drawing.Size(128, 24);
            this.updateTypeCb.TabIndex = 6;
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(172, 133);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(69, 28);
            this.closeBtn.TabIndex = 23;
            this.closeBtn.Text = "Đóng";
            this.closeBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Location = new System.Drawing.Point(111, 133);
            this.okBtn.Margin = new System.Windows.Forms.Padding(4);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(57, 28);
            this.okBtn.TabIndex = 22;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // roundUpCb
            // 
            this.roundUpCb.FormattingEnabled = true;
            this.roundUpCb.Items.AddRange(new object[] {
            "100",
            "1,000",
            "10,000",
            "100,000",
            "1.000.000"});
            this.roundUpCb.Location = new System.Drawing.Point(113, 78);
            this.roundUpCb.Margin = new System.Windows.Forms.Padding(4);
            this.roundUpCb.Name = "roundUpCb";
            this.roundUpCb.Size = new System.Drawing.Size(128, 24);
            this.roundUpCb.TabIndex = 5;
            // 
            // byPercentEd
            // 
            this.byPercentEd.Location = new System.Drawing.Point(113, 30);
            this.byPercentEd.Margin = new System.Windows.Forms.Padding(4);
            this.byPercentEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.byPercentEd.Name = "byPercentEd";
            this.byPercentEd.Size = new System.Drawing.Size(71, 22);
            this.byPercentEd.TabIndex = 2;
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
            this.label5.Location = new System.Drawing.Point(23, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Làm tròn đến";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "%";
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.title.Location = new System.Drawing.Point(1, 4);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(263, 23);
            this.title.TabIndex = 20;
            this.title.Text = "ĐIỀU CHỈNH GIÁ";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // byValueRb
            // 
            this.byValueRb.AutoSize = true;
            this.byValueRb.Enabled = false;
            this.byValueRb.Location = new System.Drawing.Point(23, 56);
            this.byValueRb.Margin = new System.Windows.Forms.Padding(4);
            this.byValueRb.Name = "byValueRb";
            this.byValueRb.Size = new System.Drawing.Size(93, 20);
            this.byValueRb.TabIndex = 3;
            this.byValueRb.TabStop = true;
            this.byValueRb.Text = "Theo giá trị";
            this.byValueRb.UseVisualStyleBackColor = true;
            this.byValueRb.CheckedChanged += new System.EventHandler(this.byValueRb_CheckedChanged);
            // 
            // byPercentRb
            // 
            this.byPercentRb.AutoSize = true;
            this.byPercentRb.Checked = true;
            this.byPercentRb.Location = new System.Drawing.Point(23, 30);
            this.byPercentRb.Margin = new System.Windows.Forms.Padding(4);
            this.byPercentRb.Name = "byPercentRb";
            this.byPercentRb.Size = new System.Drawing.Size(81, 20);
            this.byPercentRb.TabIndex = 1;
            this.byPercentRb.TabStop = true;
            this.byPercentRb.Text = "Theo tỉ lệ";
            this.byPercentRb.UseVisualStyleBackColor = true;
            this.byPercentRb.CheckedChanged += new System.EventHandler(this.byPercentRb_CheckedChanged);
            // 
            // byValueEd
            // 
            this.byValueEd.Location = new System.Drawing.Point(113, 54);
            this.byValueEd.Name = "byValueEd";
            this.byValueEd.Size = new System.Drawing.Size(128, 22);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.byValueEd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.updateTypeCb);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.roundUpCb);
            this.Controls.Add(this.byPercentEd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.title);
            this.Controls.Add(this.byValueRb);
            this.Controls.Add(this.byPercentRb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "autoPriceUpdateOptions";
            this.Size = new System.Drawing.Size(266, 173);
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
        public System.Windows.Forms.Label title;
        private System.Windows.Forms.RadioButton byValueRb;
        private System.Windows.Forms.RadioButton byPercentRb;
        private numberTextBox byValueEd;

    }
}
