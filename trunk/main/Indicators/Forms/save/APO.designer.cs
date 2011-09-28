namespace Indicators.forms
{
    partial class APO
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
            this.aroonoscLbl2 = new common.control.baseLabel();
            this.inNewPaneChk = new common.control.baseCheckBox();
            this.apoWeightEd = new System.Windows.Forms.NumericUpDown();
            this.fastperiodParaEd = new common.control.numberTextBox();
            this.apoColorEd = new common.control.ColorComboBox();
            this.paraLbl = new common.control.baseLabel();
            this.slowperiodparaEd = new common.control.numberTextBox();
            this.maTypePara = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.apoWeightEd)).BeginInit();
            this.SuspendLayout();
            // 
            // aroonoscLbl2
            // 
            this.aroonoscLbl2.AutoSize = true;
            this.aroonoscLbl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aroonoscLbl2.Location = new System.Drawing.Point(54, 49);
            this.aroonoscLbl2.Name = "aroonoscLbl2";
            this.aroonoscLbl2.Size = new System.Drawing.Size(35, 16);
            this.aroonoscLbl2.TabIndex = 183;
            this.aroonoscLbl2.Text = "APO";
            // 
            // inNewPaneChk
            // 
            this.inNewPaneChk.AutoSize = true;
            this.inNewPaneChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inNewPaneChk.Location = new System.Drawing.Point(126, 75);
            this.inNewPaneChk.Name = "inNewPaneChk";
            this.inNewPaneChk.Size = new System.Drawing.Size(189, 20);
            this.inNewPaneChk.TabIndex = 181;
            this.inNewPaneChk.Text = "Hiển thị trong cửa sổ mới";
            this.inNewPaneChk.UseVisualStyleBackColor = true;
            // 
            // apoWeightEd
            // 
            this.apoWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apoWeightEd.Location = new System.Drawing.Point(301, 40);
            this.apoWeightEd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.apoWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.apoWeightEd.Name = "apoWeightEd";
            this.apoWeightEd.Size = new System.Drawing.Size(38, 26);
            this.apoWeightEd.TabIndex = 180;
            this.apoWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.apoWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // fastperiodParaEd
            // 
            this.fastperiodParaEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fastperiodParaEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.fastperiodParaEd.Location = new System.Drawing.Point(127, 11);
            this.fastperiodParaEd.myFormat = "###";
            this.fastperiodParaEd.Name = "fastperiodParaEd";
            this.fastperiodParaEd.Size = new System.Drawing.Size(47, 26);
            this.fastperiodParaEd.TabIndex = 178;
            this.fastperiodParaEd.Text = "10";
            this.fastperiodParaEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fastperiodParaEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.fastperiodParaEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // apoColorEd
            // 
            this.apoColorEd.Color = System.Drawing.Color.Black;
            this.apoColorEd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.apoColorEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.apoColorEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apoColorEd.isColorListLoaded = false;
            this.apoColorEd.Location = new System.Drawing.Point(127, 40);
            this.apoColorEd.Name = "apoColorEd";
            this.apoColorEd.Size = new System.Drawing.Size(177, 27);
            this.apoColorEd.TabIndex = 179;
            // 
            // paraLbl
            // 
            this.paraLbl.AutoSize = true;
            this.paraLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraLbl.Location = new System.Drawing.Point(54, 19);
            this.paraLbl.Name = "paraLbl";
            this.paraLbl.Size = new System.Drawing.Size(61, 16);
            this.paraLbl.TabIndex = 182;
            this.paraLbl.Text = "Tham số";
            // 
            // slowperiodparaEd
            // 
            this.slowperiodparaEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slowperiodparaEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.slowperiodparaEd.Location = new System.Drawing.Point(174, 11);
            this.slowperiodparaEd.myFormat = "###";
            this.slowperiodparaEd.Name = "slowperiodparaEd";
            this.slowperiodparaEd.Size = new System.Drawing.Size(47, 26);
            this.slowperiodparaEd.TabIndex = 178;
            this.slowperiodparaEd.Text = "30";
            this.slowperiodparaEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slowperiodparaEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.slowperiodparaEd.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // maTypePara
            // 
            this.maTypePara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maTypePara.FormattingEnabled = true;
            this.maTypePara.Items.AddRange(new object[] {
            "Dema",
            "Ema",
            "Kama",
            "Mama",
            "Sma",
            "T3",
            "Tema",
            "Trima",
            "Wma"});
            this.maTypePara.Location = new System.Drawing.Point(221, 11);
            this.maTypePara.Name = "maTypePara";
            this.maTypePara.Size = new System.Drawing.Size(118, 24);
            this.maTypePara.TabIndex = 184;
            // 
            // APO
            // 
            this.ClientSize = new System.Drawing.Size(432, 169);
            this.Controls.Add(this.maTypePara);
            this.Controls.Add(this.aroonoscLbl2);
            this.Controls.Add(this.inNewPaneChk);
            this.Controls.Add(this.apoWeightEd);
            this.Controls.Add(this.slowperiodparaEd);
            this.Controls.Add(this.fastperiodParaEd);
            this.Controls.Add(this.apoColorEd);
            this.Controls.Add(this.paraLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "APO";
            this.Text = "APO";
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.paraLbl, 0);
            this.Controls.SetChildIndex(this.apoColorEd, 0);
            this.Controls.SetChildIndex(this.fastperiodParaEd, 0);
            this.Controls.SetChildIndex(this.slowperiodparaEd, 0);
            this.Controls.SetChildIndex(this.apoWeightEd, 0);
            this.Controls.SetChildIndex(this.inNewPaneChk, 0);
            this.Controls.SetChildIndex(this.aroonoscLbl2, 0);
            this.Controls.SetChildIndex(this.maTypePara, 0);
            ((System.ComponentModel.ISupportInitialize)(this.apoWeightEd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseLabel aroonoscLbl2;
        protected common.control.baseCheckBox inNewPaneChk;
        private System.Windows.Forms.NumericUpDown apoWeightEd;
        protected common.control.numberTextBox fastperiodParaEd;
        protected common.control.ColorComboBox apoColorEd;
        protected common.control.baseLabel paraLbl;
        protected common.control.numberTextBox slowperiodparaEd;
        private System.Windows.Forms.ComboBox maTypePara;
    }
}