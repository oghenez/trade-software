namespace baseClass.controls
{
    partial class stockCodeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stockCodeList));
            this.stockCodeLb = new baseClass.controls.lbStockCode();
            this.SuspendLayout();
            // 
            // stockCodeLb
            // 
            this.stockCodeLb.FormattingEnabled = true;
            this.stockCodeLb.ItemHeight = 16;
            this.stockCodeLb.Location = new System.Drawing.Point(165, 3);
            this.stockCodeLb.myItemString = "";
            this.stockCodeLb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeLb.myItemValues")));
            this.stockCodeLb.Name = "stockCodeLb";
            this.stockCodeLb.Size = new System.Drawing.Size(120, 84);
            this.stockCodeLb.TabIndex = 5;
            this.stockCodeLb.SelectedIndexChanged += new System.EventHandler(this.stockCodeLb_SelectedIndexChanged);
            // 
            // stockCodeList
            // 
            this.Controls.Add(this.stockCodeLb);
            this.Name = "stockCodeList";
            this.Controls.SetChildIndex(this.stockCodeLb, 0);
            this.Controls.SetChildIndex(this.addBtn, 0);
            this.Controls.SetChildIndex(this.removeBtn, 0);
            this.ResumeLayout(false);

        }

        #endregion

        protected lbStockCode stockCodeLb;



    }
}
