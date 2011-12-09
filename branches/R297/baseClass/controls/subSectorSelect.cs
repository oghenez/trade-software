using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace baseClass.controls
{
    public partial class subSectorSelect : common.controls.baseUserControl
    {
        public subSectorSelect()
        {
            try
            {
                InitializeComponent();
                bizSectorTypesSelection.LoadData();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }            
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            bizSectorTypesSelection.SetLanguage();
            subSectorListClb.SetLanguage();
            showOnlyCheckedChk.Text = language.GetString("onlySelected");
            selectAllChk.Text = language.GetString("selectAll");
        }

        public StringCollection myCheckedValues
        {
            get { return subSectorListClb.myCheckedValues;}
            set { subSectorListClb.myCheckedValues = value;}
        }
        public string myItemString
        {
            get { return subSectorListClb.myItemString; }
            set { subSectorListClb.myItemString = value; }
        }
        public int maxLen
        {
            set { subSectorListClb.maxLen = value; }
        }
        public void CheckAll(bool state)
        {
            subSectorListClb.CheckAll(state);
        }
        public bool ShowCheckedOnly
        {
            get
            {
                return this.subSectorListClb.ShowCheckedOnly;
            }
            set
            {
                this.subSectorListClb.ShowCheckedOnly = value;
            }
        }
        public virtual void LoadData()
        {
            this.subSectorListClb.LoadData();
        }
        public virtual void DataBining(BindingSource source,string fldName)
        {
            this.subSectorListClb.DataBindings.Clear();
            this.subSectorListClb.DataBindings.Add(new System.Windows.Forms.Binding("myItemString", source, fldName, true));
        }
        public virtual void LockEdit(bool state)
        {
            this.Enabled = !state;
            this.subSectorListClb.Enabled = !state;
            showOnlyCheckedChk.Enabled = !state;
            bizSectorTypesSelection.LockEdit(state);
        }

        private void showOnlyCheckedChk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.subSectorListClb.ShowCheckedOnly = showOnlyCheckedChk.Checked;
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }            
        }
        private void form_Resize(object sender, EventArgs e)
        {
            try
            {
                bizSectorTypesSelection.Width = this.Width;

                showOnlyCheckedChk.Location = new Point(0, this.Height - showOnlyCheckedChk.Height);
                selectAllChk.Location = new Point(showOnlyCheckedChk.Width+10, showOnlyCheckedChk.Location.Y);

                subSectorListClb.Location = new Point(0, bizSectorTypesSelection.Height);
                subSectorListClb.Size = new Size(this.Width, selectAllChk.Location.Y - subSectorListClb.Location.Y);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }
        private void BizSectorTypesSelection_mySectorSelectionChange(object sender, EventArgs e)
        {
            try
            {
                subSectorListClb.myItemValues = bizSectorTypesSelection.myCurrentSubSectorCodes;
                showOnlyCheckedChk.Checked = false;
                selectAllChk.Checked = false;
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }       
        }

        private void selectAllChk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                subSectorListClb.CheckAll(selectAllChk.Checked);
                if (selectAllChk.Checked)
                    subSectorListClb.ShowCheckedOnly = subSectorListClb.ShowCheckedOnly;
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }         
        }
    }
}
