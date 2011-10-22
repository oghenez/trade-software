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
            this.graphObj = new ZedGraph.ZedGraphControl();
            this.reloadBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.zoomInBtn = new System.Windows.Forms.Button();
            this.zoomOutBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // graphObj
            // 
            this.graphObj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.graphObj.IsEnableVPan = false;
            this.graphObj.IsEnableVZoom = false;
            this.graphObj.Location = new System.Drawing.Point(-1, 31);
            this.graphObj.Name = "graphObj";
            this.graphObj.ScrollGrace = 0;
            this.graphObj.ScrollMaxX = 0;
            this.graphObj.ScrollMaxY = 0;
            this.graphObj.ScrollMaxY2 = 0;
            this.graphObj.ScrollMinX = 0;
            this.graphObj.ScrollMinY = 0;
            this.graphObj.ScrollMinY2 = 0;
            this.graphObj.Size = new System.Drawing.Size(754, 669);
            this.graphObj.TabIndex = 0;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(1, 2);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(75, 23);
            this.reloadBtn.TabIndex = 1;
            this.reloadBtn.Text = "Reload";
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.reload_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(119, 2);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(36, 23);
            this.nextBtn.TabIndex = 2;
            this.nextBtn.Text = ">>";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // prevBtn
            // 
            this.prevBtn.Location = new System.Drawing.Point(83, 2);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(36, 23);
            this.prevBtn.TabIndex = 3;
            this.prevBtn.Text = "<<";
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // zoomInBtn
            // 
            this.zoomInBtn.Image = global::test.Properties.Resources.zoomIn;
            this.zoomInBtn.Location = new System.Drawing.Point(210, 2);
            this.zoomInBtn.Name = "zoomInBtn";
            this.zoomInBtn.Size = new System.Drawing.Size(27, 23);
            this.zoomInBtn.TabIndex = 4;
            this.zoomInBtn.UseVisualStyleBackColor = true;
            this.zoomInBtn.Click += new System.EventHandler(this.zoomInBtn_Click);
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.Image = global::test.Properties.Resources.zoomOut;
            this.zoomOutBtn.Location = new System.Drawing.Point(238, 2);
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.Size = new System.Drawing.Size(27, 23);
            this.zoomOutBtn.TabIndex = 5;
            this.zoomOutBtn.UseVisualStyleBackColor = true;
            this.zoomOutBtn.Click += new System.EventHandler(this.zoomOutBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 728);
            this.Controls.Add(this.zoomOutBtn);
            this.Controls.Add(this.zoomInBtn);
            this.Controls.Add(this.prevBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.reloadBtn);
            this.Controls.Add(this.graphObj);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl graphObj;
        private System.Windows.Forms.Button reloadBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button zoomInBtn;
        private System.Windows.Forms.Button zoomOutBtn;
    }
}