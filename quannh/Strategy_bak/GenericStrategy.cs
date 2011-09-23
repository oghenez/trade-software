using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace Strategy
{
    public class GenericStrategy:baseStrategy
    {
        //data
        public application.Data data;
        //Parameters for strategy
        public Parameters parameters;

        //Advice info
        public TradePoints adviceInfo=null;
        public bool is_bought = false;
        public int last_position;

        public GenericStrategy()
        {
            adviceInfo = new TradePoints(); 
        }

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
            this.adviceInfo = new TradePoints();
            this.last_position = 0;
        }

        //
        public void SelectStock(int index,BusinessInfo info)
        {
            adviceInfo.Add(AppTypes.TradeActions.Buy, index, info);
            is_bought = true;
            last_position = index;
        }

        //Buy at index with close price at index
        public void BuyAtClose(int index)
        {
            adviceInfo.Add(AppTypes.TradeActions.Buy, index);
            is_bought = true;
            last_position = index;
        }

        //Sell at index with close price at index
        public void SellAtClose(int index)
        {
            is_bought = false;
            adviceInfo.Add(AppTypes.TradeActions.Sell, index);
            last_position = index;
        }

        virtual public TradePoints Screening()
        {
            ScreeningExecute();
            return adviceInfo;
        }

        virtual protected void ScreeningExecute()
        {
        }

        virtual protected void StrategyExecute(){
        }

        virtual public TradePoints Execute(application.Data data, int[] paras)
        {
            return null;
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

    //public class GenericStrategy_Helper : baseHelper
    //{
    //    public GenericStrategy_Helper() : base(typeof(GenericStrategy)) { }
    //}
}
