using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using commonTypes;
using commonClass;


namespace application.forms
{
    public partial class commonIndicatorForm : baseIndicatorForm 
    {
        public commonIndicatorForm(Indicators.Meta meta) : base(meta)
        {
            InitializeComponent();
            tabControl.SendToBack();

            SetPara(meta);
            //TUAN 7/24/2012 - Add Windows selection for drawing - BEGIN
            if (meta.ListWindowNames!=null)
            {
                lblWindow.Visible = true;
                cbbWindow.Visible = true;
                inNewPaneChk.Visible = false;
                if (meta.inNewWindows)
                {
                    cbbWindow.Items.Add(Languages.Libs.GetString("newPanel"));
                    cbbWindow.Items.Add(Languages.Libs.GetString("pricePanel"));
                }
                else
                {
                    cbbWindow.Items.Add(Languages.Libs.GetString("pricePanel"));
                    cbbWindow.Items.Add(Languages.Libs.GetString("newPanel"));
                }
                
                for (int i = 2; i < meta.ListWindowNames.Count; i++)
                {
                    cbbWindow.Items.Add(meta.ListWindowNames[i]);
                }
                cbbWindow.SelectedIndex = 0;                
            }
            //TUAN 7/24/2012 - Add Windows selection for drawing - END
        }
        //TUAN 9/3/2012
        public void updateFormFromMeta(Indicators.Meta _meta)
        {
            if (_meta.ListWindowNames != null)
            {
                for (int i = 2; i < _meta.ListWindowNames.Count; i++)
                {
                    cbbWindow.Items.Add(_meta.ListWindowNames[i]);
                }
                cbbWindow.SelectedIndex = 0;
            }
        }
        //TUAN 9/3/2012
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("indicator");
            paraPg.Text = Languages.Libs.GetString("parameter");
            hintPg.Text = Languages.Libs.GetString("description");
            paraLbl.Text = Languages.Libs.GetString("parameter");
            nameColumn.HeaderText = Languages.Libs.GetString("name");
            valueColumn.HeaderText = Languages.Libs.GetString("value");
            outNameolumn.HeaderText = Languages.Libs.GetString("name");
            outColorColumn.HeaderText = Languages.Libs.GetString("color");
            outWeightColumn.HeaderText = Languages.Libs.GetString("weight");
            inNewPaneChk.Text = Languages.Libs.GetString("inNewPane");
            lblWindow.Text = Languages.Libs.GetString("drawOnWindow");            
        }
        protected override void CollectMetaData(Indicators.Meta meta) 
        {
            double val = 0;
            double[] paras = new double[paramGrid.Rows.Count];
            for (int idx = 0; idx < paramGrid.Rows.Count; idx++)
            {
                paras[idx] = (double.TryParse(paramGrid[1, idx].Value.ToString(), out val) ? val : 0);
            }
            meta.Parameters =  paras;

            Indicators.Meta.OutputInfo[] outPut = new Indicators.Meta.OutputInfo[outputGrid.Rows.Count];
            for (int idx = 0; idx < outputGrid.Rows.Count; idx++)
            {
                outPut[idx] = new Indicators.Meta.OutputInfo((Color)outputGrid[outColorColumn.Name, idx].Value, 
                                                   int.Parse(outputGrid[outWeightColumn.Name, idx].Value.ToString()),
                                                   (AppTypes.ChartTypes)outputGrid[outChartTypeColumn.Name, idx].Value);
            }
            meta.Output = outPut;
            meta.DrawInNewWindow = inNewPaneChk.Checked;
            meta.SelectedWindowName =meta.ListWindowNames[cbbWindow.SelectedIndex];
        }

        /// <summary>
        /// Create parametter grid from meta.ParameterDefaultValues
        /// </summary>
        /// <param name="meta"></param>
        protected void SetPara(Indicators.Meta meta)
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
