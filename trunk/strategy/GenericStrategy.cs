using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace strategy
{
    /// <summary>
    /// The GenericStrategy class is the basic class for all strategy classes
    /// </summary>
    public class GenericStrategy
    {
        /// <summary> data </summary>
        public analysis.workData data;
        public string strategyCode;
        protected bool fExportData = false;
        protected string curStrategyCode = "";
 
        /// <summary>
        /// Parameters for strategy
        /// </summary>
        public Parameters parameters;

        //Advice info
        public analysis.analysisResult adviceInfo;
        public bool is_bought = false;
        public int last_position;

        /// <summary>
        /// Constructor. Always initiate advice Info
        /// </summary>
        public GenericStrategy()
        { 
            adviceInfo = new analysis.analysisResult(); 
        }

        /// <summary>
        /// Constructor which initiates the variables
        /// </summary>
        /// <param name="d"></param>
        /// <param name="code"></param>
        /// <param name="fExport"></param>
        /// <param name="curStrategy"></param>
        public GenericStrategy(analysis.workData d, string code, bool fExport, string curStrategy)
        {
            data = d;
            strategyCode = code;
            fExportData = fExport;
            curStrategyCode = curStrategy;
            adviceInfo = new analysis.analysisResult();
            last_position = 0;
        }

        /// <summary>
        /// Constructor which initiates the variables include Parameters
        /// </summary>
        /// <param name="d"></param>
        /// <param name="code"></param>
        /// <param name="fExport"></param>
        /// <param name="curStrategy"></param>
        /// <param name="p"> Parameters of the strategy </param>
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

        ///<summary> Buy at index with close price at index </summary>
        public void BuyAtClose(int index)
        {
            adviceInfo.Add(analysis.tradeActions.Buy, index);
            is_bought = true;
            last_position = index;
        }
        
        /// <summary>
        /// Sell at index with close price at index
        /// </summary>
        /// <param name="index"></param>
        public void SellAtClose(int index)
        {
            is_bought = false;
            adviceInfo.Add(analysis.tradeActions.Sell, index);
            last_position = index;
        }

        /// <summary>
        /// Using Screening the stocks following ScreeningExecute()
        /// </summary>
        /// <returns></returns>
        virtual public analysis.analysisResult Screening()
        {
            ScreeningExecute();
            return adviceInfo;
        }
        
        /// <summary>
        /// protected function for Screening 
        /// </summary>
        virtual protected void ScreeningExecute()
        {
        }

        /// <summary>
        /// protected function for strategy execute
        /// </summary>
        virtual protected void StrategyExecute(){
        }

        virtual public analysis.analysisResult Execute()
        {
            StrategyExecute();
            return adviceInfo;
            //return null;
        }

        /// <summary>
        ///Trading rule with cut loss strategy
        /// </summary>
        /// <returns></returns>
        virtual public analysis.analysisResult Execute_CutLoss()
        {
            return null;
        }

        /// <summary>
        ///Trading rule with taking profit strategy
        /// </summary>
        /// <returns></returns>
        virtual public analysis.analysisResult Execute_TakeProfit()
        {
            return null;
        }

        /// <summary>
        ///Trading rule with full money management strategy
        /// </summary>
        /// <returns></returns>
        virtual public analysis.analysisResult Execute_MoneyManagement()
        {
            return null;
        }
    }
}
