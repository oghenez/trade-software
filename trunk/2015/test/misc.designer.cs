namespace test
{
    partial class misc
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
            this.findBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.codeEd = new common.controls.baseTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.myTimer = new System.Windows.Forms.Timer(this.components);
            this.stockSource = new System.Windows.Forms.BindingSource(this.components);
            this.tmpDS1 = new databases.tmpDS();
            this.baseTextBox1 = new common.controls.baseTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stockSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1024, 48);
            this.TitleLbl.Size = new System.Drawing.Size(34, 46);
            // 
            // findBtn
            // 
            this.findBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.findBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.findBtn.Location = new System.Drawing.Point(33, 51);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(53, 26);
            this.findBtn.TabIndex = 256;
            this.findBtn.Text = "Find";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.addBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBtn.Location = new System.Drawing.Point(86, 51);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(53, 26);
            this.addBtn.TabIndex = 257;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            // 
            // codeEd
            // 
            this.codeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEd.isRequired = true;
            this.codeEd.isToUpperCase = true;
            this.codeEd.Location = new System.Drawing.Point(33, 16);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(546, 29);
            this.codeEd.TabIndex = 3;
            this.codeEd.Text = "A00000004/ChartSettings";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(32, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 26);
            this.button1.TabIndex = 258;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Test_click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(32, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 26);
            this.button2.TabIndex = 259;
            this.button2.Text = "Timer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // myTimer
            // 
            this.myTimer.Enabled = true;
            this.myTimer.Interval = 1000;
            this.myTimer.Tick += new System.EventHandler(this.myTimer_Tick);
            // 
            // stockSource
            // 
            this.stockSource.DataMember = "stockCode";
            this.stockSource.DataSource = this.tmpDS1;
            // 
            // tmpDS1
            // 
            this.tmpDS1.DataSetName = "tmpDS";
            this.tmpDS1.EnforceConstraints = false;
            this.tmpDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // baseTextBox1
            // 
            this.baseTextBox1.Enabled = false;
            this.baseTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseTextBox1.isRequired = true;
            this.baseTextBox1.isToUpperCase = true;
            this.baseTextBox1.Location = new System.Drawing.Point(32, 165);
            this.baseTextBox1.Name = "baseTextBox1";
            this.baseTextBox1.Size = new System.Drawing.Size(105, 29);
            this.baseTextBox1.TabIndex = 261;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.price});
            this.dataGridView1.DataSource = this.stockSource;
            this.dataGridView1.Location = new System.Drawing.Point(172, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(511, 462);
            this.dataGridView1.TabIndex = 262;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // test
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(683, 538);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.baseTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.codeEd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "test";
            this.Text = "test";
            this.Controls.SetChildIndex(this.codeEd, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.findBtn, 0);
            this.Controls.SetChildIndex(this.addBtn, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.baseTextBox1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.stockSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private common.controls.baseTextBox codeEd;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        protected System.Windows.Forms.Timer myTimer;
        private System.Windows.Forms.BindingSource stockSource;
        private databases.tmpDS tmpDS1;
        private common.controls.baseTextBox baseTextBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
    }
}