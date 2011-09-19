namespace Indicators.forms
{
    partial class BBANDS
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
            this.upperColorEd = new common.control.ColorComboBox();
            this.periodEd = new common.control.numberTextBox();
            this.upperWeightEd = new System.Windows.Forms.NumericUpDown();
            this.inNewPaneChk = new common.control.baseCheckBox();
            this.lowerWeightEd = new System.Windows.Forms.NumericUpDown();
            this.kUpEd = new common.control.numberTextBox();
            this.lowerColorEd = new common.control.ColorComboBox();
            this.upperLbl = new common.control.baseLabel();
            this.lowerLbl = new common.control.baseLabel();
            this.kDownEd = new common.control.numberTextBox();
            this.middleLbl = new common.control.baseLabel();
            this.middleWeightEd = new System.Windows.Forms.NumericUpDown();
            this.middleColorEd = new common.control.ColorComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.upperWeightEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerWeightEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleWeightEd)).BeginInit();
            this.SuspendLayout();
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(149, 160);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(247, 160);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(51, 160);
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
            // upperColorEd
            // 
            this.upperColorEd.Color = System.Drawing.Color.Black;
            this.upperColorEd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.upperColorEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.upperColorEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upperColorEd.Location = new System.Drawing.Point(120, 43);
            this.upperColorEd.Name = "upperColorEd";
            this.upperColorEd.Size = new System.Drawing.Size(177, 27);
            this.upperColorEd.TabIndex = 10;
            // 
            // periodEd
            // 
            this.periodEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.periodEd.Location = new System.Drawing.Point(120, 16);
            this.periodEd.myFormat = "###";
            this.periodEd.Name = "periodEd";
            this.periodEd.Size = new System.Drawing.Size(70, 26);
            this.periodEd.TabIndex = 1;
            this.periodEd.Text = "20";
            this.periodEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.periodEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.periodEd.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // upperWeightEd
            // 
            this.upperWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upperWeightEd.Location = new System.Drawing.Point(294, 43);
            this.upperWeightEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.upperWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upperWeightEd.Name = "upperWeightEd";
            this.upperWeightEd.Size = new System.Drawing.Size(38, 26);
            this.upperWeightEd.TabIndex = 11;
            this.upperWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.upperWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // inNewPaneChk
            // 
            this.inNewPaneChk.AutoSize = true;
            this.inNewPaneChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inNewPaneChk.Location = new System.Drawing.Point(122, 132);
            this.inNewPaneChk.Name = "inNewPaneChk";
            this.inNewPaneChk.Size = new System.Drawing.Size(189, 20);
            this.inNewPaneChk.TabIndex = 90;
            this.inNewPaneChk.Text = "Hiển thị trong cửa sổ mới";
            this.inNewPaneChk.UseVisualStyleBackColor = true;
            // 
            // lowerWeightEd
            // 
            this.lowerWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowerWeightEd.Location = new System.Drawing.Point(293, 100);
            this.lowerWeightEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.lowerWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lowerWeightEd.Name = "lowerWeightEd";
            this.lowerWeightEd.Size = new System.Drawing.Size(38, 26);
            this.lowerWeightEd.TabIndex = 21;
            this.lowerWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lowerWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // kUpEd
            // 
            this.kUpEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kUpEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.kUpEd.Location = new System.Drawing.Point(190, 16);
            this.kUpEd.myFormat = "###,###,###,###,###";
            this.kUpEd.Name = "kUpEd";
            this.kUpEd.Size = new System.Drawing.Size(70, 26);
            this.kUpEd.TabIndex = 151;
            this.kUpEd.Text = "2";
            this.kUpEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kUpEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.kUpEd.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lowerColorEd
            // 
            this.lowerColorEd.Color = System.Drawing.Color.Black;
            this.lowerColorEd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lowerColorEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lowerColorEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowerColorEd.Location = new System.Drawing.Point(120, 100);
            this.lowerColorEd.Name = "lowerColorEd";
            this.lowerColorEd.Size = new System.Drawing.Size(177, 27);
            this.lowerColorEd.TabIndex = 20;
            // 
            // upperLbl
            // 
            this.upperLbl.AutoSize = true;
            this.upperLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upperLbl.Location = new System.Drawing.Point(44, 47);
            this.upperLbl.Name = "upperLbl";
            this.upperLbl.Size = new System.Drawing.Size(46, 16);
            this.upperLbl.TabIndex = 154;
            this.upperLbl.Text = "Upper";
            // 
            // lowerLbl
            // 
            this.lowerLbl.AutoSize = true;
            this.lowerLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowerLbl.Location = new System.Drawing.Point(43, 103);
            this.lowerLbl.Name = "lowerLbl";
            this.lowerLbl.Size = new System.Drawing.Size(48, 16);
            this.lowerLbl.TabIndex = 158;
            this.lowerLbl.Text = "Lower";
            // 
            // kDownEd
            // 
            this.kDownEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kDownEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.kDownEd.Location = new System.Drawing.Point(260, 16);
            this.kDownEd.myFormat = "###,###,###,###,###";
            this.kDownEd.Name = "kDownEd";
            this.kDownEd.Size = new System.Drawing.Size(70, 26);
            this.kDownEd.TabIndex = 157;
            this.kDownEd.Text = "2";
            this.kDownEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kDownEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.kDownEd.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // middleLbl
            // 
            this.middleLbl.AutoSize = true;
            this.middleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.middleLbl.Location = new System.Drawing.Point(44, 75);
            this.middleLbl.Name = "middleLbl";
            this.middleLbl.Size = new System.Drawing.Size(49, 16);
            this.middleLbl.TabIndex = 161;
            this.middleLbl.Text = "Middle";
            // 
            // middleWeightEd
            // 
            this.middleWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.middleWeightEd.Location = new System.Drawing.Point(294, 72);
            this.middleWeightEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.middleWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.middleWeightEd.Name = "middleWeightEd";
            this.middleWeightEd.Size = new System.Drawing.Size(38, 26);
            this.middleWeightEd.TabIndex = 16;
            this.middleWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.middleWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // middleColorEd
            // 
            this.middleColorEd.Color = System.Drawing.Color.Black;
            this.middleColorEd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.middleColorEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.middleColorEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.middleColorEd.Location = new System.Drawing.Point(120, 72);
            this.middleColorEd.Name = "middleColorEd";
            this.middleColorEd.Size = new System.Drawing.Size(177, 27);
            this.middleColorEd.TabIndex = 15;
            // 
            // BBANDS
            // 
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Controls.Add(this.middleLbl);
            this.Controls.Add(this.middleWeightEd);
            this.Controls.Add(this.middleColorEd);
            this.Controls.Add(this.lowerLbl);
            this.Controls.Add(this.kDownEd);
            this.Controls.Add(this.upperLbl);
            this.Controls.Add(this.lowerWeightEd);
            this.Controls.Add(this.kUpEd);
            this.Controls.Add(this.lowerColorEd);
            this.Controls.Add(this.upperWeightEd);
            this.Controls.Add(this.periodEd);
            this.Controls.Add(this.upperColorEd);
            this.Controls.Add(this.paraLbl);
            this.Controls.Add(this.inNewPaneChk);
            this.Name = "BBANDS";
            this.Text = "BBANDS";
            this.Controls.SetChildIndex(this.inNewPaneChk, 0);
            this.Controls.SetChildIndex(this.paraLbl, 0);
            this.Controls.SetChildIndex(this.upperColorEd, 0);
            this.Controls.SetChildIndex(this.periodEd, 0);
            this.Controls.SetChildIndex(this.upperWeightEd, 0);
            this.Controls.SetChildIndex(this.lowerColorEd, 0);
            this.Controls.SetChildIndex(this.kUpEd, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.lowerWeightEd, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.removeBtn, 0);
            this.Controls.SetChildIndex(this.upperLbl, 0);
            this.Controls.SetChildIndex(this.kDownEd, 0);
            this.Controls.SetChildIndex(this.lowerLbl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.middleColorEd, 0);
            this.Controls.SetChildIndex(this.middleWeightEd, 0);
            this.Controls.SetChildIndex(this.middleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.upperWeightEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerWeightEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleWeightEd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseLabel paraLbl;
        protected common.control.ColorComboBox upperColorEd;
        protected common.control.numberTextBox periodEd;
        private System.Windows.Forms.NumericUpDown upperWeightEd;
        protected common.control.baseCheckBox inNewPaneChk;
        private System.Windows.Forms.NumericUpDown lowerWeightEd;
        protected common.control.numberTextBox kUpEd;
        protected common.control.ColorComboBox lowerColorEd;
        protected common.control.baseLabel upperLbl;
        protected common.control.baseLabel lowerLbl;
        protected common.control.numberTextBox kDownEd;
        protected common.control.baseLabel middleLbl;
        private System.Windows.Forms.NumericUpDown middleWeightEd;
        protected common.control.ColorComboBox middleColorEd;
    }
}
