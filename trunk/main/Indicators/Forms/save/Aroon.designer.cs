namespace Indicators.forms
{
    partial class Aroon
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
            this.aroonDownLbl = new common.control.baseLabel();
            this.aroonUpLbl = new common.control.baseLabel();
            this.aroonDownWeightEd = new System.Windows.Forms.NumericUpDown();
            this.aroonDownColorEd = new common.control.ColorComboBox();
            this.inNewPaneChk = new common.control.baseCheckBox();
            this.aroonUpWeightEd = new System.Windows.Forms.NumericUpDown();
            this.fastParaEd = new common.control.numberTextBox();
            this.aroonUpColorEd = new common.control.ColorComboBox();
            this.paraLbl = new common.control.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.aroonDownWeightEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aroonUpWeightEd)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(223, 132);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(51, 132);
            // 
            // aroonDownLbl
            // 
            this.aroonDownLbl.AutoSize = true;
            this.aroonDownLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aroonDownLbl.Location = new System.Drawing.Point(44, 71);
            this.aroonDownLbl.Name = "aroonDownLbl";
            this.aroonDownLbl.Size = new System.Drawing.Size(88, 16);
            this.aroonDownLbl.TabIndex = 172;
            this.aroonDownLbl.Text = "Aroon Down";
            // 
            // aroonUpLbl
            // 
            this.aroonUpLbl.AutoSize = true;
            this.aroonUpLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aroonUpLbl.Location = new System.Drawing.Point(44, 45);
            this.aroonUpLbl.Name = "aroonUpLbl";
            this.aroonUpLbl.Size = new System.Drawing.Size(68, 16);
            this.aroonUpLbl.TabIndex = 170;
            this.aroonUpLbl.Text = "Aroon Up";
            // 
            // aroonDownWeightEd
            // 
            this.aroonDownWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aroonDownWeightEd.Location = new System.Drawing.Point(306, 70);
            this.aroonDownWeightEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.aroonDownWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aroonDownWeightEd.Name = "aroonDownWeightEd";
            this.aroonDownWeightEd.Size = new System.Drawing.Size(38, 26);
            this.aroonDownWeightEd.TabIndex = 164;
            this.aroonDownWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.aroonDownWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // aroonDownColorEd
            // 
            this.aroonDownColorEd.Color = System.Drawing.Color.Black;
            this.aroonDownColorEd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.aroonDownColorEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aroonDownColorEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aroonDownColorEd.Location = new System.Drawing.Point(132, 70);
            this.aroonDownColorEd.Name = "aroonDownColorEd";
            this.aroonDownColorEd.Size = new System.Drawing.Size(177, 27);
            this.aroonDownColorEd.TabIndex = 163;
            // 
            // inNewPaneChk
            // 
            this.inNewPaneChk.AutoSize = true;
            this.inNewPaneChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inNewPaneChk.Location = new System.Drawing.Point(90, 105);
            this.inNewPaneChk.Name = "inNewPaneChk";
            this.inNewPaneChk.Size = new System.Drawing.Size(189, 20);
            this.inNewPaneChk.TabIndex = 167;
            this.inNewPaneChk.Text = "Hiển thị trong cửa sổ mới";
            this.inNewPaneChk.UseVisualStyleBackColor = true;
            // 
            // aroonUpWeightEd
            // 
            this.aroonUpWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aroonUpWeightEd.Location = new System.Drawing.Point(306, 41);
            this.aroonUpWeightEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.aroonUpWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.aroonUpWeightEd.Name = "aroonUpWeightEd";
            this.aroonUpWeightEd.Size = new System.Drawing.Size(38, 26);
            this.aroonUpWeightEd.TabIndex = 162;
            this.aroonUpWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.aroonUpWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // fastParaEd
            // 
            this.fastParaEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastParaEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.fastParaEd.Location = new System.Drawing.Point(132, 14);
            this.fastParaEd.myFormat = "###";
            this.fastParaEd.Name = "fastParaEd";
            this.fastParaEd.Size = new System.Drawing.Size(70, 26);
            this.fastParaEd.TabIndex = 160;
            this.fastParaEd.Text = "25";
            this.fastParaEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fastParaEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.fastParaEd.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // aroonUpColorEd
            // 
            this.aroonUpColorEd.Color = System.Drawing.Color.Black;
            this.aroonUpColorEd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.aroonUpColorEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aroonUpColorEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aroonUpColorEd.Location = new System.Drawing.Point(132, 41);
            this.aroonUpColorEd.Name = "aroonUpColorEd";
            this.aroonUpColorEd.Size = new System.Drawing.Size(177, 27);
            this.aroonUpColorEd.TabIndex = 161;
            // 
            // paraLbl
            // 
            this.paraLbl.AutoSize = true;
            this.paraLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraLbl.Location = new System.Drawing.Point(44, 18);
            this.paraLbl.Name = "paraLbl";
            this.paraLbl.Size = new System.Drawing.Size(61, 16);
            this.paraLbl.TabIndex = 168;
            this.paraLbl.Text = "Tham số";
            // 
            // Aroon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            
            this.ClientSize = new System.Drawing.Size(369, 200);
            this.Controls.Add(this.aroonDownLbl);
            this.Controls.Add(this.aroonUpLbl);
            this.Controls.Add(this.aroonDownWeightEd);
            this.Controls.Add(this.aroonDownColorEd);
            this.Controls.Add(this.inNewPaneChk);
            this.Controls.Add(this.aroonUpWeightEd);
            this.Controls.Add(this.fastParaEd);
            this.Controls.Add(this.aroonUpColorEd);
            this.Controls.Add(this.paraLbl);
            this.Name = "Aroon";
            this.Text = "Aroon";
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.paraLbl, 0);
            this.Controls.SetChildIndex(this.aroonUpColorEd, 0);
            this.Controls.SetChildIndex(this.fastParaEd, 0);
            this.Controls.SetChildIndex(this.aroonUpWeightEd, 0);
            this.Controls.SetChildIndex(this.inNewPaneChk, 0);
            this.Controls.SetChildIndex(this.aroonDownColorEd, 0);
            this.Controls.SetChildIndex(this.aroonDownWeightEd, 0);
            this.Controls.SetChildIndex(this.aroonUpLbl, 0);
            this.Controls.SetChildIndex(this.aroonDownLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.aroonDownWeightEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aroonUpWeightEd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseLabel aroonDownLbl;
        protected common.control.baseLabel aroonUpLbl;
        private System.Windows.Forms.NumericUpDown aroonDownWeightEd;
        protected common.control.ColorComboBox aroonDownColorEd;
        protected common.control.baseCheckBox inNewPaneChk;
        private System.Windows.Forms.NumericUpDown aroonUpWeightEd;
        protected common.control.numberTextBox fastParaEd;
        protected common.control.ColorComboBox aroonUpColorEd;
        protected common.control.baseLabel paraLbl;
    }
}