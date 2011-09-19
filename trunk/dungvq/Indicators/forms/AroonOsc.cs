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
        public override IndicatorFormInfo Info
        {
            get
            {
                IndicatorFormInfo info = new IndicatorFormInfo();
                info.inNewWindows = inNewPaneChk.Checked;
                info.chartType = AppTypes.ChartTypes.Line;

                info.paras = new int[] { (int)periodParaEd.Value};
                info.color = new Color[] { aroonoscColorEd.Color };
                info.weight = (byte)aroonWeightEd.Value;
                return info;
            }
            set
            {
                inNewPaneChk.Checked = value.inNewWindows;

                periodParaEd.Value = value.paras[0];                
                aroonoscColorEd.Color = value.color[0];
                aroonWeightEd.Value = value.weight;
            }
        }
    }
}
