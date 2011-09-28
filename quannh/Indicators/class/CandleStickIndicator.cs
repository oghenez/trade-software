using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacTec.TA.Library;
using application;

namespace Indicators
{
    public class EveningStarHelper : IndicatorHelper
    {
        public EveningStarHelper()
        {
            Init(typeof(EveningStar), typeof(forms.EveningStar), Consts.constIndicatorMetaFile, typeof(DataBars));
        }
    }
    class EveningStar:DataSeries
    {
        /// <summary>
        /// Static method to create AD DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static EveningStar Series(DataBars ds, int optInPenetration, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (EveningStar)obj;

            //Create AD, cache it, return it
            EveningStar ad = new EveningStar(ds,optInPenetration, description);
            ds.Cache.Add(description, ad);
            return ad;            
        }

        /// <summary>
        /// Calculation of Chaikin A/D Line indicators
        /// </summary>
        /// <param name="db">data to calculate AD</param>        
        /// <param name="name"></param>
        public EveningStar(DataBars db, int optInPenetration, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Close.Count];

            //retCode = Core.CdlDoji(0, db.Close.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values,optInPenetration, out begin, out length, output);
            //okretCode = Core.CdlDoji(0, db.Close.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);
            //okretCode = Core.CdlEngulfing(0, db.Close.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);
            //okParam=0; retCode = Core.CdlMorningStar(0, db.Close.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, optInPenetration, out begin, out length, output);
            //OKParam=0retCode = Core.CdlEveningStar(0, db.Close.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values, optInPenetration, out begin, out length, output);
            retCode = Core.CdlMarubozu(0, db.Close.Count - 1, db.Open.Values, db.High.Values, db.Low.Values, db.Close.Values,  out begin, out length, output);
            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    
    }
}
