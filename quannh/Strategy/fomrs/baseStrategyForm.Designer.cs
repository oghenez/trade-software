﻿namespace Strategy.forms
{
    partial class baseStrategyForm
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
            this.paramGrid = new common.control.baseDataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.paraPg = new System.Windows.Forms.TabPage();
            this.paraDescEd = new common.control.baseTextBox();
            this.saveParaChk = new common.control.baseCheckBox();
            this.hintPg = new System.Windows.Forms.TabPage();
            this.hintTextEd = new common.control.baseTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.paramGrid)).BeginInit();
            this.tabControl.SuspendLayout();
            this.paraPg.SuspendLayout();
            this.hintPg.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.closeBtn.Location = new System.Drawing.Point(469, 205);
            this.closeBtn.Size = new System.Drawing.Size(104, 26);
            this.closeBtn.TabIndex = 102;
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeBtn.Visible = false;
            // 
            // okBtn
            // 
            this.okBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okBtn.Location = new System.Drawing.Point(288, 210);
            this.okBtn.Size = new System.Drawing.Size(96, 28);
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(828, 33);
            this.TitleLbl.Size = new System.Drawing.Size(87, 26);
            this.TitleLbl.Visible = false;
            // 
            // paramGrid
            // 
            this.paramGrid.AllowUserToAddRows = false;
            this.paramGrid.AllowUserToDeleteRows = false;
            this.paramGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.paramGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.valueColumn});
            this.paramGrid.DisableReadOnlyColumn = true;
            this.paramGrid.Location = new System.Drawing.Point(1, 2);
            this.paramGrid.Name = "paramGrid";
            this.paramGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paramGrid.Size = new System.Drawing.Size(401, 135);
            this.paramGrid.TabIndex = 1;
            this.paramGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.paramGrid_DataError);
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Tên tham số";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 180;
            // 
            // valueColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.valueColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.valueColumn.HeaderText = "Giá trị";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.Width = 160;
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
            this.tabControl.Size = new System.Drawing.Size(409, 269);
            this.tabControl.TabIndex = 1;
            // 
            // paraPg
            // 
            this.paraPg.Controls.Add(this.paraDescEd);
            this.paraPg.Controls.Add(this.saveParaChk);
            this.paraPg.Controls.Add(this.paramGrid);
            this.paraPg.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraPg.Location = new System.Drawing.Point(4, 25);
            this.paraPg.Name = "paraPg";
            this.paraPg.Padding = new System.Windows.Forms.Padding(3);
            this.paraPg.Size = new System.Drawing.Size(401, 240);
            this.paraPg.TabIndex = 0;
            this.paraPg.Text = "Tham số";
            this.paraPg.UseVisualStyleBackColor = true;
            // 
            // paraDescEd
            // 
            this.paraDescEd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.paraDescEd.BackColor = System.Drawing.SystemColors.Control;
            this.paraDescEd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paraDescEd.Location = new System.Drawing.Point(-1, 135);
            this.paraDescEd.Multiline = true;
            this.paraDescEd.Name = "paraDescEd";
            this.paraDescEd.ReadOnly = true;
            this.paraDescEd.Size = new System.Drawing.Size(400, 46);
            this.paraDescEd.TabIndex = 3;
            // 
            // saveParaChk
            // 
            this.saveParaChk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveParaChk.AutoSize = true;
            this.saveParaChk.Checked = true;
            this.saveParaChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveParaChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveParaChk.Location = new System.Drawing.Point(11, 189);
            this.saveParaChk.Name = "saveParaChk";
            this.saveParaChk.Size = new System.Drawing.Size(107, 20);
            this.saveParaChk.TabIndex = 2;
            this.saveParaChk.Text = "Lưu tham số";
            this.saveParaChk.UseVisualStyleBackColor = true;
            // 
            // hintPg
            // 
            this.hintPg.Controls.Add(this.hintTextEd);
            this.hintPg.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintPg.Location = new System.Drawing.Point(4, 25);
            this.hintPg.Name = "hintPg";
            this.hintPg.Padding = new System.Windows.Forms.Padding(3);
            this.hintPg.Size = new System.Drawing.Size(401, 240);
            this.hintPg.TabIndex = 1;
            this.hintPg.Text = "Mô tả";
            this.hintPg.UseVisualStyleBackColor = true;
            // 
            // hintTextEd
            // 
            this.hintTextEd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hintTextEd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hintTextEd.Location = new System.Drawing.Point(-1, 2);
            this.hintTextEd.Multiline = true;
            this.hintTextEd.Name = "hintTextEd";
            this.hintTextEd.ReadOnly = true;
            this.hintTextEd.Size = new System.Drawing.Size(403, 175);
            this.hintTextEd.TabIndex = 1;
            // 
            // baseStrategyForm
            // 
            this.ClientSize = new System.Drawing.Size(404, 266);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "baseStrategyForm";
            this.Text = "Strategy parameters";
            this.myOnProcess += new common.forms.baseDialogForm.onProcess(this.baseStrategy_myOnProcess);
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.paramGrid)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.paraPg.ResumeLayout(false);
            this.paraPg.PerformLayout();
            this.hintPg.ResumeLayout(false);
            this.hintPg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseDataGridView paramGrid;
        private System.Windows.Forms.TabPage paraPg;
        private System.Windows.Forms.TabPage hintPg;
        protected System.Windows.Forms.TabControl tabControl;
        protected common.control.baseTextBox hintTextEd;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
        protected common.control.baseCheckBox saveParaChk;
        protected common.control.baseTextBox paraDescEd;

    }
}