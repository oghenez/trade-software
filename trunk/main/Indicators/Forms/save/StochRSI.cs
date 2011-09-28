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
    public partial class StochRSI : baseIndicatorForm 
    {
        public StochRSI(Meta meta) : base(meta)
        {
            InitializeComponent();
            lineKColorEd.LoadColors();
            lineDColorEd.LoadColors();
            this.lineKColorEd.Color = Color.Blue;
            this.lineDColorEd.Color = Color.Red;
        }
        public override IndicatorFormInfo Info
        {
            get 
            {
                IndicatorFormInfo info = new IndicatorFormInfo();
                info = new IndicatorFormInfo();
                info.inNewWindows = inNewPaneChk.Checked;
                info.chartType = AppTypes.ChartTypes.Line;
                
                info.paras = new int[] { (int)rsiPeriodEd.Value, (int)fastK_PeriodEd.Value, (int)fastD_PeriodEd.Value };
                info.color = new Color[] { lineKColorEd.Color};
                info.weight = (byte)lineKWeightEd.Value;
                return info; 
            }
            set 
            {
                inNewPaneChk.Checked = value.inNewWindows;
                rsiPeriodEd.Value = value.paras[0];
                fastK_PeriodEd.Value = value.paras[1];
                fastD_PeriodEd.Value = value.paras[2];

                lineKColorEd.Color = value.color[0];
                lineKWeightEd.Value = value.weight;
            }
        }
        public override IndicatorFormInfo[] ExtraInfo
        {
            get
            {
                IndicatorFormInfo[] info = new IndicatorFormInfo[1];
                info[0] = new IndicatorFormInfo();
                info[0] = new IndicatorFormInfo();
                info[0].inNewWindows = inNewPaneChk.Checked;

                info[0].paras = new int[] { };
                info[0].color = new Color[] { lineDColorEd.Color };
                info[0].weight = (byte)lineDWeightEd.Value;
                return info;
            }
        }

      
    }
}
