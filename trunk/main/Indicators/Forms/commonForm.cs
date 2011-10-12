﻿using System;
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
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = language.GetString("indicator");
            paraPg.Text = language.GetString("parameter");
            hintPg.Text = language.GetString("description");
            paraLbl.Text = language.GetString("parameter");
            nameColumn.HeaderText = language.GetString("name");
            valueColumn.HeaderText = language.GetString("value");
            outNameolumn.HeaderText = language.GetString("name");
            outColorColumn.HeaderText = language.GetString("color");
            outWeightColumn.HeaderText = language.GetString("weight");
            inNewPaneChk.Text = language.GetString("inNewPane");
        }
        protected override void CollectMetaData(Meta meta) 
        {
            double val = 0;
            double[] paras = new double[paramGrid.Rows.Count];
            for (int idx = 0; idx < paramGrid.Rows.Count; idx++)
            {
                paras[idx] = (double.TryParse(paramGrid[1, idx].Value.ToString(), out val) ? val : 0);
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
            valueColumn.DefaultCellStyle.Format = "N" + meta.ParameterPrecision.ToString();

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
            paraDescEd.Text = common.system.ToString(meta.ParameterDescriptions);
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
