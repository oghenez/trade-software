namespace baseClass.forms
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
            this.waitingPB.Location = new System.Drawing.Point(124, 74);
            // 
            // waitingLbl
            // 
            this.waitingLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitingLbl.Location = new System.Drawing.Point(3, 158);
            this.waitingLbl.Size = new System.Drawing.Size(305, 32);
            // 
            // splashForm
            // 
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(308, 260);
            this.Name = "splashForm";
            ((System.ComponentModel.ISupportInitialize)(this.waitingPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
