using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using application;

namespace Strategy.forms
{
    public partial class baseStrategyForm : common.forms.baseDialogForm
    {
        private Meta myMeta = null;
        public baseStrategyForm(Meta meta)
        {
            InitializeComponent();
            SetPara(meta);
            tabControl.SendToBack();
        }
        public double[] Parameters
        {
            get 
            {
                double val = 0;
                double[] paras = new double[paramGrid.Rows.Count];
                for (int idx = 0; idx < paramGrid.Rows.Count; idx++)
                {
                    paras[idx] = (double.TryParse(paramGrid[1, idx].Value.ToString(), out val) ? val : 0);
                }
                return paras;
            }
            set 
            {
                for (int idx = 0; idx < value.Length && idx < paramGrid.Rows.Count; idx++)
                {
                    paramGrid[1, idx].Value = value[idx];
                }
            }
        }
       
        /// <summary>
        /// Create parametter grid from meta.ParameterDefaultValues
        /// </summary>
        /// <param name="meta"></param>
        protected void SetPara(Meta meta)
        {
            this.ShowMessage("");

            this.myMeta = meta;
            paramGrid.Rows.Clear();
            string[] keys = meta.ParameterList.Keys;
            object[] values = meta.ParameterList.Values;
            for (int idx = 0; idx < keys.Length; idx++)
            {
                paramGrid.Rows.Add(keys[idx],values[idx]);
            }
            paraDescEd.Text = common.system.ToString(meta.ParameterDescriptions);
            hintTextEd.Text = meta.Description + common.Consts.constCRLF + meta.URL;
        }
        protected override bool BeforeAcceptProcess() 
        { 
            this.Visible = true;
            return base.BeforeAcceptProcess();
        }

        protected virtual void SaveSettings()
        {
            this.myMeta.Parameters = this.Parameters;
            Libs.SaveUserSettings(this.myMeta);
            this.ShowMessage("Settings was saved");
        }

        private void baseStrategy_myOnProcess(object sender, common.baseDialogEvent e)
        {
            myFormStatus.acceptClose = true;
        }

        private void paramGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowError(e.Exception);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
