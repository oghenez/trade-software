namespace common.controls
{
    partial class dateMonthRange
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthCb = new System.Windows.Forms.ComboBox();
            this.yearEd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timeTypeCb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCb
            // 
            this.monthCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthCb.FormattingEnabled = true;
            this.monthCb.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.monthCb.Location = new System.Drawing.Point(121, 22);
            this.monthCb.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.monthCb.MaxDropDownItems = 12;
            this.monthCb.Name = "monthCb";
            this.monthCb.Size = new System.Drawing.Size(53, 24);
            this.monthCb.TabIndex = 2;
            // 
            // yearEd
            // 
            this.yearEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearEd.Location = new System.Drawing.Point(174, 22);
            this.yearEd.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.yearEd.Name = "yearEd";
            this.yearEd.Size = new System.Drawing.Size(52, 24);
            this.yearEd.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(176, 1);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 18);
            this.label7.TabIndex = 59;
            this.label7.Text = "Năm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(118, 1);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 18);
            this.label6.TabIndex = 58;
            this.label6.Text = "Tháng";
            // 
            // timeTypeCb
            // 
            this.timeTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeTypeCb.FormattingEnabled = true;
            this.timeTypeCb.Items.AddRange(new object[] {
            "Tháng",
            "Quý 1",
            "Quý 2",
            "Quý 3",
            "Quý 4",
            "Sáu tháng",
            "Chín tháng",
            "Năm"});
            this.timeTypeCb.Location = new System.Drawing.Point(0, 22);
            this.timeTypeCb.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.timeTypeCb.MaxDropDownItems = 20;
            this.timeTypeCb.Name = "timeTypeCb";
            this.timeTypeCb.Size = new System.Drawing.Size(123, 24);
            this.timeTypeCb.TabIndex = 1;
            this.timeTypeCb.SelectedIndexChanged += new System.EventHandler(this.timeTypeCb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1, 1);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 57;
            this.label5.Text = "Thời gian";
            // 
            // dateMonthRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.monthCb);
            this.Controls.Add(this.yearEd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timeTypeCb);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "dateMonthRange";
            this.Size = new System.Drawing.Size(228, 47);
            this.Load += new System.EventHandler(this.dateRange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ComboBox monthCb;
        protected System.Windows.Forms.TextBox yearEd;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.ComboBox timeTypeCb;
        protected System.Windows.Forms.Label label5;

    }
}
