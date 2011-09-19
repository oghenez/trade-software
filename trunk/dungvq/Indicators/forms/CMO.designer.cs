namespace Indicators.forms
{
    partial class CMO
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
            this.inNewPaneChk = new common.control.baseCheckBox();
            this.weightEd1 = new System.Windows.Forms.NumericUpDown();
            this.paraEd1 = new common.control.numberTextBox();
            this.colorEd1 = new common.control.ColorComboBox();
            this.lineLbl1 = new common.control.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.weightEd1)).BeginInit();
            this.SuspendLayout();
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(121, 78);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(207, 78);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(35, 78);
            // 
            // inNewPaneChk
            // 
            this.inNewPaneChk.AutoSize = true;
            this.inNewPaneChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inNewPaneChk.Location = new System.Drawing.Point(97, 51);
            this.inNewPaneChk.Name = "inNewPaneChk";
            this.inNewPaneChk.Size = new System.Drawing.Size(189, 20);
            this.inNewPaneChk.TabIndex = 150;
            this.inNewPaneChk.Text = "Hiển thị trong cửa sổ mới";
            this.inNewPaneChk.UseVisualStyleBackColor = true;
            // 
            // weightEd1
            // 
            this.weightEd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightEd1.Location = new System.Drawing.Point(290, 17);
            this.weightEd1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.weightEd1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weightEd1.Name = "weightEd1";
            this.weightEd1.Size = new System.Drawing.Size(38, 26);
            this.weightEd1.TabIndex = 149;
            this.weightEd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.weightEd1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // paraEd1
            // 
            this.paraEd1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraEd1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.paraEd1.Location = new System.Drawing.Point(98, 17);
            this.paraEd1.myFormat = "###";
            this.paraEd1.Name = "paraEd1";
            this.paraEd1.Size = new System.Drawing.Size(45, 26);
            this.paraEd1.TabIndex = 147;
            this.paraEd1.Text = "14";
            this.paraEd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.paraEd1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.paraEd1.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // colorEd1
            // 
            this.colorEd1.Color = System.Drawing.Color.Black;
            this.colorEd1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorEd1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorEd1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorEd1.Location = new System.Drawing.Point(143, 17);
            this.colorEd1.Name = "colorEd1";
            this.colorEd1.Size = new System.Drawing.Size(150, 27);
            this.colorEd1.TabIndex = 148;
            // 
            // lineLbl1
            // 
            this.lineLbl1.AutoSize = true;
            this.lineLbl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineLbl1.Location = new System.Drawing.Point(34, 22);
            this.lineLbl1.Name = "lineLbl1";
            this.lineLbl1.Size = new System.Drawing.Size(61, 16);
            this.lineLbl1.TabIndex = 151;
            this.lineLbl1.Text = "Tham số";
            // 
            // CMO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 157);
            this.Controls.Add(this.inNewPaneChk);
            this.Controls.Add(this.weightEd1);
            this.Controls.Add(this.paraEd1);
            this.Controls.Add(this.colorEd1);
            this.Controls.Add(this.lineLbl1);
            this.Name = "CMO";
            this.Text = "CMO";
            this.Controls.SetChildIndex(this.removeBtn, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.lineLbl1, 0);
            this.Controls.SetChildIndex(this.colorEd1, 0);
            this.Controls.SetChildIndex(this.paraEd1, 0);
            this.Controls.SetChildIndex(this.weightEd1, 0);
            this.Controls.SetChildIndex(this.inNewPaneChk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.weightEd1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseCheckBox inNewPaneChk;
        private System.Windows.Forms.NumericUpDown weightEd1;
        protected common.control.numberTextBox paraEd1;
        protected common.control.ColorComboBox colorEd1;
        protected common.control.baseLabel lineLbl1;
    }
}