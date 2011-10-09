namespace baseClass.forms
{
    partial class investorLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(investorLogin));
            this.accountLbl = new baseClass.controls.baseLabel();
            this.accountEd = new common.controls.baseTextBox();
            this.passwordLbl = new baseClass.controls.baseLabel();
            this.passwordEd = new common.controls.baseTextBox();
            this.loginBtn = new baseClass.controls.baseButton();
            this.exitBtn = new baseClass.controls.baseButton();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(490, 55);
            this.TitleLbl.Visible = false;
            // 
            // accountLbl
            // 
            this.accountLbl.AutoSize = true;
            this.accountLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountLbl.Location = new System.Drawing.Point(73, 20);
            this.accountLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.accountLbl.Name = "accountLbl";
            this.accountLbl.Size = new System.Drawing.Size(62, 16);
            this.accountLbl.TabIndex = 63;
            this.accountLbl.Text = "Account";
            // 
            // accountEd
            // 
            this.accountEd.Location = new System.Drawing.Point(150, 17);
            this.accountEd.Margin = new System.Windows.Forms.Padding(4);
            this.accountEd.Name = "accountEd";
            this.accountEd.Size = new System.Drawing.Size(193, 23);
            this.accountEd.TabIndex = 1;
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.Location = new System.Drawing.Point(73, 46);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(71, 16);
            this.passwordLbl.TabIndex = 66;
            this.passwordLbl.Text = "Password";
            // 
            // passwordEd
            // 
            this.passwordEd.Location = new System.Drawing.Point(150, 45);
            this.passwordEd.Margin = new System.Windows.Forms.Padding(4);
            this.passwordEd.Name = "passwordEd";
            this.passwordEd.PasswordChar = '*';
            this.passwordEd.Size = new System.Drawing.Size(193, 23);
            this.passwordEd.TabIndex = 2;
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Image = global::baseClass.Properties.Resources.select;
            this.loginBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loginBtn.Location = new System.Drawing.Point(151, 77);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(4);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(96, 33);
            this.loginBtn.TabIndex = 10;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Image = global::baseClass.Properties.Resources.close;
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.Location = new System.Drawing.Point(247, 77);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(96, 33);
            this.exitBtn.TabIndex = 11;
            this.exitBtn.Text = "E&xit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // investorLogin
            // 
            this.ClientSize = new System.Drawing.Size(418, 142);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.passwordEd);
            this.Controls.Add(this.accountLbl);
            this.Controls.Add(this.accountEd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.Name = "investorLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.userLogin_Load);
            this.Activated += new System.EventHandler(this.userLogin_Activated);
            this.Controls.SetChildIndex(this.accountEd, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.accountLbl, 0);
            this.Controls.SetChildIndex(this.passwordEd, 0);
            this.Controls.SetChildIndex(this.passwordLbl, 0);
            this.Controls.SetChildIndex(this.exitBtn, 0);
            this.Controls.SetChildIndex(this.loginBtn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal baseClass.controls.baseLabel accountLbl;
        internal common.controls.baseTextBox accountEd;
        internal baseClass.controls.baseLabel passwordLbl;
        internal common.controls.baseTextBox passwordEd;
        private baseClass.controls.baseButton loginBtn;
        private baseClass.controls.baseButton exitBtn;
    }
}