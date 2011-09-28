﻿namespace baseClass.controls
{
    partial class subSectorSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(subSectorSelect));
            this.BizSectorTypesSelection = new baseClass.controls.BizSectorTypesSelection();
            this.showOnlyCheckedChk = new baseClass.controls.baseCheckBox();
            this.subSectorListClb = new baseClass.controls.clbBizSubSector();
            this.selectAllChk = new baseClass.controls.baseCheckBox();
            this.SuspendLayout();
            // 
            // BizSectorTypesSelection
            // 
            this.BizSectorTypesSelection.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BizSectorTypesSelection.Location = new System.Drawing.Point(0, 0);
            this.BizSectorTypesSelection.Margin = new System.Windows.Forms.Padding(2);
            this.BizSectorTypesSelection.myBizSectorCode = "";
            this.BizSectorTypesSelection.myBizSectorType = application.AppTypes.BizSectorTypes.None;
            this.BizSectorTypesSelection.Name = "BizSectorTypesSelection";
            this.BizSectorTypesSelection.Size = new System.Drawing.Size(433, 24);
            this.BizSectorTypesSelection.TabIndex = 1;
            this.BizSectorTypesSelection.mySectorSelectionChange += new baseClass.controls.BizSectorTypesSelection.SectorSelectionChange(this.BizSectorTypesSelection_mySectorSelectionChange);
            // 
            // showOnlyCheckedChk
            // 
            this.showOnlyCheckedChk.AutoSize = true;
            this.showOnlyCheckedChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showOnlyCheckedChk.Location = new System.Drawing.Point(76, 233);
            this.showOnlyCheckedChk.Name = "showOnlyCheckedChk";
            this.showOnlyCheckedChk.Size = new System.Drawing.Size(80, 20);
            this.showOnlyCheckedChk.TabIndex = 4;
            this.showOnlyCheckedChk.Text = "Đã chọn";
            this.showOnlyCheckedChk.UseVisualStyleBackColor = true;
            this.showOnlyCheckedChk.CheckedChanged += new System.EventHandler(this.showOnlyCheckedChk_CheckedChanged);
            // 
            // subSectorListClb
            // 
            this.subSectorListClb.CheckOnClick = true;
            this.subSectorListClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subSectorListClb.FormattingEnabled = true;
            this.subSectorListClb.Location = new System.Drawing.Point(0, 26);
            this.subSectorListClb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("subSectorListClb.myCheckedItems")));
            this.subSectorListClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("subSectorListClb.myCheckedValues")));
            this.subSectorListClb.myItemString = "";
            this.subSectorListClb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("subSectorListClb.myItemValues")));
            this.subSectorListClb.Name = "subSectorListClb";
            this.subSectorListClb.ShowCheckedOnly = false;
            this.subSectorListClb.Size = new System.Drawing.Size(429, 202);
            this.subSectorListClb.TabIndex = 2;
            // 
            // selectAllChk
            // 
            this.selectAllChk.AutoSize = true;
            this.selectAllChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllChk.Location = new System.Drawing.Point(3, 233);
            this.selectAllChk.Name = "selectAllChk";
            this.selectAllChk.Size = new System.Drawing.Size(67, 20);
            this.selectAllChk.TabIndex = 3;
            this.selectAllChk.Text = "Tất cả";
            this.selectAllChk.UseVisualStyleBackColor = true;
            this.selectAllChk.CheckedChanged += new System.EventHandler(this.selectAllChk_CheckedChanged);
            // 
            // subSectorSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            
            this.Controls.Add(this.selectAllChk);
            this.Controls.Add(this.BizSectorTypesSelection);
            this.Controls.Add(this.showOnlyCheckedChk);
            this.Controls.Add(this.subSectorListClb);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "subSectorSelect";
            this.Size = new System.Drawing.Size(432, 259);
            this.Resize += new System.EventHandler(this.form_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private clbBizSubSector subSectorListClb;
        private baseClass.controls.baseCheckBox showOnlyCheckedChk;
        protected BizSectorTypesSelection BizSectorTypesSelection;
        protected baseCheckBox selectAllChk;
    }
}
