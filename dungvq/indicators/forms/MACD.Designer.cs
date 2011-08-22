namespace Indicators.forms
{
    partial class MACD
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
            this.paraLbl = new baseClass.controls.baseLabel();
            this.macdColorEd = new common.control.ColorComboBox();
            this.fastParaEd = new common.control.numberTextBox();
            this.macdWeightEd = new System.Windows.Forms.NumericUpDown();
            this.inNewPaneChk = new baseClass.controls.baseCheckBox();
            this.sigWeightEd = new System.Windows.Forms.NumericUpDown();
            this.slowParaEd = new common.control.numberTextBox();
            this.signalColorEd = new common.control.ColorComboBox();
            this.macdLbl2 = new baseClass.controls.baseLabel();
            this.signalLbl = new baseClass.controls.baseLabel();
            this.signalParaEd = new common.control.numberTextBox();
            this.histColorCb = new common.control.ColorComboBox();
            this.histLbl = new baseClass.controls.baseLabel();
            this.histWeightEd = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.macdWeightEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sigWeightEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histWeightEd)).BeginInit();
            this.SuspendLayout();
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(148, 156);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(246, 156);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(50, 156);
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
            // macdColorEd
            // 
            this.macdColorEd.Color = System.Drawing.Color.Black;
            this.macdColorEd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.macdColorEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.macdColorEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macdColorEd.Location = new System.Drawing.Point(120, 43);
            this.macdColorEd.Name = "macdColorEd";
            this.macdColorEd.Size = new System.Drawing.Size(177, 27);
            this.macdColorEd.TabIndex = 10;
            // 
            // fastParaEd
            // 
            this.fastParaEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastParaEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.fastParaEd.Location = new System.Drawing.Point(120, 16);
            this.fastParaEd.myFormat = "###";
            this.fastParaEd.Name = "fastParaEd";
            this.fastParaEd.Size = new System.Drawing.Size(70, 26);
            this.fastParaEd.TabIndex = 1;
            this.fastParaEd.Text = "12";
            this.fastParaEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fastParaEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.fastParaEd.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // macdWeightEd
            // 
            this.macdWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macdWeightEd.Location = new System.Drawing.Point(294, 43);
            this.macdWeightEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.macdWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.macdWeightEd.Name = "macdWeightEd";
            this.macdWeightEd.Size = new System.Drawing.Size(38, 26);
            this.macdWeightEd.TabIndex = 11;
            this.macdWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.macdWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // inNewPaneChk
            // 
            this.inNewPaneChk.AutoSize = true;
            this.inNewPaneChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inNewPaneChk.Location = new System.Drawing.Point(122, 128);
            this.inNewPaneChk.Name = "inNewPaneChk";
            this.inNewPaneChk.Size = new System.Drawing.Size(189, 20);
            this.inNewPaneChk.TabIndex = 90;
            this.inNewPaneChk.Text = "Hiển thị trong cửa sổ mới";
            this.inNewPaneChk.UseVisualStyleBackColor = true;
            // 
            // sigWeightEd
            // 
            this.sigWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sigWeightEd.Location = new System.Drawing.Point(294, 72);
            this.sigWeightEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sigWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sigWeightEd.Name = "sigWeightEd";
            this.sigWeightEd.Size = new System.Drawing.Size(38, 26);
            this.sigWeightEd.TabIndex = 21;
            this.sigWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sigWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // slowParaEd
            // 
            this.slowParaEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slowParaEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.slowParaEd.Location = new System.Drawing.Point(190, 16);
            this.slowParaEd.myFormat = "###,###,###,###,###";
            this.slowParaEd.Name = "slowParaEd";
            this.slowParaEd.Size = new System.Drawing.Size(70, 26);
            this.slowParaEd.TabIndex = 151;
            this.slowParaEd.Text = "26";
            this.slowParaEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slowParaEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.slowParaEd.Value = new decimal(new int[] {
            26,
            0,
            0,
            0});
            // 
            // signalColorEd
            // 
            this.signalColorEd.Color = System.Drawing.Color.Black;
            this.signalColorEd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.signalColorEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.signalColorEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signalColorEd.Location = new System.Drawing.Point(120, 72);
            this.signalColorEd.Name = "signalColorEd";
            this.signalColorEd.Size = new System.Drawing.Size(177, 27);
            this.signalColorEd.TabIndex = 20;
            // 
            // macdLbl2
            // 
            this.macdLbl2.AutoSize = true;
            this.macdLbl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.macdLbl2.Location = new System.Drawing.Point(44, 47);
            this.macdLbl2.Name = "macdLbl2";
            this.macdLbl2.Size = new System.Drawing.Size(46, 16);
            this.macdLbl2.TabIndex = 154;
            this.macdLbl2.Text = "MACD";
            // 
            // signalLbl
            // 
            this.signalLbl.AutoSize = true;
            this.signalLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signalLbl.Location = new System.Drawing.Point(44, 75);
            this.signalLbl.Name = "signalLbl";
            this.signalLbl.Size = new System.Drawing.Size(46, 16);
            this.signalLbl.TabIndex = 158;
            this.signalLbl.Text = "Signal";
            // 
            // signalParaEd
            // 
            this.signalParaEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signalParaEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.signalParaEd.Location = new System.Drawing.Point(260, 16);
            this.signalParaEd.myFormat = "###,###,###,###,###";
            this.signalParaEd.Name = "signalParaEd";
            this.signalParaEd.Size = new System.Drawing.Size(70, 26);
            this.signalParaEd.TabIndex = 157;
            this.signalParaEd.Text = "9";
            this.signalParaEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.signalParaEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.signalParaEd.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // histColorCb
            // 
            this.histColorCb.Color = System.Drawing.Color.Black;
            this.histColorCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.histColorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.histColorCb.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histColorCb.Location = new System.Drawing.Point(120, 98);
            this.histColorCb.Name = "histColorCb";
            this.histColorCb.Size = new System.Drawing.Size(177, 27);
            this.histColorCb.TabIndex = 30;
            // 
            // histLbl
            // 
            this.histLbl.AutoSize = true;
            this.histLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histLbl.Location = new System.Drawing.Point(44, 103);
            this.histLbl.Name = "histLbl";
            this.histLbl.Size = new System.Drawing.Size(74, 16);
            this.histLbl.TabIndex = 159;
            this.histLbl.Text = "Histogram";
            // 
            // histWeightEd
            // 
            this.histWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histWeightEd.Location = new System.Drawing.Point(294, 98);
            this.histWeightEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.histWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.histWeightEd.Name = "histWeightEd";
            this.histWeightEd.Size = new System.Drawing.Size(38, 26);
            this.histWeightEd.TabIndex = 31;
            this.histWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.histWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // macdForm
            // 
            this.ClientSize = new System.Drawing.Size(384, 223);
            this.Controls.Add(this.histLbl);
            this.Controls.Add(this.signalLbl);
            this.Controls.Add(this.signalParaEd);
            this.Controls.Add(this.histColorCb);
            this.Controls.Add(this.macdLbl2);
            this.Controls.Add(this.sigWeightEd);
            this.Controls.Add(this.slowParaEd);
            this.Controls.Add(this.signalColorEd);
            this.Controls.Add(this.inNewPaneChk);
            this.Controls.Add(this.macdWeightEd);
            this.Controls.Add(this.fastParaEd);
            this.Controls.Add(this.macdColorEd);
            this.Controls.Add(this.paraLbl);
            this.Controls.Add(this.histWeightEd);
            this.Name = "macdForm";
            this.Text = "MACD";
            this.Controls.SetChildIndex(this.histWeightEd, 0);
            this.Controls.SetChildIndex(this.paraLbl, 0);
            this.Controls.SetChildIndex(this.macdColorEd, 0);
            this.Controls.SetChildIndex(this.fastParaEd, 0);
            this.Controls.SetChildIndex(this.macdWeightEd, 0);
            this.Controls.SetChildIndex(this.inNewPaneChk, 0);
            this.Controls.SetChildIndex(this.signalColorEd, 0);
            this.Controls.SetChildIndex(this.slowParaEd, 0);
            this.Controls.SetChildIndex(this.sigWeightEd, 0);
            this.Controls.SetChildIndex(this.macdLbl2, 0);
            this.Controls.SetChildIndex(this.histColorCb, 0);
            this.Controls.SetChildIndex(this.signalParaEd, 0);
            this.Controls.SetChildIndex(this.signalLbl, 0);
            this.Controls.SetChildIndex(this.histLbl, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.removeBtn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.macdWeightEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sigWeightEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histWeightEd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseLabel paraLbl;
        protected common.control.ColorComboBox macdColorEd;
        protected common.control.numberTextBox fastParaEd;
        private System.Windows.Forms.NumericUpDown macdWeightEd;
        protected baseClass.controls.baseCheckBox inNewPaneChk;
        private System.Windows.Forms.NumericUpDown sigWeightEd;
        protected common.control.numberTextBox slowParaEd;
        protected common.control.ColorComboBox signalColorEd;
        protected baseClass.controls.baseLabel macdLbl2;
        protected baseClass.controls.baseLabel signalLbl;
        protected common.control.numberTextBox signalParaEd;
        protected common.control.ColorComboBox histColorCb;
        protected baseClass.controls.baseLabel histLbl;
        private System.Windows.Forms.NumericUpDown histWeightEd;
    }
}
