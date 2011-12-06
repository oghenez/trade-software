namespace Tools.Forms
{
    partial class addToWatchList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addToWatchList));
            this.myDataSet = new data.baseDS();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.newWatchListBtn = new common.controls.baseButton();
            this.listNameLbl = new baseClass.controls.baseLabel();
            this.watchListCb = new baseClass.controls.cbWatchList();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(194, 64);
            this.closeBtn.Size = new System.Drawing.Size(79, 26);
            // 
            // okBtn
            // 
            this.okBtn.Image = global::Tools.Properties.Resources.adddata;
            this.okBtn.Location = new System.Drawing.Point(115, 64);
            this.okBtn.Size = new System.Drawing.Size(79, 26);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(560, 68);
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // newWatchListBtn
            // 
            this.newWatchListBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newWatchListBtn.Image = global::Tools.Properties.Resources.addNew;
            this.newWatchListBtn.isDownState = false;
            this.newWatchListBtn.Location = new System.Drawing.Point(277, 24);
            this.newWatchListBtn.Name = "newWatchListBtn";
            this.newWatchListBtn.Size = new System.Drawing.Size(25, 26);
            this.newWatchListBtn.TabIndex = 2;
            this.newWatchListBtn.UseVisualStyleBackColor = true;
            this.newWatchListBtn.Click += new System.EventHandler(this.newWatchListBtn_Click);
            // 
            // listNameLbl
            // 
            this.listNameLbl.AutoSize = true;
            this.listNameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listNameLbl.Location = new System.Drawing.Point(26, 6);
            this.listNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.listNameLbl.Name = "listNameLbl";
            this.listNameLbl.Size = new System.Drawing.Size(52, 16);
            this.listNameLbl.TabIndex = 312;
            this.listNameLbl.Text = "Add to";
            // 
            // watchListCb
            // 
            this.watchListCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.watchListCb.FormattingEnabled = true;
            this.watchListCb.Location = new System.Drawing.Point(26, 25);
            this.watchListCb.myValue = "";
            this.watchListCb.Name = "watchListCb";
            this.watchListCb.Size = new System.Drawing.Size(250, 21);
            this.watchListCb.TabIndex = 1;
            this.watchListCb.WatchType = application.AppTypes.PortfolioTypes.Portfolio;
            // 
            // addToWatchList
            // 
            this.ClientSize = new System.Drawing.Size(308, 120);
            this.Controls.Add(this.listNameLbl);
            this.Controls.Add(this.watchListCb);
            this.Controls.Add(this.newWatchListBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addToWatchList";
            this.Text = "Add to watch list";
            this.myOnProcess += new common.forms.baseDialogForm.onProcess(this.AddToWatchLish_myOnProcess);
            this.Controls.SetChildIndex(this.newWatchListBtn, 0);
            this.Controls.SetChildIndex(this.watchListCb, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.listNameLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private baseClass.controls.cbWatchList watchListCb;
        protected baseClass.controls.baseLabel listNameLbl;
        protected data.baseDS myDataSet;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        private common.controls.baseButton newWatchListBtn;
    }
}
