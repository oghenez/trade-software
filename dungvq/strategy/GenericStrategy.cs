using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace strategy
{
    /// <summary>
    /// Generic Strategy class
    /// </summary>
    public class GenericStrategy
    {
        //data
        public analysis.workData data;
        public string strategyCode;
        protected bool fExportData = false;
        protected string curStrategyCode = "";
        //Parameters for strategy
        public Parameters parameters;

        //Advice info
        public analysis.analysisResult adviceInfo;
        public bool is_bought = false;
        public int last_position;

        public GenericStrategy()
        { 
            adviceInfo = new analysis.analysisResult(); 
        }

        public GenericStrategy(analysis.workData d, string code, bool fExport, string curStrategy)
        {
            data = d;
            strategyCode = code;
            fExportData = fExport;
            curStrategyCode = curStrategy;
            adviceInfo = new analysis.analysisResult();
            last_position = 0;
        }

        public GenericStrategy(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p)
        {
            data = d;
            strategyCode = code;
            fExportData = fExport;
            curStrategyCode = curStrategy;
            parameters = p;
            adviceInfo = new analysis.analysisResult();
            last_position = 0;
        }

        //
        public void SelectStock(int index,analysis.tradePointInfo info)
        {
            adviceInfo.Add(analysis.tradeActions.Buy, index,info);
            is_bought = true;
            last_position = index;
        }

        //Buy at index with close price at index
        public void BuyAtClose(int index)
        {
            adviceInfo.Add(analysis.tradeActions.Buy, index);
            is_bought = true;
            last_position = index;
        }

        //Sell at index with close price at index
        public void SellAtClose(int index)
        {
            is_bought = false;
            adviceInfo.Add(analysis.tradeActions.Sell, index);
            last_position = index;
        }

        virtual public analysis.analysisResult Screening()
        {
            ScreeningExecute();
            return adviceInfo;
        }

        virtual protected void ScreeningExecute()
        {
        }

        virtual protected void StrategyExecute(){
        }

        virtual public analysis.analysisResult Execute()
        {
            StrategyExecute();
            return adviceInfo;
            //return null;
        }

        //Trading rule with cut loss strategy
        virtual public analysis.analysisResult Execute_CutLoss()
        {
            return null;
        }

        //Trading rule with taking profit strategy
        virtual public analysis.analysisResult Execute_TakeProfit()
        {
            return null;
        }

        //Trading rule with full money management strategy
        virtual public analysis.analysisResult Execute_MoneyManagement()
        {
            return null;
        }
    }
}
