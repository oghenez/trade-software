namespace indicators.forms
{
    partial class baseIndicator
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
            this.mainColorEd = new common.control.ColorComboBox();
            this.inNewPaneChk = new baseClass.controls.baseCheckBox();
            this.removeBtn = new baseClass.controls.baseButton();
            this.curveWeightEd = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.curveWeightEd)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(286, 110);
            this.closeBtn.Size = new System.Drawing.Size(98, 26);
            this.closeBtn.TabIndex = 102;
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okBtn
            // 
            this.okBtn.Image = global::indicators.Properties.Resources.adddata;
            this.okBtn.Location = new System.Drawing.Point(90, 110);
            this.okBtn.Size = new System.Drawing.Size(98, 26);
            this.okBtn.Text = "Thực hiện";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(641, 33);
            this.TitleLbl.Visible = false;
            // 
            // mainColorEd
            // 
            this.mainColorEd.Color = System.Drawing.Color.Black;
            this.mainColorEd.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.mainColorEd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mainColorEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainColorEd.Location = new System.Drawing.Point(90, 49);
            this.mainColorEd.Name = "mainColorEd";
            this.mainColorEd.Size = new System.Drawing.Size(246, 27);
            this.mainColorEd.TabIndex = 1;
            // 
            // inNewPaneChk
            // 
            this.inNewPaneChk.AutoSize = true;
            this.inNewPaneChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inNewPaneChk.Location = new System.Drawing.Point(90, 81);
            this.inNewPaneChk.Name = "inNewPaneChk";
            this.inNewPaneChk.Size = new System.Drawing.Size(189, 20);
            this.inNewPaneChk.TabIndex = 20;
            this.inNewPaneChk.Text = "Hiển thị trong cửa sổ mới";
            this.inNewPaneChk.UseVisualStyleBackColor = true;
            // 
            // removeBtn
            // 
            this.removeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeBtn.Image = global::indicators.Properties.Resources.remove;
            this.removeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.removeBtn.Location = new System.Drawing.Point(188, 110);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(98, 26);
            this.removeBtn.TabIndex = 101;
            this.removeBtn.Text = "Hủy";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // curveWeightEd
            // 
            this.curveWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curveWeightEd.Location = new System.Drawing.Point(334, 49);
            this.curveWeightEd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.curveWeightEd.Name = "curveWeightEd";
            this.curveWeightEd.Size = new System.Drawing.Size(50, 26);
            this.curveWeightEd.TabIndex = 2;
            this.curveWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.curveWeightEd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // baseIndicator
            // 
            this.ClientSize = new System.Drawing.Size(467, 177);
            this.Controls.Add(this.curveWeightEd);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.inNewPaneChk);
            this.Controls.Add(this.mainColorEd);
            this.Name = "baseIndicator";
            this.myOnProcess += new common.forms.baseDialogForm.onProcess(this.baseIndicator_myOnProcess);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.mainColorEd, 0);
            this.Controls.SetChildIndex(this.inNewPaneChk, 0);
            this.Controls.SetChildIndex(this.removeBtn, 0);
            this.Controls.SetChildIndex(this.curveWeightEd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.curveWeightEd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.ColorComboBox mainColorEd;
        protected baseClass.controls.baseCheckBox inNewPaneChk;
        protected baseClass.controls.baseButton removeBtn;
        protected System.Windows.Forms.NumericUpDown curveWeightEd;
    }
}
