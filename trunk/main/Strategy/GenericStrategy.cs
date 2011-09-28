using application;

namespace Strategy
{
    public class GenericStrategy:baseStrategy
    {
        /// <summary>
        /// data
        /// </summary>
        public application.Data data;
        //Parameters for strategy
        public Parameters parameters;

        /// <summary>
        /// Advice info
        /// </summary>
        public TradePoints adviceInfo=null;
        public bool is_bought = false;
        public int last_position;
        public double buy_price;

        /// <summary>
        /// constructor
        /// </summary>
        public GenericStrategy()
        {
            if (adviceInfo==null)
                adviceInfo = new TradePoints(); 
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="d"></param>
        public GenericStrategy(application.Data d)
        {
            this.data = d;
            this.adviceInfo = new TradePoints();
            this.last_position = 0;
        }

        public GenericStrategy(application.Data d, Parameters p)
        {
            this.data = d;
            this.parameters = p;
            if (adviceInfo == null) 
                this.adviceInfo = new TradePoints();
            this.last_position = 0;
        }

        /// <summary>
        /// Select Stock with information about trend and everything
        /// </summary>
        /// <param name="index"></param>
        /// <param name="info"></param>
        public void SelectStock(int index,BusinessInfo info)
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
        public void ReduceAtClose(int index,  BusinessInfo info)
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

        virtual public TradePoints Execute(application.Data data, int[] paras)
        {
            this.data = data;
            parameters = new Parameters(paras);
            if (adviceInfo==null)
                adviceInfo = new TradePoints();
            StrategyExecute();
            return adviceInfo;
        }
        
        //Trading rule with cut loss strategy
        virtual public TradePoints Execute_CutLoss()
        {
            return null;
        }

        //Trading rule with taking profit strategy
        virtual public TradePoints Execute_TakeProfit()
        {
            return null;
        }

        //Trading rule with full money management strategy
        virtual public TradePoints Execute_MoneyManagement()
        {
            return null;
        }
    }    
}
