namespace client.forms
{
    partial class investorEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(investorEdit));
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchListSource)).BeginInit();
            this.infoPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLbl
            // 
            this.nameLbl.Size = new System.Drawing.Size(75, 16);
            this.nameLbl.Text = "First Name";
            // 
            // lastNameEd
            // 
            this.lastNameEd.ReadOnly = true;
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.Size = new System.Drawing.Size(75, 16);
            this.lastNameLbl.Text = "Last Name";
            // 
            // address1Lbl
            // 
            this.address1Lbl.Size = new System.Drawing.Size(74, 16);
            this.address1Lbl.Text = "Address 1";
            // 
            // accountEd
            // 
            this.accountEd.ReadOnly = true;
            // 
            // passwordLbl
            // 
            this.passwordLbl.Size = new System.Drawing.Size(71, 16);
            this.passwordLbl.Text = "Password";
            // 
            // statusLbl
            // 
            this.statusLbl.Location = new System.Drawing.Point(688, 318);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.statusLbl.Size = new System.Drawing.Size(51, 16);
            this.statusLbl.Text = "Status";
            this.statusLbl.Visible = false;
            // 
            // investorCatLbl
            // 
            this.investorCatLbl.Location = new System.Drawing.Point(688, 359);
            this.investorCatLbl.Size = new System.Drawing.Size(68, 16);
            this.investorCatLbl.Text = "Category";
            this.investorCatLbl.Visible = false;
            // 
            // expireDateEd
            // 
            this.expireDateEd.Location = new System.Drawing.Point(688, 295);
            this.expireDateEd.Margin = new System.Windows.Forms.Padding(3);
            this.expireDateEd.Size = new System.Drawing.Size(99, 20);
            this.expireDateEd.Visible = false;
            // 
            // expireDateLbl
            // 
            this.expireDateLbl.Location = new System.Drawing.Point(688, 274);
            this.expireDateLbl.Size = new System.Drawing.Size(90, 16);
            this.expireDateLbl.Text = "Expired Date";
            this.expireDateLbl.Visible = false;
            // 
            // investorCatCb
            // 
            this.investorCatCb.Location = new System.Drawing.Point(688, 384);
            this.investorCatCb.Margin = new System.Windows.Forms.Padding(2);
            this.investorCatCb.Visible = false;
            // 
            // statusCb
            // 
            this.statusCb.Location = new System.Drawing.Point(688, 337);
            this.statusCb.Visible = false;
            // 
            // displayNameEd
            // 
            this.displayNameEd.Size = new System.Drawing.Size(251, 20);
            // 
            // noteLbl
            // 
            this.noteLbl.Location = new System.Drawing.Point(24, 440);
            // 
            // noteEd
            // 
            this.noteEd.Location = new System.Drawing.Point(24, 459);
            this.noteEd.Size = new System.Drawing.Size(483, 139);
            // 
            // displayNameLbl
            // 
            this.displayNameLbl.Text = "Display Name";
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(428, 6);
            this.exitBtn.Size = new System.Drawing.Size(131, 38);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(35, 6);
            this.saveBtn.Size = new System.Drawing.Size(131, 38);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(583, 3);
            this.deleteBtn.Size = new System.Drawing.Size(106, 38);
            this.deleteBtn.Visible = false;
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(297, 6);
            this.editBtn.Size = new System.Drawing.Size(131, 38);
            this.editBtn.Text = "Lock";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Enabled = false;
            this.addNewBtn.Location = new System.Drawing.Point(706, 5);
            this.addNewBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addNewBtn.Size = new System.Drawing.Size(81, 39);
            this.addNewBtn.Visible = false;
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(868, 5);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(166, 6);
            this.findBtn.Size = new System.Drawing.Size(131, 38);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(625, 5);
            this.reloadBtn.Size = new System.Drawing.Size(81, 39);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(787, 5);
            // 
            // importBtn
            // 
            this.importBtn.Location = new System.Drawing.Point(949, 5);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1060, 9);
            this.TitleLbl.Size = new System.Drawing.Size(249, 24);
            // 
            // investorEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(530, 677);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "investorEdit";
            ((System.ComponentModel.ISupportInitialize)(this.portfolioSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchListSource)).EndInit();
            this.infoPnl.ResumeLayout(false);
            this.infoPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investorSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
