namespace baseClass.controls
{
    partial class stockCodeSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stockCodeSelection));
            this.bizSectorTypeSelection = new baseClass.controls.bizSectorTypeSelection();
            this.stockCodeClb = new baseClass.controls.clbStockCode();
            this.selectAllChk = new baseClass.controls.baseCheckBox();
            this.showOnlyCheckedChk = new baseClass.controls.baseCheckBox();
            this.SuspendLayout();
            // 
            // bizSectorTypeSelection
            // 
            this.bizSectorTypeSelection.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bizSectorTypeSelection.Location = new System.Drawing.Point(0, 172);
            this.bizSectorTypeSelection.Margin = new System.Windows.Forms.Padding(2);
            this.bizSectorTypeSelection.myBizSectorCode = "";
            this.bizSectorTypeSelection.myBizSectorType = application.myTypes.bizSectorType.None;
            this.bizSectorTypeSelection.Name = "bizSectorTypeSelection";
            this.bizSectorTypeSelection.Size = new System.Drawing.Size(429, 24);
            this.bizSectorTypeSelection.TabIndex = 4;
            this.bizSectorTypeSelection.mySectorSelectionChange += new baseClass.controls.bizSectorTypeSelection.SectorSelectionChange(this.bizSectorTypeSelection_mySectorSelectionChange);
            // 
            // stockCodeClb
            // 
            this.stockCodeClb.CheckOnClick = true;
            this.stockCodeClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeClb.FormattingEnabled = true;
            this.stockCodeClb.Location = new System.Drawing.Point(0, 22);
            this.stockCodeClb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("stockCodeClb.myCheckedItems")));
            this.stockCodeClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeClb.myCheckedValues")));
            this.stockCodeClb.myDataTbl = null;
            this.stockCodeClb.myItemString = "";
            this.stockCodeClb.Name = "stockCodeClb";
            this.stockCodeClb.ShowCheckedOnly = false;
            this.stockCodeClb.Size = new System.Drawing.Size(428, 148);
            this.stockCodeClb.TabIndex = 3;
            // 
            // selectAllChk
            // 
            this.selectAllChk.AutoSize = true;
            this.selectAllChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllChk.Location = new System.Drawing.Point(267, 1);
            this.selectAllChk.Name = "selectAllChk";
            this.selectAllChk.Size = new System.Drawing.Size(67, 20);
            this.selectAllChk.TabIndex = 2;
            this.selectAllChk.Text = "Tất cả";
            this.selectAllChk.UseVisualStyleBackColor = true;
            this.selectAllChk.CheckedChanged += new System.EventHandler(this.selectAllChk_CheckedChanged);
            // 
            // showOnlyCheckedChk
            // 
            this.showOnlyCheckedChk.AutoSize = true;
            this.showOnlyCheckedChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showOnlyCheckedChk.Location = new System.Drawing.Point(1, 1);
            this.showOnlyCheckedChk.Name = "showOnlyCheckedChk";
            this.showOnlyCheckedChk.Size = new System.Drawing.Size(182, 20);
            this.showOnlyCheckedChk.TabIndex = 1;
            this.showOnlyCheckedChk.Text = "Chỉ hiện thị các mã chọn";
            this.showOnlyCheckedChk.UseVisualStyleBackColor = true;
            this.showOnlyCheckedChk.CheckedChanged += new System.EventHandler(this.showOnlyCheckedChk_CheckedChanged);
            // 
            // stockCodeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectAllChk);
            this.Controls.Add(this.showOnlyCheckedChk);
            this.Controls.Add(this.stockCodeClb);
            this.Controls.Add(this.bizSectorTypeSelection);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "stockCodeSelection";
            this.Size = new System.Drawing.Size(430, 200);
            this.Resize += new System.EventHandler(this.form_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected bizSectorTypeSelection bizSectorTypeSelection;
        protected clbStockCode stockCodeClb;
        protected baseCheckBox selectAllChk;
        private baseCheckBox showOnlyCheckedChk;
    }
}
