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
            Charts.Controls.IntRange intRange1 = new Charts.Controls.IntRange();
            this.testBtn = new System.Windows.Forms.Button();
            this.graphPane = new Charts.Controls.baseGraphPanel();
            this.myGraphControl1 = new Charts.Controls.myGraphControl();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.SuspendLayout();
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
            // graphPane
            // 
            this.graphPane.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphPane.haveCloseButton = true;
            this.graphPane.isExpanded = true;
            this.graphPane.Location = new System.Drawing.Point(0, 133);
            this.graphPane.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.graphPane.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.graphPane.myWeight = 0;
            this.graphPane.Name = "graphPane";
            this.graphPane.Size = new System.Drawing.Size(954, 483);
            this.graphPane.TabIndex = 247;
            // 
            // myGraphControl1
            // 
            this.myGraphControl1.IsEnableHPan = false;
            this.myGraphControl1.IsEnableHZoom = false;
            this.myGraphControl1.IsEnableVPan = false;
            this.myGraphControl1.IsEnableVZoom = false;
            this.myGraphControl1.isPanning = false;
            this.myGraphControl1.IsShowContextMenu = false;
            this.myGraphControl1.IsShowPointValues = true;
            this.myGraphControl1.Location = new System.Drawing.Point(120, 12);
            this.myGraphControl1.myViewportX = intRange1;
            this.myGraphControl1.Name = "myGraphControl1";
            this.myGraphControl1.PanButtons = System.Windows.Forms.MouseButtons.None;
            this.myGraphControl1.PanButtons2 = System.Windows.Forms.MouseButtons.None;
            this.myGraphControl1.ScrollGrace = 0;
            this.myGraphControl1.ScrollMaxX = 0;
            this.myGraphControl1.ScrollMaxY = 0;
            this.myGraphControl1.ScrollMaxY2 = 0;
            this.myGraphControl1.ScrollMinX = 0;
            this.myGraphControl1.ScrollMinY = 0;
            this.myGraphControl1.ScrollMinY2 = 0;
            this.myGraphControl1.Size = new System.Drawing.Size(466, 94);
            this.myGraphControl1.TabIndex = 248;
            this.myGraphControl1.ZoomButtons = System.Windows.Forms.MouseButtons.None;
            this.myGraphControl1.ZoomStepFraction = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 679);
            this.Controls.Add(this.graphPane);
            this.Controls.Add(this.myGraphControl1);
            this.Controls.Add(this.testBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.testBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.myGraphControl1, 0);
            this.Controls.SetChildIndex(this.graphPane, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testBtn;
        private Charts.Controls.baseGraphPanel graphPane;
        private Charts.Controls.myGraphControl myGraphControl1;
    }
}