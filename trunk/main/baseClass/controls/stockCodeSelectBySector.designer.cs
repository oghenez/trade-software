namespace baseClass.controls
{
    partial class stockCodeSelectBySector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stockCodeSelectBySector));
            this.selectCodeEd = new common.controls.baseTextBox();
            this.optionPnl = new System.Windows.Forms.Panel();
            this.selectCodeBtn = new baseClass.controls.baseButton();
            this.showOnlyCheckedChk = new baseClass.controls.baseCheckBox();
            this.selectAllChk = new baseClass.controls.baseCheckBox();
            this.stockCodeClb = new baseClass.controls.clbStockCode();
            this.bizSectorTypesSelection = new baseClass.controls.BizSectorTypesSelection();
            this.optionPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectCodeEd
            // 
            this.selectCodeEd.BackColor = System.Drawing.Color.White;
            this.selectCodeEd.ForeColor = System.Drawing.Color.Black;
            this.selectCodeEd.Location = new System.Drawing.Point(222, 1);
            this.selectCodeEd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectCodeEd.Name = "selectCodeEd";
            this.selectCodeEd.Size = new System.Drawing.Size(159, 23);
            this.selectCodeEd.TabIndex = 3;
            this.selectCodeEd.Validated += new System.EventHandler(this.selectCodeEd_Validated);
            // 
            // optionPnl
            // 
            this.optionPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.optionPnl.Controls.Add(this.selectCodeBtn);
            this.optionPnl.Controls.Add(this.showOnlyCheckedChk);
            this.optionPnl.Controls.Add(this.selectCodeEd);
            this.optionPnl.Controls.Add(this.selectAllChk);
            this.optionPnl.Location = new System.Drawing.Point(0, 377);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(703, 27);
            this.optionPnl.TabIndex = 8;
            this.optionPnl.Resize += new System.EventHandler(this.optionPnl_Resize);
            // 
            // selectCodeBtn
            // 
            this.selectCodeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCodeBtn.Image = global::baseClass.Properties.Resources.addLine;
            this.selectCodeBtn.Location = new System.Drawing.Point(377, 1);
            this.selectCodeBtn.Name = "selectCodeBtn";
            this.selectCodeBtn.Size = new System.Drawing.Size(23, 23);
            this.selectCodeBtn.TabIndex = 4;
            this.selectCodeBtn.UseVisualStyleBackColor = true;
            this.selectCodeBtn.Click += new System.EventHandler(this.selectCodeBtn_Click);
            // 
            // showOnlyCheckedChk
            // 
            this.showOnlyCheckedChk.AutoSize = true;
            this.showOnlyCheckedChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showOnlyCheckedChk.Location = new System.Drawing.Point(98, 2);
            this.showOnlyCheckedChk.Name = "showOnlyCheckedChk";
            this.showOnlyCheckedChk.Size = new System.Drawing.Size(115, 20);
            this.showOnlyCheckedChk.TabIndex = 2;
            this.showOnlyCheckedChk.Text = "Only Selected";
            this.showOnlyCheckedChk.UseVisualStyleBackColor = true;
            this.showOnlyCheckedChk.CheckedChanged += new System.EventHandler(this.showOnlyCheckedChk_CheckedChanged);
            // 
            // selectAllChk
            // 
            this.selectAllChk.AutoSize = true;
            this.selectAllChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllChk.Location = new System.Drawing.Point(5, 2);
            this.selectAllChk.Name = "selectAllChk";
            this.selectAllChk.Size = new System.Drawing.Size(87, 20);
            this.selectAllChk.TabIndex = 1;
            this.selectAllChk.Text = "Select All";
            this.selectAllChk.UseVisualStyleBackColor = true;
            this.selectAllChk.CheckedChanged += new System.EventHandler(this.selectAllChk_CheckedChanged);
            // 
            // stockCodeClb
            // 
            this.stockCodeClb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stockCodeClb.CheckOnClick = true;
            this.stockCodeClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeClb.FormattingEnabled = true;
            this.stockCodeClb.Location = new System.Drawing.Point(-1, 27);
            this.stockCodeClb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("stockCodeClb.myCheckedItems")));
            this.stockCodeClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeClb.myCheckedValues")));
            this.stockCodeClb.myDataTbl = null;
            this.stockCodeClb.myItemString = "";
            this.stockCodeClb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeClb.myItemValues")));
            this.stockCodeClb.Name = "stockCodeClb";
            this.stockCodeClb.ShowCheckedOnly = false;
            this.stockCodeClb.Size = new System.Drawing.Size(703, 346);
            this.stockCodeClb.TabIndex = 2;
            // 
            // bizSectorTypesSelection
            // 
            this.bizSectorTypesSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bizSectorTypesSelection.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bizSectorTypesSelection.Location = new System.Drawing.Point(0, 1);
            this.bizSectorTypesSelection.Margin = new System.Windows.Forms.Padding(2);
            this.bizSectorTypesSelection.myBizSectorCode = "";
            this.bizSectorTypesSelection.myBizSectorType = application.AppTypes.BizSectorTypes.None;
            this.bizSectorTypesSelection.Name = "bizSectorTypesSelection";
            this.bizSectorTypesSelection.Size = new System.Drawing.Size(705, 24);
            this.bizSectorTypesSelection.TabIndex = 1;
            this.bizSectorTypesSelection.mySectorSelectionChange += new baseClass.controls.BizSectorTypesSelection.SectorSelectionChange(this.bizSectorTypesSelection_mySectorSelectionChange);
            // 
            // stockCodeSelectBySector
            // 
            this.Controls.Add(this.optionPnl);
            this.Controls.Add(this.stockCodeClb);
            this.Controls.Add(this.bizSectorTypesSelection);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "stockCodeSelectBySector";
            this.Size = new System.Drawing.Size(703, 409);
            this.optionPnl.ResumeLayout(false);
            this.optionPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected BizSectorTypesSelection bizSectorTypesSelection;
        protected clbStockCode stockCodeClb;
        protected baseCheckBox selectAllChk;
        protected common.controls.baseTextBox selectCodeEd;
        protected System.Windows.Forms.Panel optionPnl;
        protected baseButton selectCodeBtn;
        protected baseCheckBox showOnlyCheckedChk;
    }
}
