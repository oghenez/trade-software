namespace Indicators.forms
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
            this.removeBtn = new common.control.baseButton();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(262, 110);
            this.closeBtn.Size = new System.Drawing.Size(86, 26);
            this.closeBtn.TabIndex = 102;
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okBtn
            // 
            this.okBtn.Image = global::Indicators.Properties.Resources.adddata;
            this.okBtn.Location = new System.Drawing.Point(90, 110);
            this.okBtn.Size = new System.Drawing.Size(86, 26);
            this.okBtn.Text = "Vẽ";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(641, 33);
            this.TitleLbl.Visible = false;
            // 
            // removeBtn
            // 
            this.removeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeBtn.Image = global::Indicators.Properties.Resources.remove;
            this.removeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.removeBtn.Location = new System.Drawing.Point(176, 110);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(86, 26);
            this.removeBtn.TabIndex = 101;
            this.removeBtn.Text = "Hủy";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // baseIndicatorForm
            // 
            this.ClientSize = new System.Drawing.Size(432, 169);
            this.Controls.Add(this.removeBtn);
            this.Name = "baseIndicatorForm";
            this.myOnProcess += new common.forms.baseDialogForm.onProcess(this.baseIndicator_myOnProcess);
            this.Controls.SetChildIndex(this.removeBtn, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseButton removeBtn;
    }
}
