namespace client.forms
{
    partial class startSplash
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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.waitingPB)).BeginInit();
            this.SuspendLayout();
            // 
            // waitingPB
            // 
            this.waitingPB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.waitingPB.Image = global::client.Properties.Resources.waiting_bar;
            this.waitingPB.Location = new System.Drawing.Point(0, 347);
            this.waitingPB.Size = new System.Drawing.Size(402, 19);
            // 
            // waitingLbl
            // 
            this.waitingLbl.BackColor = System.Drawing.Color.Transparent;
            this.waitingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitingLbl.ForeColor = System.Drawing.Color.Black;
            this.waitingLbl.Location = new System.Drawing.Point(468, 140);
            this.waitingLbl.Size = new System.Drawing.Size(282, 35);
            this.waitingLbl.Text = "";
            this.waitingLbl.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(0, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "AUTOMATE TRADING SYSTEM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startSplash
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::client.Properties.Resources.trading2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(402, 366);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "startSplash";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.waitingPB, 0);
            this.Controls.SetChildIndex(this.waitingLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.waitingPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}
