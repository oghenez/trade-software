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
            Charts.Controls.IntRange intRange1 = new Charts.Controls.IntRange();
            Charts.Controls.IntRange intRange2 = new Charts.Controls.IntRange();
            this.zoomOutBtn = new System.Windows.Forms.Button();
            this.zoomInBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.reloadBtn = new System.Windows.Forms.Button();
            this.myPriceGraphObj = new Charts.Controls.myGraphControl();
            this.myVolumeGraphObj = new Charts.Controls.myGraphControl();
            this.SuspendLayout();
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.Image = global::test.Properties.Resources.zoomOut;
            this.zoomOutBtn.Location = new System.Drawing.Point(241, 2);
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.Size = new System.Drawing.Size(27, 23);
            this.zoomOutBtn.TabIndex = 11;
            this.zoomOutBtn.UseVisualStyleBackColor = true;
            this.zoomOutBtn.Click += new System.EventHandler(this.zoomOutBtn_Click);
            // 
            // zoomInBtn
            // 
            this.zoomInBtn.Image = global::test.Properties.Resources.zoomIn;
            this.zoomInBtn.Location = new System.Drawing.Point(213, 2);
            this.zoomInBtn.Name = "zoomInBtn";
            this.zoomInBtn.Size = new System.Drawing.Size(27, 23);
            this.zoomInBtn.TabIndex = 10;
            this.zoomInBtn.UseVisualStyleBackColor = true;
            this.zoomInBtn.Click += new System.EventHandler(this.zoomInBtn_Click);
            // 
            // prevBtn
            // 
            this.prevBtn.Location = new System.Drawing.Point(86, 2);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(36, 23);
            this.prevBtn.TabIndex = 9;
            this.prevBtn.Text = "<<";
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(122, 2);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(36, 23);
            this.nextBtn.TabIndex = 8;
            this.nextBtn.Text = ">>";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(4, 2);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(75, 23);
            this.reloadBtn.TabIndex = 7;
            this.reloadBtn.Text = "Reload";
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.reload_Click);
            // 
            // myPriceGraphObj
            // 
            this.myPriceGraphObj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPriceGraphObj.IsEnableHPan = false;
            this.myPriceGraphObj.IsEnableHZoom = false;
            this.myPriceGraphObj.IsEnableVPan = false;
            this.myPriceGraphObj.IsEnableVZoom = false;
            this.myPriceGraphObj.isPanning = false;
            this.myPriceGraphObj.Location = new System.Drawing.Point(0, 31);
            this.myPriceGraphObj.myViewportX = intRange1;
            this.myPriceGraphObj.Name = "myPriceGraphObj";
            this.myPriceGraphObj.PanButtons = System.Windows.Forms.MouseButtons.None;
            this.myPriceGraphObj.PanButtons2 = System.Windows.Forms.MouseButtons.None;
            this.myPriceGraphObj.ScrollGrace = 0;
            this.myPriceGraphObj.ScrollMaxX = 0;
            this.myPriceGraphObj.ScrollMaxY = 0;
            this.myPriceGraphObj.ScrollMaxY2 = 0;
            this.myPriceGraphObj.ScrollMinX = 0;
            this.myPriceGraphObj.ScrollMinY = 0;
            this.myPriceGraphObj.ScrollMinY2 = 0;
            this.myPriceGraphObj.Size = new System.Drawing.Size(1244, 457);
            this.myPriceGraphObj.TabIndex = 6;
            this.myPriceGraphObj.ZoomButtons = System.Windows.Forms.MouseButtons.None;
            this.myPriceGraphObj.ZoomStepFraction = 0;
            this.myPriceGraphObj.myOnViewportChanged += new Charts.Controls.myGraphControl.OnViewportChanged(this.myPriceGraphObj_myOnViewportChanged);
            // 
            // myVolumeGraphObj
            // 
            this.myVolumeGraphObj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myVolumeGraphObj.IsEnableHPan = false;
            this.myVolumeGraphObj.IsEnableHZoom = false;
            this.myVolumeGraphObj.IsEnableVPan = false;
            this.myVolumeGraphObj.IsEnableVZoom = false;
            this.myVolumeGraphObj.isPanning = false;
            this.myVolumeGraphObj.Location = new System.Drawing.Point(0, 484);
            this.myVolumeGraphObj.myViewportX = intRange2;
            this.myVolumeGraphObj.Name = "myVolumeGraphObj";
            this.myVolumeGraphObj.PanButtons = System.Windows.Forms.MouseButtons.None;
            this.myVolumeGraphObj.PanButtons2 = System.Windows.Forms.MouseButtons.None;
            this.myVolumeGraphObj.ScrollGrace = 0;
            this.myVolumeGraphObj.ScrollMaxX = 0;
            this.myVolumeGraphObj.ScrollMaxY = 0;
            this.myVolumeGraphObj.ScrollMaxY2 = 0;
            this.myVolumeGraphObj.ScrollMinX = 0;
            this.myVolumeGraphObj.ScrollMinY = 0;
            this.myVolumeGraphObj.ScrollMinY2 = 0;
            this.myVolumeGraphObj.Size = new System.Drawing.Size(1225, 231);
            this.myVolumeGraphObj.TabIndex = 12;
            this.myVolumeGraphObj.ZoomButtons = System.Windows.Forms.MouseButtons.None;
            this.myVolumeGraphObj.ZoomStepFraction = 0;
            this.myVolumeGraphObj.myOnViewportChanged += new Charts.Controls.myGraphControl.OnViewportChanged(this.myVolumeGraphObj_myOnViewportChanged);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(1225, 748);
            this.Controls.Add(this.myVolumeGraphObj);
            this.Controls.Add(this.zoomOutBtn);
            this.Controls.Add(this.zoomInBtn);
            this.Controls.Add(this.prevBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.reloadBtn);
            this.Controls.Add(this.myPriceGraphObj);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button zoomOutBtn;
        private System.Windows.Forms.Button zoomInBtn;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button reloadBtn;
        private Charts.Controls.myGraphControl myPriceGraphObj;
        private Charts.Controls.myGraphControl myVolumeGraphObj;
    }
}
