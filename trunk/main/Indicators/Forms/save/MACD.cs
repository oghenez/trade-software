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
        public MACD(Meta meta) : base(meta)
        {
            InitializeComponent();
            macdColorEd.LoadColors();
            signalColorEd.LoadColors();
            histColorCb.LoadColors();

            this.macdColorEd.Color =  (meta.Output.Length>0?meta.Output[0].Color:Color.Green);
            this.signalColorEd.Color = (meta.Output.Length > 1 ? meta.Output[1].Color : Color.Red);
            this.histColorCb.Color = (meta.Output.Length > 2 ? meta.Output[2].Color : Color.Navy);

            this.macdWeightEd.Value = (meta.Output.Length > 0 ? meta.Output[0].Weight : 1);
            this.sigWeightEd.Value = (meta.Output.Length > 1 ? meta.Output[1].Weight : 1);
            this.histWeightEd.Value = (meta.Output.Length > 2 ? meta.Output[2].Weight : 1);

        }
        public override IndicatorFormInfo Info
        {
            get 
            {
                IndicatorFormInfo info = new IndicatorFormInfo();
                info.inNewWindows = inNewPaneChk.Checked;
                info.chartType = AppTypes.ChartTypes.Line;
                
                info.paras = new int[] { (int)fastParaEd.Value, (int)slowParaEd.Value, (int)signalParaEd.Value };
                info.color = new Color[] { macdColorEd.Color};
                info.weight = (byte)macdWeightEd.Value;
                
                return info; 
            }
            set 
            {
                inNewPaneChk.Checked = value.inNewWindows;
                fastParaEd.Value = value.paras[0];
                slowParaEd.Value = value.paras[1];
                signalParaEd.Value = value.paras[2];

                macdColorEd.Color = value.color[0];
                macdWeightEd.Value = value.weight;
            }
        }
        public override IndicatorFormInfo[] ExtraInfo
        {
            get
            {
                IndicatorFormInfo[] info = new IndicatorFormInfo[2];
                info[0] = new IndicatorFormInfo();
                info[1] = new IndicatorFormInfo();
                info[0].inNewWindows = inNewPaneChk.Checked;

                info[0].paras = new int[] { };
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
