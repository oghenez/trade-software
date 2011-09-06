using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class companyList : companyEdit
    {
        public companyList()
        {
            try
            {
                InitializeComponent();
                findCriteria.LoadData();
                dataGrid.DisableReadOnlyColumn = false;
                this.CloseOnSave = false;
                ShowFindPanel(false);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }
        protected override bool FindData()
        {
            ShowFindPanel(true);
            return base.FindData();
        }
        protected override void LoadData()
        {
            this.ShowMessage("");
            myDataSet.stockCode.Clear();
            application.dataLibs.LoadFromSQL(myDataSet.stockCode, findCriteria.GetSQL());
        }
        
        private void ShowFindPanel(bool state)
        {
            findBtn.Enabled = !state;
            findPnl.Visible = state;
            dataGrid.Height = (state ? findPnl.Location.Y - dataGrid.Location.Y : this.Height - dataGrid.Location.Y - 2 * SystemInformation.CaptionHeight - 9);
        }
        private void closeFindBtn_Click(object sender, EventArgs e)
        {
            ShowFindPanel(false);
        }
        private void filterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                ShowReccount();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }
    }
}
