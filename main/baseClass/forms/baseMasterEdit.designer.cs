namespace baseClass.forms
{
    partial class baseMasterEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseMasterEdit));
            this.myDataSet = new data.baseDS();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-2, -7);
            this.toolBox.Size = new System.Drawing.Size(1167, 53);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(564, 7);
            this.exitBtn.Size = new System.Drawing.Size(70, 39);
            this.exitBtn.Text = "&Close";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(74, 7);
            this.saveBtn.Size = new System.Drawing.Size(70, 39);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "&Save";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(144, 7);
            this.deleteBtn.Size = new System.Drawing.Size(70, 39);
            this.deleteBtn.Text = "&Delete";
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(214, 7);
            this.editBtn.Size = new System.Drawing.Size(70, 39);
            this.editBtn.Text = "Edit";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(4, 7);
            this.addNewBtn.Size = new System.Drawing.Size(70, 39);
            this.addNewBtn.TabIndex = 1;
            this.addNewBtn.Text = "&New";
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(494, 7);
            this.toExcelBtn.Size = new System.Drawing.Size(70, 39);
            this.toExcelBtn.Text = "E&xport";
            this.toExcelBtn.Visible = true;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(284, 7);
            this.findBtn.Margin = new System.Windows.Forms.Padding(0);
            this.findBtn.Size = new System.Drawing.Size(70, 39);
            this.findBtn.Text = "&Find";
            this.findBtn.Visible = true;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(354, 7);
            this.reloadBtn.Size = new System.Drawing.Size(70, 39);
            this.reloadBtn.TabIndex = 6;
            this.reloadBtn.Text = "Re&load";
            this.reloadBtn.Visible = true;
            // 
            // printBtn
            // 
            this.printBtn.Enabled = false;
            this.printBtn.Location = new System.Drawing.Point(424, 7);
            this.printBtn.Size = new System.Drawing.Size(70, 39);
            this.printBtn.TabIndex = 7;
            this.printBtn.Text = "Print";
            this.printBtn.Visible = true;
            // 
            // lockBtn
            // 
            this.lockBtn.Image = global::baseClass.Properties.Resources.lock1;
            this.lockBtn.Size = new System.Drawing.Size(30, 26);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(784, 9);
            this.TitleLbl.Size = new System.Drawing.Size(116, 24);
            this.TitleLbl.Visible = false;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // baseMasterEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(634, 521);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "baseMasterEdit";
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected data.baseDS myDataSet;
    }
}

