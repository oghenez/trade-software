using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using application;

namespace Indicators.forms
{
    public partial class StochFast : baseIndicatorForm 
    {
        public StochFast(Type indicatorType)  : base(indicatorType)
        {
            InitializeComponent();
            lineKColorEd.LoadColors();
            lineDColorEd.LoadColors();
            this.lineKColorEd.Color = Color.Blue;
            this.lineDColorEd.Color = Color.Red;
        }
        public override IndicatorFormInfo[] Info
        {
            get 
            {
                IndicatorFormInfo[] info = new IndicatorFormInfo[1];
                info[0] = new IndicatorFormInfo();
                info[0].inNewWindows = inNewPaneChk.Checked;
                info[0].chartType = AppTypes.ChartTypes.Line;
                
                info[0].paras = new int[] { (int)fastK_PeriodEd.Value, (int)fastD_PeriodEd.Value };
                info[0].color = new Color[] { lineKColorEd.Color};
                info[0].weight = (byte)lineKWeightEd.Value;
                return info; 
            }
            set 
            {
                inNewPaneChk.Checked = value[0].inNewWindows;
                fastK_PeriodEd.Value = value[0].paras[0];
                fastD_PeriodEd.Value = value[0].paras[1];

                lineKColorEd.Color = value[0].color[0];
                lineKWeightEd.Value = value[0].weight;
            }
        }
        public override IndicatorFormInfo[] ExtraInfo
        {
            get
            {
                IndicatorFormInfo[] info = new IndicatorFormInfo[1];
                info[0] = new IndicatorFormInfo();
                info[0].chartType = AppTypes.ChartTypes.Line;
                info[0].inNewWindows = inNewPaneChk.Checked;

                info[0].paras = new int[] {};
                info[0].color = new Color[] { lineDColorEd.Color };
                info[0].weight = (byte)lineDWeightEd.Value;
                return info;
            }
        }

      
    }
}
