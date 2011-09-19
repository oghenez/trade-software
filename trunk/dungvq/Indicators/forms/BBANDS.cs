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
    public partial class BBANDS : baseIndicatorForm 
    {
        public BBANDS(Type indicatorType) : base(indicatorType)
        {
            InitializeComponent();
            upperColorEd.LoadColors();
            middleColorEd.LoadColors();
            lowerColorEd.LoadColors();
            this.upperColorEd.Color = Color.Blue;
            this.middleColorEd.Color = Color.Green;
            this.lowerColorEd.Color = Color.Red;
        }
        public override IndicatorFormInfo Info
        {
            get 
            {
                IndicatorFormInfo info = new IndicatorFormInfo();
                info.inNewWindows = inNewPaneChk.Checked;
                info.chartType = AppTypes.ChartTypes.Line;
                
                info.paras = new int[] { (int)periodEd.Value, (int)kUpEd.Value, (int)kDownEd.Value };
                info.color = new Color[] { middleColorEd.Color};
                info.weight = (byte)middleWeightEd.Value;
                return info; 
            }
            set 
            {
                inNewPaneChk.Checked = value.inNewWindows;
                periodEd.Value = value.paras[0];
                kUpEd.Value = value.paras[1];
                kDownEd.Value = value.paras[2];

                middleColorEd.Color = value.color[0];
                middleWeightEd.Value = value.weight;
            }
        }
        public override IndicatorFormInfo[] ExtraInfo
        {
            get
            {
                IndicatorFormInfo[] info = new IndicatorFormInfo[2];
                info[0] = new IndicatorFormInfo();
                info[0].chartType = AppTypes.ChartTypes.Line;
                info[0].inNewWindows = inNewPaneChk.Checked;

                info[0].paras = new int[] {};
                info[0].color = new Color[] { upperColorEd.Color };
                info[0].weight = (byte)upperWeightEd.Value;

                info[1] = new IndicatorFormInfo();
                info[1].chartType = AppTypes.ChartTypes.Line;
                info[1].inNewWindows = inNewPaneChk.Checked;

                info[1].paras = new int[] { };
                info[1].color = new Color[] { lowerColorEd.Color };
                info[1].weight = (byte)lowerWeightEd.Value;
                return info;
            }
        }

      
    }
}
