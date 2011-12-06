namespace baseClass.forms
{
    partial class watchListNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(watchListNew));
            this.descriptionEd = new common.controls.baseTextBox();
            this.nameLbl = new baseClass.controls.baseLabel();
            this.codeEd = new common.controls.baseTextBox();
            this.nameEd = new common.controls.baseTextBox();
            this.descriptionLbl = new baseClass.controls.baseLabel();
            this.saveBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.codeLbl = new baseClass.controls.baseLabel();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(486, 8);
            this.TitleLbl.Size = new System.Drawing.Size(83, 46);
            // 
            // descriptionEd
            // 
            this.descriptionEd.BackColor = System.Drawing.SystemColors.Window;
            this.descriptionEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionEd.isToUpperCase = false;
            this.descriptionEd.Location = new System.Drawing.Point(27, 126);
            this.descriptionEd.Multiline = true;
            this.descriptionEd.Name = "descriptionEd";
            this.descriptionEd.Size = new System.Drawing.Size(346, 41);
            this.descriptionEd.TabIndex = 367;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(26, 56);
            this.nameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(43, 16);
            this.nameLbl.TabIndex = 369;
            this.nameLbl.Text = "Name";
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.SystemColors.Window;
            this.codeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEd.isToUpperCase = false;
            this.codeEd.Location = new System.Drawing.Point(27, 25);
            this.codeEd.Name = "codeEd";
            this.codeEd.ReadOnly = true;
            this.codeEd.Size = new System.Drawing.Size(100, 24);
            this.codeEd.TabIndex = 365;
            this.codeEd.TabStop = false;
            // 
            // nameEd
            // 
            this.nameEd.BackColor = System.Drawing.SystemColors.Window;
            this.nameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameEd.isToUpperCase = false;
            this.nameEd.Location = new System.Drawing.Point(28, 75);
            this.nameEd.Name = "nameEd";
            this.nameEd.Size = new System.Drawing.Size(344, 24);
            this.nameEd.TabIndex = 366;
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.Location = new System.Drawing.Point(27, 107);
            this.descriptionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(81, 16);
            this.descriptionLbl.TabIndex = 368;
            this.descriptionLbl.Text = "Description";
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.Location = new System.Drawing.Point(207, 174);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(83, 29);
            this.saveBtn.TabIndex = 371;
            this.saveBtn.Text = "&Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.Location = new System.Drawing.Point(290, 174);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(83, 29);
            this.exitBtn.TabIndex = 372;
            this.exitBtn.Text = "&Close";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(27, 6);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(40, 16);
            this.codeLbl.TabIndex = 373;
            this.codeLbl.Text = "Code";
            // 
            // watchListNew
            // 
            this.ClientSize = new System.Drawing.Size(397, 231);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.descriptionEd);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.codeEd);
            this.Controls.Add(this.nameEd);
            this.Controls.Add(this.descriptionLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "watchListNew";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Watch List";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.descriptionLbl, 0);
            this.Controls.SetChildIndex(this.nameEd, 0);
            this.Controls.SetChildIndex(this.codeEd, 0);
            this.Controls.SetChildIndex(this.nameLbl, 0);
            this.Controls.SetChildIndex(this.descriptionEd, 0);
            this.Controls.SetChildIndex(this.exitBtn, 0);
            this.Controls.SetChildIndex(this.saveBtn, 0);
            this.Controls.SetChildIndex(this.codeLbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.controls.baseTextBox descriptionEd;
        protected baseClass.controls.baseLabel nameLbl;
        protected common.controls.baseTextBox codeEd;
        protected common.controls.baseTextBox nameEd;
        protected baseClass.controls.baseLabel descriptionLbl;
        protected System.Windows.Forms.Button saveBtn;
        protected System.Windows.Forms.Button exitBtn;
        protected baseClass.controls.baseLabel codeLbl;
    }
}