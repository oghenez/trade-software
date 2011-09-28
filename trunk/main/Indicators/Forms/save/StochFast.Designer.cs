namespace Indicators.forms
{
    partial class StochFast
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
            this.paraLbl = new common.control.baseLabel();
            this.lineKColorEd = new common.control.ColorComboBox();
            this.lineKWeightEd = new System.Windows.Forms.NumericUpDown();
            this.inNewPaneChk = new common.control.baseCheckBox();
            this.lineDWeightEd = new System.Windows.Forms.NumericUpDown();
            this.fastK_PeriodEd = new common.control.numberTextBox();
            this.lineDColorEd = new common.control.ColorComboBox();
            this.lineKLbl = new common.control.baseLabel();
            this.lineDLbl = new common.control.baseLabel();
            this.fastD_PeriodEd = new common.control.numberTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lineKWeightEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineDWeightEd)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(246, 133);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(50, 133);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(634, 33);
            // 
            // paraLbl
            // 
            this.paraLbl.AutoSize = true;
            this.paraLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraLbl.Location = new System.Drawing.Point(44, 20);
            this.paraLbl.Name = "paraLbl";
            this.paraLbl.Size = new System.Drawing.Size(61, 16);
            this.paraLbl.TabIndex = 146;
            this.paraLbl.Text = "Tham số";
            // 
            // lineKColorEd
            // 
            this.lineKColorEd.Color = System.Drawing.Color.Black;
            this.lineKColorEd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lineKColorEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lineKColorEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineKColorEd.Location = new System.Drawing.Point(120, 43);
            this.lineKColorEd.Name = "lineKColorEd";
            this.lineKColorEd.Size = new System.Drawing.Size(177, 27);
            this.lineKColorEd.TabIndex = 10;
            // 
            // lineKWeightEd
            // 
            this.lineKWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineKWeightEd.Location = new System.Drawing.Point(294, 43);
            this.lineKWeightEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.lineKWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineKWeightEd.Name = "lineKWeightEd";
            this.lineKWeightEd.Size = new System.Drawing.Size(38, 26);
            this.lineKWeightEd.TabIndex = 11;
            this.lineKWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lineKWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // inNewPaneChk
            // 
            this.inNewPaneChk.AutoSize = true;
            this.inNewPaneChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inNewPaneChk.Location = new System.Drawing.Point(122, 105);
            this.inNewPaneChk.Name = "inNewPaneChk";
            this.inNewPaneChk.Size = new System.Drawing.Size(189, 20);
            this.inNewPaneChk.TabIndex = 90;
            this.inNewPaneChk.Text = "Hiển thị trong cửa sổ mới";
            this.inNewPaneChk.UseVisualStyleBackColor = true;
            // 
            // lineDWeightEd
            // 
            this.lineDWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineDWeightEd.Location = new System.Drawing.Point(294, 72);
            this.lineDWeightEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.lineDWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lineDWeightEd.Name = "lineDWeightEd";
            this.lineDWeightEd.Size = new System.Drawing.Size(38, 26);
            this.lineDWeightEd.TabIndex = 21;
            this.lineDWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lineDWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // fastK_PeriodEd
            // 
            this.fastK_PeriodEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastK_PeriodEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.fastK_PeriodEd.Location = new System.Drawing.Point(120, 16);
            this.fastK_PeriodEd.myFormat = "###,###,###,###,###";
            this.fastK_PeriodEd.Name = "fastK_PeriodEd";
            this.fastK_PeriodEd.Size = new System.Drawing.Size(104, 26);
            this.fastK_PeriodEd.TabIndex = 151;
            this.fastK_PeriodEd.Text = "14";
            this.fastK_PeriodEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fastK_PeriodEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.fastK_PeriodEd.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // lineDColorEd
            // 
            this.lineDColorEd.Color = System.Drawing.Color.Black;
            this.lineDColorEd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lineDColorEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lineDColorEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineDColorEd.Location = new System.Drawing.Point(120, 72);
            this.lineDColorEd.Name = "lineDColorEd";
            this.lineDColorEd.Size = new System.Drawing.Size(177, 27);
            this.lineDColorEd.TabIndex = 20;
            // 
            // lineKLbl
            // 
            this.lineKLbl.AutoSize = true;
            this.lineKLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineKLbl.Location = new System.Drawing.Point(44, 47);
            this.lineKLbl.Name = "lineKLbl";
            this.lineKLbl.Size = new System.Drawing.Size(63, 16);
            this.lineKLbl.TabIndex = 154;
            this.lineKLbl.Text = "Đường K";
            // 
            // lineDLbl
            // 
            this.lineDLbl.AutoSize = true;
            this.lineDLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineDLbl.Location = new System.Drawing.Point(44, 75);
            this.lineDLbl.Name = "lineDLbl";
            this.lineDLbl.Size = new System.Drawing.Size(64, 16);
            this.lineDLbl.TabIndex = 158;
            this.lineDLbl.Text = "Đường D";
            // 
            // fastD_PeriodEd
            // 
            this.fastD_PeriodEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastD_PeriodEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.fastD_PeriodEd.Location = new System.Drawing.Point(224, 16);
            this.fastD_PeriodEd.myFormat = "###,###,###,###,###";
            this.fastD_PeriodEd.Name = "fastD_PeriodEd";
            this.fastD_PeriodEd.Size = new System.Drawing.Size(104, 26);
            this.fastD_PeriodEd.TabIndex = 157;
            this.fastD_PeriodEd.Text = "3";
            this.fastD_PeriodEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fastD_PeriodEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.fastD_PeriodEd.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // StochFast
            // 
            this.ClientSize = new System.Drawing.Size(384, 187);
            this.Controls.Add(this.lineDLbl);
            this.Controls.Add(this.lineKLbl);
            this.Controls.Add(this.lineDWeightEd);
            this.Controls.Add(this.lineDColorEd);
            this.Controls.Add(this.inNewPaneChk);
            this.Controls.Add(this.fastD_PeriodEd);
            this.Controls.Add(this.lineKWeightEd);
            this.Controls.Add(this.lineKColorEd);
            this.Controls.Add(this.fastK_PeriodEd);
            this.Controls.Add(this.paraLbl);
            this.Name = "StochFast";
            this.Text = "StochFast";
            this.Controls.SetChildIndex(this.paraLbl, 0);
            this.Controls.SetChildIndex(this.fastK_PeriodEd, 0);
            this.Controls.SetChildIndex(this.lineKColorEd, 0);
            this.Controls.SetChildIndex(this.lineKWeightEd, 0);
            this.Controls.SetChildIndex(this.fastD_PeriodEd, 0);
            this.Controls.SetChildIndex(this.inNewPaneChk, 0);
            this.Controls.SetChildIndex(this.lineDColorEd, 0);
            this.Controls.SetChildIndex(this.lineDWeightEd, 0);
            this.Controls.SetChildIndex(this.lineKLbl, 0);
            this.Controls.SetChildIndex(this.lineDLbl, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lineKWeightEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineDWeightEd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseLabel paraLbl;
        protected common.control.ColorComboBox lineKColorEd;
        private System.Windows.Forms.NumericUpDown lineKWeightEd;
        protected common.control.baseCheckBox inNewPaneChk;
        private System.Windows.Forms.NumericUpDown lineDWeightEd;
        protected common.control.numberTextBox fastK_PeriodEd;
        protected common.control.ColorComboBox lineDColorEd;
        protected common.control.baseLabel lineKLbl;
        protected common.control.baseLabel lineDLbl;
        protected common.control.numberTextBox fastD_PeriodEd;
    }
}
