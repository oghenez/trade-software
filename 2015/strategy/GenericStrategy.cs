using application;
using application.Strategy;
using commonTypes;
using commonClass;

namespace Strategy
{
    /// <summary>
    /// The base of all Quantum strategy
    /// </summary>
    public class GenericStrategy:baseStrategy
    {
        /// <summary>
        /// data
        /// </summary>
        public AnalysisData data;
        //Parameters for strategy
        public Parameters parameters;

        /// <summary>
        /// Advice info
        /// </summary>
        public StrategyData.TradePoints adviceInfo=null;

        /// <summary>
        /// check if there is bought position
        /// </summary>
        public bool is_bought = false;

        /// <summary>
        /// the last transaction position
        /// </summary>
        public int last_position;

        /// <summary>
        /// bought price
        /// </summary>
        public double buy_price;

        /// <summary>
        /// trailing stop
        /// </summary>
        public double trailing_stop;

        /// <summary>
        /// constructor
        /// </summary>
        public GenericStrategy()
        {
            if (adviceInfo==null)
                adviceInfo = new StrategyData.TradePoints(); 
        }

        /// <summary>
        /// Constructor with all data
        /// </summary>
        /// <param name="d"></param>
        public GenericStrategy(AnalysisData d)
        {
            this.data = d;
            this.adviceInfo = new StrategyData.TradePoints();
            this.last_position = 0;
            this.trailing_stop = -1;
        }

        /// <summary>
        /// Constructor with all data and parameter
        /// </summary>
        /// <param name="d"></param>
        /// <param name="p"></param>
        public GenericStrategy(AnalysisData d, Parameters p)
        {
            this.data = d;
            this.parameters = p;
            if (adviceInfo == null)
                this.adviceInfo = new StrategyData.TradePoints();
            this.last_position = 0;
            this.trailing_stop = -1;
        }

        /// <summary>
        /// Select Stock with information about trend and everything
        /// </summary>
        /// <param name="index"></param>
        /// <param name="info"></param>
        public void SelectStock(int index, BusinessInfo info)
        {
            adviceInfo.Add(AppTypes.TradeActions.Select, index, info);
            is_bought = true;
            last_position = index;
            buy_price = data.Close[index];
        }

        /// <summary>
        /// Buy at index with close price at index
        /// </summary>
        /// <param name="index"></param>
        public void BuyAtClose(int index)
        {
            adviceInfo.Add(AppTypes.TradeActions.Buy, index);
            is_bought = true;
            last_position = index;
            buy_price=data.Close[index];
        }

        /// <summary>
        /// Buy at close with info
        /// </summary>
        /// <param name="index"></param>
        /// <param name="info"></param>
        public void BuyAtClose(int index, BusinessInfo info)
        {
            adviceInfo.Add(AppTypes.TradeActions.Buy, index,info);
            is_bought = true;
            last_position = index;
            buy_price = data.Close[index];
        }

        /// <summary>
        ///Sell at index with close price at index 
        /// </summary>
        /// <param name="index"></param>
        public void SellAtClose(int index)
        {
            is_bought = false;
            adviceInfo.Add(AppTypes.TradeActions.Sell, index);
            last_position = index;
        }

        /// <summary>
        /// Sell at Close
        /// </summary>
        /// <param name="index"></param>
        /// <param name="info"></param>
        public void SellAtClose(int index, BusinessInfo info)
        {
            is_bought = false;
            adviceInfo.Add(AppTypes.TradeActions.Sell, index,info);
            last_position = index;
        }

        /// <summary>
        ///Sell cut loss at index with close price at index 
        /// </summary>
        /// <param name="index"></param>
        public void SellCutLoss(int index)
        {
            is_bought = false;
            adviceInfo.Add(AppTypes.TradeActions.Sell, index);
            last_position = index;
        }

