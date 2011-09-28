namespace Indicators.forms
{
    partial class Stoch
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
            this.fastPeriodEd = new common.control.numberTextBox();
            this.lineKWeightEd = new System.Windows.Forms.NumericUpDown();
            this.inNewPaneChk = new common.control.baseCheckBox();
            this.lineDWeightEd = new System.Windows.Forms.NumericUpDown();
            this.slowK_PeriodEd = new common.control.numberTextBox();
            this.lineDColorEd = new common.control.ColorComboBox();
            this.FastKLbl = new common.control.baseLabel();
            this.FastDLbl = new common.control.baseLabel();
            this.slowD_PeriodEd = new common.control.numberTextBox();
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
            // fastPeriodEd
            // 
            this.fastPeriodEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastPeriodEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.fastPeriodEd.Location = new System.Drawing.Point(120, 16);
            this.fastPeriodEd.myFormat = "###";
            this.fastPeriodEd.Name = "fastPeriodEd";
            this.fastPeriodEd.Size = new System.Drawing.Size(70, 26);
            this.fastPeriodEd.TabIndex = 1;
            this.fastPeriodEd.Text = "14";
            this.fastPeriodEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fastPeriodEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.fastPeriodEd.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
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
            // slowK_PeriodEd
            // 
            this.slowK_PeriodEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slowK_PeriodEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.slowK_PeriodEd.Location = new System.Drawing.Point(190, 16);
            this.slowK_PeriodEd.myFormat = "###,###,###,###,###";
            this.slowK_PeriodEd.Name = "slowK_PeriodEd";
            this.slowK_PeriodEd.Size = new System.Drawing.Size(70, 26);
            this.slowK_PeriodEd.TabIndex = 151;
            this.slowK_PeriodEd.Text = "3";
            this.slowK_PeriodEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slowK_PeriodEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.slowK_PeriodEd.Value = new decimal(new int[] {
            3,
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
            // FastKLbl
            // 
            this.FastKLbl.AutoSize = true;
            this.FastKLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FastKLbl.Location = new System.Drawing.Point(44, 47);
            this.FastKLbl.Name = "FastKLbl";
            this.FastKLbl.Size = new System.Drawing.Size(63, 16);
            this.FastKLbl.TabIndex = 154;
            this.FastKLbl.Text = "Đường K";
            // 
            // FastDLbl
            // 
            this.FastDLbl.AutoSize = true;
            this.FastDLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FastDLbl.Location = new System.Drawing.Point(44, 76);
            this.FastDLbl.Name = "FastDLbl";
            this.FastDLbl.Size = new System.Drawing.Size(64, 16);
            this.FastDLbl.TabIndex = 158;
            this.FastDLbl.Text = "Đường D";
            // 
            // slowD_PeriodEd
            // 
            this.slowD_PeriodEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slowD_PeriodEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.slowD_PeriodEd.Location = new System.Drawing.Point(260, 16);
            this.slowD_PeriodEd.myFormat = "###,###,###,###,###";
            this.slowD_PeriodEd.Name = "slowD_PeriodEd";
            this.slowD_PeriodEd.Size = new System.Drawing.Size(70, 26);
            this.slowD_PeriodEd.TabIndex = 157;
            this.slowD_PeriodEd.Text = "3";
            this.slowD_PeriodEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slowD_PeriodEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.slowD_PeriodEd.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Stoch
            // 
            this.ClientSize = new System.Drawing.Size(384, 187);
            this.Controls.Add(this.FastDLbl);
            this.Controls.Add(this.slowD_PeriodEd);
            this.Controls.Add(this.FastKLbl);
            this.Controls.Add(this.lineDWeightEd);
            this.Controls.Add(this.slowK_PeriodEd);
            this.Controls.Add(this.lineDColorEd);
            this.Controls.Add(this.inNewPaneChk);
            this.Controls.Add(this.lineKWeightEd);
            this.Controls.Add(this.fastPeriodEd);
            this.Controls.Add(this.lineKColorEd);
            this.Controls.Add(this.paraLbl);
            this.Name = "Stoch";
            this.Text = "Stoch";
            this.Controls.SetChildIndex(this.paraLbl, 0);
            this.Controls.SetChildIndex(this.lineKColorEd, 0);
            this.Controls.SetChildIndex(this.fastPeriodEd, 0);
            this.Controls.SetChildIndex(this.lineKWeightEd, 0);
            this.Controls.SetChildIndex(this.inNewPaneChk, 0);
            this.Controls.SetChildIndex(this.lineDColorEd, 0);
            this.Controls.SetChildIndex(this.slowK_PeriodEd, 0);
            this.Controls.SetChildIndex(this.lineDWeightEd, 0);
            this.Controls.SetChildIndex(this.FastKLbl, 0);
            this.Controls.SetChildIndex(this.slowD_PeriodEd, 0);
            this.Controls.SetChildIndex(this.FastDLbl, 0);
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
        protected common.control.numberTextBox fastPeriodEd;
        private System.Windows.Forms.NumericUpDown lineKWeightEd;
        protected common.control.baseCheckBox inNewPaneChk;
        private System.Windows.Forms.NumericUpDown lineDWeightEd;
        protected common.control.numberTextBox slowK_PeriodEd;
        protected common.control.ColorComboBox lineDColorEd;
        protected common.control.baseLabel FastKLbl;
        protected common.control.baseLabel FastDLbl;
        protected common.control.numberTextBox slowD_PeriodEd;
    }
}
