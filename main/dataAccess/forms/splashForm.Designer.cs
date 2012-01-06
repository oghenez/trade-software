namespace DataAccess.forms
{
    partial class splashForm
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
            this.waitingPB.Location = new System.Drawing.Point(107, 64);
            // 
            // waitingLbl
            // 
            this.waitingLbl.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitingLbl.Location = new System.Drawing.Point(2, 149);
            this.waitingLbl.Size = new System.Drawing.Size(256, 38);
            // 
            // splashForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(265, 240);
            this.Name = "splashForm";
            ((System.ComponentModel.ISupportInitialize)(this.waitingPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
