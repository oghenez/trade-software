namespace test1.Item
{
    partial class IndicatorItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIndicator = new System.Windows.Forms.Button();
            this.lbIndicator = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnIndicator
            // 
            this.btnIndicator.BackgroundImage = global::test1.Properties.Resources.indicator_icon;
            this.btnIndicator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIndicator.Location = new System.Drawing.Point(3, 3);
            this.btnIndicator.Name = "btnIndicator";
            this.btnIndicator.Size = new System.Drawing.Size(16, 17);
            this.btnIndicator.TabIndex = 0;
            this.btnIndicator.UseVisualStyleBackColor = true;
            // 
            // lbIndicator
            // 
            this.lbIndicator.AutoSize = true;
            this.lbIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIndicator.Location = new System.Drawing.Point(24, 4);
            this.lbIndicator.Name = "lbIndicator";
            this.lbIndicator.Size = new System.Drawing.Size(23, 13);
            this.lbIndicator.TabIndex = 1;
            this.lbIndicator.TabStop = true;
            this.lbIndicator.Text = "link";
            this.lbIndicator.Resize += new System.EventHandler(this.lbIndicator_Resize);
            // 
            // IndicatorItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbIndicator);
            this.Controls.Add(this.btnIndicator);
            this.Name = "IndicatorItem";
            this.Size = new System.Drawing.Size(209, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIndicator;
        private System.Windows.Forms.LinkLabel lbIndicator;
    }
}
