using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

using commonClass;

namespace application.forms
{
    /// <summary>
    /// To use this form in the MACD indicator, specifies it in the helper, MACDHelper()
    /// with Init(typeof(MACD), typeof(forms.MACD));
    /// </summary>
    public partial class sampleMACD : baseIndicatorForm 
    {
        public sampleMACD(Indicators.Meta meta) : base(meta)  
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
        protected override void CollectMetaData(Indicators.Meta meta)
        {
            meta.Parameters = new double[] { (int)fastParaEd.Value, (int)slowParaEd.Value, (int)signalParaEd.Value };
            meta.DrawInNewWindow = inNewPaneChk.Checked;

            meta.Output = new Indicators.Meta.OutputInfo[3];
            meta.Output[0].ChartType = AppTypes.ChartTypes.Line;
            meta.Output[0].Color = macdColorEd.Color;
            meta.Output[0].Weight = (byte)macdWeightEd.Value;

            meta.Output[1].ChartType = AppTypes.ChartTypes.Line;
            meta.Output[1].Color = signalColorEd.Color;
            meta.Output[1].Weight = (byte)sigWeightEd.Value;

            meta.Output[2].ChartType = AppTypes.ChartTypes.Bar;
            meta.Output[2].Color =  histColorCb.Color;
            meta.Output[2].Weight = (byte)histWeightEd.Value;
        }
    }
}
