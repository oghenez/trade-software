namespace baseClass.controls
{
    partial class indicatorSelection
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(indicatorSelection));
            this.indicatorClb = new baseClass.controls.clbIndicator();
            this.closeBtn = new common.control.baseButton();
            this.SuspendLayout();
            // 
            // indicatorClb
            // 
            this.indicatorClb.CheckOnClick = true;
            this.indicatorClb.FormattingEnabled = true;
            this.indicatorClb.Location = new System.Drawing.Point(-2, 1);
            this.indicatorClb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("indicatorClb.myCheckedItems")));
            this.indicatorClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("indicatorClb.myCheckedValues")));
            this.indicatorClb.myItemString = "";
            this.indicatorClb.Name = "indicatorClb";
            this.indicatorClb.Size = new System.Drawing.Size(324, 225);
            this.indicatorClb.TabIndex = 0;
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeBtn.Location = new System.Drawing.Point(261, 229);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(62, 25);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Đóng";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // indicatorSelection
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.indicatorClb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "indicatorSelection";
            this.Size = new System.Drawing.Size(324, 253);
            this.Resize += new System.EventHandler(this.indicatorSelection_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TextBox commonNameEd;
        protected clbIndicator indicatorClb;
        protected common.control.baseButton closeBtn;
    }
}
