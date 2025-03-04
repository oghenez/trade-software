namespace common.controls
{
    partial class dateTimeRange
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
            this.toDateEd = new System.Windows.Forms.MaskedTextBox();
            this.frDateEd = new System.Windows.Forms.MaskedTextBox();
            this.monthCb = new System.Windows.Forms.ComboBox();
            this.yearEd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timeTypeCb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.frTimeEd = new System.Windows.Forms.MaskedTextBox();
            this.toTimeEd = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // toDateEd
            // 
            this.toDateEd.Enabled = false;
            this.toDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.toDateEd.Location = new System.Drawing.Point(339, 21);
            this.toDateEd.Margin = new System.Windows.Forms.Padding(6);
            this.toDateEd.Mask = "00/00/0000";
            this.toDateEd.Name = "toDateEd";
            this.toDateEd.Size = new System.Drawing.Size(80, 24);
            this.toDateEd.TabIndex = 5;
            this.toDateEd.ValidatingType = typeof(System.DateTime);
            // 
            // frDateEd
            // 
            this.frDateEd.Enabled = false;
            this.frDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.frDateEd.Location = new System.Drawing.Point(212, 21);
            this.frDateEd.Margin = new System.Windows.Forms.Padding(6);
            this.frDateEd.Mask = "00/00/0000";
            this.frDateEd.Name = "frDateEd";
            this.frDateEd.Size = new System.Drawing.Size(85, 24);
            this.frDateEd.TabIndex = 4;
            this.frDateEd.ValidatingType = typeof(System.DateTime);
            // 
            // monthCb
            // 
            this.monthCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.monthCb.Location = new System.Drawing.Point(109, 21);
            this.monthCb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.monthCb.MaxDropDownItems = 20;
            this.monthCb.Name = "monthCb";
            this.monthCb.Size = new System.Drawing.Size(52, 24);
            this.monthCb.TabIndex = 2;
            // 
            // yearEd
            // 
            this.yearEd.Location = new System.Drawing.Point(161, 21);
            this.yearEd.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.yearEd.Name = "yearEd";
            this.yearEd.Size = new System.Drawing.Size(52, 24);
            this.yearEd.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(163, 1);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 16);
            this.label7.TabIndex = 59;
            this.label7.Text = "Năm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(105, 1);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 58;
            this.label6.Text = "Tháng";
            // 
            // timeTypeCb
            // 
            this.timeTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeTypeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTypeCb.FormattingEnabled = true;
            this.timeTypeCb.Items.AddRange(new object[] {
            "Tháng",
            "Quý 1",
            "Quý 2",
            "Quý 3",
            "Quý 4",
            "Sáu tháng",
            "Chín tháng",
            "Năm",
            "Tùy chọn"});
            this.timeTypeCb.Location = new System.Drawing.Point(0, 21);
            this.timeTypeCb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.timeTypeCb.MaxDropDownItems = 20;
            this.timeTypeCb.Name = "timeTypeCb";
            this.timeTypeCb.Size = new System.Drawing.Size(109, 24);
            this.timeTypeCb.TabIndex = 1;
            this.timeTypeCb.SelectedIndexChanged += new System.EventHandler(this.timeTypeCb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 1);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Thời gian";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(338, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "Đến ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(212, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 54;
            this.label2.Text = "Từ ngày";
            // 
            // frTimeEd
            // 
            this.frTimeEd.Enabled = false;
            this.frTimeEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.frTimeEd.Location = new System.Drawing.Point(296, 21);
            this.frTimeEd.Margin = new System.Windows.Forms.Padding(6);
            this.frTimeEd.Mask = "90:00";
            this.frTimeEd.Name = "frTimeEd";
            this.frTimeEd.Size = new System.Drawing.Size(44, 24);
            this.frTimeEd.TabIndex = 5;
            this.frTimeEd.ValidatingType = typeof(System.DateTime);
            // 
            // toTimeEd
            // 
            this.toTimeEd.Enabled = false;
            this.toTimeEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.toTimeEd.Location = new System.Drawing.Point(418, 21);
            this.toTimeEd.Margin = new System.Windows.Forms.Padding(6);
            this.toTimeEd.Mask = "90:00";
            this.toTimeEd.Name = "toTimeEd";
            this.toTimeEd.Size = new System.Drawing.Size(44, 24);
            this.toTimeEd.TabIndex = 7;
            this.toTimeEd.ValidatingType = typeof(System.DateTime);
            // 
            // dateTimeRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toTimeEd);
            this.Controls.Add(this.frTimeEd);
            this.Controls.Add(this.toDateEd);
            this.Controls.Add(this.frDateEd);
            this.Controls.Add(this.monthCb);
            this.Controls.Add(this.yearEd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timeTypeCb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "dateTimeRange";
            this.Size = new System.Drawing.Size(463, 45);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.MaskedTextBox toDateEd;
        protected System.Windows.Forms.MaskedTextBox frDateEd;
        protected System.Windows.Forms.ComboBox monthCb;
        protected System.Windows.Forms.TextBox yearEd;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.ComboBox timeTypeCb;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.MaskedTextBox frTimeEd;
        protected System.Windows.Forms.MaskedTextBox toTimeEd;

    }
}
