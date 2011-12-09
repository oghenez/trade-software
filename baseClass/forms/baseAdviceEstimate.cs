using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class baseAdviceEstimate : common.forms.baseDialogForm
    {
        private int saveWidth = 0,saveHeight=0;
        public baseAdviceEstimate()
        {
            InitializeComponent();
            dataGrid.DisableReadOnlyColumn = false;
            saveWidth = this.Width;
            saveHeight = this.Height;
        }
        public decimal myInitCapitalAmt
        {
            get { return capitalAmtEd.Value;}
            set { capitalAmtEd.Value = value;}
        }
        private application.analysis.analysisResult myTradeAdvices = null;
        private application.analysis.workData myAnalysisData = null;

        public void Init(application.analysis.workData data,
                         application.analysis.analysisResult advices)
        {
            this.myAnalysisData = data;
            this.myTradeAdvices = advices;
            ReLoad();
        }
        protected void ReLoad()
        {
            if (myTradeAdvices == null)
            {
                common.system.ThrowException("No data found"); return;
            }
            EstimateAdvice(this.myAnalysisData,this.myTradeAdvices, capitalAmtEd.Value, priceWeightEd.Value, feePercEd.Value / 100, 
                           (byte)buy2SellIntervalEd.Value, myTmpDS.tradeEstimate);
            DoFilter();
            estimateChart.DataBind();
        }
        private void DoFilter()
        {
            if (showTransOnlyChk.Checked)
                tradeEstimateSource.Filter = myTmpDS.tradeEstimate.ignoredColumn.ColumnName + "=0";
            else tradeEstimateSource.Filter = "";
            countLbl.Text = tradeEstimateSource.Count.ToString("###,###,###,###,##0");
        }
        private void FormResize()
        {
            this.Width = this.saveWidth;
            if (this.ClientRectangle.Height < dataGrid.Location.Y) this.Height = this.saveHeight;
            dataGrid.Height = this.ClientRectangle.Height - dataGrid.Location.Y - estimateChart.Height;
            estimateChart.Location = new Point(0, this.ClientRectangle.Height - estimateChart.Height);
            estimateChart.Width = this.ClientRectangle.Width;
        }

        protected virtual void EstimateAdvice(application.analysis.workData data,
                                              application.analysis.analysisResult advices, 
                                              decimal initCapAmt, decimal priceWeight, decimal feePerc, byte buy2SellInterval,
                                              data.tmpDS.tradeEstimateDataTable toTbl)
        {
            application.analysis.EstimateAdvice(data,advices, initCapAmt, priceWeight, feePerc, buy2SellInterval, toTbl);
        }


        #region event handler
        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message);
        }
        private void baseAdviceEstimate_myOnAccept(object sender)
        {
            try
            {
                ReLoad();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void showTransOnlyChk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DoFilter();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void baseAdviceEstimate_Resize(object sender, EventArgs e)
        {
            try
            {
                FormResize();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void exportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
                common.Export.ExportToExcel(myTmpDS.tradeEstimate, saveFileDialog.FileName);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void baseAdviceEstimate_Load(object sender, EventArgs e)
        {
            try
            {
                FormResize();
                data.baseDS.investorDataTable investorTbl = new data.baseDS.investorDataTable();
                application.dataLibs.LoadData(investorTbl, application.sysLibs.sysLoginCode);
                if (investorTbl.Count > 0) this.myInitCapitalAmt = investorTbl[0].cashAmt;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}
