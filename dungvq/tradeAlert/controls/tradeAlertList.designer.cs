namespace tradeAlert.controls
{
    partial class tradeAlertList
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
            this.tradeAlertGrid = new common.control.baseDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tradeAlertGrid
            // 
            this.tradeAlertGrid.Location = new System.Drawing.Point(0, 0);
            this.tradeAlertGrid.Name = "tradeAlertGrid";
            this.tradeAlertGrid.Size = new System.Drawing.Size(411, 183);
            this.tradeAlertGrid.TabIndex = 0;
            this.tradeAlertGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // tradeAlertList
            // 
            this.Controls.Add(this.tradeAlertGrid);
            this.Name = "tradeAlertList";
            this.Size = new System.Drawing.Size(531, 269);
            this.Resize += new System.EventHandler(this.tradeAlertList_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tradeAlertGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.TextBox commonNameEd;
        protected common.control.baseDataGridView tradeAlertGrid;
    }
}
