namespace baseClass.controls
{
    partial class stockCodeSelectByWatchList
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
            this.components = new System.ComponentModel.Container();
            this.stockGV = new common.controls.baseDataGridView();
            this.stockSource = new System.Windows.Forms.BindingSource(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.refreshBtn = new baseClass.controls.baseButton();
            this.codeGroupCb = new baseClass.controls.cbStockSelection();
            ((System.ComponentModel.ISupportInitialize)(this.stockGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockSource)).BeginInit();
            this.SuspendLayout();
            // 
            // stockGV
            // 
            this.stockGV.AllowUserToAddRows = false;
            this.stockGV.AllowUserToDeleteRows = false;
            this.stockGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stockGV.AutoGenerateColumns = false;
            this.stockGV.ColumnHeadersHeight = 30;
            this.stockGV.DataSource = this.stockSource;
            this.stockGV.DisableReadOnlyColumn = false;
            this.stockGV.Location = new System.Drawing.Point(0, 25);
            this.stockGV.Name = "stockGV";
            this.stockGV.ReadOnly = true;
            this.stockGV.RowHeadersWidth = 20;
            this.stockGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.stockGV.Size = new System.Drawing.Size(278, 348);
            this.stockGV.TabIndex = 10;
            this.stockGV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.stockGV_CellDoubleClick);
            this.stockGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.stockGV_DataBindingComplete);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.xls";
            this.saveFileDialog.Filter = "(*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Image = global::baseClass.Properties.Resources.refresh;
            this.refreshBtn.Location = new System.Drawing.Point(258, 1);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(4);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(18, 21);
            this.refreshBtn.TabIndex = 2;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // codeGroupCb
            // 
            this.codeGroupCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codeGroupCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codeGroupCb.FormattingEnabled = true;
            this.codeGroupCb.Location = new System.Drawing.Point(1, -1);
            this.codeGroupCb.myValue = baseClass.controls.cbStockSelection.Options.None;
            this.codeGroupCb.Name = "codeGroupCb";
            this.codeGroupCb.Size = new System.Drawing.Size(256, 24);
            this.codeGroupCb.TabIndex = 1;
            this.codeGroupCb.SelectionChangeCommitted += new System.EventHandler(this.codeGroupCb_SelectionChangeCommitted);
            // 
            // stockCodeSelectByWatchList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.codeGroupCb);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.stockGV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "stockCodeSelectByWatchList";
            this.Size = new System.Drawing.Size(280, 375);
            this.Resize += new System.EventHandler(this.form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.stockGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected baseButton refreshBtn;
        protected System.Windows.Forms.BindingSource stockSource;
        protected common.controls.baseDataGridView stockGV;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected cbStockSelection codeGroupCb;

    }
}
