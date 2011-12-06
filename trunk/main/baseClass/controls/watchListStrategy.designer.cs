namespace baseClass.controls
{
    partial class watchListStrategy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(watchListStrategy));
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeGV = new AdvancedDataGridView.TreeGridView();
            this.strategyColumn = new AdvancedDataGridView.TreeGridColumn();
            this.timeScaleCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageStrip = new System.Windows.Forms.ImageList(this.components);
            this.addAllBtn = new common.controls.baseButton();
            this.deleteBtn = new common.controls.baseButton();
            this.addNewBtn = new common.controls.baseButton();
            this.timeScaleClb = new baseClass.controls.clbTimeScale();
            this.timeScaleLbl = new baseClass.controls.baseLabel();
            this.strategyCb = new baseClass.controls.cbStrategy();
            this.strategyLbl = new baseClass.controls.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.treeGV)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "schoolName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Trường";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "gradYear";
            this.dataGridViewTextBoxColumn2.HeaderText = "Năm TN";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // treeGV
            // 
            this.treeGV.AllowUserToAddRows = false;
            this.treeGV.AllowUserToDeleteRows = false;
            this.treeGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.treeGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.treeGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.treeGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.strategyColumn,
            this.timeScaleCodeColumn});
            this.treeGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.treeGV.ImageList = this.imageStrip;
            this.treeGV.Location = new System.Drawing.Point(1, 48);
            this.treeGV.Name = "treeGV";
            this.treeGV.RowHeadersVisible = false;
            this.treeGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.treeGV.ShowLines = false;
            this.treeGV.Size = new System.Drawing.Size(572, 338);
            this.treeGV.TabIndex = 100;
            // 
            // strategyColumn
            // 
            this.strategyColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.strategyColumn.DefaultNodeImage = null;
            this.strategyColumn.HeaderText = "Strategy";
            this.strategyColumn.Name = "strategyColumn";
            this.strategyColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.strategyColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // timeScaleCodeColumn
            // 
            this.timeScaleCodeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.timeScaleCodeColumn.FillWeight = 1F;
            this.timeScaleCodeColumn.HeaderText = "";
            this.timeScaleCodeColumn.Name = "timeScaleCodeColumn";
            this.timeScaleCodeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.timeScaleCodeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.timeScaleCodeColumn.Width = 20;
            // 
            // imageStrip
            // 
            this.imageStrip.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageStrip.ImageSize = new System.Drawing.Size(16, 16);
            this.imageStrip.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // addAllBtn
            // 
            this.addAllBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addAllBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAllBtn.Image = global::baseClass.Properties.Resources.addAll;
            this.addAllBtn.isDownState = false;
            this.addAllBtn.Location = new System.Drawing.Point(524, 22);
            this.addAllBtn.Name = "addAllBtn";
            this.addAllBtn.Size = new System.Drawing.Size(24, 23);
            this.addAllBtn.TabIndex = 11;
            this.addAllBtn.UseVisualStyleBackColor = true;
            this.addAllBtn.Click += new System.EventHandler(this.addAllBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Image = global::baseClass.Properties.Resources.delete;
            this.deleteBtn.isDownState = false;
            this.deleteBtn.Location = new System.Drawing.Point(548, 22);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(24, 23);
            this.deleteBtn.TabIndex = 12;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewBtn.Image = global::baseClass.Properties.Resources.adddata;
            this.addNewBtn.isDownState = false;
            this.addNewBtn.Location = new System.Drawing.Point(500, 22);
            this.addNewBtn.Name = "addNewBtn";
            this.addNewBtn.Size = new System.Drawing.Size(24, 23);
            this.addNewBtn.TabIndex = 10;
            this.addNewBtn.UseVisualStyleBackColor = true;
            this.addNewBtn.Click += new System.EventHandler(this.addNewBtn_Click);
            // 
            // timeScaleClb
            // 
            this.timeScaleClb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeScaleClb.CheckOnClick = true;
            this.timeScaleClb.FormattingEnabled = true;
            this.timeScaleClb.Location = new System.Drawing.Point(394, 23);
            this.timeScaleClb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("timeScaleClb.myCheckedItems")));
            this.timeScaleClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("timeScaleClb.myCheckedValues")));
            this.timeScaleClb.myItemString = "";
            this.timeScaleClb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("timeScaleClb.myItemValues")));
            this.timeScaleClb.Name = "timeScaleClb";
            this.timeScaleClb.ShowCheckedOnly = false;
            this.timeScaleClb.Size = new System.Drawing.Size(106, 34);
            this.timeScaleClb.TabIndex = 2;
            this.timeScaleClb.MouseHover += new System.EventHandler(this.timeScaleClb_MouseHover);
            this.timeScaleClb.Leave += new System.EventHandler(this.timeScaleClb_Leave);
            this.timeScaleClb.Enter += new System.EventHandler(this.timeScaleClb_Enter);
            this.timeScaleClb.MouseLeave += new System.EventHandler(this.timeScaleClb_MouseLeave);
            // 
            // timeScaleLbl
            // 
            this.timeScaleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeScaleLbl.AutoSize = true;
            this.timeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeScaleLbl.Location = new System.Drawing.Point(395, 5);
            this.timeScaleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeScaleLbl.Name = "timeScaleLbl";
            this.timeScaleLbl.Size = new System.Drawing.Size(75, 16);
            this.timeScaleLbl.TabIndex = 264;
            this.timeScaleLbl.Text = "Time Scale";
            // 
            // strategyCb
            // 
            this.strategyCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.strategyCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.strategyCb.FormattingEnabled = true;
            this.strategyCb.Location = new System.Drawing.Point(0, 23);
            this.strategyCb.myValue = "";
            this.strategyCb.Name = "strategyCb";
            this.strategyCb.SelectedValue = "";
            this.strategyCb.Size = new System.Drawing.Size(395, 21);
            this.strategyCb.TabIndex = 1;
            // 
            // strategyLbl
            // 
            this.strategyLbl.AutoSize = true;
            this.strategyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyLbl.Location = new System.Drawing.Point(-1, 4);
            this.strategyLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.strategyLbl.Name = "strategyLbl";
            this.strategyLbl.Size = new System.Drawing.Size(66, 16);
            this.strategyLbl.TabIndex = 258;
            this.strategyLbl.Text = "Strategy";
            // 
            // watchListStrategy
            // 
            this.Controls.Add(this.timeScaleClb);
            this.Controls.Add(this.addAllBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.timeScaleLbl);
            this.Controls.Add(this.addNewBtn);
            this.Controls.Add(this.treeGV);
            this.Controls.Add(this.strategyCb);
            this.Controls.Add(this.strategyLbl);
            this.Name = "watchListStrategy";
            this.Size = new System.Drawing.Size(573, 389);
            ((System.ComponentModel.ISupportInitialize)(this.treeGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        protected baseLabel strategyLbl;
        private cbStrategy strategyCb;
        private AdvancedDataGridView.TreeGridView treeGV;
        protected baseLabel timeScaleLbl;
        protected common.controls.baseButton addNewBtn;
        private System.Windows.Forms.ImageList imageStrip;
        protected common.controls.baseButton deleteBtn;
        protected common.controls.baseButton addAllBtn;
        private AdvancedDataGridView.TreeGridColumn strategyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeScaleCodeColumn;
        private clbTimeScale timeScaleClb;


    }
}
