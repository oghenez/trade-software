using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using application;

namespace Indicators.forms
{
    public partial class commonForm : baseIndicatorForm 
    {
        public commonForm(Meta meta) : base(meta)
        {
            InitializeComponent();
            tabControl.SendToBack();

            SetPara(meta);
        }
        protected override void CollectMetaData(Meta meta) 
        {
            int val = 0;
            int[] paras = new int[paramGrid.Rows.Count];
            for (int idx = 0; idx < paramGrid.Rows.Count; idx++)
            {
                paras[idx] = (int.TryParse(paramGrid[1, idx].Value.ToString(), out val) ? val : 0);
            }
            meta.Parameters =  paras;

            Meta.OutputInfo[] outPut = new Meta.OutputInfo[outputGrid.Rows.Count];
            for (int idx = 0; idx < outputGrid.Rows.Count; idx++)
            {
                outPut[idx] = new Meta.OutputInfo((Color)outputGrid[outColorColumn.Name, idx].Value, 
                                                   int.Parse(outputGrid[outWeightColumn.Name, idx].Value.ToString()),
                                                   (AppTypes.ChartTypes)outputGrid[outChartTypeColumn.Name, idx].Value);
            }
            meta.Output = outPut;
            meta.DrawInNewWindow = inNewPaneChk.Checked;
        }

        /// <summary>
        /// Create parametter grid from meta.ParameterDefaultValues
        /// </summary>
        /// <param name="meta"></param>
        protected void SetPara(Meta meta)
        {
            this.Text = meta.Name;
            paramGrid.Rows.Clear();
            string[] keys = meta.ParameterList.Keys;
            object[] values = meta.ParameterList.Values;
            for (int idx = 0; idx < keys.Length; idx++)
            {
                paramGrid.Rows.Add(keys[idx], values[idx]);
            }
            inNewPaneChk.Checked = meta.DrawInNewWindow; 
            keys = meta.OutputInfoList.Keys;
            values = meta.OutputInfoList.Values;
            for (int idx = 0; idx < keys.Length; idx++)
            {
                Color color = (meta.Output.Length > idx ? meta.Output[idx].Color : Color.Red);
                int weight = (meta.Output.Length > idx ? meta.Output[idx].Weight : 1);
                AppTypes.ChartTypes chartType = (meta.Output.Length > idx ? meta.Output[idx].ChartType :  AppTypes.ChartTypes.Line);
                outputGrid.Rows.Add(keys[idx], color, weight,chartType);
            }
            paraDescEd.Text = common.system.List2String(meta.ParameterDescriptions);
            hintTextEd.Text = meta.Description + common.Consts.constCRLF + meta.URL;
        }
        protected override bool BeforeAcceptProcess() 
        { 
            this.Visible = true;
            return base.BeforeAcceptProcess();
        }
        private void paramGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowError(e.Exception);
        }
    }
}
