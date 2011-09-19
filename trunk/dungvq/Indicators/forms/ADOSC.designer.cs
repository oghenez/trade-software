namespace Indicators.forms
{
    partial class ADOSC
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
            this.adoscLbl2 = new common.control.baseLabel();
            this.slowParaEd = new common.control.numberTextBox();
            this.inNewPaneChk = new common.control.baseCheckBox();
            this.adoscWeightEd = new System.Windows.Forms.NumericUpDown();
            this.fastParaEd = new common.control.numberTextBox();
            this.adoscColorEd = new common.control.ColorComboBox();
            this.paraLbl = new common.control.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.adoscWeightEd)).BeginInit();
            this.SuspendLayout();
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(118, 113);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(204, 113);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(32, 113);
            // 
            // adoscLbl2
            // 
            this.adoscLbl2.AutoSize = true;
            this.adoscLbl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adoscLbl2.Location = new System.Drawing.Point(37, 48);
            this.adoscLbl2.Name = "adoscLbl2";
            this.adoscLbl2.Size = new System.Drawing.Size(52, 16);
            this.adoscLbl2.TabIndex = 170;
            this.adoscLbl2.Text = "ADOSC";
            // 
            // slowParaEd
            // 
            this.slowParaEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slowParaEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.slowParaEd.Location = new System.Drawing.Point(183, 17);
            this.slowParaEd.myFormat = "###,###,###,###,###";
            this.slowParaEd.Name = "slowParaEd";
            this.slowParaEd.Size = new System.Drawing.Size(70, 26);
            this.slowParaEd.TabIndex = 169;
            this.slowParaEd.Text = "10";
            this.slowParaEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slowParaEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.slowParaEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // inNewPaneChk
            // 
            this.inNewPaneChk.AutoSize = true;
            this.inNewPaneChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inNewPaneChk.Location = new System.Drawing.Point(101, 86);
            this.inNewPaneChk.Name = "inNewPaneChk";
            this.inNewPaneChk.Size = new System.Drawing.Size(189, 20);
            this.inNewPaneChk.TabIndex = 167;
            this.inNewPaneChk.Text = "Hiển thị trong cửa sổ mới";
            this.inNewPaneChk.UseVisualStyleBackColor = true;
            // 
            // adoscWeightEd
            // 
            this.adoscWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adoscWeightEd.Location = new System.Drawing.Point(287, 44);
            this.adoscWeightEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.adoscWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.adoscWeightEd.Name = "adoscWeightEd";
            this.adoscWeightEd.Size = new System.Drawing.Size(38, 26);
            this.adoscWeightEd.TabIndex = 162;
            this.adoscWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.adoscWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // fastParaEd
            // 
            this.fastParaEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastParaEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.fastParaEd.Location = new System.Drawing.Point(113, 17);
            this.fastParaEd.myFormat = "###";
            this.fastParaEd.Name = "fastParaEd";
            this.fastParaEd.Size = new System.Drawing.Size(70, 26);
            this.fastParaEd.TabIndex = 160;
            this.fastParaEd.Text = "3";
            this.fastParaEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fastParaEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.fastParaEd.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // adoscColorEd
            // 
            this.adoscColorEd.Color = System.Drawing.Color.Black;
            this.adoscColorEd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.adoscColorEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.adoscColorEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adoscColorEd.Location = new System.Drawing.Point(113, 44);
            this.adoscColorEd.Name = "adoscColorEd";
            this.adoscColorEd.Size = new System.Drawing.Size(177, 27);
            this.adoscColorEd.TabIndex = 161;
            // 
            // paraLbl
            // 
            this.paraLbl.AutoSize = true;
            this.paraLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraLbl.Location = new System.Drawing.Point(37, 21);
            this.paraLbl.Name = "paraLbl";
            this.paraLbl.Size = new System.Drawing.Size(61, 16);
            this.paraLbl.TabIndex = 168;
            this.paraLbl.Text = "Tham số";
            // 
            // ADOSC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 169);
            this.Controls.Add(this.adoscLbl2);
            this.Controls.Add(this.slowParaEd);
            this.Controls.Add(this.inNewPaneChk);
            this.Controls.Add(this.adoscWeightEd);
            this.Controls.Add(this.fastParaEd);
            this.Controls.Add(this.adoscColorEd);
            this.Controls.Add(this.paraLbl);
            this.Name = "ADOSC";
            this.Text = "ADOSC";
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.removeBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.paraLbl, 0);
            this.Controls.SetChildIndex(this.adoscColorEd, 0);
            this.Controls.SetChildIndex(this.fastParaEd, 0);
            this.Controls.SetChildIndex(this.adoscWeightEd, 0);
            this.Controls.SetChildIndex(this.inNewPaneChk, 0);
            this.Controls.SetChildIndex(this.slowParaEd, 0);
            this.Controls.SetChildIndex(this.adoscLbl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.adoscWeightEd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseLabel adoscLbl2;
        protected common.control.numberTextBox slowParaEd;
        protected common.control.baseCheckBox inNewPaneChk;
        private System.Windows.Forms.NumericUpDown adoscWeightEd;
        protected common.control.numberTextBox fastParaEd;
        protected common.control.ColorComboBox adoscColorEd;
        protected common.control.baseLabel paraLbl;
    }
}