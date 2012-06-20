namespace baseClass.forms
{
    partial class companyEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(companyEdit));
            this.xpPanelGroup_Info = new UIComponents.XPPanelGroup();
            this.xpPanel_OtherInfo = new UIComponents.XPPanel(202);
            this.companyOtherInfo = new baseClass.controls.companyOtherInfo();
            this.xpPanel_StockInfo = new UIComponents.XPPanel(181);
            this.companyStock = new baseClass.controls.companyStockInfo();
            this.xpPanel_GeneralInfo = new UIComponents.XPPanel(358);
            this.companyGeneral = new baseClass.controls.companyGeneralInfo();
            this.stockCodeSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).BeginInit();
            this.xpPanelGroup_Info.SuspendLayout();
            this.xpPanel_OtherInfo.SuspendLayout();
            this.xpPanel_StockInfo.SuspendLayout();
            this.xpPanel_GeneralInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBox
            // 
            this.toolBox.Size = new System.Drawing.Size(503, 53);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(416, 7);
            this.exitBtn.Size = new System.Drawing.Size(83, 39);
            this.exitBtn.Text = "Close";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(84, 7);
            this.saveBtn.Size = new System.Drawing.Size(83, 39);
            this.saveBtn.Text = "Save";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(167, 7);
            this.deleteBtn.Size = new System.Drawing.Size(83, 39);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(250, 7);
            this.editBtn.Size = new System.Drawing.Size(83, 39);
            this.editBtn.Text = "Lock";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(1, 7);
            this.addNewBtn.Size = new System.Drawing.Size(83, 39);
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(875, 7);
            this.toExcelBtn.Text = "Export";
            this.toExcelBtn.Visible = false;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(665, 7);
            this.findBtn.Visible = false;
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(333, 7);
            this.reloadBtn.Size = new System.Drawing.Size(83, 39);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(805, 7);
            this.printBtn.Text = "&Print";
            this.printBtn.Visible = false;
            // 
            // xpPanelGroup_Info
            // 
            this.xpPanelGroup_Info.AutoScroll = true;
            this.xpPanelGroup_Info.BackColor = System.Drawing.Color.Transparent;
            this.xpPanelGroup_Info.BorderMargin = new System.Drawing.Size(0, 0);
            this.xpPanelGroup_Info.Controls.Add(this.xpPanel_OtherInfo);
            this.xpPanelGroup_Info.Controls.Add(this.xpPanel_StockInfo);
            this.xpPanelGroup_Info.Controls.Add(this.xpPanel_GeneralInfo);
            this.xpPanelGroup_Info.Location = new System.Drawing.Point(1, 45);
            this.xpPanelGroup_Info.Name = "xpPanelGroup_Info";
            this.xpPanelGroup_Info.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpPanelGroup_Info.PanelGradient")));
            this.xpPanelGroup_Info.PanelSpacing = 0;
            this.xpPanelGroup_Info.Size = new System.Drawing.Size(500, 665);
            this.xpPanelGroup_Info.TabIndex = 146;
            // 
            // xpPanel_OtherInfo
            // 
            this.xpPanel_OtherInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_OtherInfo.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_OtherInfo.Caption = "Others";
            this.xpPanel_OtherInfo.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_OtherInfo.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_OtherInfo.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_OtherInfo.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_OtherInfo.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_OtherInfo.Controls.Add(this.companyOtherInfo);
            this.xpPanel_OtherInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_OtherInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_OtherInfo.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_OtherInfo.ImageItems.ImageSet = null;
            this.xpPanel_OtherInfo.Location = new System.Drawing.Point(0, 539);
            this.xpPanel_OtherInfo.Name = "xpPanel_OtherInfo";
            this.xpPanel_OtherInfo.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_OtherInfo.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_OtherInfo.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_OtherInfo.Size = new System.Drawing.Size(482, 202);
            this.xpPanel_OtherInfo.Spacing = new System.Drawing.Point(0, 0);
            this.xpPanel_OtherInfo.TabIndex = 2;
            this.xpPanel_OtherInfo.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_OtherInfo.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_OtherInfo.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_OtherInfo.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // companyOtherInfo
            // 
            this.companyOtherInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.companyOtherInfo.Location = new System.Drawing.Point(30, 30);
            this.companyOtherInfo.Name = "companyOtherInfo";
            this.companyOtherInfo.Size = new System.Drawing.Size(453, 155);
            this.companyOtherInfo.TabIndex = 0;
            // 
            // xpPanel_StockInfo
            // 
            this.xpPanel_StockInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_StockInfo.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_StockInfo.Caption = "Stock";
            this.xpPanel_StockInfo.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_StockInfo.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_StockInfo.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_StockInfo.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_StockInfo.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_StockInfo.Controls.Add(this.companyStock);
            this.xpPanel_StockInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_StockInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_StockInfo.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_StockInfo.ImageItems.ImageSet = null;
            this.xpPanel_StockInfo.Location = new System.Drawing.Point(0, 358);
            this.xpPanel_StockInfo.Name = "xpPanel_StockInfo";
            this.xpPanel_StockInfo.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_StockInfo.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_StockInfo.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_StockInfo.Size = new System.Drawing.Size(482, 181);
            this.xpPanel_StockInfo.Spacing = new System.Drawing.Point(0, 0);
            this.xpPanel_StockInfo.TabIndex = 1;
            this.xpPanel_StockInfo.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_StockInfo.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_StockInfo.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_StockInfo.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // companyStock
            // 
            this.companyStock.Location = new System.Drawing.Point(30, 27);
            this.companyStock.Margin = new System.Windows.Forms.Padding(2);
            this.companyStock.Name = "companyStock";
            this.companyStock.Size = new System.Drawing.Size(443, 143);
            this.companyStock.TabIndex = 0;
            // 
            // xpPanel_GeneralInfo
            // 
            this.xpPanel_GeneralInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_GeneralInfo.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_GeneralInfo.Caption = "General Info";
            this.xpPanel_GeneralInfo.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_GeneralInfo.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_GeneralInfo.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_GeneralInfo.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_GeneralInfo.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_GeneralInfo.Controls.Add(this.companyGeneral);
            this.xpPanel_GeneralInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_GeneralInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_GeneralInfo.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_GeneralInfo.ImageItems.ImageSet = null;
            this.xpPanel_GeneralInfo.Location = new System.Drawing.Point(0, 0);
            this.xpPanel_GeneralInfo.Name = "xpPanel_GeneralInfo";
            this.xpPanel_GeneralInfo.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_GeneralInfo.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_GeneralInfo.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_GeneralInfo.Size = new System.Drawing.Size(482, 358);
            this.xpPanel_GeneralInfo.Spacing = new System.Drawing.Point(0, 0);
            this.xpPanel_GeneralInfo.TabIndex = 0;
            this.xpPanel_GeneralInfo.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_GeneralInfo.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_GeneralInfo.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_GeneralInfo.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // companyGeneral
            // 
            this.companyGeneral.Location = new System.Drawing.Point(30, 29);
            this.companyGeneral.Name = "companyGeneral";
            this.companyGeneral.Size = new System.Drawing.Size(440, 317);
            this.companyGeneral.TabIndex = 0;
            // 
            // stockCodeSource
            // 
            this.stockCodeSource.DataMember = "stockCode";
            this.stockCodeSource.DataSource = this.myDataSet;
            // 
            // companyEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(499, 735);
            this.Controls.Add(this.xpPanelGroup_Info);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "companyEdit";
            this.Text = "Company";
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.xpPanelGroup_Info, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpPanelGroup_Info)).EndInit();
            this.xpPanelGroup_Info.ResumeLayout(false);
            this.xpPanel_OtherInfo.ResumeLayout(false);
            this.xpPanel_StockInfo.ResumeLayout(false);
            this.xpPanel_GeneralInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected UIComponents.XPPanelGroup xpPanelGroup_Info;
        protected UIComponents.XPPanel xpPanel_OtherInfo;
        protected baseClass.controls.companyOtherInfo companyOtherInfo;
        protected UIComponents.XPPanel xpPanel_StockInfo;
        protected baseClass.controls.companyStockInfo companyStock;
        protected UIComponents.XPPanel xpPanel_GeneralInfo;
        protected baseClass.controls.companyGeneralInfo companyGeneral;
        protected System.Windows.Forms.BindingSource stockCodeSource;



    }
}