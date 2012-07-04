namespace test
{
    partial class main
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
            this.chartTestBtn = new common.controls.baseButton();
            this.genDataBtn = new common.controls.baseButton();
            this.pannelTestBtn = new common.controls.baseButton();
            this.miscBtn = new common.controls.baseButton();
            this.threadingBtn = new common.controls.baseButton();
            this.stressTestBtn = new common.controls.baseButton();
            this.SuspendLayout();
            // 
            // chartTestBtn
            // 
            this.chartTestBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartTestBtn.isDownState = false;
            this.chartTestBtn.Location = new System.Drawing.Point(39, 22);
            this.chartTestBtn.Name = "chartTestBtn";
            this.chartTestBtn.Size = new System.Drawing.Size(105, 49);
            this.chartTestBtn.TabIndex = 145;
            this.chartTestBtn.Text = "Chart";
            this.chartTestBtn.UseVisualStyleBackColor = true;
            this.chartTestBtn.Click += new System.EventHandler(this.chartTestBtn_Click);
            // 
            // genDataBtn
            // 
            this.genDataBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genDataBtn.isDownState = false;
            this.genDataBtn.Location = new System.Drawing.Point(39, 71);
            this.genDataBtn.Name = "genDataBtn";
            this.genDataBtn.Size = new System.Drawing.Size(105, 47);
            this.genDataBtn.TabIndex = 146;
            this.genDataBtn.Text = "Generate data";
            this.genDataBtn.UseVisualStyleBackColor = true;
            this.genDataBtn.Click += new System.EventHandler(this.genDataBtn_Click);
            // 
            // pannelTestBtn
            // 
            this.pannelTestBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pannelTestBtn.isDownState = false;
            this.pannelTestBtn.Location = new System.Drawing.Point(39, 118);
            this.pannelTestBtn.Name = "pannelTestBtn";
            this.pannelTestBtn.Size = new System.Drawing.Size(105, 47);
            this.pannelTestBtn.TabIndex = 147;
            this.pannelTestBtn.Text = "Panel test";
            this.pannelTestBtn.UseVisualStyleBackColor = true;
            this.pannelTestBtn.Click += new System.EventHandler(this.pannelTestBtn_Click);
            // 
            // miscBtn
            // 
            this.miscBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miscBtn.isDownState = false;
            this.miscBtn.Location = new System.Drawing.Point(39, 212);
            this.miscBtn.Name = "miscBtn";
            this.miscBtn.Size = new System.Drawing.Size(105, 47);
            this.miscBtn.TabIndex = 148;
            this.miscBtn.Text = "Misc";
            this.miscBtn.UseVisualStyleBackColor = true;
            this.miscBtn.Click += new System.EventHandler(this.miscBtn_Click);
            // 
            // threadingBtn
            // 
            this.threadingBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.threadingBtn.isDownState = false;
            this.threadingBtn.Location = new System.Drawing.Point(39, 165);
            this.threadingBtn.Name = "threadingBtn";
            this.threadingBtn.Size = new System.Drawing.Size(105, 47);
            this.threadingBtn.TabIndex = 149;
            this.threadingBtn.Text = "Multi-thread";
            this.threadingBtn.UseVisualStyleBackColor = true;
            this.threadingBtn.Click += new System.EventHandler(this.threadingBtn_Click);
            // 
            // stressTestBtn
            // 
            this.stressTestBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stressTestBtn.isDownState = false;
            this.stressTestBtn.Location = new System.Drawing.Point(161, 22);
            this.stressTestBtn.Name = "stressTestBtn";
            this.stressTestBtn.Size = new System.Drawing.Size(105, 47);
            this.stressTestBtn.TabIndex = 150;
            this.stressTestBtn.Text = "Stress test";
            this.stressTestBtn.UseVisualStyleBackColor = true;
            this.stressTestBtn.Click += new System.EventHandler(this.stressTestBtn_Click);
            // 
            // main
            // 
            this.ClientSize = new System.Drawing.Size(369, 331);
            this.Controls.Add(this.stressTestBtn);
            this.Controls.Add(this.threadingBtn);
            this.Controls.Add(this.miscBtn);
            this.Controls.Add(this.pannelTestBtn);
            this.Controls.Add(this.genDataBtn);
            this.Controls.Add(this.chartTestBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "main";
            this.Text = "Test bed";
            this.Controls.SetChildIndex(this.chartTestBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.genDataBtn, 0);
            this.Controls.SetChildIndex(this.pannelTestBtn, 0);
            this.Controls.SetChildIndex(this.miscBtn, 0);
            this.Controls.SetChildIndex(this.threadingBtn, 0);
            this.Controls.SetChildIndex(this.stressTestBtn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private common.controls.baseButton chartTestBtn;
        private common.controls.baseButton genDataBtn;
        private common.controls.baseButton pannelTestBtn;
        private common.controls.baseButton miscBtn;
        private common.controls.baseButton threadingBtn;
        private common.controls.baseButton stressTestBtn;
    }
}