        /// <summary>
        ///Sell cut loss at index with close price at index 
        /// </summary>
        /// <param name="index"></param>
        public void SellTakeProfit(int index)
        {
            is_bought = false;
            adviceInfo.Add(AppTypes.TradeActions.Sell, index);
            last_position = index;
        }

        /// <summary>
        /// Accumulate at Close
        /// </summary>
        /// <param name="index"></param>
        public void AccumulateAtClose(int index)
        {
            is_bought = true;
            adviceInfo.Add(AppTypes.TradeActions.Accumulate, index);
            last_position = index;
        }

        /// <summary>
        /// Accumulate with info
        /// </summary>
        /// <param name="index"></param>
        /// <param name="info"></param>
        public void AccumulateAtClose(int index, BusinessInfo info)
        {
            is_bought = true;
            adviceInfo.Add(AppTypes.TradeActions.Accumulate, index, info);
            last_position = index;
        }

        /// <summary>
        /// Reduce
        /// </summary>
        /// <param name="index"></param>
        public void ReduceAtClose(int index)
        {
            //adviceInfo.Add(AppTypes.TradeActions.Reduce,index);
        }

        /// <summary>
        /// Reduce
        /// </summary>
        /// <param name="index"></param>
        public void ReduceAtClose(int index, BusinessInfo info)
        {
            //adviceInfo.Add(AppTypes.TradeActions.Reduce,index,info);
        }

        virtual protected void StrategyExecute(){
        }

        protected bool CutLossCondition(double actual_price, double buy_price, double cutlosslevel)
        {
            double distanceStopLoss = 0;

            //Cut loss Condition
            if (buy_price > 0)
                distanceStopLoss = (actual_price - buy_price) / buy_price * 100;
            else
                distanceStopLoss = 0;
            if (distanceStopLoss <= -cutlosslevel)
                return true;
            return false;
        }

        /// <summary>
        /// Condition for Taking Profit
        /// </summary>
        /// <param name="actual_price"></param>
        /// <param name="buy_price"></param>
        /// <param name="take_profit_level"></param>
        /// <returns></returns>
        protected bool TakeProfitCondition(double actual_price, double buy_price, double take_profit_level)
        {
            double distanceStopLoss = 0;

            //Take Profit Condition
            if (buy_price > 0)
                distanceStopLoss = (actual_price - buy_price) / buy_price * 100;
            else
                distanceStopLoss = 0;
            if (distanceStopLoss > take_profit_level)
                return true;
            return false;
        }

        protected void TrailingStopWithBuyBack(Rule rule,double price,double trailingstoplevel,int idx)
        {
            //Trailing stop strategtest
            double new_trailing_stop = data.Close[idx] * (1 - trailingstoplevel / 100);
            if (new_trailing_stop > trailing_stop)
            {
                trailing_stop = new_trailing_stop;
                //Buy back share if 
                if ((!is_bought) && rule.UpTrend(idx)) BuyAtClose(idx);
            }
            else
                if (data.Close[idx] < trailing_stop)
                {
                    SellTakeProfit(idx);
                    trailing_stop = -1;
                }
        }
        //virtual public TradePoints Execute(AnalysisData data, double[] paras)
        virtual public StrategyData.TradePoints Execute(AnalysisData data, double[] paras)
        {
            this.data = data;
            parameters = new Parameters(paras);
            //??Bug fixed by Dung 11 Nov 2011
            //if (adviceInfo == null)
            //    this.adviceInfo = new StrategyStrategyData.TradePoints();
            adviceInfo = new StrategyData.TradePoints();
            StrategyExecute();
            return adviceInfo;
        }
        
        //Trading rule with cut loss strategy
        virtual public StrategyData.TradePoints Execute_CutLoss()
        {
            return null;
        }

        //Trading rule with taking profit strategy
        virtual public StrategyData.TradePoints Execute_TakeProfit()
        {
            return null;
        }

        //Trading rule with full money management strategy
        virtual public StrategyData.TradePoints Execute_MoneyManagement()
        {
            return null;
        }
    }    
}
