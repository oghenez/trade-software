namespace Indicators.forms
{
    partial class AroonOsc
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
            this.aroonoscLbl2 = new baseClass.controls.baseLabel();
            this.inNewPaneChk = new baseClass.controls.baseCheckBox();
            this.aroonWeightEd = new System.Windows.Forms.NumericUpDown();
            this.periodParaEd = new common.control.numberTextBox();
            this.aroonoscColorEd = new common.control.ColorComboBox();
            this.paraLbl = new baseClass.controls.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.aroonWeightEd)).BeginInit();
            this.SuspendLayout();
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(121, 104);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(207, 104);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(35, 104);
            // 
            // aroonoscLbl2
            // 
            this.aroonoscLbl2.AutoSize = true;
            this.aroonoscLbl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aroonoscLbl2.Location = new System.Drawing.Point(27, 37);
            this.aroonoscLbl2.Name = "aroonoscLbl2";
            this.aroonoscLbl2.Size = new System.Drawing.Size(109, 16);
            this.aroonoscLbl2.TabIndex = 177;
            this.aroonoscLbl2.Text = "Aroon Oscilator";
            // 
            // inNewPaneChk
            // 
            this.inNewPaneChk.AutoSize = true;
            this.inNewPaneChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inNewPaneChk.Location = new System.Drawing.Point(104, 77);
            this.inNewPaneChk.Name = "inNewPaneChk";
            this.inNewPaneChk.Size = new System.Drawing.Size(189, 20);
            this.inNewPaneChk.TabIndex = 174;
            this.inNewPaneChk.Text = "Hiển thị trong cửa sổ mới";
            this.inNewPaneChk.UseVisualStyleBackColor = true;
            // 
            // aroonWeightEd
            // 
            this.aroonWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aroonWeightEd.Location = new System.Drawing.Point(313, 37);
            this.aroonWeightEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.aroonWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aroonWeightEd.Name = "aroonWeightEd";
            this.aroonWeightEd.Size = new System.Drawing.Size(38, 26);
            this.aroonWeightEd.TabIndex = 173;
            this.aroonWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.aroonWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // periodParaEd
            // 
            this.periodParaEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodParaEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.periodParaEd.Location = new System.Drawing.Point(139, 10);
            this.periodParaEd.myFormat = "###";
            this.periodParaEd.Name = "periodParaEd";
            this.periodParaEd.Size = new System.Drawing.Size(70, 26);
            this.periodParaEd.TabIndex = 171;
            this.periodParaEd.Text = "25";
            this.periodParaEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.periodParaEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.periodParaEd.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // aroonoscColorEd
            // 
            this.aroonoscColorEd.Color = System.Drawing.Color.Black;
            this.aroonoscColorEd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.aroonoscColorEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aroonoscColorEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aroonoscColorEd.Location = new System.Drawing.Point(139, 37);
            this.aroonoscColorEd.Name = "aroonoscColorEd";
            this.aroonoscColorEd.Size = new System.Drawing.Size(177, 27);
            this.aroonoscColorEd.TabIndex = 172;
            // 
            // paraLbl
            // 
            this.paraLbl.AutoSize = true;
            this.paraLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraLbl.Location = new System.Drawing.Point(27, 9);
            this.paraLbl.Name = "paraLbl";
            this.paraLbl.Size = new System.Drawing.Size(61, 16);
            this.paraLbl.TabIndex = 175;
            this.paraLbl.Text = "Tham số";
            // 
            // ADOSC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 169);
            this.Controls.Add(this.aroonoscLbl2);
            this.Controls.Add(this.inNewPaneChk);
            this.Controls.Add(this.aroonWeightEd);
            this.Controls.Add(this.periodParaEd);
            this.Controls.Add(this.aroonoscColorEd);
            this.Controls.Add(this.paraLbl);
            this.Name = "ADOSC";
            this.Text = "AroonOsc";
            this.Controls.SetChildIndex(this.removeBtn, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.paraLbl, 0);
            this.Controls.SetChildIndex(this.aroonoscColorEd, 0);
            this.Controls.SetChildIndex(this.periodParaEd, 0);
            this.Controls.SetChildIndex(this.aroonWeightEd, 0);
            this.Controls.SetChildIndex(this.inNewPaneChk, 0);
            this.Controls.SetChildIndex(this.aroonoscLbl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.aroonWeightEd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseLabel aroonoscLbl2;
        protected baseClass.controls.baseCheckBox inNewPaneChk;
        private System.Windows.Forms.NumericUpDown aroonWeightEd;
        protected common.control.numberTextBox periodParaEd;
        protected common.control.ColorComboBox aroonoscColorEd;
        protected baseClass.controls.baseLabel paraLbl;
    }
}