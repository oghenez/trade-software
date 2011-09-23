﻿namespace Indicators.forms
{
    partial class SMA
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
            this.lineLbl1 = new common.control.baseLabel();
            this.colorEd1 = new common.control.ColorComboBox();
            this.paraEd1 = new common.control.numberTextBox();
            this.weightEd1 = new System.Windows.Forms.NumericUpDown();
            this.inNewPaneChk = new common.control.baseCheckBox();
            this.weightEd2 = new System.Windows.Forms.NumericUpDown();
            this.paraEd2 = new common.control.numberTextBox();
            this.colorEd2 = new common.control.ColorComboBox();
            this.lineLbl2 = new common.control.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.weightEd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightEd2)).BeginInit();
            this.SuspendLayout();
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(141, 107);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(239, 107);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(43, 107);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(634, 33);
            // 
            // lineLbl1
            // 
            this.lineLbl1.AutoSize = true;
            this.lineLbl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineLbl1.Location = new System.Drawing.Point(40, 27);
            this.lineLbl1.Name = "lineLbl1";
            this.lineLbl1.Size = new System.Drawing.Size(63, 16);
            this.lineLbl1.TabIndex = 146;
            this.lineLbl1.Text = "Đường 1";
            // 
            // colorEd1
            // 
            this.colorEd1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorEd1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorEd1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorEd1.Location = new System.Drawing.Point(152, 23);
            this.colorEd1.Name = "colorEd1";
            this.colorEd1.Size = new System.Drawing.Size(150, 27);
            this.colorEd1.TabIndex = 2;
            // 
            // paraEd1
            // 
            this.paraEd1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraEd1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.paraEd1.Location = new System.Drawing.Point(107, 23);
            this.paraEd1.myFormat = "###";
            this.paraEd1.Name = "paraEd1";
            this.paraEd1.Size = new System.Drawing.Size(45, 26);
            this.paraEd1.TabIndex = 1;
            this.paraEd1.Text = "5";
            this.paraEd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.paraEd1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.paraEd1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // weightEd1
            // 
            this.weightEd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightEd1.Location = new System.Drawing.Point(299, 23);
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
            this.weightEd1.TabIndex = 3;
            this.weightEd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.weightEd1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // inNewPaneChk
            // 
            this.inNewPaneChk.AutoSize = true;
            this.inNewPaneChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inNewPaneChk.Location = new System.Drawing.Point(105, 80);
            this.inNewPaneChk.Name = "inNewPaneChk";
            this.inNewPaneChk.Size = new System.Drawing.Size(189, 20);
            this.inNewPaneChk.TabIndex = 20;
            this.inNewPaneChk.Text = "Show in new pane";
            this.inNewPaneChk.UseVisualStyleBackColor = true;
            // 
            // weightEd2
            // 
            this.weightEd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightEd2.Location = new System.Drawing.Point(299, 51);
            this.weightEd2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.weightEd2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weightEd2.Name = "weightEd2";
            this.weightEd2.Size = new System.Drawing.Size(38, 26);
            this.weightEd2.TabIndex = 12;
            this.weightEd2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.weightEd2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // paraEd2
            // 
            this.paraEd2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraEd2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.paraEd2.Location = new System.Drawing.Point(107, 51);
            this.paraEd2.myFormat = "###,###,###,###,###";
            this.paraEd2.Name = "paraEd2";
            this.paraEd2.Size = new System.Drawing.Size(45, 26);
            this.paraEd2.TabIndex = 151;
            this.paraEd2.Text = "10";
            this.paraEd2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.paraEd2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.paraEd2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // colorEd2
            // 
            this.colorEd2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorEd2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorEd2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorEd2.Location = new System.Drawing.Point(152, 51);
            this.colorEd2.Name = "colorEd2";
            this.colorEd2.Size = new System.Drawing.Size(150, 27);
            this.colorEd2.TabIndex = 11;
            // 
            // lineLbl2
            // 
            this.lineLbl2.AutoSize = true;
            this.lineLbl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineLbl2.Location = new System.Drawing.Point(40, 55);
            this.lineLbl2.Name = "lineLbl2";
            this.lineLbl2.Size = new System.Drawing.Size(63, 16);
            this.lineLbl2.TabIndex = 154;
            this.lineLbl2.Text = "Đường 2";
            // 
            // smaForm
            // 
            this.ClientSize = new System.Drawing.Size(374, 169);
            this.Controls.Add(this.lineLbl2);
            this.Controls.Add(this.weightEd2);
            this.Controls.Add(this.paraEd2);
            this.Controls.Add(this.colorEd2);
            this.Controls.Add(this.inNewPaneChk);
            this.Controls.Add(this.weightEd1);
            this.Controls.Add(this.paraEd1);
            this.Controls.Add(this.colorEd1);
            this.Controls.Add(this.lineLbl1);
            this.Name = "smaForm";
            this.Text = "SMA / EMA / WMA";
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.removeBtn, 0);
            this.Controls.SetChildIndex(this.lineLbl1, 0);
            this.Controls.SetChildIndex(this.colorEd1, 0);
            this.Controls.SetChildIndex(this.paraEd1, 0);
            this.Controls.SetChildIndex(this.weightEd1, 0);
            this.Controls.SetChildIndex(this.inNewPaneChk, 0);
            this.Controls.SetChildIndex(this.colorEd2, 0);
            this.Controls.SetChildIndex(this.paraEd2, 0);
            this.Controls.SetChildIndex(this.weightEd2, 0);
            this.Controls.SetChildIndex(this.lineLbl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.weightEd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightEd2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseLabel lineLbl1;
        protected common.control.ColorComboBox colorEd1;
        protected common.control.numberTextBox paraEd1;
        private System.Windows.Forms.NumericUpDown weightEd1;
        protected common.control.baseCheckBox inNewPaneChk;
        private System.Windows.Forms.NumericUpDown weightEd2;
        protected common.control.numberTextBox paraEd2;
        protected common.control.ColorComboBox colorEd2;
        protected common.control.baseLabel lineLbl2;
    }
}
