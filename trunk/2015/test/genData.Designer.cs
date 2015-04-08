namespace test
{
    partial class genData
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.baseLabel1 = new common.controls.baseLabel();
            this.intervalEd = new common.controls.baseNumericUpDown();
            this.codeLbl = new common.controls.baseLabel();
            this.codeEd = new common.controls.baseTextBox();
            this.tmpDataSet1 = new Tools.Data.tmpDataSet();
            this.baseLabel2 = new common.controls.baseLabel();
            this.genDataBtn = new common.controls.baseButton();
            ((System.ComponentModel.ISupportInitialize)(this.intervalEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1043, 34);
            this.TitleLbl.Size = new System.Drawing.Size(32, 23);
            this.TitleLbl.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // baseLabel1
            // 
            this.baseLabel1.AutoSize = true;
            this.baseLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel1.Location = new System.Drawing.Point(42, 32);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(101, 16);
            this.baseLabel1.TabIndex = 256;
            this.baseLabel1.Text = "Gen data each";
            // 
            // intervalEd
            // 
            this.intervalEd.Location = new System.Drawing.Point(150, 32);
            this.intervalEd.myValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.intervalEd.Name = "intervalEd";
            this.intervalEd.Size = new System.Drawing.Size(59, 23);
            this.intervalEd.TabIndex = 2;
            this.intervalEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.intervalEd.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(103, 10);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(40, 16);
            this.codeLbl.TabIndex = 258;
            this.codeLbl.Text = "Code";
            // 
            // codeEd
            // 
            this.codeEd.isRequired = true;
            this.codeEd.isToUpperCase = true;
            this.codeEd.Location = new System.Drawing.Point(150, 9);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(59, 23);
            this.codeEd.TabIndex = 1;
            this.codeEd.Text = "XAUUSD";
            // 
            // tmpDataSet1
            // 
            this.tmpDataSet1.DataSetName = "tmpDataSet";
            this.tmpDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // baseLabel2
            // 
            this.baseLabel2.AutoSize = true;
            this.baseLabel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel2.Location = new System.Drawing.Point(215, 35);
            this.baseLabel2.Name = "baseLabel2";
            this.baseLabel2.Size = new System.Drawing.Size(61, 16);
            this.baseLabel2.TabIndex = 261;
            this.baseLabel2.Text = "seconds";
            // 
            // genDataBtn
            // 
            this.genDataBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genDataBtn.isDownState = false;
            this.genDataBtn.Location = new System.Drawing.Point(150, 59);
            this.genDataBtn.Name = "genDataBtn";
            this.genDataBtn.Size = new System.Drawing.Size(88, 25);
            this.genDataBtn.TabIndex = 20;
            this.genDataBtn.Text = "Generate";
            this.genDataBtn.UseVisualStyleBackColor = true;
            this.genDataBtn.Click += new System.EventHandler(this.genDataBtn_Click);
            // 
            // genData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(331, 115);
            this.Controls.Add(this.genDataBtn);
            this.Controls.Add(this.baseLabel2);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.intervalEd);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.codeEd);
            this.Name = "genData";
            this.Text = "Generate data";
            this.Controls.SetChildIndex(this.codeEd, 0);
            this.Controls.SetChildIndex(this.codeLbl, 0);
            this.Controls.SetChildIndex(this.intervalEd, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.baseLabel2, 0);
            this.Controls.SetChildIndex(this.genDataBtn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.intervalEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private common.controls.baseLabel baseLabel1;
        private common.controls.baseNumericUpDown intervalEd;
        private common.controls.baseLabel codeLbl;
        private common.controls.baseTextBox codeEd;
        private Tools.Data.tmpDataSet tmpDataSet1;
        private common.controls.baseLabel baseLabel2;
        private common.controls.baseButton genDataBtn;
    }
}