using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace Tools.Forms
{
    public partial class baseTesting : baseClass.forms.baseForm
    {
        public baseTesting()
        {
            try
            {
                InitializeComponent();
                common.dialogs.SetFileDialogEXCEL(saveFileDialog);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public delegate void ShowStockFunc(string stockCode, AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale);
        public event ShowStockFunc myShowStock = null;

        public enum ValueTypes : byte { Amount,Percentage};

        private ValueTypes _valueType = ValueTypes.Amount;
        public ValueTypes myValueType
        {
            get { return _valueType; }
            set 
            {
                if (_valueType == value) return;
                switch (value)
                {
                    case ValueTypes.Amount: Percent2Amount(); break;
                    case ValueTypes.Percentage: Amount2Percent(); break;
                }
                _valueType = value;
            }
        }
        public decimal Amount2PercentDenominator = 1;
        protected virtual void Amount2Percent() { }
        protected virtual void Percent2Amount() { }

       
        protected void ShowStock(string stockCode, AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale)
        {
            if (myShowStock == null) return;
            myShowStock(stockCode, timeRange, timeScale);
        }

        protected void ShowTradeTransactions(data.tmpDS.stockCodeRow stockCodeRow, string strategyCode,
                                                 AppTypes.TimeRanges timeRange,AppTypes.TimeScale timeScale)
        {
            application.Data data = new application.Data(timeRange, timeScale, stockCodeRow.code);
            Strategy.Data.ClearCache();
            Strategy.Data.TradePoints advices = Strategy.Libs.Analysis(data, strategyCode);
            if (advices == null) return;
            string formName = data.DataStockCode.Trim() + "," + timeRange.ToString() + "," + Strategy.Libs.GetMetaName(strategyCode) + "," + timeScale.Code;
            profitEstimate myForm = profitEstimate.GetForm(formName);
            myForm.Text = "$(" + formName + ")";
            myForm.Init(data, advices);
            if (this.myDockedPane != null) myForm.Show(this.myDockedPane);
            else myForm.ShowDialog();
        }
    }
}