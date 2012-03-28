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
            ((System.ComponentModel.ISupportInitialize)(this.waitingPB)).BeginInit();
            this.SuspendLayout();
            // 
            // waitingPB
            // 
            this.waitingPB.Image = global::client.Properties.Resources.waiting_bar;
            this.waitingPB.Location = new System.Drawing.Point(28, 253);
            this.waitingPB.Size = new System.Drawing.Size(310, 8);
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
            // startSplash
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::client.Properties.Resources.trading2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(358, 267);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "startSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.waitingPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

    }
}
