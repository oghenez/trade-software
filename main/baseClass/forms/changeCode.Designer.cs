namespace application
{
    partial class changeCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changeCode));
            this.label2 = new System.Windows.Forms.Label();
            this.oldCodeEd = new System.Windows.Forms.TextBox();
            this.addLineBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.oldDescEd = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.oldCodeLb = new System.Windows.Forms.ListBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.newDescEd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.newCodeEd = new System.Windows.Forms.TextBox();
            this.deleteLineBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(18, 1);
            this.TitleLbl.Size = new System.Drawing.Size(477, 39);
            this.TitleLbl.Text = "ĐỔI MÃ KHÁCH HÀNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 150;
            this.label2.Text = "Mã số";
            // 
            // oldCodeEd
            // 
            this.oldCodeEd.Location = new System.Drawing.Point(22, 56);
            this.oldCodeEd.Name = "oldCodeEd";
            this.oldCodeEd.Size = new System.Drawing.Size(102, 24);
            this.oldCodeEd.TabIndex = 1;
            // 
            // addLineBtn
            // 
            this.addLineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLineBtn.Image = ((System.Drawing.Image)(resources.GetObject("addLineBtn.Image")));
            this.addLineBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addLineBtn.Location = new System.Drawing.Point(435, 53);
            this.addLineBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addLineBtn.Name = "addLineBtn";
            this.addLineBtn.Size = new System.Drawing.Size(81, 32);
            this.addLineBtn.TabIndex = 3;
            this.addLineBtn.Text = "&Thêm";
            this.addLineBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addLineBtn.UseVisualStyleBackColor = true;
            this.addLineBtn.Click += new System.EventHandler(this.addLineBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 158;
            this.label3.Text = "Mô tả";
            // 
            // oldDescEd
            // 
            this.oldDescEd.Location = new System.Drawing.Point(125, 56);
            this.oldDescEd.Name = "oldDescEd";
            this.oldDescEd.Size = new System.Drawing.Size(304, 24);
            this.oldDescEd.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.okBtn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.newDescEd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.newCodeEd);
            this.groupBox1.Location = new System.Drawing.Point(0, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 71);
            this.groupBox1.TabIndex = 167;
            this.groupBox1.TabStop = false;
            // 
            // oldCodeLb
            // 
            this.oldCodeLb.FormattingEnabled = true;
            this.oldCodeLb.ItemHeight = 18;
            this.oldCodeLb.Location = new System.Drawing.Point(22, 83);
            this.oldCodeLb.Name = "oldCodeLb";
            this.oldCodeLb.Size = new System.Drawing.Size(409, 256);
            this.oldCodeLb.TabIndex = 148;
            // 
            // okBtn
            // 
            this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Image = ((System.Drawing.Image)(resources.GetObject("okBtn.Image")));
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okBtn.Location = new System.Drawing.Point(411, 18);
            this.okBtn.Margin = new System.Windows.Forms.Padding(4);
            this.okBtn.Name = "okBtn";
            this.okBtn.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.okBtn.Size = new System.Drawing.Size(82, 48);
            this.okBtn.TabIndex = 30;
            this.okBtn.Text = "&Thực hiện";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 170;
            this.label4.Text = "Mô tả";
            // 
            // newDescEd
            // 
            this.newDescEd.BackColor = System.Drawing.SystemColors.Info;
            this.newDescEd.Enabled = false;
            this.newDescEd.Location = new System.Drawing.Point(127, 32);
            this.newDescEd.Name = "newDescEd";
            this.newDescEd.Size = new System.Drawing.Size(279, 24);
            this.newDescEd.TabIndex = 169;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 168;
            this.label1.Text = "Mã mới";
            // 
            // newCodeEd
            // 
            this.newCodeEd.Location = new System.Drawing.Point(24, 32);
            this.newCodeEd.Name = "newCodeEd";
            this.newCodeEd.Size = new System.Drawing.Size(102, 24);
            this.newCodeEd.TabIndex = 20;
            this.newCodeEd.Validating += new System.ComponentModel.CancelEventHandler(this.newCodeEd_Validating);
            // 
            // deleteLineBtn
            // 
            this.deleteLineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteLineBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteLineBtn.Image")));
            this.deleteLineBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteLineBtn.Location = new System.Drawing.Point(435, 87);
            this.deleteLineBtn.Margin = new System.Windows.Forms.Padding(4);
            this.deleteLineBtn.Name = "deleteLineBtn";
            this.deleteLineBtn.Size = new System.Drawing.Size(81, 32);
            this.deleteLineBtn.TabIndex = 168;
            this.deleteLineBtn.Text = "&Xóa";
            this.deleteLineBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteLineBtn.UseVisualStyleBackColor = true;
            this.deleteLineBtn.Click += new System.EventHandler(this.deleteLineBtn_Click);
            // 
            // changeCode
            // 
            this.ClientSize = new System.Drawing.Size(518, 439);
            this.Controls.Add(this.deleteLineBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.oldDescEd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addLineBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oldCodeEd);
            this.Controls.Add(this.oldCodeLb);
            this.Name = "changeCode";
            this.Controls.SetChildIndex(this.oldCodeLb, 0);
            this.Controls.SetChildIndex(this.oldCodeEd, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.addLineBtn, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.oldDescEd, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.deleteLineBtn, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox oldCodeEd;
        protected System.Windows.Forms.Button addLineBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox oldDescEd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox newDescEd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newCodeEd;
        private System.Windows.Forms.ListBox oldCodeLb;
        protected System.Windows.Forms.Button deleteLineBtn;
    }
}
