namespace baseClass
{
    partial class userLogin
    {

        //common.libs.appAvailable myAvail = new common.libs.appAvailable();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(userLogin));
            this.Label10 = new baseClass.controls.baseLabel();
            this.loginEd = new common.control.baseTextBox();
            this.label1 = new baseClass.controls.baseLabel();
            this.passwordEd = new common.control.baseTextBox();
            this.loginBtn = new baseClass.controls.baseButton();
            this.exitBtn = new baseClass.controls.baseButton();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(490, 55);
            this.TitleLbl.Visible = false;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(73, 20);
            this.Label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(69, 16);
            this.Label10.TabIndex = 63;
            this.Label10.Text = "Tài khoản";
            // 
            // loginEd
            // 
            this.loginEd.Location = new System.Drawing.Point(150, 17);
            this.loginEd.Margin = new System.Windows.Forms.Padding(4);
            this.loginEd.Name = "loginEd";
            this.loginEd.Size = new System.Drawing.Size(181, 24);
            this.loginEd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 66;
            this.label1.Text = "Mật khẩu";
            // 
            // passwordEd
            // 
            this.passwordEd.Location = new System.Drawing.Point(150, 45);
            this.passwordEd.Margin = new System.Windows.Forms.Padding(4);
            this.passwordEd.Name = "passwordEd";
            this.passwordEd.PasswordChar = '*';
            this.passwordEd.Size = new System.Drawing.Size(181, 24);
            this.passwordEd.TabIndex = 2;
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Image = global::baseClass.Properties.Resources.select;
            this.loginBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loginBtn.Location = new System.Drawing.Point(150, 77);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(4);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(102, 36);
            this.loginBtn.TabIndex = 10;
            this.loginBtn.Text = "Đă&ng nhập";
            this.loginBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Image = global::baseClass.Properties.Resources.close;
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.Location = new System.Drawing.Point(252, 77);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(79, 36);
            this.exitBtn.TabIndex = 11;
            this.exitBtn.Text = "&Thoát";
            this.exitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // userLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 148);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordEd);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.loginEd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.Name = "userLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dang nhap/Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.userLogin_Load);
            this.Activated += new System.EventHandler(this.userLogin_Activated);
            this.Controls.SetChildIndex(this.loginEd, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.Label10, 0);
            this.Controls.SetChildIndex(this.passwordEd, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.exitBtn, 0);
            this.Controls.SetChildIndex(this.loginBtn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal baseClass.controls.baseLabel Label10;
        internal common.control.baseTextBox loginEd;
        internal baseClass.controls.baseLabel label1;
        internal common.control.baseTextBox passwordEd;
        private baseClass.controls.baseButton loginBtn;
        private baseClass.controls.baseButton exitBtn;
    }
}