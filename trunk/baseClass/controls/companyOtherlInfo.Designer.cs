namespace baseClass.controls
{
    partial class companyOtherInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(companyOtherInfo));
            this.bizSectorClb = new baseClass.controls.subSectorSelect();
            this.bizSectorLbl = new baseClass.controls.baseLabel();
            this.employeeRangeLbl = new baseClass.controls.baseLabel();
            this.estDateLbl = new baseClass.controls.baseLabel();
            this.capitalUnitCb = new baseClass.controls.cbCurrency();
            this.capitalAmtLbl = new baseClass.controls.baseLabel();
            this.estDateEd = new baseClass.controls.txtDate();
            this.capitalAmtEd = new common.control.numberTextBox();
            this.txtDate2ss = new baseClass.controls.txtDate();
            this.employeeRangeCb = new baseClass.controls.cbEmployeeRange();
            this.SuspendLayout();
            // 
            // bizSectorClb
            // 
            this.bizSectorClb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bizSectorClb.Location = new System.Drawing.Point(0, 70);
            this.bizSectorClb.Name = "bizSectorClb";
            this.bizSectorClb.ShowCheckedOnly = false;
            this.bizSectorClb.Size = new System.Drawing.Size(440, 174);
            this.bizSectorClb.TabIndex = 10;
            // 
            // bizSectorLbl
            // 
            this.bizSectorLbl.AutoSize = true;
            this.bizSectorLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bizSectorLbl.Location = new System.Drawing.Point(3, 49);
            this.bizSectorLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bizSectorLbl.Name = "bizSectorLbl";
            this.bizSectorLbl.Size = new System.Drawing.Size(137, 16);
            this.bizSectorLbl.TabIndex = 291;
            this.bizSectorLbl.Text = "Lãnh vực họat động";
            // 
            // employeeRangeLbl
            // 
            this.employeeRangeLbl.AutoSize = true;
            this.employeeRangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeRangeLbl.Location = new System.Drawing.Point(299, 2);
            this.employeeRangeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.employeeRangeLbl.Name = "employeeRangeLbl";
            this.employeeRangeLbl.Size = new System.Drawing.Size(91, 16);
            this.employeeRangeLbl.TabIndex = 294;
            this.employeeRangeLbl.Text = "Số nhân viên";
            // 
            // estDateLbl
            // 
            this.estDateLbl.AutoSize = true;
            this.estDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estDateLbl.Location = new System.Drawing.Point(3, 2);
            this.estDateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.estDateLbl.Name = "estDateLbl";
            this.estDateLbl.Size = new System.Drawing.Size(70, 16);
            this.estDateLbl.TabIndex = 290;
            this.estDateLbl.Text = "Thành lập";
            // 
            // capitalUnitCb
            // 
            this.capitalUnitCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.capitalUnitCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalUnitCb.FormattingEnabled = true;
            this.capitalUnitCb.Location = new System.Drawing.Point(228, 22);
            this.capitalUnitCb.myValue = "";
            this.capitalUnitCb.Name = "capitalUnitCb";
            this.capitalUnitCb.Size = new System.Drawing.Size(76, 24);
            this.capitalUnitCb.TabIndex = 3;
            // 
            // capitalAmtLbl
            // 
            this.capitalAmtLbl.AutoSize = true;
            this.capitalAmtLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalAmtLbl.Location = new System.Drawing.Point(86, 2);
            this.capitalAmtLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.capitalAmtLbl.Name = "capitalAmtLbl";
            this.capitalAmtLbl.Size = new System.Drawing.Size(79, 16);
            this.capitalAmtLbl.TabIndex = 293;
            this.capitalAmtLbl.Text = "Vốn điều lệ";
            // 
            // estDateEd
            // 
            this.estDateEd.BackColor = System.Drawing.Color.White;
            this.estDateEd.BeepOnError = true;
            this.estDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estDateEd.ForeColor = System.Drawing.Color.Black;
            this.estDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.estDateEd.Location = new System.Drawing.Point(0, 22);
            this.estDateEd.Mask = "00/00/0000";
            this.estDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.estDateEd.Name = "estDateEd";
            this.estDateEd.Size = new System.Drawing.Size(85, 22);
            this.estDateEd.TabIndex = 1;
            this.estDateEd.Text = "3302011";
            // 
            // capitalAmtEd
            // 
            this.capitalAmtEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalAmtEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.capitalAmtEd.Location = new System.Drawing.Point(85, 22);
            this.capitalAmtEd.myFormat = "###,###,###,###,###";
            this.capitalAmtEd.Name = "capitalAmtEd";
            this.capitalAmtEd.Size = new System.Drawing.Size(143, 22);
            this.capitalAmtEd.TabIndex = 2;
            this.capitalAmtEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.capitalAmtEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.capitalAmtEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtDate2ss
            // 
            this.txtDate2ss.BackColor = System.Drawing.Color.White;
            this.txtDate2ss.BeepOnError = true;
            this.txtDate2ss.ForeColor = System.Drawing.Color.Black;
            this.txtDate2ss.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate2ss.Location = new System.Drawing.Point(0, 22);
            this.txtDate2ss.Mask = "00/00/0000";
            this.txtDate2ss.myDateTime = new System.DateTime(((long)(0)));
            this.txtDate2ss.Name = "txtDate2ss";
            this.txtDate2ss.Size = new System.Drawing.Size(85, 20);
            this.txtDate2ss.TabIndex = 1;
            // 
            // employeeRangeCb
            // 
            this.employeeRangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeeRangeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeRangeCb.FormattingEnabled = true;
            this.employeeRangeCb.Location = new System.Drawing.Point(300, 22);
            this.employeeRangeCb.myValue = 0;
            this.employeeRangeCb.Name = "employeeRangeCb";
            this.employeeRangeCb.Size = new System.Drawing.Size(140, 24);
            this.employeeRangeCb.TabIndex = 4;
            // 
            // companyOtherInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.employeeRangeCb);
            this.Controls.Add(this.bizSectorClb);
            this.Controls.Add(this.bizSectorLbl);
            this.Controls.Add(this.employeeRangeLbl);
            this.Controls.Add(this.estDateLbl);
            this.Controls.Add(this.capitalUnitCb);
            this.Controls.Add(this.capitalAmtLbl);
            this.Controls.Add(this.estDateEd);
            this.Controls.Add(this.capitalAmtEd);
            this.Name = "companyOtherInfo";
            this.Size = new System.Drawing.Size(440, 246);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private subSectorSelect bizSectorClb;
        protected baseLabel bizSectorLbl;
        protected baseLabel employeeRangeLbl;
        protected baseLabel estDateLbl;
        private cbCurrency capitalUnitCb;
        protected baseLabel capitalAmtLbl;
        private txtDate estDateEd;
        private common.control.numberTextBox capitalAmtEd;
        private txtDate txtDate2ss;
        private cbEmployeeRange employeeRangeCb;
    }
}
