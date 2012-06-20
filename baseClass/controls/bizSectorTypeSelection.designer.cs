﻿namespace baseClass.controls
{
    partial class BizSectorTypesSelection
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
            this.bizSectorCb = new common.controls.baseComboBox();
            this.bizSectorTypesCb = new baseClass.controls.cbBizSectorType();
            this.SuspendLayout();
            // 
            // bizSectorCb
            // 
            this.bizSectorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bizSectorCb.FormattingEnabled = true;
            this.bizSectorCb.Location = new System.Drawing.Point(175, 0);
            this.bizSectorCb.myValue = "";
            this.bizSectorCb.Name = "bizSectorCb";
            this.bizSectorCb.Size = new System.Drawing.Size(257, 21);
            this.bizSectorCb.TabIndex = 2;
            this.bizSectorCb.SelectionChangeCommitted += new System.EventHandler(this.bizSectorCb_SelectionChangeCommitted);
            // 
            // bizSectorTypesCb
            // 
            this.bizSectorTypesCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bizSectorTypesCb.FormattingEnabled = true;
            this.bizSectorTypesCb.Location = new System.Drawing.Point(0, 0);
            this.bizSectorTypesCb.myValue = commonTypes.AppTypes.BizSectorTypes.None;
            this.bizSectorTypesCb.Name = "bizSectorTypesCb";
            this.bizSectorTypesCb.SelectedValue = ((byte)(0));
            this.bizSectorTypesCb.Size = new System.Drawing.Size(175, 21);
            this.bizSectorTypesCb.TabIndex = 1;
            this.bizSectorTypesCb.SelectionChangeCommitted += new System.EventHandler(this.bizSectorTypesCb_SelectionChangeCommitted);
            // 
            // BizSectorTypesSelection
            // 
            this.Controls.Add(this.bizSectorCb);
            this.Controls.Add(this.bizSectorTypesCb);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BizSectorTypesSelection";
            this.Size = new System.Drawing.Size(430, 22);
            this.Resize += new System.EventHandler(this.form_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private cbBizSectorType bizSectorTypesCb;
        private common.controls.baseComboBox bizSectorCb;
    }
}
