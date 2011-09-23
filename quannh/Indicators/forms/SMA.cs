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
    public partial class SMA : baseIndicatorForm 
    {
        public SMA(Type indicatorType) : base(indicatorType)
        {
            InitializeComponent();
            colorEd1.LoadColors();
            colorEd2.LoadColors();
            this.colorEd1.Color = Color.Blue;
            this.colorEd2.Color = Color.Red;
        }
        public override IndicatorFormInfo[] Info
        {
            get 
            {
                IndicatorFormInfo[] info = new IndicatorFormInfo[2];
                info[0] = new IndicatorFormInfo();
                info[0].chartType = AppTypes.ChartTypes.Line;
                info[0].paras = new int[] { (int)paraEd1.Value };
                info[0].color = new Color[] { colorEd1.Color};
                info[0].weight = (byte)weightEd1.Value;
                info[0].inNewWindows = inNewPaneChk.Checked;

                info[1] = new IndicatorFormInfo();
                info[1].chartType = AppTypes.ChartTypes.Line;
                info[1].paras = new int[] { (int)paraEd2.Value };
                info[1].color = new Color[] { colorEd2.Color };
                info[1].weight = (byte)weightEd2.Value;
                info[1].inNewWindows = inNewPaneChk.Checked;

                return info; 
            }
            set 
            {
                inNewPaneChk.Checked = value[0].inNewWindows;

                paraEd1.Value = value[0].paras[0];
                colorEd1.Color = value[0].color[0];
                weightEd1.Value = value[0].weight;

                paraEd2.Value = value[1].paras[0];
                colorEd2.Color = value[1].color[0];
                weightEd2.Value = value[1].weight;
            }
        }
    }
}
