using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;

namespace application
{
    public class wsData
    {
        [DataContract]
        public class EstimateOptions
        {
            [DataMember]
            public decimal TotalCapAmt = application.Settings.sysStockTotalCapAmt;
            [DataMember]
            public decimal MaxBuyAmtPerc = application.Settings.sysStockMaxBuyAmtPerc;
            [DataMember]
            public decimal QtyReducePerc = application.Settings.sysStockReduceQtyPerc;
            [DataMember]
            public decimal QtyAccumulatePerc = application.Settings.sysStockAccumulateQtyPerc;
            [DataMember]
            public decimal TransFeecPerc = application.Settings.sysStockTransFeePercent;
            [DataMember]
            public decimal PriceWeight = application.Settings.sysStockPriceWeight;
            [DataMember]
            public decimal MaxBuyQtyPerc = application.Settings.sysStockMaxBuyQtyPerc;
            [DataMember]
            public short Buy2SellInterval = application.Settings.sysStockSell2BuyInterval;

            public EstimateOptions()
            {
                Init();
            }

            private void Init()
            {
                this.TotalCapAmt = application.Settings.sysStockTotalCapAmt;
                this.MaxBuyAmtPerc = application.Settings.sysStockMaxBuyAmtPerc;
                this.QtyReducePerc = application.Settings.sysStockReduceQtyPerc;
                this.QtyAccumulatePerc = application.Settings.sysStockAccumulateQtyPerc;
                this.TransFeecPerc = application.Settings.sysStockTransFeePercent;
                this.PriceWeight = application.Settings.sysStockPriceWeight;
                this.MaxBuyQtyPerc = application.Settings.sysStockMaxBuyQtyPerc;
                this.Buy2SellInterval = application.Settings.sysStockSell2BuyInterval;
            }

            //See http://social.msdn.microsoft.com/forums/en-US/wcf/thread/447149d5-b44c-47cd-a690-20928244b52b/
            [OnDeserialized]
            public void OnDeserialized(StreamingContext context)
            {
                Init();
            }
        }

        /// <summary>
        /// Forcasting information (market,priority...) generated from analysis process    
        /// </summary>

        [DataContract]
        public class BusinessInfo
        {
            public BusinessInfo() { }
            public BusinessInfo(AppTypes.MarketTrend shortTerm, AppTypes.MarketTrend mediumTerm, AppTypes.MarketTrend longTerm, double weight)
            {
                this.ShortTermTrend = shortTerm;
                this.MediumTermTrend = mediumTerm;
                this.LongTermTrend = longTerm;
                this.Weight = weight;
            }
            public void Set(BusinessInfo info)
            {
                this.ShortTermTrend = info.ShortTermTrend;
                this.MediumTermTrend = info.MediumTermTrend;
                this.LongTermTrend = info.LongTermTrend;
                this.Weight = info.Weight;
            }
            public void SetTrend(AppTypes.MarketTrend shortTerm, AppTypes.MarketTrend mediumTerm, AppTypes.MarketTrend longTerm)
            {
                this.ShortTermTrend = shortTerm;
                this.MediumTermTrend = mediumTerm;
                this.LongTermTrend = longTerm;
            }

            public string BusinessInfoText()
            {
                string st = "";
                switch (ShortTermTrend)
                {
                    case (AppTypes.MarketTrend.Upward):
                        st = st + "Short term trend is upward. ";
                        break;
                    case AppTypes.MarketTrend.Downward:
                        st = st + "Short term trend is downward. ";
                        break;
                    case AppTypes.MarketTrend.Sidebar:
                        st = st + "Short term trend is sideway. ";
                        break;
                    case AppTypes.MarketTrend.Unspecified:
                        //st =st+ "Short term trend is unspecified. ";
                        break;
                    default:
                        break;
                }
                switch (MediumTermTrend)
                {
                    case (AppTypes.MarketTrend.Upward):
                        st = st + "Medium term trend is upward. ";
                        break;
                    case AppTypes.MarketTrend.Downward:
                        st = st + "Medium term trend is downward. ";
                        break;
                    case AppTypes.MarketTrend.Sidebar:
                        st = st + "Medium term trend is sideway. ";
                        break;
                    case AppTypes.MarketTrend.Unspecified:
                        //st =st+ "Medium term trend is unspecified.";
                        break;
                    default:
                        break;
                }
                switch (LongTermTrend)
                {
                    case (AppTypes.MarketTrend.Upward):
                        st = st + "Long term trend is upward. ";
                        break;
                    case AppTypes.MarketTrend.Downward:
                        st = st + "Long term trend is downward. ";
                        break;
                    case AppTypes.MarketTrend.Sidebar:
                        st = st + "Long term trend is sideway. ";
                        break;
                    case AppTypes.MarketTrend.Unspecified:
                        //st = "Long term trend is unspecified.";
                        break;
                    default:
                        break;
                }

                if (Short_Target != 0)
                    st += "Short Term Target is " + Short_Target.ToString() + ". ";

                if (Stop_Loss != 0)
                    st += "Stop loss is " + Stop_Loss.ToString() + ".";

                if (Short_Resistance != 0)
                    st += "Short term resistance is " + Short_Resistance.ToString() + ".";
                if (Short_Support != 0)
                    st += " Short term support is " + Short_Support.ToString() + ".";
                return st;
            }

            [DataMember]
            public AppTypes.MarketTrend LongTermTrend = AppTypes.MarketTrend.Unspecified;

            [DataMember]
            public AppTypes.MarketTrend MediumTermTrend = AppTypes.MarketTrend.Unspecified;

            [DataMember]
            public AppTypes.MarketTrend ShortTermTrend = AppTypes.MarketTrend.Unspecified;
            [DataMember]
            public double Short_Target = 0;
            [DataMember]
            public double Stop_Loss = 0;
            [DataMember]
            public double Short_Resistance = 0;
            [DataMember]
            public double Short_Support = 0;
            [DataMember]
            public double Weight = 0;
        }

        [DataContract]
        public class TradePointInfo
        {
            public TradePointInfo() { }
            public TradePointInfo(AppTypes.TradeActions action, int dataIdx)
            {
                this.TradeAction = action;
                this.DataIdx = dataIdx;
            }
            public TradePointInfo(AppTypes.TradeActions action, int dataIdx, BusinessInfo info)
            {
                this.TradeAction = action;
                this.DataIdx = dataIdx;
                this.BusinessInfo.Set(info);
            }
            //TradePoint can be estimated by some way to decide whether the trade point is valid. 
            [DataMember]
            public bool isValid = true;

            // Data position where the trade point occured.
            // The index is used to get data (closePrice,openPrice...) of a trade point.
            [DataMember]
            public int DataIdx = 0;

            [DataMember]
            public AppTypes.TradeActions TradeAction = AppTypes.TradeActions.None;

            [DataMember]
            public BusinessInfo BusinessInfo = new BusinessInfo();
        }
    }
}
