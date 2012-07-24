namespace application.forms
{
    partial class commonIndicatorForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.paramGrid = new common.controls.baseDataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.paraPg = new System.Windows.Forms.TabPage();
            this.lblWindow = new System.Windows.Forms.Label();
            this.cbbWindow = new System.Windows.Forms.ComboBox();
            this.outputLbl = new common.controls.baseLabel();
            this.paraLbl = new common.controls.baseLabel();
            this.outputGrid = new common.controls.baseDataGridView();
            this.outNameolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outColorColumn = new common.controls.ColorPickerColumn();
            this.outWeightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outChartTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inNewPaneChk = new common.controls.baseCheckBox();
            this.paraDescEd = new common.controls.baseTextBox();
            this.hintPg = new System.Windows.Forms.TabPage();
            this.hintTextEd = new common.controls.baseTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.paramGrid)).BeginInit();
            this.tabControl.SuspendLayout();
            this.paraPg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputGrid)).BeginInit();
            this.hintPg.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(277, 311);
            this.saveBtn.Text = "Save settings";
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.closeBtn.Location = new System.Drawing.Point(481, 396);
            this.closeBtn.Size = new System.Drawing.Size(104, 26);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(175, 311);
            this.okBtn.Text = "Ok";
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(828, 33);
            this.TitleLbl.Size = new System.Drawing.Size(87, 26);
            // 
            // paramGrid
            // 
            this.paramGrid.AllowUserToAddRows = false;
            this.paramGrid.AllowUserToDeleteRows = false;
            this.paramGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.paramGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.valueColumn});
            this.paramGrid.Location = new System.Drawing.Point(3, 22);
            this.paramGrid.Name = "paramGrid";
            this.paramGrid.RowHeadersWidth = 25;
            this.paramGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paramGrid.RowTemplate.Height = 24;
            this.paramGrid.Size = new System.Drawing.Size(392, 115);
            this.paramGrid.TabIndex = 1;
            this.paramGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.paramGrid_DataError);
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Names";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 185;
            // 
            // valueColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.valueColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.valueColumn.HeaderText = "Values";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.Width = 155;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.paraPg);
            this.tabControl.Controls.Add(this.hintPg);
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(-3, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(402, 379);
            this.tabControl.TabIndex = 1;
            // 
            // paraPg
            // 
            this.paraPg.Controls.Add(this.lblWindow);
            this.paraPg.Controls.Add(this.cbbWindow);
            this.paraPg.Controls.Add(this.outputLbl);
            this.paraPg.Controls.Add(this.paraLbl);
            this.paraPg.Controls.Add(this.outputGrid);
            this.paraPg.Controls.Add(this.inNewPaneChk);
            this.paraPg.Controls.Add(this.paramGrid);
            this.paraPg.Controls.Add(this.paraDescEd);
            this.paraPg.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraPg.Location = new System.Drawing.Point(4, 25);
            this.paraPg.Name = "paraPg";
            this.paraPg.Padding = new System.Windows.Forms.Padding(3);
            this.paraPg.Size = new System.Drawing.Size(394, 350);
            this.paraPg.TabIndex = 0;
            this.paraPg.Text = "Parameters";
            this.paraPg.UseVisualStyleBackColor = true;
            // 
            // lblWindow
            // 
            this.lblWindow.AutoSize = true;
            this.lblWindow.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindow.Location = new System.Drawing.Point(6, 280);
            this.lblWindow.Name = "lblWindow";
            this.lblWindow.Size = new System.Drawing.Size(117, 16);
            this.lblWindow.TabIndex = 15;
            this.lblWindow.Text = "Draw on Window";
            this.lblWindow.Visible = false;
            // 
            // cbbWindow
            // 
            this.cbbWindow.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbWindow.FormattingEnabled = true;
            this.cbbWindow.Location = new System.Drawing.Point(6, 298);
            this.cbbWindow.Name = "cbbWindow";
            this.cbbWindow.Size = new System.Drawing.Size(150, 22);
            this.cbbWindow.TabIndex = 14;
            this.cbbWindow.Visible = false;
            // 
            // outputLbl
            // 
            this.outputLbl.AutoSize = true;
            this.outputLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLbl.Location = new System.Drawing.Point(0, 140);
            this.outputLbl.Name = "outputLbl";
            this.outputLbl.Size = new System.Drawing.Size(60, 16);
            this.outputLbl.TabIndex = 13;
            this.outputLbl.Text = "Outputs";
            // 
            // paraLbl
            // 
            this.paraLbl.AutoSize = true;
            this.paraLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraLbl.Location = new System.Drawing.Point(6, 4);
            this.paraLbl.Name = "paraLbl";
            this.paraLbl.Size = new System.Drawing.Size(84, 16);
            this.paraLbl.TabIndex = 12;
            this.paraLbl.Text = "Parameters";
            // 
            // outputGrid
            // 
            this.outputGrid.AllowUserToAddRows = false;
            this.outputGrid.AllowUserToDeleteRows = false;
            this.outputGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.outNameolumn,
            this.outColorColumn,
            this.outWeightColumn,
            this.outChartTypeColumn});
            this.outputGrid.Location = new System.Drawing.Point(1, 159);
            this.outputGrid.Name = "outputGrid";
            this.outputGrid.RowHeadersWidth = 25;
            this.outputGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputGrid.RowTemplate.Height = 24;
            this.outputGrid.Size = new System.Drawing.Size(394, 121);
            this.outputGrid.TabIndex = 11;
            // 
            // outNameolumn
            // 
            this.outNameolumn.HeaderText = "Names";
            this.outNameolumn.Name = "outNameolumn";
            this.outNameolumn.ReadOnly = true;
            this.outNameolumn.Width = 185;
            // 
            // outColorColumn
            // 
            this.outColorColumn.HeaderText = "Colors";
            this.outColorColumn.Name = "outColorColumn";
            // 
            // outWeightColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.outWeightColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.outWeightColumn.HeaderText = "Weight";
            this.outWeightColumn.Name = "outWeightColumn";
            this.outWeightColumn.Width = 55;
            // 
            // outChartTypeColumn
            // 
            this.outChartTypeColumn.HeaderText = "ChartType";
            this.outChartTypeColumn.Name = "outChartTypeColumn";
            this.outChartTypeColumn.Visible = false;
            // 
            // inNewPaneChk
            // 
            this.inNewPaneChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inNewPaneChk.AutoSize = true;
            this.inNewPaneChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inNewPaneChk.Location = new System.Drawing.Point(4, 295);
            this.inNewPaneChk.Name = "inNewPaneChk";
            this.inNewPaneChk.Size = new System.Drawing.Size(137, 20);
            this.inNewPaneChk.TabIndex = 10;
            this.inNewPaneChk.Text = "Trong cửa sổ mới";
            this.inNewPaneChk.UseVisualStyleBackColor = true;
            // 
            // paraDescEd
            // 
            this.paraDescEd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.paraDescEd.BackColor = System.Drawing.SystemColors.Control;
            this.paraDescEd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraDescEd.isRequired = true;
            this.paraDescEd.isToUpperCase = false;
            this.paraDescEd.Location = new System.Drawing.Point(-3, 377);
            this.paraDescEd.Multiline = true;
            this.paraDescEd.Name = "paraDescEd";
            this.paraDescEd.ReadOnly = true;
            this.paraDescEd.Size = new System.Drawing.Size(394, 45);
            this.paraDescEd.TabIndex = 3;
            this.paraDescEd.Visible = false;
            // 
            // hintPg
            // 
            this.hintPg.Controls.Add(this.hintTextEd);
            this.hintPg.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintPg.Location = new System.Drawing.Point(4, 25);
            this.hintPg.Name = "hintPg";
            this.hintPg.Padding = new System.Windows.Forms.Padding(3);
            this.hintPg.Size = new System.Drawing.Size(394, 350);
            this.hintPg.TabIndex = 1;
            this.hintPg.Text = "Description";
            this.hintPg.UseVisualStyleBackColor = true;
            // 
            // hintTextEd
            // 
            this.hintTextEd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hintTextEd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintTextEd.isRequired = true;
            this.hintTextEd.isToUpperCase = false;
            this.hintTextEd.Location = new System.Drawing.Point(-1, 2);
            this.hintTextEd.Multiline = true;
            this.hintTextEd.Name = "hintTextEd";
            this.hintTextEd.ReadOnly = true;
            this.hintTextEd.Size = new System.Drawing.Size(396, 254);
            this.hintTextEd.TabIndex = 1;
            // 
            // commonIndicatorForm
            // 
            this.ClientSize = new System.Drawing.Size(396, 374);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "commonIndicatorForm";
            this.Text = "Indicators";
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.Controls.SetChildIndex(this.saveBtn, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.paramGrid)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.paraPg.ResumeLayout(false);
            this.paraPg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputGrid)).EndInit();
            this.hintPg.ResumeLayout(false);
            this.hintPg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.controls.baseDataGridView paramGrid;
        private System.Windows.Forms.TabPage paraPg;
        private System.Windows.Forms.TabPage hintPg;
        protected System.Windows.Forms.TabControl tabControl;
        protected common.controls.baseTextBox hintTextEd;
        protected common.controls.baseTextBox paraDescEd;
        protected common.controls.baseCheckBox inNewPaneChk;
        protected common.controls.baseDataGridView outputGrid;
        private common.controls.baseLabel paraLbl;
        private common.controls.baseLabel outputLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn outNameolumn;
        private common.controls.ColorPickerColumn outColorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outWeightColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outChartTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
        private System.Windows.Forms.Label lblWindow;
        private System.Windows.Forms.ComboBox cbbWindow;

    }
}
