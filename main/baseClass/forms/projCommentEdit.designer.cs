namespace baseClass.forms
{
    partial class projCommentEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(projCommentEdit));
            this.projCommentSource = new System.Windows.Forms.BindingSource(this.components);
            this.commentEd = new System.Windows.Forms.RichTextBox();
            this.rateLbl = new System.Windows.Forms.Label();
            this.rateCb = new baseClass.Controls.cbProjRateType();
            this.commentLbl = new System.Windows.Forms.Label();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.codeLbl = new System.Windows.Forms.Label();
            this.userNameEd = new common.control.baseTextBox();
            this.projTitleEd = new common.control.baseTextBox();
            this.projTitleLbl = new System.Windows.Forms.Label();
            this.onDateEd = new common.control.baseTextBox();
            this.onDateLbl = new System.Windows.Forms.Label();
            this.noteEd = new System.Windows.Forms.RichTextBox();
            this.noteLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projCommentSource)).BeginInit();
            this.SuspendLayout();
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myBaseDS";
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(1, 399);
            this.toolBox.Size = new System.Drawing.Size(529, 69);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(448, 13);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(28, 13);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(581, 18);
            this.deleteBtn.Visible = false;
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(142, 13);
            this.editBtn.Text = "&Xem";
            this.editBtn.Visible = false;
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(85, 13);
            this.addNewBtn.Visible = false;
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(583, 14);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(592, 14);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(199, 13);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Size = new System.Drawing.Size(525, 24);
            this.TitleLbl.TabIndex = 149;
            this.TitleLbl.Text = "Ý KIẾN PHẢN HỒI";
            // 
            // projCommentSource
            // 
            this.projCommentSource.DataMember = "projComment";
            this.projCommentSource.DataSource = this.myDataSet;
            // 
            // commentEd
            // 
            this.commentEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projCommentSource, "comment", true));
            this.commentEd.Location = new System.Drawing.Point(30, 194);
            this.commentEd.Name = "commentEd";
            this.commentEd.Size = new System.Drawing.Size(480, 91);
            this.commentEd.TabIndex = 11;
            this.commentEd.Text = "";
            // 
            // rateLbl
            // 
            this.rateLbl.AutoSize = true;
            this.rateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rateLbl.Location = new System.Drawing.Point(28, 126);
            this.rateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rateLbl.Name = "rateLbl";
            this.rateLbl.Size = new System.Drawing.Size(61, 16);
            this.rateLbl.TabIndex = 290;
            this.rateLbl.Text = "Đánh giá";
            // 
            // rateCb
            // 
            this.rateCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.projCommentSource, "rated", true));
            this.rateCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rateCb.FormattingEnabled = true;
            this.rateCb.Location = new System.Drawing.Point(30, 146);
            this.rateCb.myValue = "";
            this.rateCb.Name = "rateCb";
            this.rateCb.Size = new System.Drawing.Size(220, 24);
            this.rateCb.TabIndex = 10;
            // 
            // commentLbl
            // 
            this.commentLbl.AutoSize = true;
            this.commentLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commentLbl.Location = new System.Drawing.Point(28, 175);
            this.commentLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.commentLbl.Name = "commentLbl";
            this.commentLbl.Size = new System.Drawing.Size(45, 16);
            this.commentLbl.TabIndex = 286;
            this.commentLbl.Text = "Ý kiến";
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.Location = new System.Drawing.Point(28, 215);
            this.descriptionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(41, 16);
            this.descriptionLbl.TabIndex = 287;
            this.descriptionLbl.Text = "Mô tả";
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(28, 28);
            this.codeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(94, 16);
            this.codeLbl.TabIndex = 285;
            this.codeLbl.Text = "Người sử dụng";
            // 
            // userNameEd
            // 
            this.userNameEd.BackColor = System.Drawing.SystemColors.Info;
            this.userNameEd.BeepOnError = true;
            this.userNameEd.Enabled = false;
            this.userNameEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameEd.Location = new System.Drawing.Point(30, 47);
            this.userNameEd.Margin = new System.Windows.Forms.Padding(4);
            this.userNameEd.Name = "userNameEd";
            this.userNameEd.Size = new System.Drawing.Size(386, 24);
            this.userNameEd.TabIndex = 274;
            this.userNameEd.Text = "Lê Thành Tâm";
            // 
            // projTitleEd
            // 
            this.projTitleEd.BackColor = System.Drawing.SystemColors.Info;
            this.projTitleEd.BeepOnError = true;
            this.projTitleEd.Enabled = false;
            this.projTitleEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projTitleEd.Location = new System.Drawing.Point(30, 97);
            this.projTitleEd.Margin = new System.Windows.Forms.Padding(4);
            this.projTitleEd.Name = "projTitleEd";
            this.projTitleEd.Size = new System.Drawing.Size(480, 24);
            this.projTitleEd.TabIndex = 275;
            this.projTitleEd.Text = "Tên lửa tàng hình";
            // 
            // projTitleLbl
            // 
            this.projTitleLbl.AutoSize = true;
            this.projTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projTitleLbl.Location = new System.Drawing.Point(28, 78);
            this.projTitleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.projTitleLbl.Name = "projTitleLbl";
            this.projTitleLbl.Size = new System.Drawing.Size(76, 16);
            this.projTitleLbl.TabIndex = 284;
            this.projTitleLbl.Text = "Tên dự án *";
            // 
            // onDateEd
            // 
            this.onDateEd.BackColor = System.Drawing.SystemColors.Info;
            this.onDateEd.BeepOnError = true;
            this.onDateEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projCommentSource, "onDate", true));
            this.onDateEd.Enabled = false;
            this.onDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.onDateEd.Location = new System.Drawing.Point(415, 47);
            this.onDateEd.Mask = "00/00/0000";
            this.onDateEd.Name = "onDateEd";
            this.onDateEd.Size = new System.Drawing.Size(89, 24);
            this.onDateEd.TabIndex = 277;
            this.onDateEd.ValidatingType = typeof(System.DateTime);
            // 
            // onDateLbl
            // 
            this.onDateLbl.AutoSize = true;
            this.onDateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onDateLbl.Location = new System.Drawing.Point(412, 29);
            this.onDateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.onDateLbl.Name = "onDateLbl";
            this.onDateLbl.Size = new System.Drawing.Size(41, 16);
            this.onDateLbl.TabIndex = 289;
            this.onDateLbl.Text = "Ngày";
            // 
            // noteEd
            // 
            this.noteEd.BackColor = System.Drawing.SystemColors.Info;
            this.noteEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projCommentSource, "notes", true));
            this.noteEd.Location = new System.Drawing.Point(29, 308);
            this.noteEd.Name = "noteEd";
            this.noteEd.Size = new System.Drawing.Size(481, 90);
            this.noteEd.TabIndex = 12;
            this.noteEd.Text = "";
            // 
            // noteLbl
            // 
            this.noteLbl.AutoSize = true;
            this.noteLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(27, 289);
            this.noteLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(126, 16);
            this.noteLbl.TabIndex = 292;
            this.noteLbl.Text = "Ghi chú  của quản trị";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 309);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 293;
            this.label2.Text = "Mô tả";
            // 
            // projCommentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(529, 495);
            this.Controls.Add(this.noteEd);
            this.Controls.Add(this.noteLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commentEd);
            this.Controls.Add(this.rateLbl);
            this.Controls.Add(this.rateCb);
            this.Controls.Add(this.commentLbl);
            this.Controls.Add(this.descriptionLbl);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.userNameEd);
            this.Controls.Add(this.projTitleEd);
            this.Controls.Add(this.projTitleLbl);
            this.Controls.Add(this.onDateEd);
            this.Controls.Add(this.onDateLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "projCommentEdit";
            this.Tag = "";
            this.Text = "Ý kiến";
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.onDateLbl, 0);
            this.Controls.SetChildIndex(this.onDateEd, 0);
            this.Controls.SetChildIndex(this.projTitleLbl, 0);
            this.Controls.SetChildIndex(this.projTitleEd, 0);
            this.Controls.SetChildIndex(this.userNameEd, 0);
            this.Controls.SetChildIndex(this.codeLbl, 0);
            this.Controls.SetChildIndex(this.descriptionLbl, 0);
            this.Controls.SetChildIndex(this.commentLbl, 0);
            this.Controls.SetChildIndex(this.rateCb, 0);
            this.Controls.SetChildIndex(this.rateLbl, 0);
            this.Controls.SetChildIndex(this.commentEd, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.noteLbl, 0);
            this.Controls.SetChildIndex(this.noteEd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.projCommentSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button checkIdCardBtn;
        protected System.Windows.Forms.BindingSource projCommentSource;
        private System.Windows.Forms.RichTextBox commentEd;
        protected System.Windows.Forms.Label rateLbl;
        private baseClass.Controls.cbProjRateType rateCb;
        protected System.Windows.Forms.Label commentLbl;
        protected System.Windows.Forms.Label descriptionLbl;
        protected System.Windows.Forms.Label codeLbl;
        protected common.control.baseTextBox userNameEd;
        protected common.control.baseTextBox projTitleEd;
        protected System.Windows.Forms.Label projTitleLbl;
        protected common.control.baseTextBox onDateEd;
        protected System.Windows.Forms.Label onDateLbl;
        private System.Windows.Forms.RichTextBox noteEd;
        protected System.Windows.Forms.Label noteLbl;
        protected System.Windows.Forms.Label label2;
    }
}