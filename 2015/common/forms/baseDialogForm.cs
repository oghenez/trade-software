using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace common.forms
{
    public partial class baseDialogForm : common.forms.baseForm
    {
        private bool okBtnSelected=false;
        public baseDialogForm()
        {
            InitializeComponent();
            this.myStatusStrip.Visible = false;
        }
        public bool ShowForm()
        {
            this.BringToFront();
            this.ShowDialog();
            return okBtnSelected;
        }

        protected virtual bool BeforeAcceptProcess() { return true; }
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (!BeforeAcceptProcess()) return;
            okBtnSelected = true;
            this.Hide();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            okBtnSelected = false;
            this.Hide();
        }

    }
}

