using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace common.forms
{
	public partial class baseForm: Form
	{
        private reports.reportViewerForm _reportViewer = null;
        protected reports.reportViewerForm reportViewer
        {
            get
            {
                if (_reportViewer == null) _reportViewer = new reports.reportViewerForm();
                return _reportViewer;
            }
        }
        protected bool fFormClosing = false;
		public baseForm()
		{
			InitializeComponent();
		}

        private System.Windows.Forms.ErrorProvider myErrNotifier = new ErrorProvider();
        public void NotifyError(Control lbl) { myErrNotifier.SetError(lbl, lbl.Text); }
        public void ClearNotifyError()
        {
            myErrNotifier.Clear();
        }

        public void SetTitle(string title1, string title2)
        {
            TitleLbl.Text = title1;
            this.Text = title2;
        }

        public void SetStatusWidth(int w)
        {
            this.statusLbl.Size = new Size(w,this.statusLbl.Height);  
        }

        protected virtual void ShowStatus(string msg)
        {
            statusLbl.Text = msg;
        }

        protected virtual void ErrorHander(Exception er)
        {
            ShowMessage(er.Message, "");
            common.sysLibs.WriteError(er);
        }
        protected virtual void ShowMessage(string msg)
        {
            ShowMessage(msg, "");
        }

        protected virtual void ShowMessage(string msg, string statusMsg)
        {
            this.messageLbl.Text = msg; this.statusLbl.Text = statusMsg;
            this.myStatusStrip.Refresh();
            return;
        }
        protected virtual void QuitApplication()
        {
            if (common.sysLibs.sysIsDesignMode) this.Close();
            else sysLibs.ExitApplication();
        }

        //Make Enter key works as Tabkey
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            string name = this.ActiveControl.GetType().Name.ToUpper().Trim();
            //Make ENTER key work as TAB key for all controls except BUTTON
            if ((common.settings.sysEnterSameAsTabKey && (msg.WParam.ToInt32() == (int)Keys.Enter) &&
                (this.ActiveControl != null) &&
                (name != "BUTTON") && (!name.StartsWith("RICHTEXT"))))
            {
                SendKeys.Send("{Tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void myStatusStrip_MouseHover(object sender, EventArgs e)
        {
            messageLbl.ToolTipText = this.messageLbl.Text.ToString();
        }

        private void baseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fFormClosing = true;
        }
	}
}