namespace common.forms
{
	partial class baseForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseForm));
            this.TitleLbl = new System.Windows.Forms.Label();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.myStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.messageLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.myStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TitleLbl.Location = new System.Drawing.Point(0, 2);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(434, 46);
            this.TitleLbl.TabIndex = 143;
            this.TitleLbl.Text = "baseForm";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // myStatusStrip
            // 
            this.myStatusStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLbl,
            this.messageLbl,
            this.progressBar});
            this.myStatusStrip.Location = new System.Drawing.Point(0, 316);
            this.myStatusStrip.Name = "myStatusStrip";
            this.myStatusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.myStatusStrip.Size = new System.Drawing.Size(434, 26);
            this.myStatusStrip.TabIndex = 144;
            this.myStatusStrip.MouseHover += new System.EventHandler(this.myStatusStrip_MouseHover);
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = false;
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(45, 21);
            this.statusLbl.Text = "   ";
            // 
            // messageLbl
            // 
            this.messageLbl.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(359, 21);
            this.messageLbl.Spring = true;
            this.messageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.AutoSize = false;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(150, 20);
            this.progressBar.Visible = false;
            // 
            // baseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(434, 342);
            this.Controls.Add(this.myStatusStrip);
            this.Controls.Add(this.TitleLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "baseForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.baseForm_FormClosing);
            this.myStatusStrip.ResumeLayout(false);
            this.myStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        protected System.Windows.Forms.Label TitleLbl;
        protected System.Windows.Forms.ToolTip myToolTip;
        protected System.Windows.Forms.ToolStripStatusLabel messageLbl;
        private System.Windows.Forms.ToolStripStatusLabel statusLbl;
        protected System.Windows.Forms.StatusStrip myStatusStrip;
        protected System.Windows.Forms.ToolStripProgressBar progressBar;
	}
}