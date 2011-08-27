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
    public partial class ADOSC : baseIndicatorForm
    {
        public ADOSC(Type indicatorType)
            : base(indicatorType)
        {
            InitializeComponent();
            adoscColorEd.LoadColors();            
            this.adoscColorEd.Color = Color.Blue;            
        }
        public override IndicatorFormInfo[] Info
        {
            get
            {
                IndicatorFormInfo[] info = new IndicatorFormInfo[1];
                info[0] = new IndicatorFormInfo();
                info[0].inNewWindows = inNewPaneChk.Checked;
                info[0].chartType = myTypes.chartType.Line;

                info[0].paras = new int[] { (int)fastParaEd.Value, (int)slowParaEd.Value };
                info[0].color = new Color[] { adoscColorEd.Color };
                info[0].weight = (byte)adoscWeightEd.Value;
                return info;
            }
            set
            {
                inNewPaneChk.Checked = value[0].inNewWindows;
                fastParaEd.Value = value[0].paras[0];
                slowParaEd.Value = value[0].paras[1];
                

                adoscColorEd.Color = value[0].color[0];
                adoscWeightEd.Value = value[0].weight;
            }
        }
    }
}
