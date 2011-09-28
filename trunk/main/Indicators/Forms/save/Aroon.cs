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
        public Aroon(Meta meta)
            : base(meta)
        {
            InitializeComponent();
            aroonUpColorEd.LoadColors();
            aroonDownColorEd.LoadColors();            
            this.aroonUpColorEd.Color = Color.Blue;
            this.aroonDownColorEd.Color = Color.Red;
        }
        public override IndicatorFormInfo Info
        {
            get
            {
                IndicatorFormInfo info = new IndicatorFormInfo();
                info.inNewWindows = inNewPaneChk.Checked;
                info.chartType = AppTypes.ChartTypes.Line;

                info.paras = new int[] { (int)fastParaEd.Value};
                info.color = new Color[] { aroonUpColorEd.Color };
                info.weight = (byte)aroonUpWeightEd.Value;
                return info;
            }
            set
            {
                inNewPaneChk.Checked = value.inNewWindows;
                fastParaEd.Value = value.paras[0];                
                aroonUpColorEd.Color = value.color[0];
                aroonUpWeightEd.Value = value.weight;
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
                info[0].color = new Color[] { aroonDownColorEd.Color };
                info[0].weight = (byte)aroonDownWeightEd.Value;
                
                return info;
            }
        }
    }
}
