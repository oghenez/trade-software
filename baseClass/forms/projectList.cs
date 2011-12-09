﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class projectList : baseClass.forms.projectEdit
    {
        public projectList()
        {
            try
            {
                InitializeComponent();
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
            myDataSet.emProject.Clear();
            application.dataLibs.LoadData(myDataSet.emProject);
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
                projectsSource.Filter = projectCriteria.GetCriteria();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }
    }
}
