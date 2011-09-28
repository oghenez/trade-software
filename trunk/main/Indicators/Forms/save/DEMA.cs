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
    public partial class DEMA : baseIndicatorForm
    {
        public DEMA(Meta meta) : base(meta)
        {
            InitializeComponent();
            colorEd1.LoadColors();
            this.colorEd1.Color = Color.Blue;
        }
        public override IndicatorFormInfo Info
        {
            get
            {
                IndicatorFormInfo info = new IndicatorFormInfo();
                info = new IndicatorFormInfo();
                info = new IndicatorFormInfo();
                info.paras = new int[] { (int)paraEd1.Value };
                info.color = new Color[] { colorEd1.Color };
                info.weight = (byte)weightEd1.Value;
                info.inNewWindows = inNewPaneChk.Checked;

                return info;
            }
            set
            {
                inNewPaneChk.Checked = value.inNewWindows;

                paraEd1.Value = value.paras[0];
                colorEd1.Color = value.color[0];
                weightEd1.Value = value.weight;
            }
        }
    }
}
