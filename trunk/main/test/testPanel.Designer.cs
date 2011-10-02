namespace test
{
    partial class testPanel
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
            this.basePanel1 = new common.controls.basePanel();
            this.trBtn = new System.Windows.Forms.Button();
            this.blBtn = new System.Windows.Forms.Button();
            this.brBtn = new System.Windows.Forms.Button();
            this.tlBtn = new System.Windows.Forms.Button();
            this.baseComboBox1 = new common.controls.baseComboBox();
            this.locationLbl = new common.controls.baseLabel();
            this.SuspendLayout();
            // 
            // basePanel1
            // 
            this.basePanel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.basePanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.basePanel1.haveCloseButton = false;
            this.basePanel1.isExpanded = true;
            this.basePanel1.isVisible = true;
            this.basePanel1.Location = new System.Drawing.Point(8, 45);
            this.basePanel1.Margin = new System.Windows.Forms.Padding(4);
            this.basePanel1.myIconLocations = common.controls.basePanel.IconLocations.TopLeft;
            this.basePanel1.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.basePanel1.myWeight = 0;
            this.basePanel1.Name = "basePanel1";
            this.basePanel1.Size = new System.Drawing.Size(487, 245);
            this.basePanel1.TabIndex = 5;
            // 
            // trBtn
            // 
            this.trBtn.BackColor = System.Drawing.Color.Maroon;
            this.trBtn.Location = new System.Drawing.Point(494, 36);
            this.trBtn.Margin = new System.Windows.Forms.Padding(4);
            this.trBtn.Name = "trBtn";
            this.trBtn.Size = new System.Drawing.Size(8, 9);
            this.trBtn.TabIndex = 6;
            this.trBtn.UseVisualStyleBackColor = false;
            // 
            // blBtn
            // 
            this.blBtn.BackColor = System.Drawing.Color.Maroon;
            this.blBtn.Location = new System.Drawing.Point(0, 288);
            this.blBtn.Margin = new System.Windows.Forms.Padding(4);
            this.blBtn.Name = "blBtn";
            this.blBtn.Size = new System.Drawing.Size(8, 9);
            this.blBtn.TabIndex = 7;
            this.blBtn.UseVisualStyleBackColor = false;
            // 
            // brBtn
            // 
            this.brBtn.BackColor = System.Drawing.Color.Maroon;
            this.brBtn.Location = new System.Drawing.Point(493, 288);
            this.brBtn.Margin = new System.Windows.Forms.Padding(4);
            this.brBtn.Name = "brBtn";
            this.brBtn.Size = new System.Drawing.Size(8, 9);
            this.brBtn.TabIndex = 8;
            this.brBtn.UseVisualStyleBackColor = false;
            // 
            // tlBtn
            // 
            this.tlBtn.BackColor = System.Drawing.Color.Maroon;
            this.tlBtn.Location = new System.Drawing.Point(0, 36);
            this.tlBtn.Margin = new System.Windows.Forms.Padding(4);
            this.tlBtn.Name = "tlBtn";
            this.tlBtn.Size = new System.Drawing.Size(8, 9);
            this.tlBtn.TabIndex = 9;
            this.tlBtn.UseVisualStyleBackColor = false;
            // 
            // baseComboBox1
            // 
            this.baseComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baseComboBox1.FormattingEnabled = true;
            this.baseComboBox1.Items.AddRange(new object[] {
            "TopLeft",
            "TopRight",
            "BottomLeft",
            "BottomRight",
            "None  "});
            this.baseComboBox1.Location = new System.Drawing.Point(16, 3);
            this.baseComboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.baseComboBox1.myValue = "";
            this.baseComboBox1.Name = "baseComboBox1";
            this.baseComboBox1.Size = new System.Drawing.Size(141, 24);
            this.baseComboBox1.TabIndex = 10;
            this.baseComboBox1.SelectionChangeCommitted += new System.EventHandler(this.baseComboBox1_SelectionChangeCommitted);
            // 
            // locationLbl
            // 
            this.locationLbl.AutoSize = true;
            this.locationLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationLbl.Location = new System.Drawing.Point(165, 6);
            this.locationLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.locationLbl.Name = "locationLbl";
            this.locationLbl.Size = new System.Drawing.Size(81, 16);
            this.locationLbl.TabIndex = 11;
            this.locationLbl.Text = "baseLabel1";
            // 
            // testPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(503, 322);
            this.Controls.Add(this.locationLbl);
            this.Controls.Add(this.baseComboBox1);
            this.Controls.Add(this.tlBtn);
            this.Controls.Add(this.brBtn);
            this.Controls.Add(this.blBtn);
            this.Controls.Add(this.trBtn);
            this.Controls.Add(this.basePanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "testPanel";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private common.controls.basePanel basePanel1;
        private System.Windows.Forms.Button trBtn;
        private System.Windows.Forms.Button blBtn;
        private System.Windows.Forms.Button brBtn;
        private System.Windows.Forms.Button tlBtn;
        private common.controls.baseComboBox baseComboBox1;
        private common.controls.baseLabel locationLbl;


    }
}