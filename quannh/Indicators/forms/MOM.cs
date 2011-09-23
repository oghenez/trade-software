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
    public partial class MOM : baseIndicatorForm
    {
        public MOM(Type indicatorType)
            : base(indicatorType)
        {
            InitializeComponent();
            colorEd1.LoadColors();
            this.colorEd1.Color = Color.Blue;
        }
        public override IndicatorFormInfo[] Info
        {
            get
            {
                IndicatorFormInfo[] info = new IndicatorFormInfo[1];
                info[0] = new IndicatorFormInfo();
                info[0].chartType = AppTypes.ChartTypes.Line;
                info[0].paras = new int[] { (int)paraEd1.Value };
                info[0].color = new Color[] { colorEd1.Color };
                info[0].weight = (byte)weightEd1.Value;
                info[0].inNewWindows = inNewPaneChk.Checked;

                return info;
            }
            set
            {
                inNewPaneChk.Checked = value[0].inNewWindows;

                paraEd1.Value = value[0].paras[0];
                colorEd1.Color = value[0].color[0];
                weightEd1.Value = value[0].weight;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void colorEd1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void inNewPaneChk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void weightEd1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void paraEd1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
