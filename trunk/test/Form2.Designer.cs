namespace test
{
    partial class Form2
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
            this.button1 = new System.Windows.Forms.Button();
            this.myGraphObj = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // myGraphObj
            // 
            this.myGraphObj.Location = new System.Drawing.Point(-2, 28);
            this.myGraphObj.Name = "myGraphObj";
            this.myGraphObj.ScrollGrace = 0;
            this.myGraphObj.ScrollMaxX = 0;
            this.myGraphObj.ScrollMaxY = 0;
            this.myGraphObj.ScrollMaxY2 = 0;
            this.myGraphObj.ScrollMinX = 0;
            this.myGraphObj.ScrollMinY = 0;
            this.myGraphObj.ScrollMinY2 = 0;
            this.myGraphObj.Size = new System.Drawing.Size(877, 220);
            this.myGraphObj.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 623);
            this.Controls.Add(this.myGraphObj);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        protected ZedGraph.ZedGraphControl myGraphObj;


    }
}