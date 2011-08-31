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
        public override IndicatorFormInfo[] Info
        {
            get
            {
                IndicatorFormInfo[] info = new IndicatorFormInfo[1];
                info[0] = new IndicatorFormInfo();
                info[0].inNewWindows = inNewPaneChk.Checked;
                info[0].chartType = myTypes.chartType.Line;

                info[0].paras = new int[] { (int)fastperiodParaEd.Value, (int)slowperiodparaEd.Value, (int)maTypePara.SelectedIndex};
                info[0].color = new Color[] { apoColorEd.Color };
                info[0].weight = (byte)apoWeightEd.Value;

                return info;
            }
            set
            {
                inNewPaneChk.Checked = value[0].inNewWindows;
                fastperiodParaEd.Value = value[0].paras[0];
                slowperiodparaEd.Value = value[0].paras[1];
                maTypePara.SelectedIndex = value[0].paras[2];

                apoColorEd.Color = value[0].color[0];
                apoWeightEd.Value = value[0].weight;
            }
        }        
    }
}
