namespace common.forms
{
    partial class dataViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dataViewer));
            this.phanLoaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gridViewer = new common.controls.gridViewer();
            this.exportBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(895, 28);
            this.TitleLbl.Size = new System.Drawing.Size(394, 36);
            this.TitleLbl.Visible = false;
            // 
            // phanLoaiToolStripMenuItem
            // 
            this.phanLoaiToolStripMenuItem.Name = "phanLoaiToolStripMenuItem";
            this.phanLoaiToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.phanLoaiToolStripMenuItem.Text = "Phân loại";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.userToolStripMenuItem.Text = "Người sử dụng";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.loginToolStripMenuItem.Text = "Đăng nhập";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(199, 6);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.setupToolStripMenuItem.Text = "Thiết lập hệ thống";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(199, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::common.Properties.Resources.export;
            this.exitToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exitToolStripMenuItem.Text = "Kết thúc";
            this.exitToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gridViewer
            // 
            this.gridViewer.Location = new System.Drawing.Point(-4, 42);
            this.gridViewer.Margin = new System.Windows.Forms.Padding(4);
            this.gridViewer.Name = "gridViewer";
            this.gridViewer.Size = new System.Drawing.Size(889, 505);
            this.gridViewer.TabIndex = 146;
            // 
            // exportBtn
            // 
            this.exportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn.Location = new System.Drawing.Point(0, 1);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(125, 28);
            this.exportBtn.TabIndex = 147;
            this.exportBtn.Text = "Xuất dữ liệu";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // dataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 560);
            this.Controls.Add(this.gridViewer);
            this.Controls.Add(this.exportBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "dataViewer";
            this.Text = " Kiem tra du lieu";
            this.SizeChanged += new System.EventHandler(this.dataViewer_SizeChanged);
            this.Controls.SetChildIndex(this.exportBtn, 0);
            this.Controls.SetChildIndex(this.gridViewer, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem phanLoaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        public common.controls.gridViewer gridViewer;
        private System.Windows.Forms.Button exportBtn;

    }
}