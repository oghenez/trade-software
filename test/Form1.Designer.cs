namespace test
{
    partial class Form1
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
            Charts.IntRange intRange1 = new Charts.IntRange();
            this.testBtn = new System.Windows.Forms.Button();
            this.myGraph2 = new Charts.Controls.myGraphControl();
            this.graphControl1 = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1043, 34);
            this.TitleLbl.Size = new System.Drawing.Size(32, 23);
            this.TitleLbl.Visible = false;
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(0, 2);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(75, 23);
            this.testBtn.TabIndex = 8;
            this.testBtn.Text = "Test";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // myGraph2
            // 
            this.myGraph2._save_myViewportX = intRange1;
            this.myGraph2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myGraph2.IsEnableHPan = false;
            this.myGraph2.IsEnableHZoom = false;
            this.myGraph2.IsEnableVPan = false;
            this.myGraph2.IsEnableVZoom = false;
            this.myGraph2.IsEnableWheelZoom = false;
            this.myGraph2.IsPrintFillPage = false;
            this.myGraph2.IsPrintKeepAspectRatio = false;
            this.myGraph2.IsPrintScaleAll = false;
            this.myGraph2.IsShowContextMenu = false;
            this.myGraph2.IsShowCopyMessage = false;
            this.myGraph2.IsShowPointValues = true;
            this.myGraph2.Location = new System.Drawing.Point(0, 490);
            this.myGraph2.myViewportX = intRange1;
            this.myGraph2.Name = "myGraph2";
            this.myGraph2.PanButtons = System.Windows.Forms.MouseButtons.None;
            this.myGraph2.PanButtons2 = System.Windows.Forms.MouseButtons.None;
            this.myGraph2.ScrollGrace = 0;
            this.myGraph2.ScrollMaxX = 0;
            this.myGraph2.ScrollMaxY = 0;
            this.myGraph2.ScrollMaxY2 = 0;
            this.myGraph2.ScrollMinX = 0;
            this.myGraph2.ScrollMinY = 0;
            this.myGraph2.ScrollMinY2 = 0;
            this.myGraph2.Size = new System.Drawing.Size(924, 186);
            this.myGraph2.TabIndex = 249;
            this.myGraph2.ZoomButtons = System.Windows.Forms.MouseButtons.None;
            this.myGraph2.ZoomStepFraction = 0;
            // 
            // graphControl1
            // 
            this.graphControl1.Location = new System.Drawing.Point(0, 31);
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.ScrollGrace = 0;
            this.graphControl1.ScrollMaxX = 0;
            this.graphControl1.ScrollMaxY = 0;
            this.graphControl1.ScrollMaxY2 = 0;
            this.graphControl1.ScrollMinX = 0;
            this.graphControl1.ScrollMinY = 0;
            this.graphControl1.ScrollMinY2 = 0;
            this.graphControl1.Size = new System.Drawing.Size(952, 439);
            this.graphControl1.TabIndex = 250;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 717);
            this.Controls.Add(this.graphControl1);
            this.Controls.Add(this.myGraph2);
            this.Controls.Add(this.testBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.testBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.myGraph2, 0);
            this.Controls.SetChildIndex(this.graphControl1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testBtn;
        private Charts.Controls.myGraphControl myGraph2;
        private ZedGraph.ZedGraphControl graphControl1;
    }
}