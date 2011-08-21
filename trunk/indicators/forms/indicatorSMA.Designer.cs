namespace indicators.forms
{
    partial class indicatorSMA
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
            this.smaVal1Lbl = new baseClass.controls.baseLabel();
            this.baseLabel1 = new baseClass.controls.baseLabel();
            this.color2Ed = new common.control.ColorComboBox();
            this.paraEd2 = new common.control.numberTextBox();
            this.paraEd1 = new common.control.numberTextBox();
            this.curveWeightLbl = new baseClass.controls.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.curveWeightEd)).BeginInit();
            this.SuspendLayout();
            // 
            // mainColorEd
            // 
            this.mainColorEd.Location = new System.Drawing.Point(221, 16);
            this.mainColorEd.Size = new System.Drawing.Size(191, 27);
            this.mainColorEd.TabIndex = 2;
            // 
            // inPricePaneChk
            // 
            this.inNewPaneChk.Location = new System.Drawing.Point(116, 103);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(214, 135);
            // 
            // curveWeightEd
            // 
            this.curveWeightEd.Location = new System.Drawing.Point(116, 71);
            this.curveWeightEd.TabIndex = 12;
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(312, 135);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(116, 135);
            // 
            // smaVal1Lbl
            // 
            this.smaVal1Lbl.AutoSize = true;
            this.smaVal1Lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smaVal1Lbl.Location = new System.Drawing.Point(38, 20);
            this.smaVal1Lbl.Name = "smaVal1Lbl";
            this.smaVal1Lbl.Size = new System.Drawing.Size(63, 16);
            this.smaVal1Lbl.TabIndex = 145;
            this.smaVal1Lbl.Text = "Đường 1";
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel1.Location = new System.Drawing.Point(38, 48);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(63, 16);
            this.baseLabel1.TabIndex = 146;
            this.baseLabel1.Text = "Đường 1";
            // 
            // color2Ed
            // 
            this.color2Ed.Color = System.Drawing.Color.Black;
            this.color2Ed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.color2Ed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.color2Ed.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.color2Ed.Location = new System.Drawing.Point(221, 44);
            this.color2Ed.Name = "color2Ed";
            this.color2Ed.Size = new System.Drawing.Size(191, 27);
            this.color2Ed.TabIndex = 11;
            // 
            // paraEd2
            // 
            this.paraEd2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraEd2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.paraEd2.Location = new System.Drawing.Point(116, 44);
            this.paraEd2.myFormat = "###,###,###,###,###";
            this.paraEd2.Name = "paraEd2";
            this.paraEd2.Size = new System.Drawing.Size(104, 26);
            this.paraEd2.TabIndex = 10;
            this.paraEd2.Text = "10";
            this.paraEd2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.paraEd2.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.paraEd2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // paraEd1
            // 
            this.paraEd1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraEd1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.paraEd1.Location = new System.Drawing.Point(116, 17);
            this.paraEd1.myFormat = "###,###,###,###,###";
            this.paraEd1.Name = "paraEd1";
            this.paraEd1.Size = new System.Drawing.Size(104, 26);
            this.paraEd1.TabIndex = 148;
            this.paraEd1.Text = "5";
            this.paraEd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.paraEd1.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.paraEd1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // curveWeightLbl
            // 
            this.curveWeightLbl.AutoSize = true;
            this.curveWeightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curveWeightLbl.Location = new System.Drawing.Point(40, 77);
            this.curveWeightLbl.Name = "curveWeightLbl";
            this.curveWeightLbl.Size = new System.Drawing.Size(54, 16);
            this.curveWeightLbl.TabIndex = 150;
            this.curveWeightLbl.Text = "Độ dày";
            // 
            // indicatorSMA
            // 
            this.ClientSize = new System.Drawing.Size(450, 197);
            this.Controls.Add(this.curveWeightLbl);
            this.Controls.Add(this.paraEd2);
            this.Controls.Add(this.paraEd1);
            this.Controls.Add(this.color2Ed);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.smaVal1Lbl);
            this.Name = "indicatorSMA";
            this.Text = "SMA";
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.mainColorEd, 0);
            this.Controls.SetChildIndex(this.inNewPaneChk, 0);
            this.Controls.SetChildIndex(this.removeBtn, 0);
            this.Controls.SetChildIndex(this.curveWeightEd, 0);
            this.Controls.SetChildIndex(this.smaVal1Lbl, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.Controls.SetChildIndex(this.color2Ed, 0);
            this.Controls.SetChildIndex(this.paraEd1, 0);
            this.Controls.SetChildIndex(this.paraEd2, 0);
            this.Controls.SetChildIndex(this.curveWeightLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.curveWeightEd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseLabel smaVal1Lbl;
        protected baseClass.controls.baseLabel baseLabel1;
        protected common.control.ColorComboBox color2Ed;
        protected common.control.numberTextBox paraEd2;
        protected common.control.numberTextBox paraEd1;
        protected baseClass.controls.baseLabel curveWeightLbl;
    }
}
