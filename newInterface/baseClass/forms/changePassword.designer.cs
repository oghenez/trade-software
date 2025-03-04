namespace baseClass.forms
{
    partial class changePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changePassword));
            this.loginLbl = new common.controls.baseLabel();
            this.loginEd = new common.controls.baseTextBox();
            this.oldPasswordLbl = new common.controls.baseLabel();
            this.oldPasswordEd = new common.controls.baseTextBox();
            this.newPassword1Lbl = new common.controls.baseLabel();
            this.newPassword1Ed = new common.controls.baseTextBox();
            this.newPassword2Lbl = new common.controls.baseLabel();
            this.newPassword2Ed = new common.controls.baseTextBox();
            this.passStrenghtLbl = new common.controls.baseLabel();
            this.passwordMatchLbl = new common.controls.baseLabel();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(249, 111);
            this.closeBtn.Size = new System.Drawing.Size(84, 26);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(165, 111);
            this.okBtn.Size = new System.Drawing.Size(84, 26);
            this.okBtn.Text = "Ok";
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(490, 55);
            // 
            // loginLbl
            // 
            this.loginLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLbl.Location = new System.Drawing.Point(65, 13);
            this.loginLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loginLbl.Name = "loginLbl";
            this.loginLbl.Size = new System.Drawing.Size(95, 18);
            this.loginLbl.TabIndex = 63;
            this.loginLbl.Text = "Tài khoản";
            // 
            // loginEd
            // 
            this.loginEd.isRequired = true;
            this.loginEd.isToUpperCase = false;
            this.loginEd.Location = new System.Drawing.Point(165, 11);
            this.loginEd.Margin = new System.Windows.Forms.Padding(4);
            this.loginEd.Name = "loginEd";
            this.loginEd.Size = new System.Drawing.Size(167, 20);
            this.loginEd.TabIndex = 1;
            // 
            // oldPasswordLbl
            // 
            this.oldPasswordLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldPasswordLbl.Location = new System.Drawing.Point(65, 37);
            this.oldPasswordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.oldPasswordLbl.Name = "oldPasswordLbl";
            this.oldPasswordLbl.Size = new System.Drawing.Size(95, 18);
            this.oldPasswordLbl.TabIndex = 66;
            this.oldPasswordLbl.Text = "Mật khẩu cũ";
            // 
            // oldPasswordEd
            // 
            this.oldPasswordEd.isRequired = true;
            this.oldPasswordEd.isToUpperCase = false;
            this.oldPasswordEd.Location = new System.Drawing.Point(165, 36);
            this.oldPasswordEd.Margin = new System.Windows.Forms.Padding(4);
            this.oldPasswordEd.Name = "oldPasswordEd";
            this.oldPasswordEd.PasswordChar = '*';
            this.oldPasswordEd.Size = new System.Drawing.Size(167, 20);
            this.oldPasswordEd.TabIndex = 2;
            // 
            // newPassword1Lbl
            // 
            this.newPassword1Lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassword1Lbl.Location = new System.Drawing.Point(65, 63);
            this.newPassword1Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newPassword1Lbl.Name = "newPassword1Lbl";
            this.newPassword1Lbl.Size = new System.Drawing.Size(95, 18);
            this.newPassword1Lbl.TabIndex = 146;
            this.newPassword1Lbl.Text = "Mật khẩu";
            // 
            // newPassword1Ed
            // 
            this.newPassword1Ed.BackColor = System.Drawing.Color.PapayaWhip;
            this.newPassword1Ed.isRequired = true;
            this.newPassword1Ed.isToUpperCase = false;
            this.newPassword1Ed.Location = new System.Drawing.Point(165, 61);
            this.newPassword1Ed.Margin = new System.Windows.Forms.Padding(4);
            this.newPassword1Ed.Name = "newPassword1Ed";
            this.newPassword1Ed.PasswordChar = '*';
            this.newPassword1Ed.Size = new System.Drawing.Size(167, 20);
            this.newPassword1Ed.TabIndex = 3;
            this.newPassword1Ed.TextChanged += new System.EventHandler(this.newPassword1Ed_TextChanged);
            // 
            // newPassword2Lbl
            // 
            this.newPassword2Lbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassword2Lbl.Location = new System.Drawing.Point(65, 87);
            this.newPassword2Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newPassword2Lbl.Name = "newPassword2Lbl";
            this.newPassword2Lbl.Size = new System.Drawing.Size(95, 18);
            this.newPassword2Lbl.TabIndex = 148;
            this.newPassword2Lbl.Text = "Nhập lại";
            // 
            // newPassword2Ed
            // 
            this.newPassword2Ed.BackColor = System.Drawing.Color.PapayaWhip;
            this.newPassword2Ed.isRequired = true;
            this.newPassword2Ed.isToUpperCase = false;
            this.newPassword2Ed.Location = new System.Drawing.Point(165, 84);
            this.newPassword2Ed.Margin = new System.Windows.Forms.Padding(4);
            this.newPassword2Ed.Name = "newPassword2Ed";
            this.newPassword2Ed.PasswordChar = '*';
            this.newPassword2Ed.Size = new System.Drawing.Size(167, 20);
            this.newPassword2Ed.TabIndex = 4;
            this.newPassword2Ed.TextChanged += new System.EventHandler(this.newPassword2Ed_TextChanged);
            // 
            // passStrenghtLbl
            // 
            this.passStrenghtLbl.AutoSize = true;
            this.passStrenghtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passStrenghtLbl.Location = new System.Drawing.Point(340, 61);
            this.passStrenghtLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passStrenghtLbl.Name = "passStrenghtLbl";
            this.passStrenghtLbl.Size = new System.Drawing.Size(16, 16);
            this.passStrenghtLbl.TabIndex = 149;
            this.passStrenghtLbl.Text = "  ";
            // 
            // passwordMatchLbl
            // 
            this.passwordMatchLbl.AutoSize = true;
            this.passwordMatchLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordMatchLbl.Location = new System.Drawing.Point(340, 86);
            this.passwordMatchLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordMatchLbl.Name = "passwordMatchLbl";
            this.passwordMatchLbl.Size = new System.Drawing.Size(16, 16);
            this.passwordMatchLbl.TabIndex = 150;
            this.passwordMatchLbl.Text = "  ";
            // 
            // changePassword
            // 
            this.ClientSize = new System.Drawing.Size(466, 169);
            this.Controls.Add(this.passwordMatchLbl);
            this.Controls.Add(this.passStrenghtLbl);
            this.Controls.Add(this.newPassword2Lbl);
            this.Controls.Add(this.newPassword2Ed);
            this.Controls.Add(this.newPassword1Lbl);
            this.Controls.Add(this.newPassword1Ed);
            this.Controls.Add(this.oldPasswordLbl);
            this.Controls.Add(this.oldPasswordEd);
            this.Controls.Add(this.loginLbl);
            this.Controls.Add(this.loginEd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "changePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay doi mat khau";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.loginEd, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.loginLbl, 0);
            this.Controls.SetChildIndex(this.oldPasswordEd, 0);
            this.Controls.SetChildIndex(this.oldPasswordLbl, 0);
            this.Controls.SetChildIndex(this.newPassword1Ed, 0);
            this.Controls.SetChildIndex(this.newPassword1Lbl, 0);
            this.Controls.SetChildIndex(this.newPassword2Ed, 0);
            this.Controls.SetChildIndex(this.newPassword2Lbl, 0);
            this.Controls.SetChildIndex(this.passStrenghtLbl, 0);
            this.Controls.SetChildIndex(this.passwordMatchLbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal common.controls.baseLabel loginLbl;
        internal common.controls.baseTextBox loginEd;
        internal common.controls.baseLabel oldPasswordLbl;
        internal common.controls.baseTextBox oldPasswordEd;
        internal common.controls.baseLabel newPassword1Lbl;
        internal common.controls.baseTextBox newPassword1Ed;
        internal common.controls.baseLabel newPassword2Lbl;
        internal common.controls.baseTextBox newPassword2Ed;
        internal common.controls.baseLabel passStrenghtLbl;
        internal common.controls.baseLabel passwordMatchLbl;
    }
}