namespace baseClass.forms
{
    partial class baseApplication
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
            this.loginInfoLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.sysTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // loginInfoLbl
            // 
            this.loginInfoLbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginInfoLbl.Name = "loginInfoLbl";
            this.loginInfoLbl.Size = new System.Drawing.Size(0, 17);
            this.loginInfoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sysTimer
            // 
            this.sysTimer.Interval = 2000;
            this.sysTimer.Tick += new System.EventHandler(this.sysTimer_Tick);
            // 
            // baseApplication
            // 
            this.ClientSize = new System.Drawing.Size(1080, 562);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "baseApplication";
            this.Load += new System.EventHandler(this.Form_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel loginInfoLbl;
        protected System.Windows.Forms.Timer sysTimer;

    }
}