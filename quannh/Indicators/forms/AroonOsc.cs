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
    public partial class AroonOsc : baseIndicatorForm
    {
        public AroonOsc(Type indicatorType)
            : base(indicatorType)
        {
            InitializeComponent();
            aroonoscColorEd.LoadColors();
            this.aroonoscColorEd.Color = Color.Blue;
        }
        public override IndicatorFormInfo[] Info
        {
            get
            {
                IndicatorFormInfo[] info = new IndicatorFormInfo[1];
                info[0] = new IndicatorFormInfo();
                info[0].inNewWindows = inNewPaneChk.Checked;
                info[0].chartType = AppTypes.ChartTypes.Line;

                info[0].paras = new int[] { (int)periodParaEd.Value};
                info[0].color = new Color[] { aroonoscColorEd.Color };
                info[0].weight = (byte)aroonWeightEd.Value;
                return info;
            }
            set
            {
                inNewPaneChk.Checked = value[0].inNewWindows;

                periodParaEd.Value = value[0].paras[0];                
                aroonoscColorEd.Color = value[0].color[0];
                aroonWeightEd.Value = value[0].weight;
            }
        }
    }
}
