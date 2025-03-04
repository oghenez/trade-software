namespace common.forms
{
    partial class baseMasterDetailForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseMasterDetailForm));
            this.detailGrid = new common.controls.baseDataGridView();
            this.editKeyLbl = new System.Windows.Forms.Label();
            this.toolBarGroup = new System.Windows.Forms.GroupBox();
            this.printDetailBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.addNewBtn = new System.Windows.Forms.Button();
            this.addLineBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.FindBtn = new System.Windows.Forms.Button();
            this.deleteLineBtn = new System.Windows.Forms.Button();
            this.subTotalEd = new System.Windows.Forms.MaskedTextBox();
            this.subTotalLbl = new System.Windows.Forms.Label();
            this.editKeyEd = new System.Windows.Forms.MaskedTextBox();
            this.myMenuStrip = new System.Windows.Forms.MenuStrip();
            this.dataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.findMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.printMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addLineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteLineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.pasteToGridMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.lockEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAfterSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoVoucherNoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printOptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printOnSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Print2PageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.printerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myPrintDialog = new System.Windows.Forms.PrintDialog();
            this.copyPanel = new System.Windows.Forms.Panel();
            this.copyTitleLbl = new System.Windows.Forms.Label();
            this.copyAppendModeChk = new System.Windows.Forms.CheckBox();
            this.copyFindBtn = new System.Windows.Forms.Button();
            this.copyExitBtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.copyLabel = new System.Windows.Forms.Label();
            this.copyEditKeyNoEd = new System.Windows.Forms.TextBox();
            this.myMasterNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.printPnl = new System.Windows.Forms.Panel();
            this.cbPrintDetailType = new System.Windows.Forms.ComboBox();
            this.printCloseBtn = new System.Windows.Forms.Button();
            this.doPrintDetailBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).BeginInit();
            this.toolBarGroup.SuspendLayout();
            this.myMenuStrip.SuspendLayout();
            this.copyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myMasterNavigator)).BeginInit();
            this.myMasterNavigator.SuspendLayout();
            this.printPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(0, 29);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.TitleLbl.Size = new System.Drawing.Size(836, 37);
            this.TitleLbl.Text = "TIÊU ĐỀ";
            // 
            // detailGrid
            // 
            this.detailGrid.ColumnHeadersHeight = 25;
            this.detailGrid.Location = new System.Drawing.Point(0, 241);
            this.detailGrid.Margin = new System.Windows.Forms.Padding(0);
            this.detailGrid.Name = "detailGrid";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.detailGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.detailGrid.RowHeadersWidth = 40;
            this.detailGrid.RowTemplate.Height = 25;
            this.detailGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detailGrid.Size = new System.Drawing.Size(808, 200);
            this.detailGrid.TabIndex = 40;
            this.detailGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailGrid_CellValueChanged);
            this.detailGrid.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.detailGrid_ColumnHeaderMouseDoubleClick);
            this.detailGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailGrid_RowEnter);
            this.detailGrid.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.detailGrid_RowValidating);
            this.detailGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailGrid_CellContentDoubleClick);
            this.detailGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailGrid_CellClick);
            this.detailGrid.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.detailGrid_DefaultValuesNeeded);
            this.detailGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.detailGrid_DataError);
            this.detailGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailGrid_CellEnter);
            this.detailGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailGrid_CellContentClick);
            // 
            // editKeyLbl
            // 
            this.editKeyLbl.AutoSize = true;
            this.editKeyLbl.Location = new System.Drawing.Point(26, 66);
            this.editKeyLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editKeyLbl.Name = "editKeyLbl";
            this.editKeyLbl.Size = new System.Drawing.Size(76, 18);
            this.editKeyLbl.TabIndex = 103;
            this.editKeyLbl.Text = "Số phiếu *";
            // 
            // toolBarGroup
            // 
            this.toolBarGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolBarGroup.Controls.Add(this.printDetailBtn);
            this.toolBarGroup.Controls.Add(this.printBtn);
            this.toolBarGroup.Controls.Add(this.addNewBtn);
            this.toolBarGroup.Controls.Add(this.addLineBtn);
            this.toolBarGroup.Controls.Add(this.exitBtn);
            this.toolBarGroup.Controls.Add(this.saveBtn);
            this.toolBarGroup.Controls.Add(this.deleteBtn);
            this.toolBarGroup.Controls.Add(this.FindBtn);
            this.toolBarGroup.Controls.Add(this.deleteLineBtn);
            this.toolBarGroup.Location = new System.Drawing.Point(-15, 547);
            this.toolBarGroup.Margin = new System.Windows.Forms.Padding(2);
            this.toolBarGroup.Name = "toolBarGroup";
            this.toolBarGroup.Padding = new System.Windows.Forms.Padding(2);
            this.toolBarGroup.Size = new System.Drawing.Size(1083, 61);
            this.toolBarGroup.TabIndex = 41;
            this.toolBarGroup.TabStop = false;
            // 
            // printDetailBtn
            // 
            this.printDetailBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printDetailBtn.Image = global::common.Properties.Resources.properties;
            this.printDetailBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.printDetailBtn.Location = new System.Drawing.Point(937, 12);
            this.printDetailBtn.Margin = new System.Windows.Forms.Padding(4);
            this.printDetailBtn.Name = "printDetailBtn";
            this.printDetailBtn.Size = new System.Drawing.Size(90, 44);
            this.printDetailBtn.TabIndex = 62;
            this.printDetailBtn.TabStop = false;
            this.printDetailBtn.Text = "Chi tiết";
            this.printDetailBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.printDetailBtn.Visible = false;
            this.printDetailBtn.Click += new System.EventHandler(this.printDetailBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtn.Image = global::common.Properties.Resources.print;
            this.printBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.printBtn.Location = new System.Drawing.Point(642, 12);
            this.printBtn.Margin = new System.Windows.Forms.Padding(4);
            this.printBtn.Name = "printBtn";
            this.printBtn.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.printBtn.Size = new System.Drawing.Size(105, 45);
            this.printBtn.TabIndex = 57;
            this.printBtn.TabStop = false;
            this.printBtn.Text = "&In";
            this.printBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewBtn.ForeColor = System.Drawing.SystemColors.InfoText;
            this.addNewBtn.Image = global::common.Properties.Resources.addNew;
            this.addNewBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.addNewBtn.Location = new System.Drawing.Point(119, 12);
            this.addNewBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addNewBtn.Name = "addNewBtn";
            this.addNewBtn.Size = new System.Drawing.Size(105, 45);
            this.addNewBtn.TabIndex = 51;
            this.addNewBtn.Text = "&Mới";
            this.addNewBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addNewBtn.UseVisualStyleBackColor = true;
            this.addNewBtn.Click += new System.EventHandler(this.addNewBtn_Click);
            // 
            // addLineBtn
            // 
            this.addLineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLineBtn.Image = global::common.Properties.Resources.addLine;
            this.addLineBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.addLineBtn.Location = new System.Drawing.Point(433, 12);
            this.addLineBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addLineBtn.Name = "addLineBtn";
            this.addLineBtn.Size = new System.Drawing.Size(105, 45);
            this.addLineBtn.TabIndex = 54;
            this.addLineBtn.Text = "&Thêm";
            this.addLineBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addLineBtn.UseVisualStyleBackColor = true;
            this.addLineBtn.Click += new System.EventHandler(this.addLineBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Image = global::common.Properties.Resources.close;
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.exitBtn.Location = new System.Drawing.Point(747, 12);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(105, 45);
            this.exitBtn.TabIndex = 60;
            this.exitBtn.Text = "Th&oát";
            this.exitBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = global::common.Properties.Resources.save;
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveBtn.Location = new System.Drawing.Point(15, 12);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(105, 45);
            this.saveBtn.TabIndex = 50;
            this.saveBtn.Text = "&Lưu";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Image = global::common.Properties.Resources.delete;
            this.deleteBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteBtn.Location = new System.Drawing.Point(328, 12);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(105, 45);
            this.deleteBtn.TabIndex = 52;
            this.deleteBtn.Text = "&Hủy";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // FindBtn
            // 
            this.FindBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindBtn.Image = global::common.Properties.Resources.find;
            this.FindBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.FindBtn.Location = new System.Drawing.Point(224, 12);
            this.FindBtn.Margin = new System.Windows.Forms.Padding(4);
            this.FindBtn.Name = "FindBtn";
            this.FindBtn.Size = new System.Drawing.Size(105, 45);
            this.FindBtn.TabIndex = 53;
            this.FindBtn.TabStop = false;
            this.FindBtn.Text = "Tìm";
            this.FindBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.FindBtn.UseVisualStyleBackColor = true;
            this.FindBtn.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // deleteLineBtn
            // 
            this.deleteLineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteLineBtn.Image = global::common.Properties.Resources.deleteLine;
            this.deleteLineBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteLineBtn.Location = new System.Drawing.Point(538, 12);
            this.deleteLineBtn.Margin = new System.Windows.Forms.Padding(4);
            this.deleteLineBtn.Name = "deleteLineBtn";
            this.deleteLineBtn.Size = new System.Drawing.Size(105, 45);
            this.deleteLineBtn.TabIndex = 55;
            this.deleteLineBtn.Text = "&Xóa";
            this.deleteLineBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deleteLineBtn.UseVisualStyleBackColor = true;
            this.deleteLineBtn.Click += new System.EventHandler(this.deleteLineBtn_Click);
            // 
            // subTotalEd
            // 
            this.subTotalEd.BackColor = System.Drawing.SystemColors.Info;
            this.subTotalEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTotalEd.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.subTotalEd.Location = new System.Drawing.Point(678, 525);
            this.subTotalEd.Margin = new System.Windows.Forms.Padding(4);
            this.subTotalEd.Name = "subTotalEd";
            this.subTotalEd.ReadOnly = true;
            this.subTotalEd.Size = new System.Drawing.Size(138, 22);
            this.subTotalEd.TabIndex = 156;
            this.subTotalEd.TabStop = false;
            this.subTotalEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // subTotalLbl
            // 
            this.subTotalLbl.AutoSize = true;
            this.subTotalLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTotalLbl.Location = new System.Drawing.Point(631, 529);
            this.subTotalLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.subTotalLbl.Name = "subTotalLbl";
            this.subTotalLbl.Size = new System.Drawing.Size(40, 16);
            this.subTotalLbl.TabIndex = 155;
            this.subTotalLbl.Text = "Cộng";
            // 
            // editKeyEd
            // 
            this.editKeyEd.Location = new System.Drawing.Point(29, 88);
            this.editKeyEd.Name = "editKeyEd";
            this.editKeyEd.Size = new System.Drawing.Size(112, 24);
            this.editKeyEd.TabIndex = 22;
            this.editKeyEd.Tag = "[Số phiếu]";
            this.editKeyEd.Validating += new System.ComponentModel.CancelEventHandler(this.editKeyEd_Validating);
            // 
            // myMenuStrip
            // 
            this.myMenuStrip.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.myMenuStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.myMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataMenuItem,
            this.editMenuItem,
            this.optionMenuItem,
            this.exitMenuItem});
            this.myMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.myMenuStrip.Name = "myMenuStrip";
            this.myMenuStrip.Size = new System.Drawing.Size(838, 24);
            this.myMenuStrip.TabIndex = 180;
            // 
            // dataMenuItem
            // 
            this.dataMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewMenuItem,
            this.toolStripSeparator1,
            this.saveMenuItem,
            this.toolStripSeparator6,
            this.deleteMenuItem,
            this.toolStripSeparator7,
            this.findMenuItem,
            this.toolStripSeparator4,
            this.printMenuItem});
            this.dataMenuItem.Name = "dataMenuItem";
            this.dataMenuItem.Size = new System.Drawing.Size(61, 20);
            this.dataMenuItem.Text = "Số liệu";
            // 
            // addNewMenuItem
            // 
            this.addNewMenuItem.Name = "addNewMenuItem";
            this.addNewMenuItem.Size = new System.Drawing.Size(140, 22);
            this.addNewMenuItem.Text = "Thêm &mới";
            this.addNewMenuItem.Click += new System.EventHandler(this.addNewBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveMenuItem.Text = "&Lưu phiếu";
            this.saveMenuItem.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(137, 6);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(140, 22);
            this.deleteMenuItem.Text = "&Hủy phiếu";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(137, 6);
            // 
            // findMenuItem
            // 
            this.findMenuItem.Name = "findMenuItem";
            this.findMenuItem.Size = new System.Drawing.Size(140, 22);
            this.findMenuItem.Text = "Tìm &kiếm";
            this.findMenuItem.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(137, 6);
            // 
            // printMenuItem
            // 
            this.printMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.printMenuItem.Name = "printMenuItem";
            this.printMenuItem.Size = new System.Drawing.Size(140, 22);
            this.printMenuItem.Text = "&In phiếu";
            this.printMenuItem.Click += new System.EventHandler(this.printMenuItem_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyLineMenuItem,
            this.copyDataMenuItem,
            this.toolStripSeparator2,
            this.addLineMenuItem,
            this.toolStripSeparator5,
            this.deleteLineMenuItem,
            this.toolStripSeparator8,
            this.pasteToGridMenuItem,
            this.toolStripSeparator9,
            this.lockEditMenuItem});
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(69, 20);
            this.editMenuItem.Text = "Biên tập";
            // 
            // copyLineMenuItem
            // 
            this.copyLineMenuItem.Name = "copyLineMenuItem";
            this.copyLineMenuItem.Size = new System.Drawing.Size(230, 22);
            this.copyLineMenuItem.Text = "Sao chép &dòng";
            this.copyLineMenuItem.Click += new System.EventHandler(this.copyLineMenuItem_Click);
            // 
            // copyDataMenuItem
            // 
            this.copyDataMenuItem.Name = "copyDataMenuItem";
            this.copyDataMenuItem.Size = new System.Drawing.Size(230, 22);
            this.copyDataMenuItem.Text = "Sao &chép phiếu";
            this.copyDataMenuItem.Click += new System.EventHandler(this.copyDataMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(227, 6);
            // 
            // addLineMenuItem
            // 
            this.addLineMenuItem.Name = "addLineMenuItem";
            this.addLineMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.addLineMenuItem.Size = new System.Drawing.Size(230, 22);
            this.addLineMenuItem.Text = "&Thêm dòng";
            this.addLineMenuItem.Click += new System.EventHandler(this.addLineBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(227, 6);
            // 
            // deleteLineMenuItem
            // 
            this.deleteLineMenuItem.Name = "deleteLineMenuItem";
            this.deleteLineMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.deleteLineMenuItem.Size = new System.Drawing.Size(230, 22);
            this.deleteLineMenuItem.Text = "&Xóa dòng";
            this.deleteLineMenuItem.Click += new System.EventHandler(this.deleteLineBtn_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(227, 6);
            // 
            // pasteToGridMenuItem
            // 
            this.pasteToGridMenuItem.Name = "pasteToGridMenuItem";
            this.pasteToGridMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.P)));
            this.pasteToGridMenuItem.Size = new System.Drawing.Size(230, 22);
            this.pasteToGridMenuItem.Text = "Dán vào lưới";
            this.pasteToGridMenuItem.Click += new System.EventHandler(this.pasteToGridMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(227, 6);
            // 
            // lockEditMenuItem
            // 
            this.lockEditMenuItem.Checked = true;
            this.lockEditMenuItem.CheckOnClick = true;
            this.lockEditMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lockEditMenuItem.Name = "lockEditMenuItem";
            this.lockEditMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.lockEditMenuItem.Size = new System.Drawing.Size(230, 22);
            this.lockEditMenuItem.Text = "Khóa dữ liệu";
            this.lockEditMenuItem.Click += new System.EventHandler(this.lockEditMenuItem_Click);
            // 
            // optionMenuItem
            // 
            this.optionMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAfterSaveMenuItem,
            this.autoVoucherNoMenuItem,
            this.printOptionsMenuItem});
            this.optionMenuItem.Name = "optionMenuItem";
            this.optionMenuItem.Size = new System.Drawing.Size(72, 20);
            this.optionMenuItem.Text = "Tùy biến";
            // 
            // newAfterSaveMenuItem
            // 
            this.newAfterSaveMenuItem.CheckOnClick = true;
            this.newAfterSaveMenuItem.Name = "newAfterSaveMenuItem";
            this.newAfterSaveMenuItem.Size = new System.Drawing.Size(183, 22);
            this.newAfterSaveMenuItem.Text = "Thêm mới  khi lưu";
            // 
            // autoVoucherNoMenuItem
            // 
            this.autoVoucherNoMenuItem.CheckOnClick = true;
            this.autoVoucherNoMenuItem.Name = "autoVoucherNoMenuItem";
            this.autoVoucherNoMenuItem.Size = new System.Drawing.Size(183, 22);
            this.autoVoucherNoMenuItem.Text = "Số phiếu tự động";
            // 
            // printOptionsMenuItem
            // 
            this.printOptionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printOnSaveMenuItem,
            this.printPreviewMenuItem,
            this.Print2PageMenuItem,
            this.toolStripSeparator3,
            this.printerMenuItem});
            this.printOptionsMenuItem.Name = "printOptionsMenuItem";
            this.printOptionsMenuItem.Size = new System.Drawing.Size(183, 22);
            this.printOptionsMenuItem.Text = "In ấn";
            // 
            // printOnSaveMenuItem
            // 
            this.printOnSaveMenuItem.CheckOnClick = true;
            this.printOnSaveMenuItem.Name = "printOnSaveMenuItem";
            this.printOnSaveMenuItem.Size = new System.Drawing.Size(159, 22);
            this.printOnSaveMenuItem.Text = "In khi lưu";
            // 
            // printPreviewMenuItem
            // 
            this.printPreviewMenuItem.Checked = true;
            this.printPreviewMenuItem.CheckOnClick = true;
            this.printPreviewMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.printPreviewMenuItem.Name = "printPreviewMenuItem";
            this.printPreviewMenuItem.Size = new System.Drawing.Size(159, 22);
            this.printPreviewMenuItem.Text = "Xem trước";
            // 
            // Print2PageMenuItem
            // 
            this.Print2PageMenuItem.CheckOnClick = true;
            this.Print2PageMenuItem.Name = "Print2PageMenuItem";
            this.Print2PageMenuItem.Size = new System.Drawing.Size(159, 22);
            this.Print2PageMenuItem.Text = "In 2 bản trang";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // printerMenuItem
            // 
            this.printerMenuItem.Name = "printerMenuItem";
            this.printerMenuItem.Size = new System.Drawing.Size(159, 22);
            this.printerMenuItem.Text = "Chọn máy in";
            this.printerMenuItem.Click += new System.EventHandler(this.printerMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(66, 20);
            this.exitMenuItem.Text = "Kết thúc";
            this.exitMenuItem.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // myPrintDialog
            // 
            this.myPrintDialog.AllowPrintToFile = false;
            this.myPrintDialog.AllowSomePages = true;
            // 
            // copyPanel
            // 
            this.copyPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.copyPanel.Controls.Add(this.copyTitleLbl);
            this.copyPanel.Controls.Add(this.copyAppendModeChk);
            this.copyPanel.Controls.Add(this.copyFindBtn);
            this.copyPanel.Controls.Add(this.copyExitBtn);
            this.copyPanel.Controls.Add(this.copyBtn);
            this.copyPanel.Controls.Add(this.copyLabel);
            this.copyPanel.Controls.Add(this.copyEditKeyNoEd);
            this.copyPanel.Location = new System.Drawing.Point(43, 205);
            this.copyPanel.Name = "copyPanel";
            this.copyPanel.Size = new System.Drawing.Size(248, 157);
            this.copyPanel.TabIndex = 181;
            this.copyPanel.Visible = false;
            // 
            // copyTitleLbl
            // 
            this.copyTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyTitleLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.copyTitleLbl.Location = new System.Drawing.Point(4, 3);
            this.copyTitleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.copyTitleLbl.Name = "copyTitleLbl";
            this.copyTitleLbl.Size = new System.Drawing.Size(242, 26);
            this.copyTitleLbl.TabIndex = 303;
            this.copyTitleLbl.Text = "SAO CHÉP DỮ LIỆU";
            this.copyTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // copyAppendModeChk
            // 
            this.copyAppendModeChk.AutoSize = true;
            this.copyAppendModeChk.Location = new System.Drawing.Point(48, 81);
            this.copyAppendModeChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.copyAppendModeChk.Name = "copyAppendModeChk";
            this.copyAppendModeChk.Size = new System.Drawing.Size(100, 22);
            this.copyAppendModeChk.TabIndex = 2;
            this.copyAppendModeChk.TabStop = false;
            this.copyAppendModeChk.Text = "Cộng thêm";
            this.myToolTip.SetToolTip(this.copyAppendModeChk, "Chi tiết sử dụng cùng [Đon vị] ");
            this.copyAppendModeChk.UseVisualStyleBackColor = true;
            // 
            // copyFindBtn
            // 
            this.copyFindBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyFindBtn.Image = global::common.Properties.Resources.find;
            this.copyFindBtn.Location = new System.Drawing.Point(176, 53);
            this.copyFindBtn.Margin = new System.Windows.Forms.Padding(0);
            this.copyFindBtn.Name = "copyFindBtn";
            this.copyFindBtn.Size = new System.Drawing.Size(28, 25);
            this.copyFindBtn.TabIndex = 179;
            this.copyFindBtn.TabStop = false;
            this.copyFindBtn.Click += new System.EventHandler(this.copyFindBtn_Click);
            // 
            // copyExitBtn
            // 
            this.copyExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyExitBtn.Location = new System.Drawing.Point(143, 114);
            this.copyExitBtn.Name = "copyExitBtn";
            this.copyExitBtn.Size = new System.Drawing.Size(71, 29);
            this.copyExitBtn.TabIndex = 302;
            this.copyExitBtn.Text = "Đóng";
            this.copyExitBtn.UseVisualStyleBackColor = true;
            this.copyExitBtn.Click += new System.EventHandler(this.copyExitBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyBtn.Location = new System.Drawing.Point(46, 114);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(93, 29);
            this.copyBtn.TabIndex = 301;
            this.copyBtn.Text = "Sao chép";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // copyLabel
            // 
            this.copyLabel.AutoSize = true;
            this.copyLabel.Location = new System.Drawing.Point(45, 32);
            this.copyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.copyLabel.Name = "copyLabel";
            this.copyLabel.Size = new System.Drawing.Size(60, 18);
            this.copyLabel.TabIndex = 104;
            this.copyLabel.Text = "Từ số  *";
            // 
            // copyEditKeyNoEd
            // 
            this.copyEditKeyNoEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyEditKeyNoEd.Location = new System.Drawing.Point(48, 53);
            this.copyEditKeyNoEd.Name = "copyEditKeyNoEd";
            this.copyEditKeyNoEd.Size = new System.Drawing.Size(128, 24);
            this.copyEditKeyNoEd.TabIndex = 300;
            // 
            // myMasterNavigator
            // 
            this.myMasterNavigator.AddNewItem = null;
            this.myMasterNavigator.CountItem = this.bindingNavigatorCountItem;
            this.myMasterNavigator.CountItemFormat = "{0}";
            this.myMasterNavigator.DeleteItem = null;
            this.myMasterNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.myMasterNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.myMasterNavigator.Location = new System.Drawing.Point(10, 502);
            this.myMasterNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.myMasterNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.myMasterNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.myMasterNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.myMasterNavigator.Name = "myMasterNavigator";
            this.myMasterNavigator.Padding = new System.Windows.Forms.Padding(1);
            this.myMasterNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.myMasterNavigator.Size = new System.Drawing.Size(200, 25);
            this.myMasterNavigator.TabIndex = 182;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 20);
            this.bindingNavigatorCountItem.Text = "{0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 23);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(56, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            this.bindingNavigatorPositionItem.Leave += new System.EventHandler(this.bindingNavigatorPositionItem_Leave);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // printPnl
            // 
            this.printPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.printPnl.Controls.Add(this.cbPrintDetailType);
            this.printPnl.Controls.Add(this.printCloseBtn);
            this.printPnl.Controls.Add(this.doPrintDetailBtn);
            this.printPnl.Location = new System.Drawing.Point(852, 430);
            this.printPnl.Name = "printPnl";
            this.printPnl.Size = new System.Drawing.Size(238, 67);
            this.printPnl.TabIndex = 221;
            this.printPnl.Visible = false;
            // 
            // cbPrintDetailType
            // 
            this.cbPrintDetailType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrintDetailType.DropDownWidth = 2;
            this.cbPrintDetailType.FormattingEnabled = true;
            this.cbPrintDetailType.Location = new System.Drawing.Point(17, 6);
            this.cbPrintDetailType.Name = "cbPrintDetailType";
            this.cbPrintDetailType.Size = new System.Drawing.Size(201, 26);
            this.cbPrintDetailType.TabIndex = 1;
            // 
            // printCloseBtn
            // 
            this.printCloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printCloseBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.printCloseBtn.Location = new System.Drawing.Point(154, 35);
            this.printCloseBtn.Name = "printCloseBtn";
            this.printCloseBtn.Size = new System.Drawing.Size(63, 27);
            this.printCloseBtn.TabIndex = 12;
            this.printCloseBtn.Text = "Đóng";
            this.printCloseBtn.UseVisualStyleBackColor = true;
            this.printCloseBtn.Click += new System.EventHandler(this.printCloseBtn_Click);
            // 
            // doPrintDetailBtn
            // 
            this.doPrintDetailBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doPrintDetailBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.doPrintDetailBtn.Location = new System.Drawing.Point(96, 35);
            this.doPrintDetailBtn.Name = "doPrintDetailBtn";
            this.doPrintDetailBtn.Size = new System.Drawing.Size(53, 27);
            this.doPrintDetailBtn.TabIndex = 11;
            this.doPrintDetailBtn.Text = "In";
            this.doPrintDetailBtn.UseVisualStyleBackColor = true;
            this.doPrintDetailBtn.Click += new System.EventHandler(this.doPrintDetailBtn_Click);
            // 
            // baseMasterDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 633);
            this.Controls.Add(this.printPnl);
            this.Controls.Add(this.myMasterNavigator);
            this.Controls.Add(this.copyPanel);
            this.Controls.Add(this.myMenuStrip);
            this.Controls.Add(this.editKeyEd);
            this.Controls.Add(this.subTotalEd);
            this.Controls.Add(this.subTotalLbl);
            this.Controls.Add(this.editKeyLbl);
            this.Controls.Add(this.toolBarGroup);
            this.Controls.Add(this.detailGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "baseMasterDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Load += new System.EventHandler(this.whenForm_Load);
            this.Shown += new System.EventHandler(this.baseMasterDetailForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.whenForm_FormClosing);
            this.Controls.SetChildIndex(this.detailGrid, 0);
            this.Controls.SetChildIndex(this.toolBarGroup, 0);
            this.Controls.SetChildIndex(this.editKeyLbl, 0);
            this.Controls.SetChildIndex(this.subTotalLbl, 0);
            this.Controls.SetChildIndex(this.subTotalEd, 0);
            this.Controls.SetChildIndex(this.editKeyEd, 0);
            this.Controls.SetChildIndex(this.myMenuStrip, 0);
            this.Controls.SetChildIndex(this.copyPanel, 0);
            this.Controls.SetChildIndex(this.myMasterNavigator, 0);
            this.Controls.SetChildIndex(this.printPnl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).EndInit();
            this.toolBarGroup.ResumeLayout(false);
            this.myMenuStrip.ResumeLayout(false);
            this.myMenuStrip.PerformLayout();
            this.copyPanel.ResumeLayout(false);
            this.copyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myMasterNavigator)).EndInit();
            this.myMasterNavigator.ResumeLayout(false);
            this.myMasterNavigator.PerformLayout();
            this.printPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label editKeyLbl;
        protected System.Windows.Forms.MaskedTextBox subTotalEd;
        protected System.Windows.Forms.GroupBox toolBarGroup;
        protected System.Windows.Forms.Button exitBtn;
        protected System.Windows.Forms.Button saveBtn;
        protected System.Windows.Forms.Button deleteBtn;
        protected System.Windows.Forms.Button addLineBtn;
        protected System.Windows.Forms.Button deleteLineBtn;
        protected System.Windows.Forms.Button FindBtn;
        protected System.Windows.Forms.Button addNewBtn;
        protected System.Windows.Forms.Label subTotalLbl;
        protected common.controls.baseDataGridView detailGrid;
        protected System.Windows.Forms.MaskedTextBox editKeyEd;
        private System.Windows.Forms.ToolStripMenuItem dataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem findMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem printMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLineMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyDataMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addLineMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem deleteLineMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAfterSaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoVoucherNoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printOptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        protected System.Windows.Forms.PrintDialog myPrintDialog;
        protected System.Windows.Forms.CheckBox copyAppendModeChk;
        protected System.Windows.Forms.Button copyFindBtn;
        protected System.Windows.Forms.Label copyLabel;
        protected System.Windows.Forms.Panel copyPanel;
        protected System.Windows.Forms.Button copyExitBtn;
        protected System.Windows.Forms.Button copyBtn;
        protected System.Windows.Forms.TextBox copyEditKeyNoEd;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        protected System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        protected System.Windows.Forms.BindingNavigator myMasterNavigator;
        protected System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem printerMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem printOnSaveMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem printPreviewMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem Print2PageMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem lockEditMenuItem;
        protected System.Windows.Forms.MenuStrip myMenuStrip;
        protected System.Windows.Forms.Label copyTitleLbl;
        protected System.Windows.Forms.Panel printPnl;
        protected System.Windows.Forms.ComboBox cbPrintDetailType;
        protected System.Windows.Forms.Button printCloseBtn;
        protected System.Windows.Forms.Button doPrintDetailBtn;
        protected System.Windows.Forms.Button printDetailBtn;
        private System.Windows.Forms.ToolStripMenuItem pasteToGridMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
    }
}