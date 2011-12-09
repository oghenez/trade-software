using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace baseClass.forms
{
    public partial class baseEstimateAdvice : common.forms.baseDialogForm
    {
        private int saveWidth = 0,saveHeight=0;
        public baseEstimateAdvice()
        {
            InitializeComponent();
            dataGrid.DisableReadOnlyColumn = false;
            saveWidth = this.Width;
            saveHeight = this.Height;
        }
        private bool fShowChart
        {
            get { return chartPnl.Visible; }
            set 
            {
                chartPnl.Visible = value;
                dataGrid.Height = this.ClientRectangle.Height - toolBoxPnl.Height - (value ? chartPnl.Height : 0);
            }
        }
        private Analysis.AnalysisResult myTradeAdvices = null;
        private Data myAnalysisData = null;

        public void Init(Data data,
                         Analysis.AnalysisResult advices)
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
            EstimateAdvice(this.myAnalysisData, this.myTradeAdvices, new Analysis.EstimateOptions(),myTmpDS.tradeEstimate);
            DoFilter();
            estimateChart.DataBind();
        }
        private void DoFilter()
        {
            if (showTransOnlyChk.Checked)
                tradeEstimateSource.Filter = myTmpDS.tradeEstimate.ignoredColumn.ColumnName + "=0";
            else tradeEstimateSource.Filter = "";
            countLbl.Text = tradeEstimateSource.Count.ToString("###,###,###,##0");
        }
        private void FormResize()
        {
            this.Width = this.saveWidth;
            if (this.ClientRectangle.Height < dataGrid.Location.Y) this.Height = this.saveHeight;
            dataGrid.Size = new Size(this.ClientRectangle.Width, toolBoxPnl.Location.Y - dataGrid.Location.Y);
            toolBoxPnl.Location = new Point(0, this.ClientRectangle.Height - toolBoxPnl.Height);
            chartPnl.Location = new Point(0, toolBoxPnl.Location.Y - chartPnl.Height);
            this.fShowChart = this.fShowChart;
        }

        protected virtual void EstimateAdvice(Data data,
                                              Analysis.AnalysisResult advices, 
                                              Analysis.EstimateOptions options,
                                              data.tmpDS.tradeEstimateDataTable toTbl)
        {
            Analysis.EstimateAdvice(data,advices, options, toTbl);
        }


        #region event handler
        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message);
        }
        private void baseAdviceEstimate_myOnAccept(object sender,common.baseDialogEvent e)
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
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void refreshBtn_Click(object sender, EventArgs e)
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

        private void chartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                fShowChart = !fShowChart;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void optionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                interfaces.ShowEstimateOptionForm();
                ReLoad();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void closeThisBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
