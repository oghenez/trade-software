namespace baseClass.controls
{
    partial class stockCodeSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stockCodeSelect));
            this.stockSelectionCb = new baseClass.controls.cbStockSelection();
            this.optionPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // bizSectorTypesSelection
            // 
            this.bizSectorTypesSelection.Enabled = false;
            this.bizSectorTypesSelection.Location = new System.Drawing.Point(0, 25);
            this.bizSectorTypesSelection.Size = new System.Drawing.Size(826, 24);
            this.bizSectorTypesSelection.TabIndex = 10;
            // 
            // stockCodeClb
            // 
            this.stockCodeClb.Location = new System.Drawing.Point(0, 52);
            this.stockCodeClb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("stockCodeClb.myCheckedItems")));
            this.stockCodeClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeClb.myCheckedValues")));
            this.stockCodeClb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeClb.myItemValues")));
            this.stockCodeClb.Size = new System.Drawing.Size(826, 508);
            this.stockCodeClb.TabIndex = 11;
            // 
            // selectAllChk
            // 
            this.selectAllChk.Location = new System.Drawing.Point(3, 3);
            // 
            // selectCodeEd
            // 
            this.selectCodeEd.Location = new System.Drawing.Point(216, 1);
            this.selectCodeEd.Size = new System.Drawing.Size(586, 23);
            // 
            // optionPnl
            // 
            this.optionPnl.Location = new System.Drawing.Point(-2, 567);
            this.optionPnl.Size = new System.Drawing.Size(827, 27);
            this.optionPnl.TabIndex = 20;
            // 
            // selectCodeBtn
            // 
            this.selectCodeBtn.Location = new System.Drawing.Point(803, 2);
            // 
            // showOnlyCheckedChk
            // 
            this.showOnlyCheckedChk.Location = new System.Drawing.Point(97, 3);
            // 
            // stockSelectionCb
            // 
            this.stockSelectionCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stockSelectionCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockSelectionCb.FormattingEnabled = true;
            this.stockSelectionCb.Location = new System.Drawing.Point(0, 0);
            this.stockSelectionCb.myValue = baseClass.controls.cbStockSelection.Options.None;
            this.stockSelectionCb.Name = "stockSelectionCb";
            this.stockSelectionCb.Size = new System.Drawing.Size(826, 24);
            this.stockSelectionCb.TabIndex = 1;
            this.stockSelectionCb.SelectionChangeCommitted += new System.EventHandler(this.stockSelectionCb_SelectionChangeCommitted);
            // 
            // stockCodeSelect
            // 
            this.Controls.Add(this.stockSelectionCb);
            this.myValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("$this.myValues")));
            this.Name = "stockCodeSelect";
            this.Size = new System.Drawing.Size(826, 596);
            this.Controls.SetChildIndex(this.stockSelectionCb, 0);
            this.Controls.SetChildIndex(this.bizSectorTypesSelection, 0);
            this.Controls.SetChildIndex(this.stockCodeClb, 0);
            this.Controls.SetChildIndex(this.optionPnl, 0);
            this.optionPnl.ResumeLayout(false);
            this.optionPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected cbStockSelection stockSelectionCb;
    }
}
