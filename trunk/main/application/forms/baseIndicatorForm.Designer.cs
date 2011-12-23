namespace application.forms
{
    partial class baseIndicatorForm
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
            this.saveBtn = new common.controls.baseButton();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.closeBtn.Location = new System.Drawing.Point(449, 125);
            this.closeBtn.Size = new System.Drawing.Size(102, 41);
            this.closeBtn.TabIndex = 103;
            this.closeBtn.Text = "Close";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.closeBtn.Visible = false;
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.okBtn.Location = new System.Drawing.Point(116, 131);
            this.okBtn.Size = new System.Drawing.Size(102, 41);
            this.okBtn.Text = "Draw";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(641, 33);
            this.TitleLbl.Visible = false;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = Properties.Resources.save;
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveBtn.isDownState = false;
            this.saveBtn.Location = new System.Drawing.Point(218, 131);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(102, 41);
            this.saveBtn.TabIndex = 102;
            this.saveBtn.Text = "Save Settings";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // baseIndicatorForm
            // 
            this.ClientSize = new System.Drawing.Size(424, 210);
            this.Controls.Add(this.saveBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "baseIndicatorForm";
            this.myOnProcess += new common.forms.baseDialogForm.onProcess(this.baseIndicator_myOnProcess);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.saveBtn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.controls.baseButton saveBtn;
    }
}
