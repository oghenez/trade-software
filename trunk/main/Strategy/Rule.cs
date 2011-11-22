using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace Strategy
{
    /// <summary>
    /// Class shown Rule for screening and trading strategy
    /// </summary>
    public class Rule
    {
        public Rule()
        {
        }

        /// <summary>
        /// condition for screening
        /// </summary>
        /// <returns></returns>
        virtual public bool isValid()
        {
            return false;
        }

        /// <summary>
        /// can stock be picked at index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        virtual public bool isValid(int index)
        {
            return false;
        }

        /// <summary>
        /// Determining the actual trend in the index point:UpTrend ?
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        virtual public bool UpTrend(int index)
        {
            return false;
        }


        /// <summary>
        /// Determining the actual trend in the index point:DownTrend ?
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        virtual public bool DownTrend(int index)
        {
            return false;
        }


        /// <summary>
        /// Determining the actual trend in the index point: Sideway ?
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        virtual public bool SideWay(int index)
        {
            return false;
        }

        virtual public bool Trending(int index)
        {
            return !SideWay(index);
        }

        /// <summary>
        /// satisfied the condition for BUY action ?
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        virtual public bool isValid_forBuy(int index)
        {
            return false;
        }


        /// <summary>
        /// satisfied the condition for SELL
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        virtual public bool isValid_forSell(int index)
        {
            return false;
        }
    }


    /// <summary>
    /// The composition of Rule
    /// </summary>
    public class CompositeRule : Rule
    {
        public Rule[] rules;
        public CompositeRule()
        {
            rules = null;
        }
    }
}
