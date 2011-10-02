namespace baseClass.forms
{
    partial class sysInterestedStrategy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sysInterestedStrategy));
            this.interestedStrategy = new baseClass.controls.watchListStrategy();
            this.exitBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(968, 333);
            this.TitleLbl.Size = new System.Drawing.Size(153, 46);
            this.TitleLbl.Visible = false;
            // 
            // interestedStrategy
            // 
            this.interestedStrategy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.interestedStrategy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.interestedStrategy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestedStrategy.Location = new System.Drawing.Point(0, 1);
            this.interestedStrategy.Margin = new System.Windows.Forms.Padding(4);
            this.interestedStrategy.Name = "interestedStrategy";
            this.interestedStrategy.Size = new System.Drawing.Size(784, 611);
            this.interestedStrategy.TabIndex = 1;
            this.interestedStrategy.Load += new System.EventHandler(this.interestedStrategy_Load);
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Image = global::baseClass.Properties.Resources.close;
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.Location = new System.Drawing.Point(670, 614);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.exitBtn.Size = new System.Drawing.Size(92, 34);
            this.exitBtn.TabIndex = 102;
            this.exitBtn.Text = "&Close";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.Location = new System.Drawing.Point(486, 614);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.saveBtn.Size = new System.Drawing.Size(92, 34);
            this.saveBtn.TabIndex = 100;
            this.saveBtn.Text = "&Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Image = global::baseClass.Properties.Resources.refresh;
            this.refreshBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refreshBtn.Location = new System.Drawing.Point(578, 614);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.refreshBtn.Size = new System.Drawing.Size(92, 34);
            this.refreshBtn.TabIndex = 101;
            this.refreshBtn.Text = "&Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // sysInterestedStrategy
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 674);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.interestedStrategy);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.saveBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "sysInterestedStrategy";
            this.Text = "Interested Strategy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.sysInterestedStrategy_FormClosing);
            this.Controls.SetChildIndex(this.saveBtn, 0);
            this.Controls.SetChildIndex(this.exitBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.interestedStrategy, 0);
            this.Controls.SetChildIndex(this.refreshBtn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.watchListStrategy interestedStrategy;
        protected System.Windows.Forms.Button exitBtn;
        protected System.Windows.Forms.Button saveBtn;
        protected System.Windows.Forms.Button refreshBtn;


    }
}