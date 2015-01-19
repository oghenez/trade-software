using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using application.Strategy;

namespace application.forms
{
    public partial class baseStrategyForm : common.forms.baseDialogForm
    {
        private StrategyMeta myMeta = null;
        public baseStrategyForm(StrategyMeta meta)
        {
            InitializeComponent();
            SetPara(meta);
            tabControl.SendToBack();
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("strategy");
            paraPg.Text = Languages.Libs.GetString("parameter");
            hintPg.Text = Languages.Libs.GetString("description");
            nameColumn.HeaderText = Languages.Libs.GetString("name");
            valueColumn.HeaderText = Languages.Libs.GetString("value");
            saveBtn.Text = Languages.Libs.GetString("saveSetting");            
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
        protected void SetPara(StrategyMeta meta)
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
            valueColumn.DefaultCellStyle.Format = "N" + meta.ParameterPrecision.ToString();
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
            StrategyLibs.SaveUserSettings(this.myMeta);
            this.ShowMessage(Languages.Libs.GetString("settingSaved"));
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
