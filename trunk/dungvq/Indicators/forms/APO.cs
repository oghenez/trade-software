using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TicTacTec.TA.Library;
using ZedGraph;
using application;

namespace Indicators.forms
{
    public partial class APO : baseIndicatorForm
    {
        public APO(Type indicatorType)
            : base(indicatorType)
        {
            InitializeComponent();
            apoColorEd.LoadColors();
            this.apoColorEd.Color = Color.Red;
        }
        public override IndicatorFormInfo Info
        {
            get
            {
                IndicatorFormInfo info = new IndicatorFormInfo();
                info.inNewWindows = inNewPaneChk.Checked;
                info.chartType = AppTypes.ChartTypes.Line;

                info.paras = new int[] { (int)fastperiodParaEd.Value, (int)slowperiodparaEd.Value, (int)maTypePara.SelectedIndex};
                info.color = new Color[] { apoColorEd.Color };
                info.weight = (byte)apoWeightEd.Value;

                return info;
            }
            set
            {
                inNewPaneChk.Checked = value.inNewWindows;
                fastperiodParaEd.Value = value.paras[0];
                slowperiodparaEd.Value = value.paras[1];
                maTypePara.SelectedIndex = value.paras[2];

                apoColorEd.Color = value.color[0];
                apoWeightEd.Value = value.weight;
            }
        }        
    }
}
