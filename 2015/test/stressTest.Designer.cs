namespace test
{
    partial class stressTest
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
            this.startBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.webServiceChk = new System.Windows.Forms.CheckBox();
            this.stopBtn = new System.Windows.Forms.Button();
            this.wsTestCountLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(460, 11);
            this.TitleLbl.Size = new System.Drawing.Size(159, 46);
            this.TitleLbl.Visible = false;
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.startBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.startBtn.Location = new System.Drawing.Point(53, 66);
            this.startBtn.Margin = new System.Windows.Forms.Padding(4);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(91, 32);
            this.startBtn.TabIndex = 259;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // webServiceChk
            // 
            this.webServiceChk.AutoSize = true;
            this.webServiceChk.Checked = true;
            this.webServiceChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.webServiceChk.Location = new System.Drawing.Point(53, 28);
            this.webServiceChk.Margin = new System.Windows.Forms.Padding(4);
            this.webServiceChk.Name = "webServiceChk";
            this.webServiceChk.Size = new System.Drawing.Size(103, 20);
            this.webServiceChk.TabIndex = 260;
            this.webServiceChk.Text = "Web service";
            this.webServiceChk.UseVisualStyleBackColor = true;
            // 
            // stopBtn
            // 
            this.stopBtn.Enabled = false;
            this.stopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.stopBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stopBtn.Location = new System.Drawing.Point(147, 66);
            this.stopBtn.Margin = new System.Windows.Forms.Padding(4);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(91, 32);
            this.stopBtn.TabIndex = 261;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // wsTestCountLbl
            // 
            this.wsTestCountLbl.AutoSize = true;
            this.wsTestCountLbl.Location = new System.Drawing.Point(163, 32);
            this.wsTestCountLbl.Name = "wsTestCountLbl";
            this.wsTestCountLbl.Size = new System.Drawing.Size(0, 16);
            this.wsTestCountLbl.TabIndex = 262;
            // 
            // stressTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 132);
            this.Controls.Add(this.wsTestCountLbl);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.webServiceChk);
            this.Controls.Add(this.startBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "stressTest";
            this.Text = "stressTest";
            this.Controls.SetChildIndex(this.startBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.webServiceChk, 0);
            this.Controls.SetChildIndex(this.stopBtn, 0);
            this.Controls.SetChildIndex(this.wsTestCountLbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox webServiceChk;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Label wsTestCountLbl;
    }
}