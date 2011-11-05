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

        virtual public bool isValid()
        {
            return false;
        }

        virtual public bool isValid(int index)
        {
            return false;
        }

        virtual public bool UpTrend(int index)
        {
            return false;
        }

        virtual public bool DownTrend(int index)
        {
            return false;
        }

        virtual public bool isValid_forBuy(int index)
        {
            return false;
        }

        virtual public bool isValid_forSell(int index)
        {
            return false;
        }
    }    


}
