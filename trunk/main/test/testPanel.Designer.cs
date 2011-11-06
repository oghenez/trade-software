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
            this.trBtn = new System.Windows.Forms.Button();
            this.blBtn = new System.Windows.Forms.Button();
            this.brBtn = new System.Windows.Forms.Button();
            this.tlBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.basePanel1 = new common.controls.basePanel();
            this.container = new common.controls.baseContainer();
            this.pane1 = new common.controls.basePanel();
            this.baseLabel1 = new common.controls.baseLabel();
            this.pane4 = new common.controls.basePanel();
            this.baseLabel4 = new common.controls.baseLabel();
            this.pane2 = new common.controls.basePanel();
            this.baseLabel2 = new common.controls.baseLabel();
            this.pane5 = new common.controls.basePanel();
            this.baseLabel5 = new common.controls.baseLabel();
            this.pane6 = new common.controls.basePanel();
            this.baseLabel6 = new common.controls.baseLabel();
            this.pane3 = new common.controls.basePanel();
            this.baseLabel3 = new common.controls.baseLabel();
            this.locationLbl = new common.controls.baseLabel();
            this.baseComboBox1 = new common.controls.baseComboBox();
            this.largerBtn = new System.Windows.Forms.Button();
            this.smallerBtn = new System.Windows.Forms.Button();
            this.baseTextBox1 = new common.controls.baseTextBox();
            this.baseTextBox2 = new common.controls.baseTextBox();
            this.baseTextBox3 = new common.controls.baseTextBox();
            this.baseTextBox4 = new common.controls.baseTextBox();
            this.baseTextBox5 = new common.controls.baseTextBox();
            this.baseTextBox6 = new common.controls.baseTextBox();
            this.container.SuspendLayout();
            this.pane1.SuspendLayout();
            this.pane4.SuspendLayout();
            this.pane2.SuspendLayout();
            this.pane5.SuspendLayout();
            this.pane6.SuspendLayout();
            this.pane3.SuspendLayout();
            this.SuspendLayout();
            // 
            // trBtn
            // 
            this.trBtn.BackColor = System.Drawing.Color.Maroon;
            this.trBtn.Location = new System.Drawing.Point(246, 37);
            this.trBtn.Margin = new System.Windows.Forms.Padding(4);
            this.trBtn.Name = "trBtn";
            this.trBtn.Size = new System.Drawing.Size(8, 9);
            this.trBtn.TabIndex = 6;
            this.trBtn.UseVisualStyleBackColor = false;
            // 
            // blBtn
            // 
            this.blBtn.BackColor = System.Drawing.Color.Maroon;
            this.blBtn.Location = new System.Drawing.Point(0, 210);
            this.blBtn.Margin = new System.Windows.Forms.Padding(4);
            this.blBtn.Name = "blBtn";
            this.blBtn.Size = new System.Drawing.Size(8, 9);
            this.blBtn.TabIndex = 7;
            this.blBtn.UseVisualStyleBackColor = false;
            // 
            // brBtn
            // 
            this.brBtn.BackColor = System.Drawing.Color.Maroon;
            this.brBtn.Location = new System.Drawing.Point(238, 210);
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(297, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 13;
            this.button1.Text = "Arrange";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // basePanel1
            // 
            this.basePanel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.basePanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.basePanel1.haveCloseButton = false;
            this.basePanel1.isExpanded = true;
            this.basePanel1.Location = new System.Drawing.Point(8, 45);
            this.basePanel1.Margin = new System.Windows.Forms.Padding(4);
            this.basePanel1.myIconLocations = common.controls.basePanel.IconLocations.TopLeft;
            this.basePanel1.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.basePanel1.myWeight = 0;
            this.basePanel1.Name = "basePanel1";
            this.basePanel1.Size = new System.Drawing.Size(238, 167);
            this.basePanel1.TabIndex = 5;
            // 
            // container
            // 
            this.container.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.container.Controls.Add(this.pane1);
            this.container.Controls.Add(this.pane4);
            this.container.Controls.Add(this.pane2);
            this.container.Controls.Add(this.pane5);
            this.container.Controls.Add(this.pane6);
            this.container.Controls.Add(this.pane3);
            this.container.Location = new System.Drawing.Point(294, 56);
            this.container.myArrangeOptions = common.controls.childArrangeOptions.Casscade;
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(252, 190);
            this.container.TabIndex = 12;
            // 
            // pane1
            // 
            this.pane1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.pane1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pane1.Controls.Add(this.baseTextBox5);
            this.pane1.Controls.Add(this.baseLabel1);
            this.pane1.haveCloseButton = false;
            this.pane1.isExpanded = true;
            this.pane1.Location = new System.Drawing.Point(9, 8);
            this.pane1.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.pane1.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.pane1.myWeight = 0;
            this.pane1.Name = "pane1";
            this.pane1.Size = new System.Drawing.Size(75, 61);
            this.pane1.TabIndex = 12;
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel1.Location = new System.Drawing.Point(27, 21);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(16, 16);
            this.baseLabel1.TabIndex = 10;
            this.baseLabel1.Text = "1";
            // 
            // pane4
            // 
            this.pane4.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.pane4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pane4.Controls.Add(this.baseTextBox6);
            this.pane4.Controls.Add(this.baseLabel4);
            this.pane4.haveCloseButton = false;
            this.pane4.isExpanded = true;
            this.pane4.Location = new System.Drawing.Point(12, 81);
            this.pane4.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.pane4.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.pane4.myWeight = 0;
            this.pane4.Name = "pane4";
            this.pane4.Size = new System.Drawing.Size(75, 61);
            this.pane4.TabIndex = 11;
            // 
            // baseLabel4
            // 
            this.baseLabel4.AutoSize = true;
            this.baseLabel4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel4.Location = new System.Drawing.Point(27, 20);
            this.baseLabel4.Name = "baseLabel4";
            this.baseLabel4.Size = new System.Drawing.Size(16, 16);
            this.baseLabel4.TabIndex = 11;
            this.baseLabel4.Text = "4";
            // 
            // pane2
            // 
            this.pane2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.pane2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pane2.Controls.Add(this.baseTextBox4);
            this.pane2.Controls.Add(this.baseLabel2);
            this.pane2.haveCloseButton = false;
            this.pane2.isExpanded = true;
            this.pane2.Location = new System.Drawing.Point(84, 8);
            this.pane2.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.pane2.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.pane2.myWeight = 0;
            this.pane2.Name = "pane2";
            this.pane2.Size = new System.Drawing.Size(75, 61);
            this.pane2.TabIndex = 10;
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel2.Location = new System.Drawing.Point(30, 23);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(16, 16);
            this.baseLabel2.TabIndex = 11;
            this.baseLabel2.Text = "2";
            // 
            // pane5
            // 
            this.pane5.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.pane5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pane5.Controls.Add(this.baseTextBox2);
            this.pane5.Controls.Add(this.baseLabel5);
            this.pane5.haveCloseButton = false;
            this.pane5.isExpanded = true;
            this.pane5.Location = new System.Drawing.Point(87, 81);
            this.pane5.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.pane5.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.pane5.myWeight = 0;
            this.pane5.Name = "pane5";
            this.pane5.Size = new System.Drawing.Size(75, 61);
            this.pane5.TabIndex = 9;
            // 
            // baseLabel5
            // 
            this.baseLabel5.AutoSize = true;
            this.baseLabel5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel5.Location = new System.Drawing.Point(27, 20);
            this.baseLabel5.Name = "baseLabel5";
            this.baseLabel5.Size = new System.Drawing.Size(16, 16);
            this.baseLabel5.TabIndex = 11;
            this.baseLabel5.Text = "5";
            // 
            // pane6
            // 
            this.pane6.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.pane6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pane6.Controls.Add(this.baseTextBox1);
            this.pane6.Controls.Add(this.baseLabel6);
            this.pane6.haveCloseButton = false;
            this.pane6.isExpanded = true;
            this.pane6.Location = new System.Drawing.Point(162, 81);
            this.pane6.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.pane6.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.pane6.myWeight = 0;
            this.pane6.Name = "pane6";
            this.pane6.Size = new System.Drawing.Size(75, 61);
            this.pane6.TabIndex = 5;
            // 
            // baseLabel6
            // 
            this.baseLabel6.AutoSize = true;
            this.baseLabel6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel6.Location = new System.Drawing.Point(27, 20);
            this.baseLabel6.Name = "baseLabel6";
            this.baseLabel6.Size = new System.Drawing.Size(16, 16);
            this.baseLabel6.TabIndex = 11;
            this.baseLabel6.Text = "6";
            // 
            // pane3
            // 
            this.pane3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.pane3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pane3.Controls.Add(this.baseTextBox3);
            this.pane3.Controls.Add(this.baseLabel3);
            this.pane3.haveCloseButton = false;
            this.pane3.isExpanded = true;
            this.pane3.Location = new System.Drawing.Point(159, 8);
            this.pane3.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.pane3.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.pane3.myWeight = 0;
            this.pane3.Name = "pane3";
            this.pane3.Size = new System.Drawing.Size(75, 61);
            this.pane3.TabIndex = 6;
            this.pane3.Resize += new System.EventHandler(this.pane3_Resize);
            // 
            // baseLabel3
            // 
            this.baseLabel3.AutoSize = true;
            this.baseLabel3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel3.Location = new System.Drawing.Point(27, 20);
            this.baseLabel3.Name = "baseLabel3";
            this.baseLabel3.Size = new System.Drawing.Size(16, 16);
            this.baseLabel3.TabIndex = 11;
            this.baseLabel3.Text = "3";
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
            // largerBtn
            // 
            this.largerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.largerBtn.Location = new System.Drawing.Point(378, 29);
            this.largerBtn.Name = "largerBtn";
            this.largerBtn.Size = new System.Drawing.Size(75, 26);
            this.largerBtn.TabIndex = 14;
            this.largerBtn.Text = "Larger";
            this.largerBtn.UseVisualStyleBackColor = true;
            this.largerBtn.Click += new System.EventHandler(this.largerBtn_Click);
            // 
            // smallerBtn
            // 
            this.smallerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smallerBtn.Location = new System.Drawing.Point(456, 29);
            this.smallerBtn.Name = "smallerBtn";
            this.smallerBtn.Size = new System.Drawing.Size(75, 26);
            this.smallerBtn.TabIndex = 15;
            this.smallerBtn.Text = "Smaller";
            this.smallerBtn.UseVisualStyleBackColor = true;
            this.smallerBtn.Click += new System.EventHandler(this.smallerBtn_Click);
            // 
            // baseTextBox1
            // 
            this.baseTextBox1.isToUpperCase = false;
            this.baseTextBox1.Location = new System.Drawing.Point(13, 1);
            this.baseTextBox1.Name = "baseTextBox1";
            this.baseTextBox1.Size = new System.Drawing.Size(38, 22);
            this.baseTextBox1.TabIndex = 12;
            // 
            // baseTextBox2
            // 
            this.baseTextBox2.isToUpperCase = false;
            this.baseTextBox2.Location = new System.Drawing.Point(16, -2);
            this.baseTextBox2.Name = "baseTextBox2";
            this.baseTextBox2.Size = new System.Drawing.Size(38, 22);
            this.baseTextBox2.TabIndex = 13;
            // 
            // baseTextBox3
            // 
            this.baseTextBox3.isToUpperCase = false;
            this.baseTextBox3.Location = new System.Drawing.Point(14, -2);
            this.baseTextBox3.Name = "baseTextBox3";
            this.baseTextBox3.Size = new System.Drawing.Size(38, 22);
            this.baseTextBox3.TabIndex = 13;
            // 
            // baseTextBox4
            // 
            this.baseTextBox4.isToUpperCase = false;
            this.baseTextBox4.Location = new System.Drawing.Point(19, -2);
            this.baseTextBox4.Name = "baseTextBox4";
            this.baseTextBox4.Size = new System.Drawing.Size(38, 22);
            this.baseTextBox4.TabIndex = 13;
            // 
            // baseTextBox5
            // 
            this.baseTextBox5.isToUpperCase = false;
            this.baseTextBox5.Location = new System.Drawing.Point(18, -2);
            this.baseTextBox5.Name = "baseTextBox5";
            this.baseTextBox5.Size = new System.Drawing.Size(38, 22);
            this.baseTextBox5.TabIndex = 13;
            // 
            // baseTextBox6
            // 
            this.baseTextBox6.isToUpperCase = false;
            this.baseTextBox6.Location = new System.Drawing.Point(15, -2);
            this.baseTextBox6.Name = "baseTextBox6";
            this.baseTextBox6.Size = new System.Drawing.Size(38, 22);
            this.baseTextBox6.TabIndex = 13;
            // 
            // testPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1027, 462);
            this.Controls.Add(this.smallerBtn);
            this.Controls.Add(this.largerBtn);
            this.Controls.Add(this.basePanel1);
            this.Controls.Add(this.container);
            this.Controls.Add(this.locationLbl);
            this.Controls.Add(this.baseComboBox1);
            this.Controls.Add(this.tlBtn);
            this.Controls.Add(this.brBtn);
            this.Controls.Add(this.blBtn);
            this.Controls.Add(this.trBtn);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "testPanel";
            this.Text = "Form1";
            this.container.ResumeLayout(false);
            this.pane1.ResumeLayout(false);
            this.pane1.PerformLayout();
            this.pane4.ResumeLayout(false);
            this.pane4.PerformLayout();
            this.pane2.ResumeLayout(false);
            this.pane2.PerformLayout();
            this.pane5.ResumeLayout(false);
            this.pane5.PerformLayout();
            this.pane6.ResumeLayout(false);
            this.pane6.PerformLayout();
            this.pane3.ResumeLayout(false);
            this.pane3.PerformLayout();
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
        private common.controls.baseContainer container;
        private common.controls.basePanel pane1;
        private common.controls.basePanel pane4;
        private common.controls.basePanel pane2;
        private common.controls.basePanel pane5;
        private common.controls.basePanel pane6;
        private common.controls.basePanel pane3;
        private common.controls.baseLabel baseLabel1;
        private common.controls.baseLabel baseLabel4;
        private common.controls.baseLabel baseLabel2;
        private common.controls.baseLabel baseLabel5;
        private common.controls.baseLabel baseLabel6;
        private common.controls.baseLabel baseLabel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button largerBtn;
        private System.Windows.Forms.Button smallerBtn;
        private common.controls.baseTextBox baseTextBox1;
        private common.controls.baseTextBox baseTextBox5;
        private common.controls.baseTextBox baseTextBox6;
        private common.controls.baseTextBox baseTextBox4;
        private common.controls.baseTextBox baseTextBox2;
        private common.controls.baseTextBox baseTextBox3;


    }
}