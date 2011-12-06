using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace baseClass.forms
{
    public partial class chartProperties : baseDialogForm  
    {
        public chartProperties()
        {
            try
            {
                InitializeComponent();
                this.myOnProcess += new onProcess(ProcessHandler);  
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("property");

            colorPg.Text = Languages.Libs.GetString("color");
            backgroundLbl.Text = Languages.Libs.GetString("background");
            foreGroundLbl.Text = Languages.Libs.GetString("foreground");
            gridLbl.Text = Languages.Libs.GetString("grid");
            barUpLbl.Text = Languages.Libs.GetString("barUp");
            barDnLbl.Text = Languages.Libs.GetString("barDn");
            bullCandleLbl.Text = Languages.Libs.GetString("bullCandle");
            bearCandleLbl.Text = Languages.Libs.GetString("bearCandle");
            lineGraphLbl.Text = Languages.Libs.GetString("lineGraph");
            volumeLbl.Text = Languages.Libs.GetString("volume");

            chartPg.Text = Languages.Libs.GetString("chart");
            showGridChk.Text = Languages.Libs.GetString("showGrid");
            showVolumeChk.Text = Languages.Libs.GetString("showVolume");
            showDescriptionChk.Text = Languages.Libs.GetString("showDescription");
            showLegendChk.Text = Languages.Libs.GetString("showLegend");
            scaleMetricChk.Text = Languages.Libs.GetString("scaleMetric");
            xScaleLbl.Text = Languages.Libs.GetString("xScale");
            yScaleLbl.Text = Languages.Libs.GetString("yScale");

            panMetricChk.Text = Languages.Libs.GetString("panMetric");
            xPanLbl.Text = Languages.Libs.GetString("xPan");
            yPanLbl.Text = Languages.Libs.GetString("yPan");
        }

        public static chartProperties GetForm(string formName)
        {
            string cacheKey = typeof(chartProperties).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            chartProperties form = (chartProperties)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new chartProperties();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }

        protected override bool LoadConfigure()
        {
            bgColorCb.Color = commonClass.Settings.sysChartBgColor;
            fgColorCb.Color = commonClass.Settings.sysChartFgColor;
            gridColorCb.Color = commonClass.Settings.sysChartGridColor;

            volumesColorCb.Color = commonClass.Settings.sysChartVolumesColor;
            lineCandleColorCb.Color = commonClass.Settings.sysChartLineCandleColor;
            bearCandleColorCb.Color = commonClass.Settings.sysChartBearCandleColor;
            bullCandleColorCb.Color = commonClass.Settings.sysChartBullCandleColor;
            barDnColorCb.Color = commonClass.Settings.sysChartBarDnColor;
            barUpColorCb.Color = commonClass.Settings.sysChartBarUpColor;

            showDescriptionChk.Checked = commonClass.Settings.sysChartShowDescription;
            showVolumeChk.Checked = commonClass.Settings.sysChartShowVolume;
            showGridChk.Checked = commonClass.Settings.sysChartShowGrid;
            showLegendChk.Checked = commonClass.Settings.sysChartShowLegend;

            scaleMetricChk.Checked = commonClass.Settings.sysChartAutoScaleMetric;
            panMetricChk.Checked = commonClass.Settings.sysChartAutoPanMetric;
            yScaleEd.Value = commonClass.Settings.sysChartYScaleMetric;
            xScaleEd.Value = commonClass.Settings.sysChartXScaleMetric;
            yPanEd.Value = commonClass.Settings.sysChartXPanMetric;
            xPanEd.Value = commonClass.Settings.sysChartYPanMetric;
            return true;
        }
        protected override bool SaveConfigure()
        {
            commonClass.Settings.sysChartBgColor = bgColorCb.Color;
            commonClass.Settings.sysChartFgColor = fgColorCb.Color;
            commonClass.Settings.sysChartGridColor = gridColorCb.Color;

            commonClass.Settings.sysChartVolumesColor = volumesColorCb.Color;
            commonClass.Settings.sysChartLineCandleColor = lineCandleColorCb.Color;
            commonClass.Settings.sysChartBearCandleColor = bearCandleColorCb.Color;
            commonClass.Settings.sysChartBullCandleColor = bullCandleColorCb.Color;
            commonClass.Settings.sysChartBarDnColor = barDnColorCb.Color;
            commonClass.Settings.sysChartBarUpColor = barUpColorCb.Color;

            commonClass.Settings.sysChartShowDescription = showDescriptionChk.Checked;
            commonClass.Settings.sysChartShowVolume = showVolumeChk.Checked;
            commonClass.Settings.sysChartShowGrid = showGridChk.Checked;
            commonClass.Settings.sysChartShowLegend = showLegendChk.Checked;

            commonClass.Settings.sysChartAutoScaleMetric = scaleMetricChk.Checked;
            commonClass.Settings.sysChartAutoPanMetric = panMetricChk.Checked;
            commonClass.Settings.sysChartYScaleMetric = yScaleEd.Value;
            commonClass.Settings.sysChartXScaleMetric = xScaleEd.Value;
            commonClass.Settings.sysChartXPanMetric = yPanEd.Value;
            commonClass.Settings.sysChartYPanMetric = xPanEd.Value;
            application.Configuration.Save_Local_Settings_CHART();
            return true;
        }

        protected override bool BeforeAcceptProcess()
        {
            bool retVal = true;
            ClearNotifyError();
            return retVal;
        }
        private void ProcessHandler(object sender,common.baseDialogEvent e)
        {
            if (e.isCloseClick) return;
            myFormStatus.acceptClose = true;
            SaveConfigure();
        }

        private void scaleMetricChk_CheckedChanged(object sender, EventArgs e)
        {
            xScaleEd.Enabled = scaleMetricChk.Checked;
            yScaleEd.Enabled = scaleMetricChk.Checked;
        }

        private void panMetricChk_CheckedChanged(object sender, EventArgs e)
        {
            xPanEd.Enabled = panMetricChk.Checked;
            yPanEd.Enabled = panMetricChk.Checked;
        }
    }    
}