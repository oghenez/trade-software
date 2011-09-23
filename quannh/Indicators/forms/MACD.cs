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
    public partial class MACD : baseIndicatorForm 
    {
        public MACD(Type indicatorType): base(indicatorType)
        {
            InitializeComponent();
            macdColorEd.LoadColors();
            signalColorEd.LoadColors();
            histColorCb.LoadColors();
            this.macdColorEd.Color = Color.Blue;
            this.signalColorEd.Color = Color.Red;
            this.histColorCb.Color = Color.Navy;
        }
        public override IndicatorFormInfo[] Info
        {
            get 
            {
                IndicatorFormInfo[] info = new IndicatorFormInfo[1];
                info[0] = new IndicatorFormInfo();
                info[0].inNewWindows = inNewPaneChk.Checked;
                info[0].chartType = AppTypes.ChartTypes.Line;
                
                info[0].paras = new int[] { (int)fastParaEd.Value, (int)slowParaEd.Value, (int)signalParaEd.Value };
                info[0].color = new Color[] { macdColorEd.Color};
                info[0].weight = (byte)macdWeightEd.Value;
                
                return info; 
            }
            set 
            {
                inNewPaneChk.Checked = value[0].inNewWindows;
                fastParaEd.Value = value[0].paras[0];
                slowParaEd.Value = value[0].paras[1];
                signalParaEd.Value = value[0].paras[2];

                macdColorEd.Color = value[0].color[0];
                macdWeightEd.Value = value[0].weight;
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
                info[0].color = new Color[] { signalColorEd.Color };
                info[0].weight = (byte)sigWeightEd.Value;


                info[1] = new IndicatorFormInfo();
                info[1].chartType = AppTypes.ChartTypes.Bar;
                info[1].inNewWindows = inNewPaneChk.Checked;

                info[1].paras = new int[] { };
                info[1].color = new Color[] { histColorCb.Color };
                info[1].weight = (byte)histWeightEd.Value;

                return info;
            }
        }
    }
}
