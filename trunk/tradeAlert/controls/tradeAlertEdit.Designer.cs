namespace tradeAlert.controls
{
    partial class tradeAlertEdit
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
            this.onTimeEd = new common.control.baseDate();
            this.onTimeLbl = new common.control.baseLabel();
            this.statusLbl = new common.control.baseLabel();
            this.subjectLbl = new common.control.baseLabel();
            this.subjectEd = new common.control.baseTextBox();
            this.portpolioLbl = new common.control.baseLabel();
            this.strategyLbl = new common.control.baseLabel();
            this.messageLbl = new common.control.baseLabel();
            this.messageEd = new common.control.baseTextBox();
            this.codeLbl = new common.control.baseLabel();
            this.codeEd = new common.control.baseTextBox();
            this.statusCb = new baseClass.controls.cbTradeAlertStatus();
            this.strategyCb = new baseClass.controls.cbStrategy();
            this.portpolioCb = new baseClass.controls.cbPorpolio();
            this.actionLbl = new common.control.baseLabel();
            this.actionCb = new baseClass.controls.cbTradeAction();
            this.SuspendLayout();
            // 
            // onTimeEd
            // 
            this.onTimeEd.BeepOnError = true;
            this.onTimeEd.Enabled = false;
            this.onTimeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onTimeEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.onTimeEd.Location = new System.Drawing.Point(1, 26);
            this.onTimeEd.Mask = "00/00/0000 90:00";
            this.onTimeEd.myDateTime = new System.DateTime(((long)(0)));
            this.onTimeEd.Name = "onTimeEd";
            this.onTimeEd.Size = new System.Drawing.Size(145, 24);
            this.onTimeEd.TabIndex = 0;
            this.onTimeEd.ValidatingType = typeof(System.DateTime);
            // 
            // onTimeLbl
            // 
            this.onTimeLbl.AutoSize = true;
            this.onTimeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onTimeLbl.Location = new System.Drawing.Point(1, 5);
            this.onTimeLbl.Name = "onTimeLbl";
            this.onTimeLbl.Size = new System.Drawing.Size(65, 16);
            this.onTimeLbl.TabIndex = 1;
            this.onTimeLbl.Text = "Thời gian";
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(133, 228);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(74, 16);
            this.statusLbl.TabIndex = 3;
            this.statusLbl.Text = "Tình trạng";
            // 
            // subjectLbl
            // 
            this.subjectLbl.AutoSize = true;
            this.subjectLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectLbl.Location = new System.Drawing.Point(1, 54);
            this.subjectLbl.Name = "subjectLbl";
            this.subjectLbl.Size = new System.Drawing.Size(54, 16);
            this.subjectLbl.TabIndex = 5;
            this.subjectLbl.Text = "Tiêu đề";
            // 
            // subjectEd
            // 
            this.subjectEd.Enabled = false;
            this.subjectEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectEd.Location = new System.Drawing.Point(1, 75);
            this.subjectEd.Name = "subjectEd";
            this.subjectEd.Size = new System.Drawing.Size(393, 24);
            this.subjectEd.TabIndex = 10;
            // 
            // portpolioLbl
            // 
            this.portpolioLbl.AutoSize = true;
            this.portpolioLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portpolioLbl.Location = new System.Drawing.Point(1, 278);
            this.portpolioLbl.Name = "portpolioLbl";
            this.portpolioLbl.Size = new System.Drawing.Size(66, 16);
            this.portpolioLbl.TabIndex = 7;
            this.portpolioLbl.Text = "Portpolio";
            // 
            // strategyLbl
            // 
            this.strategyLbl.AutoSize = true;
            this.strategyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyLbl.Location = new System.Drawing.Point(2, 331);
            this.strategyLbl.Name = "strategyLbl";
            this.strategyLbl.Size = new System.Drawing.Size(74, 16);
            this.strategyLbl.TabIndex = 9;
            this.strategyLbl.Text = "Chiến lược";
            // 
            // messageLbl
            // 
            this.messageLbl.AutoSize = true;
            this.messageLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLbl.Location = new System.Drawing.Point(1, 104);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(63, 16);
            this.messageLbl.TabIndex = 11;
            this.messageLbl.Text = "Nội dung";
            // 
            // messageEd
            // 
            this.messageEd.Enabled = false;
            this.messageEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageEd.Location = new System.Drawing.Point(1, 125);
            this.messageEd.Multiline = true;
            this.messageEd.Name = "messageEd";
            this.messageEd.Size = new System.Drawing.Size(393, 96);
            this.messageEd.TabIndex = 20;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(147, 7);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(46, 16);
            this.codeLbl.TabIndex = 15;
            this.codeLbl.Text = "Mã số";
            // 
            // codeEd
            // 
            this.codeEd.Enabled = false;
            this.codeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEd.Location = new System.Drawing.Point(146, 26);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(145, 24);
            this.codeEd.TabIndex = 2;
            // 
            // statusCb
            // 
            this.statusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.statusCb.Enabled = false;
            this.statusCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCb.FormattingEnabled = true;
            this.statusCb.Location = new System.Drawing.Point(129, 247);
            this.statusCb.myValue = application.myTypes.commonStatus.None;
            this.statusCb.Name = "statusCb";
            this.statusCb.SelectedValue = ((byte)(0));
            this.statusCb.Size = new System.Drawing.Size(127, 26);
            this.statusCb.TabIndex = 31;
            // 
            // strategyCb
            // 
            this.strategyCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.strategyCb.Enabled = false;
            this.strategyCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyCb.Location = new System.Drawing.Point(1, 351);
            this.strategyCb.myValue = "";
            this.strategyCb.Name = "strategyCb";
            this.strategyCb.Size = new System.Drawing.Size(393, 26);
            this.strategyCb.TabIndex = 41;
            // 
            // portpolioCb
            // 
            this.portpolioCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.portpolioCb.Enabled = false;
            this.portpolioCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portpolioCb.Location = new System.Drawing.Point(1, 299);
            this.portpolioCb.myValue = "";
            this.portpolioCb.Name = "portpolioCb";
            this.portpolioCb.Size = new System.Drawing.Size(393, 26);
            this.portpolioCb.TabIndex = 40;
            // 
            // actionLbl
            // 
            this.actionLbl.AutoSize = true;
            this.actionLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionLbl.Location = new System.Drawing.Point(1, 227);
            this.actionLbl.Name = "actionLbl";
            this.actionLbl.Size = new System.Drawing.Size(65, 16);
            this.actionLbl.TabIndex = 31;
            this.actionLbl.Text = "Giao dịch";
            // 
            // actionCb
            // 
            this.actionCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.actionCb.Enabled = false;
            this.actionCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionCb.Location = new System.Drawing.Point(2, 247);
            this.actionCb.myValue = application.analysis.tradeActions.None;
            this.actionCb.Name = "actionCb";
            this.actionCb.SelectedValue = ((byte)(0));
            this.actionCb.Size = new System.Drawing.Size(127, 26);
            this.actionCb.TabIndex = 30;
            // 
            // tradeAlertEdit
            // 
            this.Controls.Add(this.actionLbl);
            this.Controls.Add(this.statusCb);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.codeEd);
            this.Controls.Add(this.messageLbl);
            this.Controls.Add(this.messageEd);
            this.Controls.Add(this.strategyLbl);
            this.Controls.Add(this.strategyCb);
            this.Controls.Add(this.portpolioLbl);
            this.Controls.Add(this.portpolioCb);
            this.Controls.Add(this.subjectLbl);
            this.Controls.Add(this.subjectEd);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.onTimeLbl);
            this.Controls.Add(this.onTimeEd);
            this.Controls.Add(this.actionCb);
            this.Name = "tradeAlertEdit";
            this.Size = new System.Drawing.Size(394, 380);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseDate onTimeEd;
        protected common.control.baseLabel onTimeLbl;
        protected common.control.baseLabel statusLbl;
        protected common.control.baseLabel subjectLbl;
        protected common.control.baseTextBox subjectEd;
        protected common.control.baseLabel portpolioLbl;
        protected baseClass.controls.cbPorpolio portpolioCb;
        protected common.control.baseLabel strategyLbl;
        protected baseClass.controls.cbStrategy strategyCb;
        protected common.control.baseLabel messageLbl;
        protected common.control.baseTextBox messageEd;
        protected common.control.baseLabel codeLbl;
        protected common.control.baseTextBox codeEd;
        protected baseClass.controls.cbTradeAlertStatus statusCb;
        protected common.control.baseLabel actionLbl;
        protected baseClass.controls.cbTradeAction actionCb;

    }
}
