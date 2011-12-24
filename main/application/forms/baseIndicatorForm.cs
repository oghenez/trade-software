using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace application.forms
{
    public partial class baseIndicatorForm : common.forms.baseDialogForm
    {
        public Indicators.Meta FormMeta = null;
        public baseIndicatorForm()
        {
            InitializeComponent();
        }
        public baseIndicatorForm(Indicators.Meta meta)
        {
            InitializeComponent();
            Indicators.Libs.GetUserSettings(meta);
            this.FormMeta = meta;
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            okBtn.Text = Languages.Libs.GetString("draw");
            saveBtn.Text = Languages.Libs.GetString("saveSetting");
        }
        public delegate void PlotChart(baseIndicatorForm sender,bool removeChart);
        public event PlotChart onPlotChart = null;

        protected virtual void CollectMetaData(Indicators.Meta meta) { }

        protected override bool BeforeAcceptProcess() 
        { 
            this.Visible = true;
            return base.BeforeAcceptProcess();
        }

        protected virtual void SaveSettings()
        {
            CollectMetaData(this.FormMeta);
            Indicators.Libs.SaveUserSettings(this.FormMeta);
            this.ShowMessage(Languages.Libs.GetString("settingSaved"));
        }

        private void baseIndicator_myOnProcess(object sender, common.baseDialogEvent e)
        {
            CollectMetaData(this.FormMeta); 
            if (e.isCloseClick) return;
            if (onPlotChart == null) return;
            onPlotChart(this, true);
            onPlotChart(this, false);
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
