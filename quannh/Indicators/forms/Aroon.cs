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
    public partial class Aroon : baseIndicatorForm
    {
        public Aroon(Type indicatorType)
            : base(indicatorType)
        {
            InitializeComponent();
            aroonUpColorEd.LoadColors();
            aroonDownColorEd.LoadColors();            
            this.aroonUpColorEd.Color = Color.Blue;
            this.aroonDownColorEd.Color = Color.Red;
        }
        public override IndicatorFormInfo[] Info
        {
            get
            {
                IndicatorFormInfo[] info = new IndicatorFormInfo[1];
                info[0] = new IndicatorFormInfo();
                info[0].inNewWindows = inNewPaneChk.Checked;
                info[0].chartType = AppTypes.ChartTypes.Line;

                info[0].paras = new int[] { (int)fastParaEd.Value};
                info[0].color = new Color[] { aroonUpColorEd.Color };
                info[0].weight = (byte)aroonUpWeightEd.Value;

                return info;
            }
            set
            {
                inNewPaneChk.Checked = value[0].inNewWindows;
                fastParaEd.Value = value[0].paras[0];                
                aroonUpColorEd.Color = value[0].color[0];
                aroonUpWeightEd.Value = value[0].weight;
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

                info[0].paras = new int[] { };
                info[0].color = new Color[] { aroonDownColorEd.Color };
                info[0].weight = (byte)aroonDownWeightEd.Value;
                
                return info;
            }
        }
    }
}
