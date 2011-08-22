namespace baseClass.controls
{
    partial class strategySelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(strategySelect));
            this.strategyCatCb = new baseClass.controls.cbStrategyCat();
            this.strategyClb = new baseClass.controls.clbStrategy();
            this.selectAllChk = new baseClass.controls.baseCheckBox();
            this.SuspendLayout();
            // 
            // strategyCatCb
            // 
            this.strategyCatCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.strategyCatCb.FormattingEnabled = true;
            this.strategyCatCb.Location = new System.Drawing.Point(0, 0);
            this.strategyCatCb.myValue = "";
            this.strategyCatCb.Name = "strategyCatCb";
            this.strategyCatCb.Size = new System.Drawing.Size(415, 24);
            this.strategyCatCb.TabIndex = 1;
            this.strategyCatCb.SelectedIndexChanged += new System.EventHandler(this.strategyCatCb_SelectedIndexChanged);
            // 
            // strategyClb
            // 
            this.strategyClb.CheckOnClick = true;
            this.strategyClb.FormattingEnabled = true;
            this.strategyClb.Location = new System.Drawing.Point(0, 25);
            this.strategyClb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("strategyClb.myCheckedItems")));
            this.strategyClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("strategyClb.myCheckedValues")));
            this.strategyClb.myItemString = "";
            this.strategyClb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("strategyClb.myItemValues")));
            this.strategyClb.Name = "strategyClb";
            this.strategyClb.ShowCheckedOnly = false;
            this.strategyClb.Size = new System.Drawing.Size(412, 148);
            this.strategyClb.TabIndex = 10;
            // 
            // selectAllChk
            // 
            this.selectAllChk.AutoSize = true;
            this.selectAllChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllChk.Location = new System.Drawing.Point(3, 177);
            this.selectAllChk.Name = "selectAllChk";
            this.selectAllChk.Size = new System.Drawing.Size(102, 20);
            this.selectAllChk.TabIndex = 20;
            this.selectAllChk.Text = "Chọn tất cả";
            this.selectAllChk.UseVisualStyleBackColor = true;
            this.selectAllChk.CheckedChanged += new System.EventHandler(this.selectAllChk_CheckedChanged);
            // 
            // strategySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectAllChk);
            this.Controls.Add(this.strategyClb);
            this.Controls.Add(this.strategyCatCb);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "strategySelect";
            this.Size = new System.Drawing.Size(416, 199);
            this.Resize += new System.EventHandler(this.form_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private cbStrategyCat strategyCatCb;
        protected clbStrategy strategyClb;
        protected baseCheckBox selectAllChk;
    }
}
