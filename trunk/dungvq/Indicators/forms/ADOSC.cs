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
        public override IndicatorFormInfo Info
        {
            get
            {
                IndicatorFormInfo info = new IndicatorFormInfo();
                info.inNewWindows = inNewPaneChk.Checked;
                info.chartType = AppTypes.ChartTypes.Line;

                info.paras = new int[] { (int)fastParaEd.Value, (int)slowParaEd.Value };
                info.color = new Color[] { adoscColorEd.Color };
                info.weight = (byte)adoscWeightEd.Value;
                return info;
            }
            set
            {
                inNewPaneChk.Checked = value.inNewWindows;
                fastParaEd.Value = value.paras[0];
                slowParaEd.Value = value.paras[1];
                
                adoscColorEd.Color = value.color[0];
                adoscWeightEd.Value = value.weight;
            }
        }
    }
}
