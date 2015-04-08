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
            this.bizSectorLbl = new baseClass.controls.baseLabel();
            this.txtDate2ss = new baseClass.controls.txtDate();
            this.bizSectorLb = new baseClass.controls.subSectorList();
            this.SuspendLayout();
            // 
            // bizSectorLbl
            // 
            this.bizSectorLbl.AutoSize = true;
            this.bizSectorLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bizSectorLbl.Location = new System.Drawing.Point(3, 3);
            this.bizSectorLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bizSectorLbl.Name = "bizSectorLbl";
            this.bizSectorLbl.Size = new System.Drawing.Size(118, 16);
            this.bizSectorLbl.TabIndex = 291;
            this.bizSectorLbl.Text = "Business Sectors";
            // 
            // txtDate2ss
            // 
            this.txtDate2ss.BackColor = System.Drawing.Color.White;
            this.txtDate2ss.BeepOnError = true;
            this.txtDate2ss.ForeColor = System.Drawing.Color.Black;
            this.txtDate2ss.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate2ss.Location = new System.Drawing.Point(0, 2);
            this.txtDate2ss.Mask = "00/00/0000";
            this.txtDate2ss.myDateTime = new System.DateTime(((long)(0)));
            this.txtDate2ss.Name = "txtDate2ss";
            this.txtDate2ss.Size = new System.Drawing.Size(85, 20);
            this.txtDate2ss.TabIndex = 1;
            // 
            // bizSectorLb
            // 
            this.bizSectorLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bizSectorLb.Enabled = false;
            this.bizSectorLb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bizSectorLb.Location = new System.Drawing.Point(0, 21);
            this.bizSectorLb.Margin = new System.Windows.Forms.Padding(2);
            this.bizSectorLb.myItemString = "";
            this.bizSectorLb.Name = "bizSectorLb";
            this.bizSectorLb.Size = new System.Drawing.Size(437, 116);
            this.bizSectorLb.TabIndex = 292;
            // 
            // companyOtherInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.bizSectorLb);
            this.Controls.Add(this.bizSectorLbl);
            this.Name = "companyOtherInfo";
            this.Size = new System.Drawing.Size(440, 138);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseLabel bizSectorLbl;
        private txtDate txtDate2ss;
        protected subSectorList bizSectorLb;
    }
}
