﻿namespace test
{
    partial class test
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
            this.findBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.codeEd = new common.controls.baseTextBox();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1024, 48);
            this.TitleLbl.Size = new System.Drawing.Size(34, 46);
            // 
            // findBtn
            // 
            this.findBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.findBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.findBtn.Location = new System.Drawing.Point(33, 51);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(53, 26);
            this.findBtn.TabIndex = 256;
            this.findBtn.Text = "Find";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.addBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBtn.Location = new System.Drawing.Point(86, 51);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(53, 26);
            this.addBtn.TabIndex = 257;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // codeEd
            // 
            this.codeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEd.isRequired = true;
            this.codeEd.isToUpperCase = true;
            this.codeEd.Location = new System.Drawing.Point(33, 16);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(673, 29);
            this.codeEd.TabIndex = 3;
            this.codeEd.Text = "A00000004/ChartSettings";
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 117);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.codeEd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "test";
            this.Text = "test";
            this.Controls.SetChildIndex(this.codeEd, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.findBtn, 0);
            this.Controls.SetChildIndex(this.addBtn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private common.controls.baseTextBox codeEd;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.Button addBtn;
    }
}