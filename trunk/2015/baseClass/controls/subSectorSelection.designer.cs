namespace baseClass.controls
{
    partial class subSectorSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(subSectorSelection));
            this.bizSectorTypeSelection = new baseClass.controls.bizSectorTypeSelection();
            this.showOnlyCheckedChk = new baseClass.controls.baseCheckBox();
            this.subSectorListClb = new baseClass.controls.clbBizSubSector();
            this.selectAllChk = new baseClass.controls.baseCheckBox();
            this.SuspendLayout();
            // 
            // bizSectorTypeSelection
            // 
            this.bizSectorTypeSelection.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bizSectorTypeSelection.Location = new System.Drawing.Point(1, 230);
            this.bizSectorTypeSelection.Margin = new System.Windows.Forms.Padding(2);
            this.bizSectorTypeSelection.myBizSectorCode = "";
            this.bizSectorTypeSelection.myBizSectorType = application.myTypes.bizSectorType.None;
            this.bizSectorTypeSelection.Name = "bizSectorTypeSelection";
            this.bizSectorTypeSelection.Size = new System.Drawing.Size(433, 24);
            this.bizSectorTypeSelection.TabIndex = 2;
            this.bizSectorTypeSelection.mySectorSelectionChange += new baseClass.controls.bizSectorTypeSelection.SectorSelectionChange(this.bizSectorTypeSelection_mySectorSelectionChange);
            // 
            // showOnlyCheckedChk
            // 
            this.showOnlyCheckedChk.AutoSize = true;
            this.showOnlyCheckedChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showOnlyCheckedChk.Location = new System.Drawing.Point(0, 0);
            this.showOnlyCheckedChk.Name = "showOnlyCheckedChk";
            this.showOnlyCheckedChk.Size = new System.Drawing.Size(182, 20);
            this.showOnlyCheckedChk.TabIndex = 1;
            this.showOnlyCheckedChk.Text = "Chỉ hiện thị các mã chọn";
            this.showOnlyCheckedChk.UseVisualStyleBackColor = true;
            this.showOnlyCheckedChk.CheckedChanged += new System.EventHandler(this.showOnlyCheckedChk_CheckedChanged);
            // 
            // subSectorListClb
            // 
            this.subSectorListClb.CheckOnClick = true;
            this.subSectorListClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subSectorListClb.FormattingEnabled = true;
            this.subSectorListClb.Location = new System.Drawing.Point(1, 24);
            this.subSectorListClb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("subSectorListClb.myCheckedItems")));
            this.subSectorListClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("subSectorListClb.myCheckedValues")));
            this.subSectorListClb.myItemString = "";
            this.subSectorListClb.Name = "subSectorListClb";
            this.subSectorListClb.ShowCheckedOnly = false;
            this.subSectorListClb.Size = new System.Drawing.Size(429, 202);
            this.subSectorListClb.TabIndex = 3;
            // 
            // selectAllChk
            // 
            this.selectAllChk.AutoSize = true;
            this.selectAllChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllChk.Location = new System.Drawing.Point(250, 0);
            this.selectAllChk.Name = "selectAllChk";
            this.selectAllChk.Size = new System.Drawing.Size(67, 20);
            this.selectAllChk.TabIndex = 2;
            this.selectAllChk.Text = "Tất cả";
            this.selectAllChk.UseVisualStyleBackColor = true;
            this.selectAllChk.CheckedChanged += new System.EventHandler(this.selectAllChk_CheckedChanged);
            // 
            // subSectorSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectAllChk);
            this.Controls.Add(this.bizSectorTypeSelection);
            this.Controls.Add(this.showOnlyCheckedChk);
            this.Controls.Add(this.subSectorListClb);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "subSectorSelection";
            this.Size = new System.Drawing.Size(430, 260);
            this.Resize += new System.EventHandler(this.form_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private clbBizSubSector subSectorListClb;
        private baseClass.controls.baseCheckBox showOnlyCheckedChk;
        protected bizSectorTypeSelection bizSectorTypeSelection;
        protected baseCheckBox selectAllChk;
    }
}
