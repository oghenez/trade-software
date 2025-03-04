namespace Trade.Forms
{
    partial class portfolioWatch
    {

        //common.libs.appAvailable myAvail = new common.libs.appAvailable();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(portfolioWatch));
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectColumn = new AdvancedDataGridView.TreeGridColumn();
            this.actionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeColunm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioListSource)).BeginInit();
            this.SuspendLayout();
            // 
            // watchListCb
            // 
            this.watchListCb.Size = new System.Drawing.Size(356, 24);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(355, 1);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "tickerCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "stockExchange";
            this.dataGridViewTextBoxColumn2.HeaderText = "Sàn ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "noOpenShares";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "SL niêm yết";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // subjectColumn
            // 
            this.subjectColumn.DefaultNodeImage = null;
            this.subjectColumn.FillWeight = 8F;
            this.subjectColumn.HeaderText = "Diễn giải";
            this.subjectColumn.Name = "subjectColumn";
            this.subjectColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.subjectColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // actionColumn
            // 
            this.actionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.actionColumn.FillWeight = 1F;
            this.actionColumn.HeaderText = "";
            this.actionColumn.Name = "actionColumn";
            this.actionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.actionColumn.Width = 50;
            // 
            // timeColunm
            // 
            this.timeColunm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.timeColunm.FillWeight = 1F;
            this.timeColunm.HeaderText = "Thời gian";
            this.timeColunm.Name = "timeColunm";
            this.timeColunm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.timeColunm.Width = 170;
            // 
            // idColumn
            // 
            this.idColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idColumn.FillWeight = 1F;
            this.idColumn.HeaderText = "id";
            this.idColumn.Name = "idColumn";
            this.idColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.idColumn.Width = 50;
            // 
            // portfolioWatch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1070, 637);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "portfolioWatch";
            this.Text = "Portfolio Watch";
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioListSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private AdvancedDataGridView.TreeGridColumn subjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeColunm;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;

    }
}