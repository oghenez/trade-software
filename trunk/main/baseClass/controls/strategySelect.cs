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
    public partial class strategySelect : common.controls.baseUserControl
    {
        public strategySelect()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            selectAllChk.Text = language.GetString("selectAll");
            strategyCatCb.SetLanguage();
            strategyClb.SetLanguage();
        }
        public StringCollection myCheckedValues
        {
            get { return strategyClb.myCheckedValues; }
            set { strategyClb.myCheckedValues = value; }
        }
        public string myItemString
        {
            get { return strategyClb.myItemString; }
            set { strategyClb.myItemString = value; }
        }
        public int maxLen
        {
            set { strategyClb.maxLen = value; }
        }
        public void CheckAll(bool state)
        {
            strategyClb.CheckAll(state);
        }
        public virtual void LoadData(application.AppTypes.StrategyTypes type,bool onlyEnableItem,bool checkAll)
        {
            this.strategyClb.LoadData(type);
            this.strategyCatCb.LoadData(true);
        }
        public virtual void DataBining(BindingSource source, string fldName)
        {
            this.strategyClb.DataBindings.Clear();
            this.strategyClb.DataBindings.Add(new System.Windows.Forms.Binding("myItemString", source, fldName, true));
        }
        public virtual void LockEdit(bool state)
        {
            this.Enabled = !state;
            this.strategyClb.Enabled = !state;
            this.selectAllChk.Enabled = !state;
        }

        private void form_Resize(object sender, EventArgs e)
        {
            try
            {
                strategyCatCb.Width = this.Width;
                selectAllChk.Location = new Point(0, this.Height - selectAllChk.Height);

                strategyClb.Location = new Point(0, strategyCatCb.Height);
                strategyClb.Size = new Size(this.Width, selectAllChk.Location.Y - strategyCatCb.Location.Y - strategyCatCb.Height);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }
        private void selectAllChk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                strategyClb.CheckAll(selectAllChk.Checked);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }
        private void strategyCatCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (strategyCatCb.IsAllValueSelected()) strategyClb.SetFilter(null);
                else strategyClb.SetFilter(strategyCatCb.myValue);
                if (selectAllChk.Checked) strategyClb.CheckAll(selectAllChk.Checked);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }
    }
}
